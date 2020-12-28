using MES.API.Interfaces;
using MES.DB;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MES.API.Functions
{
    public class CityFunctions : ICity
    {
        public List<CITY> GetList()
        {
            using (MesContext context = new MesContext())
            {
                var cityList = context.CITY.ToList();
                return cityList;
            }
        }
    }
}
