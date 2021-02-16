using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MES.Web.Model;
using MES.Web.Models;
using MES.Web.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MES.Web.Controllers
{
    public class RulesController : BaseController
    {
        ServiceBusiness serviceBusiness = new ServiceBusiness();

        public IActionResult RuleDefinition(int? id)
        {
            RuleViewModel rvm = new RuleViewModel();
            var mainProcessList = serviceBusiness.ServiceGet<List<MAIN_PROCESS>>("MainProcess", "MainProcessGetList").Where(q => q.SHORT_CODE == "INCIDENT_MANAGEMENT").ToList();

            foreach (var item in mainProcessList)
            {
                rvm.MainProcessList.Add(new SelectListItem()
                {
                    Text = item.NAME,
                    Value = item.ID.ToString()
                });
            }

            var ruleCriteriaList = serviceBusiness.ServiceGet<List<RULE_CRITERIA>>("Rule", "RuleCriteriaGetList");

            foreach (var item in ruleCriteriaList)
            {
                rvm.RuleCriteriaList.Add(new SelectListItem()
                {
                    Text = item.DESCRIPTION,
                    Value = item.ID.ToString()
                });
            }


            var ruleActionList = serviceBusiness.ServiceGet<List<RULE_ACTIONS>>("RuleAction","RuleActionGetList");

            foreach (var item in ruleActionList)
            {
                rvm.RuleActionList.Add(new SelectListItem()
                {
                    Text = item.ACTION_NAME,
                    Value = item.ACTION_CODE.ToString()
                });
            }

            if (id != null)
            {
                var ruleId = Convert.ToInt32(id);
                rvm.Rule = serviceBusiness.ServiceGet<List<RULE>>("Rule","RuleGetList").FirstOrDefault(q => q.RULE_ID == ruleId);
            }



            return View(rvm);
        }

        [HttpGet]
        public JsonResult GetParameterTypeByMainProcessId(int mainProcessId)
        {
            var parameterTypeList = serviceBusiness.ServicePost<List<PARAMETER_TYPE>>(mainProcessId, "Parameter", "GetParameterTypeByMainProcessId");
            return Json(parameterTypeList);
        }

        [HttpGet]
        public JsonResult GetCriteriaData(int ruleCriteriaId)
        {
            var ruleCriteriaDataList = new List<RuleCriteriaData>();
            var ruleCriteriaList = serviceBusiness.ServiceGet<List<RULE_CRITERIA>>("Rule", "RuleCriteriaGetList");
            var selectedRuleCriteria = ruleCriteriaList.FirstOrDefault(q => q.ID == ruleCriteriaId);
            if (selectedRuleCriteria.IS_FOREIGN)
            {
                ruleCriteriaDataList = serviceBusiness.ServicePost<List<RuleCriteriaData>>(ruleCriteriaId, "Rule", "RuleCriteriaDataGetList");
            }
            return Json(new { IsForeign = selectedRuleCriteria.IS_FOREIGN, CriteriaData = ruleCriteriaDataList });
        }


        [HttpGet]
        public JsonResult GetRuleActionData(string ruleActionCode)
        {
            var dataList = new List<SelectListItem>();
            if (ruleActionCode == "GROUP")
            {
                var groupList = serviceBusiness.ServiceGet<List<GROUP>>("Group","GroupGetList");
                foreach (var item in groupList)
                {
                    dataList.Add(new SelectListItem()
                    {
                        Text = item.GROUP_NAME,
                        Value = item.ID.ToString()
                    });
                }
            }
            else if (ruleActionCode == "USER")
            {
                var expertList = serviceBusiness.ServiceGet<List<GROUP_EXPERT>>("GroupExpert", "GroupExpertGetList");
                foreach (var item in expertList)
                {
                    if (!dataList.Any(q => q.Value == item.EXPERT_NAME_ID.ToString()))
                    {
                        dataList.Add(new SelectListItem()
                        {
                            Text = item.EXPERT_NAME,
                            Value = item.EXPERT_NAME_ID.ToString()
                        });
                    }
                }
            }
            else if (ruleActionCode == "CATEGORY")
            {
                var incidentCategoryList = serviceBusiness.ServicePost<List<PARAMETER>>("INCIDENT_CATEGORY","Parameter", "GetParameterListByParameterTypeCode").Where(q => q.IS_ACTIVE == true).ToList();
                foreach (var item in incidentCategoryList)
                {
                    dataList.Add(new SelectListItem()
                    {
                        Text = item.MAIN_DATA_NAME,
                        Value = item.ID.ToString()
                    });
                }
            }
            else if (ruleActionCode == "PRIORITY")
            {
                var priorityList = serviceBusiness.ServicePost<List<PARAMETER>>("INCIDENT_PRIORITY","Parameter", "GetParameterListByParameterTypeCode").Where(q => q.IS_ACTIVE == true).ToList();
                foreach (var item in priorityList)
                {
                    dataList.Add(new SelectListItem()
                    {
                        Text = item.MAIN_DATA_NAME,
                        Value = item.ID.ToString()
                    });
                }
            }
            else if (ruleActionCode == "TYPE")
            {
                var typeList = serviceBusiness.ServicePost<List<PARAMETER>>("INCIDENT_TYPE", "Parameter", "GetParameterListByParameterTypeCode").Where(q => q.IS_ACTIVE == true).ToList();
                foreach (var item in typeList)
                {
                    dataList.Add(new SelectListItem()
                    {
                        Text = item.MAIN_DATA_NAME,
                        Value = item.ID.ToString()
                    });
                }
            }
            else if (ruleActionCode == "REQUIRED")
            {

            }

            return Json(dataList);
        }


        [HttpPost]
        public IActionResult RuleDefinition(int? id, RuleViewModel ruleViewModel)
        {
            bool success = false;
            RuleViewModel rvm = new RuleViewModel();
            var mainProcessList = serviceBusiness.ServiceGet<List<MAIN_PROCESS>>("MainProcess", "MainProcessGetList").Where(q => q.SHORT_CODE == "INCIDENT_MANAGEMENT").ToList();

            foreach (var item in mainProcessList)
            {
                rvm.MainProcessList.Add(new SelectListItem()
                {
                    Text = item.NAME,
                    Value = item.ID.ToString()
                });
            }

            var ruleCriteriaList = serviceBusiness.ServiceGet<List<RULE_CRITERIA>>("Rule", "RuleCriteriaGetList");

            foreach (var item in ruleCriteriaList)
            {
                rvm.RuleCriteriaList.Add(new SelectListItem()
                {
                    Text = item.DESCRIPTION,
                    Value = item.ID.ToString()
                });
            }

            var ruleActionList = serviceBusiness.ServiceGet<List<RULE_ACTIONS>>("RuleAction", "RuleActionGetList");

            foreach (var item in ruleActionList)
            {
                rvm.RuleActionList.Add(new SelectListItem()
                {
                    Text = item.ACTION_NAME,
                    Value = item.ACTION_CODE.ToString()
                });
            }



            if (id == null)
            {
                //ruleViewModel.Rule.CREATED_USER_ID = SessionUser.USER_ID;
                ruleViewModel.Rule.CREATED_DATE = DateTime.Now;
                success = serviceBusiness.ServicePost<bool>(ruleViewModel.Rule, "Rule", "InsertRule");
            }
            else
            {
                ruleViewModel.Rule.RULE_ID = Convert.ToInt32(id);
                //ruleViewModel.Rule.UPDATED_USER_ID = SessionUser.USER_ID;
                ruleViewModel.Rule.UPDATED_DATE = DateTime.Now;
                success = serviceBusiness.ServicePost<bool>(ruleViewModel.Rule, "Rule", "UpdateRule");
                if (success == false)
                {
                    ShowErrorToastMessage();
                    return RedirectToAction("RuleDefinition", "Rules");
                }
            }
            
            var ruleDetailList = serviceBusiness.ServicePost<List<RULE_DETAIL>>(ruleViewModel.Rule.RULE_ID, "Rule", "GetRuleDetailByRuleId");

            foreach (var item in ruleDetailList)
            {
                success = serviceBusiness.ServicePost<bool>(item.RULE_DETAIL_ID,"Rule", "DeleteRuleDetail");
                if (success == false)
                {
                    ShowErrorToastMessage();
                    return RedirectToAction("RuleDefinition", "Rules");
                }
            }

            foreach (var item in ruleViewModel.PostRuleList)
            {
                item.RULE_ID = ruleViewModel.Rule.RULE_ID;
                //item.CREATED_USER_ID = SessionUser.USER_ID;
                success = serviceBusiness.ServicePost<bool>(item, "Rule", "InsertRuleDetail");

                if (success == false)
                {
                    ShowErrorToastMessage();
                    return RedirectToAction("RuleDefinition", "Rules");
                }
            }

            ShowSuccessToastMessage();
            return RedirectToAction("RuleDefinition", "Rules");

        }


        public IActionResult RuleList()
        {
            var ruleList = serviceBusiness.ServiceGet<List<RULE>>("Rule", "RuleGetList");

            RuleViewModel rvm = new RuleViewModel();

            rvm.RuleList = ruleList;

            foreach (var item in rvm.RuleList)
            {
                if (item.RULE_ACTION == "GROUP")
                {
                    item.RULE_ACTION_DATA = serviceBusiness.ServicePost<GROUP>(Convert.ToInt32(item.RULE_ACTION_DATA),"Group","GetGroup").GROUP_NAME;
                }
                else if (item.RULE_ACTION == "USER")
                {
                    var user = serviceBusiness.ServicePost<USER>(Convert.ToInt32(item.RULE_ACTION_DATA),"User","GetUser");
                    item.RULE_ACTION_DATA = user.NAME + " " + user.SURNAME;
                }
                else if (item.RULE_ACTION == "CATEGORY")
                {
                    item.RULE_ACTION_DATA = serviceBusiness.ServicePost<PARAMETER>(Convert.ToInt32(item.RULE_ACTION_DATA),"Parameter","GetParameter").MAIN_DATA_NAME;
                }
                else if (item.RULE_ACTION == "PRIORITY")
                {

                }
                else if (item.RULE_ACTION == "TYPE")
                {

                }
                else if (item.RULE_ACTION == "REQUIRED")
                {

                }
                item.RULE_ACTION = serviceBusiness.ServicePost<RULE_ACTIONS>(item.RULE_ACTION,"RuleAction","GetRuleAction").ACTION_NAME;
            }

            return View(rvm);
        }

    }
}
