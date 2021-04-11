using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MES.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MES.Web.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MES.Web.Service;

namespace MES.Web.Controllers
{
    public class SettingsController : BaseController
    {
        ServiceBusiness serviceBusiness;

        public SettingsController(IHttpContextAccessor accessor, IConfiguration configuration)
        {
            serviceBusiness = new ServiceBusiness(configuration, accessor);
        }

        #region Knowledge Settings
        public IActionResult KnowledgeSettings()
        {
            var orderList = serviceBusiness.ServiceGet<List<ORDER_NUMBERS>>("Setting", "SettingsKnowledgeGetList");
            var mainProcessList = serviceBusiness.ServiceGet<List<MAIN_PROCESS>>("MainProcess", "MainProcessGetList");
            var prmStatusList = serviceBusiness.ServicePost<List<PARAMETER>>("KNWLEDGESTATUS", "Knowledge", "GetKnowledgeStatus");
            var kvm = new SettingKnowledgeOrderNumbersViewModel();
            kvm.orderNumbersList = orderList;

            foreach (var item in mainProcessList)
            {
                kvm.mainProcessList.Add(new SelectListItem()
                {
                    Text = item.NAME,
                    Value = item.ID.ToString()
                });
            }
            foreach (var item in prmStatusList)
            {
                kvm.PrmKnowledgeStatusList.Add(new SelectListItem()
                {
                    Text = item.MAIN_DATA_NAME,
                    Value = item.ID.ToString()
                });
            }
            return View(kvm);
        }
        [HttpPost]
        public JsonResult CreateOrEditKnowledgeOrderNumbers(int? id, ORDER_NUMBERS orderNumbers)
        {
            var user = HttpContext.Session.GetObject<USER>("User");
            bool success = false;
            orderNumbers.ID = Convert.ToInt32(id);
            //orderNumbers.UPDATED_USER_ID = user.USER_ID;
            success = serviceBusiness.ServicePost<bool>(orderNumbers, "Setting", "UpdateOrderNumbers");
            return Json(new { success = success });
        }
        [HttpGet]
        public JsonResult GetKnowledgeOrderNumbers(int id)
        {
            var order = serviceBusiness.ServicePost<ORDER_NUMBERS>(id, "Setting", "GetOrderNumbers");
            return Json(order);
        }
        [HttpGet]
        public JsonResult GetKnowledgeStatus(int id)
        {
            var status = serviceBusiness.ServicePost<KNOWLEDGE_SETTINGS>(id, "Setting", "GetStatus");
            return Json(status);
        }
        [HttpPost]
        public JsonResult EditKnowledgeStatus(int? id, KNOWLEDGE_SETTINGS status)
        {
            var user = HttpContext.Session.GetObject<USER>("User");

            bool success = false;
            status.ID = Convert.ToInt32(id);
            //status.UPDATED_USER_ID = user.USER_ID;
            success = serviceBusiness.ServicePost<bool>(status, "Setting", "UpdateStatus");
            return Json(new { success = success });
        }
        #endregion

        #region Incident Settings
        public IActionResult IncidentSettings()
        {
            var orderList = serviceBusiness.ServiceGet<List<ORDER_NUMBERS>>("Setting", "SettingsKnowledgeGetList");
            var mainProcessList = serviceBusiness.ServiceGet<List<MAIN_PROCESS>>("MainProcess", "MainProcessGetList");
            var kvm = new SettingIncidentOrderNumbersViewModel();
            kvm.orderNumbersList = orderList;

            foreach (var item in mainProcessList)
            {
                kvm.mainProcessList.Add(new SelectListItem()
                {
                    Text = item.NAME,
                    Value = item.ID.ToString()
                });
            }

            return View(kvm);
        }
        [HttpPost]
        public JsonResult CreateOrEditIncidentOrderNumbers(int? id, ORDER_NUMBERS orderNumbers)
        {
            var user = HttpContext.Session.GetObject<USER>("User");

            bool success = false;
            orderNumbers.ID = Convert.ToInt32(id);
            //orderNumbers.UPDATED_USER_ID = user.USER_ID;
            success = serviceBusiness.ServicePost<bool>(orderNumbers, "Setting", "UpdateOrderNumbers");
            return Json(new { success = success });
        }
        [HttpGet]
        public JsonResult GetIncidentOrderNumbers(int id)
        {
            var order = serviceBusiness.ServicePost<ORDER_NUMBERS>(id, "Setting", "GetIncidentOrderNumbers");
            return Json(order);
        }
        #endregion   
    }
}
