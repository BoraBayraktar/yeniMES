using MES.API.Encrypter;
using MES.API.ViewModels;
using MES.Data.Logics;
using MES.DB.Model;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MES.API.Controllers
{
    
    
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        UserLogic userLogic = new UserLogic();
        private Encryption encryption;
        public AdminController()
        {
            var SCollection = new ServiceCollection();

            //add protection services
            SCollection.AddDataProtection();
            var LockerKey = SCollection.BuildServiceProvider();
            encryption = ActivatorUtilities.CreateInstance<Encryption>(LockerKey);
        }
        // GET: api/<AdminController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AdminController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AdminController>
        [HttpPost("AddUser")]
        public void Post(string password, int userid)
        {
            
            userLogic.UserChangePassword(userid, encryption.Encrypt(password));
        }

        // PUT api/<AdminController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AdminController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
