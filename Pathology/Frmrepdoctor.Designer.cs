namespace Pathology
{
    partial class Frmrepdoctor
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
            this.cbodoctor = new System.Windows.Forms.ComboBox();
            this.btngo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dtto = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtfrom = new System.Windows.Forms.DateTimePicker();
            this.crv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnback = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Doctor Name";
            // 
            // cbodoctor
            // 
            this.cbodoctor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbodoctor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbodoctor.FormattingEnabled = true;
            this.cbodoctor.Location = new System.Drawing.Point(321, 26);
            this.cbodoctor.Name = "cbodoctor";
            this.cbodoctor.Size = new System.Drawing.Size(304, 21);
            this.cbodoctor.TabIndex = 32;
            // 
            // btngo
            // 
            this.btngo.Location = new System.Drawing.Point(643, 26);
            this.btngo.Name = "btngo";
            this.btngo.Size = new System.Drawing.Size(71, 23);
            this.btngo.TabIndex = 31;
            this.btngo.Text = "Go";
            this.btngo.UseVisualStyleBackColor = true;
            this.btngo.Click += new System.EventHandler(this.btngo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(165, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "To";
            // 
            // dtto
            // 
            this.dtto.CustomFormat = "dd/MM/yyyy";
            this.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtto.Location = new System.Drawing.Point(135, 27);
            this.dtto.Name = "dtto";
            this.dtto.ShowUpDown = true;
            this.dtto.Size = new System.Drawing.Size(92, 20);
            this.dtto.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Report Date From";
            // 
            // dtfrom
            // 
            this.dtfrom.CustomFormat = "dd/MM/yyyy";
            this.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtfrom.Location = new System.Drawing.Point(37, 27);
            this.dtfrom.Name = "dtfrom";
            this.dtfrom.ShowUpDown = true;
            this.dtfrom.Size = new System.Drawing.Size(92, 20);
            this.dtfrom.TabIndex = 27;
            // 
            // crv
            // 
            this.crv.ActiveViewIndex = -1;
            this.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv.DisplayGroupTree = false;
            this.crv.Location = new System.Drawing.Point(22, 55);
            this.crv.Name = "crv";
            this.crv.SelectionFormula = "";
            this.crv.Size = new System.Drawing.Size(770, 495);
            this.crv.TabIndex = 26;
            this.crv.ViewTimeSelectionFormula = "";
            // 
            // btnback
            // 
            this.btnback.Image = global::Pathology.Properties.Resources.back_btn;
            this.btnback.Location = new System.Drawing.Point(717, 20);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(75, 32);
            this.btnback.TabIndex = 150;
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // Frmrepdoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(804, 562);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbodoctor);
            this.Controls.Add(this.btngo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtfrom);
            this.Controls.Add(this.crv);
            this.Name = "Frmrepdoctor";
            this.Text = "Frmrepdoctor";
            this.Load += new System.EventHandler(this.Frmrepdoctor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbodoctor;
        private System.Windows.Forms.Button btngo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtfrom;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv;
        private System.Windows.Forms.Button btnback;
    }
}