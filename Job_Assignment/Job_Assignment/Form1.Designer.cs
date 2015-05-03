namespace Job_Assignment
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listOfProductionLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Features_Tab = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_ProductionPlanByWorkStation = new System.Windows.Forms.LinkLabel();
            this.lbl_ProductionPlanByDate = new System.Windows.Forms.LinkLabel();
            this.lbl_InputFromPlanner = new System.Windows.Forms.LinkLabel();
            this.lbl_LineSkillRequest = new System.Windows.Forms.LinkLabel();
            this.lbl_LineDescription = new System.Windows.Forms.LinkLabel();
            this.lbl_Empl_Skill = new System.Windows.Forms.LinkLabel();
            this.lbl_SkillList = new System.Windows.Forms.LinkLabel();
            this.KeHoachSXTheoTram = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Create = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.KHSX_WS_DatePick = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.KHSX_Save_BT = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.KHSX_WS_dtgrid = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.filterStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.showAllLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ll_WorkStationDescription = new System.Windows.Forms.LinkLabel();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Features_Tab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.KeHoachSXTheoTram.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KHSX_WS_dtgrid)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.settingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(582, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listOfProductionLineToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // listOfProductionLineToolStripMenuItem
            // 
            this.listOfProductionLineToolStripMenuItem.Name = "listOfProductionLineToolStripMenuItem";
            this.listOfProductionLineToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.listOfProductionLineToolStripMenuItem.Text = "List of Production Line";
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.settingToolStripMenuItem.Text = "Setting";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.Features_Tab);
            this.tabControl1.Controls.Add(this.KeHoachSXTheoTram);
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(582, 300);
            this.tabControl1.TabIndex = 1;
            // 
            // Features_Tab
            // 
            this.Features_Tab.Controls.Add(this.groupBox1);
            this.Features_Tab.Location = new System.Drawing.Point(4, 22);
            this.Features_Tab.Name = "Features_Tab";
            this.Features_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.Features_Tab.Size = new System.Drawing.Size(574, 274);
            this.Features_Tab.TabIndex = 0;
            this.Features_Tab.Text = "Feature List";
            this.Features_Tab.UseVisualStyleBackColor = true;
            this.Features_Tab.Click += new System.EventHandler(this.Features_Tab_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ll_WorkStationDescription);
            this.groupBox1.Controls.Add(this.lbl_ProductionPlanByWorkStation);
            this.groupBox1.Controls.Add(this.lbl_ProductionPlanByDate);
            this.groupBox1.Controls.Add(this.lbl_InputFromPlanner);
            this.groupBox1.Controls.Add(this.lbl_LineSkillRequest);
            this.groupBox1.Controls.Add(this.lbl_LineDescription);
            this.groupBox1.Controls.Add(this.lbl_Empl_Skill);
            this.groupBox1.Controls.Add(this.lbl_SkillList);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 236);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Master Database";
            // 
            // lbl_ProductionPlanByWorkStation
            // 
            this.lbl_ProductionPlanByWorkStation.AutoSize = true;
            this.lbl_ProductionPlanByWorkStation.Location = new System.Drawing.Point(6, 185);
            this.lbl_ProductionPlanByWorkStation.Name = "lbl_ProductionPlanByWorkStation";
            this.lbl_ProductionPlanByWorkStation.Size = new System.Drawing.Size(162, 13);
            this.lbl_ProductionPlanByWorkStation.TabIndex = 1;
            this.lbl_ProductionPlanByWorkStation.TabStop = true;
            this.lbl_ProductionPlanByWorkStation.Text = "7. ProductionPlanByWorkStation";
            this.lbl_ProductionPlanByWorkStation.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_ProductionPlanByWorkStation_LinkClicked);
            // 
            // lbl_ProductionPlanByDate
            // 
            this.lbl_ProductionPlanByDate.AutoSize = true;
            this.lbl_ProductionPlanByDate.Location = new System.Drawing.Point(6, 163);
            this.lbl_ProductionPlanByDate.Name = "lbl_ProductionPlanByDate";
            this.lbl_ProductionPlanByDate.Size = new System.Drawing.Size(170, 13);
            this.lbl_ProductionPlanByDate.TabIndex = 1;
            this.lbl_ProductionPlanByDate.TabStop = true;
            this.lbl_ProductionPlanByDate.Text = "6. Ke Hoach San Xuat Theo Ngay";
            this.lbl_ProductionPlanByDate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_ProductionPlanByDate_LinkClicked);
            // 
            // lbl_InputFromPlanner
            // 
            this.lbl_InputFromPlanner.AutoSize = true;
            this.lbl_InputFromPlanner.Location = new System.Drawing.Point(6, 139);
            this.lbl_InputFromPlanner.Name = "lbl_InputFromPlanner";
            this.lbl_InputFromPlanner.Size = new System.Drawing.Size(108, 13);
            this.lbl_InputFromPlanner.TabIndex = 0;
            this.lbl_InputFromPlanner.TabStop = true;
            this.lbl_InputFromPlanner.Text = "5. Input From Planner";
            this.lbl_InputFromPlanner.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_InputFromPlanner_LinkClicked);
            // 
            // lbl_LineSkillRequest
            // 
            this.lbl_LineSkillRequest.AutoSize = true;
            this.lbl_LineSkillRequest.Location = new System.Drawing.Point(6, 116);
            this.lbl_LineSkillRequest.Name = "lbl_LineSkillRequest";
            this.lbl_LineSkillRequest.Size = new System.Drawing.Size(104, 13);
            this.lbl_LineSkillRequest.TabIndex = 0;
            this.lbl_LineSkillRequest.TabStop = true;
            this.lbl_LineSkillRequest.Text = "4. Line Skill Request";
            this.lbl_LineSkillRequest.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_LineSkillRequest_LinkClicked);
            // 
            // lbl_LineDescription
            // 
            this.lbl_LineDescription.AutoSize = true;
            this.lbl_LineDescription.Location = new System.Drawing.Point(6, 71);
            this.lbl_LineDescription.Name = "lbl_LineDescription";
            this.lbl_LineDescription.Size = new System.Drawing.Size(95, 13);
            this.lbl_LineDescription.TabIndex = 0;
            this.lbl_LineDescription.TabStop = true;
            this.lbl_LineDescription.Text = "3. Line Description";
            this.lbl_LineDescription.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_LineDescription_LinkClicked);
            // 
            // lbl_Empl_Skill
            // 
            this.lbl_Empl_Skill.AutoSize = true;
            this.lbl_Empl_Skill.Location = new System.Drawing.Point(6, 47);
            this.lbl_Empl_Skill.Name = "lbl_Empl_Skill";
            this.lbl_Empl_Skill.Size = new System.Drawing.Size(87, 13);
            this.lbl_Empl_Skill.TabIndex = 0;
            this.lbl_Empl_Skill.TabStop = true;
            this.lbl_Empl_Skill.Text = "2. Employee Skill";
            this.lbl_Empl_Skill.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_Empl_Skill_LinkClicked);
            // 
            // lbl_SkillList
            // 
            this.lbl_SkillList.AutoSize = true;
            this.lbl_SkillList.Location = new System.Drawing.Point(6, 25);
            this.lbl_SkillList.Name = "lbl_SkillList";
            this.lbl_SkillList.Size = new System.Drawing.Size(57, 13);
            this.lbl_SkillList.TabIndex = 0;
            this.lbl_SkillList.TabStop = true;
            this.lbl_SkillList.Text = "1. Skill List";
            this.lbl_SkillList.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ListProductionLine_Link_LinkClicked);
            // 
            // KeHoachSXTheoTram
            // 
            this.KeHoachSXTheoTram.Controls.Add(this.panel2);
            this.KeHoachSXTheoTram.Controls.Add(this.panel1);
            this.KeHoachSXTheoTram.Controls.Add(this.KHSX_WS_dtgrid);
            this.KeHoachSXTheoTram.Location = new System.Drawing.Point(4, 22);
            this.KeHoachSXTheoTram.Name = "KeHoachSXTheoTram";
            this.KeHoachSXTheoTram.Padding = new System.Windows.Forms.Padding(3);
            this.KeHoachSXTheoTram.Size = new System.Drawing.Size(574, 274);
            this.KeHoachSXTheoTram.TabIndex = 1;
            this.KeHoachSXTheoTram.Text = "KeHoachSXTheoTram";
            this.KeHoachSXTheoTram.UseVisualStyleBackColor = true;
            this.KeHoachSXTheoTram.Click += new System.EventHandler(this.KeHoachSXTheoTram_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_Create);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.KHSX_WS_DatePick);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(568, 57);
            this.panel2.TabIndex = 4;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btn_Create
            // 
            this.btn_Create.Location = new System.Drawing.Point(281, 25);
            this.btn_Create.Name = "btn_Create";
            this.btn_Create.Size = new System.Drawing.Size(75, 23);
            this.btn_Create.TabIndex = 0;
            this.btn_Create.Text = "Create";
            this.btn_Create.UseVisualStyleBackColor = true;
            this.btn_Create.Click += new System.EventHandler(this.btn_Create_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Date";
            // 
            // KHSX_WS_DatePick
            // 
            this.KHSX_WS_DatePick.Location = new System.Drawing.Point(55, 28);
            this.KHSX_WS_DatePick.Name = "KHSX_WS_DatePick";
            this.KHSX_WS_DatePick.Size = new System.Drawing.Size(200, 20);
            this.KHSX_WS_DatePick.TabIndex = 3;
            this.KHSX_WS_DatePick.ValueChanged += new System.EventHandler(this.KHSX_WS_DatePick_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.KHSX_Save_BT);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 230);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(568, 41);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // KHSX_Save_BT
            // 
            this.KHSX_Save_BT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.KHSX_Save_BT.Location = new System.Drawing.Point(201, 7);
            this.KHSX_Save_BT.Name = "KHSX_Save_BT";
            this.KHSX_Save_BT.Size = new System.Drawing.Size(75, 23);
            this.KHSX_Save_BT.TabIndex = 0;
            this.KHSX_Save_BT.Text = "Save";
            this.KHSX_Save_BT.UseVisualStyleBackColor = true;
            this.KHSX_Save_BT.Click += new System.EventHandler(this.KHSX_Save_BT_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(299, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Export";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button1_Click);
            // 
            // KHSX_WS_dtgrid
            // 
            this.KHSX_WS_dtgrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.KHSX_WS_dtgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.KHSX_WS_dtgrid.Location = new System.Drawing.Point(3, 71);
            this.KHSX_WS_dtgrid.Name = "KHSX_WS_dtgrid";
            this.KHSX_WS_dtgrid.Size = new System.Drawing.Size(563, 153);
            this.KHSX_WS_dtgrid.TabIndex = 0;
            this.KHSX_WS_dtgrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel1,
            this.StatusLabel2,
            this.ProgressBar1,
            this.filterStatusLabel,
            this.showAllLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 330);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(582, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel1
            // 
            this.StatusLabel1.Name = "StatusLabel1";
            this.StatusLabel1.Size = new System.Drawing.Size(67, 17);
            this.StatusLabel1.Text = "StatusLabel";
            // 
            // StatusLabel2
            // 
            this.StatusLabel2.Name = "StatusLabel2";
            this.StatusLabel2.Size = new System.Drawing.Size(50, 17);
            this.StatusLabel2.Text = "Status_2";
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // filterStatusLabel
            // 
            this.filterStatusLabel.Name = "filterStatusLabel";
            this.filterStatusLabel.Size = new System.Drawing.Size(33, 17);
            this.filterStatusLabel.Text = "Filter";
            // 
            // showAllLabel
            // 
            this.showAllLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.WhiteSpace;
            this.showAllLabel.Name = "showAllLabel";
            this.showAllLabel.Size = new System.Drawing.Size(53, 17);
            this.showAllLabel.Text = "Show All";
            // 
            // ll_WorkStationDescription
            // 
            this.ll_WorkStationDescription.AutoSize = true;
            this.ll_WorkStationDescription.Location = new System.Drawing.Point(7, 94);
            this.ll_WorkStationDescription.Name = "ll_WorkStationDescription";
            this.ll_WorkStationDescription.Size = new System.Drawing.Size(134, 13);
            this.ll_WorkStationDescription.TabIndex = 2;
            this.ll_WorkStationDescription.TabStop = true;
            this.ll_WorkStationDescription.Text = "3. WorkStation Description";
            this.ll_WorkStationDescription.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_WorkStationDescription_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 352);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.Features_Tab.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.KeHoachSXTheoTram.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KHSX_WS_dtgrid)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Features_Tab;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel filterStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel showAllLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem listOfProductionLineToolStripMenuItem;
        private System.Windows.Forms.LinkLabel lbl_Empl_Skill;
        private System.Windows.Forms.LinkLabel lbl_SkillList;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel2;
        private System.Windows.Forms.LinkLabel lbl_InputFromPlanner;
        private System.Windows.Forms.LinkLabel lbl_LineSkillRequest;
        private System.Windows.Forms.LinkLabel lbl_LineDescription;
        private System.Windows.Forms.LinkLabel lbl_ProductionPlanByDate;
        private System.Windows.Forms.LinkLabel lbl_ProductionPlanByWorkStation;
        private System.Windows.Forms.TabPage KeHoachSXTheoTram;
        private System.Windows.Forms.DataGridView KHSX_WS_dtgrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker KHSX_WS_DatePick;
        private System.Windows.Forms.Button btn_Create;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button KHSX_Save_BT;
        private System.Windows.Forms.LinkLabel ll_WorkStationDescription;
    }
}

