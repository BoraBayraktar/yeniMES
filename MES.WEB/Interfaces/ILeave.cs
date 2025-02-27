﻿using MES.Web.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Web.Interfaces
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
