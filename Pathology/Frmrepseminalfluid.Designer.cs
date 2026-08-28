namespace Pathology
{
    partial class Frmrepseminalfluid
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
            this.cboname = new System.Windows.Forms.ComboBox();
            this.btngo = new System.Windows.Forms.Button();
            this.crv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.cbopcode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnsemiback = new System.Windows.Forms.Button();
            this.btnrepsfh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(151, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Patient_Name";
            // 
            // cboname
            // 
            this.cboname.FormattingEnabled = true;
            this.cboname.Location = new System.Drawing.Point(154, 26);
            this.cboname.Name = "cboname";
            this.cboname.Size = new System.Drawing.Size(279, 21);
            this.cboname.TabIndex = 12;
            this.cboname.SelectedIndexChanged += new System.EventHandler(this.cboname_SelectedIndexChanged);
            // 
            // btngo
            // 
            this.btngo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btngo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngo.Location = new System.Drawing.Point(450, 18);
            this.btngo.Name = "btngo";
            this.btngo.Size = new System.Drawing.Size(96, 35);
            this.btngo.TabIndex = 16;
            this.btngo.Text = "View";
            this.btngo.UseVisualStyleBackColor = true;
            this.btngo.Click += new System.EventHandler(this.btngo_Click);
            // 
            // crv
            // 
            this.crv.ActiveViewIndex = -1;
            this.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv.DisplayGroupTree = false;
            this.crv.Location = new System.Drawing.Point(12, 53);
            this.crv.Name = "crv";
            this.crv.SelectionFormula = "";
            this.crv.Size = new System.Drawing.Size(773, 456);
            this.crv.TabIndex = 17;
            this.crv.ViewTimeSelectionFormula = "";
            // 
            // cbopcode
            // 
            this.cbopcode.FormattingEnabled = true;
            this.cbopcode.Location = new System.Drawing.Point(37, 27);
            this.cbopcode.Name = "cbopcode";
            this.cbopcode.Size = new System.Drawing.Size(101, 21);
            this.cbopcode.TabIndex = 25;
            this.cbopcode.SelectedIndexChanged += new System.EventHandler(this.cbopcode_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Regn. No.";
            // 
            // btnsemiback
            // 
            this.btnsemiback.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnsemiback.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsemiback.Location = new System.Drawing.Point(679, 18);
            this.btnsemiback.Name = "btnsemiback";
            this.btnsemiback.Size = new System.Drawing.Size(96, 35);
            this.btnsemiback.TabIndex = 26;
            this.btnsemiback.Text = "Back";
            this.btnsemiback.UseVisualStyleBackColor = true;
            this.btnsemiback.Click += new System.EventHandler(this.btnsemiback_Click);
            // 
            // btnrepsfh
            // 
            this.btnrepsfh.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnrepsfh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrepsfh.Location = new System.Drawing.Point(552, 18);
            this.btnrepsfh.Name = "btnrepsfh";
            this.btnrepsfh.Size = new System.Drawing.Size(96, 35);
            this.btnrepsfh.TabIndex = 27;
            this.btnrepsfh.Text = "Print-H";
            this.btnrepsfh.UseVisualStyleBackColor = true;
            this.btnrepsfh.Click += new System.EventHandler(this.btnrepsfh_Click);
            // 
            // Frmrepseminalfluid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(804, 521);
            this.Controls.Add(this.btnrepsfh);
            this.Controls.Add(this.btnsemiback);
            this.Controls.Add(this.cbopcode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.crv);
            this.Controls.Add(this.btngo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboname);
            this.Name = "Frmrepseminalfluid";
            this.Text = "Seminal fluid";
            this.Load += new System.EventHandler(this.Frmrepseminalfluid_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btngo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboname;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv;
        private System.Windows.Forms.ComboBox cbopcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnsemiback;
        private System.Windows.Forms.Button btnrepsfh;
    }
}