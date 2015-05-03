using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using DataGridViewAutoFilter;

namespace MasterDatabase
{
    public partial class ucMaster : UserControl
    {

        private int Tab_index = 0;
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
        public Excel.Application OpenXL;
        ExcelController excelContrller = new ExcelController();
        public ucMaster()
        {
            InitializeComponent();
        }
        public ucMaster(Excel.Application openXL, TabControl Owner_Tab, string tab_name, int tab_index, 
                                string conection_str, string init_Database_struct_cmd, string select_database_cmd,
                                int num_of_search_engine, ExcelImportStruct [] Excel_Import_Struct,
                                ToolStripStatusLabel filterStatuslabel, ToolStripStatusLabel showAllLabel,
                                ToolStripStatusLabel status1, ToolStripStatusLabel status2,
                                ToolStripProgressBar prog)
        {
            InitializeComponent();
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
        }

        private void dtDelete_Click(object sender, EventArgs e)
        {

        }

        private void grvMaster_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            String filterStatus = DataGridViewAutoFilterColumnHeaderCell.GetFilterStatus(grvMaster);
            if (String.IsNullOrEmpty(filterStatus))
            {
                //temp
                //if (MasterDatabase_ShowAll_BT != null)
                //{
                //    MasterDatabase_ShowAll_BT.My_Button.Visible = false;
                //}
                MasterDatabase_showAllLabel.Visible = false;
                MasterDatabase_filterStatus.Visible = false;
            }
            else
            {
                //temp
                //if (MasterDatabase_ShowAll_BT != null)
                //{
                //    MasterDatabase_ShowAll_BT.My_Button.Visible = true;
                //}
                MasterDatabase_showAllLabel.Visible = false;
                MasterDatabase_filterStatus.Visible = true;
                MasterDatabase_filterStatus.Text = filterStatus;
            }
        }

        private void btImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Excel file (*.xlsx;*.xls)|*.xlsx;*.xls|All files (*.*)|*.*";

            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                ExcelController excelController = new ExcelController();
                DataTable dt = new DataTable();
                String ret = excelController.GetDataFromFile(open_dialog.FileName, ref dt);
                if (!String.IsNullOrEmpty(ret))
                {
                    MessageBox.Show(ret, "Thông báo");
                    return;
                }
                frmExcelPreview frm = new frmExcelPreview(dt);
                frm.ShowDialog();

                //file_name = open_dialog.FileName;
                //fInfo = Path.GetExtension(open_dialog.FileName);
                //btImport.Text = "Importing ...";
                //btImport.Enabled = false;
                //ret_var = excelContrller.Import_Database_Excel_File(file_name, 1, Excel_Struct, 100, 2, ProgressBar1, StatusLabel1, StatusLabel2);

                //excelContrller.Import_Database_from_file(file_name);

                //btImport.Enabled = true;
                //btImport.Text = temp;
            }
        }

        private void btExport_Click(object sender, EventArgs e)
        {

        }
    }
}
