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
    public class PasswordChangeFunctions : IPasswordChange
    {
        public List<PASSWORD_CHANGE_HISTORY> GetList()
        {
            using (MesContext context = new MesContext())
            {
                var pcList = context.PASSWORD_CHANGE_HISTORY.Where(q => q.IS_DELETED == false).ToList();
                return pcList;
            }
        }

        public PASSWORD_CHANGE_HISTORY GetPasswordChange(int id)
        {
            using (MesContext context = new MesContext())
            {
                var pc = context.PASSWORD_CHANGE_HISTORY.FirstOrDefault(q => q.ID == id && q.IS_DELETED == false);
                return pc;
            }
        }

        public PASSWORD_CHANGE_HISTORY GetPasswordChange(string guid)
        {
            using (MesContext context = new MesContext())
            {
                var pc = context.PASSWORD_CHANGE_HISTORY.FirstOrDefault(q => q.UNIQUE_IDENTIFIER.ToString() == guid && q.IS_DELETED == false);
                return pc;
            }
        }

        public bool InsertPasswordChange(PASSWORD_CHANGE_HISTORY pc)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    context.PASSWORD_CHANGE_HISTORY.Add(pc);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        //public bool UpdatePasswordChange(PASSWORD_CHANGE_HISTORY passwordChange)
        //{
        //    bool returnVal = false;
        //    try
        //    {
        //        using (MesContext context = new MesContext())
        //        {
        //            var pc = context.PASSWORD_CHANGE_HISTORY.FirstOrDefault(q => q.ID == passwordChange.ID);
        //            if (pc != null)
        //            {
        //            }
        //            context.Entry(pc).State = EntityState.Modified;
        //            context.SaveChanges();
        //            returnVal = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return returnVal;
        //}


        public bool DeletePasswordChange(int Id)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var pc = context.PASSWORD_CHANGE_HISTORY.FirstOrDefault(q => q.ID == Id);
                    pc.IS_DELETED = true;
                    context.Entry(pc).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }


        public bool DeleteAllPasswordChange(int userId)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var pcList = context.PASSWORD_CHANGE_HISTORY.Where(q => q.USER_ID == userId).ToList();
                    pcList.ForEach(q => q.IS_DELETED = true);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool UpdatePasswordChange(int Id)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var pc = context.PASSWORD_CHANGE_HISTORY.FirstOrDefault(q => q.ID == Id);
                    if (pc != null)
                    {
                        pc.CHANGE_DATE = DateTime.Now;
                        pc.IS_DELETED = true;
                    }
                    context.Entry(pc).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
    }
}
