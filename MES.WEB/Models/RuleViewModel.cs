using MES.Web.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

namespace MES.Web.Models
{
    public class RuleViewModel
    {
        public RuleViewModel()
        {
            MainProcessList = new List<SelectListItem>();
            ParameterTypeList = new List<SelectListItem>();
            RuleCriteriaList = new List<SelectListItem>();

            RuleCriteriaDataList = new List<SelectListItem>();

            RuleDetailList = new List<RuleDetail>();

            RuleActionList = new List<SelectListItem>();

        }

        public RULE Rule { get; set; }

        public string RuleName { get; set; }
        public string RuleDescription { get; set; }
        public int MainProcessId { get; set; }
        public int ParameterTypeId { get; set; }
        public int RuleCriteriaId { get; set; }

        public int ConditionId { get; set; }

        public int AndOrOption { get; set; }


        public int RuleActionType { get; set; }

        public string RuleActionCode { get; set; }


        public List<SelectListItem> MainProcessList { get; set; }
        public List<SelectListItem> ParameterTypeList { get; set; }

        public List<SelectListItem> RuleCriteriaList { get; set; }

        public List<SelectListItem> RuleCriteriaDataList { get; set; }

        public List<RuleDetail> RuleDetailList { get; set; }

        public List<RULE_DETAIL> PostRuleList { get; set; }

        public List<SelectListItem> RuleActionList { get; set; }

        public List<RULE> RuleList { get; set; }

    }


    public class RuleDetail
    {
        public int Id { get; set; }
        public string Kriter { get; set; }
        public string Deger { get; set; }
        public string Kosul { get; set; }
        public string AndOrOption { get; set; }
    }
}
