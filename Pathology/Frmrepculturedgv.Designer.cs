namespace Pathology
{
    partial class Frmrepculturedgv
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnback = new System.Windows.Forms.Button();
            this.btngo = new System.Windows.Forms.Button();
            this.crv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.cbopcode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboname = new System.Windows.Forms.ComboBox();
            this.cbodoctor = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(373, 31);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(77, 17);
            this.checkBox1.TabIndex = 65;
            this.checkBox1.Text = "No Growth";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnback
            // 
            this.btnback.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnback.Location = new System.Drawing.Point(705, 23);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(61, 27);
            this.btnback.TabIndex = 64;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // btngo
            // 
            this.btngo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btngo.Location = new System.Drawing.Point(636, 23);
            this.btngo.Name = "btngo";
            this.btngo.Size = new System.Drawing.Size(63, 27);
            this.btngo.TabIndex = 63;
            this.btngo.Text = "Go";
            this.btngo.UseVisualStyleBackColor = true;
            this.btngo.Click += new System.EventHandler(this.btngo_Click);
            // 
            // crv
            // 
            this.crv.ActiveViewIndex = -1;
            this.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv.DisplayGroupTree = false;
            this.crv.Location = new System.Drawing.Point(10, 56);
            this.crv.Name = "crv";
            this.crv.SelectionFormula = "";
            this.crv.Size = new System.Drawing.Size(857, 641);
            this.crv.TabIndex = 62;
            this.crv.ViewTimeSelectionFormula = "";
            // 
            // cbopcode
            // 
            this.cbopcode.FormattingEnabled = true;
            this.cbopcode.Location = new System.Drawing.Point(23, 29);
            this.cbopcode.Name = "cbopcode";
            this.cbopcode.Size = new System.Drawing.Size(92, 21);
            this.cbopcode.TabIndex = 61;
            this.cbopcode.SelectedIndexChanged += new System.EventHandler(this.cbopcode_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 60;
            this.label5.Text = "Regn. No.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(118, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 59;
            this.label6.Text = "Patient_Name";
            // 
            // cboname
            // 
            this.cboname.FormattingEnabled = true;
            this.cboname.Location = new System.Drawing.Point(121, 29);
            this.cboname.Name = "cboname";
            this.cboname.Size = new System.Drawing.Size(228, 21);
            this.cboname.TabIndex = 58;
            // 
            // cbodoctor
            // 
            this.cbodoctor.Enabled = false;
            this.cbodoctor.FormattingEnabled = true;
            this.cbodoctor.Location = new System.Drawing.Point(470, 27);
            this.cbodoctor.Name = "cbodoctor";
            this.cbodoctor.Size = new System.Drawing.Size(114, 21);
            this.cbodoctor.TabIndex = 66;
            // 
            // Frmrepculturedgv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(804, 578);
            this.Controls.Add(this.cbodoctor);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.btngo);
            this.Controls.Add(this.crv);
            this.Controls.Add(this.cbopcode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboname);
            this.Name = "Frmrepculturedgv";
            this.Text = "Frmrepculturedgv";
            this.Load += new System.EventHandler(this.Frmrepculturedgv_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Button btngo;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv;
        private System.Windows.Forms.ComboBox cbopcode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboname;
        private System.Windows.Forms.ComboBox cbodoctor;
    }
}