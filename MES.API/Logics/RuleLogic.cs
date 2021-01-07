using MES.Data.Functions;
using MES.Data.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;
using MES.Data.Model;

namespace MES.Data.Logics
{
    public class RuleLogic
    {
        IRule _rule = new RuleFunctions();
        public List<RULE_CRITERIA> GetRuleCriteriaList()
        {
            var ruleCriteriaList = _rule.GetRuleCriteriaList();
            return ruleCriteriaList;
        }

        public List<RuleCriteriaData> GetRuleCriteriaData(int ruleCriteriaId)
        {
            var ruleCriteriaDataList = _rule.GetRuleCriteriaData(ruleCriteriaId);
            return ruleCriteriaDataList;
        }



        public List<RULE> GetRuleList()
        {
            var ruleList = _rule.GetRuleList();
            return ruleList;
        }

        public bool InsertRule(RULE rule)
        {
            var success = _rule.InsertRule(rule);
            return success;
        }
        public bool UpdateRule(RULE rule)
        {
            var success = _rule.UpdateRule(rule);
            return success;
        }
        public bool DeleteRule(int Id)
        {
            var success = _rule.DeleteRule(Id);
            return success;
        }



        public List<RULE_DETAIL> GetRuleDetailByRuleId(int ruleId)
        {
            var ruleDetailList = _rule.GetRuleDetailByRuleId(ruleId);
            return ruleDetailList;
        }


        public List<RULE_DETAIL> GetRuleDetailList()
        {
            var ruleDetailList = _rule.GetRuleDetailList();
            return ruleDetailList;
        }

        public bool InsertRuleDetail(RULE_DETAIL ruleDetail)
        {
            var success = _rule.InsertRuleDetail(ruleDetail);
            return success;
        }
        public bool UpdateRuleDetail(RULE_DETAIL ruleDetail)
        {
            var success = _rule.UpdateRuleDetail(ruleDetail);
            return success;
        }
        public bool DeleteRuleDetail(int Id)
        {
            var success = _rule.DeleteRuleDetail(Id);
            return success;
        }

    }
}
