using System;
using System.Collections.Generic;
using System.Text;

namespace ShopBridgeRepo.Models
{
    public class ProductType
    {
        public int ProductTypeID { get; set; }
        public string ProductTypeName { get; set; }

        public ProductType(int productTypId , string productTypeName)
        {
            ProductTypeID = productTypId;
            ProductTypeName = productTypeName;
        }

        public ProductType()
        {

        }
    }
}
