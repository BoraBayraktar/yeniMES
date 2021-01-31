using MES.Data.Logics;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.API.Business
{
    
    public class OrganizationBusiness
    {
        #region Instance
        HoldingLogic holdingLogic = new HoldingLogic();
        CompanyLogic companyLogic = new CompanyLogic();
        DepartmentLogic departmentLogic = new DepartmentLogic();
        TitleLogic titleLogic = new TitleLogic();
        LocationLogic locationLogic = new LocationLogic();
        CityLogic cityLogic = new CityLogic();
        UserGroupLogic userGroupLogic = new UserGroupLogic();
        UserLogic userLogic = new UserLogic();
        UserTypeLogic userTypeLogic = new UserTypeLogic();
        LeaveLogic leaveLogic = new LeaveLogic();
        LeaveTypeLogic leaveTypeLogic = new LeaveTypeLogic();
        WorkingScheduleLogic workingScheduleLogic = new WorkingScheduleLogic();
        #endregion

        #region Holding
        public List<HOLDING> HoldingGetList()
        {
            return holdingLogic.GetList();
        }
        public bool InsertHolding(HOLDING holding)
        {
            return holdingLogic.InsertHolding(holding);
        }
        public bool UpdateHolding(HOLDING holding)
        {
            return holdingLogic.UpdateHolding(holding);
        }
        public bool DeleteHolding(int deleteId)
        {
            return holdingLogic.DeleteHolding(deleteId);
        }
        public HOLDING GetHolding(int id)
        {
            return holdingLogic.GetHolding(id);
        }
        #endregion

        #region Company
        public List<COMPANY> CompanyGetList()
        {
            return companyLogic.GetList();
        }
        public bool InsertCompany(COMPANY company)
        {
            return companyLogic.InsertCompany(company);
        }
        public bool UpdateCompany(COMPANY company)
        {
            return companyLogic.UpdateCompany(company);
        }
        public bool DeleteCompany(int id)
        {
            return companyLogic.DeleteCompany(id);
        }
        public COMPANY GetCompany(int id)
        {
            return companyLogic.GetCompany(id);
        }
        #endregion

        #region Department
        public List<DEPARTMENT> DepartmentGetList()
        {
            return departmentLogic.GetList();
        }
        public bool InsertDepartment(DEPARTMENT department)
        {
            return departmentLogic.InsertDepartment(department);
        }
        public bool UpdateDepartment(DEPARTMENT department)
        {
            return departmentLogic.UpdateDepartment(department);
        }
        public bool DeleteDepartment(int id)
        {
            return departmentLogic.DeleteDepartment(id);
        }
        public DEPARTMENT GetDepartment(int id)
        {
            return departmentLogic.GetDepartment(id);
        }
        #endregion

        #region Title
        public List<TITLE> TitleGetList()
        {
            return titleLogic.GetList();
        }
        public bool InsertTitle(TITLE title)
        {
            return titleLogic.InsertTitle(title);
        }
        public bool UpdateTitle(TITLE title)
        {
            return titleLogic.UpdateTitle(title);
        }
        public bool DeleteTitle(int id)
        {
            return titleLogic.DeleteTitle(id);
        }
        public TITLE GetTitle(int id)
        {
            return titleLogic.GetTitle(id);
        }
        #endregion

        #region Location
        public List<LOCATION> LocationGetList()
        {
            return locationLogic.GetList();
        }
        public bool InsertLocation(LOCATION location)
        {
            return locationLogic.InsertLocation(location);
        }
        public bool UpdateLocation(LOCATION location)
        {
            return locationLogic.UpdateLocation(location);
        }
        public bool DeleteLocation(int id)
        {
            return locationLogic.DeleteLocation(id);
        }
        public LOCATION GetLocation(int id)
        {
            return locationLogic.GetLocation(id);
        }
        #endregion

        #region City
        public List<CITY> CityGetList()
        {
            return cityLogic.GetList();
        }
        #endregion

        #region UserGroup
        public List<USER_GROUP> UserGroupGetList()
        {
            return userGroupLogic.GetList();
        }
        public bool InsertUserGroup(USER_GROUP userGroup)
        {
            return userGroupLogic.InsertUserGroup(userGroup);
        }
        public bool UpdateUserGroup(USER_GROUP userGroup)
        {
            return userGroupLogic.UpdateUserGroup(userGroup);
        }
        public bool DeleteUserGroup(int id)
        {
            return userGroupLogic.DeleteUserGroup(id);
        }
        public USER_GROUP GetUserGroup(int id)
        {
            return userGroupLogic.GetUserGroup(id);
        }
        #endregion

        #region User
        public List<USER> UserGetList()
        {
            return userLogic.GetList();
        }
        public bool InsertUser(USER user)
        {
            return userLogic.InsertUser(user);
        }
        public bool UpdateUser(USER user)
        {
            return userLogic.UpdateUser(user);
        }
        public bool DeleteUser(int id)
        {
            return userLogic.DeleteUser(id);
        }
        public USER GetUser(int id)
        {
            return userLogic.GetUser(id);
        }
        #endregion

        #region UserType
        public List<USER_TYPE> UserTypeGetList()
        {
            return userTypeLogic.GetList();
        }
        #endregion

        #region Leave
        public List<LEAVE> LeaveGetList()
        {
            return leaveLogic.GetList();
        }
        public bool InsertLeave(LEAVE leave)
        {
            return leaveLogic.InsertLeave(leave);
        }
        public bool UpdateLeave(LEAVE leave)
        {
            return leaveLogic.UpdateLeave(leave);
        }
        public bool DeleteLeave(int id)
        {
            return leaveLogic.DeleteLeave(id);
        }
        public LEAVE GetLeave(int id)
        {
            return leaveLogic.GetLeave(id);
        }
        #endregion

        #region LeaveType
        public List<LEAVE_TYPE> LeaveTypeGetList()
        {
            return leaveTypeLogic.GetList();
        }
        public bool InsertLeaveType(LEAVE_TYPE leaveType)
        {
            return leaveTypeLogic.InsertLeaveType(leaveType);
        }
        public bool UpdateLeaveType(LEAVE_TYPE leaveType)
        {
            return leaveTypeLogic.UpdateLeaveType(leaveType);
        }
        public bool DeleteLeaveType(int id)
        {
            return leaveTypeLogic.DeleteLeaveType(id);
        }
        public LEAVE_TYPE GetLeaveType(int id) 
        {
            return leaveTypeLogic.GetLeaveType(id);
        }
        #endregion

        #region WorkingSchedule
        public List<WORKING_SCHEDULE> WorkingScheduleGetList()
        {
            return workingScheduleLogic.GetList();
        }
        public bool InsertWorkingSchedule(WORKING_SCHEDULE workingSchedule)
        {
            return workingScheduleLogic.InsertWorkingSchedule(workingSchedule);
        }
        public bool UpdateWorkingSchedule(WORKING_SCHEDULE workingSchedule)
        {
            return workingScheduleLogic.UpdateWorkingSchedule(workingSchedule);
        }
        public bool DeleteWorkingSchedule(int id)
        {
            return workingScheduleLogic.DeleteWorkingSchedule(id);
        }
        public WORKING_SCHEDULE GetWorkingSchedule(int id)
        {
            return workingScheduleLogic.GetWorkingSchedule(id);
        }
        #endregion
    }
}
