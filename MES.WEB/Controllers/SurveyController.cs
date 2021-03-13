using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MES.Web.Model;
using MES.Web.Models;
using MES.Web.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace MES.Web.Controllers
{
    public class SurveyController : BaseController
    {
        readonly IHttpContextAccessor accessor;
        #region Instance
        private IHostingEnvironment _hostingEnvironment;
        ServiceBusiness serviceBusiness;
        public SurveyController(IConfiguration configuration, IHttpContextAccessor accessor)
        {
            serviceBusiness = new ServiceBusiness(configuration, accessor);
        }
        #endregion

        //public SurveyController(IHostingEnvironment environment)
        //{
        //    _hostingEnvironment = environment;
        //}
        public IActionResult Index()
        {
            var surveyList = serviceBusiness.ServiceGet<List<SURVEY>>("Survey", "SurveyGetList");
            SurveyViewModel svm = new SurveyViewModel();
            svm.SurveyList = surveyList;

            return View(svm);
        }

        public IActionResult CreateOrEditSurvey(int? id)
        {
            SurveyViewModel svm = new SurveyViewModel();
            var mainProcessList = serviceBusiness.ServiceGet<List<MAIN_PROCESS>>("MainProcess", "MainProcessGetList");
            var userList = serviceBusiness.ServiceGet<List<USER>>("User", "UserGetList");
            var userGroupList = serviceBusiness.ServiceGet<List<USER_GROUP>>("UserGroup", "UserGroupGetList");


            foreach (var item in mainProcessList)
            {
                svm.MainProcessList.Add(new SelectListItem()
                {
                    Text = item.NAME,
                    Value = item.ID.ToString()
                });
            }

            foreach (var item in userList)
            {
                svm.UserList.Add(new SelectListItem()
                {
                    Text = item.NAME,
                    Value = item.USER_ID.ToString()
                });
            }

            foreach (var item in userGroupList)
            {
                svm.UserGroupList.Add(new SelectListItem()
                {
                    Text = item.NAME,
                    Value = item.USER_GROUP_ID.ToString()
                });
            }

            if (id != null)
            {
                //var survey = surveyLogic.GetSurvey(Convert.ToInt32(id));
                //svm.Survey = survey;
                //svm.QuestionList = surveyQuestionLogic.GetListBySurveyId(Convert.ToInt32(id));

                //if (survey.MAIN_PROCESS_ID != null)
                //{
                //    var mainProcessStatusList = parameterLogic.GetParameterListByParameterTypeCode("STATUS", Convert.ToInt32(survey.MAIN_PROCESS_ID));
                //    foreach (var item in mainProcessStatusList)
                //    {
                //        svm.MainProcessStatusList.Add(new SelectListItem()
                //        {
                //            Text = item.MAIN_DATA_NAME,
                //            Value = item.ID.ToString()
                //        });
                //    }

                //}

                //if (!String.IsNullOrEmpty(survey.TO_USERS))
                //{
                //    svm.SelectedUsers = survey.TO_USERS.Split(',');
                //}
                //if (!String.IsNullOrEmpty(survey.TO_GROUPS))
                //{
                //    svm.SelectedGroups = survey.TO_GROUPS.Split(',');
                //}

                //if (survey.START_DATE != null)
                //{
                //    var startdate = Convert.ToDateTime(survey.START_DATE);
                //    svm.StartDate = startdate.Date;
                //    svm.StartTime = startdate.TimeOfDay;
                //}


                //string recipients = "";

                //if (survey.TO_CREATED_USER == true)
                //{
                //    recipients += "1,";
                //}
                //if (survey.TO_ASSIGNED_USER == true)
                //{
                //    recipients += "2,";
                //}
                //if (survey.TO_ASSIGNED_GROUP_USER == true)
                //{
                //    recipients += "3,";
                //}

                //svm.SelectedRecipients = recipients.Split(',');

            }


            return View(svm);
        }

        //        [HttpPost]
        //        public IActionResult CreateOrEditSurvey(int? id, SurveyViewModel surveyViewModel)
        //        {
        //            if (surveyViewModel.StartDate != null)
        //            {
        //                var sDate = Convert.ToDateTime(surveyViewModel.StartDate).ToUniversalTime();
        //                surveyViewModel.StartDate = sDate;
        //            }
        //            var user = HttpContext.Session.GetObject<USER>("User");

        //            bool success = false;

        //            SURVEY survey = new SURVEY();
        //            survey.SURVEY_NAME = surveyViewModel.Survey.SURVEY_NAME;
        //            survey.SURVEY_SEND_TYPE_ID = surveyViewModel.Survey.SURVEY_SEND_TYPE_ID;
        //            if (survey.SURVEY_SEND_TYPE_ID == (int)SurveySendTypeEnum.TekSeferlik)
        //            {
        //                //int i = 1;

        //                //if (surveyViewModel.SelectedUsers != null)
        //                //{
        //                //    int userCount = surveyViewModel.SelectedUsers.Length;
        //                //    foreach (var item in surveyViewModel.SelectedUsers)
        //                //    {
        //                //        survey.TO_USERS += item;
        //                //        if (i != userCount)
        //                //        {
        //                //            survey.TO_USERS += ",";
        //                //        }
        //                //        i++;
        //                //    }
        //                //}

        //                //if (surveyViewModel.SelectedGroups != null)
        //                //{
        //                //    int groupCount = surveyViewModel.SelectedGroups.Length;

        //                //    i = 1;
        //                //    foreach (var item in surveyViewModel.SelectedGroups)
        //                //    {
        //                //        survey.TO_GROUPS += item;
        //                //        if (i != groupCount)
        //                //        {
        //                //            survey.TO_GROUPS += ",";
        //                //        }
        //                //        i++;
        //                //    }
        //                //}

        //                var startdate = Convert.ToDateTime(surveyViewModel.StartDate);
        //                startdate = startdate.Date + (TimeSpan)surveyViewModel.StartTime;
        //                survey.START_DATE = startdate;


        //            }
        //            else if (survey.SURVEY_SEND_TYPE_ID == (int)SurveySendTypeEnum.Surekli)
        //            {
        //                survey.MAIN_PROCESS_ID = surveyViewModel.Survey.MAIN_PROCESS_ID;
        //                survey.SURVEY_PARAMETER_ID = surveyViewModel.Survey.SURVEY_PARAMETER_ID;
        //            }

        //            int i = 1;
        //            if (surveyViewModel.SelectedUsers != null)
        //            {
        //                int userCount = surveyViewModel.SelectedUsers.Length;
        //                foreach (var item in surveyViewModel.SelectedUsers)
        //                {
        //                    survey.TO_USERS += item;
        //                    if (i != userCount)
        //                    {
        //                        survey.TO_USERS += ",";
        //                    }
        //                    i++;
        //                }
        //            }

        //            if (surveyViewModel.SelectedGroups != null)
        //            {
        //                int groupCount = surveyViewModel.SelectedGroups.Length;

        //                i = 1;
        //                foreach (var item in surveyViewModel.SelectedGroups)
        //                {
        //                    survey.TO_GROUPS += item;
        //                    if (i != groupCount)
        //                    {
        //                        survey.TO_GROUPS += ",";
        //                    }
        //                    i++;
        //                }
        //            }

        //            if (surveyViewModel.SelectedRecipients != null)
        //            {
        //                foreach (var item in surveyViewModel.SelectedRecipients)
        //                {
        //                    if (item == "1")
        //                    {
        //                        survey.TO_CREATED_USER = true;
        //                    }
        //                    else if (item == "2")
        //                    {
        //                        survey.TO_ASSIGNED_USER = true;
        //                    }
        //                    else if (item == "3")
        //                    {
        //                        survey.TO_ASSIGNED_GROUP_USER = true;
        //                    }
        //                }
        //            }

        //            if (id == null)
        //            {
        //                survey.CREATED_USER_ID = user.USER_ID;
        //                success = surveyLogic.InsertSurvey(survey);
        //            }
        //            else
        //            {
        //                survey.SURVEY_ID = Convert.ToInt32(id);
        //                survey.UPDATED_USER_ID = user.USER_ID;
        //                success = surveyLogic.UpdateSurvey(survey);
        //            }


        //            var questionList = surveyQuestionLogic.GetListBySurveyId(survey.SURVEY_ID);

        //            foreach (var item in questionList)
        //            {
        //                var question = surveyViewModel.QuestionList.FirstOrDefault(q => q.ID == item.ID);
        //                if (question == null)
        //                {
        //                    success = surveyQuestionLogic.DeleteSurveyQuestion(item.ID);
        //                }
        //            }


        //            foreach (var item in surveyViewModel.QuestionList)
        //            {
        //                item.SURVEY_ID = survey.SURVEY_ID;
        //                if (item.ID == 0)
        //                {
        //                    item.CREATED_USER_ID = user.USER_ID;
        //                    success = surveyQuestionLogic.InsertSurveyQuestion(item);
        //                }
        //                else
        //                {
        //                    item.UPDATED_USER_ID = user.USER_ID;
        //                    success = surveyQuestionLogic.UpdateSurveyQuestion(item);
        //                }
        //            }


        //            ShowSuccessToastMessage();
        //            return RedirectToAction("Index", "Survey");
        //        }

        [HttpPost]
        public JsonResult DeleteSurvey(int deleteId)
        {
            bool success = false;
            success = serviceBusiness.ServicePost<bool>(deleteId,"Survey", "DeleteSurvey");
            return Json(new { success = success });
        }


        //        public IActionResult Survey(Guid id)
        //        {
        //            var sh = surveyHistoryLogic.GetSurveyHistory(id);
        //            var questionList = surveyQuestionLogic.GetListBySurveyId(sh.SURVEY_ID);

        //            SurveyHistoryViewModel shvm = new SurveyHistoryViewModel();
        //            shvm.QuestionList = questionList;

        //            return View(shvm);
        //        }

        //        [HttpPost]
        //        public IActionResult Survey(Guid id, SurveyHistoryViewModel surveyHistoryViewModel)
        //        {
        //            var sh = surveyHistoryLogic.GetSurveyHistory(id);
        //            foreach (var item in surveyHistoryViewModel.AnswerList)
        //            {
        //                var answer = item.ANSWER.Split('_');
        //                SURVEY_QUESTION_ANSWER sqa = new SURVEY_QUESTION_ANSWER()
        //                {
        //                    SURVEY_QUESTION_ID = Convert.ToInt32(answer[0]),
        //                    ANSWER = answer[1],
        //                    CREATED_DATE = DateTime.Now,
        //                    SURVEY_HISTORY_ID = sh.ID,
        //                    CREATED_USER_ID = sh.USER_ID
        //                };
        //                surveyAnswerLogic.InsertAnswer(sqa);
        //            }
        //            surveyHistoryLogic.IsDeletedSurveyHistory(sh.ID);


        //            return View(surveyHistoryViewModel);
        //        }



        //        public IActionResult SendSurvey(int id)
        //        {
        //            string body = "";


        //            var survey = surveyLogic.GetSurvey(id);
        //            string[] users = null;
        //            string[] groups = null;

        //            if (!String.IsNullOrEmpty(survey.TO_USERS))
        //            {
        //                users = survey.TO_USERS.Split(',');
        //            }
        //            if (!String.IsNullOrEmpty(survey.TO_GROUPS))
        //            {
        //                groups = survey.TO_GROUPS.Split(',');
        //            }

        //            if (groups != null)
        //            {
        //                for (int i = 0; i < groups.Length; i++)
        //                {
        //                    var groupId = Convert.ToInt32(groups[i]);
        //                    var userlist = userLogic.GetList().Where(q => q.USER_GROUP_ID == groupId);
        //                    foreach (var item in userlist)
        //                    {
        //                        body = "";
        //                        var userId = Convert.ToInt32(item.USER_ID);
        //                        SURVEY_HISTORY sh = new SURVEY_HISTORY()
        //                        {
        //                            CREATED_DATE = DateTime.Now,
        //                            IS_DELETED = false,
        //                            SURVEY_ID = id,
        //                            UNIQUE_ID = Guid.NewGuid(),
        //                            USER_ID = userId
        //                        };
        //                        surveyHistoryLogic.InsertSurveyHistory(sh);
        //                        body += "<p>Merhaba,</p><br /><br />";
        //                        body += "<p>Aşağıdaki linkten anketimize katılabilirsiniz.</p><br /><br />";
        //                        body += "https://mess.azurewebsites.net/Surveys/Index?id=";
        //                        body += sh.UNIQUE_ID;
        //                        Helper.SendEmail("MES Anket", item.EMAIL, body);
        //                    }
        //                }
        //            }

        //            if (users != null)
        //            {
        //                for (int i = 0; i < users.Length; i++)
        //                {
        //                    body = "";
        //                    var userId = Convert.ToInt32(users[i]);
        //                    SURVEY_HISTORY sh = new SURVEY_HISTORY()
        //                    {
        //                        CREATED_DATE = DateTime.Now,
        //                        IS_DELETED = false,
        //                        SURVEY_ID = id,
        //                        UNIQUE_ID = Guid.NewGuid(),
        //                        USER_ID = userId
        //                    };
        //                    surveyHistoryLogic.InsertSurveyHistory(sh);
        //                    var user = userLogic.GetUser(userId);
        //                    body += "<p>Merhaba,</p><br /><br />";
        //                    body += "<p>Aşağıdaki linkten anketimize katılabilirsiniz.</p><br /><br />";
        //                    body += "https://mess.azurewebsites.net/Surveys/Index?id=";
        //                    body += sh.UNIQUE_ID;
        //                    Helper.SendEmail("MES Anket", user.EMAIL, body);
        //                }
        //            }




        //            ShowSuccessToastMessage();
        //            return RedirectToAction("Index", "Survey");

        //        }
    }
}