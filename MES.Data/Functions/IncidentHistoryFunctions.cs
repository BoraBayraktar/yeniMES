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
    public class IncidentHistoryFunctions : IIncidentHistory
    {
        public List<INCIDENT_HISTORY> GetList()
        {
            using (MesContext context = new MesContext())
            {
                //var incidentHistoryList = context.INCIDENT_HISTORY.Where(q => q.IS_DELETED == false).Include(q => q.CREATED_USER).ToList();
                //return incidentHistoryList;

                return new List<INCIDENT_HISTORY>();
            }
        }
        public INCIDENT_HISTORY GetIncidentHistory(int id)
        {
            using (MesContext context = new MesContext())
            {
                //var incidentHistory = context.INCIDENT_HISTORY.FirstOrDefault(q => q.ID == id);
                //return incidentHistory;

                return new INCIDENT_HISTORY();
            }
        }

        public bool InsertIncidentHistory(INCIDENT_HISTORY incidentHistory)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    incidentHistory.CREATED_DATE = DateTime.Now;

                    context.INCIDENT_HISTORY.Add(incidentHistory);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool UpdateIncidentHistory(INCIDENT_HISTORY incidentHistory)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    //var _incidentHistory = context.INCIDENT_HISTORY.FirstOrDefault(q => q.ID == incidentHistory.ID);
                    //if (_incidentHistory != null)
                    //{
                    //    _incidentHistory.DESCRIPTION = incidentHistory.DESCRIPTION;
                    //    _incidentHistory.INCIDENT_ID = incidentHistory.INCIDENT_ID;
                    //    _incidentHistory.INCIDENT_PRIORITY_ID = incidentHistory.INCIDENT_PRIORITY_ID;
                    //    _incidentHistory.INCIDENT_STATUS_ID = incidentHistory.INCIDENT_STATUS_ID;
                    //    _incidentHistory.INCIDENT_TYPE_ID = incidentHistory.INCIDENT_TYPE_ID;
                    //    _incidentHistory.CREATED_USER_ID = incidentHistory.CREATED_USER_ID;

                    //    _incidentHistory.UPDATED_DATE = DateTime.Now;
                    //    _incidentHistory.UPDATED_USER_ID = incidentHistory.UPDATED_USER_ID;
                    //}
                    //context.Entry(_incidentHistory).State = EntityState.Modified;
                    //context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }


        public bool DeleteIncidentHistory(int Id)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    //var incidentHistory = context.INCIDENT_HISTORY.FirstOrDefault(q => q.ID == Id);
                    //incidentHistory.IS_DELETED = true;
                    //context.Entry(incidentHistory).State = EntityState.Modified;
                    //context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }


        public List<INCIDENT_HISTORY> GetListByIncidentId(int incidentId)
        {
            using (MesContext context = new MesContext())
            {
                var incidentHistoryList = context.INCIDENT_HISTORY.Where(q => q.IS_DELETED == false && q.INCIDENT_ID == incidentId)
                                                                  .Include(q => q.CREATED_USER)
                                                                  .Include(q => q.INCIDENT_STATUS)
                                                                  .Include(q => q.ASSIGNED_GROUP)
                                                                  .Include(q => q.ASSIGNED_USER)
                                                                  .ToList();
                return incidentHistoryList;
            }
        }

        public List<INCIDENT_HISTORY> GetHistoryListByIncidentIdVisibleToUser(int incidentId)
        {
            using (MesContext context = new MesContext())
            {
                var incidentHistoryList = context.INCIDENT_HISTORY.Where(q => q.IS_DELETED == false && q.INCIDENT_ID == incidentId && q.VISIBLE_TO_USER == true)
                                                                  .Include(q => q.CREATED_USER)
                                                                  .Include(q => q.INCIDENT_STATUS)
                                                                  .Include(q => q.ASSIGNED_GROUP)
                                                                  .Include(q => q.ASSIGNED_USER)
                                                                  .ToList();
                return incidentHistoryList;
            }
        }
    }
}
