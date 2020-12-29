using MES.Data.Functions;
using MES.Data.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Business
{
    public class DepartmentLogic
    {
        IDepartment _department = new DepartmentFunctions();
        public List<DEPARTMENT> GetList()
        {
            var departmentList = _department.GetList();
            return departmentList;
        }
        public bool InsertDepartment(DEPARTMENT department)
        {
            var success = _department.InsertDepartment(department);
            return success;
        }
        public bool InsertDepartment(List<DEPARTMENT> department)
        {
            var success = _department.InsertDepartment(department);
            return success;
        }
        public bool UpdateDepartment(DEPARTMENT department)
        {
            var success = _department.UpdateDepartment(department);
            return success;
        }
        public bool DeleteDepartment(int Id)
        {
            var success = _department.DeleteDepartment(Id);
            return success;
        }
        public DEPARTMENT GetDepartment(int id)
        {
            var department = _department.GetDepartment(id);
            return department;
        }
    }
}
