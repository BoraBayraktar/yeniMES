using MES.Web.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

namespace MES.Web.Models
{
    public class IncidentDetailViewModel
    {
        public IncidentDetailViewModel()
        {
            UserList = new List<SelectListItem>();
            UserGroupList = new List<SelectListItem>();
            IncidentPriorityList = new List<SelectListItem>();
            IncidentStatusList = new List<SelectListItem>();

            IncidentUrgencyList = new List<SelectListItem>();
            IncidentImpactList = new List<SelectListItem>();
            IncidentTypeList = new List<SelectListItem>();
            IncidentSourceList = new List<SelectListItem>();

            CategoryList = new List<SelectListItem>();
            SubCategoryList = new List<SelectListItem>();


            ServiceCatalogList = new List<SelectListItem>();

            ResolutionCodeList = new List<SelectListItem>();


            IncidentHistoryList = new List<INCIDENT_HISTORY>();

        }
        public INCIDENT incident { get; set; }

        public INCIDENT_HISTORY incidentHistory { get; set; }

        public INCIDENT_RESOLUTION incidentResolution { get; set; }


        public List<INCIDENT_HISTORY> IncidentHistoryList { get; set; }

        public List<SelectListItem> UserList { get; set; }
        public List<SelectListItem> UserGroupList { get; set; }

        public List<SelectListItem> IncidentPriorityList { get; set; }

        public List<SelectListItem> IncidentStatusList { get; set; }

        public List<SelectListItem> ServiceCatalogList { get; set; }


        public List<SelectListItem> IncidentUrgencyList { get; set; }
        public List<SelectListItem> IncidentImpactList { get; set; }
        public List<SelectListItem> IncidentTypeList { get; set; }
        public List<SelectListItem> IncidentSourceList { get; set; }

        public List<SelectListItem> CategoryList { get; set; }
        public List<SelectListItem> SubCategoryList { get; set; }

        public List<SelectListItem> ResolutionCodeList { get; set; }


    }
}
