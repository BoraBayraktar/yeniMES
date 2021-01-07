using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.API.ViewModels
{
	public class LdapUserViewModel
	{
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string NAME { get; set; }
        public string SURNAME { get; set; }
        public string EMAIL { get; set; }
        public string DESCRIPTION { get; set; }
		public bool ISLDAP { get; set; }
		public int? DEPARTMENT_ID { get; set; }
        public int? TITLE_ID { get; set; }
        public int? USER_TYPE_ID { get; set; }
        public int? LOCATION_ID { get; set; }
        public bool USER_ISACTIVE { get; set; }
    }
}
