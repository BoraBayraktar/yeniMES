using MES.API.Functions;
using MES.API.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.API.Business
{
    public class TimeManagementOffDaysLogic
    {
        ITimeManagementOffDays _offDays = new TimeManagementOffDaysFunctions();
        public List<TIME_MANAGEMENT_OFFDAYS> GetList()
        {
            var offDaysList = _offDays.GetList();
            return offDaysList;
        }
        public bool InsertOffDays(TIME_MANAGEMENT_OFFDAYS offDays)
        {
            var success = _offDays.InsertOffDays(offDays);
            return success;
        }
        public bool UpdateOffDays(TIME_MANAGEMENT_OFFDAYS offDays)
        {
            var success = _offDays.UpdateOffDays(offDays);
            return success;
        }
        public bool DeleteOffDays(int Id)
        {
            var success = _offDays.DeleteOffDays(Id);
            return success;
        }
        public TIME_MANAGEMENT_OFFDAYS GetOffDays(int id)
        {
            var offDays = _offDays.GetOffDays(id);
            return offDays;
        }

        public List<TIME_MANAGEMENT_OFFDAYS> GetOffDaysListByTmId(int timeManagementId)
        {
            var offDaysList = _offDays.GetOffDaysListByTmId(timeManagementId);
            return offDaysList;
        }
    }
}
