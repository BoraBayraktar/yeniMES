using MES.Data.Interfaces;
using MES.DB;
using MES.DB.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MES.Data.Functions
{
    public class SlaFunctions : ISla
    {
        public List<SLA> GetList()
        {
            using (MesContext context = new MesContext())
            {
                    var slaList = context.SLA.Include(q => q.CREATED_USER)
                                                                         .Include(q => q.MAIN_PROCESS_MODEL)
                                                                         .Include(q => q.IMPORTANCE_LEVEL_MODEL)
                                                                         .Include(q => q.WORKING_SCHEDULE_MODEL)
                                                                         //.Include(q => q.STARTED_STATUS_MODEL)
                                                                         //.Include(q => q.STOPED_STATUS_MODEL)
                                                                         //.Include(q => q.FINISHED_STATUS_MODEL)
                                                                         .Where(q => q.IS_DELETED == false)
                                                                         .ToList();
                    return slaList;
            }
        }
        public SLA GetSla(int id)
        {
            using (MesContext context = new MesContext())
            {
                var sla = context.SLA.FirstOrDefault(q => q.ID == id);
                return sla;
            }
        }
        public List<MAIN_PROCESS> GetMainProcess()
        {
            using (MesContext context = new MesContext())
            {
                var mp = context.MAIN_PROCESS.ToList();
                return mp;
            }
        }
        public List<PARAMETER> GetImportanceLevel(string code)
        {
            using (MesContext context = new MesContext())
            {
                var kc = context.PARAMETER.Where(q=> q.PARAMETER_TYPE.CODE==code).ToList();
                return kc;
            }
        }
        public List<WORKING_SCHEDULE> GetWorkingSchedule()
        {
            using (MesContext context = new MesContext())
            {
                var kc = context.WORKING_SCHEDULE.ToList();
                return kc;
            }
        }
        //public List<PARAMETER> GetSlaStartedStatus(string code)
        //{
        //    using (MesContext context = new MesContext())
        //    {
        //        var kc = context.PARAMETER.Where(q => q.PARAMETER_TYPE.CODE == code).ToList();
        //        return kc;
        //    }
        //}
        //public List<PARAMETER> GetSlaStopedStatus(string code)
        //{
        //    using (MesContext context = new MesContext())
        //    {
        //        var kc = context.PARAMETER.Where(q => q.PARAMETER_TYPE.CODE == code).ToList();
        //        return kc;
        //    }
        //}
        public List<PARAMETER> GetPrmStatus(string code)
        {
            using (MesContext context = new MesContext())
            {
                var kc = context.PARAMETER.Where(q => q.PARAMETER_TYPE.CODE == code)
                                          .OrderBy(q => q.PRIORITY_ORDER).ToList();
                return kc;
            }
        }
        public bool InsertSla(SLA sla)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    context.SLA.Add(sla);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
        public bool UpdateSla(SLA sla)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var h = context.SLA.FirstOrDefault(q => q.ID == sla.ID);
                    if (h != null)
                    {
                        h.NAME = sla.NAME;
                        h.TYPE = sla.TYPE;
                        h.MAIN_PROCESS_ID = sla.MAIN_PROCESS_ID;
                        h.IMPORTANCE_LEVEL_ID = sla.IMPORTANCE_LEVEL_ID;
                        h.WORKING_SCHEDULE_ID = sla.WORKING_SCHEDULE_ID;
                        h.EFFORT_MINUTE = sla.EFFORT_MINUTE;
                        h.EFFORT_HOUR = sla.EFFORT_HOUR;
                        h.EFFORT_DAY = sla.EFFORT_DAY;
                        //h.STARTED_STATUS_ID = sla.STARTED_STATUS_ID;
                        //h.STOPED_STATUS_ID = sla.STOPED_STATUS_ID;
                        //h.FINISHED_STATUS_ID = sla.FINISHED_STATUS_ID;
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
        public bool DeleteSla(int Id)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var k = context.SLA.FirstOrDefault(q => q.ID == Id);
                    k.IS_DELETED = true;
                    context.Entry(k).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }       
    }
}
