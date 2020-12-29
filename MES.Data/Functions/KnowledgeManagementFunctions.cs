using MES.Data.Interfaces;
using MES.DB;
using MES.DB.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MES.Data.Functions
{
    public class KnowledgeFunctions : IKnowledge
    {
        public List<KNOWLEDGE_MANAGEMENT> GetList(int userID)
        {
            using (MesContext context = new MesContext())
            {
                var statusID = context.KNOWLEDGE_SETTINGS.FirstOrDefault(q => q.WHICH_STATUS_IN_VISIBLE > 0 && q.IS_DELETED == false).WHICH_STATUS_IN_VISIBLE;

                    var knowledgeList = context.KNOWLEDGE_MANAGEMENT.Include(q => q.CREATED_USER)
                                                                         .Include(q => q.CATEGORY_MODEL)
                                                                         .Include(q => q.SERVICE_MODEL)
                                                                         .Include(q => q.STATUS_MODEL)
                                                                         .Where(q => q.IS_DELETED == false)
                                                                         .Where(q => q.CREATED_USER_ID == userID || q.KNOWLEDGE_STATUS_ID == statusID)
                                                                         .ToList();

                    return knowledgeList;
            }
        }
        public KNOWLEDGE_MANAGEMENT GetKnowledge(int id)
        {
            using (MesContext context = new MesContext())
            {
                var knowledge = context.KNOWLEDGE_MANAGEMENT.FirstOrDefault(q => q.ID == id);
                return knowledge;
            }
        }
        public List<SERVICECATALOG> GetServiceCatalog()
        {
            using (MesContext context = new MesContext())
            {
                var sc = context.SERVICECATALOG.ToList();
                return sc;
            }
        }
        public List<PARAMETER> GetKnowledgeCategory(string code)
        {
            using (MesContext context = new MesContext())
            {
                var kc = context.PARAMETER.Where(q=> q.PARAMETER_TYPE.CODE==code).ToList();
                return kc;
            }
        }
        public List<PARAMETER> GetKnowledgeStatus(string code)
        {
            using (MesContext context = new MesContext())
            {
                var kc = context.PARAMETER.Where(q=> q.PARAMETER_TYPE.CODE == code).ToList();
                return kc;
            }
        }
        public bool InsertKnowledge(KNOWLEDGE_MANAGEMENT knowledge)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var orderKnowlodege = context.ORDER_NUMBERS.FirstOrDefault(q => q.LAST_COUNTER > 0 && q.MAIN_PROCESS_ID == 5 && q.IS_DELETED == false);
                    if (orderKnowlodege != null)
                    {
                        orderKnowlodege.LAST_COUNTER = Convert.ToInt32(orderKnowlodege.LAST_COUNTER) + 1;
                        orderKnowlodege.LAST_ORDER_NUMBER = KnowledgeNo(true);
                    }

                    context.KNOWLEDGE_MANAGEMENT.Add(knowledge);
                    context.SaveChanges();
                    
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
        public bool UpdateKnowledge(KNOWLEDGE_MANAGEMENT knowledge)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var h = context.KNOWLEDGE_MANAGEMENT.FirstOrDefault(q => q.ID == knowledge.ID);
                    if (h != null)
                    {
                        h.KNOWLEDGE_NO = knowledge.KNOWLEDGE_NO;
                        h.SUBJECT = knowledge.SUBJECT;
                        h.KNOWLEDGE_ISACTIVE = knowledge.KNOWLEDGE_ISACTIVE;
                        h.KNOWLEDGE_SERVICE_ID = knowledge.KNOWLEDGE_SERVICE_ID;
                        h.KNOWLEDGE_CATEGORY_ID = knowledge.KNOWLEDGE_CATEGORY_ID;
                        h.KNOWLEDGE_STATUS_ID = knowledge.KNOWLEDGE_STATUS_ID;
                        h.KNOWLEDGE_DESCRIPTION = knowledge.KNOWLEDGE_DESCRIPTION;
                        h.IS_ACTIVE = knowledge.IS_ACTIVE;
                    }
                    context.Entry(h).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
        public bool DeleteKnowledge(int Id)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var k = context.KNOWLEDGE_MANAGEMENT.FirstOrDefault(q => q.ID == Id);
                    k.IS_DELETED = true;
                    context.Entry(k).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
        public bool InsertOrUpdateKnowledge(KNOWLEDGE_MANAGEMENT knowledge)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var h = context.KNOWLEDGE_MANAGEMENT.FirstOrDefault();
                    if (h == null)
                    {
                        knowledge.CREATED_DATE = DateTime.Now;
                        InsertKnowledge(knowledge);
                    }
                    else
                    {
                        knowledge.ID = h.ID;
                        knowledge.UPDATED_DATE = DateTime.Now;
                        knowledge.KNOWLEDGE_NO = h.KNOWLEDGE_NO;
                        knowledge.SUBJECT = h.SUBJECT;
                        knowledge.KNOWLEDGE_ISACTIVE = h.KNOWLEDGE_ISACTIVE;
                        knowledge.KNOWLEDGE_SERVICE_ID = h.KNOWLEDGE_SERVICE_ID;
                        knowledge.KNOWLEDGE_CATEGORY_ID = h.KNOWLEDGE_CATEGORY_ID;
                        knowledge.KNOWLEDGE_STATUS_ID = h.KNOWLEDGE_STATUS_ID;
                        knowledge.KNOWLEDGE_DESCRIPTION = h.KNOWLEDGE_DESCRIPTION;

                        UpdateKnowledge(knowledge);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
        public string KnowledgeNo(bool isUpdate)
        {
            string result = "";
            string last_Order_Number = "";
            using (MesContext context = new MesContext())
            {
                var code = context.ORDER_NUMBERS.FirstOrDefault(q => q.LAST_COUNTER > 0 && q.SYSTEM_CODE == "KNOWLEDGE" && q.IS_DELETED == false).CODE;
                var count = context.ORDER_NUMBERS.FirstOrDefault(q => q.LAST_COUNTER > 0 && q.SYSTEM_CODE == "KNOWLEDGE" && q.IS_DELETED == false).LAST_COUNTER;
                var format_code = context.ORDER_NUMBERS.FirstOrDefault(q => q.LAST_COUNTER > 0 && q.SYSTEM_CODE == "KNOWLEDGE" && q.IS_DELETED == false).ID_FORMAT_CODE;

                if (isUpdate == false)
                {
                    int codeNumLenght = format_code.Length;
                    int codeLenght = count.ToString().Length;
                    int _codeNumLenght = codeNumLenght - codeLenght;
                    for (int i = 0; i < (_codeNumLenght); i++)
                    {
                       last_Order_Number += "0";
                    }
                    result = code + "-" + last_Order_Number + count.ToString();
                }
                else
                {
                    int countUpdate = count + 1;
                    int codeNumLenght = format_code.Length;
                    int codeLenght = countUpdate.ToString().Length;
                    int _codeNumLenght = codeNumLenght - codeLenght;
                    for (int i = 0; i < (_codeNumLenght); i++)
                    {
                       last_Order_Number += "0";
                    }
                    result = code + "-" + last_Order_Number + countUpdate.ToString();
                }
            }            
            return result;
        }
        public bool InsertKnowledgeFiles(KNOWLEDGE_FILES knowledgeFile)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    context.KNOWLEDGE_FILES.Add(knowledgeFile);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
        public List<KNOWLEDGE_FILES> GetFileList(int knowledgeId)
        {
            using (MesContext context = new MesContext())
            {
                var fileList = context.KNOWLEDGE_FILES.Include(q => q.CREATED_USER) 
                                                      .Where(q => q.KNOWLEDGE_ID == knowledgeId)
                                                      .Where(q => q.IS_DELETED == false)
                                                      .ToList();
                return fileList;
            }
        }
        public bool DeleteKnowledgeFiles(int deleteId)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var k = context.KNOWLEDGE_FILES.FirstOrDefault(q => q.ID == deleteId);
                    k.IS_DELETED = true;
                    context.Entry(k).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
    }
}
