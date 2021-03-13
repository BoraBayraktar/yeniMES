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
    public class ParameterController : ControllerBase
    {
        ParameterLogic parameterLogic = new ParameterLogic();
        private int userid;
        Log logger = new Log();
        public ParameterController(IHttpContextAccessor accessor)
        {
            userid = Convert.ToInt32(accessor?.HttpContext.User.FindFirstValue(ClaimTypes.SerialNumber));
        }
        #region Parameter
        [HttpGet("ParameterGetList")]
        public List<PARAMETER> ParameterGetList()
        {
            return logger.Logging<List<PARAMETER>>(null, "Parameter", "Get", userid, "ParameterGetList", parameterLogic.GetList());
        }
        [HttpPost("InsertParameter")]
        public bool InsertParameter(PARAMETER parameter)
        {
            return logger.Logging<bool>(parameter, "Parameter", "Post", userid, "InsertParameter", parameterLogic.InsertParameter(parameter));
        }
        [HttpPost("UpdateParameter")]
        public bool UpdateParameter(PARAMETER parameter)
        {
            return logger.Logging<bool>(parameter, "Parameter", "Post", userid, "UpdateParameter", parameterLogic.UpdateParameter(parameter));
        }
        [HttpPost("DeleteParameter")]
        public bool DeleteParameter([FromBody] int deleteId)
        {
            return logger.Logging<bool>(deleteId, "Parameter", "Post", userid, "DeleteParameter", parameterLogic.DeleteParameter(deleteId));
        }
        [HttpPost("GetParameter")]
        public PARAMETER GetParameter([FromBody] int id)
        {
            return logger.Logging<PARAMETER>(id, "Parameter", "Post", userid, "GetParameter", parameterLogic.GetParameter(id));
        }
        [HttpPost("GetParameterListByParameterTypeCodeMainProcessId")]
        public List<PARAMETER> GetParameterListByParameterTypeCodeMainProcessId(string code, int mainProcessId)
        {
            return logger.Logging<List<PARAMETER>>((code, mainProcessId), "Parameter", "Post", userid, "GetParameterListByParameterTypeCodeMainProcessId", parameterLogic.GetParameterListByParameterTypeCode(code, mainProcessId));
        }
        [HttpPost("GetParameterListByParameterTypeCode")]
        public List<PARAMETER> GetParameterListByParameterTypeCode(string code)
        {
            return logger.Logging<List<PARAMETER>>(code, "Parameter", "Post", userid, "GetParameterListByParameterTypeCode", parameterLogic.GetParameterListByParameterTypeCode(code));
        }
        [HttpPost("GetParameterByMainProcessId")]
        public List<PARAMETER> GetParameterByMainProcessId([FromBody] int mainProcessId)
        {
            return logger.Logging<List<PARAMETER>>(mainProcessId, "Parameter", "Post", userid, "GetParameterByMainProcessId", parameterLogic.GetParameterByMainProcessId(mainProcessId));
        }
        #endregion

        #region ParameterType
        [HttpGet("ParameterTypeGetList")]
        public List<PARAMETER_TYPE> ParameterTypeGetList()
        {
            return logger.Logging<List<PARAMETER_TYPE>>(null, "Parameter", "Get", userid, "ParameterTypeGetList", parameterLogic.GetParameterTypeList());
        }
        [HttpPost("GetParameterTypeByMainProcessId")]
        public List<PARAMETER_TYPE> GetParameterTypeByMainProcessId([FromBody] int mainProcessId)
        {
            return logger.Logging<List<PARAMETER_TYPE>>(mainProcessId, "Parameter", "Post", userid, "GetParameterTypeByMainProcessId", parameterLogic.GetParameterTypeByMainProcessId(mainProcessId));
        }
        #endregion
    }
}
