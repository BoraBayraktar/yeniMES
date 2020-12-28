﻿using MES.API.Functions;
using MES.API.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.API.Business
{
    public class UserGroupLogic
    {
        IUserGroup _userGroup = new UserGroupFunctions();
        public List<USER_GROUP> GetList()
        {
            var userGroupList = _userGroup.GetList();
            return userGroupList;
        }
        public bool InsertUserGroup(USER_GROUP userGroup)
        {
            var success = _userGroup.InsertUserGroup(userGroup);
            return success;
        }
        public bool UpdateUserGroup(USER_GROUP userGroup)
        {
            var success = _userGroup.UpdateUserGroup(userGroup);
            return success;
        }
        public bool DeleteUserGroup(int Id)
        {
            var success = _userGroup.DeleteUserGroup(Id);
            return success;
        }
        public USER_GROUP GetUserGroup(int id)
        {
            var userGroup = _userGroup.GetUserGroup(id);
            return userGroup;
        }
    }
}
