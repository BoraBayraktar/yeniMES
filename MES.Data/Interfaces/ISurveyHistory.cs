using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Interfaces
{
    public interface ISurveyHistory
    {
        SURVEY_HISTORY GetSurveyHistory(int id);
        SURVEY_HISTORY GetSurveyHistory(Guid guid);

        bool InsertSurveyHistory(SURVEY_HISTORY surveyHistory);
        bool IsDeletedSurveyHistory(int id);
    }
}
