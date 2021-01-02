using MES.Data.Interfaces;
using MES.DB;
using MES.DB.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MES.Data.Functions
{
    public class UserFunctions : IUser
    {
        public USER CheckUser(string username, string password)
        {
            using (MesContext context = new MesContext())
            {
                var user = context.USER.FirstOrDefault(q => q.USERNAME == username && q.PASSWORD == password);
                return user;
            }
        }

        public List<USER> GetList()
        {
            using (MesContext context = new MesContext())
            {
                var userList = context.USER
                                           .Include(q => q.DEPARTMENT)
                                           .Include(q => q.TITLE)
                                           .Include(q => q.USER_TYPE)
                                           .Include(q => q.LOCATION)
                                           .Include(q => q.USER_GROUP)
                                           .Where(q => q.IS_DELETED == false)
                                           .ToList();
                return userList;
            }
        }

        public USER GetUser(int id)
        {
            using (MesContext context = new MesContext())
            {
                var user = context.USER.FirstOrDefault(q => q.USER_ID == id);
                return user;
            }
        }

        public USER GetUser(string email)
        {
            using (MesContext context = new MesContext())
            {
                var user = context.USER.FirstOrDefault(q => q.EMAIL == email);
                return user;
            }
        }

        public bool InsertUser(USER user)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    user.CREATED_DATE = DateTime.Now;
                    context.USER.Add(user);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool InsertUser(List<USER> entities)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    context.USER.AddRange(entities);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
                throw  new Exception(ex.InnerException.Message);
            }
            return returnVal;
        }
        public bool UpdateUser(USER user)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var _user = context.USER.FirstOrDefault(q => q.USER_ID == user.USER_ID);
                    if (_user != null)
                    {
                        _user.UPDATED_DATE = DateTime.Now;


                        _user.NAME = user.NAME;
                        _user.SURNAME = user.SURNAME;
                        _user.USERNAME = user.USERNAME;
                        _user.PASSWORD = user.PASSWORD;
                        _user.EMAIL = user.EMAIL;
                        _user.DESCRIPTION = user.DESCRIPTION;
                        _user.LOCATION_ID = user.LOCATION_ID;
                        _user.DEPARTMENT_ID = user.DEPARTMENT_ID;
                        _user.TITLE_ID = user.TITLE_ID;
                        _user.USER_TYPE_ID = user.USER_TYPE_ID;
                        _user.USER_GROUP_ID = user.USER_GROUP_ID;
                        _user.USER_ISACTIVE = user.USER_ISACTIVE;
                        _user.IMAGE_PATH = user.IMAGE_PATH;
                        _user.USER_ISACTIVE = user.USER_ISACTIVE;

                    }
                    context.Entry(_user).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool DeleteUser(int Id)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var user = context.USER.FirstOrDefault(q => q.USER_ID == Id);
                    user.IS_DELETED = true;
                    context.Entry(user).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool UserChangePassword(int userId, string newPassword)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var user = context.USER.FirstOrDefault(q => q.USER_ID == userId);
                    user.PASSWORD = newPassword;
                    context.Entry(user).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }


        public List<USER> GetGroupUser(int groupId)
        {
            using (MesContext context = new MesContext())
            {
                var userList = context.USER.Where(q => q.IS_DELETED == false && q.USER_GROUP_ID==groupId)
                                           .ToList();
                return userList;
            }
        }



        //public bool DeleteUser(int Id)
        //{
        //    bool returnVal = false;
        //    try
        //    {
        //        using (MesContext context = new MesContext())
        //        {
        //            var user = context.USER.FirstOrDefault(q => q.USER_ID == Id);
        //            context.USER.Remove(user);
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
