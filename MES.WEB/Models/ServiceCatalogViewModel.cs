using MES.Web.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.Web.Models
{
    public class ServiceCatalogViewModel
    {
        public ServiceCatalogViewModel()
        {
            ParameterSelectList = new List<SelectListItem>();
            ParameterOpStatusList = new List<SelectListItem>();
            UserManagerITList = new List<SelectListItem>();
            UserManagerBusinessList = new List<SelectListItem>();
        }
        public SERVICECATALOG servicecatalog { get; set; }
        public List<SERVICECATALOG> serviceCatalogList { get; set; }
        public List<SelectListItem> ParameterSelectList { get; set; }
        public List<SelectListItem> ParameterOpStatusList { get; set; }
        public List<SelectListItem> UserManagerITList { get; set; }
        public List<SelectListItem> UserManagerBusinessList { get; set; }
    }
}
