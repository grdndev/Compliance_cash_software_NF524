using Bukimedia.PrestaSharp.Entities;
using Bukimedia.PrestaSharp.Factories;
using CLIPrestashopConnector.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLICore.Data;
using CLICore.Models;
using Microsoft.EntityFrameworkCore;
using Bukimedia.PrestaSharp.Entities.AuxEntities;
using group = Bukimedia.PrestaSharp.Entities.AuxEntities.group;
using address = Bukimedia.PrestaSharp.Entities.address;
using product = Bukimedia.PrestaSharp.Entities.product;
using customer = Bukimedia.PrestaSharp.Entities.customer;
using category = Bukimedia.PrestaSharp.Entities.AuxEntities.category;
using image = Bukimedia.PrestaSharp.Entities.AuxEntities.image;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using CLICore.Services.Logger;
using System.Text.RegularExpressions;
using Microsoft.IdentityModel.Tokens;
using Bukimedia.PrestaSharp.Entities.FilterEntities;
using CLICore.Helpers;
using CLIPrestashopConnector.Services.PrestashopErrorDecoder;
using CLIPrestashopConnector.Services.CartRule;
using CLIPrestashopConnector.Services.Push;
using AppSettings = CLIPrestashopConnector.Models.AppSettings;

namespace CLIPrestashopConnector.Services.Customer
{
    public class CustomerService : ICustomerService
    {


        
        private readonly CustomerFactory _customerFactory;
        private readonly CountryFactory _countryFactory;
        private readonly AddressFactory _addressFactory;
        private readonly AppSettings _appSettings;
        private readonly ILogger<CustomerService> _logger;
        private readonly CLIContext _cliContext;
        private readonly IAddressService _addressService;
        private readonly ICartRuleService _cartRuleService;
        private readonly ILogService _logServices;
        private readonly IPushService _pushService;
        private readonly IPrestashopErrorDecoderService _prestashopErrorDecoderService;
        public CustomerService(IOptions<AppSettings> appSettings, ILogger<CustomerService> logger, CLIContext cliContext, IAddressService addressService, ILogService logService, IPrestashopErrorDecoderService prestashopErrorDecoderService,ICartRuleService cartRuleService, IPushService pushService)
        {
            _appSettings = appSettings?.Value ?? throw new ArgumentNullException(nameof(appSettings));
            this._customerFactory = new CustomerFactory(_appSettings.Endpoint, _appSettings.ApiKey, _appSettings.Password);
            this._countryFactory = new CountryFactory(_appSettings.Endpoint, _appSettings.ApiKey, _appSettings.Password);
            this._addressFactory = new AddressFactory(_appSettings.Endpoint, _appSettings.ApiKey, _appSettings.Password);
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _cliContext = cliContext;
            _addressService = addressService;
            this._logServices = logService;            
            this._prestashopErrorDecoderService = prestashopErrorDecoderService;
            this._cartRuleService = cartRuleService;
            this._pushService = pushService;


        }


        public async Task<ResponseMessage> AddOrUpdateCLIfromPSByIdAsync(long id, bool associatedAddress = false, bool associatedCartRule=false)
        {
            ResponseMessage _responseMessage = new ResponseMessage();
            try
            {
                customer customer = _customerFactory.Get(id);
                var email="";
                if (customer != null)
                {
                    email = customer.email;
                }
                TClient ClientCLI = new TClient();
                if (_cliContext.TClients.Where(c=>c.IdCustomerPrestashop==id || (c.Email==email && email !="")).Any())
                {
                    //update
                    if (_cliContext.TClients.Where(c=>c.IdCustomerPrestashop==id).Any())
                    {
                       ClientCLI = (from c in _cliContext.TClients
                                     where c.IdCustomerPrestashop == id
                                     select c).First(); 
                    }
                    else
                    {
                        ClientCLI = (from c in _cliContext.TClients
                                     where c.Email == email
                                     select c).First();
                    }

 
                  

                    ClientCLI.Actif = Convert.ToBoolean(customer.active);
                    ClientCLI.Titre = customer.id_gender;
                    ClientCLI.Prenom = customer.firstname;
                    ClientCLI.Nom = customer.lastname;
                    ClientCLI.Email = customer.email;
                    // pas de syncro du mot de passe !!
                    try{
                    ClientCLI.Datenaissance = System.DateOnly.FromDateTime(Convert.ToDateTime(customer.birthday));
                    }
                    catch(Exception ex)
                    {
                        ClientCLI.Datenaissance = null;
                    }

    
                    
                    ClientCLI.NewsLetter = Convert.ToBoolean(customer.newsletter);
                    ClientCLI.Commentaires = customer.note;
                    ClientCLI.NoSiret = customer.siret;
                    ClientCLI.Société = customer.company;
                    ClientCLI.Ape = customer.ape;
                    ClientCLI.ModifieLe = DateTime.Now;
                    ClientCLI.ModifiePar = "Web";
                    ClientCLI.ToSync = true;
                    ClientCLI.IdCustomerPrestashop = customer.id;

                    _cliContext.TClients.Update(ClientCLI);
                    _cliContext.SaveChanges();
                    //mise à jour du client prestashop pour stocker l'id du client CLI
                    customer.CLI_id_t_client = ClientCLI.IdTClient;
                    await _customerFactory.UpdateAsync(customer);
                 
                }
                else
                {
                    //insert
                    ClientCLI= new TClient();


                    ClientCLI.Actif = Convert.ToBoolean(customer.active);
                    ClientCLI.Titre = customer.id_gender;
                    ClientCLI.Prenom = customer.firstname;
                    ClientCLI.Nom = customer.lastname;
                    ClientCLI.Email = customer.email;
                    // pas de syncro du mot de passe !!
                    //On met "prestashop" par défaut
                    ClientCLI.Password = "prestashop";
                                        try{
ClientCLI.Datenaissance =  System.DateOnly.FromDateTime(Convert.ToDateTime(customer.birthday));
                    }
                    catch(Exception ex)
                    {
                        ClientCLI.Datenaissance = null;
                    }
                    ClientCLI.NewsLetter = Convert.ToBoolean(customer.newsletter);
                    ClientCLI.Commentaires = customer.note;
                    ClientCLI.NoSiret = customer.siret;
                    ClientCLI.Société = customer.company;
                    ClientCLI.Ape = customer.ape;
                    ClientCLI.CreeLe = DateTime.Now;
                    ClientCLI.CreePar = "Web";
                    ClientCLI.ModifieLe = DateTime.Now;
                    ClientCLI.ModifiePar = "Web";
                    ClientCLI.IdCustomerPrestashop = customer.id;
                    ClientCLI.ToSync = true;
                    _cliContext.TClients.Add(ClientCLI);
                    _cliContext.SaveChanges();

                    //mise à jour du client prestashop pour stocker l'id du nouveau client CLI
                    customer.CLI_id_t_client = ClientCLI.IdTClient;
                    await _customerFactory.UpdateAsync(customer);

                   


                }
                //On synchronise les tables annexes


                //Adresse
                if (associatedAddress)
                {
                    //On ajoute ou met à jour les adresses du client dans CLI
                    Dictionary<string, string> dtn = new Dictionary<string, string>();
                    dtn.Add("id_customer", id.ToString());
                    var clientPSAdresse = _addressFactory.GetByFilter(dtn, null, null).ToList();
                   
                    foreach (var adresse in clientPSAdresse)
                    {
                        _responseMessage.AddResponseMessageLinesFromResponseMessage(await
                            _addressService.AddOrUpdateCLIfromPSByIdAsync(adresse.id.Value));
                    }
                    //On supprime les adresses du client dans CLI qui ne sont plus dans PS
                    var clientCLIAdresse = _cliContext.TAdresses.Where(a => a.IdTClient == ClientCLI.IdTClient ).ToList();
                    foreach (var adresse in clientCLIAdresse)
                    {
                        if (!clientPSAdresse.Any(a => a.CLI_id_t_adresse == adresse.IdTAdresse))
                        {
                            _responseMessage.AddResponseMessageLinesFromResponseMessage(await
                                _addressService.DeleteCLIByIdAsync(adresse.IdTAdresse));
                        }
                    }

                    
                }

                //Avoir
                if (associatedCartRule)
                {

                    // A implémenter si besoin
                }
                //on log la fin de l'operation 
                await _logServices.LogEvent($"Mise à jour / ajout client CLI depuis PS  : {id}","",customer.CLI_id_t_client.Value , "t_client","OK") ;
                return _responseMessage;
            }
            catch (Exception ex)
            {
                await _logServices.LogEvent($"Problème de mise à jour / ajout client CLI depuis PS  : {id}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de mise à jour / ajout client CLI depuis PS : {id}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                return _responseMessage;
            }
        }

        public async Task<ResponseMessage> DeleteCLIByIdAsync(long id)
        {
            ResponseMessage _responseMessage = new ResponseMessage();
            try
            {
                var customerCLI = (from c in _cliContext.TClients
                                   where c.IdCustomerPrestashop == id
                                   select c).Single();
                _cliContext.TClients.Remove(customerCLI);
                _cliContext.SaveChanges();
                return _responseMessage;
            }
            catch (Exception ex)
            {

                await _logServices.LogEvent($"Problème de suppression d'un client CLI  : {id}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de suppression d'un client CLI  : {id}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                return _responseMessage;
            }



        }

        public async Task<ResponseMessage> AddOrUpdatePSfromCLIByIdAsync(long id, bool associatedAddress=false, bool associatedCartRule = false)
        {
            ResponseMessage _responseMessage=new ResponseMessage();
            try
            {                             

                //Récupération du client dans CLI
                var clientCLI = _cliContext.TClients.Where(c => c.IdTClient == id).FirstOrDefault();


                // On teste si le client possède un email et un mot de passe : dans le cas contraire, on le ne traite pas.
                // Sauf si c'est déjà un client prestashop


                if ((!clientCLI.Email.IsNullOrEmpty() && PSHelper.isPlaintextPassword(!clientCLI.Password.IsNullOrEmpty()? clientCLI.Password: "")) || clientCLI.IdCustomerPrestashop is not null)
                {
                    //Vérification si le client existe déjà dans PS, dans ce cas on MAJ, sinon on ajoute

                    Dictionary<string, string> dtn = new Dictionary<string, string>();
                    dtn.Add("CLI_id_t_client", id.ToString());
                    customer customer = _customerFactory.GetByFilter(dtn, null, null).FirstOrDefault();
                    //validation ape '/^[0-9]{3,4}[a-zA-Z]{1}$/s'
                    string ApePattern = @"^[0-9]{3,4}[a-zA-Z]{1}$";

                    if (customer == null)
                    {
                        //Vérification si l'email existe déjà dans PS, dans ce cas on log une erreur et on retourne responseMessage
                        Dictionary<string, string> dtn2 = new Dictionary<string, string>();
                        dtn2.Add("email", clientCLI.Email.Trim());
                        customer customer2 = _customerFactory.GetByFilter(dtn2, null, null).FirstOrDefault();
                        if (customer2 != null)
                        {
                            await _logServices.LogEvent($"Problème de mise à jour / ajout client CLI depuis PS  : {id}", $"L'email {clientCLI.Email} existe déjà dans Prestashop", id, "t_client", "Erreur");
                            _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de mise à jour / ajout client CLI depuis PS  : {id}", $"L'email {clientCLI.Email} existe déjà dans Prestashop");
                            return _responseMessage;
                        }
                        
                        var cust = new customer()
                        {
                            //id = clientCLI.IdTClient,
                            active = Convert.ToInt32(clientCLI.Actif),
                            id_gender = clientCLI.Titre is null ? 0 : clientCLI.Titre,
                            // firstname : Seules les lettres et le point (.), suivi d'un espace, sont autorisés. Sinon en remplace par une chaine vide
                            firstname = Regex.Replace(clientCLI.Prenom is null ? "" : clientCLI.Prenom, @"[^a-zA-Z. ]", ""),
                            // lastname : Seules les lettres et le point (.), suivi d'un espace, sont autorisés. Sinon en remplace par une chaine vide
                            lastname = Regex.Replace(clientCLI.Nom is null ? "" : clientCLI.Nom, @"[^a-zA-Z. ]", ""),
                            email = clientCLI.Email.Trim(),
                            passwd = clientCLI.Password,
                            birthday = clientCLI.Datenaissance?.ToString("yyyy-MM-dd"),
                            newsletter = Convert.ToInt32(clientCLI.NewsLetter),
                            note = clientCLI.Commentaires,
                            date_add = clientCLI.CreeLe?.ToString("yyyy-MM-dd"),
                            siret = clientCLI.NoSiret,
                            company = clientCLI.Société,
                            ape = Regex.IsMatch(clientCLI.Ape is null ? "" : clientCLI.Ape, ApePattern) ? clientCLI.Ape : "",
                            CLI_id_t_client = clientCLI.IdTClient,
                            id_default_group = 3,
                            associations = new AssociationsCustomer
                            {
                                groups = new List<group>
                        {
                            new group{ id=3}
                        }



                            }
                        };
                        cust = await _customerFactory.AddAsync(cust);

                        clientCLI.IdCustomerPrestashop = cust.id;
                        clientCLI.ToSync = true;
                        _cliContext.TClients.Update(clientCLI);
                        _cliContext.SaveChanges();
                       
                    }
                    else
                    {

                        //var cust = await _customerFactory.GetAsync((long)clientCLI.IdCustomerPrestashop);
                        var cust = await _customerFactory.GetAsync(customer.id.Value);

                         //Vérification si l'email existe déjà dans PS avec un CLI_id_t_client different, dans ce cas on log une erreur et on retourne responseMessage
                        Dictionary<string, string> dtn2 = new Dictionary<string, string>();
                        dtn2.Add("email", clientCLI.Email.Trim());
                        customer customer2 = _customerFactory.GetByFilter(dtn2, null, null).FirstOrDefault();
                        if (customer2 != null)
                        {
                            if (customer2.CLI_id_t_client != cust.CLI_id_t_client)
                            {
                            await _logServices.LogEvent($"Problème de mise à jour / ajout client CLI depuis PS  : {id}", $"L'email {clientCLI.Email} existe déjà dans Prestashop", id, "t_client", "Erreur");
                            _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de mise à jour / ajout client CLI depuis PS  : {id}", $"L'email {clientCLI.Email} existe déjà dans Prestashop");
                            return _responseMessage;
                            }

                        }


                        cust.active = Convert.ToInt32(clientCLI.Actif);
                        cust.id_gender = clientCLI.Titre is null ? 0 : clientCLI.Titre;
                        // firstname : Seules les lettres et le point (.), suivi d'un espace, sont autorisés. Sinon en remplace par une chaine vide
                        cust.firstname = Regex.Replace(clientCLI.Prenom is null ? "" : clientCLI.Prenom, @"[^a-zA-Z. ]", "");
                        // lastname : Seules les lettres et le point (.), suivi d'un espace, sont autorisés. Sinon en remplace par une chaine vide
                        cust.lastname = Regex.Replace(clientCLI.Nom is null ? "" : clientCLI.Nom, @"[^a-zA-Z. ]", "");

                        cust.email = (String.IsNullOrWhiteSpace(clientCLI.Email)) ? "noemail@chinook-leucate.com" : clientCLI.Email.Trim();
                        //On ne synchronise pas le mot de passe 
                        //cust.passwd = (String.IsNullOrWhiteSpace(clientCLI.Password)) ? "nopassword1234" : clientCLI.Password;
                        cust.birthday = clientCLI.Datenaissance?.ToString("yyyy-MM-dd");
                        cust.newsletter = Convert.ToInt32(clientCLI.NewsLetter);
                        cust.note = clientCLI.Commentaires;
                        cust.date_add = clientCLI.CreeLe?.ToString("yyyy-MM-dd");
                        cust.siret = clientCLI.NoSiret;
                        cust.company = clientCLI.Société;
                        cust.ape = Regex.IsMatch(clientCLI.Ape is null ? "" : clientCLI.Ape, ApePattern) ? clientCLI.Ape : "";
                        cust.id_default_group = 3;

                        await _customerFactory.UpdateAsync(cust);
                       clientCLI.IdCustomerPrestashop = cust.id;
                        clientCLI.ToSync = true;
                        _cliContext.TClients.Update(clientCLI);
                        _cliContext.SaveChanges();
                    }

                    //On synchronise les tables annexes


                    //Adresse
                    if (associatedAddress)
                    {
                        var clientCLIAdresse = _cliContext.TAdresses.Where(c => c.IdTClient == id).ToList();
                        foreach (var adresse in clientCLIAdresse)
                        {
                            _responseMessage.AddResponseMessageLinesFromResponseMessage(await _addressService.AddOrUpdatePSfromCLIByIdAsync(adresse.IdTAdresse));
                            
                        }
                    }


                    //Avoirs
                    if (associatedCartRule)
                    {
                        var clientCLIAvoir = _cliContext.TAvoirs.Where(c => c.IdTClient == id).ToList();
                        foreach (var avoir in clientCLIAvoir)
                        {
                            _responseMessage.AddResponseMessageLinesFromResponseMessage(await _cartRuleService.AddOrUpdatePSfromCLIByIdAsync(avoir.IdTAvoir));
                        }
                    }

                    if (_responseMessage.ConstainsError)
                    {
                        await _logServices.LogEvent($"Problème de mise à jour / ajout client PS depuis CLI   : {id}", _responseMessage.ResponseMessageLines.First().Detail, id, "t_client", "Erreur");
                    }
                    else
                    {
                        await _logServices.LogEvent($"Mise à jour / ajout Client PS depuis CLI  : {id}", "", id, "t_client", "Ok");
                    }


                    return _responseMessage;
                }
                else
                {
                    await _logServices.LogEvent($"Problème de mise à jour / ajout client PS depuis CLI  : {id}","Il ne remplit pas les conditions de synchronisation (email ou mot de passe)", id, "t_client","Erreur");
 
                    _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, "Pas de mise à jour de PS pour le client : {id}","Il ne remplit pas les conditions de synchronisation (email ou mot de passe)");
                    return _responseMessage;
                }

               


            }
            catch (Exception ex)
            {
                await _logServices.LogEvent($"Problème de mise à jour / ajout client PS depuis CLI  : {id}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}", id, "t_client", "Erreur");
               //var error = _prestashopErrorDecoderService.Decode(ex.Message);
                _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de mise à jour / ajout client PS depuis CLI  : {id}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}"); 
                return _responseMessage;
            }
            
        }

        public async Task<ResponseMessage> DeletePSByIdAsync(long id)
        {
            ResponseMessage _responseMessage = new ResponseMessage();
            try
            {
                await _customerFactory.DeleteAsync(id);
                return _responseMessage;
            }
            catch (Exception ex)
            {

                await _logServices.LogEvent($"Problème de suppression d'un client PS  : {id}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de suppression d'un client PS  : {id}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                return _responseMessage;
            }
        }


// Import des clients depuis CLI
        public async Task<ResponseMessage> ImportFromCLIAsync(bool associatedAddress = false, bool associatedCartRule=false, DateTime? UpdatedDateFrom = null, bool onlyErrors = false) {
            var _responseMessage = new ResponseMessage();
            try
            {
                //On recupere la liste des clients CLI à importer (champ ToSync = true ou IdCustomerPrestashop different de null)
                var toImportClient = _cliContext.TClients.Where(c => c.ToSync == true || c.IdCustomerPrestashop != null);
                // On recupere les avoirs des clients présents dans la liste toImportClient
                var toImportClientIds = toImportClient.Select(c => c.IdTClient).ToList();
                var toImportAvoir = _cliContext.TAvoirs.Where(c => toImportClientIds.Contains(c.IdTClient.Value));
                var logOnlyErrors = _cliContext.VLogs.Where(c => c.LogAssociatedRecordType == "t_client" && c.LogType == "Erreur").Select(c => c.LogAssociatedRecordId).OrderBy(c => c).ToList();

   
                IOrderedQueryable<long> toImport = new List<long>().AsQueryable().OrderBy(c => c);

                if (UpdatedDateFrom is not null)
                {
                    toImport = toImportClient.Where(c => c.ModifieLe >= UpdatedDateFrom || c.CreeLe >= UpdatedDateFrom).Select(c => c.IdTClient).OrderBy(c => c);
                    var toImport3 = toImportAvoir.Where(c => c.CreeLe >= UpdatedDateFrom || c.ModifieLe >= UpdatedDateFrom || c.UtiliseLe >= UpdatedDateFrom).Select(c => c.IdTClient.Value).OrderBy(c => c);

                    // on reunit les deux listes
                    if (toImport.Count() > 0)
                    {
                        toImport = (IOrderedQueryable<long>)toImport.Union(toImport3);
                    }
                    else if (toImport3.Count() > 0)
                    {
                        toImport = toImport3;
                    }
                }
                else 
                {
                    toImport = toImportClient.Select(c => c.IdTClient).OrderBy(c => c);
                }


            if (onlyErrors)
                {
                    // on teste si le client est en erreur en regardant vlog
                    toImport = (IOrderedQueryable<long>)toImport.Where(c => logOnlyErrors.Contains(c));


                }
                //enregistre une entree dans la table de log pour indiquer le début de l'import
                await _logServices.LogEvent($"Import clients PS depuis CLI", $"Import clients PS depuis CLI");

                // on envoie une notification push pour indiquer le début de l'import 
                await _pushService.Notify("Import client PS", $"Import clients PS démarré");

               foreach (var client in toImport.ToList())
                {

await AddOrUpdatePSfromCLIByIdAsync(client, associatedAddress, associatedCartRule);

                }
//enregistre une entree dans la table de log pour indiquer la fin de l'import
                await _logServices.LogEvent($"Import clients PS depuis CLI terminé", $"Import clients PS depuis CLI terminé");

            }
            catch (Exception ex)
            {
               await _logServices.LogEvent($"Problème d'import clients PS depuis CLI", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
               _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème d'import clients PS depuis CLI", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
               return _responseMessage;
            }

            // on envoie une notification push pour indiquer la fin de l'import 
            await _pushService.Notify("Import client PS", $"Import clients PS terminé");
            return _responseMessage;
        }




        #region Prestashop

        //Add
        public async Task<customer> PSAddCustomerAsync(TClient clientCLI)
        {
            var cust = new customer()
            {
                //id = clientCLI.IdTClient,
                active = Convert.ToInt32(clientCLI.Actif),
                firstname = clientCLI.Prenom,
                lastname = clientCLI.Nom,
                email = (String.IsNullOrWhiteSpace(clientCLI.Email)) ? "noemail@chinook-leucate.com" : clientCLI.Email,
                passwd = (String.IsNullOrWhiteSpace(clientCLI.Password)) ? "nopassword1234" : clientCLI.Password,
                birthday = clientCLI.Datenaissance?.ToString("yyyy-MM-dd"),
                newsletter = Convert.ToInt32(clientCLI.NewsLetter),
                note = clientCLI.Commentaires,
                date_add = clientCLI.CreeLe?.ToString("yyyy-MM-dd"),
                siret = clientCLI.NoSiret,
                company = clientCLI.Société,
                //id_t_client_CLI = clientCLI.IdTClient,
                id_default_group = 3,
                associations = new AssociationsCustomer
                {
                    groups = new List<group>
                        {
                            new group{ id=3}
                        }



                }
            };
            cust = await _customerFactory.AddAsync(cust);

            return cust;
        }


        //Update
        public async Task<bool> PSUpdateCustomerAsync(TClient clientCLI)
        {
            var cust = await _customerFactory.GetAsync((long)clientCLI.IdCustomerPrestashop);
            cust.active = Convert.ToInt32(clientCLI.Actif);
            cust.firstname = clientCLI.Prenom;
            cust.lastname = clientCLI.Nom;
            cust.email = (String.IsNullOrWhiteSpace(clientCLI.Email)) ? "noemail@chinook-leucate.com" : clientCLI.Email;
            cust.passwd = (String.IsNullOrWhiteSpace(clientCLI.Password)) ? "nopassword1234" : clientCLI.Password;
            cust.birthday = clientCLI.Datenaissance?.ToString("yyyy-MM-dd");
            cust.newsletter = Convert.ToInt32(clientCLI.NewsLetter);
            cust.note = clientCLI.Commentaires;
            cust.date_add = clientCLI.CreeLe?.ToString("yyyy-MM-dd");
            cust.siret = clientCLI.NoSiret;
            cust.company = clientCLI.Société;
            //cust.id_t_client_CLI = clientCLI.IdTClient;
            cust.id_default_group = 3;




 

            try
            {
                await _customerFactory.UpdateAsync(cust);
                return true;
            }
            catch (Exception ex)

            {
                return false;

            }
           

        }

        //Delete
        public async Task<bool> PSDeleteCustomerAsync(long id)
        {
           
            try
            {
                await _customerFactory.DeleteAsync(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            

            
        }

        //Get
        public  async Task<customer> PSGetCustomerAsync(long id)
        {
            var cust = _customerFactory.Get(id);

            return cust;

        }

        #endregion

        #region CLI

        #endregion

        #region CrossLogic

        public async Task<bool> SyncFromCLI(long id)
        {

            var customerCLI = (from c in _cliContext.TClients
                               where c.IdTClient == id
                               select c).Single();

            // On teste si le client a deja une reference prestashop, si oui on le met à jour sinon on l'ajoute
            if (customerCLI.IdCustomerPrestashop is not null)
            {
                // Mise à jour
                await this.PSUpdateCustomerAsync(customerCLI);
            }
            else
            {
                // Ajout
                var customer = await this.PSAddCustomerAsync(customerCLI);

                // mise à jour de la fiche client correspondant dans CLI

                customerCLI.IdCustomerPrestashop = customer.id;
                _cliContext.TClients.Update(customerCLI);
                await _cliContext.SaveChangesAsync();
            }
            
                     
  

                try
                {




                //Ajouter adresse par defaut
                

                        //var customerCLIAdresse = (from a in _cliContext.TAddresse
                        //                          where a.IdTClient == c.IdTClient
                        //                          select a).ToList();
                        //foreach (var a in customerCLIAdresse)
                        //{
                        //    AddAdresseFromCustomerAdresseCLI(a, id);
                        //}
                        //var customerCLIAvoir = (from a in dbContext.TAvoir
                        //                        where a.IdTClient == c.IdTClient
                        //                        select a).ToList();
                        //foreach (var a in customerCLIAvoir)
                        //{

                        //    AddCartRulesFromAvoirCLI(a, id);
                        //}
     
         

                }
                catch (Bukimedia.PrestaSharp.PrestaSharpException ex)
                {
                    //Log("Problème d'importation client (id_t_client_CLI): " + c.IdTClient);
                    // Console.WriteLine(ex.Message);
                }
           






            return true;
        }

        public async Task<bool> FullSyncFromCLI(long id)
        {

            var customerCLI = (from c in _cliContext.TClients
                               where c.IdTClient == id
                               select c).Single();

            // On teste si le client a deja une reference prestashop, si oui on le met à jour sinon on l'ajoute
            if (customerCLI.IdCustomerPrestashop is not null)
            {
                // Mise à jour
                await this.PSUpdateCustomerAsync(customerCLI);
            }
            else
            {
                // Ajout
                var customer = await this.PSAddCustomerAsync(customerCLI);

                // mise à jour de la fiche client correspondant dans CLI

                customerCLI.IdCustomerPrestashop = customer.id;
                _cliContext.TClients.Update(customerCLI);
                await _cliContext.SaveChangesAsync();
            }




            try
            {




                //Ajouter adresse par defaut
                //await _addressService.SyncFromPSById(customerCLI.IdTClient);

                //var customerCLIAdresse = (from a in _cliContext.TAddresse
                //                          where a.IdTClient == c.IdTClient
                //                          select a).ToList();
                //foreach (var a in customerCLIAdresse)
                //{
                //    AddAdresseFromCustomerAdresseCLI(a, id);
                //}
                //var customerCLIAvoir = (from a in dbContext.TAvoir
                //                        where a.IdTClient == c.IdTClient
                //                        select a).ToList();
                //foreach (var a in customerCLIAvoir)
                //{

                //    AddCartRulesFromAvoirCLI(a, id);
                //}



            }
            catch (Bukimedia.PrestaSharp.PrestaSharpException ex)
            {
                //Log("Problème d'importation client (id_t_client_CLI): " + c.IdTClient);
                // Console.WriteLine(ex.Message);
            }







            return true;
        }



        public async Task<bool> SyncFromPS(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> FullSyncFromPS(long id)
        {
            throw new NotImplementedException();
        }

        #endregion









        public async Task<customer> GetPSByIdAsync(long id)
        {
            var customer = await _customerFactory.GetAsync(id);
            return customer;
        }

        public async Task<IEnumerable<customer>> ListPSAsync()
        {
            
            var customers = await _customerFactory.GetAllAsync();
           
            return customers;


        }
        public  async Task<IEnumerable<TClient>> ListCLIAsync()
        {
           
            var customers =  _cliContext.TClients.ToList();
           
            return customers;


        }

        public async Task<bool> UpdatePSByIdAsync(long id, string modification)
        {
            customer customer = await _customerFactory.GetAsync(id);
            customer.lastname = modification;
            _customerFactory.Update(customer);
            return true;
        }

        public async Task<bool> DeleteAllCustomer()
        {
            var customers = _customerFactory.GetAll();
            
            foreach (customer c in customers)
            {
                _customerFactory.Delete(c);
            }
            return true;
        }

        public async Task<bool> ImportPSfromCLI()
        {
            await this.DeleteAllCustomer();
            var customerCLI = (from c in _cliContext.TClients
                               where c.IdTClient == 18
                               select c).ToList();


            var i = 1;
            foreach (var c in customerCLI)
            {
                //Vérifications:
                // - email
                // ....

                try
                {

                    var id = AddCustomerFromCustomerCLI(c);
                    if (id > 0)
                    {
                        //Ajouter adresse par defaut
                        AddAdresseFromCustomerCLI(c, id);

                        //var customerCLIAdresse = (from a in _cliContext.TAddresse
                        //                          where a.IdTClient == c.IdTClient
                        //                          select a).ToList();
                        //foreach (var a in customerCLIAdresse)
                        //{
                        //    AddAdresseFromCustomerAdresseCLI(a, id);
                        //}
                        //var customerCLIAvoir = (from a in dbContext.TAvoir
                        //                        where a.IdTClient == c.IdTClient
                        //                        select a).ToList();
                        //foreach (var a in customerCLIAvoir)
                        //{

                        //    AddCartRulesFromAvoirCLI(a, id);
                        //}
                        Console.WriteLine(i);
                        i++;
                    }
                    else
                    {
                        //Log("Problème d'importation client (id_t_client_CLI): " + c.IdTClient);
                    }

                }
                catch (Bukimedia.PrestaSharp.PrestaSharpException ex)
                {
                    //Log("Problème d'importation client (id_t_client_CLI): " + c.IdTClient);
                    // Console.WriteLine(ex.Message);
                }
            }






            return true;
        }

        private long AddCustomerFromCustomerCLI(TClient clientCLI)
        {
            try
            {
                
                var cust = new customer()
                {
                    //id = clientCLI.IdTClient,
                    active = Convert.ToInt32(clientCLI.Actif),
                    firstname = clientCLI.Prenom,
                    lastname = clientCLI.Nom,
                    email = (String.IsNullOrWhiteSpace(clientCLI.Email)) ? "noemail@chinook-leucate.com" : clientCLI.Email,
                    passwd = (String.IsNullOrWhiteSpace(clientCLI.Password)) ? "nopassword1234" : clientCLI.Password,
                    birthday = clientCLI.Datenaissance?.ToString("yyyy-MM-dd"),
                    newsletter = Convert.ToInt32(clientCLI.NewsLetter),
                    note = clientCLI.Commentaires,
                    date_add = clientCLI.CreeLe?.ToString("yyyy-MM-dd"),
                    siret = clientCLI.NoSiret,
                    company = clientCLI.Société,
                    //id_t_client_CLI = clientCLI.IdTClient,
                    id_default_group = 3,
                    associations = new AssociationsCustomer
                    {
                        groups = new List<group>
                        {
                            new group{ id=3}
                        }



                    }
                };
                cust = _customerFactory.Add(cust);
                Dictionary<string, string> dtn = new Dictionary<string, string>();
                //dtn.Add("id_t_client_CLI", clientCLI.IdTClient.ToString());
                //cust = _customerFactory.GetByFilter(dtn, null, null).First();

                //cust.date_add = clientCLI.CreeLe?.ToString("yyyy-MM-dd");
                //_customerFactory.Update(cust);

                clientCLI.IdCustomerPrestashop = (long)cust.id;
                _cliContext.TClients.Update(clientCLI);
                _cliContext.SaveChanges();

                return (long)cust.id;
            }
            catch (Exception ex)
            {
                //Log("Problème d'importation client (id_t_client°CLI): " + clientCLI.IdTClient);
                return 0;
            }





        }

        private long GetPays(string pays)
        {
            Dictionary<string, string> dtn = new Dictionary<string, string>();
            dtn.Add("name", pays);
            var paysId = _countryFactory.GetIdsByFilter(dtn, null, null).FirstOrDefault();

            return paysId;
        }

        private long AddAdresseFromCustomerCLI(TClient clientCLI, long id_customer)
        {
            try
            {
                var adresse = new address()
                {
                    id_customer = id_customer,
                    id_country = GetPays(clientCLI.Pays) == 0 ? 8 : GetPays(clientCLI.Pays),
                    alias = "Par défaut",
                    company = clientCLI.Société,
                    lastname = clientCLI.Nom,
                    firstname = clientCLI.Prenom,
                    vat_number = clientCLI.NoTva,
                    address1 = clientCLI.AdresseL1,
                    address2 = String.Concat(clientCLI.AdresseL2, " ", clientCLI.AdresseL3),
                    postcode = clientCLI.CodePostal,
                    city = clientCLI.Ville,
                    phone = clientCLI.Tel,
                    //fax = clientCLI.Fax,
                    dni = clientCLI.NumeroIdentite


                };
                //ajout de l'adresse
                _addressFactory.Add(adresse);
            }
            catch (Exception ex)
            {
                //Log("Problème d'importation adresse client : " + id_customer);
                return 0;
            }

            return 1;



        }

        /// <summary>
        /// Permet de mettre à jour ou supprimer un client CLI depuis PS
        /// On ne synchronise jamais le mot de passe vers CLI pour des raisons de sécurité
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public  async Task<bool> UpdateCLIfromPSByIdAsync(long id)
        {
            
            customer customer = _customerFactory.Get(id);
            
            //vérification si le client existe dans CLI, dans ce cas on MAJ sinon on ajoute


            if (_cliContext.TClients.Where(c => c.IdCustomerPrestashop == id).Any())
            {
                //update
                var customerCLI = (from c in _cliContext.TClients
                                   where c.IdCustomerPrestashop == id
                                   select c).Single();

                customerCLI.Actif = Convert.ToBoolean(customer.active);
                customerCLI.Nom = customer.lastname;
                customerCLI.Prenom = customer.firstname;
                customerCLI.Email = customer.email;
                customerCLI.Datenaissance = System.DateOnly.FromDateTime(Convert.ToDateTime(customer.birthday));
                customerCLI.NewsLetter = Convert.ToBoolean(customer.newsletter);
                customerCLI.Commentaires = customer.note;
                customerCLI.NoSiret = customer.siret;
                customerCLI.Société = customer.company;

                _cliContext.TClients.Update(customerCLI);
                _cliContext.SaveChanges();

               

            }
            else
            {
                //insert
                var customerCLI = new TClient();
                customerCLI.Actif = Convert.ToBoolean(customer.active);
                customerCLI.Nom = customer.lastname;
                customerCLI.Prenom = customer.firstname;
                customerCLI.Email = customer.email;
                customerCLI.Datenaissance = System.DateOnly.FromDateTime(Convert.ToDateTime(customer.birthday));
                customerCLI.NewsLetter = Convert.ToBoolean(customer.newsletter);
                customerCLI.Commentaires = customer.note;
                customerCLI.NoSiret = customer.siret;
                customerCLI.Société = customer.company;
                customerCLI.IdCustomerPrestashop = customer.id;

                _cliContext.TClients.Add(customerCLI);
                _cliContext.SaveChanges();
            }
            return true;

        }

        public async Task<bool> CustomerFromCLItoPS()
        {
            var result = true;

            // Lister les clients à synchroniser
            // Pour chaque client, on regarde si le client existe dans PS
            // S'il existe, on mets à jour
            // sinon on insert


            return result;
        }

        public async Task<ResponseMessage> AddOrUpdateAvoirPSfromCLIByIdAsync(long id)
        {
            ResponseMessage _responseMessage = new ResponseMessage();
            // on log le début de l'opération
            await _logServices.LogEvent($"Début de mise à jour / ajout avoir PS depuis CLI  : {id}", "", id, "t_client", "Information");
            try
            {
                var clientCLIAvoir = _cliContext.TAvoirs.Where(c => c.IdTClient == id).ToList();
                foreach (var avoir in clientCLIAvoir)
                {
                    _responseMessage.AddResponseMessageLinesFromResponseMessage(await _cartRuleService.AddOrUpdatePSfromCLIByIdAsync(avoir.IdTAvoir));
                }
            }
            catch (System.Exception ex)
            {

                //on loggue l'erreur
                await _logServices.LogEvent($"Problème de mise à jour / ajout avoir client PS depuis CLI  : {id}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}", id, "t_client", "Erreur");
               //var error = _prestashopErrorDecoderService.Decode(ex.Message);
                _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de mise à jour / ajout client PS depuis CLI  : {id}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}"); 

            }
            // on log la fin de l'opération
            await _logServices.LogEvent($"Mise à jour / ajout avoir client PS depuis CLI  : {id}", $"Fin de l'opération", id, "t_client", "Ok");


            return _responseMessage;
        }

        // write a method to erase all customers from PS
        public async Task<ResponseMessage> EraseAllCustomersFromPSAsync()
        {
            var _responseMessage = new ResponseMessage();
            try
            {
                // we write in the log that we start the process
                await _logServices.LogEvent($"Début du processus de suppression des Client PS", "");

                // we get all the products from PS, but only the id and the reference using the factory and list fecthing only the id and the reference and filtering on cache_is_pack=0 using dictionary object to exclude pack product type
                var customers = _customerFactory.GetAll();

                foreach (var customer in customers)
                {
                    _customerFactory.Delete((long)customer.id);
                }

                // we right in the log that the process is finished
                await _logServices.LogEvent($"Fin du processus de suppression des clients PS", "");

            }
            catch (Exception ex)
            {
                await _logServices.LogEvent($"Problème de suppression des client PS", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de suppression des client PS", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                return _responseMessage;
            }
            return _responseMessage;
        }
    }
}
