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
    public class SettingController : ControllerBase
    {
        SettingKnowledgeOrderNumbersLogic settingsKnowledgeLogic = new SettingKnowledgeOrderNumbersLogic();
        SettingIncidentOrderNumbersLogic settingsIncidentLogic = new SettingIncidentOrderNumbersLogic();
        private int userid;
        Log logger = new Log();
        public SettingController(IHttpContextAccessor accessor)
        {
            userid = Convert.ToInt32(accessor?.HttpContext.User.FindFirstValue(ClaimTypes.SerialNumber));
        }
        #region SettingsKnowledge
        [HttpGet("SettingsKnowledgeGetList")]
        public List<ORDER_NUMBERS> SettingsKnowledgeGetList()
        {
            return logger.Logging<List<ORDER_NUMBERS>>(null, "Setting", "Get", userid, "SettingsKnowledgeGetList", settingsKnowledgeLogic.GetList());
        }
        [HttpPost("UpdateOrderNumbers")]
        public bool UpdateOrderNumbers(ORDER_NUMBERS orderNumbers)
        {
            return logger.Logging<bool>(orderNumbers, "Setting", "Post", userid, "UpdateOrderNumbers", settingsKnowledgeLogic.UpdateOrderNumbers(orderNumbers));
        }
        [HttpPost("GetOrderNumbers")]
        public ORDER_NUMBERS GetOrderNumbers([FromBody] int id)
        {
            return logger.Logging<ORDER_NUMBERS>(id, "Setting", "Post", userid, "GetOrderNumbers", settingsKnowledgeLogic.GetOrderNumbers(id));
        }
        [HttpPost("UpdateStatus")]
        public bool UpdateStatus(KNOWLEDGE_SETTINGS knowledgeSettings)
        {
            return logger.Logging<bool>(knowledgeSettings, "Setting", "Post", userid, "UpdateStatus", settingsKnowledgeLogic.UpdateStatus(knowledgeSettings));
        }
        [HttpPost("GetStatus")]
        public KNOWLEDGE_SETTINGS GetStatus([FromBody] int id)
        {
            return logger.Logging<KNOWLEDGE_SETTINGS>(id, "Setting", "Post", userid, "GetStatus", settingsKnowledgeLogic.GetStatus(id));
        }
        #endregion

        #region SettingsIncident
        [HttpGet("SettingsIncidentGetList")]
        public List<ORDER_NUMBERS> SettingsIncidentGetList()
        {
            return logger.Logging<List<ORDER_NUMBERS>>(null, "Setting", "Get", userid, "SettingsIncidentGetList", settingsIncidentLogic.GetList());
        }
        [HttpPost("GetIncidentOrderNumbers")]
        public ORDER_NUMBERS GetIncidentOrderNumbers([FromBody] int id)
        {
            return logger.Logging<ORDER_NUMBERS>(null, "Setting", "Post", userid, "GetIncidentOrderNumbers", settingsIncidentLogic.GetOrderNumbers(id));
        }
        #endregion
    }
}
