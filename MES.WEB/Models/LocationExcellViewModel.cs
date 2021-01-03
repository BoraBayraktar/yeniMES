using MES.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.Web.Models
{
    public class LocationExcellViewModel
    {
        public string NAME { get; set; }
        public int CITY_ID { get; set; }
        public string CITY_NAME { get; set; }
        public  CITY CITY { get; set; }
    }
}
