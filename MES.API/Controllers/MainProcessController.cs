using MES.API.Logger;
using MES.Data.Logics;
using MES.DB.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainProcessController : ControllerBase
    {
        MainProcessLogic mainProcessLogic = new MainProcessLogic();
        private int userid;
        Log logger = new Log();

        #region MainProcess
        [HttpGet("MainProcessGetList")]
        public List<MAIN_PROCESS> MainProcessGetList()
        {
            return logger.Logging<List<MAIN_PROCESS>>(null, "MainProcess", "Get", userid, "MainProcessGetList", mainProcessLogic.GetList());
        }
        [HttpPost("InsertMainProcess")]
        public bool InsertMainProcess(MAIN_PROCESS mainProcess)
        {
            return logger.Logging<bool>(mainProcess, "MainProcess", "Post", userid, "InsertMainProcess", mainProcessLogic.InsertMainProcess(mainProcess));
        }
        [HttpPost("UpdateMainProcess")]
        public bool UpdateMainProcess(MAIN_PROCESS mainProcess)
        {
            return logger.Logging<bool>(mainProcess, "MainProcess", "Post", userid, "UpdateMainProcess", mainProcessLogic.UpdateMainProcess(mainProcess));
        }
        [HttpPost("DeleteMainProcess")]
        public bool DeleteMainProcess(int deleteId)
        {
            return logger.Logging<bool>(deleteId, "MainProcess", "Post", userid, "DeleteMainProcess", mainProcessLogic.DeleteMainProcess(deleteId));
        }
        [HttpPost("GetMainProcess")]
        public MAIN_PROCESS GetMainProcess(int id)
        {
            return logger.Logging<MAIN_PROCESS>(id, "MainProcess", "Post", userid, "GetMainProcess", mainProcessLogic.GetMainProcess(id));
        }
        #endregion
    }
}
