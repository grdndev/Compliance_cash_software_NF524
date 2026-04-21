using System;
using System.Runtime.CompilerServices;
using Bukimedia.PrestaSharp.Factories;
using CLICore.Data;
using CLICore.Models;
using CLICore.Services.Logger;
using CLIPrestashopConnector.Models;
using CLIPrestashopConnector.Dtos;
using CLIPrestashopConnector.Services.PrestashopErrorDecoder;
using Microsoft.Extensions.Options;
using Bukimedia.PrestaSharp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using CLIPrestashopConnector.Services.Push;
using AppSettings = CLIPrestashopConnector.Models.AppSettings;
using System.Text.RegularExpressions;

namespace CLIPrestashopConnector.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly AppSettings _appSettings;
        private readonly CLIContext _cliContext;
        private readonly ILogService _logService;
        private readonly IPrestashopErrorDecoderService _prestashopErrorDecoderService;
        private readonly OrderFactory _orderFactory;
        private readonly OrderDetailFactory _orderDetailFactory;
        private readonly CustomerFactory _customerFactory;
        private readonly AddressFactory _addressFactory;
        private readonly ProductFactory _productFactory;
        private readonly CombinationFactory _combinationFactory;
        private readonly OrderCartRuleFactory _orderCartRuleFactory;
        private readonly CartRuleFactory _cartRuleFactory;
        private readonly CountryFactory _countryFactory;
        private readonly CarrierFactory _carrierFactory;
        private readonly IPushService _pushService;

        public OrderService(IOptions<AppSettings> appSettings, CLIContext cliContext, ILogService logService, IPrestashopErrorDecoderService prestashopErrorDecoderService,IPushService pushService)
        {
            this._appSettings = appSettings?.Value ?? throw new ArgumentNullException(nameof(appSettings));
            this._cliContext = cliContext;
            this._logService = logService;
            this._prestashopErrorDecoderService = prestashopErrorDecoderService;
            this._orderFactory = new OrderFactory(_appSettings.Endpoint, _appSettings.ApiKey, _appSettings.Password);
            this._customerFactory = new CustomerFactory(_appSettings.Endpoint, _appSettings.ApiKey, _appSettings.Password);
            this._addressFactory = new AddressFactory(_appSettings.Endpoint, _appSettings.ApiKey, _appSettings.Password);
            this._productFactory = new ProductFactory(_appSettings.Endpoint, _appSettings.ApiKey, _appSettings.Password);
            this._orderCartRuleFactory = new OrderCartRuleFactory(_appSettings.Endpoint, _appSettings.ApiKey, _appSettings.Password);
            this._countryFactory = new CountryFactory(_appSettings.Endpoint, _appSettings.ApiKey, _appSettings.Password);
            this._carrierFactory = new CarrierFactory(_appSettings.Endpoint, _appSettings.ApiKey, _appSettings.Password);
            this._combinationFactory = new CombinationFactory(_appSettings.Endpoint, _appSettings.ApiKey, _appSettings.Password);
            this._cartRuleFactory = new CartRuleFactory(_appSettings.Endpoint, _appSettings.ApiKey, _appSettings.Password);
            this._orderDetailFactory = new OrderDetailFactory(_appSettings.Endpoint, _appSettings.ApiKey, _appSettings.Password);
            this._pushService = pushService;


        }

        public async Task<ResponseMessage> GetOrderInvoiceFromCLIByIdAsync(long id)
        {
            var _responseMessage = new ResponseMessage();

            // on récupere d'id de la commande CLI en fonction de la reference PS
            var _order = await _cliContext.TCommandeVentes.FirstOrDefaultAsync(x => x.IdCommandePrestashop == id);
            // On récupère la facture pdf dans le repertoire indiqué dans invoicepath dans _appSettings
            // On charge le fichier en tableau de byte et on l'ajoute dans le _responseMessage dans Objects
            var filePath = $"{_appSettings.InvoicePath}/{_order.IdTCommandeVente}.pdf";
            if (File.Exists(filePath))
            {
                _responseMessage.Objects.Add(File.ReadAllBytes(filePath));
            }
            else
            {
                _responseMessage.Objects.Add(new byte[0]);
            }


            return _responseMessage;

        }
        public async Task<ResponseMessage> SetOrderInvoiceFromCLIByIdAsync(long id, byte[] facture)
        {
            var _responseMessage = new ResponseMessage();

            // on test si le chemin existe sinon on renvoie une erreur
            if (!Directory.Exists(_appSettings.InvoicePath))
            {
                await _logService.LogEvent($"Problème d'upload de la facture CLI  : {id} ", $"Le chemin {_appSettings.InvoicePath} n'existe pas", id, "t_commandeVente", "Erreur");

                _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème d'upload de la facture CLI : {id}", $"Le chemin {_appSettings.InvoicePath} n'existe pas");

                return _responseMessage;

            }
            // on défini le chemin d'enregistrement de la facture
            var filePath = $"{_appSettings.InvoicePath}/{id}.pdf";

            try
            {
                // Si on enregistre la facture en utilisant filePath
                File.WriteAllBytes(filePath, facture);
            }
            catch (System.Exception ex)
            {
                await _logService.LogEvent($"Problème d'upload de la facture CLI  : {id} ", ex.Message, id, "t_commandeVente", "Erreur");

                _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème d'upload de la facture CLI : {id}", ex.Message);

                return _responseMessage;


            }



            await _logService.LogEvent($"Upload de la facture CLI  : {id} ", $"Upload facture ok", id, "t_commandeVente", "Ok");


            return _responseMessage;

        }

        // public Task<ResponseMessage> GetShippingCostAsync(long id_address, List<long> id_products)
        // {
        //     throw new NotImplementedException();
        // }

        // Permet de calculer les frais de port pour une commande Prestashop en fonction de l'adresse de livraison et des produits
        public async Task<ResponseMessage> GetShippingCostAsync(ShippingCostDto shippingCostDto)
        {
            var _responseMessage = new ResponseMessage();

            address? address = null;
            //on recupere l'adresse de livraison
            try
            {
                address = _addressFactory.Get(shippingCostDto.Id_address);
            }
            catch (System.Exception)
            {
                // si l'adresse n'existe pas on renvoie une erreur
                _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de récupération de l'adresse de livraison : {shippingCostDto.Id_address}", $"L'adresse de livraison n'existe pas");
                // on renvoie false
                _responseMessage.Objects.Add(false);
                return _responseMessage;
            }


            //on recupere le pays de livraison
            var country = _countryFactory.Get((long)address.id_country);
            var country_libelle = "";
            // S'il s'agit de la France, on regarde si c'est un code postal Corse
            if (country.iso_code == "FR")
            {
                if (address.postcode.StartsWith("20"))
                {
                    country_libelle = "Corse";
                }
                else
                {
                    country_libelle = "France";
                }

            }
            else{
            // on fait la correspondance entre le code pays de prestashop et le code pays de CLI
            country_libelle = _cliContext.TPays.Where(c => c.CodePays == country.iso_code).FirstOrDefault().Libelle;
            }




            // on parcours les id des produits, id_products pour recuperer le code port de chaque produit depuis TArticleEntete

            // on stocke les id_product_attribute dans une chaine séparée par |
            string id_product_attribute = "";
            foreach (var shippingCostProductDto in shippingCostDto.shippingCostProductDtos)
            {
                id_product_attribute += shippingCostProductDto.Id_product_attribute + "|";
            }
            if (id_product_attribute == "")
            {
                _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de récupération des frais de port : {shippingCostDto.Id_address}", $"Aucun produit n'a été trouvé");
                // on renvoie false
                _responseMessage.Objects.Add(false);
                return _responseMessage;
            }
            // on supprime le dernier caractère
            id_product_attribute = id_product_attribute.Substring(0, id_product_attribute.Length - 1);
            id_product_attribute = $"[{id_product_attribute}]";
            //on recupere les combinaisons de produits depuis prestashop correspondant aux id_product_attribute
            var combinations = _combinationFactory.GetByFilter(new Dictionary<string, string>() { { "id", id_product_attribute } }, null, null, new List<string>() { "reference" });


            var articlesNeuf = _cliContext.TArticleVersions.Where(x => combinations.Select(c => c.reference).Contains(x.IdTArticleVersion.ToString())).Where((x => x.Occaz == false && x.DepotVente == false))
            .Select(x => x.IdTArticleDetailNavigation.IdTArticleEnteteNavigation.CodePort
                    ).ToList();

            var articlesOccaz = _cliContext.TArticleVersions.Where(x => combinations.Select(c => c.reference).Contains(x.IdTArticleVersion.ToString())).Where((x => x.Occaz == true || x.DepotVente == true))
            .Select(x => x.IdTArticleDetailNavigation.IdTArticleEnteteNavigation.CodePort
                    ).ToList();


            // on selectionne le prix maximum du port en fonction de la destination et du code port
            var shippingCostNeufMax = _cliContext.TListeCodePortPays.Where(x => x.Pays == country_libelle && articlesNeuf.Contains(x.CodePort)).Max(x => x.Prix);
            if (shippingCostNeufMax == null)
            {
                shippingCostNeufMax = 0.0;
            }

            var shippingCostOccazMax = _cliContext.TListeCodePortPays.Where(x => x.Pays == country_libelle && articlesOccaz.Contains(x.CodePort)).Max(x => x.Prix);
            if (shippingCostOccazMax == null)
            {
                shippingCostOccazMax = 0.0;
            }
            var shippingCostMax = 0.0;


            //on récupere le parametre de port offert
            var shippingCostFree = _cliContext.TParams.Where(x => x.Paramname == "Port_offert").FirstOrDefault();
            var shippingCostFreeOccaz = _cliContext.TParams.Where(x => x.Paramname == "Port_offertOccaz").FirstOrDefault();

            if (shippingCostDto.TotalOrder > Convert.ToDecimal(shippingCostFree.Paramvalue))
            {
                shippingCostNeufMax = 0.0;
                if (shippingCostFreeOccaz.Paramvalue == "1")
                {
                    shippingCostOccazMax = 0.0;
                }
            }


            if (shippingCostOccazMax > shippingCostNeufMax)
            {
                shippingCostMax = shippingCostOccazMax.Value;
            }
            else
            {
                shippingCostMax = shippingCostNeufMax.Value;
            }



            // on enleve 20% de TVA pour renvoyer le cout du transport HT
            shippingCostMax = shippingCostMax / 1.2;
            _responseMessage.Objects.Add(shippingCostMax);
            return _responseMessage;


        }

        // Permet d'importer une commande Prestashop dans la base de données CLI
        // On passe le numéro de commande prestashop en paramètre et on récupère la commande
        public async Task<ResponseMessage> ImportFromPSByIdAsync(long id, string reference, bool force = false)
        {
            var _responseMessage = new ResponseMessage();

            try
            {
                // On log le début de l'import
                await _logService.LogEvent($"Import commande PS dans CLI  : {id} ({reference})", $"Début de l'import", 0, "t_commandeVente", "Ok");
                // On récupère la commande
                var order = _orderFactory.Get(id);
                // On vérifie si la commande existe bien dans prestashop
                if (order == null)
                {
                    // on log l'erreur
                    await _logService.LogEvent($"Problème d'import commande PS dans CLI  : {id} ({reference}) ", $"La commande n'existe pas dans PS", 0, "t_commandeVente", "Erreur");

                    _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème d'import commande PS dans CLI  : {id} ({reference}) ", $"La commande n'existe pas dans PS");

                    return _responseMessage;
                }

                // vérification si la commande existe déjà dans CLI, si oui on n'importe pas sauf si force=true
                var commandeCLI = _cliContext.TCommandeVentes.Where(c => c.IdCommandePrestashop == order.id).FirstOrDefault();
                if (commandeCLI != null)
                {
                    if (force == false)
                    {
                        // on log l'erreur
                        await _logService.LogEvent($"Problème d'import commande PS dans CLI  : {id} ({commandeCLI.ReferenceCommandePrestashop}) ", $"La commande existe déja", 0, "t_commandeVente", "Erreur");

                        _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème d'import commande PS dans CLI  : {id} ({commandeCLI.ReferenceCommandePrestashop}) ", $"La commande existe déja");

                        return _responseMessage;
                    }
                    else
                    {
                        // on supprime la commande existante
                        _cliContext.TCommandeVentes.Remove(commandeCLI);
                        await _cliContext.SaveChangesAsync();
                    }

                }

                commandeCLI = new TCommandeVente();



                // récupération du client PS
                var customer = _customerFactory.Get((long)order.id_customer);
                if (customer == null)
                {
                    // on log l'erreur
                    await _logService.LogEvent($"Problème d'import commande PS dans CLI  : {id} ({reference}) ", $"Le client n'existe pas dans PS", commandeCLI.IdTCommandeVente, "t_commandeVente", "Erreur");

                    _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème d'import commande PS dans CLI  : {id} ({reference}) ", $"Le client n'existe pas dans PS");

                    return _responseMessage;
                }

                // récupération du client correspondant dans CLI
                var clientCLI = _cliContext.TClients.Where(c => c.IdCustomerPrestashop == customer.id).FirstOrDefault();
                if (clientCLI == null)
                {
                    // on log l'erreur
                    await _logService.LogEvent($"Problème d'import commande PS dans CLI  : {id} ({reference}) ", $"Le client n'existe pas dans CLI", commandeCLI.IdTCommandeVente, "t_commandeVente", "Erreur");

                    _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème d'import commande PS dans CLI  : {id} ({reference}) ", $"Le client n'existe pas dans CLI");

                    return _responseMessage;
                }


                // récupération de l'adresse de facturation PS
                var addressInvoice = _addressFactory.Get((long)order.id_address_invoice);
                if (addressInvoice == null)
                {
                    // on log l'erreur
                    await _logService.LogEvent($"Problème d'import commande PS dans CLI  : {id} ({reference}) ", $"L'adresse de facturation n'existe pas dans PS", commandeCLI.IdTCommandeVente, "t_commandeVente", "Erreur");

                    _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème d'import commande PS dans CLI  : {id} ({reference}) ", $"L'adresse de facturation n'existe pas dans PS");

                    return _responseMessage;
                }

                // récupération du pays de facturation PS
                var countryInvoice = _countryFactory.Get((long)addressInvoice.id_country);
                if (countryInvoice == null)
                {
                    // on log l'erreur
                    await _logService.LogEvent($"Problème d'import commande PS dans CLI  : {id} ({reference})", $"Le pays de facturation n'existe pas dans PS", commandeCLI.IdTCommandeVente, "t_commandeVente", "Erreur");

                    _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème d'import commande PS dans CLI  : {id} ({reference}) ", $"Le pays de facturation n'existe pas dans PS");

                    return _responseMessage;
                }

                // récupération du pays de facturation CLI
                var countryInvoiceCLI = _cliContext.TPays.Where(x => x.CodePays == countryInvoice.iso_code).FirstOrDefault();
                if (countryInvoiceCLI == null)
                {
                    // on log l'erreur
                    await _logService.LogEvent($"Problème d'import commande PS dans CLI  : {id} ({reference})", $"Le pays de facturation n'existe pas dans CLI", commandeCLI.IdTCommandeVente, "t_commandeVente", "Erreur");

                    _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème d'import commande PS dans CLI  : {id} ({reference}) ", $"Le pays de facturation n'existe pas dans CLI");

                }

                // récupération de l'adresse de livraison PS

                // récupération de produits

                // récupération du transporteur
                var carrier = _carrierFactory.Get((long)order.id_carrier);
                if (carrier == null)
                {
                    // on log l'erreur
                    await _logService.LogEvent($"Problème d'import commande PS dans CLI  : {id} ({reference}) ", $"Le transporteur n'existe pas dans PS", commandeCLI.IdTCommandeVente, "t_commandeVente", "Erreur");

                    _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème d'import commande PS dans CLI  : {id} ({reference}) ", $"Le transporteur n'existe pas dans PS");

                    return _responseMessage;
                }


                // récupération des remises

                // récupération des avoirs utilisés

                // Insertion d'une commande dans CLI
                commandeCLI.IdTClient = clientCLI.IdTClient;
                commandeCLI.ReferenceCommandePrestashop = order.reference;
                commandeCLI.IdPanierPrestashop = order.id_cart;
                commandeCLI.IdCommandePrestashop = order.id;
                commandeCLI.WebOn = true;
                commandeCLI.IdEtatCommandeVente = 10;
                commandeCLI.CreeLe = DateTime.Now;
                commandeCLI.CreePar = "Web";
                commandeCLI.Société = customer.company;
                commandeCLI.NoSiret = customer.siret;
                commandeCLI.NoTva = addressInvoice.vat_number;
                commandeCLI.Nom = customer.lastname;
                commandeCLI.Prénom = customer.firstname;
                commandeCLI.AdresseL1 = addressInvoice.address1;
                commandeCLI.AdresseL2 = addressInvoice.address2;
                commandeCLI.CodePostal = addressInvoice.postcode;
                commandeCLI.Ville = addressInvoice.city;
                commandeCLI.Pays = countryInvoiceCLI.Libelle;
                commandeCLI.Tel = addressInvoice.phone;
                commandeCLI.Email = customer.email;
                commandeCLI.Numcaisse = 1;
                commandeCLI.TotalHt = (double)order.total_products;
                // si order.total_shipping_tax_incl != 0 alors on ajoute le montant des frais de port HT à TotalHT
                if (order.total_shipping_tax_incl != 0)
                {
                    commandeCLI.TotalHt += (double)order.total_shipping_tax_excl;
                }

                commandeCLI.Total55 = 0;
                commandeCLI.Total196 = 0;
                commandeCLI.MontantDeduire = 0;
                commandeCLI.TotalTtc = (double?)order.total_products_wt + (double?)order.total_shipping_tax_incl;
                //commandeCLI.TotalTtc=commandeCLI.TotalHt+commandeCLI.Total55+commandeCLI.Total196;

                // commentaire facture "ATTENTION : RETRAIT MAGASIN"
                if (carrier.name == "Retrait en magasin")
                {
                    commandeCLI.CommentairesCommande = "ATTENTION : RETRAIT MAGASIN";
                }

                _cliContext.TCommandeVentes.Add(commandeCLI);
                await _cliContext.SaveChangesAsync();

                // ajout des lignes de produits : attention au cas des packs





                // on recupere les lignes de commande PS
                foreach (var orderLine in order.associations.order_rows)
                {
                    // On recupere les produits de la commande PS order_details associés à la commande PS 
                    var orderDetail = _orderDetailFactory.Get((long)orderLine.id);

                    // On stock le numéro de pack si c'est un pack depuis product_name , exemple : "Pack 81040 - Nautix pied de mat a..." , donne "Pack 81040" avec une regex
                    var packNumber = Regex.Match(orderDetail.product_name, @"Pack \d+").Value;


                    // on recupere la combinaison prestashop pour avoir le champ reference
                    // var combination = _combinationFactory.Get((long)orderLine.product_attribute_id);
                    // if (combination == null){
                    //     // on log l'erreur
                    //     await _logService.LogEvent($"Problème d'import commande PS dans CLI  : {id} ({reference}) ", $"La combinaison n'existe pas dans PS", commandeCLI.IdTCommandeVente, "t_commandeVente", "Erreur");

                    //         _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème d'import commande PS dans CLI  : {id} ({reference}) ", $"La combinaison n'existe pas dans PS");

                    //     return _responseMessage;
                    // }
                    // on recuperer le produit dans CLI pour avoir la description panier
                    var productCLI = _cliContext.TArticleVersions.Where(x => x.IdTArticleVersion == (long)Convert.ToDouble(orderLine.product_reference)).FirstOrDefault();
                    if (productCLI == null)
                    {
                        // on log l'erreur
                        await _logService.LogEvent($"Problème d'import commande PS dans CLI  : {id} ({reference}) ", $"Le produit n'existe pas dans CLI", commandeCLI.IdTCommandeVente, "t_commandeVente", "Erreur");

                        _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème d'import commande PS dans CLI  : {id} ({reference}) ", $"Le produit n'existe pas dans CLI");

                        return _responseMessage;
                    }


                    var ligneCommande = new TCommandeVenteLigne();
                    ligneCommande.IdTCommandeVente = commandeCLI.IdTCommandeVente;
                    ligneCommande.IdTArticleVersion = productCLI.IdTArticleVersion;
                    ligneCommande.Occaz = productCLI.Occaz;
                    ligneCommande.DepotVente = productCLI.DepotVente;
                    // packnumber n'est pas nulle ou vide, c'est un pack, on l'ajoute au debut de la descriptionPanier
                    if (!string.IsNullOrEmpty(packNumber))
                    {
                        ligneCommande.DescriptionPanier = (packNumber + " - " + productCLI.DescriptionPanier).Substring(0, Math.Min(255, (packNumber + " - " + productCLI.DescriptionPanier).Length));
                    }
                    else
                    {
                        ligneCommande.DescriptionPanier = productCLI.DescriptionPanier?.Substring(0, Math.Min(255, productCLI.DescriptionPanier.Length));
                    }

                    ligneCommande.Qte = orderLine.product_quantity;
                    ligneCommande.PrixFournisseur = productCLI.PrixFournisseur;
                    if (orderDetail.unit_price_tax_excl == 0)
                    {
                        ligneCommande.CodeTva = 20;

                    }
                    else
                    {
                        ligneCommande.CodeTva = (double?)Math.Round((decimal)(((orderDetail.unit_price_tax_incl / orderDetail.unit_price_tax_excl) - 1) * 100), 1);

                    }


                    ligneCommande.PrixTotalTtc = (decimal?)orderDetail.unit_price_tax_incl * orderDetail.product_quantity;


                    ligneCommande.PrixVenteRemiseTtc = (decimal?)orderDetail.unit_price_tax_incl;

                    if (orderDetail.product_price == orderDetail.unit_price_tax_excl || orderDetail.product_price == 0)
                    {
                        ligneCommande.Remise = 0;
                        ligneCommande.PrixVenteInitialTtc = (decimal?)orderDetail.unit_price_tax_incl;
                    }
                    else
                    {
                        ligneCommande.Remise = 1 - ((double?)Math.Round(orderDetail.unit_price_tax_excl / orderDetail.product_price, 2));
                        ligneCommande.PrixVenteInitialTtc = Math.Round((decimal)((decimal?)orderDetail.unit_price_tax_incl / (1 - (decimal)ligneCommande.Remise)), 5);
                    }




                    _cliContext.TCommandeVenteLignes.Add(ligneCommande);
                }



                // ajout des frais de port / retrait magasin)
                var ligneCommandePort = new TCommandeVenteLigne();
                ligneCommandePort.IdTCommandeVente = commandeCLI.IdTCommandeVente;
                ligneCommandePort.IdTArticleVersion = 5;
                ligneCommandePort.Qte = 1;
                ligneCommandePort.PrixTotalTtc = (decimal)order.total_shipping_tax_incl;
                ligneCommandePort.PrixVenteInitialTtc = (decimal)order.total_shipping_tax_incl;
                ligneCommandePort.PrixVenteRemiseTtc = (decimal)order.total_shipping_tax_incl;
                ligneCommandePort.Remise = 0;

                // si retrait , mettre "Retrait magasin", sinon "Port"
                ligneCommandePort.DescriptionPanier = carrier.name == "Retrait en magasin" ? "Retrait magasin" : "Port";
                ligneCommandePort.CodeTva = 20;
                // if (order.total_shipping_tax_excl == 0)
                // {
                //     ligneCommandePort.CodeTva = 20;
                // }
                // else
                // {
                //     ligneCommandePort.CodeTva = (double?)Math.Round((decimal)(((order.total_shipping_tax_incl / order.total_shipping_tax_excl) - 1) * 100), 1);

                // }            
                _cliContext.TCommandeVenteLignes.Add(ligneCommandePort);
                await _cliContext.SaveChangesAsync();


                // Mise à jour TVA
                decimal total55 = 0;
                decimal total196 = 0;
                foreach (var ligne in _cliContext.TCommandeVenteLignes.Where(x => x.IdTCommandeVente == commandeCLI.IdTCommandeVente).ToList())
                {
                    if (ligne.CodeTva == 20)
                    {
                        //total196 = total196 + ((decimal)ligne.PrixTotalTtc - (decimal)ligne.PrixTotalHt);
                        total196 = total196 + ((decimal)ligne.PrixTotalTtc - (decimal)ligne.PrixTotalHt);
                    }
                    if (ligne.CodeTva == 5.5)
                    {
                        //total55 = total55 + ((decimal)ligne.PrixTotalTtc - (decimal)ligne.PrixTotalHt);
                        total55 = total55 + ((decimal)ligne.PrixTotalTtc - (decimal)ligne.PrixTotalHt);
                    }
                }



                // Arrondi à deux decimales
                decimal total55Arrondi = Math.Round(total55, 2);
                decimal total196Arrondi = Math.Round(total196, 2);


                commandeCLI.Total55 = (double)total55Arrondi;
                commandeCLI.Total196 = (double)total196Arrondi;

                //commandeCLI.TotalTtc = commandeCLI.TotalHt + (double)total55 + (double)total196;

                _cliContext.TCommandeVentes.Update(commandeCLI);
                await _cliContext.SaveChangesAsync();




                // ajout des règlements

                // on recupere le moyen de paiement
                var idPaiement = 0;
                var idModeReglement = 0;
                switch (order.payment)
                {
                    case "CB":
                    case "MasterCard":
                    case "Visa":
                        idPaiement = 13;
                        idModeReglement = 15;
                        break;
                    case "CB (x3)":
                    case "MasterCard (x3)":
                    case "Visa (x3)":
                        idPaiement = 13;
                        idModeReglement = 7;
                        break;
                    case "Chèque":
                        idPaiement = 2;
                        idModeReglement = 15;
                        break;
                    case "Transfert bancaire":
                        idPaiement = 4;
                        idModeReglement = 15;
                        break;
                    case "PAYPAL":
                        idPaiement = 10;
                        idModeReglement = 15;
                        break;
                    case "PayPal":
                        idPaiement = 10;
                        idModeReglement = 15;
                    break;
                    case "PayPal - SANDBOX":
                        idPaiement = 10;
                        idModeReglement = 15;
                    break;
                }

                var reglement = new TReglement();

                if (idModeReglement == 7)
                {
                    reglement = new TReglement();
                    reglement.IdTCommandeVente = commandeCLI.IdTCommandeVente;
                    reglement.ConditionReglement = idModeReglement;
                    reglement.MoyenPaiement = idPaiement;
                    reglement.Montant = (double?)order.total_paid_tax_incl / 3;
                    reglement.AEncaisser = false;
                    reglement.EcheanceLe = DateTime.Now;
                    reglement.EnregistreLe = DateTime.Now;
                    _cliContext.TReglements.Add(reglement);

                    reglement = new TReglement();
                    reglement.IdTCommandeVente = commandeCLI.IdTCommandeVente;
                    reglement.ConditionReglement = idModeReglement;
                    reglement.MoyenPaiement = idPaiement;
                    reglement.Montant = (double?)order.total_paid_tax_incl / 3;
                    reglement.AEncaisser = false;
                    reglement.EcheanceLe = DateTime.Now.AddMonths(1);
                    reglement.EnregistreLe = DateTime.Now;
                    _cliContext.TReglements.Add(reglement);

                    reglement = new TReglement();
                    reglement.IdTCommandeVente = commandeCLI.IdTCommandeVente;
                    reglement.ConditionReglement = idModeReglement;
                    reglement.MoyenPaiement = idPaiement;
                    reglement.Montant = (double?)order.total_paid_tax_incl / 3;
                    reglement.AEncaisser = false;
                    reglement.EcheanceLe = DateTime.Now.AddMonths(2);
                    reglement.EnregistreLe = DateTime.Now;
                    _cliContext.TReglements.Add(reglement);
                }
                else
                {
                    // si le mode de règlement est 0 , c'est une commande gratuite et on n'ajout pas la ligne de reglement
                    if (idModeReglement != 0)
                    {
                        reglement.IdTCommandeVente = commandeCLI.IdTCommandeVente;
                        reglement.ConditionReglement = idModeReglement;
                        reglement.MoyenPaiement = idPaiement;
                        reglement.Montant = (double?)order.total_paid_tax_incl;
                        reglement.AEncaisser = false;
                        reglement.EnregistreLe = DateTime.Now;
                        _cliContext.TReglements.Add(reglement);
                    }

                }


                // voir pour la gestion des avoirs
                // on recuperer les order_cart_rules de prestashop filtré sur un dictionnaire avec id_order
                var dtn = new Dictionary<string, string>();
                dtn.Add("id_order", order.id.ToString());
                var orderCartRules = await _orderCartRuleFactory.GetByFilterAsync(dtn, null, null);
                //Pour chaque order_cart_rules on recupere le cart_rule correspondant et on verifie si c'est un avoir CLI
                foreach (var orderCartRule in orderCartRules)
                {
                    var dtn2 = new Dictionary<string, string>();
                    dtn2.Add("id", orderCartRule.id_cart_rule.ToString());
                    var cartRule = await _cartRuleFactory.GetByFilterAsync(dtn2, null, null);
                    // on vérifier si le code de l'avoir est numerique
                    if (cartRule.FirstOrDefault().code.All(char.IsDigit))
                    {
                        // si c'est un avoir CLI, récupère le montant de l'avoir depuis CLI
                        var avoirCLI = _cliContext.TAvoirs.FirstOrDefault(x => x.IdTAvoir == Convert.ToDouble(cartRule.FirstOrDefault().code));
                        // si l'avoir n'existe pas, on log et on arrete l'import
                        if (avoirCLI == null)
                        {
                            await _logService.LogEvent($"Problème d'import commande PS dans CLI : {id} ({reference})", "Avoir CLI non trouvé", commandeCLI.IdTCommandeVente, "t_commandeVente", "Erreur");
                            _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème d'import commande PS dans CLI  : {id} ({reference}) ", $"Avoir CLI non trouvé");
                            return _responseMessage;
                        }

                        reglement = new TReglement();
                        reglement.IdTCommandeVente = commandeCLI.IdTCommandeVente;
                        reglement.ConditionReglement = 15;
                        reglement.MoyenPaiement = 7;
                        reglement.Montant = avoirCLI.Montant;
                        reglement.ReferenceAvoirBon = avoirCLI.IdTAvoir;
                        reglement.AEncaisser = false;
                        reglement.EnregistreLe = DateTime.Now;
                        _cliContext.TReglements.Add(reglement);
                    }

                }







                await _cliContext.SaveChangesAsync();

                // on log la fin de l'import
                await _logService.LogEvent($"Import commande PS dans CLI  : {id} ({reference})", "Import terminé", commandeCLI.IdTCommandeVente, "t_commandeVente", "Ok");
                await _pushService.Notify("Nouvelle commande Prestashop!",$"Nouvelle commande Prestashop! Import dans CLI : {commandeCLI.IdTCommandeVente} ({commandeCLI.ReferenceCommandePrestashop}) terminé");

                return _responseMessage;
            }
            catch (Exception ex)
            {
                await _logService.LogEvent($"Problème d'import commande PS dans CLI  : {id} ({reference})", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}", 0, "t_commandeVente", "Erreur");
                _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème d'import commande PS dans CLI  : {id} ({reference})", $"{ex.TargetSite.ReflectedType.FullName} => {ex.Message}");
                return _responseMessage;



            }


        }



        public async Task<ResponseMessage> UpdateOrderStatusFromCLIByIdAsync(long id)
        {
            var _responseMessage = new ResponseMessage();


            // on recupere la commande CLI
            try
            {
                var commandeCLI = _cliContext.TCommandeVentes.FirstOrDefault(x => x.IdTCommandeVente == id);
                // si la commande n'existe pas, on log et on arrete l'import
                if (commandeCLI == null)
                {
                    await _logService.LogEvent($"Problème de mise à jour du statut de la commande {id} : commande non trouvée dans CLI", "", id, "t_commandeVente", "Erreur");
                    _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de mise à jour du statut de la commande {id} : commande non trouvée dans CLI", "");

                    return _responseMessage;
                }

                // on recupere la commande PS
                var order = _orderFactory.Get((long)commandeCLI.IdCommandePrestashop);
                // si la commande n'existe pas, on log et on arrete l'import
                if (order == null)
                {
                    await _logService.LogEvent($"Problème de mise à jour du statut de la commande {id} : commande non trouvée dans PS", "", id, "t_commandeVente", "Erreur");
                    _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de mise à jour du statut de la commande {id} : commande non trouvée dans PS", "");
                    return _responseMessage;
                }

                // on met à jour le statut de la commande PS en fonction de la commande CLI
                var AMettreAJour = false;
                switch (commandeCLI.IdEtatCommandeVente)
                {


                    // Réglé => En cours de préparation
                    case 20:
                        if (order.current_state != 3)
                        {
                            order.current_state = 3;
                            AMettreAJour = true;
                        }

                        break;

                    // Ticket imprimé => En cours de préparation
                    case 25:
                        if (order.current_state != 3)
                        {

                            order.current_state = 3;
                            AMettreAJour = true;
                        }

                        break;

                    // Facturé => En cours de préparation
                    case 30:

                        if (order.current_state != 3)
                        {
                            order.current_state = 3;
                            AMettreAJour = true;
                        }

                        break;


                    // Sorti des stocks => En cours de préparation
                    case 40:
                        if (order.current_state != 3)
                        {
                            order.current_state = 3;
                            AMettreAJour = true;
                        }


                        break;


                    //Expédié
                    case 45:
                    
                    // on verifie si c'est une expedition ou un retrait magasin
                        if ((order.current_state != 4 && order.current_state != 26) || (order.shipping_number != commandeCLI.ExpeditionNumsuivi && !commandeCLI.ExpeditionNumsuivi.IsNullOrEmpty()))
                        {
                            if (commandeCLI.IdTTransporteur == 3)
                            {
                                order.current_state = 26;
                            }
                            else
                            {
                                order.current_state = 4;
                                order.shipping_number = commandeCLI.ExpeditionNumsuivi;
                            }
                            
                            AMettreAJour = true;
                        }


                        break;

                    //Annulé
                    case 90:
                        if (order.current_state != 6)
                        {
                            order.current_state = 6;
                            AMettreAJour = true;
                        }

                        break;
                }


                // on met à jour la commande PS si AMettreAJour = true
                if (AMettreAJour)
                {
                    await _orderFactory.UpdateAsync(order);
                    // on log la fin du changement de statut
                    await _logService.LogEvent($"Mise à jour du statut de la commande {id} : {commandeCLI.IdEtatCommandeVente} => {order.current_state}", "", id, "t_commandeVente", "Ok");

                }


            }
            catch (Exception ex)
            {
                await _logService.LogEvent($"Problème de mise à jour du statut de la commande {id} : {ex.TargetSite.ReflectedType.FullName} => {ex.Message}", "", id, "t_commandeVente", "Erreur");
                _responseMessage.AddResponseMessageLine(ResponseMessageType.Error, $"Problème de mise à jour du statut de la commande {id} : {ex.TargetSite.ReflectedType.FullName} => {ex.Message}", "");
                return _responseMessage;

            }

            return _responseMessage;
        }

    }
    

}

