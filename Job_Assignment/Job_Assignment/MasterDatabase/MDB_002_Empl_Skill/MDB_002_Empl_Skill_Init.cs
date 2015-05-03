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
        MaterDatabase Empl_Skill_List_MasterDatabase;

        public string Empl_Skill_List_Select_CMD = @"SELECT * FROM [JOB_ASSIGNMENT_DB].[dbo].[MDB_002_Empl_Skill] ";
        public string Empl_Skill_List_Init_Database_CMD = @"SELECT * FROM [JOB_ASSIGNMENT_DB].[dbo].[MDB_002_Empl_Skill] 
                                                      WHERE [Skill_ID] = ''";
        private bool Empl_Skill_List_Exist = false;

        private bool Empl_Skill_List_Init()
        {
            if (Empl_Skill_List_Exist == true)
            {
                tabControl1.SelectTab("Employee_vs_Skill");
                return true;
            }
            Empl_Skill_List_Exist = true;
            Init_Empl_Skill_Excel();
            Empl_Skill_List_MasterDatabase = new MaterDatabase(OpenXL, tabControl1, "Employee_vs_Skill", SkillList_Index, MasterDatabase_Connection_Str, 
                                                            Empl_Skill_List_Init_Database_CMD, Empl_Skill_List_Select_CMD,
                                                            3, Empl_Skill_Excel_Struct, filterStatusLabel, showAllLabel,
                                                            StatusLabel1, StatusLabel2, ProgressBar1);
            
            // Empl_Skill_List_MasterDatabase.MasterDatabase_GridviewTBL.dataGridView_View.Columns["Line_ID"].Frozen = true;
            Empl_Skill_List_MasterDatabase.MasterDatabase_GridviewTBL.GridView.BackgroundColor = Color.White;
            return true;
        }

        ExcelImportStruct[] Empl_Skill_Excel_Struct;//  = new ExcelImportStruct[7];
        const int EMPL_SKILL_INDEX_INDEX = 0;

        private void Init_Empl_Skill_Excel()
        {
            if (Empl_Skill_Excel_Struct == null)
            {
                Empl_Skill_Excel_Struct = new ExcelImportStruct[5];
                Empl_Skill_Excel_Struct[0] = new ExcelImportStruct(0, "MSNV", "MSNV", Excel_Col_Type.COL_STRING, 20, true);
                Empl_Skill_Excel_Struct[1] = new ExcelImportStruct(1, "Name", "Name", Excel_Col_Type.COL_STRING, 50, false);
                Empl_Skill_Excel_Struct[2] = new ExcelImportStruct(2, "Skill_ID", "Skill_ID", Excel_Col_Type.COL_STRING, 20, true);
                Empl_Skill_Excel_Struct[3] = new ExcelImportStruct(3, "Skill_Name", "Skill_Name", Excel_Col_Type.COL_STRING, 50, false);
                Empl_Skill_Excel_Struct[4] = new ExcelImportStruct(4, "Priority", "Priority", Excel_Col_Type.COL_STRING, 20, false);
            }
        }
    }
}