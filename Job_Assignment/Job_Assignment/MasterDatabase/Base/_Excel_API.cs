using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.IO.Ports;
using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;
using MasterDatabase;

namespace Job_Assignment
{
    public partial class Form1 : SQL_APPL
    {
        ExcelImportStruct[] <NewName>_Excel_Struct;//  = new ExcelImportStruct[7];
        const int <NewName>_INDEX = 0;

        private void Init_<NewName>_Excel(DataTable master_tbl)
        {
            if (<NewName>_Excel_Struct == null)
            {
                <NewName>_Excel_Struct = new ExcelImportStruct[<NewNumOfExcelColum>];
                <NewName>_Excel_Struct[0] = new ExcelImportStruct(0, "Line_ID", "Line_ID", Excel_Col_Type.COL_STRING, 10, true);
                <NewName>_Excel_Struct[1] = new ExcelImportStruct(1, "Line_Name", "Line_Name", Excel_Col_Type.COL_STRING, 50, false);
                <NewName>_Excel_Struct[2] = new ExcelImportStruct(2, "Skill_ID", "Skill_ID", Excel_Col_Type.COL_STRING, 10, false);
                <NewName>_Excel_Struct[3] = new ExcelImportStruct(3, "Skill_Name", "Skill_Name", Excel_Col_Type.COL_STRING, 50, false);
                <NewName>_Excel_Struct[4] = new ExcelImportStruct(4, "Priority", "Priority", Excel_Col_Type.COL_STRING, 10, false);
                <NewName>_Excel_Struct[5] = new ExcelImportStruct(5, "Note", "Note", Excel_Col_Type.COL_STRING, 200, false);
            }
        }

        private bool Import_<NewName>_in_file(string file_name)
        {
            bool ret_var;
            ret_var = Import_<NewName>_Excel_File(file_name, 1, <NewName>_Excel_Struct, 100, 2, ProgressBar1, StatusLabel1, StatusLabel2);
            return ret_var;
        }

        private bool Import_<NewName>_Excel_File(string file_name, int sheet_num, ExcelImportStruct[] excel_info,
                                        int num_col, int first_row, ToolStripProgressBar progressbar,
                                        ToolStripStatusLabel status_1, ToolStripStatusLabel status_2)
        {
            int row = first_row;
            bool next = true;
            string cur_single_box, last_single_box;
            bool sucess = true;

            progressbar.Visible = true;
            status_1.Text = "Loading File";
            OpenWB = Open_excel_file(file_name, "");
            Error_log = "";
            if (Get_Col_info(OpenWB, excel_info, num_col, first_row) == true)
            {
                row = first_row + 1;
                cur_single_box = Get_Text_Cell((Excel.Worksheet)OpenWB.Sheets[sheet_num], row, excel_info[<NewName>_INDEX].Col, excel_info[<NewName>_INDEX].Data_Max_len);
                Load_<NewName>_info(cur_single_box);
                last_single_box = cur_single_box;

                while (next == true)
                {
                    // Kiem tra Line da co trong database chua
                    Is_Exist_and_Update_Tbl(ref <NewName>List_MasterDatabase.MasterDatabase_GridviewTBL.Data_dtb, excel_info, (Excel.Worksheet)OpenWB.Sheets[sheet_num], row);

                    progressbar.Value = row % 100;
                    status_2.Text = "Loading File, Line: " + row.ToString();
                    row++;
                    cur_single_box = Get_Text_Cell((Excel.Worksheet)OpenWB.Sheets[sheet_num], row, excel_info[<NewName>_INDEX].Col, excel_info[EMPL_SKILL_INDEX_INDEX].Data_Max_len);
                    if (cur_single_box == "")
                    {
                        if (Update_SQL_Data(<NewName>List_MasterDatabase.MasterDatabase_GridviewTBL.Data_da, <NewName>List_MasterDatabase.MasterDatabase_GridviewTBL.Data_dtb) == false)
                        {
                            ((Excel.Range)((Excel.Worksheet)OpenWB.Sheets[sheet_num]).Cells[row, 1]).Interior.Color = 255;
                            sucess = false;
                        }
                        next = false;
                    }
                    else if (last_single_box != cur_single_box)
                    {
                        if (Update_SQL_Data(<NewName>List_MasterDatabase.MasterDatabase_GridviewTBL.Data_da, <NewName>List_MasterDatabase.MasterDatabase_GridviewTBL.Data_dtb) == true)
                        {
                            Load_<NewName>_info(cur_single_box);
                            last_single_box = cur_single_box;
                        }
                        else
                        {
                            ((Excel.Range)((Excel.Worksheet)OpenWB.Sheets[sheet_num]).Cells[row, 1]).Interior.Color = 255;
                            sucess = false;
                        }
                    }
                }

                Close_WorkBook(OpenWB);
                progressbar.Visible = false;
                status_2.Text = "DONE";
                if (sucess == true)
                {
                    MessageBox.Show("Complete Import Data");
                }
                else
                {
                    MessageBox.Show(Error_log, "Import Failed");
                }
                status_1.Text = "";
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
    }
}