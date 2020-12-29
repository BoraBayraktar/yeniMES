using MES.Data.Functions;
using MES.Data.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Business
{
    public class SlaLogic
    {
        ISla _Sla = new SlaFunctions();

        public List<SLA> GetList()
        {
            var k = _Sla.GetList();
            return k;
        }
        public SLA GetSla(int id)
        {
            var k = _Sla.GetSla(id);
            return k;
        }
        public List<MAIN_PROCESS> GetMainProcess()
        {
            var k = _Sla.GetMainProcess();
            return k;
        }
        public List<PARAMETER> GetImportanceLevel(string code)
        {
            var k = _Sla.GetImportanceLevel(code);
            return k;
        }
        public List<WORKING_SCHEDULE> GetWorkingSchedule()
        {
            var k = _Sla.GetWorkingSchedule();
            return k;
        }
        //public List<PARAMETER> GetSlaStartedStatus(string code)
        //{
        //    var k = _Sla.GetSlaStartedStatus(code);
        //    return k;
        //}
        //public List<PARAMETER> GetSlaStopedStatus(string code)
        //{
        //    var k = _Sla.GetSlaStopedStatus(code);
        //    return k;
        //}
        //public List<PARAMETER> GetSlaFinishedStatus(string code)
        //{
        //    var k = _Sla.GetSlaFinishedStatus(code);
        //    return k;
        //}
        public List<PARAMETER> GetPrmStatus(string code)
        {
            var k = _Sla.GetPrmStatus(code);
            return k;
        }
        public bool InsertSla(SLA sla)
        {
            var success = _Sla.InsertSla(sla);
            return success;
        }
        public bool UpdateSla(SLA sla)
        {
            var success = _Sla.UpdateSla(sla);
            return success;
        }
        public bool DeleteSla(int Id)
        {
            var success = _Sla.DeleteSla(Id);
            return success;
        }       
    }
}

