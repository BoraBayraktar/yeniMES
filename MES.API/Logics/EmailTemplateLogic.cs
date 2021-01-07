using MES.Data.Functions;
using MES.Data.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Logics
{
    public class EmailTemplateLogic
    {
        IEmailTemplate _emailTemplate = new EmailTemplateFunctions();
        public EMAIL_TEMPLATE GetEmailTemplate(int id)
        {
            var emailTemplate = _emailTemplate.GetEmailTemplate(id);
            return emailTemplate;
        }
        public List<EMAIL_TEMPLATE> GetList()
        {
            var templateList = _emailTemplate.GetList();
            return templateList;
        }
        public List<EMAIL_TEMPLATE_PARAMETERS> GetParameterList()
        {
            var parameterList = _emailTemplate.GetParameterList();
            return parameterList;
        }

        public bool InsertEmailTemplate(EMAIL_TEMPLATE template)
        {
            var success = _emailTemplate.InsertEmailTemplate(template);
            return success;
        }
        public bool UpdateEmailTemplate(EMAIL_TEMPLATE template)
        {
            var success = _emailTemplate.UpdateEmailTemplate(template);
            return success;
        }
        public bool DeleteEmailTemplate(int Id)
        {
            var success = _emailTemplate.DeleteEmailTemplate(Id);
            return success;
        }

        public List<EMAIL_TEMPLATE_PARAMETERS> GetEmailTemplateParametersByMainProcessId(int mainProcessId)
        {
            var parameterList = _emailTemplate.GetEmailTemplateParametersByMainProcessId(mainProcessId);
            return parameterList;
        }

    }
}
