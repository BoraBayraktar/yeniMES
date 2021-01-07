using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace MES.Data.Logics
{
    public class BusinessHelper
    {
        public static bool SendEmail(string subject, string emailToAddress, string body)
        {
            bool returnVal = false;
            try
            {
                MailSettingsLogic mailSettingsLogic = new MailSettingsLogic();
                var mailSettings = mailSettingsLogic.GetList().FirstOrDefault();
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(mailSettings.DEFAULT_ADDRESS);
                    mail.To.Add(emailToAddress);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;
                    //mail.Attachments.Add(new Attachment("D:\\TestFile.txt")); 
                    using (SmtpClient smtp = new SmtpClient(mailSettings.SMTP_HOST, mailSettings.SMTP_PORT))
                    {
                        smtp.Credentials = new NetworkCredential(mailSettings.USERNAME, mailSettings.PASSWORD);
                        //smtp.EnableSsl = enableSSL;
                        smtp.Send(mail);
                    }
                }
                returnVal = true;
            }
            catch (Exception ex)
            {
                returnVal = false;
            }
            return returnVal;
        }
    }
}
