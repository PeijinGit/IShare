using System;
using System.Collections.Generic;
using System.Text;


namespace Business
{
    public interface IEventBus
    {
        IEnumerable<Models.Event> ListEvents();

        IEnumerable<Models.Event> ListEventsById(int id);

        
    }
}
