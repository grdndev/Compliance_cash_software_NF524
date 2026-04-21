using System;
using CLIPrestashopConnector.Models;

namespace CLIPrestashopConnector.Services.CartRule
{
    public interface ICartRuleService
    {

        /// <summary>
        /// Permet de mettre à jour ou inserer un avoir client PS depuis CLI
        /// </summary>
        /// <param name="id">Id de l'avoir dans CLI</param>
        /// <returns></returns>
        Task<ResponseMessage> AddOrUpdatePSfromCLIByIdAsync(long id);


    }

}

