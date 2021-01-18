using MES.Data.Logics;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.API.Business
{
    
    public class OrganizationBusiness
    {

        HoldingLogic holdingLogic = new HoldingLogic();
        public List<HOLDING> HoldingList()
        {
            return holdingLogic.GetList();
        }
        public bool InsertHolding(HOLDING holding)
        {
            return holdingLogic.InsertHolding(holding);
        }

    }
}
