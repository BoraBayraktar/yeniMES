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
    public class TimeManagementOffDaysController : ControllerBase
    {
        TimeManagementOffDaysLogic timeManagementOffDaysLogic = new TimeManagementOffDaysLogic();
        private int userid;
        Log logger = new Log();
        public TimeManagementOffDaysController()
        {
            userid = Convert.ToInt32(User.FindFirst("Name").Value);
        }
        #region TimeManagement
        [HttpGet("TimeManagementOffDaysGetList")]
        public List<TIME_MANAGEMENT_OFFDAYS> TimeManagementOffDaysGetList()
        {
            return logger.Logging<List<TIME_MANAGEMENT_OFFDAYS>>(null, "TimeManagementOffDays", "Get", userid, "TimeManagementOffDaysGetList", timeManagementOffDaysLogic.GetList());
        }
        [HttpPost("InsertTimeManagementOffDays")]
        public bool InsertTimeManagementOffDays(TIME_MANAGEMENT_OFFDAYS timeManagementOffDays)
        {
            return logger.Logging<bool>(timeManagementOffDays, "TimeManagementOffDays", "Post", userid, "InsertTimeManagementOffDays", timeManagementOffDaysLogic.InsertOffDays(timeManagementOffDays));
        }
        [HttpPost("UpdateTimeManagementOffDays")]
        public bool UpdateTimeManagementOffDays(TIME_MANAGEMENT_OFFDAYS timeManagementOffDays)
        {
            return logger.Logging<bool>(timeManagementOffDays, "TimeManagementOffDays", "Post", userid, "UpdateTimeManagementOffDays", timeManagementOffDaysLogic.UpdateOffDays(timeManagementOffDays));
        }
        [HttpPost("DeleteTimeManagementOffDays")]
        public bool DeleteTimeManagementOffDays([FromBody] int deleteId)
        {
            return logger.Logging<bool>(deleteId, "TimeManagementOffDays", "Post", userid, "DeleteTimeManagementOffDays", timeManagementOffDaysLogic.DeleteOffDays(deleteId));
        }
        [HttpPost("GetTimeManagementOffDays")]
        public TIME_MANAGEMENT_OFFDAYS GetTimeManagementOffDays([FromBody] int id)
        {
            return logger.Logging<TIME_MANAGEMENT_OFFDAYS>(id, "TimeManagementOffDays", "Post", userid, "GetTimeManagementOffDays", timeManagementOffDaysLogic.GetOffDays(id));
        }
        [HttpPost("TimeManagementOffDaysGetListById")]
        public List<TIME_MANAGEMENT_OFFDAYS> TimeManagementOffDaysGetListById([FromBody] int id)
        {
            return logger.Logging<List<TIME_MANAGEMENT_OFFDAYS>>(null, "TimeManagementOffDays", "Post", userid, "TimeManagementOffDaysGetListById", timeManagementOffDaysLogic.GetOffDaysListByTmId(id));
        }
        #endregion
    }
}
