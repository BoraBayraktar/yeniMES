using MES.Data.Functions;
using MES.Data.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Business
{
    public class TitleLogic
    {
        ITitle _title = new TitleFunctions();
        public List<TITLE> GetList()
        {
            var titleList = _title.GetList();
            return titleList;
        }
        public bool InsertTitle(TITLE title)
        {
            var success = _title.InsertTitle(title);
            return success;
        }   
        public bool InsertTitle(List<TITLE> title)
        {
            var success = _title.InsertTitle(title);
            return success;
        }
        public bool UpdateTitle(TITLE title)
        {
            var success = _title.UpdateTitle(title);
            return success;
        }
        public bool DeleteTitle(int Id)
        {
            var success = _title.DeleteTitle(Id);
            return success;
        }
        public TITLE GetTitle(int id)
        {
            var title = _title.GetTitle(id);
            return title;
        }
    }
}
