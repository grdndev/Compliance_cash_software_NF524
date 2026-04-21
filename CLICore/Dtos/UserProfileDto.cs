namespace CLICore.Dtos;

public class UserProfileDto
{
    public long IdTUser { get; set; }
    public string Nom { get; set; }
    public string? Prenom { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public long IdTProfil { get; set; }
    public bool Actif { get; set; }
    public string CodeBar { get; set; }
    public bool? JournalCaisseUn { get; set; }
    public bool? JournalCaisseDeux { get; set; }
    public string? Libelle { get; set; }
    public bool? Admin { get; set; }
    public bool? VenteR  { get; set; }
    public bool? VenteW { get; set; }
    public bool? AchatR { get; set; }
    public bool? AchatW  { get; set; }
    public bool? ArticleR  { get; set; }
    public bool? ArticleW { get; set; }
    public bool? ArticleStock  { get; set; }
    public bool? ArticleOccazOnly  { get; set; }
    public bool? ArticleMag  { get; set; }
    public bool? Statistiques  { get; set; }
    public bool? Transactions  { get; set; }
    public bool? MenuActivationWeb { get; set; }
    public bool? PrixStock  { get; set; }
    public bool? Article_OccazTestOnly  { get; set; }

    public UserProfileDto()
    {
        IdTUser = 0;
        Nom = "";
        Prenom = "";
        Login = "";
        Password = "";
        IdTProfil = 0;
        Actif = false;
        CodeBar = "";
        JournalCaisseUn = false;
        JournalCaisseDeux = false;
        Libelle = "";
        Admin = false;
        VenteR = false;
        VenteW = false;
        AchatR = false;
        AchatW = false;
        ArticleR = false;
        ArticleW = false;
        ArticleStock = false;
        ArticleOccazOnly = false;
        ArticleMag = false;
        Statistiques = false;
        Transactions = false;
        MenuActivationWeb = false;
        PrixStock = false;
        Article_OccazTestOnly = false;
    }
    






}
