using MES.API.Encrypter;
using MES.API.JwtToken;
using MES.API.Logger;
using MES.Data.Logics;
using MES.DB.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        IJwtAuthenticationManager jwtAuthentication;
        private Encryption encryption = new Encryption();
        Log logger = new Log();
        public UserController(IJwtAuthenticationManager jwtAuthenticationManager, IHttpContextAccessor accessor)
        {
            this.jwtAuthentication = jwtAuthenticationManager;
            userid = Convert.ToInt32(accessor?.HttpContext.User.FindFirstValue(ClaimTypes.SerialNumber));
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
            user.PASSWORD = encryption.Decrypt(user.PASSWORD);
            return logger.Logging<bool>(user, "User", "Post", userid, "InsertUser", userLogic.InsertUser(user));
        }
        [HttpPost("UpdateUser")]
        public bool UpdateUser(USER user)
        {
            user.PASSWORD = encryption.Decrypt(user.PASSWORD);
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
            USER user =  logger.Logging<USER>(id, "User", "Post", userid, "GetUser", userLogic.GetUser(id));
            user.PASSWORD = null;
            return user;
        }
        #endregion
    }
}
