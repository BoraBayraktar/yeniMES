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
    public class CompanyFunctions : ICompany
    {
        public List<COMPANY> GetList()
        {
            using (MesContext context = new MesContext())
            {
                var companyList = context.COMPANY.Include(q => q.CREATED_USER)
                                                 .Include(q => q.HOLDING)
                                                 .Where(q => q.IS_DELETED == false)
                                                 .ToList();
                return companyList;
            }
        }

        public COMPANY GetCompany(int id)
        {
            using (MesContext context = new MesContext())
            {
                var company = context.COMPANY.FirstOrDefault(q => q.COMPANY_ID == id);
                return company;
            }
        }

        public bool InsertCompany(COMPANY company)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    company.CREATED_DATE = DateTime.Now;
                    context.COMPANY.Add(company);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }    
        public bool InsertCompany(List<COMPANY> company)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    company.ForEach(x=>x.CREATED_DATE = DateTime.Now);
                    context.COMPANY.AddRange(company);
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

        public bool UpdateCompany(COMPANY company)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var cmp = context.COMPANY.FirstOrDefault(q => q.COMPANY_ID == company.COMPANY_ID);
                    if (cmp != null)
                    {
                        cmp.CODE = company.CODE;
                        cmp.NAME = company.NAME;
                        cmp.DESCRIPTION = company.DESCRIPTION;
                        cmp.HOLDING_ID = company.HOLDING_ID;

                        cmp.UPDATED_DATE = DateTime.Now;
                        cmp.UPDATED_USER_ID = company.UPDATED_USER_ID;
                    }
                    context.Entry(cmp).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }


        public bool DeleteCompany(int Id)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var company = context.COMPANY.FirstOrDefault(q => q.COMPANY_ID == Id);
                    company.IS_DELETED = true;
                    context.Entry(company).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        //public bool DeleteCompany(int Id)
        //{
        //    bool returnVal = false;
        //    try
        //    {
        //        using (MesContext context = new MesContext())
        //        {
        //            var company = context.COMPANY.FirstOrDefault(q => q.COMPANY_ID == Id);
        //            context.COMPANY.Remove(company);
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
