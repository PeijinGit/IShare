using System.Collections.Generic;
using Business;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [EnableCors("any")]
    [ApiController]
    [Route("[controller]/[action]")]
    public class EventsController : ControllerBase
    {
        IEventBLL business;

        public EventsController(IEventBLL eventBLL) 
        {
            business = eventBLL;
        }

        [HttpGet]
        public IEnumerable<Models.Event> GetAllEvents()
        {
            return business.ListEvents();
        }

        [HttpGet]
        public IEnumerable<Models.Event> ListEventsById(int id)
        {

            return business.ListEventsById(id);
        }

        public string Welcome() 
        {
            
            return "Program start Welcome! "+ DAL.Event.connectionString;
        }
    }
}
