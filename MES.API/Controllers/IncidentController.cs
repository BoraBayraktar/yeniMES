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
        #endregion



        #region IncidentHistory
        [HttpPost("GetListByIncidentId")]
        public List<INCIDENT_HISTORY> GetListByIncidentId([FromBody] int incidentId)
        {
            return logger.Logging<List<INCIDENT_HISTORY>>(incidentId, "Incident", "Post", userid, "GetListByIncidentId", IncidentHistoryLogic.GetListByIncidentId(incidentId));
        }
        #endregion


        #region IncidentResolution
        [HttpPost("GetResolutionByIncidentId")]
        public INCIDENT_RESOLUTION GetResolutionByIncidentId([FromBody] int incidentId)
        {
            return logger.Logging<INCIDENT_RESOLUTION>(incidentId, "Incident", "Post", userid, "GetResolutionByIncidentId", IncidentResolutionLogic.GetResolutionByIncidentId(incidentId));
        }
        #endregion
    }
}
