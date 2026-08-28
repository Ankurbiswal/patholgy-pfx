namespace Pathology
{
    partial class Frmopdregister
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbodoctor = new System.Windows.Forms.ComboBox();
            this.cboreferal = new System.Windows.Forms.ComboBox();
            this.dtt = new System.Windows.Forms.DateTimePicker();
            this.dtf = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnview = new System.Windows.Forms.Button();
            this.crv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(606, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 39;
            this.label4.Text = "DOCTOR";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(443, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 38;
            this.label3.Text = "DEPT. NAME";
            // 
            // cbodoctor
            // 
            this.cbodoctor.FormattingEnabled = true;
            this.cbodoctor.Location = new System.Drawing.Point(579, 28);
            this.cbodoctor.Name = "cbodoctor";
            this.cbodoctor.Size = new System.Drawing.Size(153, 21);
            this.cbodoctor.TabIndex = 37;
            // 
            // cboreferal
            // 
            this.cboreferal.FormattingEnabled = true;
            this.cboreferal.Location = new System.Drawing.Point(401, 28);
            this.cboreferal.Name = "cboreferal";
            this.cboreferal.Size = new System.Drawing.Size(172, 21);
            this.cboreferal.TabIndex = 36;
            // 
            // dtt
            // 
            this.dtt.Checked = false;
            this.dtt.CustomFormat = "dd/MM/yyyy";
            this.dtt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtt.Location = new System.Drawing.Point(311, 29);
            this.dtt.Name = "dtt";
            this.dtt.Size = new System.Drawing.Size(85, 20);
            this.dtt.TabIndex = 35;
            // 
            // dtf
            // 
            this.dtf.Checked = false;
            this.dtf.CustomFormat = "dd/MM/yyyy";
            this.dtf.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtf.Location = new System.Drawing.Point(187, 29);
            this.dtf.Name = "dtf";
            this.dtf.Size = new System.Drawing.Size(86, 20);
            this.dtf.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(284, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 17);
            this.label2.TabIndex = 33;
            this.label2.Text = "To";
            // 
            // btnview
            // 
            this.btnview.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnview.ForeColor = System.Drawing.Color.Green;
            this.btnview.Location = new System.Drawing.Point(564, 55);
            this.btnview.Name = "btnview";
            this.btnview.Size = new System.Drawing.Size(168, 32);
            this.btnview.TabIndex = 32;
            this.btnview.Text = "View";
            this.btnview.UseVisualStyleBackColor = true;
            this.btnview.Click += new System.EventHandler(this.btnview_Click);
            // 
            // crv
            // 
            this.crv.ActiveViewIndex = -1;
            this.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv.DisplayGroupTree = false;
            this.crv.Font = new System.Drawing.Font("Symbol", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crv.Location = new System.Drawing.Point(9, 94);
            this.crv.Name = "crv";
            this.crv.SelectionFormula = "";
            this.crv.Size = new System.Drawing.Size(1077, 473);
            this.crv.TabIndex = 31;
            this.crv.ViewTimeSelectionFormula = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(109, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 30;
            this.label1.Text = "Date  From";
            // 
            // Frmopdregister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(804, 578);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbodoctor);
            this.Controls.Add(this.cboreferal);
            this.Controls.Add(this.dtt);
            this.Controls.Add(this.dtf);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnview);
            this.Controls.Add(this.crv);
            this.Controls.Add(this.label1);
            this.Name = "Frmopdregister";
            this.Text = "Frmopdregister";
            this.Load += new System.EventHandler(this.Frmopdregister_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbodoctor;
        private System.Windows.Forms.ComboBox cboreferal;
        private System.Windows.Forms.DateTimePicker dtt;
        private System.Windows.Forms.DateTimePicker dtf;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnview;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv;
        private System.Windows.Forms.Label label1;
    }
}