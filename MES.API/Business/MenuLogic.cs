using MES.Data.Functions;
using MES.Data.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Business
{
    public class MenuLogic
    {
        IMenu _menu = new MenuFunctions();
        public List<MENU> GetAllMenu()
        {
            var menuList = _menu.GetAllMenu();
            return menuList;
        }

        public bool InsertMenu(MENU entity)
        {
            return _menu.InsertMenu(entity);
        }
    }
}
