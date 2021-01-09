using System.Collections.Generic;
using Business;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EventsController : BaseController
    {
        public EventsController(IEventBus eventBus) : base(eventBus) 
        {
            
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
