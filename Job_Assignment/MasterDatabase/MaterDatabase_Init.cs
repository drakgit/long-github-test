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

namespace MasterDatabase
{
    public partial class MaterDatabase : SQL_APPL
    {
        public const bool AUTO_RESIZE = true;
        public const bool NO_AUTO_RESIZE = false;
        
        private int Tab_index = 0;

        public System.Windows.Forms.TabPage MasterDatabase_Tab;

        public Gridview_Grp MasterDatabase_GridviewTBL;
        public DataGridView MasterDatabase_Col_Select_GridviewTBL;
        public Button_Lbl MasterDatabase_Search_BT;
        public Button_Lbl MasterDatabase_ShowAll_BT;
        public Button_Lbl MasterDatabase_Select_Col_BT;

        public ToolStripProgressBar ProgressBar1;
        public ToolStripStatusLabel StatusLabel1;
        public ToolStripStatusLabel StatusLabel2;
        public ToolStripStatusLabel MasterDatabase_filterStatus;
        public ToolStripStatusLabel MasterDatabase_showAllLabel;

        public string MasterDatabase_Connection_Str;
        public string Select_Database_Str;
        public string Init_Database_Str;
        public bool MasterDatabase_inited = false;
        public DataTable Select_View_Colum;

        #region Search Engine Define
        private Search_Engine[] Search_Engine_Array;
        public DataTable[] MasterDatabase_All_Column;
        public int MasterDatabase_Total_Search_Engine;
        #endregion

        ExcelImportStruct[] Excel_Struct;//  = new ExcelImportStruct[7];
        const int First_Column = 0;

        public MaterDatabase(Excel.Application openXL, TabControl Owner_Tab, string tab_name, int tab_index, 
                                string conection_str, string init_Database_struct_cmd, string select_database_cmd,
                                int num_of_search_engine, ExcelImportStruct [] Excel_Import_Struct,
                                ToolStripStatusLabel filterStatuslabel, ToolStripStatusLabel showAllLabel,
                                ToolStripStatusLabel status1, ToolStripStatusLabel status2,
                                ToolStripProgressBar prog)
        {
            bool first_engine = true;
            PosSize possize = new PosSize();

            if (MasterDatabase_inited == true)
            {
                Owner_Tab.SelectedIndex = Tab_index;
                return;
            }
            OpenXL = openXL;
            StatusLabel1 = status1;
            StatusLabel2 = status2;
            Excel_Struct = Excel_Import_Struct;
            MasterDatabase_inited = true;
            Tab_index = tab_index;
            
            MasterDatabase_Total_Search_Engine = num_of_search_engine;
            MasterDatabase_filterStatus = filterStatuslabel;
            MasterDatabase_showAllLabel = showAllLabel;
            MasterDatabase_Connection_Str = conection_str;
            Init_Database_Str = init_Database_struct_cmd;
            Select_Database_Str = select_database_cmd;

            MasterDatabase_Tab = new System.Windows.Forms.TabPage();
            MasterDatabase_Tab.Text = tab_name;
            MasterDatabase_Tab.SuspendLayout();
            MasterDatabase_Tab.AutoScroll = true;
            MasterDatabase_Tab.Location = new System.Drawing.Point(4, 22);
            MasterDatabase_Tab.Name = tab_name;
            MasterDatabase_Tab.Padding = new System.Windows.Forms.Padding(3);
            MasterDatabase_Tab.Size = new System.Drawing.Size(845, 367);
            MasterDatabase_Tab.BackColor = Color.Transparent;
            MasterDatabase_Tab.TabIndex = Tab_index;
            MasterDatabase_Tab.Text = tab_name;
            MasterDatabase_Tab.UseVisualStyleBackColor = true;
            MasterDatabase_Tab.ResumeLayout(true);

            Owner_Tab.Controls.Add(this.MasterDatabase_Tab);
            Owner_Tab.SelectTab(tab_name);

            // Init GridView
            possize.pos_x = 6;
            possize.pos_y = 6 + (MasterDatabase_Total_Search_Engine +1 ) * 28;
            possize.width = MasterDatabase_Tab.Size.Width - 20;
            possize.height = MasterDatabase_Tab.Size.Height - (MasterDatabase_Total_Search_Engine + 1) * 28 - 16;
            MasterDatabase_GridviewTBL = new Gridview_Grp(MasterDatabase_Tab, tab_name, possize, AUTO_RESIZE,
                                                MasterDatabase_Connection_Str, "", AnchorType.NONE);
            MasterDatabase_GridviewTBL.GridView.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(MasterDatabase_GridviewTBL_DataBindingComplete);
            MasterDatabase_GridviewTBL.Import_BT.Click += new EventHandler(Import_BT_Click);
            MasterDatabase_GridviewTBL.Status_1 = status1;
            MasterDatabase_GridviewTBL.Status_2 = status2;

            Load_MasterDatabase_Struct();
            

            // Init "Select Column" Control
            possize.pos_x = 300;
            possize.pos_y = 6;
            possize.width = MasterDatabase_Tab.Size.Width - 320;
            possize.height = (MasterDatabase_Total_Search_Engine +1 ) * 28;
            Select_View_Colum = Get_All_Select_Column(MasterDatabase_GridviewTBL.Data_dtb);
            MasterDatabase_Col_Select_GridviewTBL = new DataGridView();
            MasterDatabase_Col_Select_GridviewTBL.Location = new System.Drawing.Point(possize.pos_x, possize.pos_y);
            MasterDatabase_Col_Select_GridviewTBL.Size = new System.Drawing.Size(possize.width, possize.height);
            MasterDatabase_Col_Select_GridviewTBL.Anchor = ((System.Windows.Forms.AnchorStyles)(
                                System.Windows.Forms.AnchorStyles.Top
                                | System.Windows.Forms.AnchorStyles.Left
                                | System.Windows.Forms.AnchorStyles.Right));
            MasterDatabase_Col_Select_GridviewTBL.ScrollBars = ScrollBars.Both;
            MasterDatabase_Col_Select_GridviewTBL.AllowUserToDeleteRows = false;
            MasterDatabase_Col_Select_GridviewTBL.DataSource = Select_View_Colum;
            MasterDatabase_Tab.Controls.Add(MasterDatabase_Col_Select_GridviewTBL);
            MasterDatabase_Col_Select_GridviewTBL.Visible = false;

            #region Init Search Engine
            Search_Engine_Array = new Search_Engine[MasterDatabase_Total_Search_Engine];
            MasterDatabase_All_Column = new DataTable[MasterDatabase_Total_Search_Engine];
            possize.pos_x = 6;
            possize.pos_y = 6;
            possize.pos_x = 6;
            MasterDatabase_All_Column[0] = Get_All_Column(MasterDatabase_GridviewTBL.Data_dtb);
            Search_Engine_Array[0] = new Search_Engine(first_engine, 0, MasterDatabase_Tab, possize, "", TextBox_Type.TEXT, MasterDatabase_All_Column[0],
                                                        "Search_ID", "Search_ID", AnchorType.LEFT);
            for (int i = 0; i < MasterDatabase_Total_Search_Engine; i++)
            {
                //possize.pos_x = 6;
                //MasterDatabase_All_Column[i] = Get_All_Column(MasterDatabase_GridviewTBL.Data_dtb);
                //Search_Engine_Array[i] = new Search_Engine(first_engine, i, MasterDatabase_Tab, possize, "", TextBox_Type.TEXT, MasterDatabase_All_Column[i],
                //                                            "Search_ID", "Search_ID", AnchorType.LEFT);
                possize.pos_y += 28;
                first_engine = false;
            }

            if (MasterDatabase_Total_Search_Engine != 0)
            {
                possize.pos_x = 6;
                MasterDatabase_Search_BT = new Button_Lbl(0, MasterDatabase_Tab, "Search", possize, (AnchorStyles)AnchorStyles.Top | AnchorStyles.Left);
                MasterDatabase_Search_BT.My_Button.Click += new EventHandler(MasterDatabase_Search_Button_Click);

                possize.pos_x += 100;
                MasterDatabase_Select_Col_BT = new Button_Lbl(0, MasterDatabase_Tab, "Columns", possize, (AnchorStyles)AnchorStyles.Top | AnchorStyles.Left);
                MasterDatabase_Select_Col_BT.My_Button.Click += new EventHandler(MasterDatabase_Select_Col_BT_Click);
                MasterDatabase_Select_Col_BT.My_Button.Visible = true;
            }
            else
            {
                possize.pos_x = 6;
                MasterDatabase_Select_Col_BT = new Button_Lbl(0, MasterDatabase_Tab, "Columns", possize, (AnchorStyles)AnchorStyles.Top | AnchorStyles.Left);
                MasterDatabase_Select_Col_BT.My_Button.Click += new EventHandler(MasterDatabase_Select_Col_BT_Click);
                MasterDatabase_Select_Col_BT.My_Button.Visible = true;
            }
            possize.pos_x += 100;
            MasterDatabase_ShowAll_BT = new Button_Lbl(0, MasterDatabase_Tab, "No Filter", possize, (AnchorStyles)AnchorStyles.Top | AnchorStyles.Left);
            MasterDatabase_ShowAll_BT.My_Button.Click += new EventHandler(MasterDatabase_ShowAll_Button_Click);
            MasterDatabase_ShowAll_BT.My_Button.Visible = false;

            #endregion

            MasterDatabase_filterStatus.Text = "";
            MasterDatabase_filterStatus.Visible = false;
            MasterDatabase_showAllLabel.Text = "Show &All";
            MasterDatabase_showAllLabel.Visible = false;
            MasterDatabase_showAllLabel.IsLink = true;
            MasterDatabase_showAllLabel.LinkBehavior = LinkBehavior.HoverUnderline;

            MasterDatabase_GridviewTBL.dataGridView1_BindingContextChanged(null, null);

            // Init_BOM_Manage_Excel(BOM_Manage_GridviewTBL.Data_dtb);
        }
    }
}
