using MES.API.Logger;
using MES.Data.Logics;
using MES.DB.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MES.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        IncidentLogic IncidentLogic = new IncidentLogic();
        IncidentHistoryLogic IncidentHistoryLogic = new IncidentHistoryLogic();
        IncidentResolutionLogic IncidentResolutionLogic = new IncidentResolutionLogic();

        private int userid;
        Log logger = new Log();
        public IncidentController(IHttpContextAccessor accessor)
        {
            userid = Convert.ToInt32(accessor?.HttpContext.User.FindFirstValue(ClaimTypes.SerialNumber));
        }
        #region Incident
        [HttpGet("IncidentGetList")]
        public List<INCIDENT> CityGetList()
        {
            return logger.Logging<List<INCIDENT>>(null, "Incident", "Get", userid, "IncidentGetList", IncidentLogic.GetList());
        }
        [HttpPost("GetIncident")]
        public INCIDENT GetIncident([FromBody] int incidentId)
        {
            return logger.Logging<INCIDENT>(incidentId, "Incident", "Post", userid, "GetIncident", IncidentLogic.GetIncident(incidentId));
        }
        [HttpPost("UpdateIncidentDetail")]
        public bool UpdateIncidentDetail(INCIDENT incident)
        {
            return logger.Logging<bool>(incident, "Incident", "Post", userid, "UpdateIncidentDetail", IncidentLogic.UpdateIncidentDetail(incident));
        }

        [HttpPost("InsertIncident")]
        public bool InsertIncident(INCIDENT incident)
        {
            return logger.Logging<bool>(incident, "Incident", "Post", userid, "InsertIncident", IncidentLogic.InsertIncident(incident));
        }
        [HttpPost("UpdateIncident")]
        public bool UpdateIncident(INCIDENT incident)
        {
            return logger.Logging<bool>(incident, "Group", "Post", userid, "UpdateIncident", IncidentLogic.UpdateIncident(incident));
        }
        [HttpPost("UpdateIncidentStatus")]
        public bool UpdateIncidentStatus(INCIDENT_HISTORY incidentHistory)
        {
            return logger.Logging<bool>(incidentHistory, "Incident", "Post", userid, "UpdateIncidentStatus", IncidentLogic.UpdateIncidentStatus(incidentHistory));
        }
        #endregion



        #region IncidentHistory

        [HttpPost("GetHistoryListByIncidentIdVisibleToUser")]
        public List<INCIDENT_HISTORY> GetHistoryListByIncidentIdVisibleToUser([FromBody] int incidentId)
        {
            return logger.Logging<List<INCIDENT_HISTORY>>(incidentId, "Incident", "Post", userid, "GetHistoryListByIncidentIdVisibleToUser", IncidentHistoryLogic.GetHistoryListByIncidentIdVisibleToUser(incidentId));
        }

        [HttpPost("GetListByIncidentId")]
        public List<INCIDENT_HISTORY> GetListByIncidentId([FromBody] int incidentId)
        {
            return logger.Logging<List<INCIDENT_HISTORY>>(incidentId, "Incident", "Post", userid, "GetListByIncidentId", IncidentHistoryLogic.GetListByIncidentId(incidentId));
        }

        [HttpPost("InsertIncidentHistory")]
        public bool InsertIncidentHistory(INCIDENT_HISTORY incidentHistory)
        {
            return logger.Logging<bool>(incidentHistory, "Incident", "Post", userid, "InsertIncidentHistory", IncidentHistoryLogic.InsertIncidentHistory(incidentHistory));
        }
        
        #endregion


        #region IncidentResolution
        [HttpPost("GetResolutionByIncidentId")]
        public INCIDENT_RESOLUTION GetResolutionByIncidentId([FromBody] int incidentId)
        {
            return logger.Logging<INCIDENT_RESOLUTION>(incidentId, "Incident", "Post", userid, "GetResolutionByIncidentId", IncidentResolutionLogic.GetResolutionByIncidentId(incidentId));
        }

        [HttpPost("InsertIncidentResolution")]
        public bool InsertIncidentResolution(INCIDENT_RESOLUTION incidentResolution)
        {
            return logger.Logging<bool>(incidentResolution, "Incident", "Post", userid, "InsertIncidentResolution", IncidentResolutionLogic.InsertIncidentResolution(incidentResolution));
        }
        #endregion

        #region IncidentResolution
        [HttpPost("InsertIncidentFiles")]
        public bool InsertIncidentFiles(INCIDENT_FILES incidentFiles)
        {
            return logger.Logging<bool>(incidentFiles, "Incident", "Post", userid, "InsertIncidentFiles", IncidentLogic.InsertIncidentFiles(incidentFiles));
        }
        #endregion
    }
}
