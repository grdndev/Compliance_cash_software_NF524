using System;
using CLIPrestashopConnector.Dtos;
using CLIPrestashopConnector.Models;

namespace CLIPrestashopConnector.Services.Order
{
    public interface IOrderService
    {
        Task<ResponseMessage> ImportFromPSByIdAsync(long id,string reference,bool force=false);
        Task<ResponseMessage> UpdateOrderStatusFromCLIByIdAsync(long id);
        Task<ResponseMessage> GetOrderInvoiceFromCLIByIdAsync(long id);
        Task<ResponseMessage> SetOrderInvoiceFromCLIByIdAsync(long id,byte[] facture);
        Task<ResponseMessage> GetShippingCostAsync(ShippingCostDto shippingCostDto);
    }
}

