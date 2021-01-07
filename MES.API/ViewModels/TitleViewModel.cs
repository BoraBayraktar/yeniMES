using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.API.ViewModels
{
    public class TitleViewModel
    {
        public List<TITLE> TitleList { get; set; }
        public TITLE title { get; set; }
    }
}
