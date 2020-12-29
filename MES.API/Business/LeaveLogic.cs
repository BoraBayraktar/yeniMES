using MES.Data.Functions;
using MES.Data.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Business
{
    public class LeaveLogic
    {
        ILeave _leave = new LeaveFunctions();
        public List<LEAVE> GetList()
        {
            var leaveList = _leave.GetList();
            return leaveList;
        }
        public bool InsertLeave(LEAVE leave)
        {
            var success = _leave.InsertLeave(leave);
            return success;
        }
        public bool UpdateLeave(LEAVE leave)
        {
            var success = _leave.UpdateLeave(leave);
            return success;
        }
        public bool DeleteLeave(int Id)
        {
            var success = _leave.DeleteLeave(Id);
            return success;
        }
        public LEAVE GetLeave(int id)
        {
            var leave = _leave.GetLeave(id);
            return leave;
        }
    }
}
