using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IEventDal
    {
        IEnumerable<Models.Event> ListEvents();
        IEnumerable<Models.Event> ListEventsById(int id);
    }
}
