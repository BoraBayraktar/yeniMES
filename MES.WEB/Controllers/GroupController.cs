using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MES.Web.Models;
using MES.Web.Model;
using MES.Web.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

namespace MES.Web.Controllers
{
    public class GroupController : BaseController
    {
        #region Instance
        ServiceBusiness serviceBusiness;
        //GroupLogic groupLogic = new GroupLogic();
        //WorkingScheduleLogic workingScheduleLogic = new WorkingScheduleLogic();
        //GroupExpertLogic groupExpertLogic = new GroupExpertLogic();
        #endregion
        public GroupController(IConfiguration configuration, IHttpContextAccessor accessor)
        {
            serviceBusiness = new ServiceBusiness(configuration, accessor);
        }

        #region Group
        public IActionResult GroupList()
        {
            var groupList = serviceBusiness.ServiceGet<List<GROUP>>("Group", "GroupGetList");
            var workingScheduleList = serviceBusiness.ServiceGet<List<WORKING_SCHEDULE>>("WorkingSchedule", "WorkingScheduleGetList");
            GroupViewModel gvm = new GroupViewModel();
            gvm.groupList = groupList;

            foreach (var item in groupList)
            {
                var businessHoursList = item.BUSINESS_HOURS.Split(',');
                var businessHoursName = "";
                var businessHoursCount = businessHoursList.Length;
                int i = 1;
                foreach (var bItem in businessHoursList)
                {
                    int bhItem = Convert.ToInt32(bItem);
                    businessHoursName += workingScheduleList.FirstOrDefault(q => q.WORKING_SCHEDULE_ID == bhItem).NAME;
                    if (businessHoursCount != i)
                    {
                        businessHoursName += ", ";
                    }
                    i += 1;
                }
                item.BUSINESS_HOURS = businessHoursName;
            }

            return View(gvm);
        }
        public IActionResult Group(int? id)
        {
            var groupList = serviceBusiness.ServiceGet<List<GROUP>>("Group", "GroupGetList");
            var managerList = serviceBusiness.ServiceGet<List<USER>>("Group", "GetGroupManager");
            var typeList = serviceBusiness.ServiceGet<List<GROUP_TYPE>>("Group", "GetGroupType");
            var workingScheduleList = serviceBusiness.ServiceGet<List<WORKING_SCHEDULE>>("WorkingSchedule", "WorkingScheduleGetList");
            var expertList = serviceBusiness.ServiceGet<List<USER>>("Group", "GetExpert");
            GroupViewModel gvm = new GroupViewModel();

            if (id != null)
            {
                var sc1 = serviceBusiness.ServicePost<GROUP>(Convert.ToInt32(id), "Group", "GetGroup");
                gvm.group = sc1;
            }
            foreach (var item in managerList)
            {
                gvm.groupManagerList.Add(new SelectListItem()
                {
                    Text = item.NAME + " " + item.SURNAME,
                    Value = item.USER_ID.ToString()
                });
            }
            foreach (var item in typeList)
            {
                gvm.groupTypeList.Add(new SelectListItem()
                {
                    Text = item.TYPE_NAME,
                    Value = item.ID.ToString()
                });
            }
            foreach (var item in groupList)
            {
                var businessHoursList = item.BUSINESS_HOURS.Split(',');
                var businessHoursName = "";
                var businessHoursCount = businessHoursList.Length;
                int i = 1;
                if (businessHoursList.Length < 1)
                {
                    foreach (var bItem in businessHoursList)
                    {
                        int bhItem = Convert.ToInt32(bItem);
                        businessHoursName += workingScheduleList.FirstOrDefault(q => q.WORKING_SCHEDULE_ID == bhItem).NAME;
                        if (businessHoursCount != i)
                        {
                            businessHoursName += ", ";
                        }
                        i += 1;
                    }
                    item.BUSINESS_HOURS = businessHoursName;
                }
            }
            foreach (var item in workingScheduleList)
            {
                gvm.BusinessHourList.Add(new SelectListItem()
                {
                    Text = item.NAME,
                    Value = item.WORKING_SCHEDULE_ID.ToString()
                });
            }
            foreach (var item in expertList)
            {
                gvm.groupExpertList.Add(new SelectListItem()
                {
                    Text = item.NAME + " " + item.SURNAME,
                    Value = item.USER_ID.ToString()
                });
            }
            if (id != null)
            {
                var tm = serviceBusiness.ServicePost<GROUP>(Convert.ToInt32(id), "Group", "GetGroup");

                if (!String.IsNullOrEmpty(tm.BUSINESS_HOURS))
                {
                    gvm.SelectedBusinessHour = tm.BUSINESS_HOURS.Split(',');
                }

            }


            var expertList_ = serviceBusiness.ServicePost<List<GROUP_EXPERT>>(Convert.ToInt32(id),"GroupExpert", "GetExpertListByGrpId"); 
            gvm.ExpertList = expertList_;

            return View(gvm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Group(int? id, GroupViewModel groupViewModel)
        {
            var user = HttpContext.Session.GetObject<USER>("User");

            bool success = false;
            int i = 1;
            GROUP group = new GROUP();
            group.GROUP_NAME = groupViewModel.group.GROUP_NAME;
            group.GROUP_MANAGER_ID = groupViewModel.group.GROUP_MANAGER_ID;
            group.GROUP_ASSIGNTYPE_ID = groupViewModel.group.GROUP_ASSIGNTYPE_ID;
            group.GROUP_TYPE_ID = groupViewModel.group.GROUP_TYPE_ID;
            group.GROUP_ISACTIVE = groupViewModel.group.GROUP_ISACTIVE;
            group.GROUP_DESCRIPTION = groupViewModel.group.GROUP_DESCRIPTION;
            group.BUSINESS_HOURS = groupViewModel.group.BUSINESS_HOURS;

            int bHourCount = groupViewModel.SelectedBusinessHour.Length;

            foreach (var item in groupViewModel.SelectedBusinessHour)
            {
                group.BUSINESS_HOURS += item;
                if (i != bHourCount)
                {
                    group.BUSINESS_HOURS += ",";
                }
                i++;
            }

            group.GROUP_ISACTIVE = groupViewModel.group.GROUP_ISACTIVE;

            if (id == null)
            {
                //group.CREATED_USER_ID = user.USER_ID;
                success = serviceBusiness.ServicePost<bool>(group, "Group", "InsertGroup"); 
            }
            else
            {
                group.ID = Convert.ToInt32(id);
                //group.UPDATED_USER_ID = user.USER_ID;
                success = serviceBusiness.ServicePost<bool>(group, "Group", "UpdateGroup");
            }

            var expertList = serviceBusiness.ServicePost<List<GROUP_EXPERT>>(Convert.ToInt32(id), "GroupExpert", "GetExpertListByGrpId");

            foreach (var item in expertList)
            {
                var exp = groupViewModel.PostExpert.FirstOrDefault(q => q.ID == item.ID);
                if (exp == null)
                {
                    success = serviceBusiness.ServicePost<bool>(item.ID, "Group", "DeleteGroup");
                }
            }

            foreach (var item in groupViewModel.PostExpert)
            {
                item.GROUP_ID = group.ID;
                if (item.ID == 0)
                {
                    //item.CREATED_USER_ID = user.USER_ID;
                    success = serviceBusiness.ServicePost<bool>(item, "GroupExpert", "InsertGroupExpert");
                }
                else
                {
                    //item.UPDATED_USER_ID = user.USER_ID;
                    success = serviceBusiness.ServicePost<bool>(item, "GroupExpert", "InsertGroupExpert");
                }
            }

            ShowSuccessToastMessage();
            return RedirectToAction("GroupList", "Group");
        }
        [HttpPost]
        public JsonResult CreateOrEditGroup(int? id, GroupViewModel groupViewModel)
        {
            var user = HttpContext.Session.GetObject<USER>("User");

            bool success = false;

            GROUP grp = new GROUP();
            int i = 1;
            int bHourCount = groupViewModel.SelectedBusinessHour.Length;

            i = 1;
            foreach (var item in groupViewModel.SelectedBusinessHour)
            {
                grp.BUSINESS_HOURS += item;
                if (i != bHourCount)
                {
                    grp.BUSINESS_HOURS += ",";
                }
                i++;
            }

            grp.GROUP_ISACTIVE = groupViewModel.group.GROUP_ISACTIVE;


            if (id == null)
            {
                //grp.CREATED_USER_ID = user.USER_ID;
                success = serviceBusiness.ServicePost<bool>(grp, "Group", "InsertGroup");
            }
            else
            {
                grp.ID = Convert.ToInt32(id);
               // grp.UPDATED_USER_ID = user.USER_ID;
                success = serviceBusiness.ServicePost<bool>(grp, "Group", "UpdateGroup");
            }
            return Json(new { success = success });
        }
        [HttpPost]
        public JsonResult DeleteGroup(int deleteId)
        {
            bool success = false;
            success = serviceBusiness.ServicePost<bool>(deleteId, "Group", "DeleteGroup");
            return Json(new { success = success });
        }
        public JsonResult GetGroup(int id)
        {
            var tm = serviceBusiness.ServicePost<GROUP>(id, "Group", "GetGroup");
            return Json(tm);
        }
        #endregion

        #region GroupExpert
        public JsonResult GetGroupExpert(int groupId)
        {
            var expertList = serviceBusiness.ServicePost<List<GROUP_EXPERT>>(groupId, "GroupExpert", "GetExpertListByGrpId");
            return Json(expertList);
        }
        [HttpPost]
        public JsonResult DeleteExpert(int expertDeleteId)
        {
            bool success = false;
            success = serviceBusiness.ServicePost<bool>(expertDeleteId, "GroupExpert", "DeleteGroupExpert");
            return Json(new { success = success });
        }
        [HttpPost]
        public JsonResult CreateOrEditExpert(int? expertId, int grpId, GROUP_EXPERT expert)
        {
            var user = HttpContext.Session.GetObject<USER>("User");

            expert.GROUP_ID = grpId;

            bool success = false;
            if (expertId == null)
            {
                //expert.CREATED_USER_ID = user.USER_ID;
                success = serviceBusiness.ServicePost<bool>(expert, "GroupExpert", "InsertGroupExpert");
            }
            else
            {
                expert.ID = Convert.ToInt32(expertId);
                //expert.UPDATED_USER_ID = user.USER_ID;
                success = serviceBusiness.ServicePost<bool>(expert, "GroupExpert", "UpdateGroupExpert");
            }
            return Json(new { success = success });
        }
        public JsonResult GetExpert(int id)
        {
            var expert = serviceBusiness.ServicePost<GROUP_EXPERT>(id, "GroupExpert", "GetExpert");
            return Json(expert);
        }
        public JsonResult GetExpertListByExpId(int id)
        {
            var expert = serviceBusiness.ServicePost<List<USER>>(id,"Group", "GetExpertListByExpId");// groupLogic.GetExpertListByExpId(id);
            return Json(expert);
        }
        #endregion
    }
}
