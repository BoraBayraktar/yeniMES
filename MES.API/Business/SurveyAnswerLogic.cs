using MES.API.Functions;
using MES.API.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.API.Business
{
    public class SurveyAnswerLogic
    {
        ISurveyAnswer _surveyAnswer = new SurveyAnswerFunctions();
        public bool InsertAnswer(SURVEY_QUESTION_ANSWER answer)
        {
            var success = _surveyAnswer.InsertAnswer(answer);
            return success;
        }

    }
}
