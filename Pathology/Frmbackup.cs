using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Pathology
{
    public partial class Frmbackup : Form
    {
        public Frmbackup()
        {
            InitializeComponent();
        }

        private void btnbackup_Click(object sender, EventArgs e)
        {
            try
            {
                // Let user choose backup folder
                using (FolderBrowserDialog dlg = new FolderBrowserDialog())
                {
                    dlg.Description = "Select folder to save database backup";
                    dlg.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    if (dlg.ShowDialog() != DialogResult.OK) return;

                    string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                    string backupFile = Path.Combine(dlg.SelectedPath, $"pathology2627_backup_{timestamp}.bak");

                    Class1 objclass = new Class1();
                    using (SqlConnection con = new SqlConnection(objclass.arun_con()))
                    {
                        con.Open();
                        string sql = $"BACKUP DATABASE [pathology2627] TO DISK = @backupFile WITH FORMAT, INIT, NAME = 'Pathology Full Backup', SKIP, NOREWIND, NOUNLOAD, STATS = 10";
                        using (SqlCommand cmd = new SqlCommand(sql, con))
                        {
                            cmd.CommandTimeout = 300; // 5 minutes
                            cmd.Parameters.AddWithValue("@backupFile", backupFile);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show(
                        $"✅ Backup completed successfully!\n\nSaved to:\n{backupFile}",
                        "Backup Successful",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"❌ Backup failed!\n\nError: {ex.Message}\n\nMake sure SQL Server has write permission to the selected folder.",
                    "Backup Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Frmbackup_Load(object sender, EventArgs e)
        {
            // Show last backup info if available
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var backups = Directory.GetFiles(desktopPath, "pathology2627_backup_*.bak");
            if (backups.Length > 0)
            {
                Array.Sort(backups);
                string last = backups[backups.Length - 1];
                FileInfo fi = new FileInfo(last);
                lblLastBackup.Text = $"Last backup: {fi.Name} ({Math.Round(fi.Length / 1024.0 / 1024.0, 1)} MB) on {fi.LastWriteTime:dd/MM/yyyy HH:mm}";
            }
            else
            {
                lblLastBackup.Text = "Last backup: Never (⚠️ Please backup now!)";
                lblLastBackup.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
