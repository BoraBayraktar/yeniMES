using MES.Web.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.Web.Models
{
    public class KnowledgeViewModel
    {
        public KnowledgeViewModel()
        {
            PrmKnowledgeCategoryList = new List<SelectListItem>();
            ServiceCalalogList = new List<SelectListItem>();
            PrmKnowledgeStatusList = new List<SelectListItem>();
            UserList = new List<SelectListItem>();
        }
        public KNOWLEDGE_MANAGEMENT knowledge { get; set; }
        public List<KNOWLEDGE_MANAGEMENT> knowledgeList { get; set; }
        public List<SelectListItem> PrmKnowledgeCategoryList { get; set; }
        public List<SelectListItem> ServiceCalalogList { get; set; }
        public List<SelectListItem> PrmKnowledgeStatusList { get; set; }
        public List<SelectListItem> UserList { get; set; }
        public List<KNOWLEDGE_FILES> FileList { get; set; }

    }
}
