namespace Pathology
{
    partial class Frmbackup
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.btnbackup = new System.Windows.Forms.Button();
            this.lblLastBackup = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // lblTitle
            this.lblTitle.AutoSize = false;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 15);
            this.lblTitle.Size = new System.Drawing.Size(360, 25);
            this.lblTitle.Text = "Database Backup";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // btnbackup
            this.btnbackup.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btnbackup.ForeColor = System.Drawing.Color.White;
            this.btnbackup.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnbackup.Location = new System.Drawing.Point(110, 55);
            this.btnbackup.Name = "btnbackup";
            this.btnbackup.Size = new System.Drawing.Size(160, 40);
            this.btnbackup.TabIndex = 0;
            this.btnbackup.Text = "🗄️  Take Backup Now";
            this.btnbackup.UseVisualStyleBackColor = false;
            this.btnbackup.Click += new System.EventHandler(this.btnbackup_Click);
            // lblLastBackup
            this.lblLastBackup.AutoSize = false;
            this.lblLastBackup.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblLastBackup.ForeColor = System.Drawing.Color.DimGray;
            this.lblLastBackup.Location = new System.Drawing.Point(12, 110);
            this.lblLastBackup.Size = new System.Drawing.Size(360, 40);
            this.lblLastBackup.Name = "lblLastBackup";
            this.lblLastBackup.Text = "Checking last backup...";
            this.lblLastBackup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // Frmbackup
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 170);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnbackup);
            this.Controls.Add(this.lblLastBackup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Frmbackup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Database Backup";
            this.Load += new System.EventHandler(this.Frmbackup_Load);
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Button btnbackup;
        private System.Windows.Forms.Label lblLastBackup;
        private System.Windows.Forms.Label lblTitle;
    }
}