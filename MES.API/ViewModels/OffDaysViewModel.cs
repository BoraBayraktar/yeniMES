using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.API.ViewModels
{
    public class OffDaysViewModel
    {
        public List<TIME_MANAGEMENT_OFFDAYS> OffDaysList { get; set; }
        public TIME_MANAGEMENT_OFFDAYS OffDays { get; set; }
    }
}
