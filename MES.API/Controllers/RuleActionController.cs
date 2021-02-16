using MES.API.Logger;
using MES.Data.Logics;
using MES.DB.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RuleActionController : ControllerBase
    {
        RuleActionLogic ruleActionLogic = new RuleActionLogic();
        private int userid;
        Log logger = new Log();
        #region RuleAction
        [HttpGet("RuleActionGetList")]
        public List<RULE_ACTIONS> RuleActionGetList()
        {
            return logger.Logging<List<RULE_ACTIONS>>(null, "RuleAction", "Get", userid, "RuleActionGetList", ruleActionLogic.GetRuleActionList());
        }
        [HttpPost("GetRuleAction")]
        public RULE_ACTIONS GetRuleAction(string actionCode)
        {
            return logger.Logging<RULE_ACTIONS>(actionCode, "RuleAction", "Post", userid, "GetRuleAction", ruleActionLogic.GetRuleAction(actionCode));
        }
        #endregion
    }
}
