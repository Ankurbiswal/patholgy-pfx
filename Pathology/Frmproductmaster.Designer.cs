namespace Pathology
{
    partial class Frmproductmaster
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
            this.btnsearch = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtsalerate = new System.Windows.Forms.TextBox();
            this.txtsubgroup = new System.Windows.Forms.TextBox();
            this.txtgroup = new System.Windows.Forms.TextBox();
            this.cbosubgroup = new System.Windows.Forms.ComboBox();
            this.cbogroup = new System.Windows.Forms.ComboBox();
            this.txtreorder = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboitem = new System.Windows.Forms.ComboBox();
            this.txtsaleunit = new System.Windows.Forms.TextBox();
            this.txtpurchesunit = new System.Windows.Forms.TextBox();
            this.txtvalue = new System.Windows.Forms.TextBox();
            this.txtopqty = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtdesc = new System.Windows.Forms.RichTextBox();
            this.txtitemid = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnback = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnsearch
            // 
            this.btnsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsearch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnsearch.Location = new System.Drawing.Point(369, 39);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(87, 23);
            this.btnsearch.TabIndex = 253;
            this.btnsearch.Text = "Search";
            this.btnsearch.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(337, 150);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 252;
            this.label10.Text = "Sale Rate";
            // 
            // txtsalerate
            // 
            this.txtsalerate.Location = new System.Drawing.Point(405, 146);
            this.txtsalerate.Name = "txtsalerate";
            this.txtsalerate.Size = new System.Drawing.Size(85, 20);
            this.txtsalerate.TabIndex = 246;
            // 
            // txtsubgroup
            // 
            this.txtsubgroup.Location = new System.Drawing.Point(792, 70);
            this.txtsubgroup.Name = "txtsubgroup";
            this.txtsubgroup.Size = new System.Drawing.Size(51, 20);
            this.txtsubgroup.TabIndex = 239;
            // 
            // txtgroup
            // 
            this.txtgroup.Location = new System.Drawing.Point(793, 49);
            this.txtgroup.Name = "txtgroup";
            this.txtgroup.Size = new System.Drawing.Size(41, 20);
            this.txtgroup.TabIndex = 237;
            // 
            // cbosubgroup
            // 
            this.cbosubgroup.AllowDrop = true;
            this.cbosubgroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbosubgroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbosubgroup.FormattingEnabled = true;
            this.cbosubgroup.Location = new System.Drawing.Point(361, 68);
            this.cbosubgroup.Name = "cbosubgroup";
            this.cbosubgroup.Size = new System.Drawing.Size(222, 21);
            this.cbosubgroup.Sorted = true;
            this.cbosubgroup.TabIndex = 238;
            this.cbosubgroup.SelectedIndexChanged += new System.EventHandler(this.cbosubgroup_SelectedIndexChanged);
            // 
            // cbogroup
            // 
            this.cbogroup.AllowDrop = true;
            this.cbogroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbogroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbogroup.FormattingEnabled = true;
            this.cbogroup.Location = new System.Drawing.Point(90, 68);
            this.cbogroup.Name = "cbogroup";
            this.cbogroup.Size = new System.Drawing.Size(214, 21);
            this.cbogroup.Sorted = true;
            this.cbogroup.TabIndex = 236;
            this.cbogroup.SelectedIndexChanged += new System.EventHandler(this.cbogroup_SelectedIndexChanged);
            // 
            // txtreorder
            // 
            this.txtreorder.Location = new System.Drawing.Point(405, 126);
            this.txtreorder.Name = "txtreorder";
            this.txtreorder.Size = new System.Drawing.Size(85, 20);
            this.txtreorder.TabIndex = 243;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(337, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 235;
            this.label5.Text = "Re-order Qty";
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.Color.Goldenrod;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 4F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Millimeter, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.Cornsilk;
            this.label29.Location = new System.Drawing.Point(0, 0);
            this.label29.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(635, 21);
            this.label29.TabIndex = 234;
            this.label29.Text = "Item Master";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 233;
            this.label3.Text = "Item";
            // 
            // cboitem
            // 
            this.cboitem.AllowDrop = true;
            this.cboitem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboitem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboitem.FormattingEnabled = true;
            this.cboitem.Location = new System.Drawing.Point(90, 48);
            this.cboitem.Name = "cboitem";
            this.cboitem.Size = new System.Drawing.Size(214, 21);
            this.cboitem.Sorted = true;
            this.cboitem.TabIndex = 222;
            this.cboitem.SelectedIndexChanged += new System.EventHandler(this.cboitem_SelectedIndexChanged);
            this.cboitem.TextChanged += new System.EventHandler(this.cboitem_TextChanged);
            // 
            // txtsaleunit
            // 
            this.txtsaleunit.Location = new System.Drawing.Point(248, 146);
            this.txtsaleunit.Name = "txtsaleunit";
            this.txtsaleunit.Size = new System.Drawing.Size(80, 20);
            this.txtsaleunit.TabIndex = 245;
            // 
            // txtpurchesunit
            // 
            this.txtpurchesunit.Location = new System.Drawing.Point(90, 146);
            this.txtpurchesunit.Name = "txtpurchesunit";
            this.txtpurchesunit.Size = new System.Drawing.Size(79, 20);
            this.txtpurchesunit.TabIndex = 244;
            // 
            // txtvalue
            // 
            this.txtvalue.Location = new System.Drawing.Point(248, 126);
            this.txtvalue.Name = "txtvalue";
            this.txtvalue.Size = new System.Drawing.Size(80, 20);
            this.txtvalue.TabIndex = 242;
            // 
            // txtopqty
            // 
            this.txtopqty.Location = new System.Drawing.Point(90, 126);
            this.txtopqty.Name = "txtopqty";
            this.txtopqty.Size = new System.Drawing.Size(79, 20);
            this.txtopqty.TabIndex = 241;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(192, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 232;
            this.label8.Text = "Sale unit";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 231;
            this.label7.Text = "Purch unit";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(192, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 230;
            this.label6.Text = "Value";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(436, 309);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 229;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(24, 129);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(43, 13);
            this.lbl.TabIndex = 228;
            this.lbl.Text = "Op. Qty";
            this.lbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(306, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 227;
            this.label11.Text = "Sgr Name";
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(425, 188);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(79, 39);
            this.btnPrint.TabIndex = 251;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(351, 188);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 39);
            this.btnCancel.TabIndex = 250;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(274, 188);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(79, 39);
            this.btnDelete.TabIndex = 249;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpdate.Location = new System.Drawing.Point(197, 188);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(79, 39);
            this.btnUpdate.TabIndex = 248;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAdd.Location = new System.Drawing.Point(112, 188);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 39);
            this.btnAdd.TabIndex = 247;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtdesc
            // 
            this.txtdesc.Location = new System.Drawing.Point(90, 87);
            this.txtdesc.Name = "txtdesc";
            this.txtdesc.Size = new System.Drawing.Size(493, 36);
            this.txtdesc.TabIndex = 240;
            this.txtdesc.Text = "";
            // 
            // txtitemid
            // 
            this.txtitemid.Location = new System.Drawing.Point(774, 44);
            this.txtitemid.Name = "txtitemid";
            this.txtitemid.Size = new System.Drawing.Size(53, 20);
            this.txtitemid.TabIndex = 223;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 226;
            this.label9.Text = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(776, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 225;
            this.label2.Text = "Item-Id";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 224;
            this.label1.Text = "Gr. Name";
            // 
            // btnback
            // 
            this.btnback.Image = global::Pathology.Properties.Resources.back_btn;
            this.btnback.Location = new System.Drawing.Point(508, 24);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(75, 23);
            this.btnback.TabIndex = 254;
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // Frmproductmaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(635, 469);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtsalerate);
            this.Controls.Add(this.txtsubgroup);
            this.Controls.Add(this.txtgroup);
            this.Controls.Add(this.cbosubgroup);
            this.Controls.Add(this.cbogroup);
            this.Controls.Add(this.txtreorder);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboitem);
            this.Controls.Add(this.txtsaleunit);
            this.Controls.Add(this.txtpurchesunit);
            this.Controls.Add(this.txtvalue);
            this.Controls.Add(this.txtopqty);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtdesc);
            this.Controls.Add(this.txtitemid);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Frmproductmaster";
            this.Text = "Frmproductmaster";
            this.Load += new System.EventHandler(this.Frmproductmaster_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtsalerate;
        private System.Windows.Forms.TextBox txtsubgroup;
        private System.Windows.Forms.TextBox txtgroup;
        private System.Windows.Forms.ComboBox cbosubgroup;
        private System.Windows.Forms.ComboBox cbogroup;
        private System.Windows.Forms.TextBox txtreorder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboitem;
        private System.Windows.Forms.TextBox txtsaleunit;
        private System.Windows.Forms.TextBox txtpurchesunit;
        private System.Windows.Forms.TextBox txtvalue;
        private System.Windows.Forms.TextBox txtopqty;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.RichTextBox txtdesc;
        private System.Windows.Forms.TextBox txtitemid;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnback;
    }
}