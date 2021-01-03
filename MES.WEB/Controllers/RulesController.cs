using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MES.Business;
using MES.Model;
using MES.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MES.Web.Controllers
{
    public class RulesController : BaseController
    {
        MainProcessLogic mainProcessLogic = new MainProcessLogic();
        ParameterLogic parameterLogic = new ParameterLogic();
        RuleLogic ruleLogic = new RuleLogic();
        RuleActionLogic ruleActionLogic = new RuleActionLogic();
        GroupLogic groupLogic = new GroupLogic();
        UserLogic userLogic = new UserLogic();
        GroupExpertLogic groupExpertLogic = new GroupExpertLogic();

        public IActionResult RuleDefinition(int? id)
        {
            RuleViewModel rvm = new RuleViewModel();
            var mainProcessList = mainProcessLogic.GetList().Where(q => q.SHORT_CODE == "INCIDENT_MANAGEMENT").ToList();

            foreach (var item in mainProcessList)
            {
                rvm.MainProcessList.Add(new SelectListItem()
                {
                    Text = item.NAME,
                    Value = item.ID.ToString()
                });
            }

            var ruleCriteriaList = ruleLogic.GetRuleCriteriaList();

            foreach (var item in ruleCriteriaList)
            {
                rvm.RuleCriteriaList.Add(new SelectListItem()
                {
                    Text = item.DESCRIPTION,
                    Value = item.ID.ToString()
                });
            }


            var ruleActionList = ruleActionLogic.GetRuleActionList();

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
                rvm.Rule = ruleLogic.GetRuleList().FirstOrDefault(q => q.RULE_ID == ruleId);
            }



            return View(rvm);
        }

        [HttpGet]
        public JsonResult GetParameterTypeByMainProcessId(int mainProcessId)
        {
            var parameterTypeList = parameterLogic.GetParameterTypeByMainProcessId(mainProcessId);
            return Json(parameterTypeList);
        }

        [HttpGet]
        public JsonResult GetCriteriaData(int ruleCriteriaId)
        {
            var ruleCriteriaDataList = new List<RuleCriteriaData>();
            var ruleCriteriaList = ruleLogic.GetRuleCriteriaList();
            var selectedRuleCriteria = ruleCriteriaList.FirstOrDefault(q => q.ID == ruleCriteriaId);
            if (selectedRuleCriteria.IS_FOREIGN)
            {
                ruleCriteriaDataList = ruleLogic.GetRuleCriteriaData(ruleCriteriaId);
            }
            return Json(new { IsForeign = selectedRuleCriteria.IS_FOREIGN, CriteriaData = ruleCriteriaDataList });
        }


        [HttpGet]
        public JsonResult GetRuleActionData(string ruleActionCode)
        {
            var dataList = new List<SelectListItem>();
            if (ruleActionCode == "GROUP")
            {
                var groupList = groupLogic.GetList();
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
                var expertList = groupExpertLogic.GetList();
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
                var incidentCategoryList = parameterLogic.GetParameterListByParameterTypeCode("INCIDENT_CATEGORY").Where(q => q.IS_ACTIVE == true).ToList();
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
                var priorityList = parameterLogic.GetParameterListByParameterTypeCode("INCIDENT_PRIORITY").Where(q => q.IS_ACTIVE == true).ToList();
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
                var typeList = parameterLogic.GetParameterListByParameterTypeCode("INCIDENT_TYPE").Where(q => q.IS_ACTIVE == true).ToList();
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
            var mainProcessList = mainProcessLogic.GetList().Where(q => q.SHORT_CODE == "INCIDENT_MANAGEMENT").ToList();

            foreach (var item in mainProcessList)
            {
                rvm.MainProcessList.Add(new SelectListItem()
                {
                    Text = item.NAME,
                    Value = item.ID.ToString()
                });
            }

            var ruleCriteriaList = ruleLogic.GetRuleCriteriaList();

            foreach (var item in ruleCriteriaList)
            {
                rvm.RuleCriteriaList.Add(new SelectListItem()
                {
                    Text = item.DESCRIPTION,
                    Value = item.ID.ToString()
                });
            }

            var ruleActionList = ruleActionLogic.GetRuleActionList();

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
                ruleViewModel.Rule.CREATED_USER_ID = SessionUser.USER_ID;
                ruleViewModel.Rule.CREATED_DATE = DateTime.Now;
                success = ruleLogic.InsertRule(ruleViewModel.Rule);
            }
            else
            {
                ruleViewModel.Rule.RULE_ID = Convert.ToInt32(id);
                ruleViewModel.Rule.UPDATED_USER_ID = SessionUser.USER_ID;
                ruleViewModel.Rule.UPDATED_DATE = DateTime.Now;
                success = ruleLogic.UpdateRule(ruleViewModel.Rule);
                if (success == false)
                {
                    ShowErrorToastMessage();
                    return RedirectToAction("RuleDefinition", "Rules");
                }
            }

            var ruleDetailList = ruleLogic.GetRuleDetailByRuleId(ruleViewModel.Rule.RULE_ID);

            foreach (var item in ruleDetailList)
            {
                success = ruleLogic.DeleteRuleDetail(item.RULE_DETAIL_ID);
                if (success == false)
                {
                    ShowErrorToastMessage();
                    return RedirectToAction("RuleDefinition", "Rules");
                }
            }

            foreach (var item in ruleViewModel.PostRuleList)
            {
                item.RULE_ID = ruleViewModel.Rule.RULE_ID;
                item.CREATED_USER_ID = SessionUser.USER_ID;
                success = ruleLogic.InsertRuleDetail(item);
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
            var ruleList = ruleLogic.GetRuleList();

            RuleViewModel rvm = new RuleViewModel();

            rvm.RuleList = ruleList;

            foreach (var item in rvm.RuleList)
            {
                if (item.RULE_ACTION == "GROUP")
                {
                    item.RULE_ACTION_DATA = groupLogic.GetGroup(Convert.ToInt32(item.RULE_ACTION_DATA)).GROUP_NAME;
                }
                else if (item.RULE_ACTION == "USER")
                {
                    var user = userLogic.GetUser(Convert.ToInt32(item.RULE_ACTION_DATA));
                    item.RULE_ACTION_DATA = user.NAME + " " + user.SURNAME;
                }
                else if (item.RULE_ACTION == "CATEGORY")
                {
                    item.RULE_ACTION_DATA = parameterLogic.GetParameter(Convert.ToInt32(item.RULE_ACTION_DATA)).MAIN_DATA_NAME;
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
                item.RULE_ACTION = ruleActionLogic.GetRuleAction(item.RULE_ACTION).ACTION_NAME;
            }

            return View(rvm);
        }

    }
}
