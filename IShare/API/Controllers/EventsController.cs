using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EventsController : ControllerBase
    {
        private readonly Business.Event bussiness = new Business.Event();

        [HttpGet]
        public IEnumerable<Event> GetAllEvents()
        {
            return bussiness.ListEvents();
        }

        [HttpGet]
        public IEnumerable<Event> ListEventsById(int id)
        {

            return bussiness.ListEventsById(id);
        }

        public string Welcome() 
        {
            return "Program start Welcome!";
        }
    }
}
