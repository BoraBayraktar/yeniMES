using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.API.Interfaces
{
    public interface ITitle
    {
        List<TITLE> GetList();
        TITLE GetTitle(int id);
        bool InsertTitle(TITLE title);
        bool InsertTitle(List<TITLE> title);
        bool UpdateTitle(TITLE title);
        bool DeleteTitle(int Id);
    }
}
