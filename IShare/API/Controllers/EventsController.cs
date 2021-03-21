using System.Collections.Generic;
using API.Filters;
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
            Models.Event resultEvent = business.AddEvent(newEvent);
            if (resultEvent == null)
            {
                return new Models.ResResult<Models.Event> { Status = -1, Msg = "Add Fail" };
            }
            else
            {
                Models.ResResult<Models.Event> resResult = new Models.ResResult<Models.Event>();
                resResult.Status = 1;
                resResult.ResultData = new List<Models.Event>() { resultEvent };
                resResult.Msg = "Add Success";

                return resResult;
            }
        }

        [HttpPost]
        public Models.ResResult<Models.Event> UpdateEvent(Models.Event newEvent)
         {
            Models.Event resutEvent = business.UpdateEvent(newEvent);
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

        /// <summary>
        /// Activities pagenation function
        /// </summary>
        /// <param name="startPage">AKA current page</param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        public Models.ResResult<Models.AcPageResult> ListActivitiesByPage(int startPage, int pageSize)
        {
            Models.AcPageResult acPageResult = business.ListActivitiesByPage( startPage, pageSize);
            if (acPageResult != null)
            {
                Models.ResResult<Models.AcPageResult> resResult = new Models.ResResult<Models.AcPageResult>();
                resResult.Status = 1;
                resResult.ResultData = new List<Models.AcPageResult>() { acPageResult };
                resResult.Msg = "Request Success";

                return resResult;
            }
            else 
            {
                return new Models.ResResult<Models.AcPageResult> { Status = -1, Msg = "Request Fail" };
            }

        }

        /// <summary>
        /// Activities pagenation function
        /// </summary>
        /// <param name="startPage">AKA current page</param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        public Models.ResResult<Models.AcPageResult> SearchByCondition(int startPage, int pageSize,string keyWord, string criteria)
        {
            Models.AcPageResult acPageResult = business.SearchByCondition(startPage, pageSize, keyWord, criteria);
            if (acPageResult != null)
            {
                Models.ResResult<Models.AcPageResult> resResult = new Models.ResResult<Models.AcPageResult>();
                resResult.Status = 1;
                resResult.ResultData = new List<Models.AcPageResult>() { acPageResult };
                resResult.Msg = "Request Success";

                return resResult;
            }
            else
            {
                return new Models.ResResult<Models.AcPageResult> { Status = -1, Msg = "Request Fail" };
            }

        }


        [HttpPost]
        public Models.ResResult<int> UpdateAcStatus([FromForm] string id, [FromForm] int newStatus) 
        {
            int upResult = business.UpdateAcStatus(id, newStatus);
            if (upResult > 0)
            {
                return new Models.ResResult<int> { Status = 1, Msg = "Update Sucess" };
            }
            else 
            {
                return new Models.ResResult<int> { Status = -1, Msg = "Update Fail" };
            }
        }

        public string Welcome() 
        {
            return "Program start Welcome!";
        }
    }
}
