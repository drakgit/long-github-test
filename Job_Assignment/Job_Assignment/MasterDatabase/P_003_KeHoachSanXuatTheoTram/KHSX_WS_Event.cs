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
        private void KHSX_WS_DatePick_ValueChanged(object sender, EventArgs e)
        {
            DateTime select_date = KHSX_WS_DatePick.Value;

            KHSX_WS_dtb = Load_KHSX_WS_DB_Date(select_date);

            if (KHSX_WS_dtb == null)
            {
                return;
            }
            else
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = KHSX_WS_dtb;
                KHSX_WS_dtgrid.DataSource = bs;
                return;
            }
        }

        private void KHSX_Save_BT_Click(object sender, EventArgs e)
        {
            if (Update_SQL_Data(KHSX_WS_da, KHSX_WS_dtb))
            {
                MessageBox.Show("Data is Saved", "Success");
            }
            else
            {
                MessageBox.Show("Failed to Save Data", "Failed");
            }
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            DateTime select_date = KHSX_WS_DatePick.Value;
            DataTable ws_list;
            string line_id, line_name;
            DateTime date;
            string cell_value;
            string part_number;
            int songuoi;
            float soca;
            string ws_id, ws_name;
            string shift_id;
            int percent;
            DataRow new_row;

            Clean_KHSX_WS_Date(select_date);

            Load_KHSX_DB_Date(select_date);
            Load_KHSX_WS_DB_Date(select_date);

            foreach (DataRow khsx_row in KHSX_dtb.Rows)
            {
                cell_value = khsx_row["Date"].ToString().Trim();
                date = DateTime.Parse(cell_value);
                part_number = khsx_row["PartNumber"].ToString().Trim();

                line_id = khsx_row["LineID"].ToString();
                line_name = khsx_row["LineName"].ToString();
                songuoi = (int)khsx_row["NumOfPerson_Per_Day"];
                cell_value = khsx_row["NumOfShift"].ToString();
                soca = float.Parse(cell_value);

                ws_list = Load_WS_List(line_id);

                for (float i = 0; i < soca; i++)
                {
                    shift_id = (i + 1).ToString();
                    if ((soca - i) >= 1)
                    {
                        percent = 100;
                    }
                    else
                    {
                        percent = (int)((soca - i) * 100);
                    }
                    foreach (DataRow ws_row in ws_list.Rows)
                    {
                        ws_id = ws_row["WorkStationID"].ToString();
                        ws_name = ws_row["WorkStationName"].ToString();
                        new_row = KHSX_WS_dtb.NewRow();
                        new_row["Date"] = date;
                        new_row["PartNumber"] = part_number;
                        new_row["LineID"] = line_id;
                        new_row["LineName"] = line_name;
                        new_row["WST_ID"] = ws_row["WorkStationID"].ToString();
                        new_row["WST_Name"] = ws_row["WorkStationName"].ToString();
                        new_row["Shift_Name"] = shift_id;
                        new_row["Shift_Percent"] = percent;
                        new_row["Capacity"] = 0;
                        new_row["Qty"] = 0;
                        new_row["NumOfPerson_Per_Day"] = 0;
                        new_row["NumOfShift"] = 0;

                        KHSX_WS_dtb.Rows.Add(new_row);
                    }

                }
            }
            Update_SQL_Data(KHSX_WS_da, KHSX_WS_dtb);

            BindingSource bs = new BindingSource();
            bs.DataSource = KHSX_WS_dtb;
            KHSX_WS_dtgrid.DataSource = bs;
        }
    }
}