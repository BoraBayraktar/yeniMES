using MES.Data.Interfaces;
using MES.DB;
using MES.DB.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MES.Data.Functions
{
    public class TimeManagementFunctions : ITimeManagement
    {
        public List<TIME_MANAGEMENT> GetList()
        {
            using (MesContext context = new MesContext())
            {
                var timeMngList = context.TIME_MANAGEMENT.Include(q => q.CREATED_USER)
                                                         .Include(q => q.TIMEZONE)
                                                         .Where(q => q.IS_DELETED == false)
                                                         .ToList();
                return timeMngList;
            }
        }

        public TIME_MANAGEMENT GetTimeManagement(int id)
        {
            using (MesContext context = new MesContext())
            {
                var tm = context.TIME_MANAGEMENT.FirstOrDefault(q => q.ID == id);
                return tm;
            }
        }

        public bool InsertTimeManagement(TIME_MANAGEMENT timeMng)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    timeMng.CREATED_DATE = DateTime.Now;
                    context.TIME_MANAGEMENT.Add(timeMng);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool UpdateTimeManagement(TIME_MANAGEMENT timeMng)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var tm = context.TIME_MANAGEMENT.FirstOrDefault(q => q.ID == timeMng.ID);
                    if (tm != null)
                    {
                        tm.BUSINESS_HOURS = timeMng.BUSINESS_HOURS;
                        tm.CALENDAR_DAYS = timeMng.CALENDAR_DAYS;
                        tm.CALENDAR_NAME = timeMng.CALENDAR_NAME;
                        tm.ISACTIVE = timeMng.ISACTIVE;
                        tm.TIMEZONE_ID = timeMng.TIMEZONE_ID;
                        tm.UPDATED_DATE = DateTime.Now;
                        tm.UPDATED_USER_ID = timeMng.UPDATED_USER_ID;
                    }
                    context.Entry(tm).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool DeleteTimeManagement(int Id)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var holding = context.TIME_MANAGEMENT.FirstOrDefault(q => q.ID == Id);
                    holding.IS_DELETED = true;
                    context.Entry(holding).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
        //public bool DeleteTimeManagement(int Id)
        //{
        //    bool returnVal = false;
        //    try
        //    {
        //        using (MesContext context = new MesContext())
        //        {
        //            var holding = context.TIME_MANAGEMENT.FirstOrDefault(q => q.ID == Id);
        //            context.TIME_MANAGEMENT.Remove(holding);
        //            context.SaveChanges();
        //            returnVal = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return returnVal;
        //}

        public List<TIMEZONE> GetTimezoneList()
        {
            using (MesContext context = new MesContext())
            {
                var timezoneList = context.TIMEZONE.ToList();
                return timezoneList;
            }
        }
    }
}
