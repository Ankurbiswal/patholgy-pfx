namespace Pathology
{
    partial class Frmrepculture
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
            this.crv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.cbopcode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboname = new System.Windows.Forms.ComboBox();
            this.btnback = new System.Windows.Forms.Button();
            this.btngo = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // crv
            // 
            this.crv.ActiveViewIndex = -1;
            this.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv.DisplayGroupTree = false;
            this.crv.Location = new System.Drawing.Point(13, 56);
            this.crv.Name = "crv";
            this.crv.SelectionFormula = "";
            this.crv.Size = new System.Drawing.Size(857, 641);
            this.crv.TabIndex = 54;
            this.crv.ViewTimeSelectionFormula = "";
            // 
            // cbopcode
            // 
            this.cbopcode.FormattingEnabled = true;
            this.cbopcode.Location = new System.Drawing.Point(26, 29);
            this.cbopcode.Name = "cbopcode";
            this.cbopcode.Size = new System.Drawing.Size(92, 21);
            this.cbopcode.TabIndex = 53;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 52;
            this.label5.Text = "Regn. No.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(121, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 51;
            this.label6.Text = "Patient_Name";
            // 
            // cboname
            // 
            this.cboname.FormattingEnabled = true;
            this.cboname.Location = new System.Drawing.Point(124, 29);
            this.cboname.Name = "cboname";
            this.cboname.Size = new System.Drawing.Size(228, 21);
            this.cboname.TabIndex = 50;
            // 
            // btnback
            // 
            this.btnback.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnback.Location = new System.Drawing.Point(560, 25);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(78, 27);
            this.btnback.TabIndex = 56;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // btngo
            // 
            this.btngo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btngo.Location = new System.Drawing.Point(476, 25);
            this.btngo.Name = "btngo";
            this.btngo.Size = new System.Drawing.Size(78, 27);
            this.btngo.TabIndex = 55;
            this.btngo.Text = "Go";
            this.btngo.UseVisualStyleBackColor = true;
            this.btngo.Click += new System.EventHandler(this.btngo_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(376, 31);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(84, 17);
            this.checkBox1.TabIndex = 57;
            this.checkBox1.Text = "Blank Sheet";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Frmrepculture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(804, 578);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.btngo);
            this.Controls.Add(this.crv);
            this.Controls.Add(this.cbopcode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboname);
            this.Name = "Frmrepculture";
            this.Text = "Frmrepculture";
            this.Load += new System.EventHandler(this.Frmrepculture_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv;
        private System.Windows.Forms.ComboBox cbopcode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboname;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Button btngo;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}