using MES.Data.Functions;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Business
{
    public class UserTypeMenuLogic
    {
        UserTypeMenuFunctions _userTypeMenu = new UserTypeMenuFunctions();
        public List<USERTYPE_MENU> GetList()
        {
            var userTypeMenuList = _userTypeMenu.GetList();
            return userTypeMenuList;
        }
        public bool InsertUserTypeMenu(USERTYPE_MENU userTypeMenu)
        {
            var success = _userTypeMenu.InsertUserType(userTypeMenu);
            return success;
        }
        public bool UpdateUserTypeMenu(USERTYPE_MENU userTypeMenu)
        {
            var success = _userTypeMenu.UpdateUserType(userTypeMenu);
            return success;
        }
        public bool DeleteUserTypeMenu(int userTypeId,int menuId)
        {
            var success = _userTypeMenu.DeleteUserType(userTypeId,menuId);
            return success;
        }
    }
}
