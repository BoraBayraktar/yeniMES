using MES.DB.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.API.ViewModels
{
    public class LocationViewModel
    {
        public List<LOCATION> LocationList { get; set; }
        public LOCATION location { get; set; }
        public List<SelectListItem> CitySelectList { get; set; }
    }
}
