namespace Pathology
{
    partial class Frmadminmaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmadminmaster));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtcompanycode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnback = new System.Windows.Forms.Button();
            this.gcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PASS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gdept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gdsn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gdtj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ghra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // txtcompanycode
            // 
            this.txtcompanycode.Location = new System.Drawing.Point(-1, 12);
            this.txtcompanycode.Name = "txtcompanycode";
            this.txtcompanycode.Size = new System.Drawing.Size(10, 20);
            this.txtcompanycode.TabIndex = 14;
            this.txtcompanycode.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Company Name";
            // 
            // btncancel
            // 
            this.btncancel.Image = ((System.Drawing.Image)(resources.GetObject("btncancel.Image")));
            this.btncancel.Location = new System.Drawing.Point(340, 278);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(110, 40);
            this.btncancel.TabIndex = 12;
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnsave
            // 
            this.btnsave.Image = ((System.Drawing.Image)(resources.GetObject("btnsave.Image")));
            this.btnsave.Location = new System.Drawing.Point(227, 278);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(107, 40);
            this.btnsave.TabIndex = 11;
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // dgv
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)
                            | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gcode,
            this.gname,
            this.PASS,
            this.gdept,
            this.gdsn,
            this.gdtj,
            this.gbas,
            this.ghra});
            this.dgv.Location = new System.Drawing.Point(21, 59);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(720, 202);
            this.dgv.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.label2.Font = new System.Drawing.Font("Calibri", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(249, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 33);
            this.label2.TabIndex = 15;
            this.label2.Text = "User Master";
            // 
            // btnback
            // 
            this.btnback.Image = global::Pathology.Properties.Resources.back_btn;
            this.btnback.Location = new System.Drawing.Point(581, 19);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(75, 23);
            this.btnback.TabIndex = 16;
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // gcode
            // 
            this.gcode.Frozen = true;
            this.gcode.HeaderText = "User-Id";
            this.gcode.Name = "gcode";
            // 
            // gname
            // 
            this.gname.Frozen = true;
            this.gname.HeaderText = "User Name";
            this.gname.Name = "gname";
            // 
            // PASS
            // 
            this.PASS.Frozen = true;
            this.PASS.HeaderText = "Password";
            this.PASS.Name = "PASS";
            // 
            // gdept
            // 
            this.gdept.Frozen = true;
            this.gdept.HeaderText = "Type of  User";
            this.gdept.Name = "gdept";
            // 
            // gdsn
            // 
            this.gdsn.HeaderText = "Designation";
            this.gdsn.Name = "gdsn";
            this.gdsn.Width = 80;
            // 
            // gdtj
            // 
            this.gdtj.HeaderText = "Dt of Join";
            this.gdtj.Name = "gdtj";
            this.gdtj.Width = 60;
            // 
            // gbas
            // 
            this.gbas.HeaderText = "Basic";
            this.gbas.Name = "gbas";
            this.gbas.Width = 50;
            // 
            // ghra
            // 
            this.ghra.HeaderText = "Hra";
            this.ghra.Name = "ghra";
            this.ghra.Width = 50;
            // 
            // Frmadminmaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(753, 416);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.txtcompanycode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.label2);
            this.Name = "Frmadminmaster";
            this.Text = "Frmadminmaster";
            this.Load += new System.EventHandler(this.Frmadminmaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtcompanycode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.DataGridViewTextBoxColumn gcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn gname;
        private System.Windows.Forms.DataGridViewTextBoxColumn PASS;
        private System.Windows.Forms.DataGridViewTextBoxColumn gdept;
        private System.Windows.Forms.DataGridViewTextBoxColumn gdsn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gdtj;
        private System.Windows.Forms.DataGridViewTextBoxColumn gbas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ghra;
    }
}