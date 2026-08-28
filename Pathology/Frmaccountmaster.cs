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
    public partial class Frmaccountmaster : Form
    {
        SqlConnection con;
        DataSet ds, ds1;
        SqlDataAdapter da, da1;
        SqlCommand cmd;
        SqlDataReader dr;
        
        public Frmaccountmaster()
        {
            InitializeComponent();
        }

        private void Frmaccountmaster_Load(object sender, EventArgs e)
        {
            Class1 objclass = new Class1();
            con = new SqlConnection(objclass.arun_con());
            con.Open();

            da = new SqlDataAdapter("select (acdes) from account_master ORDER BY ACDES", con);
            ds = new DataSet();
            da.Fill(ds);

            //da = new SqlDataAdapter("select  flno,name from shrmst01", con);
            //ds = new DataSet();
            ////ds.Clear();
            //da.Fill(ds);

            //this.cboaccountname.DataSource = ds.Tables[0];

            //cboaccountname.DisplayMember = "acdes";
            ////cboaccountname.ValueMember = "acdes";

            //con.Close();
            //da.Dispose();

            // cboaccountname.SelectedIndex = -1;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                this.cboaccountname.Items.Add(ds.Tables[0].Rows[i][0].ToString());

            }

            da = new SqlDataAdapter("select DISTINCT (grpname) from mstgrp ORDER BY GRPNAME ", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                this.cbogrp.Items.Add(ds.Tables[0].Rows[i][0].ToString());

            }
            da.Dispose();

            da = new SqlDataAdapter("select DISTINCT (s_group) from mstgrp ", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                this.cbosgr.Items.Add(ds.Tables[0].Rows[i].ItemArray[0].ToString());

            }
            txtpin.Text = "0";
            txtopeningbal.Text = "0.00";
            txtgcd.Enabled = false;
            txtscd.Enabled = false;
            btndelete.Enabled = false;
            btnupdate.Enabled = false;
            btnprint.Enabled = true;
            label8.Hide();
            txtzone.Hide();
        }

        private void cboaccountname_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Close();
            con.Open();

            if (this.cboaccountname.Text != "")
            {

                da = new SqlDataAdapter("select partyId,acdes,grpname,gcd,s_group,scd,add1,city,pin,zone,phone,fax,email,vatno,cstno,dl_no,opening_bal,dr_cr from account_master where acdes= '" + this.cboaccountname.SelectedItem + "'", con);
                //cmd.Connection = con;
                //cmd.ExecuteNonQuery();
                ds = new DataSet();
                da.Fill(ds);

                this.btnadd.Enabled = false;
                this.btndelete.Enabled = true;
                this.btnupdate.Enabled = true;
                this.btncancel.Enabled = true;
                this.btnprint.Enabled = false;
                this.txtaccountid.Enabled = false;
                //dr.Close();
                //dr = cmd.ExecuteReader();
                //while (ds.Tables [0].Rows.Read())
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {

                    this.txtaccountid.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    this.cboaccountname.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    this.cbogrp.Text = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                    txtgcd.Text = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                    this.cbosgr.Text = ds.Tables[0].Rows[i].ItemArray[4].ToString();
                    this.txtscd.Text = ds.Tables[0].Rows[i].ItemArray[5].ToString();
                    this.txtaddress.Text = ds.Tables[0].Rows[i].ItemArray[6].ToString();
                    this.txtcity.Text = ds.Tables[0].Rows[i].ItemArray[7].ToString();
                    this.txtpin.Text = ds.Tables[0].Rows[i].ItemArray[8].ToString();
                    this.txtzone.Text = ds.Tables[0].Rows[i].ItemArray[9].ToString();
                    this.txtphone.Text = ds.Tables[0].Rows[i].ItemArray[10].ToString();
                    this.txtfax.Text = ds.Tables[0].Rows[i].ItemArray[11].ToString();
                    this.txtemail.Text = ds.Tables[0].Rows[i].ItemArray[12].ToString();
                    this.txtvatno.Text = ds.Tables[0].Rows[i].ItemArray[13].ToString();
                    this.txtcstno.Text = ds.Tables[0].Rows[i].ItemArray[14].ToString();
                    this.txtdlno.Text = ds.Tables[0].Rows[i].ItemArray[15].ToString();
                    this.txtopeningbal.Text = ds.Tables[0].Rows[i].ItemArray[16].ToString();
                    this.txtdr_cr.Text = ds.Tables[0].Rows[i].ItemArray[17].ToString();




                }
                //dr.Close();
            }
            else
            {
                //btnNew.Enabled = true;
                //button2.Enabled = true;
                //button3.Enabled = true;
                //button5.Enabled = true;
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            cmd = new SqlCommand("select max(convert(int,partyid)) from account_master", con);
            cmd.ExecuteNonQuery();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int j = Convert.ToInt32(dr[0].ToString()) + 1;
                txtaccountid.Text = j.ToString();
                //MessageBox.Show(j.ToString());
            }
            dr.Close();

            if (MessageBox.Show("Save ? ", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (txtpin.Text == "")
                {
                    txtpin.Text = "0";
                }
                if (txtopeningbal.Text == "")
                {
                    txtopeningbal.Text = "0.00";
                }

                cboaccountname.Text = cboaccountname.Text.Replace("'", "''");
                cbogrp.Text = cbogrp.Text.Replace("'", "''");
                cbosgr.Text = cbosgr.Text.Replace("'", "''");

                txtaddress.Text = txtaddress.Text.Replace("'", "''");
                txtcity.Text = txtcity.Text.Replace("'", "''");

                if (cbosgr.Text == "Cash/Bank")
                {
                    txtgcd.Text = "3";
                    txtscd.Text = "2";
                }
                if (cbosgr.Text == "Customer")
                {
                    txtgcd.Text = "3";
                    txtscd.Text = "1";
                }
                if (cbosgr.Text == "Supplier")
                {
                    txtgcd.Text = "5";
                    txtscd.Text = "1";
                }
                if (cbosgr.Text == "Expense")
                {
                    txtgcd.Text = "80";
                    txtscd.Text = "1";
                }
                cmd = new SqlCommand("insert into account_master (partyId,acdes,grpname,gcd,s_group,scd,add1,city,pin,zone,phone,fax,email,vatno,cstno,dl_no,opening_bal,dr_cr) values('" + Convert.ToInt32(txtaccountid.Text) + "','" + this.cboaccountname.Text + "','" + cbogrp.Text + "','" + txtgcd.Text + "','" + cbosgr.Text + "','" + txtscd.Text + "','" + this.txtaddress.Text + "','" + this.txtcity.Text + "','" + Convert.ToInt32(txtpin.Text) + "','" + txtzone.Text + "','" + this.txtphone.Text + "','" + this.txtfax.Text + "','" + this.txtemail.Text + "','" + this.txtvatno.Text + "','" + this.txtcstno.Text + "','" + this.txtdlno.Text + "','" + this.txtopeningbal.Text + "','" + this.txtdr_cr.Text.Trim() + "')");
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Saved!!", "Account Data",
        MessageBoxButtons.OK, MessageBoxIcon.Information);
                // MessageBox.Show("Insert,Ok");
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Update ? ", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                con.Close();
                con.Open();

                if (txtpin.Text == "")
                {
                    txtpin.Text = "0";
                }
                if (txtopeningbal.Text == "")
                {
                    txtopeningbal.Text = "0.00";
                }
                cboaccountname.Text = cboaccountname.Text.Replace("'", "''");
                cbogrp.Text = cbogrp.Text.Replace("'", "''");
                cbosgr.Text = cbosgr.Text.Replace("'", "''");

                txtaddress.Text = txtaddress.Text.Replace("'", "''");
                txtcity.Text = txtcity.Text.Replace("'", "''");

                if (cbosgr.Text == "Cash/Bank")
                {
                    txtgcd.Text = "3";
                    txtscd.Text = "2";
                }
                if (cbosgr.Text == "Customer")
                {
                    txtgcd.Text = "3";
                    txtscd.Text = "1";
                }
                if (cbosgr.Text == "Supplier")
                {
                    txtgcd.Text = "5";
                    txtscd.Text = "1";
                }

                if (cbosgr.Text == "Expense")
                {
                    txtgcd.Text = "80";
                    txtscd.Text = "1";
                }

                cmd = new SqlCommand("update account_master set grpname='" + cbogrp.Text + "',gcd='" + txtgcd.Text + "',s_group='" + cbosgr.Text + "',scd='" + txtscd.Text + "',add1 = '" + txtaddress.Text + "',city='" + txtcity.Text + "',pin='" + Convert.ToInt32(txtpin.Text) + "',zone='" + txtzone.Text + "',phone='" + txtphone.Text + "',fax='" + this.txtfax.Text + "',email='" + txtemail.Text + "',Vatno = '" + this.txtvatno.Text + "',cstno= '" + this.txtcstno.Text + "',dl_no='" + txtdlno.Text + "',opening_bal = '" + Convert.ToDouble(txtopeningbal.Text) + "',dr_cr = '" + txtdr_cr.Text + "' where acdes='" + this.cboaccountname.Text + "'");
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                //     cmd.CommandText = "update company set comp = '" + cbocompanyname.Text + "',address = '" + txtaddress.text + "',Vatno = '" + txtvatno.text + "',cstno = '" + txtcstno.text + "',year_start = '" + comboBox1.SelectedItem + "',divient = '" + txtdvnt.Text + "',amountinvested =  '" + txtamount.Text + "',Date1 = '" + dateTimePicker1.Text + "',companyissued = '" + txtcomp.Text + "',pvccode = '" + txtpvccode.Text + "',password1 = '" + txtpwd.Text + "',PanNo = '" + txtpno.Text + "' where userid='" + comboBox2.SelectedItem + "'";
                MessageBox.Show("Data Saved!!", "Account Data",
        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("delete account_master  where acdes='" + this.cboaccountname.Text + "'");
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Deleted!!", "Account Data",
       MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnprint_Click(object sender, EventArgs e)
        {

        }

        private void txtaddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cbosgr_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
