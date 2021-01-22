﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class User:IUserDAL
    {
        static readonly string connectionString = "Data Source=DESKTOP-FG071FQ;Initial Catalog=IShareData;Integrated Security=True;";

        public int ValidateLogin(string username,string pwd) 
        {
            var events = new List<Models.Event>();
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
                            return 0;
                        }
                        else 
                        {
                            int userId = 0;
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