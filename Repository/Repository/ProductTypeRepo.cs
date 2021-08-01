using DBHelper;
using ShopBridgeRepo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ShopBridgeRepo.Repository
{
    public class ProductTypeRepo
    {
        //Public Methods
        #region Public Methods
        public List<ProductType> GetProductTypes(int id = 0)
        {
            List<ProductType> lstPTypes = new List<ProductType>();
            lstPTypes = _getProductTypes(id);
            return lstPTypes;
        }

        public int AddProductType(string name)
        {
            List<Results> lstResult = new List<Results>();
            int result = 1;
            lstResult = _addProductType(name);
            result = Int32.Parse(lstResult[0].Result.ToString());
            return result;
        }

        public int UpdateProductType(ProductType productType)
        {
            List<Results> lstResult = new List<Results>();
            int result = 1;
            lstResult = _updateProductType(productType);
            result = Int32.Parse(lstResult[0].Result.ToString());
            return result;
        }



        public int DeleteProductType(int productTypeID)
        {
            List<Results> lstResult = new List<Results>();
            int result = 1;
            lstResult = _deleteProductType(productTypeID);
            result = Int32.Parse(lstResult[0].Result.ToString());
            return result;
        }
        #endregion

        //Private Methods
        #region Private Methods
        private List<Results> _deleteProductType(int productTypeID)
        {
            SqlCommand mobj_SqlCommand = new SqlCommand();
            List<Results> _lstPTypes = new List<Results>();
            string Command = "RSP_PRODUCT_TYPE";
            mobj_SqlCommand.CommandText = Command;
            mobj_SqlCommand.CommandType = CommandType.StoredProcedure;
            mobj_SqlCommand.Parameters.AddWithValue("@PRODUCTTYPEID", productTypeID.ToString());
            SqlHelper sqlHelper = new SqlHelper();
            _lstPTypes = sqlHelper.GetReaderBySQL<Results>(mobj_SqlCommand);
            return _lstPTypes;
        }
        private List<ProductType> _getProductTypes(int id = 0)
        {
            SqlCommand mobj_SqlCommand = new SqlCommand();
            List<ProductType> _lstPTypes = new List<ProductType>();
            string Command = "DSP_PRODUCT_TYPE";
            mobj_SqlCommand.CommandText = Command;
            mobj_SqlCommand.CommandType = CommandType.StoredProcedure;
            if (id != 0)
            {
                mobj_SqlCommand.Parameters.AddWithValue("@ProductTypeID", id);
            }
            SqlHelper sqlHelper = new SqlHelper();
            _lstPTypes = sqlHelper.GetReaderBySQL<ProductType>(mobj_SqlCommand);
            return _lstPTypes;
        }

        private List<Results> _addProductType(string name)
        {
            SqlCommand mobj_SqlCommand = new SqlCommand();
            List<Results> _lstResult = new List<Results>();
            string Command = "ISP_PRODUCT_TYPE";
            mobj_SqlCommand.CommandText = Command;
            mobj_SqlCommand.CommandType = CommandType.StoredProcedure;
            mobj_SqlCommand.Parameters.AddWithValue("@PRODUCTNAME", name);
            SqlHelper sqlHelper = new SqlHelper();
            _lstResult = sqlHelper.GetReaderBySQL<Results>(mobj_SqlCommand);
            return _lstResult;
        }
        private List<Results> _updateProductType(ProductType productType)
        {
            SqlCommand mobj_SqlCommand = new SqlCommand();
            List<Results> _lstPTypes = new List<Results>();
            string Command = "USP_PRODUCT_TYPE";
            mobj_SqlCommand.CommandText = Command;
            mobj_SqlCommand.CommandType = CommandType.StoredProcedure;
            mobj_SqlCommand.Parameters.AddWithValue("@PRODUCTTYPEID", productType.ProductTypeID.ToString());
            mobj_SqlCommand.Parameters.AddWithValue("@PRODUCTTYPENAME", productType.ProductTypeName.ToString());
            SqlHelper sqlHelper = new SqlHelper();
            _lstPTypes = sqlHelper.GetReaderBySQL<Results>(mobj_SqlCommand);
            return _lstPTypes;
        }
        #endregion
    }
}
