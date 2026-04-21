using System;
using Bukimedia.PrestaSharp.Entities;
using Bukimedia.PrestaSharp.Factories;
using CLICore.Data;
using CLICore.Services.Logger;
using CLIPrestashopConnector.Models;
using CLIPrestashopConnector.Services.Country;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CLIPrestashopConnector.Services.CartRule
{
    public class CartRuleService : ICartRuleService
    {
        private readonly AppSettings _appSettings;
        private readonly CartRuleFactory _cartRuleFactory;
        private readonly CLIContext _cliContext;
        private readonly ILogService _logServices;

        public CartRuleService(IOptions<AppSettings> appSettings, CLIContext cliContext, ILogService logService)
        {
            this._appSettings = appSettings?.Value ?? throw new ArgumentNullException(nameof(appSettings));
            this._cartRuleFactory = new CartRuleFactory(_appSettings.Endpoint, _appSettings.ApiKey, _appSettings.Password);
            this._cliContext = cliContext;
            this._logServices = logService;
        }

        public async Task<ResponseMessage> AddOrUpdatePSfromCLIByIdAsync(long id)
        {
            var _responseMessage = new ResponseMessage();
            var avoirCLI = _cliContext.TAvoirs.Where(c => c.IdTAvoir == id).FirstOrDefault();
            var clientCLI = _cliContext.TClients.Where(c => c.IdTClient == avoirCLI.IdTClient).FirstOrDefault();
            //Vérification si l'avoir existe déjà dans PS, dans ce cas on MAJ, sinon on ajoute

            Dictionary<string, string> dtn = new Dictionary<string, string>();
            dtn.Add("code", id.ToString());
            cart_rule cartRule = _cartRuleFactory.GetByFilter(dtn, null, null).FirstOrDefault();

            //Gestion du libelle de l'avoir (langue Fr)
            var n = new List<Bukimedia.PrestaSharp.Entities.AuxEntities.language>();
            var i = new Bukimedia.PrestaSharp.Entities.AuxEntities.language()
            {
                id = 1,
                Value = $"{avoirCLI.Commentaire}{(avoirCLI.IdTCommandeVente != 0 ? $" ({avoirCLI.IdTCommandeVente})" : "")}"
            };
            n.Add(i);

            if (cartRule == null)
            {
                //On insert si l'avoir n'est pas déja utilisé
                if (avoirCLI.UtiliseLe.ToString() == "")
                {

                    cartRule = new cart_rule()
                    {
                        //CLI_id_t_avoir= avoirCLI.IdTAvoir,
                        id_customer = clientCLI.IdCustomerPrestashop,
                        reduction_amount = (decimal)avoirCLI.Montant,
                        reduction_tax = 1,
                        description = $"{avoirCLI.Commentaire}{(avoirCLI.IdTCommandeVente != 0 ? $" ({avoirCLI.IdTCommandeVente})" : "")}",
                        date_from = avoirCLI.CreeLe?.ToString("yyyy-MM-dd"),
                        date_to = avoirCLI.CreeLe?.AddYears(5).ToString("yyyy-MM-dd"),
                        code = avoirCLI.IdTAvoir.ToString(),
                        quantity = avoirCLI.UtiliseLe.ToString() == "" ? 1 : 0,
                        quantity_per_user = 1,
                        partial_use = 0,
                        minimum_amount_shipping = 1,
                        highlight = 1,
                        name = n,
                        active = avoirCLI.UtiliseLe.ToString() == "" ? 1 : 0


                    };

                    cartRule = await _cartRuleFactory.AddAsync(cartRule);
                    //avoirCLI.IdCartRulePrestashop = cartRule.id;
                    //_cliContext.TAvoirs.Update(avoirCLI);
                    //_cliContext.SaveChanges();
                    _cliContext.Database.ExecuteSqlRaw("UPDATE t_avoir SET IdCartRulePrestashop = {0} WHERE id_t_avoir = {1}", cartRule.id, avoirCLI.IdTAvoir);
                }



            }
            else
            {
                //On mets à jour si l'avoir n'est pas déja utilisé , on supprime si il est utilisé
                if (avoirCLI.UtiliseLe.ToString() == "")
                {

                        //CLI_id_t_avoir = avoirCLI.IdTAvoir,
                        //cartRule.id_customer = clientCLI.IdCustomerPrestashop;
                        cartRule.reduction_amount = (decimal)avoirCLI.Montant;
                        //reduction_tax = 1;
                        cartRule.description = $"{avoirCLI.Commentaire}{(avoirCLI.IdTCommandeVente != 0 ? $" ({avoirCLI.IdTCommandeVente})" : "")}";
                        cartRule.date_from = avoirCLI.CreeLe?.ToString("yyyy-MM-dd");
                        cartRule.date_to = avoirCLI.CreeLe?.AddYears(5).ToString("yyyy-MM-dd");
                        //code = avoirCLI.IdTAvoir.ToString();
                        //quantity = avoirCLI.UtiliseLe.ToString() == "" ? 1 : 0;
                        //quantity_per_user = 1;
                       // partial_use = 0;
                        //minimum_amount_shipping = 1;
                        //highlight = 1;
                        cartRule.name = n;
                        //active = avoirCLI.UtiliseLe.ToString() == "" ? 1 : 0;




                    await _cartRuleFactory.UpdateAsync(cartRule);
                    //avoirCLI.IdCartRulePrestashop = cartRule.id;
                    //_cliContext.TAvoirs.Update(avoirCLI);
                    //_cliContext.SaveChanges();
                    //_cliContext.Database.ExecuteSqlRaw("UPDATE t_avoir SET id_cart_rule_prestashop = {0} WHERE id_t_avoir = {1}", cartRule.id, avoirCLI.IdTAvoir);
                }
                else
                {
                    await _cartRuleFactory.DeleteAsync(cartRule);
                }


                //cartRule.CLI_id_t_avoir = avoirCLI.IdTAvoir;
                //cartRule.id_customer = clientCLI.IdCustomerPrestashop;
                //cartRule.reduction_amount = (decimal)avoirCLI.Montant;
                //cartRule.reduction_tax = 1;
                //cartRule.description = avoirCLI.Commentaire;
                //cartRule.date_from = avoirCLI.CreeLe?.ToString("yyyy-MM-dd");
                //cartRule.date_to = avoirCLI.CreeLe?.AddYears(2).ToString("yyyy-MM-dd");
                //cartRule.code = avoirCLI.IdTAvoir.ToString();
                //cartRule.quantity = avoirCLI.UtiliseLe.ToString() == "" ? 1 : 0;
                //cartRule.quantity_per_user = 1;
                //cartRule.partial_use = 0;
                //cartRule.minimum_amount_shipping = 1;
                //cartRule.highlight = 1;
                //cartRule.name = n;
                //cartRule.active = avoirCLI.UtiliseLe.ToString() == "" ? 1 : 0;
                //await _cartRuleFactory.UpdateAsync(cartRule);
            }

            return _responseMessage;
        }
    }
}

