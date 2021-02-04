using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
    public class Event : IEventDAL
    {
        static readonly string connectionString = "Server=tcp:ishareappserver.database.windows.net,1433;Initial Catalog=iShareData;Persist Security Info=False;User ID=ishareAdmin;Password=Hpjjphhpj1314151;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

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
                            events.Add(new Models.Event { Id = (int)reader["Id"], EventName = (string)reader["EventName"] });
                        }
                    }
                }
            }
            return events;
        }

        public IEnumerable<Models.Event> ListEventsById(int id)
        {
            var events = new List<Models.Event>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("ShowEventByUser", connection) { CommandType = System.Data.CommandType.StoredProcedure })
                {
                    connection.Open();
                    command.Parameters.Add(new SqlParameter("@id", id));
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            events.Add(new Models.Event { Id = (int)reader["Id"], EventName = (string)reader["EventName"] });
                        }
                    }
                }
            }
            return events;
        }
    }
}
