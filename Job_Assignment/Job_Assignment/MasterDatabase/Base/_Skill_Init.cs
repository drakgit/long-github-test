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
        MaterDatabase <NewName>List_MasterDatabase;

        public string <NewName>List_Select_CMD = @"SELECT * FROM [<NewName_DB_Name>].[dbo].[<NewName_Table_Name>] ";
        public string <NewName>List_Init_Database_CMD = @"SELECT * FROM [<NewName_DB_Name>].[dbo].[<NewName_Table_Name>] 
                                                      WHERE [<NewName_SearchKey>] = ''";
        private bool <NewName>List_Exist = false;

        private bool <NewName>List_Init()
        {
            if (<NewName>List_Exist == true)
            {
                tabControl1.SelectTab("<NewTabName>");
                return true;
            }
            <NewName>List_Exist = true;
            <NewName>List_MasterDatabase = new MaterDatabase(tabControl1, "<NewTabName>", <NewName>List_Index, MasterDatabase_Connection_Str, 
                                                            <NewName>List_Init_Database_CMD, <NewName>List_Select_CMD,
                                                            3, <NewName>_Excel_Struct, filterStatusLabel, showAllLabel);
            <NewName>List_MasterDatabase.MasterDatabase_GridviewTBL.Import_BT.Click += new EventHandler(<NewName>_Import_BT_Click);
            Load_<NewName>_info("");
            Init_<NewName>_Excel(<NewName>List_MasterDatabase.MasterDatabase_GridviewTBL.Data_dtb);
            // Empl_Skill_List_MasterDatabase.MasterDatabase_GridviewTBL.dataGridView_View.Columns["Line_ID"].Frozen = true;
            <NewName>List_MasterDatabase.MasterDatabase_GridviewTBL.dataGridView_View.BackgroundColor = Color.White;
            return true;
        }
    }
}