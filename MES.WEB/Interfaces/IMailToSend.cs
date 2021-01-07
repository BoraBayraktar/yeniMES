using MES.Web.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Web.Interfaces
{
    public interface IMailToSend
    {
        List<MAIL_TO_SEND> GetList();
        MAIL_TO_SEND GetMailToSend(int id);
        bool InsertMailToSend(MAIL_TO_SEND mail);
        bool UpdateMailToSend(MAIL_TO_SEND mail);
        bool DeleteMailToSend(int Id);

        bool UpdateIsSent(int Id);
    }
}
