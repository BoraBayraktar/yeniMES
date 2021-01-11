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

namespace MES.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private JwtAuthenticationManager jwtAuthenticationManager;
        private int requestId;
        private int userid;

        [HttpPost]
        [ValidateAntiForgeryToken]
        public USER LogMain(UserViewModel userViewModel)
        {
            requestId = new LoggerBusiness().RequestLog(new LOGGER_REQUEST() { CONTROLLER = "LoginController", METHOD = "Post", USER_ID = userViewModel.user.USER_ID, DATE = DateTime.Now, PATH = "LoginMain", JSONDATA = JsonConvert.SerializeObject(userViewModel) });

            var response = new LoginBusiness(jwtAuthenticationManager).LoginMain(userViewModel);

            if (response.USER_ID != 0) { userid = response.USER_ID; }

            new LoggerBusiness().ResponseLog(new LOGGER_RESPONSE() { CONTROLLER = "LoginController", METHOD = "Post", USER_ID = userViewModel.user.USER_ID, DATE = DateTime.Now, PATH = "LoginMain", JSONDATA = JsonConvert.SerializeObject(response), REQUEST_ID = requestId });
            return response;
        }
        [HttpPost]
        public string GetJwt(UserViewModel userViewModel)
        {
            requestId = new LoggerBusiness().RequestLog(new LOGGER_REQUEST() { CONTROLLER = "LoginController", METHOD = "Post", USER_ID = userViewModel.user.USER_ID, DATE = DateTime.Now, PATH = "LoginMain", JSONDATA = JsonConvert.SerializeObject(userViewModel) });

            var response = new LoginBusiness(jwtAuthenticationManager).GetJwt(userViewModel);

            new LoggerBusiness().ResponseLog(new LOGGER_RESPONSE() { CONTROLLER = "LoginController", METHOD = "Post", USER_ID = userViewModel.user.USER_ID, DATE = DateTime.Now, PATH = "LoginMain", JSONDATA = JsonConvert.SerializeObject(response), REQUEST_ID = requestId });
            return response;
        }

        [HttpPost]
        public List<MENU> SetAuthMenu(int userTypeId)
        {
            requestId = new LoggerBusiness().RequestLog(new LOGGER_REQUEST() { CONTROLLER = "LoginController", METHOD = "Post", USER_ID = userid, DATE = DateTime.Now, PATH = "SetAuthMenu", JSONDATA = JsonConvert.SerializeObject(userTypeId) });

            var response = new LoginBusiness(jwtAuthenticationManager).SetAuthMenu(userTypeId);

            new LoggerBusiness().ResponseLog(new LOGGER_RESPONSE() { CONTROLLER = "LoginController", METHOD = "Post", USER_ID = userid, DATE = DateTime.Now, PATH = "SetAuthMenu", JSONDATA = JsonConvert.SerializeObject(response), REQUEST_ID = requestId });
            return response;
        }


    }
}
