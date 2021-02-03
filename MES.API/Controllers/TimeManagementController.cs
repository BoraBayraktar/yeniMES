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
    public class TimeManagementController : ControllerBase
    {
        TimeManagementLogic timeManagementLogic = new TimeManagementLogic();
        private int userid;
        Log logger = new Log();

        #region TimeManagement
        [HttpGet("TimeManagementGetList")]
        public List<TIME_MANAGEMENT> TimeManagementGetList()
        {
            return logger.Logging<List<TIME_MANAGEMENT>>(null, "TimeManagement", "Get", userid, "TimeManagementGetList", timeManagementLogic.GetList());
        }
        [HttpPost("InsertTimeManagement")]
        public bool InsertTimeManagement(TIME_MANAGEMENT timeManagement)
        {
            return logger.Logging<bool>(timeManagement, "TimeManagement", "Post", userid, "InsertTimeManagement", timeManagementLogic.InsertTimeManagement(timeManagement));
        }
        [HttpPost("UpdateTimeManagement")]
        public bool UpdateTimeManagement(TIME_MANAGEMENT timeManagement)
        {
            return logger.Logging<bool>(timeManagement, "TimeManagement", "Post", userid, "UpdateTimeManagement", timeManagementLogic.UpdateTimeManagement(timeManagement));
        }
        [HttpPost("DeleteTimeManagement")]
        public bool DeleteTimeManagement(int deleteId)
        {
            return logger.Logging<bool>(deleteId, "TimeManagement", "Post", userid, "DeleteTimeManagement", timeManagementLogic.DeleteTimeManagement(deleteId));
        }
        [HttpPost("GetTimeManagement")]
        public TIME_MANAGEMENT GetTimeManagement(int id)
        {
            return logger.Logging<TIME_MANAGEMENT>(id, "TimeManagement", "Post", userid, "GetTimeManagement", timeManagementLogic.GetTimeManagement(id));
        }
        [HttpGet("TimezoneGetList")]
        public List<TIMEZONE> TimezoneGetList()
        {
            return logger.Logging<List<TIMEZONE>>(null, "TimeManagement", "Get", userid, "TimezoneGetList", timeManagementLogic.GetTimezoneList());
        }
        #endregion
    }
}
