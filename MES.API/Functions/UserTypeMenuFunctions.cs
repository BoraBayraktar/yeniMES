using MES.DB;
using MES.DB.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MES.API.Functions
{
    public class UserTypeMenuFunctions
    {
        public List<USERTYPE_MENU> GetList()
        {
            using (MesContext context = new MesContext())
            {
                var userTypeList = context.USERTYPE_MENU.ToList();
                return userTypeList;
            }
        }

        public USERTYPE_MENU GetUserType(int menuId,int userTypeId)
        {
            using (MesContext context = new MesContext())
            {
                var userTypeMenu = context.USERTYPE_MENU.FirstOrDefault(q => q.MenuId == menuId && q.UserTypeId == userTypeId);
                return userTypeMenu;
            }
        }

        public bool InsertUserType(USERTYPE_MENU userTypeMenu)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    context.USERTYPE_MENU.Add(userTypeMenu);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool UpdateUserType(USERTYPE_MENU userTypeMenu)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var model = context.USERTYPE_MENU.FirstOrDefault(q => q.UserTypeId == userTypeMenu.UserTypeId && q.MenuId == userTypeMenu.MenuId);
                    if (model != null)
                    {
                        model.Checked = userTypeMenu.Checked;
                    }
                    context.Entry(model).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool DeleteUserType(int userTypeId,int menuId)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var userTypeMenu = context.USERTYPE_MENU.FirstOrDefault(q => q.UserTypeId == userTypeId && q.MenuId == menuId);
                    context.Remove(userTypeMenu);
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
