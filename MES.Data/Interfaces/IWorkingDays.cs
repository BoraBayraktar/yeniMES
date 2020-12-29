using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Interfaces
{
    public interface IWorkingDays
    {
        List<WORKING_DAYS> GetList();
        WORKING_DAYS GetWorkingDays(int id);
        bool InsertWorkingDays(WORKING_DAYS wd);
        bool UpdateWorkingDays(WORKING_DAYS wd);
        bool DeleteWorkingDays(int Id);
    }
}
