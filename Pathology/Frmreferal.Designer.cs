namespace Pathology
{
    partial class Frmreferal
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
            this.label7 = new System.Windows.Forms.Label();
            this.txtbiochemist = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtpathologist = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.txtfax_no = new System.Windows.Forms.TextBox();
            this.txttelephone_no = new System.Windows.Forms.TextBox();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtcompanyid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbocompanyname = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtrefper = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 248);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 79;
            this.label7.Text = "Biochemist";
            this.label7.Visible = false;
            // 
            // txtbiochemist
            // 
            this.txtbiochemist.Location = new System.Drawing.Point(102, 245);
            this.txtbiochemist.Name = "txtbiochemist";
            this.txtbiochemist.Size = new System.Drawing.Size(255, 20);
            this.txtbiochemist.TabIndex = 78;
            this.txtbiochemist.Visible = false;
            this.txtbiochemist.TextChanged += new System.EventHandler(this.txtbiochemist_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 77;
            this.label6.Text = "Pathologist";
            this.label6.Visible = false;
            // 
            // txtpathologist
            // 
            this.txtpathologist.Location = new System.Drawing.Point(102, 223);
            this.txtpathologist.Name = "txtpathologist";
            this.txtpathologist.Size = new System.Drawing.Size(255, 20);
            this.txtpathologist.TabIndex = 76;
            this.txtpathologist.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 75;
            this.label5.Text = "Fax. No";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 74;
            this.label4.Text = "Tel.No";
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(209, 276);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 45);
            this.btncancel.TabIndex = 73;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.Location = new System.Drawing.Point(136, 276);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(75, 45);
            this.btnupdate.TabIndex = 72;
            this.btnupdate.Text = "Update";
            this.btnupdate.UseVisualStyleBackColor = true;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btndelete
            // 
            this.btndelete.Location = new System.Drawing.Point(282, 276);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(75, 45);
            this.btndelete.TabIndex = 71;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnprint
            // 
            this.btnprint.Location = new System.Drawing.Point(355, 276);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(75, 45);
            this.btnprint.TabIndex = 70;
            this.btnprint.Text = "Print";
            this.btnprint.UseVisualStyleBackColor = true;
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(63, 276);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(75, 45);
            this.btnadd.TabIndex = 69;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // txtfax_no
            // 
            this.txtfax_no.Location = new System.Drawing.Point(102, 151);
            this.txtfax_no.Name = "txtfax_no";
            this.txtfax_no.Size = new System.Drawing.Size(255, 20);
            this.txtfax_no.TabIndex = 68;
            // 
            // txttelephone_no
            // 
            this.txttelephone_no.Location = new System.Drawing.Point(102, 131);
            this.txttelephone_no.Name = "txttelephone_no";
            this.txttelephone_no.Size = new System.Drawing.Size(255, 20);
            this.txttelephone_no.TabIndex = 67;
            // 
            // txtaddress
            // 
            this.txtaddress.Location = new System.Drawing.Point(102, 74);
            this.txtaddress.Multiline = true;
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(405, 57);
            this.txtaddress.TabIndex = 66;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 65;
            this.label3.Text = "Address";
            // 
            // txtcompanyid
            // 
            this.txtcompanyid.Location = new System.Drawing.Point(456, 54);
            this.txtcompanyid.Name = "txtcompanyid";
            this.txtcompanyid.ReadOnly = true;
            this.txtcompanyid.Size = new System.Drawing.Size(51, 20);
            this.txtcompanyid.TabIndex = 64;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(391, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 63;
            this.label2.Text = "Code No.";
            // 
            // cbocompanyname
            // 
            this.cbocompanyname.FormattingEnabled = true;
            this.cbocompanyname.Location = new System.Drawing.Point(102, 53);
            this.cbocompanyname.Name = "cbocompanyname";
            this.cbocompanyname.Size = new System.Drawing.Size(290, 21);
            this.cbocompanyname.TabIndex = 62;
            this.cbocompanyname.SelectedIndexChanged += new System.EventHandler(this.cbocompanyname_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 61;
            this.label1.Text = "Referal";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(163, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(186, 20);
            this.label8.TabIndex = 80;
            this.label8.Text = "REFERAL\'S MASTER";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(78, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 13);
            this.label9.TabIndex = 82;
            this.label9.Text = "%";
            // 
            // txtrefper
            // 
            this.txtrefper.Location = new System.Drawing.Point(102, 177);
            this.txtrefper.Name = "txtrefper";
            this.txtrefper.Size = new System.Drawing.Size(255, 20);
            this.txtrefper.TabIndex = 69;
            // 
            // Frmreferal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(525, 409);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtrefper);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtbiochemist);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtpathologist);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.txtfax_no);
            this.Controls.Add(this.txttelephone_no);
            this.Controls.Add(this.txtaddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtcompanyid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbocompanyname);
            this.Controls.Add(this.label1);
            this.Name = "Frmreferal";
            this.Text = "Frmreferal";
            this.Load += new System.EventHandler(this.Frmreferal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtbiochemist;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtpathologist;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.TextBox txtfax_no;
        private System.Windows.Forms.TextBox txttelephone_no;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtcompanyid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbocompanyname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtrefper;
    }
}