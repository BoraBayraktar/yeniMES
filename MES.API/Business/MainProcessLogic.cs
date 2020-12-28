using MES.API.Functions;
using MES.API.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.API.Business
{
    public class MainProcessLogic
    {
        IMainProcess _mainProcess = new MainProcessFunctions();
        public List<MAIN_PROCESS> GetList()
        {
            var mainProcessList = _mainProcess.GetList();
            return mainProcessList;
        }
        public bool InsertMainProcess(MAIN_PROCESS mainProcess)
        {
            var success = _mainProcess.InsertMainProcess(mainProcess);
            return success;
        }
        public bool UpdateMainProcess(MAIN_PROCESS mainProcess)
        {
            var success = _mainProcess.UpdateMainProcess(mainProcess);
            return success;
        }
        public bool DeleteMainProcess(int Id)
        {
            var success = _mainProcess.DeleteMainProcess(Id);
            return success;
        }
        public MAIN_PROCESS GetMainProcess(int id)
        {
            var mainProcess = _mainProcess.GetMainProcess(id);
            return mainProcess;
        }
    }
}
