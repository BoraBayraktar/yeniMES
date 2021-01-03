using MES.Web.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.Web.Models
{
    public class SlaViewModel
    {
        public SlaViewModel()
        {
            MainProcessList = new List<SelectListItem>();
            ImportanceLevelList = new List<SelectListItem>();
            WorkingScheduleList = new List<SelectListItem>();
            SlaEvents = new List<SelectListItem>();
            SlaEventsList = new List<SelectListItem>();
            SlaAreaList = new List<SelectListItem>();
            prmStatusList = new List<SelectListItem>();
            PostSlaEvent = new List<SLA_EVENTS>();
            PostSlaArea = new List<SLA_AREA>();
            ServiceCatalogList = new List<SelectListItem>();
        }
        public SLA sla { get; set; }
        public List<SLA> slaList { get; set; }
        public List<SelectListItem> MainProcessList { get; set; }
        public List<SelectListItem> ImportanceLevelList { get; set; }
        public List<SelectListItem> WorkingScheduleList { get; set; }

        public SLA_EVENTS slaEvents { get; set; }
        public List<SLA_EVENTS> slaEventsList { get; set; }
        public List<SelectListItem> SlaEvents { get; set; }
        public List<SelectListItem> SlaEventsList { get; set; }
        public List<SelectListItem> prmStatusList { get; set; }
        public List<SLA_EVENTS> PostSlaEvent { get; set; }

        public SLA_AREA slaArea { get; set; }
        public List<SLA_AREA> slaAreaList { get; set; }
        public List<SelectListItem> SlaAreaList { get; set; }
        public List<SLA_AREA> PostSlaArea { get; set; }
        public List<SelectListItem> ServiceCatalogList { get; set; }
        public string[] SelectedCustomers { get; set; }
        public string[] SelectedServices { get; set; }
        public string[] SelectedAssets { get; set; }
    }
}
