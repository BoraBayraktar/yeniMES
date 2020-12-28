using MES.API.Functions;
using MES.API.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.API.Business
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
