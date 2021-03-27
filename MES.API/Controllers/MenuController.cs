using MES.API.Logger;
using MES.Data.Logics;
using MES.DB.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
    public class MenuController : ControllerBase
    {
        MenuLogic menuLogic = new MenuLogic();
        private int userid;
        Log logger = new Log();
        public MenuController(IHttpContextAccessor accessor, IConfiguration configuration)
        {
            userid = Convert.ToInt32(accessor?.HttpContext.User.FindFirstValue(ClaimTypes.SerialNumber));
        }
        #region Menu
        [HttpGet("MenuGetList")]
        public List<MENU> ParameterGetList()
        {
            return logger.Logging<List<MENU>>(null, "Parameter", "Get", userid, "ParameterGetList", menuLogic.GetAllMenu());
        }
        #endregion
    }
}
