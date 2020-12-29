using MES.Data.Functions;
using MES.Data.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Business
{
    public class ServiceCatalogLogic
    {
        IServiceCatalog _serviceCatalog = new ServiceCatalogFunctions();
        public List<SERVICECATALOG> GetList()
        {
            var servicecatalogList = _serviceCatalog.GetList();
            return servicecatalogList;
        }
        public List<PARAMETER> GetParameterList(string code)
        {
            var parameterList = _serviceCatalog.GetParameterList(code);
            return parameterList;
        }
        public List<PARAMETER> GetPrmOpStatus(string code)
        {
            var prmOpStatus = _serviceCatalog.GetPrmOpStatus(code);
            return prmOpStatus;
        }
        public List<USER> GetUserManagerIT()
        {
            var userManagerITList = _serviceCatalog.GetUserManagerIT();
            return userManagerITList;
        }
        public List<USER> GetUserManagerBusiness()
        {
            var userManagerBusinessList = _serviceCatalog.GetUserManagerBusiness();
            return userManagerBusinessList;
        }
        public bool InsertServiceCatalog(SERVICECATALOG servicecatalog)
        {
            var success = _serviceCatalog.InsertServiceCatalog(servicecatalog);
            return success;
        }
        public bool UpdateServiceCatalog(SERVICECATALOG servicecatalog)
        {
            var success = _serviceCatalog.UpdateServiceCatalog(servicecatalog);
            return success;
        }
        public bool DeleteServiceCatalog(int Id)
        {
            var success = _serviceCatalog.DeleteServiceCatalog(Id);
            return success;
        }
        public SERVICECATALOG GetServiceCatalog(int id)
        {
            var serviceCatalog = _serviceCatalog.GetServiceCatalog(id);
            return serviceCatalog;
        }        
    }
}
