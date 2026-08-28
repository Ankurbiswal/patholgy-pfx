namespace Pathology
{
    partial class Frmbom
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cboprofilename = new System.Windows.Forms.ComboBox();
            this.btnnrcancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnsave = new System.Windows.Forms.Button();
            this.dgvnormalreference = new System.Windows.Forms.DataGridView();
            this.tmtest = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tmgcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grunit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvnormalreference)).BeginInit();
            this.SuspendLayout();
            // 
            // cboprofilename
            // 
            this.cboprofilename.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboprofilename.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboprofilename.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboprofilename.DropDownHeight = 200;
            this.cboprofilename.IntegralHeight = false;
            this.cboprofilename.ItemHeight = 13;
            this.cboprofilename.Location = new System.Drawing.Point(181, 84);
            this.cboprofilename.Name = "cboprofilename";
            this.cboprofilename.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboprofilename.Size = new System.Drawing.Size(304, 21);
            this.cboprofilename.TabIndex = 27;
            this.cboprofilename.SelectedIndexChanged += new System.EventHandler(this.cboprofilename_SelectedIndexChanged);
            // 
            // btnnrcancel
            // 
            this.btnnrcancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnrcancel.Location = new System.Drawing.Point(363, 400);
            this.btnnrcancel.Name = "btnnrcancel";
            this.btnnrcancel.Size = new System.Drawing.Size(122, 48);
            this.btnnrcancel.TabIndex = 29;
            this.btnnrcancel.Text = "Cancel";
            this.btnnrcancel.UseVisualStyleBackColor = true;
            this.btnnrcancel.Click += new System.EventHandler(this.btnnrcancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Linen;
            this.label1.Font = new System.Drawing.Font("Rockwell", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(245, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 23);
            this.label1.TabIndex = 26;
            this.label1.Text = "Select Test Name";
            // 
            // btnsave
            // 
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.Location = new System.Drawing.Point(235, 400);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(122, 48);
            this.btnsave.TabIndex = 25;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // dgvnormalreference
            // 
            this.dgvnormalreference.BackgroundColor = System.Drawing.Color.Cornsilk;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvnormalreference.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvnormalreference.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvnormalreference.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tmtest,
            this.tmgcode,
            this.grunit});
            this.dgvnormalreference.Location = new System.Drawing.Point(99, 145);
            this.dgvnormalreference.Name = "dgvnormalreference";
            this.dgvnormalreference.Size = new System.Drawing.Size(464, 249);
            this.dgvnormalreference.TabIndex = 24;
            this.dgvnormalreference.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvnormalreference_RowValidating);
            this.dgvnormalreference.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvnormalreference_CellContentClick);
            // 
            // tmtest
            // 
            this.tmtest.HeaderText = "Item";
            this.tmtest.Name = "tmtest";
            this.tmtest.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmtest.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmtest.Width = 200;
            // 
            // tmgcode
            // 
            this.tmgcode.HeaderText = "Qty";
            this.tmgcode.Name = "tmgcode";
            // 
            // grunit
            // 
            this.grunit.HeaderText = "Unit";
            this.grunit.Name = "grunit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Linen;
            this.label3.Font = new System.Drawing.Font("Rockwell", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 545);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 23);
            this.label3.TabIndex = 30;
            this.label3.Text = "Message";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Linen;
            this.label4.Font = new System.Drawing.Font("Rockwell", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(214, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(250, 23);
            this.label4.TabIndex = 31;
            this.label4.Text = "Item Required for testing";
            // 
            // Frmbom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 578);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboprofilename);
            this.Controls.Add(this.btnnrcancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.dgvnormalreference);
            this.Controls.Add(this.label3);
            this.Name = "Frmbom";
            this.Text = "Frmbom";
            this.Load += new System.EventHandler(this.Frmbom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvnormalreference)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboprofilename;
        private System.Windows.Forms.Button btnnrcancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.DataGridView dgvnormalreference;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewComboBoxColumn tmtest;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmgcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn grunit;
        private System.Windows.Forms.Label label4;
    }
}