using MES.API.Functions;
using MES.API.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.API.Business
{
    public class WorkingDaysLogic
    {
        IWorkingDays _wd = new WorkingDaysFunctions();
        public List<WORKING_DAYS> GetList()
        {
            var wdList = _wd.GetList();
            return wdList;
        }
        public bool InsertWorkingDays(WORKING_DAYS wd)
        {
            var success = _wd.InsertWorkingDays(wd);
            return success;
        }
        public bool UpdateWorkingDays(WORKING_DAYS wd)
        {
            var success = _wd.UpdateWorkingDays(wd);
            return success;
        }
        public bool DeleteWorkingDays(int Id)
        {
            var success = _wd.DeleteWorkingDays(Id);
            return success;
        }
        public WORKING_DAYS GetWorkingDays(int id)
        {
            var wd = _wd.GetWorkingDays(id);
            return wd;
        }
    }
}
