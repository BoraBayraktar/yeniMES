using MES.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.Web.Models
{
    public class CompanyExcellViewModel
    {
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public string HOLDING_NAME { get; set; }
        public HOLDING HOLDING { get; set; }
    }
}
