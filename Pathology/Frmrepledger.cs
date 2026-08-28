using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;
namespace Pathology
{
    public partial class Frmrepledger : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataSet ds, ds0, ds1;
       
        public Frmrepledger()
        {
            InitializeComponent();
        }

        private void Frmrepledger_Load(object sender, EventArgs e)
        {
            Class1 objclass = new Class1();
            con = new SqlConnection(objclass.arun_con());
            con.Open();
            cmd = new SqlCommand("select cc,comp,year_start,year_end from setup");
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtcompid.Text = dr.GetValue(0).ToString();
                label4.Text = dr.GetValue(1).ToString();
                dtfrom.Text = dr.GetValue(2).ToString();
                //dtto.Text = dr.GetValue(3).ToString();

            }
            dr.Close();
            //cboledger.Items.Add("SUNDRY DEBTORS");
            //cboledger.Items.Add("SUNDRY CREDITORS");
            //cboledger.Items.Add("GENERAL LEDGER");
            cboledger.Items.Add("ALL");
            cboledger.Items.Add("Supplier");
            String s = ("select pcode,patient_name,temp_bal,stag from patient_master order by pcode");
            da = new SqlDataAdapter(s, con);
            ds = new DataSet();
            da.Fill(ds);
            Double netb = 0;
            int tag1 = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                //string acds = ds.Tables[0].Rows[i][0].ToString().Trim() + '-' + ds.Tables[0].Rows[i][1].ToString().Trim();
                cmd = new SqlCommand("Update patient_master set acdes='" + ds.Tables[0].Rows[i][1].ToString().Trim()+"("+Convert.ToString(ds.Tables[0].Rows[i][0].ToString().Trim())+")" + "',temp_bal='" + netb + "',stag='" + tag1 + "' where pcode='" + Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString().Trim()) + "'", con);
                //cbocashbank.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                cmd.ExecuteNonQuery();
            }
            cboledger.SelectedIndex = 0;
            con.Close();
        }

        private void cboledger_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.checkedListBox1.Show();
            //String s;

        
            if (cboledger.SelectedItem.ToString() == "ALL")
            {

                //String s = ("select cb.cc,cb.trncd,cb.vono,cb.vodt,am.acdes,cb.amt,cb.dcin,cb.narr,am.opening_bal,am.temp_bal from account_master am left join cbj cb on (am.acdes=cb.acdes and cb.cc='" + txtcompid.Text + "' and cb.vodt>='" + dtfrom.Text + "' and cb.vodt<='" + dtto.Text + "')  where (am.s_group !='Customer' and am.s_group !='Supplier') and am.temp_bal+cb.amt <>0 order by am.acdes,cb.vodt,cb.vono,cb.trncd");
                //da = new SqlDataAdapter("select partyid,acdes,gcd,grpname,scd,s_group,add1,city,pin,zone,phone,fax,email,vatno,cstno,dl_no,opening_bal,closing_bal,temp_bal,dr_cr,stag from account_master  order by acdes", con);
                da = new SqlDataAdapter("select acdes from patient_master  order by acdes", con);
                ds0 = new DataSet();
                da.Fill(ds0, "patient_master");

            }

            if (cboledger.SelectedItem.ToString() == "Supplier")
            {

                //String s = ("select cb.cc,cb.trncd,cb.vono,cb.vodt,am.acdes,cb.amt,cb.dcin,cb.narr,am.opening_bal,am.temp_bal from account_master am left join cbj cb on (am.acdes=cb.acdes and cb.cc='" + txtcompid.Text + "' and cb.vodt>='" + dtfrom.Text + "' and cb.vodt<='" + dtto.Text + "')  where (am.s_group !='Customer' and am.s_group !='Supplier') and am.temp_bal+cb.amt <>0 order by am.acdes,cb.vodt,cb.vono,cb.trncd");
                //da = new SqlDataAdapter("select partyid,acdes,gcd,grpname,scd,s_group,add1,city,pin,zone,phone,fax,email,vatno,cstno,dl_no,opening_bal,closing_bal,temp_bal,dr_cr,stag from account_master  order by acdes", con);
                da = new SqlDataAdapter("select acdes from account_master  order by acdes", con);
                ds0 = new DataSet();
                da.Fill(ds0, "account_master");

            }


            checkedListBox1.BeginUpdate();
            for (int z = 0; z < ds0.Tables[0].Rows.Count; z++)
            {
                checkedListBox1.Items.Add(ds0.Tables[0].Rows[z][0].ToString().Trim());
            }

            for (int x = 0; x < this.checkedListBox1.Items.Count; x++)
            {
                this.checkedListBox1.SetItemChecked(x, false);
            }
            this.checkedListBox1.EndUpdate();
 
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DateTime dtf, dtt;
            String dd = dtfrom.Text.Substring(0, 2).ToString();
            String mmm = this.dtfrom.Text.Substring(3, 2).ToString();
            String yy = this.dtfrom.Text.Substring(6, 4).ToString();
            dtf = DateTime.ParseExact(dd + "/" + mmm + "/" + yy, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            String dd1 = dtto.Text.Substring(0, 2).ToString();
            String mmm1 = this.dtto.Text.Substring(3, 2).ToString();
            String yy1 = this.dtto.Text.Substring(6, 4).ToString();
            dtt = DateTime.ParseExact(dd1 + "/" + mmm1 + "/" + yy1, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);


            da = new SqlDataAdapter("select acdes,vodt,amt,dcin from cbj where cc='" + txtcompid.Text + "' and vodt<'" + dtf.ToString("yyyy-MM-dd") + "' order by acdes,vodt", con);
            ds = new DataSet();
            da.Fill(ds);
            int i = 0;
            String pid;
            int tag = ds.Tables[0].Rows.Count;
            Double dbamt, cramt, netbal;
            if (tag != 0)
            {
                while (i <= tag)
                {
                    pid = ds.Tables[0].Rows[i][0].ToString();
                    dbamt = 0; cramt = 0; netbal = 0;
                    while (pid == ds.Tables[0].Rows[i][0].ToString())
                    {
                        if (ds.Tables[0].Rows[i][3].ToString() == "D")
                        {
                            dbamt = dbamt + Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                        }
                        else
                        {
                            cramt = cramt + Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                        }
                        i++;

                        netbal = dbamt - cramt;
                        if (i == tag) break;
                    }
                    con.Close();
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update patient_master set  temp_bal=" + netbal + " where acdes='" + pid + "'", con);
                    cmd.ExecuteNonQuery();
                    if (i == tag) break;

                    pid = ds.Tables[0].Rows[i][0].ToString();
                }

            }


            ds.Dispose();
            this.checkedListBox1.Hide();
            String s;
           

            if (cboledger.SelectedItem.ToString() == "ALL")
            {

                int tag1 = 1;

                foreach (object itemChecked in checkedListBox1.CheckedItems)
                {
                    con.Close();
                    con.Open();

                    cmd = new SqlCommand("update patient_master set  stag=" + tag1 + " where acdes='" + itemChecked.ToString() + "'", con);
                    cmd.ExecuteNonQuery();

                }
                if (checkBox1.Checked == true)
                {

                    s = ("select cb.cc,cb.trncd,cb.vono,cb.vodt,am.acdes,cb.amt,cb.dcin,cb.narr,am.opening_bal,am.temp_bal,cb.chno,cb.chdt from patient_master am left join cbj cb on (am.acdes=cb.acdes and cb.cc='" + txtcompid.Text + "' and cb.vodt>='" + dtf.ToString("yyyy-MM-dd") + "' and cb.vodt<='" + dtt.ToString("yyyy-MM-dd") + "' and am.temp_bal+cb.amt <>0)  order by am.pcode,cb.vodt,cb.vono,cb.trncd");
                }
                else
                {
                    s = ("select cb.cc,cb.trncd,cb.vono,cb.vodt,am.acdes,cb.amt,cb.dcin,cb.narr,am.opening_bal,am.temp_bal,cb.chno,cb.chdt from patient_master am left join cbj cb on (am.acdes=cb.acdes and cb.cc='" + txtcompid.Text + "' and cb.vodt>='" + dtf.ToString("yyyy-MM-dd") + "' and cb.vodt<='" + dtt.ToString("yyyy-MM-dd") + "' and am.temp_bal+cb.amt <>0) where am.stag=1  order by am.pcode,cb.vodt,cb.vono,cb.trncd");
                }
                //    s = ("select cb.cc,cb.trncd,cb.vodt,cb.vono,cb.partyid,cb.chno,cb.chdt,cb.amt,cb.narr,cb.dcin,am.gcd,am.scd,am.partyid,am.acdes,am.opening_bal from account_master am left join cbj cb on am.partyid=cb.partyid  where am.gcd= 3 and am.scd=1");    
                da = new SqlDataAdapter(s, con);
                ds = new DataSet();
                da.Fill(ds);
                da.Dispose();
            }

            //da = new SqlDataAdapter(s, con);
            //ds = new DataSet();
            //da.Fill(ds);
            //Ds_hope ds1 = new Ds_hope();

            //dt = ds1.Tables.Add("ds_cbj");
            DataTable dtv = new DataTable();
            dtv = ds.Tables[0];

            Pathology_Ds dsh = new Pathology_Ds();
            DataTable dt = new DataTable();
            // Ds_hope dsh = new Ds_hope();
            //  DataTable dt = new DataTable();
            dt = dsh.Tables.Add("ds_cbj");

            dt.Columns.Add("cc", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Trncd", System.Type.GetType("System.String"));
            dt.Columns.Add("Vono", System.Type.GetType("System.String"));
            dt.Columns.Add("vodt", System.Type.GetType("System.DateTime"));

            dt.Columns.Add("Acdes", System.Type.GetType("System.String"));
            dt.Columns.Add("Amt", System.Type.GetType("System.Double"));
            dt.Columns.Add("dcin", System.Type.GetType("System.String"));
            dt.Columns.Add("Narr", System.Type.GetType("System.String"));
            dt.Columns.Add("opening_bal", System.Type.GetType("System.Double"));
            dt.Columns.Add("Temp_bal", System.Type.GetType("System.Double"));

            dt.Columns.Add("Chno", System.Type.GetType("System.String"));
            dt.Columns.Add("Chdt", System.Type.GetType("System.DateTime"));
            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
            {
                if (dtv.Rows[k][0].ToString() == "")
                {
                    dtv.Rows[k][0] = "1";
                }


                if (dtv.Rows[k][3].ToString() == "")
                {
                    dtv.Rows[k][3] = System.DateTime.Now;
                }

                if (dtv.Rows[k][5].ToString() == "")
                {
                    dtv.Rows[k][5] = "0.00";
                }
                if (dtv.Rows[k][6].ToString() == "")
                {
                    dtv.Rows[k][6] = "D";
                }
                if (dtv.Rows[k][11].ToString() == "")
                {
                    dtv.Rows[k][11] = System.DateTime.Now;
                }
                if (dtv.Rows[k][8].ToString() == "")
                {
                    dtv.Rows[k][8] = "0.00";
                }

                if (dtv.Rows[k][9].ToString() == "")
                {
                    dtv.Rows[k][9] = "0.00";
                }


                if ((Convert.ToDouble(dtv.Rows[k][5]) + Convert.ToDouble(dtv.Rows[k][8]) + Convert.ToDouble(dtv.Rows[k][9])) != 0)
                {
                    // dt.Rows.Add(Convert.ToDouble(dtv.Rows[k][0]), dtv.Rows[k][1], dtv.Rows[k][2], Convert.ToDateTime(dtv.Rows[k][3]), dtv.Rows[k][4], dtv.Rows[k][5], dtv.Rows[k][6], dtv.Rows[k][7], dtv.Rows[k][8], Convert.ToDouble(dtv.Rows[k][9]), Convert.ToDouble(dtv.Rows[k][10]), Convert.ToDouble(dtv.Rows[k][11]), Convert.ToDouble(dtv.Rows[k][12]), Convert.ToDouble(dtv.Rows[k][13]), Convert.ToDouble(dtv.Rows[k][14]), Convert.ToDouble(dtv.Rows[k][15]), Convert.ToDouble(dtv.Rows[k][16]), Convert.ToDouble(dtv.Rows[k][17]), Convert.ToDouble(dtv.Rows[k][18]), dtv.Rows[k][19], dtv.Rows[k][20], dtv.Rows[k][21], dtv.Rows[k][22], dtv.Rows[k][23]);
                    dt.Rows.Add(Convert.ToInt32(dtv.Rows[k][0]), dtv.Rows[k][1], dtv.Rows[k][2], Convert.ToDateTime(dtv.Rows[k][3]), dtv.Rows[k][4], Convert.ToDouble(dtv.Rows[k][5]), dtv.Rows[k][6], dtv.Rows[k][7], Convert.ToDouble(dtv.Rows[k][8]), Convert.ToDouble(dtv.Rows[k][9]), dtv.Rows[k][10], Convert.ToDateTime(dtv.Rows[k][11]));
                }
            }



            Repled2 ledgerrep = new Repled2();
            // ledgerrep.SetDataSource(dt);
            ledgerrep.SetDataSource(dt);
            crv.ReportSource = ledgerrep;

            ledgerrep.SetParameterValue(0, label4.Text);
            ledgerrep.SetParameterValue(1, cboledger.SelectedItem.ToString());
            ledgerrep.SetParameterValue(2, dtf);
            ledgerrep.SetParameterValue(3, dtt);

            crv.Refresh();
            con.Close();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            DateTime dtf, dtt;
            String dd = dtfrom.Text.Substring(0, 2).ToString();
            String mmm = this.dtfrom.Text.Substring(3, 2).ToString();
            String yy = this.dtfrom.Text.Substring(6, 4).ToString();
            dtf = DateTime.ParseExact(dd + "/" + mmm + "/" + yy, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            String dd1 = dtto.Text.Substring(0, 2).ToString();
            String mmm1 = this.dtto.Text.Substring(3, 2).ToString();
            String yy1 = this.dtto.Text.Substring(6, 4).ToString();
            dtt = DateTime.ParseExact(dd1 + "/" + mmm1 + "/" + yy1, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);


            da = new SqlDataAdapter("select acdes,vodt,amt,dcin from cbj where cc='" + txtcompid.Text + "' and vodt<'" + dtf.ToString("yyyy-MM-dd") + "' order by acdes,vodt", con);
            ds = new DataSet();
            da.Fill(ds);
            int i = 0;
            String pid;
            int tag = ds.Tables[0].Rows.Count;
            Double dbamt, cramt, netbal;
            if (tag != 0)
            {
                while (i <= tag)
                {
                    pid = ds.Tables[0].Rows[i][0].ToString();
                    dbamt = 0; cramt = 0; netbal = 0;
                    while (pid == ds.Tables[0].Rows[i][0].ToString())
                    {
                        if (ds.Tables[0].Rows[i][3].ToString() == "D")
                        {
                            dbamt = dbamt + Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                        }
                        else
                        {
                            cramt = cramt + Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                        }
                        i++;

                        netbal = dbamt - cramt;
                        if (i == tag) break;
                    }
                    con.Close();
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update patient_master set  temp_bal=" + netbal + " where acdes='" + pid + "'", con);
                    cmd.ExecuteNonQuery();
                    if (i == tag) break;

                    pid = ds.Tables[0].Rows[i][0].ToString();
                }

            }


            ds.Dispose();
            this.checkedListBox1.Hide();
            String s;


            if (cboledger.SelectedItem.ToString() == "ALL")
            {

                int tag1 = 1;

                foreach (object itemChecked in checkedListBox1.CheckedItems)
                {
                    con.Close();
                    con.Open();

                    cmd = new SqlCommand("update patient_master set  stag=" + tag1 + " where acdes='" + itemChecked.ToString() + "'", con);
                    cmd.ExecuteNonQuery();

                }
                if (checkBox1.Checked == true)
                {

                    s = ("select cb.cc,cb.trncd,cb.vono,cb.vodt,am.acdes,cb.amt,cb.dcin,cb.narr,am.opening_bal,am.temp_bal,cb.chno,cb.chdt from patient_master am left join cbj cb on (am.acdes=cb.acdes and cb.cc='" + txtcompid.Text + "' and cb.vodt>='" + dtf.ToString("yyyy-MM-dd") + "' and cb.vodt<='" + dtt.ToString("yyyy-MM-dd") + "' and am.temp_bal+cb.amt <>0)  order by am.pcode,cb.vodt,cb.vono,cb.trncd");
                }
                else
                {
                    s = ("select cb.cc,cb.trncd,cb.vono,cb.vodt,am.acdes,cb.amt,cb.dcin,cb.narr,am.opening_bal,am.temp_bal,cb.chno,cb.chdt from patient_master am left join cbj cb on (am.acdes=cb.acdes and cb.cc='" + txtcompid.Text + "' and cb.vodt>='" + dtf.ToString("yyyy-MM-dd") + "' and cb.vodt<='" + dtt.ToString("yyyy-MM-dd") + "' and am.temp_bal+cb.amt <>0) where am.stag=1  order by am.pcode,cb.vodt,cb.vono,cb.trncd");
                }
                //    s = ("select cb.cc,cb.trncd,cb.vodt,cb.vono,cb.partyid,cb.chno,cb.chdt,cb.amt,cb.narr,cb.dcin,am.gcd,am.scd,am.partyid,am.acdes,am.opening_bal from account_master am left join cbj cb on am.partyid=cb.partyid  where am.gcd= 3 and am.scd=1");    
                da = new SqlDataAdapter(s, con);
                ds = new DataSet();
                da.Fill(ds);
                da.Dispose();
            }

            //da = new SqlDataAdapter(s, con);
            //ds = new DataSet();
            //da.Fill(ds);
            //Ds_hope ds1 = new Ds_hope();

            //dt = ds1.Tables.Add("ds_cbj");
            DataTable dtv = new DataTable();
            dtv = ds.Tables[0];

            Pathology_Ds dsh = new Pathology_Ds();
            DataTable dt = new DataTable();
            // Ds_hope dsh = new Ds_hope();
            //  DataTable dt = new DataTable();
            dt = dsh.Tables.Add("ds_cbj");

            dt.Columns.Add("cc", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Trncd", System.Type.GetType("System.String"));
            dt.Columns.Add("Vono", System.Type.GetType("System.String"));
            dt.Columns.Add("vodt", System.Type.GetType("System.DateTime"));

            dt.Columns.Add("Acdes", System.Type.GetType("System.String"));
            dt.Columns.Add("Amt", System.Type.GetType("System.Double"));
            dt.Columns.Add("dcin", System.Type.GetType("System.String"));
            dt.Columns.Add("Narr", System.Type.GetType("System.String"));
            dt.Columns.Add("opening_bal", System.Type.GetType("System.Double"));
            dt.Columns.Add("Temp_bal", System.Type.GetType("System.Double"));

            dt.Columns.Add("Chno", System.Type.GetType("System.String"));
            dt.Columns.Add("Chdt", System.Type.GetType("System.DateTime"));
            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
            {
                if (dtv.Rows[k][0].ToString() == "")
                {
                    dtv.Rows[k][0] = "1";
                }


                if (dtv.Rows[k][3].ToString() == "")
                {
                    dtv.Rows[k][3] = System.DateTime.Now;
                }

                if (dtv.Rows[k][5].ToString() == "")
                {
                    dtv.Rows[k][5] = "0.00";
                }
                if (dtv.Rows[k][6].ToString() == "")
                {
                    dtv.Rows[k][6] = "D";
                }
                if (dtv.Rows[k][11].ToString() == "")
                {
                    dtv.Rows[k][11] = System.DateTime.Now;
                }
                if (dtv.Rows[k][8].ToString() == "")
                {
                    dtv.Rows[k][8] = "0.00";
                }

                if (dtv.Rows[k][9].ToString() == "")
                {
                    dtv.Rows[k][9] = "0.00";
                }


                if ((Convert.ToDouble(dtv.Rows[k][5]) + Convert.ToDouble(dtv.Rows[k][8]) + Convert.ToDouble(dtv.Rows[k][9])) != 0)
                {
                    // dt.Rows.Add(Convert.ToDouble(dtv.Rows[k][0]), dtv.Rows[k][1], dtv.Rows[k][2], Convert.ToDateTime(dtv.Rows[k][3]), dtv.Rows[k][4], dtv.Rows[k][5], dtv.Rows[k][6], dtv.Rows[k][7], dtv.Rows[k][8], Convert.ToDouble(dtv.Rows[k][9]), Convert.ToDouble(dtv.Rows[k][10]), Convert.ToDouble(dtv.Rows[k][11]), Convert.ToDouble(dtv.Rows[k][12]), Convert.ToDouble(dtv.Rows[k][13]), Convert.ToDouble(dtv.Rows[k][14]), Convert.ToDouble(dtv.Rows[k][15]), Convert.ToDouble(dtv.Rows[k][16]), Convert.ToDouble(dtv.Rows[k][17]), Convert.ToDouble(dtv.Rows[k][18]), dtv.Rows[k][19], dtv.Rows[k][20], dtv.Rows[k][21], dtv.Rows[k][22], dtv.Rows[k][23]);
                    dt.Rows.Add(Convert.ToInt32(dtv.Rows[k][0]), dtv.Rows[k][1], dtv.Rows[k][2], Convert.ToDateTime(dtv.Rows[k][3]), dtv.Rows[k][4], Convert.ToDouble(dtv.Rows[k][5]), dtv.Rows[k][6], dtv.Rows[k][7], Convert.ToDouble(dtv.Rows[k][8]), Convert.ToDouble(dtv.Rows[k][9]), dtv.Rows[k][10], Convert.ToDateTime(dtv.Rows[k][11]));
                }
            }



            Reppending ledgerrep = new Reppending();
            // ledgerrep.SetDataSource(dt);
            ledgerrep.SetDataSource(dt);
            crv.ReportSource = ledgerrep;

            ledgerrep.SetParameterValue(0, label4.Text);
            ledgerrep.SetParameterValue(1, cboledger.SelectedItem.ToString());
            ledgerrep.SetParameterValue(2, dtf);
            ledgerrep.SetParameterValue(3, dtt);

            crv.Refresh();
            con.Close();
        }

        private void btnonday_Click(object sender, EventArgs e)
        {
            DateTime dtf, dtt;
            String dd = dtfrom.Text.Substring(0, 2).ToString();
            String mmm = this.dtfrom.Text.Substring(3, 2).ToString();
            String yy = this.dtfrom.Text.Substring(6, 4).ToString();
            dtf = DateTime.ParseExact(dd + "/" + mmm + "/" + yy, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            String dd1 = dtto.Text.Substring(0, 2).ToString();
            String mmm1 = this.dtto.Text.Substring(3, 2).ToString();
            String yy1 = this.dtto.Text.Substring(6, 4).ToString();
            dtt = DateTime.ParseExact(dd1 + "/" + mmm1 + "/" + yy1, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);


            da = new SqlDataAdapter("select acdes,vodt,amt,dcin from cbj where cc='" + txtcompid.Text + "' and vodt<'" + dtf.ToString("yyyy-MM-dd") + "' order by acdes,vodt", con);
            ds = new DataSet();
            da.Fill(ds);
            int i = 0;
            String pid;
            int tag = ds.Tables[0].Rows.Count;
            Double dbamt, cramt, netbal;
            if (tag != 0)
            {
                while (i <= tag)
                {
                    pid = ds.Tables[0].Rows[i][0].ToString();
                    dbamt = 0; cramt = 0; netbal = 0;
                    while (pid == ds.Tables[0].Rows[i][0].ToString())
                    {
                        if (ds.Tables[0].Rows[i][3].ToString() == "D")
                        {
                            dbamt = dbamt + Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                        }
                        else
                        {
                            cramt = cramt + Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                        }
                        i++;

                        netbal = dbamt - cramt;
                        if (i == tag) break;
                    }
                    con.Close();
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update patient_master set  temp_bal=" + netbal + " where acdes='" + pid + "'", con);
                    cmd.ExecuteNonQuery();
                    if (i == tag) break;

                    pid = ds.Tables[0].Rows[i][0].ToString();
                }

            }


            ds.Dispose();
            this.checkedListBox1.Hide();
            String s;


            if (cboledger.SelectedItem.ToString() == "ALL")
            {

                int tag1 = 1;

                foreach (object itemChecked in checkedListBox1.CheckedItems)
                {
                    con.Close();
                    con.Open();

                    cmd = new SqlCommand("update patient_master set  stag=" + tag1 + " where acdes='" + itemChecked.ToString() + "'", con);
                    cmd.ExecuteNonQuery();

                }
                if (checkBox1.Checked == true)
                {

                    s = ("select cb.cc,cb.trncd,cb.vono,cb.vodt,am.acdes,cb.amt,cb.dcin,cb.narr,am.opening_bal,am.temp_bal,cb.chno,cb.chdt,am.date_exam from patient_master am left join cbj cb on (am.acdes=cb.acdes and cb.cc='" + txtcompid.Text + "' and cb.vodt>='" + dtf.ToString("yyyy-MM-dd") + "' and cb.vodt<='" + dtt.ToString("yyyy-MM-dd") + "' and am.temp_bal+cb.amt <>0) where am.date_exam='"+dtf+"' order by am.pcode,cb.vodt,cb.vono,cb.trncd");
                }
                else
                {
                    s = ("select cb.cc,cb.trncd,cb.vono,cb.vodt,am.acdes,cb.amt,cb.dcin,cb.narr,am.opening_bal,am.temp_bal,cb.chno,cb.chdt,am.date_exam from patient_master am left join cbj cb on (am.acdes=cb.acdes and cb.cc='" + txtcompid.Text + "' and cb.vodt>='" + dtf.ToString("yyyy-MM-dd") + "' and cb.vodt<='" + dtt.ToString("yyyy-MM-dd") + "' and am.temp_bal+cb.amt <>0) where am.stag=1  order by am.pcode,cb.vodt,cb.vono,cb.trncd");
                }
                //    s = ("select cb.cc,cb.trncd,cb.vodt,cb.vono,cb.partyid,cb.chno,cb.chdt,cb.amt,cb.narr,cb.dcin,am.gcd,am.scd,am.partyid,am.acdes,am.opening_bal from account_master am left join cbj cb on am.partyid=cb.partyid  where am.gcd= 3 and am.scd=1");    
                da = new SqlDataAdapter(s, con);
                ds = new DataSet();
                da.Fill(ds);
                da.Dispose();
            }

            //da = new SqlDataAdapter(s, con);
            //ds = new DataSet();
            //da.Fill(ds);
            //Ds_hope ds1 = new Ds_hope();

            //dt = ds1.Tables.Add("ds_cbj");
            DataTable dtv = new DataTable();
            dtv = ds.Tables[0];

            Pathology_Ds dsh = new Pathology_Ds();
            DataTable dt = new DataTable();
            // Ds_hope dsh = new Ds_hope();
            //  DataTable dt = new DataTable();
            dt = dsh.Tables.Add("ds_cbj");

            dt.Columns.Add("cc", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Trncd", System.Type.GetType("System.String"));
            dt.Columns.Add("Vono", System.Type.GetType("System.String"));
            dt.Columns.Add("vodt", System.Type.GetType("System.DateTime"));

            dt.Columns.Add("Acdes", System.Type.GetType("System.String"));
            dt.Columns.Add("Amt", System.Type.GetType("System.Double"));
            dt.Columns.Add("dcin", System.Type.GetType("System.String"));
            dt.Columns.Add("Narr", System.Type.GetType("System.String"));
            dt.Columns.Add("opening_bal", System.Type.GetType("System.Double"));
            dt.Columns.Add("Temp_bal", System.Type.GetType("System.Double"));

            dt.Columns.Add("Chno", System.Type.GetType("System.String"));
            dt.Columns.Add("Chdt", System.Type.GetType("System.DateTime"));
            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
            {
                if (dtv.Rows[k][0].ToString() == "")
                {
                    dtv.Rows[k][0] = "1";
                }


                if (dtv.Rows[k][3].ToString() == "")
                {
                    dtv.Rows[k][3] = System.DateTime.Now;
                }

                if (dtv.Rows[k][5].ToString() == "")
                {
                    dtv.Rows[k][5] = "0.00";
                }
                if (dtv.Rows[k][6].ToString() == "")
                {
                    dtv.Rows[k][6] = "D";
                }
                if (dtv.Rows[k][11].ToString() == "")
                {
                    dtv.Rows[k][11] = System.DateTime.Now;
                }
                if (dtv.Rows[k][8].ToString() == "")
                {
                    dtv.Rows[k][8] = "0.00";
                }

                if (dtv.Rows[k][9].ToString() == "")
                {
                    dtv.Rows[k][9] = "0.00";
                }


                if ((Convert.ToDouble(dtv.Rows[k][5]) + Convert.ToDouble(dtv.Rows[k][8]) + Convert.ToDouble(dtv.Rows[k][9])) != 0)
                {
                    // dt.Rows.Add(Convert.ToDouble(dtv.Rows[k][0]), dtv.Rows[k][1], dtv.Rows[k][2], Convert.ToDateTime(dtv.Rows[k][3]), dtv.Rows[k][4], dtv.Rows[k][5], dtv.Rows[k][6], dtv.Rows[k][7], dtv.Rows[k][8], Convert.ToDouble(dtv.Rows[k][9]), Convert.ToDouble(dtv.Rows[k][10]), Convert.ToDouble(dtv.Rows[k][11]), Convert.ToDouble(dtv.Rows[k][12]), Convert.ToDouble(dtv.Rows[k][13]), Convert.ToDouble(dtv.Rows[k][14]), Convert.ToDouble(dtv.Rows[k][15]), Convert.ToDouble(dtv.Rows[k][16]), Convert.ToDouble(dtv.Rows[k][17]), Convert.ToDouble(dtv.Rows[k][18]), dtv.Rows[k][19], dtv.Rows[k][20], dtv.Rows[k][21], dtv.Rows[k][22], dtv.Rows[k][23]);
                    dt.Rows.Add(Convert.ToInt32(dtv.Rows[k][0]), dtv.Rows[k][1], dtv.Rows[k][2], Convert.ToDateTime(dtv.Rows[k][3]), dtv.Rows[k][4], Convert.ToDouble(dtv.Rows[k][5]), dtv.Rows[k][6], dtv.Rows[k][7], Convert.ToDouble(dtv.Rows[k][8]), Convert.ToDouble(dtv.Rows[k][9]), dtv.Rows[k][10], Convert.ToDateTime(dtv.Rows[k][11]));
                }
            }



            Reppending ledgerrep = new Reppending();
            // ledgerrep.SetDataSource(dt);
            ledgerrep.SetDataSource(dt);
            crv.ReportSource = ledgerrep;

            ledgerrep.SetParameterValue(0, label4.Text);
            ledgerrep.SetParameterValue(1, cboledger.SelectedItem.ToString());
            ledgerrep.SetParameterValue(2, dtf);
            ledgerrep.SetParameterValue(3, dtt);

            crv.Refresh();
            con.Close();




        }

        private void btnledgsupplier_Click(object sender, EventArgs e)
        {
DateTime dtf, dtt;
            String dd = dtfrom.Text.Substring(0, 2).ToString();
            String mmm = this.dtfrom.Text.Substring(3, 2).ToString();
            String yy = this.dtfrom.Text.Substring(6, 4).ToString();
            dtf = DateTime.ParseExact(dd + "/" + mmm + "/" + yy, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            String dd1 = dtto.Text.Substring(0, 2).ToString();
            String mmm1 = this.dtto.Text.Substring(3, 2).ToString();
            String yy1 = this.dtto.Text.Substring(6, 4).ToString();
            dtt = DateTime.ParseExact(dd1 + "/" + mmm1 + "/" + yy1, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);


            da = new SqlDataAdapter("select acdes,vodt,amt,dcin from cbj where cc='" + txtcompid.Text + "' and vodt<'" + dtf.ToString("yyyy-MM-dd") + "' order by acdes,vodt", con);
            ds = new DataSet();
            da.Fill(ds);
            int i = 0;
            String pid;
            int tag = ds.Tables[0].Rows.Count;
            Double dbamt, cramt, netbal;
            if (tag != 0)
            {
                while (i <= tag)
                {
                    pid = ds.Tables[0].Rows[i][0].ToString();
                    dbamt = 0; cramt = 0; netbal = 0;
                    while (pid == ds.Tables[0].Rows[i][0].ToString())
                    {
                        if (ds.Tables[0].Rows[i][3].ToString() == "D")
                        {
                            dbamt = dbamt + Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                        }
                        else
                        {
                            cramt = cramt + Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                        }
                        i++;

                        netbal = dbamt - cramt;
                        if (i == tag) break;
                    }
                    con.Close();
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update account_master set  temp_bal=" + netbal + " where acdes='" + pid + "'", con);
                    cmd.ExecuteNonQuery();
                    if (i == tag) break;

                    pid = ds.Tables[0].Rows[i][0].ToString();
                }

            }


            ds.Dispose();
            this.checkedListBox1.Hide();
            String s;


            if (cboledger.SelectedItem.ToString() == "Supplier")
            {

                int tag1 = 1;

                foreach (object itemChecked in checkedListBox1.CheckedItems)
                {
                    con.Close();
                    con.Open();

                    cmd = new SqlCommand("update account_master set  stag=" + tag1 + " where acdes='" + itemChecked.ToString() + "'", con);
                    cmd.ExecuteNonQuery();

                }
                if (checkBox1.Checked == true)
                {

                    s = ("select cb.cc,cb.trncd,cb.vono,cb.vodt,am.acdes,cb.amt,cb.dcin,cb.narr,am.opening_bal,am.temp_bal,cb.chno,cb.chdt from account_master am left join cbj cb on (am.acdes=cb.acdes and cb.cc='" + txtcompid.Text + "' and cb.vodt>='" + dtf.ToString("yyyy-MM-dd") + "' and cb.vodt<='" + dtt.ToString("yyyy-MM-dd") + "' and am.temp_bal+cb.amt <>0)  order by am.acdes,cb.vodt,cb.vono,cb.trncd");
                }
                else
                {
                    s = ("select cb.cc,cb.trncd,cb.vono,cb.vodt,am.acdes,cb.amt,cb.dcin,cb.narr,am.opening_bal,am.temp_bal,cb.chno,cb.chdt from account_master am left join cbj cb on (am.acdes=cb.acdes and cb.cc='" + txtcompid.Text + "' and cb.vodt>='" + dtf.ToString("yyyy-MM-dd") + "' and cb.vodt<='" + dtt.ToString("yyyy-MM-dd") + "' and am.temp_bal+cb.amt <>0) where am.stag=1  order by am.acdes,cb.vodt,cb.vono,cb.trncd");
                }
                //    s = ("select cb.cc,cb.trncd,cb.vodt,cb.vono,cb.partyid,cb.chno,cb.chdt,cb.amt,cb.narr,cb.dcin,am.gcd,am.scd,am.partyid,am.acdes,am.opening_bal from account_master am left join cbj cb on am.partyid=cb.partyid  where am.gcd= 3 and am.scd=1");    
                da = new SqlDataAdapter(s, con);
                ds = new DataSet();
                da.Fill(ds);
                da.Dispose();
            }

            //da = new SqlDataAdapter(s, con);
            //ds = new DataSet();
            //da.Fill(ds);
            //Ds_hope ds1 = new Ds_hope();

            //dt = ds1.Tables.Add("ds_cbj");
            DataTable dtv = new DataTable();
            dtv = ds.Tables[0];

            Pathology_Ds dsh = new Pathology_Ds();
            DataTable dt = new DataTable();
            // Ds_hope dsh = new Ds_hope();
            //  DataTable dt = new DataTable();
            dt = dsh.Tables.Add("ds_cbj");

            dt.Columns.Add("cc", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Trncd", System.Type.GetType("System.String"));
            dt.Columns.Add("Vono", System.Type.GetType("System.String"));
            dt.Columns.Add("vodt", System.Type.GetType("System.DateTime"));

            dt.Columns.Add("Acdes", System.Type.GetType("System.String"));
            dt.Columns.Add("Amt", System.Type.GetType("System.Double"));
            dt.Columns.Add("dcin", System.Type.GetType("System.String"));
            dt.Columns.Add("Narr", System.Type.GetType("System.String"));
            dt.Columns.Add("opening_bal", System.Type.GetType("System.Double"));
            dt.Columns.Add("Temp_bal", System.Type.GetType("System.Double"));

            dt.Columns.Add("Chno", System.Type.GetType("System.String"));
            dt.Columns.Add("Chdt", System.Type.GetType("System.DateTime"));
            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
            {
                if (dtv.Rows[k][0].ToString() == "")
                {
                    dtv.Rows[k][0] = "1";
                }


                if (dtv.Rows[k][3].ToString() == "")
                {
                    dtv.Rows[k][3] = System.DateTime.Now;
                }

                if (dtv.Rows[k][5].ToString() == "")
                {
                    dtv.Rows[k][5] = "0.00";
                }
                if (dtv.Rows[k][6].ToString() == "")
                {
                    dtv.Rows[k][6] = "D";
                }
                if (dtv.Rows[k][11].ToString() == "")
                {
                    dtv.Rows[k][11] = System.DateTime.Now;
                }
                if (dtv.Rows[k][8].ToString() == "")
                {
                    dtv.Rows[k][8] = "0.00";
                }

                if (dtv.Rows[k][9].ToString() == "")
                {
                    dtv.Rows[k][9] = "0.00";
                }

                if ((Convert.ToDouble(dtv.Rows[k][5]) + Convert.ToDouble(dtv.Rows[k][8]) + Convert.ToDouble(dtv.Rows[k][9])) != 0)
                {
                    // dt.Rows.Add(Convert.ToDouble(dtv.Rows[k][0]), dtv.Rows[k][1], dtv.Rows[k][2], Convert.ToDateTime(dtv.Rows[k][3]), dtv.Rows[k][4], dtv.Rows[k][5], dtv.Rows[k][6], dtv.Rows[k][7], dtv.Rows[k][8], Convert.ToDouble(dtv.Rows[k][9]), Convert.ToDouble(dtv.Rows[k][10]), Convert.ToDouble(dtv.Rows[k][11]), Convert.ToDouble(dtv.Rows[k][12]), Convert.ToDouble(dtv.Rows[k][13]), Convert.ToDouble(dtv.Rows[k][14]), Convert.ToDouble(dtv.Rows[k][15]), Convert.ToDouble(dtv.Rows[k][16]), Convert.ToDouble(dtv.Rows[k][17]), Convert.ToDouble(dtv.Rows[k][18]), dtv.Rows[k][19], dtv.Rows[k][20], dtv.Rows[k][21], dtv.Rows[k][22], dtv.Rows[k][23]);
                    dt.Rows.Add(Convert.ToInt32(dtv.Rows[k][0]), dtv.Rows[k][1], dtv.Rows[k][2], Convert.ToDateTime(dtv.Rows[k][3]), dtv.Rows[k][4], Convert.ToDouble(dtv.Rows[k][5]), dtv.Rows[k][6], dtv.Rows[k][7], Convert.ToDouble(dtv.Rows[k][8]), Convert.ToDouble(dtv.Rows[k][9]), dtv.Rows[k][10], Convert.ToDateTime(dtv.Rows[k][11]));
                }
            }



            Repled2 ledgerrep = new Repled2();
            // ledgerrep.SetDataSource(dt);
            ledgerrep.SetDataSource(dt);
            crv.ReportSource = ledgerrep;

            ledgerrep.SetParameterValue(0, label4.Text);
            ledgerrep.SetParameterValue(1, cboledger.SelectedItem.ToString());
            ledgerrep.SetParameterValue(2, dtf);
            ledgerrep.SetParameterValue(3, dtt);

            crv.Refresh();
            con.Close();
        }

        
        
        
        }
    }

