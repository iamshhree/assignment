using System;
using System.Collections.Generic;
using System.Text;

namespace ShopBridgeRepo.Models
{
    public class ProductDetails
    {
        public int ProductID { get; set; }
        public int ProductTypeID { get; set; }
        public int SubProductTypeID { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public decimal ProductQuantity { get; set; }
        public decimal ProductValue { get; set; }
        public string ProductOffers { get; set; }

        public ProductDetails(int productid, int producttypeid, int subproducttypeid, string productname, string productdesc, int quantity, int value, string offers)
        {
            ProductID = productid;
            ProductTypeID = producttypeid;
            SubProductTypeID = subproducttypeid;
            ProductName = productname;
            ProductDesc = productdesc;
            ProductQuantity = quantity;
            ProductValue = value;
            ProductOffers = offers;
        }

        public ProductDetails()
        {

        }
    }


}
