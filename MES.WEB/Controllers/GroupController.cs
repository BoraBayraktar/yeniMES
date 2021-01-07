//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using MES.Web.Models;
//using MES.Entities.Model;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using MES.Business;

//namespace MES.Web.Controllers
//{
//    public class GroupController : BaseController
//    {
//        GroupLogic groupLogic = new GroupLogic();
//        WorkingScheduleLogic workingScheduleLogic = new WorkingScheduleLogic();
//        GroupExpertLogic groupExpertLogic = new GroupExpertLogic();

//        public IActionResult GroupList()
//        {
//            var groupList = groupLogic.GetList();
//            var workingScheduleList = workingScheduleLogic.GetList();
//            GroupViewModel gvm = new GroupViewModel();
//            gvm.groupList = groupList;

//            foreach (var item in groupList)
//            {
//                var businessHoursList = item.BUSINESS_HOURS.Split(',');
//                var businessHoursName = "";
//                var businessHoursCount = businessHoursList.Length;
//                int i = 1;
//                foreach (var bItem in businessHoursList)
//                {
//                    int bhItem = Convert.ToInt32(bItem);
//                    businessHoursName += workingScheduleList.FirstOrDefault(q => q.WORKING_SCHEDULE_ID == bhItem).NAME;
//                    if (businessHoursCount != i)
//                    {
//                        businessHoursName += ", ";
//                    }
//                    i += 1;
//                }
//                item.BUSINESS_HOURS = businessHoursName;
//            }

//            return View(gvm);
//        }
//        public IActionResult Group(int? id)
//        {
//            var groupList = groupLogic.GetList();
//            var managerList = groupLogic.GetGroupManager();
//            var typeList = groupLogic.GetGroupType();
//            var workingScheduleList = workingScheduleLogic.GetList();
//            var expertList = groupLogic.GetExpert();
//            GroupViewModel gvm = new GroupViewModel();

//            if (id != null)
//            {
//                var sc1 = groupLogic.GetGroup(Convert.ToInt32(id));
//                gvm.group = sc1;
//            }
//            foreach (var item in managerList)
//            {
//                gvm.groupManagerList.Add(new SelectListItem()
//                {
//                    Text = item.NAME + " " + item.SURNAME,
//                    Value = item.USER_ID.ToString()
//                });
//            }
//            foreach (var item in typeList)
//            {
//                gvm.groupTypeList.Add(new SelectListItem()
//                {
//                    Text = item.TYPE_NAME,
//                    Value = item.ID.ToString()
//                });
//            }
//            foreach (var item in groupList)
//            {
//                var businessHoursList = item.BUSINESS_HOURS.Split(',');
//                var businessHoursName = "";
//                var businessHoursCount = businessHoursList.Length;
//                int i = 1;
//                if (businessHoursList.Length < 1)
//                {
//                    foreach (var bItem in businessHoursList)
//                    {
//                        int bhItem = Convert.ToInt32(bItem);
//                        businessHoursName += workingScheduleList.FirstOrDefault(q => q.WORKING_SCHEDULE_ID == bhItem).NAME;
//                        if (businessHoursCount != i)
//                        {
//                            businessHoursName += ", ";
//                        }
//                        i += 1;
//                    }
//                    item.BUSINESS_HOURS = businessHoursName;
//                }               
//            }
//            foreach (var item in workingScheduleList)
//            {
//                gvm.BusinessHourList.Add(new SelectListItem()
//                {
//                    Text = item.NAME,
//                    Value = item.WORKING_SCHEDULE_ID.ToString()
//                });
//            }
//            foreach (var item in expertList)
//            {
//                gvm.groupExpertList.Add(new SelectListItem()
//                {
//                    Text = item.NAME + " " + item.SURNAME,
//                    Value = item.USER_ID.ToString()
//                });
//            }
//            if (id != null)
//            {
//                var tm = groupLogic.GetGroup(Convert.ToInt32(id));

//                if (!String.IsNullOrEmpty(tm.BUSINESS_HOURS))
//                {
//                    gvm.SelectedBusinessHour = tm.BUSINESS_HOURS.Split(',');
//                }

//            }


//            var expertList_ = groupExpertLogic.GetExpertListByGrpId(Convert.ToInt32(id));
//            gvm.ExpertList = expertList_;

//            return View(gvm);
//        }
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Group(int? id, GroupViewModel groupViewModel)
//        {
//            var user = HttpContext.Session.GetObject<USER>("User");

//            bool success = false;
//            int i = 1;
//            GROUP group = new GROUP();
//            group.GROUP_NAME = groupViewModel.group.GROUP_NAME;
//            group.GROUP_MANAGER_ID = groupViewModel.group.GROUP_MANAGER_ID;
//            group.GROUP_ASSIGNTYPE_ID = groupViewModel.group.GROUP_ASSIGNTYPE_ID;
//            group.GROUP_TYPE_ID = groupViewModel.group.GROUP_TYPE_ID;
//            group.GROUP_ISACTIVE = groupViewModel.group.GROUP_ISACTIVE;
//            group.GROUP_DESCRIPTION = groupViewModel.group.GROUP_DESCRIPTION;
//            group.BUSINESS_HOURS = groupViewModel.group.BUSINESS_HOURS;

//            int bHourCount = groupViewModel.SelectedBusinessHour.Length;

//            foreach (var item in groupViewModel.SelectedBusinessHour)
//            {
//                group.BUSINESS_HOURS += item;
//                if (i != bHourCount)
//                {
//                    group.BUSINESS_HOURS += ",";
//                }
//                i++;
//            }

//            group.GROUP_ISACTIVE = groupViewModel.group.GROUP_ISACTIVE;

//            if (id == null)
//            {
//                group.CREATED_USER_ID = user.USER_ID;
//                success = groupLogic.InsertGroup(group);
//            }
//            else
//            {
//                group.ID = Convert.ToInt32(id);
//                group.UPDATED_USER_ID = user.USER_ID;
//                success = groupLogic.UpdateGroup(group);
//            }

//            var expertList = groupExpertLogic.GetExpertListByGrpId(group.ID);

//            foreach (var item in expertList)
//            {
//                var exp = groupViewModel.PostExpert.FirstOrDefault(q => q.ID == item.ID);
//                if (exp == null)
//                {
//                    success = groupExpertLogic.DeleteExpert(item.ID);
//                }
//            }

//            foreach (var item in groupViewModel.PostExpert)
//            {
//                item.GROUP_ID = group.ID;
//                if (item.ID == 0)
//                {
//                    item.CREATED_USER_ID = user.USER_ID;
//                    success = groupExpertLogic.InsertExpert(item);
//                }
//                else
//                {
//                    item.UPDATED_USER_ID = user.USER_ID;
//                    success = groupExpertLogic.UpdateExpert(item);
//                }
//            }

//            ShowSuccessToastMessage();
//            return RedirectToAction("GroupList", "Group");
//        }
//        [HttpPost]
//        public JsonResult CreateOrEditGroup(int? id, GroupViewModel groupViewModel)
//        {
//            var user = HttpContext.Session.GetObject<USER>("User");

//            bool success = false;

//            GROUP grp = new GROUP();
//            int i = 1;
//            int bHourCount = groupViewModel.SelectedBusinessHour.Length;

//            i = 1;
//            foreach (var item in groupViewModel.SelectedBusinessHour)
//            {
//                 grp.BUSINESS_HOURS += item;
//                 if (i != bHourCount)
//                 {
//                    grp.BUSINESS_HOURS += ",";
//                 }
//                 i++;   
//            }      

//            grp.GROUP_ISACTIVE = groupViewModel.group.GROUP_ISACTIVE;


//            if (id == null)
//            {
//                grp.CREATED_USER_ID = user.USER_ID;
//                success = groupLogic.InsertGroup(grp);
//            }
//            else
//            {
//                grp.ID = Convert.ToInt32(id);
//                grp.UPDATED_USER_ID = user.USER_ID;
//                success = groupLogic.UpdateGroup(grp);
//            }
//            return Json(new { success = success });
//        }
//        [HttpPost]
//        public JsonResult DeleteGroup(int deleteId)
//        {
//            bool success = false;
//            success = groupLogic.DeleteGroup(deleteId);
//            return Json(new { success = success });
//        }
//        public JsonResult GetGroup(int id)
//        {
//            var tm = groupLogic.GetGroup(id);
//            return Json(tm);
//        }


//        #region GroupExpert
//        public JsonResult GetGroupExpert(int groupId)
//        {
//            var expertList = groupExpertLogic.GetExpertListByGrpId(groupId);
//            return Json(expertList);
//        }
//        [HttpPost]
//        public JsonResult DeleteExpert(int expertDeleteId)
//        {
//            bool success = false;
//            success = groupExpertLogic.DeleteExpert(expertDeleteId);
//            return Json(new { success = success });
//        }
//        [HttpPost]
//        public JsonResult CreateOrEditExpert(int? expertId, int grpId, GROUP_EXPERT expert)
//        {
//            var user = HttpContext.Session.GetObject<USER>("User");

//            expert.GROUP_ID = grpId;

//            bool success = false;
//            if (expertId == null)
//            {
//                expert.CREATED_USER_ID = user.USER_ID;
//                success = groupExpertLogic.InsertExpert(expert);
//            }
//            else
//            {
//                expert.ID = Convert.ToInt32(expertId);
//                expert.UPDATED_USER_ID = user.USER_ID;
//                success = groupExpertLogic.UpdateExpert(expert);
//            }
//            return Json(new { success = success });
//        }
//        public JsonResult GetExpert(int id)
//        {
//            var expert = groupExpertLogic.GetExpert(id);
//            return Json(expert);
//        }
//        public JsonResult GetExpertListByExpId(int id)
//        {
//            var expert = groupLogic.GetExpertListByExpId(id);
//            return Json(expert);
//        }
//        #endregion
//    }
//}
