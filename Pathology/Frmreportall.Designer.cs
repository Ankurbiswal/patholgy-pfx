namespace Pathology
{
    partial class Frmreportall
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmreportall));
            this.btnback = new System.Windows.Forms.Button();
            this.cbopcode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btngo = new System.Windows.Forms.Button();
            this.crv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.cboname = new System.Windows.Forms.ComboBox();
            this.btnwidal = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtdate = new System.Windows.Forms.Label();
            this.txtpname = new System.Windows.Forms.Label();
            this.btnwidalheader = new System.Windows.Forms.Button();
            this.btnwithhead = new System.Windows.Forms.Button();
            this.btn_US = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnback
            // 
            this.btnback.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnback.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnback.Image = ((System.Drawing.Image)(resources.GetObject("btnback.Image")));
            this.btnback.Location = new System.Drawing.Point(949, 32);
            this.btnback.Margin = new System.Windows.Forms.Padding(4);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(63, 24);
            this.btnback.TabIndex = 35;
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // cbopcode
            // 
            this.cbopcode.FormattingEnabled = true;
            this.cbopcode.Location = new System.Drawing.Point(18, 32);
            this.cbopcode.Margin = new System.Windows.Forms.Padding(4);
            this.cbopcode.Name = "cbopcode";
            this.cbopcode.Size = new System.Drawing.Size(118, 27);
            this.cbopcode.TabIndex = 32;
            this.cbopcode.SelectedIndexChanged += new System.EventHandler(this.cbopcode_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 19);
            this.label2.TabIndex = 31;
            this.label2.Text = "Registration Number";
            // 
            // btngo
            // 
            this.btngo.BackColor = System.Drawing.Color.Goldenrod;
            this.btngo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btngo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngo.ForeColor = System.Drawing.Color.Orange;
            this.btngo.Location = new System.Drawing.Point(402, 4);
            this.btngo.Margin = new System.Windows.Forms.Padding(4);
            this.btngo.Name = "btngo";
            this.btngo.Size = new System.Drawing.Size(116, 70);
            this.btngo.TabIndex = 30;
            this.btngo.Text = "Haematology      Serology    Bio-chem Hormone";
            this.btngo.UseVisualStyleBackColor = false;
            this.btngo.Click += new System.EventHandler(this.btngo_Click);
            // 
            // crv
            // 
            this.crv.ActiveViewIndex = -1;
            this.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv.DisplayGroupTree = false;
            this.crv.Location = new System.Drawing.Point(13, 82);
            this.crv.Margin = new System.Windows.Forms.Padding(4);
            this.crv.Name = "crv";
            this.crv.SelectionFormula = "";
            this.crv.Size = new System.Drawing.Size(1016, 622);
            this.crv.TabIndex = 29;
            this.crv.ViewTimeSelectionFormula = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(223, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 19);
            this.label1.TabIndex = 28;
            this.label1.Text = "Patient Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cboname
            // 
            this.cboname.FormattingEnabled = true;
            this.cboname.Location = new System.Drawing.Point(144, 32);
            this.cboname.Margin = new System.Windows.Forms.Padding(4);
            this.cboname.Name = "cboname";
            this.cboname.Size = new System.Drawing.Size(251, 27);
            this.cboname.TabIndex = 27;
            this.cboname.SelectedIndexChanged += new System.EventHandler(this.cboname_SelectedIndexChanged);
            // 
            // btnwidal
            // 
            this.btnwidal.BackColor = System.Drawing.Color.Goldenrod;
            this.btnwidal.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnwidal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnwidal.ForeColor = System.Drawing.Color.Orange;
            this.btnwidal.Location = new System.Drawing.Point(630, 19);
            this.btnwidal.Margin = new System.Windows.Forms.Padding(4);
            this.btnwidal.Name = "btnwidal";
            this.btnwidal.Size = new System.Drawing.Size(122, 51);
            this.btnwidal.TabIndex = 37;
            this.btnwidal.Text = "Report Combine Widal";
            this.btnwidal.UseVisualStyleBackColor = false;
            this.btnwidal.Click += new System.EventHandler(this.btnwidal_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Moccasin;
            this.panel1.Controls.Add(this.txtdate);
            this.panel1.Controls.Add(this.txtpname);
            this.panel1.Controls.Add(this.btnwidalheader);
            this.panel1.Controls.Add(this.btnwithhead);
            this.panel1.Controls.Add(this.btn_US);
            this.panel1.Controls.Add(this.btngo);
            this.panel1.Controls.Add(this.cbopcode);
            this.panel1.Controls.Add(this.cboname);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnwidal);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnback);
            this.panel1.Location = new System.Drawing.Point(6, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 81);
            this.panel1.TabIndex = 38;
            // 
            // txtdate
            // 
            this.txtdate.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdate.Location = new System.Drawing.Point(263, 57);
            this.txtdate.Name = "txtdate";
            this.txtdate.Size = new System.Drawing.Size(132, 24);
            this.txtdate.TabIndex = 42;
            this.txtdate.Text = "label3";
            // 
            // txtpname
            // 
            this.txtpname.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpname.Location = new System.Drawing.Point(372, 4);
            this.txtpname.Name = "txtpname";
            this.txtpname.Size = new System.Drawing.Size(23, 24);
            this.txtpname.TabIndex = 41;
            this.txtpname.Text = "label3";
            this.txtpname.Visible = false;
            // 
            // btnwidalheader
            // 
            this.btnwidalheader.BackColor = System.Drawing.Color.Goldenrod;
            this.btnwidalheader.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnwidalheader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnwidalheader.ForeColor = System.Drawing.Color.Orange;
            this.btnwidalheader.Location = new System.Drawing.Point(835, 18);
            this.btnwidalheader.Margin = new System.Windows.Forms.Padding(4);
            this.btnwidalheader.Name = "btnwidalheader";
            this.btnwidalheader.Size = new System.Drawing.Size(83, 51);
            this.btnwidalheader.TabIndex = 40;
            this.btnwidalheader.Text = "Report widal Header";
            this.btnwidalheader.UseVisualStyleBackColor = false;
            this.btnwidalheader.Click += new System.EventHandler(this.btnwidalheader_Click);
            // 
            // btnwithhead
            // 
            this.btnwithhead.BackColor = System.Drawing.Color.Goldenrod;
            this.btnwithhead.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnwithhead.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnwithhead.ForeColor = System.Drawing.Color.Orange;
            this.btnwithhead.Location = new System.Drawing.Point(752, 19);
            this.btnwithhead.Margin = new System.Windows.Forms.Padding(4);
            this.btnwithhead.Name = "btnwithhead";
            this.btnwithhead.Size = new System.Drawing.Size(83, 51);
            this.btnwithhead.TabIndex = 39;
            this.btnwithhead.Text = "Report with Header";
            this.btnwithhead.UseVisualStyleBackColor = false;
            this.btnwithhead.Click += new System.EventHandler(this.btnwithhead_Click);
            // 
            // btn_US
            // 
            this.btn_US.AutoEllipsis = true;
            this.btn_US.BackColor = System.Drawing.Color.Goldenrod;
            this.btn_US.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_US.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_US.ForeColor = System.Drawing.Color.Chocolate;
            this.btn_US.Location = new System.Drawing.Point(517, 19);
            this.btn_US.Margin = new System.Windows.Forms.Padding(4);
            this.btn_US.Name = "btn_US";
            this.btn_US.Size = new System.Drawing.Size(114, 51);
            this.btn_US.TabIndex = 38;
            this.btn_US.Text = "Report Combine Urine+Stool";
            this.btn_US.UseVisualStyleBackColor = false;
            this.btn_US.Click += new System.EventHandler(this.btn_US_Click);
            // 
            // Frmreportall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(958, 578);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.crv);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frmreportall";
            this.Text = "Frmreportall";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmreportall_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.ComboBox cbopcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btngo;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboname;
        private System.Windows.Forms.Button btnwidal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_US;
        private System.Windows.Forms.Button btnwithhead;
        private System.Windows.Forms.Button btnwidalheader;
        private System.Windows.Forms.Label txtpname;
        private System.Windows.Forms.Label txtdate;

    }
}