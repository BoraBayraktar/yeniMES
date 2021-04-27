using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MES.Web.Model;
using MES.Web.Models;
using MES.Web.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace MES.Web.Controllers
{
    public class ServiceCatalogController : BaseController
    {
        ServiceBusiness serviceBusiness;
        public ServiceCatalogController(IHttpContextAccessor accessor, IConfiguration configuration)
        {
            serviceBusiness = new ServiceBusiness(configuration, accessor);
        }
        public IActionResult ServiceCatalogList()
        {
            var serviceList = serviceBusiness.ServiceGet<List<SERVICECATALOG>>("ServiceCatalog", "ServiceCatalogGetList");
            ServiceCatalogViewModel scvm = new ServiceCatalogViewModel();
            //foreach (var item in serviceList)
            //{
            //    item.CREATED_USER = serviceBusiness.ServicePost<USER>(item.CREATED_USER_ID, "User", "GetUser");
            //}
            scvm.serviceCatalogList = serviceList;
            return View(scvm);
        }

        public IActionResult ServiceCatalog(int? id)
        {
            var sc = serviceBusiness.ServiceGet<List<SERVICECATALOG>>("ServiceCatalog", "ServiceCatalogGetList");
            var prmServiceType = serviceBusiness.ServicePost<List<PARAMETER>>("SERVICETYPE", "ServiceCatalog", "GetParameterList");
            var prmOpStatus = serviceBusiness.ServicePost<List<PARAMETER>>("OPSTATUS", "ServiceCatalog", "GetParameterList");
            var userManagerIT = serviceBusiness.ServiceGet<List<USER>>("ServiceCatalog", "GetUserManagerIT");
            var userManagerBusiness = serviceBusiness.ServiceGet<List<USER>>("ServiceCatalog", "GetUserManagerBusiness");
            ServiceCatalogViewModel scvm = new ServiceCatalogViewModel();

            if (id != null)
            {
                var sc1 = serviceBusiness.ServicePost<SERVICECATALOG>(Convert.ToInt32(id), "ServiceCatalog", "GetServiceCatalog");
                scvm.servicecatalog = sc1;
            }

            foreach (var item in prmServiceType)
            {
                scvm.ParameterSelectList.Add(new SelectListItem()
                {
                    Text = item.MAIN_DATA_NAME,
                    Value = item.ID.ToString()
                });
            }

            foreach (var item in prmOpStatus)
            {
                scvm.ParameterOpStatusList.Add(new SelectListItem()
                {
                    Text = item.MAIN_DATA_NAME,
                    Value = item.ID.ToString()
                });
            }

            foreach (var item in userManagerIT)
            {
                scvm.UserManagerITList.Add(new SelectListItem()
                {
                    Text = item.NAME + " " + item.SURNAME,
                    Value = item.USER_ID.ToString()
                });
            }

            foreach (var item in userManagerBusiness)
            {
                scvm.UserManagerBusinessList.Add(new SelectListItem()
                {
                    Text = item.NAME + " " + item.SURNAME,
                    Value = item.USER_ID.ToString()
                });
            }
            return View(scvm);
        }

        [HttpPost]
        public IActionResult ServiceCatalog(int? id, ServiceCatalogViewModel serviceCatalogViewModel)
        {
            var user = HttpContext.Session.GetObject<USER>("User");

            bool success = false;

            SERVICECATALOG service = new SERVICECATALOG();
            service.SERVICE_NAME = serviceCatalogViewModel.servicecatalog.SERVICE_NAME;
            service.DESCRIPTION = serviceCatalogViewModel.servicecatalog.DESCRIPTION;
            service.SERVICE_PARAMETER_ID = serviceCatalogViewModel.servicecatalog.SERVICE_PARAMETER_ID;
            service.SERVICE_LEVEL = serviceCatalogViewModel.servicecatalog.SERVICE_LEVEL;
            service.OPERATIONAL_STATUS_ID = serviceCatalogViewModel.servicecatalog.OPERATIONAL_STATUS_ID;
            service.SERVICE_MANAGER_IT_ID = serviceCatalogViewModel.servicecatalog.SERVICE_MANAGER_IT_ID;
            service.SERVICE_MANAGER_BUSINESS_ID = serviceCatalogViewModel.servicecatalog.SERVICE_MANAGER_BUSINESS_ID;

            if (id == null)
            {
                //service.CREATED_USER_ID = user.USER_ID;
                success = serviceBusiness.ServicePost<bool>(service, "ServiceCatalog", "InsertServiceCatalog");
            }
            else
            {
                service.SERVICE_ID = Convert.ToInt32(id);
                //service.UPDATED_USER_ID = user.USER_ID;
                success = serviceBusiness.ServicePost<bool>(service, "ServiceCatalog", "UpdateServiceCatalog");
            }
            ShowSuccessToastMessage();
            return RedirectToAction("ServiceCatalogList", "ServiceCatalog");
        }

        [HttpPost]
        public JsonResult DeleteServiceCatalog(int deleteId)
        {
            bool success = false;
            success = serviceBusiness.ServicePost<bool>(deleteId, "ServiceCatalog", "DeleteServiceCatalog");
            return Json(new { success = success });
        }
    }
}
