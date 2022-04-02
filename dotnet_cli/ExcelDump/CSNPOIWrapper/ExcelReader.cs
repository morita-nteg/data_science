using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.UserModel;

namespace CSNPOIWrapper
{
    public class ExcelReader
    {
        public static void DumpConsole(string excelFileName, int n)
        {
            try
            {
                IWorkbook workbook = WorkbookFactory.Create(excelFileName);
                ISheet worksheet = workbook.GetSheetAt(n);
                int lastRow = worksheet.LastRowNum;
                for (int i = 0; i <= lastRow; i++)
                {
                    IRow row = worksheet.GetRow(i);
                    int lastCell = row.LastCellNum;
                    string[] cellValues = new string[lastCell];
                    for (int j = 0; j < lastCell; j++)
                    {
                        ICell cell = row?.GetCell(j);
                        if (cell != null)
                        {
                            switch (cell?.CellType)
                            {
                                case CellType.String:
                                    cellValues[j] = cell?.StringCellValue;
                                    break;
                                case CellType.Numeric:
                                    cellValues[j] = cell?.NumericCellValue.ToString();
                                    break;
                                default:
                                    break;
                            }

                        }
                    }
                    Console.WriteLine(String.Join(",", cellValues));
                }
                Console.WriteLine();
            }
            catch
            {

            }
        }
    }
}
