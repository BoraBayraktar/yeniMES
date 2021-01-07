using MES.Data.Functions;
using MES.Data.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Logics
{
    public class LocationLogic
    {
        ILocation _location = new LocationFunctions();
        public List<LOCATION> GetList()
        {
            var locationList = _location.GetList();
            return locationList;
        }
        public bool InsertLocation(LOCATION location)
        {
            var success = _location.InsertLocation(location);
            return success;
        } 
        public bool InsertLocation(List<LOCATION> location)
        {
            var success = _location.InsertLocation(location);
            return success;
        }
        public bool UpdateLocation(LOCATION location)
        {
            var success = _location.UpdateLocation(location);
            return success;
        }
        public bool DeleteLocation(int Id)
        {
            var success = _location.DeleteLocation(Id);
            return success;
        }
        public LOCATION GetLocation(int id)
        {
            var location = _location.GetLocation(id);
            return location;
        }
    }
}
