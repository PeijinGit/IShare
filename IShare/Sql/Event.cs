using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
    public class Event: IEventDal
    {
        static readonly string connectionString = "Data Source=DESKTOP-FG071FQ;Initial Catalog=IShareData;Integrated Security=True;";

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
            //string sql = "SELECT * FROM Events WHERE ID";
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
