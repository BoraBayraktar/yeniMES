using MES.Data.Functions;
using MES.Data.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Business
{
    public class IncidentResolutionLogic
    {
        IIncidentResolution _incidentResolution = new IncidentResolutionFunctions();

        public List<INCIDENT_RESOLUTION> GetList()
        {
            var resolutionList = _incidentResolution.GetList();
            return resolutionList;
        }

        public List<INCIDENT_RESOLUTION> GetListByIncidentId(int incidentId)
        {
            var resolutionList = _incidentResolution.GetListByIncidentId(incidentId);
            return resolutionList;
        }

        public INCIDENT_RESOLUTION GetResolutionByIncidentId(int incidentId)
        {
            var resolution = _incidentResolution.GetResolutionByIncidentId(incidentId);
            return resolution;
        }
        public bool InsertIncidentResolution(INCIDENT_RESOLUTION incidentResolution)
        {
            var success = _incidentResolution.InsertIncidentResolution(incidentResolution);
            return success;
        }

        public bool UpdateIncidentResolution(INCIDENT_RESOLUTION incidentResolution)
        {
            var success = _incidentResolution.UpdateIncidentResolution(incidentResolution);
            return success;
        }
    }
}
