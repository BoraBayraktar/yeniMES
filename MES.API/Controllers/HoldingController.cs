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
    public class HoldingController : ControllerBase
    {
        HoldingLogic holdingLogic = new HoldingLogic();
        Log logger = new Log();
        private int userid;

        #region Holding
        [HttpGet("HoldingGetList")]
        public List<HOLDING> HoldingGetList()
        {
            return logger.Logging<List<HOLDING>>(null, "Holding", "Get", userid, "HoldingGetList", holdingLogic.GetList());
        }
        [HttpPost("InsertHolding")]
        public bool InsertHolding(HOLDING holding)
        {
            return logger.Logging<bool>(holding, "Holding", "Post", userid, "InsertHolding", holdingLogic.InsertHolding(holding));
        }
        [HttpPost("UpdateHolding")]
        public bool UpdateHolding(HOLDING holding)
        {
            return logger.Logging<bool>(holding, "Holding", "Post", userid, "UpdateHolding", holdingLogic.UpdateHolding(holding));
        }
        [HttpPost("DeleteHolding")]
        public bool DeleteHolding(int deleteId)
        {
            return logger.Logging<bool>(deleteId, "Holding", "Post", userid, "DeleteHolding", holdingLogic.DeleteHolding(deleteId));
        }
        [HttpPost("GetHolding")]
        public HOLDING GetHolding(int id)
        {
            return logger.Logging<HOLDING>(id, "Holding", "Post", userid, "GetHolding", holdingLogic.GetHolding(id));
        }
        #endregion
    }

}
