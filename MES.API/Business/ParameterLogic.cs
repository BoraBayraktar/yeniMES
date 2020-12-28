using MES.API.Functions;
using MES.API.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MES.API.Business
{
    public class ParameterLogic
    {
        IParameter _parameter = new ParameterFunctions();
        public List<PARAMETER> GetList()
        {
            var parameterList = _parameter.GetList();
            return parameterList;
        }
        public bool InsertParameter(PARAMETER parameter)
        {
            var success = _parameter.InsertParameter(parameter);
            return success;
        }
        public bool UpdateParameter(PARAMETER parameter)
        {
            var success = _parameter.UpdateParameter(parameter);
            return success;
        }
        public bool DeleteParameter(int Id)
        {
            var success = _parameter.DeleteParameter(Id);
            return success;
        }
        public PARAMETER GetParameter(int id)
        {
            var parameter = _parameter.GetParameter(id);
            return parameter;
        }

        public List<PARAMETER_TYPE> GetParameterTypeList()
        {
            var parameterTypeList = _parameter.GetParameterTypeList();
            return parameterTypeList;
        }

        public List<PARAMETER> GetParameterListByParameterTypeCode(string code, int mainProcessId)
        {
            var parameterList = _parameter.GetParameterListByParameterTypeCode(code, mainProcessId);
            return parameterList;
        }

        public List<PARAMETER> GetParameterListByParameterTypeCode(string code)
        {
            var parameterList = _parameter.GetParameterListByParameterTypeCode(code);
            return parameterList;
        }

        public List<PARAMETER_TYPE> GetParameterTypeByMainProcessId(int mainProcessId)
        {
            var parameterTypeList = _parameter.GetParameterTypeByMainProcessId(mainProcessId);
            return parameterTypeList;
        }

        public List<PARAMETER> GetParameterByMainProcessId(int mainProcessId)
        {
            var parameterList = _parameter.GetParameterByMainProcessId(mainProcessId);
            return parameterList;
        }
    }
}
