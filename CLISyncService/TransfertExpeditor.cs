namespace CLISyncService;

using System.Net.Http.Json;
using CLICore.Data;
using CLICore.Models;
using CLIPrestashopConnector.Dtos;
using System.Text.Json;
using System.Text.Json.Serialization;
using FluentFTP;
using System.Text;
using Bukimedia.PrestaSharp.Factories;
using System.Globalization;

public class TransfertExpeditor : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private Boolean isProcessing;
    private readonly IConfiguration _configuration;
    private Int32 _CliTransfertExpeditorDelay;


    private readonly string _ConnectionStringCLI;

    private CLIContext _cliContext;
    private HttpClient _client;
    private IServiceProvider _serviceProvider;

    public TransfertExpeditor(ILogger<Worker> logger, IConfiguration configuration, IServiceProvider serviceProvider, CLIContext clicontext)
    {
        _logger = logger;
        // _configuration = configuration;
        // _ConnectionStringCLI = _configuration.GetValue<string>("App:ConnectionStringCLI");
        _cliContext = clicontext;
        // _serviceProvider=serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (!isProcessing)
            {
                isProcessing = true;



                _logger.LogInformation("TransfertExpeditor running at: {time}", DateTimeOffset.Now);
                //récuperation du delai
                _CliTransfertExpeditorDelay = Convert.ToInt32(_cliContext.TParams.Where(c => c.Paramname == "CliTransfertExpeditorDelay").First().Paramvalue);
                
try
{

    CultureInfo.CurrentCulture = new CultureInfo("fr-FR");
     // On traite la fabrication du fichier d'expedition
                var chaineFichierExpedition = "";
// On récupere la date de la derniière exportation depui TParams
                var dateDerniereExtraction = Convert.ToDateTime(_cliContext.TParams.Where(c => c.Paramname == "CliDateDerniereExtraction").First().Paramvalue);

                // On traite la fabrication du fichier d'expedition depuis la derniere extraction
                // On realise une jointure entre TCommandeVente et TPays pour recuperer le code pays
                
                var fichierExpedition = _cliContext.TCommandeVentes
                    .Where(c => (c.WebOn == true || c.VpcOn == true) && c.IdEtatCommandeVente != 90 && c.IdTTransporteur==1 && c.ExpeditionLe >= dateDerniereExtraction)
                    .Join(_cliContext.TPays, c => c.Pays, p => p.Libelle, (c, p) => new
                    {
                        c.IdTCommandeVente,
                        c.IdTClient,
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
                // id_t_commandevente,id_t_client,Prénom,Nom,Société,AdresseL1,AdresseL2,AdresseL3,t_Pays.codepays as Pays,Codepostal,Ville,Tel,Mobile,email
                foreach (var item in fichierExpedition)
                {
                    chaineFichierExpedition += item.IdTCommandeVente + ";" + item.IdTClient + ";" + item.Prénom?.ToString().Replace(";", "").Replace(Environment.NewLine, " ").ToUpper() + ";" + item.Nom?.ToString().Replace(";", "").Replace(Environment.NewLine, " ").ToUpper() + ";" + item.Société?.ToString().Replace(";", "").Replace(Environment.NewLine, " ").ToUpper() + ";" + item.AdresseL1?.ToString().Replace(";", "").Replace(Environment.NewLine, " ").ToUpper() + ";" + item.AdresseL2?.ToString().Replace(";", "").Replace(Environment.NewLine, " ").ToUpper().ToString().Replace(";", "").Replace(Environment.NewLine, " ").ToUpper() + ";" + item.AdresseL3 + ";" + item.CodePays?.ToString().Replace(";", "").Replace(Environment.NewLine, " ").ToUpper()  + ";" + item.CodePostal?.ToString().Replace(";", "").Replace(Environment.NewLine, " ").ToUpper() + ";" + item.Ville?.ToString().Replace(";", "").Replace(Environment.NewLine, " ").ToUpper() + ";" + item.Tel?.ToString().Replace(";", "").Replace(Environment.NewLine, " ").ToUpper() + ";" + item.Mobile?.ToString().Replace(";", "").Replace(Environment.NewLine, " ").ToUpper() + ";" + item.Email?.ToString().Replace(";", "").Replace(Environment.NewLine, " ").ToUpper() +  ";SARL ILE DU VENT;2" + Environment.NewLine;
                } 

                // Envoi sur le serveur FTP si le fichier n'est pas vide (encodable en iso-8859-1)
           

                if (chaineFichierExpedition != "")
                {
                    // On envoie le fichier sur le serveur FTP
                    var ftpServer = _cliContext.TParams.Where(c => c.Paramname == "FTP_Host_Expeditor").First().Paramvalue;
                    var ftpUser = _cliContext.TParams.Where(c => c.Paramname == "FTP_UID_Expeditor").First().Paramvalue;
                    var ftpPassword = _cliContext.TParams.Where(c => c.Paramname == "FTP_PWD_Expeditor").First().Paramvalue;
                    var ftpDirectory = _cliContext.TParams.Where(c => c.Paramname == "FTP_remote_path_Expeditor").First().Paramvalue;
                    var ftpFileNameRoot = _cliContext.TParams.Where(c => c.Paramname == "FTP_file_name_Expeditor").First().Paramvalue;
                    var ftpFileName = ftpFileNameRoot + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";
                    var ftpFullPath = ftpDirectory + ftpFileName;

// write the file 
                   
                    File.WriteAllText(ftpFileName, chaineFichierExpedition, Encoding.GetEncoding("iso-8859-1"));

                    // tranferer le fichier sur le serveur ftp
                    
                    var ftp = new FtpClient(ftpServer, ftpUser, ftpPassword);
                    ftp.UploadFile(ftpFileName, ftpFullPath);
                    ftp.Disconnect();

                    //supprime le fichier local
                    File.Delete(ftpFileName);
                }

                
                // On met à jour la date de la derniere extraction
                _cliContext.TParams.Where(c => c.Paramname == "CliDateDerniereExtraction").First().Paramvalue = DateTime.Now.ToString();
                _cliContext.SaveChanges();
}
catch (System.Exception ex)
{
    Console.WriteLine(ex.Message);
 
}
               

                isProcessing = false;
                await Task.Delay(_CliTransfertExpeditorDelay, stoppingToken);
            }

        }
    }
}

