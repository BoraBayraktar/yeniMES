using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;

namespace MES.API.Encrypter
{
    public class Encryption
    {
        private const string Key = "qHJhfH@jUıolMunP373U3ubrf3F3U½+^+&7/%Fuf4ıjfnFN4V_r3_343Rr3r4ttT443T2Tg1312324/(&43TgRGGRT3T43T4G4h43iN3RzxcDVdvDEFgegGrhRT?=5!4#$½£$2NTHTNhrew324er4RWFrERfe";
        public string Encrypt(string input)
        {
            if (input == null)
            {
                return String.Empty;
            }

            // Get the bytes of the string
            var bytesToBeEncrypted = Encoding.UTF8.GetBytes(Key);
            var inputBytes = Encoding.UTF8.GetBytes(input);

            // Hash the password with SHA256
            inputBytes = SHA256.Create().ComputeHash(inputBytes);

            var bytesEncrypted = Encrypt(bytesToBeEncrypted, inputBytes);

            return Convert.ToBase64String(bytesEncrypted);
            //var protector = _dataProtectionProvider.CreateProtector(Key);
            //return protector.Protect(input);
        }
        public string Decrypt(string input)
        {
            if (input == null)
            {
                return String.Empty;
            }

            // Get the bytes of the string
            var bytesToBeDecrypted = Convert.FromBase64String(Key);
            var inputBytes = Encoding.UTF8.GetBytes(input);

            inputBytes = SHA256.Create().ComputeHash(inputBytes);

            var bytesDecrypted = Decrypt(bytesToBeDecrypted, inputBytes);

            return Encoding.UTF8.GetString(bytesDecrypted);
            //var protector = _dataProtectionProvider.CreateProtector(Key);
            //return protector.Unprotect(input);
        }
        private byte[] Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);

                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }

                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        private byte[] Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);

                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);
                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }

                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }
    }
}
