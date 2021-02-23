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
    public class TitleController : ControllerBase
    {
        TitleLogic titleLogic = new TitleLogic();
        Log logger = new Log();
        private int userid;
        public TitleController()
        {
            userid = Convert.ToInt32(User.FindFirst("Name").Value);
        }
        #region Title
        [HttpGet("TitleGetList")]
        public List<TITLE> TitleGetList()
        {
            return logger.Logging<List<TITLE>>(null, "Title", "Get", userid, "TitleGetList", titleLogic.GetList());
        }
        [HttpPost("InsertTitle")]
        public bool InsertTitle(TITLE title)
        {
            return logger.Logging<bool>(title, "Title", "Post", userid, "InsertTitle", titleLogic.InsertTitle(title));
        }
        [HttpPost("UpdateTitle")]
        public bool UpdateTitle(TITLE title)
        {
            return logger.Logging<bool>(title, "Title", "Post", userid, "UpdateTitle", titleLogic.UpdateTitle(title));
        }
        [HttpPost("DeleteTitle")]
        public bool DeleteTitle([FromBody] int deleteId)
        {
            return logger.Logging<bool>(deleteId, "Title", "Post", userid, "DeleteTitle", titleLogic.DeleteTitle(deleteId));
        }
        [HttpPost("GetTitle")]
        public TITLE GetTitle([FromBody] int id)
        {
            return logger.Logging<TITLE>(id, "Title", "Post", userid, "GetTitle", titleLogic.GetTitle(id));
        }
        #endregion
    }
}
