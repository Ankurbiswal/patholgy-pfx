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
    public partial class Frmreferal : Form
    {
        SqlConnection con;
        DataSet ds;
        SqlDataAdapter da;
        SqlCommand cmd;
        SqlDataReader dr;
        public Frmreferal()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void Frmreferal_Load(object sender, EventArgs e)
        {
            Class1 objclass = new Class1();
            con = new SqlConnection(objclass.arun_con());
            con.Open();

            da = new SqlDataAdapter("select Name from referal  order by name ", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                cbocompanyname.Items.Add(ds.Tables[0].Rows[i].ItemArray[0].ToString());
            }
            txtrefper.Text = "0.00";
            btndelete.Enabled = false;
            btnupdate.Enabled = false;
            btnprint.Enabled = false;
        }

        private void txtbiochemist_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbocompanyname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbocompanyname.Text != "")
            {

                cmd = new SqlCommand("select  Cc,Name,Address,TELPHONENO,FAXNO,Pathologist,Biochemist,refper from referal  where name= '" + cbocompanyname.SelectedItem + "'");
                cmd.Connection = con;
                //cmd.ExecuteNonQuery();

                this.btnadd.Enabled = false;
                this.btndelete.Enabled = true;
                this.btnupdate.Enabled = true;
                this.btncancel.Enabled = true;
                this.btnprint.Enabled = true;
                this.txtcompanyid.Enabled = false;
                //dr.Close();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    this.txtcompanyid.Text = dr.GetValue(0).ToString();
                    this.cbocompanyname.Text = dr.GetValue(1).ToString();
                    this.txtaddress.Text = dr.GetValue(2).ToString();
                    this.txttelephone_no.Text = dr.GetValue(3).ToString();
                    this.txtfax_no.Text = dr.GetValue(4).ToString();
                    this.txtpathologist.Text = dr.GetValue(5).ToString();
                    this.txtbiochemist.Text = dr.GetValue(6).ToString();
                    this.txtrefper.Text = dr.GetValue(7).ToString();
                }
                dr.Close();
            }
            else
            {

            }
           
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select max(cc) from referal ");
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr[0].ToString() != "")
                {
                    int j = Convert.ToInt32(dr[0].ToString()) + 1;
                    txtcompanyid.Text = j.ToString();
                }
                else
                {
                    txtcompanyid.Text = "1";
                }
                //MessageBox.Show(j.ToString());
            }

            dr.Close();
            //{
            //    MessageBox.Show("Already Exists...");
            //}
            if (MessageBox.Show("Save ? ", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (txtrefper.Text == "")
                { txtrefper.Text = "0.00"; }
                
                
                cmd = new SqlCommand("insert into referal  (Cc,Name,Address,TELPHONENO,FAXNO,pathologist,Biochemist,refper) values('" + this.txtcompanyid.Text + "','" + cbocompanyname.Text + "','" + this.txtaddress.Text + "','" + this.txttelephone_no.Text + "','" + this.txtfax_no.Text + "','" + this.txtpathologist.Text + "','" + this.txtbiochemist.Text + "','" + this.txtrefper.Text + "')");
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Update ? ", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                cmd = new SqlCommand("update referal  set Name = '" + cbocompanyname.Text + "',Address = '" + txtaddress.Text + "',TELPHONENO='" + this.txttelephone_no.Text + "',FAXNO='" + this.txtfax_no.Text + "',pathologist='" + this.txtpathologist.Text + "',Biochemist='" + this.txtbiochemist.Text + "',refper='" + this.txtrefper.Text + "' where Name='" + cbocompanyname.SelectedItem + "'");
                cmd.Connection = con;
                dr.Close();
                //Cc,Comp,Address,TELPHONENO,FAXNO,Vatno,cstno,year_start,year_end
                cmd.ExecuteNonQuery();
                //     cmd.CommandText = "update company set comp = '" + cbocompanyname.Text + "',address = '" + txtaddress.text + "',Vatno = '" + txtvatno.text + "',cstno = '" + txtcstno.text + "',year_start = '" + comboBox1.SelectedItem + "',divient = '" + txtdvnt.Text + "',amountinvested =  '" + txtamount.Text + "',Date1 = '" + dateTimePicker1.Text + "',companyissued = '" + txtcomp.Text + "',pvccode = '" + txtpvccode.Text + "',password1 = '" + txtpwd.Text + "',PanNo = '" + txtpno.Text + "' where userid='" + comboBox2.SelectedItem + "'";
                MessageBox.Show("Record Updated");
                //comboBox2.Items.Remove (gcl.dr.GetValue(gcl.i));
                // variables frm = new variables();

                //frm.name = cbocompanyname.Text;
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
                cmd = new SqlCommand("delete from referal where Name='" + cbocompanyname.Text + "'");
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
