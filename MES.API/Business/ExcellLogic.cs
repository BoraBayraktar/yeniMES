using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MES.Data.Business
{
    public class ExcellLogic
    {
        public void CreateExcelFile(ref MemoryStream stream)
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

                string sheetName = "Wriju";
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
                row.AppendChild(AddCellWithText("Name"));
                row.AppendChild(AddCellWithText("Email"));
                sheetData.AppendChild(row);
                rowindex++;

                row = new Row();
                row.RowIndex = (UInt32)rowindex;
                row.AppendChild(AddCellWithText("Özlem Tomruk"));
                row.AppendChild(AddCellWithText("ozlem.tomruk@emse.com.tr"));
                sheetData.AppendChild(row);

                wbPart.Workbook.Sheets.AppendChild(sheet);
                wbPart.Workbook.Save();
            }
        }

        static Cell AddCellWithText(string text)
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
    }
}
