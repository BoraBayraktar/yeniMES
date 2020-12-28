using MES.API.Interfaces;
using MES.DB;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MES.API.Functions
{
    public class RuleActionFunctions : IRuleAction
    {
        public List<RULE_ACTIONS> GetRuleActionList()
        {
            using (MesContext context = new MesContext())
            {
                var ruleActionList = context.RULE_ACTIONS.ToList();
                return ruleActionList;
            }
        }

        public RULE_ACTIONS GetRuleAction(string actionCode)
        {
            using (MesContext context = new MesContext())
            {
                var ruleAction = context.RULE_ACTIONS.FirstOrDefault(q => q.ACTION_CODE == actionCode);
                return ruleAction;
            }
        }
    }
}
