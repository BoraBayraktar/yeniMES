﻿using MES.API.Logger;
using MES.Data.Logics;
using MES.DB.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserLogic userLogic = new UserLogic();
        private int userid;
        Log logger = new Log();
        public UserController()
        {
            userid = Convert.ToInt32(User.FindFirst("Name").Value);
        }
        #region User
        [HttpGet("UserGetList")]
        public List<USER> UserGetList()
        {
            return logger.Logging<List<USER>>(null, "User", "Get", userid, "UserGetList", userLogic.GetList());
        }
        [HttpPost("InsertUser")]
        public bool InsertUser(USER user)
        {
            return logger.Logging<bool>(user, "User", "Post", userid, "InsertUser", userLogic.InsertUser(user));
        }
        [HttpPost("UpdateUser")]
        public bool UpdateUser(USER user)
        {
            return logger.Logging<bool>(user, "User", "Post", userid, "UpdateUser", userLogic.UpdateUser(user));
        }
        [HttpPost("DeleteUser")]
        public bool DeleteUser([FromBody] int deleteId)
        {
            return logger.Logging<bool>(deleteId, "User", "Post", userid, "DeleteUser", userLogic.DeleteUser(deleteId));
        }
        [HttpPost("GetUser")]
        public USER GetUser([FromBody] int id)
        {
            return logger.Logging<USER>(id, "User", "Post", userid, "GetUser", userLogic.GetUser(id));
        }
        #endregion
    }
}
