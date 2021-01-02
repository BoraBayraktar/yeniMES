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
    public class LocationFunctions : ILocation
    {
        public List<LOCATION> GetList()
        {
            using (MesContext context = new MesContext())
            {
                var locationList = context.LOCATION
                                                   .Include(q => q.CITY)
                                                   .Where(q => q.IS_DELETED == false)
                                                   .ToList();
                return locationList;
            }
        }

        public LOCATION GetLocation(int id)
        {
            using (MesContext context = new MesContext())
            {
                var location = context.LOCATION.FirstOrDefault(q => q.LOCATION_ID == id);
                return location;
            }
        }

        public bool InsertLocation(LOCATION location)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    location.CREATED_DATE = DateTime.Now;
                    context.LOCATION.Add(location);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
        public bool InsertLocation(List<LOCATION> location)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    location.ForEach(x=>x.CREATED_DATE = DateTime.Now);
                    context.LOCATION.AddRange(location);
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

        public bool UpdateLocation(LOCATION location)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var loc = context.LOCATION.FirstOrDefault(q => q.LOCATION_ID == location.LOCATION_ID);
                    if (loc != null)
                    {
                        loc.CODE = location.CODE;
                        loc.NAME = location.NAME;
                        loc.CITY_ID = location.CITY_ID;

                        loc.UPDATED_DATE = DateTime.Now;
                    }
                    context.Entry(loc).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool DeleteLocation(int Id)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var location = context.LOCATION.FirstOrDefault(q => q.LOCATION_ID == Id);
                    location.IS_DELETED = true;
                    context.Entry(location).State = EntityState.Modified;
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
