using DAL;
using System.Collections.Generic;

namespace Business
{
    public class Event : IEventBLL
    {
        IEventDAL dal;

        public Event(IEventDAL eventDAL) 
        {
            dal = eventDAL;
        }

        public IEnumerable<Models.Event> ListEvents()
        {
            return dal.ListEvents();
        }

        public IEnumerable<Models.Event> ListEventsById(int id)
        {
            return dal.ListEventsById( id);
        }
    }
}
