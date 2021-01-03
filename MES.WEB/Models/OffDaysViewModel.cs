using MES.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.Web.Models
{
    public class OffDaysViewModel
    {
        public List<TIME_MANAGEMENT_OFFDAYS> OffDaysList { get; set; }
        public TIME_MANAGEMENT_OFFDAYS OffDays { get; set; }
    }
}
