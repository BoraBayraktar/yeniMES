using MES.DB.Model;
using MES.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Interfaces
{
    public interface IRule
    {
        List<RULE_CRITERIA> GetRuleCriteriaList();
        List<RuleCriteriaData> GetRuleCriteriaData(int ruleCriteriaId);

        List<RULE> GetRuleList();
        bool InsertRule(RULE rule);
        bool UpdateRule(RULE rule);
        bool DeleteRule(int Id);

        List<RULE_DETAIL> GetRuleDetailByRuleId(int ruleId);
        List<RULE_DETAIL> GetRuleDetailList();
        bool InsertRuleDetail(RULE_DETAIL ruleDetail);
        bool UpdateRuleDetail(RULE_DETAIL ruleDetail);
        bool DeleteRuleDetail(int Id);
    }
}
