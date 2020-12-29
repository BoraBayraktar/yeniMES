using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Interfaces
{
    public interface IWorkingSchedule
    {
        List<WORKING_SCHEDULE> GetList();
        WORKING_SCHEDULE GetWorkingSchedule(int id);
        bool InsertWorkingSchedule(WORKING_SCHEDULE workingSchedule);
        bool UpdateWorkingSchedule(WORKING_SCHEDULE workingSchedule);
        bool DeleteWorkingSchedule(int Id);
    }
}
