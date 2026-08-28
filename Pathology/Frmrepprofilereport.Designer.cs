namespace Pathology
{
    partial class Frmrepprofilereport
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
            this.btnshowprofile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboprofile = new System.Windows.Forms.ComboBox();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label2 = new System.Windows.Forms.Label();
            this.cbocode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboname = new System.Windows.Forms.ComboBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.btnnote = new System.Windows.Forms.Button();
            this.btngraph = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnshowprofile
            // 
            this.btnshowprofile.Location = new System.Drawing.Point(369, 51);
            this.btnshowprofile.Name = "btnshowprofile";
            this.btnshowprofile.Size = new System.Drawing.Size(119, 30);
            this.btnshowprofile.TabIndex = 0;
            this.btnshowprofile.Text = "Show Profile";
            this.btnshowprofile.UseVisualStyleBackColor = true;
            this.btnshowprofile.Click += new System.EventHandler(this.btnshowprofile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(366, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Profile";
            // 
            // cboprofile
            // 
            this.cboprofile.FormattingEnabled = true;
            this.cboprofile.Location = new System.Drawing.Point(369, 24);
            this.cboprofile.Name = "cboprofile";
            this.cboprofile.Size = new System.Drawing.Size(367, 21);
            this.cboprofile.TabIndex = 2;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.DisplayGroupTree = false;
            this.crystalReportViewer1.Location = new System.Drawing.Point(12, 87);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1090, 638);
            this.crystalReportViewer1.TabIndex = 3;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Regn. No.";
            // 
            // cbocode
            // 
            this.cbocode.FormattingEnabled = true;
            this.cbocode.Location = new System.Drawing.Point(27, 24);
            this.cbocode.Name = "cbocode";
            this.cbocode.Size = new System.Drawing.Size(91, 21);
            this.cbocode.TabIndex = 16;
            this.cbocode.SelectedIndexChanged += new System.EventHandler(this.cbocode_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(126, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Patient_Name";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // cboname
            // 
            this.cboname.FormattingEnabled = true;
            this.cboname.Location = new System.Drawing.Point(124, 24);
            this.cboname.Name = "cboname";
            this.cboname.Size = new System.Drawing.Size(239, 21);
            this.cboname.TabIndex = 14;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(168, 51);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(153, 17);
            this.radioButton1.TabIndex = 19;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Without Normal-Range";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(27, 51);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(135, 17);
            this.radioButton2.TabIndex = 20;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "With Normal-Range";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // btnnote
            // 
            this.btnnote.Location = new System.Drawing.Point(506, 51);
            this.btnnote.Name = "btnnote";
            this.btnnote.Size = new System.Drawing.Size(119, 30);
            this.btnnote.TabIndex = 21;
            this.btnnote.Text = "Print Note ";
            this.btnnote.UseVisualStyleBackColor = true;
            this.btnnote.Visible = false;
            this.btnnote.Click += new System.EventHandler(this.btnnote_Click);
            // 
            // btngraph
            // 
            this.btngraph.Location = new System.Drawing.Point(650, 51);
            this.btngraph.Name = "btngraph";
            this.btngraph.Size = new System.Drawing.Size(119, 30);
            this.btngraph.TabIndex = 22;
            this.btngraph.Text = "Graph";
            this.btngraph.UseVisualStyleBackColor = true;
            this.btngraph.Click += new System.EventHandler(this.btngraph_Click);
            // 
            // Frmrepprofilereport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(1124, 746);
            this.Controls.Add(this.btngraph);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.btnnote);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbocode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboname);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.cboprofile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnshowprofile);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Frmrepprofilereport";
            this.Text = "PROFILE REPORT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmrepprofilereport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnshowprofile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboprofile;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbocode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboname;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button btnnote;
        private System.Windows.Forms.Button btngraph;
    }
}