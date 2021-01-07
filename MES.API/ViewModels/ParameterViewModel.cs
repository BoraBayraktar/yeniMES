using MES.DB.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.API.ViewModels
{
    public class ParameterViewModel
    {
        public ParameterViewModel()
        {
            MainProcessSelectList = new List<SelectListItem>();
            ParameterTypeSelectList = new List<SelectListItem>();
            ParameterSelectList = new List<SelectListItem>();
        }
        public List<PARAMETER> ParameterList { get; set; }
        public PARAMETER parameter { get; set; }
        public List<SelectListItem> MainProcessSelectList { get; set; }
        public List<SelectListItem> ParameterTypeSelectList { get; set; }
        public List<SelectListItem> ParameterSelectList { get; set; }

    }
}
