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
        private bool Load_<NewName>_info(string <NewName>)
        {
            string sql_cmd = @"SELECT * FROM [<NewName_DB_Name>].[dbo].[<NewName_Table_Name>] 
                                                      WHERE [<NewName_SearchKey>] = '" + <NewName> + "'";
            if (<NewName>List_MasterDatabase.MasterDatabase_GridviewTBL == null) return false;
            <NewName>List_MasterDatabase.MasterDatabase_GridviewTBL.Load_DataBase(MasterDatabase_Connection_Str, sql_cmd);
            return true;
        }
    }
}