using MES.Data.Functions;
using MES.Data.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Business
{
    public class SettingIncidentOrderNumbersLogic
    {
        ISettingIncidentOrderNumbers _OrderNumbers = new SettingIncidentOrderNumbersFunctions();
        public List<ORDER_NUMBERS> GetList()
        {
            var orderNumbersList = _OrderNumbers.GetList();
            return orderNumbersList;
        }
        public ORDER_NUMBERS GetOrderNumbers(int id)
        {
            var orderNumbers = _OrderNumbers.GetOrderNumbers(id);
            return orderNumbers;
        }
        public List<MAIN_PROCESS> GetMainProcess()
        {
            var mainProcess = _OrderNumbers.GetMainProcess();
            return mainProcess;
        }
        public bool UpdateOrderNumbers(ORDER_NUMBERS orderNumbers)
        {
            var success = _OrderNumbers.UpdateOrderNumbers(orderNumbers);
            return success;
        }
    }
}

