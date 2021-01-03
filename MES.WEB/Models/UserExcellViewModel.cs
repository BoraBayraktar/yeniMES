using MES.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.Web.Models
{
    public class UserExcellViewModel
    {
        public string USERNAME { get; set; }
        public string NAME { get; set; }
        public string SURNAME { get; set; }
        public string EMAIL { get; set; }
        public string DEPARTMENT_NAME { get; set; }
        public string TITLE_NAME { get; set; }
        public string USER_TYPE_NAME { get; set; }
        public string LOCATION_NAME { get; set; }
    }
}
