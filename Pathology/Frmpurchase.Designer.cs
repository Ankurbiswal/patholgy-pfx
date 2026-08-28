namespace Pathology
{
    partial class Frmpurchase
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
            this.label29 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtruntotal = new System.Windows.Forms.TextBox();
            this.dtorder = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dtchallan = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtorderno = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtchallanno = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txttotalamt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbotransport = new System.Windows.Forms.ComboBox();
            this.btnsearch = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.dgvitem = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Grquantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvunit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grrate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvgross = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpbilldate = new System.Windows.Forms.DateTimePicker();
            this.cbobillnumber = new System.Windows.Forms.ComboBox();
            this.txtcompanycode = new System.Windows.Forms.TextBox();
            this.cbopartyname = new System.Windows.Forms.ComboBox();
            this.cbotype = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnback = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.Color.Coral;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 4F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Millimeter, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.Cornsilk;
            this.label29.Location = new System.Drawing.Point(0, 0);
            this.label29.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(779, 19);
            this.label29.TabIndex = 148;
            this.label29.Text = "Material Receipt/Consumption";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(52, 19);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(0, 13);
            this.label22.TabIndex = 147;
            // 
            // txtruntotal
            // 
            this.txtruntotal.Location = new System.Drawing.Point(733, 426);
            this.txtruntotal.Name = "txtruntotal";
            this.txtruntotal.Size = new System.Drawing.Size(10, 20);
            this.txtruntotal.TabIndex = 146;
            // 
            // dtorder
            // 
            this.dtorder.CustomFormat = "dd/MM/yyyy";
            this.dtorder.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtorder.Location = new System.Drawing.Point(591, 67);
            this.dtorder.Name = "dtorder";
            this.dtorder.Size = new System.Drawing.Size(87, 20);
            this.dtorder.TabIndex = 129;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(526, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 145;
            this.label10.Text = "Order Date";
            // 
            // dtchallan
            // 
            this.dtchallan.CustomFormat = "dd/MM/yyyy";
            this.dtchallan.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtchallan.Location = new System.Drawing.Point(247, 67);
            this.dtchallan.Name = "dtchallan";
            this.dtchallan.Size = new System.Drawing.Size(91, 20);
            this.dtchallan.TabIndex = 127;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(195, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 144;
            this.label6.Text = "Date";
            // 
            // txtorderno
            // 
            this.txtorderno.Location = new System.Drawing.Point(410, 67);
            this.txtorderno.Name = "txtorderno";
            this.txtorderno.Size = new System.Drawing.Size(110, 20);
            this.txtorderno.TabIndex = 128;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(344, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 143;
            this.label5.Text = "Order No.";
            // 
            // txtchallanno
            // 
            this.txtchallanno.Location = new System.Drawing.Point(116, 67);
            this.txtchallanno.Name = "txtchallanno";
            this.txtchallanno.Size = new System.Drawing.Size(73, 20);
            this.txtchallanno.TabIndex = 126;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 142;
            this.label4.Text = "Bill No.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(584, 440);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 141;
            this.label3.Text = "Total :";
            // 
            // txttotalamt
            // 
            this.txttotalamt.Location = new System.Drawing.Point(627, 433);
            this.txttotalamt.Name = "txttotalamt";
            this.txttotalamt.Size = new System.Drawing.Size(100, 20);
            this.txttotalamt.TabIndex = 134;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(344, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 139;
            this.label2.Text = "Ref. ID";
            // 
            // cbotransport
            // 
            this.cbotransport.FormattingEnabled = true;
            this.cbotransport.Location = new System.Drawing.Point(410, 87);
            this.cbotransport.Name = "cbotransport";
            this.cbotransport.Size = new System.Drawing.Size(165, 21);
            this.cbotransport.TabIndex = 131;
            // 
            // btnsearch
            // 
            this.btnsearch.Location = new System.Drawing.Point(591, 87);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(87, 22);
            this.btnsearch.TabIndex = 132;
            this.btnsearch.Text = "Search";
            this.btnsearch.UseVisualStyleBackColor = true;
            // 
            // btnprint
            // 
            this.btnprint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnprint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnprint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.Location = new System.Drawing.Point(411, 430);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(55, 30);
            this.btnprint.TabIndex = 140;
            this.btnprint.Text = "Print";
            this.btnprint.UseVisualStyleBackColor = true;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // btncancel
            // 
            this.btncancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btncancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btncancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.Location = new System.Drawing.Point(340, 430);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(67, 30);
            this.btncancel.TabIndex = 138;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btndelete
            // 
            this.btndelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btndelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btndelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btndelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete.Location = new System.Drawing.Point(268, 430);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(65, 30);
            this.btndelete.TabIndex = 137;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnupdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnupdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnupdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnupdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnupdate.Location = new System.Drawing.Point(193, 430);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(70, 30);
            this.btnupdate.TabIndex = 136;
            this.btnupdate.Text = "Update";
            this.btnupdate.UseVisualStyleBackColor = true;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btnadd
            // 
            this.btnadd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnadd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnadd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnadd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadd.Location = new System.Drawing.Point(132, 430);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(55, 30);
            this.btnadd.TabIndex = 135;
            this.btnadd.Text = "&Add";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // dgv
            // 
            this.dgv.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvitem,
            this.Grquantity,
            this.dgvunit,
            this.Grrate,
            this.dgvgross});
            this.dgv.Location = new System.Drawing.Point(30, 115);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(915, 305);
            this.dgv.TabIndex = 133;
            this.dgv.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEndEdit);
            this.dgv.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_EditingControlShowing);
            // 
            // dgvitem
            // 
            this.dgvitem.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.dgvitem.DisplayStyleForCurrentCellOnly = true;
            this.dgvitem.HeaderText = "Item Desc";
            this.dgvitem.Name = "dgvitem";
            this.dgvitem.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvitem.Sorted = true;
            this.dgvitem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvitem.Width = 250;
            // 
            // Grquantity
            // 
            this.Grquantity.HeaderText = "Quantity";
            this.Grquantity.Name = "Grquantity";
            // 
            // dgvunit
            // 
            this.dgvunit.HeaderText = "Unit";
            this.dgvunit.Name = "dgvunit";
            // 
            // Grrate
            // 
            this.Grrate.HeaderText = "Rate";
            this.Grrate.Name = "Grrate";
            // 
            // dgvgross
            // 
            this.dgvgross.HeaderText = "Amount";
            this.dgvgross.Name = "dgvgross";
            // 
            // dtpbilldate
            // 
            this.dtpbilldate.CustomFormat = "dd/MM/yyyy";
            this.dtpbilldate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpbilldate.Location = new System.Drawing.Point(591, 47);
            this.dtpbilldate.Name = "dtpbilldate";
            this.dtpbilldate.Size = new System.Drawing.Size(87, 20);
            this.dtpbilldate.TabIndex = 125;
            // 
            // cbobillnumber
            // 
            this.cbobillnumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbobillnumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbobillnumber.FormattingEnabled = true;
            this.cbobillnumber.Location = new System.Drawing.Point(410, 46);
            this.cbobillnumber.Name = "cbobillnumber";
            this.cbobillnumber.Size = new System.Drawing.Size(110, 21);
            this.cbobillnumber.TabIndex = 124;
            this.cbobillnumber.Validating += new System.ComponentModel.CancelEventHandler(this.cbobillnumber_Validating);
            this.cbobillnumber.SelectedIndexChanged += new System.EventHandler(this.cbobillnumber_SelectedIndexChanged);
            // 
            // txtcompanycode
            // 
            this.txtcompanycode.Location = new System.Drawing.Point(116, 47);
            this.txtcompanycode.Name = "txtcompanycode";
            this.txtcompanycode.Size = new System.Drawing.Size(39, 20);
            this.txtcompanycode.TabIndex = 121;
            // 
            // cbopartyname
            // 
            this.cbopartyname.FormattingEnabled = true;
            this.cbopartyname.Location = new System.Drawing.Point(116, 87);
            this.cbopartyname.Name = "cbopartyname";
            this.cbopartyname.Size = new System.Drawing.Size(222, 21);
            this.cbopartyname.TabIndex = 130;
            // 
            // cbotype
            // 
            this.cbotype.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbotype.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbotype.FormattingEnabled = true;
            this.cbotype.Location = new System.Drawing.Point(247, 46);
            this.cbotype.Name = "cbotype";
            this.cbotype.Size = new System.Drawing.Size(91, 21);
            this.cbotype.TabIndex = 122;
            this.cbotype.SelectedIndexChanged += new System.EventHandler(this.cbotype_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(31, 90);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 13);
            this.label13.TabIndex = 123;
            this.label13.Text = "Party Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 120;
            this.label9.Text = "Company Code";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(555, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 119;
            this.label8.Text = "Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(344, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 118;
            this.label7.Text = "Receipt No.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(195, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 117;
            this.label1.Text = "Type";
            // 
            // btnback
            // 
            this.btnback.Image = global::Pathology.Properties.Resources.back_btn;
            this.btnback.Location = new System.Drawing.Point(704, 22);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(75, 41);
            this.btnback.TabIndex = 149;
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // Frmpurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(1050, 530);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.txtruntotal);
            this.Controls.Add(this.dtorder);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtchallan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtorderno);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtchallanno);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txttotalamt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbotransport);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.dtpbilldate);
            this.Controls.Add(this.cbobillnumber);
            this.Controls.Add(this.txtcompanycode);
            this.Controls.Add(this.cbopartyname);
            this.Controls.Add(this.cbotype);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Name = "Frmpurchase";
            this.Text = "Frmpurchase";
            this.Load += new System.EventHandler(this.Frmpurchase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtruntotal;
        private System.Windows.Forms.DateTimePicker dtorder;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtchallan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtorderno;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtchallanno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txttotalamt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbotransport;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DateTimePicker dtpbilldate;
        private System.Windows.Forms.ComboBox cbobillnumber;
        private System.Windows.Forms.TextBox txtcompanycode;
        private System.Windows.Forms.ComboBox cbopartyname;
        private System.Windows.Forms.ComboBox cbotype;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvitem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grquantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvunit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grrate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvgross;
        private System.Windows.Forms.Button btnback;
    }
}