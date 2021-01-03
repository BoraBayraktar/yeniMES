using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MES.Web.Models;
using MES.Entities.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MES.Business;
using MES.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Reflection.Metadata;

namespace MES.Web.Controllers
{
    public class SlaController: BaseController
    {
        SlaLogic slaLogic = new SlaLogic();
        MainProcessLogic mainProcessLogic = new MainProcessLogic();
        WorkingScheduleLogic workingScheduleLogic = new WorkingScheduleLogic();
        SlaEventLogic slaEventLogic = new SlaEventLogic();
        SlaAreaLogic slaAreaLogic = new SlaAreaLogic();
        MesContext context = new MesContext();
        ServiceCatalogLogic serviceCatalogLogic = new ServiceCatalogLogic();

        //private IHostingEnvironment _hostingEnvironment;


        //public SlaController(IHostingEnvironment environment)
        //{
        //    _hostingEnvironment = environment;

        //}
        public IActionResult SlaList()
        {
            var slaList = slaLogic.GetList();
            SlaViewModel svm = new SlaViewModel();

            svm.slaList = slaList;

            var areaList = slaAreaLogic.GetList();

            foreach (var item in areaList)
            {
                if (!String.IsNullOrEmpty(item.SERVICE_ID))
                {
                    string[] services = item.CUSTOMER_ID.Split(',');
                    foreach (var itemService in services)
                    {
                        var service = slaAreaLogic.GetSlaArea(Convert.ToInt32(itemService));
                        item.SERVICE_ID += service.SERVICE_ID + ", ";
                    }
                }
            }

            return View(svm);
        }
        public IActionResult Sla(int? id)
        {
            var slaList = slaLogic.GetList();
            var mainProcessList = mainProcessLogic.GetList();
            var prmImportanceLevelList = slaLogic.GetImportanceLevel("INCIDENT_PRIORITY");
            var workingScheduleList = workingScheduleLogic.GetList();
            var prmStatusList = slaLogic.GetPrmStatus("STATUS");
            var serviceCatalogList = serviceCatalogLogic.GetList();
            var slaAreaList = slaAreaLogic.GetList();

            SlaViewModel svm = new SlaViewModel();
            svm.sla = new SLA();

            if (id != null)
            {
                var s = slaLogic.GetSla(Convert.ToInt32(id));
                svm.sla = s;
            }
            foreach (var item in mainProcessList)
            {
                svm.MainProcessList.Add(new SelectListItem()
                {
                    Text = item.NAME,
                    Value = item.ID.ToString()
                });
            }
            foreach (var item in prmImportanceLevelList)
            {
                svm.ImportanceLevelList.Add(new SelectListItem()
                {
                    Text = item.MAIN_DATA_NAME,
                    Value = item.ID.ToString()
                });
            }
            foreach (var item in workingScheduleList)
            {
                svm.WorkingScheduleList.Add(new SelectListItem()
                {
                    Text = item.NAME,
                    Value = item.WORKING_SCHEDULE_ID.ToString()
                });
            }
            foreach (var item in prmStatusList)
            {
                svm.prmStatusList.Add(new SelectListItem()
                {
                    Text = item.MAIN_DATA_NAME,
                    Value = item.ID.ToString()
                });
            }
            foreach (var item in serviceCatalogList)
            {
                svm.ServiceCatalogList.Add(new SelectListItem()
                {
                    Text = item.SERVICE_NAME,
                    Value = item.SERVICE_ID.ToString()
                });
            }
            foreach (var item in slaAreaList)
            {
                svm.SlaAreaList.Add(new SelectListItem()
                {
                    Text = item.SLA_MODEL.NAME,
                    Value = item.SLA_AREA_TYPE_ID.ToString()
                });
            }

            var eventList_ = slaEventLogic.GetSlaEventListByEventId(Convert.ToInt32(id));
            svm.slaEventsList = eventList_;


            var areaList_ = slaAreaLogic.GetSlaAreaListByAreaId(Convert.ToInt32(id));
            svm.slaAreaList = areaList_;
           
            return View(svm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Sla(int? id,int? areaID, SlaViewModel slaViewModel)
        {
            var user = HttpContext.Session.GetObject<USER>("User");
            bool success;
            SLA sla = new SLA();
            sla.NAME = slaViewModel.sla.NAME;
            sla.TYPE = slaViewModel.sla.TYPE;
            sla.MAIN_PROCESS_ID = slaViewModel.sla.MAIN_PROCESS_ID;
            sla.IMPORTANCE_LEVEL_ID = slaViewModel.sla.IMPORTANCE_LEVEL_ID;
            sla.WORKING_SCHEDULE_ID = slaViewModel.sla.WORKING_SCHEDULE_ID;
            sla.EFFORT_MINUTE = slaViewModel.sla.EFFORT_MINUTE;
            sla.EFFORT_HOUR = slaViewModel.sla.EFFORT_HOUR;
            sla.EFFORT_DAY = slaViewModel.sla.EFFORT_DAY;
            if (id == null)
            {
                sla.CREATED_USER_ID = user.USER_ID;
                success = slaLogic.InsertSla(sla);
            }
            else
            {
                sla.ID = Convert.ToInt32(id);
                sla.UPDATED_USER_ID = user.USER_ID;
                success = slaLogic.UpdateSla(sla);
            }
            
            SLA_AREA slaArea = new SLA_AREA();
            slaArea.SLA_ID = sla.ID;
            slaArea.CUSTOMER_ID = slaViewModel.slaArea.CUSTOMER_ID;
            slaArea.SERVICE_ID = slaViewModel.slaArea.SERVICE_ID;
            slaArea.ASSET_ID = slaViewModel.slaArea.ASSET_ID;
            slaArea.SLA_AREA_TYPE_ID = slaViewModel.slaArea.SLA_AREA_TYPE_ID;
            if (areaID == null)
            {
                slaArea.CREATED_USER_ID = user.USER_ID;
                success = slaAreaLogic.InsertSlaArea(slaArea);
            }
            else
            {
                slaArea.ID = Convert.ToInt32(areaID);
                slaArea.UPDATED_USER_ID = user.USER_ID;
                success = slaAreaLogic.UpdateSlaArea(slaArea);
            }


            var eventList = slaEventLogic.GetSlaEventListByEventId(sla.ID);
            var areaList = slaAreaLogic.GetSlaAreaListByAreaId(sla.ID);

            foreach (var item in eventList)
            {
                var exp = slaViewModel.PostSlaEvent.FirstOrDefault(q => q.ID == item.ID);
                if (exp == null)
                {
                    success = slaEventLogic.DeleteSlaEvent(item.ID);
                }
            }

            foreach (var item in areaList)
            {
                var exp = slaViewModel.PostSlaArea.FirstOrDefault(q => q.ID == item.ID);
                if (exp == null)
                {
                    success = slaAreaLogic.DeleteSlaArea(item.ID);
                }
            }

            foreach (var item in slaViewModel.PostSlaEvent)
            {
                item.SLA_ID = sla.ID;
                if (item.ID == 0)
                {
                    item.CREATED_USER_ID = user.USER_ID;
                    success = slaEventLogic.InsertSlaEvent(item);
                }
                else
                {
                    item.UPDATED_USER_ID = user.USER_ID;
                    success = slaEventLogic.UpdateSlaEvent(item);
                }
            }

            foreach (var item in slaViewModel.PostSlaArea)
            {
                item.SLA_ID = sla.ID;
                if (item.ID == 0)
                {
                    item.CREATED_USER_ID = user.USER_ID;
                    success = slaAreaLogic.InsertSlaArea(item);
                }
                else
                {
                    item.UPDATED_USER_ID = user.USER_ID;
                    success = slaAreaLogic.UpdateSlaArea(item);
                }
            }

            int i = 1;
            if (slaViewModel.SelectedServices != null)
            {
                int serviceCount = slaViewModel.SelectedServices.Length;
                foreach (var item in slaViewModel.SelectedServices)
                {
                    slaArea.SERVICE_ID += item;
                    if (i != serviceCount)
                    {
                        slaArea.SERVICE_ID += ",";
                    }
                    i++;
                }
            }

            ShowSuccessToastMessage();

           return RedirectToAction("SlaList", "Sla");            
        }
        [HttpPost]
        public JsonResult CreateOrEditSla(int? id, SlaViewModel slaViewModel)
        {
            var user = HttpContext.Session.GetObject<USER>("User");

            bool success = false;

            SLA sla = new SLA();
            SLA_EVENTS slaEvents = new SLA_EVENTS();

            if (id == null)
            {
                sla.CREATED_USER_ID = user.USER_ID;
                success = slaLogic.InsertSla(sla);
            }
            else
            {
                sla.ID = Convert.ToInt32(id);
                sla.UPDATED_USER_ID = user.USER_ID;
                success = slaLogic.UpdateSla(sla);
            }
            return Json(new { success = success });
        }
        [HttpPost]
        public JsonResult DeleteSla(int deleteId)
        {
            bool success = false;
            success = slaLogic.DeleteSla(deleteId);
            return Json(new { success = success });
        }
        public JsonResult GetSla(int id)
        {
            var s = slaLogic.GetSla(id);
            return Json(s);
        }  
    }
}
