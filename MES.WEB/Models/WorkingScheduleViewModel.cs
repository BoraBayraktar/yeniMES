using MES.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.Web.Models
{
    public class WorkingScheduleViewModel
    {
        public List<WORKING_SCHEDULE> WorkingScheduleList { get; set; }
        public WORKING_SCHEDULE WorkingSchedule { get; set; }
    }
}
