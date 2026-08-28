namespace Pathology
{
    partial class Frmvoucherentry
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label29 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.gracdes = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.grdcin = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.grdebitamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grcreditamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grnarr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grchno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grchdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbovoucherno = new System.Windows.Forms.ComboBox();
            this.txtchdt = new System.Windows.Forms.DateTimePicker();
            this.dtvoucher = new System.Windows.Forms.DateTimePicker();
            this.txtchno = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtcompid = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cbobankname = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtdb = new System.Windows.Forms.Label();
            this.txtcr = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnback = new System.Windows.Forms.Button();
            this.crvvch = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.Color.Goldenrod;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 4F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Millimeter, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.Cornsilk;
            this.label29.Location = new System.Drawing.Point(-4, -1);
            this.label29.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(814, 18);
            this.label29.TabIndex = 154;
            this.label29.Text = "Voucher Entry";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(11, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(2, 15);
            this.label4.TabIndex = 155;
            // 
            // dgv
            // 
            this.dgv.BackgroundColor = System.Drawing.Color.LightYellow;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gracdes,
            this.grdcin,
            this.grdebitamount,
            this.grcreditamount,
            this.grnarr,
            this.grchno,
            this.grchdt});
            this.dgv.Location = new System.Drawing.Point(11, 90);
            this.dgv.Name = "dgv";
            this.dgv.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(987, 331);
            this.dgv.TabIndex = 147;
            this.dgv.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEndEdit);
            this.dgv.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_EditingControlShowing);
            this.dgv.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_DataError);
            // 
            // gracdes
            // 
            this.gracdes.HeaderText = "A/c Description";
            this.gracdes.Name = "gracdes";
            this.gracdes.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gracdes.Sorted = true;
            this.gracdes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.gracdes.ToolTipText = "A/c Name to be selected";
            this.gracdes.Width = 250;
            // 
            // grdcin
            // 
            this.grdcin.DisplayStyleForCurrentCellOnly = true;
            this.grdcin.HeaderText = "Dr/Cr";
            this.grdcin.Name = "grdcin";
            this.grdcin.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grdcin.Sorted = true;
            this.grdcin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.grdcin.ToolTipText = "if paid then Dr/Cr is D else if received  Dr/Cr is C";
            this.grdcin.Width = 50;
            // 
            // grdebitamount
            // 
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0.00";
            this.grdebitamount.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdebitamount.HeaderText = "Paid Amt  ";
            this.grdebitamount.Name = "grdebitamount";
            this.grdebitamount.ToolTipText = "if Dr/Cr=D Give value for paid amount ";
            this.grdebitamount.Width = 95;
            // 
            // grcreditamount
            // 
            this.grcreditamount.HeaderText = "Received Amt  ";
            this.grcreditamount.Name = "grcreditamount";
            this.grcreditamount.ToolTipText = "if Dr/Cr=C Give value for received amount";
            // 
            // grnarr
            // 
            this.grnarr.HeaderText = "Narration";
            this.grnarr.Name = "grnarr";
            this.grnarr.Width = 200;
            // 
            // grchno
            // 
            this.grchno.HeaderText = "Chqno";
            this.grchno.Name = "grchno";
            // 
            // grchdt
            // 
            this.grchdt.HeaderText = "Chdt";
            this.grchdt.Name = "grchdt";
            // 
            // cbovoucherno
            // 
            this.cbovoucherno.AllowDrop = true;
            this.cbovoucherno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbovoucherno.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbovoucherno.FormatString = "N0";
            this.cbovoucherno.FormattingEnabled = true;
            this.cbovoucherno.Location = new System.Drawing.Point(375, 36);
            this.cbovoucherno.Name = "cbovoucherno";
            this.cbovoucherno.Size = new System.Drawing.Size(116, 21);
            this.cbovoucherno.Sorted = true;
            this.cbovoucherno.TabIndex = 142;
            this.cbovoucherno.Validating += new System.ComponentModel.CancelEventHandler(this.cbovoucherno_Validating);
            this.cbovoucherno.SelectedIndexChanged += new System.EventHandler(this.cbovoucherno_SelectedIndexChanged);
            // 
            // txtchdt
            // 
            this.txtchdt.CustomFormat = "dd/MM/yyyy";
            this.txtchdt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtchdt.Location = new System.Drawing.Point(595, 60);
            this.txtchdt.Name = "txtchdt";
            this.txtchdt.ShowCheckBox = true;
            this.txtchdt.Size = new System.Drawing.Size(103, 20);
            this.txtchdt.TabIndex = 146;
            // 
            // dtvoucher
            // 
            this.dtvoucher.CustomFormat = "dd/MM/yyyy";
            this.dtvoucher.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtvoucher.Location = new System.Drawing.Point(595, 36);
            this.dtvoucher.Name = "dtvoucher";
            this.dtvoucher.Size = new System.Drawing.Size(103, 20);
            this.dtvoucher.TabIndex = 143;
            // 
            // txtchno
            // 
            this.txtchno.Location = new System.Drawing.Point(375, 60);
            this.txtchno.Name = "txtchno";
            this.txtchno.Size = new System.Drawing.Size(116, 20);
            this.txtchno.TabIndex = 145;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(508, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 15);
            this.label6.TabIndex = 141;
            this.label6.Text = "Cheq. Date :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(299, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 15);
            this.label5.TabIndex = 139;
            this.label5.Text = "Cheq No. :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 138;
            this.label3.Text = "Txn Type :";
            // 
            // txtcompid
            // 
            this.txtcompid.Location = new System.Drawing.Point(12, 64);
            this.txtcompid.Name = "txtcompid";
            this.txtcompid.ReadOnly = true;
            this.txtcompid.Size = new System.Drawing.Size(20, 20);
            this.txtcompid.TabIndex = 140;
            this.txtcompid.Visible = false;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label28.Location = new System.Drawing.Point(38, 69);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(68, 15);
            this.label28.TabIndex = 153;
            this.label28.Text = "Company Id.";
            this.label28.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Cornsilk;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.Brown;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(147, 473);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 34);
            this.btnAdd.TabIndex = 148;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Cornsilk;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Brown;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(402, 473);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 34);
            this.btnCancel.TabIndex = 151;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Cornsilk;
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.Brown;
            this.btnPrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Location = new System.Drawing.Point(487, 473);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(87, 34);
            this.btnPrint.TabIndex = 152;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Cornsilk;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(317, 473);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(87, 34);
            this.btnDelete.TabIndex = 150;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Cornsilk;
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Location = new System.Drawing.Point(232, 473);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(87, 34);
            this.btnUpdate.TabIndex = 149;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cbobankname
            // 
            this.cbobankname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbobankname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbobankname.FormattingEnabled = true;
            this.cbobankname.Location = new System.Drawing.Point(123, 36);
            this.cbobankname.Name = "cbobankname";
            this.cbobankname.Size = new System.Drawing.Size(156, 21);
            this.cbobankname.Sorted = true;
            this.cbobankname.TabIndex = 144;
            this.cbobankname.SelectedIndexChanged += new System.EventHandler(this.cbobankname_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(285, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 136;
            this.label1.Text = "Voucher No.:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(545, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 15);
            this.label2.TabIndex = 137;
            this.label2.Text = "Date :";
            // 
            // txtdb
            // 
            this.txtdb.AutoSize = true;
            this.txtdb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtdb.Location = new System.Drawing.Point(352, 445);
            this.txtdb.Name = "txtdb";
            this.txtdb.Size = new System.Drawing.Size(56, 15);
            this.txtdb.TabIndex = 156;
            this.txtdb.Text = "Paid amt :";
            // 
            // txtcr
            // 
            this.txtcr.AutoSize = true;
            this.txtcr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtcr.Location = new System.Drawing.Point(452, 445);
            this.txtcr.Name = "txtcr";
            this.txtcr.Size = new System.Drawing.Size(61, 15);
            this.txtcr.TabIndex = 157;
            this.txtcr.Text = "Recv amt :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(241, 445);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 15);
            this.label7.TabIndex = 158;
            this.label7.Text = "Total :";
            // 
            // btnback
            // 
            this.btnback.Image = global::Pathology.Properties.Resources.back_btn;
            this.btnback.Location = new System.Drawing.Point(887, 36);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(111, 49);
            this.btnback.TabIndex = 159;
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // crvvch
            // 
            this.crvvch.ActiveViewIndex = -1;
            this.crvvch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvvch.DisplayGroupTree = false;
            this.crvvch.Location = new System.Drawing.Point(15, 137);
            this.crvvch.Name = "crvvch";
            this.crvvch.SelectionFormula = "";
            this.crvvch.Size = new System.Drawing.Size(983, 597);
            this.crvvch.TabIndex = 160;
            this.crvvch.ViewTimeSelectionFormula = "";
            this.crvvch.Load += new System.EventHandler(this.crvvch_Load);
            // 
            // Frmvoucherentry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(1179, 746);
            this.Controls.Add(this.crvvch);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtcr);
            this.Controls.Add(this.txtdb);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.cbovoucherno);
            this.Controls.Add(this.txtchdt);
            this.Controls.Add(this.dtvoucher);
            this.Controls.Add(this.txtchno);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtcompid);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.cbobankname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "Frmvoucherentry";
            this.Text = "VOUCHER PREPARATION";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmvoucherentry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ComboBox cbovoucherno;
        private System.Windows.Forms.DateTimePicker txtchdt;
        private System.Windows.Forms.DateTimePicker dtvoucher;
        private System.Windows.Forms.TextBox txtchno;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtcompid;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox cbobankname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtdb;
        private System.Windows.Forms.Label txtcr;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.DataGridViewComboBoxColumn gracdes;
        private System.Windows.Forms.DataGridViewComboBoxColumn grdcin;
        private System.Windows.Forms.DataGridViewTextBoxColumn grdebitamount;
        private System.Windows.Forms.DataGridViewTextBoxColumn grcreditamount;
        private System.Windows.Forms.DataGridViewTextBoxColumn grnarr;
        private System.Windows.Forms.DataGridViewTextBoxColumn grchno;
        private System.Windows.Forms.DataGridViewTextBoxColumn grchdt;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvvch;
    }
}