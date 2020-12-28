using MES.API.Interfaces;
using MES.DB;
using MES.DB.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MES.API.Functions
{
    public class MenuFunctions:IMenu
    {
        public List<MENU> GetAllMenu()
        {
            using (MesContext context = new MesContext())
            {
                var menuList = context.MENU.OrderBy(q => q.MENU_SORT)
                                           .ToList();
                return menuList;
            }
        }

        public bool InsertMenu(MENU entity)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    context.MENU.Add(entity);
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
