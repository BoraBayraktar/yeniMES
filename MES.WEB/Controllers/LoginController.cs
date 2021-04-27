using MES.Web.Encrypter;
using MES.Web.Model;
using MES.Web.Models;
using MES.Web.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MES.Web.Controllers
{
    public class LoginController : Controller
    {
        private IConfiguration configuration;
        ServiceBusiness serviceBusiness;
        private Encryption encryption = new Encryption();
        private IHttpContextAccessor httpContextAccessor;
        public LoginController(IConfiguration configuration, IHttpContextAccessor accessor)
        {
            httpContextAccessor = accessor;
            serviceBusiness = new ServiceBusiness(configuration, accessor);
        }
        public IActionResult Index()
        {
            GENERAL_SETTINGS generalSettings = serviceBusiness.ServiceGet<GENERAL_SETTINGS>("GeneralSettings", "GetGeneralSettings");
            ViewData["GeneralSettings"] = generalSettings;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IndexAsync(UserViewModel userViewModel)
        {
            try
            {
                userViewModel.Password = encryption.Encrypt(userViewModel.Password);
                (USER,string) loginResponse = serviceBusiness.ServicePost<(USER,string)>(userViewModel, "Login", "LogMain");
                USER user = loginResponse.Item1;
                string jwt = loginResponse.Item2;
                if (user == null)
                {
                    ShowLoginFailedToastMessage();
                    return View();
                }
                else
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Authentication, jwt),
                    };
                    var userIdentity = new ClaimsIdentity(claims);
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    Task claimtask = signIn(principal);
                    HttpContext.Session.SetString("token", jwt);
                }
                int uti = (int)user.USER_TYPE_ID;
                HttpContext.Session.SetObject("User", user);
                List<MENU> modifedMenu = serviceBusiness.ServicePost<List<MENU>>(uti, "Login", "SetAuthMenu");
                HttpContext.Session.SetObject("Menu", modifedMenu);
                return RedirectToAction("Index", "Home");
            }
            catch (System.Exception ex)
            {
                ShowToastMessage("error", "Hata Oluştu", ex.Message);
            }

            return View();
        }
        public async Task signIn(ClaimsPrincipal claims)
        {
            await HttpContext.SignInAsync(claims);
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(UserViewModel userViewModel)
        {
            try
            {
                USER user = serviceBusiness.ServicePost<USER>(userViewModel, "Login", "EmailCheck");
                if (user == null)
                {
                    ShowToastMessage("error", "Hata Mesajı", "Email adresi bulunamadı.");
                    return View();
                }
                else
                {
                    serviceBusiness.ServicePut<int>(user.USER_ID, "Login", "DeletePassChange");
                    PASSWORD_CHANGE_HISTORY pch = new PASSWORD_CHANGE_HISTORY()
                    {
                        CREATED_DATE = DateTime.Now,
                        UNIQUE_IDENTIFIER = Guid.NewGuid(),
                        USER_ID = user.USER_ID,
                        IS_DELETED = false
                    };

                    bool pcSuccess = serviceBusiness.ServicePost<bool>(pch, "Login", "InsertPassChange");
                    if (!pcSuccess)
                    {
                        ShowToastMessage("error", "Hata Mesajı", "Hata oluştu, lütfen daha sonra tekrar deneyiniz.");
                        return View();
                    }

                    string body = "";
                    body += "Merhaba,<br />";
                    body += "Şifre sıfırlama linkiniz:<br />";
                    body += "http://localhost:57190/Login/ChangePassword?guid=" + pch.UNIQUE_IDENTIFIER;
                    body += "https://mess.azurewebsites.net/Login/ChangePassword?guid=" + pch.UNIQUE_IDENTIFIER;

                    MAIL_TO_SEND mailToSend = new MAIL_TO_SEND()
                    {
                        TO_ADDRESS = user.EMAIL,
                        MAIL_SUBJECT = "MES Şifre Sıfırlama Linki",
                        MAIL_BODY = body,
                        CREATED_DATE = DateTime.Now
                    };

                    bool mailToSuccess = serviceBusiness.ServicePost<bool>(mailToSend, "Login", "InsertMailToSend");
                    if (!mailToSuccess)
                    {
                        ShowToastMessage("error", "Hata Mesajı", "Hata oluştu, lütfen daha sonra tekrar deneyiniz.");
                        return View();
                    }

                    ShowToastMessage("success", "İşlem Başarılı", "Şifre sıfırlama linki mail adresinize gönderildi.");
                    return RedirectToAction("Index", "Login");
                }

            }
            catch (System.Exception ex)
            {
                ShowToastMessage("error", "Hata Mesajı", "Sistemden kaynaklanan bir hata oluştu. Lütfen daha sonra tekrar deneyiniz.");
            }

            return View();
        }



        public ActionResult ChangePassword()
        {
            return View();
        }


        public ActionResult ChangePassword(string guid, UserViewModel userViewModel)
        {
            try
            {
                PASSWORD_CHANGE_HISTORY passwordChange = serviceBusiness.ServicePost<PASSWORD_CHANGE_HISTORY>(guid, "Login", "GetPassChange");
                if (passwordChange == null)
                {
                    ShowToastMessage("error", "Hata Mesajı", "Şifre değiştirme linki bulunamadı.");
                    return RedirectToAction("ChangePassword", "Login", new { guid = guid });
                }
                else
                {
                    if (userViewModel.NewPassword != userViewModel.ReNewPassword)
                    {
                        ShowToastMessage("error", "Hata", "Girdiğiniz şifreler eşleşmemektedir.");
                        return RedirectToAction("ChangePassword", "Login", new { guid = guid });
                    }
                    if (userViewModel.NewPassword.Length < 6)
                    {
                        ShowToastMessage("error", "Hata", "Şifreniz en az 6 karakterli olmalıdır.");
                        return RedirectToAction("ChangePassword", "Login", new { guid = guid });
                    }

                    serviceBusiness.ServicePut<int>(passwordChange.ID, "Login", "UpdatePassChange");

                    
                    (int, string) IdPassword = (passwordChange.USER_ID,encryption.Encrypt(userViewModel.NewPassword));
                    serviceBusiness.ServicePut<(int, string)>(IdPassword, "Login", "UserChangePassword");
                }
                ShowToastMessage("success", "İşlem Başarılı", "Şifreniz başarıyla değiştirilmiştir.");
                return RedirectToAction("Index", "Login");
            }
            catch (System.Exception ex)
            {
                ShowToastMessage("error", "Hata Mesajı", "Sistemden kaynaklanan bir hata oluştu. Lütfen daha sonra tekrar deneyiniz.");
            }

            return RedirectToAction("ChangePassword", "Login", new { guid = guid });
        }





        public ActionResult LogOut()
        {
            HttpContext.Session.Remove("User");
            HttpContext.Session.Remove("Menu");
            HttpContext.Session.Remove("GeneralSettings");
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
        public void ShowLoginFailedToastMessage()
        {
            TempData["toastType"] = "error";
            TempData["toastTitle"] = "İşlem Başarısız";
            TempData["toastMessage"] = "Kullanıcı bulunamadı. Kullanıcı Adı veya şifreniz kontrol edip tekrar deneyiniz.";
        }
        public void ShowToastMessage(string type, string title, string message)
        {
            TempData["toastType"] = type;
            TempData["toastTitle"] = title;
            TempData["toastMessage"] = message;
        }
    }
}