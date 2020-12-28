using MES.API.Functions;
using MES.API.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.API.Business
{
    public class HoldingLogic
    {
        IHolding _holding = new HoldingFunctions();
        public List<HOLDING> GetList()
        {
            var holdingList = _holding.GetList();
            return holdingList;
        }
        public bool InsertHolding(HOLDING holding)
        {
            var success = _holding.InsertHolding(holding);
            return success;
        }  
        public bool InsertHolding(List<HOLDING> holding)
        {
            var success = _holding.InsertHolding(holding);
            return success;
        }
        public bool UpdateHolding(HOLDING holding)
        {
            var success = _holding.UpdateHolding(holding);
            return success;
        }
        public bool DeleteHolding(int Id)
        {
            var success = _holding.DeleteHolding(Id);
            return success;
        }
        public HOLDING GetHolding(int id)
        {
            var holding = _holding.GetHolding(id);
            return holding;
        }
    }
}
