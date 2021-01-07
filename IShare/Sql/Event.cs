using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
    public class Event
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

        //public IEnumerable<Models.Event> ListEventsById(int id)
        //{
        //    var events = new List<Models.Event>();
        //    using (var connection = new SqlConnection(connectionString))
        //    {
        //        using (var command = new SqlCommand("ShowEventByUser", connection) { CommandType = CommandType.StoredProcedure })
        //        {
        //            connection.Open();
        //            command.Parameters.Add(new SqlParameter( "@id",id));
        //            SqlDataAdapter sd = new SqlDataAdapter(command);
        //            DataSet ds = new DataSet();
        //            sd.Fill(ds);
        //            DataTable dt = ds.Tables[0];
        //            foreach (DataRow dr in dt.Rows)
        //            {
        //                events.Add(ToEventModel(dr));
        //            }
        //        }
        //    }
        //    return events;
        //}

        //private Models.Event ToEventModel(DataRow dr)
        //{
        //    Models.Event md = new Models.Event();
        //    md.Id = (int)dr["Id"];
        //    md.EventName = dr["EventName"].ToString();
        //    return md;
        //}
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
