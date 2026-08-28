namespace Pathology
{
    partial class Frmprofilemaster
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tmtest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grmethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grtunit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmrr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TMRATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TMGR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TMSGR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TMSGRCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TMSGRSRLNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtmnote1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnback = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cboprofilename
            // 
            this.cboprofilename.FormattingEnabled = true;
            this.cboprofilename.Location = new System.Drawing.Point(113, 34);
            this.cboprofilename.Name = "cboprofilename";
            this.cboprofilename.Size = new System.Drawing.Size(552, 21);
            this.cboprofilename.TabIndex = 16;
            this.cboprofilename.SelectedIndexChanged += new System.EventHandler(this.cboprofilename_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightYellow;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(287, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 24);
            this.label1.TabIndex = 15;
            this.label1.Text = "Profile Master";
            // 
            // btnsave
            // 
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.Location = new System.Drawing.Point(4, 305);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(57, 212);
            this.btnsave.TabIndex = 14;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tmtest,
            this.grmethod,
            this.grtunit,
            this.tmrr,
            this.TMRATE,
            this.TMGR,
            this.TMSGR,
            this.TMSGRCODE,
            this.TMSGRSRLNO});
            this.dataGridView1.Location = new System.Drawing.Point(23, 63);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Size = new System.Drawing.Size(1220, 182);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // tmtest
            // 
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tmtest.DefaultCellStyle = dataGridViewCellStyle2;
            this.tmtest.Frozen = true;
            this.tmtest.HeaderText = "Test";
            this.tmtest.Name = "tmtest";
            this.tmtest.Width = 300;
            // 
            // grmethod
            // 
            this.grmethod.Frozen = true;
            this.grmethod.HeaderText = "Method";
            this.grmethod.Name = "grmethod";
            // 
            // grtunit
            // 
            this.grtunit.Frozen = true;
            this.grtunit.HeaderText = "Unit";
            this.grtunit.Name = "grtunit";
            this.grtunit.Width = 50;
            // 
            // tmrr
            // 
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tmrr.DefaultCellStyle = dataGridViewCellStyle3;
            this.tmrr.Frozen = true;
            this.tmrr.HeaderText = "Reference-Range";
            this.tmrr.Name = "tmrr";
            this.tmrr.Width = 200;
            // 
            // TMRATE
            // 
            this.TMRATE.Frozen = true;
            this.TMRATE.HeaderText = "Rate";
            this.TMRATE.Name = "TMRATE";
            this.TMRATE.Visible = false;
            this.TMRATE.Width = 50;
            // 
            // TMGR
            // 
            this.TMGR.HeaderText = "Group";
            this.TMGR.Name = "TMGR";
            this.TMGR.Width = 200;
            // 
            // TMSGR
            // 
            this.TMSGR.HeaderText = "Sub-Grp";
            this.TMSGR.Name = "TMSGR";
            // 
            // TMSGRCODE
            // 
            this.TMSGRCODE.HeaderText = "GR-CODE";
            this.TMSGRCODE.Name = "TMSGRCODE";
            // 
            // TMSGRSRLNO
            // 
            this.TMSGRSRLNO.HeaderText = "SRL-NO";
            this.TMSGRSRLNO.Name = "TMSGRSRLNO";
            // 
            // txtmnote1
            // 
            this.txtmnote1.Location = new System.Drawing.Point(67, 253);
            this.txtmnote1.Multiline = true;
            this.txtmnote1.Name = "txtmnote1";
            this.txtmnote1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtmnote1.Size = new System.Drawing.Size(1059, 295);
            this.txtmnote1.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightYellow;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-3, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 24);
            this.label2.TabIndex = 18;
            this.label2.Text = "Note";
            // 
            // btnback
            // 
            this.btnback.Image = global::Pathology.Properties.Resources.back_btn;
            this.btnback.Location = new System.Drawing.Point(700, 12);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(75, 34);
            this.btnback.TabIndex = 19;
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // Frmprofilemaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(804, 578);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtmnote1);
            this.Controls.Add(this.cboprofilename);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Frmprofilemaster";
            this.Text = "Frmprofilemaster";
            this.Load += new System.EventHandler(this.Frmprofilemaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboprofilename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtmnote1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmtest;
        private System.Windows.Forms.DataGridViewTextBoxColumn grmethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn grtunit;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmrr;
        private System.Windows.Forms.DataGridViewTextBoxColumn TMRATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TMGR;
        private System.Windows.Forms.DataGridViewTextBoxColumn TMSGR;
        private System.Windows.Forms.DataGridViewTextBoxColumn TMSGRCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TMSGRSRLNO;
    }
}