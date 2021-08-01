using System;
using System.Collections.Generic;
using System.Text;

namespace ShopBridgeRepo.Models
{
    public class SubProductType
    {
        public int SubProductTypeID { get; set; }
        public int ProductTypeID { get; set; }
        public string SubProductTypeName { get; set; }

        public SubProductType(int subproductTypId, int productTypId, string subProductTypeName)
        {
            SubProductTypeID = subproductTypId;
            ProductTypeID = productTypId;
            SubProductTypeName = subProductTypeName;
        }

        public SubProductType()
        {

        }
    }
}
