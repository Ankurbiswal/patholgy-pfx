using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Pathology
{
    public partial class Frmportsetup : Form
    {
        SqlConnection con;
        SqlCommand cmd, cmd1;
        SqlDataAdapter da;
        DataSet ds, ds0;
        SqlDataReader dr;
        
        
        public Frmportsetup()
        {
            InitializeComponent();
        }

        private void parity2_TextChanged(object sender, EventArgs e)
        {
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void Frmportsetup_Load(object sender, EventArgs e)
        {
            Class1 objclass = new Class1();
            con = new SqlConnection(objclass.arun_con());
            con.Open();
            cmd = new SqlCommand("select baudrate1,databits1,parity1,stopbits1,dtrenables11,handshake1,dtrenables12 from wbs1");
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                baudrate1.Text = dr.GetValue(0).ToString();
                databits1.Text = dr.GetValue(1).ToString();
                parity1.Text = dr.GetValue(2).ToString();
                stopbits1.Text = dr.GetValue(3).ToString();
                dtrenable11.Text = dr.GetValue(4).ToString();
                handshake1.Text = dr.GetValue(5).ToString();
                dtrenable12.Text = dr.GetValue(6).ToString();
            }
            dr.Close();


        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            cmd1 = new SqlCommand("update wbs1 set baudrate1='" + baudrate1.Text + "',databits1='" + databits1.Text + "',parity1='" + parity1.Text + "',stopbits1='" + stopbits1.Text + "',dtrenables11='" + dtrenable11.Text + "',handshake1='" + handshake1.Text + "',dtrenables12='" + dtrenable12.Text + "'  ");
            cmd1.Connection = con;
            cmd1.ExecuteNonQuery();
        }
    }
}
