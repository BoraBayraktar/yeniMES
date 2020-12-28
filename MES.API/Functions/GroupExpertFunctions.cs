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
    public class GrupExpertFunctions : IGroupExpert
    {
        public List<GROUP_EXPERT> GetList()
        {
            using (MesContext context = new MesContext())
            {
                var expertList = context.GROUP_EXPERT.Include(q => q.CREATED_USER)
                                                                 .Where(q => q.IS_DELETED == false)
                                                                 .ToList();
                return expertList;
            }
        }

        public GROUP_EXPERT GetExpert(int id)
        {
            using (MesContext context = new MesContext())
            {
                var expert = context.GROUP_EXPERT.FirstOrDefault(q => q.ID == id);
                return expert;
            }
        }

        public bool InsertExpert(GROUP_EXPERT expert)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    expert.CREATED_DATE = DateTime.Now;
                    context.GROUP_EXPERT.Add(expert);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool UpdateExpert(GROUP_EXPERT expert)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var exp = context.GROUP_EXPERT.FirstOrDefault(q => q.ID == expert.ID);
                    if (exp != null)
                    {
                        exp.EXPERT_NAME = expert.EXPERT_NAME;
                        exp.EXPERT_EMAIL = expert.EXPERT_EMAIL;
                        exp.UPDATED_DATE = DateTime.Now;
                    }
                    context.Entry(exp).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool DeleteExpert(int Id)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var expert = context.GROUP_EXPERT.FirstOrDefault(q => q.ID == Id);
                    expert.IS_DELETED = true;
                    context.Entry(expert).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public List<GROUP_EXPERT> GetExpertListByGrpId(int groupId)
        {
            using (MesContext context = new MesContext())
            {
                var expertList = context.GROUP_EXPERT.Include(q => q.CREATED_USER)
                                                                 .Where(q => q.GROUP_ID == groupId)
                                                                 .Where(q => q.IS_DELETED == false)
                                                                 .ToList();
                return expertList;
            }
        }
    }
}
