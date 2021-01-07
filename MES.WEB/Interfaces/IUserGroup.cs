using MES.Web.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Web.Interfaces
{
    public interface IUserGroup
    {
        List<USER_GROUP> GetList();
        USER_GROUP GetUserGroup(int id);
        bool InsertUserGroup(USER_GROUP userGroup);
        bool UpdateUserGroup(USER_GROUP userGroup);
        bool DeleteUserGroup(int Id);
    }
}
