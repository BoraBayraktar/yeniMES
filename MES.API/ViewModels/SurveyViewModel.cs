using MES.DB.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.API.ViewModels
{
    public class SurveyViewModel
    {
        public SurveyViewModel()
        {
            QuestionList = new List<SURVEY_QUESTION>();
            SurveyList = new List<SURVEY>();
            MainProcessList = new List<SelectListItem>();
            MainProcessStatusList = new List<SelectListItem>();

            UserList = new List<SelectListItem>();
            UserGroupList = new List<SelectListItem>();
        }
        public SURVEY Survey { get; set; }
        public List<SURVEY_QUESTION> QuestionList { get; set; }
        public List<SURVEY> SurveyList { get; set; }

        public List<SelectListItem> MainProcessList { get; set; }
        public List<SelectListItem> MainProcessStatusList { get; set; }

        public DateTime? StartDate { get; set; }
        public TimeSpan? StartTime { get; set; }


        public string[] SelectedUsers { get; set; }
        public string[] SelectedGroups { get; set; }

        public string[] SelectedRecipients { get; set; }


        public List<SelectListItem> UserList { get; set; }
        public List<SelectListItem> UserGroupList { get; set; }


    }
}
