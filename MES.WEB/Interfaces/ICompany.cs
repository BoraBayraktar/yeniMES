using MES.Web.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Web.Interfaces
{
    public interface ICompany
    {
        List<COMPANY> GetList();
        COMPANY GetCompany(int id);
        bool InsertCompany(COMPANY company);
        bool InsertCompany(List<COMPANY> company);
        bool UpdateCompany(COMPANY company);
        bool DeleteCompany(int Id);
    }
}
