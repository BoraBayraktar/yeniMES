using MES.API.Logger;
using MES.Data.Logics;
using MES.DB.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MES.API.Controllers
{
    [Authorize]
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
        [HttpPost("IncidentReject")]
        public bool IncidentReject([FromBody] int incidentid, int userid)
        {
            return logger.Logging<bool>((incidentid, userid), "Incident", "Post", userid, "IncidentReject", IncidentLogic.IncidentReject(incidentid, userid));
        }
        [HttpPost("IncidentConfirmAndClose")]
        public bool IncidentConfirmAndClose([FromBody] int incidentid, int userid)
        {
            return logger.Logging<bool>((incidentid, userid), "Incident", "Post", userid, "IncidentConfirmAndClose", IncidentLogic.IncidentConfirmAndClose(incidentid, userid));
        }
        [HttpGet("sumUnResolved")]
        public int sumUnResolved()
        {
            return logger.Logging<int>(null, "Incident", "Get", userid, "sumUnResolved", IncidentLogic.sumUnResolved());
        }
        [HttpGet("sumOverdue")]
        public int sumOverdue()
        {
            return logger.Logging<int>(null, "Incident", "Get", userid, "sumOverdue", IncidentLogic.sumOverdue());
        }
        [HttpGet("sumDuetoday")]
        public int sumDuetoday()
        {
            return logger.Logging<int>(null, "Incident", "Get", userid, "sumDuetoday", IncidentLogic.sumDuetoday());
        }
        [HttpGet("sumOpen")]
        public int sumOpen()
        {
            return logger.Logging<int>(null, "Incident", "Get", userid, "sumOpen", IncidentLogic.sumOpen());
        }
        [HttpGet("sumOnhold")]
        public int sumOnhold()
        {
            return logger.Logging<int>(null, "Incident", "Get", userid, "sumOnhold", IncidentLogic.sumOnhold());
        }
        [HttpGet("sumUnassigned")]
        public int sumUnassigned()
        {
            return logger.Logging<int>(null, "Incident", "Get", userid, "sumUnassigned", IncidentLogic.sumUnassigned());
        }
        [HttpGet("MaxCode")]
        public string MaxCode()
        {
            return logger.Logging<string>(null, "Incident", "Get", userid, "MaxCode", IncidentLogic.MaxCode());
        }
        [HttpPost("GetIncidentType")]
        public INCIDENT_TYPE GetIncidentType([FromBody]string code)
        {
            return logger.Logging<INCIDENT_TYPE>(code, "Incident", "Get", userid, "GetIncidentType", IncidentLogic.GetIncidentType(code));
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
        [HttpPost("InsertIncidentFiles")]
        public bool InsertIncidentFiles(INCIDENT_FILES incidentFiles)
        {
            return logger.Logging<bool>(incidentFiles, "Incident", "Post", userid, "InsertIncidentFiles", IncidentLogic.InsertIncidentFiles(incidentFiles));
        }
        #endregion
    }
}
