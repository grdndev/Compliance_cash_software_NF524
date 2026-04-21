using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Bukimedia.PrestaSharp.Entities;
using CLICore.Models;
using CLIPrestashopConnector.Models;

namespace CLIPrestashopConnector.Services.Customer
{
    public interface ICustomerService
    {
        Task<IEnumerable<customer>> ListPSAsync();
        Task<customer> GetPSByIdAsync(long id);
        Task<bool> UpdatePSByIdAsync(long id, string modification);
        Task<IEnumerable<TClient>> ListCLIAsync();
        Task<bool> UpdateCLIfromPSByIdAsync(long id);
        Task<bool> DeleteAllCustomer();
        Task<bool> ImportPSfromCLI();
        Task<bool> SyncFromCLI(long id);
        Task<bool> FullSyncFromCLI(long id);
        Task<bool> SyncFromPS(long id);
        Task<bool> FullSyncFromPS(long id);


//
/// <summary>
/// Permet de mettre à jour ou d'inserer un client PS depuis CLI
/// </summary>
/// <param name="associatedAddresses">Adresses à synchroniser ?</param>
/// <param name="associatedCartRule">Avoirs à synchroniser ?</param>
/// <returns></returns>

Task<ResponseMessage> ImportFromCLIAsync(bool associatedAddress = false, bool associatedCartRule=false, DateTime? UpdatedDateFrom = null, bool onlyErrors = false);


        //
        /// <summary>
        /// Permet de mettre à jour ou d'inserer un client CLI depuis PS
        /// </summary>
        /// <param name="id">Id du client PS</param>
        /// <returns></returns>
        Task<ResponseMessage> AddOrUpdateCLIfromPSByIdAsync(long id, bool associatedAddress = false, bool associatedCartRule = false);

        /// <summary>
        /// Permet de supprimer un client dans CLI à partir de son Id
        /// </summary>
        /// <param name="id">Id du client dans CLI</param>
        /// <param name="associatedAddresses">Adresses à synchroniser ?</param>
        /// <param name="associatedCartRule">Avoirs à synchroniser ?</param>
        /// <returns></returns>
        Task<ResponseMessage> DeleteCLIByIdAsync(long id);

        /// <summary>
        /// Permet de mettre à jour ou inserer un client PS depuis CLI
        /// </summary>
        /// <param name="id">Id du client dans CLI</param>
        /// <param name="associatedAddresses">Adresses à synchroniser ?</param>
        /// <param name="associatedCartRule">Avoirs à synchroniser ?</param>
        /// <returns></returns>

        Task<ResponseMessage> AddOrUpdatePSfromCLIByIdAsync(long id, bool associatedAddress = false, bool associatedCartRule=false);

        /// <summary>
        /// Permet de supprimer un client PS à partir de son Id
        /// </summary>
        /// <param name="id">Id du client dans PS</param>
        /// <returns></returns>
        Task<ResponseMessage> DeletePSByIdAsync(long id);

        Task<ResponseMessage> AddOrUpdateAvoirPSfromCLIByIdAsync(long id);
    Task<ResponseMessage> EraseAllCustomersFromPSAsync();

    }
}
