using CLICore.Dtos;
using CLICore.Data;
using CLICore.Models;
using Microsoft.EntityFrameworkCore;
using CLICore.Dtos;


namespace CLICore.Services.User;

public class UserService : IUserService
{
        private readonly AppSettings _appSettings;
        private readonly CLIContext _cliContext;

        public UserService(AppSettings appSettings, CLIContext cliContext)
        {
            _appSettings = appSettings;
            _cliContext = cliContext;
        }

    public async Task<UserProfileDto> GetUserProfileAsync(string login, string password)
    {
        UserProfileDto userProfile;
        //select into userProfile
        userProfile = (UserProfileDto)_cliContext.TUsers.Include("t_profile").Where(x => x.Login == login && x.Password == password).Select(x => new UserProfileDto
        {
            IdTUser = x.IdTUser,
            Nom = x.Nom,
            Prenom = x.Prenom,
            Login = x.Login,
            Password = x.Password,
            IdTProfil = x.IdTProfil,
            Actif = x.Actif,
            CodeBar = x.CodeBar,
            JournalCaisseUn = x.JournalCaisseUn,
            JournalCaisseDeux = x.JournalCaisseDeux,
            Libelle = x.IdTProfilNavigation.Libelle,
            Admin = x.IdTProfilNavigation.Admin,
            VenteR = x.IdTProfilNavigation.VenteR,
            VenteW = x.IdTProfilNavigation.VenteW,
            AchatR = x.IdTProfilNavigation.AchatR,
            AchatW = x.IdTProfilNavigation.AchatW,
            ArticleR = x.IdTProfilNavigation.ArticleR,
            ArticleW = x.IdTProfilNavigation.ArticleW,
            ArticleStock = x.IdTProfilNavigation.ArticleStock,
            ArticleOccazOnly = x.IdTProfilNavigation.ArticleOccazOnly,
            ArticleMag = x.IdTProfilNavigation.ArticleMag,
            Statistiques = x.IdTProfilNavigation.Statistiques,
            Transactions = x.IdTProfilNavigation.Transactions,
            MenuActivationWeb = x.IdTProfilNavigation.MenuActivationWeb,
            PrixStock = x.IdTProfilNavigation.PrixStock,
            Article_OccazTestOnly = x.IdTProfilNavigation.ArticleOccazTestOnly
        });

        return userProfile;

        


    }

    public async Task<UserProfileDto> GetUserProfileAsync(string codeBar)
    {
        throw new NotImplementedException();
    }
}
