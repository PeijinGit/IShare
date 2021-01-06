using System.Collections.Generic;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return new List<Event>
            {
                new Event{ Id = 42 , Name = "Friday Party" },
                new Event{ Id = 99 , Name = "New Year meeting" }
            };
        }
    }
}
