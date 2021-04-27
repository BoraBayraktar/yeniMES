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
    public class ServiceCatalogController : ControllerBase
    {
        ServiceCatalogLogic serviceCatalogLogic = new ServiceCatalogLogic();
        private int userid;
        Log logger = new Log();
        
        public ServiceCatalogController(IHttpContextAccessor accessor)
        {
            userid = Convert.ToInt32(accessor?.HttpContext.User.FindFirstValue(ClaimTypes.SerialNumber));
        }

        #region ServiceCatalog
        [HttpGet("ServiceCatalogGetList")]
        public List<SERVICECATALOG> ServiceCatalogGetList()
        {
            return logger.Logging<List<SERVICECATALOG>>(null, "ServiceCatalog", "Get", userid, "ServiceCatalogGetList", serviceCatalogLogic.GetList());
        }
        [HttpPost("GetServiceCatalog")]
        public SERVICECATALOG GetServiceCatalog([FromBody] int serviceCatalogId)
        {
            return logger.Logging<SERVICECATALOG>(serviceCatalogId, "ServiceCatalog", "Post", userid, "GetServiceCatalog", serviceCatalogLogic.GetServiceCatalog(serviceCatalogId));
        }
        [HttpPost("InsertServiceCatalog")]
        public bool InsertServiceCatalog(SERVICECATALOG serviceCatalog)
        {
            return logger.Logging<bool>(serviceCatalog, "ServiceCatalog", "Post", userid, "InsertServiceCatalog", serviceCatalogLogic.InsertServiceCatalog(serviceCatalog));
        }
        [HttpPost("UpdateServiceCatalog")]
        public bool UpdateServiceCatalog(SERVICECATALOG serviceCatalog)
        {
            return logger.Logging<bool>(serviceCatalog, "ServiceCatalog", "Post", userid, "UpdateServiceCatalog", serviceCatalogLogic.UpdateServiceCatalog(serviceCatalog));
        }
        [HttpPost("DeleteServiceCatalog")]
        public bool DeleteServiceCatalog([FromBody] int deleteid)
        {
            return logger.Logging<bool>(deleteid, "ServiceCatalog", "Post", userid, "DeleteServiceCatalog", serviceCatalogLogic.DeleteServiceCatalog(deleteid));
        }
        [HttpPost("GetParameterList")]
        public List<PARAMETER> GetParameterList([FromBody]string code)
        {
            return logger.Logging<List<PARAMETER>>(code, "ServiceCatalog", "Post", userid, "GetParameterList", serviceCatalogLogic.GetParameterList(code));
        }
        [HttpPost("GetPrmOpStatus")]
        public List<PARAMETER> GetPrmOpStatus([FromBody]string code)
        {
            return logger.Logging<List<PARAMETER>>(code, "ServiceCatalog", "Post", userid, "GetPrmOpStatus", serviceCatalogLogic.GetPrmOpStatus(code));
        }
        [HttpGet("GetUserManagerIT")]
        public List<USER> GetUserManagerIT()
        {
            return logger.Logging<List<USER>>(null, "ServiceCatalog", "Get", userid, "GetUserManagerIT", serviceCatalogLogic.GetUserManagerIT());
        }
        [HttpGet("GetUserManagerBusiness")]
        public List<USER> GetUserManagerBusiness()
        {
            return logger.Logging<List<USER>>(null, "ServiceCatalog", "Get", userid, "GetUserManagerBusiness", serviceCatalogLogic.GetUserManagerBusiness());
        }
        #endregion
    }
}
