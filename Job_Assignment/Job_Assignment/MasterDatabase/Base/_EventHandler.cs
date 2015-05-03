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
using DataGridViewAutoFilter;
using MasterDatabase;

namespace Job_Assignment
{
    public partial class Form1 : SQL_APPL
    {
        public void <NewName>_Import_BT_Click(object sender, EventArgs e)
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
                temp = <NewName>List_MasterDatabase.MasterDatabase_GridviewTBL.Import_BT.Text;
                <NewName>List_MasterDatabase.MasterDatabase_GridviewTBL.Import_BT.Text = "Importing ...";
                <NewName>List_MasterDatabase.MasterDatabase_GridviewTBL.Import_BT.Enabled = false;

                Import_<NewName>_in_file(file_name);
                
                <NewName>List_MasterDatabase.MasterDatabase_GridviewTBL.Import_BT.Enabled = true;
                <NewName>List_MasterDatabase.MasterDatabase_GridviewTBL.Import_BT.Text = temp;
            }
        }
    }
}
