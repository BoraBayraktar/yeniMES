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
    public class WorkingDaysFunctions : IWorkingDays
    {
        public List<WORKING_DAYS> GetList()
        {
            using (MesContext context = new MesContext())
            {
                var wdList = context.WORKING_DAYS.Include(q => q.CREATED_USER).Where(q => q.IS_DELETED == false).ToList();
                return wdList;
            }
        }

        public WORKING_DAYS GetWorkingDays(int id)
        {
            using (MesContext context = new MesContext())
            {
                var wd = context.WORKING_DAYS.FirstOrDefault(q => q.ID == id);
                return wd;
            }
        }

        public bool InsertWorkingDays(WORKING_DAYS wd)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    context.WORKING_DAYS.Add(wd);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool UpdateWorkingDays(WORKING_DAYS wd)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var wDay = context.WORKING_DAYS.FirstOrDefault(q => q.ID == wd.ID);
                    if (wDay != null)
                    {
                        wd.NAME = wDay.NAME;
                        wd.CODE = wDay.CODE;
                        wd.UPDATED_DATE = DateTime.Now;
                    }
                    context.Entry(wd).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }


        public bool DeleteWorkingDays(int Id)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var wd = context.WORKING_DAYS.FirstOrDefault(q => q.ID == Id);
                    wd.IS_DELETED = true;
                    context.Entry(wd).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
        //public bool DeleteWorkingDays(int Id)
        //{
        //    bool returnVal = false;
        //    try
        //    {
        //        using (MesContext context = new MesContext())
        //        {
        //            var wd = context.WORKING_DAYS.FirstOrDefault(q => q.ID == Id);
        //            context.WORKING_DAYS.Remove(wd);
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
