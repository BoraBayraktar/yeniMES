using MES.Web.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Web.Interfaces
{
    public interface ITimeManagement
    {
        List<TIME_MANAGEMENT> GetList();
        TIME_MANAGEMENT GetTimeManagement(int id);
        bool InsertTimeManagement(TIME_MANAGEMENT timeManagement);
        bool UpdateTimeManagement(TIME_MANAGEMENT timeManagement);
        bool DeleteTimeManagement(int Id);
        List<TIMEZONE> GetTimezoneList();
    }
}
