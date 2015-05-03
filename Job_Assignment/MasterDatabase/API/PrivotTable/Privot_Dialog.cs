using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MasterDatabase
{
    public partial class Privot_Dialog_Form : SQL_APPL
    {
        private DataTable Source_Tbl = new DataTable();
        private DataTable Col_list;
        public string [] ColumnsField;
        public string RowField;
        public string ValueField;
        public AggregateFunction Privot_Type;

        public DialogResult Privot_Dialog(DataTable source_tbl)
        {
            InitializeComponent();

            Source_Tbl = source_tbl;
            Col_list = Get_All_Select_Column(Source_Tbl);
            AllCol_listBox.DataSource = Col_list;
            AllCol_listBox.DisplayMember = "Column_Name";
            AllCol_listBox.ValueMember = "Column_Name";

            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.AcceptButton = OK_BT;
            this.CancelButton = Cancel_BT;

            OK_BT.DialogResult = DialogResult.OK;
            Cancel_BT.DialogResult = DialogResult.Cancel;

            string[] types = Enum.GetNames(typeof(AggregateFunction));
            PrivotType_Cbx.Items.AddRange(Enum.GetNames(typeof(AggregateFunction)));
            PrivotType_Cbx.SelectedIndex = 0;
            string text = PrivotType_Cbx.SelectedItem.ToString().Trim();
            Privot_Type = (AggregateFunction)Enum.Parse(typeof(AggregateFunction), text);

            DialogResult dialogResult = this.ShowDialog();
            return dialogResult;
        }

        private void ColField_Select_BT_Click(object sender, EventArgs e)
        {
            int allItem = AllCol_listBox.SelectedItems.Count;
            string col_name;
            //for (int i = 0; i < allItem; i++)
            //{
            //    col_name = AllCol_listBox.SelectedItems[i].ToString().Trim();
            //    ColField_ListBox.Items.Add(col_name);
            //}
            col_name = ((DataRowView)AllCol_listBox.SelectedItem)["Column_Name"].ToString().Trim();
            ColField_ListBox.Items.Add(col_name);
        }

        private void ColField_Remove_BT_Click(object sender, EventArgs e)
        {
            int allItem = ColField_ListBox.SelectedItems.Count;
            for (int i = 0; i < allItem; i++)
            {
                ColField_ListBox.Items.Remove(ColField_ListBox.SelectedItems[i]);
            }
        }

        private void RowField_Select_BT_Click(object sender, EventArgs e)
        {
            int allItem = AllCol_listBox.SelectedItems.Count;
            string col_name;
            if (allItem >0)
            {
                col_name = ((DataRowView)AllCol_listBox.SelectedItem)["Column_Name"].ToString().Trim();
                RowField_Txt.Text  = col_name;
            }
        }

        private void Value_BT_Click(object sender, EventArgs e)
        {
            int allItem = AllCol_listBox.SelectedItems.Count;
            string col_name;
            if (allItem > 0)
            {
                col_name = ((DataRowView)AllCol_listBox.SelectedItem)["Column_Name"].ToString().Trim();
                ValueField_Txt.Text = col_name;
            }
        }

        private void ValueField_Cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = PrivotType_Cbx.SelectedItem.ToString().Trim();
            Privot_Type = (AggregateFunction)Enum.Parse(typeof(AggregateFunction), text);
        }


        private void OK_BT_Click(object sender, EventArgs e)
        {
            int allItem;
            string col_name;
            string col_field_str = "";
            // build col field
            allItem = ColField_ListBox.Items.Count;
            if (ColField_ListBox.Items.Count > 0)
            {
                for (int i = 0; i < allItem; i++)
                {
                    col_name = ColField_ListBox.Items[i].ToString().Trim();
                    if (col_name != "")
                    {
                        col_field_str += col_name + ";";
                    }
                }
                if (col_field_str != "")
                {
                    col_field_str = col_field_str.Substring(0, col_field_str.Length - 1).Trim();
                    if (col_field_str != "")
                    {
                        ColumnsField = col_field_str.Split(';');
                    }
                    else
                    {
                        ColumnsField = null;
                    }
                }
            }

            RowField = RowField_Txt.Text.Trim();
            ValueField = ValueField_Txt.Text.Trim();
            string text = PrivotType_Cbx.SelectedItem.ToString().Trim();
            Privot_Type = (AggregateFunction)Enum.Parse(typeof(AggregateFunction), text);
        }

        private void Clear_BT_Click(object sender, EventArgs e)
        {
            ColField_ListBox.Items.Clear();
            RowField_Txt.Text = "";
        }

        private void Cancel_BT_Click(object sender, EventArgs e)
        {

        }

        
    }
}
