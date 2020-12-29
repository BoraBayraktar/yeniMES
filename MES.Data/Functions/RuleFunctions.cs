using MES.Data.Model;
using MES.Data.Interfaces;
using MES.DB;
using MES.DB.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace MES.Data.Functions
{
    public class RuleFunctions : IRule
    {
        public static List<T> RawSqlQuery<T>(string query, Func<DbDataReader, T> map)
        {
            using (var context = new MesContext())
            {
                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;

                    context.Database.OpenConnection();

                    using (var result = command.ExecuteReader())
                    {
                        var entities = new List<T>();

                        while (result.Read())
                        {
                            entities.Add(map(result));
                        }

                        return entities;
                    }
                }
            }
        }

        public List<RULE_CRITERIA> GetRuleCriteriaList()
        {
            using (MesContext context = new MesContext())
            {
                var ruleCriteriaList = context.RULE_CRITERIA.ToList();
                return ruleCriteriaList;
            }
        }

        public List<RuleCriteriaData> GetRuleCriteriaData(int ruleCriteriaId)
        {
            string query = "";
            using (MesContext context = new MesContext())
            {
                var ruleCritreria = context.RULE_CRITERIA.FirstOrDefault(q => q.ID == ruleCriteriaId);
                if (ruleCritreria != null)
                {
                    query += "select \"" + ruleCritreria.FOREIGN_KEY + "\"," + ruleCritreria.FOREIGN_VALUE + " from \"" + ruleCritreria.FOREIGN_TABLE_NAME + "\"";
                    if (!String.IsNullOrEmpty(ruleCritreria.FOREIGN_WHERE_CLAUSE))
                    {
                        query += " where ";
                        query += ruleCritreria.FOREIGN_WHERE_CLAUSE;
                    }
                    var result = RawSqlQuery(query, q => new RuleCriteriaData { Key = (int)q[0], Value = (string)q[1] });
                    return result;
                }
            }
            return null;
        }


        public List<RULE> GetRuleList()
        {
            using (MesContext context = new MesContext())
            {
                var ruleList = context.RULE.Include(q => q.CREATED_USER)
                                             .Where(q => q.IS_DELETED == false)
                                             .ToList();
                return ruleList;
            }
        }
        public bool InsertRule(RULE rule)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    rule.CREATED_DATE = DateTime.Now;
                    context.RULE.Add(rule);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool UpdateRule(RULE rule)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var _rule = context.RULE.FirstOrDefault(q => q.RULE_ID == rule.RULE_ID);
                    if (_rule != null)
                    {
                        _rule.UPDATED_DATE = DateTime.Now;
                        _rule.UPDATED_USER_ID = rule.UPDATED_USER_ID;

                        _rule.IS_DELETED = rule.IS_DELETED;
                        _rule.MAIN_PROCESS_ID = rule.MAIN_PROCESS_ID;
                        _rule.RULE_NAME = rule.RULE_NAME;
                        _rule.RULE_DESCRIPTION = rule.RULE_DESCRIPTION;
                        _rule.RULE_ACTION_TYPE = rule.RULE_ACTION_TYPE;
                        _rule.RULE_ACTION_DATA = rule.RULE_ACTION_DATA;
                        _rule.RULE_ACTION = rule.RULE_ACTION;
                    }
                    context.Entry(_rule).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }


        public bool DeleteRule(int Id)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var rule = context.RULE.FirstOrDefault(q => q.RULE_ID == Id);
                    rule.IS_DELETED = true;
                    context.Entry(rule).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }




        public List<RULE_DETAIL> GetRuleDetailByRuleId(int ruleId)
        {
            using (MesContext context = new MesContext())
            {
                var ruleDetailList = context.RULE_DETAIL.Include(q => q.CREATED_USER)
                                                        .Where(q => q.IS_DELETED == false && q.RULE_ID == ruleId)
                                                        .ToList();
                return ruleDetailList;
            }
        }

        public List<RULE_DETAIL> GetRuleDetailList()
        {
            using (MesContext context = new MesContext())
            {
                var ruleDetailList = context.RULE_DETAIL.Include(q => q.CREATED_USER)
                                                        .Where(q => q.IS_DELETED == false)
                                                        .ToList();
                return ruleDetailList;
            }
        }
        public bool InsertRuleDetail(RULE_DETAIL ruleDetail)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    ruleDetail.CREATED_DATE = DateTime.Now;
                    context.RULE_DETAIL.Add(ruleDetail);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool UpdateRuleDetail(RULE_DETAIL ruleDetail)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var _ruleDetail = context.RULE_DETAIL.FirstOrDefault(q => q.RULE_DETAIL_ID == ruleDetail.RULE_DETAIL_ID);
                    if (_ruleDetail != null)
                    {
                        _ruleDetail.UPDATED_DATE = DateTime.Now;
                        _ruleDetail.UPDATED_USER_ID = ruleDetail.UPDATED_USER_ID;

                        _ruleDetail.CONDITION = ruleDetail.CONDITION;
                        _ruleDetail.CRITERIA = ruleDetail.CRITERIA;
                        _ruleDetail.REQUIREMENT = ruleDetail.REQUIREMENT;
                        _ruleDetail.VALUE = ruleDetail.VALUE;
                    }
                    context.Entry(_ruleDetail).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool DeleteRuleDetail(int Id)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var rule = context.RULE_DETAIL.FirstOrDefault(q => q.RULE_DETAIL_ID == Id);
                    rule.IS_DELETED = true;
                    context.Entry(rule).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        List<RuleCriteriaData> IRule.GetRuleCriteriaData(int ruleCriteriaId)
        {
            throw new NotImplementedException();
        }
    }
}
