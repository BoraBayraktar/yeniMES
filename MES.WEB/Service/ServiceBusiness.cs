using MES.Web.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MES.Web.Service
{
    public class ServiceBusiness : IServiceBusiness
    {
        public async Task<object> ObjSendObjGet(object objects, string controller, string func)
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
                        var jwt = await response.Content.ReadAsStringAsync();
                        Object gettedObject = JsonConvert.DeserializeObject<object>(jwt);
                        return gettedObject;
                    }
                    else { return null; }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<string> ObjSendStringGet(object objects, string controller, string func)
        {
            try
            {

                using (var client = new HttpClient())
                {
                    string gettedString = "";
                    client.BaseAddress = new Uri(IpTarget);
                    HttpRequestMessage requestMessage = new HttpRequestMessage();
                    var data = JsonConvert.SerializeObject(objects);
                    requestMessage.Content = new StringContent(data, Encoding.UTF8, "application/json");
                    var response = client.PostAsync("api/"+controller+"/"+func, requestMessage.Content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        gettedString = await response.Content.ReadAsStringAsync();
                        if (gettedString == "") { gettedString = null; }
                        return gettedString;
                    }
                    else { return gettedString; }

                }

            }
            catch (Exception ex)
            {
                throw;

            }

        }
    }
}
