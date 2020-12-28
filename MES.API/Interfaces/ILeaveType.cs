using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.API.Interfaces
{
    public interface ILeaveType
    {
        List<LEAVE_TYPE> GetList();
        LEAVE_TYPE GetLeaveType(int id);
        bool InsertLeaveType(LEAVE_TYPE leave);
        bool UpdateLeaveType(LEAVE_TYPE leave);
        bool DeleteLeaveType(int Id);
    }
}
