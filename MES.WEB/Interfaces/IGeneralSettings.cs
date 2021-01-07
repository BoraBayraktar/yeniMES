using MES.Web.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Web.Interfaces
{
    public interface IGeneralSettings
    {
        GENERAL_SETTINGS GetGeneralSettings();
        bool InsertGeneralSettings(GENERAL_SETTINGS generalSettings);
        bool UpdateGeneralSettings(GENERAL_SETTINGS generalSettings);
        bool InsertOrUpdateGeneralSettings(GENERAL_SETTINGS gs);
    }
}
