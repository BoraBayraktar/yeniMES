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
    public class DepartmentController : ControllerBase
    {
        private int userid;
        Log logger = new Log();
        DepartmentLogic departmentLogic = new DepartmentLogic();
        public DepartmentController(IHttpContextAccessor accessor)
        {
            userid = Convert.ToInt32(accessor?.HttpContext.User.FindFirstValue(ClaimTypes.SerialNumber));
        }
        #region Department
        [HttpGet("DepartmentGetList")]
        public List<DEPARTMENT> DepartmentGetList()
        {
            return logger.Logging<List<DEPARTMENT>>(null, "Department", "Get", userid, "DepartmentGetList", departmentLogic.GetList());
        }
        [HttpPost("InsertDepartment")]
        public bool InsertDepartment(DEPARTMENT department)
        {
            return logger.Logging<bool>(department, "Department", "Post", userid, "InsertDepartment", departmentLogic.InsertDepartment(department));
        }
        [HttpPost("UpdateDepartment")]
        public bool UpdateDepartment(DEPARTMENT department)
        {
            return logger.Logging<bool>(department, "Department", "Post", userid, "UpdateDepartment", departmentLogic.UpdateDepartment(department));
        }
        [HttpPost("DeleteDepartment")]
        public bool DeleteDepartment([FromBody] int deleteId)
        {
            return logger.Logging<bool>(deleteId, "Department", "Post", userid, "DeleteDepartment", departmentLogic.DeleteDepartment(deleteId));
        }
        [HttpPost("GetDepartment")]
        public DEPARTMENT GetDepartment([FromBody] int id)
        {
            return logger.Logging<DEPARTMENT>(id, "Department", "Post", userid, "GetDepartment", departmentLogic.GetDepartment(id));
        }
        #endregion
    }
}
