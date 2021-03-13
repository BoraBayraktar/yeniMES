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
    public class UserGroupController : ControllerBase
    {
        Log logger = new Log();
        private int userid;
        private JwtAuthenticationManager jwtAuthentication;
        UserGroupLogic userGroupLogic = new UserGroupLogic();
        public UserGroupController(IHttpContextAccessor accessor)
        {
            userid = Convert.ToInt32(accessor?.HttpContext.User.FindFirstValue(ClaimTypes.SerialNumber));
        }
        #region UserGroup
        [HttpGet("UserGroupGetList")]
        public List<USER_GROUP> UserGroupGetList()
        {
            return logger.Logging<List<USER_GROUP>>(null, "UserGroup", "Get", userid, "UserGroupGetList", userGroupLogic.GetList());
        }
        [HttpPost("InsertUserGroup")]
        public bool InsertUserGroup(USER_GROUP userGroup)
        {
            return logger.Logging<bool>(userGroup, "UserGroup", "Post", userid, "InsertUserGroup", userGroupLogic.InsertUserGroup(userGroup));
        }
        [HttpPost("UpdateUserGroup")]
        public bool UpdateUserGroup(USER_GROUP userGroup)
        {
            return logger.Logging<bool>(userGroup, "UserGroup", "Post", userid, "UpdateUserGroup", userGroupLogic.UpdateUserGroup(userGroup));
        }
        [HttpPost("DeleteUserGroup")]
        public bool DeleteUserGroup([FromBody] int deleteId)
        {
            return logger.Logging<bool>(deleteId, "UserGroup", "Post", userid, "DeleteUserGroup", userGroupLogic.DeleteUserGroup(deleteId));
        }
        [HttpPost("GetUserGroup")]
        public USER_GROUP GetUserGroup([FromBody] int id)
        {
            return logger.Logging<USER_GROUP>(id, "UserGroup", "Post", userid, "GetUserGroup", userGroupLogic.GetUserGroup(id));
        }
        #endregion

    }
}
