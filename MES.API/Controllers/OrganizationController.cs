using MES.API.Logger;
using MES.Data.Logics;
using MES.DB.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MES.API.JwtToken;
using MES.API.Business;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MES.API.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        Log logger = new Log();
        private JwtAuthenticationManager jwtAuthentication;
        private OrganizationBusiness organizationBusiness = new OrganizationBusiness();
        private int userid;

        public OrganizationController(IHttpContextAccessor accessor)
        {
            userid = jwtAuthentication.Decode(accessor.HttpContext.User.Claims.ToList().Where(x => x.Type == ClaimTypes.SerialNumber).FirstOrDefault().ToString());
            //int userid = Convert.ToInt32(User.Claims.Where(x=> x.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value);
        }

        #region Holding
        [HttpGet("HoldingGetList")]
        public List<HOLDING> HoldingGetList()
        {
            return logger.Logging<List<HOLDING>>(null, "Organization", "Get", userid, "HoldingGetList", organizationBusiness.HoldingGetList());
        }
        [HttpPost("InsertHolding")]
        public bool InsertHolding(HOLDING holding)
        {
            return logger.Logging<bool>(holding, "Organization", "Post", userid, "InsertHolding", organizationBusiness.InsertHolding(holding));
        }
        [HttpPost("UpdateHolding")]
        public bool UpdateHolding(HOLDING holding)
        {
            return logger.Logging<bool>(holding, "Organization", "Post", userid, "UpdateHolding", organizationBusiness.UpdateHolding(holding));
        }
        [HttpPost("DeleteHolding")]
        public bool DeleteHolding(int deleteId)
        {
            return logger.Logging<bool>(deleteId, "Organization", "Post", userid, "DeleteHolding", organizationBusiness.DeleteHolding(deleteId));
        }
        [HttpPost("GetHolding")]
        public HOLDING GetHolding(int id)
        {
            return logger.Logging<HOLDING>(id, "Organization", "Post", userid, "GetHolding", organizationBusiness.GetHolding(id));
        }
        #endregion

        #region Company
        [HttpGet("CompanyGetList")]
        public List<COMPANY> CompanyGetList()
        {
            return logger.Logging<List<COMPANY>>(null, "Organization", "Get", userid, "CompanyGetList", organizationBusiness.CompanyGetList());
        }
        [HttpPost("InsertCompany")]
        public bool InsertCompany(COMPANY company)
        {
            return logger.Logging<bool>(company, "Organization", "Post", userid, "InsertCompany", organizationBusiness.InsertCompany(company));
        }
        [HttpPost("UpdateCompany")]
        public bool UpdateCompany(COMPANY company)
        {
            return logger.Logging<bool>(company, "Organization", "Post", userid, "UpdateCompany", organizationBusiness.UpdateCompany(company));
        }
        [HttpPost("DeleteCompany")]
        public bool DeleteCompany(int deleteId)
        {
            return logger.Logging<bool>(deleteId, "Organization", "Post", userid, "DeleteCompany", organizationBusiness.DeleteCompany(deleteId));
        }
        [HttpPost("GetCompany")]
        public COMPANY GetCompany(int id)
        {
            return logger.Logging<COMPANY>(id, "Organization", "Post", userid, "GetCompany", organizationBusiness.GetCompany(id));
        }
        #endregion

        #region Department
        [HttpGet("DepartmentGetList")]
        public List<DEPARTMENT> DepartmentGetList()
        {
            return logger.Logging<List<DEPARTMENT>>(null, "Organization", "Get", userid, "DepartmentGetList", organizationBusiness.DepartmentGetList());
        }
        [HttpPost("InsertDepartment")]
        public bool InsertDepartment(DEPARTMENT department)
        {
            return logger.Logging<bool>(department, "Organization", "Post", userid, "InsertDepartment", organizationBusiness.InsertDepartment(department));
        }
        [HttpPost("UpdateDepartment")]
        public bool UpdateDepartment(DEPARTMENT department)
        {
            return logger.Logging<bool>(department, "Organization", "Post", userid, "UpdateDepartment", organizationBusiness.UpdateDepartment(department));
        }
        [HttpPost("DeleteDepartment")]
        public bool DeleteDepartment(int deleteId)
        {
            return logger.Logging<bool>(deleteId, "Organization", "Post", userid, "DeleteDepartment", organizationBusiness.DeleteDepartment(deleteId));
        }
        [HttpPost("GetDepartment")]
        public DEPARTMENT GetDepartment(int id)
        {
            return logger.Logging<DEPARTMENT>(id, "Organization", "Post", userid, "GetDepartment", organizationBusiness.GetDepartment(id));
        }
        #endregion

        #region Title
        [HttpGet("TitleGetList")]
        public List<TITLE> TitleGetList()
        {
            return logger.Logging<List<TITLE>>(null, "Organization", "Get", userid, "TitleGetList", organizationBusiness.TitleGetList());
        }
        [HttpPost("InsertTitle")]
        public bool InsertTitle(TITLE title)
        {
            return logger.Logging<bool>(title, "Organization", "Post", userid, "InsertTitle", organizationBusiness.InsertTitle(title));
        }
        [HttpPost("UpdateTitle")]
        public bool UpdateTitle(TITLE title)
        {
            return logger.Logging<bool>(title, "Organization", "Post", userid, "UpdateTitle", organizationBusiness.UpdateTitle(title));
        }
        [HttpPost("DeleteTitle")]
        public bool DeleteTitle(int deleteId)
        {
            return logger.Logging<bool>(deleteId, "Organization", "Post", userid, "DeleteTitle", organizationBusiness.DeleteTitle(deleteId));
        }
        [HttpPost("GetTitle")]
        public TITLE GetTitle(int id)
        {
            return logger.Logging<TITLE>(id, "Organization", "Post", userid, "GetTitle", organizationBusiness.GetTitle(id));
        }
        #endregion

        #region Location
        [HttpGet("LocationGetList")]
        public List<LOCATION> LocationGetList()
        {
            return logger.Logging<List<LOCATION>>(null, "Organization", "Get", userid, "LocationGetList", organizationBusiness.LocationGetList());
        }
        [HttpPost("InsertLocation")]
        public bool InsertLocation(LOCATION location)
        {
            return logger.Logging<bool>(location, "Organization", "Post", userid, "InsertLocation", organizationBusiness.InsertLocation(location));
        }
        [HttpPost("UpdateLocation")]
        public bool UpdateTitle(LOCATION location)
        {
            return logger.Logging<bool>(location, "Organization", "Post", userid, "UpdateLocation", organizationBusiness.UpdateLocation(location));
        }
        [HttpPost("DeleteLocation")]
        public bool DeleteLocation(int deleteId)
        {
            return logger.Logging<bool>(deleteId, "Organization", "Post", userid, "DeleteLocation", organizationBusiness.DeleteLocation(deleteId));
        }
        [HttpPost("GetLocation")]
        public LOCATION GetLocation(int id)
        {
            return logger.Logging<LOCATION>(id, "Organization", "Post", userid, "GetLocation", organizationBusiness.GetLocation(id));
        }
        #endregion

        #region City
        [HttpGet("CityGetList")]
        public List<CITY> CityGetList()
        {
            return logger.Logging<List<CITY>>(null, "Organization", "Get", userid, "CityGetList", organizationBusiness.CityGetList());
        }
        #endregion

        #region UserGroup
        [HttpGet("UserGroupGetList")]
        public List<USER_GROUP> UserGroupGetList()
        {
            return logger.Logging<List<USER_GROUP>>(null, "Organization", "Get", userid, "UserGroupGetList", organizationBusiness.UserGroupGetList());
        }
        [HttpPost("InsertUserGroup")]
        public bool InsertUserGroup(USER_GROUP userGroup)
        {
            return logger.Logging<bool>(userGroup, "Organization", "Post", userid, "InsertUserGroup", organizationBusiness.InsertUserGroup(userGroup));
        }
        [HttpPost("UpdateUserGroup")]
        public bool UpdateUserGroup(USER_GROUP userGroup)
        {
            return logger.Logging<bool>(userGroup, "Organization", "Post", userid, "UpdateUserGroup", organizationBusiness.UpdateUserGroup(userGroup));
        }
        [HttpPost("DeleteUserGroup")]
        public bool DeleteUserGroup(int deleteId)
        {
            return logger.Logging<bool>(deleteId, "Organization", "Post", userid, "DeleteUserGroup", organizationBusiness.DeleteUserGroup(deleteId));
        }
        [HttpPost("GetUserGroup")]
        public USER_GROUP GetUserGroup(int id)
        {
            return logger.Logging<USER_GROUP>(id, "Organization", "Post", userid, "GetUserGroup", organizationBusiness.GetUserGroup(id));
        }
        #endregion

        #region User
        [HttpGet("UserGetList")]
        public List<USER> UserGetList()
        {
            return logger.Logging<List<USER>>(null, "Organization", "Get", userid, "UserGetList", organizationBusiness.UserGetList());
        }
        [HttpPost("InsertUser")]
        public bool InsertUser(USER user)
        {
            return logger.Logging<bool>(user, "Organization", "Post", userid, "InsertUser", organizationBusiness.InsertUser(user));
        }
        [HttpPost("UpdateUser")]
        public bool UpdateUser(USER user)
        {
            return logger.Logging<bool>(user, "Organization", "Post", userid, "UpdateUser", organizationBusiness.UpdateUser(user));
        }
        [HttpPost("DeleteUser")]
        public bool DeleteUser(int deleteId)
        {
            return logger.Logging<bool>(deleteId, "Organization", "Post", userid, "DeleteUser", organizationBusiness.DeleteUser(deleteId));
        }
        [HttpPost("GetUser")]
        public USER GetUser(int id)
        {
            return logger.Logging<USER>(id, "Organization", "Post", userid, "GetUser", organizationBusiness.GetUser(id));
        }
        #endregion

        #region UserType
        [HttpGet("UserTypeGetList")]
        public List<USER_TYPE> UserTypeGetList()
        {
            return logger.Logging<List<USER_TYPE>>(null, "Organization", "Get", userid, "UserTypeGetList", organizationBusiness.UserTypeGetList());
        }
        #endregion

        #region Leave
        [HttpGet("LeaveGetList")]
        public List<LEAVE> LeaveGetList()
        {
            return logger.Logging<List<LEAVE>>(null, "Organization", "Get", userid, "LeaveGetList", organizationBusiness.LeaveGetList());
        }
        [HttpPost("InsertLeave")]
        public bool InsertLeave(LEAVE leave)
        {
            return logger.Logging<bool>(leave, "Organization", "Post", userid, "InsertLeave", organizationBusiness.InsertLeave(leave));
        }
        [HttpPost("UpdateLeave")]
        public bool UpdateLeave(LEAVE leave)
        {
            return logger.Logging<bool>(leave, "Organization", "Post", userid, "UpdateLeave", organizationBusiness.UpdateLeave(leave));
        }
        [HttpPost("DeleteLeave")]
        public bool DeleteLeave(int deleteId)
        {
            return logger.Logging<bool>(deleteId, "Organization", "Post", userid, "DeleteLeave", organizationBusiness.DeleteLeave(deleteId));
        }
        [HttpPost("GetLeave")]
        public LEAVE GetLeave(int id)
        {
            return logger.Logging<LEAVE>(id, "Organization", "Post", userid, "GetLeave", organizationBusiness.GetLeave(id));
        }
        #endregion

        #region LeaveType
        [HttpGet("LeaveTypeGetList")]
        public List<LEAVE_TYPE> LeaveTypeGetList()
        {
            return logger.Logging<List<LEAVE_TYPE>>(null, "Organization", "Get", userid, "LeaveTypeGetList", organizationBusiness.LeaveTypeGetList());
        }
        [HttpPost("InsertLeaveType")]
        public bool InsertLeaveType(LEAVE_TYPE leaveType)
        {
            return logger.Logging<bool>(leaveType, "Organization", "Post", userid, "InsertLeaveType", organizationBusiness.InsertLeaveType(leaveType));
        }
        [HttpPost("UpdateLeaveType")]
        public bool UpdateLeaveType(LEAVE_TYPE leaveType)
        {
            return logger.Logging<bool>(leaveType, "Organization", "Post", userid, "UpdateLeaveType", organizationBusiness.UpdateLeaveType(leaveType));
        }
        [HttpPost("DeleteLeaveType")]
        public bool DeleteLeaveType(int deleteId)
        {
            return logger.Logging<bool>(deleteId, "Organization", "Post", userid, "DeleteLeaveType", organizationBusiness.DeleteLeaveType(deleteId));
        }
        [HttpPost("GetLeaveType")]
        public LEAVE_TYPE GetLeaveType(int id)
        {
            return logger.Logging<LEAVE_TYPE>(id, "Organization", "Post", userid, "GetLeaveType", organizationBusiness.GetLeaveType(id));
        }
        #endregion

        #region WorkingSchedule
        [HttpGet("WorkingScheduleGetList")]
        public List<WORKING_SCHEDULE> WorkingScheduleGetList()
        {
            return logger.Logging<List<WORKING_SCHEDULE>>(null, "Organization", "Get", userid, "WorkingScheduleGetList", organizationBusiness.WorkingScheduleGetList());
        }
        [HttpPost("InsertWorkingSchedule")]
        public bool InsertWorkingSchedule(WORKING_SCHEDULE workingSchedule)
        {
            return logger.Logging<bool>(workingSchedule, "Organization", "Post", userid, "InsertWorkingSchedule", organizationBusiness.InsertWorkingSchedule(workingSchedule));
        }
        [HttpPost("UpdateWorkingSchedule")]
        public bool UpdateWorkingSchedule(WORKING_SCHEDULE workingSchedule)
        {
            return logger.Logging<bool>(workingSchedule, "Organization", "Post", userid, "UpdateWorkingSchedule", organizationBusiness.UpdateWorkingSchedule(workingSchedule));
        }
        [HttpPost("DeleteWorkingSchedule")]
        public bool DeleteWorkingSchedule(int deleteId)
        {
            return logger.Logging<bool>(deleteId, "Organization", "Post", userid, "DeleteWorkingSchedule", organizationBusiness.DeleteWorkingSchedule(deleteId));
        }
        [HttpPost("GetWorkingSchedule")]
        public WORKING_SCHEDULE GetWorkingSchedule(int id)
        {
            return logger.Logging<WORKING_SCHEDULE>(id, "Organization", "Post", userid, "GetWorkingSchedule", organizationBusiness.GetWorkingSchedule(id));
        }
        #endregion
    }
}
