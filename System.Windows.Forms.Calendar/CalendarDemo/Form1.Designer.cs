namespace CalendarDemo
{
    partial class DemoForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange6 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange7 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange8 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange9 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange10 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.redTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yellowTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greenTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blueTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otherColorTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.patternToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diagonalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.noneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timescaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.minutesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.minutesToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.minutesToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.selectImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageAlignmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.northToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.southToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.westToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.editItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.calendar1 = new System.Windows.Forms.Calendar.Calendar();
            this.monthView1 = new System.Windows.Forms.Calendar.MonthView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.redTagToolStripMenuItem,
            this.yellowTagToolStripMenuItem,
            this.greenTagToolStripMenuItem,
            this.blueTagToolStripMenuItem,
            this.otherColorTagToolStripMenuItem,
            this.toolStripMenuItem1,
            this.patternToolStripMenuItem,
            this.timescaleToolStripMenuItem,
            this.toolStripMenuItem2,
            this.selectImageToolStripMenuItem,
            this.imageAlignmentToolStripMenuItem,
            this.toolStripMenuItem5,
            this.editItemToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(167, 242);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // redTagToolStripMenuItem
            // 
            this.redTagToolStripMenuItem.Name = "redTagToolStripMenuItem";
            this.redTagToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.redTagToolStripMenuItem.Text = "Red tag";
            this.redTagToolStripMenuItem.Click += new System.EventHandler(this.redTagToolStripMenuItem_Click);
            // 
            // yellowTagToolStripMenuItem
            // 
            this.yellowTagToolStripMenuItem.Name = "yellowTagToolStripMenuItem";
            this.yellowTagToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.yellowTagToolStripMenuItem.Text = "Yellow tag";
            this.yellowTagToolStripMenuItem.Click += new System.EventHandler(this.yellowTagToolStripMenuItem_Click);
            // 
            // greenTagToolStripMenuItem
            // 
            this.greenTagToolStripMenuItem.Name = "greenTagToolStripMenuItem";
            this.greenTagToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.greenTagToolStripMenuItem.Text = "Green tag";
            this.greenTagToolStripMenuItem.Click += new System.EventHandler(this.greenTagToolStripMenuItem_Click);
            // 
            // blueTagToolStripMenuItem
            // 
            this.blueTagToolStripMenuItem.Name = "blueTagToolStripMenuItem";
            this.blueTagToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.blueTagToolStripMenuItem.Text = "Blue tag";
            this.blueTagToolStripMenuItem.Click += new System.EventHandler(this.blueTagToolStripMenuItem_Click);
            // 
            // otherColorTagToolStripMenuItem
            // 
            this.otherColorTagToolStripMenuItem.Name = "otherColorTagToolStripMenuItem";
            this.otherColorTagToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.otherColorTagToolStripMenuItem.Text = "Other color tag...";
            this.otherColorTagToolStripMenuItem.Click += new System.EventHandler(this.otherColorTagToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(163, 6);
            // 
            // patternToolStripMenuItem
            // 
            this.patternToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.diagonalToolStripMenuItem,
            this.verticalToolStripMenuItem,
            this.horizontalToolStripMenuItem,
            this.hatchToolStripMenuItem,
            this.toolStripMenuItem3,
            this.noneToolStripMenuItem});
            this.patternToolStripMenuItem.Name = "patternToolStripMenuItem";
            this.patternToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.patternToolStripMenuItem.Text = "Pattern";
            // 
            // diagonalToolStripMenuItem
            // 
            this.diagonalToolStripMenuItem.Name = "diagonalToolStripMenuItem";
            this.diagonalToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.diagonalToolStripMenuItem.Text = "Diagonal";
            this.diagonalToolStripMenuItem.Click += new System.EventHandler(this.diagonalToolStripMenuItem_Click);
            // 
            // verticalToolStripMenuItem
            // 
            this.verticalToolStripMenuItem.Name = "verticalToolStripMenuItem";
            this.verticalToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.verticalToolStripMenuItem.Text = "Vertical";
            this.verticalToolStripMenuItem.Click += new System.EventHandler(this.verticalToolStripMenuItem_Click);
            // 
            // horizontalToolStripMenuItem
            // 
            this.horizontalToolStripMenuItem.Name = "horizontalToolStripMenuItem";
            this.horizontalToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.horizontalToolStripMenuItem.Text = "Horizontal";
            this.horizontalToolStripMenuItem.Click += new System.EventHandler(this.horizontalToolStripMenuItem_Click);
            // 
            // hatchToolStripMenuItem
            // 
            this.hatchToolStripMenuItem.Name = "hatchToolStripMenuItem";
            this.hatchToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.hatchToolStripMenuItem.Text = "Cross";
            this.hatchToolStripMenuItem.Click += new System.EventHandler(this.hatchToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(126, 6);
            // 
            // noneToolStripMenuItem
            // 
            this.noneToolStripMenuItem.Name = "noneToolStripMenuItem";
            this.noneToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.noneToolStripMenuItem.Text = "None";
            this.noneToolStripMenuItem.Click += new System.EventHandler(this.noneToolStripMenuItem_Click);
            // 
            // timescaleToolStripMenuItem
            // 
            this.timescaleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hourToolStripMenuItem,
            this.minutesToolStripMenuItem,
            this.toolStripMenuItem4,
            this.minutesToolStripMenuItem1,
            this.minutesToolStripMenuItem2,
            this.minutesToolStripMenuItem3});
            this.timescaleToolStripMenuItem.Name = "timescaleToolStripMenuItem";
            this.timescaleToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.timescaleToolStripMenuItem.Text = "Timescale";
            // 
            // hourToolStripMenuItem
            // 
            this.hourToolStripMenuItem.Name = "hourToolStripMenuItem";
            this.hourToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.hourToolStripMenuItem.Text = "1 hour";
            this.hourToolStripMenuItem.Click += new System.EventHandler(this.hourToolStripMenuItem_Click);
            // 
            // minutesToolStripMenuItem
            // 
            this.minutesToolStripMenuItem.Name = "minutesToolStripMenuItem";
            this.minutesToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.minutesToolStripMenuItem.Text = "30 minutes";
            this.minutesToolStripMenuItem.Click += new System.EventHandler(this.minutesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(132, 22);
            this.toolStripMenuItem4.Text = "15 minutes";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // minutesToolStripMenuItem1
            // 
            this.minutesToolStripMenuItem1.Name = "minutesToolStripMenuItem1";
            this.minutesToolStripMenuItem1.Size = new System.Drawing.Size(132, 22);
            this.minutesToolStripMenuItem1.Text = "10 minutes";
            this.minutesToolStripMenuItem1.Click += new System.EventHandler(this.minutesToolStripMenuItem1_Click);
            // 
            // minutesToolStripMenuItem2
            // 
            this.minutesToolStripMenuItem2.Name = "minutesToolStripMenuItem2";
            this.minutesToolStripMenuItem2.Size = new System.Drawing.Size(132, 22);
            this.minutesToolStripMenuItem2.Text = "6 minutes";
            this.minutesToolStripMenuItem2.Click += new System.EventHandler(this.minutesToolStripMenuItem2_Click);
            // 
            // minutesToolStripMenuItem3
            // 
            this.minutesToolStripMenuItem3.Name = "minutesToolStripMenuItem3";
            this.minutesToolStripMenuItem3.Size = new System.Drawing.Size(132, 22);
            this.minutesToolStripMenuItem3.Text = "5 minutes";
            this.minutesToolStripMenuItem3.Click += new System.EventHandler(this.minutesToolStripMenuItem3_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(163, 6);
            // 
            // selectImageToolStripMenuItem
            // 
            this.selectImageToolStripMenuItem.Name = "selectImageToolStripMenuItem";
            this.selectImageToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.selectImageToolStripMenuItem.Text = "Select Image...";
            this.selectImageToolStripMenuItem.Click += new System.EventHandler(this.selectImageToolStripMenuItem_Click);
            // 
            // imageAlignmentToolStripMenuItem
            // 
            this.imageAlignmentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.northToolStripMenuItem,
            this.eastToolStripMenuItem,
            this.southToolStripMenuItem,
            this.westToolStripMenuItem});
            this.imageAlignmentToolStripMenuItem.Name = "imageAlignmentToolStripMenuItem";
            this.imageAlignmentToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.imageAlignmentToolStripMenuItem.Text = "Image Alignment";
            // 
            // northToolStripMenuItem
            // 
            this.northToolStripMenuItem.Name = "northToolStripMenuItem";
            this.northToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.northToolStripMenuItem.Text = "North";
            this.northToolStripMenuItem.Click += new System.EventHandler(this.northToolStripMenuItem_Click);
            // 
            // eastToolStripMenuItem
            // 
            this.eastToolStripMenuItem.Name = "eastToolStripMenuItem";
            this.eastToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.eastToolStripMenuItem.Text = "East";
            this.eastToolStripMenuItem.Click += new System.EventHandler(this.eastToolStripMenuItem_Click);
            // 
            // southToolStripMenuItem
            // 
            this.southToolStripMenuItem.Name = "southToolStripMenuItem";
            this.southToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.southToolStripMenuItem.Text = "South";
            this.southToolStripMenuItem.Click += new System.EventHandler(this.southToolStripMenuItem_Click);
            // 
            // westToolStripMenuItem
            // 
            this.westToolStripMenuItem.Name = "westToolStripMenuItem";
            this.westToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.westToolStripMenuItem.Text = "West";
            this.westToolStripMenuItem.Click += new System.EventHandler(this.westToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(163, 6);
            // 
            // editItemToolStripMenuItem
            // 
            this.editItemToolStripMenuItem.Name = "editItemToolStripMenuItem";
            this.editItemToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.editItemToolStripMenuItem.Text = "Edit item\'s text";
            this.editItemToolStripMenuItem.Click += new System.EventHandler(this.editItemToolStripMenuItem_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(208, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 497);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // calendar1
            // 
            this.calendar1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.calendar1.ContextMenuStrip = this.contextMenuStrip1;
            this.calendar1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.calendar1.FromDate = new System.DateTime(2016, 5, 29, 0, 0, 0, 0);
            calendarHighlightRange6.DayOfWeek = System.DayOfWeek.Monday;
            calendarHighlightRange6.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange6.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange7.DayOfWeek = System.DayOfWeek.Tuesday;
            calendarHighlightRange7.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange7.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange8.DayOfWeek = System.DayOfWeek.Wednesday;
            calendarHighlightRange8.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange8.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange9.DayOfWeek = System.DayOfWeek.Thursday;
            calendarHighlightRange9.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange9.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange10.DayOfWeek = System.DayOfWeek.Friday;
            calendarHighlightRange10.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange10.StartTime = System.TimeSpan.Parse("08:00:00");
            this.calendar1.HighlightRanges = new System.Windows.Forms.Calendar.CalendarHighlightRange[] {
        calendarHighlightRange6,
        calendarHighlightRange7,
        calendarHighlightRange8,
        calendarHighlightRange9,
        calendarHighlightRange10};
            this.calendar1.Lines = null;
            this.calendar1.Location = new System.Drawing.Point(213, 89);
            this.calendar1.Name = "calendar1";
            this.calendar1.Size = new System.Drawing.Size(610, 408);
            this.calendar1.TabIndex = 2;
            this.calendar1.Text = "calendar1";
            this.calendar1.TimeScale = System.Windows.Forms.Calendar.CalendarTimeScale.SixtyMinutes;
            this.calendar1.ToDate = new System.DateTime(2016, 6, 1, 0, 0, 0, 0);
            this.calendar1.LoadItems += new System.Windows.Forms.Calendar.Calendar.CalendarLoadEventHandler(this.calendar1_LoadItems);
            this.calendar1.DayHeaderClick += new System.Windows.Forms.Calendar.Calendar.CalendarDayEventHandler(this.calendar1_DayHeaderClick);
            this.calendar1.ItemCreated += new System.Windows.Forms.Calendar.Calendar.CalendarItemCancelEventHandler(this.calendar1_ItemCreated);
            this.calendar1.ItemDeleted += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.calendar1_ItemDeleted);
            this.calendar1.ItemClick += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.calendar1_ItemClick);
            this.calendar1.ItemDoubleClick += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.calendar1_ItemDoubleClick);
            this.calendar1.ItemMouseHover += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.calendar1_ItemMouseHover);
            // 
            // monthView1
            // 
            this.monthView1.ArrowsColor = System.Drawing.SystemColors.Window;
            this.monthView1.ArrowsSelectedColor = System.Drawing.Color.Gold;
            this.monthView1.DayBackgroundColor = System.Drawing.Color.Empty;
            this.monthView1.DayGrayedText = System.Drawing.SystemColors.GrayText;
            this.monthView1.DaySelectedBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.monthView1.DaySelectedColor = System.Drawing.SystemColors.WindowText;
            this.monthView1.DaySelectedTextColor = System.Drawing.SystemColors.HighlightText;
            this.monthView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.monthView1.ItemPadding = new System.Windows.Forms.Padding(2);
            this.monthView1.Location = new System.Drawing.Point(0, 0);
            this.monthView1.MaxSelectionCount = 35;
            this.monthView1.MonthTitleColor = System.Drawing.SystemColors.ActiveCaption;
            this.monthView1.MonthTitleColorInactive = System.Drawing.SystemColors.InactiveCaption;
            this.monthView1.MonthTitleTextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.monthView1.MonthTitleTextColorInactive = System.Drawing.SystemColors.InactiveCaptionText;
            this.monthView1.Name = "monthView1";
            this.monthView1.Size = new System.Drawing.Size(208, 497);
            this.monthView1.TabIndex = 3;
            this.monthView1.Text = "monthView1";
            this.monthView1.TodayBorderColor = System.Drawing.Color.Maroon;
            this.monthView1.SelectionChanged += new System.EventHandler(this.monthView1_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(213, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(610, 82);
            this.panel1.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(11, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Line 2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(111, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "Line 3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(212, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "Line 4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(317, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 0;
            this.button5.Text = "Line 5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // DemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 497);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.calendar1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.monthView1);
            this.Name = "DemoForm";
            this.Text = "Calendar Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DemoForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Calendar.Calendar calendar1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem redTagToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yellowTagToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem greenTagToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blueTagToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem timescaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hourToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minutesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem editItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minutesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem minutesToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem minutesToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem otherColorTagToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patternToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diagonalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem noneToolStripMenuItem;
        private System.Windows.Forms.Calendar.MonthView monthView1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem selectImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageAlignmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem northToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem southToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem westToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
    }
}

