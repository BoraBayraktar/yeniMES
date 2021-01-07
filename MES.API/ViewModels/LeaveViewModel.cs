using MES.DB.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.API.ViewModels
{
    public class LeaveViewModel
    {
        public LeaveViewModel()
        {
            LeaveTypeList = new List<SelectListItem>();
            UserList = new List<SelectListItem>();

        }
        public List<LEAVE> LeaveList { get; set; }
        public LEAVE leave { get; set; }
        public List<SelectListItem> LeaveTypeList { get; set; }
        public List<SelectListItem> UserList { get; set; }

    }

    public class LEAVE_DTO : BASE
    {
        public int LEAVE_ID { get; set; }
        public DateTime START_DATE { get; set; }
        public DateTime END_DATE { get; set; }
        public string DESCRIPTION { get; set; }
        public int LEAVE_TYPE_ID { get; set; }
        public int TOTAL_DAY { get; set; }
        public int USER_ID { get; set; }
        public LEAVE_TYPE LEAVE_TYPE { get; set; }
        public USER USER { get; set; }

    }
}
