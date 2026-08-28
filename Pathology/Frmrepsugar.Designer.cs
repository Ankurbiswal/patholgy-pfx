namespace Pathology
{
    partial class Frmrepsugar
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtfrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtto = new System.Windows.Forms.DateTimePicker();
            this.btngo = new System.Windows.Forms.Button();
            this.crv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.cboname = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Report Date From";
            // 
            // dtfrom
            // 
            this.dtfrom.CustomFormat = "dd/MM/yyyy";
            this.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtfrom.Location = new System.Drawing.Point(68, 21);
            this.dtfrom.Name = "dtfrom";
            this.dtfrom.ShowUpDown = true;
            this.dtfrom.Size = new System.Drawing.Size(92, 20);
            this.dtfrom.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(196, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "To";
            // 
            // dtto
            // 
            this.dtto.CustomFormat = "dd/MM/yyyy";
            this.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtto.Location = new System.Drawing.Point(166, 21);
            this.dtto.Name = "dtto";
            this.dtto.ShowUpDown = true;
            this.dtto.Size = new System.Drawing.Size(92, 20);
            this.dtto.TabIndex = 19;
            // 
            // btngo
            // 
            this.btngo.Location = new System.Drawing.Point(299, 21);
            this.btngo.Name = "btngo";
            this.btngo.Size = new System.Drawing.Size(91, 23);
            this.btngo.TabIndex = 20;
            this.btngo.Text = "Go";
            this.btngo.UseVisualStyleBackColor = true;
            this.btngo.Click += new System.EventHandler(this.btngo_Click);
            // 
            // crv
            // 
            this.crv.ActiveViewIndex = -1;
            this.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv.DisplayGroupTree = false;
            this.crv.Location = new System.Drawing.Point(20, 74);
            this.crv.Name = "crv";
            this.crv.SelectionFormula = "";
            this.crv.Size = new System.Drawing.Size(758, 426);
            this.crv.TabIndex = 21;
            this.crv.ViewTimeSelectionFormula = "";
            // 
            // cboname
            // 
            this.cboname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboname.FormattingEnabled = true;
            this.cboname.Location = new System.Drawing.Point(473, 23);
            this.cboname.Name = "cboname";
            this.cboname.Size = new System.Drawing.Size(213, 21);
            this.cboname.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(396, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Patient Name";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboname);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtfrom);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtto);
            this.panel1.Controls.Add(this.btngo);
            this.panel1.Location = new System.Drawing.Point(20, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 56);
            this.panel1.TabIndex = 24;
            // 
            // Frmrepsugar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(804, 512);
            this.Controls.Add(this.crv);
            this.Controls.Add(this.panel1);
            this.Name = "Frmrepsugar";
            this.Text = "Frmrepsugar";
            this.Load += new System.EventHandler(this.Frmrepsugar_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtfrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtto;
        private System.Windows.Forms.Button btngo;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv;
        private System.Windows.Forms.ComboBox cboname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
    }
}