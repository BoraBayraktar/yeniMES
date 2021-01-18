using MES.DB.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.API.Logger
{
    public class Log
    {
        int userId;
        private int requestId;
        public T Logging<T>(object obj, string controller, string method, int user_id, string path, T response)
        {
            requestId = new LoggerBusiness().RequestLog(new LOGGER_REQUEST() { CONTROLLER = controller, METHOD = method, USER_ID = user_id, DATE = DateTime.Now, PATH = path, JSONDATA = JsonConvert.SerializeObject(obj) });

            new LoggerBusiness().ResponseLog(new LOGGER_RESPONSE() { CONTROLLER = controller, METHOD = method, USER_ID = user_id, DATE = DateTime.Now, PATH = path, JSONDATA = JsonConvert.SerializeObject(response), REQUEST_ID = requestId });
            return response;
        }

        public void LoggingNoReturn(object obj, string controller, string method, int user_id, string path)
        {
            requestId = new LoggerBusiness().RequestLog(new LOGGER_REQUEST() { CONTROLLER = controller, METHOD = method, USER_ID = user_id, DATE = DateTime.Now, PATH = path, JSONDATA = JsonConvert.SerializeObject(obj) });

            new LoggerBusiness().ResponseLog(new LOGGER_RESPONSE() { CONTROLLER = controller, METHOD = method, USER_ID = user_id, DATE = DateTime.Now, PATH = path, JSONDATA = JsonConvert.SerializeObject(null), REQUEST_ID = requestId });
        }
    }
}
