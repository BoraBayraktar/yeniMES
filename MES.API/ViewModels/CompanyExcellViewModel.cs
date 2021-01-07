using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.API.ViewModels
{
    public class CompanyExcellViewModel
    {
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public string HOLDING_NAME { get; set; }
        public HOLDING HOLDING { get; set; }
    }
}
