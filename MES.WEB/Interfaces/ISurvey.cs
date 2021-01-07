using MES.Web.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Web.Interfaces
{
    public interface ISurvey
    {
        List<SURVEY> GetList();
        SURVEY GetSurvey(int id);
        bool InsertSurvey(SURVEY survey);
        bool UpdateSurvey(SURVEY survey);
        bool DeleteSurvey(int Id);
    }
}
