using MES.Data.Functions;
using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Data.Business
{
	public class LdapInfoLogic
	{
        LdapInfoFunctions _ldapInfo = new LdapInfoFunctions();
        public LDAP_INFO Get()
        {
            var ldapList = _ldapInfo.GetLdapInfo();
            return ldapList;
        }
        public bool InsertLdapInfo(LDAP_INFO ldpInf)
        {
            var success = _ldapInfo.InsertLdapInfo(ldpInf);
            return success;
        }
        public bool UpdateLdapInfo(LDAP_INFO ldpInf)
        {
            var success = _ldapInfo.UpdateLdapInfo(ldpInf);
            return success;
        }
    }
}
