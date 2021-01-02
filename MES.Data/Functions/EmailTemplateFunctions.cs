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
    public class EmailTemplateFunctions : IEmailTemplate
    {
        public EMAIL_TEMPLATE GetEmailTemplate(int id)
        {
            using (MesContext context = new MesContext())
            {
                var emailTemplate = context.EMAIL_TEMPLATE.Include(q => q.MAIN_PROCESS)
                                                          .FirstOrDefault(q => q.ID == id);
                return emailTemplate;
            }
        }
        public List<EMAIL_TEMPLATE> GetList()
        {
            using (MesContext context = new MesContext())
            {
                var templateList = context.EMAIL_TEMPLATE.Include(q => q.MAIN_PROCESS).Where(q => q.IS_DELETED == false).ToList();
                foreach (var item in templateList)
                {
                    var parameter = context.PARAMETER.FirstOrDefault(q => q.ID == item.MAIN_PROCESS_STATUS_ID);
                    if (parameter != null)
                    {
                        item.MAIN_PROCESS_STATUS = parameter.MAIN_DATA_NAME;
                    }
                }
                return templateList;
            }
        }
        public List<EMAIL_TEMPLATE_PARAMETERS> GetParameterList()
        {
            using (MesContext context = new MesContext())
            {
                var parameterList = context.EMAIL_TEMPLATE_PARAMETERS.ToList();
                return parameterList;
            }
        }

        public bool InsertEmailTemplate(EMAIL_TEMPLATE template)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    template.CREATED_DATE = DateTime.Now;
                    context.EMAIL_TEMPLATE.Add(template);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool UpdateEmailTemplate(EMAIL_TEMPLATE template)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var tmp = context.EMAIL_TEMPLATE.FirstOrDefault(q => q.ID == template.ID);
                    if (tmp != null)
                    {
                        tmp.NAME = template.NAME;
                        tmp.SUBJECT = template.SUBJECT;
                        tmp.TO_ASSIGNED_USER = template.TO_ASSIGNED_USER;
                        tmp.TO_CREATED_USER = template.TO_CREATED_USER;
                        tmp.TO_ASSIGNED_GROUP_USER = template.TO_ASSIGNED_GROUP_USER;
                        tmp.TO_USERS = template.TO_USERS;
                        tmp.TO_GROUPS = template.TO_GROUPS;
                        tmp.BODY = template.BODY;


                        tmp.MAIN_PROCESS_STATUS_ID = template.MAIN_PROCESS_STATUS_ID;
                        tmp.MAIN_PROCESS_ID = template.MAIN_PROCESS_ID;


                        tmp.UPDATED_DATE = DateTime.Now;
                    }
                    context.Entry(tmp).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }


        public bool DeleteEmailTemplate(int Id)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var template = context.EMAIL_TEMPLATE.FirstOrDefault(q => q.ID == Id);
                    template.IS_DELETED = true;
                    context.Entry(template).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        //public bool DeleteEmailTemplate(int Id)
        //{
        //    bool returnVal = false;
        //    try
        //    {
        //        using (MesContext context = new MesContext())
        //        {
        //            var template = context.EMAIL_TEMPLATE.FirstOrDefault(q => q.ID == Id);
        //            context.EMAIL_TEMPLATE.Remove(template);
        //            context.SaveChanges();
        //            returnVal = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return returnVal;
        //}


        public List<EMAIL_TEMPLATE_PARAMETERS> GetEmailTemplateParametersByMainProcessId(int mainProcessId)
        {
            using (MesContext context = new MesContext())
            {
                var parameterList = context.EMAIL_TEMPLATE_PARAMETERS.Where(q => q.MAIN_PROCESS_ID == mainProcessId).ToList();
                return parameterList;
            }
        }

    }
}
