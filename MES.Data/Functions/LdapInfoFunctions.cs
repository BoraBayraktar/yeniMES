using MES.DB;
using MES.DB.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MES.Data.Functions
{
	public class LdapInfoFunctions
	{
        public LDAP_INFO GetLdapInfo()
        {
            using (MesContext context = new MesContext())
            {
                var ldapInfo = context.LDAP_INFO.FirstOrDefault();
                var deneme = context.LDAP_INFO.ToList();
                return ldapInfo;
            }
        }

        public bool InsertLdapInfo(LDAP_INFO ldapInfo)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    context.LDAP_INFO.Add(ldapInfo);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }

        public bool UpdateLdapInfo(LDAP_INFO ldapInfo)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var _ldap = context.LDAP_INFO.FirstOrDefault();
                    if (_ldap != null)
                    {
                        _ldap.UPDATED_DATE = DateTime.Now;
                        _ldap.UPDATED_USER_ID = ldapInfo.UPDATED_USER_ID;

                        _ldap.ServerAddress = ldapInfo.ServerAddress;
                        _ldap.PortNumber = ldapInfo.PortNumber;
                        _ldap.Username = ldapInfo.Username;
                        _ldap.Password = ldapInfo.Password;
                        _ldap.SearchBase = ldapInfo.SearchBase;
                        _ldap.CronType = ldapInfo.CronType;
                        _ldap.DailyTime = ldapInfo.DailyTime;
                        _ldap.DayOfWeek = ldapInfo.DayOfWeek;
                        _ldap.DayOfMonth = ldapInfo.DayOfMonth;
                        _ldap.OneTime = ldapInfo.OneTime;
                        _ldap.SelectedOu = ldapInfo.SelectedOu;
                        context.Entry(_ldap).State = EntityState.Modified;
                    }
                    else
                        context.Entry(ldapInfo).State = EntityState.Added;
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
