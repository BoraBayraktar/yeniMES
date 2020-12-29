using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Interfaces
{
    public interface IGroupExpert
    {
        List<GROUP_EXPERT> GetList();
        GROUP_EXPERT GetExpert(int id);
        bool InsertExpert(GROUP_EXPERT expert);
        bool UpdateExpert(GROUP_EXPERT expert);
        bool DeleteExpert(int Id);
        List<GROUP_EXPERT> GetExpertListByGrpId(int groupId);
    }
}
