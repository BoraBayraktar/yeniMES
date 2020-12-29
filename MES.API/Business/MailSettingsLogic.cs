using MES.Data.Functions;
using MES.Data.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Business
{
    public class MailSettingsLogic
    {
        IMailSettings _mailSettings = new MailSettingsFunctions();
        public List<MAIL_SERVER_SETUP> GetList()
        {
            var mailServerList = _mailSettings.GetList();
            return mailServerList;
        }
        public bool InsertMailServerSetup(MAIL_SERVER_SETUP mss)
        {
            var success = _mailSettings.InsertMailServerSetup(mss);
            return success;
        }
        public bool UpdateMailServerSetup(MAIL_SERVER_SETUP mss)
        {
            var success = _mailSettings.UpdateMailServerSetup(mss);
            return success;
        }
        public bool DeleteMailServerSetup(int Id)
        {
            var success = _mailSettings.DeleteMailServerSetup(Id);
            return success;
        }
        public MAIL_SERVER_SETUP GetMailServerSetup(int id)
        {
            var mss = _mailSettings.GetMailServerSetup(id);
            return mss;
        }

        public bool InsertOrUpdateMailServerSetup(MAIL_SERVER_SETUP mss)
        {
            var success = _mailSettings.InsertOrUpdateMailServerSetup(mss);
            return success;
        }
    }
}
