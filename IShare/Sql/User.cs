using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Utility;

namespace DAL
{
    public class User:BaseDAL,IUserDAL
    {
        public User(IOptions<ConnectionStrings> appConfiguration) : base(appConfiguration)
        {
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
