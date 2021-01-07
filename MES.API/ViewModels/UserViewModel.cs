using MES.DB.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.API.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            DepartmentSelectList = new List<SelectListItem>();
            TitleSelectList = new List<SelectListItem>();
            LocationSelectList = new List<SelectListItem>();
            UserGroupSelectList = new List<SelectListItem>();
            UserTypeSelectList = new List<SelectListItem>();
        }
        public string Username { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }

        public string NewPassword { get; set; }
        public string ReNewPassword { get; set; }

        public List<USER> UserList { get; set; }
        public USER user { get; set; }
        public List<SelectListItem> DepartmentSelectList { get; set; }
        public List<SelectListItem> TitleSelectList { get; set; }
        public List<SelectListItem> LocationSelectList { get; set; }
        public List<SelectListItem> UserGroupSelectList { get; set; }
        public List<SelectListItem> UserTypeSelectList { get; set; }
    }
}
