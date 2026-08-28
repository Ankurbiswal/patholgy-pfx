using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Pathology
{
    public partial class Frmpending : Form
    {
        SqlConnection con;

        public Frmpending()
        {
            InitializeComponent();
        }

        private void Frmpending_Load(object sender, EventArgs e)
        {
            Class1 objclass = new Class1();
            con = new SqlConnection(objclass.arun_con());
            con.Open();
            LoadPending();
        }

        private void LoadPending()
        {
            string filter = cboStatus.SelectedItem?.ToString() ?? "Pending";
            string sql = filter == "All"
                ? "SELECT pcode, patient_name, age, sex, doctor, date_exam, tpt AS Tests, ISNULL(report_status,'Pending') AS Status FROM patient_master WHERE del_tag IS NULL OR del_tag=0 ORDER BY date_exam DESC"
                : "SELECT pcode, patient_name, age, sex, doctor, date_exam, tpt AS Tests, ISNULL(report_status,'Pending') AS Status FROM patient_master WHERE (ISNULL(report_status,'Pending')=@status) AND (del_tag IS NULL OR del_tag=0) ORDER BY date_exam DESC";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            if (filter != "All") da.SelectCommand.Parameters.AddWithValue("@status", filter);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgv.DataSource = ds.Tables[0];

            // Style
            dgv.Columns["pcode"].HeaderText = "ID";
            dgv.Columns["pcode"].Width = 50;
            dgv.Columns["patient_name"].HeaderText = "Patient Name";
            dgv.Columns["patient_name"].Width = 160;
            dgv.Columns["age"].Width = 40;
            dgv.Columns["sex"].Width = 45;
            dgv.Columns["doctor"].HeaderText = "Doctor";
            dgv.Columns["doctor"].Width = 120;
            dgv.Columns["date_exam"].HeaderText = "Date";
            dgv.Columns["date_exam"].Width = 90;
            dgv.Columns["Tests"].Width = 180;
            dgv.Columns["Status"].Width = 80;

            // Color code rows
            foreach (DataGridViewRow row in dgv.Rows)
            {
                string status = row.Cells["Status"].Value?.ToString();
                if (status == "Pending") row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235);
                else if (status == "Ready") row.DefaultCellStyle.BackColor = Color.FromArgb(235, 255, 235);
                else if (status == "Delivered") row.DefaultCellStyle.BackColor = Color.FromArgb(235, 235, 255);
            }

            lblCount.Text = $"Showing {ds.Tables[0].Rows.Count} record(s) — Status: {filter}";
        }

        private void UpdateStatus(string newStatus)
        {
            if (dgv.SelectedRows.Count == 0) { MessageBox.Show("Please select a patient row first."); return; }
            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                string pcode = row.Cells["pcode"].Value?.ToString();
                SqlCommand cmd = new SqlCommand("UPDATE patient_master SET report_status=@status" +
                    (newStatus == "Delivered" ? ",delivered_on=GETDATE()" : "") +
                    " WHERE pcode=@pcode", con);
                cmd.Parameters.AddWithValue("@status", newStatus);
                cmd.Parameters.AddWithValue("@pcode", pcode);
                cmd.ExecuteNonQuery();
            }
            LoadPending();
        }

        private void btnReady_Click(object sender, EventArgs e) => UpdateStatus("Ready");
        private void btnDelivered_Click(object sender, EventArgs e) => UpdateStatus("Delivered");
        private void btnPending_Click(object sender, EventArgs e) => UpdateStatus("Pending");
        private void btnRefresh_Click(object sender, EventArgs e) => LoadPending();
        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e) => LoadPending();

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (con?.State == System.Data.ConnectionState.Open) con.Close();
            base.OnFormClosing(e);
        }
    }
}
