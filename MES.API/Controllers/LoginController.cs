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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;

namespace MES.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        public int requestId;
        public int userid;
        IJwtAuthenticationManager jwtAuthenticationManager;
        private IHttpContextAccessor accessor;
        LoginBusiness loginBusiness;
        Log logger = new Log();
        public LoginController(IJwtAuthenticationManager jwtAuthenticationManager, IHttpContextAccessor accessor)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
            loginBusiness = new LoginBusiness(jwtAuthenticationManager);
            userid = Convert.ToInt32(accessor?.HttpContext.User.FindFirstValue(ClaimTypes.SerialNumber));
            this.accessor = accessor;
        }
        [AllowAnonymous]
        [HttpPost("LogMain")]
        public (USER, string) LogMain(UserViewModel userViewModel)
        {
            return logger.Logging<(USER, string)>(userViewModel, "LoginController", "Post", 0, "LogMain", loginBusiness.LoginMain(userViewModel));
        }
        [HttpPost("SetAuthMenu")]
        public List<MENU> SetAuthMenu([FromBody]int userTypeId)
        {
            return logger.Logging<List<MENU>>(userTypeId, "LoginController", "Post", userid, "SetAuthMenu", loginBusiness.SetAuthMenu(userTypeId));
        }
        [HttpPost("EmailCheck")]
        public USER EmailCheck(UserViewModel userViewModel)
        {
            return logger.Logging<USER>(userViewModel, "LoginController", "Post", userid, "EmailCheck", loginBusiness.EmailCheck(userViewModel));
        }
        [HttpDelete("DeletePassChange")]
        public void DeletePassChange([FromBody]int UserId)
        {
            logger.LoggingNoReturn(UserId, "LoginController", "Delete", userid, "DeletePassChange");
            loginBusiness.DeletePassChange(UserId);
        }
        [HttpPost("InsertPassChange")]
        public bool InsertPassChange(PASSWORD_CHANGE_HISTORY pch)
        {
            return logger.Logging<bool>(pch, "LoginController", "Post", userid, "InsertPassChange", loginBusiness.InsertPassChange(pch));
        }
        [HttpPost("InsertMailToSend")]
        public bool InsertMailToSend(MAIL_TO_SEND mailToSend)
        {
            return logger.Logging<bool>(mailToSend, "LoginController", "Post", userid, "InsertMailToSend", loginBusiness.InsertMailToSend(mailToSend));
        }
        [HttpPost("GetPassChange")]
        public PASSWORD_CHANGE_HISTORY GetPassChange(string guid)
        {
            return logger.Logging<PASSWORD_CHANGE_HISTORY>(guid, "LoginController", "Post", userid, "GetPassChange", loginBusiness.GetPassChange(guid));
        }
        [HttpPost("UpdatePassChange")]
        public void UpdatePassChange([FromBody] int pcId)
        {
            logger.LoggingNoReturn(pcId, "LoginController", "Put", userid, "UpdatePassChange");
            loginBusiness.UpdatePassChange(pcId);
        }
        [HttpPost("UserChangePassword")]
        public void UserChangePassword((int, string) IdPassword)
        {
            logger.LoggingNoReturn(IdPassword, "LoginController", "Put", userid, "UserChangePassword");
            loginBusiness.UserChangePassword(IdPassword);
        }

    }
}
