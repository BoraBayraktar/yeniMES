using MES.Data.Interfaces;
using MES.DB;
using MES.DB.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MES.Data.Functions
{
    public class MainProcessFunctions : IMainProcess
    {
        public List<MAIN_PROCESS> GetList()
        {
            using (MesContext context = new MesContext())
            {
                var mainProcessList = context.MAIN_PROCESS.Include(q => q.CREATED_USER).Where(q => q.IS_DELETED == false).ToList();
                return mainProcessList;
            }
        }

        public MAIN_PROCESS GetMainProcess(int id)
        {
            using (MesContext context = new MesContext())
            {
                var mainProcess = context.MAIN_PROCESS.FirstOrDefault(q => q.ID == id);
                return mainProcess;
            }
        }

        public bool InsertMainProcess(MAIN_PROCESS mainProcess)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    mainProcess.CREATED_DATE = DateTime.Now;
                    context.MAIN_PROCESS.Add(mainProcess);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool UpdateMainProcess(MAIN_PROCESS mainProcess)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var mp = context.MAIN_PROCESS.FirstOrDefault(q => q.ID == mainProcess.ID);
                    if (mp != null)
                    {
                        mp.NAME = mainProcess.NAME;
                        mp.SHORT_CODE = mainProcess.SHORT_CODE;
                        mp.DOMAIN_ID = mainProcess.DOMAIN_ID;
                        mp.UPDATED_DATE = DateTime.Now;
                    }
                    context.Entry(mp).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool DeleteMainProcess(int Id)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var mainProcess = context.MAIN_PROCESS.FirstOrDefault(q => q.ID == Id);
                    mainProcess.IS_DELETED = true;
                    context.Entry(mainProcess).State = EntityState.Modified;
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
