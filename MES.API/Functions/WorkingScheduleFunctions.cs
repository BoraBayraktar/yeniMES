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
    public class WorkingScheduleFunctions : IWorkingSchedule
    {
        public List<WORKING_SCHEDULE> GetList()
        {
            using (MesContext context = new MesContext())
            {
                var wsList = context.WORKING_SCHEDULE.Include(q => q.CREATED_USER)
                                                     .Where(q => q.IS_DELETED == false)
                                                     .Where(q => q.ISACTIVE == true)
                                                     .ToList();
                return wsList;
            }
        }

        public WORKING_SCHEDULE GetWorkingSchedule(int id)
        {
            using (MesContext context = new MesContext())
            {
                var ws = context.WORKING_SCHEDULE.FirstOrDefault(q => q.WORKING_SCHEDULE_ID == id);
                return ws;
            }
        }

        public bool InsertWorkingSchedule(WORKING_SCHEDULE ws)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    ws.CREATED_DATE = DateTime.Now;
                    context.WORKING_SCHEDULE.Add(ws);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool UpdateWorkingSchedule(WORKING_SCHEDULE workingSchedule)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var ws = context.WORKING_SCHEDULE.FirstOrDefault(q => q.WORKING_SCHEDULE_ID == workingSchedule.WORKING_SCHEDULE_ID);
                    if (ws != null)
                    {
                        ws.NAME = workingSchedule.NAME;
                        ws.START_TIME = workingSchedule.START_TIME;
                        ws.END_TIME = workingSchedule.END_TIME;
                        ws.ISACTIVE = workingSchedule.ISACTIVE;

                        ws.UPDATED_DATE = DateTime.Now;
                        ws.UPDATED_USER_ID = workingSchedule.UPDATED_USER_ID;
                    }
                    context.Entry(ws).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool DeleteWorkingSchedule(int Id)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var ws = context.WORKING_SCHEDULE.FirstOrDefault(q => q.WORKING_SCHEDULE_ID == Id);
                    ws.IS_DELETED = true;
                    context.Entry(ws).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
        //public bool DeleteWorkingSchedule(int Id)
        //{
        //    bool returnVal = false;
        //    try
        //    {
        //        using (MesContext context = new MesContext())
        //        {
        //            var ws = context.WORKING_SCHEDULE.FirstOrDefault(q => q.WORKING_SCHEDULE_ID == Id);
        //            context.WORKING_SCHEDULE.Remove(ws);
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
