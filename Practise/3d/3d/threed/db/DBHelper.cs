using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
/// <summary>
/// DataAccess 的摘要说明
/// </summary>


namespace threed
{
    public class DataHelper
    {
        public DataHelper()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        public static IDbConnection GetCon()
        {
            string connStr = ConfigurationManager.AppSettings["constr"]; //@"Server=XQ-COMPUTER\SQLEXPRESS;Database=DBExpense;Uid=zhliu;Pwd=123456";
            //string conStr = @"Driver={SQL Native Client};Server=myServerAddress;Database=myDataBase;Uid=zhliu;Pwd=123456";
            IDbConnection con = new SqlConnection(connStr);
            return con;
        }
        public static DataSet ExecuteDataSet(IDbConnection con, string sql, CommandType commandType)
        {
            DataSet ds = new DataSet();
            switch (commandType)
            {
                case CommandType.Text:
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = commandType;
                    cmd.CommandText = sql;
                    cmd.Connection = (SqlConnection)con;
                    IDbDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    break;
                default:
                    ds = null;
                    break;
            }
            return ds;
        }

        public static void ExecuteNonQuery(IDbConnection con, string sql, CommandType commandType)
        {
            switch (commandType)
            {
                case CommandType.Text:
                    IDbCommand cmd = new SqlCommand();
                    cmd.CommandType = commandType;
                    cmd.CommandText = sql;
                    cmd.Connection = con;
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    cmd.ExecuteNonQuery();
                    break;
                default:
                    throw new Exception("invalid params");
                    break;
            }
            con.Close();
        }


    }
}