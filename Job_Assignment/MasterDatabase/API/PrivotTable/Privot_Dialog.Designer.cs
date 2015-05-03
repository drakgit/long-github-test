namespace MasterDatabase
{
    partial class Privot_Dialog_Form
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
            this.ColField_ListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AllCol_listBox = new System.Windows.Forms.ListBox();
            this.RowField_Select_BT = new System.Windows.Forms.Button();
            this.ColField_Select_BT = new System.Windows.Forms.Button();
            this.OK_BT = new System.Windows.Forms.Button();
            this.Clear_BT = new System.Windows.Forms.Button();
            this.Cancel_BT = new System.Windows.Forms.Button();
            this.RowField_Txt = new System.Windows.Forms.TextBox();
            this.PrivotType_Cbx = new System.Windows.Forms.ComboBox();
            this.Value_lbl = new System.Windows.Forms.Label();
            this.Value_BT = new System.Windows.Forms.Button();
            this.ValueField_Txt = new System.Windows.Forms.TextBox();
            this.ColField_Remove_BT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ColField_ListBox
            // 
            this.ColField_ListBox.FormattingEnabled = true;
            this.ColField_ListBox.Location = new System.Drawing.Point(255, 49);
            this.ColField_ListBox.Name = "ColField_ListBox";
            this.ColField_ListBox.Size = new System.Drawing.Size(237, 108);
            this.ColField_ListBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "All Columns ";
            // 
            // AllCol_listBox
            // 
            this.AllCol_listBox.FormattingEnabled = true;
            this.AllCol_listBox.Location = new System.Drawing.Point(12, 50);
            this.AllCol_listBox.Name = "AllCol_listBox";
            this.AllCol_listBox.Size = new System.Drawing.Size(237, 264);
            this.AllCol_listBox.TabIndex = 1;
            // 
            // RowField_Select_BT
            // 
            this.RowField_Select_BT.Location = new System.Drawing.Point(255, 210);
            this.RowField_Select_BT.Name = "RowField_Select_BT";
            this.RowField_Select_BT.Size = new System.Drawing.Size(75, 23);
            this.RowField_Select_BT.TabIndex = 3;
            this.RowField_Select_BT.Text = "Row Field";
            this.RowField_Select_BT.UseVisualStyleBackColor = true;
            this.RowField_Select_BT.Click += new System.EventHandler(this.RowField_Select_BT_Click);
            // 
            // ColField_Select_BT
            // 
            this.ColField_Select_BT.Location = new System.Drawing.Point(255, 20);
            this.ColField_Select_BT.Name = "ColField_Select_BT";
            this.ColField_Select_BT.Size = new System.Drawing.Size(96, 23);
            this.ColField_Select_BT.TabIndex = 3;
            this.ColField_Select_BT.Text = "Columns Field";
            this.ColField_Select_BT.UseVisualStyleBackColor = true;
            this.ColField_Select_BT.Click += new System.EventHandler(this.ColField_Select_BT_Click);
            // 
            // OK_BT
            // 
            this.OK_BT.Location = new System.Drawing.Point(12, 328);
            this.OK_BT.Name = "OK_BT";
            this.OK_BT.Size = new System.Drawing.Size(75, 23);
            this.OK_BT.TabIndex = 4;
            this.OK_BT.Text = "OK";
            this.OK_BT.UseVisualStyleBackColor = true;
            this.OK_BT.Click += new System.EventHandler(this.OK_BT_Click);
            // 
            // Clear_BT
            // 
            this.Clear_BT.Location = new System.Drawing.Point(93, 328);
            this.Clear_BT.Name = "Clear_BT";
            this.Clear_BT.Size = new System.Drawing.Size(75, 23);
            this.Clear_BT.TabIndex = 4;
            this.Clear_BT.Text = "Clear";
            this.Clear_BT.UseVisualStyleBackColor = true;
            this.Clear_BT.Click += new System.EventHandler(this.Clear_BT_Click);
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Location = new System.Drawing.Point(174, 328);
            this.Cancel_BT.Name = "Cancel_BT";
            this.Cancel_BT.Size = new System.Drawing.Size(75, 23);
            this.Cancel_BT.TabIndex = 4;
            this.Cancel_BT.Text = "Cancel";
            this.Cancel_BT.UseVisualStyleBackColor = true;
            this.Cancel_BT.Click += new System.EventHandler(this.Cancel_BT_Click);
            // 
            // RowField_Txt
            // 
            this.RowField_Txt.Enabled = false;
            this.RowField_Txt.Location = new System.Drawing.Point(255, 239);
            this.RowField_Txt.Name = "RowField_Txt";
            this.RowField_Txt.Size = new System.Drawing.Size(235, 20);
            this.RowField_Txt.TabIndex = 5;
            // 
            // PrivotType_Cbx
            // 
            this.PrivotType_Cbx.FormattingEnabled = true;
            this.PrivotType_Cbx.Location = new System.Drawing.Point(255, 183);
            this.PrivotType_Cbx.Name = "PrivotType_Cbx";
            this.PrivotType_Cbx.Size = new System.Drawing.Size(235, 21);
            this.PrivotType_Cbx.TabIndex = 6;
            this.PrivotType_Cbx.SelectedIndexChanged += new System.EventHandler(this.ValueField_Cbx_SelectedIndexChanged);
            // 
            // Value_lbl
            // 
            this.Value_lbl.AutoSize = true;
            this.Value_lbl.Location = new System.Drawing.Point(255, 167);
            this.Value_lbl.Name = "Value_lbl";
            this.Value_lbl.Size = new System.Drawing.Size(61, 13);
            this.Value_lbl.TabIndex = 7;
            this.Value_lbl.Text = "Privot Type";
            // 
            // Value_BT
            // 
            this.Value_BT.Location = new System.Drawing.Point(255, 265);
            this.Value_BT.Name = "Value_BT";
            this.Value_BT.Size = new System.Drawing.Size(75, 23);
            this.Value_BT.TabIndex = 3;
            this.Value_BT.Text = "Value Field";
            this.Value_BT.UseVisualStyleBackColor = true;
            this.Value_BT.Click += new System.EventHandler(this.Value_BT_Click);
            // 
            // ValueField_Txt
            // 
            this.ValueField_Txt.Enabled = false;
            this.ValueField_Txt.Location = new System.Drawing.Point(255, 294);
            this.ValueField_Txt.Name = "ValueField_Txt";
            this.ValueField_Txt.Size = new System.Drawing.Size(235, 20);
            this.ValueField_Txt.TabIndex = 5;
            // 
            // ColField_Remove_BT
            // 
            this.ColField_Remove_BT.Location = new System.Drawing.Point(419, 20);
            this.ColField_Remove_BT.Name = "ColField_Remove_BT";
            this.ColField_Remove_BT.Size = new System.Drawing.Size(75, 23);
            this.ColField_Remove_BT.TabIndex = 8;
            this.ColField_Remove_BT.Text = "Remove";
            this.ColField_Remove_BT.UseVisualStyleBackColor = true;
            this.ColField_Remove_BT.Click += new System.EventHandler(this.ColField_Remove_BT_Click);
            // 
            // Privot_Dialog_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 363);
            this.Controls.Add(this.ColField_Remove_BT);
            this.Controls.Add(this.Value_lbl);
            this.Controls.Add(this.PrivotType_Cbx);
            this.Controls.Add(this.ValueField_Txt);
            this.Controls.Add(this.RowField_Txt);
            this.Controls.Add(this.Cancel_BT);
            this.Controls.Add(this.Clear_BT);
            this.Controls.Add(this.OK_BT);
            this.Controls.Add(this.ColField_Select_BT);
            this.Controls.Add(this.Value_BT);
            this.Controls.Add(this.RowField_Select_BT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AllCol_listBox);
            this.Controls.Add(this.ColField_ListBox);
            this.Name = "Privot_Dialog_Form";
            this.Text = "Privot_Dialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ColField_ListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox AllCol_listBox;
        private System.Windows.Forms.Button RowField_Select_BT;
        private System.Windows.Forms.Button ColField_Select_BT;
        private System.Windows.Forms.Button OK_BT;
        private System.Windows.Forms.Button Clear_BT;
        private System.Windows.Forms.Button Cancel_BT;
        private System.Windows.Forms.TextBox RowField_Txt;
        private System.Windows.Forms.ComboBox PrivotType_Cbx;
        private System.Windows.Forms.Label Value_lbl;
        private System.Windows.Forms.Button Value_BT;
        private System.Windows.Forms.TextBox ValueField_Txt;
        private System.Windows.Forms.Button ColField_Remove_BT;
    }
}