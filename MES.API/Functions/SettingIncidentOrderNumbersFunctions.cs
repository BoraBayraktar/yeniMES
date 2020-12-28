using MES.API.Interfaces;
using MES.DB;
using MES.DB.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MES.API.Functions
{
    public class SettingIncidentOrderNumbersFunctions : ISettingIncidentOrderNumbers
    {        
        public List<ORDER_NUMBERS> GetList()
        {
            using (MesContext context = new MesContext())
            {
                var orderNumbers = context.ORDER_NUMBERS.Include(q => q.CREATED_USER)
                                                        .Include(q => q.MAINPROCESS_MODEL)
                                                        .Where(q => q.IS_DELETED == false)
                                                        .Where(q => q.SYSTEM_CODE == "INCIDENT")
                                                        .ToList();                
                return orderNumbers;
            }
        }
        public ORDER_NUMBERS GetOrderNumbers(int id)
        {
            using (MesContext context = new MesContext())
            {
                var orderNumbers = context.ORDER_NUMBERS.FirstOrDefault(q => q.ID == id);
                return orderNumbers;
            }
        }
        public List<MAIN_PROCESS> GetMainProcess()
        {
            using (MesContext context = new MesContext())
            {
                var mainProcess = context.MAIN_PROCESS.Where(q => q.IS_DELETED == false)
                                                .ToList();
                return mainProcess;
            }
        }
        public bool UpdateOrderNumbers(ORDER_NUMBERS orderNumbers)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var h = context.ORDER_NUMBERS.FirstOrDefault(q => q.ID == orderNumbers.ID);
                    if (h != null)
                    {
                        //h.MAIN_PROCESS_ID = orderNumbers.MAIN_PROCESS_ID;
                        h.CODE = orderNumbers.CODE;
                        h.ID_FORMAT_CODE = orderNumbers.ID_FORMAT_CODE;
                        //h.IS_ACTIVE = orderNumbers.IS_ACTIVE;
                    }
                    context.Entry(h).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
    }
}
