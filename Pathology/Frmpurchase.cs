using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO.Ports;
using System.Text.RegularExpressions;
namespace Pathology
{
    
    public partial class Frmpurchase : Form
    {
        SqlConnection con;
        DataSet ds;
        SqlDataAdapter da;
        SqlCommand cmd;
        SqlDataReader dr;

        public Frmpurchase()
        {
            InitializeComponent();
        }

        private void Frmpurchase_Load(object sender, EventArgs e)
        {
            Class1 objclass = new Class1();
            con = new SqlConnection(objclass.arun_con());
            con.Open();
            cbotype.Items.Add("Purchase");
            cbotype.Items.Add("Issue");
            cbotype.SelectedIndex = 0;

            da = new SqlDataAdapter("select cc,comp from setup order by cc", con);
            ds = new DataSet();
            da.Fill(ds);
            txtcompanycode.Text = ds.Tables[0].Rows[0][0].ToString();
            label22.Text = ds.Tables[0].Rows[0][1].ToString();
            txtcompanycode.Enabled = false;



            da = new SqlDataAdapter("select item from product_master  order by item", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                this.dgvitem.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }

            dgvitem.AutoComplete = true;
            da.Dispose();
            da = new SqlDataAdapter("select (acdes) from account_master ORDER BY ACDES", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                this.cbopartyname.Items.Add(ds.Tables[0].Rows[i][0].ToString());

            }
            da.Dispose();


            
        }

        private void cbobillnumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbobillnumber.Text != "")
            {
                //                cmd = new SqlCommand("select cc,type,blno,bldt,challan_no,challan_dt,order_no,order_dt,acdes,transport,gross,excise_rt,excise,discount_rt,discount,vat_rt,vat,cst_rt,cst,advance,tamt from Mrn where type = '"+cbotype.SelectedItem  +"' and blno= '" + this.cbobillnumber.SelectedItem + "'");
                da = new SqlDataAdapter("select cc,type,blno,bldt,acdes,child ,item,qty,unit,rate,gross from Mrn_detail where type = '" + cbotype.SelectedItem + "' and blno= '" + this.cbobillnumber.SelectedItem + "'",con);
                ds = new DataSet();
                da.Fill(ds);

                //cmd.ExecuteNonQuery();

                this.btnadd.Enabled = false;
                this.btndelete.Enabled = true;
                this.btnupdate.Enabled = true;
                this.btncancel.Enabled = true;
                this.btnprint.Enabled = false;
                this.txtcompanycode.Enabled = false;
                
                if (ds.Tables[0].Rows.Count!=0)
                {
                    this.txtcompanycode.Text = ds.Tables[0].Rows[0][0].ToString();
                    this.cbotype.Text = ds.Tables[0].Rows[0][1].ToString();
                    this.cbobillnumber.Text = ds.Tables[0].Rows[0][2].ToString();
                    this.dtpbilldate.Text = ds.Tables[0].Rows[0][3].ToString();
                   
                    this.cbopartyname.Text = ds.Tables[0].Rows[0][4].ToString();
                    this.cbotransport.Text = ds.Tables[0].Rows[0][5].ToString();
                    
                }
               //dr.Close();
            }
            
            int ictr = 0;
            Double tt = 0;
            dgv.Rows.Clear();
            for (ictr = 0; ictr <= ds.Tables[0].Rows.Count - 1; ictr++)
            {

                dgv.Rows.Add(ictr, dgv.Rows.Count + 1);
                //dgv.Rows[ictr].Cells[0].Value = this.cbobillnumber .Text;
                dgv.Rows[ictr].Cells[0].Value = ds.Tables[0].Rows[ictr][6].ToString();
                dgv.Rows[ictr].Cells[1].Value = ds.Tables[0].Rows[ictr][7].ToString();
                dgv.Rows[ictr].Cells[2].Value = ds.Tables[0].Rows[ictr][8].ToString();
                dgv.Rows[ictr].Cells[3].Value = ds.Tables[0].Rows[ictr][9].ToString();
                dgv.Rows[ictr].Cells[4].Value = ds.Tables[0].Rows[ictr][10].ToString();
                tt = tt + Convert.ToDouble (dgv.Rows[ictr].Cells[4].Value);
            
            
            }
            txttotalamt.Text = tt.ToString("#.##");
            con.Close();
            con.Open();
           
           
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Save ? ", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
               
                Double tot = 0;
                String dd = dtpbilldate.Text.Substring(0, 2).ToString();
                String mm = this.dtpbilldate.Text.Substring(3, 2).ToString();
                String yy = this.dtpbilldate.Text.Substring(6, 4).ToString();
                DateTime repdt1 = DateTime.ParseExact(dd + "/" + mm + "/" + yy, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                
                
                
                
                int i;
                for (i = 0; i < dgv.Rows.Count ; i++)
                {
                    if (dgv.Rows[i].Cells[0].Value != null)
                    {

                        con.Close();
                        con.Open();
                        cmd = new SqlCommand("insert into mrn_detail(cc,type,blno,bldt,acdes,child ,item,qty,unit,rate,gross) values('" + txtcompanycode.Text + "','" + cbotype.Text + "','" + cbobillnumber.Text + "','" + repdt1 + "','" + cbopartyname.Text + "','" + cbotransport.Text + "','" + dgv.Rows[i].Cells[0].Value + "','" + Convert.ToDouble(dgv.Rows[i].Cells[1].Value) + "','" + dgv.Rows[i].Cells[2].Value + "','" + Convert.ToDouble(dgv.Rows[i].Cells[3].Value) + "','" + Convert.ToDouble(dgv.Rows[i].Cells[4].Value) + "')");
                        cmd.Connection = con;
                        //cmd.ExecuteNonQuery();
                        try
                        {
                            cmd.ExecuteNonQuery();
                            tot = tot + Convert.ToDouble(dgv.Rows[i].Cells[4].Value);
                        }
                        catch
                        {
                            MessageBox.Show(e.ToString());
                        }
                        finally
                        {
                            con.Close();

                        }

                    }
                }
                con.Close();
                con.Open();
                txttotalamt.Text = tot.ToString();
               
//cbj
                Double gtt = Convert.ToDouble(txttotalamt.Text); //+ Convert.ToDouble(txtadvance.Text);
                String pnarr = "Bill No." + cbobillnumber.Text + " Dated. " + repdt1;
                con.Close();
                con.Open();
                if (cbotype.Text == "Purchase")
                {
                    cmd = new SqlCommand("insert into cbj (cc,trncd,vodt,vono,acdes,amt,dcin,narr) values('" + Convert.ToInt32(txtcompanycode.Text) + "','" + cbotype.Text + "','" + repdt1 + "','" + cbobillnumber.Text + "','" + cbopartyname.Text + "','" + gtt + "','" + "C" + "','" + pnarr + "')", con);
                    cmd.ExecuteNonQuery();
                    //Double gsale = Convert.ToDouble(txttotalamt.Text) + Convert.ToDouble(txtexcise.Text) - Convert.ToDouble(txtdiscount.Text);

                    cmd = new SqlCommand("insert into cbj (cc,trncd,vodt,vono,acdes,amt,dcin,narr) values('" + Convert.ToInt32(txtcompanycode.Text) + "','" + cbotype.Text + "','" + repdt1 + "','" + cbobillnumber.Text + "','Purchase A/c','" + gtt + "','" + "D" + "','" + pnarr + "')", con);

                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd = new SqlCommand("insert into cbj (cc,trncd,vodt,vono,acdes,amt,dcin,narr) values('" + Convert.ToInt32(txtcompanycode.Text) + "','" + cbotype.Text + "','" + repdt1 + "','" + cbobillnumber.Text + "','" + cbopartyname.Text + "','" + gtt + "','" + "D" + "','" + pnarr + "')", con);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("insert into cbj (cc,trncd,vodt,vono,acdes,amt,dcin,narr) values('" + Convert.ToInt32(txtcompanycode.Text) + "','" + cbotype.Text + "','" + repdt1 + "','" + cbobillnumber.Text + "','Purchase A/c','" + gtt + "','" + "C" + "','" + pnarr + "')", con);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Insert,OK");

                cbobillnumber.Text = Convert.ToString(Convert.ToInt32(cbobillnumber.Text) + 1);

                dgv.Rows.Clear();
                //cbj


            
            
            }
           


           
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            cmd = new SqlCommand("delete from Mrn_detail where  cc= '" + txtcompanycode.Text + "' and type='" + this.cbotype.Text + "' and blno = '" + this.cbobillnumber.Text + "'");
            cmd.Connection = con;
            cmd.ExecuteNonQuery();

            String dd = dtpbilldate.Text.Substring(0, 2).ToString();
            String mm = this.dtpbilldate.Text.Substring(3, 2).ToString();
            String yy = this.dtpbilldate.Text.Substring(6, 4).ToString();
            DateTime repdt1 = DateTime.ParseExact(dd + "/" + mm + "/" + yy, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            
            
            
            Double tot = 0;
            int i;
            for (i = 0; i < dgv.Rows.Count ; i++)
            {
                con.Close();
                con.Open();
                if (dgv.Rows[i].Cells[0].Value != null)
                {
                    cmd = new SqlCommand("insert into mrn_detail(cc,type,blno,bldt,acdes,child ,item,qty,unit,rate,gross) values('" + txtcompanycode.Text + "','" + cbotype.Text + "','" + cbobillnumber.Text + "','" + repdt1 + "','" + cbopartyname.Text + "','" + cbotransport.Text + "','" + dgv.Rows[i].Cells[0].Value + "','" + Convert.ToDouble(dgv.Rows[i].Cells[1].Value) + "','" + dgv.Rows[i].Cells[2].Value + "','" + Convert.ToDouble(dgv.Rows[i].Cells[3].Value) + "','" + Convert.ToDouble(dgv.Rows[i].Cells[4].Value) + "')");
                    // cmd = new SqlCommand("insert into Mrn_detail(cc,type,blno,bldt,item,qty_main,unitm,qty,unit,rate,discount_rt,rejected,gross) values( '" + txtcompanycode.Text + "','" + this.cbotype.Text + "','" + this.cbobillnumber.Text + "','"+dtpbilldate .Text+"','" + dgv.Rows[i].Cells[1].Value + "','" + dgv.Rows[i].Cells[2].Value + "','" + dgv.Rows[i].Cells[3].Value + "','" + dgv.Rows[i].Cells[4].Value.ToString() + "','" + dgv.Rows[i].Cells[5].Value + "','" + dgv.Rows[i].Cells[6].Value.ToString() + "','" + dgv.Rows[i].Cells[7].Value + "','" + dgv.Rows[i].Cells[8].Value.ToString() + "','" + dgv.Rows[i].Cells[9].Value.ToString() + "')");
                    // cmd2 = new SqlCommand("insert into invex_detail(blno,item,salenoteno,ides,bales,unt,qty,unit,rate,cvc,gross,gross_wt,net_wt) values('" + COMBOB_INVOICENO.Text + "','" + dataGridView1.Rows[ictr].Cells[1].Value + "','" + dataGridView1.Rows[ictr].Cells[2].Value + "','" + dataGridView1.Rows[ictr].Cells[3].Value + "','" + dataGridView1.Rows[ictr].Cells[4].Value + "','" + dataGridView1.Rows[ictr].Cells[5].Value + "','" + dataGridView1.Rows[ictr].Cells[6].Value + "','" + dataGridView1.Rows[ictr].Cells[7].Value + "','" + dataGridView1.Rows[ictr].Cells[8].Value + "','" + dataGridView1.Rows[ictr].Cells[9].Value + "','" + dataGridView1.Rows[ictr].Cells[10].Value + "','" + dataGridView1.Rows[ictr].Cells[11].Value + "','" + dataGridView1.Rows[ictr].Cells[12].Value + "')", con);
                    cmd.Connection = con;

                    cmd.ExecuteNonQuery();
                    tot = tot + Convert.ToDouble(dgv.Rows[i].Cells[4].Value);
                    //con.Close();
                }
            }
            txttotalamt.Text = tot.ToString();
            //txtgrtot.Text = tot.ToString();
            if (MessageBox.Show("Update ? ", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                cmd = new SqlCommand("delete from cbj where  trncd='" + cbotype.Text + "' and vono = '" + this.cbobillnumber.Text + "'", con);
                cmd.ExecuteNonQuery();
               
                Double gtt = Convert.ToDouble(txttotalamt.Text); //+ Convert.ToDouble(txtadvance.Text);
                String pnarr = "Bill No." + cbobillnumber.Text + " Dated. " + repdt1;
                con.Close();
                con.Open();
                if (cbotype.Text == "Purchase")
                {
                    cmd = new SqlCommand("insert into cbj (cc,trncd,vodt,vono,acdes,amt,dcin,narr) values('" + Convert.ToInt32(txtcompanycode.Text) + "','" + cbotype.Text + "','" + repdt1 + "','" + cbobillnumber.Text + "','" + cbopartyname.Text + "','" + gtt + "','" + "C" + "','" + pnarr + "')", con);
                    cmd.ExecuteNonQuery();
                    //Double gsale = Convert.ToDouble(txttotalamt.Text) + Convert.ToDouble(txtexcise.Text) - Convert.ToDouble(txtdiscount.Text);

                    cmd = new SqlCommand("insert into cbj (cc,trncd,vodt,vono,acdes,amt,dcin,narr) values('" + Convert.ToInt32(txtcompanycode.Text) + "','" + cbotype.Text + "','" + repdt1 + "','" + cbobillnumber.Text + "','Purchase A/c','" + gtt + "','" + "D" + "','" + pnarr + "')", con);

                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd = new SqlCommand("insert into cbj (cc,trncd,vodt,vono,acdes,amt,dcin,narr) values('" + Convert.ToInt32(txtcompanycode.Text) + "','" + cbotype.Text + "','" + repdt1 + "','" + cbobillnumber.Text + "','" + cbopartyname.Text + "','" + gtt + "','" + "D" + "','" + pnarr + "')", con);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("insert into cbj (cc,trncd,vodt,vono,acdes,amt,dcin,narr) values('" + Convert.ToInt32(txtcompanycode.Text) + "','" + cbotype.Text + "','" + repdt1 + "','" + cbobillnumber.Text + "','Purchase A/c','" + gtt + "','" + "C" + "','" + pnarr + "')", con);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Data Changed,OK");
 
            }
      
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            cmd = new SqlCommand("delete from Mrn_detail where  type='" + cbotype.Text + "' and blno = '" + this.cbobillnumber.Text + "'");
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("delete from cbj where  trncd='" + cbotype.Text + "' and vono = '" + this.cbobillnumber.Text + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Open();
          
            //Double gtt = Convert.ToDouble(txttotalamt.Text); //+ Convert.ToDouble(txtadvance.Text);
            //String pnarr = "Bill No." + cbobillnumber.Text + " Dated. " + repdt1;
            //con.Close();
            //con.Open();
          
            MessageBox.Show("Delete,OK");    
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnprint_Click(object sender, EventArgs e)
        {

        }

        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Double tt = 0;

            tt = Convert.ToDouble(dgv.CurrentRow.Cells[1].Value) * Convert.ToDouble(dgv.CurrentRow.Cells[3].Value);
            dgv.CurrentRow.Cells[4].Value = tt .ToString ();

            //dgv.CurrentRow.Cells[8].Value = Convert.ToString(tt - Convert.ToDouble(dgv.CurrentRow.Cells[7].Value));

            Double dbval = 0.00;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv.Rows[i].Cells[0].Value != null)
                {

                    dbval = dbval + (Convert.ToDouble(dgv.Rows[i].Cells[4].Value.ToString()));

                }
            }


            txttotalamt.Text = dbval.ToString("#.##");
        
        


        
        
        }

        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.dgv.CurrentCell.ColumnIndex == 0)
            {
                ComboBox c = e.Control as ComboBox;
                ((ComboBox)c).DropDownStyle = ComboBoxStyle.DropDown;

            }
        }

        private void cbotype_SelectedIndexChanged(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("select distinct blno from Mrn_detail where  type='" + cbotype.SelectedItem + "' order by blno", con);

            ds = new DataSet();
            da.Fill(ds);
            cbobillnumber.Items.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                this.cbobillnumber.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }


            da.Dispose();
            da = new SqlDataAdapter("select max(convert(int,blno)) from Mrn_detail where  type='" + cbotype.Text + "' group by type ", con);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                cbobillnumber.Text = Convert.ToString(Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) + 1);

            }
            else
            {
                cbobillnumber.Text = "1";
            }


            da.Dispose();

        }

        private void cbobillnumber_Validating(object sender, CancelEventArgs e)
        {
            string txt = cbobillnumber.Text;
            var numericPart = Regex.Match(txt, "\\d+").Value;
            //comboBox1.Items.Add(numericPart);
            //listBox1.Items.Add(numericPart);
            if (numericPart != "")
            {
                cbobillnumber.Text = numericPart;
                //btn_wt_value.Focus();
            }
            else
            {
                MessageBox.Show(numericPart + " Please Check the Number? Enter only last Voucher number to Add !!! ");
                cbobillnumber.Focus();
            }
            
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
