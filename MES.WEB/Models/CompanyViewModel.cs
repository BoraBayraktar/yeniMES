using MES.Web.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.Web.Models
{
    public class CompanyViewModel
    {
        public List<COMPANY> CompanyList { get; set; }
        public COMPANY company { get; set; }
        public List<SelectListItem> HoldingSelectList { get; set; }
    }
}
