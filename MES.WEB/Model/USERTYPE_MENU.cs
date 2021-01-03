using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Web.Model
{
    public class USERTYPE_MENU :BASE
    {
        public int MenuId { get; set; }
        public int UserTypeId { get; set; }
        public virtual USER_TYPE USER_TYPE { get; set; }
        public virtual MENU MENU { get; set; }
        public bool Checked { get; set; }
      
    }
}
