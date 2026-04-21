using System;
using CLIPrestashopConnector.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CLIPrestashopConnector.Dtos
{
    public class ShippingCostProductDto
    {
        public long Id_product { get; set; }
        public long? Id_product_attribute { get; set; }

        public ShippingCostProductDto(long id_product, long? id_product_attribute)
        {
            Id_product = id_product;
            Id_product_attribute = id_product_attribute;
        }
       
            
     
    }
}