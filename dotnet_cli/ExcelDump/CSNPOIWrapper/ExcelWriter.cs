using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace CSNPOIWrapper
{
    public class ExcelWriter
    {
        public static void CreateSimpleSheet(string fileName, string sheetName)
        {

        }

        public static void FromList(string fileName, string sheetName, List<string[]> cellList)
        {
            using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook = new XSSFWorkbook();
                ISheet excelSheet = workbook.CreateSheet(sheetName);

                for (int rowIndex = 0; rowIndex < cellList.Count; rowIndex++) {
                    var row = excelSheet.CreateRow(rowIndex);
                    string[] rowValues = cellList[rowIndex];
                    for (int cellIndex = 0; cellIndex < rowValues.Length; cellIndex++)
                    {
                        row.CreateCell(cellIndex).SetCellValue(rowValues[cellIndex]);
                    }
                
                }

                workbook.Write(fs);
            }
        }
    }
}
