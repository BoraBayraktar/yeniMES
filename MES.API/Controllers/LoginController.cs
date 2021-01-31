using MES.Data.Logics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using MES.API.ViewModels;
using MES.API.Business;
using MES.DB.Model;
using MES.API.Logger;
using Newtonsoft.Json;
using MES.API.JwtToken;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;
using MES.API.Encrypter;

namespace MES.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private int requestId;
        public int userid;
        private JwtAuthenticationManager jwtAuthentication;
        Log logger = new Log();
        public LoginController()
        {
            userid = 0;
        }

        //[ValidateAntiForgeryToken]
        [HttpPost("LogMain")]
        public USER LogMain(UserViewModel userViewModel)
        {
            return logger.Logging<USER>(userViewModel, "LoginController", "Post", userid, "LogMain", new LoginBusiness().LoginMain(userViewModel));
        }
        [HttpPost("GetJwt")]
        public string GetJwt(UserViewModel userViewModel)
        {
            return logger.Logging<string>(userViewModel, "LoginController", "Post", userid, "GetJwt", new LoginBusiness().GetJwt(userViewModel));
        }
        [HttpPost("SetAuthMenu")]
        public List<MENU> SetAuthMenu(int userTypeId)
        {
            return logger.Logging<List<MENU>>(userTypeId, "LoginController", "Post", userid, "SetAuthMenu", new LoginBusiness().SetAuthMenu(userTypeId));
        }

        [HttpGet("GeneralSettings")]
        public GENERAL_SETTINGS GeneralSettings()
        {
            return logger.Logging<GENERAL_SETTINGS>(null, "LoginController", "Get", userid, "GeneralSettings", new LoginBusiness().GeneralSettings());
        }

        [HttpPost("EmailCheck")]
        public USER EmailCheck(UserViewModel userViewModel)
        {
            return logger.Logging<USER>(userViewModel, "LoginController", "Post", userid, "EmailCheck", new LoginBusiness().EmailCheck(userViewModel));
        }
        [HttpDelete("DeletePassChange")]
        public void DeletePassChange(int UserId)
        {
            logger.LoggingNoReturn(UserId, "LoginController", "Delete", userid, "DeletePassChange");
            new LoginBusiness().DeletePassChange(UserId);
        }
        [HttpPost("InsertPassChange")]
        public bool InsertPassChange(PASSWORD_CHANGE_HISTORY pch)
        {
            return logger.Logging<bool>(pch, "LoginController", "Post", userid, "InsertPassChange", new LoginBusiness().InsertPassChange(pch));
        }
        [HttpPost("InsertMailToSend")]
        public bool InsertMailToSend(MAIL_TO_SEND mailToSend)
        {
            return logger.Logging<bool>(mailToSend, "LoginController", "Post", userid, "InsertMailToSend", new LoginBusiness().InsertMailToSend(mailToSend));
        }
        [HttpPost("GetPassChange")]
        public PASSWORD_CHANGE_HISTORY GetPassChange(string guid)
        {
            return logger.Logging<PASSWORD_CHANGE_HISTORY>(guid, "LoginController", "Post", userid, "GetPassChange", new LoginBusiness().GetPassChange(guid));
        }
        [HttpPut("UpdatePassChange")]
        public void UpdatePassChange(int pcId)
        {
            logger.LoggingNoReturn(pcId, "LoginController", "Put", userid, "UpdatePassChange");
            new LoginBusiness().UpdatePassChange(pcId);
        }
        [HttpPut("UserChangePassword")]
        public void UserChangePassword(List<(int, string)> list)
        {
            logger.LoggingNoReturn(list, "LoginController", "Put", userid, "UserChangePassword");
            new LoginBusiness().UserChangePassword(list);
        }

    }
}
