﻿using MES.Web.Interfaces;
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
        public T ServicePost<T>(object objects, string controller, string func)
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
                        string responsestr = response.Content.ReadAsStringAsync().Result;
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
                    var response = client.GetAsync("api/" + controller + "/" + func).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string responsestr = response.Content.ReadAsStringAsync().Result;
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
