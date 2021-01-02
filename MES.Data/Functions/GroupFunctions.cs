using MES.Data.Interfaces;
using MES.DB;
using MES.DB.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MES.Data.Functions
{
    public class GroupFunctions : IGroup
    {
        public List<GROUP> GetList()
        {
            using (MesContext context = new MesContext())
            {
                var groupList = context.GROUP
                                             .Include(q => q.GROUP_USERMANAGERMODEL)
                                             .Include(q => q.GROUP_GROUPTYPEMODEL)
                                             .Where(q => q.IS_DELETED == false)
                                             .ToList();
                return groupList;
            }
        }
        public GROUP GetGroup(int id)
        {
            using (MesContext context = new MesContext())
            {
                var group = context.GROUP.FirstOrDefault(q => q.ID == id);
                return group;
            }
        }
        public List<USER> GetGroupManager()
        {
            using (MesContext context = new MesContext())
            {
                var groupManager = context.USER.Where(q => q.IS_DELETED == false)
                                               .ToList();
                return groupManager;
            }
        }
        public List<GROUP_TYPE> GetGroupType()
        {
            using (MesContext context = new MesContext())
            {
                var groupType = context.GROUP_TYPE.Where(q => q.IS_DELETED == false)
                                                  .ToList();
                return groupType;
            }
        }
        public List<USER> GetExpert()
        {
            using (MesContext context = new MesContext())
            {
                var groupExpert = context.USER.Where(q => q.IS_DELETED == false)
                                              .ToList();
                return groupExpert;
            }
        }
        public bool InsertGroup(GROUP group)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    context.GROUP.Add(group);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
        public bool UpdateGroup(GROUP group)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var h = context.GROUP.FirstOrDefault(q => q.ID == group.ID);
                    if (h != null)
                    {
                        h.GROUP_NAME = group.GROUP_NAME;
                        h.GROUP_MANAGER_ID = group.GROUP_MANAGER_ID;
                        h.GROUP_ASSIGNTYPE_ID = group.GROUP_ASSIGNTYPE_ID;
                        h.GROUP_TYPE_ID = group.GROUP_TYPE_ID;
                        h.GROUP_ISACTIVE = group.GROUP_ISACTIVE;
                        h.GROUP_DESCRIPTION = group.GROUP_DESCRIPTION;
                        h.BUSINESS_HOURS = group.BUSINESS_HOURS;
                    }
                    context.Entry(h).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
        public bool DeleteGroup(int Id)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var group = context.GROUP.FirstOrDefault(q => q.ID == Id);
                    group.IS_DELETED = true;
                    context.Entry(group).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
        public bool InsertOrUpdateGroup(GROUP group)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var h = context.GROUP.FirstOrDefault();
                    if (h == null)
                    {
                        group.CREATED_DATE = DateTime.Now;
                        InsertGroup(group);
                    }
                    else
                    {
                        group.ID = h.ID;
                        group.UPDATED_DATE = DateTime.Now;
                        group.GROUP_MANAGER_ID = h.GROUP_MANAGER_ID;
                        group.GROUP_ASSIGNTYPE_ID = h.GROUP_ASSIGNTYPE_ID;
                        group.GROUP_TYPE_ID = h.GROUP_TYPE_ID;
                        group.GROUP_ISACTIVE = h.GROUP_ISACTIVE;
                        group.GROUP_DESCRIPTION = h.GROUP_DESCRIPTION;
                        group.BUSINESS_HOURS = h.BUSINESS_HOURS;

                        UpdateGroup(group);
                    }
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
                var expertList = context.GROUP_EXPERT
                                                                 .Where(q => q.GROUP_ID == groupId)
                                                                 .ToList();
                return expertList;
            }
        }
        public List<USER> GetExpertListByExpId(int id)
        {
            using (MesContext context = new MesContext())
            {
                var expertList = context.USER.Include(q => q.USER_ID == id).ToList();
                return expertList;
            }
        }

    }
}
