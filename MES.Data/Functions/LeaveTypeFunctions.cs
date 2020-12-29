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
    public class LeaveTypeFunctions : ILeaveType
    {
        public List<LEAVE_TYPE> GetList()
        {
            using (MesContext context = new MesContext())
            {
                var leaveTypeList = context.LEAVE_TYPE.Include(q => q.CREATED_USER)
                                                      .Where(q => q.IS_DELETED == false)
                                                      .ToList();
                return leaveTypeList;
            }
        }

        public LEAVE_TYPE GetLeaveType(int id)
        {
            using (MesContext context = new MesContext())
            {
                var leaveType = context.LEAVE_TYPE.FirstOrDefault(q => q.LEAVE_TYPE_ID == id);
                return leaveType;
            }
        }

        public bool InsertLeaveType(LEAVE_TYPE leaveType)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    leaveType.CREATED_DATE = DateTime.Now;
                    context.LEAVE_TYPE.Add(leaveType);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool UpdateLeaveType(LEAVE_TYPE leaveType)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var _leaveType = context.LEAVE_TYPE.FirstOrDefault(q => q.LEAVE_TYPE_ID == leaveType.LEAVE_TYPE_ID);
                    if (_leaveType != null)
                    {
                        _leaveType.UPDATED_DATE = DateTime.Now;
                        _leaveType.UPDATED_USER_ID = leaveType.UPDATED_USER_ID;

                        _leaveType.NAME = leaveType.NAME;
                        _leaveType.CODE = leaveType.CODE;
                    }
                    context.Entry(leaveType).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool DeleteLeaveType(int Id)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var leaveType = context.LEAVE_TYPE.FirstOrDefault(q => q.LEAVE_TYPE_ID == Id);
                    leaveType.IS_DELETED = true;
                    context.Entry(leaveType).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        //public bool DeleteLeaveType(int Id)
        //{
        //    bool returnVal = false;
        //    try
        //    {
        //        using (MesContext context = new MesContext())
        //        {
        //            var leaveType = context.LEAVE_TYPE.FirstOrDefault(q => q.LEAVE_TYPE_ID == Id);
        //            context.LEAVE_TYPE.Remove(leaveType);
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
