using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.API.Interfaces
{
    public interface IGeneralSettings
    {
        GENERAL_SETTINGS GetGeneralSettings();
        bool InsertGeneralSettings(GENERAL_SETTINGS generalSettings);
        bool UpdateGeneralSettings(GENERAL_SETTINGS generalSettings);
        bool InsertOrUpdateGeneralSettings(GENERAL_SETTINGS gs);
    }
}
