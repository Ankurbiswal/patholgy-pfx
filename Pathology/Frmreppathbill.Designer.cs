namespace Pathology
{
    partial class Frmreppathbill
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
            this.cboissto = new System.Windows.Forms.ComboBox();
            this.cboissfrom = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnview = new System.Windows.Forms.Button();
            this.crv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.btnback = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboissto
            // 
            this.cboissto.FormattingEnabled = true;
            this.cboissto.Location = new System.Drawing.Point(350, 10);
            this.cboissto.Name = "cboissto";
            this.cboissto.Size = new System.Drawing.Size(96, 21);
            this.cboissto.TabIndex = 19;
            // 
            // cboissfrom
            // 
            this.cboissfrom.FormattingEnabled = true;
            this.cboissfrom.Location = new System.Drawing.Point(213, 11);
            this.cboissfrom.Name = "cboissfrom";
            this.cboissfrom.Size = new System.Drawing.Size(96, 21);
            this.cboissfrom.TabIndex = 18;
            this.cboissfrom.SelectedIndexChanged += new System.EventHandler(this.cboissfrom_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(320, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "To";
            // 
            // btnview
            // 
            this.btnview.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnview.ForeColor = System.Drawing.Color.Green;
            this.btnview.Location = new System.Drawing.Point(468, 3);
            this.btnview.Name = "btnview";
            this.btnview.Size = new System.Drawing.Size(136, 32);
            this.btnview.TabIndex = 16;
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
            this.crv.Location = new System.Drawing.Point(12, 37);
            this.crv.Name = "crv";
            this.crv.SelectionFormula = "";
            this.crv.Size = new System.Drawing.Size(772, 521);
            this.crv.TabIndex = 15;
            this.crv.ViewTimeSelectionFormula = "";
            this.crv.Load += new System.EventHandler(this.crv_Load);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(125, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Bill No. From";
            // 
            // btnback
            // 
            this.btnback.Image = global::Pathology.Properties.Resources.back_btn;
            this.btnback.Location = new System.Drawing.Point(709, 4);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(75, 32);
            this.btnback.TabIndex = 151;
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // Frmreppathbill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(804, 578);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.cboissto);
            this.Controls.Add(this.cboissfrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnview);
            this.Controls.Add(this.crv);
            this.Controls.Add(this.label1);
            this.Name = "Frmreppathbill";
            this.Text = "Frmreppathbill";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmreppathbill_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboissto;
        private System.Windows.Forms.ComboBox cboissfrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnview;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnback;
    }
}