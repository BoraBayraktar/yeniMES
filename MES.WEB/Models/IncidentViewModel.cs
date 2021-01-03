using MES.Web.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.Web.Models
{
    public class IncidentViewModel
    {
        public IncidentViewModel()
        {
            UserList = new List<SelectListItem>();
            UserGroupList = new List<SelectListItem>();
            IncidentPriorityList = new List<SelectListItem>();
            IncidentStatusList = new List<SelectListItem>();
            DepartmentList = new List<SelectListItem>();
            TitleList = new List<SelectListItem>();
        }
        public INCIDENT incident { get; set; }
        public INCIDENT_HISTORY incidentHistory { get; set; }
        public List<INCIDENT> IncidentList { get; set; }
        public List<SelectListItem> UserList { get; set; }
        public List<SelectListItem> UserGroupList { get; set; }
        public List<SelectListItem> IncidentPriorityList { get; set; }
        public List<SelectListItem> IncidentStatusList { get; set; }
        public List<SelectListItem> DepartmentList { get; set; }
        public List<SelectListItem> TitleList { get; set; }
        public int SumUnRelased { get; set; }
        public int SumOverdue { get; set; }
        public int SumDuetoday { get; set; }
        public int SumOpen { get; set; }
        public int SumOnhold { get; set; }
        public int SumUnassigned { get; set; }
    }
}
