////using MES.Business;
//using MES.Web;
//using MES.Web.Model;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Mail;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;

//namespace MES.Web.Models
//{
//    public static class Helper
//    {
//        public static string EkranaYaz()
//        {
//            string degisken1 = "Nuri Şahin";
//            return degisken1;
//        }
//        public static string MD5HashDoubleLayer(string input)
//        {
//            string hash = "MesHash_";
//            hash += MD5Hash(input);
//            hash += "_MesPass";
//            // Use input string to calculate MD5 hash
//            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
//            {
//                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(hash);
//                byte[] hashBytes = md5.ComputeHash(inputBytes);

//                // Convert the byte array to hexadecimal string
//                StringBuilder sb = new StringBuilder();
//                for (int i = 0; i < hashBytes.Length; i++)
//                {
//                    sb.Append(hashBytes[i].ToString("X2"));
//                }
//                return sb.ToString();
//            }
//        }
//        public static string MD5Hash(string input)
//        {
//            // Use input string to calculate MD5 hash
//            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
//            {
//                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
//                byte[] hashBytes = md5.ComputeHash(inputBytes);

//                // Convert the byte array to hexadecimal string
//                StringBuilder sb = new StringBuilder();
//                for (int i = 0; i < hashBytes.Length; i++)
//                {
//                    sb.Append(hashBytes[i].ToString("X2"));
//                }
//                return sb.ToString();
//            }
//        }
//        public static string GetEnumDescription(this Enum GenericEnum) //Hint: Change the method signature and input paramter to use the type parameter T
//        {
//            Type genericEnumType = GenericEnum.GetType();
//            MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
//            if ((memberInfo != null && memberInfo.Length > 0))
//            {
//                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
//                if ((_Attribs != null && _Attribs.Count() > 0))
//                {
//                    return ((System.ComponentModel.DescriptionAttribute)_Attribs.ElementAt(0)).Description;
//                }
//            }
//            return GenericEnum.ToString();
//        }

//        public static void Timezone()
//        {
//            var timezones = TimeZoneInfo.GetSystemTimeZones();
//            var date1 = new DateTime(2015, 1, 15);
//            var date2 = new DateTime(2015, 7, 15);

//            Console.WriteLine(String.Format("{0,-62} {1,-32} {2,-32} {3,-15} {4,-20} {5,-20}", "Display Name", "Standard Name", "Daylight Name", "Supports DST", "UTC Standard Offset", "UTC Daylight Offset"));
//            Console.WriteLine(String.Format("{0}", "".PadRight(186, '-')));

//            foreach (var timezone in timezones)
//            {
//                var o1 = timezone.GetUtcOffset(date1);
//                var o2 = timezone.GetUtcOffset(date2);
//                var o1String = " 00:00";
//                var o2String = " 00:00";

//                if (o1 < TimeSpan.Zero)
//                    o1String = o1.ToString(@"\-hh\:mm");
//                if (o1 > TimeSpan.Zero)
//                    o1String = o1.ToString(@"\+hh\:mm");
//                if (o2 < TimeSpan.Zero)
//                    o2String = o2.ToString(@"\-hh\:mm");
//                if (o2 > TimeSpan.Zero)
//                    o2String = o2.ToString(@"\+hh\:mm");

//                using (MesContext context = new MesContext())
//                {
//                    TIMEZONE tm = new TIMEZONE()
//                    {
//                        NAME = timezone.DisplayName,
//                        UTC_STANDARD_OFFSET = o1String,
//                        UTC_DAYLIGHT_OFFSET = o2String
//                    };
//                    context.TIMEZONE.Add(tm);
//                    context.SaveChanges();
//                }
//            }
//        }

//        public static void SendEmail(string subject, string emailToAddress, string body)
//        {
//            MailSettingsLogic mailSettingsLogic = new MailSettingsLogic();
//            var mailSettings = mailSettingsLogic.GetList().FirstOrDefault();
//            using (MailMessage mail = new MailMessage())
//            {
//                mail.From = new MailAddress(mailSettings.DEFAULT_ADDRESS);
//                mail.To.Add(emailToAddress);
//                mail.Subject = subject;
//                mail.Body = body;
//                mail.IsBodyHtml = true;
//                //mail.Attachments.Add(new Attachment("D:\\TestFile.txt")); 
//                using (SmtpClient smtp = new SmtpClient(mailSettings.SMTP_HOST, mailSettings.SMTP_PORT))
//                {
//                    smtp.Credentials = new NetworkCredential(mailSettings.USERNAME, mailSettings.PASSWORD);
//                    //smtp.EnableSsl = enableSSL;
//                    smtp.Send(mail);
//                }
//            }
//        }

//        public static int SayiYaz()
//        {
//            return 5;
//        }
//    }
//}
