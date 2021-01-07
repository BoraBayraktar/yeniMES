using MES.Web.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Web.Interfaces
{
    public interface IGroup
    {
        List<GROUP> GetList();
        GROUP GetGroup(int id);
        List<USER> GetGroupManager();
        List<GROUP_TYPE> GetGroupType();
        List<USER> GetExpert();
        bool InsertGroup(GROUP group);
        bool UpdateGroup(GROUP group);
        bool DeleteGroup(int Id);
        List<USER> GetExpertListByExpId(int id);

        List<GROUP_EXPERT> GetExpertListByGrpId(int groupId);

    }
}
