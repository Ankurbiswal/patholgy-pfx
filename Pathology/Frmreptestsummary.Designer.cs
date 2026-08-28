namespace Pathology
{
    partial class Frmreptestsummary
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
            this.cboname = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtfrom = new System.Windows.Forms.DateTimePicker();
            this.crv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnurst = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnblood = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtto = new System.Windows.Forms.DateTimePicker();
            this.btngo = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            // dtfrom
            // 
            this.dtfrom.CustomFormat = "dd/MM/yyyy";
            this.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtfrom.Location = new System.Drawing.Point(189, 33);
            this.dtfrom.Name = "dtfrom";
            this.dtfrom.ShowUpDown = true;
            this.dtfrom.Size = new System.Drawing.Size(92, 20);
            this.dtfrom.TabIndex = 17;
            // 
            // crv
            // 
            this.crv.ActiveViewIndex = -1;
            this.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv.DisplayGroupTree = false;
            this.crv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crv.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.crv.Location = new System.Drawing.Point(16, 111);
            this.crv.Name = "crv";
            this.crv.SelectionFormula = "";
            this.crv.Size = new System.Drawing.Size(914, 435);
            this.crv.TabIndex = 25;
            this.crv.ViewTimeSelectionFormula = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(317, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "To";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.btnurst);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnblood);
            this.panel1.Controls.Add(this.cboname);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtfrom);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtto);
            this.panel1.Controls.Add(this.btngo);
            this.panel1.Location = new System.Drawing.Point(13, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(758, 110);
            this.panel1.TabIndex = 26;
            // 
            // btnurst
            // 
            this.btnurst.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnurst.Location = new System.Drawing.Point(36, 60);
            this.btnurst.Name = "btnurst";
            this.btnurst.Size = new System.Drawing.Size(222, 47);
            this.btnurst.TabIndex = 26;
            this.btnurst.Text = "Urine and Stool count";
            this.btnurst.UseVisualStyleBackColor = true;
            this.btnurst.Click += new System.EventHandler(this.btnurst_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "label4";
            // 
            // btnblood
            // 
            this.btnblood.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnblood.Location = new System.Drawing.Point(257, 61);
            this.btnblood.Name = "btnblood";
            this.btnblood.Size = new System.Drawing.Size(226, 47);
            this.btnblood.TabIndex = 24;
            this.btnblood.Text = "Haematology Tests count";
            this.btnblood.UseVisualStyleBackColor = true;
            this.btnblood.Click += new System.EventHandler(this.btnblood_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(190, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Report Date From";
            // 
            // dtto
            // 
            this.dtto.CustomFormat = "dd/MM/yyyy";
            this.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtto.Location = new System.Drawing.Point(287, 33);
            this.dtto.Name = "dtto";
            this.dtto.ShowUpDown = true;
            this.dtto.Size = new System.Drawing.Size(92, 20);
            this.dtto.TabIndex = 19;
            // 
            // btngo
            // 
            this.btngo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngo.Location = new System.Drawing.Point(489, 61);
            this.btngo.Name = "btngo";
            this.btngo.Size = new System.Drawing.Size(197, 47);
            this.btngo.TabIndex = 20;
            this.btngo.Text = "Bio-Chem tests  count";
            this.btngo.UseVisualStyleBackColor = true;
            this.btngo.Click += new System.EventHandler(this.btngo_Click);
            // 
            // Frmreptestsummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 578);
            this.Controls.Add(this.crv);
            this.Controls.Add(this.panel1);
            this.Name = "Frmreptestsummary";
            this.Text = "Frmreptestsummary";
            this.Load += new System.EventHandler(this.Frmreptestsummary_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtfrom;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtto;
        private System.Windows.Forms.Button btngo;
        private System.Windows.Forms.Button btnblood;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnurst;
    }
}