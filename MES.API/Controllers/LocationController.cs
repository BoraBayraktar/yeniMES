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
    public class LocationController : ControllerBase
    {
        LocationLogic locationLogic = new LocationLogic();
        Log logger = new Log();
        private int userid;

        #region Location
        [HttpGet("LocationGetList")]
        public List<LOCATION> LocationGetList()
        {
            return logger.Logging<List<LOCATION>>(null, "Location", "Get", userid, "LocationGetList", locationLogic.GetList());
        }
        [HttpPost("InsertLocation")]
        public bool InsertLocation(LOCATION location)
        {
            return logger.Logging<bool>(location, "Location", "Post", userid, "InsertLocation", locationLogic.InsertLocation(location));
        }
        [HttpPost("UpdateLocation")]
        public bool UpdateTitle(LOCATION location)
        {
            return logger.Logging<bool>(location, "Location", "Post", userid, "UpdateLocation", locationLogic.UpdateLocation(location));
        }
        [HttpPost("DeleteLocation")]
        public bool DeleteLocation(int deleteId)
        {
            return logger.Logging<bool>(deleteId, "Location", "Post", userid, "DeleteLocation", locationLogic.DeleteLocation(deleteId));
        }
        [HttpPost("GetLocation")]
        public LOCATION GetLocation(int id)
        {
            return logger.Logging<LOCATION>(id, "Location", "Post", userid, "GetLocation", locationLogic.GetLocation(id));
        }
        #endregion
    }
}
