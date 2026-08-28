namespace Pathology
{
    partial class Frmreppaid
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
            this.label2 = new System.Windows.Forms.Label();
            this.dtreport = new System.Windows.Forms.DateTimePicker();
            this.dtfrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtto = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btngo = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cboname = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // crv
            // 
            this.crv.ActiveViewIndex = -1;
            this.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv.DisplayGroupTree = false;
            this.crv.Location = new System.Drawing.Point(25, 59);
            this.crv.Name = "crv";
            this.crv.SelectionFormula = "";
            this.crv.Size = new System.Drawing.Size(756, 454);
            this.crv.TabIndex = 13;
            this.crv.ViewTimeSelectionFormula = "";
            this.crv.Load += new System.EventHandler(this.crv_Load);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, -82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Report Date";
            // 
            // dtreport
            // 
            this.dtreport.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtreport.Location = new System.Drawing.Point(133, -66);
            this.dtreport.Name = "dtreport";
            this.dtreport.ShowUpDown = true;
            this.dtreport.Size = new System.Drawing.Size(92, 20);
            this.dtreport.TabIndex = 11;
            // 
            // dtfrom
            // 
            this.dtfrom.CustomFormat = "dd/MM/yyyy";
            this.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtfrom.Location = new System.Drawing.Point(71, 33);
            this.dtfrom.Name = "dtfrom";
            this.dtfrom.ShowUpDown = true;
            this.dtfrom.Size = new System.Drawing.Size(92, 20);
            this.dtfrom.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Report Date From";
            // 
            // dtto
            // 
            this.dtto.CustomFormat = "dd/MM/yyyy";
            this.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtto.Location = new System.Drawing.Point(169, 33);
            this.dtto.Name = "dtto";
            this.dtto.ShowUpDown = true;
            this.dtto.Size = new System.Drawing.Size(92, 20);
            this.dtto.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(199, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "To";
            // 
            // btngo
            // 
            this.btngo.Location = new System.Drawing.Point(267, 32);
            this.btngo.Name = "btngo";
            this.btngo.Size = new System.Drawing.Size(113, 23);
            this.btngo.TabIndex = 18;
            this.btngo.Text = "Go";
            this.btngo.UseVisualStyleBackColor = true;
            this.btngo.Click += new System.EventHandler(this.btngo_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(386, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Patient Name";
            // 
            // cboname
            // 
            this.cboname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboname.FormattingEnabled = true;
            this.cboname.Location = new System.Drawing.Point(463, 32);
            this.cboname.Name = "cboname";
            this.cboname.Size = new System.Drawing.Size(192, 21);
            this.cboname.TabIndex = 24;
            // 
            // Frmreppaid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(804, 525);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboname);
            this.Controls.Add(this.btngo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtfrom);
            this.Controls.Add(this.crv);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtreport);
            this.Name = "Frmreppaid";
            this.Text = "Frmreppaid";
            this.Load += new System.EventHandler(this.Frmreppaid_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtreport;
        private System.Windows.Forms.DateTimePicker dtfrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btngo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboname;
    }
}