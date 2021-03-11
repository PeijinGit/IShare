using DAL;
using Models;
using System.Collections.Generic;

namespace Business
{
    public class Event : IEventBLL
    {
        IEventDAL dal;

        public Event(IEventDAL eventDAL) 
        {
            dal = eventDAL;
        }

        public IEnumerable<Models.Event> ListEvents()
        {
            return dal.ListEvents();
        }

        public IEnumerable<Models.Event> ListEventsById(int id)
        {
            return dal.ListEventsById( id);
        }

        public Models.Event AddEvent(Models.Event newEvent) 
        {
            return dal.AddEvent(newEvent.UserId,newEvent.EventName);
        }

        public Models.Event UpdateEvent(Models.Event newEvent)
        {
            return dal.UpdateEvent(newEvent.Id, newEvent.EventName);
        }

        Models.ResResult<Models.Activities> IEventBLL.ListActivities()
        {
            var activities = dal.ListActivities();
            if (activities != null)
            {
                return new Models.ResResult<Models.Activities> 
                {   
                    Status = 1, 
                    ResultData = (List<Activities>)activities, 
                    Msg = "Success" 
                };
            }
            else 
            {
                return new Models.ResResult<Models.Activities> 
                { 
                    Status = -1, 
                    ResultData = (List<Activities>)activities, 
                    Msg = "Fail" 
                };
            }
            
        }

        public int AddActivity()
        {
            return dal.AddActivity();
        }
    }
}
