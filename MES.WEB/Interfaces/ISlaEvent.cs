using MES.Web.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Web.Interfaces
{
    public interface ISlaEvent
    {
        List<SLA_EVENTS> GetList();
        SLA_EVENTS GetSlaEvent(int id);
        bool InsertSlaEvent(SLA_EVENTS events);
        bool UpdateSlaEvent(SLA_EVENTS events);
        bool DeleteSlaEvent(int Id);
        List<SLA_EVENTS> GetSlaEventListByEventId(int slaId);
    }
}
