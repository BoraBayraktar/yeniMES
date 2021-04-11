using MES.API.Logger;
using MES.Data.Logics;
using MES.DB.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MES.API.JwtToken;
using MES.API.Business;

namespace MES.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        Log logger = new Log();
        private SurveyLogic surveyLogic = new SurveyLogic();
        private SurveyHistoryLogic surveyHistoryLogic = new SurveyHistoryLogic();
        private SurveyQuestionLogic surveyQuestionLogic = new SurveyQuestionLogic();
        private SurveyAnswerLogic surveyAnswerLogic = new SurveyAnswerLogic();
        private int userid;

        public SurveyController(IHttpContextAccessor accessor)
        {
            userid = Convert.ToInt32(accessor?.HttpContext.User.FindFirstValue(ClaimTypes.SerialNumber));
        }
        #region Survey
        [HttpGet("SurveyGetList")]
        public List<SURVEY> SurveyGetList()
        {
            return logger.Logging<List<SURVEY>>(null, "Survey", "Get", userid, "SurveyGetList", surveyLogic.GetList());
        }
        [HttpPost("InsertSurvey")]
        public bool InsertSurvey(SURVEY survey)
        {
            return logger.Logging<bool>(survey, "Survey", "Post", userid, "InsertSurvey", surveyLogic.InsertSurvey(survey));
        }
        [HttpPost("UpdateSurvey")]
        public bool UpdateSurvey(SURVEY survey)
        {
            return logger.Logging<bool>(survey, "Survey", "Post", userid, "UpdateSurvey", surveyLogic.UpdateSurvey(survey));
        }
        [HttpDelete("DeleteSurvey")]
        public bool DeleteSurvey([FromBody] int deleteId)
        {
            return logger.Logging<bool>(deleteId, "Survey", "Post", userid, "DeleteSurvey", surveyLogic.DeleteSurvey(deleteId));
        }
        [HttpPost("GetSurvey")]
        public SURVEY GetSurvey([FromBody]int id)
        {
            return logger.Logging<SURVEY>(id, "Survey", "Post", userid, "GetSurvey", surveyLogic.GetSurvey(id));
        }
        #endregion

        #region SurveyQuestion
        [HttpPost("SurveyQuestionGetListById")]
        public List<SURVEY_QUESTION> SurveyQuestionGetListById([FromBody] int id)
        {
            return logger.Logging<List<SURVEY_QUESTION>>(id, "Survey", "Post", userid, "SurveyQuestionGetListById", surveyQuestionLogic.GetListBySurveyId(id));
        }
        [HttpPost("InsertSurveyQuestion")]
        public bool InsertSurveyQuestion(SURVEY_QUESTION surveyQuestion)
        {
            return logger.Logging<bool>(surveyQuestion, "Survey", "Post", userid, "InsertSurveyQuestion", surveyQuestionLogic.InsertSurveyQuestion(surveyQuestion));
        }
        [HttpPost("UpdateSurveyQuestion")]
        public bool UpdateSurveyQuestion(SURVEY_QUESTION surveyQuestion)
        {
            return logger.Logging<bool>(surveyQuestion, "Survey", "Post", userid, "UpdateSurveyQuestion", surveyQuestionLogic.UpdateSurveyQuestion(surveyQuestion));
        }
        [HttpDelete("DeleteSurveyQuestion")]
        public bool DeleteSurveyQuestion([FromBody] int deleteId)
        {
            return logger.Logging<bool>(deleteId, "Survey", "Post", userid, "DeleteSurveyQuestion", surveyQuestionLogic.DeleteSurveyQuestion(deleteId));
        }
        #endregion

        #region SurveyHistory
        [HttpPost("GetSurveyHistory")]
        public SURVEY_HISTORY GetSurveyHistory([FromBody] int id)
        {
            return logger.Logging<SURVEY_HISTORY>(id, "Survey", "Post", userid, "GetSurveyHistory", surveyHistoryLogic.GetSurveyHistory(id));
        }
        [HttpPost("InsertSurveyHistory")]
        public bool InsertSurveyHistory(SURVEY_HISTORY surveyHistory)
        {
            return logger.Logging<bool>(surveyHistory, "Survey", "Post", userid, "InsertSurveyHistory", surveyHistoryLogic.InsertSurveyHistory(surveyHistory));
        }
        [HttpPost("IsDeletedSurveyHistory")]
        public bool IsDeletedSurveyHistory([FromBody] int id)
        {
            return logger.Logging<bool>(id, "Survey", "Post", userid, "IsDeletedSurveyHistory", surveyHistoryLogic.IsDeletedSurveyHistory(id));
        }

        #endregion

        #region SurveyAnswer
        [HttpPost("InsertSurveyQuestionAnswer")]
        public bool InsertSurveyQuestionAnswer(SURVEY_QUESTION_ANSWER surveyQuestionAnswer)
        {
            return logger.Logging<bool>(surveyQuestionAnswer, "Survey", "Post", userid, "InsertSurveyQuestionAnswer", surveyAnswerLogic.InsertAnswer(surveyQuestionAnswer));
        }
        #endregion
    }
}
