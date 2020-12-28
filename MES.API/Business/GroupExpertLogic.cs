using MES.API.Functions;
using MES.API.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.API.Business
{
    public class GroupExpertLogic
    {
        IGroupExpert _expert = new GrupExpertFunctions();
        public List<GROUP_EXPERT> GetList()
        {
            var expertList = _expert.GetList();
            return expertList;
        }
        public bool InsertExpert(GROUP_EXPERT expert)
        {
            var success = _expert.InsertExpert(expert);
            return success;
        }
        public bool UpdateExpert(GROUP_EXPERT expert)
        {
            var success = _expert.UpdateExpert(expert);
            return success;
        }
        public bool DeleteExpert(int Id)
        {
            var success = _expert.DeleteExpert(Id);
            return success;
        }
        public GROUP_EXPERT GetExpert(int id)
        {
            var expert = _expert.GetExpert(id);
            return expert;
        }
        public List<GROUP_EXPERT> GetExpertListByGrpId(int groupId)
        {
            var expertList = _expert.GetExpertListByGrpId(groupId);
            return expertList;
        }
    }
}
