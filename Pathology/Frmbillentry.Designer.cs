namespace Pathology
{
    partial class Frmbillentry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmbillentry));
            this.dgvbillnew = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtest = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvoutsource = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvoscompany = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.txtdue = new System.Windows.Forms.Label();
            this.cbopcode = new System.Windows.Forms.Label();
            this.cboname1 = new System.Windows.Forms.Label();
            this.btnsave = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbalance = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtadv = new System.Windows.Forms.TextBox();
            this.txtdisc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbillnew)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvbillnew
            // 
            this.dgvbillnew.BackgroundColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvbillnew.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvbillnew.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvbillnew.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.dgvtest,
            this.dgvprice,
            this.dgvoutsource,
            this.dgvoscompany});
            this.dgvbillnew.Location = new System.Drawing.Point(33, 71);
            this.dgvbillnew.Name = "dgvbillnew";
            this.dgvbillnew.Size = new System.Drawing.Size(813, 325);
            this.dgvbillnew.TabIndex = 0;
            this.dgvbillnew.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvbillnew_UserDeletingRow);
            this.dgvbillnew.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvbillnew_UserDeletedRow);
            this.dgvbillnew.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvbillnew_CellEndEdit);
            this.dgvbillnew.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvbillnew_EditingControlShowing);
            this.dgvbillnew.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvbillnew_DataError);
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            // 
            // dgvtest
            // 
            this.dgvtest.HeaderText = "Test Name";
            this.dgvtest.Name = "dgvtest";
            this.dgvtest.Width = 250;
            // 
            // dgvprice
            // 
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0.00";
            this.dgvprice.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvprice.HeaderText = "Rate";
            this.dgvprice.Name = "dgvprice";
            this.dgvprice.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvprice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvoutsource
            // 
            this.dgvoutsource.HeaderText = "Out-Source(Put Tick Mark)";
            this.dgvoutsource.Name = "dgvoutsource";
            this.dgvoutsource.ToolTipText = "Put Check Mark";
            // 
            // dgvoscompany
            // 
            this.dgvoscompany.HeaderText = " Company Name/Referal ";
            this.dgvoscompany.Name = "dgvoscompany";
            this.dgvoscompany.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvoscompany.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvoscompany.Width = 200;
            // 
            // txtdue
            // 
            this.txtdue.AutoSize = true;
            this.txtdue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdue.Location = new System.Drawing.Point(594, 404);
            this.txtdue.Name = "txtdue";
            this.txtdue.Size = new System.Drawing.Size(0, 18);
            this.txtdue.TabIndex = 1;
            this.txtdue.Validating += new System.ComponentModel.CancelEventHandler(this.Frmbillentry_Validating);
            // 
            // cbopcode
            // 
            this.cbopcode.AutoSize = true;
            this.cbopcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbopcode.Location = new System.Drawing.Point(187, 32);
            this.cbopcode.Name = "cbopcode";
            this.cbopcode.Size = new System.Drawing.Size(57, 20);
            this.cbopcode.TabIndex = 2;
            this.cbopcode.Text = "label1";
            // 
            // cboname1
            // 
            this.cboname1.AutoSize = true;
            this.cboname1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboname1.Location = new System.Drawing.Point(415, 29);
            this.cboname1.Name = "cboname1";
            this.cboname1.Size = new System.Drawing.Size(57, 20);
            this.cboname1.TabIndex = 3;
            this.cboname1.Text = "label2";
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.Cornsilk;
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.Location = new System.Drawing.Point(204, 445);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(92, 41);
            this.btnsave.TabIndex = 5;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btncancel
            // 
            this.btncancel.BackColor = System.Drawing.Color.Cornsilk;
            this.btncancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.Image = ((System.Drawing.Image)(resources.GetObject("btncancel.Image")));
            this.btncancel.Location = new System.Drawing.Point(696, 29);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(76, 30);
            this.btncancel.TabIndex = 5;
            this.btncancel.UseVisualStyleBackColor = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.Cornsilk;
            this.btnprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.Location = new System.Drawing.Point(302, 445);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(91, 41);
            this.btnprint.TabIndex = 6;
            this.btnprint.Text = "Print";
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Regn No./Bill No  :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(274, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Patient\'s Name  :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(508, 405);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "TOTAL  :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(140, 400);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 24);
            this.label4.TabIndex = 10;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtbalance
            // 
            this.txtbalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbalance.Location = new System.Drawing.Point(587, 480);
            this.txtbalance.Name = "txtbalance";
            this.txtbalance.Size = new System.Drawing.Size(100, 24);
            this.txtbalance.TabIndex = 4;
            this.txtbalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbalance_KeyPress);
            this.txtbalance.Validating += new System.ComponentModel.CancelEventHandler(this.txtbalance_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(478, 483);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 18);
            this.label7.TabIndex = 32;
            this.label7.Text = "Amount Due  :";
            // 
            // txtadv
            // 
            this.txtadv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtadv.Location = new System.Drawing.Point(587, 454);
            this.txtadv.Name = "txtadv";
            this.txtadv.Size = new System.Drawing.Size(100, 23);
            this.txtadv.TabIndex = 3;
            this.txtadv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtadv_KeyPress);
            this.txtadv.Validating += new System.ComponentModel.CancelEventHandler(this.txtadv_Validating);
            // 
            // txtdisc
            // 
            this.txtdisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdisc.Location = new System.Drawing.Point(587, 428);
            this.txtdisc.Name = "txtdisc";
            this.txtdisc.Size = new System.Drawing.Size(100, 23);
            this.txtdisc.TabIndex = 2;
            this.txtdisc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtdisc_KeyPress);
            this.txtdisc.Validating += new System.ComponentModel.CancelEventHandler(this.txtdisc_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(443, 456);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 18);
            this.label6.TabIndex = 29;
            this.label6.Text = "Amount Received  :";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(498, 431);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 18);
            this.label5.TabIndex = 28;
            this.label5.Text = "Discount  :";
            // 
            // Frmbillentry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightYellow;
            this.ClientSize = new System.Drawing.Size(858, 578);
            this.Controls.Add(this.txtbalance);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtadv);
            this.Controls.Add(this.txtdisc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.cboname1);
            this.Controls.Add(this.cbopcode);
            this.Controls.Add(this.txtdue);
            this.Controls.Add(this.dgvbillnew);
            this.Name = "Frmbillentry";
            this.Text = "BILLING";
            this.Load += new System.EventHandler(this.Frmbillentry_Load);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.Frmbillentry_Validating);
            ((System.ComponentModel.ISupportInitialize)(this.dgvbillnew)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvbillnew;
        private System.Windows.Forms.Label txtdue;
        private System.Windows.Forms.Label cbopcode;
        private System.Windows.Forms.Label cboname1;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtbalance;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtadv;
        private System.Windows.Forms.TextBox txtdisc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvtest;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvprice;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvoutsource;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvoscompany;
    }
}