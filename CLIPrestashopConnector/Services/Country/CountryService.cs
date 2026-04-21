using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Xml;
using Bukimedia.PrestaSharp.Entities;
using Bukimedia.PrestaSharp.Factories;
using CLICore.Data;
using CLICore.Models;
using CLICore.Services.Logger;
using CLIPrestashopConnector.Services.PrestashopErrorDecoder;
using CLIPrestashopConnector.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using AppSettings = CLIPrestashopConnector.Models.AppSettings;

namespace CLIPrestashopConnector.Services.Country
{
	public class CountryService: ICountryService
	{

        private readonly CountryFactory _countryFactory;
        private readonly AppSettings _appSettings;
        private readonly CLIContext _cliContext;
        private readonly ILogService _logServices;
        private readonly IPrestashopErrorDecoderService _prestashopErrorDecoderService;


        public CountryService(IOptions<AppSettings> appSettings, CLIContext cliContext, ILogService logService, IPrestashopErrorDecoderService prestashopErrorDecoderService)
        {
            this._appSettings = appSettings?.Value ?? throw new ArgumentNullException(nameof(appSettings));
            this._countryFactory = new CountryFactory(_appSettings.Endpoint, _appSettings.ApiKey, _appSettings.Password);
            _cliContext = cliContext;
            _logServices = logService;
            _prestashopErrorDecoderService = prestashopErrorDecoderService;
        }

        #region Prestashop
        //Get
        public async Task<country> PSGetCountryAsync(long id)
        {
            var country = _countryFactory.Get(id);
            if (country is null) country = new country();
            return country;

        }

        public async Task<country> PSGetCountryAsync(string name)
        {

            Dictionary<string, string> dtn = new Dictionary<string, string>();

            dtn.Add("name", name);
            var country =  _countryFactory.GetByFilter(dtn,null,null).FirstOrDefault();
            if (country is null) country = new country();
            return country;

        }
        public async Task<country> PSGetCountryByIsoCodeAsync(string isoCode)
        {

            Dictionary<string, string> dtn = new Dictionary<string, string>();

            dtn.Add("iso_code", isoCode);
            var country = _countryFactory.GetByFilter(dtn, null, null).FirstOrDefault();
            if (country is null) country = new country();
            return country;

        }
        public async Task<country> PSGetCountryAsync(TClient clientCLI)
        {
            // On récupère le code ISO du pays du client
            var codeIso = (from p in _cliContext.TPays where p.Libelle == clientCLI.Pays select p.CodePays).FirstOrDefault();
            

            Dictionary<string, string> dtn = new Dictionary<string, string>();

            dtn.Add("iso_code", codeIso);
            var country = new country();
            try
            {
                country = _countryFactory.GetByFilter(dtn, null, null).FirstOrDefault();
            }
            catch (Exception ex)
            {
                //var pattern = @"\<.*\>";
                //var match = Regex.Match(ex.Message, pattern, RegexOptions.Multiline | RegexOptions.Singleline);
                //if (match.Success)
                //{
                //    //Console.WriteLine(match.Groups[0]);
                //    XmlDocument doc = new XmlDocument();
                //    doc.LoadXml(match.Groups[0].Value);
                //}


                 _prestashopErrorDecoderService.Decode(ex.Message);
                
            }
            
            if (country is null) country = new country();
            return country;
        }
        #endregion

        #region CLI

        #endregion

        #region CrossLogic

        #endregion

    }
}

