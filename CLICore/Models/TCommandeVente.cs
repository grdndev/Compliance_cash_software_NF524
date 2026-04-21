using System;
using System.Collections.Generic;

namespace CLICore.Models;

public partial class TCommandeVente
{
    public long IdTCommandeVente { get; set; }

    public long? IdTClient { get; set; }

    public string? Société { get; set; }

    public string? Nom { get; set; }

    public string? Prénom { get; set; }

    public long? IdEtatCommandeVente { get; set; }

    public string? AdresseL1 { get; set; }

    public string? AdresseL2 { get; set; }

    public string? AdresseL3 { get; set; }

    public string? CodePostal { get; set; }

    public string? Ville { get; set; }

    public string? Pays { get; set; }

    public string? Tel { get; set; }

    public string? Fax { get; set; }

    public string? Mobile { get; set; }

    public string? Email { get; set; }

    public string? CreePar { get; set; }

    public DateTime? CreeLe { get; set; }

    public string? ModifiePar { get; set; }

    public DateTime? ModifieLe { get; set; }

    public DateTime? PayeLe { get; set; }

    public DateTime? RenduLe { get; set; }

    public DateTime? TicketLe { get; set; }

    public DateTime? FactureLe { get; set; }

    public DateTime? ExpedieLe { get; set; }

    public bool? WebOn { get; set; }

    public string? ExpeditionNumsuivi { get; set; }

    public long? IdTTransporteur { get; set; }

    public double? TotalHt { get; set; }

    public double? TotalTtc { get; set; }

    public double? Total55 { get; set; }

    public double? Total196 { get; set; }

    public string? ModeReglement { get; set; }

    public double? MontantPaiementTtc { get; set; }

    public double? MontantEncaisseTtc { get; set; }

    public double? MontantArendreTtc { get; set; }

    public double? MontantRenduTtc { get; set; }

    public long? AvoirUtiliseNo { get; set; }

    public double? AvoirUtiliseMontant { get; set; }

    public long? AvoirCreeNo { get; set; }

    public bool? TvaOn { get; set; }

    public string? CommentairesFacture { get; set; }

    public bool? Export { get; set; }

    public double? MontantDeduire { get; set; }

    public string? NoTva { get; set; }

    public string? NoSiret { get; set; }

    public string? VuAvec { get; set; }

    public string? CommentairesCommande { get; set; }

    public DateTime? ExpeditionLe { get; set; }

    public bool? VpcOn { get; set; }

    public double? TotalTtcAvantDeduction { get; set; }

    public int? Numcaisse { get; set; }

    public string? ImportFile { get; set; }

    public string? ExportFile { get; set; }

    public string? TicketWebCaisse { get; set; }

    public string? CommandeWebCaisse { get; set; }

    public long? IdCommandePrestashop { get; set; }

    public string? ReferenceCommandePrestashop { get; set; }

    public long? IdPanierPrestashop { get; set; }

    public virtual ICollection<TCommandeVenteLigne> TCommandeVenteLignes { get; set; } = new List<TCommandeVenteLigne>();

    public virtual ICollection<TReglement> TReglements { get; set; } = new List<TReglement>();
}
