using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.API.Interfaces
{
    public interface IServiceCatalog
    {
        List<SERVICECATALOG> GetList();
        List<PARAMETER> GetParameterList(string code);
        List<PARAMETER> GetPrmOpStatus(string code);
        List<USER> GetUserManagerIT();
        List<USER> GetUserManagerBusiness();
        SERVICECATALOG GetServiceCatalog(int id);
        bool InsertServiceCatalog(SERVICECATALOG servicecatalog);
        bool UpdateServiceCatalog(SERVICECATALOG servicecatalog);
        bool DeleteServiceCatalog(int Id);
    }
}
