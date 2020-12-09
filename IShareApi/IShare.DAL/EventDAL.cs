using IShare.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace IShare.DAL
{
    public class Event
    {
        public static string constr = "Data Source=DESKTOP-FG071FQ;Initial Catalog=IShareData;Integrated Security=True";
        SqlHelper sh = new SqlHelper(constr);
        public IEnumerable<Events> GetEventsById(int id)
        {
            List<Events> events = new List<Events>();
            DataTable dt = sh.ExecuteTableProcedure("ShowEventByUser", new SqlParameter("id", id));
            foreach (DataRow dr in dt.Rows)
            {
                events.Add(ToEventModel(dr));
            }
            return events;
           
        }

        private Events ToEventModel(DataRow dr)
        {
            Events md = new Events();
            md.Id = (int)dr["Id"];
            md.EventName = dr["EventName"].ToString();
            return md;
        }
    }
}
