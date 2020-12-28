using MES.API.Functions;
using MES.API.Interfaces;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.API.Business
{
    public class GeneralSettingsLogic
    {
        IGeneralSettings _generalSettings = new GeneralSettingsFunctions();
        public bool InsertGeneralSettings(GENERAL_SETTINGS generalSettings)
        {
            var success = _generalSettings.InsertGeneralSettings(generalSettings);
            return success;
        }
        public bool UpdateGeneralSettings(GENERAL_SETTINGS generalSettings)
        {
            var success = _generalSettings.UpdateGeneralSettings(generalSettings);
            return success;
        }
        public bool InsertOrUpdateGeneralSettings(GENERAL_SETTINGS generalSettings)
        {
            var success = _generalSettings.InsertOrUpdateGeneralSettings(generalSettings);
            return success;
        }
        public GENERAL_SETTINGS GetGeneralSettings()
        {
            var generalSettings = _generalSettings.GetGeneralSettings();
            return generalSettings;
        }
    }
}
