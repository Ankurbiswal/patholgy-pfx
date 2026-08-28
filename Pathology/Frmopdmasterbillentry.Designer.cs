namespace Pathology
{
    partial class Frmopdmasterbillentry
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
            this.txttreatment_given = new System.Windows.Forms.TextBox();
            this.dgvtest = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.dt_discharge = new System.Windows.Forms.DateTimePicker();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.txtbalance = new System.Windows.Forms.TextBox();
            this.txtadv = new System.Windows.Forms.TextBox();
            this.dgvoutsource = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtdisc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtdue = new System.Windows.Forms.Label();
            this.dgvbillnew = new System.Windows.Forms.DataGridView();
            this.dgvprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnprint = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.cboname1 = new System.Windows.Forms.Label();
            this.cbopcode = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbillnew)).BeginInit();
            this.SuspendLayout();
            // 
            // txttreatment_given
            // 
            this.txttreatment_given.Location = new System.Drawing.Point(165, 70);
            this.txttreatment_given.Multiline = true;
            this.txttreatment_given.Name = "txttreatment_given";
            this.txttreatment_given.Size = new System.Drawing.Size(376, 67);
            this.txttreatment_given.TabIndex = 69;
            // 
            // dgvtest
            // 
            this.dgvtest.HeaderText = "Test";
            this.dgvtest.Name = "dgvtest";
            this.dgvtest.Width = 250;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(73, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 68;
            this.label9.Text = "Treatment Given";
            // 
            // dt_discharge
            // 
            this.dt_discharge.CustomFormat = "dd/MM/yyyy";
            this.dt_discharge.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_discharge.Location = new System.Drawing.Point(452, 25);
            this.dt_discharge.Name = "dt_discharge";
            this.dt_discharge.Size = new System.Drawing.Size(89, 20);
            this.dt_discharge.TabIndex = 67;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(369, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 66;
            this.label8.Text = "Date Discharge  :";
            // 
            // txtbalance
            // 
            this.txtbalance.Location = new System.Drawing.Point(486, 520);
            this.txtbalance.Name = "txtbalance";
            this.txtbalance.Size = new System.Drawing.Size(100, 20);
            this.txtbalance.TabIndex = 65;
            this.txtbalance.Validating += new System.ComponentModel.CancelEventHandler(this.txtbalance_Validating);
            // 
            // txtadv
            // 
            this.txtadv.Location = new System.Drawing.Point(486, 494);
            this.txtadv.Name = "txtadv";
            this.txtadv.Size = new System.Drawing.Size(100, 20);
            this.txtadv.TabIndex = 63;
            // 
            // dgvoutsource
            // 
            this.dgvoutsource.HeaderText = "O/s";
            this.dgvoutsource.Name = "dgvoutsource";
            // 
            // txtdisc
            // 
            this.txtdisc.Location = new System.Drawing.Point(486, 468);
            this.txtdisc.Name = "txtdisc";
            this.txtdisc.Size = new System.Drawing.Size(100, 20);
            this.txtdisc.TabIndex = 62;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(422, 494);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 61;
            this.label6.Text = "Advance  :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(422, 471);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 60;
            this.label5.Text = "Discount  :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(73, 418);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 59;
            this.label4.Text = "label4";
            // 
            // txtdue
            // 
            this.txtdue.AutoSize = true;
            this.txtdue.Location = new System.Drawing.Point(485, 448);
            this.txtdue.Name = "txtdue";
            this.txtdue.Size = new System.Drawing.Size(0, 13);
            this.txtdue.TabIndex = 51;
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
            this.dgvbillnew.Location = new System.Drawing.Point(29, 143);
            this.dgvbillnew.Name = "dgvbillnew";
            this.dgvbillnew.Size = new System.Drawing.Size(739, 237);
            this.dgvbillnew.TabIndex = 50;
            this.dgvbillnew.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvbillnew_CellEndEdit);
            // 
            // dgvprice
            // 
            this.dgvprice.HeaderText = "Rate";
            this.dgvprice.Name = "dgvprice";
            this.dgvprice.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvprice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(402, 523);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 64;
            this.label7.Text = "Balance Due  :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(422, 449);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 58;
            this.label3.Text = "TOTAL  :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "Regn No./Bill No  :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 57;
            this.label2.Text = "Name  :";
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.Cornsilk;
            this.btnprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.Location = new System.Drawing.Point(296, 457);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(91, 41);
            this.btnprint.TabIndex = 56;
            this.btnprint.Text = "Print";
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // btncancel
            // 
            this.btncancel.BackColor = System.Drawing.Color.Cornsilk;
            this.btncancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.Location = new System.Drawing.Point(688, 14);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 41);
            this.btncancel.TabIndex = 55;
            this.btncancel.Text = "Back";
            this.btncancel.UseVisualStyleBackColor = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.Cornsilk;
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.Location = new System.Drawing.Point(181, 457);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(99, 41);
            this.btnsave.TabIndex = 54;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // cboname1
            // 
            this.cboname1.AutoSize = true;
            this.cboname1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboname1.Location = new System.Drawing.Point(281, 24);
            this.cboname1.Name = "cboname1";
            this.cboname1.Size = new System.Drawing.Size(57, 20);
            this.cboname1.TabIndex = 53;
            this.cboname1.Text = "label2";
            // 
            // cbopcode
            // 
            this.cbopcode.AutoSize = true;
            this.cbopcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbopcode.Location = new System.Drawing.Point(170, 23);
            this.cbopcode.Name = "cbopcode";
            this.cbopcode.Size = new System.Drawing.Size(57, 20);
            this.cbopcode.TabIndex = 52;
            this.cbopcode.Text = "label1";
            // 
            // Frmopdmasterbillentry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 572);
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
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.cboname1);
            this.Controls.Add(this.cbopcode);
            this.Name = "Frmopdmasterbillentry";
            this.Text = "Frmopdmasterbillentry";
            this.Load += new System.EventHandler(this.Frmopdmasterbillentry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvbillnew)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txttreatment_given;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvtest;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dt_discharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtbalance;
        private System.Windows.Forms.TextBox txtadv;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvoutsource;
        private System.Windows.Forms.TextBox txtdisc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtdue;
        private System.Windows.Forms.DataGridView dgvbillnew;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvprice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Label cboname1;
        private System.Windows.Forms.Label cbopcode;
    }
}