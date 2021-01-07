using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;

namespace MES.API.Encryption
{
    public class Encryption
    {
        private readonly IDataProtectionProvider _dataProtectionProvider;
        private const string Key = "KDFSDG3425TGHTH6HG45YRJRYJY234T3G3G53Y54YHY46H6J456";
        public Encryption(IDataProtectionProvider dataProtectionProvider)
        {
            _dataProtectionProvider = dataProtectionProvider;
        }
        public string Encrypt(string input)
        {

            var protector = _dataProtectionProvider.CreateProtector(Key);
            return protector.Protect(input);
        }

        public string Decrypt(string input)
        {
            var protector = _dataProtectionProvider.CreateProtector(Key);
            return protector.Unprotect(input);
        }
    }
}
