﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public interface IEventBLL
    {
        IEnumerable<Models.Event> ListEvents();
        IEnumerable<Models.Event> ListEventsById(int id);
        Models.Event AddEvent(Models.Event newEvent);
        Models.Event UpdateEvent(Models.Event newEvent);
        int AddActivity();
        Models.AcPageResult ListActivitiesByPage(int startPage, int pageSize);
        Models.AcPageResult SearchByCondition(int startPage, int pageSize, string keyWord, string proc);
        int UpdateAcStatus(string id, int status);
    }
}
