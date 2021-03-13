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
    public class GroupExpertController : ControllerBase
    {
        GroupExpertLogic groupExpertLogic = new GroupExpertLogic();
        private int userid;
        Log logger = new Log();
        public GroupExpertController(IHttpContextAccessor accessor)
        {
            userid = Convert.ToInt32(accessor?.HttpContext.User.FindFirstValue(ClaimTypes.SerialNumber));
        }
        #region GroupExpert
        [HttpGet("GroupExpertGetList")]
        public List<GROUP_EXPERT> GroupExpertGetList()
        {
            return logger.Logging<List<GROUP_EXPERT>>(null, "GroupExpert", "Get", userid, "GroupExpertGetList", groupExpertLogic.GetList());
        }
        [HttpPost("InsertGroupExpert")]
        public bool InsertGroupExpert(GROUP_EXPERT groupExpert)
        {
            return logger.Logging<bool>(groupExpert, "GroupExpert", "Post", userid, "InsertGroupExpert", groupExpertLogic.InsertExpert(groupExpert));
        }
        [HttpPost("UpdateGroupExpert")]
        public bool UpdateGroupExpert(GROUP_EXPERT groupExpert)
        {
            return logger.Logging<bool>(groupExpert, "GroupExpert", "Post", userid, "UpdateGroupExpert", groupExpertLogic.UpdateExpert(groupExpert));
        }
        [HttpPost("DeleteGroupExpert")]
        public bool DeleteGroupExpert([FromBody] int deleteId)
        {
            return logger.Logging<bool>(deleteId, "GroupExpert", "Post", userid, "DeleteGroupExpert", groupExpertLogic.DeleteExpert(deleteId));
        }
        [HttpPost("GetGroupExpert")]
        public GROUP_EXPERT GetGroupExpert([FromBody] int id)
        {
            return logger.Logging<GROUP_EXPERT>(id, "Group", "Post", userid, "GetGroupExpert", groupExpertLogic.GetExpert(id));
        }
        [HttpPost("GetExpertListByGrpId")]
        public List<GROUP_EXPERT> GetExpertListByGrpId([FromBody] int id)
        {
            return logger.Logging<List<GROUP_EXPERT>>(id, "Group", "Post", userid, "GetExpertListByGrpId", groupExpertLogic.GetExpertListByGrpId(id));
        }
        #endregion
    }
}
