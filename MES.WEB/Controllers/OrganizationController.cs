using System;
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
using Microsoft.Extensions.Configuration;

namespace MES.Web.Controllers
{
    [Authorize]
    public class OrganizationController : BaseController
    {
        #region Instance
        [Obsolete]
        IHostingEnvironment _hostingEnvironment;
        ServiceBusiness serviceBusiness;

        #endregion

        [Obsolete]
        public OrganizationController(IHostingEnvironment environment, IConfiguration configuration, IHttpContextAccessor accessor)
        {
            serviceBusiness = new ServiceBusiness(configuration, accessor);
            _hostingEnvironment = environment;
        }

        #region Holding
        public IActionResult Holding()
        {
            var holdingList = serviceBusiness.ServiceGet<List<HOLDING>>("Holding", "HoldingGetList");
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
                success = serviceBusiness.ServicePost<bool>(holding, "Holding", "InsertHolding");
            }
            else
            {
                holding.HOLDING_ID = Convert.ToInt32(id);
                //holding.UPDATED_USER_ID = user.USER_ID;
                success = serviceBusiness.ServicePost<bool>(holding, "Holding", "UpdateHolding");
            }
            return Json(new { success = success });
        }
        //[HttpPost]
        public JsonResult DeleteHolding(int deleteId)
        {
            bool success = false;
            success = serviceBusiness.ServicePost<bool>(deleteId, "Holding", "DeleteHolding");
            return Json(new { success = success });
        }

        public JsonResult GetHolding(int id)
        {
            var holding = serviceBusiness.ServicePost<HOLDING>(id, "Holding", "GetHolding");
            return Json(holding);
        }
        #endregion

        #region Company
        public IActionResult Company()
        {
            var companyList = serviceBusiness.ServiceGet<List<COMPANY>>("Company", "CompanyGetList");
            var holdingList = serviceBusiness.ServiceGet<List<HOLDING>>("Company", "HoldingGetList");
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
                success = serviceBusiness.ServicePost<bool>(company, "Company", "InsertCompany");
            }
            else
            {
                company.COMPANY_ID = Convert.ToInt32(id);
                //company.UPDATED_USER_ID = user.USER_ID;
                success = serviceBusiness.ServicePost<bool>(company, "Company", "UpdateCompany");
            }
            return Json(new { success = success });
        }
        [HttpPost]
        public JsonResult DeleteCompany(int deleteId)
        {
            bool success = false;
            success = serviceBusiness.ServicePost<bool>(deleteId, "Company", "DeleteCompany");
            return Json(new { success = success });
        }

        public JsonResult GetCompany(int id)
        {
            var company = serviceBusiness.ServicePost<COMPANY>(id, "Company", "GetCompany");
            return Json(company);
        }
        #endregion

        #region Department
        public IActionResult Department()
        {
            var departmentList = serviceBusiness.ServiceGet<List<DEPARTMENT>>("Department", "DepartmentGetList");
            var companyList = serviceBusiness.ServiceGet<List<COMPANY>>("Department", "CompanyGetList");
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
                success = serviceBusiness.ServicePost<bool>(department, "Department", "InsertDepartment");
            }
            else
            {
                department.DEPARTMENT_ID = Convert.ToInt32(id);
                //department.UPDATED_USER_ID = user.USER_ID;
                success = serviceBusiness.ServicePost<bool>(department, "Department", "UpdateDepartment");
            }
            return Json(new { success = success });
        }
        //[HttpPost]
        public JsonResult DeleteDepartment(int deleteId)
        {
            bool success = false;
            success = serviceBusiness.ServicePost<bool>(deleteId, "Department", "DeleteDepartment");
            return Json(new { success = success });
        }

        public JsonResult GetDepartment(int id)
        {
            var department = serviceBusiness.ServicePost<DEPARTMENT>(id, "Department", "GetDepartment");
            return Json(department);
        }
        #endregion

        #region Title
        public IActionResult Title()
        {
            var titleList = serviceBusiness.ServiceGet<List<TITLE>>("Title","TitleGetList");
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
                success = serviceBusiness.ServicePost<bool>(title, "Title", "InsertTitle");
            }
            else
            {
                title.TITLE_ID = Convert.ToInt32(id);
                //title.UPDATED_USER_ID = user.USER_ID;
                success = serviceBusiness.ServicePost<bool>(title, "Title", "UpdateTitle");
            }
            return Json(new { success = success });
        }
        //[HttpPost]
        public JsonResult DeleteTitle(int deleteId)
        {
            bool success = false;
            success = serviceBusiness.ServicePost<bool>(deleteId, "Title", "DeleteTitle");
            return Json(new { success = success });
        }

        public JsonResult GetTitle(int id)
        {
            var title = serviceBusiness.ServicePost<TITLE>(id, "Title", "GetTitle");
            return Json(title);
        }
        #endregion

        #region Location
        public IActionResult Location()
        {
            var locationList = serviceBusiness.ServiceGet<List<LOCATION>>("Location", "LocationGetList");
            var cityList = serviceBusiness.ServiceGet<List<CITY>>("Location", "CityGetList");
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
                success = serviceBusiness.ServicePost<bool>(location, "Location", "InsertLocation");
            }
            else
            {
                location.LOCATION_ID = Convert.ToInt32(id);
                //location.UPDATED_USER_ID = user.USER_ID;
                success = success = serviceBusiness.ServicePost<bool>(location, "Location", "UpdateLocation");
            }
            return Json(new { success = success });
        }
        [HttpPost]
        public JsonResult DeleteLocation(int deleteId)
        {
            bool success = false;
            success = serviceBusiness.ServicePost<bool>(deleteId, "Location", "DeleteLocation");
            return Json(new { success = success });
        }

        public JsonResult GetLocation(int id)
        {
            var location = serviceBusiness.ServicePost<LOCATION>(id, "Location", "GetLocation");
            return Json(location);
        }
        #endregion

        #region UserGroup
        public IActionResult UserGroup()
        {
            var userGroupList = serviceBusiness.ServiceGet<List<USER_GROUP>>("UserGroup", "UserGroupGetList");
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
                success = serviceBusiness.ServicePost<bool>(userGroup, "UserGroup", "InsertUserGroup");
            }
            else
            {
                userGroup.USER_GROUP_ID = Convert.ToInt32(id);
                //userGroup.UPDATED_USER_ID = user.USER_ID;
                success = serviceBusiness.ServicePost<bool>(userGroup, "UserGroup", "UpdateUserGroup");
            }
            return Json(new { success = success });
        }
        //[HttpPost]
        public JsonResult DeleteUserGroup(int deleteId)
        {
            bool success = false;
            success = serviceBusiness.ServicePost<bool>(deleteId, "UserGroup", "DeleteUserGroup");
            return Json(new { success = success });
        }

        public JsonResult GetUserGroup(int id)
        {
            var userGroup = serviceBusiness.ServicePost<USER_GROUP>(id, "UserGroup", "GetUserGroup");
            return Json(userGroup);
        }
        #endregion

        #region Users
        public IActionResult Users()
        {
            var userList = serviceBusiness.ServiceGet<List<USER>>("User", "UserGetList");
            var departmentList = serviceBusiness.ServiceGet<List<DEPARTMENT>>("Department","DepartmentGetList");
            var locationList = serviceBusiness.ServiceGet<List<LOCATION>>("Location", "LocationGetList");
            var titleList = serviceBusiness.ServiceGet<List<TITLE>>("Title", "TitleGetList");
            var userGroupList = serviceBusiness.ServiceGet<List<USER_GROUP>>("UserGroup", "UserGroupGetList");
            var userTypeList = serviceBusiness.ServiceGet<List<USER_TYPE>>("UserType", "UserTypeGetList");


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
                success = serviceBusiness.ServicePost<bool>(user, "User", "InsertUser");
            }
            else
            {
                //user.UPDATED_USER_ID = currentUser.USER_ID;
                user.USER_ID = Convert.ToInt32(id);
                success = serviceBusiness.ServicePost<bool>(user, "User", "UpdateUser");
            }
            return Json(new { success = success });
        }
        //[HttpPost]
        public JsonResult DeleteUser(int deleteId)
        {
            bool success = false;
            success = serviceBusiness.ServicePost<bool>(deleteId, "User", "DeleteUser");
            return Json(new { success = success });
        }

        public JsonResult GetUser(int id)
        {
            var user = serviceBusiness.ServicePost<USER>(id, "User","GetUser");
            return Json(user);
        }
        #endregion

        #region Leave
        public IActionResult Leave()
        {
            var leaveList = serviceBusiness.ServiceGet<List<LEAVE>>("Leave", "LeaveGetList");
            var leaveTypeList = serviceBusiness.ServiceGet<List<LEAVE_TYPE>>("LeaveType", "LeaveTypeGetList");
            var userList = serviceBusiness.ServiceGet<List<USER>>("LeaveType", "UserGetList");

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
                success = serviceBusiness.ServicePost<bool>(leave,"Leave", "InsertLeave");
            }
            else
            {
                //leave.UPDATED_USER_ID = user.USER_ID;
                leave.LEAVE_ID = Convert.ToInt32(id);
                success = serviceBusiness.ServicePost<bool>(leave, "Leave", "UpdateLeave");
            }
            return Json(new { success = success });
        }
        [HttpPost]
        public JsonResult DeleteLeave(int deleteId)
        {
            bool success = false;
            success = serviceBusiness.ServicePost<bool>(deleteId, "Leave", "DeleteLeave");
            return Json(new { success = success });
        }

        public JsonResult GetLeave(int id)
        {
            var leave = serviceBusiness.ServicePost<LEAVE>(id, "Leave", "GetLeave");
            return Json(leave);
        }
        #endregion

        #region WorkingSchedule
        public IActionResult WorkingSchedule()
        {
            var wsList = serviceBusiness.ServiceGet<List<WORKING_SCHEDULE>>("WorkingSchedule", "WorkingScheduleGetList");
            WorkingScheduleViewModel wsvm = new WorkingScheduleViewModel();
            wsvm.WorkingScheduleList = wsList;
            return View(wsvm);
        }
        //[HttpPost]
        public JsonResult CreateOrEditWorkingSchedule(int? id, WORKING_SCHEDULE workingSchedule)
        {
            var user = HttpContext.Session.GetObject<USER>("User");

            bool success = false;
            if (id == null)
            {
                //workingSchedule.CREATED_USER_ID = user.USER_ID;

                success = serviceBusiness.ServicePost<bool>(workingSchedule, "WorkingSchedule", "InsertWorkingSchedule");
            }
            else
            {
                workingSchedule.WORKING_SCHEDULE_ID = Convert.ToInt32(id);
                //workingSchedule.UPDATED_USER_ID = user.USER_ID;

                success = serviceBusiness.ServicePost<bool>(workingSchedule, "WorkingSchedule", "UpdateWorkingSchedule");
            }
            return Json(new { success = success });
        }
        //[HttpPost]
        public JsonResult DeleteWorkingSchedule(int deleteId)
        {
            bool success = false;
            success = serviceBusiness.ServicePost<bool>(deleteId, "WorkingSchedule", "DeleteWorkingSchedule");
            return Json(new { success = success });
        }

        public JsonResult GetWorkingSchedule(int id)
        {
            var ws = serviceBusiness.ServicePost<WORKING_SCHEDULE>(id, "WorkingSchedule", "GetWorkingSchedule");
            return Json(ws);
        }
        #endregion

        #region EmailSettings
        public IActionResult EmailSettings()
        {
            var emailSettings = serviceBusiness.ServiceGet<List<MAIL_SERVER_SETUP>>("MailSettings", "MailSettingsGetList");
            EmailSettingsViewModel evm = new EmailSettingsViewModel();
            evm.MailServerSetup = emailSettings.FirstOrDefault();

            return View(evm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EmailSettings(MAIL_SERVER_SETUP mailServerSetup)
        {
            var currentUser = HttpContext.Session.GetObject<USER>("User");
            //mailServerSetup.CREATED_USER_ID = currentUser.USER_ID;

            var emailSettings = serviceBusiness.ServicePost<bool>(mailServerSetup, "MailSettings", "InsertOrUpdateMailSettings");
            EmailSettingsViewModel evm = new EmailSettingsViewModel();
            evm.MailServerSetup = mailServerSetup;
            ShowSuccessToastMessage();
            return View(evm);
        }
        #endregion

        #region TimeManagement
        public IActionResult TimeManagement()
        {
            var timeManagementList = serviceBusiness.ServiceGet<List<TIME_MANAGEMENT>>("TimeManagement", "TimeManagementGetList");
            var workingDaysList = serviceBusiness.ServiceGet<List<WORKING_DAYS>>("WorkingDays", "WorkingDaysGetList");
            var workingScheduleList = serviceBusiness.ServiceGet<List<WORKING_SCHEDULE>>("WorkingSchedule", "WorkingScheduleGetList");
            var timezoneList = serviceBusiness.ServiceGet<List<TIMEZONE>>("TimeManagement","TimezoneGetList");

            foreach (var item in timeManagementList)
            {
                var calendarDaysList = item.CALENDAR_DAYS.Split(',');
                var calendarDaysName = "";
                var calendarDaysCount = calendarDaysList.Length;
                int i = 1;
                foreach (var dayItem in calendarDaysList)
                {
                    calendarDaysName += workingDaysList.FirstOrDefault(q => q.CODE == dayItem).NAME;
                    if (calendarDaysCount != i)
                    {
                        calendarDaysName += ", ";
                    }
                    i += 1;
                }

                item.CALENDAR_DAYS = calendarDaysName;


                var businessHoursList = item.BUSINESS_HOURS.Split(',');
                var businessHoursName = "";
                var businessHoursCount = businessHoursList.Length;
                i = 1;
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

            TimeManagementViewModel tvm = new TimeManagementViewModel();
            tvm.TimeManagementList = timeManagementList;

            foreach (var item in workingDaysList)
            {
                tvm.WorkDaysList.Add(new SelectListItem()
                {
                    Text = item.NAME,
                    Value = item.CODE.ToString()
                });
            }

            foreach (var item in workingScheduleList)
            {
                tvm.BusinessHoursList.Add(new SelectListItem()
                {
                    Text = item.NAME,
                    Value = item.WORKING_SCHEDULE_ID.ToString()
                });
            }

            foreach (var item in timezoneList)
            {
                tvm.TimezoneList.Add(new SelectListItem()
                {
                    Text = item.NAME,
                    Value = item.ID.ToString()
                });
            }


            return View(tvm);
        }


        public IActionResult AddTimeManagement(int? id)
        {
            var timeManagementList = serviceBusiness.ServiceGet<List<TIME_MANAGEMENT>>("TimeManagement","TimeManagementGetList");
            var workingDaysList = serviceBusiness.ServiceGet<List<WORKING_DAYS>>("WorkingDays","WorkingDaysGetList");
            var workingScheduleList = serviceBusiness.ServiceGet<List<WORKING_SCHEDULE>>("WorkingSchedule","WorkingScheduleGetList");
            var timezoneList = serviceBusiness.ServiceGet<List<TIMEZONE>>("TimeManagement","TimezoneGetList");

            foreach (var item in timeManagementList)
            {
                var calendarDaysList = item.CALENDAR_DAYS.Split(',');
                var calendarDaysName = "";
                var calendarDaysCount = calendarDaysList.Length;
                int i = 1;
                foreach (var dayItem in calendarDaysList)
                {
                    calendarDaysName += workingDaysList.FirstOrDefault(q => q.CODE == dayItem).NAME;
                    if (calendarDaysCount != i)
                    {
                        calendarDaysName += ", ";
                    }
                    i += 1;
                }

                item.CALENDAR_DAYS = calendarDaysName;


                var businessHoursList = item.BUSINESS_HOURS.Split(',');
                var businessHoursName = "";
                var businessHoursCount = businessHoursList.Length;
                i = 1;
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

            TimeManagementViewModel tvm = new TimeManagementViewModel();
            tvm.TimeManagementList = timeManagementList;

            foreach (var item in workingDaysList)
            {
                tvm.WorkDaysList.Add(new SelectListItem()
                {
                    Text = item.NAME,
                    Value = item.CODE.ToString()
                });
            }

            foreach (var item in workingScheduleList)
            {
                tvm.BusinessHoursList.Add(new SelectListItem()
                {
                    Text = item.NAME,
                    Value = item.WORKING_SCHEDULE_ID.ToString()
                });
            }

            foreach (var item in timezoneList)
            {
                tvm.TimezoneList.Add(new SelectListItem()
                {
                    Text = item.NAME,
                    Value = item.ID.ToString()
                });
            }

            if (id != null)
            {
                var tm = serviceBusiness.ServicePost<TIME_MANAGEMENT>(Convert.ToInt32(id),"TimeManagement","GetTimeManagement");
                tvm.CALENDAR_NAME = tm.CALENDAR_NAME;
                tvm.TIMEZONE_ID = tm.TIMEZONE_ID;
                tvm.ISACTIVE = tm.ISACTIVE;
                //tvm.CALENDAR_DAYS = tm.CALENDAR_DAYS;
                //tvm.BUSINESS_HOURS = tm.BUSINESS_HOURS;

                if (!String.IsNullOrEmpty(tm.CALENDAR_DAYS))
                {
                    tvm.SelectedWorkDays = tm.CALENDAR_DAYS.Split(',');
                }
                if (!String.IsNullOrEmpty(tm.BUSINESS_HOURS))
                {
                    tvm.SelectedBusinessHours = tm.BUSINESS_HOURS.Split(',');
                }

                var offDayList = serviceBusiness.ServicePost<List<TIME_MANAGEMENT_OFFDAYS>>(Convert.ToInt32(id), "TimeManagementOffDays", "TimeManagementOffDaysGetListById");
                tvm.OffDaysList = offDayList;
            }




            return View(tvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTimeManagement(int? id, TimeManagementViewModel timeManagement)
        {
            var user = HttpContext.Session.GetObject<USER>("User");

            bool success = false;

            TIME_MANAGEMENT tm = new TIME_MANAGEMENT();
            tm.CALENDAR_NAME = timeManagement.CALENDAR_NAME;
            int i = 1;
            int dayCount = timeManagement.SelectedWorkDays.Length;
            int bHourCount = timeManagement.SelectedBusinessHours.Length;

            foreach (var item in timeManagement.SelectedWorkDays)
            {
                tm.CALENDAR_DAYS += item;
                if (i != dayCount)
                {
                    tm.CALENDAR_DAYS += ",";
                }
                i++;
            }

            i = 1;
            foreach (var item in timeManagement.SelectedBusinessHours)
            {
                tm.BUSINESS_HOURS += item;
                if (i != bHourCount)
                {
                    tm.BUSINESS_HOURS += ",";
                }
                i++;
            }

            tm.TIMEZONE_ID = timeManagement.TIMEZONE_ID;
            tm.ISACTIVE = timeManagement.ISACTIVE;


            if (id == null)
            {
                //tm.CREATED_USER_ID = user.USER_ID;
                success = serviceBusiness.ServicePost<bool>(tm, "TimeManagement", "InsertTimeManagement");
            }
            else
            {
                tm.ID = Convert.ToInt32(id);
                //tm.UPDATED_USER_ID = user.USER_ID;
                success = serviceBusiness.ServicePost<bool>(tm, "TimeManagement", "UpdateTimeManagement");
            }

            var offDaysList = serviceBusiness.ServicePost<List<TIME_MANAGEMENT_OFFDAYS>>(tm.ID, "TimeManagementOffDays", "TimeManagementOffDaysGetListById");

            foreach (var item in offDaysList)
            {
                var day = timeManagement.PostOffDays.FirstOrDefault(q => q.ID == item.ID);
                if (day == null)
                {
                    success = serviceBusiness.ServicePost<bool>(item.ID, "TimeManagementOffDays", "DeleteTimeManagementOffDays");
                }
            }

            foreach (var item in timeManagement.PostOffDays)
            {
                item.TIME_MANAGEMENT_ID = tm.ID;
                if (item.ID == 0)
                {
                    //item.CREATED_USER_ID = user.USER_ID;
                    success = serviceBusiness.ServicePost<bool>(item, "TimeManagementOffDays", "InsertTimeManagementOffDays");
                }
                else
                {
                    //item.UPDATED_USER_ID = user.USER_ID;
                    success = serviceBusiness.ServicePost<bool>(item, "TimeManagementOffDays", "UpdateTimeManagementOffDays");
                }
            }

            ShowSuccessToastMessage();
            return RedirectToAction("TimeManagement", "Organization");
        }


        [HttpPost]
        public JsonResult CreateOrEditTimeManagement(int? id, TimeManagementViewModel timeManagement)
        {
            var user = HttpContext.Session.GetObject<USER>("User");

            bool success = false;

            TIME_MANAGEMENT tm = new TIME_MANAGEMENT();
            tm.CALENDAR_NAME = timeManagement.CALENDAR_NAME;
            int i = 1;
            int dayCount = timeManagement.SelectedWorkDays.Length;
            int bHourCount = timeManagement.SelectedBusinessHours.Length;

            foreach (var item in timeManagement.SelectedWorkDays)
            {
                tm.CALENDAR_DAYS += item;
                if (i != dayCount)
                {
                    tm.CALENDAR_DAYS += ",";
                }
                i++;
            }

            i = 1;
            foreach (var item in timeManagement.SelectedBusinessHours)
            {
                tm.BUSINESS_HOURS += item;
                if (i != bHourCount)
                {
                    tm.BUSINESS_HOURS += ",";
                }
                i++;
            }

            tm.TIMEZONE_ID = timeManagement.TIMEZONE_ID;
            tm.ISACTIVE = timeManagement.ISACTIVE;


            if (id == null)
            {
                //tm.CREATED_USER_ID = user.USER_ID;
                success = serviceBusiness.ServicePost<bool>(tm, "TimeManagement", "InsertTimeManagement");
            }
            else
            {
                tm.ID = Convert.ToInt32(id);
                //tm.UPDATED_USER_ID = user.USER_ID;
                success = serviceBusiness.ServicePost<bool>(tm, "TimeManagement", "UpdateTimeManagement");
            }
            return Json(new { success = success });
        }


        [HttpPost]
        public JsonResult DeleteTimeManagement(int deleteId)
        {
            bool success = false;
            success = serviceBusiness.ServicePost<bool>(deleteId, "TimeManagement","DeleteTimeManagement");
            if (success)
            {
                var dayList = serviceBusiness.ServicePost<List<TIME_MANAGEMENT_OFFDAYS>>(deleteId,"TimeManagementOffDays", "TimeManagementOffDaysGetListById");
                foreach (var item in dayList)
                {
                    serviceBusiness.ServicePost<bool>(item.ID, "TimeManagementOffDays", "DeleteTimeManagementOffDays");
                }
            }
            return Json(new { success = success });
        }

        public JsonResult GetTimeManagement(int id)
        {
            var tm = serviceBusiness.ServicePost<TIME_MANAGEMENT>(id, "TimeManagement", "GetTimeManagement");
            return Json(tm);
        }
        #endregion

        #region TimeManagementOffDays
        public JsonResult GetTimeManagementOffDays(int timeManagementId)
        {
            var offDayList = serviceBusiness.ServicePost<List<TIME_MANAGEMENT_OFFDAYS>>(timeManagementId, "TimeManagementOffDays", "TimeManagementOffDaysGetListById");
            return Json(offDayList);
        }


        [HttpPost]
        public JsonResult DeleteOffDays(int offDayDeleteId)
        {
            bool success = false;
            success = serviceBusiness.ServicePost<bool>(offDayDeleteId, "TimeManagementOffDays", "DeleteTimeManagementOffDays");
            return Json(new { success = success });
        }

        [HttpPost]
        public JsonResult CreateOrEditOffDays(int? offDayId, int tmId, TIME_MANAGEMENT_OFFDAYS offDays)
        {
            var user = HttpContext.Session.GetObject<USER>("User");

            offDays.TIME_MANAGEMENT_ID = tmId;

            bool success = false;
            if (offDayId == null)
            {
                //offDays.CREATED_USER_ID = user.USER_ID;
                success = serviceBusiness.ServicePost<bool>(offDays, "TimeManagementOffDays", "InsertTimeManagementOffDays");
            }
            else
            {
                offDays.ID = Convert.ToInt32(offDayId);
                //offDays.UPDATED_USER_ID = user.USER_ID;
                success = serviceBusiness.ServicePost<bool>(offDays, "TimeManagementOffDays", "UpdateTimeManagementOffDays");
            }
            return Json(new { success = success });
        }


        public JsonResult GetOffDays(int id)
        {
            var offDay = serviceBusiness.ServicePost<bool>(id, "TimeManagementOffDays", "GetTimeManagementOffDays");
            return Json(offDay);
        }
        #endregion

        #region GeneralSettings
        public IActionResult GeneralSettings()
        {
            var generalSettings = serviceBusiness.ServiceGet<GENERAL_SETTINGS>("GeneralSettings", "GetGeneralSettings");
            return View(generalSettings);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GeneralSettings(GENERAL_SETTINGS generalSettings, IFormFile loginPageBackgroundFile, IFormFile logoFile)
        {
            if (loginPageBackgroundFile != null)
            {
                var uploads = Path.Combine(_hostingEnvironment.ContentRootPath, @"Content/images/bg");
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(loginPageBackgroundFile.FileName);
                var filePath = Path.Combine(uploads, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    loginPageBackgroundFile.CopyTo(fileStream);
                }
                generalSettings.LOGIN_PAGE_BACKGROUND = "/Content/images/bg/" + fileName;
            }

            if (logoFile != null)
            {
                var uploads = Path.Combine(_hostingEnvironment.ContentRootPath, @"Content/images/logo");
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(logoFile.FileName);
                var filePath = Path.Combine(uploads, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    logoFile.CopyTo(fileStream);
                }
                generalSettings.LOGO = "/Content/images/logo/" + fileName;
            }

            var success = serviceBusiness.ServicePost<bool>(generalSettings, "GeneralSettings", "InsertOrUpdateGeneralSettings");
            var gs = serviceBusiness.ServiceGet<GENERAL_SETTINGS>("GeneralSettings", "GetGeneralSettings");
            HttpContext.Session.SetObject("GeneralSettings", gs);
            ShowSuccessToastMessage();
            return View(gs);
        }
        #endregion

    }
}