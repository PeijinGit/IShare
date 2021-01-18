using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IEventDAL
    {
        IEnumerable<Models.Event> ListEventsById(int id);
        IEnumerable<Models.Event> ListEvents();
    }
}
