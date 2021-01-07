using MES.Web.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Web.Interfaces
{
    public interface IIncidentResolution
    {
        List<INCIDENT_RESOLUTION> GetList();

        List<INCIDENT_RESOLUTION> GetListByIncidentId(int incidentId);

        INCIDENT_RESOLUTION GetResolutionByIncidentId(int incidentId);


        bool InsertIncidentResolution(INCIDENT_RESOLUTION incidentResolution);
        bool UpdateIncidentResolution(INCIDENT_RESOLUTION incidentResolution);

    }
}
