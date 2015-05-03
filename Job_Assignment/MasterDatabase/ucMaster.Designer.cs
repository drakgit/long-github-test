namespace MasterDatabase
{
    partial class ucMaster
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.grvMaster = new System.Windows.Forms.DataGridView();
            this.dtDelete = new System.Windows.Forms.Button();
            this.pnFunction = new System.Windows.Forms.Panel();
            this.btRefresh = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.btImport = new System.Windows.Forms.Button();
            this.btExport = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvMaster)).BeginInit();
            this.pnFunction.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(744, 73);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.grvMaster);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 73);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(744, 292);
            this.panel3.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(744, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // grvMaster
            // 
            this.grvMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvMaster.Location = new System.Drawing.Point(0, 0);
            this.grvMaster.Name = "grvMaster";
            this.grvMaster.Size = new System.Drawing.Size(744, 292);
            this.grvMaster.TabIndex = 0;
            this.grvMaster.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grvMaster_DataBindingComplete);
            // 
            // dtDelete
            // 
            this.dtDelete.Location = new System.Drawing.Point(24, 13);
            this.dtDelete.Name = "dtDelete";
            this.dtDelete.Size = new System.Drawing.Size(75, 23);
            this.dtDelete.TabIndex = 0;
            this.dtDelete.Text = "Delete All";
            this.dtDelete.UseVisualStyleBackColor = true;
            this.dtDelete.Click += new System.EventHandler(this.dtDelete_Click);
            // 
            // pnFunction
            // 
            this.pnFunction.Controls.Add(this.btRefresh);
            this.pnFunction.Controls.Add(this.btSave);
            this.pnFunction.Controls.Add(this.btImport);
            this.pnFunction.Controls.Add(this.btExport);
            this.pnFunction.Controls.Add(this.dtDelete);
            this.pnFunction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFunction.Location = new System.Drawing.Point(0, 365);
            this.pnFunction.Name = "pnFunction";
            this.pnFunction.Size = new System.Drawing.Size(744, 48);
            this.pnFunction.TabIndex = 2;
            // 
            // btRefresh
            // 
            this.btRefresh.Location = new System.Drawing.Point(431, 13);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(75, 23);
            this.btRefresh.TabIndex = 4;
            this.btRefresh.Text = "Refresh";
            this.btRefresh.UseVisualStyleBackColor = true;
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(335, 13);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 3;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // btImport
            // 
            this.btImport.Location = new System.Drawing.Point(242, 13);
            this.btImport.Name = "btImport";
            this.btImport.Size = new System.Drawing.Size(75, 23);
            this.btImport.TabIndex = 2;
            this.btImport.Text = "Import";
            this.btImport.UseVisualStyleBackColor = true;
            this.btImport.Click += new System.EventHandler(this.btImport_Click);
            // 
            // btExport
            // 
            this.btExport.Location = new System.Drawing.Point(131, 13);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(75, 23);
            this.btExport.TabIndex = 1;
            this.btExport.Text = "Export";
            this.btExport.UseVisualStyleBackColor = true;
            this.btExport.Click += new System.EventHandler(this.btExport_Click);
            // 
            // ucMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnFunction);
            this.Name = "ucMaster";
            this.Size = new System.Drawing.Size(744, 413);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvMaster)).EndInit();
            this.pnFunction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel panel2;
        protected System.Windows.Forms.Panel panel3;
        protected System.Windows.Forms.DataGridView grvMaster;
        protected System.Windows.Forms.Button dtDelete;
        protected System.Windows.Forms.Panel pnFunction;
        protected System.Windows.Forms.Button btImport;
        protected System.Windows.Forms.Button btExport;
        protected System.Windows.Forms.Button btRefresh;
        protected System.Windows.Forms.Button btSave;
        protected System.Windows.Forms.Label label1;
    }
}
