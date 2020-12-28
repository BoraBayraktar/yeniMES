using MES.API.Functions;
using MES.API.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.API.Business
{
    public class IncidentLogic
    {
        IIncident _incident = new IncidentFunctions();

        public List<INCIDENT> GetList()
        {
            var incidentList = _incident.GetList();
            return incidentList;
        }
        public bool InsertIncident(INCIDENT incident)
        {
            var success = _incident.InsertIncident(incident);
            return success;
        }
        public bool UpdateIncident(INCIDENT incident)
        {
            var success = _incident.UpdateIncident(incident);
            return success;
        }
        public bool DeleteHolding(int Id)
        {
            var success = _incident.DeleteIncident(Id);
            return success;
        }
        public INCIDENT GetIncident(int id)
        {
            var incident = _incident.GetIncident(id);
            return incident;
        }

        public string MaxCode()
        {
            return _incident.MaxCode();
        }

        public bool InsertIncidentFiles(INCIDENT_FILES incidentFile)
        {
            var success = _incident.InsertIncidentFiles(incidentFile);
            return success;
        }

        public INCIDENT_TYPE GetIncidentType(string code)
        {
            var incidentType = _incident.GetIncidentType(code);
            return incidentType;
        }

        public List<PARAMETER> IncidentStatusList()
        {
            var incidentStatusList = _incident.IncidentStatusList();
            return incidentStatusList;
        }

        public bool UpdateIncidentDetail(INCIDENT incident)
        {
            var success = _incident.UpdateIncidentDetail(incident);
            return success;
        }

        public bool UpdateIncidentStatus(INCIDENT_HISTORY incidentHistory)
        {
            var success = _incident.UpdateIncidentStatus(incidentHistory);
            return success;
        }

        public bool SendMailAndSurvey(INCIDENT incident)
        {
            var success = _incident.SendMailAndSurvey(incident);
            return success;
        }

        public bool IncidentConfirmAndClose(int incidentId, int userId)
        {
            var success = _incident.IncidentConfirmAndClose(incidentId, userId);
            return success;
        }

        public bool IncidentReject(int incidentId, int userId)
        {
            var success = _incident.IncidentReject(incidentId, userId);
            return success;
        }

        public int sumUnResolved()
        {
            return _incident.sumUnResolved();
        }
        public int sumOverdue()
        {
            return _incident.sumOverdue();
        }
        public int sumDuetoday()
        {
            return _incident.sumDuetoday();
        }
        public int sumOpen()
        {
            return _incident.sumOpen();
        }
        public int sumOnhold()
        {
            return _incident.sumOnhold();
        }
        public int sumUnassigned()
        {
            return _incident.sumUnassigned();
        }
    }
}
