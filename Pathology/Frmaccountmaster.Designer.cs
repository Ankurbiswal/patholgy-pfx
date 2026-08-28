namespace Pathology
{
    partial class Frmaccountmaster
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
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtscd = new System.Windows.Forms.TextBox();
            this.txtgcd = new System.Windows.Forms.TextBox();
            this.cboaccountname = new System.Windows.Forms.ComboBox();
            this.bbtnsearch = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.txtdr_cr = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtopeningbal = new System.Windows.Forms.TextBox();
            this.txtdlno = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtcstno = new System.Windows.Forms.TextBox();
            this.txtvatno = new System.Windows.Forms.TextBox();
            this.txtphone = new System.Windows.Forms.TextBox();
            this.txtcity = new System.Windows.Forms.TextBox();
            this.txtpin = new System.Windows.Forms.TextBox();
            this.txtzone = new System.Windows.Forms.TextBox();
            this.txtfax = new System.Windows.Forms.TextBox();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbosgr = new System.Windows.Forms.ComboBox();
            this.cbogrp = new System.Windows.Forms.ComboBox();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.txtaccountid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(377, 84);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(46, 13);
            this.label18.TabIndex = 94;
            this.label18.Text = "Sub Gr";
            this.label18.Click += new System.EventHandler(this.label18_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(85, 86);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 13);
            this.label17.TabIndex = 93;
            this.label17.Text = "Group";
            // 
            // txtscd
            // 
            this.txtscd.Location = new System.Drawing.Point(435, 100);
            this.txtscd.Name = "txtscd";
            this.txtscd.ReadOnly = true;
            this.txtscd.Size = new System.Drawing.Size(213, 20);
            this.txtscd.TabIndex = 69;
            // 
            // txtgcd
            // 
            this.txtgcd.Location = new System.Drawing.Point(131, 104);
            this.txtgcd.Name = "txtgcd";
            this.txtgcd.ReadOnly = true;
            this.txtgcd.Size = new System.Drawing.Size(218, 20);
            this.txtgcd.TabIndex = 66;
            // 
            // cboaccountname
            // 
            this.cboaccountname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboaccountname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboaccountname.FormattingEnabled = true;
            this.cboaccountname.Location = new System.Drawing.Point(131, 63);
            this.cboaccountname.Name = "cboaccountname";
            this.cboaccountname.Size = new System.Drawing.Size(218, 21);
            this.cboaccountname.TabIndex = 56;
            this.cboaccountname.SelectedIndexChanged += new System.EventHandler(this.cboaccountname_SelectedIndexChanged);
            // 
            // bbtnsearch
            // 
            this.bbtnsearch.Location = new System.Drawing.Point(534, 55);
            this.bbtnsearch.Name = "bbtnsearch";
            this.bbtnsearch.Size = new System.Drawing.Size(98, 23);
            this.bbtnsearch.TabIndex = 92;
            this.bbtnsearch.Text = "Search";
            this.bbtnsearch.UseVisualStyleBackColor = true;
            // 
            // btnprint
            // 
            this.btnprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnprint.Location = new System.Drawing.Point(416, 362);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(75, 38);
            this.btnprint.TabIndex = 91;
            this.btnprint.Text = "Print";
            this.btnprint.UseVisualStyleBackColor = true;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // btncancel
            // 
            this.btncancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.ForeColor = System.Drawing.Color.SeaGreen;
            this.btncancel.Location = new System.Drawing.Point(343, 362);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 38);
            this.btncancel.TabIndex = 90;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btndelete
            // 
            this.btndelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete.ForeColor = System.Drawing.Color.SeaGreen;
            this.btndelete.Location = new System.Drawing.Point(270, 362);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(75, 38);
            this.btndelete.TabIndex = 89;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnupdate.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnupdate.Location = new System.Drawing.Point(197, 361);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(75, 38);
            this.btnupdate.TabIndex = 88;
            this.btnupdate.Text = "Update";
            this.btnupdate.UseVisualStyleBackColor = true;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btnadd
            // 
            this.btnadd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadd.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnadd.Location = new System.Drawing.Point(124, 361);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(75, 38);
            this.btnadd.TabIndex = 87;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // label16
            // 
            this.label16.AllowDrop = true;
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(320, 336);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 13);
            this.label16.TabIndex = 86;
            this.label16.Text = "Dr/Cr";
            // 
            // txtdr_cr
            // 
            this.txtdr_cr.AllowDrop = true;
            this.txtdr_cr.AutoCompleteCustomSource.AddRange(new string[] {
            "D",
            "C"});
            this.txtdr_cr.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtdr_cr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtdr_cr.Location = new System.Drawing.Point(362, 332);
            this.txtdr_cr.Name = "txtdr_cr";
            this.txtdr_cr.Size = new System.Drawing.Size(55, 20);
            this.txtdr_cr.TabIndex = 83;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(46, 335);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 13);
            this.label15.TabIndex = 85;
            this.label15.Text = "Opening Bal.";
            // 
            // txtopeningbal
            // 
            this.txtopeningbal.Location = new System.Drawing.Point(131, 332);
            this.txtopeningbal.Name = "txtopeningbal";
            this.txtopeningbal.Size = new System.Drawing.Size(175, 20);
            this.txtopeningbal.TabIndex = 82;
            // 
            // txtdlno
            // 
            this.txtdlno.Location = new System.Drawing.Point(131, 312);
            this.txtdlno.Name = "txtdlno";
            this.txtdlno.Size = new System.Drawing.Size(175, 20);
            this.txtdlno.TabIndex = 81;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(54, 315);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 13);
            this.label14.TabIndex = 84;
            this.label14.Text = "Credit Days";
            // 
            // txtcstno
            // 
            this.txtcstno.Location = new System.Drawing.Point(131, 292);
            this.txtcstno.Name = "txtcstno";
            this.txtcstno.Size = new System.Drawing.Size(175, 20);
            this.txtcstno.TabIndex = 80;
            this.txtcstno.Visible = false;
            // 
            // txtvatno
            // 
            this.txtvatno.Location = new System.Drawing.Point(131, 272);
            this.txtvatno.Name = "txtvatno";
            this.txtvatno.Size = new System.Drawing.Size(175, 20);
            this.txtvatno.TabIndex = 79;
            // 
            // txtphone
            // 
            this.txtphone.Location = new System.Drawing.Point(131, 212);
            this.txtphone.Name = "txtphone";
            this.txtphone.Size = new System.Drawing.Size(175, 20);
            this.txtphone.TabIndex = 76;
            // 
            // txtcity
            // 
            this.txtcity.Location = new System.Drawing.Point(131, 173);
            this.txtcity.Name = "txtcity";
            this.txtcity.Size = new System.Drawing.Size(175, 20);
            this.txtcity.TabIndex = 73;
            // 
            // txtpin
            // 
            this.txtpin.Location = new System.Drawing.Point(131, 193);
            this.txtpin.Name = "txtpin";
            this.txtpin.Size = new System.Drawing.Size(175, 20);
            this.txtpin.TabIndex = 74;
            // 
            // txtzone
            // 
            this.txtzone.Location = new System.Drawing.Point(360, 213);
            this.txtzone.Name = "txtzone";
            this.txtzone.Size = new System.Drawing.Size(175, 20);
            this.txtzone.TabIndex = 75;
            // 
            // txtfax
            // 
            this.txtfax.Location = new System.Drawing.Point(131, 232);
            this.txtfax.Name = "txtfax";
            this.txtfax.Size = new System.Drawing.Size(175, 20);
            this.txtfax.TabIndex = 77;
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(131, 252);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(175, 20);
            this.txtemail.TabIndex = 78;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(87, 295);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 13);
            this.label13.TabIndex = 72;
            this.label13.Text = "Cstno";
            this.label13.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(81, 279);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 70;
            this.label12.Text = "GSTIN";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(89, 255);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 68;
            this.label11.Text = "Email";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(99, 235);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 67;
            this.label10.Text = "Fax";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(83, 215);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 65;
            this.label9.Text = "Phone";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(322, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 63;
            this.label8.Text = "Zone";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(101, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 61;
            this.label7.Text = "Pin";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(98, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 59;
            this.label6.Text = "City";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(364, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 58;
            this.label5.Text = "Sgr Code";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(66, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "Grp Code";
            // 
            // cbosgr
            // 
            this.cbosgr.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbosgr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbosgr.FormattingEnabled = true;
            this.cbosgr.Location = new System.Drawing.Point(435, 79);
            this.cbosgr.Name = "cbosgr";
            this.cbosgr.Size = new System.Drawing.Size(213, 21);
            this.cbosgr.TabIndex = 64;
            this.cbosgr.SelectedIndexChanged += new System.EventHandler(this.cbosgr_SelectedIndexChanged);
            // 
            // cbogrp
            // 
            this.cbogrp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbogrp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbogrp.BackColor = System.Drawing.Color.White;
            this.cbogrp.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbogrp.FormattingEnabled = true;
            this.cbogrp.Location = new System.Drawing.Point(131, 83);
            this.cbogrp.Name = "cbogrp";
            this.cbogrp.Size = new System.Drawing.Size(218, 21);
            this.cbogrp.TabIndex = 62;
            // 
            // txtaddress
            // 
            this.txtaddress.Location = new System.Drawing.Point(131, 124);
            this.txtaddress.Multiline = true;
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(385, 50);
            this.txtaddress.TabIndex = 71;
            this.txtaddress.TextChanged += new System.EventHandler(this.txtaddress_TextChanged);
            // 
            // txtaccountid
            // 
            this.txtaccountid.Location = new System.Drawing.Point(435, 59);
            this.txtaccountid.Name = "txtaccountid";
            this.txtaccountid.Size = new System.Drawing.Size(93, 20);
            this.txtaccountid.TabIndex = 60;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(74, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 55;
            this.label3.Text = "Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(354, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "Account Id";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "A/c Head";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(248, 25);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(197, 24);
            this.label19.TabIndex = 95;
            this.label19.Text = "Account Head Entry";
            // 
            // Frmaccountmaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(727, 483);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtscd);
            this.Controls.Add(this.txtgcd);
            this.Controls.Add(this.cboaccountname);
            this.Controls.Add(this.bbtnsearch);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtdr_cr);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtopeningbal);
            this.Controls.Add(this.txtdlno);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtcstno);
            this.Controls.Add(this.txtvatno);
            this.Controls.Add(this.txtphone);
            this.Controls.Add(this.txtcity);
            this.Controls.Add(this.txtpin);
            this.Controls.Add(this.txtzone);
            this.Controls.Add(this.txtfax);
            this.Controls.Add(this.txtemail);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbosgr);
            this.Controls.Add(this.cbogrp);
            this.Controls.Add(this.txtaddress);
            this.Controls.Add(this.txtaccountid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Frmaccountmaster";
            this.Text = "Frmaccountmaster";
            this.Load += new System.EventHandler(this.Frmaccountmaster_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtscd;
        private System.Windows.Forms.TextBox txtgcd;
        private System.Windows.Forms.ComboBox cboaccountname;
        private System.Windows.Forms.Button bbtnsearch;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtdr_cr;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtopeningbal;
        private System.Windows.Forms.TextBox txtdlno;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtcstno;
        private System.Windows.Forms.TextBox txtvatno;
        private System.Windows.Forms.TextBox txtphone;
        private System.Windows.Forms.TextBox txtcity;
        private System.Windows.Forms.TextBox txtpin;
        private System.Windows.Forms.TextBox txtzone;
        private System.Windows.Forms.TextBox txtfax;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbosgr;
        private System.Windows.Forms.ComboBox cbogrp;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.TextBox txtaccountid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label19;
    }
}