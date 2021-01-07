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

        [HttpPost("SignIn")]
        [ValidateAntiForgeryToken]
        public bool SignIn(UserViewModel userViewModel)
        {
            requestId = new LoggerBusiness().RequestLog(new LOGGER_REQUEST() { CONTROLLER = "SignInController", METHOD = "Post", USER_ID = userViewModel.user.USER_ID, DATE = DateTime.Now, PATH = "SignIn", JSONDATA = JsonConvert.SerializeObject(userViewModel) });

            var response = new LoginBusiness(jwtAuthenticationManager).LoginMain(userViewModel);

            new LoggerBusiness().ResponseLog(new LOGGER_RESPONSE() { CONTROLLER = "SignInController", METHOD = "Post", USER_ID = userViewModel.user.USER_ID, DATE = DateTime.Now, PATH = "SignIn", JSONDATA = JsonConvert.SerializeObject(response), REQUEST_ID = requestId });
            return response;
        }


    }
}
