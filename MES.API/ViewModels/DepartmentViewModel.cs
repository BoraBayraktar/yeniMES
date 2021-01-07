using MES.DB.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.API.ViewModels
{
    public class DepartmentViewModel
    {
        public List<DEPARTMENT> DepartmentList { get; set; }
        public DEPARTMENT department { get; set; }
        public List<SelectListItem> CompanySelectList { get; set; }
    }
}
