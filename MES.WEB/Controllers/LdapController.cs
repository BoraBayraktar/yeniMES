//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;
//using MES.Web.Ldap;
//using MES.Web.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using Newtonsoft.Json;
//using Novell.Directory.Ldap;
//using NUglify.Helpers;
//using MES.Business;
//using AutoMapper;
//using MES.Entities.Model;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using System.Text;

//namespace MES.Web.Controllers
//{
//    public class LdapController : Controller
//    {
//        private IConfiguration Configuration { get; }
//        private UserLogic _userLogic;
//        private LdapInfoLogic _ldapInfoLogic;
//        private IMapper _mapper;
//        public LdapController(IConfiguration configuration,
//            UserLogic UserLogic,
//            LdapInfoLogic LdapInfoLogic,
//            IMapper Mapper)
//        {
//            Configuration = configuration;
//            _userLogic = UserLogic;
//            _ldapInfoLogic = LdapInfoLogic;
//            _mapper = Mapper;
//        }
//        public IActionResult Index()
//        {
//            try
//            {
//                //var jsonString = System.IO.File.ReadAllText("ldapsettings.json");
//                var deneme = _ldapInfoLogic.Get();
//                LdapViewModel items = _mapper.Map<LdapViewModel>(_ldapInfoLogic.Get());
//                if (items == null) return View();

//                return View(items);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        #region Connection/Config
//        public IActionResult CheckLdapConnection(string ServerAddress, int PortNumber, string username, string password)
//        {
//            try
//            {
//                if (LdapHelper.LdapConnectionVerify(ServerAddress, PortNumber, username, password))
//                    return Ok("Bağlantı bilgileri doğru.");
//                return BadRequest("Bağlantıda bir hata meydana geldi.");
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        public IActionResult SaveLdapConfig(string ServerAddress, int PortNumber, string SearchBase, string username, string password)
//        {
//            try
//            {
//                _ldapInfoLogic.UpdateLdapInfo(new LDAP_INFO()
//                {
//                    ServerAddress = ServerAddress,
//                    PortNumber = PortNumber,
//                    Username = username,
//                    Password = password,
//                    SearchBase = SearchBase
//                });
//                return Json(new { success = true });
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }
//        #endregion

//        #region Ou
//        public IActionResult ReturnLdapOu()
//        {
//            try
//            {
//                var ldapModel = _ldapInfoLogic.Get();
//                var groupmodel = LdapHelper.SearchForGroup(ldapModel.ServerAddress, ldapModel.PortNumber, ldapModel.SearchBase, ldapModel.Username, ldapModel.Password);
//                LdapViewModel model = new LdapViewModel();
//                model.ServerAddress = ldapModel.ServerAddress;
//                model.PortNumber = ldapModel.PortNumber;
//                model.Username = ldapModel.Username;
//                model.Password = ldapModel.Password;
//                groupmodel.ForEach(x => model.LdapOus.Add(new LdapOuModel() { OuName = x.Key, IdentifierNameToString = String.Join('-', x.Value), IdentifierName = new List<string>(x.Value as IEnumerable<string>) }));
//                return PartialView("_OuPartialView", model);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }
//        [HttpPost]
//        public IActionResult SaveLdapOu(string oulist)
//        {
//            try
//            {
//                var existingUserList = _userLogic.GetList();
//                var ouModel = new List<string>(oulist.Split('-'));
//                ouModel.Remove(ouModel.Last());
//                var ldapModel = _ldapInfoLogic.Get();
//                var model = LdapHelper.SearchForUser(ldapModel.ServerAddress, ldapModel.PortNumber, ldapModel.SearchBase, ldapModel.Username, ldapModel.Password, new HashSet<string>(ouModel));
//                var entityModel = _mapper.Map<List<USER>>(model);
//                var lastModel = entityModel.Where(x => existingUserList.All(y => x.USERNAME != y.USERNAME)).ToList();
//                var updateModel = existingUserList.Where(x => entityModel.All(y => x.USERNAME == y.USERNAME && y.USER_ISACTIVE == false)).ToList();
//                updateModel?.ForEach(x => x.USER_ISACTIVE = false);
//                _userLogic.InsertUser(lastModel);
//                foreach (var item in updateModel)
//                {
//                    _userLogic.UpdateUser(item);
//                }

//                return Json(new { success = true, responseText = "başarılı bir şekilde eklendiler." });
//            }
//            catch (Exception ex)
//            {
//                return BadRequest("Hata meydana geldi");
//            }
//        }
//        #endregion

//        #region Schedule
//        public IActionResult ReturnLdapSchedule()
//        {
//            try
//            {
//                var ldapModel = _ldapInfoLogic.Get();
//                var groupmodel = LdapHelper.SearchForGroup(ldapModel.ServerAddress, ldapModel.PortNumber, ldapModel.SearchBase, ldapModel.Username, ldapModel.Password);
//                var model = _mapper.Map<LdapViewModel>(_ldapInfoLogic.Get());
//                groupmodel.ForEach(x => model.LdapOus.Add(new LdapOuModel() { OuName = x.Key, IdentifierNameToString = String.Join('-', x.Value), IdentifierName = new List<string>(x.Value as IEnumerable<string>) }));
//                List<SelectListItem> dayList = GetDayList();
//                dayList.Find(c => c.Value == model.DayOfWeek.ToString()).Selected = true;
//                model.DayOfWeekInit = dayList;

//                // Selected Ou
//                StringBuilder sb = new StringBuilder();
//                HashSet<string> distinct = new HashSet<string>();
//                var sou = model.SelectedOu?.Split('-');
//                if (sou == null) return PartialView("_LdapScheduleView", model);
//                foreach (var item in sou)
//                {
//                    var ouModel = item.Split(',').FirstOrDefault(x => x.Contains("OU"));
//                    if (ouModel != null) distinct.Add(ouModel);

//                }
//                model.SelectedOuModels = string.Join(',', distinct);
//                return PartialView("_LdapScheduleView", model);
//            }
//            catch (Exception ex)
//            {
//                return Json(new { success = false, responseText = "Bir hata meydana geldi : " + ex.Message });
//            }

//        }
//        public IActionResult SaveSceduleTime(string cronType, DateTime dailyTime, int dayOfWeek, int dayOfMonth, DateTime oneTime, string ouselect)
//        {
//            try
//            {
//                var ldapModel = _ldapInfoLogic.Get();
//                ldapModel.SelectedOu = ouselect;
//                switch (cronType)
//                {
//                    case "Cron.Daily":
//                        ldapModel.DailyTime = dailyTime.TimeOfDay;
//                        break;
//                    case "Cron.Weekly":
//                        ldapModel.DayOfWeek = dayOfWeek;
//                        break;
//                    case "Cron.Monthly":
//                        ldapModel.DayOfMonth = dayOfMonth;
//                        break;
//                    case "Cron.Delayed":
//                        ldapModel.OneTime = oneTime;
//                        break;
//                    default:
//                        break;
//                }

//                ldapModel.CronType = cronType;
//                _ldapInfoLogic.UpdateLdapInfo(ldapModel);

//                return Json(new { success = true, responseText = "başarılı bir şekilde eklendiler." });
//            }
//            catch (Exception ex)
//            {
//                return Json(new { success = false, responseText = "Bir hata meydana geldi : " + ex.Message });
//            }
//        }
//        #endregion

//        private static List<SelectListItem> GetDayList()
//        {
//            var model = new List<string>() { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi", "Pazar" };
//            List<SelectListItem> dayOfList = new List<SelectListItem>();
//            for (int i = 0; i < 7; i++)
//            {
//                dayOfList.Add(new SelectListItem() { Text = model[i], Value = i.ToString() });
//            }

//            return dayOfList;
//        }

//    }
//}
