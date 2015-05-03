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
    public partial class frmExcelPreview : Form
    {
        //public frmExcelPreview()
        //{
        //    InitializeComponent();
        //}
        public frmExcelPreview(DataTable dt)
        {
            InitializeComponent();
            grvPreview.DataSource = dt;
        }

        private void btConfirm_Click(object sender, EventArgs e)
        {

        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
