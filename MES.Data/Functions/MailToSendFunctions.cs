using MES.Data.Interfaces;
using MES.DB;
using MES.DB.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MES.Data.Functions
{
    public class MailToSendFunctions : IMailToSend
    {
        public List<MAIL_TO_SEND> GetList()
        {
            using (MesContext context = new MesContext())
            {
                var mailList = context.MAIL_TO_SEND.Where(q => q.IS_DELETED == false && q.IS_SENT == false).ToList();
                return mailList;
            }
        }

        public MAIL_TO_SEND GetMailToSend(int id)
        {
            using (MesContext context = new MesContext())
            {
                var mail = context.MAIL_TO_SEND.FirstOrDefault(q => q.ID == id);
                return mail;
            }
        }

        public bool InsertMailToSend(MAIL_TO_SEND mail)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    context.MAIL_TO_SEND.Add(mail);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool UpdateMailToSend(MAIL_TO_SEND mail)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var m = context.MAIL_TO_SEND.FirstOrDefault(q => q.ID == mail.ID);
                    if (m != null)
                    {
                        m.IS_DELETED = mail.IS_DELETED;
                        m.IS_SENT = mail.IS_SENT;
                        m.MAIL_BODY = mail.MAIL_BODY;
                        m.MAIL_SUBJECT = mail.MAIL_SUBJECT;
                        m.MAIN_PROCESS_ID = mail.MAIN_PROCESS_ID;
                        m.PARAMETER_ID = mail.PARAMETER_ID;
                        m.PARAMETER_TYPE_ID = mail.PARAMETER_TYPE_ID;
                        m.TO_ADDRESS = mail.TO_ADDRESS;
                        m.UPDATED_DATE = DateTime.Now;
                    }
                    context.Entry(m).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }


        public bool DeleteMailToSend(int Id)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var mail = context.MAIL_TO_SEND.FirstOrDefault(q => q.ID == Id);
                    mail.IS_DELETED = true;
                    context.Entry(mail).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }


        public bool UpdateIsSent(int Id)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var m = context.MAIL_TO_SEND.FirstOrDefault(q => q.ID == Id);
                    if (m != null)
                    {
                        m.IS_SENT = true;
                    }
                    context.Entry(m).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
    }
}
