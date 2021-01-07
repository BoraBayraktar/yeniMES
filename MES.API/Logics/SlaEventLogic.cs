using MES.Data.Functions;
using MES.Data.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Logics
{
    public class SlaEventLogic
    {
        ISlaEvent _slaEvent = new SlaEventFunctions();
        public List<SLA_EVENTS> GetList()
        {
            var slaEventList = _slaEvent.GetList();
            return slaEventList;
        }
        public bool InsertSlaEvent(SLA_EVENTS events)
        {
            var success = _slaEvent.InsertSlaEvent(events);
            return success;
        }
        public bool UpdateSlaEvent(SLA_EVENTS events)
        {
            var success = _slaEvent.UpdateSlaEvent(events);
            return success;
        }
        public bool DeleteSlaEvent(int Id)
        {
            var success = _slaEvent.DeleteSlaEvent(Id);
            return success;
        }
        public SLA_EVENTS GetSlaEvent(int id)
        {
            var events = _slaEvent.GetSlaEvent(id);
            return events;
        }
        public List<SLA_EVENTS> GetSlaEventListByEventId(int slaId)
        {
            var eventList = _slaEvent.GetSlaEventListByEventId(slaId);
            return eventList;
        }
    }
}
