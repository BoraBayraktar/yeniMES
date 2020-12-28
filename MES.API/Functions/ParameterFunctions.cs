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
    public class ParameterFunctions : IParameter
    {
        public List<PARAMETER> GetList()
        {
            using (MesContext context = new MesContext())
            {
                var parameterList = context.PARAMETER.Include(q => q.CREATED_USER)
                                                     .Include(q => q.MAIN_PROCESS)
                                                     .Include(q => q.PARAMETER_TYPE)
                                                     .Include(q => q.PARENT_PARAMETER)
                                                     .Where(q => q.IS_DELETED == false)
                                                     .ToList();
                return parameterList;
            }
        }

        public PARAMETER GetParameter(int id)
        {
            using (MesContext context = new MesContext())
            {
                var parameter = context.PARAMETER.FirstOrDefault(q => q.ID == id);
                return parameter;
            }
        }

        public bool InsertParameter(PARAMETER parameter)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    parameter.CREATED_DATE = DateTime.Now;
                    context.PARAMETER.Add(parameter);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool UpdateParameter(PARAMETER parameter)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var prm = context.PARAMETER.FirstOrDefault(q => q.ID == parameter.ID);
                    if (prm != null)
                    {
                        prm.MAIN_DATA_NAME = parameter.MAIN_DATA_NAME;
                        prm.IS_ACTIVE = parameter.IS_ACTIVE;
                        prm.MAIN_PROCESS_ID = parameter.MAIN_PROCESS_ID;
                        prm.PARAMETER_TYPE_ID = parameter.PARAMETER_TYPE_ID;
                        prm.PARENT_PARAMETER_ID = parameter.PARENT_PARAMETER_ID;
                        prm.PRIORITY_ORDER = parameter.PRIORITY_ORDER;
                        prm.DESCRIPTION = parameter.DESCRIPTION;
                        prm.UPDATED_DATE = DateTime.Now;
                    }
                    context.Entry(prm).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool DeleteParameter(int Id)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var parameter = context.PARAMETER.FirstOrDefault(q => q.ID == Id);
                    parameter.IS_DELETED = true;
                    context.Entry(parameter).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
        //public bool DeleteParameter(int Id)
        //{
        //    bool returnVal = false;
        //    try
        //    {
        //        using (MesContext context = new MesContext())
        //        {
        //            var parameter = context.PARAMETER.FirstOrDefault(q => q.ID == Id);
        //            context.PARAMETER.Remove(parameter);
        //            context.SaveChanges();
        //            returnVal = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return returnVal;
        //}

        public List<PARAMETER_TYPE> GetParameterTypeList()
        {
            using (MesContext context = new MesContext())
            {
                var parameterTypeList = context.PARAMETER_TYPE.ToList();
                return parameterTypeList;
            }
        }

        public List<PARAMETER> GetParameterListByParameterTypeCode(string code, int mainProcessId)
        {
            using (MesContext context = new MesContext())
            {
                var parameterList = context.PARAMETER.Include(q => q.PARAMETER_TYPE)
                                                     .Where(q => q.PARAMETER_TYPE.CODE == code && q.MAIN_PROCESS_ID == mainProcessId)
                                                     .OrderBy(q=>q.PRIORITY_ORDER)
                                                     .ToList();
                return parameterList;
            }
        }

        public List<PARAMETER> GetParameterListByParameterTypeCode(string code)
        {
            using (MesContext context = new MesContext())
            {
                var parameterList = context.PARAMETER.Include(q => q.PARAMETER_TYPE)
                                                     .Where(q => q.PARAMETER_TYPE.CODE == code)
                                                     .OrderBy(q => q.PRIORITY_ORDER)
                                                     .ToList();
                return parameterList;
            }
        }

        public List<PARAMETER_TYPE> GetParameterTypeByMainProcessId(int mainProcessId)
        {
            using (MesContext context = new MesContext())
            {
                var parameterTypeList = context.PARAMETER_TYPE.Where(q => q.MAIN_PROCESS_ID == mainProcessId).ToList();
                return parameterTypeList;
            }
        }

        public List<PARAMETER> GetParameterByMainProcessId(int mainProcessId)
        {
            using (MesContext context = new MesContext())
            {
                var parameterList = context.PARAMETER.Where(q => q.MAIN_PROCESS_ID == mainProcessId).ToList();
                return parameterList;
            }
        }
    }

}