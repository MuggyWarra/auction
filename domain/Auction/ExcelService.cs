using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
namespace Auction
{
    public class ExcelService
    {
        private readonly string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Auction.xlsx");
        public ExcelService(string filePath)
        {
            _filePath = filePath;
        }
        public string GetCellValueAsString(ICell cell)
        {
            if (cell == null)
            {
                return null;
            }
            switch (cell.CellType)
            {
                case CellType.String:
                    return cell.StringCellValue;
                case CellType.Numeric:
                    return cell.NumericCellValue.ToString();
                case CellType.Boolean:
                    return cell.BooleanCellValue.ToString();
                case CellType.Formula:
                    return cell.CellFormula;
                case CellType.Blank:
                    return string.Empty;
                default:
                    return null;
            }
        }
        public Akk[] GetAkk()
        {
            var akks = new List<Akk>();
            using (var sream = new FileStream(_filePath,FileMode.Open,FileAccess.Read))
            {
                var workbook = new XSSFWorkbook(sream);
                var sheet = workbook.GetSheet("Akk");
                if (sheet == null) return akks.ToArray();
                for (int rowIndex = 1; rowIndex <= sheet.LastRowNum; rowIndex++)
                {
                    var row = sheet.GetRow(rowIndex);
                    if (row == null) continue;
                    var akk = new Akk(
                        Convert.ToInt32(row.GetCell(0)?.NumericCellValue),
                        row.GetCell(1)?.StringCellValue,
                        row.GetCell(2)?.StringCellValue,
                        GetCellValueAsString(row.GetCell(3)),
                    Convert.ToDecimal(row.GetCell(4)?.NumericCellValue)
                    );
                    akks.Add(akk);
                }
                return akks.ToArray();
            }
        }
        public Slot[] GetSlots()
        {
            var slots = new List<Slot>();
            using (var stream = new FileStream(_filePath, FileMode.Open, FileAccess.Read))
            {
                var workbook = new XSSFWorkbook(stream);
                var sheet = workbook.GetSheet("Slot");
                if (sheet == null) return slots.ToArray();

                for (int rowIndex = 1; rowIndex <= sheet.LastRowNum; rowIndex++)
                {
                    var row = sheet.GetRow(rowIndex);
                    if (row == null) continue;

                    var slot = new Slot(
                        Convert.ToInt32(row.GetCell(0)?.NumericCellValue),
                        row.GetCell(4)?.StringCellValue,
                        row.GetCell(5)?.StringCellValue,
                        row.GetCell(6)?.StringCellValue,
                        Convert.ToDecimal(row.GetCell(7)?.NumericCellValue),
                        Convert.ToDecimal(row.GetCell(9)?.NumericCellValue)
                    );
                    slots.Add(slot);
                }
            }
            return slots.ToArray();
        }
    }
}
