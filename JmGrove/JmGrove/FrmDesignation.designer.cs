namespace Bsnl
{
    partial class FrmDesignation
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDesig = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtdesigId = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dgDesig = new System.Windows.Forms.DataGridView();
            this.ddlDesignType = new System.Windows.Forms.ComboBox();
            this.Sno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesigId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesigNm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesignationCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgDesig)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(661, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "Designation Details";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDesig
            // 
            this.txtDesig.Location = new System.Drawing.Point(28, 458);
            this.txtDesig.Name = "txtDesig";
            this.txtDesig.ShortcutsEnabled = false;
            this.txtDesig.Size = new System.Drawing.Size(243, 26);
            this.txtDesig.TabIndex = 2;
            this.txtDesig.Tag = "Designation Name";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(28, 490);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(64, 28);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(98, 490);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(68, 28);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(172, 490);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(65, 28);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(243, 490);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(69, 28);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(393, 490);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 28);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtdesigId
            // 
            this.txtdesigId.BackColor = System.Drawing.Color.White;
            this.txtdesigId.ForeColor = System.Drawing.Color.Black;
            this.txtdesigId.Location = new System.Drawing.Point(12, 492);
            this.txtdesigId.Name = "txtdesigId";
            this.txtdesigId.ReadOnly = true;
            this.txtdesigId.Size = new System.Drawing.Size(10, 26);
            this.txtdesigId.TabIndex = 8;
            this.txtdesigId.Tag = "";
            this.txtdesigId.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(318, 490);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(69, 28);
            this.btnPrint.TabIndex = 10;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // dgDesig
            // 
            this.dgDesig.AllowUserToAddRows = false;
            this.dgDesig.AllowUserToDeleteRows = false;
            this.dgDesig.AllowUserToResizeRows = false;
            this.dgDesig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDesig.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sno,
            this.DesigId,
            this.DesigNm,
            this.DesignationCode});
            this.dgDesig.Location = new System.Drawing.Point(0, 54);
            this.dgDesig.MultiSelect = false;
            this.dgDesig.Name = "dgDesig";
            this.dgDesig.ReadOnly = true;
            this.dgDesig.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDesig.Size = new System.Drawing.Size(661, 398);
            this.dgDesig.TabIndex = 42;
            this.dgDesig.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgDesig_MouseDoubleClick);
            // 
            // ddlDesignType
            // 
            this.ddlDesignType.FormattingEnabled = true;
            this.ddlDesignType.Location = new System.Drawing.Point(290, 458);
            this.ddlDesignType.Name = "ddlDesignType";
            this.ddlDesignType.Size = new System.Drawing.Size(194, 26);
            this.ddlDesignType.TabIndex = 43;
            // 
            // Sno
            // 
            this.Sno.DataPropertyName = "Sno";
            this.Sno.HeaderText = "Sno.";
            this.Sno.Name = "Sno";
            this.Sno.ReadOnly = true;
            this.Sno.Width = 50;
            // 
            // DesigId
            // 
            this.DesigId.DataPropertyName = "DesigId";
            this.DesigId.HeaderText = "DesigId";
            this.DesigId.Name = "DesigId";
            this.DesigId.ReadOnly = true;
            this.DesigId.Visible = false;
            this.DesigId.Width = 5;
            // 
            // DesigNm
            // 
            this.DesigNm.DataPropertyName = "DesigNm";
            this.DesigNm.HeaderText = "Designation";
            this.DesigNm.Name = "DesigNm";
            this.DesigNm.ReadOnly = true;
            this.DesigNm.Width = 375;
            // 
            // DesignationCode
            // 
            this.DesignationCode.DataPropertyName = "DesignationCode";
            this.DesignationCode.HeaderText = "Designation Code";
            this.DesignationCode.Name = "DesignationCode";
            this.DesignationCode.ReadOnly = true;
            // 
            // FrmDesignation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 527);
            this.Controls.Add(this.ddlDesignType);
            this.Controls.Add(this.dgDesig);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtdesigId);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtDesig);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FrmDesignation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Designation Details";
            this.Load += new System.EventHandler(this.FrmDesignation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDesig)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDesig;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtdesigId;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dgDesig;
        private System.Windows.Forms.ComboBox ddlDesignType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sno;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesigId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesigNm;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesignationCode;
    }
}