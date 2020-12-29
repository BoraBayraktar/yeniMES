using MES.Data.Functions;
using MES.Data.Interfaces;
using MES.DB.Model;
using System.Collections.Generic;

namespace MES.Data.Business
{
    public class UserLogic
    {
        IUser _user = new UserFunctions();
        public USER CheckUser(string username, string password)
        {
            var user = _user.CheckUser(username, password);
            return user;
        }

        public List<USER> GetList()
        {
            var userList = _user.GetList();
            return userList;
        }
        public bool InsertUser(USER user)
        {
            var success = _user.InsertUser(user);
            return success;
        } 
        public bool InsertUser(List<USER> entities)
        {
            var success = _user.InsertUser(entities);
            return success;
        }
        public bool UpdateUser(USER user)
        {
            var success = _user.UpdateUser(user);
            return success;
        }
        public bool DeleteUser(int Id)
        {
            var success = _user.DeleteUser(Id);
            return success;
        }
        public USER GetUser(int id)
        {
            var user = _user.GetUser(id);
            return user;
        }

        public USER GetUser(string email)
        {
            var user = _user.GetUser(email);
            return user;
        }

        public bool UserChangePassword(int userId,string newPassword)
        {
            var success = _user.UserChangePassword(userId, newPassword);
            return success;
        }

        public List<USER> GetGroupUser(int groupId)
        {
            var userList = _user.GetGroupUser(groupId);
            return userList;
        }
    }
}
