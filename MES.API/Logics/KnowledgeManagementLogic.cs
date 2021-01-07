using MES.Data.Functions;
using MES.Data.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Logics
{
    public class KnowledgeLogic
    {
        IKnowledge _Knowledge = new KnowledgeFunctions();

        public List<KNOWLEDGE_MANAGEMENT> GetList(int userID)
        {
            var k = _Knowledge.GetList(userID);
            return k;
        }
        public KNOWLEDGE_MANAGEMENT GetKnowledge(int id)
        {
            var k = _Knowledge.GetKnowledge(id);
            return k;
        }
        public List<SERVICECATALOG> GetServiceCatalog()
        {
            var k = _Knowledge.GetServiceCatalog();
            return k;
        }
        public List<PARAMETER> GetKnowledgeCategory(string code)
        {
            var k = _Knowledge.GetKnowledgeCategory(code);
            return k;
        }
        public List<PARAMETER> GetKnowledgeStatus( string code)
        {
            var k = _Knowledge.GetKnowledgeStatus(code);
            return k;
        }
        public bool InsertKnowledge(KNOWLEDGE_MANAGEMENT knowledge)
        {
            var success = _Knowledge.InsertKnowledge(knowledge);
            return success;
        }
        public bool UpdateKnowledge(KNOWLEDGE_MANAGEMENT knowledge)
        {
            var success = _Knowledge.UpdateKnowledge(knowledge);
            return success;
        }
        public bool DeleteKnowledge(int Id)
        {
            var success = _Knowledge.DeleteKnowledge(Id);
            return success;
        }
        public string KnowledgeNo(bool isUpdate)
        {
            return _Knowledge.KnowledgeNo(false);
        }
        public bool InsertKnowledgeFiles(KNOWLEDGE_FILES knowledgeFile)
        {
            var success = _Knowledge.InsertKnowledgeFiles(knowledgeFile);
            return success;
        }
        public List<KNOWLEDGE_FILES> GetFileList(int knowledgeId)
        {
            var k = _Knowledge.GetFileList(knowledgeId);
            return k;
        }
        public bool DeleteKnowledgeFiles(int deleteId)
        {
            var success = _Knowledge.DeleteKnowledgeFiles(deleteId);
            return success;
        }
    }
}

