using MES.Data.Functions;
using MES.Data.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Logics
{
    public class UserTypeLogic
    {
        IUserType _userType = new UserTypeFunctions();
        public List<USER_TYPE> GetList()
        {
            var userTypeList = _userType.GetList();
            return userTypeList;
        }
        public bool InsertUserType(USER_TYPE userType)
        {
            var success = _userType.InsertUserType(userType);
            return success;
        }
        public bool UpdateUserType(USER_TYPE userType)
        {
            var success = _userType.UpdateUserType(userType);
            return success;
        }
        public bool DeleteUserType(int Id)
        {
            var success = _userType.DeleteUserType(Id);
            return success;
        }
        public USER_TYPE GetUserType(int id)
        {
            var userType = _userType.GetUserType(id);
            return userType;
        }
    }
}
