using MES.DB.Model;
using MES.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.API.Logger
{
    public class LoggerBusiness
    {
        private readonly MesContext context;
        public LoggerBusiness()
        {
            context = new MesContext();
        }

        public int RequestLog(LOGGER_REQUEST loggerRequest)
        {
            context.LOGGER_REQUESTS.Add(loggerRequest);
            context.SaveChanges();
            return Convert.ToInt32(context.LOGGER_REQUESTS.OrderByDescending(x => x.ID).FirstOrDefault().ID);
        }
        public void ResponseLog(LOGGER_RESPONSE loggerResponse)
        {
            context.LOGGER_RESPONSE.Add(loggerResponse);
            context.SaveChanges();

        }
    }
}
