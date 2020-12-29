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
    public class LeaveFunctions : ILeave
    {
        public List<LEAVE> GetList()
        {
            using (MesContext context = new MesContext())
            {
                var leaveList = context.LEAVE.Include(q => q.CREATED_USER)
                                             .Include(q => q.LEAVE_TYPE)
                                             .Include(q => q.USER)
                                             .Where(q => q.IS_DELETED == false)
                                             .ToList();
                return leaveList;
            }
        }

        public LEAVE GetLeave(int id)
        {
            using (MesContext context = new MesContext())
            {
                var leave = context.LEAVE.FirstOrDefault(q => q.LEAVE_ID == id);
                return leave;
            }
        }

        public bool InsertLeave(LEAVE leave)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    leave.CREATED_DATE = DateTime.Now;
                    context.LEAVE.Add(leave);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool UpdateLeave(LEAVE _leave)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var leave = context.LEAVE.FirstOrDefault(q => q.LEAVE_ID == _leave.LEAVE_ID);
                    if (leave != null)
                    {
                        leave.UPDATED_DATE = DateTime.Now;
                        leave.UPDATED_USER_ID = _leave.UPDATED_USER_ID;

                        leave.DESCRIPTION = _leave.DESCRIPTION;
                        leave.START_DATE = _leave.START_DATE;
                        leave.END_DATE = _leave.END_DATE;
                        leave.TOTAL_DAY = _leave.TOTAL_DAY;
                        leave.LEAVE_TYPE_ID = _leave.LEAVE_TYPE_ID;


                    }
                    context.Entry(leave).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }


        public bool DeleteLeave(int Id)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var leave = context.LEAVE.FirstOrDefault(q => q.LEAVE_ID == Id);
                    leave.IS_DELETED = true;
                    context.Entry(leave).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
        //public bool DeleteLeave(int Id)
        //{
        //    bool returnVal = false;
        //    try
        //    {
        //        using (MesContext context = new MesContext())
        //        {
        //            var leave = context.LEAVE.FirstOrDefault(q => q.LEAVE_ID == Id);
        //            context.LEAVE.Remove(leave);
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
