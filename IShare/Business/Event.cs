using System.Collections.Generic;

namespace Business
{
    /// <summary>
    /// 
    /// </summary>
    public class Event
    {
        private DAL.Event dal = new DAL.Event();

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
