using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class User:IUserDAL
    {
        static readonly string connectionString = "Server=tcp:ishareappserver.database.windows.net,1433;Initial Catalog=iShareData;Persist Security Info=False;User ID=ishareAdmin;Password=Hpjjphhpj1314151;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public int ThirdPartyLogin(string username)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("ThirdPartyLogin", connection) { CommandType = System.Data.CommandType.StoredProcedure })
                {
                    connection.Open();
                    command.Parameters.Add(new SqlParameter("@username", username));
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader == null)
                        {
                            return -1;
                        }
                        else
                        {
                            int userId = -1;
                            while (reader.Read())
                            {
                                userId = (int)reader["Id"];
                            }
                            return userId;
                        }
                    }
                }
            }
        }

        public int ValidateLogin(string username,string pwd) 
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("ValidateLogin", connection) { CommandType = System.Data.CommandType.StoredProcedure })
                {
                    connection.Open();
                    command.Parameters.Add(new SqlParameter("@username", username));
                    command.Parameters.Add(new SqlParameter("@pwd", pwd));
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader == null)
                        {
                            return -1;
                        }
                        else 
                        {
                            int userId = -1;
                            while (reader.Read()) 
                            {
                                userId = (int)reader["Id"];
                            }
                            return userId;
                        }
                    }
                }
            }
        }

        
    }
}
