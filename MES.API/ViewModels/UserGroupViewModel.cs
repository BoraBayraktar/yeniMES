using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.API.ViewModels
{
    public class UserGroupViewModel
    {
        public List<USER_GROUP> UserGroupList { get; set; }
        public USER_GROUP userGroup { get; set; }
    }
}
