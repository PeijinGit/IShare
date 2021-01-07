using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class Event
    {
        static string connectionString = "data source=localhost\\SQLEXPRESS;Initial Catalog=master; Integrated Security = SSPI;";

        public IEnumerable<Models.Event> ListEvents()
        {
            var events = new List<Models.Event>();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("ListEvents", connection) { CommandType = System.Data.CommandType.StoredProcedure })
                {
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            events.Add(new Models.Event { Id = (int)reader["Id"], Name = (string)reader["Name"] });
                        }
                    }
                }
            }

            return events;
        }
    }
}
