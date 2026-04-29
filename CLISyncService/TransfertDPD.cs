namespace CLISyncService;

using CLICore.Data;
using FluentFTP;
using System.Globalization;
using System.Text;

/// <summary>
/// Service d'export DPD CargoNET — Format V110 (cargoNET 12/2024 v5.7c).
///
/// Pattern identique à TransfertExpeditor (Colissimo) :
///   - Poll de la base toutes les CliTransfertDPDDelay ms
///   - Filtre les commandes WEB/VPC non annulées avec IdTTransporteur = DPD
///     et ExpeditionLe >= CliDateDerniereExtractionDPD
///   - Génère un fichier texte à longueur fixe (3126 chars + CRLF par colis,
///     en-tête $VERSION=110), encodage iso-8859-1
///   - Upload FTP vers le partage Synology par environnement
///     (soDevelopement / soStaging / soProduction)
///
/// Les comptes DPD (Classic 066-7485 / Predict 066-7486 / Relais 066-7487)
/// sont sélectionnés manuellement par le vendeur dans Station.NET.
/// </summary>
public class TransfertDPD : BackgroundService
{
    private const int RECORD_LENGTH = 3126;
    private const string HEADER_LINE = "$VERSION=110";

    private readonly ILogger<Worker> _logger;
    private bool _isProcessing;
    private int _delay;
    private readonly CLIContext _cliContext;

    public TransfertDPD(ILogger<Worker> logger, IConfiguration configuration, IServiceProvider serviceProvider, CLIContext clicontext)
    {
        _logger = logger;
        _cliContext = clicontext;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (!_isProcessing)
            {
                _isProcessing = true;

                _logger.LogInformation("TransfertDPD running at: {time}", DateTimeOffset.Now);

                _delay = Convert.ToInt32(GetParam("CliTransfertDPDDelay") ?? "60000");

                try
                {
                    CultureInfo.CurrentCulture = new CultureInfo("fr-FR");

                    var idTransporteurDpd = Convert.ToInt64(GetParam("IdTTransporteurDPD") ?? "0");
                    if (idTransporteurDpd == 0)
                    {
                        _logger.LogWarning("TransfertDPD: param IdTTransporteurDPD non configuré, skip.");
                    }
                    else
                    {
                        var dateDerniereExtraction = Convert.ToDateTime(GetParam("CliDateDerniereExtractionDPD") ?? "1900-01-01");

                        var commandes = _cliContext.TCommandeVentes
                            .Where(c => (c.WebOn == true || c.VpcOn == true)
                                        && c.IdEtatCommandeVente != 90
                                        && c.IdTTransporteur == idTransporteurDpd
                                        && c.ExpeditionLe >= dateDerniereExtraction)
                            .Join(_cliContext.TPays, c => c.Pays, p => p.Libelle, (c, p) => new
                            {
                                c.IdTCommandeVente,
                                c.Prénom,
                                c.Nom,
                                c.Société,
                                c.AdresseL1,
                                c.AdresseL2,
                                c.AdresseL3,
                                p.CodePays,
                                c.CodePostal,
                                c.Ville,
                                c.Tel,
                                c.Mobile,
                                c.Email
                            })
                            .ToList();

                        if (commandes.Count > 0)
                        {
                            var sb = new StringBuilder();
                            sb.Append(HEADER_LINE);
                            sb.Append("\r\n");

                            foreach (var c in commandes)
                            {
                                sb.Append(BuildV110Record(
                                    idCommande: c.IdTCommandeVente,
                                    societe: c.Société,
                                    nom: c.Nom,
                                    prenom: c.Prénom,
                                    adresseL1: c.AdresseL1,
                                    adresseL2: c.AdresseL2,
                                    adresseL3: c.AdresseL3,
                                    codePostal: c.CodePostal,
                                    ville: c.Ville,
                                    codePays: string.IsNullOrEmpty(c.CodePays) ? "FR" : c.CodePays,
                                    tel: c.Tel,
                                    mobile: c.Mobile,
                                    email: c.Email));
                                sb.Append("\r\n");
                            }

                            UploadDpdFile(sb.ToString());
                            _logger.LogInformation("TransfertDPD: {count} commande(s) exportée(s).", commandes.Count);
                        }

                        UpsertParam("CliDateDerniereExtractionDPD", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        _cliContext.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "TransfertDPD error");
                }

                _isProcessing = false;
                await Task.Delay(_delay, stoppingToken);
            }
        }
    }

    private void UploadDpdFile(string contenu)
    {
        var ftpServer = GetParam("FTP_Host_DPD");
        var ftpUser = GetParam("FTP_UID_DPD");
        var ftpPassword = GetParam("FTP_PWD_DPD");
        var ftpDirectory = GetParam("FTP_remote_path_DPD") ?? "/";
        var ftpFileNameRoot = GetParam("FTP_file_name_DPD") ?? "DPD";
        var ftpFileName = ftpFileNameRoot + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".dat";
        var ftpFullPath = ftpDirectory.EndsWith("/") ? ftpDirectory + ftpFileName : ftpDirectory + "/" + ftpFileName;

        File.WriteAllText(ftpFileName, contenu, Encoding.GetEncoding("iso-8859-1"));

        try
        {
            var ftp = new FtpClient(ftpServer, ftpUser, ftpPassword);
            ftp.UploadFile(ftpFileName, ftpFullPath);
            ftp.Disconnect();
        }
        finally
        {
            if (File.Exists(ftpFileName)) File.Delete(ftpFileName);
        }
    }

    private string? GetParam(string name)
    {
        return _cliContext.TParams.FirstOrDefault(c => c.Paramname == name)?.Paramvalue;
    }

    private void UpsertParam(string name, string value)
    {
        var p = _cliContext.TParams.FirstOrDefault(c => c.Paramname == name);
        if (p == null)
        {
            _cliContext.TParams.Add(new CLICore.Models.TParam { Paramname = name, Paramvalue = value });
        }
        else
        {
            p.Paramvalue = value;
        }
    }

    /// <summary>
    /// Construit un enregistrement V110 (3126 caractères) à longueur fixe ASCII,
    /// AN justifié à gauche (espaces).
    /// </summary>
    private static string BuildV110Record(
        long idCommande,
        string? societe, string? nom, string? prenom,
        string? adresseL1, string? adresseL2, string? adresseL3,
        string? codePostal, string? ville, string? codePays,
        string? tel, string? mobile, string? email)
    {
        var rec = new char[RECORD_LENGTH];
        for (int i = 0; i < RECORD_LENGTH; i++) rec[i] = ' ';

        var ref1 = "CLI" + idCommande.ToString("D8");
        Place(rec, 1, 35, ref1);                                  // Référence client N°1

        string nomPrincipal;
        string complement1;
        if (!string.IsNullOrWhiteSpace(societe))
        {
            nomPrincipal = societe!;
            complement1 = ((nom ?? "") + " " + (prenom ?? "")).Trim();
        }
        else
        {
            nomPrincipal = ((nom ?? "") + " " + (prenom ?? "")).Trim();
            complement1 = "";
        }
        Place(rec, 61, 35, nomPrincipal);                          // Nom destinataire
        Place(rec, 96, 35, complement1);                           // Complément adresse 1
        Place(rec, 131, 35, adresseL2);                            // Complément adresse 2
        Place(rec, 166, 35, adresseL3);                            // Complément adresse 3
        Place(rec, 271, 10, codePostal);                           // Code postal
        Place(rec, 281, 35, ville);                                // Ville
        Place(rec, 326, 35, adresseL1);                            // Rue
        Place(rec, 371, 3, codePays);                              // Code pays ISO
        Place(rec, 374, 20, !string.IsNullOrEmpty(mobile) ? mobile : tel); // Téléphone (mobile prio)
        Place(rec, 902, 10, DateTime.Now.ToString("dd/MM/yyyy"));  // Date expédition
        // Pos 912-919 (compte DPD) : laissé vide, sélection manuelle dans Station.NET
        Place(rec, 955, 35, "Cde#" + idCommande.ToString());       // Référence client N°2
        Place(rec, 1072, 35, ref1);                                // N° de consolidation
        Place(rec, 1232, 80, email);                               // E-mail destinataire
        Place(rec, 1312, 35, mobile);                              // GSM destinataire

        return new string(rec);
    }

    /// <summary>
    /// Place une valeur AN dans l'enregistrement, justifiée à gauche, tronquée
    /// si trop longue, en supprimant les caractères de contrôle.
    /// </summary>
    private static void Place(char[] rec, int pos, int longueur, string? valeur)
    {
        if (string.IsNullOrEmpty(valeur)) return;
        var v = valeur!.Replace("\r", " ").Replace("\n", " ").Replace("\t", " ");
        var idx = pos - 1; // 1-based -> 0-based
        var max = Math.Min(longueur, v.Length);
        for (int i = 0; i < max && idx + i < rec.Length; i++)
        {
            rec[idx + i] = v[i];
        }
    }
}
