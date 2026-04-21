using System;
using System.Reflection;
using Bukimedia.PrestaSharp.Entities;
using Bukimedia.PrestaSharp.Entities.AuxEntities;
using Bukimedia.PrestaSharp.Entities.FilterEntities;
using Bukimedia.PrestaSharp.Factories;
using CLICore.Data;
using CLICore.Models;
using CLICore.Services.Logger;
using CLIPrestashopConnector.Models;
using CLIPrestashopConnector.Services.Country;
using CLIPrestashopConnector.Services.Customer;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using customer = Bukimedia.PrestaSharp.Entities.customer;
using address = Bukimedia.PrestaSharp.Entities.address;
using country = Bukimedia.PrestaSharp.Entities.country;
using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;
using AppSettings = CLIPrestashopConnector.Models.AppSettings;

namespace CLIPrestashopConnector.Services.Address
{
	public class AddressService: IAddressService
	{
        private readonly AppSettings _appSettings;
        private readonly AddressFactory _addressFactory;
        private readonly CustomerFactory _customerFactory;
        private readonly CLIContext _cliContext;
        private readonly ICountryService _countryService;
        private readonly ILogService _logServices;


        public AddressService(IOptions<AppSettings> appSettings, CLIContext cliContext, ICountryService countryService, ILogService logService)
		{
            this._appSettings = appSettings?.Value ?? throw new ArgumentNullException(nameof(appSettings));
            this._addressFactory = new AddressFactory(_appSettings.Endpoint, _appSettings.ApiKey, _appSettings.Password);
            this._cliContext = cliContext;
            this._countryService = countryService;
            this._customerFactory = new CustomerFactory(_appSettings.Endpoint, _appSettings.ApiKey, _appSettings.Password);
            this._logServices = logService;

        }



        public async Task<ResponseMessage> AddOrUpdateCLIfromPSByIdAsync(long id)
        {
            ResponseMessage _responseMessage = new ResponseMessage();
            try
            {
                address address = _addressFactory.Get(id);

                customer customer = _customerFactory.Get(address.id_customer.Value);

                country country = await _countryService.PSGetCountryAsync(address.id_country.Value);

                var pays = _cliContext.TPays.Where(c => c.CodePays == country.iso_code).Select(c => c.Libelle).FirstOrDefault();

                //vérification si l'adresse client existe dans CLI, dans ce cas on MAJ sinon on ajoute


                if (_cliContext.TAdresses.Where(c => c.IdAddressPrestashop == id || c.IdTAdresse== address.CLI_id_t_adresse).Any())
                {
                    //update
                    var AdresseCLI = (from c in _cliContext.TAdresses
                                      where c.IdAddressPrestashop == id || c.IdTAdresse== address.CLI_id_t_adresse
                                      select c).Single();


                    AdresseCLI.IdAddressPrestashop = address.id;
                    AdresseCLI.IdTClient = customer.CLI_id_t_client;
                    AdresseCLI.Libelle = address.alias;
                    AdresseCLI.Société = address.company;
                    AdresseCLI.Nom = address.lastname;
                    AdresseCLI.Prenom = address.firstname;
                    AdresseCLI.AdresseL1 = address.address1;
                    AdresseCLI.AdresseL2 = address.address2;
                    AdresseCLI.CodePostal = address.postcode;
                    AdresseCLI.Ville = address.city;
                    AdresseCLI.Pays = pays;
                    AdresseCLI.Autre = address.other;
                    AdresseCLI.NoTva = address.vat_number;
                    AdresseCLI.Tel = address.phone;
                    AdresseCLI.Mobile = address.phone_mobile;
                    AdresseCLI.NumeroIdentite = address.dni;
                    AdresseCLI.ModifieLe = DateTime.Now;
                    AdresseCLI.ModifiePar = "Web";


                    _cliContext.TAdresses.Update(AdresseCLI);
                    _cliContext.SaveChanges();



                }
                else
                {
                    //insert
                    var AdresseCLI = new TAdresse();
                    AdresseCLI.IdAddressPrestashop = address.id;
                    AdresseCLI.IdTClient = customer.CLI_id_t_client;
                    AdresseCLI.Libelle = address.alias;
                    AdresseCLI.Société = address.company;
                    AdresseCLI.Nom = address.lastname;
                    AdresseCLI.Prenom = address.firstname;
                    AdresseCLI.AdresseL1 = address.address1;
                    AdresseCLI.AdresseL2 = address.address2;
                    AdresseCLI.CodePostal = address.postcode;
                    AdresseCLI.Ville = address.city;
                    AdresseCLI.Pays = pays;
                    AdresseCLI.Autre = address.other;
                    AdresseCLI.NoTva = address.vat_number;
                    AdresseCLI.Tel = address.phone;
                    AdresseCLI.Mobile = address.phone_mobile;
                    AdresseCLI.NumeroIdentite = address.dni;
                    AdresseCLI.CreeLe = DateTime.Now;
                    AdresseCLI.CreePar = "Web";
                    AdresseCLI.ModifieLe = DateTime.Now;
                    AdresseCLI.ModifiePar = "Web";

                    _cliContext.TAdresses.Add(AdresseCLI);
                    _cliContext.SaveChanges();

                    //mise à jour de l'adresse du client prestashop pour stocker l'id de la nouvelle adresse

                    address.CLI_id_t_adresse = AdresseCLI.IdTAdresse;
                    await _addressFactory.UpdateAsync(address);

                }

                try {
 // On recupère l'adresse de la fiche client CLI
                var clientCLI = _cliContext.TClients.Where(c => c.IdTClient == customer.CLI_id_t_client).FirstOrDefault();

                // Si le champ ville est vide, on met à jour le champ ville, codepostal, adressel1, adressel2, adressel3, pays de la fiche client CLI
                if (clientCLI != null && string.IsNullOrEmpty(clientCLI.Ville))
                {
                    clientCLI.Ville = address.city;
                    clientCLI.CodePostal = address.postcode;
                    clientCLI.AdresseL1 = address.address1;
                    clientCLI.AdresseL2 = address.address2;
                    
                    clientCLI.Pays = pays;
                    _cliContext.Update(clientCLI);
                    _cliContext.SaveChanges();
                }

                }
                catch (Exception ex)
                {

                }
               

                return _responseMessage;
            }
            catch (Exception ex)
            {
                await _logServices.LogEvent($"Problème de mise à jour / ajout d'adresse client CLI  : {id}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de mise à jour / ajout d'adresse client CLI  : {id}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                return _responseMessage;
            }
            

        }


        public async Task<ResponseMessage> AddOrUpdatePSfromCLIByIdAsync(long id)
        {
            ResponseMessage _responseMessage = new ResponseMessage();
            try
            {
                //Récupération de l'adresse dans CLI

                var adresseCLI = _cliContext.TAdresses.Where(c => c.IdTAdresse == id).FirstOrDefault();
                var clientCLI = _cliContext.TClients.Where(c => c.IdTClient == adresseCLI.IdTClient).FirstOrDefault();
                var paysCli = _cliContext.TPays.Where(c => c.Libelle == adresseCLI.Pays).FirstOrDefault();

                //vérification si l'adresse client existe dans PS, dans ce cas on MAJ sinon on ajoute
                Dictionary<string, string> dtn = new Dictionary<string, string>();
                dtn.Add("CLI_id_t_adresse", id.ToString());
                address address = _addressFactory.GetByFilter(dtn, null, null).FirstOrDefault();
                var country = await _countryService.PSGetCountryByIsoCodeAsync(paysCli.CodePays);

                if (address == null)
                {
                    //insertion
                    address = new address();
                    address.id_customer = clientCLI.IdCustomerPrestashop;
                    address.id_country = country.id;
                    //alias: Caractères interdits: <>={}  On les remplace par une chaine vide
                    address.alias = Regex.Replace(adresseCLI.Libelle, @"[<>={}]", "").Substring(0, Math.Min(adresseCLI.Libelle.Length, 32));
                    //Caractères interdits: <>={}    On les remplace par une chaine vide    
                    // Sinon en remplace par une chaine vide             
                    address.company = Regex.Replace(adresseCLI.Société, @"[<>={}]", "");
                    //Caractères interdits: 0-9!<>,;?=+()@#"�{}_$%:
                    //Sinon en remplace par une chaine vide
                    address.lastname = Regex.Replace(adresseCLI.Nom, @"[0-9!<>,;?=+()@#""�{}_$%:]", "");
                    //Caractères interdits: 0-9!<>,;?=+()@#"�{}_$%:
                    //Sinon en remplace par une chaine vide
                    address.firstname = Regex.Replace(adresseCLI.Prenom, @"[0-9!<>,;?=+()@#""�{}_$%:]", "");
                    address.address1 = adresseCLI.AdresseL1;
                    address.address2 = String.Concat(adresseCLI.AdresseL2, " ", adresseCLI.AdresseL3);
                    address.postcode = clientCLI.CodePostal;
                    address.city = adresseCLI.Ville;
                    address.dni = adresseCLI.NumeroIdentite;
                    address.other= adresseCLI.Autre;
                    address.vat_number= adresseCLI.NoTva;
                    address.phone=adresseCLI.Tel;
                    address.phone_mobile=adresseCLI.Mobile;
                    address.CLI_id_t_adresse = adresseCLI.IdTAdresse;

                        _cliContext.Update(adresseCLI);
                        _cliContext.SaveChanges();
                        var AddressPrestashop = await _addressFactory.AddAsync(address);
                        adresseCLI.IdAddressPrestashop = AddressPrestashop.id;
                        _cliContext.Update(adresseCLI);
                        _cliContext.SaveChanges();

                        return _responseMessage;
                    
                }
                else
                {
                    //mise à jour


                    //Dictionary<string, string> dtn = new Dictionary<string, string>();
                    //dtn.Add("alias", "Par défaut");

                    address.id_customer = clientCLI.IdCustomerPrestashop;
                    address.id_country = country.id;
                   //alias: Caractères interdits: <>={}  On les remplace par une chaine vide
                    address.alias = Regex.Replace(adresseCLI.Libelle, @"[<>={}]", "").Substring(0, Math.Min(adresseCLI.Libelle.Length, 32));
                    //Caractères interdits: <>={}    On les remplace par une chaine vide    
                    // Sinon en remplace par une chaine vide             
                    address.company = Regex.Replace(adresseCLI.Société, @"[<>={}]", "");
                    //Caractères interdits: 0-9!<>,;?=+()@#"�{}_$%:
                    //Sinon en remplace par une chaine vide
                    address.lastname = Regex.Replace(adresseCLI.Nom, @"[0-9!<>,;?=+()@#""�{}_$%:]", "");
                    //Caractères interdits: 0-9!<>,;?=+()@#"�{}_$%:
                    //Sinon en remplace par une chaine vide
                    address.firstname = Regex.Replace(adresseCLI.Prenom, @"[0-9!<>,;?=+()@#""�{}_$%:]", "");
                    address.address1 = adresseCLI.AdresseL1;
                    address.address2 = String.Concat(adresseCLI.AdresseL2, " ", adresseCLI.AdresseL3);
                    address.postcode = clientCLI.CodePostal;
                    address.city = adresseCLI.Ville;
                    address.dni = adresseCLI.NumeroIdentite;
                    address.other = adresseCLI.Autre;
                    address.vat_number = adresseCLI.NoTva;
                    address.phone = adresseCLI.Tel;
                    address.phone_mobile = adresseCLI.Mobile;


                    await _addressFactory.UpdateAsync(address);
                        return _responseMessage;
                    
                }
            }
            catch (Exception ex)
            {
                await _logServices.LogEvent($"Problème de mise à jour / ajout d'adresse client PS  : {id}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de mise à jour / ajout d'adresse client PS depuis CLI  : {id}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                return _responseMessage;
            }
           


        }


        public async Task<ResponseMessage> DeleteCLIByIdAsync(long id)
        {
            ResponseMessage _responseMessage = new ResponseMessage();
            try
            {
                var adresseCLI = _cliContext.TAdresses.Where(c => c.IdTAdresse == id).Single();
                _cliContext.TAdresses.Remove(adresseCLI);
                _cliContext.SaveChanges();
                return _responseMessage;
            }
            catch (Exception ex)
            {

                await _logServices.LogEvent($"Problème de suppression d'adresse client CLI  : {id}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de suppression d'adresse client CLI  : {id}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                return _responseMessage;
            }
            



        }


        public async Task<ResponseMessage> DeletePSByIdAsync(long id)
        {
            ResponseMessage _responseMessage = new ResponseMessage();
            try
            {
                await _addressFactory.DeleteAsync(id);
                return _responseMessage;
            }
            catch (Exception ex)
            {

                await _logServices.LogEvent($"Problème de suppression d'adresse client PS  : {id}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de suppression d'adresse client PS  : {id}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                return _responseMessage;
            }
        }






        //#region Prestashop




        ////Add
        //public async Task<address> PSAddAddressAsync(TClient clientCLI)
        //{
        //    var adresse = new address();
        //    var country= new country();
        //    country = await _countryService.PSGetCountryAsync(clientCLI);
        //    try


        //    {
                 
        //    }
        //    catch (Exception ex)
        //    {
        //        await _logServices.LogEvent($"Problème d\'ajout d'adresse client CLI  : {clientCLI.IdTClient}", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");

        //    }


        //    try
        //    {
        //        adresse = new address();
        //        adresse.id_customer = clientCLI.IdCustomerPrestashop;
        //        adresse.id_country = country.id == 0 ? 8 : country.id;


        //        //id_country = GetPays(clientCLI.Pays) == 0 ? 8 : GetPays(clientCLI.Pays),
        //        adresse.alias = "Par défaut";
        //        adresse.company = clientCLI.Société;
        //        adresse.lastname = clientCLI.Nom;
        //        adresse.firstname = clientCLI.Prenom;
        //        adresse.vat_number = clientCLI.NoTva;
        //        adresse.address1 = clientCLI.AdresseL1;
        //        adresse.address2 = String.Concat(clientCLI.AdresseL2, " ", clientCLI.AdresseL3);
        //        adresse.postcode = clientCLI.CodePostal;
        //        adresse.city = clientCLI.Ville;
        //        adresse.phone = clientCLI.Tel;
        //        //fax = clientCLI.Fax,
        //        adresse.dni = clientCLI.NumeroIdentite;



        //        //ajout de l'adresse
        //        adresse = _addressFactory.Add(adresse);
        //        return adresse;
        //    }
        //    catch (Exception ex)
        //    {
        //        await _logServices.LogEvent($"Problème d\'ajout d'adresse client CLI  : {clientCLI.IdTClient}",$"{ ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
        //        return adresse;

        //        //Log("Problème d'importation adresse client : " + id_customer);

        //    }
                     

        //}
        //public async Task<address> PSAddAddressAsync(TAdresse adresseClientCLI, TClient clientCLI)
        //{
        //    var adresse = new address();
        //    var country = await _countryService.PSGetCountryAsync(clientCLI.Pays);

        //    try
        //    {
        //        adresse = new address()
        //        {
        //            id_customer = clientCLI.IdCustomerPrestashop,
        //            id_country = country.id,
        //            alias = adresseClientCLI.Libelle,
        //            company = adresseClientCLI.Société,
        //            lastname = adresseClientCLI.Nom,
        //            firstname = adresseClientCLI.Prenom,
        //            address1 = adresseClientCLI.AdresseL1,
        //            address2 = String.Concat(adresseClientCLI.AdresseL2, " ", adresseClientCLI.AdresseL3),
        //            postcode = adresseClientCLI.CodePostal,
        //            city = adresseClientCLI.Ville
        //        };
        //        _addressFactory.Add(adresse);
        //        return adresse;
        //    }
        //    catch (Exception ex)
        //    {
        //        //Log("Problème d'importation adresse client : " + id_customer);
        //        return adresse;
        //    }

           



        //}

        ////Update
        //public async Task<address> PSUpdateAddressAsync(TClient clientCLI)
        //{

        //    var country = await _countryService.PSGetCountryAsync(clientCLI);
            
        //    //Dictionary<string, string> dtn = new Dictionary<string, string>();
        //    //dtn.Add("alias", "Par défaut");
        //    var address = await PSGetAddressAsync(clientCLI.IdCustomerPrestashop.ToString());
        //    address.id_customer = clientCLI.IdCustomerPrestashop;
        //    address.id_country = country.id;
        //    address.alias = "Par défaut";
        //    address.company = clientCLI.Société;
        //    address.lastname = clientCLI.Nom;
        //    address.firstname = clientCLI.Prenom;
        //    address.address1 = clientCLI.AdresseL1;
        //    address.address2 = String.Concat(clientCLI.AdresseL2, " ", clientCLI.AdresseL3);
        //    address.postcode = clientCLI.CodePostal;
        //    address.city = clientCLI.Ville;
        //    address.dni = clientCLI.NumeroIdentite;






        //    try
        //    {
        //        await _addressFactory.UpdateAsync(address);
        //        return address;
        //    }
        //    catch (Exception ex)

        //    {
        //        throw ex;
        //        return address;

        //    }


        //}

        //public async Task<address> PSUpdateAddressAsync(TAdresse adresseClientCLI,TClient clientCLI)
        //{

        //    var country = await _countryService.PSGetCountryAsync(clientCLI.Pays);

        //    //Dictionary<string, string> dtn = new Dictionary<string, string>();
        //    //dtn.Add("alias", "Par défaut");
        //    var address = await PSGetAddressAsync(clientCLI.IdCustomerPrestashop.ToString(),adresseClientCLI.Libelle);
        //    address.id_customer = clientCLI.IdCustomerPrestashop;
        //    address.id_country = country.id;
        //    address.alias = adresseClientCLI.Libelle;
        //    address.company = adresseClientCLI.Société;
        //    address.lastname = adresseClientCLI.Nom;
        //    address.firstname = adresseClientCLI.Prenom;
        //    address.address1 = adresseClientCLI.AdresseL1;
        //    address.address2 = String.Concat(adresseClientCLI.AdresseL2, " ", adresseClientCLI.AdresseL3);
        //    address.postcode = clientCLI.CodePostal;
        //    address.city = adresseClientCLI.Ville;
        //    address.dni = ""; //adresseClientCLI.NumeroIdentite;






        //    try
        //    {
        //        await _addressFactory.UpdateAsync(address);
        //        return address;
        //    }
        //    catch (Exception ex)

        //    {
        //        throw ex;
        //        return address;

        //    }


        //}

        ////Get
        //public async Task<address> PSGetAddressAsync(string id, string alias="Par défaut")
        //{
        //    Dictionary<string, string> dtn = new Dictionary<string, string>();
        //    dtn.Add("alias", alias);
        //    dtn.Add("id_customer", id);
        //    var address = _addressFactory.GetByFilter(dtn, null, null).FirstOrDefault();

            

        //    return address;

        //}

        //#endregion


        //#region CLI

 


        //#endregion

        //#region CrossLogic


        //public async Task<bool> SyncFromPSById(long id)
        //{
        //    var customerCLI = (from c in _cliContext.TClients
        //                       where c.IdTClient == id
        //                       select c).Single();

        //    var address = await this.PSGetAddressAsync(customerCLI.IdCustomerPrestashop.ToString());

        //    // On teste si le client a dejà une adresse par default dans prestashop, si oui on la mets à jour sinon on l'ajoute
        //    if (address is not null)
        //    {
        //        // Mise à jour
        //        await this.PSUpdateAddressAsync(customerCLI);
        //    }
        //    else
        //    {
        //        // Ajout
        //       address = await this.PSAddAddressAsync(customerCLI);
        //    }

        //    // On parcourt l'ensemble des adresse et on ajout ou met à jour si besoin


        //    var addressCLI = (from a in _cliContext.TAdresses
        //                      where a.IdTClient == id
        //                      select a).ToList();
        //    foreach (var a in addressCLI)
        //    {
        //         address = await this.PSGetAddressAsync(customerCLI.IdCustomerPrestashop.ToString(),a.Libelle);

        //        // On teste si le client a dejà une adresse par default dans prestashop, si oui on la mets à jour sinon on l'ajoute
        //        if (address is not null)
        //        {
        //            // Mise à jour
        //            await this.PSUpdateAddressAsync(a,customerCLI);
        //        }
        //        else
        //        {
        //            // Ajout
        //            address = await this.PSAddAddressAsync(a,customerCLI);
        //        }

        //    }



        //    return true;
        //}

        //Task<bool> IAddressService.PSUpdateAddressAsync(TClient clientCLI)
        //{
        //    throw new NotImplementedException();
        //}

       

        //#endregion

    }
}

