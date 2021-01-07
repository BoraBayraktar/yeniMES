//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using AutoMapper;
//using DocumentFormat.OpenXml.Packaging;
//using DocumentFormat.OpenXml.Spreadsheet;
//using ExcelDataReader;
//using MES.Business;
//using MES.Entities.Model;
//using MES.Web.Excell;
//using MES.Web.Models;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace MES.Web.Controllers
//{
//    public class ExcellController : Controller
//    {
//        private ExcellLogic _excellLogic;
//        private UserLogic _userLogic;
//        private DepartmentLogic _departmentLogic;
//        private TitleLogic _titleLogic;
//        private UserTypeLogic _userTypeLogic;
//        private LocationLogic _locationLogic;
//        private HoldingLogic _holdingLogic;
//        private CompanyLogic _companyLogic;
//        private CityLogic _cityLogic;
//        private IMapper _mapper;
//        public ExcellController(
//            ExcellLogic excellLogic,
//            UserLogic userLogic,
//            DepartmentLogic departmentLogic,
//            TitleLogic titleLogic,
//            UserTypeLogic userTypeLogic,
//            LocationLogic locationLogic,
//            HoldingLogic holdingLogic,
//            CompanyLogic companyLogic,
//            CityLogic cityLogic,
//            IMapper Mapper
//            )
//        {
//            this._excellLogic = excellLogic;
//            this._userLogic = userLogic;
//            this._departmentLogic = departmentLogic;
//            this._titleLogic = titleLogic;
//            this._userTypeLogic = userTypeLogic;
//            this._locationLogic = locationLogic;
//            this._holdingLogic = holdingLogic;
//            this._companyLogic = companyLogic;
//            this._cityLogic = cityLogic;
//            this._mapper = Mapper;
//        }

//        #region User
//        public IActionResult CreateUserExcell()
//        {
//            var asd = _userLogic.GetList();
//            var model = _mapper.Map<List<UserExcellViewModel>>(_userLogic.GetList());
//            if (model == null || model.Count == 0) return BadRequest("Herhangi bir kayıt bulunamadı!");
//            MemoryStream stream = new MemoryStream();
//            ExcellHelper.CreateUserExcelFile(ref stream, model);

//            return this.File(
//                fileContents: stream.ToArray(),
//                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
//                fileDownloadName: "Users.xlsx"
//            );
//        }

//        public IActionResult UploadUserExcell()
//        {
//            try
//            {
//                IFormFile file = Request.Form.Files[0];
//                MemoryStream ms = new MemoryStream();
//                file.CopyTo(ms);

//                var model = ExcellHelper.UploadUserExcell(ref ms);

//                if (model == null || model.Count == 0) return BadRequest("Bir hata oluştu");
//                var departmentModel = _departmentLogic.GetList();
//                var titleModel = _titleLogic.GetList();
//                var userTypeModel = _userTypeLogic.GetList();
//                var locationModel = _locationLogic.GetList();

//                var modelSaveUser = _mapper.Map<List<UserExcellSaveViewModel>>(model);
//                foreach (var item in modelSaveUser)
//                {
//                    if (item.DEPARTMENT_NAME != null)
//                        item.DEPARTMENT_ID = (departmentModel.FirstOrDefault(x => x.NAME.Replace(" ", "").ToLower().Equals(item.DEPARTMENT_NAME.Replace(" ", "").ToLower())) != null)
//                                        ? departmentModel.FirstOrDefault(x => x.NAME.Replace(" ", "").ToLower().Equals(item.DEPARTMENT_NAME.Replace(" ", "").ToLower())).DEPARTMENT_ID : 0;

//                    if (item.TITLE_NAME != null)
//                        item.TITLE_ID = (titleModel.FirstOrDefault(x => x.NAME.Replace(" ", "").ToLower().Equals(item.TITLE_NAME.Replace(" ", "").ToLower())) != null)
//                                        ? titleModel.FirstOrDefault(x => x.NAME.Replace(" ", "").ToLower().Equals(item.TITLE_NAME.Replace(" ", "").ToLower())).TITLE_ID : 0;

//                    if (item.USER_TYPE_NAME != null)
//                        item.USER_TYPE_ID = (userTypeModel.FirstOrDefault(x => x.NAME.Replace(" ", "").ToLower().Equals(item.USER_TYPE_NAME.Replace(" ", "").ToLower())) != null)
//                                        ? userTypeModel.FirstOrDefault(x => x.NAME.Replace(" ", "").ToLower().Equals(item.USER_TYPE_NAME.Replace(" ", "").ToLower())).USER_TYPE_ID : 0;

//                    if(item.LOCATION_NAME!= null)
//                        item.LOCATION_ID = (locationModel.FirstOrDefault(x => x.NAME.Replace(" ", "").ToLower().Equals(item.LOCATION_NAME.Replace(" ", "").ToLower())) != null)
//                                        ? locationModel.FirstOrDefault(x => x.NAME.Replace(" ", "").ToLower().Equals(item.LOCATION_NAME.Replace(" ", "").ToLower())).LOCATION_ID : 0;

//                }
//                var modelUser = _mapper.Map<List<USER>>(modelSaveUser);
//                _userLogic.InsertUser(modelUser);

//                return Ok("Başarılı bir şekilde yüklendi");
//            }
//            catch (Exception ex)
//            {
//                return BadRequest("Bir hata meydana geldi! Hata : " + ex.Message);
//            }
//        }
//        #endregion

//        #region Holding

//        public IActionResult CreateHoldingExcell()
//        {
//            var asd = _holdingLogic.GetList();
//            var model = _mapper.Map<List<HoldingExcellViewModel>>(_holdingLogic.GetList());
//            if (model == null || model.Count == 0) return BadRequest("Herhangi bir kayıt bulunamadı!");
//            MemoryStream stream = new MemoryStream();
//            ExcellHelper.CreateHoldingExcelFile(ref stream, model);

//            return this.File(
//                fileContents: stream.ToArray(),
//                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
//                fileDownloadName: "Holding.xlsx"
//            );
//        }

//        public IActionResult UploadHoldingExcell()
//        {
//            try
//            {
//                IFormFile file = Request.Form.Files[0];
//                MemoryStream ms = new MemoryStream();
//                file.CopyTo(ms);

//                var model = ExcellHelper.UploadHoldingExcell(ref ms);

//                if (model == null || model.Count == 0) return BadRequest("Bir hata oluştu,Lütfen Excelldeki tüm verilerin doldurulduğuna emin olunuz");
             

//                var modelSaveHolding = _mapper.Map<List<HOLDING>>(model);
          
//                _holdingLogic.InsertHolding(modelSaveHolding);

//                return Ok("Başarılı bir şekilde yüklendi");
//            }
//            catch (Exception ex)
//            {
//                return BadRequest("Bir hata meydana geldi! : " + ex.Message);
//            }
//        }

//        #endregion

//        #region Sirket

//        public IActionResult CreateCompanyExcell()
//        {
//            var asd = _companyLogic.GetList();
//            var model = _mapper.Map<List<CompanyExcellViewModel>>(_companyLogic.GetList());
//            if (model == null || model.Count == 0) return BadRequest("Herhangi bir kayıt bulunamadı!");
//            foreach (var item in model)
//            {
//                if (item.HOLDING != null) item.HOLDING_NAME = item.HOLDING.NAME;
//            }
//            MemoryStream stream = new MemoryStream();
//            ExcellHelper.CreateCompanyExcelFile(ref stream, model);

//            return this.File(
//                fileContents: stream.ToArray(),
//                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
//                fileDownloadName: "Company.xlsx"
//            );
//        }

//        public IActionResult UploadCompanyExcell()
//        {
//            try
//            {
//                IFormFile file = Request.Form.Files[0];
//                MemoryStream ms = new MemoryStream();
//                file.CopyTo(ms);

//                var model = ExcellHelper.UploadCompanyExcell(ref ms);

//                if (model == null || model.Count == 0) return BadRequest("Bir hata oluştu,Lütfen Excelldeki tüm verilerin doldurulduğuna emin olunuz");

//                var holdingModel = _holdingLogic.GetList();

//                foreach (var item in model)
//                {
//                    if (item.HOLDING_NAME != null)
//                        item.HOLDING_ID = (holdingModel.FirstOrDefault(x => x.NAME.Replace(" ", "").ToLower().Equals(item.HOLDING_NAME.Replace(" ", "").ToLower())) != null)
//                                        ? holdingModel.FirstOrDefault(x => x.NAME.Replace(" ", "").ToLower().Equals(item.HOLDING_NAME.Replace(" ", "").ToLower())).HOLDING_ID : 0;

                  
//                }
//                var modelSaveCompany = _mapper.Map<List<COMPANY>>(model);

//                _companyLogic.InsertCompany(modelSaveCompany);

//                return Ok("Başarılı bir şekilde yüklendi");
//            }
//            catch (Exception ex)
//            {
//                return BadRequest("Bir hata meydana geldi! : " + ex.Message);
//            }
//        }

//        #endregion

//        #region Şube

//        public IActionResult CreateLocationExcell()
//        {
//            var asd = _locationLogic.GetList();
//            var model = _mapper.Map<List<LocationExcellViewModel>>(_locationLogic.GetList());
//            if (model == null || model.Count == 0) return BadRequest("Herhangi bir kayıt bulunamadı!");
//            MemoryStream stream = new MemoryStream();
//            foreach (var item in model)
//            {
//                if (item.CITY != null) item.CITY_NAME = item.CITY.NAME;
//            }
//            ExcellHelper.CreateLocationExcelFile(ref stream, model);

//            return this.File(
//                fileContents: stream.ToArray(),
//                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
//                fileDownloadName: "Location.xlsx"
//            );
//        }

//        public IActionResult UploadLocationExcell()
//        {
//            try
//            {
//                IFormFile file = Request.Form.Files[0];
//                MemoryStream ms = new MemoryStream();
//                file.CopyTo(ms);

//                var model = ExcellHelper.UploadLocationExcell(ref ms);

//                if (model == null || model.Count == 0) return BadRequest("Bir hata oluştu,Lütfen Excelldeki tüm verilerin doldurulduğuna emin olunuz");

//                var cityModel = _cityLogic.GetList();

//                foreach (var item in model)
//                {
//                    if (item.CITY_NAME != null)
//                        item.CITY_ID = (cityModel.FirstOrDefault(x => x.NAME.Replace(" ", "").ToLower().Equals(item.CITY_NAME.Replace(" ", "").ToLower())) != null)
//                                        ? cityModel.FirstOrDefault(x => x.NAME.Replace(" ", "").ToLower().Equals(item.CITY_NAME.Replace(" ", "").ToLower())).CITY_ID : 0;


//                }
//                var modelSaveLocation = _mapper.Map<List<LOCATION>>(model);

//                _locationLogic.InsertLocation(modelSaveLocation);

//                return Ok("Başarılı bir şekilde yüklendi");
//            }
//            catch (Exception ex)
//            {
//                return BadRequest("Bir hata meydana geldi! : " + ex.Message);
//            }
//        }

//        #endregion

//        #region Department
//        public IActionResult CreateDepartmenExcell()
//        {
//            var asd = _departmentLogic.GetList();
//            var model = _mapper.Map<List<DepartmentExcellViewModel>>(_departmentLogic.GetList());
//            if (model == null || model.Count == 0) return BadRequest("Herhangi bir kayıt bulunamadı!");
//            foreach (var item in model)
//            {
//                if (item.COMPANY != null) item.COMPANY_NAME = item.COMPANY.NAME;
//            }
//            MemoryStream stream = new MemoryStream();
//            ExcellHelper.CreateDepartmentExcelFile(ref stream, model);

//            return this.File(
//                fileContents: stream.ToArray(),
//                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
//                fileDownloadName: "Department.xlsx"
//            );
//        }

//        public IActionResult UploadDepartmentExcell()
//        {
//            try
//            {
//                IFormFile file = Request.Form.Files[0];
//                MemoryStream ms = new MemoryStream();
//                file.CopyTo(ms);

//                var model = ExcellHelper.UploadDepartmentExcell(ref ms);

//                if (model == null || model.Count == 0) return BadRequest("Bir hata oluştu,Lütfen Excelldeki tüm verilerin doldurulduğuna emin olunuz");

//                var companyModel = _companyLogic.GetList();

//                foreach (var item in model)
//                {
//                    if (item.COMPANY_NAME != null)
//                        item.COMPANY_ID= (companyModel.FirstOrDefault(x => x.NAME.Replace(" ", "").ToLower().Equals(item.COMPANY_NAME.Replace(" ", "").ToLower())) != null)
//                                        ? companyModel.FirstOrDefault(x => x.NAME.Replace(" ", "").ToLower().Equals(item.COMPANY_NAME.Replace(" ", "").ToLower())).COMPANY_ID : 0;


//                }
//                var modelSaveDepartment = _mapper.Map<List<DEPARTMENT>>(model);

//                _departmentLogic.InsertDepartment(modelSaveDepartment);

//                return Ok("Başarılı bir şekilde yüklendi");
//            }
//            catch (Exception ex)
//            {
//                return BadRequest("Bir hata meydana geldi! : " + ex.Message);
//            }
//        }
//        #endregion

//        #region Title
//        public IActionResult CreateTitleExcell()
//        {
//            var asd = _titleLogic.GetList();
//            var model = _mapper.Map<List<TitleExcellViewModel>>(_titleLogic.GetList());
//            if (model == null || model.Count == 0) return BadRequest("Herhangi bir kayıt bulunamadı!");
//            MemoryStream stream = new MemoryStream();
//            ExcellHelper.CreateTitleExcelFile(ref stream, model);

//            return this.File(
//                fileContents: stream.ToArray(),
//                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
//                fileDownloadName: "Title.xlsx"
//            );
//        }

//        public IActionResult UploadTitleExcell()
//        {
//            try
//            {
//                IFormFile file = Request.Form.Files[0];
//                MemoryStream ms = new MemoryStream();
//                file.CopyTo(ms);

//                var model = ExcellHelper.UploadTitleExcell(ref ms);

//                if (model == null || model.Count == 0) return BadRequest("Bir hata oluştu,Lütfen Excelldeki tüm verilerin doldurulduğuna emin olunuz");
            
//                var modelSaveTitle = _mapper.Map<List<TITLE>>(model);

//                _titleLogic.InsertTitle(modelSaveTitle);

//                return Ok("Başarılı bir şekilde yüklendi");
//            }
//            catch (Exception ex)
//            {
//                return BadRequest("Bir hata meydana geldi!");
//            }
//        }

//        #endregion

//        #region Functions

//        public IActionResult DownloadExcellTemplate(string parameter)
//        {
//            try
//            {
//                List<string> templateString = new List<string>();
//                MemoryStream stream = new MemoryStream();
//                switch (parameter)
//                {
//                    case "user":
//                        templateString.Add("ADI");
//                        templateString.Add("SOYADI");
//                        templateString.Add("KULLANICI ADI");
//                        templateString.Add("EPOSTA");
//                        templateString.Add("DEPARTMAN");
//                        templateString.Add("UNVAN");
//                        templateString.Add("KULLANICI TİPİ");
//                        templateString.Add("ŞUBE");
//                        ExcellHelper.CreateExcelFileTemplate(ref stream, templateString);
//                        break;
//                    case "holding":
//                        templateString.Add("ADI");
//                        templateString.Add("AÇIKLAMA");
//                        ExcellHelper.CreateExcelFileTemplate(ref stream, templateString);
//                        break;
//                    case "company":
//                        templateString.Add("ADI");
//                        templateString.Add("AÇIKLAMA");
//                        templateString.Add("HOLDİNG");
//                        ExcellHelper.CreateExcelFileTemplate(ref stream, templateString);
//                        break;   
//                    case "location":
//                        templateString.Add("ADI");
//                        templateString.Add("ŞEHİR");
//                        ExcellHelper.CreateExcelFileTemplate(ref stream, templateString);
//                        break;  
//                    case "department":
//                        templateString.Add("ADI");
//                        templateString.Add("AÇIKLAMA");
//                        templateString.Add("ŞİRKET");
//                        ExcellHelper.CreateExcelFileTemplate(ref stream, templateString);
//                        break;  
//                    case "title":
//                        templateString.Add("ADI");
//                        templateString.Add("AÇIKLAMA");
//                        ExcellHelper.CreateExcelFileTemplate(ref stream, templateString);
//                        break;
//                    default:
//                        break;
//                }

//                return this.File(
//                    fileContents: stream.ToArray(),
//                    contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
//                    fileDownloadName: "Template.xlsx"
//                );
//            }
//            catch (Exception)
//            {
//                return BadRequest("Bir hata oluştu");
//                throw;
//            }


//        }

//        #endregion
//    }
//}
