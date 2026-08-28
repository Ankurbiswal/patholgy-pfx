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
    public partial class Frmcompany : Form
    {
        SqlConnection con;
        DataSet ds;
        SqlDataAdapter da;
        SqlCommand cmd;
        SqlDataReader dr;
        //Class1  c1;
        public Frmcompany()
        {
            InitializeComponent();
        }

        private void Frmcompany_Load(object sender, EventArgs e)
        {
           //con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Pathology;Persist Security Info=True;User ID=sa;Password=software;");
            Class1 objclass = new Class1();
            con = new SqlConnection(objclass.arun_con());
            
            con.Open();
          
            da = new SqlDataAdapter("select comp from company ", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                cbocompanyname.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }

            btndelete.Enabled = false;
            btnupdate.Enabled = false;
            btnprint.Enabled = false;
            //this.WindowState = FormWindowState.Maximized;
        }

        private void cbocompanyname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbocompanyname.Text != "")
            {

                cmd = new SqlCommand("select  Cc,Comp,Address,TELPHONENO,FAXNO,Vatno,cstno,year_start,year_end,Pathologist,Biochemist,address1 from company where comp= '" + cbocompanyname.SelectedItem + "'");
                cmd.Connection = con;
                

                this.btnadd.Enabled = false;
                this.btndelete.Enabled = true;
                this.btnupdate.Enabled = true;
                this.btncancel.Enabled = true;
                this.btnprint.Enabled = true;
                this.txtcompanyid.Enabled = false;
              
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    this.txtcompanyid.Text = dr.GetValue(0).ToString();
                    this.cbocompanyname.Text = dr.GetValue(1).ToString();
                    this.txtaddress.Text = dr.GetValue(2).ToString();
                    this.txttelephone_no.Text = dr.GetValue(3).ToString();
                    this.txtfax_no.Text = dr.GetValue(4).ToString();
                    this.txtvatno.Text = dr.GetValue(5).ToString();
                    this.txtcst_no.Text = dr.GetValue(6).ToString();
                    //this.txtdlno.Text = dr.GetValue(7).ToString();
                    this.dtyearstart.Text = dr.GetValue(7).ToString();
                    this.dtyearend.Text = dr.GetValue(8).ToString();
                    this.txtpathologist.Text = dr.GetValue(9).ToString();
                    this.txtbiochemist.Text = dr.GetValue(10).ToString();
                  this.txtdlno.Text = dr.GetValue(11).ToString();

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

        private void btnadd_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select count(cc) from Company");
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int j = Convert.ToInt32(dr[0].ToString()) + 1;
                txtcompanyid.Text = j.ToString();
                MessageBox.Show(j.ToString());
            }

            dr.Close();
            //{
            //    MessageBox.Show("Already Exists...");
            //}
            DateTime dtf, dtt;
            String dd = dtyearstart.Text.Substring(0, 2).ToString();
            String mmm = this.dtyearstart.Text.Substring(3, 2).ToString();
            String yy = this.dtyearstart.Text.Substring(6, 4).ToString();
            dtf = DateTime.ParseExact(dd + "/" + mmm + "/" + yy, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            String dd1 = dtyearend.Text.Substring(0, 2).ToString();
            String mmm1 = this.dtyearend.Text.Substring(3, 2).ToString();
            String yy1 = this.dtyearend.Text.Substring(6, 4).ToString();
            dtt = DateTime.ParseExact(dd1 + "/" + mmm1 + "/" + yy1, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            
            if (MessageBox.Show("Save ? ", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                cmd = new SqlCommand("insert into company (Cc,Comp,Address,TELPHONENO,FAXNO,Vatno,cstno,year_start,year_end,pathologist,biochemist,address1) values('" + this.txtcompanyid.Text + "','" + cbocompanyname.Text + "','" + this.txtaddress.Text + "','" + this.txttelephone_no.Text + "','" + this.txtfax_no.Text + "','" + this.txtvatno.Text + "','" + this.txtcst_no.Text + "','" + dtf.ToString("yyyy-MM-dd") + "','" + dtt.ToString("yyyy-MM-dd") + "','" + this.txtpathologist.Text.Trim() + "','" + this.txtbiochemist.Text.Trim() + "','" + this.txtdlno.Text.Trim() + "')");
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            DateTime dtf, dtt;
            String dd = dtyearstart.Text.Substring(0, 2).ToString();
            String mmm = this.dtyearstart.Text.Substring(3, 2).ToString();
            String yy = this.dtyearstart.Text.Substring(6, 4).ToString();
            dtf = DateTime.ParseExact(dd + "/" + mmm + "/" + yy, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            String dd1 = dtyearend.Text.Substring(0, 2).ToString();
            String mmm1 = this.dtyearend.Text.Substring(3, 2).ToString();
            String yy1 = this.dtyearend.Text.Substring(6, 4).ToString();
            dtt = DateTime.ParseExact(dd1 + "/" + mmm1 + "/" + yy1, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            
            
            if (MessageBox.Show("Do You Want Update ? ", "Update", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                cmd = new SqlCommand("update company set comp = '" + cbocompanyname.Text + "',Address = '" + txtaddress.Text + "',TELPHONENO='" + this.txttelephone_no.Text + "',FAXNO='" + this.txtfax_no.Text + "',Vatno = '" + this.txtvatno.Text + "',cstno = '" + this.txtcst_no.Text + "',year_start = '" + dtf.ToString("yyyy-MM-dd") + "',year_end = '" + dtt.ToString("yyyy-MM-dd") + "',pathologist = '" + this.txtpathologist.Text + "',biochemist = '" + this.txtbiochemist.Text + "',address1='" + this.txtdlno.Text.Trim() + "' where comp='" + cbocompanyname.Text + "'");
                cmd.Connection = con;
                dr.Close();
             
                cmd.ExecuteNonQuery();
              
                MessageBox.Show("Record Updated");
               
            }
         

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Delete ? ", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                cmd = new SqlCommand("delete from company where comp='" + cbocompanyname.Text + "'");
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("update setup set cc='" + txtcompanyid.Text + "' ,comp='" + cbocompanyname.SelectedItem + "'");
            cmd.Connection = con;
            //dr.Close();
            cmd.ExecuteNonQuery();
            //     cmd.CommandText = "update company set comp = '" + cbocompanyname.Text + "',address = '" + txtaddress.text + "',Vatno = '" + txtvatno.text + "',cstno = '" + txtcstno.text + "',year_start = '" + comboBox1.SelectedItem + "',divient = '" + txtdvnt.Text + "',amountinvested =  '" + txtamount.Text + "',Date1 = '" + dateTimePicker1.Text + "',companyissued = '" + txtcomp.Text + "',pvccode = '" + txtpvccode.Text + "',password1 = '" + txtpwd.Text + "',PanNo = '" + txtpno.Text + "' where userid='" + comboBox2.SelectedItem + "'";
            MessageBox.Show("Company Selected");
            this.Close();
            //comboBox2.Items.Remove (gcl.dr.GetValue(gcl.i));
        }

        private void Frmcompany_KeyDown(object sender, KeyEventArgs e)
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

        private void txtaddress_Enter(object sender, EventArgs e)
        {
            this.KeyPreview = false;
        }

        private void txtaddress_Leave(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

       
    }
}