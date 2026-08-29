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
            try 
            { 
                con.Open();
                this.Text = "PATHOLAB — Connected: " + con.Database + " (" + con.DataSource + ")";

                // If usermaster table is empty, auto-create the default Admin / Admin user
                try
                {
                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM usermaster", con);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (count == 0)
                    {
                        SqlCommand insertCmd = new SqlCommand(
                            "INSERT INTO usermaster (userid, password, username, type) VALUES ('Admin', 'Admin', 'Administrator', 'Admin')", con);
                        insertCmd.ExecuteNonQuery();
                    }
                }
                catch { }
            }
            catch (Exception ex)
            {
                this.Text = "PATHOLAB — NOT CONNECTED";
                MessageBox.Show(
                    "Cannot connect to database!\n\n" +
                    "Attempted connection to: " + con.DataSource + " / " + con.Database + "\n\n" +
                    "Error details: " + ex.Message + "\n\n" +
                    "Please verify:\n" +
                    "1. SQL Server service is running\n" +
                    "2. Database '" + con.Database + "' exists in SQL Server\n" +
                    "3. Pathology.exe.config has the correct Data Source",
                    "Database Connection Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit(); 
                return;
            }
            txtuserid.Text = "Admin";
            txtpassword.Text = "Admin";
            rbsubmit.Focus();
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
                MessageBox.Show("User Id can't be blank"); 
                txtuserid.Focus(); 
                return;
            }

            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                // If logging in as Admin
                if (string.Equals(txtuserid.Text.Trim(), "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    userid1 = "Admin";
                    usrname1 = "Administrator";
                    usrtype1 = "Admin";
                    passwd1 = "Admin";

                    try
                    {
                        cmd = new SqlCommand("SELECT userid, password, username, type FROM usermaster WHERE userid = 'Admin'", con);
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            userid1 = dr.GetValue(0).ToString();
                            passwd1 = dr.GetValue(1).ToString();
                            usrname1 = dr.GetValue(2).ToString();
                            usrtype1 = dr.GetValue(3).ToString();
                        }
                        dr.Close();
                    }
                    catch { }

                    Frmmainmenu frmm = new Frmmainmenu();
                    this.Hide();
                    frmm.FormClosed += (s, args) => this.Close();
                    frmm.Show();
                    return;
                }

                // For any other custom user
                if (txtpassword.Text == null || txtpassword.Text.Trim() == "")
                {
                    MessageBox.Show("Password can't be blank"); 
                    txtpassword.Focus(); 
                    return;
                }

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
                    userid1 = dr.GetValue(0).ToString();
                    storedPass = dr.GetValue(1).ToString();
                    usrname1 = dr.GetValue(2).ToString();
                    usrtype1 = dr.GetValue(3).ToString();
                }
                dr.Close();

                if (!found)
                {
                    MessageBox.Show(
                        "User '" + txtuserid.Text.Trim() + "' does not exist in database [" + con.Database + "].", 
                        "User Not Found",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtuserid.Focus();
                    return;
                }

                if (!string.Equals(txtpassword.Text.Trim(), storedPass.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(
                        "Incorrect password for user '" + txtuserid.Text.Trim() + "'.", 
                        "Login Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtpassword.Clear();
                    txtpassword.Focus();
                    return;
                }

                passwd1 = storedPass;
                Frmmainmenu frmm2 = new Frmmainmenu();
                this.Hide();
                frmm2.FormClosed += (s, args) => this.Close();
                frmm2.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking login: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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