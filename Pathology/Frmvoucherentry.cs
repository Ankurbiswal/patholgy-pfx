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
    public partial class Frmvoucherentry : Form
    {
        SqlConnection con;
        DataSet ds;
        SqlDataAdapter da;
        SqlCommand cmd;
        //SqlCommand cmd1;
        //SqlCommand cmd2;
        SqlDataReader dr;
        public static int vpcode_del_tag = Frmpassword.pcode_del_tag;
        public static String vuserid1 = Frmpassword.userid1;
        public static String vpasswd1 = Frmpassword.passwd1;
        public static String vusrname1 = Frmpassword.usrname1;
        public static String vusrtype1 = Frmpassword.usrtype1;

        public static String adr = "";
        public static String telp = "";
        
        public Frmvoucherentry()
        {
            InitializeComponent();
        }

        private void Frmvoucherentry_Load(object sender, EventArgs e)
        {
            Class1 objclass = new Class1();
            con = new SqlConnection(objclass.arun_con());
            con.Open();
            cmd = new SqlCommand("select cc,comp,address,telphoneno from company");
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                this.txtcompid.Text = dr.GetValue(0).ToString();
                label4.Text = dr.GetValue(1).ToString();
                adr = dr.GetValue(2).ToString();
                telp = dr.GetValue(3).ToString();
            }
            dr.Close();



            String s = ("select acdes from account_master where gcd=3 and scd=2 order by Acdes");

            da = new SqlDataAdapter(s, con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                this.cbobankname.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            cbobankname.Items.Add("Journal");
            //cbobankname.Items.Add("Cash A/c");
            //cbobankname.SelectedIndex = 0;
            //This for item name 
            con.Close();
            con.Open();
            da = new SqlDataAdapter("select pcode,patient_name from patient_master order by pcode", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                gracdes.Items.Add( ds.Tables[0].Rows[i][1].ToString().Trim ()+"("+ds.Tables[0].Rows[i][0].ToString().Trim () +")" );
            }
            da.Dispose();
            da = new SqlDataAdapter("select name from doctor order by name", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                gracdes.Items.Add(ds.Tables[0].Rows[i][0].ToString() );
            }
            da.Dispose();
            da = new SqlDataAdapter("select name from referal order by name", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                gracdes.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            da.Dispose();
            da = new SqlDataAdapter("select acdes from account_master order by acdes", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                gracdes.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            da.Dispose();

            grdcin.Items.Add("D");
            grdcin.Items.Add("C");

            con.Close();
            txtcompid.Enabled = false;
            //txtpartyid.Text = "1";
            //txtpartyid.Enabled = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Enabled = true;
            cbobankname.Text = "Cash A/c";
            crvvch.Visible = false;
        }

        private void cbobankname_SelectedIndexChanged(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("select distinct vono from cbj where cc='" + txtcompid.Text + "' and trncd='" + cbobankname.SelectedItem + "' order by vono", con);
            ds = new DataSet();
            da.Fill(ds);
            cbovoucherno.Items.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cbovoucherno.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            //cmd = new SqlCommand("select max(vono) from cbj where cc='" + txtcompid.Text + "' and trncd='" + cbobankname.SelectedItem + "' group by trncd", con);
            da = new SqlDataAdapter("select max(convert(int,vono)) from cbj where cc='" + txtcompid.Text + "' and trncd='" + cbobankname.SelectedItem + "' group by trncd", con);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("No Records Entered");
            }
            else
            {
                cbovoucherno.Text = Convert.ToString((ds.Tables[0].Rows[0][0] != DBNull.Value ? Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) : 0) + 1);
            }
        }

        private void cbovoucherno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbovoucherno.Text != "")
            {
                con.Close();
                con.Open();
                da = new SqlDataAdapter("select cc,Trncd,Vodt,Vono,acdes,dcin,Amt,narr,chno,chdt  from cbj where cc='" + txtcompid.Text + "' and trncd='" + cbobankname.Text + "' and vono= '" + cbovoucherno.Text + "'", con);
                //cmd.Connection = con;
                // cmd.ExecuteNonQuery();
                ds = new DataSet();
                da.Fill(ds);

                btnAdd.Enabled = false;
                //btnUpdate.Enabled = false;
                //btnDelete.Enabled = false;
                btnCancel.Enabled = true;
                
                
                //btnAdd.Enabled = true;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnCancel.Enabled = true;
                btnPrint.Enabled = true;
                this.txtcompid.Enabled = false;
                int ictr = 0;
                //dr.Close();
                // = cmd.ExecuteReader();
                //while (dr.Read())
                dgv.Rows.Clear();
                Double tdb = 0;
                Double tcr = 0;

                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {

                    txtcompid.Text = ds.Tables[0].Rows[i][0].ToString();
                    cbobankname.Text = ds.Tables[0].Rows[i][1].ToString();
                    dtvoucher.Text = ds.Tables[0].Rows[i][2].ToString();
                    cbovoucherno.Text = ds.Tables[0].Rows[i][3].ToString();
                    dgv.Rows.Insert(i);
                    dgv.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][4].ToString();
                    dgv.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][5].ToString();
                    if (ds.Tables[0].Rows[i][5].ToString() == "D")
                    {
                        dgv.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][6].ToString();
                        tdb = tdb + Convert.ToDouble(ds.Tables[0].Rows[i][6].ToString());
                    }
                    else
                    {
                        dgv.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][6].ToString();

                        tcr = tcr + Convert.ToDouble(ds.Tables[0].Rows[i][6].ToString());
                    }
                    dgv.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][7].ToString();
                    dgv.Rows[i].Cells[5].Value = ds.Tables[0].Rows[i][8].ToString();
                    dgv.Rows[i].Cells[6].Value = ds.Tables[0].Rows[i][9].ToString();
                    ictr++;

                }
                txtdb.Text = tdb.ToString();
                txtcr.Text = tcr.ToString();

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            //DateTime dtf = DateTime.dtvoucher.Text;
           //string format = "dd-mm-yyyy";
           //string dtTObeInsertedInSQL = dt.ToString(format);

            
            DateTime dtf, dtt;
            //dtf = Convert.ToDateTime(dtvoucher.Text, @dtvoucher.Text, 105);
            String dd = dtvoucher.Text.Substring(0, 2).ToString();
            String mmm = dtvoucher.Text.Substring(3, 2).ToString();
            String yy = dtvoucher.Text.Substring(6, 4).ToString();
            dtf = DateTime.ParseExact(dd + "/" + mmm + "/" + yy, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            //dtf = Convert.ToDateTime(dd + '/' + mm + '/' + yy);
            //string format = "dd-mm-yyyy";
           // string dtTObeInsertedInSQL = dtf.ToString(format);
            String dd1 = txtchdt.Text.Substring(0, 2).ToString();
            String mmm1 = txtchdt.Text.Substring(3, 2).ToString();
            String yy1 = txtchdt.Text.Substring(6, 4).ToString();
            dtt = DateTime.ParseExact(dd1 + "/" + mmm1 + "/" + yy1, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            
            
            int i;

            if (dgv.Rows[0].Cells[0].Value != null)
            {

                for (i = 0; i <= dgv.Rows.Count - 1; i++)
                {
                    con.Close();
                    con.Open();
                    if (dgv.Rows[i].Cells[0].Value != null)
                    {

                        if (Convert.ToString(dgv.Rows[i].Cells[1].Value) == "D")
                        {
                            cmd = new SqlCommand("insert into cbj (cc,Trncd,Vodt,Vono,acdes,dcin,Amt,narr,chno,chdt) values('" + txtcompid.Text + "','" + this.cbobankname.Text + "','" + dtf.ToString("yyyy-MM-dd") + "','" + cbovoucherno.Text + "', '" + dgv.Rows[i].Cells[0].Value + "', '" + dgv.Rows[i].Cells[1].Value + "', '" + Convert.ToDouble(dgv.Rows[i].Cells[2].Value) + "', '" + dgv.Rows[i].Cells[4].Value + "', '" + dgv.Rows[i].Cells[5].Value + "', '" + dgv.Rows[i].Cells[6].Value + "')", con);
                        }
                        else
                        {
                            cmd = new SqlCommand("insert into cbj (cc,Trncd,Vodt,Vono,acdes,dcin,Amt,narr,chno,chdt) values('" + txtcompid.Text + "','" + this.cbobankname.Text + "','" + dtf.ToString("yyyy-MM-dd") + "','" + cbovoucherno.Text + "', '" + dgv.Rows[i].Cells[0].Value + "', '" + dgv.Rows[i].Cells[1].Value + "', '" + Convert.ToDouble(dgv.Rows[i].Cells[3].Value) + "', '" + dgv.Rows[i].Cells[4].Value + "', '" + dgv.Rows[i].Cells[5].Value + "', '" + dgv.Rows[i].Cells[6].Value + "')", con);
                        }
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                MessageBox.Show("Data Saved !!");
                cbovoucherno.Items.Add(cbovoucherno.Text );
                cbovoucherno.Text = Convert.ToString(Convert.ToInt32(cbovoucherno.Text) + 1);
                dgv.Rows.Clear();
            }
            else
            {
                MessageBox.Show("Add Voucher detail !!");
                cbovoucherno.Focus();
            }

            
        
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DateTime dtf, dtt;
            String dd = dtvoucher.Text.Substring(0, 2).ToString();
            String mmm = dtvoucher.Text.Substring(3, 2).ToString();
            String yy = dtvoucher.Text.Substring(6, 4).ToString();
            dtf = DateTime.ParseExact(dd + "/" + mmm + "/" + yy, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            String dd1 = txtchdt.Text.Substring(0, 2).ToString();
            String mmm1 = txtchdt.Text.Substring(3, 2).ToString();
            String yy1 = txtchdt.Text.Substring(6, 4).ToString();
            dtt = DateTime.ParseExact(dd1 + "/" + mmm1 + "/" + yy1, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            con.Close();
            con.Open();
            if (vusrtype1 == "Admin")
            {
                cmd = new SqlCommand("delete from cbj where cc='" + txtcompid.Text + "' and trncd='" + cbobankname.SelectedItem + "' and vono = '" + cbovoucherno.Text + "'", con);
                cmd.ExecuteNonQuery();

                con.Close();

                int i;
                for (i = 0; i <= dgv.Rows.Count - 1; i++)
                {

                    con.Close();
                    con.Open();

                    if (dgv.Rows[i].Cells[0].Value != null)
                    {
                        if (Convert.ToString(dgv.Rows[i].Cells[1].Value) == "D")
                        {
                            cmd = new SqlCommand("insert into cbj (cc,Trncd,Vodt,Vono,acdes,dcin,Amt,narr,chno,chdt) values('" + txtcompid.Text + "','" + this.cbobankname.Text + "','" + dtf.ToString("yyyy-MM-dd") + "','" + cbovoucherno.Text + "', '" + dgv.Rows[i].Cells[0].Value + "', '" + dgv.Rows[i].Cells[1].Value + "', '" + Convert.ToDouble(dgv.Rows[i].Cells[2].Value) + "', '" + dgv.Rows[i].Cells[4].Value + "', '" + dgv.Rows[i].Cells[5].Value + "', '" + dgv.Rows[i].Cells[6].Value + "')", con);
                        }
                        else
                        {
                            cmd = new SqlCommand("insert into cbj (cc,Trncd,Vodt,Vono,acdes,dcin,Amt,narr,chno,chdt) values('" + txtcompid.Text + "','" + this.cbobankname.Text + "','" + dtf.ToString("yyyy-MM-dd") + "','" + cbovoucherno.Text + "', '" + dgv.Rows[i].Cells[0].Value + "', '" + dgv.Rows[i].Cells[1].Value + "', '" + Convert.ToDouble(dgv.Rows[i].Cells[3].Value) + "', '" + dgv.Rows[i].Cells[4].Value + "', '" + dgv.Rows[i].Cells[5].Value + "', '" + dgv.Rows[i].Cells[6].Value + "')", con);
                        }
                        cmd.ExecuteNonQuery();

                    }
                }


                con.Close();

                MessageBox.Show("Update,OK");
                cbovoucherno.Text = Convert.ToString(Convert.ToInt32(cbovoucherno.Text) + 1);
                dgv.Rows.Clear();
                txtchno.Text = "";
            }
            else
            {
                MessageBox.Show("You are not Authorized !!");
                cbovoucherno.Focus();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            if (vusrtype1 == "Admin")
            {
                cmd = new SqlCommand("delete from cbj where cc='" + txtcompid.Text + "' and trncd='" + cbobankname.SelectedItem + "' and vono ='" + cbovoucherno.Text + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Voucher Deleted!");
            }
            else
            {
                MessageBox.Show("You are not Authorized !!");
                cbovoucherno.Focus();
            }
        
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            }
        }

        private void cbovoucherno_Validating(object sender, CancelEventArgs e)
        {
            string txt = cbovoucherno.Text;
            var numericPart = Regex.Match(txt, "\\d+").Value;
            //comboBox1.Items.Add(numericPart);
            //listBox1.Items.Add(numericPart);
            if (numericPart != "")
            {
                cbovoucherno.Text = numericPart;
                //btn_wt_value.Focus();
            }
            else
            {
                MessageBox.Show(numericPart + " Please Check the Number? Enter only last Voucher number to Add !!! ");          
                 cbovoucherno.Focus();
            }
            
            
            // this.textBox1.Text += numericPart + "\n";
            // string number = Regex.Match("txt<br>", @"\d+").Value;
        }

        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Double tdb = 0; Double tcr = 0;

            int i;
            for (i = 0; i <= dgv.Rows.Count - 1; i++)
            {

                con.Close();
                con.Open();

                if (dgv.Rows[i].Cells[0].Value != null)
                {
                    if (Convert.ToString(dgv.Rows[i].Cells[1].Value) == "D")
                    {
                        //cmd = new SqlCommand("insert into cbj (cc,Trncd,Vodt,Vono,acdes,dcin,Amt,narr,chno,chdt) values('" + txtcompid.Text + "','" + this.cbobankname.Text + "','" + dtf.ToString("yyyy-MM-dd") + "','" + cbovoucherno.Text + "', '" + dgv.Rows[i].Cells[0].Value + "', '" + dgv.Rows[i].Cells[1].Value + "', '" + Convert.ToDouble(dgv.Rows[i].Cells[2].Value) + "', '" + dgv.Rows[i].Cells[4].Value + "', '" + dgv.Rows[i].Cells[5].Value + "', '" + dgv.Rows[i].Cells[6].Value + "')", con);
                        tdb = tdb + Convert.ToDouble(dgv.Rows[i].Cells[2].Value);
                    
                    }
                    else
                    {
                       // cmd = new SqlCommand("insert into cbj (cc,Trncd,Vodt,Vono,acdes,dcin,Amt,narr,chno,chdt) values('" + txtcompid.Text + "','" + this.cbobankname.Text + "','" + dtf.ToString("yyyy-MM-dd") + "','" + cbovoucherno.Text + "', '" + dgv.Rows[i].Cells[0].Value + "', '" + dgv.Rows[i].Cells[1].Value + "', '" + Convert.ToDouble(dgv.Rows[i].Cells[3].Value) + "', '" + dgv.Rows[i].Cells[4].Value + "', '" + dgv.Rows[i].Cells[5].Value + "', '" + dgv.Rows[i].Cells[6].Value + "')", con);
                        tcr = tcr + Convert.ToDouble(dgv.Rows[i].Cells[3].Value);
                    }
                    //cmd.ExecuteNonQuery();

                }
            }
            txtdb.Text = tdb.ToString("#.##");
            txtcr.Text = tcr.ToString("#.##");
        
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
              if (this.cbovoucherno.Text != "")
            {
                
                crvvch.Visible = true;

                con.Close();
                con.Open();
                da = new SqlDataAdapter("select cc,Trncd,Vodt,Vono,acdes,chno,chdt,Amt,narr,dcin  from cbj where cc='" + txtcompid.Text + "' and trncd='" + cbobankname.SelectedItem + "' and vono= '" + cbovoucherno.Text + "'", con);
                ds = new DataSet();
                da.Fill(ds);

                btnPrint.Enabled = true;
                this.txtcompid.Enabled = false;
                int ictr = 0;
                DataTable dtv = new DataTable();
                dtv = ds.Tables[0];

                Pathology_Ds dsh = new Pathology_Ds();
                
                  DataTable dt = new DataTable();
                dt = dsh.Tables.Add("ds_cbj");
                dt.Columns.Add("Cc", System.Type.GetType("System.Int32"));
                dt.Columns.Add("Trncd", System.Type.GetType("System.String"));
                dt.Columns.Add("Vodt", System.Type.GetType("System.DateTime"));
                dt.Columns.Add("Vono", System.Type.GetType("System.String"));

                dt.Columns.Add("Acdes", System.Type.GetType("System.String"));
                dt.Columns.Add("Chno", System.Type.GetType("System.String"));
                dt.Columns.Add("Chdt", System.Type.GetType("System.DateTime"));
                dt.Columns.Add("Amt", System.Type.GetType("System.Double"));
                dt.Columns.Add("Narr", System.Type.GetType("System.String"));
                dt.Columns.Add("Dcin", System.Type.GetType("System.String"));
                //dt.Columns.Add("paddress", System.Type.GetType("System.String"));
                for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                {
                    if (ds.Tables[0].Rows[k][6].ToString() == "")
                    {
                        dtv.Rows[k][6] = "";
                    }
                    //  dt.Rows.Add(Convert.ToDouble(dtv.Rows[k][0]), dtv.Rows[k][1], dtv.Rows[k][2], Convert.ToDateTime(dtv.Rows[k][3]), dtv.Rows[k][4], dtv.Rows[k][5], dtv.Rows[k][6], dtv.Rows[k][7], dtv.Rows[k][8], Convert.ToDouble(dtv.Rows[k][9]), Convert.ToDouble(dtv.Rows[k][10]), Convert.ToDouble(dtv.Rows[k][11]), Convert.ToDouble(dtv.Rows[k][12]), Convert.ToDouble(dtv.Rows[k][13]), Convert.ToDouble(dtv.Rows[k][14]), Convert.ToDouble(dtv.Rows[k][15]), Convert.ToDouble(dtv.Rows[k][16]), Convert.ToDouble(dtv.Rows[k][17]), Convert.ToDouble(dtv.Rows[k][18]), dtv.Rows[k][19], dtv.Rows[k][20], dtv.Rows[k][21], dtv.Rows[k][22], dtv.Rows[k][23]);
                    dt.Rows.Add(Convert.ToInt32(dtv.Rows[k][0]), dtv.Rows[k][1], Convert.ToDateTime(dtv.Rows[k][2]), dtv.Rows[k][3], dtv.Rows[k][4], dtv.Rows[k][5], Convert.ToDateTime(dtv.Rows[k][6]), Convert.ToDouble(dtv.Rows[k][7]), dtv.Rows[k][8], dtv.Rows[k][9]);

                }
               Repvoucherprint cashbankrep = new Repvoucherprint();
                //cashbankrep.SetDatabaseLogon("sa", "techsoft",@".\SQLEXPRESS", "hope_account");
                cashbankrep.SetDataSource(dt);
                crvvch.ReportSource = cashbankrep;

                //cashbankrep.SetParameterValue(0, clbal);
                //cashbankrep.SetParameterValue(1, cbocashbank.Text);
                cashbankrep.SetParameterValue(0, label4.Text);
                cashbankrep.SetParameterValue(1, adr);
                cashbankrep.SetParameterValue(2, telp);



            }
        }

        private void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex != 1)
            {
                String err = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
                //lblerr.Text = err + " Not Found in New Test Master !!";
                MessageBox.Show(err + " is Deleted or Moved from Account Master,;Reenter it with Same name !!");
                dgv.Rows[e.RowIndex].Cells[0].Value = "";
            }
        }

        private void crvvch_Load(object sender, EventArgs e)
        {

        }
        

       



        }
    }

