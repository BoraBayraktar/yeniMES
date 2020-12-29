using MES.DB.Model;
using System.Collections.Generic;

namespace MES.Data.Interfaces
{
    public interface IUser
    {
        USER CheckUser(string username, string password);
        List<USER> GetList();
        USER GetUser(int id);
        USER GetUser(string email);

        bool InsertUser(USER user);
        bool InsertUser(List<USER> users);
        bool UpdateUser(USER user);
        bool DeleteUser(int Id);

        bool UserChangePassword(int userId, string newPassword);

        List<USER> GetGroupUser(int groupId);
    }
}
