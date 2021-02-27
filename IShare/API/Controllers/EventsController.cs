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

        [HttpPost]
        public Models.ResResult<Models.Event> AddEvent(Models.Event newEvent)
        {
            Models.Event resutEvent = business.AddEvent(newEvent);
            if (resutEvent == null)
            {
                return new Models.ResResult<Models.Event> { Status = -1, Msg = "Add Fail" };
            }
            else
            {
                Models.ResResult<Models.Event> resResult = new Models.ResResult<Models.Event>();
                resResult.Status = 1;
                resResult.ResultData = new List<Models.Event>() { resutEvent };
                resResult.Msg = "Add Success";

                return resResult;
            }
        }

        public string Welcome() 
        {
            return "Program start Welcome!";
        }
    }
}
