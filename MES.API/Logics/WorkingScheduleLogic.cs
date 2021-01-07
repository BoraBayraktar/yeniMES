using MES.Data.Functions;
using MES.Data.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Logics
{
    public class WorkingScheduleLogic
    {
        IWorkingSchedule _ws = new WorkingScheduleFunctions();
        public List<WORKING_SCHEDULE> GetList()
        {
            var wsList = _ws.GetList();
            return wsList;
        }
        public bool InsertWorkingSchedule(WORKING_SCHEDULE ws)
        {
            var success = _ws.InsertWorkingSchedule(ws);
            return success;
        }
        public bool UpdateWorkingSchedule(WORKING_SCHEDULE ws)
        {
            var success = _ws.UpdateWorkingSchedule(ws);
            return success;
        }
        public bool DeleteWorkingSchedule(int Id)
        {
            var success = _ws.DeleteWorkingSchedule(Id);
            return success;
        }
        public WORKING_SCHEDULE GetWorkingSchedule(int id)
        {
            var ws = _ws.GetWorkingSchedule(id);
            return ws;
        }
    }
}
