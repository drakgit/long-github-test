using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using System.IO;
using System.IO.Ports;
using System.Globalization;
using Excel = Microsoft.Office.Interop.Excel;

namespace MasterDatabase
{
    public partial class SQL_APPL
    {
        public enum Excel_Col_Type
        {
            COL_STRING,
            COL_BOOL,
            COL_INT,
            COL_FLOAT,
            COL_DATE,
            COL_TIME,
            COL_DECIMAL,
        };
        public string Error_log;

        public class ExcelImportStruct : Form
        {
            public string Col_str;
            public string DB_str;
            public int Col;
            public int CSV_Col;
            public Excel_Col_Type Col_type;
            public int Data_Max_len;
            public bool Is_Primary_Key;
            public int My_index;

            public ExcelImportStruct(int index, string name, string col_str, Excel_Col_Type type, int data_max_len, bool pri_key)
            {
                My_index = index;
                Name = name;
                Col_str = col_str;
                DB_str = name;
                Col_type = type;
                Data_Max_len = data_max_len;
                Col = 0;
                Is_Primary_Key = pri_key;
            }
        }


        public bool Import_Excel_File(string file_name, int sheet_num, ExcelImportStruct[] excel_info, 
                                        ref DataTable table, ref SqlDataAdapter data_da,  int num_col, int first_row, ProgressBar progressbar, 
                                        ToolStripStatusLabel status_1, ToolStripStatusLabel status_2)
        {
            int row = first_row;
            string cell_str;
            bool pri_key;
            int first_pri_key_info = 0;
            bool next = true;

            progressbar.Visible = true;
            status_1.Text = "Loading File";
            try
            {
                OpenWB = Open_excel_file(file_name, "");
            }
            catch
            {
                return false;
            }
            Error_log = "";
            if (Get_Col_info(OpenWB, excel_info, num_col, first_row) == true)
            {
                // Load_SQL_Database();
                row = first_row + 1;

                foreach (ExcelImportStruct info in excel_info)
                {
                    pri_key = info.Is_Primary_Key;
                    if (pri_key == true)
                    {
                        cell_str = Get_Text_Cell((Excel.Worksheet)OpenWB.Sheets[sheet_num], row, info.Col, 1);
                        first_pri_key_info = info.My_index;
                        next = true;
                        break;
                    }
                }

                while (next == true)
                {
                    // Kiem tra Line da co trong database chua
                    Is_Exist_and_Update_Tbl(ref table, excel_info, (Excel.Worksheet)OpenWB.Sheets[sheet_num], row);


                    // Kiem tra Line da co trong database chua
                    //if (Is_Exist_and_Update_Tbl(ref table, excel_info, (Excel.Worksheet)OpenWB.Sheets[1], row) == true)
                    //{
                    //    // Update for this row
                    //    Update_Old_Line(ref table, excel_info, (Excel.Worksheet)OpenWB.Sheets[1], row);
                    //}
                    //else
                    //{
                    //    // Insert new row
                    //    Create_New_Line(ref table, excel_info, (Excel.Worksheet)OpenWB.Sheets[1], row);
                    //}
                    
                    progressbar.Value = row % 100;
                    status_2.Text = "Loading File, Line: " + row.ToString();
                    row++;
                    cell_str = Get_Text_Cell((Excel.Worksheet)OpenWB.Sheets[sheet_num], row, excel_info[first_pri_key_info].Col, 20);
                    if (cell_str == "") next = false;

                }

                Close_WorkBook(OpenWB);
                // Store data
                if (Update_SQL_Data(data_da, table) == true)
                {
                    progressbar.Visible = false;
                    status_2.Text = "DONE";
                    MessageBox.Show("Complete Import Data");
                }
                else
                {
                    progressbar.Visible = false;
                    status_2.Text = "Import Failed";
                    MessageBox.Show("Import Data Failed");
                    status_2.Text = "DONE";
                }

            }
            else
            {
                Close_WorkBook(OpenWB);
                progressbar.Visible = false;
                status_2.Text = "Import Failed";
                MessageBox.Show(Error_log, "Error File");
                status_2.Text = "DONE";
            }
            return true;
        }

        public bool Get_Col_info(Excel.Workbook cur_wbook, ExcelImportStruct[] excel_info, int num_col, int first_row)
        {
            int i, col, row;
            string cell_val;
            string error_log = "";
            bool error = false;

            foreach (ExcelImportStruct info in excel_info)
            {
                info.Col = 0;
            }

            row = first_row;
            for (col = 1; col < num_col; col++)
            {
                // cell_val = Get_Excel_Line((Excel.Worksheet)cur_wbook.Sheets[1], row, col, 1, ';');
                cell_val = Get_Text_Cell((Excel.Worksheet)cur_wbook.Sheets[1], row, col, 100);
                cell_val = cell_val.Trim();
                for (i = 0; i < excel_info.Count(); i++)
                {
                    if (cell_val == excel_info[i].Col_str.Trim())
                    {
                        excel_info[i].Col = col;
                        break;
                    }
                }
            }

            for (i = 0; i < excel_info.Count(); i++)
            {
                if (excel_info[i].Col == 0)
                {
                    error_log += "Can not find Column:" + excel_info[i].Col_str + "\n";
                    error = true;
                }
            }

            if (error == true)
            {

                Error_log = error_log;
                return false;
            }
            else
            {
                Error_log = "";
                return true;
            }
        }

        public bool Is_Exist_and_Update_Tbl(ref DataTable table, ExcelImportStruct[] excel_info, Excel.Worksheet xsheet, int row)
        {
            Excel_Col_Type col_type;
            bool line_exist = false;
            bool pri_key;
            string cell_string;

            DataRow new_row = table.NewRow();

            // Read excel row
            foreach (ExcelImportStruct info in excel_info)
            {
                col_type = info.Col_type;
                switch (col_type)
                {
                    case Excel_Col_Type.COL_STRING:
                        new_row[info.DB_str] = Get_Text_Cell(xsheet, row, info.Col, info.Data_Max_len);
                        break;
                    case Excel_Col_Type.COL_INT:
                        new_row[info.DB_str] = Get_int_Cell(xsheet, row, info.Col);
                        break;
                    case Excel_Col_Type.COL_FLOAT:
                        new_row[info.DB_str] = Get_float_Cell(xsheet, row, info.Col);
                        break;
                    case Excel_Col_Type.COL_DATE:
                        cell_string =  Get_date_str_Cell(xsheet, row, info.Col);
                        if (cell_string!= "")
                        {
                            new_row[info.DB_str] = cell_string;
                        }
                        break;
                    case Excel_Col_Type.COL_BOOL:
                        new_row[info.DB_str] = Get_bool_Cell(xsheet, row, info.Col);
                        break;
                    case Excel_Col_Type.COL_DECIMAL:
                        new_row[info.DB_str] = Get_decimal_Cell(xsheet, row, info.Col);
                        break;
                    default:
                        break;
                }
            }
            // Check exist on data table
            foreach (DataRow cur_row in table.Rows)
            {
                // Find exist line
                line_exist = true;
                foreach (ExcelImportStruct info in excel_info)
                {
                    pri_key = info.Is_Primary_Key;
                    if (pri_key == true)
                    {
                        if (new_row[info.DB_str].ToString().Trim() != cur_row[info.DB_str].ToString().Trim())
                        {
                            line_exist = false;
                            break;
                        }
                    }
                }

                // if Exist row: update this row ==> return true
                if (line_exist == true)
                {
                    foreach (ExcelImportStruct info in excel_info)
                    {
                        cur_row[info.DB_str] = new_row[info.DB_str];
                    }
                    return true;
                }
            }

            // if not exist row: add new row ==> Return false
            if (line_exist == false)
            {
                table.Rows.Add(new_row);
            }

            return false;
        }
    }
}
