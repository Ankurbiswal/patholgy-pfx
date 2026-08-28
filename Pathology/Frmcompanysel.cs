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
    public partial class Frmcompanysel : Form
    {
        SqlConnection con;
        DataSet ds;
        SqlDataAdapter da;
        SqlCommand cmd;
        SqlDataReader dr;
        DateTime yrs;
        DateTime yre;
        //Class1 c1;
        public Frmcompanysel()
        {
            InitializeComponent();
        }

        private void cbocompanyname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbocompanyname.Text != "")
            {

                cmd = new SqlCommand("select  Cc,Comp,year_start,year_end from company where comp= '" + cbocompanyname.SelectedItem + "'");
                cmd.Connection = con;

                this.btncancel.Enabled = true;
                this.btnprint.Enabled = true;
                this.txtcompanyid.Enabled = false;
                // DateTime yrs;
                // DateTime yre;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    this.txtcompanyid.Text = dr.GetValue(0).ToString();
                    this.cbocompanyname.Text = dr.GetValue(1).ToString();
                    yrs = Convert.ToDateTime(dr.GetValue(2).ToString());
                    yre = Convert.ToDateTime(dr.GetValue(3).ToString());
                    //this.txtfax_no.Text = dr.GetValue(4).ToString();
                    //this.txtvatno.Text = dr.GetValue(5).ToString();
                    //this.txtcst_no.Text = dr.GetValue(6).ToString();
                    ////this.txtdlno.Text = dr.GetValue(7).ToString();
                    //this.dtyearstart.Text = dr.GetValue(7).ToString();
                    //this.dtyearend.Text = dr.GetValue(8).ToString();



                }
                dr.Close();
            }
            else
            {
                //btnNew.Enabled = true;
                //button2.Enabled = true;
                //button3.Enabled = true;
                //button5.Enabled = true;
            }
            //con.Close();
        }

        private void Frmcompanysel_Load(object sender, EventArgs e)
        {
            //con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Pathology;Persist Security Info=True;User ID=sa;Password=software;");
            Class1 objclass = new Class1();
            con = new SqlConnection(objclass.arun_con());
            
            con.Open();
            //c1.open();

            da = new SqlDataAdapter("select comp from company ", con);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    cbocompanyname.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                }

                cbocompanyname.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Add a Company First!");
            }

        }

        private void btnprint_Click(object sender, EventArgs e)
        {

            cmd = new SqlCommand("update setup set cc='" + txtcompanyid.Text + "' ,comp='" + cbocompanyname.SelectedItem + "',year_start='" + yrs + "',year_end='" + yre + "'");
            cmd.Connection = con;
            //dr.Close();
            cmd.ExecuteNonQuery();
            //     cmd.CommandText = "update company set comp = '" + cbocompanyname.Text + "',address = '" + txtaddress.text + "',Vatno = '" + txtvatno.text + "',cstno = '" + txtcstno.text + "',year_start = '" + comboBox1.SelectedItem + "',divient = '" + txtdvnt.Text + "',amountinvested =  '" + txtamount.Text + "',Date1 = '" + dateTimePicker1.Text + "',companyissued = '" + txtcomp.Text + "',pvccode = '" + txtpvccode.Text + "',password1 = '" + txtpwd.Text + "',PanNo = '" + txtpno.Text + "' where userid='" + comboBox2.SelectedItem + "'";
            MessageBox.Show("Company Selected");
            //comboBox2.Items.Remove (gcl.dr.GetValue(gcl.i));
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}