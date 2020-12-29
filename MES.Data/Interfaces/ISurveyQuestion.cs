using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Interfaces
{
    public interface ISurveyQuestion
    {
        List<SURVEY_QUESTION> GetList();
        List<SURVEY_QUESTION> GetListBySurveyId(int surveyId);
        SURVEY_QUESTION GetSurveyQuestion(int id);
        bool InsertSurveyQuestion(SURVEY_QUESTION surveyQuestion);
        bool UpdateSurveyQuestion(SURVEY_QUESTION surveyQuestion);
        bool DeleteSurveyQuestion(int Id);
    }
}
