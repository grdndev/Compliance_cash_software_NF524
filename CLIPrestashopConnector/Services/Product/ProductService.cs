using System;
using Bukimedia.PrestaSharp.Entities.AuxEntities;
using Bukimedia.PrestaSharp.Factories;
using CLICore.Data;
using CLICore.Helpers;
using CLICore.Models;
using CLICore.Services.Logger;
using CLIPrestashopConnector.Services.Push;
using CLIPrestashopConnector.Models;
using CLIPrestashopConnector.Services.CartRule;
using CLIPrestashopConnector.Services.Customer;
using CLIPrestashopConnector.Services.PrestashopErrorDecoder;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using product = Bukimedia.PrestaSharp.Entities.product;
using manufacturer = Bukimedia.PrestaSharp.Entities.manufacturer;
using combination = Bukimedia.PrestaSharp.Entities.combination;
using stock_available = Bukimedia.PrestaSharp.Entities.stock_available;
using specific_price = Bukimedia.PrestaSharp.Entities.specific_price;
using product_feature = Bukimedia.PrestaSharp.Entities.product_feature;
using product_feature_value = Bukimedia.PrestaSharp.Entities.product_feature_value;
using product_option = Bukimedia.PrestaSharp.Entities.product_option;
using product_option_value = Bukimedia.PrestaSharp.Entities.product_option_value;

using category = Bukimedia.PrestaSharp.Entities.category;
using Bukimedia.PrestaSharp.Entities;
using Microsoft.EntityFrameworkCore;
using Bukimedia.PrestaSharp.Entities.FilterEntities;
using System.ComponentModel.Design;
using System.Net;
using System.Reflection;
using System.Linq.Dynamic;
using Microsoft.EntityFrameworkCore.DynamicLinq;
using System.Linq.Dynamic.Core;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Security.Cryptography.X509Certificates;
using AppSettings = CLIPrestashopConnector.Models.AppSettings;

namespace CLIPrestashopConnector.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly ProductFactory _productFactory;
        private readonly CombinationFactory _combinationFactory;
        private readonly StockAvailableFactory _stockAvailableFactory;
        private readonly SpecificPriceFactory _specificPriceFactory;
        private readonly ManufacturerFactory _manufacturerFactory;
        private readonly ProductFeatureFactory _productFeatureFactory;
        private readonly ProductFeatureValueFactory _productFeatureValueFactory;
        private readonly ProductOptionFactory _productOptionFactory;
        private readonly ProductOptionValueFactory _productOptionValueFactory;
        private readonly CategoryFactory _categoryFactory;
        private readonly ImageFactory _imageFactory;
        private readonly AppSettings _appSettings;
        private readonly CLIContext _cliContext;
        private readonly ILogService _logServices;
        private readonly IPushService _pushService;
        private readonly IPrestashopErrorDecoderService _prestashopErrorDecoderService;

        public ProductService(IOptions<AppSettings> appSettings, CLIContext cliContext, ILogService logService, IPrestashopErrorDecoderService prestashopErrorDecoderService, IPushService pushService)
        {
            this._appSettings = appSettings?.Value ?? throw new ArgumentNullException(nameof(appSettings));
            this._productFactory = new ProductFactory(_appSettings.Endpoint, _appSettings.ApiKey, _appSettings.Password);
            this._stockAvailableFactory = new StockAvailableFactory(_appSettings.Endpoint, _appSettings.ApiKey, _appSettings.Password);
            this._combinationFactory = new CombinationFactory(_appSettings.Endpoint, _appSettings.ApiKey, _appSettings.Password);
            this._specificPriceFactory = new SpecificPriceFactory(_appSettings.Endpoint, _appSettings.ApiKey, _appSettings.Password);
            this._manufacturerFactory = new ManufacturerFactory(_appSettings.Endpoint, _appSettings.ApiKey, _appSettings.Password);
            this._productFeatureFactory = new ProductFeatureFactory(_appSettings.Endpoint, _appSettings.ApiKey, _appSettings.Password);
            this._productFeatureValueFactory = new ProductFeatureValueFactory(_appSettings.Endpoint, _appSettings.ApiKey, _appSettings.Password);
            this._productOptionFactory = new ProductOptionFactory(_appSettings.Endpoint, _appSettings.ApiKey, _appSettings.Password);
            this._productOptionValueFactory = new ProductOptionValueFactory(_appSettings.Endpoint, _appSettings.ApiKey, _appSettings.Password);
            this._categoryFactory = new CategoryFactory(_appSettings.Endpoint, _appSettings.ApiKey, _appSettings.Password);
            this._imageFactory = new ImageFactory(_appSettings.Endpoint, _appSettings.ApiKey, _appSettings.Password);
            this._cliContext = cliContext;
            this._logServices = logService;
            this._pushService = pushService;
            this._prestashopErrorDecoderService = prestashopErrorDecoderService;
        }
        // Import des produits depuis la sous famille de CLI
        public async Task<ResponseMessage> ImportFromLegacySubFamilyFromCLIByIdAsync(long id_t_sousfamille, long id_t_famille, bool image = false, bool onlyErrors = false, bool onlyNewSync = false, DateTime? UpdatedDateFrom = null, bool importStock = false, bool deleteBeforeImport = false)
        {

            var _responseMessage = new ResponseMessage();
            try
            {
                // on recupere le nom de la sous famille
                var sousFamille = "";
                if (id_t_sousfamille != 0)
                {
                    sousFamille = _cliContext.TSousFamilles.Where(c => c.IdTSousFamille == id_t_sousfamille).Select(m => m.Libelle).FirstOrDefault();







                    //On recupere le champ caractristiquesPrestashop de la sous famille et si c'est une chaine vide on log une erreur et dans reponsemessage avec Addresponsemessagline et on sort de la fonction
                    var caracteristiquesPrestashop = _cliContext.TSousFamilles.Where(c => c.IdTSousFamille == id_t_sousfamille).Select(m => m.CaracteristiquesPrestashop).FirstOrDefault();
                    if (caracteristiquesPrestashop == null || caracteristiquesPrestashop == "")
                    {
                        await _logServices.LogEvent($"Problème d'import produits PS depuis la sous famille  : {id_t_sousfamille}", $"Le champ CaracteristiquesPrestashop de la sous famille est vide");
                        _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème d'import produits PS depuis la sous famille  : {id_t_sousfamille}", $"Le champ CaracteristiquesPrestashop de la sous famille est vide");
                        return _responseMessage;
                    }
                }

                // on recupere le nom de la  famille
                var famille = "";
                if (id_t_famille != 0)
                {
                    famille = _cliContext.TFamilles.Where(c => c.IdTFamille == id_t_famille).Select(m => m.Libelle).FirstOrDefault();
                }


                // on declare toImport comme la liste de base des entetes des produits à importer
                IOrderedQueryable<long> toImport;
                // Dans toutes les requêtes ont tiens compte de colonne toSync de t_sousfamille pour savoir si on doit importer ou pas
                // si on a spécifié une sous famille, on recupere les id des entetes des produits de la sous famille (distincts et ordonnés)
                if (id_t_sousfamille != 0)
                {
                    // on recupere les id des entetes des produits de la sous famille (distincts et ordonnés
                    toImport = _cliContext.TArticleVersions.Where(c => c.IdTArticleDetailNavigation.IdTArticleEnteteNavigation.IdTSousfamille == id_t_sousfamille && c.IdTArticleDetailNavigation.IdTArticleEnteteNavigation.IdTSousfamilleNavigation.ToSync == true && c.ActiveOn.Value && c.WebOn.Value).Select(m => m.IdTArticleDetailNavigation.IdTArticleEnteteNavigation.IdTArticleEntete).Distinct().OrderBy(x => x);
                    if (UpdatedDateFrom is not null)
                    {
                        toImport = _cliContext.TArticleVersions.Where(c => c.IdTArticleDetailNavigation.IdTArticleEnteteNavigation.IdTSousfamille == id_t_sousfamille && c.IdTArticleDetailNavigation.IdTArticleEnteteNavigation.IdTSousfamilleNavigation.ToSync == true && c.ActiveOn.Value && c.WebOn.Value && c.ModifieLe >= UpdatedDateFrom).Select(m => m.IdTArticleDetailNavigation.IdTArticleEnteteNavigation.IdTArticleEntete).Distinct().OrderBy(x => x);
                    }
                }
                // si on a spécifié une famille, on recupere les id des entetes des produits de la famille (distincts et ordonnés)
                else if (id_t_famille != 0)
                {
                    // on recupere les id des entetes des produits de la famille et des sous familles à syncroniser (toSync) (distincts et ordonnés )

                    toImport = _cliContext.TArticleVersions.Where(c => c.IdTArticleDetailNavigation.IdTArticleEnteteNavigation.IdTSousfamilleNavigation.IdTFamille == id_t_famille && c.IdTArticleDetailNavigation.IdTArticleEnteteNavigation.IdTSousfamilleNavigation.ToSync == true && c.ActiveOn.Value && c.WebOn.Value).Select(m => m.IdTArticleDetailNavigation.IdTArticleEnteteNavigation.IdTArticleEntete).Distinct().OrderBy(x => x);
                    if (UpdatedDateFrom is not null)
                    {
                        toImport = _cliContext.TArticleVersions.Where(c => c.IdTArticleDetailNavigation.IdTArticleEnteteNavigation.IdTSousfamilleNavigation.IdTFamille == id_t_famille && c.IdTArticleDetailNavigation.IdTArticleEnteteNavigation.IdTSousfamilleNavigation.ToSync == true && c.ActiveOn.Value && c.WebOn.Value && c.ModifieLe >= UpdatedDateFrom).Select(m => m.IdTArticleDetailNavigation.IdTArticleEnteteNavigation.IdTArticleEntete).Distinct().OrderBy(x => x);
                    }
                }
                else
                {
                    // on recupere les id des entetes des produits (distincts et ordonnés)
                    toImport = _cliContext.TArticleVersions.Where(c => c.ActiveOn.Value && c.WebOn.Value && c.IdTArticleDetailNavigation.IdTArticleEnteteNavigation.IdTSousfamilleNavigation.ToSync == true).Select(m => m.IdTArticleDetailNavigation.IdTArticleEnteteNavigation.IdTArticleEntete).Distinct().OrderBy(x => x);
                    if (UpdatedDateFrom is not null)
                    {
                        toImport = _cliContext.TArticleVersions.Where(c => c.IdTArticleDetailNavigation.IdTArticleEnteteNavigation.IdTSousfamilleNavigation.ToSync == true && (c.ModifieLe >= UpdatedDateFrom || c.CreeLe>=UpdatedDateFrom)).Select(m => m.IdTArticleDetailNavigation.IdTArticleEnteteNavigation.IdTArticleEntete).Distinct().OrderBy(x => x);
                        //toImport = _cliContext.TArticleVersions.Where(c => c.ActiveOn.Value && c.WebOn.Value && c.IdTArticleDetailNavigation.IdTArticleEnteteNavigation.IdTSousfamilleNavigation.ToSync == true && (c.ModifieLe >= UpdatedDateFrom || c.CreeLe>=UpdatedDateFrom)).Select(m => m.IdTArticleDetailNavigation.IdTArticleEnteteNavigation.IdTArticleEntete).Distinct().OrderBy(x => x);
                        var toImportTransaction = _cliContext.TArticleStocks.Where(c => c.Date >= UpdatedDateFrom).Select(m => m.IdTArticleVersionNavigation.IdTArticleDetailNavigation.IdTArticleEnteteNavigation.IdTArticleEntete).Distinct().OrderBy(x => x);
                        // on reunit les deux listes
                        if (toImportTransaction.Count() > 0)
                        {
                            toImport = (IOrderedQueryable<long>)toImport.Union(toImportTransaction);
                        }
                    }
                }
                var count = toImport.Count();
                // on filtre la liste toImport pour enlever les nulls
                var toImportList = toImport.Where(c => c != null).ToList();

                var logOnlyErrors = _cliContext.VLogs.Where(c => c.LogAssociatedRecordType == "t_article_entete" && c.LogType == "Erreur").Select(c => c.LogAssociatedRecordId).ToList();
                var logOnlyNewSync = _cliContext.VLogs.Where(c => c.LogAssociatedRecordType == "t_article_entete").Select(c => c.LogAssociatedRecordId).ToList();

                //enregistre une entree dans la table de log pour indiquer le début de l'import et si onlyErrors, on l'indique dans le message
                await _logServices.LogEvent($"Import produits PS depuis la famille  :{famille}({id_t_famille})/ sous famille  : {sousFamille}({id_t_sousfamille}) {(onlyErrors ? "avec seulement les erreurs" : "")}", $"Import produits PS depuis la famille  :{famille}({id_t_famille})/ sous famille  : {sousFamille}({id_t_sousfamille}) {(onlyErrors ? "avec seulement les erreurs" : "")}");
                // on envoie une notification push pour indiquer le début de l'import avec le nom de la sous famille et de la famille
                await _pushService.Notify("Import produits PS", $"Import produits PS depuis : {famille} ({id_t_famille}) / {sousFamille} ({id_t_sousfamille}) démarré");


                if (onlyErrors)
                {
                    // on teste si l'entete est en erreur en regardant vlog
                    toImportList = toImportList.Where(c => logOnlyErrors.Contains(c)).ToList();


                }
                if (onlyNewSync)
                {
                    // on teste si l'entete a déja été synchronisé en regardant vlog
                    toImportList = toImportList.Where(c => !logOnlyNewSync.Contains(c)).ToList();


                }

                // si on doit supprimer avant import
                if (deleteBeforeImport)
                {
                    foreach (var idTArticleEntete in toImportList)
                    {
                        await DeletePSProductfromCLIByIdAsync(idTArticleEntete);
                    }
                }

                foreach (var idTArticleEntete in toImportList)
                {


                    await AddOrUpdatePSfromCLIByIdAsync(idTArticleEntete, image, "entete", importStock);




                }
                //enregistre une entree dans la table de log pour indiquer la fin de l'import
                await _logServices.LogEvent($"Import produits PS Import produits PS depuis la famille  :{famille}({id_t_famille})/ sous famille  : {sousFamille}({id_t_sousfamille}) {(onlyErrors ? "avec seulement les erreurs" : "")} terminé", $"Import produits PS depuis la famille  :{famille}({id_t_famille})/ sous famille  : {sousFamille}({id_t_sousfamille}) {(onlyErrors ? "avec seulement les erreurs" : "")} terminé");

                // on envoie une notification push pour indiquer la fin de l'import
                await _pushService.Notify("Import produits PS", $"Import produits PS depuis : {famille} ({id_t_famille}) / {sousFamille} ({id_t_sousfamille}) terminé");
            }
            
            catch (Exception ex)
            {
                await _logServices.LogEvent($"Problème d'import produits PS depuis la sous famille  : {id_t_sousfamille} ", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème d'import produits PS depuis la sous famille : {id_t_sousfamille}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                return _responseMessage;
            }
            return _responseMessage;
        }

        public async Task<ResponseMessage> AddOrUpdatePSfromCLIByIdAsync(long id, Boolean importLegacyImages = false, string EnteteVersion = "version", bool importStock = false)
        {
            var _responseMessage = new ResponseMessage();
            var ArticleEntete = new TArticleEntete();
            ArticleEntete.IdTArticleEntete = 0;
            try
            {
                //Récupération du produit à insérer ou mettre à jour


                TArticleVersion? ArticleVersion = new TArticleVersion();
                if (EnteteVersion == "version")
                {
                    ArticleVersion = _cliContext.TArticleVersions.Where(c => c.IdTArticleVersion == id).First();
                }
                if (EnteteVersion == "entete")
                {
                    ArticleVersion = _cliContext.TArticleVersions.Where(c => c.IdTArticleDetailNavigation.IdTArticleEnteteNavigation.IdTArticleEntete == id).First();
                }

                var ArticleDetail = _cliContext.TArticleDetails.Where(c => c.IdTArticleDetail == ArticleVersion.IdTArticleDetail).First();
                ArticleEntete = _cliContext.TArticleEntetes.Where(c => c.IdTArticleEntete == ArticleDetail.IdTArticleEntete).Include("TArticleDetails.TArticleVersions").First();
                var ArticleSousFamille = _cliContext.TSousFamilles.Where(c => c.IdTSousFamille == ArticleEntete.IdTSousfamille).First();
                // On regarde si la sousfamille de l'article est à synchroniser (toSync) sinon log un message et on sort de la fonction
                if (!ArticleSousFamille.ToSync)
                {
                    await _logServices.LogEvent($"Import produits PS depuis CLI  : {id} {EnteteVersion}", $"La sous famille {ArticleSousFamille.Libelle} n'est pas à synchroniser", ArticleEntete.IdTArticleEntete, "t_article_entete", "Ok");

                    _responseMessage.AddResponseMessageLine(ResponseMessageType.Information, $"Import produits PS depuis CLI  : {id}", $"La sous famille {ArticleSousFamille.Libelle} n'est pas à synchroniser");
                    return _responseMessage;
                }


                var ArticleFamille = _cliContext.TFamilles.Where(c => c.IdTFamille == ArticleSousFamille.IdTFamille).First();
                var ArticleSousFamilleEquipement = _cliContext.TArticleDetails.Where(c => c.IdTArticleDetail == ArticleVersion.IdTArticleDetail).First().Type;
                // On récupère le texte pour un artice precommande dans la table t_params
                var PS_PreCommandeTexte = _cliContext.TParams.Where(c => c.Paramname == "PS_PreCommandeTexte").First().Paramvalue;
                // On récupère le texte pour un artice surcommande dans la table t_params
                var PS_SurCommandeTexte = _cliContext.TParams.Where(c => c.Paramname == "PS_SurCommandeTexte").First().Paramvalue;
                // On récupère le texte pour un artice en rupture de stock dans la table t_params
                var PS_RuptureTexte = _cliContext.TParams.Where(c => c.Paramname == "PS_RuptureTexte").First().Paramvalue;
                // On récupère le texte pour un artice en stock dans la table t_params
                var PS_EnStockTexte = _cliContext.TParams.Where(c => c.Paramname == "PS_EnStockTexte").First().Paramvalue;
                /// On recupere le nom de la sous sous famille puis la propriété correspondante dans l'objet ArticleDetail
                string ArticleSousSousFamille = "";
                var SousSousFamille = _cliContext.TSousFamilles.Where(c => c.IdTSousFamille == ArticleSousFamille.IdTSousFamille).First().SousSousFamille;
                var entityType = ArticleDetail.GetType();
                var propertySousSousFamille = entityType.GetProperty(SousSousFamille);

                if (propertySousSousFamille.GetValue(ArticleDetail) != null)
                {
                    ArticleSousSousFamille = propertySousSousFamille.GetValue(ArticleDetail).ToString().Trim();
                }
                else
                {
                    ArticleSousSousFamille = "";
                }

                /// 2
                string ArticleSousSousFamille2 = "";
                var SousSousFamille2 = _cliContext.TSousFamilles.Where(c => c.IdTSousFamille == ArticleSousFamille.IdTSousFamille).First().SousSousFamille2;
if (SousSousFamille2 != null){
 var propertySousSousFamille2= entityType.GetProperty(SousSousFamille2);

                if (propertySousSousFamille2.GetValue(ArticleDetail) != null)
                {
                    ArticleSousSousFamille2= propertySousSousFamille2.GetValue(ArticleDetail).ToString().Trim();
                }
                else
                {
                    ArticleSousSousFamille2 = "";
                }
                }
                else{
                    ArticleSousSousFamille2 = "";
                }
                
                /// 3
                string ArticleSousSousFamille3 = "";
                var SousSousFamille3= _cliContext.TSousFamilles.Where(c => c.IdTSousFamille == ArticleSousFamille.IdTSousFamille).First().SousSousFamille3;
if (SousSousFamille3 != null){
 var propertySousSousFamille3= entityType.GetProperty(SousSousFamille3);

                if (propertySousSousFamille3.GetValue(ArticleDetail) != null)
                {
                    ArticleSousSousFamille3= propertySousSousFamille3.GetValue(ArticleDetail).ToString().Trim();
                }
                else
                {
                    ArticleSousSousFamille3 = "";
                }
                }
                else{
                    ArticleSousSousFamille3 = "";
                }

                      /// 4
                string ArticleSousSousFamille4 = "";
                var SousSousFamille4= _cliContext.TSousFamilles.Where(c => c.IdTSousFamille == ArticleSousFamille.IdTSousFamille).First().SousSousFamille4;
                if (SousSousFamille4 != null){
 var propertySousSousFamille4= entityType.GetProperty(SousSousFamille4);

                if (propertySousSousFamille4.GetValue(ArticleDetail) != null)
                {
                    ArticleSousSousFamille4= propertySousSousFamille4.GetValue(ArticleDetail).ToString().Trim();
                }
                else
                {
                    ArticleSousSousFamille4 = "";
                }
                }
                else{
                    ArticleSousSousFamille4 = "";
                }
               

                /// fin de la récupération de la sous sous famille

                // ArticleSousSousFamille = ArticleDetail.Programme;
                var TableauTechnique = "";
                double ArticleStock = 0;
                var Occaz = ArticleVersion.DepotVente.Value || ArticleVersion.Occaz.Value || ArticleVersion.Test.Value;
                var Equipement = ArticleFamille.IdTFamille == 3;
                var RewriteOccaz = Occaz ? "-Occaz" : "";
                var enPromo = _cliContext.TArticleVersions.Where(c => c.IdTArticleDetailNavigation.IdTArticleEnteteNavigation.IdTArticleEntete == ArticleEntete.IdTArticleEntete && c.PrixVenteInitialTtc != c.PrixVenteRemiseTtc && c.WebOn == true && c.ActiveOn == true).Count() > 0;
                var PrixMiniTTC = _cliContext.TArticleVersions.Where(c => c.IdTArticleDetailNavigation.IdTArticleEnteteNavigation.IdTArticleEntete == ArticleEntete.IdTArticleEntete && c.WebOn == true && c.ActiveOn == true).Min(c => c.PrixVenteInitialTtc);

                var PoidsMini = _cliContext.TArticleVersions.Where(c => c.IdTArticleDetailNavigation.IdTArticleEnteteNavigation.IdTArticleEntete == ArticleEntete.IdTArticleEntete && c.WebOn == true && c.ActiveOn == true).Min(c => c.Poids);

                var Precommande = _cliContext.TArticleVersions.Where(c => c.IdTArticleDetailNavigation.IdTArticleEnteteNavigation.IdTArticleEntete == ArticleEntete.IdTArticleEntete && c.Precommande == true && c.WebOn == true && c.ActiveOn == true).Count() > 0;
                var Surcommande = _cliContext.TArticleVersions.Where(c => c.IdTArticleDetailNavigation.IdTArticleEnteteNavigation.IdTArticleEntete == ArticleEntete.IdTArticleEntete && c.Surcommande == true && c.WebOn == true && c.ActiveOn == true).Count() > 0;
                var toDeactivate = _cliContext.TArticleVersions.Where(c => c.IdTArticleDetailNavigation.IdTArticleEnteteNavigation.IdTArticleEntete == ArticleEntete.IdTArticleEntete && c.WebOn == true && c.ActiveOn == true).Count() == 0;
                // Selectionne toutes les versions correspondant à l'entete et qui sont actives et en ligne
                var ArticleVersions = _cliContext.TArticleVersions.Where(c => c.IdTArticleDetailNavigation.IdTArticleEnteteNavigation.IdTArticleEntete == ArticleEntete.IdTArticleEntete && c.WebOn == true && c.ActiveOn == true).Select(x => x.IdTArticleVersion).ToList();

                // Fait une jointure entre les versions et les stocks pour récupérer le stock total
                var EnStock = _cliContext.VArticleStocks.Where(c => ArticleVersions.Contains(c.IdTArticleVersion)).Select(x => x.Stock).Sum() > 0;
                if (!toDeactivate)
                {
                    toDeactivate = !Precommande && !Surcommande && !EnStock;
                }

                var toDeactivateVersion = false;
                //Récupération du champ id_t_article_entete_lies de la table t_article_entete dans une variable
                var ArticleEnteteLies = ArticleEntete.IdTArticleEnteteLies;
                //si le champ n'est ni null ni vide, on decoupe la chaine de caractère sur le caractère "," et on stocke le résultat dans un tableau
                var ArticleEnteteLiesArray = ArticleEnteteLies?.Split(',');
                // on parcourt le tableau et on ajoute 'E' devant chaque élément
                var ArticleEnteteLiesArrayE = ArticleEnteteLiesArray?.Select(x => "E" + x).ToArray();

                //Rayon Accueil
                Dictionary<string, string> dtnAccueil = new Dictionary<string, string>();
                dtnAccueil.Add("name", "Accueil");
                category categoryAccueil = _categoryFactory.GetByFilter(dtnAccueil, null, null).FirstOrDefault();


                if (categoryAccueil == null)
                {
                    await _logServices.LogEvent($"Problème de mise à jour / ajout produit PS depuis CLI  : {id} {EnteteVersion}", $"Problème avec la catégorie Accueil", ArticleEntete.IdTArticleEntete, "t_article_entete", "Erreur");

                    _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de mise à jour / ajout produit PS depuis CLI  : {id}", $"Problème avec la catégorie Accueil");
                    return _responseMessage;
                }

                //Rayon Occasion
                Dictionary<string, string> dtnOccasions = new Dictionary<string, string>();
                dtnOccasions.Add("name", "Occasions");
                category categoryOccasions = _categoryFactory.GetByFilter(dtnOccasions, null, null).FirstOrDefault();

                if (categoryOccasions == null)
                {
                    await _logServices.LogEvent($"Problème de mise à jour / ajout produit PS depuis CLI  : {id} {EnteteVersion}", $"Problème avec la catégorie Occasions", ArticleEntete.IdTArticleEntete, "t_article_entete", "Erreur");

                    _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de mise à jour / ajout produit PS depuis CLI  : {id}", $"Problème avec la catégorie Occasions");
                    return _responseMessage;
                }

                //Rayon (gestion des occasions ?)
                Dictionary<string, string> dtnFamille = new Dictionary<string, string>();
                dtnFamille.Add("CLI_id_t_famille", ArticleFamille.IdTFamille.ToString());
                dtnFamille.Add("CLI_Occaz", Occaz ? "1" : "0");

                category category = _categoryFactory.GetByFilter(dtnFamille, null, null).FirstOrDefault();

                var categoryshortDescription = PSHelper.PSChampMultiLangue(ArticleFamille.Libelle.ToString());
                var categorylink_rewrite = PSHelper.PSChampMultiLangue($"{ArticleFamille.Libelle.RemoveSpecialCharacters().Replace(" ", "-")}{RewriteOccaz}");


                if (category is null)
                {
                    category = new category();
                    category.active = 1;
                    category.name = categoryshortDescription;
                    category.link_rewrite = categorylink_rewrite;
                    //Accueil ou Occasions
                    category.id_parent = Occaz ? categoryOccasions.id : categoryAccueil.id;
                    category.CLI_id_t_famille = ArticleFamille.IdTFamille;
                    category.CLI_Occaz = Convert.ToInt32(Occaz);
                    category = _categoryFactory.Add(category);


                }

                //Sous Rayon
                Dictionary<string, string> dtnSousFamille = new Dictionary<string, string>();
                dtnSousFamille.Add("CLI_id_t_sousfamille", ArticleSousFamille.IdTSousFamille.ToString());
                dtnSousFamille.Add("CLI_Occaz", Occaz ? "1" : "0");
                dtnSousFamille.Add("id_parent", category.id.ToString());
                category category2 = _categoryFactory.GetByFilter(dtnSousFamille, null, null).FirstOrDefault();

                var category2shortDescription = PSHelper.PSChampMultiLangue($"{ArticleSousFamille.Libelle.ToString()}");
                var category2link_rewrite = PSHelper.PSChampMultiLangue($"{ArticleSousFamille.Libelle.ToString().RemoveSpecialCharacters().Replace(" ", "-")}{RewriteOccaz}");

                if (category2 is null)
                {
                    category2 = new category();
                    category2.active = 1;
                    category2.name = category2shortDescription;
                    category2.link_rewrite = category2link_rewrite;
                    category2.id_parent = category.id;
                    category2.CLI_id_t_sousfamille = ArticleSousFamille.IdTSousFamille;
                    category2.CLI_Occaz = Convert.ToInt32(Occaz);
                    category2 = _categoryFactory.Add(category2);


                }

                //Rayon néoprène
                category category3 = null;
                category category4 = null;
                category category5 = null;
                category category6 = null;

                // voir s'il faut gérer le cas des équipements (sous sous famille) ou pas
                //if (Equipement)

                if (1 == 2)
                {
                    Dictionary<string, string> dtnSousFamilleNeoprene = new Dictionary<string, string>();
                    dtnSousFamilleNeoprene.Add("CLI_id_t_sousfamille", ArticleSousFamille.IdTSousFamille.ToString());
                    dtnSousFamilleNeoprene.Add("CLI_Occaz", Occaz ? "1" : "0");
                    dtnSousFamilleNeoprene.Add("name", ArticleSousSousFamille.ToString());
                    dtnSousFamilleNeoprene.Add("id_parent", category2.id.ToString());

                    category3 = _categoryFactory.GetByFilter(dtnSousFamilleNeoprene, null, null).FirstOrDefault();

                    var category3shortDescription = PSHelper.PSChampMultiLangue($"{ArticleSousFamilleEquipement.ToString()}");
                    var category3link_rewrite = PSHelper.PSChampMultiLangue($"{ArticleSousFamilleEquipement.ToString().RemoveSpecialCharacters().Replace(" ", "-")}{RewriteOccaz}");

                    if (category3 is null)
                    {
                        category3 = new category();
                        category3.active = 1;
                        category3.name = category3shortDescription;
                        category3.link_rewrite = category3link_rewrite;
                        category3.id_parent = category2.id;
                        category3.CLI_id_t_sousfamille = ArticleSousFamille.IdTSousFamille;
                        category3.CLI_Occaz = Convert.ToInt32(Occaz);
                        category3 = _categoryFactory.Add(category3);


                    }
                }
                else
                {
                    Dictionary<string, string> dtnSousSousFamille = new Dictionary<string, string>();
                    dtnSousSousFamille.Add("CLI_id_t_sousfamille", ArticleSousFamille.IdTSousFamille.ToString());
                    dtnSousSousFamille.Add("CLI_Occaz", Occaz ? "1" : "0");
                    dtnSousSousFamille.Add("name", ArticleSousSousFamille.ToString());
                    dtnSousSousFamille.Add("id_parent", category2.id.ToString());

                    category3 = _categoryFactory.GetByFilter(dtnSousSousFamille, null, null).FirstOrDefault();

                    var category3shortDescription = PSHelper.PSChampMultiLangue($"{ArticleSousSousFamille.ToString()}");
                    var category3link_rewrite = PSHelper.PSChampMultiLangue($"{ArticleSousSousFamille.ToString().RemoveSpecialCharacters().Replace(" ", "-")}{RewriteOccaz}");

                    if (category3 is null)
                    {
                        category3 = new category();
                        category3.active = 1;
                        category3.name = category3shortDescription;
                        category3.link_rewrite = category3link_rewrite;
                        category3.id_parent = category2.id;
                        category3.CLI_id_t_sousfamille = ArticleSousFamille.IdTSousFamille;
                        category3.CLI_Occaz = Convert.ToInt32(Occaz);
                        category3 = _categoryFactory.Add(category3);


                    }

                    // 2

                    if (ArticleSousSousFamille2 !=""){
 Dictionary<string, string> dtnSousSousFamille2 = new Dictionary<string, string>();
                    dtnSousSousFamille2.Add("CLI_id_t_sousfamille", ArticleSousFamille.IdTSousFamille.ToString());
                    dtnSousSousFamille2.Add("CLI_Occaz", Occaz ? "1" : "0");
                    dtnSousSousFamille2.Add("name", ArticleSousSousFamille2.ToString());
                    dtnSousSousFamille2.Add("id_parent", category2.id.ToString());

                    category4 = _categoryFactory.GetByFilter(dtnSousSousFamille2, null, null).FirstOrDefault();

                    var category4shortDescription = PSHelper.PSChampMultiLangue($"{ArticleSousSousFamille2.ToString()}");
                    var category4link_rewrite = PSHelper.PSChampMultiLangue($"{ArticleSousSousFamille2.ToString().RemoveSpecialCharacters().Replace(" ", "-")}{RewriteOccaz}");

                    if (category4 is null)
                    {
                        category4 = new category();
                        category4.active = 1;
                        category4.name = category4shortDescription;
                        category4.link_rewrite = category4link_rewrite;
                        category4.id_parent = category2.id;
                        category4.CLI_id_t_sousfamille = ArticleSousFamille.IdTSousFamille;
                        category4.CLI_Occaz = Convert.ToInt32(Occaz);
                        category4 = _categoryFactory.Add(category4);


                    }
                    }
                   
    // 3

                    if (ArticleSousSousFamille3 !=""){
 Dictionary<string, string> dtnSousSousFamille3 = new Dictionary<string, string>();
                    dtnSousSousFamille3.Add("CLI_id_t_sousfamille", ArticleSousFamille.IdTSousFamille.ToString());
                    dtnSousSousFamille3.Add("CLI_Occaz", Occaz ? "1" : "0");
                    dtnSousSousFamille3.Add("name", ArticleSousSousFamille3.ToString());
                    dtnSousSousFamille3.Add("id_parent", category2.id.ToString());

                    category5 = _categoryFactory.GetByFilter(dtnSousSousFamille3, null, null).FirstOrDefault();

                    var category5shortDescription = PSHelper.PSChampMultiLangue($"{ArticleSousSousFamille3.ToString()}");
                    var category5link_rewrite = PSHelper.PSChampMultiLangue($"{ArticleSousSousFamille3.ToString().RemoveSpecialCharacters().Replace(" ", "-")}{RewriteOccaz}");

                    if (category5 is null)
                    {
                        category5 = new category();
                        category5.active = 1;
                        category5.name = category5shortDescription;
                        category5.link_rewrite = category5link_rewrite;
                        category5.id_parent = category2.id;
                        category5.CLI_id_t_sousfamille = ArticleSousFamille.IdTSousFamille;
                        category5.CLI_Occaz = Convert.ToInt32(Occaz);
                        category5= _categoryFactory.Add(category5);


                    }
                    }

                    // 4

                    if (ArticleSousSousFamille4 !=""){
 Dictionary<string, string> dtnSousSousFamille4 = new Dictionary<string, string>();
                    dtnSousSousFamille4.Add("CLI_id_t_sousfamille", ArticleSousFamille.IdTSousFamille.ToString());
                    dtnSousSousFamille4.Add("CLI_Occaz", Occaz ? "1" : "0");
                    dtnSousSousFamille4.Add("name", ArticleSousSousFamille4.ToString());
                    dtnSousSousFamille4.Add("id_parent", category2.id.ToString());

                    category6 = _categoryFactory.GetByFilter(dtnSousSousFamille4, null, null).FirstOrDefault();

                    var category6shortDescription = PSHelper.PSChampMultiLangue($"{ArticleSousSousFamille4.ToString()}");
                    var category6link_rewrite = PSHelper.PSChampMultiLangue($"{ArticleSousSousFamille4.ToString().RemoveSpecialCharacters().Replace(" ", "-")}{RewriteOccaz}");

                    if (category6 is null)
                    {
                        category6 = new category();
                        category6.active = 1;
                        category6.name = category6shortDescription;
                        category6.link_rewrite = category6link_rewrite;
                        category6.id_parent = category2.id;
                        category6.CLI_id_t_sousfamille = ArticleSousFamille.IdTSousFamille;
                        category6.CLI_Occaz = Convert.ToInt32(Occaz);
                        category6= _categoryFactory.Add(category6);


                    }
                    }

                }


                //Taux de tva
                var ArticleTauxTva = _cliContext.TCodeTvas.Where(c => c.Taux == ArticleEntete.CodeTva).First();
                decimal ArticleTauxTvaMultiplicateur = (decimal)(1 + ArticleTauxTva.Taux / 100);

                //name

                var NomProduit = "";
                //le nom du produit se construit différement en fonction d'une occasion ou d'un produit classique (présence de déclinaison ou non)
                // gestion de l'annee pour certaines sous familles à implémenter
                if (ArticleVersion.Occaz.Value || ArticleVersion.Test.Value || ArticleVersion.DepotVente.Value)
                {
                    NomProduit = ArticleVersion.DescriptionPanier.ToString();
                }
                else
                {
                    if (ArticleSousFamille.AnneeOn.Value)
                    {
                        NomProduit = $"{ArticleEntete.Marque.ToString()} {ArticleEntete.Modele.ToString()} {ArticleEntete.Annee.ToString()}";
                    }
                    else
                    {
                        NomProduit = $"{ArticleEntete.Marque.ToString()} {ArticleEntete.Modele.ToString()}";
                    }

                }
                var name = PSHelper.PSChampMultiLangue(NomProduit);


                //Description


                // Ajout du tableau de caractéristiques technique (en fonction des version) si AttributsPrestashop différent de chaine vide dans ArticleSousFamille
                if (ArticleSousFamille.AttributsPrestashop != "" && ArticleSousFamille.AttributsPrestashop != null)
                {
                    TableauTechnique = PSHelper.GetTechnicalTab(ArticleEntete, ArticleSousFamille);
                }

     
                var description = new List<Bukimedia.PrestaSharp.Entities.AuxEntities.language>();
                if (ArticleEntete.Description is not null)
                {
                    if (ArticleEntete.Description2 is not null)
                    {
                        description = PSHelper.PSChampMultiLangue($"{ArticleEntete.Description.ToString().RemoveUnicodeCharacters().RemoveScriptTags().Replace("\r\n", "<br>")}<br>{ArticleEntete.Description2.ToString().RemoveUnicodeCharacters().RemoveScriptTags().Replace("\r\n", "<br>")}<br>{TableauTechnique}");
                    }
                    else
                    {
                        description = PSHelper.PSChampMultiLangue($"{ArticleEntete.Description.ToString().RemoveUnicodeCharacters().Replace("\r\n", "<br>")}<br>{TableauTechnique}");
                    }
                }
                else
                {
                    description = PSHelper.PSChampMultiLangue($"");
                }




                //Short Description
                var shortDescription = PSHelper.PSChampMultiLangue($"{ArticleEntete.Description?.ToString().RemoveUnicodeCharacters().Truncate(800).Replace("\r\n", "<br>")}");

                //Link rewrite
                var link_rewrite = PSHelper.PSChampMultiLangue(NomProduit.RemoveSpecialCharacters().RemoveUnicodeCharacters().Replace(".", "").Replace(" ", "-"));

                //Marque

                Dictionary<string, string> dtnManutacturer = new Dictionary<string, string>();
                dtnManutacturer.Add("name", ArticleEntete.Marque.ToString());


                manufacturer manufacturer = _manufacturerFactory.GetByFilter(dtnManutacturer, null, null).FirstOrDefault();

                if (manufacturer is null)
                {
                    manufacturer = new manufacturer();
                    manufacturer.active = 1;
                    manufacturer.name = ArticleEntete.Marque.ToString();
                    manufacturer = _manufacturerFactory.Add(manufacturer);


                }





                //Caractéristiques (en fonction de la sous famille)

                var caracteristiques = new List<Bukimedia.PrestaSharp.Entities.AuxEntities.product_feature>();
                var categories = new List<Bukimedia.PrestaSharp.Entities.AuxEntities.category>();

                var product_Feature = new product_feature();
                var product_Feature_Value = new product_feature_value();


                //Boucle sur les caractéristiques de la sous famille à ajouter
                try
                {
                    var caracteristiquesSousFamille = ArticleSousFamille.CaracteristiquesPrestashop.Split("+");
                    foreach (var item in caracteristiquesSousFamille)
                    {
                        var ChampTable = item.Replace("<", "").Replace(">", "").Split(".");
                        var ChampTableLibelle = ChampTable[1].Split(":");
                        product_Feature = PSHelper.AddOrGetProductFeature(ChampTableLibelle[0], _productFeatureFactory);
                        Type type = null;
                        if (ChampTable[0] == "entete")
                        {
                            type = ArticleEntete.GetType();
                        }
                        else
                        if (ChampTable[0] == "detail")
                        {
                            type = ArticleDetail.GetType();
                        }
                        else
                        if (ChampTable[0] == "version")
                        {
                            type = ArticleVersion.GetType();
                        }

                        // Get the property info object
                        PropertyInfo property = type.GetProperty(ChampTableLibelle[1]);
                        string value = null;
                        // Get the property value
                        if (ChampTable[0] == "entete")
                        {
                            value = property.GetValue(ArticleEntete).ToString().Trim();
                        }
                        else
                        if (ChampTable[0] == "detail")
                        {
                            value = property.GetValue(ArticleDetail).ToString().Trim();
                        }
                        else
                        if (ChampTable[0] == "version")
                        {
                            value = property.GetValue(ArticleVersion).ToString().Trim();
                        }
if (value != null && value != ""){
    product_Feature_Value = PSHelper.AddOrGetProductFeatureValue(value, product_Feature, _productFeatureValueFactory);

                        // Ajout à la liste
                        caracteristiques.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.product_feature { id = product_Feature.id.Value, id_feature_value = product_Feature_Value.id.Value }
        );
}

                        

                    }
                }
                catch (Exception ex)
                {
                    //
                }



                //Voiles
                // -> programme

                // Libelle
                //product_Feature = PSHelper.AddOrGetProductFeature("Programme", _productFeatureFactory);

                // Valeur 



                // Get the type of the object instance
                //                Type type = ArticleDetail.GetType();

                //                // Get the property info object
                //                PropertyInfo property = type.GetProperty("Programme");

                //                // Get the property value
                //                object value = property.GetValue(ArticleDetail);
                //                product_Feature_Value = PSHelper.AddOrGetProductFeatureValue((string)value, product_Feature, _productFeatureValueFactory);

                //                // Ajout à la liste
                //                caracteristiques.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.product_feature { id = product_Feature.id.Value, id_feature_value = product_Feature_Value.id.Value }
                //);

                // -> modèle

                //                // Libelle
                //                product_Feature = PSHelper.AddOrGetProductFeature("Modèle", _productFeatureFactory);

                //                // Valeur 

                //                product_Feature_Value = PSHelper.AddOrGetProductFeatureValue(ArticleEntete.Modele, product_Feature, _productFeatureValueFactory);


                //                // Ajout à la liste
                //                caracteristiques.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.product_feature { id = product_Feature.id.Value, id_feature_value = product_Feature_Value.id.Value }
                //);

                //                // -> Collection

                //                // Libelle
                //                product_Feature = PSHelper.AddOrGetProductFeature("Collection", _productFeatureFactory);

                //                // Valeur 

                //                product_Feature_Value = PSHelper.AddOrGetProductFeatureValue(ArticleEntete.Annee, product_Feature, _productFeatureValueFactory);

                //                // Ajout à la liste
                //                caracteristiques.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.product_feature { id = product_Feature.id.Value, id_feature_value = product_Feature_Value.id.Value }
                //);

                // On recherche si le produit existe déjà, sinon on le crée
                Dictionary<string, string> dtnProduit = new Dictionary<string, string>();

                //Si produit avec déclinaison alors on recherche sur l'entete avec un E concaténé sinon on recherche sur id_t_version
                dtnProduit.Add("reference", "E" + ArticleEntete.IdTArticleEntete.ToString());
                product product = _productFactory.GetByFilter(dtnProduit, null, null).FirstOrDefault();
                bool bProduitNew = false;
                if (product is null)
                {
                    bProduitNew = true;
                    product = new product();
                }
                else
                {
                    bProduitNew = false;
                }

                product.name = name;
                product.description = description;
                product.link_rewrite = link_rewrite;
                if (toDeactivate)
                {
                    product.available_for_order = 0;
                    product.active = 0;
                    product.visibility = "none";
                }
                else
                {
                    product.available_for_order = 1;
                    product.active = 1;
                    product.visibility = "both";
                }


                product.state = 1;
                product.description_short = shortDescription;
                product.id_tax_rules_group = ArticleTauxTva.IdTaxPrestashop;
                product.id_manufacturer = manufacturer.id;
                product.id_category_default = category2.id;
                product.reference = "E" + ArticleEntete.IdTArticleEntete.ToString();
                product.position_in_category = null;
                product.condition = Occaz ? "used" : "new";
                product.show_condition = Occaz ? 1 : 0;
                product.show_price = 1;
                product.on_sale = enPromo ? 1 : 0;
                if (PrixMiniTTC == null)
                {
                    product.price = decimal.Round((decimal)ArticleVersion.PrixVenteInitialTtc / ArticleTauxTvaMultiplicateur, 6);
                }
                else
                {
                    product.price = decimal.Round((decimal)PrixMiniTTC / ArticleTauxTvaMultiplicateur, 6);
                }
                if (PoidsMini is null)
                {
                    product.weight = 0;
                }
                else
                {
                    product.weight = (decimal)PoidsMini;
                }


                product.available_now = PSHelper.PSChampMultiLangue(PS_EnStockTexte);


                if (Precommande || Surcommande)
                {
                    if (Precommande)
                    {
                        product.available_later = PSHelper.PSChampMultiLangue(PS_PreCommandeTexte);
                    }
                    else
                    if (Surcommande)
                    {
                        product.available_later = PSHelper.PSChampMultiLangue(PS_SurCommandeTexte);
                    }
                }
                else
                {
                    product.available_later = PSHelper.PSChampMultiLangue("");
                }




                categories.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.category { id = categoryAccueil.id.Value });
                if (Occaz) categories.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.category { id = categoryOccasions.id.Value });
                categories.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.category { id = category.id.Value });
                categories.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.category { id = category2.id.Value });
                //if (Equipement) categories.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.category { id = category3.id.Value });
                categories.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.category { id = category3.id.Value });
                if (category4 is not null) categories.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.category { id = category4.id.Value });
                if (category5 is not null) categories.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.category { id = category5.id.Value });
                if (category6 is not null) categories.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.category { id = category6.id.Value });
                product.associations.categories = categories;

                product.associations.product_features = caracteristiques;


                if (ArticleEnteteLiesArrayE is not null)
                {
                    // on parcourt le tableau ArticleEnteteLiesArrayE et pour chaque entete on regarde si le produit existe dans prestashop
                    // si oui on le lie au produit
                    List<Bukimedia.PrestaSharp.Entities.AuxEntities.product> productLies = new List<Bukimedia.PrestaSharp.Entities.AuxEntities.product>();


                    foreach (string vArticleEnteteLies in ArticleEnteteLiesArrayE)
                    {
                        //Si produit avec déclinaison alors on recherche sur l'entete avec un E concaténé sinon on recherche sur id_t_version
                        var dtnProduitLie = new Dictionary<string, string>();
                        dtnProduitLie.Add("reference", vArticleEnteteLies);

                        var productFullLies = _productFactory.GetByFilter(dtnProduitLie, null, null).ToList();
                        if (!(productFullLies is null))
                        {

                            //pour chaque produit trouvé on l'ajoute à la liste des produits liés
                            foreach (var productFullLie in productFullLies)
                            {
                                productLies.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.product { id = productFullLie.id.Value });
                            }


                        }

                    }



                    product.associations.accessories = productLies;
                }






                if (bProduitNew)
                {
                    product = _productFactory.Add(product);
                }
                else
                {
                    _productFactory.Update(product);
                }

                //Remise automatique
                // si remise auto est >0, on ajoute ou on mets à jour une règle valide pour le produit quelle que soit la déclinaison
                // 
                // sinon on supprime la règle
                // On mets également à jour le bandeau promo pour l'article (à faire dans chaque version)

                Dictionary<string, string> dtnPriceAll = new Dictionary<string, string>();
                dtnPriceAll.Add("id_product", product.id.ToString());
                dtnPriceAll.Add("id_product_attribute", "0");
                dtnPriceAll.Add("id_customer", "0");

                specific_price specific_PriceAll = _specificPriceFactory.GetByFilter(dtnPriceAll, null, null).FirstOrDefault();
                if (ArticleEntete.RemiseAuto > 0)
                {
                    enPromo = true;

                    bool bSpecifiPriceAllNew = false;
                    if (specific_PriceAll is null)
                    {
                        bSpecifiPriceAllNew = true;
                        specific_PriceAll = new specific_price();

                    }

                    specific_PriceAll.id_shop = 0;
                    specific_PriceAll.id_cart = 0;
                    specific_PriceAll.id_currency = 0;
                    specific_PriceAll.id_country = 0;
                    specific_PriceAll.id_group = 0;
                    specific_PriceAll.id_customer = 0;
                    specific_PriceAll.id_customer = 0;
                    specific_PriceAll.price = -1;
                    specific_PriceAll.from_quantity = 1;
                    specific_PriceAll.reduction_tax = 1;

                    specific_PriceAll.id_product_attribute = 0;
                    specific_PriceAll.id_product = product.id;
                    specific_PriceAll.reduction_type = "percentage";
                    specific_PriceAll.reduction = (decimal)ArticleEntete.RemiseAuto;
                    specific_PriceAll.from = ArticleEntete.RemiseAutoDu?.ToString("yyyy-MM-dd");
                    specific_PriceAll.to = ArticleEntete.RemiseAutoAu?.ToString("yyyy-MM-dd");


                    if (bSpecifiPriceAllNew)
                    {
                        _specificPriceFactory.Add(specific_PriceAll);
                    }
                    else
                    {
                        _specificPriceFactory.Update(specific_PriceAll);
                    }

                }
                else
                {
                    if (specific_PriceAll is not null)
                    {
                        _specificPriceFactory.Delete(specific_PriceAll);
                    }
                }


                if (importStock)
                {
                    Dictionary<string, string> dtnStockAvailableMain = new Dictionary<string, string>();
                    dtnStockAvailableMain.Add("id_product", product.id.ToString());
                    dtnStockAvailableMain.Add("id_product_attribute", "0");

                    stock_available stockAvailableMain = _stockAvailableFactory.GetByFilter(dtnStockAvailableMain, null, null).FirstOrDefault();

                    stockAvailableMain.quantity = (int)ArticleStock;


                    if (Precommande || Surcommande)
                    {
                        stockAvailableMain.out_of_stock = 1;
                    }
                    else
                    {
                        stockAvailableMain.out_of_stock = 2;
                    }

                    _stockAvailableFactory.Update(stockAvailableMain);

                }

                //Attributs  (en fonction de la sous famille)
                var options = new List<Bukimedia.PrestaSharp.Entities.AuxEntities.product_option_value>();
                //On vérifie s'il y a au moins une version avec libelle<>'' et libelle<>null et active et webon
                bool bLibelleVersion = false;
                foreach (var detail in ArticleEntete.TArticleDetails)
                {
                    foreach (var version in detail.TArticleVersions)
                    {
                        if (version.Libelle?.ToString() != "" && version.Libelle != null && version.ActiveOn.Value && version.WebOn.Value)
                        {
                            bLibelleVersion = true;
                            break;
                        }
                        
                    }
                }


                foreach (var detail in ArticleEntete.TArticleDetails)
                {


                    foreach (var version in detail.TArticleVersions)
                    {

                        Type typeDetail = null;
                        typeDetail = detail.GetType();
                        PropertyInfo propertyDetail = typeDetail.GetProperty(ArticleSousFamille.ChampTriAttributsPrestashop);
                        string valueDetail = propertyDetail.GetValue(detail).ToString();

                        options = new List<Bukimedia.PrestaSharp.Entities.AuxEntities.product_option_value>();

                        // Libelle
                        product_option product_Option = PSHelper.AddOrGetProductOption($"{ArticleSousFamille.LibelleTech} {ArticleSousFamille.Libelle}", ArticleSousFamille.LibelleTech, _productOptionFactory); ;

                        //Valeur 
                        product_option_value product_Option_Value = PSHelper.AddOrGetProductOptionValue(valueDetail, product_Option, _productOptionValueFactory);

                        // Ajout à la liste
                        options.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.product_option_value() { id = product_Option_Value.id.Value });


                        // -> variante
                        var libelleVersion = "-";
                        if (version.Libelle?.ToString() != "" && version.Libelle != null)
                        {
                            libelleVersion = version.Libelle;
                        }
                        

                        if (bLibelleVersion )
                        {


                            // Libelle
                            product_Option = PSHelper.AddOrGetProductOption($"{ArticleSousFamille.LibelleVersion} {ArticleSousFamille.Libelle}", $"{ArticleSousFamille.LibelleVersion} {ArticleSousFamille.Libelle}", _productOptionFactory);

                            // Valeur 

                            product_Option_Value = PSHelper.AddOrGetProductOptionValue(libelleVersion, product_Option, _productOptionValueFactory);

                            // Ajout à la liste
                            options.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.product_option_value() { id = product_Option_Value.id.Value });

                        }


                        //Combinaisons
                        // On recherche si la combinaison existe déjà, sinon on la crée 
                        Dictionary<string, string> dtnCombinaison = new Dictionary<string, string>();
                        dtnCombinaison.Add("reference", version.IdTArticleVersion.ToString());
                        combination combination = _combinationFactory.GetByFilter(dtnCombinaison, null, null).FirstOrDefault();
                        ArticleStock = _cliContext.TArticleStocks.Where(c => c.IdTArticleVersion == version.IdTArticleVersion).Sum(c => c.Operation).Value;
                        toDeactivateVersion = false;
                        var versionPrecommandeOrSurcommande=version.Precommande.Value || version.Surcommande.Value;

                        //if (ArticleStock == 0 & !versionPrecommandeOrSurcommande) toDeactivateVersion = true;
                        if (ArticleStock == 0 & !Precommande & !Surcommande) toDeactivateVersion = true;

                        if (version.ActiveOn.Value && version.WebOn.Value && !toDeactivateVersion)
                        {
                            bool bCombinationNew = false;
                            if (combination is null)
                            {
                                bCombinationNew = true;
                                combination = new combination();
                            }
                            else
                            {
                                bCombinationNew = false;
                            }



                            combination.id_product = product.id;
                            combination.minimal_quantity = 1;
                            combination.reference = version.IdTArticleVersion.ToString();
                            combination.price = decimal.Round((decimal)version.PrixVenteInitialTtc.Value / ArticleTauxTvaMultiplicateur, 6) - decimal.Round((decimal)PrixMiniTTC.Value / ArticleTauxTvaMultiplicateur, 6);

                            if (PoidsMini is null || version.Poids is null)
                            {
                                combination.weight = 0;
                            }
                            else
                            {
                                combination.weight = (decimal)version.Poids.Value - (decimal)PoidsMini;
                            }




                            combination.associations =
                                    new AssociationsCombination()
                                    {
                                        product_option_values = options
                                    };

                            if (bCombinationNew)
                            {
                                combination = _combinationFactory.Add(combination);
                            }
                            else
                            {
                                _combinationFactory.Update(combination);
                            }
                            Dictionary<string, string> dtn = new Dictionary<string, string>();
                            dtn.Add("id_product", product.id.ToString());
                            dtn.Add("id_product_attribute", combination.id.ToString());

                            if (importStock)
                            {



                                stock_available stockAvailable = _stockAvailableFactory.GetByFilter(dtn, null, null).FirstOrDefault();

                                stockAvailable.quantity = (int)ArticleStock;
                                if (Precommande || Surcommande)
                                {
                                    stockAvailable.out_of_stock = 1;
                                }
                                else
                                {
                                    stockAvailable.out_of_stock = 2;
                                }

                                _stockAvailableFactory.Update(stockAvailable);

                            }


                            //Specific price
                            // si le prix initial <> prix remisé, on ajoute ou on mets à jour une règle
                            // 
                            // sinon on supprime la règle


                            specific_price specific_Price = _specificPriceFactory.GetByFilter(dtn, null, null).FirstOrDefault();
                            if (Decimal.Round(version.PrixVenteRemiseTtc.Value, 2) != Decimal.Round(version.PrixVenteInitialTtc.Value, 2))
                            {


                                bool bSpecifiPriceNew = false;
                                if (specific_Price is null)
                                {
                                    bSpecifiPriceNew = true;
                                    specific_Price = new specific_price();

                                }

                                specific_Price.id_shop = 0;
                                specific_Price.id_cart = 0;
                                specific_Price.id_currency = 0;
                                specific_Price.id_country = 0;
                                specific_Price.id_group = 0;
                                specific_Price.id_customer = 0;
                                specific_Price.id_customer = 0;
                                specific_Price.price = -1;
                                specific_Price.from_quantity = 1;
                                specific_Price.reduction_tax = 1;

                                specific_Price.id_product_attribute = combination.id;
                                specific_Price.id_product = product.id;
                                specific_Price.reduction_type = "percentage";
                                specific_Price.reduction = Decimal.Round((decimal)(1 - (version.PrixVenteRemiseTtc / version.PrixVenteInitialTtc)), 6);


                                if (bSpecifiPriceNew)
                                {
                                    _specificPriceFactory.Add(specific_Price);
                                }
                                else
                                {
                                    _specificPriceFactory.Update(specific_Price);
                                }

                            }
                            else
                            {
                                if (specific_Price is not null)
                                {
                                    _specificPriceFactory.Delete(specific_Price);
                                }
                            }

                        }
                        else
                        {
                            // on supprime
                            if (combination is not null)
                            {
                                _combinationFactory.Delete(combination.id.Value);
                            }

                        }
                    }





                }






                //Import des impages depuis l'ancien site si importLegacyImages est true
                if (importLegacyImages)
                {
                    //Suppression des images avant d'importer
                    List<declination> images = new List<declination>();
                    try
                    {
                        images = _imageFactory.GetProductImages(product.id.Value);
                    }
                    catch (Exception ex)
                    {
                        // on ne fait rien
                    }

                    foreach (var i in images)
                    {
                        _imageFactory.DeleteProductImage(product.id.Value, i.id);
                    }

                    WebClient myWebClient = new WebClient();
                    byte[] image = null;
                    bool bImage = false;
                    image = myWebClient.DownloadData($"https://195.154.30.41/upload/vignettes/photo_big1_{ArticleEntete.IdTArticleEntete}.jpg");
                    if (PictureHelper.TryGetExtension(image) != null)
                    {
                        bImage = true;
                        _imageFactory.AddProductImage(product.id.Value, image);
                    }
                    image = myWebClient.DownloadData($"https://195.154.30.41/upload/vignettes/photo_big2_{ArticleEntete.IdTArticleEntete}.jpg");
                    if (PictureHelper.TryGetExtension(image) != null)
                    {
                        bImage = true;
                        _imageFactory.AddProductImage(product.id.Value, image);
                    }
                    image = myWebClient.DownloadData($"https://195.154.30.41/upload/vignettes/photo_big3_{ArticleEntete.IdTArticleEntete}.jpg");
                    if (PictureHelper.TryGetExtension(image) != null)
                    {
                        bImage = true;
                        _imageFactory.AddProductImage(product.id.Value, image);
                    }


                }



                //Si pas d'image, on en met une par défaut depuis le dossier local _appSettings.MiscellaneousPath en ajoutant / si besoin avec le nom _appSettings.NoPhotoName 

                List<declination> images2 = new List<declination>();

                var addDefaultImage = false;
                try
                {
                    images2 = _imageFactory.GetProductImages(product.id.Value);
                }
                catch (Exception ex)
                {
                    addDefaultImage = true;
                }


                if (addDefaultImage)
                {
                    byte[] image2 = null;
                    string path = _appSettings.MiscellaneousPath;
                    if (!path.EndsWith("/"))
                    {
                        path += "/";
                    }
                    path += _appSettings.NoPhotoName;
                    if (File.Exists(path))
                    {
                        image2 = File.ReadAllBytes(path);
                        _imageFactory.AddProductImage(product.id.Value, image2);
                    }



                }




            }
            catch (Exception ex)
            {
                await _logServices.LogEvent($"Problème de mise à jour / ajout produit PS depuis CLI  : {id} {EnteteVersion}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}", ArticleEntete.IdTArticleEntete, "t_article_entete", "Erreur");
                _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de mise à jour / ajout produit PS depuis CLI  : {id} {EnteteVersion}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                return _responseMessage;
            }




            await _logServices.LogEvent($"Mise à jour / ajout produit PS depuis CLI  : {id} {EnteteVersion}", "", ArticleEntete.IdTArticleEntete, "t_article_entete", "Ok");

            return _responseMessage;


        }

        // Permet de supprimer un produit PS depuis CLI en fonction du id_t_article_entete passé en paramètre
        public async Task<ResponseMessage> DeletePSProductfromCLIByIdAsync(long id)
        {
            var _responseMessage = new ResponseMessage();
            // On log un événement
            await _logServices.LogEvent($"Début suppression Produit PS depuis CLI  : {id}", "", id, "t_article_entete","Ok");
            var dtn = new Dictionary<string, string>();
            dtn.Add("reference", "E" + id.ToString());
            var product = _productFactory.GetByFilter(dtn, null, null).FirstOrDefault();
            if (product is null)
            {
                //await _logServices.LogEvent($"Le produit {id} n'existe pas", "DeletePSProductfromCLIByIdAsync");
                _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Le produit {id} n'existe pas");
                return _responseMessage;
            }
            _productFactory.Delete(product.id.Value);

            await _logServices.LogEvent($"Fin suppression Produit PS depuis CLI  : {id}", "", id, "t_article_entete", "Ok");

            return _responseMessage;
        }

        // Permet de supprimer une combinaison PS depuis CLI en fonction du id_t_article_version passé en paramètre
        public async Task<ResponseMessage> DeletePSCombinaisonfromCLIByIdAsync(long id)
        {
            var _responseMessage = new ResponseMessage();
            // On log un événement
            await _logServices.LogEvent($"Suppression Combinaison PS depuis CLI  : {id}", "", id, "t_article_version");
            var dtn = new Dictionary<string, string>();
            dtn.Add("reference", id.ToString());
            var combinaison = _combinationFactory.GetByFilter(dtn, null, null).FirstOrDefault();
            if (combinaison is null)
            {
                await _logServices.LogEvent($"Le produit {id} n'existe pas", "DeletePSfromCLIByIdAsync");
                _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"La combinaison {id} n'existe pas");
                return _responseMessage;
            }
            _combinationFactory.Delete(combinaison.id.Value);


            // On vérifie si le produit parent a des combinaisons, si non on le supprime
            var dtn2 = new Dictionary<string, string>();
            dtn2.Add("id_product", combinaison.id_product.ToString());
            var combinaisons = _combinationFactory.GetByFilter(dtn2, null, null).ToList();
            if (combinaisons.Count == 0)
            {
                var dtn3 = new Dictionary<string, string>();
                dtn3.Add("id", combinaison.id_product.ToString());
                var product = _productFactory.GetByFilter(dtn3, null, null).FirstOrDefault();
                if (product is not null)
                {
                    _productFactory.Delete(product.id.Value);
                }
            }


            await _logServices.LogEvent($"Suppression PS depuis CLI  : {id}", "", id, "t_article_version", "Ok");

            return _responseMessage;
        }
        //create a function to sort all product_option_value ascending by name property given a specific product_option and update the position property
        // public async Task<ResponseMessage> SortProductOptionValueAsync(long productionOptionId){
        //     var responseMessage = new ResponseMessage();
        //     try{
        //         var product_Option = _productOptionFactory.Get(productionOptionId);
        //         if(product_Option is null){
        //               await _logServices.LogEvent($"L'option {productionOptionId} n'existe pas", "SortProductOptionValueAsync");

        //             responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"L'option {productionOptionId} n'existe pas");
        //             return responseMessage;
        //         }
        //         var product_Option_Values = _productOptionValueFactory.GetByFilter(new Dictionary<string, string> {{"id_attribute_group", product_Option.id.Value.ToString()}}, "name_ASC", null);
        //         if(product_Option_Values is null || product_Option_Values.Count == 0){
        //             await _logServices.LogEvent($"L'option {productionOptionId} n'a pas de valeurs", "SortProductOptionValueAsync");
        //             responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"L'option {productionOptionId} n'a pas de valeurs");
        //             return responseMessage;
        //         }





        //                 for (int i = 0; i < product_Option_Values.Count; i++){
        //             product_Option_Values[i].position = i;
        //             _productOptionValueFactory.Update(product_Option_Values[i]);
        //         }
        //     }
        //     catch (Exception ex) {
        //         await _logServices.LogEvent($"Problème de tri de la liste des options pour l'option : {productionOptionId}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
        //         responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de tri de la liste des options pour l'option: {productionOptionId}",  $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
        //         return responseMessage;
        //     }

        //     return responseMessage;
        // }
        public async Task<ResponseMessage> SortProductOptionValueAsync(long productionOptionId)
        {
            var responseMessage = new ResponseMessage();
            try
            {
                var product_Option = _productOptionFactory.Get(productionOptionId);
                if (product_Option is null)
                {
                    await _logServices.LogEvent($"L'option {productionOptionId} n'existe pas", "SortProductOptionValueAsync");

                    responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"L'option {productionOptionId} n'existe pas");
                    return responseMessage;
                }
                var product_Option_Values = _productOptionValueFactory.GetByFilter(new Dictionary<string, string> { { "id_attribute_group", product_Option.id.Value.ToString() } }, "name_ASC", null);
                if (product_Option_Values is null || product_Option_Values.Count == 0)
                {
                    await _logServices.LogEvent($"L'option {productionOptionId} n'a pas de valeurs", "SortProductOptionValueAsync");
                    responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"L'option {productionOptionId} n'a pas de valeurs");
                    return responseMessage;
                }

                product_Option_Values = product_Option_Values.OrderBy(x =>
                {
                    if (double.TryParse(x.name[0].Value, out double result))
                    {
                        return result;
                    }
                    return double.MaxValue;
                }).ToList();

                for (int i = 0; i < product_Option_Values.Count; i++)
                {
                    product_Option_Values[i].position = i;
                    _productOptionValueFactory.Update(product_Option_Values[i]);
                }
            }
            catch (Exception ex)
            {
                await _logServices.LogEvent($"Problème de tri de la liste des options pour l'option : {productionOptionId}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de tri de la liste des options pour l'option: {productionOptionId}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                return responseMessage;
            }

            return responseMessage;
        }


        public async Task<ResponseMessage> GetAllProductOptionAsync()
        {
            var responseMessage = new ResponseMessage();
            //get all product_option
            var product_Options = _productOptionFactory.GetAll();
            if (product_Options is null || product_Options.Count == 0)
            {
                await _logServices.LogEvent($"Aucune option n'a été trouvée", "GetAllProductOptionAsync");
                responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Aucune option n'a été trouvée");
                return responseMessage;
            }
            // map all product_option to object with only id and name property and put it in responseMessage.Objects with cast
            responseMessage.Objects = product_Options.Select(x => new { x.id, x.name.FirstOrDefault().Value }).Cast<object>().ToList();






            return responseMessage;
        }
        public async Task<ResponseMessage> AddProductImage(long ProductId, byte[] Image)
        {
            var _responseMessage = new ResponseMessage();
            try
            {
                // récupération de l'entete du produit CLI
                var ArticleEntete = _cliContext.TArticleVersions.Where(c => c.IdTArticleVersion == ProductId).Select(c => c.IdTArticleDetailNavigation.IdTArticleEnteteNavigation.IdTArticleEntete).FirstOrDefault();
                // récupération du ProductId
                Dictionary<string, string> dtnProduct = new Dictionary<string, string>();
                dtnProduct.Add("reference", "E" + ArticleEntete.ToString());
                product product = _productFactory.GetByFilter(dtnProduct, null, null).FirstOrDefault();

                if (product == null)
                {
                    await _logServices.LogEvent($"Problème d'ajout d'image produit PS    : {ProductId}", "La référence n'a pas été trouvée");
                    _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème d'ajout d'image produit PS   : {ProductId}");
                    return _responseMessage;
                }

                _imageFactory.AddProductImage(product.id.Value, Image);
            }
            catch (Exception ex)
            {
                await _logServices.LogEvent($"Problème d'ajout d'image produit PS  : {ProductId}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème d'ajout d'image produit PS  : {ProductId}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                return _responseMessage;
            }

            return _responseMessage;
        }

        public async Task<ResponseMessage> AddProductImages(long ProductId, List<ImageData> Images)
        {
            var _responseMessage = new ResponseMessage();
            try
            {
                // récupération de l'entete du produit CLI
                var ArticleEntete = _cliContext.TArticleVersions.Where(c => c.IdTArticleVersion == ProductId).Select(c => c.IdTArticleDetailNavigation.IdTArticleEnteteNavigation.IdTArticleEntete).FirstOrDefault();
                // récupération du ProductId
                Dictionary<string, string> dtnProduct = new Dictionary<string, string>();
                dtnProduct.Add("reference", "E" + ArticleEntete.ToString());
                product product = _productFactory.GetByFilter(dtnProduct, null, null).FirstOrDefault();
                if (product == null)
                {
                    await _logServices.LogEvent($"Problème d'ajout d'images produit PS    : {ProductId}", "La référence n'a pas été trouvée");
                    _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème d'ajout d'image produit PS   : {ProductId}");
                    return _responseMessage;
                }
                foreach (var image in Images)
                {
                    _imageFactory.AddProductImage(product.id.Value, image.Data);
                }

            }
            catch (Exception ex)
            {
                await _logServices.LogEvent($"Problème d'ajout d'images produit PS  : {ProductId}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème d'ajout d'image produit PS  : {ProductId}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                return _responseMessage;
            }

            return _responseMessage;
        }

        public async Task<ResponseMessage> DeleteProductImage(long ProductId, long ImageId)
        {
            var _responseMessage = new ResponseMessage();
            try
            {
                _imageFactory.DeleteProductImage(ProductId, ImageId);
            }
            catch (Exception ex)
            {
                await _logServices.LogEvent($"Problème de suppression d'image produit PS  : {ProductId} {ImageId}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de suppression d'image produit PS  : {ProductId} {ImageId}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                return _responseMessage;
            }

            return _responseMessage;
        }

        public async Task<ResponseMessage> DeleteProductImages(long ProductId, List<long> ImageId)
        {
            var _responseMessage = new ResponseMessage();
            try
            {
                // récupération de l'entete du produit CLI
                var ArticleEntete = _cliContext.TArticleVersions.Where(c => c.IdTArticleVersion == ProductId).Select(c => c.IdTArticleDetailNavigation.IdTArticleEnteteNavigation.IdTArticleEntete).FirstOrDefault();
                // récupération du ProductId
                Dictionary<string, string> dtnProduct = new Dictionary<string, string>();
                dtnProduct.Add("reference", "E" + ArticleEntete.ToString());
                product product = _productFactory.GetByFilter(dtnProduct, null, null).FirstOrDefault();
                foreach (var imageId in ImageId)
                {
                    _imageFactory.DeleteProductImage(product.id.Value, imageId);
                }

            }
            catch (Exception ex)
            {
                await _logServices.LogEvent($"Problème de suppression d'image produit PS  : {ProductId} {ImageId}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de suppression d'image produit PS  : {ProductId} {ImageId}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                return _responseMessage;
            }

            return _responseMessage;
        }

        public async Task<ResponseMessage> DeleteAllProductImages(long ProductId)
        {

            var _responseMessage = new ResponseMessage();
            var images = _imageFactory.GetProductImages(ProductId);

            foreach (var image in images)
            {
                try
                {
                    _imageFactory.DeleteProductImage(ProductId, image.id);
                }
                catch (Exception ex)
                {
                    await _logServices.LogEvent($"Problème de suppression d'image produit PS  : {ProductId} {image.id}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                    _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de suppression d'image produit PS  : {ProductId} {image.id}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                    return _responseMessage;
                }

            }

            return _responseMessage;
        }

        public async Task<ResponseMessage> UpdateProductImage(ImageData image)
        {
            var _responseMessage = new ResponseMessage();
            try
            {
                _imageFactory.UpdateProductImage(image.ProductId, image.Id, image.Data);
            }
            catch (Exception ex)
            {
                await _logServices.LogEvent($"Problème de mise à jour d'une image produit PS  : {image.ProductId} {image.Id}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de mise à jour d'une image produit PS  : {image.ProductId} {image.Id}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                return _responseMessage;

            }
            return _responseMessage;
        }

        public async Task<ResponseMessage> GetProductImage(long ProductId, long ImageId)
        {
            var _responseMessage = new ResponseMessage();
            try
            {
                var imageData = new ImageData();
                imageData.Id = ImageId;
                imageData.ProductId = ProductId;
                imageData.Data = _imageFactory.GetProductImage(ProductId, ImageId);
                _responseMessage.ImageDatas.Add(imageData);
            }
            catch (Exception ex)
            {
                await _logServices.LogEvent($"Problème de récupération d'une image produit PS  : {ProductId} {ImageId}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de récupération d'une image produit PS : {ProductId} {ImageId}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                return _responseMessage;
            }

            return _responseMessage;
        }

        // create function to get product and to get the default image id
        public async Task<ResponseMessage> GetProductDefaultImageId(long ProductId)
        {
            var _responseMessage = new ResponseMessage();
            try
            {
                // récupération de l'entete du produit CLI
                var ArticleEntete = _cliContext.TArticleVersions.Where(c => c.IdTArticleVersion == ProductId).Select(c => c.IdTArticleDetailNavigation.IdTArticleEnteteNavigation.IdTArticleEntete).FirstOrDefault();
                // récupération du ProductId
                Dictionary<string, string> dtnProduct = new Dictionary<string, string>();
                dtnProduct.Add("reference", "E" + ArticleEntete.ToString());
                product product = _productFactory.GetByFilter(dtnProduct, null, null).FirstOrDefault();
                if (product == null)
                {
                    _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de récupération d'un id image par defaut produit PS : {ProductId}", $"Le produit n'existe pas");
                    return _responseMessage;
                }


                // on retourne le id de l'image par défaut
                var defaultImageId = product.id_default_image;



                _responseMessage.Objects.Add(defaultImageId);
                return _responseMessage;

            }
            catch (Exception ex)
            {
                await _logServices.LogEvent($"Problème de récupération d'un id image produit PS  : {ProductId}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de récupération d'un id image produit PS : {ProductId}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                return _responseMessage;

            }
        }



        public async Task<ResponseMessage> SetProductDefaultImage(long ProductId, long ImageId)
        {
            var _responseMessage = new ResponseMessage();
            try
            {
                // récupération de l'entete du produit CLI
                var ArticleEntete = _cliContext.TArticleVersions.Where(c => c.IdTArticleVersion == ProductId).Select(c => c.IdTArticleDetailNavigation.IdTArticleEnteteNavigation.IdTArticleEntete).FirstOrDefault();
                // récupération du ProductId
                Dictionary<string, string> dtnProduct = new Dictionary<string, string>();
                dtnProduct.Add("reference", "E" + ArticleEntete.ToString());
                product product = _productFactory.GetByFilter(dtnProduct, null, null).FirstOrDefault();

                // si le produit est null on renvoie une erreur
                if (product == null)
                {
                    _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de mise à jour d'un id image par defaut produit PS : {ProductId}", $"Le produit n'existe pas");
                    return _responseMessage;
                }

                // on met à jour l'image par défaut
                product.id_default_image = ImageId;
                _productFactory.Update(product);

                return _responseMessage;

            }
            catch (Exception ex)
            {
                await _logServices.LogEvent($"Problème de mise à jour d'un id image par défaut produit PS  : {ProductId} {ImageId}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de récupération d'un id image par défaut produit PS : {ProductId} {ImageId}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                return _responseMessage;
            }

            return _responseMessage;
        }

        public async Task<ResponseMessage> GetProductImages(long ProductId)
        {
            var _responseMessage = new ResponseMessage();
            try
            {
                // récupération de l'entete du produit CLI
                var ArticleEntete = _cliContext.TArticleVersions.Where(c => c.IdTArticleVersion == ProductId).Select(c => c.IdTArticleDetailNavigation.IdTArticleEnteteNavigation.IdTArticleEntete).FirstOrDefault();
                // récupération du ProductId
                Dictionary<string, string> dtnProduct = new Dictionary<string, string>();
                dtnProduct.Add("reference", "E" + ArticleEntete.ToString());
                product product = _productFactory.GetByFilter(dtnProduct, null, null).FirstOrDefault();
                if (product == null)
                {
                    await _logServices.LogEvent($"Problème de récupération des images d'un produit PS  : {ProductId}", "La référence n'a pas été trouvée");
                    _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de récupération des images d'un produit PS  : {ProductId}");
                    return _responseMessage;
                }

                // Dictionary<string, string> dtnCombinaison = new Dictionary<string, string>();
                // dtnCombinaison.Add("reference", ProductId.ToString());
                // combination combination = _combinationFactory.GetByFilter(dtnCombinaison, null, null).FirstOrDefault();
                // if (combination == null)
                // {
                //     await _logServices.LogEvent($"Problème de récupération des images d'un produit PS  : {ProductId}", "La référence n'a pas été trouvée");
                //     _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de récupération des images d'un produit PS  : {ProductId}");
                //     return _responseMessage;
                // }

                List<declination> images = new List<declination>();
                try
                {
                    images = _imageFactory.GetProductImages(product.id.Value);
                }
                catch (Exception ex)
                {

                }


                foreach (var image in images)
                {
                    _responseMessage.ImageDatas.Add(new ImageData { Id = image.id, ProductId = product.id.Value, Data = _imageFactory.GetProductImage(product.id.Value, image.id) });
                }

                return _responseMessage;
            }
            catch (Exception ex)
            {
                await _logServices.LogEvent($"Problème de récupération des images d'un produit PS  : {ProductId}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de récupération des images d'un produit PS: {ProductId}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                return _responseMessage;
            }


        }

        public async Task<ResponseMessage> UpdatePSStockfromCLIByIdAsync(long id)
        {
            var _responseMessage = new ResponseMessage();

            try
            {
                Dictionary<string, string> dtnCombinaison = new Dictionary<string, string>();
                dtnCombinaison.Add("reference", id.ToString());
                combination combination = _combinationFactory.GetByFilter(dtnCombinaison, null, null).FirstOrDefault();
                if (combination == null)
                {
                    //syncronisation du produit
                    await AddOrUpdatePSfromCLIByIdAsync(id);
                    combination = _combinationFactory.GetByFilter(dtnCombinaison, null, null).FirstOrDefault();
                    if (combination == null)
                    {
                        await _logServices.LogEvent($"Problème de mise à jour du stock produit PS depuis CLI  : {id}", "La référence n'a pas été trouvée");
                        _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de mise à jour du stock produit PS depuis CLI  : {id}");
                        return _responseMessage;
                    }

                }

                Dictionary<string, string> dtn = new Dictionary<string, string>();
                dtn.Add("id_product", combination.id_product.ToString());
                dtn.Add("id_product_attribute", combination.id.ToString());

                stock_available stockAvailable = _stockAvailableFactory.GetByFilter(dtn, null, null).FirstOrDefault();

                if (stockAvailable == null)
                {
                    await _logServices.LogEvent($"Problème de mise à jour du stock produit PS depuis CLI  : {id}", "La stock n'a pas été trouvée");
                    _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de mise à jour du stock produit PS depuis CLI  : {id}");
                    return _responseMessage;
                }

                var ArticleStock = _cliContext.TArticleStocks.Where(c => c.IdTArticleVersion == id).Sum(c => c.Operation).Value;

                stockAvailable.quantity = (int)ArticleStock;


                _stockAvailableFactory.Update(stockAvailable);
                if (ArticleStock == 0)
                {
                    await AddOrUpdatePSfromCLIByIdAsync(id);
                }

            }
            catch (Exception ex)
            {
                await _logServices.LogEvent($"Problème de mise à jour du stock produit PS depuis CLI  : {id}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de mise à jour du stock produit PS depuis CLI  : {id}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                return _responseMessage;


            }


            return _responseMessage;

        }

        // create a function to check all the products in the database and check if product exits in CLI using the reference that should match idtentete
        // if not then delete the product from PS
        public async Task<ResponseMessage> DeleteProductFromPSWithNoMatchCLIAsync()
        {
            var _responseMessage = new ResponseMessage();
            try
            {
                // we write in the log that we start the process
                await _logServices.LogEvent($"Début du processus de suppression des produits PS sans correspondance CLI", "");


                // we get all the products from PS, but only the id and the reference using the factory and list fecthing only the id and the reference and filtering on cache_is_pack=0 using dictionary object to exclude pack product type
                var products = _productFactory.GetByFilter(new Dictionary<string, string> { { "cache_is_pack", "0" } }, null, null, new List<string> { "id", "reference" });



                // var products= _productFactory.GetByFilter(null, null, null, new List<string> { "id", "reference","cache_is_pack" });

                foreach (var product in products)
                {
                    var productReference = product.reference;

                    // we test if the product reference is empty, if yes we delete the product
                    if (string.IsNullOrEmpty(productReference))
                    {
                        _productFactory.Delete((long)product.id);
                        continue;
                    }
                    else
                    {
                        // we remove the E from the reference to get the idTArticleEntete and check if the product exists in CLI
                        // if not we delete the product from PS
                        var productReferenceId = Convert.ToInt64(productReference.Replace("E", ""));
                        var productInCLI = _cliContext.TArticleEntetes.Where(c => c.IdTArticleEntete == productReferenceId).FirstOrDefault();
                        if (productInCLI == null)
                        {
                            _productFactory.Delete((long)product.id);
                        }
                    }


                }
                // we right in the log that the process is finished
                await _logServices.LogEvent($"Fin du processus de suppression des produits PS sans correspondance CLI", "");

            }
            catch (Exception ex)
            {
                await _logServices.LogEvent($"Problème de suppression des produits PS", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de suppression des produits PS", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                return _responseMessage;
            }
            return _responseMessage;


        }


        // Create a function to fetch the url of a given product by passing the product reference
        public async Task<ResponseMessage> GetProductUrlFromPSAsync(long id)
        {
            var _responseMessage = new ResponseMessage();
            try
            {

                // we get the product from PS using the reference
                // we filter on the reference field
                var dtn = new Dictionary<string, string>();
                dtn.Add("reference", $"E{id}");
                var product = _productFactory.GetByFilter(dtn, null, null).FirstOrDefault();

                if (product == null)
                {
                    await _logServices.LogEvent($"Problème de récupération de l'url du produit PS", "Le produit n'a pas été trouvé");
                    _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de récupération de l'url du produit PS", "Le produit n'a pas été trouvé");
                    return _responseMessage;
                }
                // we get the categroy of the product to add to the url
                var category = _categoryFactory.Get((long)product.id_category_default);
                if (category == null)
                {
                    await _logServices.LogEvent($"Problème de récupération de l'url du produit PS", "La catégorie du produit n'a pas été trouvée");
                    _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de récupération de l'url du produit PS", "La catégorie du produit n'a pas été trouvée");
                    return _responseMessage;
                }

                // we get the product url from PS
                var productUrl = $"{_appSettings.PrestashopBaseUrl}/{category.link_rewrite?.FirstOrDefault()?.Value}/{product.id}-{product.link_rewrite?.FirstOrDefault()?.Value}.html";
                if (productUrl == null)
                {
                    await _logServices.LogEvent($"Problème de récupération de l'url du produit PS", "L'url du produit n'a pas été trouvé");
                    _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de récupération de l'url du produit PS", "L'url du produit n'a pas été trouvé");
                    return _responseMessage;
                }
                // we add the product url to the response message
                _responseMessage.Objects.Add(productUrl);


            }
            catch (Exception ex)
            {
                await _logServices.LogEvent($"Problème de récupération de l'url du produit PS", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de récupération de l'url du produit PS", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                return _responseMessage;
            }
            return _responseMessage;
        }

        // Function to clean up PS from CLI
        // It will remove all products from PS that are not in CLI
        // It will remove all combinations from PS that are active_on=0 in CLI

        public async Task<ResponseMessage> CleanPSFromCLIAsync()
        {
            var _responseMessage = new ResponseMessage();

            // we write in the log that we start the process

            await _logServices.LogEvent($"Début du processus de nettoyage des produits PS depuis CLI", "");

            // remove product from PS that are not in CLI
            await DeleteProductFromPSWithNoMatchCLIAsync();

            // select all id_t_article_version, active_on, web_on,surcommande,precommande and stock from CLI
            var listFromCli = _cliContext.TArticleVersions.Join(_cliContext.VArticleStocks, x => x.IdTArticleVersion, y => y.IdTArticleVersion, (x, y) => new { x, y })
                .Select(x => new 
                {
                    x.x.IdTArticleVersion,
                    x.x.ActiveOn,
                    x.x.WebOn,
                    x.x.Surcommande,
                    x.x.Precommande,
                    x.y.Stock
                })
                .ToList();
            // Select all combinations from PS where reference is numeric
            var dtn = new Dictionary<string, string>();
            var combinations = _combinationFactory.GetByFilter(dtn, null, null)
                .Select(x => new { Id = x.id, Reference = Convert.ToInt64(x.reference) })
                .ToList();
            // select all combinations from PS that are in listFromCli and active_on=0 or web_on=0 or (surcommande=0 or precommande=0) or stock=0
            var toDelete = combinations.Join(listFromCli, x => x.Reference, y => y.IdTArticleVersion, (x, y) => new { x, y })
                .Where(a => a.y.ActiveOn == false || a.y.WebOn == false ||  (a.y.Stock <= 0 && a.y.Surcommande == false && a.y.Precommande == false))
                .Select(x => new { x.x.Id, x.x.Reference })
                .ToList();
            
            // delete all combinations from PS that are in toDelete
            foreach (var item in toDelete)
            {
                _combinationFactory.Delete(item.Id.Value);
            }

            // deactive all products from PS that have no combinations
            // First we get all products from PS that are active, we select only the id and active property
            var dtn2 = new Dictionary<string, string>();
            dtn2.Add("active", "1");
            var products = _productFactory.GetByFilter(dtn2, null, null, new List<string> { "id", "active" });
            
            var combinaisons = _combinationFactory.GetAll().Select(x=>x.id_product).Distinct().ToList();
            
            // select all products from PS that have no combinations
            var toDelete2 = products.Where(x => !combinaisons.Contains(x.id.Value)).ToList();
            // deactive all products from PS that have no combinations
            foreach (var item in toDelete2)
            {
                item.active = 0;
                _productFactory.Update(item);
            }


         
            await _logServices.LogEvent($"Nombre de combinaisons à supprimé : {toDelete.Count}, produits désactivés : {toDelete2.Count}", "");
            _responseMessage.AddResponseMessageLine(ResponseMessageType.Information, $"Nombre de combinaisons à supprimé : {toDelete.Count}, produits désactivés : {toDelete2.Count}");

            return _responseMessage;
        }
// write a method to erase all products from PS
        public async Task<ResponseMessage> EraseAllProductsFromPSAsync()
        {
            var _responseMessage = new ResponseMessage();
            try
            {
                // we write in the log that we start the process
                await _logServices.LogEvent($"Début du processus de suppression des produits PS", "");

                // we get all the products from PS, but only the id and the reference using the factory and list fecthing only the id and the reference and filtering on cache_is_pack=0 using dictionary object to exclude pack product type
                var products = _productFactory.GetByFilter(new Dictionary<string, string> { { "cache_is_pack", "0" } }, null, null, new List<string> { "id", "reference" });

                foreach (var product in products)
                {
                    _productFactory.Delete((long)product.id);
                }
                // we right in the log that the process is finished
                await _logServices.LogEvent($"Fin du processus de suppression des produits PS", "");

            }
            catch (Exception ex)
            {
                await _logServices.LogEvent($"Problème de suppression des produits PS", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de suppression des produits PS", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                return _responseMessage;
            }
            return _responseMessage;
        }

        public async Task<List<ResponseMessage>> AddOrUpdateMultiplePSfromCLIByIdsAsync(List<long> ids, bool importLegacyImages = false, bool importStock = false)
        {
            var responseMessages = new List<ResponseMessage>();
            
            await _logServices.LogEvent("Début ajout ou mise à jour multiple de produits PS depuis CLI", "Début", 0, "t_article_entete", "Ok");
            foreach (var id in ids)
            {
                try
                {
                    var retour = await AddOrUpdatePSfromCLIByIdAsync(id, importLegacyImages, "entete", importStock);
                    responseMessages.Add(retour);
                }
                catch (Exception ex)
                {
                    await _logServices.LogEvent($"Problème lors de l'ajout ou mise à jour du produit PS depuis CLI pour l'ID : {id}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}", id, "t_article_version", "Error");
                    var errorMessage = new ResponseMessage();
                    errorMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème lors de l'ajout ou mise à jour du produit PS depuis CLI pour l'ID : {id}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                    responseMessages.Add(errorMessage);
                }
            }
            await _logServices.LogEvent("Fin ajout ou mise à jour multiple de produits PS depuis CLI", "Fin", 0, "t_article_", "Ok");
            return responseMessages;
        }
        // Method to fetch unique available_now messages from products in PS
        public async Task<ResponseMessage> GetUniqueAvailableNowMessagesFromPSAsync()
        {
            var _responseMessage = new ResponseMessage();
            try
            {
                // we get all the products available_for_order=1 from PS, but only the available_now field using the factory and list fecthing only the available_now field
                var dtn = new Dictionary<string, string>();
                dtn.Add("available_for_order", "1");
                var products = _productFactory.GetByFilter(dtn, null, null, new List<string> { "available_now" });
                

                // we select only the available_now field unique values

                var availableNowMessages = products.Select(x => x.available_now.FirstOrDefault().Value).Distinct().ToList();

                // we add the available_now messages to the response message
                _responseMessage.Objects = availableNowMessages.Cast<object>().ToList();
            }
            catch (Exception ex)
            {
                await _logServices.LogEvent($"Problème de récupération des messages de disponibilité des produits PS", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de récupération des messages de disponibilité des produits PS", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                return _responseMessage;
            }
            return _responseMessage;
        }
        // Method to fetch unique available_later messages from products in PS
        public async Task<ResponseMessage> GetUniqueAvailableLaterMessagesFromPSAsync()
        {
            var _responseMessage = new ResponseMessage();
            try
            {
                // we get all the products available_for_order=1 from PS, but only the available_later field using the factory and list fecthing only the available_later field
                var dtn = new Dictionary<string, string>();
                dtn.Add("available_for_order", "1");
                var products = _productFactory.GetByFilter(dtn, null, null, new List<string> { "available_later" });
                

                // we select only the available_later field unique values

                var availableLaterMessages = products.Select(x => x.available_later.FirstOrDefault().Value).Distinct().ToList();

                // we add the available_later messages to the response message
                _responseMessage.Objects = availableLaterMessages.Cast<object>().ToList();
            }
            catch (Exception ex)
            {
                await _logServices.LogEvent($"Problème de récupération des messages de disponibilité ultérieure des produits PS", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de récupération des messages de disponibilité ultérieure des produits PS", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                return _responseMessage;
            }
            return _responseMessage;
        }

        public async Task<ResponseMessage> UpdateAvailableNowMessageAsync(string currentMessage, string newMessage)
        {
            var _responseMessage = new ResponseMessage();
            try
            {
                // Get all products with the current available_now message
                 var dtn = new Dictionary<string, string>();
                dtn.Add("available_for_order", "1");
                dtn.Add("available_now", currentMessage);
                var productIDs = _productFactory.GetIdsByFilter(dtn, null, null);

                foreach (var product in productIDs)
                {
                    // Get the product
                    var productToUpdate = _productFactory.Get(product);
                    // Update the available_now message
                    productToUpdate.available_now = PSHelper.PSChampMultiLangue(newMessage);
                    
                  await  _productFactory.UpdateAsync(productToUpdate);
                }
await _logServices.LogEvent($"Mise à jour de {productIDs.Count} produits avec le nouveau message disponible maintenant.","",0,"","Ok");
                _responseMessage.AddResponseMessageLine(ResponseMessageType.Information, $"Mise à jour de {productIDs.Count} produits avec le nouveau message disponible maintenant.");
            }
            catch (Exception ex)
            {
                await _logServices.LogEvent($"Problème de mise à jour des messages disponibles maintenant des produits PS", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de mise à jour des messages disponibles maintenant des produits PS", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                return _responseMessage;
            }
            return _responseMessage;
        }

          public async Task<ResponseMessage> UpdateAvailableLaterMessageAsync(string currentMessage, string newMessage)
        {
            var _responseMessage = new ResponseMessage();
            try
            {
                // Get all products with the current available_now message
                var dtn = new Dictionary<string, string>();
                dtn.Add("available_for_order", "1");
                dtn.Add("available_later", currentMessage);
                var productIDs = _productFactory.GetIdsByFilter(new Dictionary<string, string> { { "available_later", currentMessage } }, null, null);

                foreach (var product in productIDs)
                {
                    // Get the product
                    var productToUpdate = _productFactory.Get(product);
                    // Update the available_now message
                    productToUpdate.available_later = PSHelper.PSChampMultiLangue(newMessage);
                    
                    await _productFactory.UpdateAsync(productToUpdate);
                }
await _logServices.LogEvent($"Mise à jour de {productIDs.Count} produits avec le nouveau message disponible ultérieurement.","",0,"","Ok");

                _responseMessage.AddResponseMessageLine(ResponseMessageType.Information, $"Mise à jour de {productIDs.Count} produits avec le nouveau message disponible ultérieurement.");
            }
            catch (Exception ex)
            {
                await _logServices.LogEvent($"Problème de mise à jour des messages disponible ultérieurement des produits PS", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de mise à jour des messages disponible ultérieurement des produits PS", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                return _responseMessage;
            }
            return _responseMessage;
        }
        
    }
}




