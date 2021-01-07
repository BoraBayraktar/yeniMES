using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.API.ViewModels
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
