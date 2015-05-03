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
        MaterDatabase InputFromPlannerList_MasterDatabase;
        Button_Lbl Check_BT;

        public string InputFromPlannerList_Select_CMD = @"SELECT * FROM [JOB_ASSIGNMENT_DB].[dbo].[P_001_InputFromPlanner] ";
        public string InputFromPlannerList_Init_Database_CMD = @"SELECT * FROM [JOB_ASSIGNMENT_DB].[dbo].[P_001_InputFromPlanner] 
                                                      WHERE [PartNumber] = ''";
        private bool InputFromPlannerList_Exist = false;

        private bool InputFromPlannerList_Init()
        {
            if (InputFromPlannerList_Exist == true)
            {
                tabControl1.SelectTab("InputFromPlanner");
                return true;
            }
            InputFromPlannerList_Exist = true;
            Init_InputFromPlanner_Excel();
            InputFromPlannerList_MasterDatabase = new MaterDatabase(OpenXL, tabControl1, "InputFromPlanner", InputFromPlannerList_Index, MasterDatabase_Connection_Str, 
                                                            InputFromPlannerList_Init_Database_CMD, InputFromPlannerList_Select_CMD,
                                                            3, InputFromPlanner_Excel_Struct, filterStatusLabel, showAllLabel,
                                                            StatusLabel1, StatusLabel2, ProgressBar1);
            
            // Empl_Skill_List_MasterDatabase.MasterDatabase_GridviewTBL.dataGridView_View.Columns["Line_ID"].Frozen = true;
            InputFromPlannerList_MasterDatabase.MasterDatabase_GridviewTBL.GridView.BackgroundColor = Color.White;
            PosSize possize = new PosSize();
            possize.pos_x = 6;
            possize.pos_y = 6;
            Check_BT = new Button_Lbl(1, InputFromPlannerList_MasterDatabase.MasterDatabase_Tab, "Check", possize, (AnchorStyles)AnchorStyles.Left | AnchorStyles.Top);
            return true;
        }
        ExcelImportStruct[] InputFromPlanner_Excel_Struct;
        const int InputFromPlanner_INDEX = 0;

        private void Init_InputFromPlanner_Excel()
        {
            if (InputFromPlanner_Excel_Struct == null)
            {
                InputFromPlanner_Excel_Struct = new ExcelImportStruct[8];
                InputFromPlanner_Excel_Struct[0] = new ExcelImportStruct(0, "PartNumber", "PartNumber", Excel_Col_Type.COL_STRING, 20, true);
                InputFromPlanner_Excel_Struct[1] = new ExcelImportStruct(1, "LineID", "LineID", Excel_Col_Type.COL_STRING, 20, false);
                InputFromPlanner_Excel_Struct[2] = new ExcelImportStruct(2, "LineName", "LineName", Excel_Col_Type.COL_STRING, 50, false);
                InputFromPlanner_Excel_Struct[3] = new ExcelImportStruct(3, "GroupID", "GroupID", Excel_Col_Type.COL_STRING, 20, false);
                InputFromPlanner_Excel_Struct[4] = new ExcelImportStruct(4, "Capacity", "Capacity", Excel_Col_Type.COL_INT, 20, false);
                InputFromPlanner_Excel_Struct[5] = new ExcelImportStruct(5, "Date", "Date", Excel_Col_Type.COL_DATE, 50, false);
                InputFromPlanner_Excel_Struct[6] = new ExcelImportStruct(6, "Demand", "Demand", Excel_Col_Type.COL_INT, 50, false);
                InputFromPlanner_Excel_Struct[7] = new ExcelImportStruct(7, "SoCa", "SoCa", Excel_Col_Type.COL_FLOAT, 50, false);
            }
        }
    }
}