using MES.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.Web.Models
{
    public class SurveyHistoryViewModel
    {
        public SurveyHistoryViewModel()
        {
            QuestionList = new List<SURVEY_QUESTION>();
        }

        public List<SURVEY_QUESTION> QuestionList { get; set; }
        public List<SURVEY_QUESTION_ANSWER> AnswerList { get; set; }


    }
}
