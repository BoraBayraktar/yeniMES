using MES.Web.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace MES.Web.Service
{
    public class ServiceBusiness : IServiceBusiness
    {
        public async Task<Object> ObjSendObjPost(object objects, string controller, string func)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(IpTarget);
                    HttpRequestMessage requestMessage = new HttpRequestMessage();
                    var data = JsonConvert.SerializeObject(objects);
                    requestMessage.Content = new StringContent(data, Encoding.UTF8, "application/json");
                    var response = client.PostAsync("api/" + controller + "/" + func, requestMessage.Content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string received = await response.Content.ReadAsStringAsync();
                        Object recobj = JsonConvert.DeserializeObject<Object>(received);
                        return recobj;
                    }
                    else { return null; }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public object ObjSendObjGet(string controller, string func)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(IpTarget);
                    HttpRequestMessage requestMessage = new HttpRequestMessage();
                    var response = client.GetAsync("api/" + controller + "/" + func).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string received = response.Content.ReadAsStringAsync().Result;
                        //object obj = JsonConvert.DeserializeObject(received);
                        //JObject jObject = received[0] as JObject;
                        JValue jValue = new JValue(received);
                        object obj = jValue.ToObject(typeof(object));
                        return obj;
                        
                    }
                    else { return null; }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string ObjSendObjGeter(string controller, string func)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(IpTarget);
                    HttpRequestMessage requestMessage = new HttpRequestMessage();
                    var response = client.GetAsync("api/" + controller + "/" + func).Result;
                    if (response.IsSuccessStatusCode)
                    {

                        return response.Content.ReadAsStringAsync().Result;
                    }
                    else { return null; }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
