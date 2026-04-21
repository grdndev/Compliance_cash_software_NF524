using System;
using Bukimedia.PrestaSharp.Entities;
using CLICore.Models;
using CLIPrestashopConnector.Models;

namespace CLIPrestashopConnector.Services
{
	public interface IAddressService
	{
        //Task<bool> SyncFromPSById(long id);
        //Task<bool> PSUpdateAddressAsync(TClient clientCLI);
        //Task<address> PSAddAddressAsync(TClient clientCLI);
        //Task<address> PSAddAddressAsync(TAdresse adresseClientCLI, TClient clientCLI);
        //Task<address> PSGetAddressAsync(string id, string alias);

        //
        /// <summary>
        /// Permet de mettre à jour ou d'inserer une adresse client CLI depuis PS
        /// </summary>
        /// <param name="id">Id de l'adresse PS</param>
        /// <returns></returns>
        Task<ResponseMessage> AddOrUpdateCLIfromPSByIdAsync(long id);

        /// <summary>
        /// Permet de supprimer une adresse dans CLI à partir de son Id
        /// </summary>
        /// <param name="id">Id de l'adresse dans CLI</param>
        /// <returns></returns>
        Task<ResponseMessage> DeleteCLIByIdAsync(long id);

        /// <summary>
        /// Permet de mettre à jour ou inserer une adresse client PS depuis CLI
        /// </summary>
        /// <param name="id">Id de l'adresse dans CLI</param>
        /// <returns></returns>
        Task<ResponseMessage> AddOrUpdatePSfromCLIByIdAsync(long id);

        /// <summary>
        /// Permet de supprimer une adresse client PS à partir de son Id
        /// </summary>
        /// <param name="id">Id de l'adresse dans PS</param>
        /// <returns></returns>
        Task<ResponseMessage> DeletePSByIdAsync(long id);
    }
}

