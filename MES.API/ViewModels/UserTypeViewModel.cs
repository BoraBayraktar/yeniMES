using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.API.ViewModels
{
    public class UserTypeViewModel
    {
        public UserTypeViewModel()
        {
            this.USERTYPE_MENUS = new List<UserTypeMenuViewModel>();
        }
        public int USER_TYPE_ID { get; set; }
        public string CODE { get; set; }
        public string NAME { get; set; }
        public List<UserTypeMenuViewModel> USERTYPE_MENUS { get; set; }
    }
}
