using MES.API.Logger;
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
    public class UserTypeController : ControllerBase
    {
        UserTypeLogic userTypeLogic = new UserTypeLogic();
        private int userid;
        Log logger = new Log();

        #region UserType
        [HttpGet("UserTypeGetList")]
        public List<USER_TYPE> UserTypeGetList()
        {
            return logger.Logging<List<USER_TYPE>>(null, "UserType", "Get", userid, "UserTypeGetList", userTypeLogic.GetList());
        }
        #endregion
    }
}
