using MES.DB.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.API.Models
{
    public class SettingKnowledgeOrderNumbersViewModel
    {
        public SettingKnowledgeOrderNumbersViewModel()
        {
            mainProcessList = new List<SelectListItem>();
            PrmKnowledgeStatusList = new List<SelectListItem>();
        }
        public List<ORDER_NUMBERS> orderNumbersList { get; set; }
        public ORDER_NUMBERS orderNumbers { get; set; }        
        public List<SelectListItem> mainProcessList { get; set; }
        public List<SelectListItem> PrmKnowledgeStatusList { get; set; }
        public KNOWLEDGE_SETTINGS status { get; set; }
    }
}
