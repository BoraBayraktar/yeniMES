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
    public class TitleFunctions : ITitle
    {
        public List<TITLE> GetList()
        {
            using (MesContext context = new MesContext())
            {
                var titleList = context.TITLE.Include(q => q.CREATED_USER).Where(q => q.IS_DELETED == false).ToList();
                return titleList;
            }
        }

        public TITLE GetTitle(int id)
        {
            using (MesContext context = new MesContext())
            {
                var title = context.TITLE.FirstOrDefault(q => q.TITLE_ID == id);
                return title;
            }
        }

        public bool InsertTitle(TITLE title)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    title.CREATED_DATE = DateTime.Now;
                    context.TITLE.Add(title);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
        public bool InsertTitle(List<TITLE> title)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    title.ForEach(x=>x.CREATED_DATE = DateTime.Now);
                    context.TITLE.AddRange(title);
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

        public bool UpdateTitle(TITLE title)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var tt = context.TITLE.FirstOrDefault(q => q.TITLE_ID == title.TITLE_ID);
                    if (tt != null)
                    {
                        tt.CODE = title.CODE;
                        tt.NAME = title.NAME;
                        tt.DESCRIPTION = title.DESCRIPTION;
                        tt.UPDATED_DATE = DateTime.Now;
                        tt.UPDATED_USER_ID = title.UPDATED_USER_ID;
                    }
                    context.Entry(tt).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool DeleteTitle(int Id)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var title = context.TITLE.FirstOrDefault(q => q.TITLE_ID == Id);
                    title.IS_DELETED = true;
                    context.Entry(title).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        //public bool DeleteTitle(int Id)
        //{
        //    bool returnVal = false;
        //    try
        //    {
        //        using (MesContext context = new MesContext())
        //        {
        //            var title = context.TITLE.FirstOrDefault(q => q.TITLE_ID == Id);
        //            context.TITLE.Remove(title);
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
