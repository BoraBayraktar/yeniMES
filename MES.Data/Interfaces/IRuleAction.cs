using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Interfaces
{
    public interface IRuleAction
    {
        List<RULE_ACTIONS> GetRuleActionList();
        RULE_ACTIONS GetRuleAction(string actionCode);
    }
}
