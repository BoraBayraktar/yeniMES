﻿using MES.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.Web.Models
{
    public class HoldingViewModel
    {
        public List<HOLDING> HoldingList { get; set; }
        public HOLDING holding { get; set; }
    }
}
