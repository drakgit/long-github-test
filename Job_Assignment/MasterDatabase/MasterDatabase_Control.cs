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
        public bool Load_MasterDatabase_Struct()
        {
            string sql_cmd = Init_Database_Str;
            if (MasterDatabase_GridviewTBL == null) return false;
            MasterDatabase_GridviewTBL.Load_DataBase(MasterDatabase_Connection_Str, sql_cmd);
            return true;
        }

        public bool Load_Database_info(string first_col_data)
        {
            string sql_cmd = Select_Database_Str + " WHERE "
                + Excel_Struct[First_Column].Col_str.ToString().Trim()
                + " = '" + first_col_data + "'";
            if (MasterDatabase_GridviewTBL == null) return false;
            MasterDatabase_GridviewTBL.Load_DataBase(MasterDatabase_Connection_Str, sql_cmd);
            return true;
        }

        public bool Search_MasterDatabase_Info(string search_engine)
        {
            string sql_cmd = Select_Database_Str;
            if (search_engine == "")
            {
                MessageBox.Show("Please check Search Condition", "Error");
                return false;
            }
            else if (search_engine != "All")
            {
                sql_cmd += " WHERE " + search_engine;
            }
            if (MasterDatabase_GridviewTBL == null) return false;
            MasterDatabase_GridviewTBL.Load_DataBase(MasterDatabase_Connection_Str, sql_cmd);

            if (MasterDatabase_GridviewTBL.Data_dtb.Rows.Count == 0)
            {
                MessageBox.Show("Can't find any item match with condition: \n" + search_engine, "Search Failed");
            }

            return true;
        }
    }
}