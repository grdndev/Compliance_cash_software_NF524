using System;
using CLIPrestashopConnector.Models;

namespace CLIPrestashopConnector.Services.Product
{
    public interface IProductService
    {


        /// <summary>
        /// Permet de mettre à jour ou inserer un produit PS depuis CLI
        /// </summary>
        /// <param name="id">Id du produit dans CLI</param>
        /// <returns></returns>
        Task<ResponseMessage> AddOrUpdatePSfromCLIByIdAsync(long id, Boolean importLegacyImages = false, string EnteteVersion = "version",bool importStock = false);
        Task<ResponseMessage> DeletePSProductfromCLIByIdAsync(long id);
        Task<ResponseMessage> DeletePSCombinaisonfromCLIByIdAsync(long id);
        Task<ResponseMessage> CleanPSFromCLIAsync();
        Task<ResponseMessage> ImportFromLegacySubFamilyFromCLIByIdAsync(long id_t_sousfamille,long id_t_famille, bool image=false,bool onlyErrors=false,bool onlyNewSync=false,DateTime? UpdatedDateFrom=null,bool importStock = false, bool deleteBeforeImport = false);
        Task<ResponseMessage> GetProductImage(long ProductId, long ImageId);
        Task<ResponseMessage> DeleteProductImage(long ProductId, long ImageId);
        Task<ResponseMessage> DeleteProductImages(long ProductId, List<long> ImageId);
        Task<ResponseMessage> DeleteAllProductImages(long ProductId);
        Task<ResponseMessage> GetProductImages(long ProductId);
        Task<ResponseMessage> AddProductImage(long ProductId, byte[] Image);
        Task<ResponseMessage> AddProductImages(long ProductId, List<ImageData> Images);
        Task<ResponseMessage> UpdateProductImage(ImageData image);
        Task<ResponseMessage> UpdatePSStockfromCLIByIdAsync(long id);
        Task<ResponseMessage> SortProductOptionValueAsync(long productionOptionId);
        Task<ResponseMessage> GetAllProductOptionAsync();
Task<ResponseMessage> DeleteProductFromPSWithNoMatchCLIAsync();
        Task<ResponseMessage> GetProductUrlFromPSAsync(long id);
  Task<ResponseMessage> GetProductDefaultImageId(long ProductId);
  Task<ResponseMessage> SetProductDefaultImage(long ProductId, long ImageId);
  Task<ResponseMessage> EraseAllProductsFromPSAsync();
        Task<List<ResponseMessage>> AddOrUpdateMultiplePSfromCLIByIdsAsync(List<long> ids, bool importLegacyImages = false, bool importStock = false);
        Task<ResponseMessage> GetUniqueAvailableNowMessagesFromPSAsync();
        Task<ResponseMessage> GetUniqueAvailableLaterMessagesFromPSAsync();
        Task<ResponseMessage> UpdateAvailableNowMessageAsync(string currentMessage, string newMessage);
        Task<ResponseMessage> UpdateAvailableLaterMessageAsync(string currentMessage, string newMessage);

    }
}

