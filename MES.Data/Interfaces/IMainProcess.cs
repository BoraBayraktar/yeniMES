using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Interfaces
{
    public interface IMainProcess
    {
        List<MAIN_PROCESS> GetList();
        MAIN_PROCESS GetMainProcess(int id);
        bool InsertMainProcess(MAIN_PROCESS mainProcess);
        bool UpdateMainProcess(MAIN_PROCESS mainProcess);
        bool DeleteMainProcess(int Id);
    }
}
