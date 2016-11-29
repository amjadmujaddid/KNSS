using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNSSUtility
{
    public class Library
    {
        #region DBConnection
        public static string ConDb(string con = "")
        {
            string ret = "";
            switch (con)
            {
                case "0":
                default: ret = ConfigurationManager.ConnectionStrings["KNSSWeb"].ConnectionString; break;
            }
            return ret;
        }

        public static SqlConnection DbConString(string con)
        {
            SqlConnection ret = new SqlConnection(ConDb(con));
            return ret;
        }

        #endregion

        public static string InsertString(string table, Dictionary<string, string> _data)
        {
            string sValCol = "";
            string value = "";

            foreach (var data in _data)
            {
                sValCol += data.Key + ",";
                if (data.Value != null)
                {
                    value += "'" + IsInjection(data.Value) + "',";
                }
                else
                {
                    value += "NULL,";
                }
            }

            string sql = "insert into " + table + " (" + sValCol + ") values (" + value + "')";
            sql = sql.Replace(",')", ")");
            sql = sql.Replace(",)", ")");

            return sql;
        }

        public static string UpdateString(string table, Dictionary<string, string> _data, Dictionary<string, string> _where = null)
        {
            string value = "";
            string where = "";

            foreach (var data in _data)
            {
                if (data.Value != null)
                {
                    value += data.Key + "=" + "'" + IsInjection(data.Value) + "',";
                }
                else
                {
                    value += data.Key + "=NULL,";
                }
            }

            if (_where != null)
            {
                foreach (var data in _where)
                {
                    where += " and " + data.Key + "=" + "'" + IsInjection(data.Value) + "'";
                }
            }

            string sql = "update " + table + " set " + value + " where 1=1 " + where;
            return sql.Replace("', w", "' w");
        }

        public static string DeleteString(string table, Dictionary<string, string> _where)
        {
            string sql = "delete from " + table + " where 1=1 ";

            foreach (var data in _where)
            {
                sql += " and " + data.Key + "=" + "'" + IsInjection(data.Value) + "'";
            }

            return sql;
        }

        public static string IsInjection(string sData)
        {
            string ret = "";

            if (sData != "" && sData != null)
            {
                ret = sData.ToString().Replace("'", "''");
            }

            return ret.Trim();
        }

        #region Store Procedure Function

        #region SP Get Multi Data Function Repository

        public static DataSet ExecGetMultiDataBySP(string SpName, Dictionary<string, string> spParams, SqlConnection dbConString = null)
        {
            if (dbConString == null)
            {
                dbConString = DbConString("0");
            }

            DataSet dData;
            SqlDataAdapter sAdapter = new SqlDataAdapter();
            SqlCommand sCommand = new SqlCommand();
            DataSet sDataSet = new DataSet();

            try
            {
                dbConString.Close();
                dbConString.Open();

                sCommand = new SqlCommand(SpName, dbConString);
                foreach (var item in spParams)
                {
                    if (item.Value != "")
                    {
                        sCommand.Parameters.AddWithValue("@" + item.Key, item.Value);
                    }
                    else
                    {
                        sCommand.Parameters.AddWithValue("@" + item.Key, DBNull.Value);
                    }
                }

                sCommand.CommandType = CommandType.StoredProcedure;
                sAdapter.SelectCommand = sCommand;
                sAdapter.Fill(sDataSet);
                dData = sDataSet;
            }

            catch (Exception ex)
            {
                dData = null;
            }

            finally
            {
                dbConString.Close();
                dbConString.Dispose();
                sCommand.Dispose();
                sAdapter.Dispose();
                sDataSet = null;
            }

            return dData;


        }        

        #endregion

        #region SP IDAL Function Repository

        public static bool ExecSP(string SpName, string spType, Dictionary<string, string> spParams, SqlConnection dbConString = null)
        {
            bool res = true;

            if (dbConString == null)
            {
                dbConString = DbConString("0");
            }

            SqlDataAdapter sAdapter = new SqlDataAdapter();
            SqlCommand sCommand = new SqlCommand();

            try
            {
                sCommand = new SqlCommand(SpName, dbConString);
                foreach (var item in spParams)
                {
                    if (item.Value != "")
                    {
                        sCommand.Parameters.AddWithValue("@" + item.Key, item.Value);
                    }
                    else
                    {
                        sCommand.Parameters.AddWithValue("@" + item.Key, DBNull.Value);
                    }
                }

                sCommand.CommandType = CommandType.StoredProcedure;

                dbConString.Close();
                dbConString.Open();

                switch (spType)
                {
                    case "add":
                        sAdapter.InsertCommand = sCommand;
                        sAdapter.InsertCommand.ExecuteNonQuery();
                        break;
                    case "edit":
                        sAdapter.UpdateCommand = sCommand;
                        sAdapter.UpdateCommand.ExecuteNonQuery();
                        break;
                    case "delete":
                        sAdapter.DeleteCommand = sCommand;
                        sAdapter.DeleteCommand.ExecuteNonQuery();
                        break;
                    default:
                        break;
                }
                res = true;
            }

            catch (Exception ex)
            {
                res = false;
            }

            finally
            {
                dbConString.Close();
                dbConString.Dispose();
                sCommand.Dispose();
                sAdapter.Dispose();
                sCommand.Dispose();
            }

            return res;
        }

        #endregion

        #endregion
    }
}
