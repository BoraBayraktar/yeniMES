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
    public class IncidentResolutionFunctions : IIncidentResolution
    {
        public List<INCIDENT_RESOLUTION> GetList()
        {
            using (MesContext context = new MesContext())
            {
                var resolutionList = context.INCIDENT_RESOLUTION.Include(q => q.CREATED_USER)
                                                           .Where(q => q.IS_DELETED == false)
                                                           .ToList();
                return resolutionList;
            }
        }

        public List<INCIDENT_RESOLUTION> GetListByIncidentId(int incidentId)
        {
            using (MesContext context = new MesContext())
            {
                var resolutionList = context.INCIDENT_RESOLUTION.Include(q => q.CREATED_USER)
                                                           .Where(q => q.IS_DELETED == false && q.INCIDENT_ID == incidentId)
                                                           .ToList();
                return resolutionList;
            }
        }


        public INCIDENT_RESOLUTION GetResolutionByIncidentId(int incidentId)
        {
            using (MesContext context = new MesContext())
            {
                var resolution = context.INCIDENT_RESOLUTION.Include(q => q.CREATED_USER)
                                                            .FirstOrDefault(q => q.IS_DELETED == false && q.INCIDENT_ID == incidentId);
                return resolution;
            }
        }

        public bool InsertIncidentResolution(INCIDENT_RESOLUTION incidentResolution)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    incidentResolution.CREATED_DATE = DateTime.Now;
                    context.INCIDENT_RESOLUTION.Add(incidentResolution);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool UpdateIncidentResolution(INCIDENT_RESOLUTION incidentResolution)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var resolution = context.INCIDENT_RESOLUTION.FirstOrDefault(q => q.ID == incidentResolution.ID);
                    if (resolution != null)
                    {
                        resolution.IS_APPROVED = incidentResolution.IS_APPROVED;
                        resolution.RESOLVED_CODE = incidentResolution.RESOLVED_CODE;
                        resolution.RESOLVED_DATE = incidentResolution.RESOLVED_DATE;
                        resolution.RESOLVED_DESCRIPTION = incidentResolution.RESOLVED_DESCRIPTION;
                        resolution.UPDATED_USER_ID = incidentResolution.UPDATED_USER_ID;
                        resolution.UPDATED_DATE = DateTime.Now;
                    }
                    context.Entry(resolution).State = EntityState.Modified;
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
