using System;
using Bukimedia.PrestaSharp.Entities;
using CLICore.Models;

namespace CLIPrestashopConnector.Services.Country
{
	public interface ICountryService
	{
        Task<country> PSGetCountryAsync(long id);

        Task<country> PSGetCountryAsync(string name);
        Task<country> PSGetCountryByIsoCodeAsync(string isoCode);
        Task<country> PSGetCountryAsync(TClient clientCLI);

    }

}

