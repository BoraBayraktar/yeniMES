using MES.API.Interfaces;
using MES.DB;
using MES.DB.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MES.API.Functions
{
    public class DepartmentFunctions : IDepartment
    {
        public List<DEPARTMENT> GetList()
        {
            using (MesContext context = new MesContext())
            {
                var departmentList = context.DEPARTMENT.Include(q => q.CREATED_USER)
                                                       .Include(q => q.COMPANY)
                                                       .Where(q => q.IS_DELETED == false)
                                                       .ToList();
                return departmentList;
            }
        }

        public DEPARTMENT GetDepartment(int id)
        {
            using (MesContext context = new MesContext())
            {
                var department = context.DEPARTMENT.FirstOrDefault(q => q.DEPARTMENT_ID == id);
                return department;
            }
        }

        public bool InsertDepartment(DEPARTMENT department)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    department.CREATED_DATE = DateTime.Now;
                    context.DEPARTMENT.Add(department);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool InsertDepartment(List<DEPARTMENT> department)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    department.ForEach(x=>x.CREATED_DATE = DateTime.Now);
                    context.DEPARTMENT.AddRange(department);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
            return returnVal;
        }

        public bool UpdateDepartment(DEPARTMENT department)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var dep = context.DEPARTMENT.FirstOrDefault(q => q.DEPARTMENT_ID == department.DEPARTMENT_ID);
                    if (dep != null)
                    {
                        dep.CODE = department.CODE;
                        dep.NAME = department.NAME;
                        dep.DESCRIPTION = department.DESCRIPTION;
                        dep.COMPANY_ID = department.COMPANY_ID;
                        dep.UPDATED_DATE = DateTime.Now;
                        dep.UPDATED_USER_ID = department.UPDATED_USER_ID;
                    }
                    context.Entry(dep).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }


        public bool DeleteDepartment(int Id)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var department = context.DEPARTMENT.FirstOrDefault(q => q.DEPARTMENT_ID == Id);
                    department.IS_DELETED = true;
                    context.Entry(department).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        //public bool DeleteDepartment(int Id)
        //{
        //    bool returnVal = false;
        //    try
        //    {
        //        using (MesContext context = new MesContext())
        //        {
        //            var department = context.DEPARTMENT.FirstOrDefault(q => q.DEPARTMENT_ID == Id);
        //            context.DEPARTMENT.Remove(department);
        //            context.SaveChanges();
        //            returnVal = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return returnVal;
        //}
    }
}
