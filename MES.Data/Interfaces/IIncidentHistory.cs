using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Interfaces
{
    public interface IIncidentHistory
    {
        List<INCIDENT_HISTORY> GetList();
        INCIDENT_HISTORY GetIncidentHistory(int id);
        bool InsertIncidentHistory(INCIDENT_HISTORY incidentHistory);
        bool UpdateIncidentHistory(INCIDENT_HISTORY incidentHistory);
        bool DeleteIncidentHistory(int Id);

        List<INCIDENT_HISTORY> GetListByIncidentId(int incidentId);
        List<INCIDENT_HISTORY> GetHistoryListByIncidentIdVisibleToUser(int incidentId);
    }
}
