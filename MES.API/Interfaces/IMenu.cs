using MES.DB.Model;
using System.Collections.Generic;

namespace MES.API.Interfaces
{
    public interface IMenu
    {
        List<MENU> GetAllMenu();
        bool InsertMenu(MENU entity);
    }
}
