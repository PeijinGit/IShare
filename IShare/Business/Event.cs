using DAL;
using System.Collections.Generic;

namespace Business
{
    public class Event :IEventBus
    {
        // private DAL.Event dal = new DAL.Event();
        private readonly IEventDal _eventDal;
        public Event(IEventDal eventDal) 
        {
            _eventDal = eventDal;
        }

        public IEnumerable<Models.Event> ListEvents()
        {
            return _eventDal.ListEvents();
        }

        public IEnumerable<Models.Event> ListEventsById(int id)
        {
            return _eventDal.ListEventsById( id);
        }
    }
}
