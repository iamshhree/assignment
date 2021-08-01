using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Reflection;

namespace SQLConnect
{
    public class SqlHelper
    {
        private static string mstr_ConnectionString;
        private SqlConnection mobj_SqlConnection;
        private SqlCommand mobj_SqlCommand;
        private int mint_CommandTimeout = 30;



        public SqlHelper()
        {
            try
            {
                //string a = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                //mstr_ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                //mstr_ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                //mobj_SqlConnection = new SqlConnection(mstr_ConnectionString);
                //mobj_SqlCommand = new SqlCommand();
                //mobj_SqlCommand.CommandTimeout = mint_CommandTimeout;
                //mobj_SqlCommand.Connection = mobj_SqlConnection;


                //ParseConnectionString();
            }
            catch (Exception ex)
            {
                throw new Exception("Error initializing data class." + Environment.NewLine + ex.Message);
            }
        }

        private string GetConnectionString()
        {
            ConnectionStringSettingsCollection connections = ConfigurationManager.ConnectionStrings;

            if (connections != null)
            {
                foreach (ConnectionStringSettings cs in connections)
                {
                    Console.WriteLine(cs.Name);
                    Console.WriteLine(cs.ProviderName);
                    Console.WriteLine(cs.ConnectionString);
                }
            }
            string mstr_ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            return mstr_ConnectionString;
        }
        public void Dispose()
        {
            try
            {
                //Clean Up Connection Object
                if (mobj_SqlConnection != null)
                {
                    if (mobj_SqlConnection.State != ConnectionState.Closed)
                    {
                        mobj_SqlConnection.Close();
                    }
                    mobj_SqlConnection.Dispose();
                }

                //Clean Up Command Object
                if (mobj_SqlCommand != null)
                {
                    mobj_SqlCommand.Dispose();
                }

            }

            catch (Exception ex)
            {
                throw new Exception("Error disposing data class." + Environment.NewLine + ex.Message);
            }

        }

        public void CloseConnection()
        {
            if (mobj_SqlConnection.State != ConnectionState.Closed) mobj_SqlConnection.Close();
        }
        public int GetExecuteScalarByCommand(string Command)
        {

            object identity = 0;
            try
            {
                mobj_SqlCommand.CommandText = Command;
                mobj_SqlCommand.CommandTimeout = mint_CommandTimeout;
                mobj_SqlCommand.CommandType = CommandType.StoredProcedure;

                mobj_SqlConnection.Open();

                mobj_SqlCommand.Connection = mobj_SqlConnection;
                identity = mobj_SqlCommand.ExecuteScalar();
                CloseConnection();
            }
            catch (Exception ex)
            {
                CloseConnection();
                throw ex;
            }
            return Convert.ToInt32(identity);
        }

        public int GetExecuteNonQueryByCommand(SqlCommand Command)
        {
            try
            {
                //mobj_SqlCommand.CommandText = Command;
                //mobj_SqlCommand.CommandTimeout = mint_CommandTimeout;
                //mobj_SqlCommand.CommandType = CommandType.StoredProcedure;
                int rowsAffected = 0;
                mobj_SqlConnection.Open();

                Command.Connection = mobj_SqlConnection;
                rowsAffected = Command.ExecuteNonQuery();
                CloseConnection();
                return rowsAffected;

            }
            catch (Exception ex)
            {
                CloseConnection();
                throw ex;
            }
        }



        public List<T> GetReaderBySQL<T>(SqlCommand command)
        {
            List<T> result = new List<T>();
            SqlConnection sqlConn = new SqlConnection(GetConnectionString());
            sqlConn.Open();
            try
            {
                //SqlCommand myCommand = new SqlCommand(strSQL, mobj_SqlConnection);
                SqlDataReader reader;
                reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    T item = _getItem<T>(row);
                    result.Add(item);
                }
                return result;
            }
            catch (Exception ex)
            {
                CloseConnection();
                throw ex;
            }
        }

        private static T _getItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

        public SqlDataReader GetReaderByCmd(string Command)
        {
            SqlDataReader objSqlDataReader = null;
            try
            {
                mobj_SqlCommand.CommandText = Command;
                mobj_SqlCommand.CommandType = CommandType.StoredProcedure;
                mobj_SqlCommand.CommandTimeout = mint_CommandTimeout;

                mobj_SqlConnection.Open();
                mobj_SqlCommand.Connection = mobj_SqlConnection;

                objSqlDataReader = mobj_SqlCommand.ExecuteReader();
                return objSqlDataReader;
            }
            catch (Exception ex)
            {
                CloseConnection();
                throw ex;
            }

        }

        public void AddParameterToSQLCommand(string ParameterName, SqlDbType ParameterType)
        {
            try
            {
                mobj_SqlCommand.Parameters.Add(new SqlParameter(ParameterName, ParameterType));
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AddParameterToSQLCommand(string ParameterName, SqlDbType ParameterType, int ParameterSize)
        {
            try
            {
                mobj_SqlCommand.Parameters.Add(new SqlParameter(ParameterName, ParameterType, ParameterSize));
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SetSQLCommandParameterValue(string ParameterName, object Value)
        {
            try
            {
                mobj_SqlCommand.Parameters[ParameterName].Value = Value;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
