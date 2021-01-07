using MES.Web.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Web.Interfaces
{
    public interface IMailSettings
    {
        List<MAIL_SERVER_SETUP> GetList();
        MAIL_SERVER_SETUP GetMailServerSetup(int id);
        bool InsertMailServerSetup(MAIL_SERVER_SETUP mailServerSetup);
        bool UpdateMailServerSetup(MAIL_SERVER_SETUP mailServerSetup);

        bool InsertOrUpdateMailServerSetup(MAIL_SERVER_SETUP mailServerSetup);

        bool DeleteMailServerSetup(int Id);
    }
}
