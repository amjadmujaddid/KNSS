using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace KNSSEF.SPFunction
{
    public class Func
    {
        #region Store Procedure Function

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

        public static DataSet ExecDataBySp(string SpName, Dictionary<string, string> spParams, SqlConnection dbConString = null)
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
                //dbConString.Close();
                //dbConString.Dispose();
                sCommand.Dispose();
                sAdapter.Dispose();
                sDataSet = null;
            }

            return dData;


        }

        #endregion
    }
}
