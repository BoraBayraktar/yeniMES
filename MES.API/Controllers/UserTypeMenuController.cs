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
    public class UserTypeMenuController : ControllerBase
    {
        UserTypeMenuLogic userTypeMenuLogic = new UserTypeMenuLogic();
        private int userid;
        Log logger = new Log();
        public UserTypeMenuController(IHttpContextAccessor accessor)
        {
            userid = Convert.ToInt32(accessor?.HttpContext.User.FindFirstValue(ClaimTypes.SerialNumber));
        }
        #region UserTypeMenu
        [HttpGet("UserTypeMenuGetList")]
        public List<USERTYPE_MENU> UserTypeMenuGetList()
        {
            return logger.Logging<List<USERTYPE_MENU>>(null, "UserTypeMenu", "Get", userid, "UserTypeMenuGetList", userTypeMenuLogic.GetList());
        }
        [HttpPost("InsertUserTypeMenu")]
        public bool InsertUserTypeMenu(USERTYPE_MENU usertypemenu)
        {
            return logger.Logging<bool>(usertypemenu, "UserTypeMenu", "Post", userid, "InsertUserTypeMenu", userTypeMenuLogic.InsertUserTypeMenu(usertypemenu));
        }
        [HttpPost("DeleteUserTypeMenu")]
        public bool DeleteUserTypeMenu(USERTYPE_MENU usertypemenu)
        {
            return logger.Logging<bool>(usertypemenu, "UserTypeMenu", "Post", userid, "DeleteUserTypeMenu", userTypeMenuLogic.DeleteUserTypeMenu(usertypemenu.UserTypeId, usertypemenu.MenuId));
        }
        #endregion
    }
}
