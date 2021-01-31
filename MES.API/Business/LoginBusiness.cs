using MES.API.Encrypter;
using MES.API.JwtToken;
using MES.API.ViewModels;
using MES.Data.Logics;
using MES.DB.Model;
using Microsoft.Extensions.DependencyInjection;
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
        Encryption encryption = new Encryption();
        private JwtAuthenticationManager jwtAuthentication;
        public LoginBusiness()
        {
            
        }
        public USER LoginMain(UserViewModel userViewModel)
        {
            USER user = userLogic.CheckUser(userViewModel.Username, userViewModel.Password);
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public string GetJwt(UserViewModel userViewModel)
        {
            return jwtAuthentication.Authenticate(userViewModel);
        }
        public List<MENU> SetAuthMenu(int userTypeId)
        {
            try
            {
                var firstMenuModel = menuLogic.GetAllMenu();
                var userTypeMenuModel = userTypeMenuLogic.GetList().Where(x => x.UserTypeId == userTypeId).ToList();
                var lastMenuModel = firstMenuModel.Where(item => userTypeMenuModel.Any(utm => utm.MenuId == item.MENU_ID)).ToList();
                var modifedMenu = AddTopMenu(lastMenuModel);
                return modifedMenu;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<MENU> AddTopMenu(List<MENU> lastmenu) 
        {
            List<MENU> result = new List<MENU>(lastmenu);
            foreach (var item in lastmenu)
            {
                if (item.TOPMENU == null) continue;
                if (!result.Contains(item.TOPMENU))
                {
                    result.Add(item.TOPMENU);
                    if (item.TOPMENU.TOPMENU != null && !result.Contains(item.TOPMENU.TOPMENU))
                    {
                        result.Add(item.TOPMENU.TOPMENU);
                    }
                }
            }
            return result;
        }
        public GENERAL_SETTINGS GeneralSettings()
        {
            return new GeneralSettingsLogic().GetGeneralSettings();
        }
        public USER EmailCheck(UserViewModel userViewModel)
        {
            return userLogic.GetUser(userViewModel.Email);
        }
        public void DeletePassChange(int UserId)
        {
            passwordChangeLogic.DeleteAllPasswordChange(UserId);
        }
        public bool InsertPassChange(PASSWORD_CHANGE_HISTORY pch)
        {
            return passwordChangeLogic.InsertPasswordChange(pch);
        }
        public bool InsertMailToSend(MAIL_TO_SEND mailToSend)
        {
            return mailToSendLogic.InsertMailToSend(mailToSend);
        }
        public PASSWORD_CHANGE_HISTORY GetPassChange(string guid)
        {
            return passwordChangeLogic.GetPasswordChange(guid);
        }
        public void UpdatePassChange(int pcId)
        {
            passwordChangeLogic.UpdatePasswordChange(pcId);
        }
        public void UserChangePassword(List<(int, string)> list)
        {
            userLogic.UserChangePassword(list.First().Item1, encryption.Decrypt(list.First().Item2));
        }
    }
}
