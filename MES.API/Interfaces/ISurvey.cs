using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.API.Interfaces
{
    public interface ISurvey
    {
        List<SURVEY> GetList();
        SURVEY GetSurvey(int id);
        bool InsertSurvey(SURVEY survey);
        bool UpdateSurvey(SURVEY survey);
        bool DeleteSurvey(int Id);
    }
}
