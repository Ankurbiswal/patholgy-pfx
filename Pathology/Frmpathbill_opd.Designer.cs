namespace Pathology
{
    partial class Frmpathbill_opd
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
            this.cboissueto = new System.Windows.Forms.ComboBox();
            this.cboissuefrom = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cboissto = new System.Windows.Forms.ComboBox();
            this.cboissfrom = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnview = new System.Windows.Forms.Button();
            this.crv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboissueto
            // 
            this.cboissueto.FormattingEnabled = true;
            this.cboissueto.Location = new System.Drawing.Point(350, 18);
            this.cboissueto.Name = "cboissueto";
            this.cboissueto.Size = new System.Drawing.Size(96, 21);
            this.cboissueto.TabIndex = 43;
            // 
            // cboissuefrom
            // 
            this.cboissuefrom.FormattingEnabled = true;
            this.cboissuefrom.Location = new System.Drawing.Point(213, 19);
            this.cboissuefrom.Name = "cboissuefrom";
            this.cboissuefrom.Size = new System.Drawing.Size(96, 21);
            this.cboissuefrom.TabIndex = 42;
            this.cboissuefrom.SelectedIndexChanged += new System.EventHandler(this.cboissuefrom_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(315, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 17);
            this.label3.TabIndex = 41;
            this.label3.Text = "To";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Green;
            this.button1.Location = new System.Drawing.Point(468, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 32);
            this.button1.TabIndex = 40;
            this.button1.Text = "View";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(107, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 17);
            this.label4.TabIndex = 38;
            this.label4.Text = "Bill No. From";
            // 
            // cboissto
            // 
            this.cboissto.FormattingEnabled = true;
            this.cboissto.Location = new System.Drawing.Point(305, -104);
            this.cboissto.Name = "cboissto";
            this.cboissto.Size = new System.Drawing.Size(96, 21);
            this.cboissto.TabIndex = 37;
            // 
            // cboissfrom
            // 
            this.cboissfrom.FormattingEnabled = true;
            this.cboissfrom.Location = new System.Drawing.Point(168, -103);
            this.cboissfrom.Name = "cboissfrom";
            this.cboissfrom.Size = new System.Drawing.Size(96, 21);
            this.cboissfrom.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(270, -100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 17);
            this.label2.TabIndex = 35;
            this.label2.Text = "To";
            // 
            // btnview
            // 
            this.btnview.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnview.ForeColor = System.Drawing.Color.Green;
            this.btnview.Location = new System.Drawing.Point(423, -111);
            this.btnview.Name = "btnview";
            this.btnview.Size = new System.Drawing.Size(136, 32);
            this.btnview.TabIndex = 34;
            this.btnview.Text = "View";
            this.btnview.UseVisualStyleBackColor = true;
            // 
            // crv
            // 
            this.crv.ActiveViewIndex = -1;
            this.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv.DisplayGroupTree = false;
            this.crv.Font = new System.Drawing.Font("Symbol", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crv.Location = new System.Drawing.Point(23, 49);
            this.crv.Name = "crv";
            this.crv.SelectionFormula = "";
            this.crv.Size = new System.Drawing.Size(720, 365);
            this.crv.TabIndex = 33;
            this.crv.ViewTimeSelectionFormula = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, -101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 32;
            this.label1.Text = "Bill No. From";
            // 
            // Frmpathbill_opd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(760, 426);
            this.Controls.Add(this.cboissueto);
            this.Controls.Add(this.cboissuefrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboissto);
            this.Controls.Add(this.cboissfrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnview);
            this.Controls.Add(this.crv);
            this.Controls.Add(this.label1);
            this.Name = "Frmpathbill_opd";
            this.Text = "Frmpathbill_opd";
            this.Load += new System.EventHandler(this.Frmpathbill_opd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboissueto;
        private System.Windows.Forms.ComboBox cboissuefrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboissto;
        private System.Windows.Forms.ComboBox cboissfrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnview;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv;
        private System.Windows.Forms.Label label1;

    }
}