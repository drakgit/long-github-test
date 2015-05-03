using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using System.IO;
using System.IO.Ports;
using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;
using MasterDatabase;


namespace Job_Assignment
{
    public partial class Form1 : SQL_APPL
    {
        public static string MasterDatabase_Connection_Str = @"server=.;database=JOB_ASSIGNMENT_DB;Integrated Security = TRUE";
        private string Cur_Path;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StatusLabel1.Text = "";
            StatusLabel2.Text = "";
            ProgressBar1.Visible = false;

            filterStatusLabel.Text = "";
            filterStatusLabel.Visible = false;
            showAllLabel.Text = "Show &All";
            showAllLabel.Visible = false;
            showAllLabel.IsLink = true;

            Cur_Path = Directory.GetCurrentDirectory();


            // BOM_Manage_Init();
            OpenXL = new Excel.Application();

            System.Globalization.CultureInfo oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            OpenXL.SheetsInNewWorkbook = 1;
            OpenXL.Visible = false;
            OpenXL.DisplayAlerts = false;
        }

        private void Features_Tab_Click(object sender, EventArgs e)
        {

        }

        private void KeHoachSXTheoTram_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
      
        

        

  
    }
}
