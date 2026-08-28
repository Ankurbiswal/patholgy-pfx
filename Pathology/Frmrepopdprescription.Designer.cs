namespace Pathology
{
    partial class Frmrepopdprescription
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmrepopdprescription));
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboissueto = new System.Windows.Forms.ComboBox();
            this.cboissuefrom = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnviewopd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cboissto = new System.Windows.Forms.ComboBox();
            this.cboissfrom = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnview = new System.Windows.Forms.Button();
            this.crv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.btncancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(302, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 17);
            this.label6.TabIndex = 96;
            this.label6.Text = ":";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(138, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 17);
            this.label5.TabIndex = 95;
            this.label5.Text = ":";
            // 
            // cboissueto
            // 
            this.cboissueto.FormattingEnabled = true;
            this.cboissueto.Location = new System.Drawing.Point(320, 21);
            this.cboissueto.Name = "cboissueto";
            this.cboissueto.Size = new System.Drawing.Size(132, 21);
            this.cboissueto.TabIndex = 93;
            // 
            // cboissuefrom
            // 
            this.cboissuefrom.BackColor = System.Drawing.SystemColors.Window;
            this.cboissuefrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboissuefrom.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboissuefrom.FormattingEnabled = true;
            this.cboissuefrom.Location = new System.Drawing.Point(156, 22);
            this.cboissuefrom.Name = "cboissuefrom";
            this.cboissuefrom.Size = new System.Drawing.Size(120, 24);
            this.cboissuefrom.TabIndex = 92;
            this.cboissuefrom.Validating += new System.ComponentModel.CancelEventHandler(this.cboissuefrom_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(282, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 17);
            this.label3.TabIndex = 91;
            this.label3.Text = "To";
            // 
            // btnviewopd
            // 
            this.btnviewopd.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnviewopd.ForeColor = System.Drawing.Color.Green;
            this.btnviewopd.Location = new System.Drawing.Point(472, 13);
            this.btnviewopd.Name = "btnviewopd";
            this.btnviewopd.Size = new System.Drawing.Size(118, 32);
            this.btnviewopd.TabIndex = 90;
            this.btnviewopd.Text = "View";
            this.btnviewopd.UseVisualStyleBackColor = true;
            this.btnviewopd.Click += new System.EventHandler(this.btnviewopd_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(33, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 17);
            this.label4.TabIndex = 89;
            this.label4.Text = "Regd. No. From";
            // 
            // cboissto
            // 
            this.cboissto.FormattingEnabled = true;
            this.cboissto.Location = new System.Drawing.Point(771, 12);
            this.cboissto.Name = "cboissto";
            this.cboissto.Size = new System.Drawing.Size(21, 21);
            this.cboissto.TabIndex = 88;
            this.cboissto.Visible = false;
            // 
            // cboissfrom
            // 
            this.cboissfrom.FormattingEnabled = true;
            this.cboissfrom.Location = new System.Drawing.Point(732, 13);
            this.cboissfrom.Name = "cboissfrom";
            this.cboissfrom.Size = new System.Drawing.Size(33, 21);
            this.cboissfrom.TabIndex = 87;
            this.cboissfrom.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(754, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 17);
            this.label2.TabIndex = 86;
            this.label2.Text = "To";
            // 
            // btnview
            // 
            this.btnview.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnview.ForeColor = System.Drawing.Color.Green;
            this.btnview.Location = new System.Drawing.Point(783, 9);
            this.btnview.Name = "btnview";
            this.btnview.Size = new System.Drawing.Size(25, 32);
            this.btnview.TabIndex = 85;
            this.btnview.Text = "View";
            this.btnview.UseVisualStyleBackColor = true;
            this.btnview.Visible = false;
            // 
            // crv
            // 
            this.crv.ActiveViewIndex = -1;
            this.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv.DisplayGroupTree = false;
            this.crv.Font = new System.Drawing.Font("Symbol", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crv.Location = new System.Drawing.Point(12, 65);
            this.crv.Name = "crv";
            this.crv.SelectionFormula = "";
            this.crv.Size = new System.Drawing.Size(781, 436);
            this.crv.TabIndex = 84;
            this.crv.ViewTimeSelectionFormula = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(726, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 83;
            this.label1.Text = "Bill No. From";
            this.label1.Visible = false;
            // 
            // btncancel
            // 
            this.btncancel.BackColor = System.Drawing.Color.Cornsilk;
            this.btncancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.Image = ((System.Drawing.Image)(resources.GetObject("btncancel.Image")));
            this.btncancel.Location = new System.Drawing.Point(596, 12);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(76, 36);
            this.btncancel.TabIndex = 94;
            this.btncancel.UseVisualStyleBackColor = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // Frmrepopdprescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(804, 513);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.cboissueto);
            this.Controls.Add(this.cboissuefrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnviewopd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboissto);
            this.Controls.Add(this.cboissfrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnview);
            this.Controls.Add(this.crv);
            this.Controls.Add(this.label1);
            this.Name = "Frmrepopdprescription";
            this.Text = "Frmrepopdprescription";
            this.Load += new System.EventHandler(this.Frmrepopdprescription_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.ComboBox cboissueto;
        private System.Windows.Forms.ComboBox cboissuefrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnviewopd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboissto;
        private System.Windows.Forms.ComboBox cboissfrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnview;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv;
        private System.Windows.Forms.Label label1;
    }
}