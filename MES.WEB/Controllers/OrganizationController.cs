﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MES.Web.Model;
using MES.Web.Models;
using MES.Web.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MES.Web.Controllers
{
    [Authorize]
    public class OrganizationController : BaseController
    {
        #region Instance
        private IHostingEnvironment _hostingEnvironment;
        ServiceBusiness serviceBusiness = new ServiceBusiness();

        #endregion

        public OrganizationController(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
        }

        #region Holding
        public IActionResult Holding()
        {
            var holdingList = serviceBusiness.ServiceGet<List<HOLDING>>("Organization", "HoldingGetList");
            HoldingViewModel hvm = new HoldingViewModel();
            hvm.HoldingList = holdingList;
            return View(hvm);
        }
        //[HttpPost]
        public JsonResult CreateOrEditHolding(int? id, HOLDING holding)
        {
            var user = HttpContext.Session.GetObject<USER>("User");

            bool success = false;
            if (id == null)
            {
                //holding.CREATED_USER_ID = user.USER_ID;
                success = serviceBusiness.ServicePost<bool>(holding,"Organization", "InsertHolding");
            }
            else
            {
                holding.HOLDING_ID = Convert.ToInt32(id);
                //holding.UPDATED_USER_ID = user.USER_ID;
                success = serviceBusiness.ServicePost<bool>(holding, "Organization", "UpdateHolding");
            }
            return Json(new { success = success });
        }
        //[HttpPost]
        public JsonResult DeleteHolding(int deleteId)
        {
            bool success = false;
            success = serviceBusiness.ServicePost<bool>(deleteId, "Organization", "DeleteHolding");
            return Json(new { success = success });
        }

        public JsonResult GetHolding(int id)
        {
            var holding = serviceBusiness.ServicePost<HOLDING>(id, "Organization", "GetHolding");
            return Json(holding);
        }
        #endregion

        #region Company
        public IActionResult Company()
        {
            var companyList = serviceBusiness.ServiceGet<List<COMPANY>>("Organization", "CompanyGetList");
            var holdingList = serviceBusiness.ServiceGet<List<HOLDING>>("Organization", "HoldingGetList");
            CompanyViewModel cvm = new CompanyViewModel();
            cvm.HoldingSelectList = new List<SelectListItem>();
            cvm.CompanyList = companyList;
            foreach (var item in holdingList)
            {
                cvm.HoldingSelectList.Add(new SelectListItem()
                {
                    Text = item.NAME,
                    Value = item.HOLDING_ID.ToString()
                });
            }

            return View(cvm);
        }
        [HttpPost]
        public JsonResult CreateOrEditCompany(int? id, COMPANY company)
        {
            var user = HttpContext.Session.GetObject<USER>("User");

            bool success = false;
            if (id == null)
            {
                //company.CREATED_USER_ID = user.USER_ID;
                success = serviceBusiness.ServicePost<bool>(company, "Organization", "InsertCompany");
            }
            else
            {
                company.COMPANY_ID = Convert.ToInt32(id);
                //company.UPDATED_USER_ID = user.USER_ID;
                success = serviceBusiness.ServicePost<bool>(company, "Organization", "UpdateCompany");
            }
            return Json(new { success = success });
        }
        [HttpPost]
        public JsonResult DeleteCompany(int deleteId)
        {
            bool success = false;
            success = serviceBusiness.ServicePost<bool>(deleteId, "Organization", "DeleteCompany");
            return Json(new { success = success });
        }

        public JsonResult GetCompany(int id)
        {
            var company = serviceBusiness.ServicePost<COMPANY>(id, "Organization", "GetCompany");
            return Json(company);
        }
        #endregion

        #region Department
        public IActionResult Department()
        {
            var departmentList = serviceBusiness.ServiceGet<List<DEPARTMENT>>("Organization", "DepartmentGetList");
            var companyList = serviceBusiness.ServiceGet<List<COMPANY>>("Organization", "CompanyGetList");
            DepartmentViewModel dvm = new DepartmentViewModel();
            dvm.CompanySelectList = new List<SelectListItem>();
            dvm.DepartmentList = departmentList;
            foreach (var item in companyList)
            {
                dvm.CompanySelectList.Add(new SelectListItem()
                {
                    Text = item.NAME,
                    Value = item.COMPANY_ID.ToString()
                });
            }

            return View(dvm);
        }
        //[HttpPost]
        public JsonResult CreateOrEditDepartment(int? id, DEPARTMENT department)
        {
            var user = HttpContext.Session.GetObject<USER>("User");

            bool success = false;
            if (id == null)
            {
                //department.CREATED_USER_ID = user.USER_ID;
                success = serviceBusiness.ServicePost<bool>(department,"Organization", "InsertDepartment");
            }
            else
            {
                department.DEPARTMENT_ID = Convert.ToInt32(id);
                //department.UPDATED_USER_ID = user.USER_ID;
                success = serviceBusiness.ServicePost<bool>(department, "Organization", "UpdateDepartment");
            }
            return Json(new { success = success });
        }
        //[HttpPost]
        public JsonResult DeleteDepartment(int deleteId)
        {
            bool success = false;
            success = serviceBusiness.ServicePost<bool>(deleteId, "Organization", "DeleteDepartment");
            return Json(new { success = success });
        }

        public JsonResult GetDepartment(int id)
        {
            var department = serviceBusiness.ServicePost<DEPARTMENT>(id, "Organization", "GetDepartment");
            return Json(department);
        }
        #endregion

        #region Title
        public IActionResult Title()
        {
            var titleList = serviceBusiness.ServiceGet<List<TITLE>>("Organization","TitleGetList");
            TitleViewModel tvm = new TitleViewModel();
            tvm.TitleList = titleList;

            return View(tvm);
        }
        //[HttpPost]
        public JsonResult CreateOrEditTitle(int? id, TITLE title)
        {
            var user = HttpContext.Session.GetObject<USER>("User");

            bool success = false;
            if (id == null)
            {
                //title.CREATED_USER_ID = user.USER_ID;
                success = serviceBusiness.ServicePost<bool>(title, "Organization", "InsertTitle");
            }
            else
            {
                title.TITLE_ID = Convert.ToInt32(id);
                //title.UPDATED_USER_ID = user.USER_ID;
                success = serviceBusiness.ServicePost<bool>(title, "Organization", "UpdateTitle");
            }
            return Json(new { success = success });
        }
        //[HttpPost]
        public JsonResult DeleteTitle(int deleteId)
        {
            bool success = false;
            success = serviceBusiness.ServicePost<bool>(deleteId, "Organization", "DeleteTitle");
            return Json(new { success = success });
        }

        public JsonResult GetTitle(int id)
        {
            var title = serviceBusiness.ServicePost<TITLE>(id, "Organization", "GetTitle");
            return Json(title);
        }
        #endregion

        #region Location
        public IActionResult Location()
        {
            var locationList = serviceBusiness.ServiceGet<List<LOCATION>>("Organization", "LocationGetList");
            var cityList = serviceBusiness.ServiceGet<List<CITY>>("Organization", "CityGetList");
            LocationViewModel lvm = new LocationViewModel();
            lvm.LocationList = locationList;
            lvm.CitySelectList = new List<SelectListItem>();
            foreach (var item in cityList)
            {
                lvm.CitySelectList.Add(new SelectListItem()
                {
                    Text = item.NAME,
                    Value = item.CITY_ID.ToString()
                });
            }

            return View(lvm);
        }
        //[HttpPost]
        public JsonResult CreateOrEditLocation(int? id, LOCATION location)
        {
            var user = HttpContext.Session.GetObject<USER>("User");

            bool success = false;
            if (id == null)
            {
                //location.CREATED_USER_ID = user.USER_ID;
                success = serviceBusiness.ServicePost<bool>(location, "Organization", "InsertLocation");
            }
            else
            {
                location.LOCATION_ID = Convert.ToInt32(id);
                //location.UPDATED_USER_ID = user.USER_ID;
                success = success = serviceBusiness.ServicePost<bool>(location, "Organization", "UpdateLocation");
            }
            return Json(new { success = success });
        }
        [HttpPost]
        public JsonResult DeleteLocation(int deleteId)
        {
            bool success = false;
            success = serviceBusiness.ServicePost<bool>(deleteId, "Organization", "DeleteLocation");
            return Json(new { success = success });
        }

        public JsonResult GetLocation(int id)
        {
            var location = serviceBusiness.ServicePost<LOCATION>(id, "Organization", "GetLocation");
            return Json(location);
        }
        #endregion

        #region UserGroup
        public IActionResult UserGroup()
        {
            var userGroupList = serviceBusiness.ServiceGet<List<USER_GROUP>>("Organization", "UserGroupGetList");
            UserGroupViewModel uvm = new UserGroupViewModel();
            uvm.UserGroupList = userGroupList;

            return View(uvm);
        }
        //[HttpPost]
        public JsonResult CreateOrEditUserGroup(int? id, USER_GROUP userGroup)
        {
            var user = HttpContext.Session.GetObject<USER>("User");

            bool success = false;
            if (id == null)
            {
                //userGroup.CREATED_USER_ID = user.USER_ID;
                success = serviceBusiness.ServicePost<bool>(userGroup, "Organization", "InsertUserGroup");
            }
            else
            {
                userGroup.USER_GROUP_ID = Convert.ToInt32(id);
                //userGroup.UPDATED_USER_ID = user.USER_ID;
                success = serviceBusiness.ServicePost<bool>(userGroup, "Organization", "UpdateUserGroup");
            }
            return Json(new { success = success });
        }
        //[HttpPost]
        public JsonResult DeleteUserGroup(int deleteId)
        {
            bool success = false;
            success = serviceBusiness.ServicePost<bool>(deleteId, "Organization", "DeleteUserGroup");
            return Json(new { success = success });
        }

        public JsonResult GetUserGroup(int id)
        {
            var userGroup = serviceBusiness.ServicePost<USER_GROUP>(id, "Organization", "GetUserGroup");
            return Json(userGroup);
        }
        #endregion

        #region Users
        public IActionResult Users()
        {
            var userList = serviceBusiness.ServiceGet<List<USER>>("Organization", "UserGetList");
            var departmentList = serviceBusiness.ServiceGet<List<DEPARTMENT>>("Organization","DepartmentGetList");
            var locationList = serviceBusiness.ServiceGet<List<LOCATION>>("Organization", "LocationGetList");
            var titleList = serviceBusiness.ServiceGet<List<TITLE>>("Organization", "TitleGetList");
            var userGroupList = serviceBusiness.ServiceGet<List<USER_GROUP>>("Organization", "UserGroupGetList");
            var userTypeList = serviceBusiness.ServiceGet<List<USER_TYPE>>("Organization", "UserTypeGetList");


            UserViewModel uvm = new UserViewModel();
            uvm.UserList = userList;

            foreach (var item in departmentList)
            {
                uvm.DepartmentSelectList.Add(new SelectListItem()
                {
                    Text = item.NAME,
                    Value = item.DEPARTMENT_ID.ToString()
                });
            }
            foreach (var item in locationList)
            {
                uvm.LocationSelectList.Add(new SelectListItem()
                {
                    Text = item.NAME,
                    Value = item.LOCATION_ID.ToString()
                });
            }
            foreach (var item in titleList)
            {
                uvm.TitleSelectList.Add(new SelectListItem()
                {
                    Text = item.NAME,
                    Value = item.TITLE_ID.ToString()
                });
            }
            foreach (var item in userGroupList)
            {
                uvm.UserGroupSelectList.Add(new SelectListItem()
                {
                    Text = item.NAME,
                    Value = item.USER_GROUP_ID.ToString()
                });
            }
            foreach (var item in userTypeList)
            {
                uvm.UserTypeSelectList.Add(new SelectListItem()
                {
                    Text = item.NAME,
                    Value = item.USER_TYPE_ID.ToString()
                });
            }

            return View(uvm);
        }
        //[HttpPost]
        public JsonResult CreateOrEditUser(int? id, USER user, IFormFile imageFile)
        {
            bool success = false;

            var currentUser = HttpContext.Session.GetObject<USER>("User");
            if (imageFile != null)
            {
                var uploads = Path.Combine(_hostingEnvironment.ContentRootPath, @"Content/images/user");
                //var fileName = ContentDispositionHeaderValue.Parse(imageFile.ContentDisposition).FileName.Trim('"');
                //var fileName = Path.GetFileName(imageFile.FileName);
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(uploads, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(fileStream);
                }
                user.IMAGE_PATH = "/Content/images/user/" + fileName;

            }

            if (id == null)
            {
                //user.CREATED_USER_ID = currentUser.USER_ID;
                success = serviceBusiness.ServicePost<bool>(user, "Organization", "InsertUser");
            }
            else
            {
                //user.UPDATED_USER_ID = currentUser.USER_ID;
                user.USER_ID = Convert.ToInt32(id);
                success = serviceBusiness.ServicePost<bool>(user, "Organization", "UpdateUser");
            }
            return Json(new { success = success });
        }
        //[HttpPost]
        public JsonResult DeleteUser(int deleteId)
        {
            bool success = false;
            success = serviceBusiness.ServicePost<bool>(deleteId, "Organization", "DeleteUser");
            return Json(new { success = success });
        }

        public JsonResult GetUser(int id)
        {
            var user = serviceBusiness.ServicePost<USER>(id, "Organization","GetUser");
            return Json(user);
        }
        #endregion

        #region Leave
        public IActionResult Leave()
        {
            var leaveList = serviceBusiness.ServiceGet<List<LEAVE>>("Organization", "LeaveGetList");
            var leaveTypeList = serviceBusiness.ServiceGet<List<LEAVE_TYPE>>("Organization", "LeaveTypeGetList");
            var userList = serviceBusiness.ServiceGet<List<USER>>("Organization", "UserGetList");

            LeaveViewModel lvm = new LeaveViewModel();
            lvm.LeaveList = leaveList;
            foreach (var item in leaveTypeList)
            {
                lvm.LeaveTypeList.Add(new SelectListItem()
                {
                    Text = item.NAME,
                    Value = item.LEAVE_TYPE_ID.ToString()
                });
            }

            foreach (var item in userList)
            {
                lvm.UserList.Add(new SelectListItem()
                {
                    Text = item.NAME + " " + item.SURNAME,
                    Value = item.USER_ID.ToString()
                });
            }

            return View(lvm);
        }
        [HttpPost]
        public JsonResult CreateOrEditLeave(int? id, LEAVE leave)
        {
            var user = HttpContext.Session.GetObject<USER>("User");

            bool success = false;
            if (id == null)
            {
                //leave.CREATED_USER_ID = user.USER_ID;
                success = serviceBusiness.ServicePost<bool>(leave,"Organization", "InsertLeave");
            }
            else
            {
                //leave.UPDATED_USER_ID = user.USER_ID;
                leave.LEAVE_ID = Convert.ToInt32(id);
                success = serviceBusiness.ServicePost<bool>(leave, "Organization", "UpdateLeave");
            }
            return Json(new { success = success });
        }
        [HttpPost]
        public JsonResult DeleteLeave(int deleteId)
        {
            bool success = false;
            success = serviceBusiness.ServicePost<bool>(deleteId, "Organization", "DeleteLeave");
            return Json(new { success = success });
        }

        public JsonResult GetLeave(int id)
        {
            var leave = serviceBusiness.ServicePost<LEAVE>(id, "Organization", "GetLeave");
            return Json(leave);
        }
        #endregion

        #region WorkingSchedule
        public IActionResult WorkingSchedule()
        {
            var wsList = workingScheduleLogic.GetList();
            WorkingScheduleViewModel wsvm = new WorkingScheduleViewModel();
            wsvm.WorkingScheduleList = wsList;
            return View(wsvm);
        }
        [HttpPost]
        public JsonResult CreateOrEditWorkingSchedule(int? id, WORKING_SCHEDULE workingSchedule)
        {
            var user = HttpContext.Session.GetObject<USER>("User");

            bool success = false;
            if (id == null)
            {
                //workingSchedule.CREATED_USER_ID = user.USER_ID;

                success = serviceBusiness.ServicePost<bool>(workingSchedule, "Organization", "InsertWorkingSchedule");
            }
            else
            {
                workingSchedule.WORKING_SCHEDULE_ID = Convert.ToInt32(id);
                //workingSchedule.UPDATED_USER_ID = user.USER_ID;

                success = serviceBusiness.ServicePost<bool>(workingSchedule, "Organization", "UpdateWorkingSchedule");
            }
            return Json(new { success = success });
        }
        [HttpPost]
        public JsonResult DeleteWorkingSchedule(int deleteId)
        {
            bool success = false;
            success = workingScheduleLogic.DeleteWorkingSchedule(deleteId);
            return Json(new { success = success });
        }

        public JsonResult GetWorkingSchedule(int id)
        {
            var ws = workingScheduleLogic.GetWorkingSchedule(id);
            return Json(ws);
        }
        #endregion

        //        #region EmailSettings
        //        public IActionResult EmailSettings()
        //        {
        //            var emailSettings = emailSettingsLogic.GetList();
        //            EmailSettingsViewModel evm = new EmailSettingsViewModel();
        //            evm.MailServerSetup = emailSettings.FirstOrDefault();

        //            return View(evm);
        //        }

        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public IActionResult EmailSettings(MAIL_SERVER_SETUP mailServerSetup)
        //        {
        //            var currentUser = HttpContext.Session.GetObject<USER>("User");
        //            mailServerSetup.CREATED_USER_ID = currentUser.USER_ID;

        //            var emailSettings = emailSettingsLogic.InsertOrUpdateMailServerSetup(mailServerSetup);
        //            EmailSettingsViewModel evm = new EmailSettingsViewModel();
        //            evm.MailServerSetup = mailServerSetup;
        //            ShowSuccessToastMessage();
        //            return View(evm);
        //        }
        //        #endregion

        //        #region TimeManagement
        //        public IActionResult TimeManagement()
        //        {
        //            var timeManagementList = timeManagementLogic.GetList();
        //            var workingDaysList = workingDaysLogic.GetList();
        //            var workingScheduleList = workingScheduleLogic.GetList();
        //            var timezoneList = timeManagementLogic.GetTimezoneList();

        //            foreach (var item in timeManagementList)
        //            {
        //                var calendarDaysList = item.CALENDAR_DAYS.Split(',');
        //                var calendarDaysName = "";
        //                var calendarDaysCount = calendarDaysList.Length;
        //                int i = 1;
        //                foreach (var dayItem in calendarDaysList)
        //                {
        //                    calendarDaysName += workingDaysList.FirstOrDefault(q => q.CODE == dayItem).NAME;
        //                    if (calendarDaysCount != i)
        //                    {
        //                        calendarDaysName += ", ";
        //                    }
        //                    i += 1;
        //                }

        //                item.CALENDAR_DAYS = calendarDaysName;


        //                var businessHoursList = item.BUSINESS_HOURS.Split(',');
        //                var businessHoursName = "";
        //                var businessHoursCount = businessHoursList.Length;
        //                i = 1;
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

        //            TimeManagementViewModel tvm = new TimeManagementViewModel();
        //            tvm.TimeManagementList = timeManagementList;

        //            foreach (var item in workingDaysList)
        //            {
        //                tvm.WorkDaysList.Add(new SelectListItem()
        //                {
        //                    Text = item.NAME,
        //                    Value = item.CODE.ToString()
        //                });
        //            }

        //            foreach (var item in workingScheduleList)
        //            {
        //                tvm.BusinessHoursList.Add(new SelectListItem()
        //                {
        //                    Text = item.NAME,
        //                    Value = item.WORKING_SCHEDULE_ID.ToString()
        //                });
        //            }

        //            foreach (var item in timezoneList)
        //            {
        //                tvm.TimezoneList.Add(new SelectListItem()
        //                {
        //                    Text = item.NAME,
        //                    Value = item.ID.ToString()
        //                });
        //            }


        //            return View(tvm);
        //        }


        //        public IActionResult AddTimeManagement(int? id)
        //        {
        //            var timeManagementList = timeManagementLogic.GetList();
        //            var workingDaysList = workingDaysLogic.GetList();
        //            var workingScheduleList = workingScheduleLogic.GetList();
        //            var timezoneList = timeManagementLogic.GetTimezoneList();

        //            foreach (var item in timeManagementList)
        //            {
        //                var calendarDaysList = item.CALENDAR_DAYS.Split(',');
        //                var calendarDaysName = "";
        //                var calendarDaysCount = calendarDaysList.Length;
        //                int i = 1;
        //                foreach (var dayItem in calendarDaysList)
        //                {
        //                    calendarDaysName += workingDaysList.FirstOrDefault(q => q.CODE == dayItem).NAME;
        //                    if (calendarDaysCount != i)
        //                    {
        //                        calendarDaysName += ", ";
        //                    }
        //                    i += 1;
        //                }

        //                item.CALENDAR_DAYS = calendarDaysName;


        //                var businessHoursList = item.BUSINESS_HOURS.Split(',');
        //                var businessHoursName = "";
        //                var businessHoursCount = businessHoursList.Length;
        //                i = 1;
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

        //            TimeManagementViewModel tvm = new TimeManagementViewModel();
        //            tvm.TimeManagementList = timeManagementList;

        //            foreach (var item in workingDaysList)
        //            {
        //                tvm.WorkDaysList.Add(new SelectListItem()
        //                {
        //                    Text = item.NAME,
        //                    Value = item.CODE.ToString()
        //                });
        //            }

        //            foreach (var item in workingScheduleList)
        //            {
        //                tvm.BusinessHoursList.Add(new SelectListItem()
        //                {
        //                    Text = item.NAME,
        //                    Value = item.WORKING_SCHEDULE_ID.ToString()
        //                });
        //            }

        //            foreach (var item in timezoneList)
        //            {
        //                tvm.TimezoneList.Add(new SelectListItem()
        //                {
        //                    Text = item.NAME,
        //                    Value = item.ID.ToString()
        //                });
        //            }

        //            if (id != null)
        //            {
        //                var tm = timeManagementLogic.GetTimeManagement(Convert.ToInt32(id));
        //                tvm.CALENDAR_NAME = tm.CALENDAR_NAME;
        //                tvm.TIMEZONE_ID = tm.TIMEZONE_ID;
        //                tvm.ISACTIVE = tm.ISACTIVE;
        //                //tvm.CALENDAR_DAYS = tm.CALENDAR_DAYS;
        //                //tvm.BUSINESS_HOURS = tm.BUSINESS_HOURS;

        //                if (!String.IsNullOrEmpty(tm.CALENDAR_DAYS))
        //                {
        //                    tvm.SelectedWorkDays = tm.CALENDAR_DAYS.Split(',');
        //                }
        //                if (!String.IsNullOrEmpty(tm.BUSINESS_HOURS))
        //                {
        //                    tvm.SelectedBusinessHours = tm.BUSINESS_HOURS.Split(',');
        //                }

        //                var offDayList = timeManagementOffDaysLogic.GetOffDaysListByTmId(Convert.ToInt32(id));
        //                tvm.OffDaysList = offDayList;
        //            }




        //            return View(tvm);
        //        }

        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public ActionResult AddTimeManagement(int? id, TimeManagementViewModel timeManagement)
        //        {
        //            var user = HttpContext.Session.GetObject<USER>("User");

        //            bool success = false;

        //            TIME_MANAGEMENT tm = new TIME_MANAGEMENT();
        //            tm.CALENDAR_NAME = timeManagement.CALENDAR_NAME;
        //            int i = 1;
        //            int dayCount = timeManagement.SelectedWorkDays.Length;
        //            int bHourCount = timeManagement.SelectedBusinessHours.Length;

        //            foreach (var item in timeManagement.SelectedWorkDays)
        //            {
        //                tm.CALENDAR_DAYS += item;
        //                if (i != dayCount)
        //                {
        //                    tm.CALENDAR_DAYS += ",";
        //                }
        //                i++;
        //            }

        //            i = 1;
        //            foreach (var item in timeManagement.SelectedBusinessHours)
        //            {
        //                tm.BUSINESS_HOURS += item;
        //                if (i != bHourCount)
        //                {
        //                    tm.BUSINESS_HOURS += ",";
        //                }
        //                i++;
        //            }

        //            tm.TIMEZONE_ID = timeManagement.TIMEZONE_ID;
        //            tm.ISACTIVE = timeManagement.ISACTIVE;


        //            if (id == null)
        //            {
        //                tm.CREATED_USER_ID = user.USER_ID;
        //                success = timeManagementLogic.InsertTimeManagement(tm);
        //            }
        //            else
        //            {
        //                tm.ID = Convert.ToInt32(id);
        //                tm.UPDATED_USER_ID = user.USER_ID;
        //                success = timeManagementLogic.UpdateTimeManagement(tm);
        //            }

        //            var offDaysList = timeManagementOffDaysLogic.GetOffDaysListByTmId(tm.ID);

        //            foreach (var item in offDaysList)
        //            {
        //                var day = timeManagement.PostOffDays.FirstOrDefault(q => q.ID == item.ID);
        //                if (day == null)
        //                {
        //                    success = timeManagementOffDaysLogic.DeleteOffDays(item.ID);
        //                }
        //            }

        //            foreach (var item in timeManagement.PostOffDays)
        //            {
        //                item.TIME_MANAGEMENT_ID = tm.ID;
        //                if (item.ID == 0)
        //                {
        //                    item.CREATED_USER_ID = user.USER_ID;
        //                    success = timeManagementOffDaysLogic.InsertOffDays(item);
        //                }
        //                else
        //                {
        //                    item.UPDATED_USER_ID = user.USER_ID;
        //                    success = timeManagementOffDaysLogic.UpdateOffDays(item);
        //                }
        //            }

        //            ShowSuccessToastMessage();
        //            return RedirectToAction("TimeManagement", "Organization");
        //        }


        //        [HttpPost]
        //        public JsonResult CreateOrEditTimeManagement(int? id, TimeManagementViewModel timeManagement)
        //        {
        //            var user = HttpContext.Session.GetObject<USER>("User");

        //            bool success = false;

        //            TIME_MANAGEMENT tm = new TIME_MANAGEMENT();
        //            tm.CALENDAR_NAME = timeManagement.CALENDAR_NAME;
        //            int i = 1;
        //            int dayCount = timeManagement.SelectedWorkDays.Length;
        //            int bHourCount = timeManagement.SelectedBusinessHours.Length;

        //            foreach (var item in timeManagement.SelectedWorkDays)
        //            {
        //                tm.CALENDAR_DAYS += item;
        //                if (i != dayCount)
        //                {
        //                    tm.CALENDAR_DAYS += ",";
        //                }
        //                i++;
        //            }

        //            i = 1;
        //            foreach (var item in timeManagement.SelectedBusinessHours)
        //            {
        //                tm.BUSINESS_HOURS += item;
        //                if (i != bHourCount)
        //                {
        //                    tm.BUSINESS_HOURS += ",";
        //                }
        //                i++;
        //            }

        //            tm.TIMEZONE_ID = timeManagement.TIMEZONE_ID;
        //            tm.ISACTIVE = timeManagement.ISACTIVE;


        //            if (id == null)
        //            {
        //                tm.CREATED_USER_ID = user.USER_ID;
        //                success = timeManagementLogic.InsertTimeManagement(tm);
        //            }
        //            else
        //            {
        //                tm.ID = Convert.ToInt32(id);
        //                tm.UPDATED_USER_ID = user.USER_ID;
        //                success = timeManagementLogic.UpdateTimeManagement(tm);
        //            }
        //            return Json(new { success = success });
        //        }


        //        [HttpPost]
        //        public JsonResult DeleteTimeManagement(int deleteId)
        //        {
        //            bool success = false;
        //            success = timeManagementLogic.DeleteTimeManagement(deleteId);
        //            if (success)
        //            {
        //                var dayList = timeManagementOffDaysLogic.GetOffDaysListByTmId(deleteId);
        //                foreach (var item in dayList)
        //                {
        //                    timeManagementOffDaysLogic.DeleteOffDays(item.ID);
        //                }
        //            }
        //            return Json(new { success = success });
        //        }

        //        public JsonResult GetTimeManagement(int id)
        //        {
        //            var tm = timeManagementLogic.GetTimeManagement(id);
        //            return Json(tm);
        //        }
        //        #endregion


        //        #region TimeManagementOffDays
        //        public JsonResult GetTimeManagementOffDays(int timeManagementId)
        //        {
        //            var offDayList = timeManagementOffDaysLogic.GetOffDaysListByTmId(timeManagementId);
        //            return Json(offDayList);
        //        }


        //        [HttpPost]
        //        public JsonResult DeleteOffDays(int offDayDeleteId)
        //        {
        //            bool success = false;
        //            success = timeManagementOffDaysLogic.DeleteOffDays(offDayDeleteId);
        //            return Json(new { success = success });
        //        }

        //        [HttpPost]
        //        public JsonResult CreateOrEditOffDays(int? offDayId, int tmId, TIME_MANAGEMENT_OFFDAYS offDays)
        //        {
        //            var user = HttpContext.Session.GetObject<USER>("User");

        //            offDays.TIME_MANAGEMENT_ID = tmId;

        //            bool success = false;
        //            if (offDayId == null)
        //            {
        //                offDays.CREATED_USER_ID = user.USER_ID;
        //                success = timeManagementOffDaysLogic.InsertOffDays(offDays);
        //            }
        //            else
        //            {
        //                offDays.ID = Convert.ToInt32(offDayId);
        //                offDays.UPDATED_USER_ID = user.USER_ID;
        //                success = timeManagementOffDaysLogic.UpdateOffDays(offDays);
        //            }
        //            return Json(new { success = success });
        //        }


        //        public JsonResult GetOffDays(int id)
        //        {
        //            var offDay = timeManagementOffDaysLogic.GetOffDays(id);
        //            return Json(offDay);
        //        }
        //        #endregion

        //        #region GeneralSettings
        //        public IActionResult GeneralSettings()
        //        {
        //            var generalSettings = generalSettingsLogic.GetGeneralSettings();
        //            return View(generalSettings);
        //        }

        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public IActionResult GeneralSettings(GENERAL_SETTINGS generalSettings, IFormFile loginPageBackgroundFile, IFormFile logoFile)
        //        {
        //            if (loginPageBackgroundFile != null)
        //            {
        //                var uploads = Path.Combine(_hostingEnvironment.ContentRootPath, @"Content/images/bg");
        //                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(loginPageBackgroundFile.FileName);
        //                var filePath = Path.Combine(uploads, fileName);
        //                using (var fileStream = new FileStream(filePath, FileMode.Create))
        //                {
        //                    loginPageBackgroundFile.CopyTo(fileStream);
        //                }
        //                generalSettings.LOGIN_PAGE_BACKGROUND = "/Content/images/bg/" + fileName;
        //            }

        //            if (logoFile != null)
        //            {
        //                var uploads = Path.Combine(_hostingEnvironment.ContentRootPath, @"Content/images/logo");
        //                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(logoFile.FileName);
        //                var filePath = Path.Combine(uploads, fileName);
        //                using (var fileStream = new FileStream(filePath, FileMode.Create))
        //                {
        //                    logoFile.CopyTo(fileStream);
        //                }
        //                generalSettings.LOGO = "/Content/images/logo/" + fileName;
        //            }

        //            var success = generalSettingsLogic.InsertOrUpdateGeneralSettings(generalSettings);
        //            var gs = generalSettingsLogic.GetGeneralSettings();
        //            HttpContext.Session.SetObject("GeneralSettings", gs);
        //            ShowSuccessToastMessage();
        //            return View(gs);
        //        }
        //        #endregion
        //
    }
}