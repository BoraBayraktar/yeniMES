using MES.Data.Functions;
using MES.Data.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Business
{
    public class GroupLogic
    {
        IGroup _group = new GroupFunctions();
        public List<GROUP> GetList()
        {
            var group = _group.GetList();
            return group;
        }
        public List<USER> GetGroupManager()
        {
            var groupManagerList = _group.GetGroupManager();
            return groupManagerList;
        }
        public List<GROUP_TYPE> GetGroupType()
        {
            var groupTypeList = _group.GetGroupType();
            return groupTypeList;
        }
        public List<USER> GetExpert()
        {
            var expert = _group.GetExpert();
            return expert;
        }
        public bool InsertGroup(GROUP group)
        {
            var success = _group.InsertGroup(group);
            return success;
        }
        public bool UpdateGroup(GROUP group)
        {
            var success = _group.UpdateGroup(group);
            return success;
        }
        public bool DeleteGroup(int Id)
        {
            var success = _group.DeleteGroup(Id);
            return success;
        }
        public GROUP GetGroup(int id)
        {
            var group = _group.GetGroup(id);
            return group;
        }
        public List<USER> GetExpertListByExpId(int id)
        {
            var expertList = _group.GetExpertListByExpId(id);
            return expertList;
        }

        public List<GROUP_EXPERT> GetExpertListByGrpId(int groupId)
        {
            var groupExpertList = _group.GetExpertListByGrpId(groupId);
            return groupExpertList;
        }
    }
}
