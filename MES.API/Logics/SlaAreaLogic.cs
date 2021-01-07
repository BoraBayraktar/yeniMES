using MES.Data.Functions;
using MES.Data.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Logics
{
    public class SlaAreaLogic
    {
        ISlaArea _slaArea = new SlaAreaFunctions();
        public List<SLA_AREA> GetList()
        {
            var slaAreaList = _slaArea.GetList();
            return slaAreaList;
        }
        public bool InsertSlaArea(SLA_AREA area)
        {
            var success = _slaArea.InsertSlaArea(area);
            return success;
        }
        public bool UpdateSlaArea(SLA_AREA area)
        {
            var success = _slaArea.UpdateSlaArea(area);
            return success;
        }
        public bool DeleteSlaArea(int Id)
        {
            var success = _slaArea.DeleteSlaArea(Id);
            return success;
        }
        public SLA_AREA GetSlaArea(int id)
        {
            var events = _slaArea.GetSlaArea(id);
            return events;
        }
        public List<SLA_AREA> GetSlaAreaListByAreaId(int slaId)
        {
            var eventList = _slaArea.GetSlaAreaListByAreaId(slaId);
            return eventList;
        }
    }
}
