using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.API.ViewModels
{
    public class EmailSettingsViewModel
    {
        public MAIL_SERVER_SETUP MailServerSetup { get; set; }
    }
}
