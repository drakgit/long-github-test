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
using System.Threading;
using System.IO;
using System.IO.Ports;
using System.Globalization;
using Excel = Microsoft.Office.Interop.Excel;

namespace MasterDatabase
{
    public partial class SQL_APPL
    {
        public enum AggregateFunction
        {
            First = 1,
            Last = 2,
            Count = 3,
            Sum = 4,
            Average = 5,
            Max = 6,
            Min = 7,
            Exists = 8
        }

        private DataTable Privot_Source_Table = new DataTable();

        public DataTable Create_PrivotTable(DataTable input_table)
        {
            string[] columnFields;
            string rowField;
            string dataField;
            AggregateFunction privot_type;
            DataTable output_table = new DataTable();

            Privot_Source_Table = input_table;

            Privot_Dialog_Form privot_dialog = new Privot_Dialog_Form();
            if (privot_dialog.Privot_Dialog(Privot_Source_Table) == DialogResult.OK)
            {
                columnFields = privot_dialog.ColumnsField;
                rowField = privot_dialog.RowField;
                dataField = privot_dialog.ValueField;
                privot_type = privot_dialog.Privot_Type;
            }
            else
            {
                return null;
            }
            output_table = PrivotTable(input_table, rowField, dataField, columnFields, privot_type);
            // output_table = PivotData(input_table, rowField, dataField,privot_type, columnFields);
            return output_table;
        }

        public DataTable PrivotTable(DataTable input_table, string rowField, string dataField, 
                                        string [] columnFields, AggregateFunction privot_type)
        {
            DataTable output_Tbl;
            string rowField_data;
            DateTime row_col_date;
            int total_row;
            int numofcol;

            Privot_Source_Table = input_table;

            numofcol = columnFields.Count();
            // Check Correct Colum in table
            if (IsTableCol(Privot_Source_Table, rowField) == false)
            {
                MessageBox.Show("Column: " + rowField + " is not exist in table", "Error");
                return null;
            }

            foreach (string col_name in columnFields)
            {
                if (col_name != "")
                {
                    if (IsTableCol(Privot_Source_Table, col_name) == false)
                    {
                        MessageBox.Show("Column: " + col_name + " is not exist in table", "Error");
                        return null;
                    }
                }
            }

            // String Create privot Table 
            output_Tbl = new DataTable();
            foreach (string col_name in columnFields)
            {
                if (col_name != "")
                {
                    output_Tbl.Columns.Add(col_name);
                }
            }
            DataView view = new DataView(Privot_Source_Table);
            view.Sort = rowField;
            DataTable rowField_dataList = view.ToTable(true, rowField);
            rowField_dataList.Select("",rowField);
            total_row = rowField_dataList.Rows.Count;

            if (Privot_Source_Table.Columns[rowField].DataType == typeof(DateTime))
            {
                for (int i = 0; i < total_row; i++)
                {
                    rowField_data = rowField_dataList.Rows[i][rowField].ToString().Trim();
                    try
                    {
                        if (rowField_data != "")
                        {
                            row_col_date = DateTime.Parse(rowField_data);
                            rowField_data = row_col_date.ToString("dd MMM");
                            output_Tbl.Columns.Add(rowField_data);
                        }
                        else
                        {
                            output_Tbl.Columns.Add("Blank");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Not able to Reconize DateTime Value:" + rowField_data, "Error");
                        return null;
                    }
                }
            }
            else
            {
                for (int i = 0; i < total_row; i++)
                {
                    rowField_data = rowField_dataList.Rows[i][rowField].ToString().Trim();

                    if (rowField_data != "")
                    {

                        output_Tbl.Columns.Add(rowField_data);
                    }
                    else
                    {
                        output_Tbl.Columns.Add("Blank");
                    }

                }
            }

            // Fill Data
            DataView data_view = new DataView(Privot_Source_Table);
            DataTable row_list = data_view.ToTable(true, columnFields);
            foreach (DataRow data_row in row_list.Rows)
            {
                DataRow new_row = output_Tbl.NewRow();
                string strFilter = "";

                foreach (string col in columnFields)
                {
                    if (strFilter == "")
                    {
                    strFilter = col + " = '" + data_row[col] + "'";
                    }
                    else
                    {
                        strFilter += " and " + col + " = '" + data_row[col] + "'";
                    }

                    new_row[col] = data_row[col].ToString().Trim();
                }
                total_row = rowField_dataList.Rows.Count;
                for (int i = 0; i < total_row; i++)
                {
                    string filter;
                    rowField_data = rowField_dataList.Rows[i][rowField].ToString().Trim();
                    filter = strFilter + " and " + rowField + " = '" + rowField_data + "'";
                    if (rowField_data != "")
                    {
                        new_row[rowField_data] = GetData(filter, dataField, privot_type);
                    }
                    else
                    {
                        new_row["Blank"] = GetData(filter, dataField, privot_type);
                    }
                }

                output_Tbl.Rows.Add(new_row);
            }
            return output_Tbl;
        }

        /// <summary>
        /// Retrives the data for matching RowField value and ColumnFields values with Aggregate function applied on them.
        /// </summary>
        /// <param name="Filter">DataTable Filter condition as a string</param>
        /// <param name="DataField">The column name which needs to spread out in Data Part of the Pivoted table</param>
        /// <param name="Aggregate">Enumeration to determine which function to apply to aggregate the data</param>
        /// <returns></returns>
        private object GetData(string Filter, string DataField, AggregateFunction Aggregate)
        {
            try
            {
                DataRow[] FilteredRows = Privot_Source_Table.Select(Filter);
                object[] objList = FilteredRows.Select(x => x.Field<object>(DataField)).ToArray();

                switch (Aggregate)
                {
                    case AggregateFunction.Average:
                        return GetAverage(objList);
                    case AggregateFunction.Count:
                        return objList.Count();
                    case AggregateFunction.Exists:
                        return (objList.Count() == 0) ? "False" : "True";
                    case AggregateFunction.First:
                        return GetFirst(objList);
                    case AggregateFunction.Last:
                        return GetLast(objList);
                    case AggregateFunction.Max:
                        return GetMax(objList);
                    case AggregateFunction.Min:
                        return GetMin(objList);
                    case AggregateFunction.Sum:
                        return GetSum(objList);
                    default:
                        return null;
                }
            }
            catch (Exception ex)
            {
                return "#Error";
            }
            return null;
        }

        private object GetAverage(object[] objList)
        {
            return objList.Count() == 0 ? null : (object)(Convert.ToDecimal(GetSum(objList)) / objList.Count());
        }
        private object GetSum(object[] objList)
        {
            return objList.Count() == 0 ? null : (object)(objList.Aggregate(new decimal(), (x, y) => x += Convert.ToDecimal(y)));
        }
        private object GetFirst(object[] objList)
        {
            return (objList.Count() == 0) ? null : objList.First();
        }
        private object GetLast(object[] objList)
        {
            return (objList.Count() == 0) ? null : objList.Last();
        }
        private object GetMax(object[] objList)
        {
            return (objList.Count() == 0) ? null : objList.Max();
        }
        private object GetMin(object[] objList)
        {
            return (objList.Count() == 0) ? null : objList.Min();
        }

        public bool IsTableCol(DataTable table, string col_name)
        {
            string cur_col_name;
            foreach (DataColumn col in table.Columns)
            {
                cur_col_name = col.ColumnName.ToString().Trim();
                if (cur_col_name == col_name)
                {
                    return true;
                }
            }
            return false;
        }
    }
}