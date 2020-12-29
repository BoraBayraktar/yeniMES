using MES.Data.Functions;
using MES.Data.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Business
{
    public class MailToSendLogic
    {
        IMailToSend _mail = new MailToSendFunctions();
        public List<MAIL_TO_SEND> GetList()
        {
            var mailList = _mail.GetList();
            return mailList;
        }
        public bool InsertMailToSend(MAIL_TO_SEND mail)
        {
            var success = _mail.InsertMailToSend(mail);
            return success;
        }
        public bool UpdateMailToSend(MAIL_TO_SEND mail)
        {
            var success = _mail.UpdateMailToSend(mail);
            return success;
        }
        public bool DeleteMailToSend(int Id)
        {
            var success = _mail.DeleteMailToSend(Id);
            return success;
        }
        public MAIL_TO_SEND GetMailToSend(int id)
        {
            var mail = _mail.GetMailToSend(id);
            return mail;
        }

        public void MailToSend()
        {
            var mailList = _mail.GetList();
            foreach (var item in mailList)
            {
                var success = BusinessHelper.SendEmail(item.MAIL_SUBJECT, item.TO_ADDRESS, item.MAIL_BODY);
                if (success)
                {
                    _mail.UpdateIsSent(item.ID);
                }
            }
        }
    }
}
