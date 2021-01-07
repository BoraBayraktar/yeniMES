using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.API.ViewModels
{
    public class HoldingViewModel
    {
        public List<HOLDING> HoldingList { get; set; }
        public HOLDING holding { get; set; }
    }
}
