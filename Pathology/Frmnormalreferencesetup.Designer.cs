namespace Pathology
{
    partial class Frmnormalreferencesetup
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cboprofilename = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnsave = new System.Windows.Forms.Button();
            this.dgvnormalreference = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnnrcancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnback = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tmrcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmtest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grmethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grtunit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmrr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TMGR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TMSGR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmgcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmgrangef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmranget = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvnormalreference)).BeginInit();
            this.SuspendLayout();
            // 
            // cboprofilename
            // 
            this.cboprofilename.DropDownHeight = 200;
            this.cboprofilename.IntegralHeight = false;
            this.cboprofilename.ItemHeight = 13;
            this.cboprofilename.Location = new System.Drawing.Point(178, 57);
            this.cboprofilename.Name = "cboprofilename";
            this.cboprofilename.Size = new System.Drawing.Size(318, 21);
            this.cboprofilename.TabIndex = 20;
            this.cboprofilename.SelectedIndexChanged += new System.EventHandler(this.cboprofilename_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Linen;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(174, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 24);
            this.label1.TabIndex = 19;
            this.label1.Text = "Reference Range Master";
            // 
            // btnsave
            // 
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.Location = new System.Drawing.Point(229, 560);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(122, 48);
            this.btnsave.TabIndex = 18;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // dgvnormalreference
            // 
            this.dgvnormalreference.BackgroundColor = System.Drawing.Color.Cornsilk;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvnormalreference.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvnormalreference.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvnormalreference.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tmrcode,
            this.tmtest,
            this.grmethod,
            this.grtunit,
            this.tmrr,
            this.TMGR,
            this.TMSGR,
            this.tmgcode,
            this.tmgrangef,
            this.tmranget});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvnormalreference.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvnormalreference.Location = new System.Drawing.Point(12, 97);
            this.dgvnormalreference.Name = "dgvnormalreference";
            this.dgvnormalreference.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvnormalreference.RowTemplate.Height = 30;
            this.dgvnormalreference.Size = new System.Drawing.Size(1153, 447);
            this.dgvnormalreference.TabIndex = 17;
            this.dgvnormalreference.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvnormalreference_UserDeletingRow);
            this.dgvnormalreference.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvnormalreference_RowValidating);
            this.dgvnormalreference.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvnormalreference_CellValidating);
            this.dgvnormalreference.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvnormalreference_CellEndEdit);
            this.dgvnormalreference.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvnormalreference_EditingControlShowing);
            this.dgvnormalreference.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvnormalreference_DataError);
            this.dgvnormalreference.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvnormalreference_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.NavajoWhite;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(498, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "< Select here";
            // 
            // btnnrcancel
            // 
            this.btnnrcancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnrcancel.Location = new System.Drawing.Point(368, 560);
            this.btnnrcancel.Name = "btnnrcancel";
            this.btnnrcancel.Size = new System.Drawing.Size(122, 48);
            this.btnnrcancel.TabIndex = 22;
            this.btnnrcancel.Text = "Cancel";
            this.btnnrcancel.UseVisualStyleBackColor = true;
            this.btnnrcancel.Click += new System.EventHandler(this.btnnrcancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Linen;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 572);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 24);
            this.label3.TabIndex = 23;
            this.label3.Text = "Message";
            // 
            // btnback
            // 
            this.btnback.Image = global::Pathology.Properties.Resources.back_btn;
            this.btnback.Location = new System.Drawing.Point(712, 51);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(75, 32);
            this.btnback.TabIndex = 24;
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.LightYellow;
            this.label4.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(481, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 18);
            this.label4.TabIndex = 155;
            this.label4.Text = "Press ";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.LightYellow;
            this.label6.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label6.Location = new System.Drawing.Point(508, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 21);
            this.label6.TabIndex = 157;
            this.label6.Text = "SHIFT+ENTER";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.LightYellow;
            this.label5.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(481, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(216, 21);
            this.label5.TabIndex = 158;
            this.label5.Text = "Key To Add more Lines in Reference Range Col.";
            this.label5.Click += new System.EventHandler(this.label5_Click_1);
            // 
            // tmrcode
            // 
            this.tmrcode.Frozen = true;
            this.tmrcode.HeaderText = "Ref-Code";
            this.tmrcode.Name = "tmrcode";
            this.tmrcode.ReadOnly = true;
            this.tmrcode.Width = 70;
            // 
            // tmtest
            // 
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tmtest.DefaultCellStyle = dataGridViewCellStyle2;
            this.tmtest.Frozen = true;
            this.tmtest.HeaderText = "Test";
            this.tmtest.Name = "tmtest";
            this.tmtest.ReadOnly = true;
            this.tmtest.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.tmtest.Width = 250;
            // 
            // grmethod
            // 
            this.grmethod.HeaderText = "Method";
            this.grmethod.Name = "grmethod";
            // 
            // grtunit
            // 
            this.grtunit.HeaderText = "Unit";
            this.grtunit.Name = "grtunit";
            this.grtunit.Width = 50;
            // 
            // tmrr
            // 
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tmrr.DefaultCellStyle = dataGridViewCellStyle3;
            this.tmrr.HeaderText = "Reference-Range";
            this.tmrr.Name = "tmrr";
            this.tmrr.Width = 150;
            // 
            // TMGR
            // 
            this.TMGR.HeaderText = "Group";
            this.TMGR.Name = "TMGR";
            // 
            // TMSGR
            // 
            this.TMSGR.HeaderText = "Sub-Grp";
            this.TMSGR.Name = "TMSGR";
            // 
            // tmgcode
            // 
            this.tmgcode.HeaderText = "Gr.Code";
            this.tmgcode.Name = "tmgcode";
            this.tmgcode.Width = 50;
            // 
            // tmgrangef
            // 
            this.tmgrangef.HeaderText = "Range-From";
            this.tmgrangef.Name = "tmgrangef";
            this.tmgrangef.Width = 70;
            // 
            // tmranget
            // 
            this.tmranget.HeaderText = "Range-To";
            this.tmranget.Name = "tmranget";
            this.tmranget.Width = 70;
            // 
            // Frmnormalreferencesetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(804, 578);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnnrcancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboprofilename);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.dgvnormalreference);
            this.Name = "Frmnormalreferencesetup";
            this.Text = "Frmnormalreferencesetup";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmnormalreferencesetup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvnormalreference)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboprofilename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.DataGridView dgvnormalreference;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnnrcancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmrcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmtest;
        private System.Windows.Forms.DataGridViewTextBoxColumn grmethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn grtunit;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmrr;
        private System.Windows.Forms.DataGridViewTextBoxColumn TMGR;
        private System.Windows.Forms.DataGridViewTextBoxColumn TMSGR;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmgcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmgrangef;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmranget;
    }
}