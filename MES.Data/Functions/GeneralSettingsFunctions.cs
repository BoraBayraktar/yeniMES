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
    public class GeneralSettingsFunctions : IGeneralSettings
    {
        public GENERAL_SETTINGS GetGeneralSettings()
        {
            using (MesContext context = new MesContext())
            {
                var generalSettings = context.GENERAL_SETTINGS.FirstOrDefault();
                return generalSettings;
            }
        }

        public bool InsertGeneralSettings(GENERAL_SETTINGS generalSettings)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    context.GENERAL_SETTINGS.Add(generalSettings);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool UpdateGeneralSettings(GENERAL_SETTINGS generalSettings)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var gs = context.GENERAL_SETTINGS.FirstOrDefault();
                    if (gs != null)
                    {
                        gs.LOGIN_PAGE_TEXT = generalSettings.LOGIN_PAGE_TEXT;
                        if (generalSettings.LOGIN_PAGE_BACKGROUND != null)
                        {
                            gs.LOGIN_PAGE_BACKGROUND = generalSettings.LOGIN_PAGE_BACKGROUND;
                        }
                        if (generalSettings.LOGO != null)
                        {
                            gs.LOGO = generalSettings.LOGO;
                        }

                    }
                    context.Entry(gs).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool InsertOrUpdateGeneralSettings(GENERAL_SETTINGS gs)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var generalSettings = context.GENERAL_SETTINGS.FirstOrDefault();
                    if (generalSettings == null)
                    {
                        InsertGeneralSettings(gs);
                    }
                    else
                    {
                        gs.ID = generalSettings.ID;
                        UpdateGeneralSettings(gs);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
    }
}
