//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using MES.Web.Models;
//using MES.Entities.Model;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using MES.Business;
//using MES.Entities;

//namespace MES.Web.Controllers
//{
//    public class SettingsController: BaseController
//    {
//        SettingKnowledgeOrderNumbersLogic settingsKnowledgeLogic = new SettingKnowledgeOrderNumbersLogic();
//        SettingIncidentOrderNumbersLogic settingsIncidentLogic = new SettingIncidentOrderNumbersLogic();
//        MainProcessLogic mainProcessLogic = new MainProcessLogic();
//        KnowledgeLogic knowledgeLogic = new KnowledgeLogic();

//        #region Knowledge Settings
//        public IActionResult KnowledgeSettings()
//            {
//                var orderList = settingsKnowledgeLogic.GetList();
//                var mainProcessList = mainProcessLogic.GetList();
//                var prmStatusList = knowledgeLogic.GetKnowledgeStatus("KNWLEDGESTATUS");
//                var  kvm = new SettingKnowledgeOrderNumbersViewModel();
//                kvm.orderNumbersList = orderList;

//                foreach (var item in mainProcessList)
//                {
//                    kvm.mainProcessList.Add(new SelectListItem()
//                    {
//                        Text = item.NAME,
//                        Value = item.ID.ToString()
//                    });
//                }
//            foreach (var item in prmStatusList)
//            {
//                kvm.PrmKnowledgeStatusList.Add(new SelectListItem()
//                {
//                    Text = item.MAIN_DATA_NAME,
//                    Value = item.ID.ToString()
//                });
//            }
//            return View(kvm);
//            }        
//        [HttpPost]
//        public JsonResult CreateOrEditKnowledgeOrderNumbers(int? id,ORDER_NUMBERS orderNumbers)
//            {
//                var user = HttpContext.Session.GetObject<USER>("User");

//                bool success = false;
//                using (MesContext context = new MesContext())
//                {
//                    orderNumbers.ID = Convert.ToInt32(id);
//                    orderNumbers.UPDATED_USER_ID = user.USER_ID;
//                    success = settingsKnowledgeLogic.UpdateOrderNumbers(orderNumbers);
//                }
//                return Json(new { success = success });
//            }        
//        [HttpGet]
//        public JsonResult GetKnowledgeOrderNumbers(int id)
//            {
//                var order = settingsKnowledgeLogic.GetOrderNumbers(id);
//                return Json(order);
//            }
//        [HttpGet]
//        public JsonResult GetKnowledgeStatus(int id)
//        {
//            var status = settingsKnowledgeLogic.GetStatus(id);
//            return Json(status);
//        }
//        [HttpPost]
//        public JsonResult EditKnowledgeStatus(int? id, KNOWLEDGE_SETTINGS status)
//            {
//                var user = HttpContext.Session.GetObject<USER>("User");

//                bool success = false;
//                using (MesContext context = new MesContext())
//                {
//                    status.ID = Convert.ToInt32(id);
//                    status.UPDATED_USER_ID = user.USER_ID;
//                    success = settingsKnowledgeLogic.UpdateStatus(status);
//                }
//                return Json(new { success = success });
//            }
//        #endregion

//        #region Incident Settings
//        public IActionResult IncidentSettings()
//        {
//            var orderList = settingsIncidentLogic.GetList();
//            var mainProcessList = mainProcessLogic.GetList();
//            var kvm = new SettingIncidentOrderNumbersViewModel();
//            kvm.orderNumbersList = orderList;

//            foreach (var item in mainProcessList)
//            {
//                kvm.mainProcessList.Add(new SelectListItem()
//                {
//                    Text = item.NAME,
//                    Value = item.ID.ToString()
//                });
//            }

//            return View(kvm);
//        }
//        [HttpPost]
//        public JsonResult CreateOrEditIncidentOrderNumbers(int? id, ORDER_NUMBERS orderNumbers)
//        {
//            var user = HttpContext.Session.GetObject<USER>("User");

//            bool success = false;
//            using (MesContext context = new MesContext())
//            {
//                orderNumbers.ID = Convert.ToInt32(id);
//                orderNumbers.UPDATED_USER_ID = user.USER_ID;
//                success = settingsIncidentLogic.UpdateOrderNumbers(orderNumbers);
//            }
//            return Json(new { success = success });
//        }
//        [HttpGet]
//        public JsonResult GetIncidentOrderNumbers(int id)
//        {
//            var order = settingsIncidentLogic.GetOrderNumbers(id);
//            return Json(order);
//        }
//        #endregion   
//    }
//}
