using MES.DB.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.API.ViewModels
{
    public class TimeManagementViewModel
    {
        public TimeManagementViewModel()
        {
            WorkDaysList = new List<SelectListItem>();
            BusinessHoursList = new List<SelectListItem>();
            TimezoneList = new List<SelectListItem>();
            PostOffDays = new List<TIME_MANAGEMENT_OFFDAYS>();

        }
        public List<TIME_MANAGEMENT> TimeManagementList { get; set; }
        public List<SelectListItem> WorkDaysList { get; set; }
        public List<SelectListItem> BusinessHoursList { get; set; }
        public List<SelectListItem> TimezoneList { get; set; }

        public List<TIME_MANAGEMENT_OFFDAYS> OffDaysList { get; set; }
        public TIME_MANAGEMENT_OFFDAYS OffDays { get; set; }

        public List<TIME_MANAGEMENT_OFFDAYS> PostOffDays { get; set; }


        public string[] SelectedWorkDays { get; set; }
        public string[] SelectedBusinessHours { get; set; }


        public int ID { get; set; }
        public string CALENDAR_NAME { get; set; }
        public string CALENDAR_DAYS { get; set; }
        public string BUSINESS_HOURS { get; set; }
        public int? TIMEZONE_ID { get; set; }
        public bool ISACTIVE { get; set; }
    }
}
