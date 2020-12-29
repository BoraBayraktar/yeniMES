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
    public class SlaEventFunctions : ISlaEvent
    {
        public List<SLA_EVENTS> GetList()
        {
            using (MesContext context = new MesContext())
            {
                var eventList = context.SLA_EVENTS.Include(q => q.CREATED_USER)
                                                                 .Where(q => q.IS_DELETED == false)
                                                                 .ToList();
                return eventList;
            }
        }
        public SLA_EVENTS GetSlaEvent(int id)
        {
            using (MesContext context = new MesContext())
            {
                var events = context.SLA_EVENTS.FirstOrDefault(q => q.ID == id);
                return events;
            }
        }
        public bool InsertSlaEvent(SLA_EVENTS events)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    events.CREATED_DATE = DateTime.Now;
                    context.SLA_EVENTS.Add(events);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
        public bool UpdateSlaEvent(SLA_EVENTS events)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var exp = context.SLA_EVENTS.FirstOrDefault(q => q.ID == events.ID);
                    if (exp != null)
                    {
                        exp.EVENT_ID = events.EVENT_ID;
                        exp.STATUS_ID = events.EVENT_ID;
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
        public bool DeleteSlaEvent(int Id)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var events = context.SLA_EVENTS.FirstOrDefault(q => q.ID == Id);
                    events.IS_DELETED = true;
                    context.Entry(events).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
        public List<SLA_EVENTS> GetSlaEventListByEventId(int slaId)
        {
            using (MesContext context = new MesContext())
            {
                var eventList = context.SLA_EVENTS.Include(q => q.CREATED_USER)
                                                  .Include(q => q.STATUS_MODEL)
                                                  .Where(q => q.SLA_ID == slaId)
                                                  .Where(q => q.IS_DELETED == false)
                                                  .ToList();
                return eventList;
            }
        }
    }
}
