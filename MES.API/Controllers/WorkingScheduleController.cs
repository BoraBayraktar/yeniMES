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
    public class WorkingScheduleController : ControllerBase
    {
        WorkingScheduleLogic workingScheduleLogic = new WorkingScheduleLogic();
        private int userid;
        Log logger = new Log();

        #region WorkingSchedule
        [HttpGet("WorkingScheduleGetList")]
        public List<WORKING_SCHEDULE> WorkingScheduleGetList()
        {
            return logger.Logging<List<WORKING_SCHEDULE>>(null, "WorkingSchedule", "Get", userid, "WorkingScheduleGetList", workingScheduleLogic.GetList());
        }
        [HttpPost("InsertWorkingSchedule")]
        public bool InsertWorkingSchedule(WORKING_SCHEDULE workingSchedule)
        {
            return logger.Logging<bool>(workingSchedule, "WorkingSchedule", "Post", userid, "InsertWorkingSchedule", workingScheduleLogic.InsertWorkingSchedule(workingSchedule));
        }
        [HttpPost("UpdateWorkingSchedule")]
        public bool UpdateWorkingSchedule(WORKING_SCHEDULE workingSchedule)
        {
            return logger.Logging<bool>(workingSchedule, "WorkingSchedule", "Post", userid, "UpdateWorkingSchedule", workingScheduleLogic.UpdateWorkingSchedule(workingSchedule));
        }
        [HttpPost("DeleteWorkingSchedule")]
        public bool DeleteWorkingSchedule(int deleteId)
        {
            return logger.Logging<bool>(deleteId, "WorkingSchedule", "Post", userid, "DeleteWorkingSchedule", workingScheduleLogic.DeleteWorkingSchedule(deleteId));
        }
        [HttpPost("GetWorkingSchedule")]
        public WORKING_SCHEDULE GetWorkingSchedule(int id)
        {
            return logger.Logging<WORKING_SCHEDULE>(id, "WorkingSchedule", "Post", userid, "GetWorkingSchedule", workingScheduleLogic.GetWorkingSchedule(id));
        }
        #endregion
    }
}
