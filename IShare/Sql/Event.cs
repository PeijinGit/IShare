using Microsoft.Extensions.Options;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
    public class Event : BaseDAL, IEventDAL
    {

        public Event(IOptions<AppSettingModels> appSettings) : base(appSettings)
        {
        }
        /// <summary>
        /// Add event function
        /// Insert single event with eventId CreatorId and eventName 
        /// </summary>
        /// <param name="creatorId"></param>
        /// <param name="eventName"></param>
        /// <returns></returns>
        public Models.Event AddEvent(int creatorId, string eventName)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("AddEvents", connection) { CommandType = System.Data.CommandType.StoredProcedure })
                {
                    connection.Open();
                    string id = System.Guid.NewGuid().ToString("N");
                    command.Parameters.Add(new SqlParameter("@creatorId", creatorId));
                    command.Parameters.Add(new SqlParameter("@eventName", eventName));
                    command.Parameters.Add(new SqlParameter("@id", id));
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader == null)
                        {
                            return null;
                        }
                        else
                        {
                            return new Models.Event { Id = id, EventName = eventName };
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Update event function
        /// Update event with eventId and new eventName 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="eventName"></param>
        /// <returns></returns>
        public Models.Event UpdateEvent(string id, string eventName)
        {
            var events = new List<Models.Event>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("UpdateEvent", connection) { CommandType = System.Data.CommandType.StoredProcedure })
                {
                    connection.Open();
                    command.Parameters.Add(new SqlParameter("@eventName", eventName));
                    command.Parameters.Add(new SqlParameter("@id", id));
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader == null)
                        {
                            return null;
                        }
                        else
                        {
                            return new Models.Event { Id = id, EventName = eventName };
                        }
                    }
                }
            }
        }

        /// <summary>
        /// List All Events
        /// </summary>
        /// <returns></returns>
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
                            events.Add(new Models.Event { Id = (string)reader["Id"], EventName = (string)reader["EventName"], UserId = (int)reader["CreatorId"] });
                        }
                    }
                }
            }
            return events;
        }

        /// <summary>
        /// list by user id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
                            events.Add(new Models.Event { Id = (string)reader["Id"], EventName = (string)reader["EventName"] });
                        }
                    }
                }
            }
            return events;
        }

        public int AddActivity(int i)
        {
            string name = "";
            DateTime start = DateTime.Now;
            string eventId = "";
            int count = 0;
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("AddActivities", connection) { CommandType = System.Data.CommandType.StoredProcedure })
                {
                    connection.Open();
                    DateTime end = start.AddDays(15 + i);
                    name = "AC" + i;
                    eventId = i + "";
                    string id = System.Guid.NewGuid().ToString("N");
                    command.Parameters.Add(new SqlParameter("@id", id));
                    command.Parameters.Add(new SqlParameter("@name", name));
                    command.Parameters.Add(new SqlParameter("@startDate", start));
                    command.Parameters.Add(new SqlParameter("@endDate", end));
                    command.Parameters.Add(new SqlParameter("@eventId", eventId));
                    using (var reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            count = (int)reader["RowNum"];
                        }
                    }

                }
            }
            return count;
        }

        public Tuple<List<Models.Activities>, int> ListActivitiesByPage(int startPage, int pageSize)
        {
            var activites = new List<Models.Activities>();
            int count = -1;
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("AcPage", connection) { CommandType = System.Data.CommandType.StoredProcedure })
                {
                    connection.Open();
                    command.Parameters.Add(new SqlParameter("@startPage", startPage));
                    command.Parameters.Add(new SqlParameter("@pageSize", pageSize));

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            if (count == -1)
                            {
                                count = (int)reader["ACsum"];
                            }
                            activites.Add(new Models.Activities
                            {
                                Id = (string)reader["Id"],
                                AcName = (string)reader["Name"],
                                EsFee = (int)reader["EsFee"],
                                Descript = (string)reader["Descript"],
                                StartDate = (DateTime)reader["StartTime"],
                                EndDate = (DateTime)reader["EndTime"],
                                EventId = (string)reader["EventId"],
                                AcStatus = (byte)reader["Status"],
                                Img = (string)reader["Imgs"],
                                Detail = (string)reader["Detail"],
                                Vision = (byte)reader["Vision"],
                            });

                        }
                    }
                }
            }
            return new Tuple<List<Activities>, int>(activites, count);
        }

        public Tuple<List<Models.Activities>, int> SearchByCondition(int startPage, int pageSize,string keyWord, string proc)
        {
            var activites = new List<Models.Activities>();
            int count = -1;
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(proc, connection) { CommandType = System.Data.CommandType.StoredProcedure })
                {
                    connection.Open();
                    command.Parameters.Add(new SqlParameter("@condition", keyWord));
                    command.Parameters.Add(new SqlParameter("@startPage", startPage));
                    command.Parameters.Add(new SqlParameter("@pageSize", pageSize));

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            if (count == -1)
                            {
                                count = (int)reader["ACsum"];
                            }
                            activites.Add(new Models.Activities
                            {
                                Id = (string)reader["Id"],
                                AcName = (string)reader["Name"],
                                EsFee = (int)reader["EsFee"],
                                Descript = (string)reader["Descript"],
                                StartDate = (DateTime)reader["StartTime"],
                                EndDate = (DateTime)reader["EndTime"],
                                EventId = (string)reader["EventId"],
                                AcStatus = (byte)reader["Status"],
                                Img = (string)reader["Imgs"],
                                Detail = (string)reader["Detail"],
                                Vision = (byte)reader["Vision"],
                            });

                        }
                    }
                }
            }
            return new Tuple<List<Activities>, int>(activites, count);
        }

        public int UpdateAcStatus(string id, int status)
        {
            int count = -1;
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("UpdateACStatus", connection) { CommandType = System.Data.CommandType.StoredProcedure })
                {
                    connection.Open();
                    command.Parameters.Add(new SqlParameter("@id", id));
                    command.Parameters.Add(new SqlParameter("@status", status));
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader == null)
                        {
                            return -1;
                        }
                        else
                        {
                            while (reader.Read()) 
                            {
                                count = (int)reader["RowNum"];
                            }
                            return count;
                        }
                    }
                }
            }
        }
    }
}
