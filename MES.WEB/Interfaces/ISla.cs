using MES.Web.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Web.Interfaces
{
    public interface ISla
    {
        List<SLA> GetList();
        SLA GetSla(int id);
        List<MAIN_PROCESS> GetMainProcess();
        List<PARAMETER> GetImportanceLevel(string code);
        List<WORKING_SCHEDULE> GetWorkingSchedule();
        //List<PARAMETER> GetSlaStartedStatus(string code);
        //List<PARAMETER> GetSlaStopedStatus(string code);
        //List<PARAMETER> GetSlaFinishedStatus(string code);        
        List<PARAMETER> GetPrmStatus(string code);
        bool InsertSla(SLA sla);
        bool UpdateSla(SLA sla);
        bool DeleteSla(int Id); 
    }
}
