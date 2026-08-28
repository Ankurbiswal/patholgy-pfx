namespace Pathology
{
    partial class Frmcompanysel
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
            this.btncancel = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.txtcompanyid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbocompanyname = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(478, 133);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 36);
            this.btncancel.TabIndex = 30;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnprint
            // 
            this.btnprint.Location = new System.Drawing.Point(397, 133);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(75, 36);
            this.btnprint.TabIndex = 29;
            this.btnprint.Text = "Ok";
            this.btnprint.UseVisualStyleBackColor = true;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // txtcompanyid
            // 
            this.txtcompanyid.Location = new System.Drawing.Point(511, 72);
            this.txtcompanyid.Name = "txtcompanyid";
            this.txtcompanyid.ReadOnly = true;
            this.txtcompanyid.Size = new System.Drawing.Size(40, 20);
            this.txtcompanyid.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(437, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Company Id.";
            // 
            // cbocompanyname
            // 
            this.cbocompanyname.FormattingEnabled = true;
            this.cbocompanyname.Location = new System.Drawing.Point(182, 72);
            this.cbocompanyname.Name = "cbocompanyname";
            this.cbocompanyname.Size = new System.Drawing.Size(249, 21);
            this.cbocompanyname.TabIndex = 26;
            this.cbocompanyname.SelectedIndexChanged += new System.EventHandler(this.cbocompanyname_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Select Company ";
            // 
            // Frmcompanysel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(655, 315);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.txtcompanyid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbocompanyname);
            this.Controls.Add(this.label1);
            this.Name = "Frmcompanysel";
            this.Text = "Company Selection";
            this.Load += new System.EventHandler(this.Frmcompanysel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.TextBox txtcompanyid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbocompanyname;
        private System.Windows.Forms.Label label1;
    }
}