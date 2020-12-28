using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.API.Interfaces
{
    public interface IParameter
    {
        List<PARAMETER> GetList();
        PARAMETER GetParameter(int id);
        bool InsertParameter(PARAMETER parameter);
        bool UpdateParameter(PARAMETER parameter);
        bool DeleteParameter(int Id);

        List<PARAMETER_TYPE> GetParameterTypeList();

        List<PARAMETER> GetParameterListByParameterTypeCode(string code, int mainProcessId);
        List<PARAMETER> GetParameterListByParameterTypeCode(string code);


        List<PARAMETER_TYPE> GetParameterTypeByMainProcessId(int mainProcessId);

        List<PARAMETER> GetParameterByMainProcessId(int mainProcessId);
    }
}
