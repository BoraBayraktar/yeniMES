using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Interfaces
{
    public interface IPasswordChange
    {
        List<PASSWORD_CHANGE_HISTORY> GetList();
        PASSWORD_CHANGE_HISTORY GetPasswordChange(int id);
        PASSWORD_CHANGE_HISTORY GetPasswordChange(string guid);

        bool InsertPasswordChange(PASSWORD_CHANGE_HISTORY passwordChange);
        bool UpdatePasswordChange(int Id);
        bool DeletePasswordChange(int Id);

        bool DeleteAllPasswordChange(int userId);

    }
}
