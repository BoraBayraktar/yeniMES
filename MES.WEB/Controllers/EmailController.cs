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
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace MES.Web.Controllers
{
    public class EmailController : BaseController
    {
        #region Instance
        ServiceBusiness serviceBusiness;
        //UserLogic userLogic = new UserLogic();
        //UserGroupLogic userGroupLogic = new UserGroupLogic();
        //EmailTemplateLogic emailTemplateLogic = new EmailTemplateLogic();
        //ParameterLogic parameterLogic = new ParameterLogic();
        //MainProcessLogic mainProcessLogic = new MainProcessLogic();
        #endregion
        public EmailController(IConfiguration configuration, IHttpContextAccessor accessor)
        {
            serviceBusiness = new ServiceBusiness(configuration, accessor);
        }
        #region EmailTemplate
        public IActionResult EmailTemplate()
        {
            var templateList = serviceBusiness.ServiceGet<List<EMAIL_TEMPLATE>>("EmailTemplate", "EmailTemplateGetList");
            EmailTemplateViewModel evm = new EmailTemplateViewModel();
            evm.EmailTemplateList = templateList;

            foreach (var item in evm.EmailTemplateList)
            {
                item.Recipients = "";

                if (item.TO_CREATED_USER == true)
                {
                    item.Recipients += "Created User, ";
                }
                if (item.TO_ASSIGNED_USER == true)
                {
                    item.Recipients += "Assigned User, ";
                }
                if (item.TO_ASSIGNED_GROUP_USER == true)
                {
                    item.Recipients += "Assigned Group User, ";
                }

                if (!String.IsNullOrEmpty(item.TO_USERS))
                {
                    string[] users = item.TO_USERS.Split(',');
                    foreach (var itemUser in users)
                    {
                        var user = serviceBusiness.ServicePost<USER>(Convert.ToInt32(itemUser), "User", "GetUser");
                        item.Recipients += user.NAME + " " + user.SURNAME + ", ";
                    }
                }

                if (!String.IsNullOrEmpty(item.TO_GROUPS))
                {
                    string[] groups = item.TO_GROUPS.Split(',');
                    foreach (var itemGroup in groups)
                    {
                        var group = serviceBusiness.ServicePost<USER_GROUP>(Convert.ToInt32(itemGroup), "UserGroup", "GetUserGroup");
                        item.Recipients += group.NAME + ", ";
                    }
                }

                if (item.Recipients.Length > 2)
                {
                    item.Recipients = item.Recipients.Substring(0, item.Recipients.Length - 2);
                }
            }


            return View(evm);
        }

        public IActionResult CreateOrEditEmailTemplate(int? id)
        {
            var evm = new EmailTemplateViewModel();
            var userList = serviceBusiness.ServicePost<List<USER>>(id, "User", "UserGetList");
            var userGroupList = serviceBusiness.ServiceGet<List<USER_GROUP>>("UserGroup", "UserGroupGetList");
            //var parameterList = emailTemplateLogic.GetParameterList();
            var mainProcessList = serviceBusiness.ServiceGet<List<MAIN_PROCESS>>("MainProcess", "MainProcessGetList");



            if (id != null)
            {
                evm.EmailTemplate = serviceBusiness.ServicePost<EMAIL_TEMPLATE>(Convert.ToInt32(id), "EmailTemplate", "GetEmailTemplate");

                if (!String.IsNullOrEmpty(evm.EmailTemplate.TO_USERS))
                {
                    evm.SelectedUsers = evm.EmailTemplate.TO_USERS.Split(',');
                }
                if (!String.IsNullOrEmpty(evm.EmailTemplate.TO_GROUPS))
                {
                    evm.SelectedGroups = evm.EmailTemplate.TO_GROUPS.Split(',');
                }

                string recipients = "";

                if (evm.EmailTemplate.TO_CREATED_USER == true)
                {
                    recipients += "1,";
                }
                if (evm.EmailTemplate.TO_ASSIGNED_USER == true)
                {
                    recipients += "2,";
                }
                if (evm.EmailTemplate.TO_ASSIGNED_GROUP_USER == true)
                {
                    recipients += "3,";
                }

                if (!String.IsNullOrEmpty(evm.EmailTemplate.TO_USERS))
                {
                    recipients += "4,";
                }
                if (!String.IsNullOrEmpty(evm.EmailTemplate.TO_GROUPS))
                {
                    recipients += "5,";
                }
                evm.SelectedRecipients = recipients.Split(',');


                var mainProcessStatusList = serviceBusiness.ServicePost<List<PARAMETER>>(("STATUS", evm.EmailTemplate.MAIN_PROCESS_ID), "Parameter", "GetParameterListByParameterTypeCode");

                foreach (var item in mainProcessStatusList)
                {
                    evm.MainProcessStatusList.Add(new SelectListItem()
                    {
                        Text = item.MAIN_DATA_NAME,
                        Value = item.ID.ToString()
                    });
                }


                var parameterList = serviceBusiness.ServicePost<List<PARAMETER>>(evm.EmailTemplate.MAIN_PROCESS_ID, "Parameter", "GetParameterTypeByMainProcessId");

                foreach (var item in parameterList)
                {
                    evm.ParameterList.Add(new SelectListItem()
                    {
                        Text = item.MAIN_DATA_NAME,
                        Value = item.ID.ToString()
                    });
                }

            }

            foreach (var item in userList)
            {
                evm.UserList.Add(new SelectListItem()
                {
                    Text = item.NAME,
                    Value = item.USER_ID.ToString()
                });
            }

            foreach (var item in userGroupList)
            {
                evm.UserGroupList.Add(new SelectListItem()
                {
                    Text = item.NAME,
                    Value = item.USER_GROUP_ID.ToString()
                });
            }

            //foreach (var item in parameterList)
            //{
            //    evm.ParameterList.Add(new SelectListItem()
            //    {
            //        Text = item.PARAMETER,
            //        Value = item.ID.ToString()
            //    });
            //}

            foreach (var item in mainProcessList)
            {
                evm.MainProcessList.Add(new SelectListItem()
                {
                    Text = item.NAME,
                    Value = item.ID.ToString()
                });
            }


            return View(evm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateOrEditEmailTemplate(int? id, EmailTemplateViewModel templateModel)
        {
            var user = HttpContext.Session.GetObject<USER>("User");

            bool success = false;

            EMAIL_TEMPLATE template = new EMAIL_TEMPLATE();
            template.NAME = templateModel.EmailTemplate.NAME;
            int i = 1;

            if (templateModel.SelectedUsers != null)
            {
                int userCount = templateModel.SelectedUsers.Length;
                foreach (var item in templateModel.SelectedUsers)
                {
                    template.TO_USERS += item;
                    if (i != userCount)
                    {
                        template.TO_USERS += ",";
                    }
                    i++;
                }
            }

            if (templateModel.SelectedGroups != null)
            {
                int groupCount = templateModel.SelectedGroups.Length;

                i = 1;
                foreach (var item in templateModel.SelectedGroups)
                {
                    template.TO_GROUPS += item;
                    if (i != groupCount)
                    {
                        template.TO_GROUPS += ",";
                    }
                    i++;
                }
            }

            if (templateModel.SelectedRecipients != null)
            {
                foreach (var item in templateModel.SelectedRecipients)
                {
                    if (item == "1")
                    {
                        template.TO_CREATED_USER = true;
                    }
                    else if (item == "2")
                    {
                        template.TO_ASSIGNED_USER = true;
                    }
                    else if (item == "3")
                    {
                        template.TO_ASSIGNED_GROUP_USER = true;
                    }
                }
            }



            template.SUBJECT = templateModel.EmailTemplate.SUBJECT;
            template.BODY = templateModel.EmailTemplate.BODY;

            template.MAIN_PROCESS_ID = templateModel.EmailTemplate.MAIN_PROCESS_ID;
            template.MAIN_PROCESS_STATUS_ID = templateModel.EmailTemplate.MAIN_PROCESS_STATUS_ID;


            //if (id == null)
            //{
            //    template.CREATED_USER_ID = user.USER_ID;
            //    success = emailTemplateLogic.InsertEmailTemplate(template);
            //}
            //else
            //{
            //    template.ID = Convert.ToInt32(id);
            //    template.UPDATED_USER_ID = user.USER_ID;
            //    success = emailTemplateLogic.UpdateEmailTemplate(template);
            //}

            ShowSuccessToastMessage();
            return RedirectToAction("EmailTemplate", "Email");
        }


        [HttpPost]
        public JsonResult DeleteEmailTemplate(int deleteId)
        {
            bool success = false;
            success = serviceBusiness.ServicePost<bool>(deleteId, "EmailTemplate", "DeleteEmailTemplate"); 
            return Json(new { success = success });
        }
        #endregion

        #region Parameter
        public IActionResult Parameter()
        {
            var parameterList = serviceBusiness.ServiceGet<List<PARAMETER>>("Parameter", "ParameterGetList");
            var mainProcessList = serviceBusiness.ServiceGet<List<MAIN_PROCESS>>("MainProcess", "MainProcessGetList"); 
            var parameterTypeList = serviceBusiness.ServiceGet<List<PARAMETER_TYPE>>("Parameter", "ParameterTypeGetList");

            var pvm = new ParameterViewModel();

            pvm.ParameterList = parameterList;
            foreach (var item in mainProcessList)
            {
                pvm.MainProcessSelectList.Add(new SelectListItem()
                {
                    Text = item.NAME,
                    Value = item.ID.ToString()
                });
            }

            foreach (var item in parameterTypeList)
            {
                pvm.ParameterTypeSelectList.Add(new SelectListItem()
                {
                    Text = item.TYPE_NAME,
                    Value = item.PARAMETER_TYPE_ID.ToString()
                });
            }

            foreach (var item in parameterList)
            {
                pvm.ParameterSelectList.Add(new SelectListItem()
                {
                    Text = item.MAIN_DATA_NAME,
                    Value = item.ID.ToString()
                });
            }

            return View(pvm);

        }
        [HttpPost]
        public JsonResult CreateOrEditParameter(int? id, PARAMETER parameter)
        {
            var user = HttpContext.Session.GetObject<USER>("User");

            bool success = false;
            if (id == null)
            {
                //parameter.CREATED_USER_ID = user.USER_ID;
                success = serviceBusiness.ServicePost<bool>(parameter, "Parameter", "InsertParameter");
            }
            else
            {
                parameter.ID = Convert.ToInt32(id);
                //parameter.UPDATED_USER_ID = user.USER_ID;
                success = serviceBusiness.ServicePost<bool>(parameter, "Parameter", "UpdateParameter"); 
            }
            return Json(new { success = success });
        }
        [HttpPost]
        public JsonResult DeleteParameter(int deleteId)
        {
            bool success = false;
            success = serviceBusiness.ServicePost<bool>(deleteId, "Parameter", "DeleteEmailTemplate");
            return Json(new { success = success });
        }

        public JsonResult GetParameter(int id)
        {
            var parameter = serviceBusiness.ServicePost<PARAMETER>(id, "Parameter", "GetParameter"); 
            return Json(parameter);
        }
        #endregion

        #region MainProcessId
        [HttpGet]
        public JsonResult GetParameterStatusByMainProcessId(int mainProcessId)
        {
            var parameterStatusList = serviceBusiness.ServicePost<List<PARAMETER>>(("STATUS",mainProcessId), "Parameter", "GetParameterListByParameterTypeCodeMainProcessId");
            foreach (var item in parameterStatusList)
            {
                item.PARAMETER_TYPE = null;
            }
            return Json(parameterStatusList);
        }

        [HttpGet]
        public JsonResult GetParameterTypeByMainProcessId(int mainProcessId)
        {
            var parameterTypeList = serviceBusiness.ServicePost<List<PARAMETER>>(mainProcessId, "Parameter", "GetParameterByMainProcessId"); 
            return Json(parameterTypeList);
        }

        [HttpGet]
        public JsonResult GetParameterByMainProcessId(int mainProcessId, int? parameterTypeId)
        {
            var parameterList = serviceBusiness.ServicePost<List<PARAMETER>>(mainProcessId, "Parameter", "GetParameterByMainProcessId");
            if (parameterTypeId != null)
            {
                parameterList = parameterList.Where(q => q.PARAMETER_TYPE_ID != parameterTypeId).ToList();
            }
            return Json(parameterList);
        }


        [HttpGet]
        public JsonResult GetEmailTemplateParametersByMainProcessId(int mainProcessId)
        {
            var parameterList = serviceBusiness.ServicePost<List<EMAIL_TEMPLATE_PARAMETERS>>(mainProcessId, "EmailTemplate", "GetEmailTemplateParametersByMainProcessId");
            return Json(parameterList);
        }
#endregion
    }
}
