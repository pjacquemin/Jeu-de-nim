using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace PackModel
{
    public class ExcelDoc
    {



        /// <summary>
        /// Model to create a EXCEL document
        /// </summary>
        private Excel.Application app;
        private Excel.Workbook workbook;
        private Excel.Worksheet worksheet;
        private Excel.Range workSheet_range;
        //variable to open and write into an excel file


        /// <summary>
        /// Excel constructor
        /// </summary>
        public ExcelDoc()
        {
            this.app = null;
            this.workbook = null;
            this.worksheet = null;
            this.workSheet_range = null;
        }

        /// <summary>
        /// Method that create an excel doc
        /// </summary>
        /// <returns></returns>

        public Boolean createDoc()
        {
            //try to open excel with blank sheet
            try
            {
                app = new Excel.Application();
                app.Visible = true;
                workbook = app.Workbooks.Add(1);
                worksheet = (Excel.Worksheet)workbook.Sheets[1];
                return true;
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// Method that add an header to excel doc
        /// </summary>

        public void createHeaders(int row, int col, string htext, string cell1, string cell2, int mergeColumns, bool font, int size)
        {
            worksheet.Cells[row, col] = htext;
            workSheet_range = worksheet.get_Range(cell1, cell2);
            workSheet_range.Merge(mergeColumns);
            workSheet_range.Font.Bold = font;
            workSheet_range.ColumnWidth = size;
        }

        /// <summary>
        /// Method that add data into the excel doc
        /// </summary>
        public void addData(int row, int col, string data,
                    string cell1, string cell2, string format)
        {
            worksheet.Cells[row, col] = data;
            workSheet_range = worksheet.get_Range(cell1, cell2);
            workSheet_range.NumberFormat = format;
        }


    }
}