namespace Pathology
{
    partial class Frmpending
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnReady = new System.Windows.Forms.Button();
            this.btnDelivered = new System.Windows.Forms.Button();
            this.btnPending = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // lblTitle
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Size = new System.Drawing.Size(900, 35);
            this.lblTitle.Text = "  📋 Pending Reports Tracker";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // lblFilter
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(12, 47);
            this.lblFilter.Text = "Filter Status:";
            this.lblFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            // cboStatus
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Location = new System.Drawing.Point(95, 44);
            this.cboStatus.Size = new System.Drawing.Size(110, 22);
            this.cboStatus.Items.AddRange(new object[]{"Pending","Ready","Delivered","All"});
            this.cboStatus.SelectedIndex = 0;
            this.cboStatus.SelectedIndexChanged += new System.EventHandler(this.cboStatus_SelectedIndexChanged);
            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(220, 43);
            this.btnRefresh.Size = new System.Drawing.Size(75, 24);
            this.btnRefresh.Text = "🔄 Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // btnPending
            this.btnPending.Location = new System.Drawing.Point(550, 43);
            this.btnPending.Size = new System.Drawing.Size(95, 24);
            this.btnPending.Text = "Mark Pending";
            this.btnPending.BackColor = System.Drawing.Color.FromArgb(255, 200, 200);
            this.btnPending.Click += new System.EventHandler(this.btnPending_Click);
            // btnReady
            this.btnReady.Location = new System.Drawing.Point(655, 43);
            this.btnReady.Size = new System.Drawing.Size(95, 24);
            this.btnReady.Text = "✅ Mark Ready";
            this.btnReady.BackColor = System.Drawing.Color.FromArgb(180, 255, 180);
            this.btnReady.Click += new System.EventHandler(this.btnReady_Click);
            // btnDelivered
            this.btnDelivered.Location = new System.Drawing.Point(760, 43);
            this.btnDelivered.Size = new System.Drawing.Size(110, 24);
            this.btnDelivered.Text = "📦 Mark Delivered";
            this.btnDelivered.BackColor = System.Drawing.Color.FromArgb(180, 200, 255);
            this.btnDelivered.Click += new System.EventHandler(this.btnDelivered_Click);
            // dgv
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ReadOnly = true;
            this.dgv.MultiSelect = true;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.RowHeadersVisible = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgv.Location = new System.Drawing.Point(0, 76);
            this.dgv.Size = new System.Drawing.Size(900, 440);
            this.dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240,240,240);
            this.dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(250,250,250);
            // lblCount
            this.lblCount.Location = new System.Drawing.Point(0, 520);
            this.lblCount.Size = new System.Drawing.Size(900, 22);
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblCount.ForeColor = System.Drawing.Color.DimGray;
            this.lblCount.Text = "Loading...";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 548);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnPending);
            this.Controls.Add(this.btnReady);
            this.Controls.Add(this.btnDelivered);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.lblCount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Frmpending";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pending Reports";
            this.Load += new System.EventHandler(this.Frmpending_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnReady, btnDelivered, btnPending, btnRefresh;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label lblFilter, lblCount, lblTitle;
    }
}
