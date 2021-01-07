using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly Business.Event bussiness = new Business.Event();

        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return bussiness.ListEvents();
        }
    }
}
