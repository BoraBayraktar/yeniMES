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
    public class CompanyController : ControllerBase
    {
        CompanyLogic companyLogic = new CompanyLogic();
        private int userid;
        Log logger = new Log();
        public CompanyController()
        {
            userid = Convert.ToInt32(User.FindFirst("Name").Value);
        }
        #region Company
        [HttpGet("CompanyGetList")]
        public List<COMPANY> CompanyGetList()
        {
            return logger.Logging<List<COMPANY>>(null, "Company", "Get", userid, "CompanyGetList", companyLogic.GetList());
        }
        [HttpPost("InsertCompany")]
        public bool InsertCompany(COMPANY company)
        {
            return logger.Logging<bool>(company, "Company", "Post", userid, "InsertCompany", companyLogic.InsertCompany(company));
        }
        [HttpPost("UpdateCompany")]
        public bool UpdateCompany(COMPANY company)
        {
            return logger.Logging<bool>(company, "Company", "Post", userid, "UpdateCompany", companyLogic.UpdateCompany(company));
        }
        [HttpPost("DeleteCompany")]
        public bool DeleteCompany([FromBody] int deleteId)
        {
            return logger.Logging<bool>(deleteId, "Company", "Post", userid, "DeleteCompany", companyLogic.DeleteCompany(deleteId));
        }
        [HttpPost("GetCompany")]
        public COMPANY GetCompany([FromBody] int id)
        {
            return logger.Logging<COMPANY>(id, "Company", "Post", userid, "GetCompany", companyLogic.GetCompany(id));
        }
        #endregion
    }
}
