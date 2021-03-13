using MES.API.JwtToken;
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
    public class GroupController : ControllerBase
    {
        GroupLogic groupLogic = new GroupLogic();
        private int userid;
        Log logger = new Log();
        public GroupController(IHttpContextAccessor accessor)
        {
            userid = Convert.ToInt32(accessor?.HttpContext.User.FindFirstValue(ClaimTypes.SerialNumber));
        }
        #region Group
        [HttpGet("GroupGetList")]
        public List<GROUP> GroupGetList()
        {
            return logger.Logging<List<GROUP>>(null, "Group", "Get", userid, "GroupGetList", groupLogic.GetList());
        }
        [HttpGet("GetGroupManager")]
        public List<USER> GetGroupManager()
        {
            return logger.Logging<List<USER>>(null, "Group", "Get", userid, "GetGroupManager", groupLogic.GetGroupManager());
        }
        [HttpGet("GetGroupType")]
        public List<GROUP_TYPE> GetGroupType()
        {
            return logger.Logging<List<GROUP_TYPE>>(null, "Group", "Get", userid, "GetGroupType", groupLogic.GetGroupType());
        }
        [HttpGet("GetExpert")]
        public List<USER> GetExpert()
        {
            return logger.Logging<List<USER>>(null, "Group", "Get", userid, "GetExpert", groupLogic.GetExpert());
        }
        [HttpPost("InsertGroup")]
        public bool InsertGroup(GROUP group)
        {
            return logger.Logging<bool>(group, "Group", "Post", userid, "InsertGroup", groupLogic.InsertGroup(group));
        }
        [HttpPost("UpdateGroup")]
        public bool UpdateGroup(GROUP group)
        {
            return logger.Logging<bool>(group, "Group", "Post", userid, "UpdateGroup", groupLogic.UpdateGroup(group));
        }
        [HttpPost("DeleteGroup")]
        public bool DeleteGroup([FromBody] int deleteId)
        {
            return logger.Logging<bool>(deleteId, "Group", "Post", userid, "DeleteGroup", groupLogic.DeleteGroup(deleteId));
        }
        [HttpPost("GetGroup")]
        public GROUP GetGroup([FromBody] int id)
        {
            return logger.Logging<GROUP>(id, "Group", "Post", userid, "GetGroup", groupLogic.GetGroup(id));
        }
        [HttpPost("GetExpertListByExpId")]
        public List<USER> GetExpertListByExpId([FromBody] int id)
        {
            return logger.Logging<List<USER>>(id, "Group", "Post", userid, "GetExpertListByExpId", groupLogic.GetExpertListByExpId(id));
        }
        [HttpPost("GetExpertListByGrpId")]
        public List<GROUP_EXPERT> GetExpertListByGrpId([FromBody] int id)
        {
            return logger.Logging<List<GROUP_EXPERT>>(id, "Group", "Post", userid, "GetExpertListByGrpId", groupLogic.GetExpertListByGrpId(id));
        }
        #endregion
    }
}
