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
    public class LeaveController : ControllerBase
    {
        LeaveLogic leaveLogic = new LeaveLogic();
        private int userid;
        Log logger = new Log();
        #region Leave
        [HttpGet("LeaveGetList")]
        public List<LEAVE> LeaveGetList()
        {
            return logger.Logging<List<LEAVE>>(null, "Leave", "Get", userid, "LeaveGetList", leaveLogic.GetList());
        }
        [HttpPost("InsertLeave")]
        public bool InsertLeave(LEAVE leave)
        {
            return logger.Logging<bool>(leave, "Leave", "Post", userid, "InsertLeave", leaveLogic.InsertLeave(leave));
        }
        [HttpPost("UpdateLeave")]
        public bool UpdateLeave(LEAVE leave)
        {
            return logger.Logging<bool>(leave, "Leave", "Post", userid, "UpdateLeave", leaveLogic.UpdateLeave(leave));
        }
        [HttpPost("DeleteLeave")]
        public bool DeleteLeave(int deleteId)
        {
            return logger.Logging<bool>(deleteId, "Leave", "Post", userid, "DeleteLeave", leaveLogic.DeleteLeave(deleteId));
        }
        [HttpPost("GetLeave")]
        public LEAVE GetLeave(int id)
        {
            return logger.Logging<LEAVE>(id, "Leave", "Post", userid, "GetLeave", leaveLogic.GetLeave(id));
        }
        #endregion
    }
}
