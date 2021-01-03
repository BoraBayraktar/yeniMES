//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc.Filters;
//using MES.Business;
//using MES.Web.Models;
//using Newtonsoft.Json;
//using Microsoft.Extensions.Caching.Memory;
//using MES.Entities.Model;

//namespace MES.Web.Controllers
//{
//    public class BaseController : Controller
//    {
//        //private readonly IMemoryCache _memCache;
//        //const string generalSettingsCacheKey = "generalSettingsKey";

//        //MenuLogic menuLogic = new MenuLogic();
//        //GeneralSettingsLogic generalSettingsLogic = new GeneralSettingsLogic();
//        //UserTypeMenuLogic userTypeMenuLogic = new UserTypeMenuLogic();


//        //public BaseController(IMemoryCache memCache)
//        //{
//        //    _memCache = memCache;
//        //}
//        public BaseController()
//        {
//        }
//        public USER SessionUser
//        {
//            get
//            {
//                return HttpContext.Session.GetObject<USER>("User");
//            }
//            set
//            {
//                HttpContext.Session.SetObject("User", value);
//            }
//        }
        
//        public void ShowSuccessToastMessage()
//        {
//            TempData["toastType"] = "success";
//            TempData["toastTitle"] = "İşlem Başarılı";
//            TempData["toastMessage"] = "Yapmış olduğunuz işlem başarılı olarak gerçekleştirilmiştir.";
//        }
//        public void ShowErrorToastMessage()
//        {
//            TempData["toastType"] = "error";
//            TempData["toastTitle"] = "İşlem Başarısız";
//            TempData["toastMessage"] = "Sistemden kaynaklanan bir hatadan dolayı işlem tamamlanamamıştır. Lütfen daha sonra tekrar deneyiniz.";
//        }

//        public override void OnActionExecuting(ActionExecutingContext filterContext)
//        {
//            base.OnActionExecuting(filterContext);

//            //var getCache = _memCache.Get(generalSettingsCacheKey);
//            //if (getCache == null)
//            //{
//            //    var cacheExpOptions = new MemoryCacheEntryOptions
//            //    {
//            //        AbsoluteExpiration = DateTime.Now.AddMinutes(30),
//            //        Priority = CacheItemPriority.Normal
//            //    };

//            //    var gs = generalSettingsLogic.GetGeneralSettings();

//            //    _memCache.Set(generalSettingsCacheKey, gs, cacheExpOptions);
//            //}

//            if (filterContext.HttpContext.Session.GetString("GeneralSettings") == null)
//            {
//                var gs = generalSettingsLogic.GetGeneralSettings();
//                filterContext.HttpContext.Session.SetObject("GeneralSettings", gs);
//            }

//            if (filterContext.HttpContext.Session.GetString("User") == null)
//                filterContext.Result = RedirectToAction("Index", "Login");

//            //if (filterContext.HttpContext.Session.GetString("Menu") == null)
//            //{
//            //    var menuList = menuLogic.GetAllMenu();
//            //    filterContext.HttpContext.Session.SetObject("Menu", menuList);
//            //}
//        }
//    }
//    public static class SessionExtensions
//    {
//        public static void SetObject(this ISession session, string key, object value)
//        {
//            session.SetString(key, JsonConvert.SerializeObject(value));
//        }

//        public static T GetObject<T>(this ISession session, string key)
//        {
//            var value = session.GetString(key);
//            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
//        }
//    }
//}