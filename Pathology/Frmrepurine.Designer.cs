namespace Pathology
{
    partial class Frmrepurine
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
            this.cbocode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.crv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btngo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboname = new System.Windows.Forms.ComboBox();
            this.btnurineback = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cbocode
            // 
            this.cbocode.FormattingEnabled = true;
            this.cbocode.Location = new System.Drawing.Point(50, 30);
            this.cbocode.Name = "cbocode";
            this.cbocode.Size = new System.Drawing.Size(84, 21);
            this.cbocode.TabIndex = 0;
            this.cbocode.SelectedIndexChanged += new System.EventHandler(this.cbocode_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Regn. NO.";
            // 
            // crv
            // 
            this.crv.ActiveViewIndex = -1;
            this.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv.DisplayGroupTree = false;
            this.crv.Location = new System.Drawing.Point(24, 57);
            this.crv.Name = "crv";
            this.crv.SelectionFormula = "";
            this.crv.Size = new System.Drawing.Size(836, 677);
            this.crv.TabIndex = 4;
            this.crv.ViewTimeSelectionFormula = "";
            // 
            // btngo
            // 
            this.btngo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btngo.Location = new System.Drawing.Point(516, 24);
            this.btngo.Name = "btngo";
            this.btngo.Size = new System.Drawing.Size(114, 30);
            this.btngo.TabIndex = 5;
            this.btngo.Text = "Go";
            this.btngo.UseVisualStyleBackColor = true;
            this.btngo.Click += new System.EventHandler(this.btngo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Patient_Name";
            // 
            // cboname
            // 
            this.cboname.FormattingEnabled = true;
            this.cboname.Location = new System.Drawing.Point(140, 30);
            this.cboname.Name = "cboname";
            this.cboname.Size = new System.Drawing.Size(254, 21);
            this.cboname.TabIndex = 8;
            this.cboname.SelectedIndexChanged += new System.EventHandler(this.cboname_SelectedIndexChanged);
            // 
            // btnurineback
            // 
            this.btnurineback.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnurineback.Location = new System.Drawing.Point(636, 24);
            this.btnurineback.Name = "btnurineback";
            this.btnurineback.Size = new System.Drawing.Size(114, 30);
            this.btnurineback.TabIndex = 9;
            this.btnurineback.Text = "Back";
            this.btnurineback.UseVisualStyleBackColor = true;
            this.btnurineback.Click += new System.EventHandler(this.btnurineback_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(409, 32);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(101, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "Pregnancy Test";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Frmrepurine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(804, 578);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnurineback);
            this.Controls.Add(this.cboname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btngo);
            this.Controls.Add(this.crv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbocode);
            this.Name = "Frmrepurine";
            this.Text = "Frmrepurine";
            this.Load += new System.EventHandler(this.Frmrepurine_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbocode;
        private System.Windows.Forms.Label label1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv;
        private System.Windows.Forms.Button btngo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboname;
        private System.Windows.Forms.Button btnurineback;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}