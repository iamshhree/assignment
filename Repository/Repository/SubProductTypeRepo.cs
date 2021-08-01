using DBHelper;
using ShopBridgeRepo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ShopBridgeRepo.Repository
{
    public class SubProductTypeRepo
    {
        #region Public Methods
        public List<SubProductType> GetSubProductTypes(int id = 0)
        {
            List<SubProductType> lstPTypes = new List<SubProductType>();
            lstPTypes = _getSubProductTypes(id);
            return lstPTypes;
        }

        public int AddSubProductType(SubProductType subProductType)
        {
            List<Results> lstResult = new List<Results>();
            int result = 1;
            lstResult = _addSubProductType(subProductType);
            result = Int32.Parse(lstResult[0].Result.ToString());
            return result;
        }

        public int UpdateSubProductType(SubProductType SubProductType)
        {
            List<Results> lstResult = new List<Results>();
            int result = 1;
            lstResult = _updateSubProductType(SubProductType);
            result = Int32.Parse(lstResult[0].Result.ToString());
            return result;
        }



        public int DeleteSubProductType(int SubProductTypeID)
        {
            List<Results> lstResult = new List<Results>();
            int result = 1;
            lstResult = _deleteSubProductType(SubProductTypeID);
            result = Int32.Parse(lstResult[0].Result.ToString());
            return result;
        }
        #endregion

        //Private Methods
        #region Private Methods
        private List<Results> _deleteSubProductType(int SubProductTypeID)
        {
            SqlCommand mobj_SqlCommand = new SqlCommand();
            List<Results> _lstPTypes = new List<Results>();
            string Command = "RSP_SUBPRODUCT_TYPE";
            mobj_SqlCommand.CommandText = Command;
            mobj_SqlCommand.CommandType = CommandType.StoredProcedure;
            mobj_SqlCommand.Parameters.AddWithValue("@SubProductTypeID", SubProductTypeID.ToString());
            SqlHelper sqlHelper = new SqlHelper();
            _lstPTypes = sqlHelper.GetReaderBySQL<Results>(mobj_SqlCommand);
            return _lstPTypes;
        }
        private List<SubProductType> _getSubProductTypes(int id = 0)
        {
            SqlCommand mobj_SqlCommand = new SqlCommand();
            List<SubProductType> _lstPTypes = new List<SubProductType>();
            string Command = "DSP_SUBPRODUCT_TYPE";
            mobj_SqlCommand.CommandText = Command;
            mobj_SqlCommand.CommandType = CommandType.StoredProcedure;
            if (id != 0)
            {
                mobj_SqlCommand.Parameters.AddWithValue("@SubProductTypeID", id);
            }
            SqlHelper sqlHelper = new SqlHelper();
            _lstPTypes = sqlHelper.GetReaderBySQL<SubProductType>(mobj_SqlCommand);
            return _lstPTypes;
        }

        private List<Results> _addSubProductType(SubProductType subProductType)
        {
            SqlCommand mobj_SqlCommand = new SqlCommand();
            List<Results> _lstResult = new List<Results>();
            string Command = "ISP_SUBPRODUCT_TYPE";
            mobj_SqlCommand.CommandText = Command;
            mobj_SqlCommand.CommandType = CommandType.StoredProcedure;
            mobj_SqlCommand.Parameters.AddWithValue("@PRODUCTYPEID", subProductType.ProductTypeID);
            mobj_SqlCommand.Parameters.AddWithValue("@SUBPRODUCTYPENAME", subProductType.SubProductTypeName);
            SqlHelper sqlHelper = new SqlHelper();
            _lstResult = sqlHelper.GetReaderBySQL<Results>(mobj_SqlCommand);
            return _lstResult;
        }
        private List<Results> _updateSubProductType(SubProductType SubProductType)
        {
            SqlCommand mobj_SqlCommand = new SqlCommand();
            List<Results> _lstPTypes = new List<Results>();
            string Command = "USP_SUBPRODUCT_TYPE";
            mobj_SqlCommand.CommandText = Command;
            mobj_SqlCommand.CommandType = CommandType.StoredProcedure;
            mobj_SqlCommand.Parameters.AddWithValue("@SUBPRODUCTTYPEID", SubProductType.SubProductTypeID.ToString());
            mobj_SqlCommand.Parameters.AddWithValue("@PRODUCTTYPEID", SubProductType.ProductTypeID.ToString());
            mobj_SqlCommand.Parameters.AddWithValue("@SUBPRODUCTTYPENAME", SubProductType.SubProductTypeName.ToString());

            SqlHelper sqlHelper = new SqlHelper();
            _lstPTypes = sqlHelper.GetReaderBySQL<Results>(mobj_SqlCommand);
            return _lstPTypes;
        }
        #endregion
    }
}
