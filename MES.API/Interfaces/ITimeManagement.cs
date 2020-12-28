using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.API.Interfaces
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
