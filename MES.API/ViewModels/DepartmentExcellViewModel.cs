using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.API.ViewModels
{
    public class DepartmentExcellViewModel
    {
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public string COMPANY_NAME { get; set; }
        public int COMPANY_ID { get; set; }
        public virtual COMPANY COMPANY { get; set; }
    }
}
