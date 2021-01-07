//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;
//using MES.Web.Models;
//using MES.Entities.Model;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using MES.Business;
//using MES.Entities;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//using System.Reflection.Metadata;

//namespace MES.Web.Controllers
//{
//    public class KnowledgeController: BaseController
//    {
//        KnowledgeLogic knowledgeLogic = new KnowledgeLogic();
//        UserLogic userLogic = new UserLogic();
//        MainProcessLogic mainProcessLogic = new MainProcessLogic();
//        MesContext context = new MesContext();

//        private IHostingEnvironment _hostingEnvironment;
       

//        public KnowledgeController(IHostingEnvironment environment)
//        {
//            _hostingEnvironment = environment;

//        }
//        public IActionResult KnowledgeList()
//        {
//            var user = HttpContext.Session.GetObject<USER>("User");

//            var knowledgeList = knowledgeLogic.GetList(user.USER_ID);  
//            KnowledgeViewModel kvm = new KnowledgeViewModel();
//            kvm.knowledgeList = knowledgeList;            

//            return View(kvm);
//        }
//        public IActionResult Knowledge(int? id)
//        {
//            var user = HttpContext.Session.GetObject<USER>("User");
//            var knowledgeList = knowledgeLogic.GetList(user.USER_ID);
//            var userList = userLogic.GetList();
//            var prmCategoryList = knowledgeLogic.GetKnowledgeCategory("KNWLEDGECATEGORY");
//            var prmStatusList = knowledgeLogic.GetKnowledgeStatus("KNWLEDGESTATUS");
//            var serviceList = knowledgeLogic.GetServiceCatalog();
//            var knowledgeNo = knowledgeLogic.KnowledgeNo(false);

//            KnowledgeViewModel kvm = new KnowledgeViewModel();
//            kvm.knowledge = new KNOWLEDGE_MANAGEMENT();
//            kvm.knowledge.KNOWLEDGE_NO = knowledgeNo;
//            if (id != null)
//            {
//                var sc1 = knowledgeLogic.GetKnowledge(Convert.ToInt32(id));
//                kvm.knowledge = sc1;
//            }
//            foreach (var item in userList)
//            {
//                kvm.UserList.Add(new SelectListItem()
//                {
//                    Text = item.NAME + " " + item.SURNAME,
//                    Value = item.USER_ID.ToString()
//                });
//            }
//            foreach (var item in prmCategoryList)
//            {
//                kvm.PrmKnowledgeCategoryList.Add(new SelectListItem()
//                {
//                    Text = item.MAIN_DATA_NAME,
//                    Value = item.ID.ToString()
//                });
//            }
//            foreach (var item in serviceList)
//            {
//                kvm.ServiceCalalogList.Add(new SelectListItem()
//                {
//                    Text = item.SERVICE_NAME,
//                    Value = item.SERVICE_ID.ToString()
//                });
//            }
//            foreach (var item in prmStatusList)
//            {
//                kvm.PrmKnowledgeStatusList.Add(new SelectListItem()
//                {
//                    Text = item.MAIN_DATA_NAME,
//                    Value = item.ID.ToString()
//                });
//            }

//            var fileList = knowledgeLogic.GetFileList(Convert.ToInt32(id));
//            kvm.FileList = fileList;

//            return View(kvm);
//        }
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Knowledge(int? id, KnowledgeViewModel knowledgeViewModel, IFormFile knowledgeFiles)
//        {
//            var user = HttpContext.Session.GetObject<USER>("User");

//            KNOWLEDGE_MANAGEMENT knowledge = new KNOWLEDGE_MANAGEMENT();
//            knowledge.KNOWLEDGE_NO = knowledgeViewModel.knowledge.KNOWLEDGE_NO;
//            knowledge.KNOWLEDGE_ISACTIVE = knowledgeViewModel.knowledge.KNOWLEDGE_ISACTIVE;
//            knowledge.KNOWLEDGE_SERVICE_ID = knowledgeViewModel.knowledge.KNOWLEDGE_SERVICE_ID;
//            knowledge.KNOWLEDGE_CATEGORY_ID = knowledgeViewModel.knowledge.KNOWLEDGE_CATEGORY_ID;
//            knowledge.KNOWLEDGE_STATUS_ID = knowledgeViewModel.knowledge.KNOWLEDGE_STATUS_ID;
//            knowledge.SUBJECT = knowledgeViewModel.knowledge.SUBJECT;
//            knowledge.KNOWLEDGE_DESCRIPTION = knowledgeViewModel.knowledge.KNOWLEDGE_DESCRIPTION;


//            bool success;
//            string localFileName = "";
//            KNOWLEDGE_FILES _knowledgeFiles = new KNOWLEDGE_FILES();

//            if (knowledgeFiles != null)
//            {
//                localFileName = knowledgeFiles.FileName;
//                var uploads = Path.Combine(_hostingEnvironment.ContentRootPath, @"Content/images/knowledge");
//                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(knowledgeFiles.FileName);
//                var filePath = Path.Combine(uploads, fileName);
//                using (var fileStream = new FileStream(filePath, FileMode.Create))
//                {
//                    knowledgeFiles.CopyTo(fileStream);
//                }
//                _knowledgeFiles.FILE_PATH = "/Content/images/knowledge/" + fileName;
//            }


//            if (id == null)
//            {
//                knowledge.CREATED_USER_ID = user.USER_ID;
//                success = knowledgeLogic.InsertKnowledge(knowledge);
//            }
//            else
//            {
//                knowledge.ID = Convert.ToInt32(id);
//                knowledge.UPDATED_USER_ID = user.USER_ID;
//                success = knowledgeLogic.UpdateKnowledge(knowledge);
//            }

//            var userList = userLogic.GetList();
//            KnowledgeViewModel kvm = new KnowledgeViewModel();

//            foreach (var item in userList)
//            {
//                kvm.UserList.Add(new SelectListItem()
//                {
//                    Text = item.NAME + " " + item.SURNAME,
//                    Value = item.USER_ID.ToString()
//                });
//            }
//            if (success)
//            {
//                if (!String.IsNullOrEmpty(_knowledgeFiles.FILE_PATH))
//                {
//                    _knowledgeFiles.CREATED_USER_ID = user.USER_ID;
//                    _knowledgeFiles.KNOWLEDGE_ID = knowledge.ID;
//                    _knowledgeFiles.FILE_NAME = localFileName;
//                    var successFile = knowledgeLogic.InsertKnowledgeFiles(_knowledgeFiles);
//                    if (successFile)
//                    {
//                        ShowSuccessToastMessage();
//                    }
//                    else
//                    {
//                        ShowErrorToastMessage();
//                    }
//                }
//            }

//            ShowSuccessToastMessage();

//           return RedirectToAction("KnowledgeList", "Knowledge");            
//        }
//        [HttpPost]
//        public JsonResult CreateOrEditKnowledge(int? id, KnowledgeViewModel knowledgeViewModel)
//        {
//            var user = HttpContext.Session.GetObject<USER>("User");

//            bool success = false;

//            KNOWLEDGE_MANAGEMENT know = new KNOWLEDGE_MANAGEMENT();

//            know.KNOWLEDGE_ISACTIVE = knowledgeViewModel.knowledge.KNOWLEDGE_ISACTIVE;

//            if (id == null)
//            {
//                know.CREATED_USER_ID = user.USER_ID;
//                success = knowledgeLogic.InsertKnowledge(know);
//            }
//            else
//            {
//                know.ID = Convert.ToInt32(id);
//                know.UPDATED_USER_ID = user.USER_ID;
//                success = knowledgeLogic.UpdateKnowledge(know);
//            }
//            return Json(new { success = success });
//        }
//        [HttpPost]
//        public JsonResult DeleteKnowledge(int deleteId)
//        {
//            bool success = false;
//            success = knowledgeLogic.DeleteKnowledge(deleteId);
//            return Json(new { success = success });
//        }
//        public JsonResult GetKnowledge(int id)
//        {
//            var know = knowledgeLogic.GetKnowledge(id);
//            return Json(know);
//        }
//        [HttpPost]
//        public JsonResult DeleteKnowledgeFiles(int deleteId)
//        {
//            bool success = false;
//            success = knowledgeLogic.DeleteKnowledgeFiles(deleteId);
//            return Json(new { success = success });
//        }
//    }
//}
