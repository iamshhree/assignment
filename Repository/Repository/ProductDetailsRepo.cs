using DBHelper;
//using Repository.Models;
using ShopBridgeRepo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ShopBridgeRepo.Repository
{
    public class ProductDetailsRepo
    {
        #region Public Methods
        public List<ProductDetails> GetProductDetails(Pagination<ProductDetails> pagination )
        {
            List<ProductDetails> lstPTypes = new List<ProductDetails>();
            lstPTypes = _getProductDetails(pagination);
            return lstPTypes;
        }

        public int GetProductDetailsCount(Pagination<ProductDetails> pagination)
        {
            int totalCount = 0;
            totalCount = _getProductDetailsCount(pagination);
            return totalCount;
        }

        public int AddProductDetails(ProductDetails productDetails)
        {
            List<Results> lstResult = new List<Results>();
            int result = 1;
            lstResult = _addProductDetails(productDetails);
            result = Int32.Parse(lstResult[0].Result.ToString());
            return result;
        }

        public int UpdateProductDetails(ProductDetails ProductDetails)
        {
            List<Results> lstResult = new List<Results>();
            int result = 1;
            lstResult = _updateProductDetails(ProductDetails);
            result = Int32.Parse(lstResult[0].Result.ToString());
            return result;
        }



        public int DeleteProductDetails(int ProductID)
        {
            List<Results> lstResult = new List<Results>();
            int result = 1;
            lstResult = _deleteProductDetails(ProductID);
            result = Int32.Parse(lstResult[0].Result.ToString());
            return result;
        }
        #endregion

        //Private Methods
        #region Private Methods
        private List<Results> _deleteProductDetails(int ProductID)
        {
            SqlCommand mobj_SqlCommand = new SqlCommand();
            List<Results> _lstPTypes = new List<Results>();
            string Command = "RSP_PRODUCT_DETAILS";
            mobj_SqlCommand.CommandText = Command;
            mobj_SqlCommand.CommandType = CommandType.StoredProcedure;
            mobj_SqlCommand.Parameters.AddWithValue("@PRODUCTID", ProductID.ToString());
            SqlHelper sqlHelper = new SqlHelper();
            _lstPTypes = sqlHelper.GetReaderBySQL<Results>(mobj_SqlCommand);
            return _lstPTypes;
        }
        private List<ProductDetails> _getProductDetails(Pagination<ProductDetails> pagination)
        {
            SqlCommand mobj_SqlCommand = new SqlCommand();
            List<ProductDetails> _lstPTypes = new List<ProductDetails>();
            string Command = "DSP_PRODUCT_DETAILS";
            mobj_SqlCommand.CommandText = Command;
            mobj_SqlCommand.CommandType = CommandType.StoredProcedure;
            if (pagination.SearchedRecord != "" || pagination.SearchedRecord != null)
            {
                mobj_SqlCommand.Parameters.AddWithValue("@PRODUCTNAME", pagination.SearchedRecord);
            }
            mobj_SqlCommand.Parameters.AddWithValue("@PageNumber", pagination.PageNumber);
            mobj_SqlCommand.Parameters.AddWithValue("@PageSize", pagination.NumberOfRecords);
            SqlHelper sqlHelper = new SqlHelper();
            _lstPTypes = sqlHelper.GetReaderBySQL<ProductDetails>(mobj_SqlCommand);
            return _lstPTypes;
        }

        private int _getProductDetailsCount(Pagination<ProductDetails> pagination)
        {
            SqlCommand mobj_SqlCommand = new SqlCommand();
            int totalCount = 0;
            List<Results> _lstPTypes = new List<Results>();
            string Command = "CSP_PRODUCT_DETAILS";
            mobj_SqlCommand.CommandText = Command;
            mobj_SqlCommand.CommandType = CommandType.StoredProcedure;
            if (pagination.SearchedRecord != "" || pagination.SearchedRecord != null)
            {
                mobj_SqlCommand.Parameters.AddWithValue("@PRODUCTNAME", pagination.SearchedRecord);
            }
            SqlHelper sqlHelper = new SqlHelper();
            _lstPTypes = sqlHelper.GetReaderBySQL<Results>(mobj_SqlCommand);
            totalCount = Convert.ToInt16(_lstPTypes[0].Result);
            return totalCount;
        }

        private List<Results> _addProductDetails(ProductDetails productDetails)
        {
            SqlCommand mobj_SqlCommand = new SqlCommand();
            List<Results> _lstResult = new List<Results>();
            string Command = "ISP_PRODUCT_DETAILS";
            mobj_SqlCommand.CommandText = Command;
            mobj_SqlCommand.CommandType = CommandType.StoredProcedure;
            mobj_SqlCommand.Parameters.AddWithValue("@PRODUCTTYPEID", productDetails.ProductTypeID);
            mobj_SqlCommand.Parameters.AddWithValue("@SUBPRODUCTTYPEID", productDetails.SubProductTypeID);
            mobj_SqlCommand.Parameters.AddWithValue("@PRODUCTNAME", productDetails.ProductName);
            mobj_SqlCommand.Parameters.AddWithValue("@PRODUCTDESC", productDetails.ProductDesc);
            mobj_SqlCommand.Parameters.AddWithValue("@PRODUCTQUANTITY", productDetails.ProductQuantity);
            mobj_SqlCommand.Parameters.AddWithValue("@PRODUCTVALUE", productDetails.ProductValue);
            mobj_SqlCommand.Parameters.AddWithValue("@PRODUCTOFFERS", productDetails.ProductOffers);
            SqlHelper sqlHelper = new SqlHelper();
            _lstResult = sqlHelper.GetReaderBySQL<Results>(mobj_SqlCommand);
            return _lstResult;
        }
        private List<Results> _updateProductDetails(ProductDetails productDetails)
        {
            SqlCommand mobj_SqlCommand = new SqlCommand();
            List<Results> _lstPTypes = new List<Results>();
            string Command = "USP_PRODUCT_DETAILS";
            mobj_SqlCommand.CommandText = Command;
            mobj_SqlCommand.CommandType = CommandType.StoredProcedure;
            mobj_SqlCommand.Parameters.AddWithValue("@PRODUCTID", productDetails.ProductID);
            mobj_SqlCommand.Parameters.AddWithValue("@PRODUCTTYPEID", productDetails.ProductTypeID);
            mobj_SqlCommand.Parameters.AddWithValue("@SUBPRODUCTTYPEID", productDetails.SubProductTypeID);
            mobj_SqlCommand.Parameters.AddWithValue("@PRODUCTNAME", productDetails.ProductName);
            mobj_SqlCommand.Parameters.AddWithValue("@PRODUCTDESC", productDetails.ProductDesc);
            mobj_SqlCommand.Parameters.AddWithValue("@PRODUCTQUANTITY", productDetails.ProductQuantity);
            mobj_SqlCommand.Parameters.AddWithValue("@PRODUCTVALUE", productDetails.ProductValue);
            mobj_SqlCommand.Parameters.AddWithValue("@PRODUCTOFFERS", productDetails.ProductOffers);
            SqlHelper sqlHelper = new SqlHelper();
            _lstPTypes = sqlHelper.GetReaderBySQL<Results>(mobj_SqlCommand);
            return _lstPTypes;
        }
        #endregion
    }
}
