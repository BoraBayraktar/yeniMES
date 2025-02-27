﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.InkML;
using MES.Web.Model;
using MES.Web.Models;
using MES.Web.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace MES.Web.Controllers
{
    public class SupportController : BaseController
    {
        #region Instance
        //UserLogic userLogic = new UserLogic();
        //UserGroupLogic userGroupLogic = new UserGroupLogic();
        //IncidentLogic incidentLogic = new IncidentLogic();
        //ParameterLogic parameterLogic = new ParameterLogic();
        //IncidentHistoryLogic incidentHistoryLogic = new IncidentHistoryLogic();
        //ServiceCatalogLogic serviceCatalogLogic = new ServiceCatalogLogic();
        //GroupLogic groupLogic = new GroupLogic();
        //DepartmentLogic departmentLogic = new DepartmentLogic();
        //TitleLogic titleLogic = new TitleLogic();
        //IncidentResolutionLogic incidentResolutionLogic = new IncidentResolutionLogic();
        //RuleLogic ruleLogic = new RuleLogic();
        ServiceBusiness serviceBusiness;

        private IHostingEnvironment _hostingEnvironment;

        #endregion

        public SupportController(IHostingEnvironment environment, IHttpContextAccessor accessor, IConfiguration configuration)
        {
            serviceBusiness = new ServiceBusiness(configuration, accessor);
            _hostingEnvironment = environment;

        }
        public IActionResult Visitor()
        {
            return View();
        }

        public IActionResult Operator()
        {
            var incidentList = serviceBusiness.ServiceGet<List<INCIDENT>>("Incident", "IncidentGetList");
            var incidentStatusList = serviceBusiness.ServicePost<List<PARAMETER>>("STATUS", "Parameter", "GetParameterListByParameterTypeCode").Where(q => q.IS_ACTIVE == true).ToList();
            var groupList = serviceBusiness.ServiceGet<List<GROUP>>("Group", "GroupGetList");

            IncidentViewModel ivm = new IncidentViewModel();
            ivm.IncidentList = incidentList;

            foreach (var item in incidentStatusList)
            {
                ivm.IncidentStatusList.Add(new SelectListItem()
                {
                    Text = item.MAIN_DATA_NAME,
                    Value = item.ID.ToString()
                });
            }

            foreach (var item in groupList)
            {
                ivm.UserGroupList.Add(new SelectListItem()
                {
                    Text = item.GROUP_NAME,
                    Value = item.ID.ToString()
                });
            }

            return View(ivm);
        }


        public IActionResult OperatorDetail(int incidentId)
        {
            var incident = serviceBusiness.ServicePost<INCIDENT>(incidentId, "Incident", "GetIncident");
            IncidentDetailViewModel ivm = new IncidentDetailViewModel();
            ivm.incident = incident;

            var incidentHistoryList = serviceBusiness.ServicePost<List<INCIDENT_HISTORY>>(incidentId, "Incident", "GetListByIncidentId");
            ivm.IncidentHistoryList = incidentHistoryList;

            var incidentResolution = serviceBusiness.ServicePost<INCIDENT_RESOLUTION>(incidentId, "Incident", "GetResolutionByIncidentId");
            ivm.incidentResolution = incidentResolution;

            var priorityList = serviceBusiness.ServicePost<List<PARAMETER>>("INCIDENT_PRIORITY_USER", "Parameter", "GetParameterListByParameterTypeCode").Where(q => q.IS_ACTIVE == true).ToList();
            var serviceCatalogList = serviceBusiness.ServiceGet<List<SERVICECATALOG>>("ServiceCatalog", "ServiceCatalogGetList");
            var incidentUrgencyList = serviceBusiness.ServicePost<List<PARAMETER>>("INCIDENT_URGENCY", "Parameter", "GetParameterListByParameterTypeCode").Where(q => q.IS_ACTIVE == true).ToList();
            var incidentImpactList = serviceBusiness.ServicePost<List<PARAMETER>>("INCIDENT_IMPACT", "Parameter", "GetParameterListByParameterTypeCode").Where(q => q.IS_ACTIVE == true).ToList();
            var incidentStatusList = serviceBusiness.ServicePost<List<PARAMETER>>("STATUS", "Parameter", "GetParameterListByParameterTypeCode").Where(q => q.IS_ACTIVE == true).ToList();
            var incidentSourceList = serviceBusiness.ServicePost<List<PARAMETER>>("INCIDENT_SOURCE", "Parameter", "GetParameterListByParameterTypeCode").Where(q => q.IS_ACTIVE == true).ToList();
            var incidentTypeList = serviceBusiness.ServicePost<List<PARAMETER>>("INCIDENT_TYPE", "Parameter", "GetParameterListByParameterTypeCode").Where(q => q.IS_ACTIVE == true).ToList();
            var incidentCategoryList = serviceBusiness.ServicePost<List<PARAMETER>>("INCIDENT_CATEGORY", "Parameter", "GetParameterListByParameterTypeCode").Where(q => q.IS_ACTIVE == true).ToList();
            var incidentSubCategoryList = serviceBusiness.ServicePost<List<PARAMETER>>("INCIDENT_SUB_CATEGORY", "Parameter", "GetParameterListByParameterTypeCode").Where(q => q.IS_ACTIVE == true).ToList();
            if (incident.CATEGORY_ID != null)
            {
                incidentSubCategoryList = incidentSubCategoryList.Where(q => q.PARENT_PARAMETER_ID == incident.CATEGORY_ID).ToList();
            }

            var resolutionCodeList = serviceBusiness.ServicePost<List<PARAMETER>>("RESOLUTION_CODE", "Parameter", "GetParameterListByParameterTypeCode").Where(q => q.IS_ACTIVE == true).ToList();


            if (incident.ASSIGNED_GROUP_ID != null)
            {
                var groupExpertList = serviceBusiness.ServicePost<List<GROUP_EXPERT>>(Convert.ToInt32(incident.ASSIGNED_GROUP_ID),"Group", "GetExpertListByGrpId");
                foreach (var item in groupExpertList)
                {
                    ivm.UserList.Add(new SelectListItem()
                    {
                        Text = item.EXPERT_NAME,
                        Value = item.EXPERT_NAME_ID.ToString()
                    });
                }
            }
            else
            {
                var userList = serviceBusiness.ServiceGet<List<USER>>("User", "UserGetList");

                foreach (var item in userList)
                {
                    ivm.UserList.Add(new SelectListItem()
                    {
                        Text = item.NAME + " " + item.SURNAME,
                        Value = item.USER_ID.ToString()
                    });
                }
            }

            var userGroupList = serviceBusiness.ServiceGet<List<GROUP>>("Group", "GroupGetList");


            foreach (var item in priorityList)
            {
                ivm.IncidentPriorityList.Add(new SelectListItem()
                {
                    Text = item.MAIN_DATA_NAME,
                    Value = item.ID.ToString()
                });
            }


            foreach (var item in serviceCatalogList)
            {
                ivm.ServiceCatalogList.Add(new SelectListItem()
                {
                    Text = item.SERVICE_NAME,
                    Value = item.SERVICE_ID.ToString()
                });
            }


            foreach (var item in incidentUrgencyList)
            {
                ivm.IncidentUrgencyList.Add(new SelectListItem()
                {
                    Text = item.MAIN_DATA_NAME,
                    Value = item.ID.ToString()
                });
            }

            foreach (var item in incidentImpactList)
            {
                ivm.IncidentImpactList.Add(new SelectListItem()
                {
                    Text = item.MAIN_DATA_NAME,
                    Value = item.ID.ToString()
                });
            }

            foreach (var item in incidentStatusList)
            {
                ivm.IncidentStatusList.Add(new SelectListItem()
                {
                    Text = item.MAIN_DATA_NAME,
                    Value = item.ID.ToString()
                });
            }

            foreach (var item in incidentSourceList)
            {
                ivm.IncidentSourceList.Add(new SelectListItem()
                {
                    Text = item.MAIN_DATA_NAME,
                    Value = item.ID.ToString()
                });
            }

            foreach (var item in incidentTypeList)
            {
                ivm.IncidentTypeList.Add(new SelectListItem()
                {
                    Text = item.MAIN_DATA_NAME,
                    Value = item.ID.ToString()
                });
            }

            foreach (var item in incidentCategoryList)
            {
                ivm.CategoryList.Add(new SelectListItem()
                {
                    Text = item.MAIN_DATA_NAME,
                    Value = item.ID.ToString()
                });
            }
            foreach (var item in incidentSubCategoryList)
            {
                ivm.SubCategoryList.Add(new SelectListItem()
                {
                    Text = item.MAIN_DATA_NAME,
                    Value = item.ID.ToString()
                });
            }



            foreach (var item in userGroupList)
            {
                ivm.UserGroupList.Add(new SelectListItem()
                {
                    Text = item.GROUP_NAME,
                    Value = item.ID.ToString()
                });
            }


            foreach (var item in resolutionCodeList)
            {
                ivm.ResolutionCodeList.Add(new SelectListItem()
                {
                    Text = item.MAIN_DATA_NAME,
                    Value = item.ID.ToString()
                });
            }


            return View(ivm);
        }


        public IActionResult OperatorIncidentList()
        {
            var incidentList = serviceBusiness.ServiceGet<List<INCIDENT>>("Incident", "IncidentGetList"); 
            IncidentViewModel ivm = new IncidentViewModel();
            ivm.IncidentList = incidentList;
            return View(ivm);
        }

        public IActionResult IncidentList()
        {
            var incidentList = serviceBusiness.ServiceGet<List<INCIDENT>>("Incident", "IncidentGetList");
            var unresolved = serviceBusiness.ServiceGet<int>("Incident", "sumUnResolved");
            var overdue = serviceBusiness.ServiceGet<int>("Incident", "sumOverdue");
            var duotoday = serviceBusiness.ServiceGet<int>("Incident", "sumDuetoday");
            var open = serviceBusiness.ServiceGet<int>("Incident", "sumOpen");
            var onHold = serviceBusiness.ServiceGet<int>("Incident", "sumOnhold");
            var unassigned = serviceBusiness.ServiceGet<int>("Incident", "sumUnassigned");
            IncidentViewModel ivm = new IncidentViewModel();
            ivm.IncidentList = incidentList;
            ivm.SumUnRelased = unresolved;
            ivm.SumOverdue = overdue;
            ivm.SumDuetoday = duotoday;
            ivm.SumOpen = open;
            ivm.SumOnhold = onHold;
            ivm.SumUnassigned = unassigned;
            return View(ivm);
        }

        public IActionResult CreateIncident()
        {
            var userList = serviceBusiness.ServiceGet<List<USER>>("User", "UserGetList");
            var departmentList = serviceBusiness.ServiceGet<List<DEPARTMENT>>("Department", "DepartmentGetList");
            var titleList = serviceBusiness.ServiceGet<List<TITLE>>("Title", "TitleGetList");
            //var priorityList = incidentLogic.GetPriorityList();           
            var priorityList = serviceBusiness.ServicePost<List<PARAMETER>>("INCIDENT_PRIORITY_USER", "Parameter", "GetParameterListByParameterTypeCode").Where(q => q.IS_ACTIVE == true).ToList();
            var code = serviceBusiness.ServiceGet<string>("Incident", "MaxCode");


            IncidentViewModel ivm = new IncidentViewModel();
            ivm.incident = new INCIDENT();
            ivm.incident.CODE = code;

            foreach (var item in userList)
            {
                ivm.UserList.Add(new SelectListItem()
                {
                    Text = item.NAME + " " + item.SURNAME,
                    Value = item.USER_ID.ToString()
                });
            }

            foreach (var item in departmentList)
            {
                ivm.DepartmentList.Add(new SelectListItem()
                {
                    Text = item.NAME,
                    Value = item.DEPARTMENT_ID.ToString()
                });
            }

            foreach (var item in titleList)
            {
                ivm.TitleList.Add(new SelectListItem()
                {
                    Text = item.NAME,
                    Value = item.TITLE_ID.ToString()
                });
            }

            foreach (var item in priorityList)
            {
                ivm.IncidentPriorityList.Add(new SelectListItem()
                {
                    Text = item.MAIN_DATA_NAME,
                    Value = item.ID.ToString()
                });
            }
            return View(ivm);
        }


        [HttpPost]
        public IActionResult OperatorDetail(IncidentDetailViewModel incidentDetailModel)
        {
            bool success = false;

            incidentDetailModel.incident.UPDATED_USER_ID = SessionUser.USER_ID;

            success = serviceBusiness.ServicePost<bool>(incidentDetailModel.incident, "Incident", "UpdateIncidentDetail");

            if (success)
            {
                var getIncident = serviceBusiness.ServicePost<INCIDENT>(incidentDetailModel.incident.ID, "Incident", "GetIncident"); 
                INCIDENT_HISTORY history = new INCIDENT_HISTORY()
                {
                    CREATED_DATE = DateTime.Now,
                    CREATED_USER_ID = SessionUser.USER_ID,
                    DESCRIPTION = incidentDetailModel.incidentHistory.DESCRIPTION,
                    INCIDENT_ID = incidentDetailModel.incident.ID,
                    INCIDENT_PRIORITY_ID = incidentDetailModel.incident.INCIDENT_PRIORITY_ID,
                    INCIDENT_STATUS_ID = incidentDetailModel.incident.INCIDENT_STATUS_ID,
                    ASSIGNED_USER_ID = incidentDetailModel.incident.ASSIGNED_USER_ID,
                    ASSIGNED_GROUP_ID = incidentDetailModel.incident.ASSIGNED_GROUP_ID,
                    IS_DELETED = false,
                    EFFORT_DAY = incidentDetailModel.incidentHistory.EFFORT_DAY,
                    EFFORT_HOUR = incidentDetailModel.incidentHistory.EFFORT_HOUR,
                    EFFORT_MINUTE = incidentDetailModel.incidentHistory.EFFORT_MINUTE,
                    INCIDENT_TYPE_ID = serviceBusiness.ServicePost<INCIDENT_TYPE>("ST", "Incident", "GetIncidentType").INCIDENT_TYPE_ID,
                    VISIBLE_TO_USER = incidentDetailModel.incidentHistory.VISIBLE_TO_USER,
                    VISIBLE_TO_OPERATOR = incidentDetailModel.incidentHistory.VISIBLE_TO_OPERATOR
                };
                var successHistory = serviceBusiness.ServicePost<bool>(history, "Incident", "InsertIncidentHistory");

                if (successHistory)
                {
                    if (!String.IsNullOrEmpty(incidentDetailModel.incidentResolution.RESOLVED_DESCRIPTION))
                    {
                        INCIDENT_RESOLUTION incidentResolution = new INCIDENT_RESOLUTION()
                        {
                            INCIDENT_ID = incidentDetailModel.incident.ID,
                            CREATED_DATE = DateTime.Now,
                            CREATED_USER_ID = SessionUser.USER_ID,
                            IS_APPROVED = false,
                            IS_DELETED = false,
                            RESOLVED_CODE = incidentDetailModel.incidentResolution.RESOLVED_CODE,
                            RESOLVED_DESCRIPTION = incidentDetailModel.incidentResolution.RESOLVED_DESCRIPTION,
                            RESOLVED_DATE = incidentDetailModel.incidentResolution.RESOLVED_DATE
                        };
                        var successResolution = serviceBusiness.ServicePost<bool>(incidentResolution, "Incident", "InsertIncidentResolution"); 
                        if (successResolution)
                        {
                            ShowSuccessToastMessage();
                        }
                        else
                        {
                            ShowErrorToastMessage();
                        }
                    }
                    else
                    {
                        ShowSuccessToastMessage();
                    }
                }
                else
                {
                    ShowErrorToastMessage();
                }

            }
            else
            {
                ShowErrorToastMessage();
            }

            return RedirectToAction("OperatorDetail", "Support", new { incidentId = incidentDetailModel.incident.ID });
        }



        [HttpPost]
        public IActionResult CreateIncident(IncidentViewModel incidentViewModel, IFormFile imageFile)
        {
            bool success = false;

            INCIDENT_FILES incidentFiles = new INCIDENT_FILES();

            if (imageFile != null)
            {
                var uploads = Path.Combine(_hostingEnvironment.ContentRootPath, @"Content/images/incident");
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(uploads, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(fileStream);
                }
                incidentFiles.FILE_PATH = "/Content/images/incident/" + fileName;
            }

            incidentViewModel.incident.INCIDENT_STATUS_ID = 1;


            incidentViewModel.incident.CREATED_USER_ID = SessionUser.USER_ID;
            success = serviceBusiness.ServicePost<bool>(incidentViewModel.incident, "Incident", "InsertIncident"); //incidentLogic.InsertIncident(incidentViewModel.incident);
            if (success)
            {
                INCIDENT_HISTORY history = new INCIDENT_HISTORY()
                {
                    CREATED_DATE = DateTime.Now,
                    CREATED_USER_ID = SessionUser.USER_ID,
                    DESCRIPTION = incidentViewModel.incident.DESCRIPTION,
                    INCIDENT_ID = incidentViewModel.incident.ID,
                    INCIDENT_PRIORITY_ID = incidentViewModel.incident.INCIDENT_PRIORITY_ID,
                    INCIDENT_STATUS_ID = incidentViewModel.incident.INCIDENT_STATUS_ID,
                    IS_DELETED = false,
                    INCIDENT_TYPE_ID = serviceBusiness.ServicePost<INCIDENT_TYPE>("ST", "Incident", "GetIncidentType").INCIDENT_TYPE_ID,
                    VISIBLE_TO_OPERATOR = true,
                    VISIBLE_TO_USER = true
                };
                
                var successHistory = serviceBusiness.ServicePost<bool>(history, "Incident", "InsertIncidentHistory");

                if (successHistory)
                {
                    if (!String.IsNullOrEmpty(incidentFiles.FILE_PATH))
                    {
                        incidentFiles.INCIDENT_ID = incidentViewModel.incident.ID;
                        var successFile = serviceBusiness.ServicePost<bool>(incidentFiles, "Incident", "InsertIncidentFiles");
                        if (successFile)
                        {
                            ShowSuccessToastMessage();
                        }
                        else
                        {
                            ShowErrorToastMessage();
                        }
                    }
                    else
                    {
                        ShowSuccessToastMessage();

                    }
                }
                else
                {
                    ShowErrorToastMessage();
                }


            }
            else
            {
                ShowErrorToastMessage();
            }

            var userList = serviceBusiness.ServiceGet<List<USER>>("User", "UserGetList");
            var priorityList =  serviceBusiness.ServicePost<List<PARAMETER>>("INCIDENT_PRIORITY", "Parameter", "GetParameterListByParameterTypeCode");

            IncidentViewModel ivm = new IncidentViewModel();
            foreach (var item in userList)
            {
                ivm.UserList.Add(new SelectListItem()
                {
                    Text = item.NAME + " " + item.SURNAME,
                    Value = item.USER_ID.ToString()
                });
            }

            foreach (var item in priorityList)
            {
                ivm.IncidentPriorityList.Add(new SelectListItem()
                {
                    Text = item.MAIN_DATA_NAME,
                    Value = item.ID.ToString()
                });
            }

            bool sonuc = false;
            var ruleList = serviceBusiness.ServiceGet<List<RULE>>("Rule", "RuleGetList").Where(q => q.RULE_ACTION_TYPE == 1).ToList();
            if (ruleList.Count > 0)
            {
                foreach (var item in ruleList)
                {
                    var ruleDetail = serviceBusiness.ServicePost<List<RULE_DETAIL>>(item.RULE_ID, "Rule", "GetRuleDetailByRuleId");
                    foreach (var detail in ruleDetail)
                    {
                        switch (detail.CRITERIA)
                        {
                            case "Konu":
                                if (detail.REQUIREMENT == "Like")
                                {
                                    if (incidentViewModel.incident.SUBJECT.Contains(detail.VALUE))
                                    {
                                        if (detail.CONDITION == "Ve")
                                        {
                                            if (sonuc)
                                            {
                                                sonuc = true;
                                            }
                                            else
                                            {
                                                sonuc = false;
                                            }
                                        }
                                        else
                                        {
                                            sonuc = true;
                                        }
                                    }
                                    else
                                    {
                                        if (detail.CONDITION == "Ve")
                                        {
                                            sonuc = false;
                                        }
                                        else
                                        {
                                            if (sonuc)
                                            {
                                                sonuc = true;
                                            }
                                            else
                                            {
                                                sonuc = false;
                                            }
                                        }
                                    }
                                }
                                else if (detail.REQUIREMENT == "Contains")
                                {
                                    if (incidentViewModel.incident.SUBJECT.Contains(detail.VALUE))
                                    {
                                        if (detail.CONDITION == "Ve")
                                        {
                                            if (sonuc)
                                            {
                                                sonuc = true;
                                            }
                                            else
                                            {
                                                sonuc = false;
                                            }
                                        }
                                        else
                                        {
                                            sonuc = true;
                                        }
                                    }
                                    else
                                    {
                                        if (detail.CONDITION == "Ve")
                                        {
                                            sonuc = false;
                                        }
                                        else
                                        {
                                            if (sonuc)
                                            {
                                                sonuc = true;
                                            }
                                            else
                                            {
                                                sonuc = false;
                                            }
                                        }
                                    }
                                }
                                else if (detail.REQUIREMENT == "Is")
                                {
                                    if (incidentViewModel.incident.SUBJECT == detail.VALUE)
                                    {
                                        if (detail.CONDITION == "Ve")
                                        {
                                            if (sonuc)
                                            {
                                                sonuc = true;
                                            }
                                            else
                                            {
                                                sonuc = false;
                                            }
                                        }
                                        else
                                        {
                                            sonuc = true;
                                        }
                                    }
                                    else
                                    {
                                        if (detail.CONDITION == "Ve")
                                        {
                                            sonuc = false;
                                        }
                                        else
                                        {
                                            if (sonuc)
                                            {
                                                sonuc = true;
                                            }
                                            else
                                            {
                                                sonuc = false;
                                            }
                                        }
                                    }
                                }
                                break;
                            case "Atanan Grup":
                                if (incidentViewModel.incident.ASSIGNED_GROUP_ID == Convert.ToInt32(detail.VALUE))
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                    else
                                    {
                                        sonuc = true;
                                    }
                                }
                                else
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        sonuc = false;
                                    }
                                    else
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                }
                                break;
                            case "Kullanıcı":
                                if (incidentViewModel.incident.CREATED_USER_ID == Convert.ToInt32(detail.VALUE))
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                    else
                                    {
                                        sonuc = true;
                                    }
                                }
                                else
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        sonuc = false;
                                    }
                                    else
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                }
                                break;
                            case "Kullanıcı Departman":
                                var user = serviceBusiness.ServicePost<USER>(Convert.ToInt32(incidentViewModel.incident.CREATED_USER_ID), "User", "GetUser");
                                if (Convert.ToInt32(user.DEPARTMENT_ID) == Convert.ToInt32(detail.VALUE))
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                    else
                                    {
                                        sonuc = true;
                                    }
                                }
                                else
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        sonuc = false;
                                    }
                                    else
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                }
                                break;
                            case "Kullanıcı Şirketi":
                                var ksUser = serviceBusiness.ServicePost<USER>(Convert.ToInt32(incidentViewModel.incident.CREATED_USER_ID), "User", "GetUser");
                                if (ksUser.DEPARTMENT_ID != null)
                                {
                                    var ksDepartment = serviceBusiness.ServicePost<DEPARTMENT>(Convert.ToInt32(ksUser.DEPARTMENT_ID), "Department", "GetDepartment");
                                    if (Convert.ToInt32(ksDepartment.COMPANY_ID) == Convert.ToInt32(detail.VALUE))
                                    {
                                        if (detail.CONDITION == "Ve")
                                        {
                                            if (sonuc)
                                            {
                                                sonuc = true;
                                            }
                                            else
                                            {
                                                sonuc = false;
                                            }
                                        }
                                        else
                                        {
                                            sonuc = true;
                                        }
                                    }
                                    else
                                    {
                                        if (detail.CONDITION == "Ve")
                                        {
                                            sonuc = false;
                                        }
                                        else
                                        {
                                            if (sonuc)
                                            {
                                                sonuc = true;
                                            }
                                            else
                                            {
                                                sonuc = false;
                                            }
                                        }
                                    }
                                }
                                break;
                            case "Öncelik":
                                if (incidentViewModel.incident.INCIDENT_PRIORITY_ID == Convert.ToInt32(detail.VALUE))
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                    else
                                    {
                                        sonuc = true;
                                    }
                                }
                                else
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        sonuc = false;
                                    }
                                    else
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                }
                                break;
                            case "Kategori":
                                if (incidentViewModel.incident.CATEGORY_ID == Convert.ToInt32(detail.VALUE))
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                    else
                                    {
                                        sonuc = true;
                                    }
                                }
                                else
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        sonuc = false;
                                    }
                                    else
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                }
                                break;
                            case "Aciliyet":
                                if (incidentViewModel.incident.INCIDENT_PRIORITY_ID == Convert.ToInt32(detail.VALUE))
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                    else
                                    {
                                        sonuc = true;
                                    }
                                }
                                else
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        sonuc = false;
                                    }
                                    else
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                }
                                break;
                            case "Hizmet":
                                if (incidentViewModel.incident.SERVICE_CATALOG_ID == Convert.ToInt32(detail.VALUE))
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                    else
                                    {
                                        sonuc = true;
                                    }
                                }
                                else
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        sonuc = false;
                                    }
                                    else
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                }
                                break;
                            case "Atanan Kişi":
                                if (incidentViewModel.incident.ASSIGNED_USER_ID == Convert.ToInt32(detail.VALUE))
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                    else
                                    {
                                        sonuc = true;
                                    }
                                }
                                else
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        sonuc = false;
                                    }
                                    else
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                }
                                break;
                            case "Durum":
                                if (incidentViewModel.incident.INCIDENT_STATUS_ID == Convert.ToInt32(detail.VALUE))
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                    else
                                    {
                                        sonuc = true;
                                    }
                                }
                                else
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        sonuc = false;
                                    }
                                    else
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                }
                                break;
                            case "Bildirim Kaynağı":
                                if (incidentViewModel.incident.INCIDENT_SOURCE_ID == Convert.ToInt32(detail.VALUE))
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                    else
                                    {
                                        sonuc = true;
                                    }
                                }
                                else
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        sonuc = false;
                                    }
                                    else
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                }
                                break;
                            case "Etki":
                                if (incidentViewModel.incident.INCIDENT_IMPACT_ID == Convert.ToInt32(detail.VALUE))
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                    else
                                    {
                                        sonuc = true;
                                    }
                                }
                                else
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        sonuc = false;
                                    }
                                    else
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                }
                                break;
                            case "Sorun Tipi":
                                if (incidentViewModel.incident.INCIDENT_TYPE_ID == Convert.ToInt32(detail.VALUE))
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                    else
                                    {
                                        sonuc = true;
                                    }
                                }
                                else
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        sonuc = false;
                                    }
                                    else
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                }
                                break;
                            default:
                                if (detail.CONDITION == "Ve")
                                {
                                    sonuc = false;
                                }
                                break;
                        }
                    }

                    if (sonuc)
                    {
                        var incident = serviceBusiness.ServicePost<INCIDENT>(incidentViewModel.incident.ID, "Incident", "GetIncident"); 

                        switch (item.RULE_ACTION)
                        {
                            case "GROUP":
                                incident.ASSIGNED_GROUP_ID = Convert.ToInt32(item.RULE_ACTION_DATA);
                                break;
                            case "USER":
                                incident.ASSIGNED_USER_ID = Convert.ToInt32(item.RULE_ACTION_DATA);
                                break;
                            case "CATEGORY":
                                incident.CATEGORY_ID = Convert.ToInt32(item.RULE_ACTION_DATA);
                                break;
                            case "PRIORITY":
                                incident.INCIDENT_PRIORITY_ID = Convert.ToInt32(item.RULE_ACTION_DATA);
                                break;
                            case "TYPE":
                                break;
                            case "REQUIRED":
                                break;
                            default:
                                break;
                        }

                        serviceBusiness.ServicePost<bool>(incident, "Incident", "UpdateIncident");
                    }


                }
            }

            return RedirectToAction("IncidentList", "Support");
        }


        [HttpGet]
        public JsonResult UserList(int groupId)
        {
            var userList = serviceBusiness.ServicePost<USER_GROUP>(groupId, "UserGroup", "GetGroupUser");
            return Json(userList);
        }


        [HttpGet]
        public JsonResult GetExpertListByGroupId(int groupId)
        {
            var groupList = serviceBusiness.ServicePost<GROUP_EXPERT>(groupId, "Group", "GetExpertListByGrpId"); 
            return Json(groupList);
        }


        [HttpGet]
        public JsonResult GetSubCategoryByCategoryId(int categoryId)
        {
            var incidentSubCategoryList = serviceBusiness.ServicePost<List<PARAMETER>>("INCIDENT_SUB_CATEGORY", "Parameter", "GetParameterListByParameterTypeCode").Where(q => q.IS_ACTIVE == true && q.PARENT_PARAMETER_ID == categoryId).ToList(); 
            return Json(incidentSubCategoryList);
        }



        [HttpPost]
        public JsonResult UpdateIncidentStatus(INCIDENT_HISTORY incidentHistory)
        {
            var user = HttpContext.Session.GetObject<USER>("User");

            bool success = false;

            incidentHistory.UPDATED_USER_ID = user.USER_ID;

            success = serviceBusiness.ServicePost<bool>(incidentHistory, "Incident", "UpdateIncidentStatus");

            ShowSuccessToastMessage();
            return Json(new { success = success });
        }


        [HttpGet]
        public JsonResult GetIncident(int incidentId)
        {
            var incident = serviceBusiness.ServicePost<INCIDENT>(incidentId, "Incident", "GetIncident");
            return Json(incident);
        }



        public IActionResult IncidentDetail(int incidentId)
        {
            var incident = serviceBusiness.ServicePost<INCIDENT>(incidentId, "Incident", "GetIncident");
            IncidentDetailViewModel ivm = new IncidentDetailViewModel();
            ivm.incident = incident;

            var incidentHistoryList = serviceBusiness.ServicePost<List<INCIDENT_HISTORY>>(incidentId, "Incident", "GetHistoryListByIncidentIdVisibleToUser");
            ivm.IncidentHistoryList = incidentHistoryList;

            var incidentResolution = serviceBusiness.ServicePost<INCIDENT_RESOLUTION>(incidentId, "Incident", "GetResolutionByIncidentId"); 
            ivm.incidentResolution = incidentResolution;
            
            var priorityList = serviceBusiness.ServicePost<List<PARAMETER>>("INCIDENT_PRIORITY_USER", "Parameter", "GetParameterListByParameterTypeCode").Where(q => q.IS_ACTIVE == true).ToList();
            var serviceCatalogList = serviceBusiness.ServiceGet<List<SERVICECATALOG>>("ServiceCatalog", "ServiceCatalogGetList");
            var incidentUrgencyList = serviceBusiness.ServicePost<List<PARAMETER>>("INCIDENT_URGENCY", "Parameter", "GetParameterListByParameterTypeCode").Where(q => q.IS_ACTIVE == true).ToList();
            var incidentImpactList = serviceBusiness.ServicePost<List<PARAMETER>>("INCIDENT_IMPACT", "Parameter", "GetParameterListByParameterTypeCode").Where(q => q.IS_ACTIVE == true).ToList();
            var incidentStatusList = serviceBusiness.ServicePost<List<PARAMETER>>("STATUS", "Parameter", "GetParameterListByParameterTypeCode").Where(q => q.IS_ACTIVE == true).ToList();
            var incidentSourceList = serviceBusiness.ServicePost<List<PARAMETER>>("INCIDENT_SOURCE", "Parameter", "GetParameterListByParameterTypeCode").Where(q => q.IS_ACTIVE == true).ToList();
            var incidentTypeList = serviceBusiness.ServicePost<List<PARAMETER>>("INCIDENT_TYPE", "Parameter", "GetParameterListByParameterTypeCode").Where(q => q.IS_ACTIVE == true).ToList();

            var incidentCategoryList = serviceBusiness.ServicePost<List<PARAMETER>>("INCIDENT_CATEGORY", "Parameter", "GetParameterListByParameterTypeCode").Where(q => q.IS_ACTIVE == true).ToList();
            var incidentSubCategoryList = serviceBusiness.ServicePost<List<PARAMETER>>("INCIDENT_SUB_CATEGORY", "Parameter", "GetParameterListByParameterTypeCode").Where(q => q.IS_ACTIVE == true).ToList();
            if (incident.CATEGORY_ID != null)
            {
                incidentSubCategoryList = incidentSubCategoryList.Where(q => q.PARENT_PARAMETER_ID == incident.CATEGORY_ID).ToList();
            }

            var resolutionCodeList = serviceBusiness.ServicePost<List<PARAMETER>>("RESOLUTION_CODE", "Parameter", "GetParameterListByParameterTypeCode").Where(q => q.IS_ACTIVE == true).ToList();


            if (incident.ASSIGNED_GROUP_ID != null)
            {
                var groupExpertList = serviceBusiness.ServicePost<List<GROUP_EXPERT>>(Convert.ToInt32(incident.ASSIGNED_GROUP_ID), "Group", "GetExpertListByGrpId"); 
                foreach (var item in groupExpertList)
                {
                    ivm.UserList.Add(new SelectListItem()
                    {
                        Text = item.EXPERT_NAME,
                        Value = item.EXPERT_NAME_ID.ToString()
                    });
                }
            }
            else
            {
                var userList = serviceBusiness.ServiceGet<List<USER>>("User", "UserGetList");

                foreach (var item in userList)
                {
                    ivm.UserList.Add(new SelectListItem()
                    {
                        Text = item.NAME + " " + item.SURNAME,
                        Value = item.USER_ID.ToString()
                    });
                }
            }

            var userGroupList = serviceBusiness.ServiceGet<List<GROUP>>("Group", "GroupGetList");


            foreach (var item in priorityList)
            {
                ivm.IncidentPriorityList.Add(new SelectListItem()
                {
                    Text = item.MAIN_DATA_NAME,
                    Value = item.ID.ToString()
                });
            }


            foreach (var item in serviceCatalogList)
            {
                ivm.ServiceCatalogList.Add(new SelectListItem()
                {
                    Text = item.SERVICE_NAME,
                    Value = item.SERVICE_ID.ToString()
                });
            }


            foreach (var item in incidentUrgencyList)
            {
                ivm.IncidentUrgencyList.Add(new SelectListItem()
                {
                    Text = item.MAIN_DATA_NAME,
                    Value = item.ID.ToString()
                });
            }

            foreach (var item in incidentImpactList)
            {
                ivm.IncidentImpactList.Add(new SelectListItem()
                {
                    Text = item.MAIN_DATA_NAME,
                    Value = item.ID.ToString()
                });
            }

            foreach (var item in incidentStatusList)
            {
                ivm.IncidentStatusList.Add(new SelectListItem()
                {
                    Text = item.MAIN_DATA_NAME,
                    Value = item.ID.ToString()
                });
            }

            foreach (var item in incidentSourceList)
            {
                ivm.IncidentSourceList.Add(new SelectListItem()
                {
                    Text = item.MAIN_DATA_NAME,
                    Value = item.ID.ToString()
                });
            }

            foreach (var item in incidentTypeList)
            {
                ivm.IncidentTypeList.Add(new SelectListItem()
                {
                    Text = item.MAIN_DATA_NAME,
                    Value = item.ID.ToString()
                });
            }

            foreach (var item in incidentCategoryList)
            {
                ivm.CategoryList.Add(new SelectListItem()
                {
                    Text = item.MAIN_DATA_NAME,
                    Value = item.ID.ToString()
                });
            }
            foreach (var item in incidentSubCategoryList)
            {
                ivm.SubCategoryList.Add(new SelectListItem()
                {
                    Text = item.MAIN_DATA_NAME,
                    Value = item.ID.ToString()
                });
            }



            foreach (var item in userGroupList)
            {
                ivm.UserGroupList.Add(new SelectListItem()
                {
                    Text = item.GROUP_NAME,
                    Value = item.ID.ToString()
                });
            }


            foreach (var item in resolutionCodeList)
            {
                ivm.ResolutionCodeList.Add(new SelectListItem()
                {
                    Text = item.MAIN_DATA_NAME,
                    Value = item.ID.ToString()
                });
            }

            ivm.incident.CREATED_USER = serviceBusiness.ServicePost<USER>(ivm.incident.CREATED_USER_ID, "User", "GetUser");
            return View(ivm);
        }


        [HttpPost]
        public IActionResult IncidentDetail(IncidentDetailViewModel incidentDetailModel)
        {
            bool success = false;

            incidentDetailModel.incident.UPDATED_USER_ID = SessionUser.USER_ID;

            var getIncident = serviceBusiness.ServicePost<INCIDENT>(incidentDetailModel.incident.ID, "Incident", "GetIncident");

            if (getIncident.INCIDENT_STATUS_ID == 40 && !String.IsNullOrEmpty(incidentDetailModel.incident.DESCRIPTION))
            {
                getIncident.INCIDENT_STATUS_ID = 39;
                 serviceBusiness.ServicePost<bool>(getIncident, "Incident", "UpdateIncident");
            }

            INCIDENT_HISTORY history = new INCIDENT_HISTORY()
            {
                CREATED_DATE = DateTime.Now,
                //CREATED_USER_ID = SessionUser.USER_ID,
                DESCRIPTION = incidentDetailModel.incidentHistory.DESCRIPTION,
                INCIDENT_ID = incidentDetailModel.incident.ID,
                IS_DELETED = false,
                VISIBLE_TO_USER = true,
                VISIBLE_TO_OPERATOR = true
            };
            var successHistory = serviceBusiness.ServicePost<bool>(history, "Incident", "InsertIncidentHistory"); 

            if (successHistory)
            {
                ShowSuccessToastMessage();
            }
            else
            {
                ShowErrorToastMessage();
            }


            bool sonuc = false;
            var ruleList = serviceBusiness.ServiceGet<List<RULE>>("Rule", "RuleGetList").Where(q => q.RULE_ACTION_TYPE == 2).ToList();
            if (ruleList.Count > 0)
            {
                foreach (var item in ruleList)
                {
                    var ruleDetail = serviceBusiness.ServicePost<List<RULE_DETAIL>>(item.RULE_ID, "Rule", "GetRuleDetailByRuleId");
                    foreach (var detail in ruleDetail)
                    {
                        switch (detail.CRITERIA)
                        {
                            case "Konu":
                                if (detail.REQUIREMENT == "Like")
                                {
                                    if (incidentDetailModel.incident.SUBJECT.Contains(detail.VALUE))
                                    {
                                        if (detail.CONDITION == "Ve")
                                        {
                                            if (sonuc)
                                            {
                                                sonuc = true;
                                            }
                                            else
                                            {
                                                sonuc = false;
                                            }
                                        }
                                        else
                                        {
                                            sonuc = true;
                                        }
                                    }
                                    else
                                    {
                                        if (detail.CONDITION == "Ve")
                                        {
                                            sonuc = false;
                                        }
                                        else
                                        {
                                            if (sonuc)
                                            {
                                                sonuc = true;
                                            }
                                            else
                                            {
                                                sonuc = false;
                                            }
                                        }
                                    }
                                }
                                else if (detail.REQUIREMENT == "Contains")
                                {
                                    if (incidentDetailModel.incident.SUBJECT.Contains(detail.VALUE))
                                    {
                                        if (detail.CONDITION == "Ve")
                                        {
                                            if (sonuc)
                                            {
                                                sonuc = true;
                                            }
                                            else
                                            {
                                                sonuc = false;
                                            }
                                        }
                                        else
                                        {
                                            sonuc = true;
                                        }
                                    }
                                    else
                                    {
                                        if (detail.CONDITION == "Ve")
                                        {
                                            sonuc = false;
                                        }
                                        else
                                        {
                                            if (sonuc)
                                            {
                                                sonuc = true;
                                            }
                                            else
                                            {
                                                sonuc = false;
                                            }
                                        }
                                    }
                                }
                                else if (detail.REQUIREMENT == "Is")
                                {
                                    if (incidentDetailModel.incident.SUBJECT == detail.VALUE)
                                    {
                                        if (detail.CONDITION == "Ve")
                                        {
                                            if (sonuc)
                                            {
                                                sonuc = true;
                                            }
                                            else
                                            {
                                                sonuc = false;
                                            }
                                        }
                                        else
                                        {
                                            sonuc = true;
                                        }
                                    }
                                    else
                                    {
                                        if (detail.CONDITION == "Ve")
                                        {
                                            sonuc = false;
                                        }
                                        else
                                        {
                                            if (sonuc)
                                            {
                                                sonuc = true;
                                            }
                                            else
                                            {
                                                sonuc = false;
                                            }
                                        }
                                    }
                                }
                                break;
                            case "Atanan Grup":
                                if (incidentDetailModel.incident.ASSIGNED_GROUP_ID == Convert.ToInt32(detail.VALUE))
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                    else
                                    {
                                        sonuc = true;
                                    }
                                }
                                else
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        sonuc = false;
                                    }
                                    else
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                }
                                break;
                            case "Kullanıcı":
                                if (incidentDetailModel.incident.CREATED_USER_ID == Convert.ToInt32(detail.VALUE))
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                    else
                                    {
                                        sonuc = true;
                                    }
                                }
                                else
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        sonuc = false;
                                    }
                                    else
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                }
                                break;
                            case "Kullanıcı Departman":
                                var user = serviceBusiness.ServicePost<USER>(Convert.ToInt32(incidentDetailModel.incident.CREATED_USER_ID), "User", "GetUser");
                                if (Convert.ToInt32(user.DEPARTMENT_ID) == Convert.ToInt32(detail.VALUE))
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                    else
                                    {
                                        sonuc = true;
                                    }
                                }
                                else
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        sonuc = false;
                                    }
                                    else
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                }
                                break;
                            case "Kullanıcı Şirketi":
                                var ksUser = serviceBusiness.ServicePost<USER>(Convert.ToInt32(incidentDetailModel.incident.CREATED_USER_ID), "User", "GetUser");
                                if (ksUser.DEPARTMENT_ID != null)
                                {
                                    var ksDepartment = serviceBusiness.ServicePost<DEPARTMENT>(Convert.ToInt32(ksUser.DEPARTMENT_ID), "Department", "GetDepartment");
                                    if (Convert.ToInt32(ksDepartment.COMPANY_ID) == Convert.ToInt32(detail.VALUE))
                                    {
                                        if (detail.CONDITION == "Ve")
                                        {
                                            if (sonuc)
                                            {
                                                sonuc = true;
                                            }
                                            else
                                            {
                                                sonuc = false;
                                            }
                                        }
                                        else
                                        {
                                            sonuc = true;
                                        }
                                    }
                                    else
                                    {
                                        if (detail.CONDITION == "Ve")
                                        {
                                            sonuc = false;
                                        }
                                        else
                                        {
                                            if (sonuc)
                                            {
                                                sonuc = true;
                                            }
                                            else
                                            {
                                                sonuc = false;
                                            }
                                        }
                                    }
                                }
                                break;
                            case "Öncelik":
                                if (incidentDetailModel.incident.INCIDENT_PRIORITY_ID == Convert.ToInt32(detail.VALUE))
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                    else
                                    {
                                        sonuc = true;
                                    }
                                }
                                else
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        sonuc = false;
                                    }
                                    else
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                }
                                break;
                            case "Kategori":
                                if (incidentDetailModel.incident.CATEGORY_ID == Convert.ToInt32(detail.VALUE))
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                    else
                                    {
                                        sonuc = true;
                                    }
                                }
                                else
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        sonuc = false;
                                    }
                                    else
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                }
                                break;
                            case "Aciliyet":
                                if (incidentDetailModel.incident.INCIDENT_URGENCY_ID == Convert.ToInt32(detail.VALUE))
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                    else
                                    {
                                        sonuc = true;
                                    }
                                }
                                else
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        sonuc = false;
                                    }
                                    else
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                }
                                break;
                            case "Hizmet":
                                if (incidentDetailModel.incident.SERVICE_CATALOG_ID == Convert.ToInt32(detail.VALUE))
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                    else
                                    {
                                        sonuc = true;
                                    }
                                }
                                else
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        sonuc = false;
                                    }
                                    else
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                }
                                break;
                            case "Atanan Kişi":
                                if (incidentDetailModel.incident.ASSIGNED_USER_ID == Convert.ToInt32(detail.VALUE))
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                    else
                                    {
                                        sonuc = true;
                                    }
                                }
                                else
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        sonuc = false;
                                    }
                                    else
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                }
                                break;
                            case "Durum":
                                if (incidentDetailModel.incident.INCIDENT_STATUS_ID == Convert.ToInt32(detail.VALUE))
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                    else
                                    {
                                        sonuc = true;
                                    }
                                }
                                else
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        sonuc = false;
                                    }
                                    else
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                }
                                break;
                            case "Bildirim Kaynağı":
                                if (incidentDetailModel.incident.INCIDENT_SOURCE_ID == Convert.ToInt32(detail.VALUE))
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                    else
                                    {
                                        sonuc = true;
                                    }
                                }
                                else
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        sonuc = false;
                                    }
                                    else
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                }
                                break;
                            case "Etki":
                                if (incidentDetailModel.incident.INCIDENT_IMPACT_ID == Convert.ToInt32(detail.VALUE))
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                    else
                                    {
                                        sonuc = true;
                                    }
                                }
                                else
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        sonuc = false;
                                    }
                                    else
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                }
                                break;
                            case "Sorun Tipi":
                                if (incidentDetailModel.incident.INCIDENT_TYPE_ID == Convert.ToInt32(detail.VALUE))
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                    else
                                    {
                                        sonuc = true;
                                    }
                                }
                                else
                                {
                                    if (detail.CONDITION == "Ve")
                                    {
                                        sonuc = false;
                                    }
                                    else
                                    {
                                        if (sonuc)
                                        {
                                            sonuc = true;
                                        }
                                        else
                                        {
                                            sonuc = false;
                                        }
                                    }
                                }
                                break;
                            default:
                                if (detail.CONDITION == "Ve")
                                {
                                    sonuc = false;
                                }
                                break;
                        }
                    }

                    if (sonuc)
                    {
                        var incident =  serviceBusiness.ServicePost<INCIDENT>(incidentDetailModel.incident.ID, "Incident", "GetIncident");

                        switch (item.RULE_ACTION)
                        {
                            case "GROUP":
                                incident.ASSIGNED_GROUP_ID = Convert.ToInt32(item.RULE_ACTION_DATA);
                                break;
                            case "USER":
                                incident.ASSIGNED_USER_ID = Convert.ToInt32(item.RULE_ACTION_DATA);
                                break;
                            case "CATEGORY":
                                incident.CATEGORY_ID = Convert.ToInt32(item.RULE_ACTION_DATA);
                                break;
                            case "PRIORITY":
                                incident.INCIDENT_PRIORITY_ID = Convert.ToInt32(item.RULE_ACTION_DATA);
                                break;
                            case "TYPE":
                                break;
                            case "REQUIRED":
                                break;
                            default:
                                break;
                        }

                        serviceBusiness.ServicePost<bool>(incident, "Incident", "UpdateIncident");
                    }


                }
            }


            return RedirectToAction("IncidentDetail", "Support", new { incidentId = incidentDetailModel.incident.ID });
        }


        [HttpGet]
        public JsonResult IncidentConfirmAndClose(int incidentId)
        {
            bool success = false;
            var userId = SessionUser.USER_ID;

            var incident = serviceBusiness.ServicePost<INCIDENT>(incidentId, "Incident", "GetIncident");
            if (incident.INCIDENT_STATUS_ID != 4)
            {
                return Json(new { success = success, message = "Arızanın durumu \"Çözüldü\" olmadığı için işlemi gerçekleştiremezsiniz." });
            }

            success = serviceBusiness.ServicePost<bool>((incidentId, userId), "Incident", "IncidentConfirmAndClose");
            ShowSuccessToastMessage();

            return Json(new { success = success });
        }


        [HttpGet]
        public JsonResult IncidentReject(int incidentId)
        {
            bool success = false;
            var userId = SessionUser.USER_ID;

            var incident = serviceBusiness.ServicePost<INCIDENT>(incidentId, "Incident", "GetIncident");
            if (incident.INCIDENT_STATUS_ID != 4)
            {
                return Json(new { success = success, message = "Arızanın durumu \"Çözüldü\" olmadığı için işlemi gerçekleştiremezsiniz." });
            }

            success = serviceBusiness.ServicePost<bool>((incidentId, userId), "Incident", "IncidentReject");

            ShowSuccessToastMessage();
            return Json(new { success = success });
        }

    }
}