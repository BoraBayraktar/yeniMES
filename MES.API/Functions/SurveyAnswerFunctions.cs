using MES.API.Interfaces;
using MES.DB;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.API.Functions
{
    public class SurveyAnswerFunctions : ISurveyAnswer
    {
        public bool InsertAnswer(SURVEY_QUESTION_ANSWER answer)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    answer.CREATED_DATE = DateTime.Now;
                    context.SURVEY_QUESTION_ANSWER.Add(answer);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
    }
}
