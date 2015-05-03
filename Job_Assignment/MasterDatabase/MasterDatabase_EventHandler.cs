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
using Excel = Microsoft.Office.Interop.Excel;
using DataGridViewAutoFilter;

namespace MasterDatabase
{
    public partial class MaterDatabase
    {
        public void MasterDatabase_Search_Button_Click(object sender, EventArgs e)
        {
            bool first_engine = true;
            string search_engine = "", cur_engine;

            //for (int i = 0; i < MasterDatabase_Total_Search_Engine; i++)
            //{
            //    cur_engine = Search_Engine_Array[i].Get_Search_String(first_engine);
            //    if (cur_engine != "")
            //    {
            //        if (cur_engine == "All")
            //        {
            //            search_engine = "All";
            //            break;
            //        }
            //        search_engine += cur_engine;
            //        first_engine = false;
            //    }
            //}
            search_engine = Search_Engine_Array[0].Get_Search_String(false);
            Search_MasterDatabase_Info(search_engine);
        }

        public void MasterDatabase_ShowAll_Button_Click(object sender, EventArgs e)
        {
            DataGridViewAutoFilterTextBoxColumn.RemoveFilter(MasterDatabase_GridviewTBL.GridView);
        }

        public void MasterDatabase_GridviewTBL_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            String filterStatus = DataGridViewAutoFilterColumnHeaderCell.GetFilterStatus(MasterDatabase_GridviewTBL.GridView);
            if (String.IsNullOrEmpty(filterStatus))
            {
                if (MasterDatabase_ShowAll_BT != null)
                {
                    MasterDatabase_ShowAll_BT.My_Button.Visible = false;
                }
                MasterDatabase_showAllLabel.Visible = false;
                MasterDatabase_filterStatus.Visible = false;
            }
            else
            {
                if (MasterDatabase_ShowAll_BT != null)
                {
                    MasterDatabase_ShowAll_BT.My_Button.Visible = true;
                }
                MasterDatabase_showAllLabel.Visible = false;
                MasterDatabase_filterStatus.Visible = true;
                MasterDatabase_filterStatus.Text = filterStatus;
            }
        }

        public void MasterDatabase_Select_Col_BT_Click(object sender, EventArgs e)
        {
            string col_name;
            bool visible;
            if (MasterDatabase_Select_Col_BT.My_Button.Text.Trim() == "Columns")
            {
                MasterDatabase_Select_Col_BT.My_Button.Text = "Complete";
                MasterDatabase_Col_Select_GridviewTBL.Visible = true;
            }
            else
            {
                MasterDatabase_Select_Col_BT.My_Button.Text = "Columns";
                MasterDatabase_Col_Select_GridviewTBL.Visible = false;
                if (Select_View_Colum != null)
                {
                    foreach (DataRow row in Select_View_Colum.Rows)
                    {
                        col_name = row["Column_Name"].ToString().Trim();
                        visible = (bool)row["Select"];
                        MasterDatabase_GridviewTBL.GridView.Columns[col_name].Visible = visible;
                    }
                }
            }

        }

        private bool Import_Database_from_file(string file_name)
        {
            bool ret_var;
            if (Excel_Struct == null)
            {
                MessageBox.Show("Excel Struct not initialize", "Error");
                return false;
            }
            if (ProgressBar1 == null)
            {
                ProgressBar1 = new ToolStripProgressBar();
            }
            if (StatusLabel1 == null)
            {
                StatusLabel1 = new ToolStripStatusLabel();
            }
            if (StatusLabel2 == null)
            {
                StatusLabel2 = new ToolStripStatusLabel();
            }

            ret_var = Import_Database_Excel_File(file_name, 1, Excel_Struct, 100, 2, ProgressBar1, StatusLabel1, StatusLabel2);
            return ret_var;
        }

        private bool Import_Database_Excel_File(string file_name, int sheet_num, ExcelImportStruct[] excel_info,
                                        int num_col, int first_row, ToolStripProgressBar progressbar,
                                        ToolStripStatusLabel status_1, ToolStripStatusLabel status_2)
        {
            int row = first_row;
            bool next = true;
            string cur_first_col_data, last_first_col_data;
            bool sucess = true;

            progressbar.Visible = true;
            status_1.Text = "Loading File";
            OpenWB = Open_excel_file(file_name, "");
            Error_log = "";
            if (Get_Col_info(OpenWB, excel_info, num_col, first_row) == true)
            {
                row = first_row + 1;
                cur_first_col_data = Get_Text_Cell((Excel.Worksheet)OpenWB.Sheets[sheet_num], row, excel_info[First_Column].Col, excel_info[First_Column].Data_Max_len);
                Load_Database_info(cur_first_col_data);
                last_first_col_data = cur_first_col_data;

                while (next == true)
                {
                    // Kiem tra Line da co trong database chua
                    Is_Exist_and_Update_Tbl(ref MasterDatabase_GridviewTBL.Data_dtb, excel_info, (Excel.Worksheet)OpenWB.Sheets[sheet_num], row);

                    progressbar.Value = row % 100;
                    status_2.Text = "Loading File, Line: " + row.ToString();
                    row++;
                    cur_first_col_data = Get_Text_Cell((Excel.Worksheet)OpenWB.Sheets[sheet_num], row, excel_info[First_Column].Col, excel_info[First_Column].Data_Max_len);
                    if (cur_first_col_data == "")
                    {
                        if (Update_SQL_Data(MasterDatabase_GridviewTBL.Data_da, MasterDatabase_GridviewTBL.Data_dtb) == false)
                        {
                            ((Excel.Range)((Excel.Worksheet)OpenWB.Sheets[sheet_num]).Cells[row, 1]).Interior.Color = 255;
                            sucess = false;
                        }
                        next = false;
                    }
                    else if (last_first_col_data != cur_first_col_data)
                    {
                        if (Update_SQL_Data(MasterDatabase_GridviewTBL.Data_da, MasterDatabase_GridviewTBL.Data_dtb) == true)
                        {
                            Load_Database_info(cur_first_col_data);
                            last_first_col_data = cur_first_col_data;
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

        public void Import_BT_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog();
            string file_name;
            string fInfo;
            string temp;

            open_dialog.Filter = "Excel file (*.xlsx;*.xls)|*.xlsx;*.xls|All files (*.*)|*.*";

            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                file_name = open_dialog.FileName;
                fInfo = Path.GetExtension(open_dialog.FileName);
                temp = MasterDatabase_GridviewTBL.Import_BT.Text;
                MasterDatabase_GridviewTBL.Import_BT.Text = "Importing ...";
                MasterDatabase_GridviewTBL.Import_BT.Enabled = false;

                Import_Database_from_file(file_name);

                MasterDatabase_GridviewTBL.Import_BT.Enabled = true;
                MasterDatabase_GridviewTBL.Import_BT.Text = temp;
            }
        }
    }
}