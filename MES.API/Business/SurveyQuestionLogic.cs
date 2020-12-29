using MES.Data.Functions;
using MES.Data.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Business
{
    public class SurveyQuestionLogic
    {
        ISurveyQuestion _surveyQuestion = new SurveyQuestionFunctions();
        public List<SURVEY_QUESTION> GetList()
        {
            var surveyQuestionList = _surveyQuestion.GetList();
            return surveyQuestionList;
        }
        public List<SURVEY_QUESTION> GetListBySurveyId(int surveyId)
        {
            var surveyQuestionList = _surveyQuestion.GetListBySurveyId(surveyId);
            return surveyQuestionList;
        }
        public bool InsertSurveyQuestion(SURVEY_QUESTION surveyQuestion)
        {
            var success = _surveyQuestion.InsertSurveyQuestion(surveyQuestion);
            return success;
        }
        public bool UpdateSurveyQuestion(SURVEY_QUESTION surveyQuestion)
        {
            var success = _surveyQuestion.UpdateSurveyQuestion(surveyQuestion);
            return success;
        }
        public bool DeleteSurveyQuestion(int Id)
        {
            var success = _surveyQuestion.DeleteSurveyQuestion(Id);
            return success;
        }
        public SURVEY_QUESTION GetSurveyQuestion(int id)
        {
            var sq = _surveyQuestion.GetSurveyQuestion(id);
            return sq;
        }
    }
}
