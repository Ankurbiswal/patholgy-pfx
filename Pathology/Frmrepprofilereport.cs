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
    public partial class Frmrepprofilereport : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds, ds2,ds3;
        SqlDataReader dr;
        
        public Frmrepprofilereport()
        {
            InitializeComponent();
        }

        private void Frmrepprofilereport_Load(object sender, EventArgs e)
        {
            Class1 objclass = new Class1();
            con = new SqlConnection(objclass.arun_con());

            con.Open();
            cmd = new SqlCommand("select cc,comp,year_start,year_end,regno from setup");
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbocode.Text = dr.GetValue(4).ToString();
                //label4.Text = dr.GetValue(1).ToString();
                //dtfrom.Text = dr.GetValue(2).ToString();
            }
            dr.Close();
            da = new SqlDataAdapter("select patient_name,pcode from patient_master where pcode='" + cbocode.Text + "' order by pcode", con);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
                cboname.Text = ds.Tables[0].Rows[0][0].ToString();


            da.Dispose();
            da = new SqlDataAdapter("select  pcode from patient_master order by pcode", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                //this.cboname.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                this.cbocode.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }

            da.Dispose();



            da = new SqlDataAdapter("select cc,comp,address,year_start,year_end,pathologist,biochemist,telphoneno,email,cstno,address1,faxno from company", con);
            ds2 = new DataSet();
            da.Fill(ds2);
            da.Dispose();
            radioButton2.Checked = true;
        }

        private void btnshowprofile_Click(object sender, EventArgs e)
        {

            da = new SqlDataAdapter("select note from profile_note where pcode='" + cbocode.Text + "' and type='" + cboprofile.Text + "' order by pcode", con);
            DataSet ds3 = new DataSet();
            da.Fill(ds3);
            String note = "";

            if (ds3.Tables[0].Rows.Count>0)
            {
            if (ds3.Tables[0].Rows[0][0].ToString().Trim ()=="")
            {
          note = "";
            }
            else
            {
          note = ds3.Tables[0].Rows[0][0].ToString();
            }
                da.Dispose();
            }
            String qrdata = cbocode.Text.Trim()+cboname.Text.Trim();
            BarcodeLib.Barcode.Linear qrcode = new BarcodeLib.Barcode.Linear();
           // qrcode.Type = BarcodeLib.Barcode.BarcodeType.CODE39;
            qrcode.Data = qrdata;
            // qrcode.ModuleSize = 4;
            //qrcode.ECL = QRCodeErrorCorrectionLevel.L;
            //qrcode.ImageHeight = 118;
            //qrcode.ImageWidth = 118;

            // Save & output QR Code barcode image to your system
            qrcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;
            byte[] imageData = qrcode.drawBarcodeAsBytes();
            
            
            
            //SqlCommand command = new SqlCommand("itmgrp", con);
            SqlDataAdapter adapter = new SqlDataAdapter("select b.pcode,b.patient_name,b.date_exam,b.scn as telphoneno,b.age,b.sex,a.test,a.method,a.result,a.unit,a.reference_range as normal_range,a.grp,a.sgrp,a.type,b.month_year,b.doctor,a.pcode,a.grp_code,a.srlno,b.tpt from profile_data a,patient_master b where (a.pcode=b.pcode) and b.pcode='" + cbocode.Text + "' and a.type='" + cboprofile.Text + "' and a.result!=' ' order by Convert(int,a.grp_code),Convert(int,a.srlno)  ", con);
            //SqlDataAdapter adapter = new SqlDataAdapter("select b.pcode,b.patient_name,b.date_exam,b.telphoneno,b.age,b.sex,a.test,a.method,a.result,a.unit,a.reference_range,a.grp,a.sgrp,a.pcode,a.type from profile_data where (a.pcode=b.pcode) and b.pcode='" + cbocode.Text + "' and a.type='" + cboprofile.Text + "'   ", con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "outsource");
            ds.Tables[0].Columns.Add(new DataColumn("barcode", typeof(byte[])));
            if (ds.Tables[0].Rows.Count > 0)
            {

                DataTable dtv = new DataTable();
                dtv = ds.Tables[0];

                Pathology_Ds dsh = new Pathology_Ds();
                DataTable dt = new DataTable();
                // Ds_hope dsh = new Ds_hope();
                //  DataTable dt = new DataTable();
                dt = dsh.Tables.Add("outsource");
                dt.Columns.Add("pcode", System.Type.GetType("System.Int32"));
                dt.Columns.Add("patient_name", System.Type.GetType("System.String"));
                dt.Columns.Add("date_exam", System.Type.GetType("System.DateTime"));
                dt.Columns.Add("telphoneno", System.Type.GetType("System.String"));

                dt.Columns.Add("age", System.Type.GetType("System.String"));
                dt.Columns.Add("sex", System.Type.GetType("System.String"));
                dt.Columns.Add("test", System.Type.GetType("System.String"));
                dt.Columns.Add("method", System.Type.GetType("System.String"));
                dt.Columns.Add("result", System.Type.GetType("System.String"));
                dt.Columns.Add("unit", System.Type.GetType("System.String"));

                dt.Columns.Add("normal_range", System.Type.GetType("System.String"));
                dt.Columns.Add("grp", System.Type.GetType("System.String"));
                dt.Columns.Add("sgrp", System.Type.GetType("System.String"));
                dt.Columns.Add("type", System.Type.GetType("System.String"));
                dt.Columns.Add("month_year", System.Type.GetType("System.String"));
                dt.Columns.Add("doctor", System.Type.GetType("System.String"));

                dt.Columns.Add("grp_code", System.Type.GetType("System.String"));
                dt.Columns.Add("srlno", System.Type.GetType("System.String"));
                dt.Columns.Add("tpt", System.Type.GetType("System.String"));
                dt.Columns.Add("barcode", System.Type.GetType("System.Byte[]"));
                //dt.Columns.Add("month_year", System.Type.GetType("System.String"));
                //dt.Columns.Add("doctor", System.Type.GetType("System.String"));

                for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                {
                    //if (dtv.Rows[k][9].ToString() == "")
                    //{
                    //    dtv.Rows[k][9] = "0.00";
                    //}
                    //  dt.Rows.Add(Convert.ToDouble(dtv.Rows[k][0]), dtv.Rows[k][1], dtv.Rows[k][2], Convert.ToDateTime(dtv.Rows[k][3]), dtv.Rows[k][4], dtv.Rows[k][5], dtv.Rows[k][6], dtv.Rows[k][7], dtv.Rows[k][8], Convert.ToDouble(dtv.Rows[k][9]), Convert.ToDouble(dtv.Rows[k][10]), Convert.ToDouble(dtv.Rows[k][11]), Convert.ToDouble(dtv.Rows[k][12]), Convert.ToDouble(dtv.Rows[k][13]), Convert.ToDouble(dtv.Rows[k][14]), Convert.ToDouble(dtv.Rows[k][15]), Convert.ToDouble(dtv.Rows[k][16]), Convert.ToDouble(dtv.Rows[k][17]), Convert.ToDouble(dtv.Rows[k][18]), dtv.Rows[k][19], dtv.Rows[k][20], dtv.Rows[k][21], dtv.Rows[k][22], dtv.Rows[k][23]);
                    dt.Rows.Add(Convert.ToDouble(dtv.Rows[k][0]), dtv.Rows[k][1], Convert.ToDateTime(dtv.Rows[k][2]), dtv.Rows[k][3], dtv.Rows[k][4], dtv.Rows[k][5], dtv.Rows[k][6], dtv.Rows[k][7], dtv.Rows[k][8], dtv.Rows[k][9], dtv.Rows[k][10], dtv.Rows[k][11], dtv.Rows[k][12], dtv.Rows[k][13], dtv.Rows[k][14], dtv.Rows[k][15], dtv.Rows[k][16], dtv.Rows[k][17], dtv.Rows[k][18], imageData);

                } 


                
                
                
                
                
                if (radioButton1.Checked == true)
                {

                    Reportprofilewonor cashbankrep = new Reportprofilewonor();
                    // cashbankrep.SetDatabaseLogon("sa", "software", @".\SQLEXPRESS", "pathology2627");
                    cashbankrep.SetDataSource(dt);
                    crystalReportViewer1.ReportSource = cashbankrep;
                    cashbankrep.SetParameterValue(0, ds2.Tables[0].Rows[0][5].ToString());
                    cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows[0][6].ToString());
                    ////cashbankrep.SetParameterValue(2, clbal);
                    cashbankrep.SetParameterValue(2, cboprofile.Text);
                    cashbankrep.SetParameterValue(3, note);
                    cashbankrep.SetParameterValue(4, ds2.Tables[0].Rows[0][9].ToString());
                    cashbankrep.SetParameterValue(5, ds2.Tables[0].Rows[0][10].ToString());
                    cashbankrep.SetParameterValue(6, ds2.Tables[0].Rows[0][11].ToString());
                    
                    //cashbankrep.SetParameterValue(3, label4.Text);
                    crystalReportViewer1.Refresh();
                }
                else
                {
                    Repprofilereport cashbankrep = new Repprofilereport();
                    // cashbankrep.SetDatabaseLogon("sa", "software", @".\SQLEXPRESS", "pathology2627");
                    cashbankrep.SetDataSource(dt);
                    crystalReportViewer1.ReportSource = cashbankrep;
                    cashbankrep.SetParameterValue(0, ds2.Tables[0].Rows[0][5].ToString());
                    cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows[0][6].ToString());
                    ////cashbankrep.SetParameterValue(2, clbal);
                    cashbankrep.SetParameterValue(2, cboprofile.Text);
                    cashbankrep.SetParameterValue(3, note);
                    cashbankrep.SetParameterValue(4, ds2.Tables[0].Rows[0][9].ToString());
                    cashbankrep.SetParameterValue(5, ds2.Tables[0].Rows[0][10].ToString());
                    cashbankrep.SetParameterValue(6, ds2.Tables[0].Rows[0][11].ToString());
                    crystalReportViewer1.Refresh();
                
                }
                
                
                }
            else
            {
                MessageBox.Show("No record found");
            }
        }

        private void cbocode_SelectedIndexChanged(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("select distinct type,pcode  from profile_data where pcode='" + cbocode.Text + "' order by type,pcode", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                this.cboprofile.Items.Add(ds.Tables[0].Rows[i][0].ToString());

            }
            da.Dispose();
            cboprofile.Text = ds.Tables[0].Rows[0][0].ToString();
            da = new SqlDataAdapter("select patient_name,pcode from patient_master where pcode='" + cbocode.Text + "' order by pcode", con);
            ds = new DataSet();
            da.Fill(ds);
            cboname.Text = ds.Tables[0].Rows[0][0].ToString();

            da.Dispose();
        
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnnote_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("select note from profile_note where pcode='" + cbocode.Text + "' and type='" + cboprofile.Text + "' order by pcode", con);
            DataSet ds3 = new DataSet();
            da.Fill(ds3);
            String note = "";

            if (ds3.Tables[0].Rows.Count > 0)
            {
                if (ds3.Tables[0].Rows[0][0].ToString().Trim() == "")
                {
                    note = "";
                }
                else
                {
                    note = ds3.Tables[0].Rows[0][0].ToString();
                }
                da.Dispose();
            }



            //SqlCommand command = new SqlCommand("itmgrp", con);
            SqlDataAdapter adapter = new SqlDataAdapter("select b.pcode,b.patient_name,b.date_exam,b.scn as telphoneno,b.age,b.sex,a.test,a.method,a.result,a.unit,a.reference_range as normal_range,a.grp,a.sgrp,a.type,b.month_year,b.doctor,a.pcode,a.grp_code,a.srlno,b.tpt from profile_data a,patient_master b where (a.pcode=b.pcode) and b.pcode='" + cbocode.Text + "' and a.type='" + cboprofile.Text + "' and a.result!=' ' order by Convert(int,a.grp_code),Convert(int,a.srlno)  ", con);
            //SqlDataAdapter adapter = new SqlDataAdapter("select b.pcode,b.patient_name,b.date_exam,b.telphoneno,b.age,b.sex,a.test,a.method,a.result,a.unit,a.reference_range,a.grp,a.sgrp,a.pcode,a.type from profile_data where (a.pcode=b.pcode) and b.pcode='" + cbocode.Text + "' and a.type='" + cboprofile.Text + "'   ", con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "outsource");

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (radioButton1.Checked == true)
                {

                    Reportnote cashbankrep = new Reportnote();
                    // cashbankrep.SetDatabaseLogon("sa", "software", @".\SQLEXPRESS", "pathology2627");
                    cashbankrep.SetDataSource(ds);
                    crystalReportViewer1.ReportSource = cashbankrep;
                    cashbankrep.SetParameterValue(0, ds2.Tables[0].Rows[0][5].ToString());
                    cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows[0][6].ToString());
                    ////cashbankrep.SetParameterValue(2, clbal);
                    cashbankrep.SetParameterValue(2, cboprofile.Text);
                    cashbankrep.SetParameterValue(3, note);
                    //cashbankrep.SetParameterValue(3, label4.Text);
                    crystalReportViewer1.Refresh();
                }
                else
                {
                    Reportnote cashbankrep = new Reportnote();
                    // cashbankrep.SetDatabaseLogon("sa", "software", @".\SQLEXPRESS", "pathology2627");
                    cashbankrep.SetDataSource(ds);
                    crystalReportViewer1.ReportSource = cashbankrep;
                    cashbankrep.SetParameterValue(0, ds2.Tables[0].Rows[0][5].ToString());
                    cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows[0][6].ToString());
                    ////cashbankrep.SetParameterValue(2, clbal);
                    cashbankrep.SetParameterValue(2, cboprofile.Text);
                    cashbankrep.SetParameterValue(3, note);
                    //cashbankrep.SetParameterValue(3, label4.Text);
                    crystalReportViewer1.Refresh();

                }


            }
            else
            {
                MessageBox.Show("No record found");
            }
        }

        private void btngraph_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("select note from profile_note where pcode='" + cbocode.Text + "' and type='" + cboprofile.Text + "' order by pcode", con);
            DataSet ds3 = new DataSet();
            da.Fill(ds3);
            String note = "";

            if (ds3.Tables[0].Rows.Count > 0)
            {
                if (ds3.Tables[0].Rows[0][0].ToString().Trim() == "")
                {
                    note = "";
                }
                else
                {
                    note = ds3.Tables[0].Rows[0][0].ToString();
                }
                da.Dispose();
            }



            //SqlCommand command = new SqlCommand("itmgrp", con);
            SqlDataAdapter adapter = new SqlDataAdapter("select b.pcode,b.patient_name,b.date_exam,b.scn as telphoneno,b.age,b.sex,a.test,a.method,a.result,a.unit,a.reference_range as normal_range,a.grp,a.sgrp,a.type,b.month_year,b.doctor,a.pcode,a.grp_code,a.srlno,b.tpt from profile_data a,patient_master b where (a.pcode=b.pcode) and b.pcode='" + cbocode.Text + "' and a.type='" + cboprofile.Text + "' and a.result!=' ' order by Convert(int,a.grp_code),Convert(int,a.srlno)  ", con);
            //SqlDataAdapter adapter = new SqlDataAdapter("select b.pcode,b.patient_name,b.date_exam,b.telphoneno,b.age,b.sex,a.test,a.method,a.result,a.unit,a.reference_range,a.grp,a.sgrp,a.pcode,a.type from profile_data where (a.pcode=b.pcode) and b.pcode='" + cbocode.Text + "' and a.type='" + cboprofile.Text + "'   ", con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "outsource");

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (radioButton1.Checked == true)
                {

                    Reportprofilewonor cashbankrep = new Reportprofilewonor();
                    // cashbankrep.SetDatabaseLogon("sa", "software", @".\SQLEXPRESS", "pathology2627");
                    cashbankrep.SetDataSource(ds);
                    crystalReportViewer1.ReportSource = cashbankrep;
                    cashbankrep.SetParameterValue(0, ds2.Tables[0].Rows[0][5].ToString());
                    cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows[0][6].ToString());
                    ////cashbankrep.SetParameterValue(2, clbal);
                    cashbankrep.SetParameterValue(2, cboprofile.Text);
                    cashbankrep.SetParameterValue(3, note);
                    
                    
                    //cashbankrep.SetParameterValue(3, label4.Text);
                    crystalReportViewer1.Refresh();
                }
                else
                {
                    Repprofilereport cashbankrep = new Repprofilereport();
                    //Repprofilereportg cashbankrep = new Repprofilereportg();
                    // cashbankrep.SetDatabaseLogon("sa", "software", @".\SQLEXPRESS", "pathology2627");
                    cashbankrep.SetDataSource(ds);
                    crystalReportViewer1.ReportSource = cashbankrep;
                    cashbankrep.SetParameterValue(0, ds2.Tables[0].Rows[0][5].ToString());
                    cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows[0][6].ToString());
                    ////cashbankrep.SetParameterValue(2, clbal);
                    cashbankrep.SetParameterValue(2, cboprofile.Text);
                    cashbankrep.SetParameterValue(3, note);
                    //cashbankrep.SetParameterValue(3, label4.Text);
                    crystalReportViewer1.Refresh();

                }


            }
            else
            {
                MessageBox.Show("No record found");
            }
        }
    }
}
