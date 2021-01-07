using MES.Web.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Web.Interfaces
{
    public interface IHolding
    {
        List<HOLDING> GetList();
        HOLDING GetHolding(int id);
        bool InsertHolding(HOLDING holding);
        bool InsertHolding(List<HOLDING> holding);
        bool UpdateHolding(HOLDING holding);
        bool DeleteHolding(int Id);
    }
}
