using System;
using System.Data;
using System.Data.SqlClient;

namespace IShare.DAL
{
    public class SqlHelper
    {
        private string dbAddr;
        public string constr = "Data Source=DESKTOP-FG071FQ;Initial Catalog=IShareData;Integrated Security=True";
        public SqlHelper(string addr) 
        {
            this.dbAddr = constr;
        }
        //Get data from database
        public DataTable ExecuteTable(string sqlStr, params SqlParameter[] sqlPar) 
        {
            using (SqlConnection conn = new SqlConnection(dbAddr)) 
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr,conn);
                cmd.Parameters.AddRange(sqlPar);
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sd.Fill(ds);
                return ds.Tables[0];
            }
        }

        //CUD
        public int ExecuteNoneQuery(string sqlStr, params SqlParameter[] sqlPar)
        {
            using (SqlConnection conn = new SqlConnection(dbAddr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.Parameters.AddRange(sqlPar); 
                return cmd.ExecuteNonQuery();
            }
        }

        //Get data from database Procedures
        public DataTable ExecuteTableProcedure(string sqlStr, params SqlParameter[] sqlPar)
        {
            using (SqlConnection conn = new SqlConnection(dbAddr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(sqlPar);
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sd.Fill(ds);
                return ds.Tables[0];
            }
        }

        //CUD
        public int ExecuteNoneQueryProcedure(string sqlStr, params SqlParameter[] sqlPar)
        {
            using (SqlConnection conn = new SqlConnection(dbAddr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(sqlPar);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
