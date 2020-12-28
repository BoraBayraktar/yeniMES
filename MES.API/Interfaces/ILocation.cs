using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.API.Interfaces
{
    public interface ILocation
    {
        List<LOCATION> GetList();
        LOCATION GetLocation(int id);
        bool InsertLocation(LOCATION holding);
        bool InsertLocation(List<LOCATION> holding);
        bool UpdateLocation(LOCATION holding);
        bool DeleteLocation(int Id);
    }
}
