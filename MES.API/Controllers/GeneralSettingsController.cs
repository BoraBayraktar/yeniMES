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
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralSettingsController : ControllerBase
    {
        GeneralSettingsLogic generalSettingsLogic = new GeneralSettingsLogic();
        private int userid;
        Log logger = new Log();
        [HttpGet("GetGeneralSettings")]
        public GENERAL_SETTINGS GetGeneralSettings()
        {
            return logger.Logging<GENERAL_SETTINGS>(null, "GeneralSettings", "Get", userid, "GetGeneralSettings", generalSettingsLogic.GetGeneralSettings());
        }
        [Authorize]
        [HttpPost("InsertOrUpdateGeneralSettings")]
        public bool InsertOrUpdateGeneralSettings(GENERAL_SETTINGS generalSettings)
        {
            return logger.Logging<bool>(generalSettings, "GeneralSettings", "Post", userid, "InsertOrUpdateGeneralSettings", generalSettingsLogic.InsertOrUpdateGeneralSettings(generalSettings));
        }
    }
}
