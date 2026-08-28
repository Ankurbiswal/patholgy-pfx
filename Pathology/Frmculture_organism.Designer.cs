namespace Pathology
{
    partial class Frmculture_organism
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tmrr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tmtest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grmethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grtunit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TMRATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TMGR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TMSGR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grrangefrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grrangeto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTNPRINT = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btncancel = new System.Windows.Forms.Button();
            this.BTNCULSAVE = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrr
            // 
            this.tmrr.HeaderText = "NORMAL_RANGE";
            this.tmrr.Name = "tmrr";
            this.tmrr.Visible = false;
            this.tmrr.Width = 200;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tmtest,
            this.grmethod,
            this.grtunit,
            this.tmrr,
            this.TMRATE,
            this.TMGR,
            this.TMSGR,
            this.grrangefrom,
            this.grrangeto});
            this.dataGridView1.Location = new System.Drawing.Point(27, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1004, 222);
            this.dataGridView1.TabIndex = 171;
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // tmtest
            // 
            this.tmtest.HeaderText = "Type";
            this.tmtest.Name = "tmtest";
            this.tmtest.Width = 300;
            // 
            // grmethod
            // 
            this.grmethod.HeaderText = "METHOD";
            this.grmethod.Name = "grmethod";
            // 
            // grtunit
            // 
            this.grtunit.HeaderText = "UNIT";
            this.grtunit.Name = "grtunit";
            this.grtunit.Visible = false;
            this.grtunit.Width = 50;
            // 
            // TMRATE
            // 
            this.TMRATE.HeaderText = "PRICE";
            this.TMRATE.Name = "TMRATE";
            this.TMRATE.Visible = false;
            // 
            // TMGR
            // 
            this.TMGR.HeaderText = "GROUP";
            this.TMGR.Name = "TMGR";
            this.TMGR.Visible = false;
            // 
            // TMSGR
            // 
            this.TMSGR.HeaderText = "SUB GRP";
            this.TMSGR.Name = "TMSGR";
            this.TMSGR.Visible = false;
            // 
            // grrangefrom
            // 
            this.grrangefrom.HeaderText = "Range-From";
            this.grrangefrom.Name = "grrangefrom";
            this.grrangefrom.Visible = false;
            // 
            // grrangeto
            // 
            this.grrangeto.HeaderText = "Range-To";
            this.grrangeto.Name = "grrangeto";
            this.grrangeto.Visible = false;
            // 
            // BTNPRINT
            // 
            this.BTNPRINT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNPRINT.Location = new System.Drawing.Point(394, 353);
            this.BTNPRINT.Name = "BTNPRINT";
            this.BTNPRINT.Size = new System.Drawing.Size(122, 48);
            this.BTNPRINT.TabIndex = 175;
            this.BTNPRINT.Text = "PRINT";
            this.BTNPRINT.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightYellow;
            this.label1.Font = new System.Drawing.Font("Calibri", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(148, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 33);
            this.label1.TabIndex = 170;
            this.label1.Text = "Culture Organism";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightYellow;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 307);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 19);
            this.label2.TabIndex = 173;
            this.label2.Text = "Test Master";
            // 
            // btncancel
            // 
            this.btncancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.Location = new System.Drawing.Point(245, 353);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(122, 48);
            this.btncancel.TabIndex = 172;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            // 
            // BTNCULSAVE
            // 
            this.BTNCULSAVE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNCULSAVE.Location = new System.Drawing.Point(117, 353);
            this.BTNCULSAVE.Name = "BTNCULSAVE";
            this.BTNCULSAVE.Size = new System.Drawing.Size(122, 48);
            this.BTNCULSAVE.TabIndex = 169;
            this.BTNCULSAVE.Text = "Save";
            this.BTNCULSAVE.UseVisualStyleBackColor = true;
            this.BTNCULSAVE.Click += new System.EventHandler(this.BTNCULSAVE_Click);
            // 
            // btnback
            // 
            this.btnback.Image = global::Pathology.Properties.Resources.back_btn;
            this.btnback.Location = new System.Drawing.Point(719, 31);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(75, 32);
            this.btnback.TabIndex = 174;
            this.btnback.UseVisualStyleBackColor = true;
            // 
            // Frmculture_organism
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 425);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.BTNPRINT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.BTNCULSAVE);
            this.Name = "Frmculture_organism";
            this.Text = "Frmculture_organism";
            this.Load += new System.EventHandler(this.Frmculture_organism_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn tmrr;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmtest;
        private System.Windows.Forms.DataGridViewTextBoxColumn grmethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn grtunit;
        private System.Windows.Forms.DataGridViewTextBoxColumn TMRATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TMGR;
        private System.Windows.Forms.DataGridViewTextBoxColumn TMSGR;
        private System.Windows.Forms.DataGridViewTextBoxColumn grrangefrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn grrangeto;
        private System.Windows.Forms.Button BTNPRINT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button BTNCULSAVE;
    }
}