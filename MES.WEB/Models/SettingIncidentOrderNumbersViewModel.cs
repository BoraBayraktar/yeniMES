using MES.Web.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.Web.Models
{
    public class SettingIncidentOrderNumbersViewModel
    {
        public SettingIncidentOrderNumbersViewModel()
        {
            mainProcessList = new List<SelectListItem>();
        }
        public List<ORDER_NUMBERS> orderNumbersList { get; set; }
        public ORDER_NUMBERS orderNumbers { get; set; }        
        public List<SelectListItem> mainProcessList { get; set; }
    }
}
