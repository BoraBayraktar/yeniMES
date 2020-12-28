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
    public class HoldingFunctions : IHolding
    {
        public List<HOLDING> GetList()
        {
            using (MesContext context = new MesContext())
            {
                var holdingList = context.HOLDING.Where(q => q.IS_DELETED == false).ToList();
                return holdingList;
            }
        }

        public HOLDING GetHolding(int id)
        {
            using (MesContext context = new MesContext())
            {
                var holding = context.HOLDING.FirstOrDefault(q => q.HOLDING_ID == id);
                return holding;
            }
        }

        public bool InsertHolding(HOLDING holding)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    holding.CREATED_DATE = DateTime.Now;
                    context.HOLDING.Add(holding);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }  
        public bool InsertHolding(List<HOLDING> holding)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    holding.ForEach(x => x.CREATED_DATE = DateTime.Now); 
                    context.HOLDING.AddRange(holding);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
            return returnVal;
        }

        public bool UpdateHolding(HOLDING holding)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var h = context.HOLDING.FirstOrDefault(q => q.HOLDING_ID == holding.HOLDING_ID);
                    if (h != null)
                    {
                        h.CODE = holding.CODE;
                        h.NAME = holding.NAME;
                        h.DESCRIPTION = holding.DESCRIPTION;
                        h.UPDATED_DATE = DateTime.Now;
                        h.UPDATED_USER_ID = holding.UPDATED_USER_ID;
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


        public bool DeleteHolding(int Id)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var holding = context.HOLDING.FirstOrDefault(q => q.HOLDING_ID == Id);
                    holding.IS_DELETED = true;
                    context.Entry(holding).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
        //public bool DeleteHolding(int Id)
        //{
        //    bool returnVal = false;
        //    try
        //    {
        //        using (MesContext context = new MesContext())
        //        {
        //            var holding = context.HOLDING.FirstOrDefault(q => q.HOLDING_ID == Id);
        //            context.HOLDING.Remove(holding);
        //            context.SaveChanges();
        //            returnVal = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return returnVal;
        //}
    }
}
