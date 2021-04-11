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
        [HttpPost("DeleteEmailTemplate")]
        public bool DeleteEmailTemplate([FromBody] int deleteId)
        {
            return logger.Logging<bool>(deleteId, "EmailTemplate", "Post", userid, "DeleteEmail", emailTemplateLogic.DeleteEmailTemplate(deleteId));
            
        }

        [HttpPost("GetEmailTemplateParametersByMainProcessId")]
        public List<EMAIL_TEMPLATE_PARAMETERS> GetEmailTemplateParametersByMainProcessId([FromBody] int mainProcessId)
        {
            return logger.Logging<List<EMAIL_TEMPLATE_PARAMETERS>>(mainProcessId, "Parameter", "Post", userid, "GetParameterByMainProcessId", emailTemplateLogic.GetEmailTemplateParametersByMainProcessId(mainProcessId));
        }
        #endregion

        #region EmailTemplateParameter
        [HttpGet("ParameterGetList")]
        public List<EMAIL_TEMPLATE_PARAMETERS> ParameterGetList()
        {
            return logger.Logging<List<EMAIL_TEMPLATE_PARAMETERS>>(null, "EmailTemplate", "Get", userid, "ParameterGetList", emailTemplateLogic.GetParameterList());
        }
        //[HttpPost("DeleteEmailTemplate")]
        //public bool DeleteEmailTemplate([FromBody] int deleteId)
        //{
        //    return logger.Logging<bool>(deleteId, "EmailTemplate", "Post", userid, "DeleteEmail", emailTemplateLogic.DeleteEmailTemplate(deleteId));

        //}

        //[HttpPost("GetEmailTemplateParametersByMainProcessId")]
        //public List<EMAIL_TEMPLATE_PARAMETERS> GetEmailTemplateParametersByMainProcessId([FromBody] int mainProcessId)
        //{
        //    return logger.Logging<List<EMAIL_TEMPLATE_PARAMETERS>>(mainProcessId, "Parameter", "Post", userid, "GetParameterByMainProcessId", emailTemplateLogic.GetEmailTemplateParametersByMainProcessId(mainProcessId));
        //}
        #endregion
    }
}
