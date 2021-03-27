using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MES.Web.Model;
using MES.Web.Models;
using MES.Web.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MES.Web.Controllers
{
    public class AuthController : Controller
    {
        ServiceBusiness serviceBusiness;
        private IMapper _mapper;
        public AuthController(IHttpContextAccessor accessor, IConfiguration configuration, IMapper mapper)
        {
            _mapper = mapper;
            serviceBusiness = new ServiceBusiness(configuration, accessor);
        }
        public IActionResult Index()
        {
            var menuModel = _mapper.Map<List<MenuViewModel>>(serviceBusiness.ServiceGet<List<MENU>>("Menu","MenuGetList").OrderBy(x => x.MENU_SORT));
            var userTypeModel = _mapper.Map<List<UserTypeViewModel>>(serviceBusiness.ServiceGet<List<USER_TYPE>>("UserType", "UserTypeGetList"));
            foreach (var item in menuModel.Where(x => x.TOPMENU_ID == null))
            {
                foreach (var level1 in item.SUBMENULIST)
                {
                    foreach (var level2 in level1.SUBMENULIST)
                    {
                        level2.RealPath = item.MENU_NAME + " --> " + level1.MENU_NAME + " --> " + level2.MENU_NAME;
                    }
                    level1.RealPath = item.MENU_NAME + " --> " + level1.MENU_NAME;
                }
                item.RealPath = item.MENU_NAME;
            }
            AuthViewModel authViewModel = new AuthViewModel()
            {
                MenuList = menuModel,
                UserTypeList = userTypeModel
            };
            return View(authViewModel);
        }

        [HttpPost]
        public IActionResult UpdateStatus(int usertypeId, int menuId, bool checkStatus)
        {
            bool result = false;
            if (checkStatus)
                result = serviceBusiness.ServicePost<bool>(new USERTYPE_MENU() { UserTypeId = usertypeId, MenuId = menuId, Checked = true }, "UserTypeMenu", "InsertUserTypeMenu");
            else
                result = serviceBusiness.ServicePost<bool>(new USERTYPE_MENU(){ UserTypeId = usertypeId, MenuId = menuId, Checked =         true }, "UserTypeMenu", "InsertUserTypeMenu");
            return Ok();
        }


    }
}
