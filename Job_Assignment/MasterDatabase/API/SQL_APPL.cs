using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.IO.Ports;

namespace MasterDatabase
{
    public partial class SQL_APPL : Form
    {
        public DataTable Get_SQL_Data(string connString, string cmd_str, ref SqlDataAdapter dataAdapter, ref DataSet input_dataset)
        {
            DataTable dtbTmp = new DataTable();

            System.Data.SqlClient.SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                dataAdapter = new SqlDataAdapter(cmd_str, conn);
                dataAdapter.Fill(input_dataset);
                dtbTmp = input_dataset.Tables[0];
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
            finally
            {
                conn.Close();
            }
            return dtbTmp;
        }

        public bool Update_SQL_Data(SqlDataAdapter dataAdapter, DataTable dtbTmp)
        {
            int row;
            // Create SQL Command builder
            SqlCommandBuilder cb = new SqlCommandBuilder(dataAdapter);
            try
            {
                cb.GetUpdateCommand();
                dataAdapter.DeleteCommand = cb.GetDeleteCommand(true);
                dataAdapter.UpdateCommand = cb.GetUpdateCommand(true);
                //dataAdapter.UpdateCommand.CommandTimeout = 200;
                dataAdapter.InsertCommand = cb.GetInsertCommand(true);
                row = dataAdapter.Update(dtbTmp);
                dtbTmp.AcceptChanges();
            }
            catch (Exception ex)
            {
                // Bắt lỗi
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public bool Update_Data_Info(string connString, string sql_cmd)
        {
            // Tạo connection
            System.Data.SqlClient.SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                // Get data from Database
                SqlCommand update_sql = new SqlCommand(sql_cmd, conn);
                update_sql.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }


        public bool Check_ItemExistTable(string item, DataTable table, string col)
        {
            //foreach (DataRow row in Card_List_Each_Provider_dtb.Rows)
            foreach (DataRow row in table.Rows)
            {
                if (item.Trim() == row[col].ToString().Trim())
                {
                    return true;
                }
            }
            return false;
        }

        public DataTable Get_All_Column(DataTable master_table)
        {
            DataTable all_colum_tbl = new DataTable();
            all_colum_tbl.Columns.Add("Search_ID");
            all_colum_tbl.Rows.Add("None");
            all_colum_tbl.Rows.Add("All");

            foreach (DataColumn col in master_table.Columns)
            {
                all_colum_tbl.Rows.Add(col.ColumnName.ToString().Trim());
            }
            return all_colum_tbl;
        }

        public DataTable Get_All_Select_Column(DataTable master_table)
        {
            DataTable all_colum_tbl = new DataTable();
            all_colum_tbl.Columns.Add("Select", typeof(bool));
            all_colum_tbl.Columns.Add("Column_Name");

            foreach (DataColumn col in master_table.Columns)
            {
                all_colum_tbl.Rows.Add(true, col.ColumnName.ToString().Trim());
            }
            return all_colum_tbl;
        }
    }
}
