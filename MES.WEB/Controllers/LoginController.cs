
using MES.Web.Model;
using MES.Web.Models;
using MES.Web.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace MES.Web.Controllers
{
    public class LoginController : Controller
    {
        ServiceBusiness serviceBusiness = new ServiceBusiness();
        private Encryption.Encryption encryption;

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Index(UserViewModel userViewModel)
        {
            try
            {
                userViewModel.Password = encryption.Encrypt(userViewModel.Password);
                userViewModel.NewPassword = encryption.Encrypt(userViewModel.NewPassword);
                userViewModel.NewPassword = encryption.Encrypt(userViewModel.ReNewPassword);
                object useR = serviceBusiness.ObjSendObjGet(userViewModel, "Login", "LoginMain");
                USER user = (USER)useR;
                if (user == null)
                {
                    ShowLoginFailedToastMessage();
                    return View();
                }
                else
                {
                    object jwtobj = serviceBusiness.ObjSendObjGet(userViewModel, "Login", "GetJwt");
                    string jwt = (string)jwtobj;
                    if (!String.IsNullOrEmpty(jwt))
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.UserData, jwt)
                            //new Claim(ClaimTypes.Name, user.NAME)
                        };
                        var userIdentity = new ClaimsIdentity(claims, "login");
                        ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                        HttpContext.SignInAsync(principal);
                    }
                }
                int uti = (int)user.USER_TYPE_ID;
                SetAuthMenu(uti);
                HttpContext.Session.SetObject("User", user);
                return RedirectToAction("Index", "Home");
            }
            catch (System.Exception ex)
            {
                ShowToastMessage("error", "Hata Oluştu", ex.Message);
            }

            return View();
        }

        public void SetAuthMenu(int userTypeId)
        {
            try
            {
                object modifedobj = serviceBusiness.ObjSendObjGet(userTypeId, "Login", "SetAuthMenu");
                List<MENU> modifedMenu = (List<MENU>)modifedobj;
                HttpContext.Session.SetObject("Menu", modifedMenu);
            }
            catch (Exception ex)
            {

            }
        }

        //public List<MENU> AddTopMenu(List<MENU> lastmenu)
        //{
        //    List<MENU> result = new List<MENU>(lastmenu);
        //    foreach (var item in lastmenu)
        //    {
        //        if (item.TOPMENU == null) continue;
        //        if (!result.Contains(item.TOPMENU))
        //        {
        //            result.Add(item.TOPMENU);
        //            if (item.TOPMENU.TOPMENU != null && !result.Contains(item.TOPMENU.TOPMENU))
        //            {
        //                result.Add(item.TOPMENU.TOPMENU);
        //            }
        //        }
        //    }
        //    return result;
        //}


        //public ActionResult ForgotPassword()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult ForgotPassword(UserViewModel userViewModel)
        //{
        //    try
        //    {
        //        var user = userLogic.GetUser(userViewModel.Email);
        //        if (user == null)
        //        {
        //            ShowToastMessage("error", "Hata Mesajı", "Email adresi bulunamadı.");
        //            return View();
        //        }
        //        else
        //        {
        //            passwordChangeLogic.DeleteAllPasswordChange(user.USER_ID);
        //            PASSWORD_CHANGE_HISTORY pch = new PASSWORD_CHANGE_HISTORY()
        //            {
        //                CREATED_DATE = DateTime.Now,
        //                UNIQUE_IDENTIFIER = Guid.NewGuid(),
        //                USER_ID = user.USER_ID,
        //                IS_DELETED = false
        //            };

        //            var pcSuccess = passwordChangeLogic.InsertPasswordChange(pch);
        //            if (!pcSuccess)
        //            {
        //                ShowToastMessage("error", "Hata Mesajı", "Hata oluştu, lütfen daha sonra tekrar deneyiniz.");
        //                return View();
        //            }

        //            string body = "";
        //            body += "Merhaba,<br />";
        //            body += "Şifre sıfırlama linkiniz:<br />";
        //            body += "http://localhost:57190/Login/ChangePassword?guid=" + pch.UNIQUE_IDENTIFIER;
        //            body += "https://mess.azurewebsites.net/Login/ChangePassword?guid=" + pch.UNIQUE_IDENTIFIER;


        //            MAIL_TO_SEND mailToSend = new MAIL_TO_SEND()
        //            {
        //                TO_ADDRESS = user.EMAIL,
        //                MAIL_SUBJECT = "MES Şifre Sıfırlama Linki",
        //                MAIL_BODY = body,
        //                CREATED_DATE = DateTime.Now
        //            };

        //            var mailToSuccess = mailToSendLogic.InsertMailToSend(mailToSend);
        //            if (!mailToSuccess)
        //            {
        //                ShowToastMessage("error", "Hata Mesajı", "Hata oluştu, lütfen daha sonra tekrar deneyiniz.");
        //                return View();
        //            }

        //            ShowToastMessage("success", "İşlem Başarılı", "Şifre sıfırlama linki mail adresinize gönderildi.");
        //            return RedirectToAction("Index", "Login");
        //        }

        //    }
        //    catch (System.Exception ex)
        //    {
        //        ShowToastMessage("error", "Hata Mesajı", "Sistemden kaynaklanan bir hata oluştu. Lütfen daha sonra tekrar deneyiniz.");
        //    }

        //    return View();
        //}



        //public ActionResult ChangePassword()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult ChangePassword(string guid, UserViewModel userViewModel)
        //{
        //    try
        //    {
        //        var passwordChange = passwordChangeLogic.GetPasswordChange(guid);
        //        if (passwordChange == null)
        //        {
        //            ShowToastMessage("error", "Hata Mesajı", "Şifre değiştirme linki bulunamadı.");
        //            return RedirectToAction("ChangePassword", "Login", new { guid = guid });
        //        }
        //        else
        //        {
        //            if (userViewModel.NewPassword != userViewModel.ReNewPassword)
        //            {
        //                ShowToastMessage("error", "Hata", "Girdiğiniz şifreler eşleşmemektedir.");
        //                return RedirectToAction("ChangePassword", "Login", new { guid = guid });
        //            }
        //            if (userViewModel.NewPassword.Length < 6)
        //            {
        //                ShowToastMessage("error", "Hata", "Şifreniz en az 6 karakterli olmalıdır.");
        //                return RedirectToAction("ChangePassword", "Login", new { guid = guid });
        //            }

        //            passwordChangeLogic.UpdatePasswordChange(passwordChange.ID);
        //            userLogic.UserChangePassword(passwordChange.USER_ID, Helper.MD5HashDoubleLayer(userViewModel.NewPassword));
        //        }
        //        ShowToastMessage("success", "İşlem Başarılı", "Şifreniz başarıyla değiştirilmiştir.");
        //        return RedirectToAction("Index", "Login");

        //    }
        //    catch (System.Exception ex)
        //    {
        //        ShowToastMessage("error", "Hata Mesajı", "Sistemden kaynaklanan bir hata oluştu. Lütfen daha sonra tekrar deneyiniz.");
        //    }

        //    return RedirectToAction("ChangePassword", "Login", new { guid = guid });
        //}





        public ActionResult LogOut()
        {
            HttpContext.Session.Remove("User");
            HttpContext.Session.Remove("Menu");
            HttpContext.Session.Remove("GeneralSettings");
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