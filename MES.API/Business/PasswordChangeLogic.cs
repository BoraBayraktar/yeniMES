using MES.Data.Functions;
using MES.Data.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Business
{
    public class PasswordChangeLogic
    {
        IPasswordChange _passwordChange = new PasswordChangeFunctions();
        public List<PASSWORD_CHANGE_HISTORY> GetList()
        {
            var pcList = _passwordChange.GetList();
            return pcList;
        }
        public bool InsertPasswordChange(PASSWORD_CHANGE_HISTORY passwordChange)
        {
            var success = _passwordChange.InsertPasswordChange(passwordChange);
            return success;
        }
        public bool UpdatePasswordChange(int Id)
        {
            var success = _passwordChange.UpdatePasswordChange(Id);
            return success;
        }
        public bool DeletePasswordChange(int Id)
        {
            var success = _passwordChange.DeletePasswordChange(Id);
            return success;
        }

        public bool DeleteAllPasswordChange(int userId)
        {
            var success = _passwordChange.DeleteAllPasswordChange(userId);
            return success;
        }

        public PASSWORD_CHANGE_HISTORY GetPasswordChange(int id)
        {
            var pc = _passwordChange.GetPasswordChange(id);
            return pc;
        }

        public PASSWORD_CHANGE_HISTORY GetPasswordChange(string guid)
        {
            var pc = _passwordChange.GetPasswordChange(guid);
            return pc;
        }
    }
}
