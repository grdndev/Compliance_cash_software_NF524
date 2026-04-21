using System;
using CLIPrestashopConnector.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CLIPrestashopConnector.Dtos
{
    public class ShippingCostDto
    {
        public long Id_address { get; set; } 
        public decimal TotalOrder { get; set; }
        public List<ShippingCostProductDto> shippingCostProductDtos { get; set; } 

        public ShippingCostDto(long id_address, decimal totalOrder)
        {
            Id_address = id_address;
            TotalOrder = totalOrder;
            shippingCostProductDtos = new List<ShippingCostProductDto>();
        }


    }
}