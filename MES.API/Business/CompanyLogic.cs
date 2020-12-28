using MES.API.Functions;
using MES.API.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.API.Business
{
    public class CompanyLogic
    {
        ICompany _company = new CompanyFunctions();
        public List<COMPANY> GetList()
        {
            var companyList = _company.GetList();
            return companyList;
        }
        public bool InsertCompany(COMPANY company)
        {
            var success = _company.InsertCompany(company);
            return success;
        }
        public bool InsertCompany(List<COMPANY> company)
        {
            var success = _company.InsertCompany(company);
            return success;
        }
        public bool UpdateCompany(COMPANY company)
        {
            var success = _company.UpdateCompany(company);
            return success;
        }
        public bool DeleteCompany(int Id)
        {
            var success = _company.DeleteCompany(Id);
            return success;
        }
        public COMPANY GetCompany(int id)
        {
            var company = _company.GetCompany(id);
            return company;
        }
    }
}
