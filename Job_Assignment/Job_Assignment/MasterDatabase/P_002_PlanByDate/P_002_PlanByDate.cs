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
        readonly Color COLOR_TOTAL_SHIFT_INVALID = Color.Red;
        readonly Color COLOR_TOTAL_SHIFT_VALID = Color.White;
        
        MaterDatabase KeHoachSanXuatTheoNgayList_MasterDatabase;
        Button_Lbl PlanByDate_Calculate_BT;
        TextBox_Lbl txtTextBox;

       // Button_Lbl PlanByDate_Check_BT;
        //Dho-Fixme: Do we need to use the button "Check_BT"?
        PlanByDateController planByDateController;
        public string KeHoachSanXuatTheoNgayList_Select_CMD = @"SELECT * FROM [JOB_ASSIGNMENT_DB].[dbo].[P_002_PlanForProductionByDate] ";
        public string KeHoachSanXuatTheoNgayList_Init_Database_CMD = @"SELECT * FROM [JOB_ASSIGNMENT_DB].[dbo].[P_002_PlanForProductionByDate] 
                                                      WHERE [Date] = ''";
        private bool KeHoachSanXuatTheoNgayList_Exist = false;

        private bool KeHoachSanXuatTheoNgayList_Init()
        {
            if (KeHoachSanXuatTheoNgayList_Exist == true)
            {
                tabControl1.SelectTab("KeHoachSanXuatTheoNgay");
                return true;
            }
            KeHoachSanXuatTheoNgayList_Exist = true;
            Init_KeHoachSanXuatTheoNgay_Excel();
            KeHoachSanXuatTheoNgayList_MasterDatabase = new MaterDatabase(OpenXL, tabControl1, "KeHoachSanXuatTheoNgay", ProductionPlanByDate_Index, MasterDatabase_Connection_Str, 
                                                            KeHoachSanXuatTheoNgayList_Init_Database_CMD, KeHoachSanXuatTheoNgayList_Select_CMD,
                                                            3, KeHoachSanXuatTheoNgay_Excel_Struct, filterStatusLabel, showAllLabel,
                                                            StatusLabel1, StatusLabel2, ProgressBar1);
            
            // Empl_Skill_List_MasterDatabase.MasterDatabase_GridviewTBL.dataGridView_View.Columns["Line_ID"].Frozen = true;
            KeHoachSanXuatTheoNgayList_MasterDatabase.MasterDatabase_GridviewTBL.GridView.BackgroundColor = Color.White;

            planByDateController = new PlanByDateController(KeHoachSanXuatTheoNgayList_MasterDatabase);

            //Dho-Fixme: Do we need to use the button "Check_BT"?
            PosSize possize = new PosSize();
            possize.pos_x = 200;
            possize.pos_y = 90;
            PlanByDate_Calculate_BT = new Button_Lbl(1, KeHoachSanXuatTheoNgayList_MasterDatabase.MasterDatabase_Tab, "Calculate", possize, (AnchorStyles)AnchorStyles.Left | AnchorStyles.Top);
            PlanByDate_Calculate_BT.My_Button.Click += new EventHandler(Button_Calculte_Click);

            possize.pos_x = 400;
            possize.pos_y = 90;
            txtTextBox = new TextBox_Lbl(1, KeHoachSanXuatTheoNgayList_MasterDatabase.MasterDatabase_Tab, "Total", TextBox_Type.TEXT, possize, AnchorType.LEFT);
            txtTextBox.My_TextBox.ReadOnly = true;
            txtTextBox.My_TextBox.TextAlign = HorizontalAlignment.Right;
            txtTextBox.My_TextBox.BackColor = Color.Red;
            //possize.pos_x = 300;
            //possize.pos_y = 90;
            //PlanByDate_Check_BT = new Button_Lbl(1, KeHoachSanXuatTheoNgayList_MasterDatabase.MasterDatabase_Tab, "Check", possize, (AnchorStyles)AnchorStyles.Left | AnchorStyles.Top);
            // PlanByDate_Check_BT.My_Button.Click += new EventHandler(PlanByDate_Check_BT_Click);

            return true;
        }

        void Button_Calculte_Click(object sender, EventArgs e)
        {
            DataTable inputTable = ((BindingSource)KeHoachSanXuatTheoNgayList_MasterDatabase.MasterDatabase_GridviewTBL.GridView.DataSource).DataSource as DataTable;
           // inputTable.Rows[0][1] = "B";
            String ret = planByDateController.Calculate(inputTable);
            if (!String.IsNullOrEmpty(ret))
            {
                MessageBox.Show(ret);
                return;
            }

            //check rule
            Dictionary<String, bool> lineRule = new Dictionary<string,bool>();
            ret = planByDateController.GetLineRule(inputTable, ref lineRule);
            if (!String.IsNullOrEmpty(ret))
            {
                MessageBox.Show(ret);
                return;
            }

            //high line totalshift
            for (int i = 0; i < KeHoachSanXuatTheoNgayList_MasterDatabase.MasterDatabase_GridviewTBL.GridView.Rows.Count; i++)
            {
                object sDate = KeHoachSanXuatTheoNgayList_MasterDatabase.MasterDatabase_GridviewTBL.GridView["Date", i].Value;
                if (sDate != null && !String.IsNullOrEmpty(sDate.ToString()))
                {
                    DateTime dt;
                    bool b = DateTime.TryParse(sDate.ToString(), out dt);
                    if (b)
                    {
                        String partNumber = KeHoachSanXuatTheoNgayList_MasterDatabase.MasterDatabase_GridviewTBL.GridView["PartNumber", i].Value as String;
                        String key = String.Format("{0}_{1}", dt.ToString("dd/MM/yyyy"), partNumber);
                        KeHoachSanXuatTheoNgayList_MasterDatabase.MasterDatabase_GridviewTBL.GridView["TotalShiftPerLine", i].Style.BackColor = lineRule[key] ? COLOR_TOTAL_SHIFT_INVALID : COLOR_TOTAL_SHIFT_VALID;
                    }
                }
            }
            //show TotalResource
            Decimal totalResource =  0;
            ret =   planByDateController.GetTotalResource(inputTable, ref totalResource);
            if (!String.IsNullOrEmpty(ret))
            {
                MessageBox.Show(ret);
                return;
            }
            txtTextBox.My_TextBox.Text = totalResource.ToString("###,###,###,###");
        }

        ExcelImportStruct[] KeHoachSanXuatTheoNgay_Excel_Struct;
        const int KeHoachSanXuatTheoNgay_INDEX = 0;

        private void Init_KeHoachSanXuatTheoNgay_Excel()
        {
            if (KeHoachSanXuatTheoNgay_Excel_Struct == null)
            {
                KeHoachSanXuatTheoNgay_Excel_Struct = new ExcelImportStruct[10];
                KeHoachSanXuatTheoNgay_Excel_Struct[0] = new ExcelImportStruct(0, "Date", "Date", Excel_Col_Type.COL_DATE, 10, true);
                KeHoachSanXuatTheoNgay_Excel_Struct[1] = new ExcelImportStruct(1, "PartNumber", "PartNumber", Excel_Col_Type.COL_STRING, 20, true);
                KeHoachSanXuatTheoNgay_Excel_Struct[2] = new ExcelImportStruct(2, "LineID", "LineID", Excel_Col_Type.COL_STRING, 20, false);
                KeHoachSanXuatTheoNgay_Excel_Struct[3] = new ExcelImportStruct(3, "LineName", "LineName", Excel_Col_Type.COL_STRING, 50, false);
                KeHoachSanXuatTheoNgay_Excel_Struct[4] = new ExcelImportStruct(4, "GroupID", "GroupID", Excel_Col_Type.COL_STRING, 20, false);
                KeHoachSanXuatTheoNgay_Excel_Struct[5] = new ExcelImportStruct(5, "TotalShiftPerLine", "TotalShiftPerLine", Excel_Col_Type.COL_STRING, 50, false);
                KeHoachSanXuatTheoNgay_Excel_Struct[6] = new ExcelImportStruct(6, "Capacity", "Capacity", Excel_Col_Type.COL_INT, 20, false);
                KeHoachSanXuatTheoNgay_Excel_Struct[7] = new ExcelImportStruct(7, "Qty", "Qty", Excel_Col_Type.COL_INT, 20, false);
                KeHoachSanXuatTheoNgay_Excel_Struct[8] = new ExcelImportStruct(8, "NumOfShift", "NumOfShift", Excel_Col_Type.COL_FLOAT, 20, false);
                KeHoachSanXuatTheoNgay_Excel_Struct[9] = new ExcelImportStruct(9, "NumOfPerson_Per_Day", "NumOfPerson_Per_Day", Excel_Col_Type.COL_INT, 50, false);
            }
        }
    }
}