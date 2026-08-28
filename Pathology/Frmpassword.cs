using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Pathology
{
    public partial class Frmpassword : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        public static int pcode_del_tag = 0;
        public static String userid1 = "";
        public static String passwd1 = "";
        public static String usrname1 = "";
        public static String usrtype1 = "";
        public Frmpassword()
        {
            InitializeComponent();
        }
        private void Frmpassword_Load(object sender, EventArgs e)
        {
            Class1 objclass = new Class1();
            con = new SqlConnection(objclass.arun_con());
            con.Open();
            txtuserid.Text = "Admin";
            txtuserid.Focus();
        }
        private void txtuserid_Validating(object sender, CancelEventArgs e)
        {
            if (txtuserid.Text == "" || txtuserid.Text == null)
            {
                MessageBox.Show("User Id can't be blank");
                txtuserid.Focus();
            }
            }
        private void Frmpassword_KeyDown(object sender, KeyEventArgs e)
        {
            Control nextControl;
            if (e.KeyCode == Keys.Enter)
            {
                nextControl = GetNextControl(ActiveControl, !e.Shift);
                if (nextControl == null)
                    nextControl = GetNextControl(null, true);
                nextControl.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void rbsubmit_Click(object sender, EventArgs e)
        {
            if (txtuserid.Text == null || txtuserid.Text.Trim() == "")
            {
                MessageBox.Show("User Id can't be blank"); txtuserid.Focus(); return;
            }
            if (txtpassword.Text == null || txtpassword.Text.Trim() == "")
            {
                MessageBox.Show("Password can't be blank"); txtpassword.Focus(); return;
            }

            // Parameterized query — no SQL injection possible
            cmd = new SqlCommand(
                "SELECT userid, password, username, type FROM usermaster WHERE userid = @uid",
                con);
            cmd.Parameters.AddWithValue("@uid", txtuserid.Text.Trim());
            dr = cmd.ExecuteReader();

            bool found = false;
            string storedPass = "";
            while (dr.Read())
            {
                found = true;
                userid1  = dr.GetValue(0).ToString();
                storedPass = dr.GetValue(1).ToString();
                usrname1 = dr.GetValue(2).ToString();
                usrtype1 = dr.GetValue(3).ToString();
            }
            dr.Close();

            if (!found || txtpassword.Text.Trim() != storedPass.Trim())
            {
                MessageBox.Show("Invalid User Name / Password", "Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtpassword.Clear();
                txtpassword.Focus();
                return;
            }

            passwd1 = storedPass;
            Frmmainmenu frmm = new Frmmainmenu();
            frmm.Show();
        }

        private void rblogincancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

       
    }
}