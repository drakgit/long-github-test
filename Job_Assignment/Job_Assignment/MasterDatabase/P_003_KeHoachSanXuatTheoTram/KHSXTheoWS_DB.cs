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
        public DataTable KHSX_WS_dtb = new DataTable();
        public DataSet KHSX_WS_ds = new DataSet();
        public SqlDataAdapter KHSX_WS_da;

        public DataTable KHSX_dtb = new DataTable();
        public DataSet KHSX_ds = new DataSet();
        public SqlDataAdapter KHSX_da;

        public DataTable WS_List_dtb = new DataTable();
        public DataSet WS_List_ds = new DataSet();
        public SqlDataAdapter WS_List_da;
        
        public DataTable Load_KHSX_WS_DB_Date(DateTime select_date)
        {
            string sql_cmd = @"SELECT * FROM [JOB_ASSIGNMENT_DB].[dbo].[P_003_KeHoachSanXuatTheoTram]";
            sql_cmd += " WHERE [Date] = '" + select_date.ToString("dd MMM yyyy") + "'";

            if (KHSX_WS_dtb != null)
            {
                KHSX_WS_dtb.Clear();
            }
            KHSX_WS_dtb = Get_SQL_Data(MasterDatabase_Connection_Str, sql_cmd, ref KHSX_WS_da, ref KHSX_WS_ds);
            return KHSX_WS_dtb;
        }

        public DataTable Load_KHSX_DB_Date(DateTime select_date)
        {
            string sql_cmd = @"SELECT * FROM [JOB_ASSIGNMENT_DB].[dbo].[P_002_PlanForProductionByDate]";
            sql_cmd += " WHERE [Date] = '" + select_date.ToString("dd MMM yyyy") + "'";

            if (KHSX_dtb != null)
            {
                KHSX_dtb.Clear();
            }
            KHSX_dtb = Get_SQL_Data(MasterDatabase_Connection_Str, sql_cmd, ref KHSX_da, ref KHSX_ds);
            return KHSX_dtb;
        }

        private bool Clean_KHSX_WS_Date(DateTime select_date )
        {
            Load_KHSX_WS_DB_Date(select_date);
            //KHSX_WS_dtb.Clear();

            var rows = KHSX_WS_dtb.Select();

            foreach (var row in rows)
            {
                row.Delete();            
            }

            Update_SQL_Data(KHSX_WS_da, KHSX_WS_dtb);
            return true;
        }

        private DataTable Load_WS_List(string LineID)
        {
            string sql_cmd = @"SELECT * FROM [JOB_ASSIGNMENT_DB].[dbo].[MDB_004_LineSkillRequest]";
            sql_cmd += " WHERE [LineID] = '" + LineID + "'";

            if (WS_List_dtb != null)
            {
                WS_List_dtb.Clear();
            }
            WS_List_dtb = Get_SQL_Data(MasterDatabase_Connection_Str, sql_cmd, ref WS_List_da, ref WS_List_ds);
            return WS_List_dtb;
        }
    }
}