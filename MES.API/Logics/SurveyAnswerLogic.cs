using MES.Data.Functions;
using MES.Data.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Logics
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
