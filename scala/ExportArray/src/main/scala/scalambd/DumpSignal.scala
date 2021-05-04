package com.scalambd

import org.apache.poi.ss.usermodel.{WorkbookFactory, DataFormatter}
import org.apache.poi.hssf.usermodel._
import java.io._

class DumpSignal(val wbName : String, val simstop : Double, val simfreq : Double) {
    val N = (simstop * simfreq).toInt
    val syms = {
        val workbook = WorkbookFactory.create(new File(wbName))
        val sheet = workbook.getSheetAt(0)
        val row1st = sheet.getRow(0)
        var syms_tmp = Array[(String, Array[Int])]()

        try {
            for (cnum <- 1 to 500) {
                val str = row1st.getCell(cnum).getStringCellValue
                var zeros = (0 to N).map((k : Int) => 0).toArray
                syms_tmp = syms_tmp ++ Array((str, zeros))
            }
        }
        catch {
            case _ : Throwable => {}
        }

        workbook.close()
        syms_tmp
    }

    def addStep(t : Double, sym : String, s : Int) = {
        val n = (t * simfreq).toInt
        for (elem <- syms) {
            if (elem._1 == sym) {
                for (t <- n to N) {
                    elem._2(t) = s
                }
            }
        }
    }

    def write(filename : String, sheetName : String) = {
        val wb = new HSSFWorkbook
        val sheet = wb.createSheet(sheetName)

        for (i <- 0 to N) {
            val row = sheet.createRow(i)
            if (i == 0) {
                row.createCell(0).setCellValue("time")
                for (j <- 1 to syms.length) {
                    row.createCell(j).setCellValue(syms(j-1)._1)
                }
            }
            else {
                var tm = 0.001 * i.toDouble
                row.createCell(0).setCellValue(tm)
                for (j <- 1 to syms.length) {
                    row.createCell(j).setCellValue(syms(j-1)._2(i))
                }
            }
        }
        
        val out = new FileOutputStream(filename)
        wb.write(out)
        out.close()
    }

}