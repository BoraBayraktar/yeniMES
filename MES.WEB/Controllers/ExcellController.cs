using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using ExcelDataReader;
using MES.DB.Model;
using MES.Web.Excell;
using MES.Web.Models;
using MES.Web.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MES.Web.Controllers
{
    public class ExcellController : Controller
    {
        #region Instance
        ServiceBusiness serviceBusiness;
        //private ExcellLogic _excellLogic;
        //private UserLogic _userLogic;
        //private DepartmentLogic _departmentLogic;
        //private TitleLogic _titleLogic;
        //private UserTypeLogic _userTypeLogic;
        //private LocationLogic _locationLogic;
        //private HoldingLogic _holdingLogic;
        //private CompanyLogic _companyLogic;
        //private CityLogic _cityLogic;
        private IMapper _mapper;
        #endregion
        public ExcellController(IConfiguration configuration, IHttpContextAccessor accessor, IMapper Mapper)
        {
            serviceBusiness = new ServiceBusiness(configuration, accessor);
            this._mapper = Mapper;
        }

        #region User
        public IActionResult CreateUserExcell()
        {
            var asd = serviceBusiness.ServiceGet<List<USER>>("User", "UserGetList");
            var model = _mapper.Map<List<UserExcellViewModel>>(serviceBusiness.ServiceGet<List<USER>>("User", "UserGetList"));
            if (model == null || model.Count == 0) return BadRequest("Herhangi bir kayıt bulunamadı!");
            MemoryStream stream = new MemoryStream();
            ExcellHelper.CreateUserExcelFile(ref stream, model);

            return this.File(
                fileContents: stream.ToArray(),
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "Users.xlsx"
            );
        }

        public IActionResult UploadUserExcell()
        {
            try
            {
                IFormFile file = Request.Form.Files[0];
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);

                var model = ExcellHelper.UploadUserExcell(ref ms);

                if (model == null || model.Count == 0) return BadRequest("Bir hata oluştu");
                var departmentModel = serviceBusiness.ServiceGet<List<DEPARTMENT>>("Department", "DepartmentGetList"); 
                var titleModel = serviceBusiness.ServiceGet<List<TITLE>>("Title", "TitleGetList"); 
                var userTypeModel = serviceBusiness.ServiceGet<List<USER_TYPE>>("UserType", "UserTypeGetList"); 
                var locationModel = serviceBusiness.ServiceGet<List<LOCATION>>("Location", "LocationGetList"); 

                var modelSaveUser = _mapper.Map<List<UserExcellSaveViewModel>>(model);
                foreach (var item in modelSaveUser)
                {
                    if (item.DEPARTMENT_NAME != null)
                        item.DEPARTMENT_ID = (departmentModel.FirstOrDefault(x => x.NAME.Replace(" ", "").ToLower().Equals(item.DEPARTMENT_NAME.Replace(" ", "").ToLower())) != null)
                                        ? departmentModel.FirstOrDefault(x => x.NAME.Replace(" ", "").ToLower().Equals(item.DEPARTMENT_NAME.Replace(" ", "").ToLower())).DEPARTMENT_ID : 0;

                    if (item.TITLE_NAME != null)
                        item.TITLE_ID = (titleModel.FirstOrDefault(x => x.NAME.Replace(" ", "").ToLower().Equals(item.TITLE_NAME.Replace(" ", "").ToLower())) != null)
                                        ? titleModel.FirstOrDefault(x => x.NAME.Replace(" ", "").ToLower().Equals(item.TITLE_NAME.Replace(" ", "").ToLower())).TITLE_ID : 0;

                    if (item.USER_TYPE_NAME != null)
                        item.USER_TYPE_ID = (userTypeModel.FirstOrDefault(x => x.NAME.Replace(" ", "").ToLower().Equals(item.USER_TYPE_NAME.Replace(" ", "").ToLower())) != null)
                                        ? userTypeModel.FirstOrDefault(x => x.NAME.Replace(" ", "").ToLower().Equals(item.USER_TYPE_NAME.Replace(" ", "").ToLower())).USER_TYPE_ID : 0;

                    if (item.LOCATION_NAME != null)
                        item.LOCATION_ID = (locationModel.FirstOrDefault(x => x.NAME.Replace(" ", "").ToLower().Equals(item.LOCATION_NAME.Replace(" ", "").ToLower())) != null)
                                        ? locationModel.FirstOrDefault(x => x.NAME.Replace(" ", "").ToLower().Equals(item.LOCATION_NAME.Replace(" ", "").ToLower())).LOCATION_ID : 0;

                }
                var modelUser = _mapper.Map<List<USER>>(modelSaveUser);
                serviceBusiness.ServicePost<bool>(modelUser, "User", "InsertUser"); 

                return Ok("Başarılı bir şekilde yüklendi");
            }
            catch (Exception ex)
            {
                return BadRequest("Bir hata meydana geldi! Hata : " + ex.Message);
            }
        }
        #endregion

        #region Holding

        public IActionResult CreateHoldingExcell()
        {
            var asd = serviceBusiness.ServiceGet<List<HOLDING>>("Holding", "HoldingGetList");
            var model = _mapper.Map<List<HoldingExcellViewModel>>(serviceBusiness.ServiceGet<List<HOLDING>>("Holding", "HoldingGetList"));
            if (model == null || model.Count == 0) return BadRequest("Herhangi bir kayıt bulunamadı!");
            MemoryStream stream = new MemoryStream();
            ExcellHelper.CreateHoldingExcelFile(ref stream, model);

            return this.File(
                fileContents: stream.ToArray(),
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "Holding.xlsx"
            );
        }

        public IActionResult UploadHoldingExcell()
        {
            try
            {
                IFormFile file = Request.Form.Files[0];
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);

                var model = ExcellHelper.UploadHoldingExcell(ref ms);

                if (model == null || model.Count == 0) return BadRequest("Bir hata oluştu,Lütfen Excelldeki tüm verilerin doldurulduğuna emin olunuz");


                var modelSaveHolding = _mapper.Map<List<HOLDING>>(model);
                serviceBusiness.ServicePost<bool>(modelSaveHolding, "Holding", "InsertHolding");
               

                return Ok("Başarılı bir şekilde yüklendi");
            }
            catch (Exception ex)
            {
                return BadRequest("Bir hata meydana geldi! : " + ex.Message);
            }
        }

        #endregion

        #region Sirket

        public IActionResult CreateCompanyExcell()
        {
            var asd = serviceBusiness.ServiceGet<List<COMPANY>>("Company", "CompanyGetList");
            var model = _mapper.Map<List<CompanyExcellViewModel>>(serviceBusiness.ServiceGet<List<COMPANY>>("Company", "CompanyGetList"));
            if (model == null || model.Count == 0) return BadRequest("Herhangi bir kayıt bulunamadı!");
            foreach (var item in model)
            {
                if (item.HOLDING != null) item.HOLDING_NAME = item.HOLDING.NAME;
            }
            MemoryStream stream = new MemoryStream();
            ExcellHelper.CreateCompanyExcelFile(ref stream, model);

            return this.File(
                fileContents: stream.ToArray(),
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "Company.xlsx"
            );
        }

        public IActionResult UploadCompanyExcell()
        {
            try
            {
                IFormFile file = Request.Form.Files[0];
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);

                var model = ExcellHelper.UploadCompanyExcell(ref ms);

                if (model == null || model.Count == 0) return BadRequest("Bir hata oluştu,Lütfen Excelldeki tüm verilerin doldurulduğuna emin olunuz");

                var holdingModel = serviceBusiness.ServiceGet<List<COMPANY>>("Company", "HoldingGetList");

                foreach (var item in model)
                {
                    if (item.HOLDING_NAME != null)
                        item.HOLDING_ID = (holdingModel.FirstOrDefault(x => x.NAME.Replace(" ", "").ToLower().Equals(item.HOLDING_NAME.Replace(" ", "").ToLower())) != null)
                                        ? holdingModel.FirstOrDefault(x => x.NAME.Replace(" ", "").ToLower().Equals(item.HOLDING_NAME.Replace(" ", "").ToLower())).HOLDING_ID : 0;


                }
                var modelSaveCompany = _mapper.Map<List<COMPANY>>(model);

                serviceBusiness.ServicePost<bool>(modelSaveCompany, "Company", "InsertCompany");

                return Ok("Başarılı bir şekilde yüklendi");
            }
            catch (Exception ex)
            {
                return BadRequest("Bir hata meydana geldi! : " + ex.Message);
            }
        }

        #endregion

        #region Şube

        public IActionResult CreateLocationExcell()
        {
            var asd = serviceBusiness.ServiceGet<List<LOCATION>>("Location", "LocationGetList");
            var model = _mapper.Map<List<LocationExcellViewModel>>(serviceBusiness.ServiceGet<List<LOCATION>>("Location", "LocationGetList"));
            if (model == null || model.Count == 0) return BadRequest("Herhangi bir kayıt bulunamadı!");
            MemoryStream stream = new MemoryStream();
            foreach (var item in model)
            {
                if (item.CITY != null) item.CITY_NAME = item.CITY.NAME;
            }
            ExcellHelper.CreateLocationExcelFile(ref stream, model);

            return this.File(
                fileContents: stream.ToArray(),
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "Location.xlsx"
            );
        }

        public IActionResult UploadLocationExcell()
        {
            try
            {
                IFormFile file = Request.Form.Files[0];
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);

                var model = ExcellHelper.UploadLocationExcell(ref ms);

                if (model == null || model.Count == 0) return BadRequest("Bir hata oluştu,Lütfen Excelldeki tüm verilerin doldurulduğuna emin olunuz");

                var cityModel = serviceBusiness.ServiceGet<List<LOCATION>>("Location", "LocationGetList");

                foreach (var item in model)
                {
                    if (item.CITY_NAME != null)
                        item.CITY_ID = (cityModel.FirstOrDefault(x => x.NAME.Replace(" ", "").ToLower().Equals(item.CITY_NAME.Replace(" ", "").ToLower())) != null)
                                        ? cityModel.FirstOrDefault(x => x.NAME.Replace(" ", "").ToLower().Equals(item.CITY_NAME.Replace(" ", "").ToLower())).CITY_ID : 0;


                }
                var modelSaveLocation = _mapper.Map<List<LOCATION>>(model);

                serviceBusiness.ServicePost<bool>(modelSaveLocation, "Location", "InsertLocation");

                return Ok("Başarılı bir şekilde yüklendi");
            }
            catch (Exception ex)
            {
                return BadRequest("Bir hata meydana geldi! : " + ex.Message);
            }
        }

        #endregion

        #region Department
        public IActionResult CreateDepartmenExcell()
        {
            var asd = serviceBusiness.ServiceGet<List<DEPARTMENT>>("Department", "DepartmentGetList");
            var model = _mapper.Map<List<DepartmentExcellViewModel>>(serviceBusiness.ServiceGet<List<DEPARTMENT>>("Department", "DepartmentGetList"));
            if (model == null || model.Count == 0) return BadRequest("Herhangi bir kayıt bulunamadı!");
            foreach (var item in model)
            {
                if (item.COMPANY != null) item.COMPANY_NAME = item.COMPANY.NAME;
            }
            MemoryStream stream = new MemoryStream();
            ExcellHelper.CreateDepartmentExcelFile(ref stream, model);

            return this.File(
                fileContents: stream.ToArray(),
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "Department.xlsx"
            );
        }

        public IActionResult UploadDepartmentExcell()
        {
            try
            {
                IFormFile file = Request.Form.Files[0];
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);

                var model = ExcellHelper.UploadDepartmentExcell(ref ms);

                if (model == null || model.Count == 0) return BadRequest("Bir hata oluştu,Lütfen Excelldeki tüm verilerin doldurulduğuna emin olunuz");

                var companyModel = serviceBusiness.ServiceGet<List<COMPANY>>("Company", "CompanyGetList");

                foreach (var item in model)
                {
                    if (item.COMPANY_NAME != null)
                        item.COMPANY_ID = (companyModel.FirstOrDefault(x => x.NAME.Replace(" ", "").ToLower().Equals(item.COMPANY_NAME.Replace(" ", "").ToLower())) != null)
                                        ? companyModel.FirstOrDefault(x => x.NAME.Replace(" ", "").ToLower().Equals(item.COMPANY_NAME.Replace(" ", "").ToLower())).COMPANY_ID : 0;


                }
                var modelSaveDepartment = _mapper.Map<List<DEPARTMENT>>(model);

                serviceBusiness.ServicePost<bool>(modelSaveDepartment, "Department", "InsertDepartment");

                return Ok("Başarılı bir şekilde yüklendi");
            }
            catch (Exception ex)
            {
                return BadRequest("Bir hata meydana geldi! : " + ex.Message);
            }
        }
        #endregion

        #region Title
        public IActionResult CreateTitleExcell()
        {
            var asd = serviceBusiness.ServiceGet<List<TITLE>>("Title", "TitleGetList");
            var model = _mapper.Map<List<TitleExcellViewModel>>(serviceBusiness.ServiceGet<List<TITLE>>("Title", "TitleGetList"));
            if (model == null || model.Count == 0) return BadRequest("Herhangi bir kayıt bulunamadı!");
            MemoryStream stream = new MemoryStream();
            ExcellHelper.CreateTitleExcelFile(ref stream, model);

            return this.File(
                fileContents: stream.ToArray(),
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "Title.xlsx"
            );
        }

        public IActionResult UploadTitleExcell()
        {
            try
            {
                IFormFile file = Request.Form.Files[0];
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);

                var model = ExcellHelper.UploadTitleExcell(ref ms);

                if (model == null || model.Count == 0) return BadRequest("Bir hata oluştu,Lütfen Excelldeki tüm verilerin doldurulduğuna emin olunuz");

                var modelSaveTitle = _mapper.Map<List<TITLE>>(model);

                serviceBusiness.ServicePost<bool>(modelSaveTitle, "Title", "InsertTitle");

                return Ok("Başarılı bir şekilde yüklendi");
            }
            catch (Exception ex)
            {
                return BadRequest("Bir hata meydana geldi!");
            }
        }

        #endregion

        #region Functions

        public IActionResult DownloadExcellTemplate(string parameter)
        {
            try
            {
                List<string> templateString = new List<string>();
                MemoryStream stream = new MemoryStream();
                switch (parameter)
                {
                    case "user":
                        templateString.Add("ADI");
                        templateString.Add("SOYADI");
                        templateString.Add("KULLANICI ADI");
                        templateString.Add("EPOSTA");
                        templateString.Add("DEPARTMAN");
                        templateString.Add("UNVAN");
                        templateString.Add("KULLANICI TİPİ");
                        templateString.Add("ŞUBE");
                        ExcellHelper.CreateExcelFileTemplate(ref stream, templateString);
                        break;
                    case "holding":
                        templateString.Add("ADI");
                        templateString.Add("AÇIKLAMA");
                        ExcellHelper.CreateExcelFileTemplate(ref stream, templateString);
                        break;
                    case "company":
                        templateString.Add("ADI");
                        templateString.Add("AÇIKLAMA");
                        templateString.Add("HOLDİNG");
                        ExcellHelper.CreateExcelFileTemplate(ref stream, templateString);
                        break;
                    case "location":
                        templateString.Add("ADI");
                        templateString.Add("ŞEHİR");
                        ExcellHelper.CreateExcelFileTemplate(ref stream, templateString);
                        break;
                    case "department":
                        templateString.Add("ADI");
                        templateString.Add("AÇIKLAMA");
                        templateString.Add("ŞİRKET");
                        ExcellHelper.CreateExcelFileTemplate(ref stream, templateString);
                        break;
                    case "title":
                        templateString.Add("ADI");
                        templateString.Add("AÇIKLAMA");
                        ExcellHelper.CreateExcelFileTemplate(ref stream, templateString);
                        break;
                    default:
                        break;
                }

                return this.File(
                    fileContents: stream.ToArray(),
                    contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    fileDownloadName: "Template.xlsx"
                );
            }
            catch (Exception)
            {
                return BadRequest("Bir hata oluştu");
                throw;
            }


        }

        #endregion
    }
}
