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
    public class UserTypeFunctions : IUserType
    {
        public List<USER_TYPE> GetList()
        {
            using (MesContext context = new MesContext())
            {
                var userTypeList = context.USER_TYPE.Include(q => q.CREATED_USER)
                                                    .Include(q=>q.USERTYPE_MENUS)
                                                    .Where(q => q.IS_DELETED == false)
                                                    .ToList();
                return userTypeList;
            }
        }

        public USER_TYPE GetUserType(int id)
        {
            using (MesContext context = new MesContext())
            {
                var userType = context.USER_TYPE.FirstOrDefault(q => q.USER_TYPE_ID == id);
                return userType;
            }
        }

        public bool InsertUserType(USER_TYPE userType)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    context.USER_TYPE.Add(userType);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool UpdateUserType(USER_TYPE userType)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var uType = context.USER_TYPE.FirstOrDefault(q => q.USER_TYPE_ID == userType.USER_TYPE_ID);
                    if (uType != null)
                    {
                        uType.CODE = userType.CODE;
                        uType.NAME = userType.NAME;
                    }
                    context.Entry(uType).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool DeleteUserType(int Id)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var userType = context.USER_TYPE.FirstOrDefault(q => q.USER_TYPE_ID == Id);
                    userType.IS_DELETED = true;
                    context.Entry(userType).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
        //public bool DeleteUserType(int Id)
        //{
        //    bool returnVal = false;
        //    try
        //    {
        //        using (MesContext context = new MesContext())
        //        {
        //            var userType = context.USER_TYPE.FirstOrDefault(q => q.USER_TYPE_ID == Id);
        //            context.USER_TYPE.Remove(userType);
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
