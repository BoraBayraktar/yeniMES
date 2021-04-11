using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MES.Web.Model;
using MES.Web.Models;
using MES.Web.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MES.Web.Controllers
{
    public class SurveysController : BaseController
    {
        private ServiceBusiness serviceBusiness;
        public SurveysController(IHttpContextAccessor accessor, IConfiguration configuration)
        {
            serviceBusiness = new ServiceBusiness(configuration, accessor);
        }

        public IActionResult Index(Guid id)
        {
            var sh = serviceBusiness.ServicePost<SURVEY_HISTORY>(id, "Survey", "GetSurveyHistory");
            var questionList = serviceBusiness.ServicePost<List<SURVEY_QUESTION>>(id, "Survey", "SurveyQuestionGetListById");

            SurveyHistoryViewModel shvm = new SurveyHistoryViewModel();
            shvm.QuestionList = questionList;

            return View(shvm);
        }

        [HttpPost]
        public IActionResult Index(Guid id, SurveyHistoryViewModel surveyHistoryViewModel)
        {
            var sh = serviceBusiness.ServicePost<SURVEY_HISTORY>(id,"Survey","GetSurveyHistory");
            foreach (var item in surveyHistoryViewModel.AnswerList)
            {
                var answer = item.ANSWER.Split('_');
                SURVEY_QUESTION_ANSWER sqa = new SURVEY_QUESTION_ANSWER()
                {
                    SURVEY_QUESTION_ID = Convert.ToInt32(answer[0]),
                    ANSWER = answer[1],
                    CREATED_DATE = DateTime.Now,
                    SURVEY_HISTORY_ID = sh.ID,
                    //CREATED_USER_ID = sh.USER_ID
                };
                serviceBusiness.ServicePost<bool>(sqa, "Survey", "InsertSurveyQuestionAnswer");
            }
            serviceBusiness.ServicePost<bool>(sh.ID, "Survey", "IsDeletedSurveyHistory");

            return View(surveyHistoryViewModel);
        }
    }
}