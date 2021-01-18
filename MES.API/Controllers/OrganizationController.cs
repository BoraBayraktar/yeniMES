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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MES.API.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        Log logger = new Log();
        HoldingLogic holdingLogic = new HoldingLogic();
        private JwtAuthenticationManager jwtAuthentication;
        private int userid;

        public OrganizationController(IHttpContextAccessor accessor)
        {
            userid = jwtAuthentication.Decode(accessor.HttpContext.User.Claims.ToList().Where(x => x.Type == ClaimTypes.SerialNumber).FirstOrDefault().ToString());
            //int userid = Convert.ToInt32(User.Claims.Where(x=> x.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value);
        }
        [HttpGet("HoldingGetList")]
        public List<HOLDING> HoldingGetList()
        {
            return logger.Logging<List<HOLDING>>(null, "Organization", "Get", userid, "HoldingGetList", holdingLogic.GetList());
        }
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrganizationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrganizationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
