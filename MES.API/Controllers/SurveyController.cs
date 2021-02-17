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
        private JwtAuthenticationManager jwtAuthentication;
        private int userid;

        public SurveyController(IHttpContextAccessor accessor)
        {
            userid = jwtAuthentication.Decode(accessor.HttpContext.User.Claims.ToList().Where(x => x.Type == ClaimTypes.SerialNumber).FirstOrDefault().ToString());
        }

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
        public bool DeleteSurvey(int deleteId)
        {
            return logger.Logging<bool>(deleteId, "Survey", "Post", userid, "DeleteHolding", surveyLogic.DeleteSurvey(deleteId));
        }
        public SURVEY GetSurvey(int id)
        {
            return logger.Logging<SURVEY>(id, "Survey", "Post", userid, "GetHolding", surveyLogic.GetSurvey(id));
        }

    }
}
