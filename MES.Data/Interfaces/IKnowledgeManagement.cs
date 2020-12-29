using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Interfaces
{
    public interface IKnowledge
    {
        List<KNOWLEDGE_MANAGEMENT> GetList(int userID);
        KNOWLEDGE_MANAGEMENT GetKnowledge(int id);
        List<SERVICECATALOG> GetServiceCatalog();
        List<PARAMETER> GetKnowledgeCategory(string code);
        List<PARAMETER> GetKnowledgeStatus(string code);
        bool InsertKnowledge(KNOWLEDGE_MANAGEMENT knowledge);
        bool UpdateKnowledge(KNOWLEDGE_MANAGEMENT knowledge);
        bool DeleteKnowledge(int Id);
        string KnowledgeNo(bool isUpdate);
        bool InsertKnowledgeFiles(KNOWLEDGE_FILES knowledgeFile);
        List<KNOWLEDGE_FILES> GetFileList(int knowledgeId);
        bool DeleteKnowledgeFiles(int deleteId);

    }
}
