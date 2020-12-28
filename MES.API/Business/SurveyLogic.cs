using MES.API.Functions;
using MES.API.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.API.Business
{
    public class SurveyLogic
    {
        ISurvey _survey = new SurveyFunctions();
        public List<SURVEY> GetList()
        {
            var surveyList = _survey.GetList();
            return surveyList;
        }
        public bool InsertSurvey(SURVEY survey)
        {
            var success = _survey.InsertSurvey(survey);
            return success;
        }
        public bool UpdateSurvey(SURVEY survey)
        {
            var success = _survey.UpdateSurvey(survey);
            return success;
        }
        public bool DeleteSurvey(int Id)
        {
            var success = _survey.DeleteSurvey(Id);
            return success;
        }
        public SURVEY GetSurvey(int id)
        {
            var survey = _survey.GetSurvey(id);
            return survey;
        }
    }
}
