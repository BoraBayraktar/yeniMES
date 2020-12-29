using MES.Data.Functions;
using MES.Data.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Business
{
    public class LeaveTypeLogic
    {
        ILeaveType _leaveType = new LeaveTypeFunctions();
        public List<LEAVE_TYPE> GetList()
        {
            var leaveTypeList = _leaveType.GetList();
            return leaveTypeList;
        }
        public bool InsertLeaveType(LEAVE_TYPE leaveType)
        {
            var success = _leaveType.InsertLeaveType(leaveType);
            return success;
        }
        public bool UpdateLeaveType(LEAVE_TYPE leaveType)
        {
            var success = _leaveType.UpdateLeaveType(leaveType);
            return success;
        }
        public bool DeleteLeaveType(int Id)
        {
            var success = _leaveType.DeleteLeaveType(Id);
            return success;
        }
        public LEAVE_TYPE GetLeaveType(int id)
        {
            var leaveType = _leaveType.GetLeaveType(id);
            return leaveType;
        }
    }
}
