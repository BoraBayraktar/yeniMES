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
    public class SlaAreaFunctions : ISlaArea
    {
        public List<SLA_AREA> GetList()
        {
            using (MesContext context = new MesContext())
            {
                var areaList = context.SLA_AREA.Include(q => q.CREATED_USER)
                                                                 .Where(q => q.IS_DELETED == false)
                                                                 .ToList();
                return areaList;
            }
        }
        public SLA_AREA GetSlaArea(int id)
        {
            using (MesContext context = new MesContext())
            {
                var area = context.SLA_AREA.FirstOrDefault(q => q.ID == id);
                return area;
            }
        }
        public bool InsertSlaArea(SLA_AREA area)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    area.CREATED_DATE = DateTime.Now;
                    context.SLA_AREA.Add(area);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
        public bool UpdateSlaArea(SLA_AREA area)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var exp = context.SLA_AREA.FirstOrDefault(q => q.ID == area.ID);
                    if (exp != null)
                    {
                        exp.SLA_AREA_TYPE_ID = area.SLA_AREA_TYPE_ID;
                        exp.CUSTOMER_ID = area.CUSTOMER_ID;
                        exp.SERVICE_ID = area.SERVICE_ID;
                        exp.ASSET_ID = area.SERVICE_ID;
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
        public bool DeleteSlaArea(int Id)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var area = context.SLA_AREA.FirstOrDefault(q => q.ID == Id);
                    area.IS_DELETED = true;
                    context.Entry(area).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
        public List<SLA_AREA> GetSlaAreaListByAreaId(int slaId)
        {
            using (MesContext context = new MesContext())
            {
                var areaList = context.SLA_AREA.Include(q => q.CREATED_USER)
                                                  .Where(q => q.SLA_ID == slaId)
                                                  .Where(q => q.IS_DELETED == false)
                                                  .ToList();
                return areaList;
            }
        }
    }
}
