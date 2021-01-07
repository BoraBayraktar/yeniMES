using MES.Web.Model;
using System.Collections.Generic;

namespace MES.Web.Interfaces
{
    public interface IMenu
    {
        List<MENU> GetAllMenu();
        bool InsertMenu(MENU entity);
    }
}
