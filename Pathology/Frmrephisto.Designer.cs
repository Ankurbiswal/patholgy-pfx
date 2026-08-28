namespace Pathology
{
    partial class Frmrephisto
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
            this.btncytoback = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbocode = new System.Windows.Forms.ComboBox();
            this.btngo = new System.Windows.Forms.Button();
            this.crv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.cboname = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btncytoback
            // 
            this.btncytoback.BackColor = System.Drawing.Color.ForestGreen;
            this.btncytoback.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btncytoback.ForeColor = System.Drawing.Color.ForestGreen;
            this.btncytoback.Location = new System.Drawing.Point(590, 18);
            this.btncytoback.Name = "btncytoback";
            this.btncytoback.Size = new System.Drawing.Size(91, 39);
            this.btncytoback.TabIndex = 35;
            this.btncytoback.Text = "Back";
            this.btncytoback.UseVisualStyleBackColor = false;
            this.btncytoback.Click += new System.EventHandler(this.btncytoback_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Regn. No.";
            // 
            // cbocode
            // 
            this.cbocode.FormattingEnabled = true;
            this.cbocode.Location = new System.Drawing.Point(13, 34);
            this.cbocode.Name = "cbocode";
            this.cbocode.Size = new System.Drawing.Size(113, 21);
            this.cbocode.TabIndex = 33;
            this.cbocode.SelectedIndexChanged += new System.EventHandler(this.cbocode_SelectedIndexChanged);
            // 
            // btngo
            // 
            this.btngo.BackColor = System.Drawing.Color.ForestGreen;
            this.btngo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btngo.ForeColor = System.Drawing.Color.ForestGreen;
            this.btngo.Location = new System.Drawing.Point(479, 16);
            this.btngo.Name = "btngo";
            this.btngo.Size = new System.Drawing.Size(105, 39);
            this.btngo.TabIndex = 32;
            this.btngo.Text = "Go";
            this.btngo.UseVisualStyleBackColor = false;
            this.btngo.Click += new System.EventHandler(this.btngo_Click);
            // 
            // crv
            // 
            this.crv.ActiveViewIndex = -1;
            this.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv.DisplayGroupTree = false;
            this.crv.Location = new System.Drawing.Point(13, 58);
            this.crv.Name = "crv";
            this.crv.SelectionFormula = "";
            this.crv.Size = new System.Drawing.Size(668, 505);
            this.crv.TabIndex = 31;
            this.crv.ViewTimeSelectionFormula = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Patient_Name";
            // 
            // cboname
            // 
            this.cboname.FormattingEnabled = true;
            this.cboname.Location = new System.Drawing.Point(132, 34);
            this.cboname.Name = "cboname";
            this.cboname.Size = new System.Drawing.Size(269, 21);
            this.cboname.TabIndex = 29;
            // 
            // Frmrephisto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 426);
            this.Controls.Add(this.btncytoback);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbocode);
            this.Controls.Add(this.btngo);
            this.Controls.Add(this.crv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboname);
            this.Name = "Frmrephisto";
            this.Text = "Frmrephisto";
            this.Load += new System.EventHandler(this.Frmrephisto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btncytoback;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbocode;
        private System.Windows.Forms.Button btngo;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboname;
    }
}