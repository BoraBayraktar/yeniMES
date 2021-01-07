using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.API.ViewModels
{
    public class AuthViewModel
    {
        public List<MenuViewModel> MenuList { get; set; }
        public List<UserTypeViewModel> UserTypeList { get; set; }
    }
}
