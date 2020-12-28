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
    public class SurveyQuestionFunctions : ISurveyQuestion
    {
        public List<SURVEY_QUESTION> GetList()
        {
            using (MesContext context = new MesContext())
            {
                var surveyQuestionList = context.SURVEY_QUESTION.Include(q => q.CREATED_USER).Where(q => q.IS_DELETED == false).ToList();
                return surveyQuestionList;
            }
        }

        public List<SURVEY_QUESTION> GetListBySurveyId(int surveyId)
        {
            using (MesContext context = new MesContext())
            {
                var surveyQuestionList = context.SURVEY_QUESTION.Where(q => q.SURVEY_ID == surveyId && q.IS_DELETED==false).Include(q => q.CREATED_USER).ToList();
                return surveyQuestionList;
            }
        }

        public SURVEY_QUESTION GetSurveyQuestion(int id)
        {
            using (MesContext context = new MesContext())
            {
                var surveyQuestion = context.SURVEY_QUESTION.FirstOrDefault(q => q.ID == id);
                return surveyQuestion;
            }
        }

        public bool InsertSurveyQuestion(SURVEY_QUESTION surveyQuestion)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    context.SURVEY_QUESTION.Add(surveyQuestion);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool UpdateSurveyQuestion(SURVEY_QUESTION surveyQuestion)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var sq = context.SURVEY_QUESTION.FirstOrDefault(q => q.ID == surveyQuestion.ID);
                    if (sq != null)
                    {
                        sq.EVALUATION_1 = surveyQuestion.EVALUATION_1;
                        sq.EVALUATION_2 = surveyQuestion.EVALUATION_2;
                        sq.EVALUATION_3 = surveyQuestion.EVALUATION_3;
                        sq.EVALUATION_4 = surveyQuestion.EVALUATION_4;
                        sq.EVALUATION_5 = surveyQuestion.EVALUATION_5;

                        sq.BINARY_OPTION_1 = surveyQuestion.BINARY_OPTION_1;
                        sq.BINARY_OPTION_2 = surveyQuestion.BINARY_OPTION_2;

                        sq.QUESTION_TEXT = surveyQuestion.QUESTION_TEXT;
                        sq.SURVEY_ANSWER_TYPE_ID = surveyQuestion.SURVEY_ANSWER_TYPE_ID;

                        sq.UPDATED_DATE = DateTime.Now;
                        sq.UPDATED_USER_ID = surveyQuestion.UPDATED_USER_ID;
                    }
                    context.Entry(sq).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool DeleteSurveyQuestion(int Id)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var sq = context.SURVEY_QUESTION.FirstOrDefault(q => q.ID == Id);
                    sq.IS_DELETED = true;
                    context.Entry(sq).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
        //public bool DeleteSurveyQuestion(int Id)
        //{
        //    bool returnVal = false;
        //    try
        //    {
        //        using (MesContext context = new MesContext())
        //        {
        //            var sq = context.SURVEY_QUESTION.FirstOrDefault(q => q.ID == Id);
        //            context.SURVEY_QUESTION.Remove(sq);
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
