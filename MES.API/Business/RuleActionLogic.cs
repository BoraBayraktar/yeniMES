using MES.API.Functions;
using MES.API.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.API.Business
{
    public class RuleActionLogic
    {
        IRuleAction _ruleAction = new RuleActionFunctions();
        public List<RULE_ACTIONS> GetRuleActionList()
        {
            var ruleActionList = _ruleAction.GetRuleActionList();
            return ruleActionList;
        }

        public RULE_ACTIONS GetRuleAction(string actionCode)
        {
            var ruleAction = _ruleAction.GetRuleAction(actionCode);
            return ruleAction;
        }
    }
}
