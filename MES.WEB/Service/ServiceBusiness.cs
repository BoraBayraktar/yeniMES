using MES.Web.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using MES.Web.Controllers;

namespace MES.Web.Service
{
    public class ServiceBusiness
    {
        private readonly IConfiguration configuration;
        private readonly IHttpContextAccessor httpContextAccessor;
        string IpTarget;
        public ServiceBusiness(IConfiguration config, IHttpContextAccessor accessor)
        {
            httpContextAccessor = accessor;
            configuration = config;
            IpTarget = configuration.GetConnectionString("DefaultConnection");
        }
        public T ServicePost<T>(object objects, string controller, string func)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(IpTarget);
                    HttpRequestMessage requestMessage = new HttpRequestMessage();
                    var data = JsonConvert.SerializeObject(objects);
                    HttpResponseMessage response;
                    if (httpContextAccessor.HttpContext.Session.GetString("token") != null)
                    {
                        string token = httpContextAccessor.HttpContext.Session.GetString("token");
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }
                    requestMessage.Content = new StringContent(data, Encoding.UTF8, "application/json");
                    response = client.PostAsync($"api/{controller}/{func}", requestMessage.Content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string responsestr = response.Content.ReadAsStringAsync().Result;
                        if (typeof(T) == typeof(string))
                        {
                            return (T)Convert.ChangeType(responsestr, typeof(T));
                        }
                        return JsonConvert.DeserializeObject<T>(responsestr);
                    }
                    else { return default(T); }
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public T ServiceGet<T>(string controller, string func)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(IpTarget);
                    HttpRequestMessage requestMessage = new HttpRequestMessage();
                    if (httpContextAccessor.HttpContext.Session.GetString("token") != null)
                    {
                        string token = httpContextAccessor.HttpContext.Session.GetString("token");
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }
                    var response = client.GetAsync("api/" + controller + "/" + func).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string responsestr = response.Content.ReadAsStringAsync().Result;
                        if (typeof(T) == typeof(string))
                        {
                            return (T)Convert.ChangeType(responsestr, typeof(T));
                        }
                        return JsonConvert.DeserializeObject<T>(responsestr);

                    }
                    else { return default(T); }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void ServiceDelete<T>(T objects, string controller, string func)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(IpTarget);
                    HttpRequestMessage requestMessage = new HttpRequestMessage();
                    if (httpContextAccessor.HttpContext.Session.GetString("token") != null)
                    {
                        string token = httpContextAccessor.HttpContext.Session.GetString("token");
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }
                    var data = JsonConvert.SerializeObject(objects);
                    requestMessage.Content = new StringContent(data, Encoding.UTF8, "application/json");
                    client.DeleteAsync("api/" + controller + "/" + func);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ServicePut<T>(T objects, string controller, string func)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(IpTarget);
                    HttpRequestMessage requestMessage = new HttpRequestMessage();
                    if (httpContextAccessor.HttpContext.Session.GetString("token") != null)
                    {
                        string token = httpContextAccessor.HttpContext.Session.GetString("token");
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }
                    var data = JsonConvert.SerializeObject(objects);
                    requestMessage.Content = new StringContent(data, Encoding.UTF8, "application/json");
                    client.PutAsync("api/" + controller + "/" + func, requestMessage.Content);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
