using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Interfaces
{
    public interface ILeave
    {
        List<LEAVE> GetList();
        LEAVE GetLeave(int id);
        bool InsertLeave(LEAVE leave);
        bool UpdateLeave(LEAVE leave);
        bool DeleteLeave(int Id);
    }
}
