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
        #endregion
    }
}
