namespace Pathology
{
    partial class Frmopdbillentry
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
            this.txtbalance = new System.Windows.Forms.TextBox();
            this.dgvoutsource = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtadv = new System.Windows.Forms.TextBox();
            this.txtdisc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtdue = new System.Windows.Forms.Label();
            this.dgvbillnew = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtest = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnprint = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.cboname1 = new System.Windows.Forms.Label();
            this.cbopcode = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dt_discharge = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.txttreatment_given = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbillnew)).BeginInit();
            this.SuspendLayout();
            // 
            // txtbalance
            // 
            this.txtbalance.Location = new System.Drawing.Point(469, 514);
            this.txtbalance.Name = "txtbalance";
            this.txtbalance.Size = new System.Drawing.Size(100, 20);
            this.txtbalance.TabIndex = 44;
            this.txtbalance.Validating += new System.ComponentModel.CancelEventHandler(this.txtbalance_Validating);
            // 
            // dgvoutsource
            // 
            this.dgvoutsource.HeaderText = "O/s";
            this.dgvoutsource.Name = "dgvoutsource";
            // 
            // txtadv
            // 
            this.txtadv.Location = new System.Drawing.Point(469, 488);
            this.txtadv.Name = "txtadv";
            this.txtadv.Size = new System.Drawing.Size(100, 20);
            this.txtadv.TabIndex = 42;
            this.txtadv.Validating += new System.ComponentModel.CancelEventHandler(this.txtadv_Validating);
            // 
            // txtdisc
            // 
            this.txtdisc.Location = new System.Drawing.Point(469, 462);
            this.txtdisc.Name = "txtdisc";
            this.txtdisc.Size = new System.Drawing.Size(100, 20);
            this.txtdisc.TabIndex = 41;
            this.txtdisc.Validating += new System.ComponentModel.CancelEventHandler(this.txtdisc_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(405, 488);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Advance  :";
            // 
            // dgvprice
            // 
            this.dgvprice.HeaderText = "Rate";
            this.dgvprice.Name = "dgvprice";
            this.dgvprice.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvprice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(405, 465);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Discount  :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 412);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "label4";
            // 
            // txtdue
            // 
            this.txtdue.AutoSize = true;
            this.txtdue.Location = new System.Drawing.Point(468, 442);
            this.txtdue.Name = "txtdue";
            this.txtdue.Size = new System.Drawing.Size(0, 13);
            this.txtdue.TabIndex = 30;
            this.txtdue.Validating += new System.ComponentModel.CancelEventHandler(this.txtdue_Validating);
            // 
            // dgvbillnew
            // 
            this.dgvbillnew.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvbillnew.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.dgvtest,
            this.dgvprice,
            this.dgvoutsource});
            this.dgvbillnew.Location = new System.Drawing.Point(12, 137);
            this.dgvbillnew.Name = "dgvbillnew";
            this.dgvbillnew.Size = new System.Drawing.Size(739, 237);
            this.dgvbillnew.TabIndex = 29;
            this.dgvbillnew.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvbillnew_CellEndEdit);
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            // 
            // dgvtest
            // 
            this.dgvtest.HeaderText = "Test";
            this.dgvtest.Name = "dgvtest";
            this.dgvtest.Width = 250;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(385, 517);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 43;
            this.label7.Text = "Balance Due  :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(405, 443);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "TOTAL  :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Name  :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Regn No./Bill No  :";
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.Cornsilk;
            this.btnprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.Location = new System.Drawing.Point(279, 451);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(91, 41);
            this.btnprint.TabIndex = 35;
            this.btnprint.Text = "Print";
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // btncancel
            // 
            this.btncancel.BackColor = System.Drawing.Color.Cornsilk;
            this.btncancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.Location = new System.Drawing.Point(671, 8);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 41);
            this.btncancel.TabIndex = 34;
            this.btncancel.Text = "Back";
            this.btncancel.UseVisualStyleBackColor = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.Cornsilk;
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.Location = new System.Drawing.Point(164, 451);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(99, 41);
            this.btnsave.TabIndex = 33;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // cboname1
            // 
            this.cboname1.AutoSize = true;
            this.cboname1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboname1.Location = new System.Drawing.Point(264, 18);
            this.cboname1.Name = "cboname1";
            this.cboname1.Size = new System.Drawing.Size(57, 20);
            this.cboname1.TabIndex = 32;
            this.cboname1.Text = "label2";
            // 
            // cbopcode
            // 
            this.cbopcode.AutoSize = true;
            this.cbopcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbopcode.Location = new System.Drawing.Point(153, 17);
            this.cbopcode.Name = "cbopcode";
            this.cbopcode.Size = new System.Drawing.Size(57, 20);
            this.cbopcode.TabIndex = 31;
            this.cbopcode.Text = "label1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(352, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 45;
            this.label8.Text = "Date Discharge  :";
            // 
            // dt_discharge
            // 
            this.dt_discharge.CustomFormat = "dd/MM/yyyy";
            this.dt_discharge.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_discharge.Location = new System.Drawing.Point(435, 19);
            this.dt_discharge.Name = "dt_discharge";
            this.dt_discharge.Size = new System.Drawing.Size(89, 20);
            this.dt_discharge.TabIndex = 46;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(56, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 47;
            this.label9.Text = "Treatment Given";
            // 
            // txttreatment_given
            // 
            this.txttreatment_given.Location = new System.Drawing.Point(148, 64);
            this.txttreatment_given.Multiline = true;
            this.txttreatment_given.Name = "txttreatment_given";
            this.txttreatment_given.Size = new System.Drawing.Size(376, 67);
            this.txttreatment_given.TabIndex = 48;
            // 
            // Frmopdbillentry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 578);
            this.Controls.Add(this.txttreatment_given);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dt_discharge);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtbalance);
            this.Controls.Add(this.txtadv);
            this.Controls.Add(this.txtdisc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtdue);
            this.Controls.Add(this.dgvbillnew);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.cboname1);
            this.Controls.Add(this.cbopcode);
            this.Name = "Frmopdbillentry";
            this.Text = "Frmopdbillentry";
            this.Load += new System.EventHandler(this.Frmopdbillentry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvbillnew)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbalance;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvoutsource;
        private System.Windows.Forms.TextBox txtadv;
        private System.Windows.Forms.TextBox txtdisc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvprice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtdue;
        private System.Windows.Forms.DataGridView dgvbillnew;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvtest;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Label cboname1;
        private System.Windows.Forms.Label cbopcode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dt_discharge;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txttreatment_given;
    }
}