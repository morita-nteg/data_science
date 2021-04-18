// Import the required classes
import org.apache.poi.ss.usermodel.{WorkbookFactory, DataFormatter}
import java.io.File

// Automatically convert Java collections to Scala equivalents
import scala.collection.JavaConversions._


object ExcelReader {

    // dump all sheets
    def dumpSheets(wbName : String) = {
        val workbook = WorkbookFactory.create(new File(wbName))
        val formatter = new DataFormatter()

        for {
            (sheet, i) <- workbook.zipWithIndex
            row <- sheet
            cell <- row
        }
        {
            println(s"\t\t${formatter.formatCellValue(cell)}")
        }

        workbook.close()
    }

    // 
    def toTimeSeries(wbName : String, sheetName : String, sym : String) : Array[(Double,Int)] = {
        val workbook = WorkbookFactory.create(new File(wbName))
        val sheet = workbook.getSheet(sheetName)
        val row1st = sheet.getRow(0)
        var tmSeries = Array[(Double,Int)]()

        var col = -1
        try {
            for (cnum <- 1 to 500) {
                if (row1st.getCell(cnum).getStringCellValue == sym) {col = cnum}
            }
        }
        catch {
            case _ : Throwable => {}
        }

        try {
            for (rnum <- 1 to 1000) {
                val tm = sheet.getRow(rnum).getCell(0).getNumericCellValue.toDouble
                val x = sheet.getRow(rnum).getCell(col).getNumericCellValue.toInt
                tmSeries = tmSeries ++ Array((tm,x))
            }
        }
        catch {
            case _ : Throwable => {}
        }

        workbook.close()
        tmSeries
    }
}