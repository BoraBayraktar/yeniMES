using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Interfaces
{
    public interface ISettingIncidentOrderNumbers
    {
        List<ORDER_NUMBERS> GetList();
        ORDER_NUMBERS GetOrderNumbers(int id);        
        List<MAIN_PROCESS> GetMainProcess();
        bool UpdateOrderNumbers(ORDER_NUMBERS orderNumbers);
    }
}
