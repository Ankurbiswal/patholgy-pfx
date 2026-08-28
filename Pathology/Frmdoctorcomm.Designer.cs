namespace Pathology
{
    partial class Frmdoctorcomm
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
            this.label29 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.whatischecked = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.txtcompid = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pvdt = new System.Windows.Forms.DateTimePicker();
            this.crv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label3 = new System.Windows.Forms.Label();
            this.dtto = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtfrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cboledger = new System.Windows.Forms.ComboBox();
            this.btnback = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 4F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Millimeter, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.Cornsilk;
            this.label29.Location = new System.Drawing.Point(0, 0);
            this.label29.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(1003, 18);
            this.label29.TabIndex = 164;
            this.label29.Text = "COMMISSION LEDGERS";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(759, 22);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(70, 17);
            this.checkBox1.TabIndex = 163;
            this.checkBox1.Text = "Select All";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // whatischecked
            // 
            this.whatischecked.Location = new System.Drawing.Point(321, 44);
            this.whatischecked.Name = "whatischecked";
            this.whatischecked.Size = new System.Drawing.Size(89, 24);
            this.whatischecked.TabIndex = 162;
            this.whatischecked.Text = "Whatischecked";
            this.whatischecked.UseVisualStyleBackColor = true;
            this.whatischecked.Visible = false;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(759, 44);
            this.checkedListBox1.MultiColumn = true;
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(228, 484);
            this.checkedListBox1.TabIndex = 161;
            this.checkedListBox1.ThreeDCheckBoxes = true;
            // 
            // txtcompid
            // 
            this.txtcompid.Location = new System.Drawing.Point(806, 20);
            this.txtcompid.Name = "txtcompid";
            this.txtcompid.Size = new System.Drawing.Size(10, 20);
            this.txtcompid.TabIndex = 160;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 4F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Millimeter, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 20);
            this.label4.TabIndex = 159;
            this.label4.Text = "Comp";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(321, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 24);
            this.button1.TabIndex = 158;
            this.button1.Text = "Show Ledger";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pvdt
            // 
            this.pvdt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.pvdt.Location = new System.Drawing.Point(799, -1);
            this.pvdt.Name = "pvdt";
            this.pvdt.Size = new System.Drawing.Size(20, 20);
            this.pvdt.TabIndex = 157;
            // 
            // crv
            // 
            this.crv.ActiveViewIndex = -1;
            this.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv.DisplayGroupTree = false;
            this.crv.Location = new System.Drawing.Point(26, 95);
            this.crv.Name = "crv";
            this.crv.SelectionFormula = "";
            this.crv.Size = new System.Drawing.Size(727, 464);
            this.crv.TabIndex = 156;
            this.crv.ViewTimeSelectionFormula = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(197, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 155;
            this.label3.Text = "To";
            // 
            // dtto
            // 
            this.dtto.CustomFormat = "dd/MM/yyyy";
            this.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtto.Location = new System.Drawing.Point(223, 65);
            this.dtto.Name = "dtto";
            this.dtto.Size = new System.Drawing.Size(92, 20);
            this.dtto.TabIndex = 154;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 153;
            this.label2.Text = "Date From";
            // 
            // dtfrom
            // 
            this.dtfrom.CustomFormat = "dd/MM/yyyy";
            this.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtfrom.Location = new System.Drawing.Point(99, 65);
            this.dtfrom.Name = "dtfrom";
            this.dtfrom.Size = new System.Drawing.Size(92, 20);
            this.dtfrom.TabIndex = 152;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 151;
            this.label1.Text = "Select Ledger";
            // 
            // cboledger
            // 
            this.cboledger.FormattingEnabled = true;
            this.cboledger.Location = new System.Drawing.Point(99, 46);
            this.cboledger.Name = "cboledger";
            this.cboledger.Size = new System.Drawing.Size(216, 21);
            this.cboledger.TabIndex = 150;
            this.cboledger.SelectedIndexChanged += new System.EventHandler(this.cboledger_SelectedIndexChanged);
            // 
            // btnback
            // 
            this.btnback.Image = global::Pathology.Properties.Resources.back_btn;
            this.btnback.Location = new System.Drawing.Point(637, 39);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(75, 23);
            this.btnback.TabIndex = 165;
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // Frmdoctorcomm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(804, 576);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.whatischecked);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.txtcompid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pvdt);
            this.Controls.Add(this.crv);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtfrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboledger);
            this.Name = "Frmdoctorcomm";
            this.Text = "Frmdoctorcomm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmdoctorcomm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button whatischecked;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.TextBox txtcompid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker pvdt;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtfrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboledger;
        private System.Windows.Forms.Button btnback;
    }
}