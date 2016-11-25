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
