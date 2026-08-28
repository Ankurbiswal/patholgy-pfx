namespace Pathology
{
    partial class Frmrepissue
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
            this.crv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnview = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboissfrom = new System.Windows.Forms.ComboBox();
            this.cboissto = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtcompid = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Issue No. From";
            // 
            // crv
            // 
            this.crv.ActiveViewIndex = -1;
            this.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv.DisplayGroupTree = false;
            this.crv.Location = new System.Drawing.Point(24, 52);
            this.crv.Name = "crv";
            this.crv.SelectionFormula = "";
            this.crv.Size = new System.Drawing.Size(675, 304);
            this.crv.TabIndex = 3;
            this.crv.ViewTimeSelectionFormula = "";
            // 
            // btnview
            // 
            this.btnview.Location = new System.Drawing.Point(413, 21);
            this.btnview.Name = "btnview";
            this.btnview.Size = new System.Drawing.Size(175, 23);
            this.btnview.TabIndex = 4;
            this.btnview.Text = "View";
            this.btnview.UseVisualStyleBackColor = true;
            this.btnview.Click += new System.EventHandler(this.btnview_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(257, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "To";
            // 
            // cboissfrom
            // 
            this.cboissfrom.FormattingEnabled = true;
            this.cboissfrom.Location = new System.Drawing.Point(155, 23);
            this.cboissfrom.Name = "cboissfrom";
            this.cboissfrom.Size = new System.Drawing.Size(96, 21);
            this.cboissfrom.TabIndex = 6;
            // 
            // cboissto
            // 
            this.cboissto.FormattingEnabled = true;
            this.cboissto.Location = new System.Drawing.Point(283, 20);
            this.cboissto.Name = "cboissto";
            this.cboissto.Size = new System.Drawing.Size(96, 21);
            this.cboissto.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "label3";
            // 
            // txtcompid
            // 
            this.txtcompid.Location = new System.Drawing.Point(6, 32);
            this.txtcompid.Name = "txtcompid";
            this.txtcompid.Size = new System.Drawing.Size(19, 20);
            this.txtcompid.TabIndex = 9;
            // 
            // Frmrepissue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 368);
            this.Controls.Add(this.txtcompid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboissto);
            this.Controls.Add(this.cboissfrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnview);
            this.Controls.Add(this.crv);
            this.Controls.Add(this.label1);
            this.Name = "Frmrepissue";
            this.Text = "Frmrepissue";
            this.Load += new System.EventHandler(this.Frmrepissue_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv;
        private System.Windows.Forms.Button btnview;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboissfrom;
        private System.Windows.Forms.ComboBox cboissto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtcompid;
    }
}