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
    public partial class Frmproductmaster : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        DataSet ds, ds1, ds2;
        SqlDataAdapter da;
        SqlDataReader dr;
        
        public Frmproductmaster()
        {
            InitializeComponent();
        }

        private void Frmproductmaster_Load(object sender, EventArgs e)
        {
            //con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=pathology;Persist Security Info=True;User ID=sa;Password=software;");
            Class1 objclass = new Class1();
            con = new SqlConnection(objclass.arun_con());
            con.Open();

            da = new SqlDataAdapter("select DISTINCT (item) from product_master", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                this.cboitem.Items.Add(ds.Tables[0].Rows[i].ItemArray[0].ToString());
            }
            da = new SqlDataAdapter("select DISTINCT (grpname) from itmgrp", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                this.cbogroup.Items.Add(ds.Tables[0].Rows[i].ItemArray[0].ToString());
            }
            txtreorder.Text = "0";
            txtopqty.Text = "0";
            txtvalue.Text = "0.00";
            txtsalerate.Text = "0.00";
            txtsubgroup.Enabled = false;
            txtgroup.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnPrint.Enabled = true;

            //txtsalerate.Hide();
            //txtpurchesunit.Hide();
            //txtsaleunit.Hide();
            //label7.Hide();
            //label8.Hide();
            //label10.Hide();
 
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();

            cmd = new SqlCommand("select max(itemid) from product_master");
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr[0].ToString() != "")
                {
                    int j = Convert.ToInt32(dr[0].ToString()) + 1;
                    txtitemid.Text = j.ToString().Trim();
                    //MessageBox.Show(j.ToString());
                }
                else
                {
                    txtitemid.Text = "1";
                }

            }



            dr.Close();

            da = new SqlDataAdapter("select item from product_master where item='" + cboitem.Text + "' ", con);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                if (cbogroup.Text != "" && cbosubgroup.Text != "")
                {

                    if (MessageBox.Show("Save ? ", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        if (txtreorder.Text == "")
                        {
                            txtreorder.Text = "0";
                        }
                        if (txtopqty.Text == "")
                        {
                            txtopqty.Text = "0";
                        }
                        if (txtvalue.Text == "")
                        {
                            txtvalue.Text = "0.00";
                        }
                        if (txtsalerate.Text == "")
                        {
                            txtsalerate.Text = "0.00";
                        }
                        cboitem.Text = cboitem.Text.Replace("'", "''");
                        cbogroup.Text = cbogroup.Text.Replace("'", "''");
                        cbosubgroup.Text = cbosubgroup.Text.Replace("'", "''");
                        txtdesc.Text = txtdesc.Text.Replace("'", "''");
                        cmd = new SqlCommand("insert into product_master (itemid,item,gcd,grpname,scd,sgrpname,itemdes,opqty,opvalue,reorder_qty,unit_s,unit_p,sale_rate) values('" + Convert.ToInt32(txtitemid.Text) + "','" + this.cboitem.Text + "','" + this.txtgroup.Text + "','" + cbogroup.Text + "','" + this.txtsubgroup.Text + "','" + cbosubgroup.Text + "','" + txtdesc.Text + "','" + Convert.ToDouble(txtopqty.Text) + "','" + Convert.ToDouble(txtvalue.Text) + "','" + Convert.ToDouble(txtreorder.Text) + "','" + this.txtpurchesunit.Text + "','" + this.txtsaleunit.Text + "','" + Convert.ToDouble(txtsalerate.Text) + "')");
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record Added");

                    }
                    da.Dispose();
                }
                else
                {
                    MessageBox.Show("Select Item Group and subgroup!! ");
                    cbogroup.Focus();
                }
 
 
 }
            else
            {
                MessageBox.Show("Already exists!!");
                cboitem.Focus ();
            }
            
            
            }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Update ? ", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (txtreorder.Text == "")
                {
                    txtreorder.Text = "0";
                }
                if (txtopqty.Text == "")
                {
                    txtopqty.Text = "0";
                }
                if (txtvalue.Text == "")
                    txtvalue.Text = "0.00";
                if (txtsalerate.Text == "")
                    txtsalerate.Text = "0.00";

                cboitem.Text = cboitem.Text.Replace("'", "''");
                cbogroup.Text = cbogroup.Text.Replace("'", "''");
                cbosubgroup.Text = cbosubgroup.Text.Replace("'", "''");
                txtdesc.Text = txtdesc.Text.Replace("'", "''");


                cmd = new SqlCommand("update product_master set gcd = '" + Convert.ToInt32(txtgroup.Text) + "',grpname='" + cbogroup.Text + "',scd = '" + Convert.ToInt32(txtsubgroup.Text) + "',sgrpname='" + cbosubgroup.Text + "',itemdes= '" + this.txtdesc.Text + "',opqty = '" + Convert.ToDouble(txtopqty.Text) + "',opvalue='" + Convert.ToDouble(txtvalue.Text) + "',reorder_qty='" + Convert.ToDouble(txtreorder.Text) + "',unit_p='" + this.txtpurchesunit.Text + "',unit_s='" + this.txtsaleunit.Text + "',sale_rate='" + Convert.ToDouble(txtsalerate.Text) + "' where item='" + this.cboitem.SelectedItem + "'");
                cmd.Connection = con;
                //dr.Close();
                cmd.ExecuteNonQuery();
                //     cmd.CommandText = "update company set comp = '" + cbocompanyname.Text + "',address = '" + txtaddress.text + "',Vatno = '" + txtvatno.text + "',cstno = '" + txtcstno.text + "',year_start = '" + comboBox1.SelectedItem + "',divient = '" + txtdvnt.Text + "',amountinvested =  '" + txtamount.Text + "',Date1 = '" + dateTimePicker1.Text + "',companyissued = '" + txtcomp.Text + "',pvccode = '" + txtpvccode.Text + "',password1 = '" + txtpwd.Text + "',PanNo = '" + txtpno.Text + "' where userid='" + comboBox2.SelectedItem + "'";
                MessageBox.Show("Record Updated");
                //comboBox2.Items.Remove (gcl.dr.GetValue(gcl.i));
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Delete ? ", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                cmd = new SqlCommand("delete from product_master where item='" + this.cboitem.SelectedItem + "'");
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                //     cmd.CommandText = "update company set comp = '" + cbocompanyname.Text + "',address = '" + txtaddress.text + "',Vatno = '" + txtvatno.text + "',cstno = '" + txtcstno.text + "',year_start = '" + comboBox1.SelectedItem + "',divient = '" + txtdvnt.Text + "',amountinvested =  '" + txtamount.Text + "',Date1 = '" + dateTimePicker1.Text + "',companyissued = '" + txtcomp.Text + "',pvccode = '" + txtpvccode.Text + "',password1 = '" + txtpwd.Text + "',PanNo = '" + txtpno.Text + "' where userid='" + comboBox2.SelectedItem + "'";
                MessageBox.Show("Record Deleted");
                //comboBox2.Items.Remove (gcl.dr.GetValue(gcl.i));
                //dr.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cboitem.Dispose();
            this.Close();
            return;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void cboitem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboitem.Text != "")
            {

                da = new SqlDataAdapter("select itemid,item,gcd,grpname,scd,sgrpname,itemdes,opqty,opvalue,reorder_qty,unit_s,unit_p,sale_rate  from product_master where item= '" + this.cboitem.Text + "'", con);
                
                ds = new DataSet();
                da.Fill(ds, "product_master");
                btnAdd.Enabled = false;
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                btnCancel.Enabled = true;
                btnPrint.Enabled = false;
                this.txtitemid.Enabled = false;
                
                this.txtitemid.Text = ds.Tables[0].Rows[0][0].ToString();
                this.cboitem.Text = ds.Tables[0].Rows[0][1].ToString();
                this.txtgroup.Text = ds.Tables[0].Rows[0][2].ToString();
                cbogroup.Text = ds.Tables[0].Rows[0][3].ToString();
                this.txtsubgroup.Text = ds.Tables[0].Rows[0][4].ToString();
                cbosubgroup.Text = ds.Tables[0].Rows[0][5].ToString();
                this.txtdesc.Text = ds.Tables[0].Rows[0][6].ToString();
                this.txtopqty.Text = ds.Tables[0].Rows[0][7].ToString();
                //this.txtrate.Text = ds.Tables[0].Rows[0][0].ToString();;
                this.txtvalue.Text = ds.Tables[0].Rows[0][8].ToString();
                this.txtreorder.Text = ds.Tables[0].Rows[0][9].ToString();
                this.txtpurchesunit.Text = ds.Tables[0].Rows[0][10].ToString();
                this.txtsaleunit.Text = ds.Tables[0].Rows[0][11].ToString();
                this.txtsalerate.Text = ds.Tables[0].Rows[0][12].ToString();


            }
            da.Dispose();

        }

        private void cbogroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbogroup.Text != "")
            {
                con.Close();
                con.Open();
                da = new SqlDataAdapter("select distinct gcd,grpname from itmgrp where grpname= '" + this.cbogroup.Text + "'", con);
                ds2 = new DataSet();
                da.Fill(ds2);
                txtgroup.Text = ds2.Tables[0].Rows[0][0].ToString();
                cbogroup.Text = ds2.Tables[0].Rows[0][1].ToString();
                da.Dispose();

                da = new SqlDataAdapter("select scd,s_group from itmgrp where grpname= '" + this.cbogroup.Text + "'", con);
                ds2 = new DataSet();
                da.Fill(ds2);
                cbosubgroup.Items.Clear();
                for (int i = 0; i <= ds2.Tables[0].Rows.Count - 1; i++)
                {
                    //txtgroup.Text = ds.Tables[0].Rows[i][0].ToString();
                    cbosubgroup.Items.Add(ds2.Tables[0].Rows[i][1].ToString());
                }
                da.Dispose();


            }
        }

        private void cbosubgroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            if (this.cbosubgroup.Text != "")
            {

                da = new SqlDataAdapter("select scd,s_group from itmgrp where gcd='" + txtgroup.Text + "' and s_group= '" + this.cbosubgroup.Text + "'", con);
                ds1 = new DataSet();
                da.Fill(ds1, "itmgrp");
                txtsubgroup.Text = ds1.Tables[0].Rows[0][0].ToString();
            }
            da.Dispose();

        }

        private void cboitem_TextChanged(object sender, EventArgs e)
        {
            if (cboitem.Text == null || cboitem.Text == " ")
            {
                MessageBox.Show("Product cannot be blank");
                cboitem.Focus();

            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
