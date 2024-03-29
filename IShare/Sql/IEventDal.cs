﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IEventDAL
    {
        IEnumerable<Models.Event> ListEventsById(int id);
        IEnumerable<Models.Event> ListEvents();
        Models.Event AddEvent(int creatorId, string eventName);
        Models.Event UpdateEvent(string id, string eventName);
        int AddActivity(int i);
        int UpdateAcStatus(string id,int status);
        Tuple<List<Models.Activities>, int> ListActivitiesByPage(int startPage,int pageSize);
        Tuple<List<Models.Activities>, int> SearchByCondition(int startPage, int pageSize, string keyWord, string proc);
    }
}
