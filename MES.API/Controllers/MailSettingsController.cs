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
    public class MailSettingsController : ControllerBase
    {
        MailSettingsLogic mailSettingsLogic = new MailSettingsLogic();
        private int userid;
        Log logger = new Log();
        public MailSettingsController()
        {
            userid = Convert.ToInt32(User.FindFirst("Name").Value);
        }
        #region MailSettings
        [HttpGet("MailSettingsGetList")]
        public List<MAIL_SERVER_SETUP> MailSettingsGetList()
        {
            return logger.Logging<List<MAIL_SERVER_SETUP>>(null, "MailSettings", "Get", userid, "MailSettingsGetList", mailSettingsLogic.GetList());
        }
        [HttpPost("InsertOrUpdateMailSettings")]
        public bool InsertOrUpdateMailSettings(MAIL_SERVER_SETUP mailServerSetup)
        {
            return logger.Logging<bool>(mailServerSetup, "MailSettings", "Post", userid, "MailSettingsGetList", mailSettingsLogic.InsertOrUpdateMailServerSetup(mailServerSetup));
        }
        #endregion
    }
}
