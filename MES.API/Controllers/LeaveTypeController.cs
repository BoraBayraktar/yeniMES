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
using MES.API.JwtToken;
using System.Security.Claims;

namespace MES.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        LeaveTypeLogic leaveTypeLogic = new LeaveTypeLogic();
        private int userid;
        Log logger = new Log();
        public LeaveTypeController(IHttpContextAccessor accessor)
        {
            userid = userid = Convert.ToInt32(accessor?.HttpContext.User.FindFirstValue(ClaimTypes.SerialNumber));
        }
        #region LeaveType
        [HttpGet("LeaveTypeGetList")]
        public List<LEAVE_TYPE> LeaveTypeGetList()
        {
            return logger.Logging<List<LEAVE_TYPE>>(null, "LeaveType", "Get", userid, "LeaveTypeGetList", leaveTypeLogic.GetList());
        }
        [HttpPost("InsertLeaveType")]
        public bool InsertLeaveType(LEAVE_TYPE leaveType)
        {
            return logger.Logging<bool>(leaveType, "LeaveType", "Post", userid, "InsertLeaveType", leaveTypeLogic.InsertLeaveType(leaveType));
        }
        [HttpPost("UpdateLeaveType")]
        public bool UpdateLeaveType(LEAVE_TYPE leaveType)
        {
            return logger.Logging<bool>(leaveType, "LeaveType", "Post", userid, "UpdateLeaveType", leaveTypeLogic.UpdateLeaveType(leaveType));
        }
        [HttpPost("DeleteLeaveType")]
        public bool DeleteLeaveType([FromBody] int deleteId)
        {
            return logger.Logging<bool>(deleteId, "LeaveType", "Post", userid, "DeleteLeaveType", leaveTypeLogic.DeleteLeaveType(deleteId));
        }
        [HttpPost("GetLeaveType")]
        public LEAVE_TYPE GetLeaveType([FromBody] int id)
        {
            return logger.Logging<LEAVE_TYPE>(id, "LeaveType", "Post", userid, "GetLeaveType", leaveTypeLogic.GetLeaveType(id));
        }
        #endregion
    }
}
