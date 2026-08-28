using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Design;
namespace Pathology
{
    public partial class Frmopdregistration : Form
    {
        SqlConnection con;
        DataSet ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds10, ds11, ds12, ds13, ds14, ds15, ds16;
        DataSet dsru1;
        SqlDataAdapter da, da1;
        SqlCommand cmd, cmd1;
        SqlDataReader dr;
        DataRow drw;
        int rowindex;

        DataTable dt;
        //DataSet ds, ds1, ds2, ds5;
        public static string Ggrp, Gdesc, Gdesc1, Gresult, Gunit, Gnormalrange, Gnormalrange1;
        public static int gcode, gage;
        public static string gsex, gpatient_name, gdoctor, gmnyr, gscn, gtpt;
        public static DateTime gdt_report;
        public static string reportname = "";
        public static String Gdescpss = "";
        public static String Gresultpss = "";
        public static int pidr = 0;
        int i = 0;
        public string dd, mm, yy;
        public static DateTime repdt1;

        public static string pat_name = "";
        //public static string cbo = "";
        ToolTip t = new ToolTip();
       
        public Frmopdregistration()
        {
            InitializeComponent();
        }

        private void Frmopdregistration_Load(object sender, EventArgs e)
        {
            Class1 objclass = new Class1();
            con = new SqlConnection(objclass.arun_con());
            con.Open();
            cmd = new SqlCommand("select cc,comp,year_start,year_end from setup", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtcompanycode.Text = dr.GetValue(0).ToString();
                label53.Text = dr.GetValue(1).ToString();
                dtreport.Text = DateTime.Now.ToShortDateString();
            }
            dr.Close();
            con.Close();

            con.Open();
            da = new SqlDataAdapter("select pcode,patient_name from OPD_Master order by pcode", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                this.cbopcode.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                this.cboname.Items.Add(ds.Tables[0].Rows[i][1].ToString());
            }
            da.Dispose();
            da = new SqlDataAdapter("select max(pcode) from OPD_Master", con);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows[0][0].ToString() == "")
            {
                cbopcode.Text = "1";
            }
            else
            {
                int p = (Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) + 1);
                cbopcode.Text = Convert.ToString(p);
            }
            pidr = Convert.ToInt32(cbopcode.Text);
            da.Dispose();
            da = new SqlDataAdapter("select Name from Doctor ", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cbodoctor.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            da.Dispose();
            da = new SqlDataAdapter("select Name from referal ", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cboreferal.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            da.Dispose();
            da = new SqlDataAdapter("select test from Test_master order by test ", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                // dgvbilltest.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            da.Dispose();

            da = new SqlDataAdapter("select test,method,unit,reference_range from test_master order by test", con);
            ds = new DataSet();
            da.Fill(ds, "test_master");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                // grtestmast.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                // dgvostest.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                // dgvostestos.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                //dgrutest.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }

            da.Dispose();
            //SqlDataAdapter adapter = new SqlDataAdapter("select grp,sgrp from Group_master order by grp", con);
            //ds = new DataSet();
            //adapter.Fill(ds, "Group_master");
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    cboprofilename.Items.Add(ds.Tables[0].Rows[i][0].ToString());

            //}
            //adapter.Dispose();




            da = new SqlDataAdapter("select cc,comp,address,year_start,year_end,pathologist,biochemist from company", con);
            DataSet ds2 = new DataSet();
            da.Fill(ds2);

            con.Close();
            cbosex.Items.Add("Male");
            cbosex.Items.Add("Female");
            cbosex.Items.Add("Mch");
            cbosex.Items.Add("Fch");

            cbomy1.Items.Add("Months");
            cbomy1.Items.Add("Yrs.");
            cbomy1.Text = "Yrs.";
            rmdelete.Enabled = false;
            //RMMERGE.Enabled = false;
            // reentry.Enabled = false;
            txtage.Text = "";
            //txtdue.Text = "0.00";
            //txtpaid.Text = "0.00";
            //RE_Neutrophild.Text = "0";
            //RE_Eosinophils.Text = "0";
            //RE_Lymphocytes.Text = "0";
            //RE_Basophils.Text = "0";
            //RE_Monocytes.Text = "0";
            //RE_Twbc.Text = "0";
            //RE_Hb.Text = "0.00";


            Double texp = 0;
            //txtusg.Text = "0.00";
            //txtendoscopy.Text = "0.00";
            //txtecg.Text = "0.00";
            //txtxray.Text = "0.00";
            //txtctscan.Text = "0.00";
            //txteeg.Text = "0.00";
            //txtextra.Text = "0.00";
            //txtcf.Text = "0.00";
            //txtdoppler.Text = "0.00";
            //txtexpenditure.Text = "0.00";
            //Double tbal = 0;
            //txtpaid.Text = "0.00";
            //txtreferal.Text = "0.00";
            //txtbalance.Text = "0.00";
            RMBILLING.Enabled = false;

            //t.Show("M:12-18 F:11-16", BDc_Hb);
            //t.Show("M:12-18 F:11-16", BDc_Hb);
            //t.SetToolTip(this.BDc_Hb, "M:12-18 F:11-16");
            //private void BDc_Hb_MouseHover(object sender, EventArgs e)
            //{
            //    t.Show("M:12-18 F:11-16", BDc_Hb);
            //}
        }

        private void RMSAVE_Click(object sender, EventArgs e)
        {
            String Sqlstr = "";
            con.Close();
            con.Open();
            if (MessageBox.Show("Save ? ", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                if (cboname.Text != "")
                {
                    //btnbill1.Enabled = true;
                    pat_name = cboname.Text;
                    Sqlstr = "select cc,pcode,patient_name,sex,age,doctor,date_exam,month_year,Scn,Tpt";
                    Sqlstr = Sqlstr + " from OPD_Master where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
                    da = new SqlDataAdapter(Sqlstr, con);
                    ds1 = new DataSet();
                    da.Fill(ds1);

                    if (ds1.Tables[0].Rows.Count == 0)
                    {


                        if (txtage.Text == "")
                            txtage.Text = "0";

                        //if (txtdue.Text == "")
                        //    txtdue.Text = "0.00";

                        //if (txtpaid.Text == "")
                        //    txtpaid.Text = "0.00";

                        dd = dtreport.Text.Substring(0, 2).ToString();
                        mm = this.dtreport.Text.Substring(3, 2).ToString();
                        yy = this.dtreport.Text.Substring(6, 4).ToString();
                        //String tt = this.dtreport.Text.Substring(11,5).ToString();
                        repdt1 = DateTime.ParseExact(dd + "/" + mm + "/" + yy, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        //dd1 = txttpt.Text.Substring(0, 2).ToString();
                        //mm1 = this.txttpt.Text.Substring(3, 2).ToString();
                        //yy1 = this.txttpt.Text.Substring(6, 4).ToString();
                        //deldt1 = DateTime.ParseExact(dd1 + "/" + mm1 + "/" + yy1, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        Sqlstr = "insert into OPD_Master (cc,Patient_name,pcode,sex,age,doctor,date_exam,month_year,Scn,Tpt,referal) values('" + Convert.ToInt32(txtcompanycode.Text) + "','" + this.cboname.Text + "','" + Convert.ToInt32(cbopcode.Text) + "','" + this.cbosex.Text + "','" + Convert.ToInt32(txtage.Text) + "','" + this.cbodoctor.Text + "','" + repdt1 + "','" + cbomy1.Text + "', '" + txtscn.Text + "','" + txttpt.Text + "','" + cboreferal.Text + "')";
                        cmd = new SqlCommand(Sqlstr, con);
                        cmd.ExecuteNonQuery();
                        Sqlstr = "";
                        cbopcode.Items.Add(cbopcode.Text);
                        pidr = Convert.ToInt32(cbopcode.Text);
                        //String ostrue = "";


                        cmd1 = new SqlCommand("insert into opd_detail (cc,pcode,date_exam,test,doctor) values('" + Convert.ToInt32(txtcompanycode.Text) + "','" + Convert.ToInt32(cbopcode.Text) + "','" + dgvregn.Rows[i].Cells[0].Value + "','" + dgvregn.Rows[i].Cells[1].Value + "', '" + dgvregn.Rows[i].Cells[2].Value + "')", con);
                        cmd1.ExecuteNonQuery();
                        //dataGridView1.Rows.Clear();
                        //da.Dispose();

                        //Sqlstr = "select date_exam,pcode,patient_name,scn as mob,usg,endoscopy,xray,ctscan,ecg,eeg,extra,cfees,doppler,due_amount,paid_amount,expenditure,referal,balance,tpt,doctor";
                        //Sqlstr = Sqlstr + " from OPD_Master ";
                        //da = new SqlDataAdapter(Sqlstr, con);
                        //ds1 = new DataSet();
                        //da.Fill(ds1);
                        // dataGridView1.DataSource = ds1.Tables[0].DefaultView;

                    }
                    else
                    {

                        if (txtage.Text == "")
                            txtage.Text = "0";

                        //if (txtdue.Text == "")
                        //    txtdue.Text = "0.00";

                        //if (txtpaid.Text == "")
                        //    txtpaid.Text = "0.00";

                        dd = dtreport.Text.Substring(0, 2).ToString();
                        mm = this.dtreport.Text.Substring(3, 2).ToString();
                        yy = this.dtreport.Text.Substring(6, 4).ToString();
                        //String tt = this.dtreport.Text.Substring(11, 8).ToString();
                        repdt1 = DateTime.ParseExact(dd + "/" + mm + "/" + yy, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);


                        Sqlstr = "update OPD_Master set cc='" + Convert.ToInt32(txtcompanycode.Text) + "',Patient_name='" + this.cboname.Text + "',pcode='" + Convert.ToInt32(cbopcode.Text) + "',sex='" + this.cbosex.Text + "',age='" + Convert.ToInt32(txtage.Text) + "',doctor='" + this.cbodoctor.Text + "',date_exam='" + repdt1 + "',month_year='" + cbomy1.Text + "',Scn='" + txtscn.Text + "',Tpt='" + txttpt.Text + "',referal='" + cboreferal.Text + "' WHERE Pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
                        cmd = new SqlCommand(Sqlstr, con);
                        cmd.ExecuteNonQuery();
                        Sqlstr = "";

                        pidr = Convert.ToInt32(cbopcode.Text);

                        cmd1 = new SqlCommand("delete opd_detail where pcode='" + Convert.ToInt32(cbopcode.Text) + "'", con);
                        cmd1.ExecuteNonQuery();
                        cmd1 = new SqlCommand("insert into opd_detail (cc,pcode,date_exam,test,doctor) values('" + Convert.ToInt32(txtcompanycode.Text) + "','" + Convert.ToInt32(cbopcode.Text) + "','" + dgvregn.Rows[i].Cells[0].Value + "','" + dgvregn.Rows[i].Cells[1].Value + "', '" + dgvregn.Rows[i].Cells[2].Value + "')", con);
                        cmd1.ExecuteNonQuery();
                    
                    }

                    //Sqlstr = "select date_exam,test,doctor";
                    //Sqlstr = Sqlstr + " from OPD_Detail where pcode='"+cbopcode.Text +"'";
                    //da = new SqlDataAdapter(Sqlstr, con);
                    //ds1 = new DataSet();
                    //da.Fill(ds1);
                    //dataGridView1.DataSource = ds1.Tables[0].DefaultView;



                    //dgvregn.Rows.Clear();
                    //for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                    //{
                    //    if (ds1.Tables[0].Rows[j][0].ToString() != null)
                    //    {
                    //        dgvregn.Rows.Add();
                    //        dgvregn.Rows[j].Cells[0].Value = ds1.Tables[0].Rows[j][0].ToString();
                    //        dgvregn.Rows[j].Cells[1].Value = ds1.Tables[0].Rows[j][1].ToString();
                    //        dgvregn.Rows[j].Cells[2].Value = ds1.Tables[0].Rows[j][2].ToString();
                    //        //dgvregn.Rows[j].Cells[3].Value = ds1.Tables[0].Rows[j][3].ToString();
                    //        //dgvregn.Rows[j].Cells[4].Value = ds1.Tables[0].Rows[j][4].ToString();
                    //        //dgvregn.Rows[j].Cells[5].Value = ds1.Tables[0].Rows[j][5].ToString();
                    //        //dgvregn.Rows[j].Cells[6].Value = ds1.Tables[0].Rows[j][6].ToString();
                    //        //dgvregn.Rows[j].Cells[7].Value = ds1.Tables[0].Rows[j][7].ToString();
                    //        //dgvregn.Rows[j].Cells[8].Value = ds1.Tables[0].Rows[j][8].ToString();
                    //        //dgvregn.Rows[j].Cells[9].Value = ds1.Tables[0].Rows[j][9].ToString();
                    //        //dgvregn.Rows[j].Cells[10].Value = ds1.Tables[0].Rows[j][10].ToString();
                    //        //dgvregn.Rows[j].Cells[11].Value = ds1.Tables[0].Rows[j][11].ToString();
                    //        //dataGridView1.Rows[j].Cells[12].Value = ds1.Tables[0].Rows[j][12].ToString();
                    //        //dataGridView1.Rows[j].Cells[13].Value = ds1.Tables[0].Rows[j][13].ToString();
                    //        //dataGridView1.Rows[j].Cells[14].Value = ds1.Tables[0].Rows[j][14].ToString();
                    //        //dataGridView1.Rows[j].Cells[15].Value = ds1.Tables[0].Rows[j][15].ToString();
                    //        //dataGridView1.Rows[j].Cells[16].Value = ds1.Tables[0].Rows[j][16].ToString();
                    //        //dataGridView1.Rows[j].Cells[17].Value = ds1.Tables[0].Rows[j][17].ToString();
                    //        //dataGridView1.Rows[j].Cells[18].Value = ds1.Tables[0].Rows[j][18].ToString();
                    //        //dataGridView1.Rows[j].Cells[19].Value = ds1.Tables[0].Rows[j][19].ToString();
                    //        //dataGridView1.Rows[j].Cells[20].Value = ds1.Tables[0].Rows[j][20].ToString();







                    //    }
                    //}








                    pat_name = cboname.Text;
                    //dgvbill.Hide();
                    cboname.Focus();
                    //reentry.Enabled = true;
                    rmdelete.Enabled = true;
                    //RMMERGE.Enabled = true;
                    RMBILLING.Enabled = true;



                }
                else
                {
                    MessageBox.Show("name can't be blank");
                    cboname.Focus();
                }

            }
        }

        private void rmdelete_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            if (MessageBox.Show("Delete ? ", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                if (cbopcode.Text != "")
                {
                    cmd = new SqlCommand("delete from OPD_Master where  pcode='" + Convert.ToInt32(cbopcode.Text) + "'", con);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("delete from OPD_Detail where  pcode='" + Convert.ToInt32(cbopcode.Text) + "'", con);
                    cmd.ExecuteNonQuery();


                    cmd = new SqlCommand("delete from cbj where  vono='" + (cbopcode.Text) + "' and trncd='Test'", con);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("delete from billl where pcode='" + Convert.ToInt32(cbopcode.Text) + "'", con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("All Test Deleted in this Reg.No.");
                }
                else
                {
                    MessageBox.Show("Select Reg.No.");
                }
            }
        }

        private void RMCANCEL_Click(object sender, EventArgs e)
        {

        }

        private void Rmsearch_Click(object sender, EventArgs e)
        {
            //Frmserch repsr = new Frmserch();
            //repsr.Show();
            dd = dtreport.Text.Substring(0, 2).ToString();
            mm = this.dtreport.Text.Substring(3, 2).ToString();
            yy = this.dtreport.Text.Substring(6, 4).ToString();
            repdt1 = DateTime.ParseExact(dd + "/" + mm + "/" + yy, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            String Sqlstr = "select date_exam,pcode,patient_name,scn as mob,acdes,doctor";
            Sqlstr = Sqlstr + " from OPD_Master where date_exam='" + repdt1 + "'";
            da = new SqlDataAdapter(Sqlstr, con);
            ds1 = new DataSet();
            da.Fill(ds1);
            //dataGridView1.DataSource = ds1.Tables[0].DefaultView;



            //dataGridView1.Rows.Clear();
            //for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            //{
            //    if (ds1.Tables[0].Rows[j][0].ToString() != null)
            //    {
            //        dataGridView1.Rows.Add();
            //        dataGridView1.Rows[j].Cells[0].Value = ds1.Tables[0].Rows[j][0].ToString();
            //        dataGridView1.Rows[j].Cells[1].Value = ds1.Tables[0].Rows[j][1].ToString();
            //        dataGridView1.Rows[j].Cells[2].Value = ds1.Tables[0].Rows[j][2].ToString();
            //        dataGridView1.Rows[j].Cells[3].Value = ds1.Tables[0].Rows[j][3].ToString();
            //        dataGridView1.Rows[j].Cells[4].Value = ds1.Tables[0].Rows[j][4].ToString();
            //        dataGridView1.Rows[j].Cells[5].Value = ds1.Tables[0].Rows[j][5].ToString();
            //        //dataGridView1.Rows[j].Cells[6].Value = ds1.Tables[0].Rows[j][6].ToString();
            //        //dataGridView1.Rows[j].Cells[7].Value = ds1.Tables[0].Rows[j][7].ToString();
            //        //dataGridView1.Rows[j].Cells[8].Value = ds1.Tables[0].Rows[j][8].ToString();
            //        //dataGridView1.Rows[j].Cells[9].Value = ds1.Tables[0].Rows[j][9].ToString();
            //        //dataGridView1.Rows[j].Cells[10].Value = ds1.Tables[0].Rows[j][10].ToString();
            //        //dataGridView1.Rows[j].Cells[11].Value = ds1.Tables[0].Rows[j][11].ToString();
            //        //dataGridView1.Rows[j].Cells[12].Value = ds1.Tables[0].Rows[j][12].ToString();
            //        //dataGridView1.Rows[j].Cells[13].Value = ds1.Tables[0].Rows[j][13].ToString();
            //        //dataGridView1.Rows[j].Cells[14].Value = ds1.Tables[0].Rows[j][14].ToString();
            //        //dataGridView1.Rows[j].Cells[15].Value = ds1.Tables[0].Rows[j][15].ToString();
            //        //dataGridView1.Rows[j].Cells[16].Value = ds1.Tables[0].Rows[j][16].ToString();
            //        //dataGridView1.Rows[j].Cells[17].Value = ds1.Tables[0].Rows[j][17].ToString();
            //        //dataGridView1.Rows[j].Cells[18].Value = ds1.Tables[0].Rows[j][18].ToString();
            //        //dataGridView1.Rows[j].Cells[19].Value = ds1.Tables[0].Rows[j][19].ToString();
            //    }
            //}
            //da.Dispose();
            //Sqlstr = "select date_exam,'','','',sum(due_amount),sum(paid_amount),sum(expenditure),sum(referal),sum(balance),sum(cfees)";
            //Sqlstr = Sqlstr + " from OPD_Master where date_exam='" + repdt1 + "' group by date_exam";
            //da = new SqlDataAdapter(Sqlstr, con);
            //ds1 = new DataSet();
            //da.Fill(ds1);
            ////dataGridView1.DataSource = ds1.Tables[0].DefaultView;
            //int k = 0;
            //dgv2.Rows.Clear();
            //dgv2.Rows.Add();
            //dgv2.Rows[k].Cells[0].Value = ds1.Tables[0].Rows[k][0].ToString();
            //dgv2.Rows[k].Cells[1].Value = ds1.Tables[0].Rows[k][1].ToString();
            //dgv2.Rows[k].Cells[2].Value = ds1.Tables[0].Rows[k][2].ToString();
            //dgv2.Rows[k].Cells[3].Value = ds1.Tables[0].Rows[k][3].ToString();
            //dgv2.Rows[k].Cells[4].Value = ds1.Tables[0].Rows[k][4].ToString();
            //dgv2.Rows[k].Cells[5].Value = ds1.Tables[0].Rows[k][5].ToString();
            //dgv2.Rows[k].Cells[6].Value = ds1.Tables[0].Rows[k][6].ToString();
            //dgv2.Rows[k].Cells[7].Value = ds1.Tables[0].Rows[k][7].ToString();
            //dgv2.Rows[k].Cells[8].Value = ds1.Tables[0].Rows[k][8].ToString();
            //dgv2.Rows[k].Cells[9].Value = ds1.Tables[0].Rows[k][9].ToString();
            ////dgv2.Rows[k].Cells[10].Value = ds1.Tables[0].Rows[k][10].ToString();
            ////dgv2.Rows[k].Cells[11].Value = ds1.Tables[0].Rows[k][11].ToString();
            ////dgv2.Rows[k].Cells[12].Value = ds1.Tables[0].Rows[k][12].ToString();
            ////dgv2.Rows[k].Cells[13].Value = ds1.Tables[0].Rows[k][13].ToString();
            ////dgv2.Rows[k].Cells[14].Value = ds1.Tables[0].Rows[k][14].ToString();
            ////dgv2.Rows[k].Cells[15].Value = ds1.Tables[0].Rows[k][15].ToString();
            ////dgv2.Rows[k].Cells[16].Value = ds1.Tables[0].Rows[k][16].ToString();
            ////dgv2.Rows[k].Cells[17].Value = ds1.Tables[0].Rows[k][17].ToString();
            ////dgv2.Rows[k].Cells[18].Value = ds1.Tables[0].Rows[k][18].ToString();
            ////dgv2.Rows[k].Cells[19].Value = ds1.Tables[0].Rows[k][19].ToString();     
                    
                    
        
        }

        private void RMBILLING_Click(object sender, EventArgs e)
        {
            pat_name = cboname.Text;
            pidr = Convert.ToInt32(cbopcode.Text);
            dd = dtreport.Text.Substring(0, 2).ToString();
            mm = this.dtreport.Text.Substring(3, 2).ToString();
            yy = this.dtreport.Text.Substring(6, 4).ToString();
            repdt1 = DateTime.ParseExact(dd + "/" + mm + "/" + yy, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);


            Frmopdbillentry FPBILLent = new Frmopdbillentry();
            FPBILLent.Show();
        }

        private void RMADDNEXT_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("select max(pcode) from OPD_Master", con);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows[0][0].ToString() == "")
            {
                cbopcode.Text = "1";
            }
            else
            {
                int p = (Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) + 1);
                cbopcode.Text = Convert.ToString(p);
            }
            pidr = Convert.ToInt32(cbopcode.Text);



            rmdelete.Enabled = false;

            txtage.Text = "";
            //txtdue.Text = "0.00";
            //txtpaid.Text = "0.00";




            cboname.Text = "";
            cbodoctor.Text = "";
            cbosex.Text = "";
            txtscn.Text = "";
            txttpt.Text = "";
            cboreferal.Text = "";
            //txtusg.Text = "0.00";
            //txtendoscopy.Text = "0.00";
            //txtecg.Text = "0.00";
            //txtxray.Text = "0.00";
            //txtctscan.Text = "0.00";
            //txteeg.Text = "0.00";
            //txtextra.Text = "0.00";
            //txtcf.Text = "0.00";
            //txtdoppler.Text = "0.00";
            //txtexpenditure.Text = "0.00";
            //Double tbal = 0;
            //txtpaid.Text = "0.00";
            //txtreferal.Text = "0.00";
            //txtbalance.Text = "0.00";
          
        
        
        
        
        }

        private void callnumber(KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && !Char.IsPunctuation(e.KeyChar) && e.KeyChar != Delete;
        }

        private void cbopcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            pidr = Convert.ToInt32(cbopcode.Text);
            RMBILLING.Enabled = true;
            String strsql1 = "select cc,pcode,patient_name,sex,age,doctor,date_exam,month_year,Scn,Tpt,referal";
            strsql1 = strsql1 + " from opd_master where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
            da = new SqlDataAdapter(strsql1, con);
            ds1 = new DataSet();
            da.Fill(ds1);
            if (ds1.Tables[0].Rows.Count != 0)
            {
                txtcompanycode.Text = ds1.Tables[0].Rows[0][0].ToString();
                cbopcode.Text = ds1.Tables[0].Rows[0][1].ToString();
                cboname.Text = ds1.Tables[0].Rows[0][2].ToString();

                cbosex.Text = ds1.Tables[0].Rows[0][3].ToString();
                txtage.Text = ds1.Tables[0].Rows[0][4].ToString();
                cbodoctor.Text = ds1.Tables[0].Rows[0][5].ToString();
                dtreport.Text = ds1.Tables[0].Rows[0][6].ToString();

                cbomy1.Text = ds1.Tables[0].Rows[0][7].ToString();
                txtscn.Text = ds1.Tables[0].Rows[0][8].ToString();
                txttpt.Text = ds1.Tables[0].Rows[0][9].ToString();
                //txtusg.Text = ds1.Tables[0].Rows[0][10].ToString();
                //txtendoscopy.Text = ds1.Tables[0].Rows[0][11].ToString();
                //txtxray.Text = ds1.Tables[0].Rows[0][12].ToString();
                //txtctscan.Text = ds1.Tables[0].Rows[0][13].ToString();
                //txtecg.Text = ds1.Tables[0].Rows[0][14].ToString();
                //txteeg.Text = ds1.Tables[0].Rows[0][15].ToString();
                //txtextra.Text = ds1.Tables[0].Rows[0][16].ToString();
                //txtcf.Text = ds1.Tables[0].Rows[0][10].ToString();
                ////txtdoppler.Text = ds1.Tables[0].Rows[0][18].ToString();

                //txtdue.Text = ds1.Tables[0].Rows[0][11].ToString();
                //txtpaid.Text = ds1.Tables[0].Rows[0][12].ToString();
                //txtexpenditure.Text = ds1.Tables[0].Rows[0][13].ToString();
                //txtreferal.Text = ds1.Tables[0].Rows[0][14].ToString();
                //txtbalance.Text = ds1.Tables[0].Rows[0][15].ToString();
                cboreferal.Text = ds1.Tables[0].Rows[0][10].ToString();

            }
            String Sqlstr = "";
            Sqlstr = "select date_exam,test,doctor";
            Sqlstr = Sqlstr + " from OPD_Detail where  pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
            da = new SqlDataAdapter(Sqlstr, con);
            ds1 = new DataSet();
            da.Fill(ds1);
            dgvregn.Rows.Clear();
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
                if (ds1.Tables[0].Rows[j][0].ToString() != null)
                {
                    dgvregn.Rows.Add();
                    dgvregn.Rows[j].Cells[0].Value = ds1.Tables[0].Rows[j][0].ToString();
                    dgvregn.Rows[j].Cells[1].Value = ds1.Tables[0].Rows[j][1].ToString();
                    dgvregn.Rows[j].Cells[2].Value = ds1.Tables[0].Rows[j][2].ToString();
                }
            }
        
        
        
        }

        private void rdprint_Click(object sender, EventArgs e)
        {
            Frmpathbill_opd fpopd = new Frmpathbill_opd();
            fpopd.Show();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    
    
    
    }
}
