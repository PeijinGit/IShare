using System;
using System.Data;
using System.Data.SqlClient;

namespace IShare.DAL
{
    public class SqlHelper
    {
        private string P_addr;

        public SqlHelper(string addr) 
        {
            this.P_addr = addr;
        }
        //Get data from database
        public DataTable ExecuteTable(string sqlStr, params SqlParameter[] sqlPar) 
        {
            using (SqlConnection conn = new SqlConnection(P_addr)) 
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

        //CRUD
        public int ExecuteNoneQuery(string sqlStr, params SqlParameter[] sqlPar)
        {
            using (SqlConnection conn = new SqlConnection(P_addr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.Parameters.AddRange(sqlPar); 
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
