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
    public class Search_Engine : SQL_APPL
    {
        public ComboBox_Lbl List_Search;
        public DataTable All_Colum;
        public ComboBox_Lbl Type_Search;
        public DataTable All_type_search;
        
        public TextBox_Lbl Value_Txt;
        public Checkbox_Lbl Search_Or_Check;
        public DatePick_LBL From_Date;
        public DatePick_LBL To_Date;

        public TextBox_Lbl Value_GreaterThan_Txt;
        public TextBox_Lbl Value_LessThan_Txt;

        public Search_Engine(bool first_engine, int index, System.Windows.Forms.TabPage owner_tab, PosSize possize, string label,
                            TextBox_Type type, DataTable table, string display_member, string value_member, AnchorType anchor_type)
        {
            PosSize search_location_start = new PosSize();
            All_Colum = table;

            // search colum
            Search_Or_Check = new Checkbox_Lbl(index, owner_tab, "Or", possize, (AnchorStyles)AnchorStyles.Top | AnchorStyles.Left);
            Search_Or_Check.My_CheckBox.Checked = false;
            if (first_engine == true)
            {
                Search_Or_Check.My_CheckBox.Visible = false;
            }

            possize.pos_x += 40;
            List_Search = new ComboBox_Lbl(index, owner_tab, "Search by ", possize,
                            All_Colum, display_member, value_member, AnchorType.LEFT);
            
            // Search Type
            possize.pos_x += 250;
            All_type_search = new DataTable();
            All_type_search.Columns.Add("SearchType");
            All_type_search.Rows.Add("Text");
            All_type_search.Rows.Add("Date");
            All_type_search.Rows.Add("Value");
            Type_Search = new ComboBox_Lbl(index, owner_tab, "Type ", possize,
                            All_type_search, "SearchType", "SearchType", AnchorType.LEFT);
            Type_Search.My_Combo.Size = new System.Drawing.Size(70, 20);
            Type_Search.My_Combo.SelectedIndexChanged += new EventHandler(Type_Search_SelectedIndexChanged);

            possize.pos_x += 180;
            search_location_start.pos_x = possize.pos_x;
            search_location_start.pos_y = possize.pos_y;

            // Text Search
            Value_Txt = new TextBox_Lbl(index, owner_tab, "Value", TextBox_Type.TEXT, possize, AnchorType.LEFT );
            Value_Txt.My_TextBox.Location = new System.Drawing.Point(possize.pos_x + 40, possize.pos_y);

            // Date Search
            possize.pos_x = search_location_start.pos_x;
            possize.pos_y = search_location_start.pos_y;
            From_Date = new DatePick_LBL(index, owner_tab, "From", possize, AnchorType.LEFT);

            possize.pos_x += 150;
            To_Date = new DatePick_LBL(index, owner_tab, "To", possize, AnchorType.LEFT);


            // Value Search 
            possize.pos_x = search_location_start.pos_x;
            possize.pos_y = search_location_start.pos_y;
            Value_GreaterThan_Txt = new TextBox_Lbl(index, owner_tab, "Greater Than", TextBox_Type.TEXT, possize, AnchorType.LEFT);
            Value_GreaterThan_Txt.My_TextBox.Location = new System.Drawing.Point(possize.pos_x + 80, possize.pos_y);

            possize.pos_x += 200;
            Value_LessThan_Txt = new TextBox_Lbl(index, owner_tab, "Less Than", TextBox_Type.TEXT, possize, AnchorType.LEFT);
            Value_LessThan_Txt.My_TextBox.Location = new System.Drawing.Point(possize.pos_x + 70, possize.pos_y);

            Type_Search_SelectedIndexChanged(null, null);
        }

        public void Type_Search_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Type_Search.My_Combo.Text.ToString().Trim())
            {
                case "Text":
                    Value_Txt.My_Label.Visible = true;
                    Value_Txt.My_TextBox.Visible = true;

                    From_Date.My_Label.Visible = false;
                    From_Date.My_picker.Visible = false;
                    To_Date.My_Label.Visible = false;
                    To_Date.My_picker.Visible = false;

                    Value_GreaterThan_Txt.My_Label.Visible = false;
                    Value_GreaterThan_Txt.My_TextBox.Visible = false;
                    Value_LessThan_Txt.My_Label.Visible = false;
                    Value_LessThan_Txt.My_TextBox.Visible = false;
                    break;
                case "Date":
                    Value_Txt.My_Label.Visible = false;
                    Value_Txt.My_TextBox.Visible = false;

                    From_Date.My_Label.Visible = true;
                    From_Date.My_picker.Visible = true;
                    To_Date.My_Label.Visible = true;
                    To_Date.My_picker.Visible = true;

                    Value_GreaterThan_Txt.My_Label.Visible = false;
                    Value_GreaterThan_Txt.My_TextBox.Visible = false;
                    Value_LessThan_Txt.My_Label.Visible = false;
                    Value_LessThan_Txt.My_TextBox.Visible = false;
                    break;
                case "Value":
                    Value_Txt.My_Label.Visible = false;
                    Value_Txt.My_TextBox.Visible = false;

                    From_Date.My_Label.Visible = false;
                    From_Date.My_picker.Visible = false;
                    To_Date.My_Label.Visible = false;
                    To_Date.My_picker.Visible = false;

                    Value_GreaterThan_Txt.My_Label.Visible = true;
                    Value_GreaterThan_Txt.My_TextBox.Visible = true;
                    Value_LessThan_Txt.My_Label.Visible = true;
                    Value_LessThan_Txt.My_TextBox.Visible = true;
                    break;
                default:
                    Value_Txt.My_Label.Visible = false;
                    Value_Txt.My_TextBox.Visible = false;

                    From_Date.My_Label.Visible = false;
                    From_Date.My_picker.Visible = false;
                    To_Date.My_Label.Visible = false;
                    To_Date.My_picker.Visible = false;

                    Value_GreaterThan_Txt.My_Label.Visible = false;
                    Value_GreaterThan_Txt.My_TextBox.Visible = false;
                    Value_LessThan_Txt.My_Label.Visible = false;
                    Value_LessThan_Txt.My_TextBox.Visible = false;
                    break;
            }
        }

        public string Get_Search_String(bool first_patten)
        {
            string search_patten;
            string greater_value, less_value;

            if (List_Search.My_Combo.Text.Trim() == "None")
            {
                List_Search.My_Combo.BackColor = Color.Yellow;
                return "";
            }

            if (List_Search.My_Combo.Text.Trim() == "All")
            {
                List_Search.My_Combo.BackColor = Color.Yellow;
                return "All";
            }

            switch (Type_Search.My_Combo.Text.ToString().Trim())
            {
                case "Text":
                    search_patten = List_Search.My_Combo.Text.Trim() + " LIKE N'%" + Value_Txt.My_TextBox.Text.Trim() + "%'";
                    break;
                case "Date":
                    search_patten = List_Search.My_Combo.Text.Trim() + " BETWEEN '" + From_Date.My_picker.Value.Date.ToString("dd MMM yyyy") + "' ";
                    search_patten += " AND '" + To_Date.My_picker.Value.Date.ToString("dd MMM yyyy") + "' ";
                    break;
                case "Value":
                    greater_value = Value_GreaterThan_Txt.My_TextBox.Text.ToString().Trim();
                    less_value = Value_LessThan_Txt.My_TextBox.Text.ToString().Trim();
                    if ((greater_value == "") && (less_value != ""))
                    {
                        search_patten = List_Search.My_Combo.Text.Trim() + " <= '" + less_value + "' ";
                    }
                    else if ((greater_value != "") && (less_value == ""))
                    {
                        search_patten = List_Search.My_Combo.Text.Trim() + " >= '" + greater_value + "' ";
                    }
                    else if ((Valid_Number(greater_value) == true) && (Valid_Number(greater_value) == true))
                    {
                        search_patten = List_Search.My_Combo.Text.Trim() + " BETWEEN '" + greater_value + "' ";
                        search_patten += " AND '" + less_value + "' ";
                    }
                    else
                    {
                        search_patten = "";
                    }
                    break;
                default:
                    search_patten = "";
                    break;
            }

            if (first_patten == false)
            {
                if (Search_Or_Check.My_CheckBox.Checked == true)
                {
                    search_patten = " OR " + search_patten;
                }
                else
                {
                    search_patten = " AND " + search_patten;
                }
            }
            List_Search.My_Combo.BackColor = Color.White;
            return search_patten;
        }

        private bool Valid_Number(string chuoi)
        {
            if (chuoi == "")
            {
                return false;
            }
            else
            {
                foreach (char c in chuoi)
                {
                    if (Char.IsDigit(c) != true)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}