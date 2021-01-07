//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using AutoMapper;
//using MES.Business;
//using MES.Entities.Model;
//using MES.Web.Models;
//using Microsoft.AspNetCore.Mvc;
//using NUglify.Helpers;

//namespace MES.Web.Controllers
//{
//    public class AuthController : Controller
//    {
//        private MenuLogic _menuLogic;
//        private UserTypeLogic _userTypeLogic;
//        private UserTypeMenuLogic _userTypeMenuLogic;
//        private IMapper _mapper;

//        public AuthController(MenuLogic MenuLogic, 
//            UserTypeLogic UserTypeLogic, 
//            UserTypeMenuLogic UserTypeMenuLogic, 
//            IMapper Mapper)
//        {
//            _menuLogic = MenuLogic;
//            _userTypeLogic = UserTypeLogic;
//            _userTypeMenuLogic = UserTypeMenuLogic;
//            _mapper = Mapper;
//        }
//        public IActionResult Index()
//        {
//            var menuModel = _mapper.Map<List<MenuViewModel>>(_menuLogic.GetAllMenu().OrderBy(x=>x.MENU_SORT));
//            var userTypeModel = _mapper.Map<List<UserTypeViewModel>>(_userTypeLogic.GetList());
//			foreach (var item in menuModel.Where(x=>x.TOPMENU_ID == null))
//			{
//				foreach (var level1 in item.SUBMENULIST)
//				{
//					foreach (var level2 in level1.SUBMENULIST)
//					{
//                        level2.RealPath = item.MENU_NAME + " --> " + level1.MENU_NAME + " --> " + level2.MENU_NAME;
//					}
//                    level1.RealPath = item.MENU_NAME + " --> " + level1.MENU_NAME;
//                }
//                item.RealPath = item.MENU_NAME;
//			}
//            AuthViewModel authViewModel = new AuthViewModel()
//            {
//                MenuList = menuModel,
//                UserTypeList = userTypeModel
//            };
//            return View(authViewModel);
//        }

//        [HttpPost]
//        public IActionResult UpdateStatus(int usertypeId,int menuId,bool checkStatus)
//        {
//            bool result = false;
//            if (checkStatus)
//                result = _userTypeMenuLogic.InsertUserTypeMenu(new USERTYPE_MENU() { UserTypeId = usertypeId, MenuId = menuId, Checked = true });
//            else
//                result = _userTypeMenuLogic.DeleteUserTypeMenu(usertypeId,menuId);
//            return Ok();
//        }

        
//    }
//}
