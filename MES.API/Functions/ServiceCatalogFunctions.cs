using MES.API.Interfaces;
using MES.DB;
using MES.DB.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MES.API.Functions
{
    public class ServiceCatalogFunctions : IServiceCatalog
    {
        public List<SERVICECATALOG> GetList()
        {
            using (MesContext context = new MesContext())
            {
                var serviceCatalogList = context.SERVICECATALOG.Include(q => q.CREATED_USER)
                                                               .Include(q => q.PARAMETERMODEL)
                                                               .Include(q => q.PARAMETER_OPSTATUSMODEL)
                                                               .Include(q => q.USER_MANAGERBUSINESSMODEL)
                                                               .Include(q => q.USER_MANAGERITMODEL)
                                                               .Where(q => q.IS_DELETED == false)
                                                               .ToList();
                return serviceCatalogList;
            }
        }
        public List<PARAMETER> GetParameterList(string code)
        {
            using (MesContext context = new MesContext())
            {
                var parameterList = context.PARAMETER.Where(q => q.PARAMETER_TYPE.CODE == code)
                                                     .Where(q => q.IS_DELETED == false)
                                                     .Where(q => q.IS_ACTIVE == true)
                                                     .ToList();
                return parameterList;
            }
        }
        public List<PARAMETER> GetPrmOpStatus(string code)
        {
            using (MesContext context = new MesContext())
            {
                var prmOpStatus = context.PARAMETER.Where(q => q.PARAMETER_TYPE.CODE == code)
                                                   .Where(q => q.IS_DELETED == false)
                                                   .Where(q => q.IS_ACTIVE == true)
                                                   .ToList();
                return prmOpStatus;
            }
        }
        public List<USER> GetUserManagerIT()
        {
            using (MesContext context = new MesContext())
            {
                var userIT = context.USER.Where(q => q.IS_DELETED == false)
                                         .ToList();
                return userIT;
            }
        }
        public List<USER> GetUserManagerBusiness()
        {
            using (MesContext context = new MesContext())
            {
                var userBusiness = context.USER.Where(q => q.IS_DELETED == false)
                                          .ToList();
                return userBusiness;
            }
        }
        public SERVICECATALOG GetServiceCatalog(int id)
        {
            using (MesContext context = new MesContext())
            {
                var servicecatalog = context.SERVICECATALOG.FirstOrDefault(q => q.SERVICE_ID == id);
                return servicecatalog;
            }
        }
        public bool InsertServiceCatalog(SERVICECATALOG servicecatalog)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    context.SERVICECATALOG.Add(servicecatalog);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
        public bool UpdateServiceCatalog(SERVICECATALOG servicecatalog)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var h = context.SERVICECATALOG.FirstOrDefault(qm => qm.SERVICE_ID == servicecatalog.SERVICE_ID);
                    if (h != null)
                    {
                        h.SERVICE_NAME = servicecatalog.SERVICE_NAME;
                        h.DESCRIPTION = servicecatalog.DESCRIPTION;
                        h.SERVICE_PARAMETER_ID = servicecatalog.SERVICE_PARAMETER_ID;
                        h.SERVICE_LEVEL = servicecatalog.SERVICE_LEVEL;
                        h.OPERATIONAL_STATUS_ID = servicecatalog.OPERATIONAL_STATUS_ID;
                        h.SERVICE_MANAGER_IT_ID = servicecatalog.SERVICE_MANAGER_IT_ID;
                        h.SERVICE_MANAGER_BUSINESS_ID = servicecatalog.SERVICE_MANAGER_BUSINESS_ID;
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

        public bool DeleteServiceCatalog(int Id)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var servicecatalog = context.SERVICECATALOG.FirstOrDefault(q => q.SERVICE_ID == Id);
                    servicecatalog.IS_DELETED = true;
                    context.Entry(servicecatalog).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
        //public bool DeleteServiceCatalog(int Id)
        //{
        //    bool returnVal = false;
        //    try
        //    {
        //        using (MesContext context = new MesContext())
        //        {
        //            var servicecatalog = context.SERVICECATALOG.FirstOrDefault(q => q.SERVICE_ID == Id);
        //            context.SERVICECATALOG.Remove(servicecatalog);
        //            context.SaveChanges();
        //            returnVal = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return returnVal;
        //}
        public bool InsertOrUpdateServiceCatalog(SERVICECATALOG servicecatalog)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var h = context.SERVICECATALOG.FirstOrDefault();
                    if (h == null)
                    {
                        servicecatalog.CREATED_DATE = DateTime.Now;
                        InsertServiceCatalog(servicecatalog);
                    }
                    else
                    {
                        servicecatalog.SERVICE_ID = h.SERVICE_ID;
                        servicecatalog.UPDATED_DATE = DateTime.Now;
                        servicecatalog.SERVICE_PARAMETER_ID = h.SERVICE_PARAMETER_ID;
                        servicecatalog.SERVICE_LEVEL = h.SERVICE_LEVEL;
                        servicecatalog.OPERATIONAL_STATUS_ID = h.OPERATIONAL_STATUS_ID;
                        servicecatalog.SERVICE_MANAGER_IT_ID = h.SERVICE_MANAGER_IT_ID;
                        servicecatalog.SERVICE_MANAGER_BUSINESS_ID = h.SERVICE_MANAGER_BUSINESS_ID;
                        UpdateServiceCatalog(servicecatalog);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

    }
}
