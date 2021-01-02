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
    public class UserGroupFunctions : IUserGroup
    {
        public List<USER_GROUP> GetList()
        {
            using (MesContext context = new MesContext())
            {
                var userGroupList = context.USER_GROUP.Where(q => q.IS_DELETED == false).ToList();
                return userGroupList;
            }
        }

        public USER_GROUP GetUserGroup(int id)
        {
            using (MesContext context = new MesContext())
            {
                var userGroup = context.USER_GROUP.FirstOrDefault(q => q.USER_GROUP_ID == id);
                return userGroup;
            }
        }

        public bool InsertUserGroup(USER_GROUP userGroup)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    userGroup.CREATED_DATE = DateTime.Now;
                    context.USER_GROUP.Add(userGroup);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool UpdateUserGroup(USER_GROUP userGroup)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var ugroup = context.USER_GROUP.FirstOrDefault(q => q.USER_GROUP_ID == userGroup.USER_GROUP_ID);
                    if (ugroup != null)
                    {
                        ugroup.CODE = userGroup.CODE;
                        ugroup.NAME = userGroup.NAME;

                        ugroup.UPDATED_DATE = DateTime.Now;

                    }
                    context.Entry(ugroup).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool DeleteUserGroup(int Id)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var userGroup = context.USER_GROUP.FirstOrDefault(q => q.USER_GROUP_ID == Id);
                    userGroup.IS_DELETED = true;
                    context.Entry(userGroup).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
        //public bool DeleteUserGroup(int Id)
        //{
        //    bool returnVal = false;
        //    try
        //    {
        //        using (MesContext context = new MesContext())
        //        {
        //            var userGroup = context.USER_GROUP.FirstOrDefault(q => q.USER_GROUP_ID == Id);
        //            context.USER_GROUP.Remove(userGroup);
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
