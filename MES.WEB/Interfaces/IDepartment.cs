using MES.Web.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Web.Interfaces
{
    public interface IDepartment
    {
        List<DEPARTMENT> GetList();
        DEPARTMENT GetDepartment(int id);
        bool InsertDepartment(DEPARTMENT department);
        bool InsertDepartment(List<DEPARTMENT> department);
        bool UpdateDepartment(DEPARTMENT department);
        bool DeleteDepartment(int Id);
    }
}
