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
    public class CityController : ControllerBase
    {
        CityLogic cityLogic = new CityLogic();
        private int userid;
        Log logger = new Log();

        #region City
        [HttpGet("CityGetList")]
        public List<CITY> CityGetList()
        {
            return logger.Logging<List<CITY>>(null, "City", "Get", userid, "CityGetList", cityLogic.GetList());
        }
        #endregion
    }
}
