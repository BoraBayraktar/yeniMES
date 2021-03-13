using MES.API.JwtToken;
using MES.API.Logger;
using MES.Data.Logics;
using MES.Data.Model;
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
    public class RuleController : ControllerBase
    {
        #region RuleCriteria
        RuleLogic ruleLogic = new RuleLogic();
        Log logger = new Log();
        private int userid;
        public RuleController(IHttpContextAccessor accessor)
        {
            userid = Convert.ToInt32(accessor?.HttpContext.User.FindFirstValue(ClaimTypes.SerialNumber));
        }

        [HttpGet("RuleCriteriaGetList")]
        public List<RULE_CRITERIA> RuleCriteriaGetList()
        {
            return logger.Logging<List<RULE_CRITERIA>>(null, "Rule", "Get", userid, "RuleCriteriaGetList", ruleLogic.GetRuleCriteriaList());
        }
        [HttpPost("RuleCriteriaDataGetList")]
        public List<RuleCriteriaData> RuleCriteriaDataGetList([FromBody] int id)
        {
            return logger.Logging<List<RuleCriteriaData>>(id, "Rule", "Post", userid, "RuleCriteriaDataGetList", ruleLogic.GetRuleCriteriaData(id));
        }
        #endregion
        
        #region Rule
        [HttpGet("RuleGetList")]
        public List<RULE> RuleGetList()
        {
            return logger.Logging<List<RULE>>(null, "Rule", "Get", userid, "RuleGetList", ruleLogic.GetRuleList());
        }
        [HttpPost("InsertRule")]
        public bool InsertRule(RULE rule)
        {
            return logger.Logging<bool>(rule, "Rule", "Post", userid, "InsertRule", ruleLogic.InsertRule(rule));
        }
        [HttpPost("UpdateRule")]
        public bool UpdateRule(RULE rule)
        {
            return logger.Logging<bool>(rule, "Rule", "Post", userid, "UpdateRule", ruleLogic.UpdateRule(rule));
        }
        [HttpPost("DeleteRule")]
        public bool DeleteRule([FromBody] int deleteId)
        {
            return logger.Logging<bool>(deleteId, "Rule", "Post", userid, "DeleteRule", ruleLogic.DeleteRule(deleteId));
        }

        #endregion
        #region RuleDetail
        [HttpGet("RuleDetailGetList")]
        public List<RULE_DETAIL> RuleDetailGetList()
        {
            return logger.Logging<List<RULE_DETAIL>>(null, "Rule", "Get", userid, "RuleDetailGetList", ruleLogic.GetRuleDetailList());
        }
        [HttpPost("InsertRuleDetail")]
        public bool InsertRuleDetail(RULE_DETAIL ruleDetail)
        {
            return logger.Logging<bool>(ruleDetail, "Rule", "Post", userid, "InsertRuleDetail", ruleLogic.InsertRuleDetail(ruleDetail));
        }
        [HttpPost("UpdateRuleDetail")]
        public bool UpdateRuleDetail(RULE_DETAIL ruleDetail)
        {
            return logger.Logging<bool>(ruleDetail, "Rule", "Post", userid, "UpdateRuleDetail", ruleLogic.UpdateRuleDetail(ruleDetail));
        }
        [HttpPost("DeleteRuleDetail")]
        public bool DeleteRuleDetail([FromBody] int deleteId)
        {
            return logger.Logging<bool>(deleteId, "Rule", "Post", userid, "DeleteRuleDetail", ruleLogic.DeleteRuleDetail(deleteId));
        }
        [HttpPost("GetRuleDetailByRuleId")]
        public List<RULE_DETAIL> GetRuleDetailByRuleId([FromBody] int ruleDetailid)
        {
            return logger.Logging<List<RULE_DETAIL>>(ruleDetailid, "Rule", "Post", userid, "GetRuleDetailByRuleId", ruleLogic.GetRuleDetailByRuleId(ruleDetailid));
        }
        #endregion
    }
}
