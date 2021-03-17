using DAL;
using Models;
using System;
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

        public Models.ResResult<Models.Activities> ListActivities()
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
            return dal.AddActivity(239);
        }

        public AcPageResult ListActivitiesByPage(int startPage, int pageSize)
        {
            var resutlt = dal.ListActivitiesByPage(startPage, pageSize);
            int totalAc = resutlt.Item2;
            if (totalAc != -1 ) 
            {
                int totalP = totalAc % pageSize == 0 ? totalAc / pageSize : totalAc / pageSize + 1;
                return new AcPageResult 
                        {
                            PageNum=startPage, 
                            totalNum = totalAc, 
                            totalPages = totalP, 
                            PageSize = pageSize, 
                            Activities = resutlt.Item1
                        };
            }
            else
            {
                return null;
            }
        }

        public int UpdateAcStatus(string id, int status)
        {
            //int newStatus = status == 0 ? 1 : 0;
            return dal.UpdateAcStatus(id, status);
        }
    }
}
