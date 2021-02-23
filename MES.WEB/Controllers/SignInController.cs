using MES.Web.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MES.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignInController : ControllerBase
    {
        private readonly IConfiguration configuration;
        string IpTarget;
        public SignInController(IConfiguration configuration)
        {
            
            this.configuration = configuration;
            IpTarget = this.configuration.GetConnectionString("DefaultConnection");
        }
        
        public bool SignIn(string token, string controller, string func)
        {
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(IpTarget);
                HttpRequestMessage requestMessage = new HttpRequestMessage();
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "dfdfs");
                requestMessage.Content = new StringContent(token, Encoding.UTF8, "application/json");
                var response = client.PostAsync($"api/{controller}/{func}", requestMessage.Content).Result;
                return JsonConvert.DeserializeObject<bool>(response.Content.ReadAsStringAsync().ToString());
            }
        }
    }

}
