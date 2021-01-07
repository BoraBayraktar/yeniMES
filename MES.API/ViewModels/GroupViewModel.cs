using MES.DB.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.API.ViewModels
{
    public class GroupViewModel
    {
        public GroupViewModel()
        {
            groupManagerList = new List<SelectListItem>();
            groupTypeList = new List<SelectListItem>();
            BusinessHourList = new List<SelectListItem>();
            groupExpertList = new List<SelectListItem>();
            PostExpert = new List<GROUP_EXPERT>();
        }
        public GROUP group { get; set; }
        public List<GROUP> groupList { get; set; }
        public List<SelectListItem> groupManagerList { get; set; }
        public List<SelectListItem> groupTypeList { get; set; }
        public List<SelectListItem> BusinessHourList { get; set; }
        public List<SelectListItem> groupExpertList { get; set; }
        public string[] SelectedBusinessHour { get; set; }
        public List<GROUP_EXPERT> PostExpert { get; set; }
        public List<GROUP_EXPERT> ExpertList { get; set; }
        public GROUP_EXPERT Expert { get; set; }
    }
}
