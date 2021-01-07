using MES.Data.Functions;
using MES.Data.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Logics
{
    public class CityLogic
    {
        ICity _city = new CityFunctions();
        public List<CITY> GetList()
        {
            var cityList = _city.GetList();
            return cityList;
        }
    }
}
