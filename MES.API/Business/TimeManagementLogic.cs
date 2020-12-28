using MES.API.Functions;
using MES.API.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.API.Business
{
    public class TimeManagementLogic
    {
        ITimeManagement _tm = new TimeManagementFunctions();
        public List<TIME_MANAGEMENT> GetList()
        {
            var tmList = _tm.GetList();
            return tmList;
        }
        public bool InsertTimeManagement(TIME_MANAGEMENT tm)
        {
            var success = _tm.InsertTimeManagement(tm);
            return success;
        }
        public bool UpdateTimeManagement(TIME_MANAGEMENT tm)
        {
            var success = _tm.UpdateTimeManagement(tm);
            return success;
        }
        public bool DeleteTimeManagement(int Id)
        {
            var success = _tm.DeleteTimeManagement(Id);
            return success;
        }
        public TIME_MANAGEMENT GetTimeManagement(int id)
        {
            var tm = _tm.GetTimeManagement(id);
            return tm;
        }
        public List<TIMEZONE> GetTimezoneList()
        {
            var timezoneList = _tm.GetTimezoneList();
            return timezoneList;
        }
    }
}
