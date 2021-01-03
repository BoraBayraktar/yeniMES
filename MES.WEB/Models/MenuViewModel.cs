using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.Web.Models
{
    public class MenuViewModel
    {
        public MenuViewModel()
        {
            UserTypeMenu = new List<UserTypeMenuViewModel>();
        }
        public int MENU_ID { get; set; }
        public string MENU_NAME { get; set; }
        public string CONTROLLER { get; set; }
        public string ACTION { get; set; }
        public string MENU_LINK { get; set; }
        public string MENU_ICON { get; set; }
        public string PAGE_TITLE { get; set; }
        public string PAGE_SUBTITLE { get; set; }
        public bool MENU_SHOW { get; set; }
        public int? MENU_SORT { get; set; }
        public int? TOPMENU_ID { get; set; }
        public List<UserTypeMenuViewModel> UserTypeMenu { get; set; }
        public string RealPath { get; set; }
        public List<MenuViewModel> SUBMENULIST { get; set; }
    }
}
