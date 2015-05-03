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
using DataGridViewAutoFilter;

namespace MasterDatabase
{
    public class Gridview_Grp : SQL_APPL
    {
        public System.Windows.Forms.GroupBox Tab_Grp;
        public System.Windows.Forms.DataGridView GridView;
        public System.Windows.Forms.Button Review_BT;
        public System.Windows.Forms.Button Submit_BT;
        public System.Windows.Forms.Button Export_BT;
        public System.Windows.Forms.Button Import_BT;
        public System.Windows.Forms.Button Delete_All_BT;
        public System.Windows.Forms.Button Delete_Rows_BT;
        public System.Windows.Forms.Button Privot_BT;

        private string Database_Conn;
        private string SQL_Load_CMD;
        public DataTable Data_dtb = new DataTable();
        public DataTable Privot_DataTable = new DataTable();
        public DataSet Data_ds = new DataSet();
        public SqlDataAdapter Data_da;
        private string Group_Name;
        PosSize My_PosSize;
        bool My_autoResize;
        public AnchorType My_anchor;
        public ToolStripProgressBar ProgressBar1 = new ToolStripProgressBar();
        public ToolStripStatusLabel Status_1 = new ToolStripStatusLabel();
        public ToolStripStatusLabel Status_2 = new  ToolStripStatusLabel();

        public Gridview_Grp(System.Windows.Forms.TabPage owner_tab, string group_name, PosSize possize,
                            bool autoresize, string connection_str, string sql_load_cmd, AnchorType anchor)
        {
            Database_Conn = connection_str;
            SQL_Load_CMD = sql_load_cmd;
            My_PosSize = possize;
            My_autoResize = autoresize;
            My_anchor = anchor;
            Group_Name = group_name;
            Init_GrpBox(owner_tab, group_name);
            Init_GridView(owner_tab, group_name);
        }

        private bool Init_GrpBox(System.Windows.Forms.TabPage owner_tab, string group_name)
        {
            int height, width;
            height = My_PosSize.height;
            width = My_PosSize.width;

            Tab_Grp = new System.Windows.Forms.GroupBox();
            owner_tab.Controls.Add(Tab_Grp);
            this.Tab_Grp.AutoSize = true;
            this.Tab_Grp.SuspendLayout();
            this.Tab_Grp.Location = new System.Drawing.Point(My_PosSize.pos_x, My_PosSize.pos_y);
            this.Tab_Grp.Name = group_name;
            this.Tab_Grp.Size = new System.Drawing.Size(width, height);
            this.Tab_Grp.TabIndex = 0;
            this.Tab_Grp.TabStop = false;
            this.Tab_Grp.Text = group_name;
            this.Tab_Grp.ResumeLayout(true);
            this.Tab_Grp.PerformLayout();
            this.Tab_Grp.AutoSize = false;
            if (My_autoResize == true)
            {
                this.Tab_Grp.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top
                                        | System.Windows.Forms.AnchorStyles.Bottom
                                        | System.Windows.Forms.AnchorStyles.Left
                                        | System.Windows.Forms.AnchorStyles.Right));
                // this.Tab_Grp.AutoSize = true;
            }
            else
            {
                if (My_anchor == AnchorType.RIGHT)
                {
                    this.Tab_Grp.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top
                                                            | System.Windows.Forms.AnchorStyles.Right));
                }
                else if (My_anchor == AnchorType.LEFT)
                {
                    this.Tab_Grp.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top
                                                            | System.Windows.Forms.AnchorStyles.Left));
                }
            }
            return true;
        }

        private bool Init_GridView(System.Windows.Forms.TabPage owner_tab, string group_name)
        {
            GridView = new DataGridView();
            Review_BT = new Button();
            Submit_BT = new Button();
            Import_BT = new Button();
            Export_BT = new Button();
            Delete_All_BT = new Button();
            Delete_Rows_BT = new Button();
            Privot_BT = new Button();

            Tab_Grp.Controls.Add(GridView);
            Tab_Grp.Controls.Add(Delete_All_BT);
            Tab_Grp.Controls.Add(Delete_Rows_BT);
            Tab_Grp.Controls.Add(Export_BT);
            Tab_Grp.Controls.Add(Import_BT);
            Tab_Grp.Controls.Add(Submit_BT);
            Tab_Grp.Controls.Add(Review_BT);
            Tab_Grp.Controls.Add(Privot_BT);

            GridView.Location = new System.Drawing.Point(10, 16);
            GridView.Size = new System.Drawing.Size(My_PosSize.width - 20, My_PosSize.height - 50);
            GridView.Anchor = ((System.Windows.Forms.AnchorStyles)(
                                System.Windows.Forms.AnchorStyles.Top
                                | System.Windows.Forms.AnchorStyles.Bottom
                                | System.Windows.Forms.AnchorStyles.Left
                                | System.Windows.Forms.AnchorStyles.Right));
            GridView.ScrollBars = ScrollBars.Both;
            GridView.AllowUserToDeleteRows = true;
            GridView.BindingContextChanged += new EventHandler(dataGridView1_BindingContextChanged);
            // GridView.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(GridView_DataBindingComplete);
            //GridView.CellContentDoubleClick += new DataGridViewCellEventHandler(GridView_CellContentDoubleClick);
            //GridView.RowsDefaultCellStyle.BackColor = Color.White;
            //GridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue;
            //GridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //GridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //GridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            Delete_Rows_BT.Text = "Del Rows";
            Delete_Rows_BT.Location = new System.Drawing.Point(10, Tab_Grp.Size.Height - 30);
            Delete_Rows_BT.Anchor = ((System.Windows.Forms.AnchorStyles)((
                                System.Windows.Forms.AnchorStyles.Bottom)
                                | System.Windows.Forms.AnchorStyles.Left));
            Delete_Rows_BT.Size = new System.Drawing.Size(65, 23);
            Delete_Rows_BT.Click += new System.EventHandler(Delete_Rows_BT_Click_event);
            Delete_Rows_BT.Visible = false;

            Delete_All_BT.Text = "Del All";
            Delete_All_BT.Location = new System.Drawing.Point(90, Tab_Grp.Size.Height - 30);
            Delete_All_BT.Anchor = ((System.Windows.Forms.AnchorStyles)((
                                System.Windows.Forms.AnchorStyles.Bottom)
                                | System.Windows.Forms.AnchorStyles.Left));
            Delete_All_BT.Size = new System.Drawing.Size(60, 23);
            Delete_All_BT.Click += new System.EventHandler(Delete_All_BT_Click_event);

            Export_BT.Text = "Export";
            Export_BT.Location = new System.Drawing.Point(170, Tab_Grp.Size.Height - 30);
            Export_BT.Size = new System.Drawing.Size(60, 23);
            Export_BT.Anchor = ((System.Windows.Forms.AnchorStyles)((
                                System.Windows.Forms.AnchorStyles.Bottom)
                                | System.Windows.Forms.AnchorStyles.Left));
            Export_BT.Click += new System.EventHandler(Export_BT_Click_event);

            Import_BT.Text = "Import";
            Import_BT.Location = new System.Drawing.Point(250, Tab_Grp.Size.Height - 30);
            Import_BT.Size = new System.Drawing.Size(60, 23);
            Import_BT.Anchor = ((System.Windows.Forms.AnchorStyles)((
                                System.Windows.Forms.AnchorStyles.Bottom)
                                | System.Windows.Forms.AnchorStyles.Left));

            Submit_BT.Text = "Save";
            Submit_BT.Location = new System.Drawing.Point(330, Tab_Grp.Size.Height - 30);
            Submit_BT.Size = new System.Drawing.Size(60, 23);
            Submit_BT.Anchor = ((System.Windows.Forms.AnchorStyles)((
                                System.Windows.Forms.AnchorStyles.Bottom)
                                | System.Windows.Forms.AnchorStyles.Left));
            Submit_BT.Click += new System.EventHandler(Submit_BT_Click_event);

            Review_BT.Text = "Refresh";
            Review_BT.Location = new System.Drawing.Point(410, Tab_Grp.Size.Height - 30);
            Review_BT.Size = new System.Drawing.Size(60, 23);
            Review_BT.Anchor = ((System.Windows.Forms.AnchorStyles)((
                                System.Windows.Forms.AnchorStyles.Bottom)
                                | System.Windows.Forms.AnchorStyles.Left));
            Review_BT.Click += new System.EventHandler(Review_BT_Click_event);

            Privot_BT.Text = "Privot";
            Privot_BT.Location = new System.Drawing.Point(490, Tab_Grp.Size.Height - 30);
            Privot_BT.Size = new System.Drawing.Size(60, 23);
            Privot_BT.Anchor = ((System.Windows.Forms.AnchorStyles)((
                                System.Windows.Forms.AnchorStyles.Bottom)
                                | System.Windows.Forms.AnchorStyles.Left));
            Privot_BT.Click += new System.EventHandler(Privot_BT_Click_event);
            Privot_BT.Visible = false;

            return true;
        }

        public bool Load_DataBase(string connection_str, string sql_cmd)
        {
            SQL_Load_CMD = sql_cmd;
            if (Data_dtb != null)
            {
                Data_dtb.Clear();
            }
            Data_dtb = Get_SQL_Data(connection_str, sql_cmd, ref Data_da, ref Data_ds);

            if (Data_dtb == null)
            {
                return false;
            }
            else
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = Data_dtb;
                GridView.DataSource = bs;
                return true;
            }
            // GridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        public void Update_Size(PosSize possize)
        {
            My_PosSize = possize;
            GridView.Size = new System.Drawing.Size(My_PosSize.width - 20, My_PosSize.height - 50);
        }

        public void Review_BT_Click_event(object sender, EventArgs e)
        {
            Load_DataBase(Database_Conn, SQL_Load_CMD);
        }

        public void Delete_Rows_BT_Click_event(object sender, EventArgs e)
        {
            int max_row;

            max_row = GridView.RowCount;

            for (int i = 0; i < max_row - 1; i++)
            {
                if (GridView.Rows[i].Selected)
                {
                    if (MessageBox.Show("Would you like to Delete row: " + (i + 1).ToString() + "?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        GridView.Rows.RemoveAt(i);
                        max_row--;
                        i--;
                    }
                }
            }
        }

        public void Save_Data()
        {
            if ((Update_SQL_Data(Data_da, Data_dtb) == false))
            {
                MessageBox.Show("Store Data Fail", "Failed");
            }
        }

        public void Submit_BT_Click_event(object sender, EventArgs e)
        {
            if ((Update_SQL_Data(Data_da, Data_dtb) == true))
            {
                MessageBox.Show("Store Data Complete", "Successful");
            }
            else
            {
                MessageBox.Show("Store Data Fail", "Failed");
            }
        }


        public void Delete_All_BT_Click_event(object sender, EventArgs e)
        {
            if (MessageBox.Show("Would you like to Delete All Data " + "?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int total_row;
                total_row = GridView.RowCount;
                for (int i = 0; i < total_row - 1; i++)
                {
                    GridView.Rows.RemoveAt(i);
                    total_row--;
                    i--;
                }
            }
        }

        public void GridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Do you want to copy clipboard and edit " + "?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (GridView.CurrentCell.Value.ToString().Trim() != null)
                {
                    Clipboard.SetDataObject(GridView.CurrentCell.Value.ToString().Trim(), false);
                    //GridView.ClearSelection();
                }
            }
        }

        public void Export_BT_Click_event(object sender, EventArgs e)
        {
            SaveFileDialog save_diaglog = new SaveFileDialog();
            string file_name, fInfo;
            string temp;
            

            if (Update_SQL_Data(Data_da, Data_dtb) == false)
            {
                MessageBox.Show("Cập nhật thay đổi trước khi export file thất bại", "Thông báo");
            }

            save_diaglog.Filter = "Excel file (*.xlsx;*.xls)|*.xlsx;*.xls|All files (*.*)|*.*";
            if (save_diaglog.ShowDialog() == DialogResult.OK)
            {
                file_name = save_diaglog.FileName;
                fInfo = Path.GetExtension(save_diaglog.FileName);
                temp = Export_BT.Text;
                Export_BT.Text = "Exporting ...";
                Export_BT.Enabled = false;
                if ((fInfo == ".xlsx") || (fInfo == ".xls"))
                {
                    // ExportDataToExcel(file_name, fInfo, Group_Name, Data_dtb, ProgressBar1);
                    ExportGridviewToExcel(file_name, fInfo, Group_Name, GridView, ProgressBar1, Status_1, Status_2);
                }
                Export_BT.Enabled = true;
                Export_BT.Text = temp;
                MessageBox.Show("Export File thành công", "Thông báo");
            }

        }

        public void Refresh_Form()
        {
            Load_DataBase(Database_Conn, SQL_Load_CMD);
        }

        public void dataGridView1_BindingContextChanged(object sender, EventArgs e)
        {
            if (GridView.DataSource == null) return;

            foreach (DataGridViewColumn col in GridView.Columns)
            {
                col.HeaderCell = new
                    DataGridViewAutoFilterColumnHeaderCell(col.HeaderCell);
            }
            GridView.AutoResizeColumns();
        }

        public void Privot_BT_Click_event(object sender, EventArgs e)
        {
            Privot_DataTable = Create_PrivotTable(Data_dtb);
            if (Privot_DataTable != null)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = Privot_DataTable;
                GridView.DataSource = bs;
                GridView.AllowUserToAddRows = false;
                GridView.AutoResizeColumns();
            }
        }
    }
}
