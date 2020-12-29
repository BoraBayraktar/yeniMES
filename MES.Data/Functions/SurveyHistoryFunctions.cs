using MES.Data.Interfaces;
using MES.DB;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MES.Data.Functions
{
    public class SurveyHistoryFunctions : ISurveyHistory
    {
        public SURVEY_HISTORY GetSurveyHistory(int id)
        {
            using (MesContext context = new MesContext())
            {
                var surveyHistory = context.SURVEY_HISTORY.FirstOrDefault(q => q.ID == id);
                return surveyHistory;
            }
        }
        public SURVEY_HISTORY GetSurveyHistory(Guid guid)
        {
            using (MesContext context = new MesContext())
            {
                var surveyHistory = context.SURVEY_HISTORY.FirstOrDefault(q => q.UNIQUE_ID == guid && q.IS_DELETED==false);
                return surveyHistory;
            }
        }

        public bool InsertSurveyHistory(SURVEY_HISTORY surveyHistory)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    context.SURVEY_HISTORY.Add(surveyHistory);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }


        public bool IsDeletedSurveyHistory(int id)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var sh = context.SURVEY_HISTORY.FirstOrDefault(q => q.ID == id);
                    sh.IS_DELETED = true;
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
