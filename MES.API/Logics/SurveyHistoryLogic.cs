using MES.Data.Functions;
using MES.Data.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Logics
{
    public class SurveyHistoryLogic
    {
        ISurveyHistory _surveyHistory = new SurveyHistoryFunctions();
        public SURVEY_HISTORY GetSurveyHistory(int id)
        {
            var surveyHistory = _surveyHistory.GetSurveyHistory(id);
            return surveyHistory;
        }
        public SURVEY_HISTORY GetSurveyHistory(Guid guid)
        {
            var surveyHistory = _surveyHistory.GetSurveyHistory(guid);
            return surveyHistory;
        }

        public bool InsertSurveyHistory(SURVEY_HISTORY surveyHistory)
        {
            var success = _surveyHistory.InsertSurveyHistory(surveyHistory);
            return success;
        }
        public bool IsDeletedSurveyHistory(int id)
        {
            var success = _surveyHistory.IsDeletedSurveyHistory(id);
            return success;
        }
    }
}
