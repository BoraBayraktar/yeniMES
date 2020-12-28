using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.API.Interfaces
{
    public interface ISlaArea
    {
        List<SLA_AREA> GetList();
        SLA_AREA GetSlaArea(int id);
        bool InsertSlaArea(SLA_AREA area);
        bool UpdateSlaArea(SLA_AREA area);
        bool DeleteSlaArea(int Id);
        List<SLA_AREA> GetSlaAreaListByAreaId(int slaId);
    }
}
