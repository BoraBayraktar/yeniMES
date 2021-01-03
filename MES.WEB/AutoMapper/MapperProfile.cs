using AutoMapper;
using MES.Web.Models;
using MES.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.Web.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<MENU,MenuViewModel>();
            CreateMap<USER_TYPE,UserTypeViewModel>();
            CreateMap<USERTYPE_MENU,UserTypeMenuViewModel>();
            CreateMap<USER,UserExcellViewModel>().ReverseMap();
            CreateMap<UserExcellViewModel,UserExcellSaveViewModel>();
            CreateMap<USER,UserExcellSaveViewModel>().ReverseMap();
            CreateMap<HOLDING, HoldingExcellViewModel>().ReverseMap();
            CreateMap<LOCATION, LocationExcellViewModel>().ReverseMap();
            CreateMap<COMPANY, CompanyExcellViewModel>();
            CreateMap<COMPANY, CompanyExcellSaveViewModel>().ReverseMap();
            CreateMap<DEPARTMENT, DepartmentExcellViewModel>().ReverseMap();
            CreateMap<TITLE, TitleExcellViewModel>().ReverseMap();
            CreateMap<LDAP_INFO, LdapViewModel>().ReverseMap();
            CreateMap<USER, LdapUserViewModel>().ReverseMap();
            CreateMap<LDAP_INFO, LdapViewModel>().ReverseMap();
        }
        
    }
}
