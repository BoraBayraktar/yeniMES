using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.API.Interfaces
{
    public interface ITimeManagementOffDays
    {
        List<TIME_MANAGEMENT_OFFDAYS> GetList();
        TIME_MANAGEMENT_OFFDAYS GetOffDays(int id);
        bool InsertOffDays(TIME_MANAGEMENT_OFFDAYS offDays);
        bool UpdateOffDays(TIME_MANAGEMENT_OFFDAYS offDays);
        bool DeleteOffDays(int Id);
        List<TIME_MANAGEMENT_OFFDAYS> GetOffDaysListByTmId(int timeManagementId);

    }
}
