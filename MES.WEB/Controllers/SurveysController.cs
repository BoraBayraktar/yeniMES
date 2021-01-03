using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MES.Business;
using MES.Entities.Model;
using MES.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace MES.Web.Controllers
{
    public class SurveysController : BaseController
    {
        SurveyQuestionLogic surveyQuestionLogic = new SurveyQuestionLogic();
        SurveyHistoryLogic surveyHistoryLogic = new SurveyHistoryLogic();
        SurveyAnswerLogic surveyAnswerLogic = new SurveyAnswerLogic();

        public IActionResult Index(Guid id)
        {
            var sh = surveyHistoryLogic.GetSurveyHistory(id);
            var questionList = surveyQuestionLogic.GetListBySurveyId(sh.SURVEY_ID);

            SurveyHistoryViewModel shvm = new SurveyHistoryViewModel();
            shvm.QuestionList = questionList;

            return View(shvm);
        }

        [HttpPost]
        public IActionResult Index(Guid id, SurveyHistoryViewModel surveyHistoryViewModel)
        {
            var sh = surveyHistoryLogic.GetSurveyHistory(id);
            foreach (var item in surveyHistoryViewModel.AnswerList)
            {
                var answer = item.ANSWER.Split('_');
                SURVEY_QUESTION_ANSWER sqa = new SURVEY_QUESTION_ANSWER()
                {
                    SURVEY_QUESTION_ID = Convert.ToInt32(answer[0]),
                    ANSWER = answer[1],
                    CREATED_DATE = DateTime.Now,
                    SURVEY_HISTORY_ID = sh.ID,
                    CREATED_USER_ID = sh.USER_ID
                };
                surveyAnswerLogic.InsertAnswer(sqa);
            }
            surveyHistoryLogic.IsDeletedSurveyHistory(sh.ID);


            return View(surveyHistoryViewModel);
        }
    }
}