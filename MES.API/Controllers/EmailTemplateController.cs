﻿using MES.API.Logger;
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
    public class EmailTemplateController : ControllerBase
    {
        EmailTemplateLogic emailTemplateLogic;
        private int userid;
        Log logger = new Log();
        public EmailTemplateController(IHttpContextAccessor accessor)
        {
            emailTemplateLogic = new EmailTemplateLogic();
            userid = Convert.ToInt32(accessor?.HttpContext.User.FindFirstValue(ClaimTypes.SerialNumber));
        }
        #region EmailTemplate
        [HttpGet("EmailTemplateGetList")]
        public List<EMAIL_TEMPLATE> EmailTemplateGetList()
        {
            return logger.Logging<List<EMAIL_TEMPLATE>>(null, "EmailTemplate", "Get", userid, "EmailTemplateGetList", emailTemplateLogic.GetList());
        }
        #endregion
    }
}
