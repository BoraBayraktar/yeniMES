using MES.API.Interfaces;
using MES.DB;
using MES.DB.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MES.API.Functions
{
    public class SurveyFunctions : ISurvey
    {
        public List<SURVEY> GetList()
        {
            using (MesContext context = new MesContext())
            {
                var surveyList = context.SURVEY.Include(q => q.CREATED_USER).Where(q => q.IS_DELETED == false).ToList();
                return surveyList;
            }
        }

        public SURVEY GetSurvey(int id)
        {
            using (MesContext context = new MesContext())
            {
                var survey = context.SURVEY.FirstOrDefault(q => q.SURVEY_ID == id);
                return survey;
            }
        }

        public bool InsertSurvey(SURVEY survey)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    context.SURVEY.Add(survey);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool UpdateSurvey(SURVEY survey)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var srv = context.SURVEY.FirstOrDefault(q => q.SURVEY_ID == survey.SURVEY_ID);
                    if (srv != null)
                    {
                        srv.SURVEY_NAME = survey.SURVEY_NAME;
                        srv.SURVEY_SEND_TYPE_ID = survey.SURVEY_SEND_TYPE_ID;

                        srv.TO_USERS = survey.TO_USERS;
                        srv.TO_GROUPS = survey.TO_GROUPS;
                        srv.START_DATE = survey.START_DATE;

                        srv.MAIN_PROCESS_ID = survey.MAIN_PROCESS_ID;
                        srv.SURVEY_PARAMETER_ID = survey.SURVEY_PARAMETER_ID;

                        srv.TO_ASSIGNED_USER = survey.TO_ASSIGNED_USER;
                        srv.TO_CREATED_USER = survey.TO_CREATED_USER;
                        srv.TO_ASSIGNED_GROUP_USER = survey.TO_ASSIGNED_GROUP_USER;

                        srv.UPDATED_DATE = DateTime.Now;
                    }
                    context.Entry(srv).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool DeleteSurvey(int Id)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var survey = context.SURVEY.FirstOrDefault(q => q.SURVEY_ID == Id);
                    survey.IS_DELETED = true;
                    context.Entry(survey).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
        //public bool DeleteSurvey(int Id)
        //{
        //    bool returnVal = false;
        //    try
        //    {
        //        using (MesContext context = new MesContext())
        //        {
        //            var survey = context.SURVEY.FirstOrDefault(q => q.SURVEY_ID == Id);
        //            context.SURVEY.Remove(survey);
        //            context.SaveChanges();
        //            returnVal = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return returnVal;
        //}
    }
}
