using MES.DB.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.API.ViewModels
{
    public class EmailTemplateViewModel
    {
        public EmailTemplateViewModel()
        {
            UserList = new List<SelectListItem>();
            UserGroupList = new List<SelectListItem>();
            ParameterList = new List<SelectListItem>();
            MainProcessList = new List<SelectListItem>();
            MainProcessStatusList = new List<SelectListItem>();

        }
        public List<EMAIL_TEMPLATE> EmailTemplateList { get; set; }

        public EMAIL_TEMPLATE EmailTemplate { get; set; }
        public string[] SelectedRecipients { get; set; }
        public string[] SelectedUsers { get; set; }
        public string[] SelectedGroups { get; set; }

        public List<SelectListItem> UserList { get; set; }
        public List<SelectListItem> UserGroupList { get; set; }
        public List<SelectListItem> ParameterList { get; set; }

        public List<SelectListItem> MainProcessList { get; set; }
        public List<SelectListItem> MainProcessStatusList { get; set; }

    }
}
