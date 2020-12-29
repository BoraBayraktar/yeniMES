using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Interfaces
{
    public interface IIncident
    {
        List<INCIDENT> GetList();
        INCIDENT GetIncident(int id);

        bool InsertIncident(INCIDENT incident);
        bool UpdateIncident(INCIDENT incident);
        bool UpdateIncidentDetail(INCIDENT incident);

        bool DeleteIncident(int Id);

        string MaxCode();

        bool InsertIncidentFiles(INCIDENT_FILES incidentFile);

        INCIDENT_TYPE GetIncidentType(string code);

        List<PARAMETER> IncidentStatusList();


        bool UpdateIncidentStatus(INCIDENT_HISTORY incidentHistory);


        bool SendMailAndSurvey(INCIDENT incident);

        bool IncidentConfirmAndClose(int incidentId, int userId);

        bool IncidentReject(int incidentId, int userId);

        int sumUnResolved();
        int sumOverdue();
        int sumDuetoday();
        int sumOpen();
        int sumOnhold();
        int sumUnassigned();

    }
}
