using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.API.Interfaces
{
    public interface IEmailTemplate
    {
        EMAIL_TEMPLATE GetEmailTemplate(int id);

        List<EMAIL_TEMPLATE> GetList();

        List<EMAIL_TEMPLATE_PARAMETERS> GetParameterList();

        bool InsertEmailTemplate(EMAIL_TEMPLATE template);
        bool UpdateEmailTemplate(EMAIL_TEMPLATE template);
        bool DeleteEmailTemplate(int Id);

        List<EMAIL_TEMPLATE_PARAMETERS> GetEmailTemplateParametersByMainProcessId(int mainProcessId);
    }
}
