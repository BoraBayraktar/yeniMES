using MES.Data.Functions;
using MES.Data.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Logics
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
