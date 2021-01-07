﻿using MES.Web.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Web.Interfaces
{
    public interface IUserType
    {
        List<USER_TYPE> GetList();
        USER_TYPE GetUserType(int id);
        bool InsertUserType(USER_TYPE userType);
        bool UpdateUserType(USER_TYPE userType);
        bool DeleteUserType(int Id);
    }
}
