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
using MES.API.JwtToken;
namespace MES.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class KnowledgeController : ControllerBase
    {
        KnowledgeLogic knowledgeLogic = new KnowledgeLogic();
        private int userid;
        private JwtAuthenticationManager jwtAuthentication;
        Log logger = new Log();
        public KnowledgeController(IHttpContextAccessor accessor)
        {
            userid = Convert.ToInt32(accessor?.HttpContext.User.FindFirstValue(ClaimTypes.SerialNumber));
        }
        #region Knowledge
        [HttpPost("KnowledgeGetList")]
        public List<KNOWLEDGE_MANAGEMENT> KnowledgeGetList([FromBody] int userID)
        {
            return logger.Logging<List<KNOWLEDGE_MANAGEMENT>>(userID, "Knowledge", "Post", userid, "KnowledgeGetList", knowledgeLogic.GetList(userID));
        }
        [HttpPost("GetKnowledge")]
        public KNOWLEDGE_MANAGEMENT GetKnowledge([FromBody] int userID)
        {
            return logger.Logging<KNOWLEDGE_MANAGEMENT>(userID, "Knowledge", "Post", userid, "GetKnowledge", knowledgeLogic.GetKnowledge(userID));
        }
        [HttpGet("GetServiceCatalog")]
        public List<SERVICECATALOG> GetServiceCatalog()
        {
            return logger.Logging<List<SERVICECATALOG>>(null, "Knowledge", "Get", userid, "GetServiceCatalog", knowledgeLogic.GetServiceCatalog());
        }
        [HttpPost("GetKnowledgeCategory")]
        public List<PARAMETER> GetKnowledgeCategory(string code)
        {
            return logger.Logging<List<PARAMETER>>(code, "Knowledge", "Post", userid, "GetKnowledgeCategory", knowledgeLogic.GetKnowledgeCategory(code));
        }
        [HttpPost("GetKnowledgeStatus")]
        public List<PARAMETER> GetKnowledgeStatus(string code)
        {
            return logger.Logging<List<PARAMETER>>(code, "Knowledge", "Post", userid, "GetKnowledgeStatus", knowledgeLogic.GetKnowledgeStatus(code));
        }
        [HttpPost("InsertKnowledge")]
        public bool InsertKnowledge(KNOWLEDGE_MANAGEMENT knowledge)
        {
            return logger.Logging<bool>(knowledge, "Knowledge", "Post", userid, "InsertKnowledge", knowledgeLogic.InsertKnowledge(knowledge));
        }
        [HttpPost("UpdateKnowledge")]
        public bool UpdateKnowledge(KNOWLEDGE_MANAGEMENT knowledge)
        {
            return logger.Logging<bool>(knowledge, "Knowledge", "Post", userid, "UpdateKnowledge", knowledgeLogic.UpdateKnowledge(knowledge));
        }
        [HttpPost("DeleteKnowledge")]
        public bool DeleteKnowledge([FromBody] int userID)
        {
            return logger.Logging<bool>(userID, "Knowledge", "Post", userid, "DeleteKnowledge", knowledgeLogic.DeleteKnowledge(userID));
        }
        [HttpPost("KnowledgeNo")]
        public string KnowledgeNo(bool isUpdate)
        {
            return logger.Logging<string>(isUpdate, "Knowledge", "Post", userid, "KnowledgeNo", knowledgeLogic.KnowledgeNo(isUpdate));
        }
        [HttpPost("InsertKnowledgeFiles")]
        public bool InsertKnowledgeFiles(KNOWLEDGE_FILES knowledgeFile)
        {
            return logger.Logging<bool>(knowledgeFile, "Knowledge", "Post", userid, "InsertKnowledgeFiles", knowledgeLogic.InsertKnowledgeFiles(knowledgeFile));
        }
        [HttpPost("GetFileList")]
        public List<KNOWLEDGE_FILES> GetFileList ([FromBody] int knowledgeId)
        {
            return logger.Logging<List<KNOWLEDGE_FILES>>(knowledgeId, "Knowledge", "Post", userid, "GetFileList", knowledgeLogic.GetFileList(knowledgeId));
        }
        [HttpPost("DeleteKnowledgeFiles")]
        public bool DeleteKnowledgeFiles([FromBody] int deleteId)
        {
            return logger.Logging<bool>(deleteId, "Knowledge", "Post", userid, "DeleteKnowledgeFiles", knowledgeLogic.DeleteKnowledgeFiles(deleteId));
        }
        #endregion
    }
}
