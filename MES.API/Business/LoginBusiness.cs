using MES.API.ViewModels;
using MES.Data.Logics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.API.Business
{
    public class LoginBusiness
    {
        UserLogic userLogic = new UserLogic();
        PasswordChangeLogic passwordChangeLogic = new PasswordChangeLogic();
        MailToSendLogic mailToSendLogic = new MailToSendLogic();
        MenuLogic menuLogic = new MenuLogic();
        UserTypeMenuLogic userTypeMenuLogic = new UserTypeMenuLogic();
        private Encryption.Encryption encryption;
        public bool LoginMain(UserViewModel userViewModel)
        {
            var user = userLogic.CheckUser(userViewModel.Username, encryption.Decrypt(userViewModel.Password));
            if ( user == null)
            {
                return false;
            }
        
        }

        public int SetAuthMenu(int userTypeId)
        { 
        
        }
    }
}
