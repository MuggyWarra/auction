using OfficeOpenXml;
using System;
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
        public Akk[] GetAkk()
        {
            using (var pac = new ExcelPackage(new FileInfo(_filePath)))
            {
                var worksheet = pac.Workbook.Worksheets["Akk"];
                var rowCount = worksheet.Dimension.Rows;
                var akks = new Akk[rowCount - 1];
                for (int i = 2; i <= rowCount; i++)
                {
                    var akk = new Akk(
                        Convert.ToInt32(worksheet.Cells[i, 1].Value),
                        worksheet.Cells[i, 2].Value.ToString(),
                        worksheet.Cells[i, 3].Value.ToString(),
                        worksheet.Cells[i, 4].Value.ToString(),
                        Convert.ToDecimal(worksheet.Cells[i, 5].Value)
                    );
                    akks[i - 2] = akk;
                }
                return akks;
            }
        }
        public Slot[] GetSlots()
        {
            using (var package = new ExcelPackage(new FileInfo(_filePath)))
            {
                var worksheet = package.Workbook.Worksheets["Slot"];
                var rowCount = worksheet.Dimension.Rows;
                var slots = new Slot[rowCount - 1];
                for (int i = 2; i <= rowCount; i++)
                {
                    var slot = new Slot(
                        Convert.ToInt32(worksheet.Cells[i, 1].Value),
                        worksheet.Cells[i, 4].Value.ToString(),
                        worksheet.Cells[i, 5].Value.ToString(),
                        worksheet.Cells[i, 6].Value.ToString(),
                        Convert.ToDecimal(worksheet.Cells[i, 7].Value),
                        Convert.ToDecimal(worksheet.Cells[i, 9].Value)
                    );
                    slots[i - 2] = slot;
                }
                return slots;
            }
        }
    }
}
