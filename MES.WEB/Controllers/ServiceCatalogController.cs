//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using MES.Web.Models;
//using MES.Entities.Model;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using MES.Business;

//namespace MES.Web.Controllers
//{
//    public class ServiceCatalogController : BaseController
//    {
//        ServiceCatalogLogic serviceCatalogLogic = new ServiceCatalogLogic();

//        public IActionResult ServiceCatalogList()
//        {
//            var serviceList = serviceCatalogLogic.GetList();
//            ServiceCatalogViewModel scvm = new ServiceCatalogViewModel();
//            scvm.serviceCatalogList = serviceList;

//            return View(scvm);
//        }

//        public IActionResult ServiceCatalog(int? id)
//        {
//            var sc = serviceCatalogLogic.GetList();
//            var prmServiceType = serviceCatalogLogic.GetParameterList("SERVICETYPE");
//            var prmOpStatus = serviceCatalogLogic.GetPrmOpStatus("OPSTATUS");
//            var userManagerIT = serviceCatalogLogic.GetUserManagerIT();
//            var userManagerBusiness = serviceCatalogLogic.GetUserManagerBusiness();
//            ServiceCatalogViewModel scvm = new ServiceCatalogViewModel();

//            if (id != null)
//            {
//                var sc1 = serviceCatalogLogic.GetServiceCatalog(Convert.ToInt32(id));
//                scvm.servicecatalog = sc1;
//            }

//            foreach (var item in prmServiceType)
//            {
//                scvm.ParameterSelectList.Add(new SelectListItem()
//                {
//                    Text = item.MAIN_DATA_NAME,
//                    Value = item.ID.ToString()
//                });
//            }

//            foreach (var item in prmOpStatus)
//            {
//                scvm.ParameterOpStatusList.Add(new SelectListItem()
//                {
//                    Text = item.MAIN_DATA_NAME,
//                    Value = item.ID.ToString()
//                });
//            }

//            foreach (var item in userManagerIT)
//            {
//                scvm.UserManagerITList.Add(new SelectListItem()
//                {
//                    Text = item.NAME + " " + item.SURNAME,
//                    Value = item.USER_ID.ToString()
//                });
//            }

//            foreach (var item in userManagerBusiness)
//            {
//                scvm.UserManagerBusinessList.Add(new SelectListItem()
//                {
//                    Text = item.NAME + " " + item.SURNAME,
//                    Value = item.USER_ID.ToString()
//                });
//            }

//            return View(scvm);
//        }        

//        [HttpPost]
//        public IActionResult ServiceCatalog(int? id, ServiceCatalogViewModel serviceCatalogViewModel)
//        {
//            var user = HttpContext.Session.GetObject<USER>("User");

//            bool success = false;

//            SERVICECATALOG service = new SERVICECATALOG();
//            service.SERVICE_NAME = serviceCatalogViewModel.servicecatalog.SERVICE_NAME;
//            service.DESCRIPTION = serviceCatalogViewModel.servicecatalog.DESCRIPTION;
//            service.SERVICE_PARAMETER_ID = serviceCatalogViewModel.servicecatalog.SERVICE_PARAMETER_ID;
//            service.SERVICE_LEVEL = serviceCatalogViewModel.servicecatalog.SERVICE_LEVEL;
//            service.OPERATIONAL_STATUS_ID = serviceCatalogViewModel.servicecatalog.OPERATIONAL_STATUS_ID;
//            service.SERVICE_MANAGER_IT_ID = serviceCatalogViewModel.servicecatalog.SERVICE_MANAGER_IT_ID;
//            service.SERVICE_MANAGER_BUSINESS_ID = serviceCatalogViewModel.servicecatalog.SERVICE_MANAGER_BUSINESS_ID;

//            if (id == null)
//            {
//                service.CREATED_USER_ID = user.USER_ID;
//                success = serviceCatalogLogic.InsertServiceCatalog(service);
//            }
//            else
//            {
//                service.SERVICE_ID = Convert.ToInt32(id);
//                service.UPDATED_USER_ID = user.USER_ID;
//                success = serviceCatalogLogic.UpdateServiceCatalog(service);
//            }
//            ShowSuccessToastMessage();
//            return RedirectToAction("ServiceCatalogList", "ServiceCatalog");
//        }        
               
//        [HttpPost]
//        public JsonResult DeleteServiceCatalog(int deleteId)
//        {
//            bool success = false;
//            success = serviceCatalogLogic.DeleteServiceCatalog(deleteId);
//            return Json(new { success = success });
//        }       
//    }
//}
