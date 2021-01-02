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
    public class TimeManagementOffDaysFunctions : ITimeManagementOffDays
    {
        public List<TIME_MANAGEMENT_OFFDAYS> GetList()
        {
            using (MesContext context = new MesContext())
            {
                var offDaysList = context.TIME_MANAGEMENT_OFFDAYS
                                                                 .Where(q => q.IS_DELETED == false)
                                                                 .ToList();
                return offDaysList;
            }
        }

        public TIME_MANAGEMENT_OFFDAYS GetOffDays(int id)
        {
            using (MesContext context = new MesContext())
            {
                var offDay = context.TIME_MANAGEMENT_OFFDAYS.FirstOrDefault(q => q.ID == id);
                return offDay;
            }
        }

        public bool InsertOffDays(TIME_MANAGEMENT_OFFDAYS offDays)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    offDays.CREATED_DATE = DateTime.Now;
                    context.TIME_MANAGEMENT_OFFDAYS.Add(offDays);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool UpdateOffDays(TIME_MANAGEMENT_OFFDAYS offDays)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var day = context.TIME_MANAGEMENT_OFFDAYS.FirstOrDefault(q => q.ID == offDays.ID);
                    if (day != null)
                    {
                        day.YEAR = offDays.YEAR;
                        day.DESCRIPTION = offDays.DESCRIPTION;
                        day.START_DATE = offDays.START_DATE;
                        day.END_DATE = offDays.END_DATE;
                        day.OFF_DAY = offDays.OFF_DAY;
                        day.UPDATED_DATE = DateTime.Now;
                    }
                    context.Entry(day).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool DeleteOffDays(int Id)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var offDays = context.TIME_MANAGEMENT_OFFDAYS.FirstOrDefault(q => q.ID == Id);
                    offDays.IS_DELETED = true;
                    context.Entry(offDays).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        //public bool DeleteOffDays(int Id)
        //{
        //    bool returnVal = false;
        //    try
        //    {
        //        using (MesContext context = new MesContext())
        //        {
        //            var offDays = context.TIME_MANAGEMENT_OFFDAYS.FirstOrDefault(q => q.ID == Id);
        //            context.TIME_MANAGEMENT_OFFDAYS.Remove(offDays);
        //            context.SaveChanges();
        //            returnVal = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return returnVal;
        //}

        public List<TIME_MANAGEMENT_OFFDAYS> GetOffDaysListByTmId(int timeManagementId)
        {
            using (MesContext context = new MesContext())
            {
                var offDaysList = context.TIME_MANAGEMENT_OFFDAYS
                                                                 .Where(q => q.TIME_MANAGEMENT_ID == timeManagementId && q.IS_DELETED == false)
                                                                 .ToList();
                return offDaysList;
            }
        }
    }
}
