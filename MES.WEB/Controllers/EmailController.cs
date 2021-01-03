//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using MES.Business;
//using MES.Web.Model;
//using MES.Web.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.Extensions.Caching.Memory;


//namespace MES.Web.Controllers
//{
//    public class EmailController : BaseController
//    {
//        #region Instance
//        //UserLogic userLogic = new UserLogic();
//        //UserGroupLogic userGroupLogic = new UserGroupLogic();
//        //EmailTemplateLogic emailTemplateLogic = new EmailTemplateLogic();
//        //ParameterLogic parameterLogic = new ParameterLogic();
//        //MainProcessLogic mainProcessLogic = new MainProcessLogic();

//        #endregion

//        #region EmailTemplate
//        public IActionResult EmailTemplate()
//        {
//            var templateList = emailTemplateLogic.GetList();
//            EmailTemplateViewModel evm = new EmailTemplateViewModel();
//            evm.EmailTemplateList = templateList;

//            foreach (var item in evm.EmailTemplateList)
//            {
//                item.Recipients = "";

//                if (item.TO_CREATED_USER == true)
//                {
//                    item.Recipients += "Created User, ";
//                }
//                if (item.TO_ASSIGNED_USER == true)
//                {
//                    item.Recipients += "Assigned User, ";
//                }
//                if (item.TO_ASSIGNED_GROUP_USER == true)
//                {
//                    item.Recipients += "Assigned Group User, ";
//                }

//                if (!String.IsNullOrEmpty(item.TO_USERS))
//                {
//                    string[] users = item.TO_USERS.Split(',');
//                    foreach (var itemUser in users)
//                    {
//                        var user = userLogic.GetUser(Convert.ToInt32(itemUser));
//                        item.Recipients += user.NAME + " " + user.SURNAME + ", ";
//                    }
//                }

//                if (!String.IsNullOrEmpty(item.TO_GROUPS))
//                {
//                    string[] groups = item.TO_GROUPS.Split(',');
//                    foreach (var itemGroup in groups)
//                    {
//                        var group = userGroupLogic.GetUserGroup(Convert.ToInt32(itemGroup));
//                        item.Recipients += group.NAME + ", ";
//                    }
//                }

//                if (item.Recipients.Length > 2)
//                {
//                    item.Recipients = item.Recipients.Substring(0, item.Recipients.Length - 2);
//                }
//            }


//            return View(evm);
//        }

//        public IActionResult CreateOrEditEmailTemplate(int? id)
//        {
//            var evm = new EmailTemplateViewModel();
//            var userList = userLogic.GetList();
//            var userGroupList = userGroupLogic.GetList();
//            //var parameterList = emailTemplateLogic.GetParameterList();
//            var mainProcessList = mainProcessLogic.GetList();



//            if (id != null)
//            {
//                evm.EmailTemplate = emailTemplateLogic.GetEmailTemplate(Convert.ToInt32(id));

//                if (!String.IsNullOrEmpty(evm.EmailTemplate.TO_USERS))
//                {
//                    evm.SelectedUsers = evm.EmailTemplate.TO_USERS.Split(',');
//                }
//                if (!String.IsNullOrEmpty(evm.EmailTemplate.TO_GROUPS))
//                {
//                    evm.SelectedGroups = evm.EmailTemplate.TO_GROUPS.Split(',');
//                }

//                string recipients = "";

//                if (evm.EmailTemplate.TO_CREATED_USER == true)
//                {
//                    recipients += "1,";
//                }
//                if (evm.EmailTemplate.TO_ASSIGNED_USER == true)
//                {
//                    recipients += "2,";
//                }
//                if (evm.EmailTemplate.TO_ASSIGNED_GROUP_USER == true)
//                {
//                    recipients += "3,";
//                }

//                if (!String.IsNullOrEmpty(evm.EmailTemplate.TO_USERS))
//                {
//                    recipients += "4,";
//                }
//                if (!String.IsNullOrEmpty(evm.EmailTemplate.TO_GROUPS))
//                {
//                    recipients += "5,";
//                }
//                evm.SelectedRecipients = recipients.Split(',');


//                var mainProcessStatusList = parameterLogic.GetParameterListByParameterTypeCode("STATUS", evm.EmailTemplate.MAIN_PROCESS_ID);
//                foreach (var item in mainProcessStatusList)
//                {
//                    evm.MainProcessStatusList.Add(new SelectListItem()
//                    {
//                        Text = item.MAIN_DATA_NAME,
//                        Value = item.ID.ToString()
//                    });
//                }


//                var parameterList = emailTemplateLogic.GetEmailTemplateParametersByMainProcessId(evm.EmailTemplate.MAIN_PROCESS_ID);
//                foreach (var item in parameterList)
//                {
//                    evm.ParameterList.Add(new SelectListItem()
//                    {
//                        Text = item.PARAMETER,
//                        Value = item.ID.ToString()
//                    });
//                }

//            }

//            foreach (var item in userList)
//            {
//                evm.UserList.Add(new SelectListItem()
//                {
//                    Text = item.NAME,
//                    Value = item.USER_ID.ToString()
//                });
//            }

//            foreach (var item in userGroupList)
//            {
//                evm.UserGroupList.Add(new SelectListItem()
//                {
//                    Text = item.NAME,
//                    Value = item.USER_GROUP_ID.ToString()
//                });
//            }

//            //foreach (var item in parameterList)
//            //{
//            //    evm.ParameterList.Add(new SelectListItem()
//            //    {
//            //        Text = item.PARAMETER,
//            //        Value = item.ID.ToString()
//            //    });
//            //}

//            foreach (var item in mainProcessList)
//            {
//                evm.MainProcessList.Add(new SelectListItem()
//                {
//                    Text = item.NAME,
//                    Value = item.ID.ToString()
//                });
//            }


//            return View(evm);
//        }


//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult CreateOrEditEmailTemplate(int? id, EmailTemplateViewModel templateModel)
//        {
//            var user = HttpContext.Session.GetObject<USER>("User");

//            bool success = false;

//            EMAIL_TEMPLATE template = new EMAIL_TEMPLATE();
//            template.NAME = templateModel.EmailTemplate.NAME;
//            int i = 1;

//            if (templateModel.SelectedUsers != null)
//            {
//                int userCount = templateModel.SelectedUsers.Length;
//                foreach (var item in templateModel.SelectedUsers)
//                {
//                    template.TO_USERS += item;
//                    if (i != userCount)
//                    {
//                        template.TO_USERS += ",";
//                    }
//                    i++;
//                }
//            }

//            if (templateModel.SelectedGroups != null)
//            {
//                int groupCount = templateModel.SelectedGroups.Length;

//                i = 1;
//                foreach (var item in templateModel.SelectedGroups)
//                {
//                    template.TO_GROUPS += item;
//                    if (i != groupCount)
//                    {
//                        template.TO_GROUPS += ",";
//                    }
//                    i++;
//                }
//            }

//            if (templateModel.SelectedRecipients != null)
//            {
//                foreach (var item in templateModel.SelectedRecipients)
//                {
//                    if (item == "1")
//                    {
//                        template.TO_CREATED_USER = true;
//                    }
//                    else if (item == "2")
//                    {
//                        template.TO_ASSIGNED_USER = true;
//                    }
//                    else if (item == "3")
//                    {
//                        template.TO_ASSIGNED_GROUP_USER = true;
//                    }
//                }
//            }



//            template.SUBJECT = templateModel.EmailTemplate.SUBJECT;
//            template.BODY = templateModel.EmailTemplate.BODY;

//            template.MAIN_PROCESS_ID = templateModel.EmailTemplate.MAIN_PROCESS_ID;
//            template.MAIN_PROCESS_STATUS_ID = templateModel.EmailTemplate.MAIN_PROCESS_STATUS_ID;


//            if (id == null)
//            {
//                template.CREATED_USER_ID = user.USER_ID;
//                success = emailTemplateLogic.InsertEmailTemplate(template);
//            }
//            else
//            {
//                template.ID = Convert.ToInt32(id);
//                template.UPDATED_USER_ID = user.USER_ID;
//                success = emailTemplateLogic.UpdateEmailTemplate(template);
//            }

//            ShowSuccessToastMessage();
//            return RedirectToAction("EmailTemplate", "Email");
//        }


//        [HttpPost]
//        public JsonResult DeleteEmailTemplate(int deleteId)
//        {
//            bool success = false;
//            success = emailTemplateLogic.DeleteEmailTemplate(deleteId);
//            return Json(new { success = success });
//        }
//        #endregion

//        #region Parameter
//        public IActionResult Parameter()
//        {
//            var parameterList = parameterLogic.GetList();
//            var mainProcessList = mainProcessLogic.GetList();
//            var parameterTypeList = parameterLogic.GetParameterTypeList();

//            var pvm = new ParameterViewModel();

//            pvm.ParameterList = parameterList;
//            foreach (var item in mainProcessList)
//            {
//                pvm.MainProcessSelectList.Add(new SelectListItem()
//                {
//                    Text = item.NAME,
//                    Value = item.ID.ToString()
//                });
//            }

//            foreach (var item in parameterTypeList)
//            {
//                pvm.ParameterTypeSelectList.Add(new SelectListItem()
//                {
//                    Text = item.TYPE_NAME,
//                    Value = item.PARAMETER_TYPE_ID.ToString()
//                });
//            }

//            foreach (var item in parameterList)
//            {
//                pvm.ParameterSelectList.Add(new SelectListItem()
//                {
//                    Text = item.MAIN_DATA_NAME,
//                    Value = item.ID.ToString()
//                });
//            }

//            return View(pvm);

//        }
//        [HttpPost]
//        public JsonResult CreateOrEditParameter(int? id, PARAMETER parameter)
//        {
//            var user = HttpContext.Session.GetObject<USER>("User");

//            bool success = false;
//            if (id == null)
//            {
//                parameter.CREATED_USER_ID = user.USER_ID;
//                success = parameterLogic.InsertParameter(parameter);
//            }
//            else
//            {
//                parameter.ID = Convert.ToInt32(id);
//                parameter.UPDATED_USER_ID = user.USER_ID;
//                success = parameterLogic.UpdateParameter(parameter);
//            }
//            return Json(new { success = success });
//        }
//        [HttpPost]
//        public JsonResult DeleteParameter(int deleteId)
//        {
//            bool success = false;
//            success = parameterLogic.DeleteParameter(deleteId);
//            return Json(new { success = success });
//        }

//        public JsonResult GetParameter(int id)
//        {
//            var parameter = parameterLogic.GetParameter(id);
//            return Json(parameter);
//        }
//        #endregion


//        [HttpGet]
//        public JsonResult GetParameterStatusByMainProcessId(int mainProcessId)
//        {
//            var parameterStatusList = parameterLogic.GetParameterListByParameterTypeCode("STATUS", mainProcessId);
//            foreach (var item in parameterStatusList)
//            {
//                item.PARAMETER_TYPE = null;
//            }
//            return Json(parameterStatusList);
//        }

//        [HttpGet]
//        public JsonResult GetParameterTypeByMainProcessId(int mainProcessId)
//        {
//            var parameterTypeList = parameterLogic.GetParameterTypeByMainProcessId(mainProcessId);
//            return Json(parameterTypeList);
//        }

//        [HttpGet]
//        public JsonResult GetParameterByMainProcessId(int mainProcessId, int? parameterTypeId)
//        {
//            var parameterList = parameterLogic.GetParameterByMainProcessId(mainProcessId);
//            if (parameterTypeId != null)
//            {
//                parameterList = parameterList.Where(q => q.PARAMETER_TYPE_ID != parameterTypeId).ToList();
//            }
//            return Json(parameterList);
//        }


//        [HttpGet]
//        public JsonResult GetEmailTemplateParametersByMainProcessId(int mainProcessId)
//        {
//            var parameterList = emailTemplateLogic.GetEmailTemplateParametersByMainProcessId(mainProcessId);
//            return Json(parameterList);
//        }

//    }
//}