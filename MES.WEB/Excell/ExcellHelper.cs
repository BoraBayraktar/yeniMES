using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using MES.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MES.Web.Excell
{
    public class ExcellHelper
    {
        #region User
        public static void CreateUserExcelFile(ref MemoryStream stream, List<UserExcellViewModel> userModels)
        {

            using (SpreadsheetDocument spreedDoc = SpreadsheetDocument.Create(stream,
                DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart wbPart = spreedDoc.WorkbookPart;
                if (wbPart == null)
                {
                    wbPart = spreedDoc.AddWorkbookPart();
                    wbPart.Workbook = new Workbook();
                }

                string sheetName = "Kullanıcılar";
                WorksheetPart worksheetPart = null;
                worksheetPart = wbPart.AddNewPart<WorksheetPart>();
                var sheetData = new SheetData();

                worksheetPart.Worksheet = new Worksheet(sheetData);

                if (wbPart.Workbook.Sheets == null)
                {
                    wbPart.Workbook.AppendChild<Sheets>(new Sheets());
                }

                var sheet = new Sheet()
                {
                    Id = wbPart.GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = sheetName
                };

                var workingSheet = ((WorksheetPart)wbPart.GetPartById(sheet.Id)).Worksheet;

                int rowindex = 1;
                Row row = new Row();
                row.RowIndex = (UInt32)rowindex;
                row.AppendChild(AddCellWithText("ADI"));
                row.AppendChild(AddCellWithText("SOYADI"));
                row.AppendChild(AddCellWithText("KULLANICI ADI"));
                row.AppendChild(AddCellWithText("EPOSTA"));
                row.AppendChild(AddCellWithText("DEPARTMAN"));
                row.AppendChild(AddCellWithText("UNVAN"));
                row.AppendChild(AddCellWithText("KULLANICI TİPİ"));
                row.AppendChild(AddCellWithText("ŞUBE"));
                sheetData.AppendChild(row);


                foreach (var item in userModels)
                {
                    rowindex++;
                    row = new Row();
                    row.RowIndex = (UInt32)rowindex;
                    row.AppendChild(AddCellWithText(item.NAME));
                    row.AppendChild(AddCellWithText(item.SURNAME));
                    row.AppendChild(AddCellWithText(item.USERNAME));
                    row.AppendChild(AddCellWithText(item.EMAIL));
                    row.AppendChild(AddCellWithText(item.DEPARTMENT_NAME));
                    row.AppendChild(AddCellWithText(item.TITLE_NAME));
                    row.AppendChild(AddCellWithText(item.USER_TYPE_NAME));
                    row.AppendChild(AddCellWithText(item.LOCATION_NAME));
                    sheetData.AppendChild(row);
                }


                wbPart.Workbook.Sheets.AppendChild(sheet);
                wbPart.Workbook.Save();
            }
        }

        public static List<UserExcellViewModel> UploadUserExcell(ref MemoryStream stream)
        {
            List<UserExcellViewModel> returnValue = new List<UserExcellViewModel>();
            using (SpreadsheetDocument doc = SpreadsheetDocument.Open(stream, false))
            {
                Sheet sheet = (doc.WorkbookPart.Workbook.Sheets.ElementAt(0) as Sheet);
                Worksheet worksheet = (doc.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart).Worksheet;
                IEnumerable<Row> rows = worksheet.GetFirstChild<SheetData>().Descendants<Row>();


                int i = 0;
                foreach (Row r in rows)
                {
                    i++;
                    if (i == 1)
                    {
                        continue;
                    }
                    int j = 1;
                    UserExcellViewModel uewm = new UserExcellViewModel();
                    foreach (Cell cell in r.Descendants<Cell>())
                    {
                        if (GetCellValue(doc, cell).Any())
                        {
                            switch (cell.CellReference.InnerText[0])
                            {
                                case 'A':
                                    uewm.NAME = GetCellValue(doc, cell);
                                    break;
                                case 'B':
                                    uewm.SURNAME = GetCellValue(doc, cell);
                                    break;
                                case 'C':
                                    uewm.USERNAME = GetCellValue(doc, cell);
                                    break;
                                case 'D':
                                    uewm.EMAIL = GetCellValue(doc, cell);
                                    break;
                                case 'E':
                                    uewm.DEPARTMENT_NAME = GetCellValue(doc, cell);
                                    break;
                                case 'F':
                                    uewm.TITLE_NAME = GetCellValue(doc, cell);
                                    break;
                                case 'G':
                                    uewm.USER_TYPE_NAME = GetCellValue(doc, cell);
                                    break;
                                case 'H':
                                    uewm.LOCATION_NAME = GetCellValue(doc, cell);
                                    break;

                                default: break;
                            }
                        }
                        j++;

                    }
                    if (uewm.NAME != null)
                        returnValue.Add(uewm);
                }
            }
            return returnValue;
        }

        #endregion

        #region Holding

        public static void CreateHoldingExcelFile(ref MemoryStream stream, List<HoldingExcellViewModel> holdingModels)
        {

            using (SpreadsheetDocument spreedDoc = SpreadsheetDocument.Create(stream,
                DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart wbPart = spreedDoc.WorkbookPart;
                if (wbPart == null)
                {
                    wbPart = spreedDoc.AddWorkbookPart();
                    wbPart.Workbook = new Workbook();
                }

                string sheetName = "Holdingler";
                WorksheetPart worksheetPart = null;
                worksheetPart = wbPart.AddNewPart<WorksheetPart>();
                var sheetData = new SheetData();

                worksheetPart.Worksheet = new Worksheet(sheetData);

                if (wbPart.Workbook.Sheets == null)
                {
                    wbPart.Workbook.AppendChild<Sheets>(new Sheets());
                }

                var sheet = new Sheet()
                {
                    Id = wbPart.GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = sheetName
                };

                var workingSheet = ((WorksheetPart)wbPart.GetPartById(sheet.Id)).Worksheet;

                int rowindex = 1;
                Row row = new Row();
                row.RowIndex = (UInt32)rowindex;
                row.AppendChild(AddCellWithText("ADI"));
                row.AppendChild(AddCellWithText("AÇIKLAMA"));
                sheetData.AppendChild(row);


                foreach (var item in holdingModels)
                {
                    rowindex++;
                    row = new Row();
                    row.RowIndex = (UInt32)rowindex;
                    row.AppendChild(AddCellWithText(item.NAME));
                    row.AppendChild(AddCellWithText(item.DESCRIPTION));
                    sheetData.AppendChild(row);
                }
                wbPart.Workbook.Sheets.AppendChild(sheet);
                wbPart.Workbook.Save();
            }
        }

        public static List<HoldingExcellViewModel> UploadHoldingExcell(ref MemoryStream stream)
        {
            List<HoldingExcellViewModel> returnValue = new List<HoldingExcellViewModel>();
            using (SpreadsheetDocument doc = SpreadsheetDocument.Open(stream, false))
            {
                Sheet sheet = (doc.WorkbookPart.Workbook.Sheets.ElementAt(0) as Sheet);
                Worksheet worksheet = (doc.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart).Worksheet;
                IEnumerable<Row> rows = worksheet.GetFirstChild<SheetData>().Descendants<Row>();

                int i = 0;
                foreach (Row r in rows)
                {
                    i++;
                    if (i == 1 )
                    {
                        continue;
                    }
                  
                    int j = 1;
                    HoldingExcellViewModel hoewm = new HoldingExcellViewModel();
                    foreach (Cell cell in r.Descendants<Cell>())
                    {
                        if (GetCellValue(doc, cell).Any())
                        {
                            switch (cell.CellReference.InnerText[0])
                            {
                                case 'A':
                                    hoewm.NAME = GetCellValue(doc, cell);
                                    break;
                                case 'B':
                                    hoewm.DESCRIPTION = GetCellValue(doc, cell);
                                    break;
                                default: break;
                            }
                        }
                        j++;

                    }
                    if(hoewm.NAME != null)
                        returnValue.Add(hoewm);
                }
            }
            return returnValue;
        }
        #endregion

        #region Company 

        public static void CreateCompanyExcelFile(ref MemoryStream stream, List<CompanyExcellViewModel> userModels)
        {

            using (SpreadsheetDocument spreedDoc = SpreadsheetDocument.Create(stream,
                DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart wbPart = spreedDoc.WorkbookPart;
                if (wbPart == null)
                {
                    wbPart = spreedDoc.AddWorkbookPart();
                    wbPart.Workbook = new Workbook();
                }

                string sheetName = "Holdingler";
                WorksheetPart worksheetPart = null;
                worksheetPart = wbPart.AddNewPart<WorksheetPart>();
                var sheetData = new SheetData();

                worksheetPart.Worksheet = new Worksheet(sheetData);

                if (wbPart.Workbook.Sheets == null)
                {
                    wbPart.Workbook.AppendChild<Sheets>(new Sheets());
                }

                var sheet = new Sheet()
                {
                    Id = wbPart.GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = sheetName
                };

                var workingSheet = ((WorksheetPart)wbPart.GetPartById(sheet.Id)).Worksheet;

                int rowindex = 1;
                Row row = new Row();
                row.RowIndex = (UInt32)rowindex;
                row.AppendChild(AddCellWithText("ADI"));
                row.AppendChild(AddCellWithText("AÇIKLAMA"));
                row.AppendChild(AddCellWithText("HOLDİNG"));
                sheetData.AppendChild(row);


                foreach (var item in userModels)
                {
                    rowindex++;
                    row = new Row();
                    row.RowIndex = (UInt32)rowindex;
                    row.AppendChild(AddCellWithText(item.NAME));
                    row.AppendChild(AddCellWithText(item.DESCRIPTION));
                    row.AppendChild(AddCellWithText(item.HOLDING_NAME));
                    sheetData.AppendChild(row);
                }
                wbPart.Workbook.Sheets.AppendChild(sheet);
                wbPart.Workbook.Save();
            }
        }

        public static List<CompanyExcellSaveViewModel> UploadCompanyExcell(ref MemoryStream stream)
        {
            List<CompanyExcellSaveViewModel> returnValue = new List<CompanyExcellSaveViewModel>();
            using (SpreadsheetDocument doc = SpreadsheetDocument.Open(stream, false))
            {
                Sheet sheet = (doc.WorkbookPart.Workbook.Sheets.ElementAt(0) as Sheet);
                Worksheet worksheet = (doc.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart).Worksheet;
                IEnumerable<Row> rows = worksheet.GetFirstChild<SheetData>().Descendants<Row>();

                int i = 0;
                foreach (Row r in rows)
                {
                    i++;
                    if (i == 1)
                    {
                        continue;
                    }
                    int j = 1;
                    CompanyExcellSaveViewModel cewm = new CompanyExcellSaveViewModel();
                    foreach (Cell cell in r.Descendants<Cell>())
                    {
                        if (GetCellValue(doc, cell).Any())
                        {
                            switch (cell.CellReference.InnerText[0])
                            {
                                case 'A':
                                    cewm.NAME = GetCellValue(doc, cell);
                                    break;
                                case 'B':
                                    cewm.DESCRIPTION = GetCellValue(doc, cell);
                                    break;
                                case 'C':
                                    cewm.HOLDING_NAME = GetCellValue(doc, cell);
                                    break;
                                default: break;
                            }
                        }
                        j++;

                    }
                    if (cewm.NAME != null)
                        returnValue.Add(cewm);
                }
            }
            return returnValue;
        }
        #endregion

        #region Location
        public static void CreateLocationExcelFile(ref MemoryStream stream, List<LocationExcellViewModel> locationModels)
        {

            using (SpreadsheetDocument spreedDoc = SpreadsheetDocument.Create(stream,
                DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart wbPart = spreedDoc.WorkbookPart;
                if (wbPart == null)
                {
                    wbPart = spreedDoc.AddWorkbookPart();
                    wbPart.Workbook = new Workbook();
                }

                string sheetName = "Şubeler";
                WorksheetPart worksheetPart = null;
                worksheetPart = wbPart.AddNewPart<WorksheetPart>();
                var sheetData = new SheetData();

                worksheetPart.Worksheet = new Worksheet(sheetData);

                if (wbPart.Workbook.Sheets == null)
                {
                    wbPart.Workbook.AppendChild<Sheets>(new Sheets());
                }

                var sheet = new Sheet()
                {
                    Id = wbPart.GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = sheetName
                };

                var workingSheet = ((WorksheetPart)wbPart.GetPartById(sheet.Id)).Worksheet;

                int rowindex = 1;
                Row row = new Row();
                row.RowIndex = (UInt32)rowindex;
                row.AppendChild(AddCellWithText("ADI"));
                row.AppendChild(AddCellWithText("ŞEHİR"));
                sheetData.AppendChild(row);


                foreach (var item in locationModels)
                {
                    rowindex++;
                    row = new Row();
                    row.RowIndex = (UInt32)rowindex;
                    row.AppendChild(AddCellWithText(item.NAME));
                    row.AppendChild(AddCellWithText(item.CITY_NAME));
                    sheetData.AppendChild(row);
                }
                wbPart.Workbook.Sheets.AppendChild(sheet);
                wbPart.Workbook.Save();
            }
        }

        public static List<LocationExcellViewModel> UploadLocationExcell(ref MemoryStream stream)
        {
            List<LocationExcellViewModel> returnValue = new List<LocationExcellViewModel>();
            using (SpreadsheetDocument doc = SpreadsheetDocument.Open(stream, false))
            {
                Sheet sheet = (doc.WorkbookPart.Workbook.Sheets.ElementAt(0) as Sheet);
                Worksheet worksheet = (doc.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart).Worksheet;
                IEnumerable<Row> rows = worksheet.GetFirstChild<SheetData>().Descendants<Row>();

                int i = 0;
                foreach (Row r in rows)
                {
                    i++;
                    if (i == 1)
                    {
                        continue;
                    }
                    int j = 1;
                    LocationExcellViewModel lewm = new LocationExcellViewModel();
                    foreach (Cell cell in r.Descendants<Cell>())
                    {
                        if (GetCellValue(doc, cell).Any())
                        {
                            switch (cell.CellReference.InnerText[0])
                            {
                                case 'A':
                                    lewm.NAME = GetCellValue(doc, cell);
                                    break;
                                case 'B':
                                    lewm.CITY_NAME = GetCellValue(doc, cell);
                                    break;
                                default: break;
                            }
                        }
                        j++;

                    }
                    if (lewm.NAME != null)
                        returnValue.Add(lewm);
                }
            }
            return returnValue;
        }
        #endregion

        #region Department
        public static void CreateDepartmentExcelFile(ref MemoryStream stream, List<DepartmentExcellViewModel> departmentModels)
        {

            using (SpreadsheetDocument spreedDoc = SpreadsheetDocument.Create(stream,
                DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart wbPart = spreedDoc.WorkbookPart;
                if (wbPart == null)
                {
                    wbPart = spreedDoc.AddWorkbookPart();
                    wbPart.Workbook = new Workbook();
                }

                string sheetName = "Departmanlar";
                WorksheetPart worksheetPart = null;
                worksheetPart = wbPart.AddNewPart<WorksheetPart>();
                var sheetData = new SheetData();

                worksheetPart.Worksheet = new Worksheet(sheetData);

                if (wbPart.Workbook.Sheets == null)
                {
                    wbPart.Workbook.AppendChild<Sheets>(new Sheets());
                }

                var sheet = new Sheet()
                {
                    Id = wbPart.GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = sheetName
                };

                var workingSheet = ((WorksheetPart)wbPart.GetPartById(sheet.Id)).Worksheet;

                int rowindex = 1;
                Row row = new Row();
                row.RowIndex = (UInt32)rowindex;
                row.AppendChild(AddCellWithText("ADI"));
                row.AppendChild(AddCellWithText("AÇIKLAMA"));
                row.AppendChild(AddCellWithText("ŞİRKET ADI"));
                sheetData.AppendChild(row);


                foreach (var item in departmentModels)
                {
                    rowindex++;
                    row = new Row();
                    row.RowIndex = (UInt32)rowindex;
                    row.AppendChild(AddCellWithText(item.NAME));
                    row.AppendChild(AddCellWithText(item.DESCRIPTION));
                    row.AppendChild(AddCellWithText(item.COMPANY_NAME));
                    sheetData.AppendChild(row);
                }
                wbPart.Workbook.Sheets.AppendChild(sheet);
                wbPart.Workbook.Save();
            }
        }

        public static List<DepartmentExcellViewModel> UploadDepartmentExcell(ref MemoryStream stream)
        {
            List<DepartmentExcellViewModel> returnValue = new List<DepartmentExcellViewModel>();
            using (SpreadsheetDocument doc = SpreadsheetDocument.Open(stream, false))
            {
                Sheet sheet = (doc.WorkbookPart.Workbook.Sheets.ElementAt(0) as Sheet);
                Worksheet worksheet = (doc.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart).Worksheet;
                IEnumerable<Row> rows = worksheet.GetFirstChild<SheetData>().Descendants<Row>();

                int i = 0;
                foreach (Row r in rows)
                {
                    i++;
                    if (i == 1)
                    {
                        continue;
                    }
                    int j = 1;
                    DepartmentExcellViewModel dewm = new DepartmentExcellViewModel();
                    foreach (Cell cell in r.Descendants<Cell>())
                    {
                        if (GetCellValue(doc, cell).Any())
                        {
                            switch (cell.CellReference.InnerText[0])
                            {
                                case 'A':
                                    dewm.NAME = GetCellValue(doc, cell);
                                    break;
                                case 'B':
                                    dewm.DESCRIPTION = GetCellValue(doc, cell);
                                    break;     
                                case 'C':
                                    dewm.COMPANY_NAME = GetCellValue(doc, cell);
                                    break;
                                default: break;
                            }
                        }
                        j++;

                    }
                    if (dewm.NAME != null)
                        returnValue.Add(dewm);
                }
            }
            return returnValue;
        }
        #endregion

        #region Title

        public static void CreateTitleExcelFile(ref MemoryStream stream, List<TitleExcellViewModel> titleModels)
        {

            using (SpreadsheetDocument spreedDoc = SpreadsheetDocument.Create(stream,
                DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart wbPart = spreedDoc.WorkbookPart;
                if (wbPart == null)
                {
                    wbPart = spreedDoc.AddWorkbookPart();
                    wbPart.Workbook = new Workbook();
                }

                string sheetName = "Departmanlar";
                WorksheetPart worksheetPart = null;
                worksheetPart = wbPart.AddNewPart<WorksheetPart>();
                var sheetData = new SheetData();

                worksheetPart.Worksheet = new Worksheet(sheetData);

                if (wbPart.Workbook.Sheets == null)
                {
                    wbPart.Workbook.AppendChild<Sheets>(new Sheets());
                }

                var sheet = new Sheet()
                {
                    Id = wbPart.GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = sheetName
                };

                var workingSheet = ((WorksheetPart)wbPart.GetPartById(sheet.Id)).Worksheet;

                int rowindex = 1;
                Row row = new Row();
                row.RowIndex = (UInt32)rowindex;
                row.AppendChild(AddCellWithText("ADI"));
                row.AppendChild(AddCellWithText("AÇIKLAMA"));
                sheetData.AppendChild(row);


                foreach (var item in titleModels)
                {
                    rowindex++;
                    row = new Row();
                    row.RowIndex = (UInt32)rowindex;
                    row.AppendChild(AddCellWithText(item.NAME));
                    row.AppendChild(AddCellWithText(item.DESCRIPTION));
                    sheetData.AppendChild(row);
                }
                wbPart.Workbook.Sheets.AppendChild(sheet);
                wbPart.Workbook.Save();
            }
        }

        public static List<TitleExcellViewModel> UploadTitleExcell(ref MemoryStream stream)
        {
            List<TitleExcellViewModel> returnValue = new List<TitleExcellViewModel>();
            using (SpreadsheetDocument doc = SpreadsheetDocument.Open(stream, false))
            {
                Sheet sheet = (doc.WorkbookPart.Workbook.Sheets.ElementAt(0) as Sheet);
                Worksheet worksheet = (doc.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart).Worksheet;
                IEnumerable<Row> rows = worksheet.GetFirstChild<SheetData>().Descendants<Row>();

                int i = 0;
                foreach (Row r in rows)
                {
                    i++;
                    if (i == 1)
                    {
                        continue;
                    }
                    int j = 1;
                    TitleExcellViewModel tewm = new TitleExcellViewModel();
                    foreach (Cell cell in r.Descendants<Cell>())
                    {
                        if (GetCellValue(doc, cell).Any())
                        {
                            switch (cell.CellReference.InnerText[0])
                            {
                                case 'A':
                                    tewm.NAME = GetCellValue(doc, cell);
                                    break;
                                case 'B':
                                    tewm.DESCRIPTION = GetCellValue(doc, cell);
                                    break;
                                default: break;
                            }
                        }
                        j++;

                    }
                    returnValue.Add(tewm);
                }
            }
            return returnValue;
        }
        #endregion

        #region Function 
        public static void CreateExcelFileTemplate(ref MemoryStream stream, List<string> templateList)
        {

            using (SpreadsheetDocument spreedDoc = SpreadsheetDocument.Create(stream,
                DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart wbPart = spreedDoc.WorkbookPart;
                if (wbPart == null)
                {
                    wbPart = spreedDoc.AddWorkbookPart();
                    wbPart.Workbook = new Workbook();
                }

                string sheetName = "Template";
                WorksheetPart worksheetPart = null;
                worksheetPart = wbPart.AddNewPart<WorksheetPart>();
                var sheetData = new SheetData();

                worksheetPart.Worksheet = new Worksheet(sheetData);

                if (wbPart.Workbook.Sheets == null)
                {
                    wbPart.Workbook.AppendChild<Sheets>(new Sheets());
                }

                var sheet = new Sheet()
                {
                    Id = wbPart.GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = sheetName
                };

                var workingSheet = ((WorksheetPart)wbPart.GetPartById(sheet.Id)).Worksheet;

                int rowindex = 1;
                Row row = new Row();
                row.RowIndex = (UInt32)rowindex;
                foreach (var item in templateList)
                {
                    row.AppendChild(AddCellWithText(item));
                }
                sheetData.AppendChild(row);

                wbPart.Workbook.Sheets.AppendChild(sheet);
                wbPart.Workbook.Save();
            }
        }

        private static Cell AddCellWithText(string text)
        {
            Cell c1 = new Cell();
            c1.DataType = CellValues.InlineString;
            InlineString inlineString = new InlineString();
            Text t = new Text();
            t.Text = text;
            inlineString.AppendChild(t);

            c1.AppendChild(inlineString);

            return c1;
        }

        private static string GetCellValue(SpreadsheetDocument doc, Cell cell)
        {
            string value = cell.InnerText;
            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return doc.WorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements.GetItem(int.Parse(value))
                    .InnerText;
            }

            return value;
        }
        #endregion

    }
}
