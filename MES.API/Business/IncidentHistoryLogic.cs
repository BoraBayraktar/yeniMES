using MES.API.Functions;
using MES.API.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.API.Business
{
    public class IncidentHistoryLogic
    {
        IIncidentHistory _incidentHistory = new IncidentHistoryFunctions();
        public List<INCIDENT_HISTORY> GetList()
        {
            var incidentHistoryList = _incidentHistory.GetList();
            return incidentHistoryList;
        }
        public bool InsertIncidentHistory(INCIDENT_HISTORY incidentHistory)
        {
            var success = _incidentHistory.InsertIncidentHistory(incidentHistory);
            return success;
        }
        public bool UpdateIncidentHistory(INCIDENT_HISTORY incidentHistory)
        {
            var success = _incidentHistory.UpdateIncidentHistory(incidentHistory);
            return success;
        }
        public bool DeleteIncidentHistory(int Id)
        {
            var success = _incidentHistory.DeleteIncidentHistory(Id);
            return success;
        }
        public INCIDENT_HISTORY GetIncidentHistory(int id)
        {
            var incidentHistory = _incidentHistory.GetIncidentHistory(id);
            return incidentHistory;
        }

        public List<INCIDENT_HISTORY> GetListByIncidentId(int incidentId)
        {
            var incidentHistoryList = _incidentHistory.GetListByIncidentId(incidentId);
            return incidentHistoryList;
        }

        public List<INCIDENT_HISTORY> GetHistoryListByIncidentIdVisibleToUser(int incidentId)
        {
            var incidentHistoryList = _incidentHistory.GetHistoryListByIncidentIdVisibleToUser(incidentId);
            return incidentHistoryList;
        }
    }
}
