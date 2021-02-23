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
    public class WorkingDaysController : ControllerBase
    {
        WorkingDaysLogic workingDaysLogic = new WorkingDaysLogic();
        private int userid;
        Log logger = new Log();
        public WorkingDaysController()
        {
            userid = Convert.ToInt32(User.FindFirst("Name").Value);
        }
        #region WorkingDays
        [HttpGet("WorkingDaysGetList")]
        public List<WORKING_DAYS> WorkingDaysGetList()
        {
            return logger.Logging<List<WORKING_DAYS>>(null, "WorkingDays", "Get", userid, "WorkingDaysGetList", workingDaysLogic.GetList());
        }
        [HttpPost("InsertWorkingDays")]
        public bool InsertWorkingDays(WORKING_DAYS workingDays)
        {
            return logger.Logging<bool>(workingDays, "WorkingDays", "Post", userid, "InsertWorkingDays", workingDaysLogic.InsertWorkingDays(workingDays));
        }
        [HttpPost("UpdateWorkingDays")]
        public bool UpdateWorkingDays(WORKING_DAYS workingDays)
        {
            return logger.Logging<bool>(workingDays, "WorkingDays", "Post", userid, "UpdateWorkingDays", workingDaysLogic.UpdateWorkingDays(workingDays));
        }
        [HttpPost("DeleteWorkingDays")]
        public bool DeleteWorkingDays([FromBody] int deleteId)
        {
            return logger.Logging<bool>(deleteId, "WorkingDays", "Post", userid, "DeleteWorkingDays", workingDaysLogic.DeleteWorkingDays(deleteId));
        }
        [HttpPost("GetWorkingDays")]
        public WORKING_DAYS GetWorkingDays([FromBody] int id)
        {
            return logger.Logging<WORKING_DAYS>(id, "WorkingDays", "Post", userid, "GetWorkingDays", workingDaysLogic.GetWorkingDays(id));
        }
        #endregion
    }
}
