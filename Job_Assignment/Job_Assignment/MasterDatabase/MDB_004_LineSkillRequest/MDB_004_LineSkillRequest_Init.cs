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
        MaterDatabase LineSkillRequestList_MasterDatabase;

        public string LineSkillRequestList_Select_CMD = @"SELECT * FROM [JOB_ASSIGNMENT_DB].[dbo].[MDB_004_LineSkillRequest] ";
        public string LineSkillRequestList_Init_Database_CMD = @"SELECT * FROM [JOB_ASSIGNMENT_DB].[dbo].[MDB_004_LineSkillRequest] 
                                                      WHERE [LineID] = ''";
        private bool LineSkillRequestList_Exist = false;

        private bool LineSkillRequestList_Init()
        {
            if (LineSkillRequestList_Exist == true)
            {
                tabControl1.SelectTab("Line_vs_Skill_Request");
                return true;
            }
            LineSkillRequestList_Exist = true;

            Init_LineSkillRequest_Excel();
            LineSkillRequestList_MasterDatabase = new MaterDatabase(OpenXL, tabControl1, "Line_vs_Skill_Request", LineSkillRequestList_Index, MasterDatabase_Connection_Str, 
                                                            LineSkillRequestList_Init_Database_CMD, LineSkillRequestList_Select_CMD,
                                                            3, LineSkillRequest_Excel_Struct, filterStatusLabel, showAllLabel,
                                                            StatusLabel1, StatusLabel2, ProgressBar1);

            // Empl_Skill_List_MasterDatabase.MasterDatabase_GridviewTBL.dataGridView_View.Columns["Line_ID"].Frozen = true;
            LineSkillRequestList_MasterDatabase.MasterDatabase_GridviewTBL.GridView.BackgroundColor = Color.White;
            return true;
        }
        ExcelImportStruct[] LineSkillRequest_Excel_Struct;
        const int LineSkillRequest_INDEX = 0;

        private void Init_LineSkillRequest_Excel()
        {
            if (LineSkillRequest_Excel_Struct == null)
            {
                LineSkillRequest_Excel_Struct = new ExcelImportStruct[6];
                LineSkillRequest_Excel_Struct[0] = new ExcelImportStruct(0, "WorkStationID", "WorkStationID", Excel_Col_Type.COL_STRING, 20, true);
                LineSkillRequest_Excel_Struct[1] = new ExcelImportStruct(1, "WorkStationName", "WorkStationName", Excel_Col_Type.COL_STRING, 50, true);
                LineSkillRequest_Excel_Struct[2] = new ExcelImportStruct(2, "LineID", "LineID", Excel_Col_Type.COL_STRING, 20, true);
                LineSkillRequest_Excel_Struct[3] = new ExcelImportStruct(3, "LineName", "LineName", Excel_Col_Type.COL_STRING, 50, true);
                LineSkillRequest_Excel_Struct[4] = new ExcelImportStruct(4, "SkillID", "SkillID", Excel_Col_Type.COL_STRING, 20, false);
                LineSkillRequest_Excel_Struct[5] = new ExcelImportStruct(5, "SkillName", "SkillName", Excel_Col_Type.COL_STRING, 50, false);
            }
        }

    }
}