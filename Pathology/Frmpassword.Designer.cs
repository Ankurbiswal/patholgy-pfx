namespace Pathology
{
    partial class Frmpassword
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtpsd = new System.Windows.Forms.TextBox();
            this.txtuserid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.txtpasswordd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.rblogincancel = new RoundButton();
            this.rbsubmit = new RoundButton();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.ForestGreen;
            this.button1.Location = new System.Drawing.Point(0, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 40);
            this.button1.TabIndex = 24;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.ForestGreen;
            this.button2.Location = new System.Drawing.Point(0, 198);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 40);
            this.button2.TabIndex = 25;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // txtpsd
            // 
            this.txtpsd.AcceptsReturn = true;
            this.txtpsd.AcceptsTab = true;
            this.txtpsd.AllowDrop = true;
            this.txtpsd.BackColor = System.Drawing.SystemColors.Window;
            this.txtpsd.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtpsd.Location = new System.Drawing.Point(648, 210);
            this.txtpsd.Name = "txtpsd";
            this.txtpsd.Size = new System.Drawing.Size(15, 20);
            this.txtpsd.TabIndex = 4;
            this.txtpsd.Visible = false;
            // 
            // txtuserid
            // 
            this.txtuserid.BackColor = System.Drawing.SystemColors.Window;
            this.txtuserid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtuserid.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtuserid.Location = new System.Drawing.Point(227, 89);
            this.txtuserid.Name = "txtuserid";
            this.txtuserid.Size = new System.Drawing.Size(214, 26);
            this.txtuserid.TabIndex = 22;
            this.txtuserid.Validating += new System.ComponentModel.CancelEventHandler(this.txtuserid_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(121, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 24);
            this.label2.TabIndex = 21;
            this.label2.Text = "User Id : *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(98, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 24);
            this.label3.TabIndex = 17;
            this.label3.Text = "Password : *";
            // 
            // txtpassword
            // 
            this.txtpassword.BackColor = System.Drawing.SystemColors.Window;
            this.txtpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpassword.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtpassword.Location = new System.Drawing.Point(228, 130);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.PasswordChar = '*';
            this.txtpassword.Size = new System.Drawing.Size(213, 26);
            this.txtpassword.TabIndex = 23;
            // 
            // txtpasswordd
            // 
            this.txtpasswordd.BackColor = System.Drawing.SystemColors.Window;
            this.txtpasswordd.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtpasswordd.Location = new System.Drawing.Point(663, 12);
            this.txtpasswordd.Name = "txtpasswordd";
            this.txtpasswordd.PasswordChar = '*';
            this.txtpasswordd.Size = new System.Drawing.Size(19, 20);
            this.txtpasswordd.TabIndex = 23;
            this.txtpasswordd.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.ForestGreen;
            this.label1.Location = new System.Drawing.Point(294, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 24);
            this.label1.TabIndex = 26;
            this.label1.Text = "LOG IN";
            // 
            // button3
            // 
            this.button3.AutoSize = true;
            this.button3.BackColor = System.Drawing.Color.LemonChiffon;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.ForestGreen;
            this.button3.Location = new System.Drawing.Point(0, 265);
            this.button3.Name = "button3";
            this.button3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button3.Size = new System.Drawing.Size(685, 30);
            this.button3.TabIndex = 27;
            this.button3.Text = "PathoLab Software  By HOPE SOFTWARE, Bhubaneswar, PhonePay.:9937726338,whatsapp:7" +
                "606967197";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // rblogincancel
            // 
            this.rblogincancel.BackColor = System.Drawing.Color.Moccasin;
            this.rblogincancel.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.rblogincancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.rblogincancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.rblogincancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rblogincancel.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rblogincancel.Location = new System.Drawing.Point(328, 176);
            this.rblogincancel.Name = "rblogincancel";
            this.rblogincancel.Size = new System.Drawing.Size(113, 35);
            this.rblogincancel.TabIndex = 57;
            this.rblogincancel.Text = "CANCEL";
            this.rblogincancel.UseVisualStyleBackColor = false;
            this.rblogincancel.Click += new System.EventHandler(this.rblogincancel_Click);
            // 
            // rbsubmit
            // 
            this.rbsubmit.BackColor = System.Drawing.Color.Moccasin;
            this.rbsubmit.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.rbsubmit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.rbsubmit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.rbsubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbsubmit.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbsubmit.Location = new System.Drawing.Point(219, 176);
            this.rbsubmit.Name = "rbsubmit";
            this.rbsubmit.Size = new System.Drawing.Size(103, 35);
            this.rbsubmit.TabIndex = 56;
            this.rbsubmit.Text = "SUBMIT";
            this.rbsubmit.UseVisualStyleBackColor = false;
            this.rbsubmit.Click += new System.EventHandler(this.rbsubmit_Click);
            // 
            // Frmpassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(681, 294);
            this.Controls.Add(this.rblogincancel);
            this.Controls.Add(this.rbsubmit);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtpasswordd);
            this.Controls.Add(this.txtuserid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.txtpsd);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.KeyPreview = true;
            this.Name = "Frmpassword";
            this.Text = "PATHOLAB ";
            this.Load += new System.EventHandler(this.Frmpassword_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frmpassword_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtpsd;
        private System.Windows.Forms.TextBox txtuserid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.TextBox txtpasswordd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private RoundButton rbsubmit;
        private RoundButton rblogincancel;
    }
}