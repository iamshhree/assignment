using ShopBridgeRepo.Models;
using SQLConnect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ShopBridgeRepo.Repository
{
    public class ProductTypeRepo
    {
        public List<ProductType> GetProductTypes()
        {
            List<ProductType> lstPTypes = new List<ProductType>();
            lstPTypes = _getProductTypes();
            return lstPTypes;
        }

        private List<ProductType> _getProductTypes()
        {
            SqlCommand mobj_SqlCommand = new SqlCommand();
            List<ProductType> _lstPTypes = new List<ProductType>();
            string Command = "DSP_PRODUCT_TYPE";
            mobj_SqlCommand.CommandText = Command;
            mobj_SqlCommand.CommandType = CommandType.StoredProcedure;
            SqlHelper sqlHelper = new SqlHelper();
            _lstPTypes = sqlHelper.GetReaderBySQL<ProductType>(mobj_SqlCommand);
            return _lstPTypes;
        }
}
}
