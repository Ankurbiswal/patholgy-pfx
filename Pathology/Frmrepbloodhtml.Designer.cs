namespace Pathology
{
    partial class Frmrepbloodhtml
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
            this.chkmontouxwidal = new System.Windows.Forms.CheckBox();
            this.btngo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtreport = new System.Windows.Forms.DateTimePicker();
            this.cboname = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // chkmontouxwidal
            // 
            this.chkmontouxwidal.AutoSize = true;
            this.chkmontouxwidal.Location = new System.Drawing.Point(420, 20);
            this.chkmontouxwidal.Name = "chkmontouxwidal";
            this.chkmontouxwidal.Size = new System.Drawing.Size(123, 17);
            this.chkmontouxwidal.TabIndex = 18;
            this.chkmontouxwidal.Text = "Montoux/Widal Test";
            this.chkmontouxwidal.UseVisualStyleBackColor = true;
            // 
            // btngo
            // 
            this.btngo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btngo.Location = new System.Drawing.Point(576, 19);
            this.btngo.Name = "btngo";
            this.btngo.Size = new System.Drawing.Size(125, 27);
            this.btngo.TabIndex = 17;
            this.btngo.Text = "Go";
            this.btngo.UseVisualStyleBackColor = true;
            this.btngo.Click += new System.EventHandler(this.btngo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Report Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Patient_Name";
            // 
            // dtreport
            // 
            this.dtreport.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtreport.Location = new System.Drawing.Point(253, 22);
            this.dtreport.Name = "dtreport";
            this.dtreport.ShowUpDown = true;
            this.dtreport.Size = new System.Drawing.Size(92, 20);
            this.dtreport.TabIndex = 14;
            // 
            // cboname
            // 
            this.cboname.FormattingEnabled = true;
            this.cboname.Location = new System.Drawing.Point(33, 21);
            this.cboname.Name = "cboname";
            this.cboname.Size = new System.Drawing.Size(175, 21);
            this.cboname.TabIndex = 13;
            // 
            // Frmrepbloodhtml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 359);
            this.Controls.Add(this.chkmontouxwidal);
            this.Controls.Add(this.btngo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtreport);
            this.Controls.Add(this.cboname);
            this.Name = "Frmrepbloodhtml";
            this.Text = "Frmrepbloodhtml";
            this.Load += new System.EventHandler(this.Frmrepbloodhtml_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkmontouxwidal;
        private System.Windows.Forms.Button btngo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtreport;
        private System.Windows.Forms.ComboBox cboname;
    }
}