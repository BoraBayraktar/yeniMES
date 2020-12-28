using MES.API.Interfaces;
using MES.DB;
using MES.DB.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MES.API.Functions
{
    public class MailSettingsFunctions : IMailSettings
    {
        public List<MAIL_SERVER_SETUP> GetList()
        {
            using (MesContext context = new MesContext())
            {
                var mailServerList = context.MAIL_SERVER_SETUP.Include(q => q.CREATED_USER).Where(q => q.IS_DELETED == false).ToList();
                return mailServerList;
            }
        }

        public MAIL_SERVER_SETUP GetMailServerSetup(int id)
        {
            using (MesContext context = new MesContext())
            {
                var mss = context.MAIL_SERVER_SETUP.FirstOrDefault(q => q.ID == id);
                return mss;
            }
        }

        public bool InsertMailServerSetup(MAIL_SERVER_SETUP mss)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    mss.CREATED_DATE = DateTime.Now;
                    context.MAIL_SERVER_SETUP.Add(mss);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool UpdateMailServerSetup(MAIL_SERVER_SETUP mss)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var mailServer = context.MAIL_SERVER_SETUP.FirstOrDefault(q => q.ID == mss.ID);
                    if (mailServer != null)
                    {
                        mailServer.SMTP_HOST = mss.SMTP_HOST;
                        mailServer.SMTP_PORT = mss.SMTP_PORT;
                        mailServer.USERNAME = mss.USERNAME;
                        mailServer.PASSWORD = mss.PASSWORD;
                        mailServer.DEFAULT_ADDRESS = mss.DEFAULT_ADDRESS;
                        mailServer.DEFAULT_NAME = mss.DEFAULT_NAME;
                        mailServer.TRY_COUNT = mss.TRY_COUNT;

                        mailServer.UPDATED_USER_ID = mss.CREATED_USER_ID;
                        mailServer.UPDATED_DATE = DateTime.Now;

                    }
                    context.Entry(mailServer).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool DeleteMailServerSetup(int Id)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var mss = context.MAIL_SERVER_SETUP.FirstOrDefault(q => q.ID == Id);
                    mss.IS_DELETED = true;
                    context.Entry(mss).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
        //public bool DeleteMailServerSetup(int Id)
        //{
        //    bool returnVal = false;
        //    try
        //    {
        //        using (MesContext context = new MesContext())
        //        {
        //            var mss = context.MAIL_SERVER_SETUP.FirstOrDefault(q => q.ID == Id);
        //            context.MAIL_SERVER_SETUP.Remove(mss);
        //            context.SaveChanges();
        //            returnVal = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return returnVal;
        //}

        public bool InsertOrUpdateMailServerSetup(MAIL_SERVER_SETUP mss)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var mailSetup = context.MAIL_SERVER_SETUP.FirstOrDefault();
                    if (mailSetup == null)
                    {
                        InsertMailServerSetup(mss);
                    }
                    else
                    {
                        mss.ID = mailSetup.ID;
                        UpdateMailServerSetup(mss);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
    }
}
