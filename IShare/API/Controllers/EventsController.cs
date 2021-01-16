using System.Collections.Generic;
using Business;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [EnableCors("any")]
    [ApiController]
    [Route("[controller]/[action]")]
    public class EventsController 
    {
        public IEventBus _eventBus;
        public EventsController(IEventBus eventBus) 
        {
            _eventBus = eventBus;
        }

        [HttpGet]
        public IEnumerable<Models.Event> GetAllEvents()
        {
            return _eventBus.ListEvents();
        }

        [HttpGet]
        public IEnumerable<Models.Event> ListEventsById(int id)
        {

            return _eventBus.ListEventsById(id);
        }

        public string Welcome() 
        {
            return "Program start Welcome!";
        }
    }
}
