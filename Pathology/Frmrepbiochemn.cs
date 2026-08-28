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
    public partial class Frmrepbiochemn : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        SqlDataReader dr1;
        DataRow dr;
        DataTable dt;
        DataSet ds1,ds2,ds3;
        public string Ggrp, Gdesc, Gdesc1, Gresult, Gunit, Gnormalrange, Gnormalrange1, grange_from, grange_to;
        public int gcode, gage;
        public string gsex, gpatient_name, gdoctor,gmnyr,gscn,gtpt,grrd,grrd3;
        public DateTime gdt_report;
        public Byte[] imageData;
        public static String qrcode = "";
        public Frmrepbiochemn()
        {
            InitializeComponent();
        }

        private void Frmrepbiochemn_Load(object sender, EventArgs e)
        {
            //con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Pathology;Persist Security Info=True;User ID=sa;Password=software;");
            Class1 objclass = new Class1();
            con = new SqlConnection(objclass.arun_con());
            
            con.Open();
            cmd = new SqlCommand("select cc,comp,year_start,year_end,regno from setup",con);
            
            dr1 = cmd.ExecuteReader();
            while (dr1.Read())
            {
                cbopcode.Text = dr1.GetValue(4).ToString();
                //cboname.Text = dr1.GetValue(5).ToString();
             
            }
            dr1.Close();
            // cbotype.Items.Add("Sale");
            //da.Dispose();
            da = new SqlDataAdapter("select patient_name,pcode from patient_master where pcode='" + cbopcode.Text + "' order by pcode", con);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
                cboname.Text = ds.Tables[0].Rows[0][0].ToString();
            da.Dispose();
            da = new SqlDataAdapter("select distinct patient_name,pcode from patient_master order by pcode", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cboname.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                cbopcode.Items.Add(ds.Tables[0].Rows[i][1].ToString());
            }
            
           
            da.Dispose();
            da = new SqlDataAdapter("select cc,comp,address,year_start,year_end,pathologist,biochemist,telphoneno,email,cstno,address1,faxno from company", con);
            ds2 = new DataSet();
            da.Fill(ds2);
            radioButton3.Checked = true;
            da.Dispose();
        }


        public void ADDROW()
        {

            dr = dt.NewRow();
            dr["Grp"] = Ggrp;
            dr["Desc"] = Gdesc;
            dr["Desc1"] = Gdesc1;
            dr["Result"] = Gresult;
            dr["Unit"] = Gunit;
            dr["Normal_Range"] = Gnormalrange;
            dr["Normal_Range1"] = Gnormalrange1;
            dr["pcode"] = gcode;
            dr["Age"] = gage;
            dr["Sex"] = gsex;
            dr["Patient_name"] = gpatient_name;
            dr["dt_report"] = gdt_report;
            dr["doctor"] = gdoctor;
            dr["month_year"] = gmnyr;
            dr["scn"] = gscn;
            dr["tpt"] = gtpt;
            //dr["range_from"] = grange_from;
            //dr["range_to"] = grange_to;
            String qrdata = gpatient_name.Trim() + cbopcode.Text.Trim();


            BarcodeLib.Barcode.Linear qrcode = new BarcodeLib.Barcode.Linear();

            qrcode.Data = qrdata;

            // Save & output QR Code barcode image to your system
            qrcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;
            byte[] imageData = qrcode.drawBarcodeAsBytes();
            //imageData = qrcode.drawBarcodeAsBytes();
            dr["barcode"] = imageData;
 

            dt.Rows.Add(dr);
            dt.AcceptChanges();
        }
        
        
        
        
        
        
        
        
        private void btngo_Click(object sender, EventArgs e)
        {
            String strsql = "";
            strsql = "select a.cc,a.patient_name,a.pcode,a.sex,a.age,a.doctor,a.date_exam,a.month_year,a.Scn,a.Tpt,";
            strsql = strsql + "b.cc,b.pcode,b.Bcr1_Glucose_Fpg_RPG,b.Bcr1_PPPG_PGPG_2hr,b.Bcr1_PPPG_PGPG_1hr,b.Bcr1_RBS,b.Bcr1_PBBS,b.Bcr1_PLBS,b.Bcr1_GTT_1hr,b.Bcr1_GTT_2hr,b.Bcr1_GTT_3hr,b.Bcr1_PGBS_1hr,b.Bcr1_PGBS_2hr,b.Bcr1_HBAC_good,b.Bcr1_HBAC_fair,b.Bcr1_HBAC_poor, b.Bcr1_MBGE,b.Bcr_LP_Triglycerides,b.Bcr_LP_Cholesterol,b.Bcr_LP_HDLCholesterol,";
            strsql = strsql + "b.Bcr_LP_LDLCholesterol,b.Bcr_LP_VLDLCholesterol,b.Bcr2_LP_CHR,b.Bcr2_LP_LHR,b.Bcr_RP_Urea,b.Bcr_RP_Creatinine,b.Bcr3_Uric_Acid,b.Bcr_RP_BUN,b.Bcr3_NPN,b.Bcr_LFT_Bilirubin_total,b.Bcr_LFT_Bilirubin_Direct,b.Bcr4_LFT_Indirect,";
            strsql = strsql + "b.Bcr_LFT_SGOT_AST,b.Bcr_LFT_SGPT_ALT,b.Bcr_LFT_Alkaline_Phosphates,b.Bcr_LFT_Protein,b.Bcr_LFT_Albumin,b.Bcr_LFT_Globulin,b.Bcr_LFT_AG_Ratio,b.Bcr4_LFT_GGTP,b.Bcr_Electrolyte_Sodium,";
            strsql = strsql + "b.Bcr_Electrolyte_Potassium,b.Bcr5_Electrolyte_Chlorides,b.Bcr_OTH_Acid_Calcium,b.Bcr_OTH_Acid_Phosphorus,b.Bcr_OTH_Uric_Acid,b.Bcr_OTH_Pasting_urine_sugar,b.Bcr_OTH_Amylase,b.Bcr_OTH_Acid_Phosphate,b.Bcr_OTH_PP_PG_urine_sugar,b.db_imp,b.Bcr_OTH_Lipase,b.Bcr_OTH_Nac";

            strsql = strsql + " from patient_master a,biochemist b where a.pcode='" + cbopcode.Text + "' and a.pcode=b.pcode";

            da = new SqlDataAdapter(strsql, con);
            ds = new DataSet();
            da.Fill(ds, "Biochemist");
            int i = 0;
            if (ds.Tables[0].Rows.Count != 0)
            {

                dt = new DataTable();
                ds1 = new DataSet();
                dt = ds1.Tables.Add("Pathology_Dt");
                dt.Columns.Add("Grp", System.Type.GetType("System.String"));
                dt.Columns.Add("Desc", System.Type.GetType("System.String"));
                dt.Columns.Add("Desc1", System.Type.GetType("System.String"));
                dt.Columns.Add("Result", System.Type.GetType("System.String"));
                dt.Columns.Add("Unit", System.Type.GetType("System.String"));
                dt.Columns.Add("Normal_Range", System.Type.GetType("System.String"));
                dt.Columns.Add("Normal_Range1", System.Type.GetType("System.String"));
                dt.Columns.Add("Pcode", System.Type.GetType("System.Int32"));
                dt.Columns.Add("Age", System.Type.GetType("System.Int32"));
                dt.Columns.Add("Sex", System.Type.GetType("System.String"));
                dt.Columns.Add("Patient_Name", System.Type.GetType("System.String"));
                dt.Columns.Add("Dt_Report", System.Type.GetType("System.DateTime"));
                dt.Columns.Add("Doctor", System.Type.GetType("System.String"));
                dt.Columns.Add("month_year", System.Type.GetType("System.String"));
                dt.Columns.Add("scn", System.Type.GetType("System.String"));
                dt.Columns.Add("tpt", System.Type.GetType("System.String"));

                dt.Columns.Add("range_from", System.Type.GetType("System.Double"));
                dt.Columns.Add("range_to", System.Type.GetType("System.Double"));
                dt.Columns.Add("barcode", System.Type.GetType("System.Byte[]"));

                String qrdata = cbopcode.Text.Trim();
                BarcodeLib.Barcode.Linear qrcode = new BarcodeLib.Barcode.Linear();
                qrcode.Type = BarcodeLib.Barcode.BarcodeType.CODE39;
                qrcode.Data = qrdata;

                // Save & output QR Code barcode image to your system
                qrcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;
                byte[] imageData = qrcode.drawBarcodeAsBytes();
          
               
                
                
                
                gcode = Convert.ToInt32(ds.Tables[0].Rows[i][2].ToString());
                gage = Convert.ToInt32(ds.Tables[0].Rows[i][4].ToString());
                gsex = ds.Tables[0].Rows[i][3].ToString();
                gpatient_name = ds.Tables[0].Rows[i][1].ToString();
                gdt_report = Convert.ToDateTime(ds.Tables[0].Rows[i][6].ToString());
                gdoctor = ds.Tables[0].Rows[i][5].ToString();
                gmnyr = ds.Tables[0].Rows[i][7].ToString();
                gscn = ds.Tables[0].Rows[i][8].ToString();
                gtpt = ds.Tables[0].Rows[i][9].ToString();

                if (radioButton1.Checked == true)
                {

                    Double rend1 = Convert.ToDouble(ds.Tables[0].Rows[i][12].ToString());
                    Double rend2 = Convert.ToDouble(ds.Tables[0].Rows[i][13].ToString());
                    Double rend3 = Convert.ToDouble(ds.Tables[0].Rows[i][14].ToString());
                    String grrd;
                    if ((rend1 != 0 & rend2 != 0 ) || (rend1 != 0 & rend3 != 0 ))
                    {
                        grrd = "DIABETIC  PROFILE";
                    }
                    else
                    {
                        grrd = "";
                    }
                    
       
                    
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][12].ToString()) != 0)
                    {
                        Ggrp = grrd;
                        Gdesc = "FASTING BLOOD SUGAR ( FBS )";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][12].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'FASTING BLOOD SUGAR ( FBS )'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        //Gunit = "mg/dl";

                        //Gnormalrange = "70 - 110 ";
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][13].ToString()) != 0)
                    {
                        Ggrp = grrd;
                        Gdesc = "POST PRANDIAL BLOOD SUGAR(PPBS-2hr)";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][13].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'POST PRANDIAL BLOOD SUGAR(PPBS-2hr)'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][14].ToString()) != 0)
                    {
                        Ggrp = grrd;
                        Gdesc = "POST PRANDIAL BLOOD SUGAR(PPBS-1hr)";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][14].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'POST PRANDIAL BLOOD SUGAR(PPBS-1hr)'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();

                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][15].ToString()) != 0)
                    {
                        Ggrp = grrd3;
                        Gdesc = "RANDOM BLOOD SUGAR ( RBS )";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][15].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'RANDOM BLOOD SUGAR ( RBS )'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][16].ToString()) != 0)
                    {
                        Ggrp = grrd3;
                        Gdesc = "POST BREAKFAST BLOOD SUGAR ( PBBS )";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][16].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'POST BREAKFAST BLOOD SUGAR ( PBBS )'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][17].ToString()) != 0)
                    {
                        Ggrp = grrd3;
                        Gdesc = "POST LUNCH BLOOD SUGAR ( PLBS )";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][17].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'POST LUNCH BLOOD SUGAR ( PLBS )'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }


                    if (Convert.ToDouble(ds.Tables[0].Rows[i][18].ToString()) != 0)
                    {
                        Ggrp = grrd3;
                        Gdesc = "GLUCOSE TOLERANCE TEST (GTT-1hr)";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][18].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'GLUCOSE TOLERANCE TEST (GTT-1hr)'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][19].ToString()) != 0)
                    {
                        Ggrp = grrd3;
                        Gdesc = "";
                        Gdesc1 = "(2 hr)";
                        Gresult = ds.Tables[0].Rows[i][19].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        Gunit = "mg/dl";
                        Gnormalrange = "70 - 140";

                        Gnormalrange1 = "";

                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][20].ToString()) != 0)
                    {
                        Ggrp = grrd3;
                        Gdesc = "                                    ";
                        Gdesc1 = "(3 hr)";
                        Gresult = ds.Tables[0].Rows[i][20].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        Gunit = "mg/dl";
                        Gnormalrange = "70 - 140";
                        Gnormalrange1 = "";
                        ADDROW();
                    }


                    if (Convert.ToDouble(ds.Tables[0].Rows[i][21].ToString()) != 0)
                    {
                        Ggrp = grrd3;
                        Gdesc = "POST GLUCOSE BLOOD SUGAR (PGBS-1hr)";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][21].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'POST GLUCOSE BLOOD SUGAR (PGBS-1hr)'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][22].ToString()) != 0)
                    {
                        Ggrp = grrd3;
                        Gdesc = "POST GLUCOSE BLOOD SUGAR (PGBS-2hr)";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][22].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'POST GLUCOSE BLOOD SUGAR (PGBS-2hr)'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }

                


                
                
                
                }
                    //only FBS
                if (radioButton4.Checked == true)
                {

                     Double ren1d = Convert.ToDouble(ds.Tables[0].Rows[i][34].ToString());
                    Double ren2d = Convert.ToDouble(ds.Tables[0].Rows[i][35].ToString());
                    Double ren3d = Convert.ToDouble(ds.Tables[0].Rows[i][36].ToString());
                    String Grrdr;
                    if (ren1d != 0 & ren2d != 0 & ren3d != 0)
                    {
                       Grrdr = "RENAL  FUNCTION  TEST ( RFT )";
                        //Grr = "";
                    }
                    else
                    {
                        Grrdr = "";
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][34].ToString()) != 0)
                    {
                        Ggrp = Grrdr;
                        Gdesc = "BLOOD UREA";
                        Gdesc1 = " ";
                        Gresult = ds.Tables[0].Rows[i][34].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'UREA'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }



                    if (Convert.ToDouble(ds.Tables[0].Rows[i][35].ToString()) != 0.00)
                    {
                        Ggrp = Grrdr;
                        Gdesc = "S. CREATININE";
                        Gdesc1 = " ";
                        Gresult = ds.Tables[0].Rows[i][35].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'CREATININE'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][36].ToString()) != 0.00)
                    {
                        Ggrp = Grrdr;
                        Gdesc = "URIC ACID";
                        Gdesc1 = " ";
                        Gresult = ds.Tables[0].Rows[i][36].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'URIC ACID'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }

                    //if (Convert.ToDouble(ds.Tables[0].Rows[i][45].ToString()) != 0.00)
                    //{
                    //    Ggrp = Grrdr;
                    //    Gdesc = "TOTAL PROTEIN";
                    //    Gdesc1 = "";
                    //    Gresult = ds.Tables[0].Rows[i][45].ToString();
                    //    Double gre = Convert.ToDouble(Gresult);
                    //    Gresult = Math.Round(gre, 2).ToString("0.0###");
                    //    da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'TOTAL PROTEIN'", con);
                    //    ds3 = new DataSet();
                    //    da.Fill(ds3);
                    //    Gunit = ds3.Tables[0].Rows[0][1].ToString();
                    //    Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                    //    Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                    //    Gnormalrange1 = "";
                    //    if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                    //    {
                    //        grange_from = "1";
                    //        grange_to = "1";
                    //    }
                    //    else
                    //    {
                    //        grange_from = "0";
                    //        grange_to = "0";
                    //    }

                    //    ADDROW();
                    //}
                    //if (Convert.ToDouble(ds.Tables[0].Rows[i][46].ToString()) != 0.00)
                    //{
                    //    Ggrp = Grrdr;
                    //    Gdesc = "ALBUMIN";
                    //    Gdesc1 = "";
                    //    Gresult = ds.Tables[0].Rows[i][46].ToString();
                    //    Double gre = Convert.ToDouble(Gresult);
                    //    Gresult = Math.Round(gre, 2).ToString("0.0###");
                    //    da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'ALBUMIN'", con);
                    //    ds3 = new DataSet();
                    //    da.Fill(ds3);
                    //    Gunit = ds3.Tables[0].Rows[0][1].ToString();
                    //    Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                    //    Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                    //    Gnormalrange1 = "";
                    //    if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                    //    {
                    //        grange_from = "1";
                    //        grange_to = "1";
                    //    }
                    //    else
                    //    {
                    //        grange_from = "0";
                    //        grange_to = "0";
                    //    }

                    //    ADDROW();
                    //}
                    
                    
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][37].ToString()) != 0)
                    {
                        Ggrp = Grrdr;
                        Gdesc = "BLOOD UREA NITROGEN ( BUN )";
                        Gdesc1 = " ";
                        Gresult = ds.Tables[0].Rows[i][37].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'BLOOD UREA NITROGEN ( BUN )'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }

                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][38].ToString()) != 0.00)
                    {
                        Ggrp = Grrdr;
                        Gdesc = "NPN";
                        Gdesc1 = " ";
                        Gresult = ds.Tables[0].Rows[i][38].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'NPN'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }

                        ADDROW();
                    }
                    Double ren110 = Convert.ToDouble(ds.Tables[0].Rows[i][50].ToString());
                    Double ren111 = Convert.ToDouble(ds.Tables[0].Rows[i][51].ToString());
                    String Gre;
                    if (ren110 != 0 & ren111 != 0.00)
                    {
                        Gre = "ELECTROLYTES";
                    }
                    else
                    {
                        Gre = "";
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][50].ToString()) != 0)
                    {
                        Ggrp = Gre;
                        Gdesc = "SODIUM";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][50].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'SODIUM'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";

                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][51].ToString()) != 0.00)
                    {
                        Ggrp = Gre;
                        Gdesc = "POTASSIUM";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][51].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'POTASSIUM'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }

                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][52].ToString()) != 0.00)
                    {
                        Ggrp = Gre;
                        Gdesc = "CHLORIDES";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][52].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'CHLORIDES'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }

                        ADDROW();
                    }



                    if (Convert.ToDouble(ds.Tables[0].Rows[i][53].ToString()) != 0.00)
                    {
                        Ggrp = Gre;
                        Gdesc = "CALCIUM";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][53].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'CALCIUM'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";

                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }

                
                
                
                
                }
                   

                if (radioButton2.Checked == true)
                {

                     Double ren11 = Convert.ToDouble(ds.Tables[0].Rows[i][27].ToString());
                    Double ren21 = Convert.ToDouble(ds.Tables[0].Rows[i][28].ToString());
                    Double ren31 = Convert.ToDouble(ds.Tables[0].Rows[i][29].ToString());
                    Double ren41 = Convert.ToDouble(ds.Tables[0].Rows[i][30].ToString());
                    Double ren51 = Convert.ToDouble(ds.Tables[0].Rows[i][31].ToString());
                    Double ren61 = Convert.ToDouble(ds.Tables[0].Rows[i][32].ToString());
                    Double ren71 = Convert.ToDouble(ds.Tables[0].Rows[i][33].ToString());
                    String Grl;
                    if (ren11 != 0 & ren21 != 0 & ren31 != 0.00 & ren41 != 0.00 & ren51 != 0.00)
                    {
                        Grl = "LIPID  PROFILE";
                    }
                    else
                    {
                        Grl = "";
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][28].ToString()) != 0.00)
                    {
                        Ggrp = Grl;
                        Gdesc = "CHOLESTEROL";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][28].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'CHOLESTEROL'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }


                    if (Convert.ToDouble(ds.Tables[0].Rows[i][27].ToString()) != 0.00)
                    {
                        Ggrp = Grl;
                        Gdesc = "TRIGLYCERIDE";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][27].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'TRIGLYCERIDE'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }

                   

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][29].ToString()) != 0.00)
                    {
                        Ggrp = Grl;
                        Gdesc = "HIGH DENSITY LIPOPROTEIN ( HDL )";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][29].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'HIGH DENSITY LIPOPROTEIN ( HDL )'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][30].ToString()) != 0.00)
                    {
                        Ggrp = Grl;
                        Gdesc = "LOW DENSITY LIPOPROTEIN ( LDL )";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][30].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'LOW DENSITY LIPOPROTEIN ( LDL )'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][31].ToString()) != 0.00)
                    {
                        Ggrp = Grl;
                        Gdesc = "VERY LOW DENSITY LIPOPROTEIN ( VLDL )";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][31].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'VERY LOW DENSITY LIPOPROTEIN ( VLDL )'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][32].ToString()) != 0.00)
                    {
                        Ggrp = Grl;
                        Gdesc = "CHOL/HDL RATIO";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][32].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'CHOL/HDL RATIO'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][33].ToString()) != 0.00)
                    {
                        Ggrp = Grl;
                        Gdesc = "LDL/HDL RATIO";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][33].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'LDL/HDL RATIO'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }



                   

                }  
                
    //LFT START
                if (radioButton5.Checked == true)
                {

                    Double ren10 = Convert.ToDouble(ds.Tables[0].Rows[i][39].ToString());
                    Double ren20 = Convert.ToDouble(ds.Tables[0].Rows[i][40].ToString());
                    Double ren30 = Convert.ToDouble(ds.Tables[0].Rows[i][41].ToString());
                    Double ren40 = Convert.ToDouble(ds.Tables[0].Rows[i][42].ToString());
                    Double ren50 = Convert.ToDouble(ds.Tables[0].Rows[i][43].ToString());
                    Double ren60 = Convert.ToDouble(ds.Tables[0].Rows[i][44].ToString());
                    Double ren70 = Convert.ToDouble(ds.Tables[0].Rows[i][45].ToString());
                    Double ren80 = Convert.ToDouble(ds.Tables[0].Rows[i][46].ToString());
                    Double ren90 = Convert.ToDouble(ds.Tables[0].Rows[i][47].ToString());
                    Double ren100 = Convert.ToDouble(ds.Tables[0].Rows[i][48].ToString());
                    Double ren101 = Convert.ToDouble(ds.Tables[0].Rows[i][49].ToString());

                    String Grf;
                    if (ren10 != 0.00 & ren20 != 0.00 & ren40 != 0 & ren50 != 0 & ren60 != 0.00)
                    {
                        Grf = "LIVER  FUNCTION  TEST ( LFT )";
                    }
                    else
                    {
                        Grf = "";
                    }


                    if (Convert.ToDouble(ds.Tables[0].Rows[i][39].ToString()) != 0.00)
                    {
                        Ggrp = Grf;
                        Gdesc = "TOTAL BILIRUBIN";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][39].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'TOTAL BILIRUBIN'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }

                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][40].ToString()) != 0.00)
                    {
                        Ggrp = Grf;
                        Gdesc = "DIRECT BILIRUBIN";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][40].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'DIRECT BILIRUBIN'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }

                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][41].ToString()) != 0.00)
                    {
                        Ggrp = Grf;
                        Gdesc = "INDIRECT BILIRUBIN";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][41].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range ,range_from,range_to,method from reference_master where test = 'INDIRECT BILIRUBIN'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }

                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][42].ToString()) != 0)
                    {
                        Ggrp = Grf;
                        Gdesc = "A.S.T.(S.G.O.T.)";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][42].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'A.S.T.(S.G.O.T.)'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }

                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][43].ToString()) != 0)
                    {
                        Ggrp = Grf;
                        Gdesc = "A.L.T.(S.G.P.T.)";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][43].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'A.L.T.(S.G.P.T.)'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";

                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][44].ToString()) != 0)
                    {
                        Ggrp = Grf;
                        Gdesc = "ALKALINE PHOSPHATASE";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][44].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'ALKALINE PHOSPHATASE'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }

                        ADDROW();
                    }


                    if (Convert.ToDouble(ds.Tables[0].Rows[i][45].ToString()) != 0.00)
                    {
                        Ggrp = Grf;
                        Gdesc = "TOTAL PROTEIN";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][45].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'TOTAL PROTEIN'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }

                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][46].ToString()) != 0.00)
                    {
                        Ggrp = Grf;
                        Gdesc = "ALBUMIN";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][46].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'ALBUMIN'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }

                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][47].ToString()) != 0.00)
                    {
                        Ggrp = Grf;
                        Gdesc = "GLOBULIN";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][47].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'GLOBULIN'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";

                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][48].ToString()) != 0.00)
                    {
                        Ggrp = Grf;
                        Gdesc = "A:G RATIO";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][48].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'A:G RATIO'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }

                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][49].ToString()) != 0.00)
                    {
                        Ggrp = Grf;
                        Gdesc = "GAMMA GLUTAMYL TRANSFERASE";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][49].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'GAMMA GLUTAMYL TRANSFERASE'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";

                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }
                
                
                
                
                }

//LFT END
                //OTHER START
                if (radioButton7.Checked == true)
                {
                    String Grf;
                    //if (ren10 != 0.00 & ren20 != 0.00 & ren40 != 0 & ren50 != 0 & ren60 != 0.00)
                    //{
                    //    Grf = "LIVER  FUNCTION  TEST ( LFT )";
                    //}
                    //else
                    //{
                        Grf = "OTHERS";
                    //}
                    
                    
                    
                  
                   
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][54].ToString()) != 0.00)
                    {
                        Ggrp = "OTHERS";
                        Gdesc = "PHOSPHORUS";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][54].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'INORGANIC PHOSPHORUS'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }

                        ADDROW();
                    }
                    


                    if (Convert.ToDouble(ds.Tables[0].Rows[i][55].ToString()) != 0)
                    {
                        Ggrp = "CARDIAC ( ENZYMES )";
                        Gdesc = "LDH";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][55].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'LDH'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][56].ToString()) != 0)
                    {
                        Ggrp = "CARDIAC ( ENZYMES )";
                        Gdesc = "CPK - MB";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][56].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'CPK - MB'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][57].ToString()) != 0)
                    {
                        Ggrp = "OTHERS";
                        Gdesc = "AMYLASE";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][57].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'ALPHA AMYLASE'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }

                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][61].ToString()) != 0)
                    {
                        //Mgrpc = "25";
                        //Mgrpname = "BIO-CHEMISTRY";
                        Ggrp = "OTHERS";
                        Gdesc = "LIPASE";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][61].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method  from reference_master where test = 'LIPASE'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }
                    
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][58].ToString()) != 0)
                    {
                        Ggrp = "OTHERS";
                        Gdesc = "ACID PHOSPHATASE";
                        Gdesc1 = "";
                       
                        Gresult = ds.Tables[0].Rows[i][58].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'ACID PHOSPHATASE'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }

                        ADDROW();
                    }
                }

         
                //OTHERS END
                
                //hba1c start
                if (radioButton6.Checked == true)
                {
                    String grrd3;
                    grrd3 = "HbA1C";

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][23].ToString()) != 0)
                    {
                        Ggrp = grrd3;
                        Gdesc = "GLYCOSYLATED HEMOGLOBIN ( HbA1C )";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][23].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'GLYCOSYLATED HEMOGLOBIN ( HbA1C )'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        // Fair to good control: 7 - 8        Unsatisfactory control: 8 - 10          Poor Control:   >10";                        //Poor Control,   >7.6"
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        //Poor Control,   >7.6"
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }


                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][24].ToString()) != 0)
                    {
                        Ggrp = grrd3;
                        Gdesc = " ";
                        Gdesc1 = " ";
                        Gresult = ds.Tables[0].Rows[i][24].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        Gunit = "";
                        Gnormalrange = " ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][25].ToString()) != 0)
                    {
                        Ggrp = grrd3;
                        Gdesc = " ";
                        Gdesc1 = " ";
                        Gresult = ds.Tables[0].Rows[i][25].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        Gunit = "";
                        Gnormalrange = " ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][26].ToString()) != 0)
                    {
                        Ggrp = grrd3;
                        Gdesc = "AVERAGE BLOOD GLUCOSE ESTIMATION";
                        Gdesc1 = " ";
                        Gresult = ds.Tables[0].Rows[i][26].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'MEAN BLOOD GLUCOSE ESTIMATION'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }

                
                
                
                }
                //HbA1c End
                if (radioButton3.Checked == true)
                {

                    Double rend31 = Convert.ToDouble(ds.Tables[0].Rows[i][12].ToString());
                    Double rend32 = Convert.ToDouble(ds.Tables[0].Rows[i][13].ToString());
                    Double rend33 = Convert.ToDouble(ds.Tables[0].Rows[i][14].ToString());
                    String grrd3;
                    if ((rend31 != 0 & rend32 != 0) || (rend31 != 0 & rend33 != 0))
                    {
                        grrd3 = "DIABETIC  PROFILE";
                    }
                    else
                    {
                        grrd3 = "";
                    }


                    
                    
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][12].ToString()) != 0)
                    {
                        Ggrp = grrd3;
                        Gdesc = "FASTING BLOOD SUGAR ( FBS )";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][12].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'FASTING BLOOD SUGAR ( FBS )'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][13].ToString()) != 0)
                    {
                        Ggrp = grrd3;
                        Gdesc = "POST PRANDIAL BLOOD SUGAR(PPBS-2hr)";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][13].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'POST PRANDIAL BLOOD SUGAR(PPBS-2hr)'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][14].ToString()) != 0)
                    {
                        Ggrp = grrd3;
                        Gdesc = "POST PRANDIAL BLOOD SUGAR(PPBS-1hr)";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][14].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'POST PRANDIAL BLOOD SUGAR(PPBS-1hr)'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }



                    if (Convert.ToDouble(ds.Tables[0].Rows[i][15].ToString()) != 0)
                    {
                        Ggrp = grrd3;
                        Gdesc = "RANDOM BLOOD SUGAR ( RBS )";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][15].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'RANDOM BLOOD SUGAR ( RBS )'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][16].ToString()) != 0)
                    {
                        Ggrp = grrd3;
                        Gdesc = "POST BREAKFAST BLOOD SUGAR ( PBBS )";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][16].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'POST BREAKFAST BLOOD SUGAR ( PBBS )'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][17].ToString()) != 0)
                    {
                        Ggrp = grrd3;
                        Gdesc = "POST LUNCH BLOOD SUGAR ( PLBS )";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][17].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'POST LUNCH BLOOD SUGAR ( PLBS )'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }


                    if (Convert.ToDouble(ds.Tables[0].Rows[i][18].ToString()) != 0)
                    {
                        Ggrp = grrd3;
                        Gdesc = "GLUCOSE TOLERANCE TEST (GTT-1hr)";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][18].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'GLUCOSE TOLERANCE TEST (GTT-1hr)'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][19].ToString()) != 0)
                    {
                        Ggrp = grrd3;
                        Gdesc = "";
                        Gdesc1 = "(2 hr)";
                        Gresult = ds.Tables[0].Rows[i][19].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        Gunit = "mg/dl";
                        Gnormalrange = "70 - 140";
                        
                        Gnormalrange1 = "";
                        
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][20].ToString()) != 0)
                    {
                        Ggrp = grrd3;
                        Gdesc = "                                    ";
                        Gdesc1 = "(3 hr)";
                        Gresult = ds.Tables[0].Rows[i][20].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        Gunit = "mg/dl";
                        Gnormalrange = "70 - 140";
                        Gnormalrange1 = "";
                        ADDROW();
                    }


                    if (Convert.ToDouble(ds.Tables[0].Rows[i][21].ToString()) != 0)
                    {
                        Ggrp = grrd3;
                        Gdesc = "POST GLUCOSE BLOOD SUGAR (PGBS-1hr)";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][21].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'POST GLUCOSE BLOOD SUGAR (PGBS-1hr)'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][22].ToString()) != 0)
                    {
                        Ggrp = grrd3;
                        Gdesc = "POST GLUCOSE BLOOD SUGAR (PGBS-2hr)";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][22].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'POST GLUCOSE BLOOD SUGAR (PGBS-2hr)'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }


                    if (Convert.ToDouble(ds.Tables[0].Rows[i][23].ToString()) != 0)
                    {
                        Ggrp = grrd3;
                        Gdesc = "GLYCOSYLATED HEMOGLOBIN ( HbA1C )";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][23].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'GLYCOSYLATED HEMOGLOBIN ( HbA1C )'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString(); 
                       // Fair to good control: 7 - 8        Unsatisfactory control: 8 - 10          Poor Control:   >10";                        //Poor Control,   >7.6"
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        //Poor Control,   >7.6"
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        
                        
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][24].ToString()) != 0)
                    {
                        Ggrp = grrd3;
                        Gdesc = " ";
                        Gdesc1 = " ";
                        Gresult = ds.Tables[0].Rows[i][24].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        Gunit = "";
                        Gnormalrange = " ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][25].ToString()) != 0)
                    {
                        Ggrp = grrd3;
                        Gdesc = " ";
                        Gdesc1 = " ";
                        Gresult = ds.Tables[0].Rows[i][25].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        Gunit = "";
                        Gnormalrange = " ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][26].ToString()) != 0)
                    {
                        Ggrp = grrd3;
                        Gdesc = "AVERAGE BLOOD GLUCOSE ESTIMATION";
                        Gdesc1 = " ";
                        Gresult = ds.Tables[0].Rows[i][26].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'MEAN BLOOD GLUCOSE ESTIMATION'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }



                   


                    Double ren11 = Convert.ToDouble(ds.Tables[0].Rows[i][27].ToString());
                    Double ren21 = Convert.ToDouble(ds.Tables[0].Rows[i][28].ToString());
                    Double ren31 = Convert.ToDouble(ds.Tables[0].Rows[i][29].ToString());
                    Double ren41 = Convert.ToDouble(ds.Tables[0].Rows[i][30].ToString());
                    Double ren51 = Convert.ToDouble(ds.Tables[0].Rows[i][31].ToString());
                    Double ren61 = Convert.ToDouble(ds.Tables[0].Rows[i][32].ToString());
                    Double ren71 = Convert.ToDouble(ds.Tables[0].Rows[i][33].ToString());
                    String Grl;
                    if (ren11 != 0 & ren21 != 0 & ren31 != 0.00 & ren41 != 0.00 & ren51 != 0.00 )
                    {
                        Grl = "LIPID  PROFILE";
                    }
                    else
                    {
                        Grl = "";
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][28].ToString()) != 0.00)
                    {
                        Ggrp = Grl;
                        Gdesc = "CHOLESTEROL";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][28].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'CHOLESTEROL'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }

                        ADDROW();
                    }


                    if (Convert.ToDouble(ds.Tables[0].Rows[i][27].ToString()) != 0.00)
                    {
                        Ggrp = Grl;
                        Gdesc = "TRIGLYCERIDE(Tg)";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][27].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'TRIGLYCERIDE'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }

                        ADDROW();
                    }

                  
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][29].ToString()) != 0.00)
                    {
                        Ggrp = Grl;
                        Gdesc = "HIGH DENSITY LIPOPROTEIN ( HDL )";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][29].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'HIGH DENSITY LIPOPROTEIN ( HDL )'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }

                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][30].ToString()) != 0.00)
                    {
                        Ggrp = Grl;
                        Gdesc = "LOW DENSITY LIPOPROTEIN ( LDL )";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][30].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'LOW DENSITY LIPOPROTEIN ( LDL )'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }

                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][31].ToString()) != 0.00)
                    {
                        Ggrp = Grl;
                        Gdesc = "VERY LOW DENSITY LIPOPROTEIN ( VLDL )";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][31].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'VERY LOW DENSITY LIPOPROTEIN ( VLDL )'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";

                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }



                    if (Convert.ToDouble(ds.Tables[0].Rows[i][32].ToString()) != 0.00)
                    {
                        Ggrp = Grl;
                        Gdesc = "CHOL/HDL RATIO";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][32].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'CHOL/HDL RATIO'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][33].ToString()) != 0.00)
                    {
                        Ggrp = Grl;
                        Gdesc = "LDL/HDL RATIO";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][33].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'LDL/HDL RATIO'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }
                   
                 

                    Double ren13a = Convert.ToDouble(ds.Tables[0].Rows[i][34].ToString());
                    Double ren23a = Convert.ToDouble(ds.Tables[0].Rows[i][35].ToString());
                    Double ren33a = Convert.ToDouble(ds.Tables[0].Rows[i][36].ToString());
                    String Grr3a;
                    if (ren13a != 0 & ren23a != 0 & ren33a != 0.00)
                    {
                        Grr3a = "RENAL  FUNCTION  TEST ( RFT )";
                    }
                    else
                    {
                        Grr3a = "";
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][34].ToString()) != 0)
                    {
                        Ggrp = Grr3a;
                        Gdesc = "UREA";
                        Gdesc1 = " ";
                        Gresult = ds.Tables[0].Rows[i][34].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'UREA'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }



                    if (Convert.ToDouble(ds.Tables[0].Rows[i][35].ToString()) != 0.00)
                    {
                        Ggrp = Grr3a;
                        Gdesc = "CREATININE";
                        Gdesc1 = " ";
                        Gresult = ds.Tables[0].Rows[i][35].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'CREATININE'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }

                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][36].ToString()) != 0.00)
                    {
                        Ggrp = Grr3a;
                        Gdesc = "URIC ACID";
                        Gdesc1 = " ";
                        Gresult = ds.Tables[0].Rows[i][36].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'URIC ACID'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }

                        ADDROW();
                    }
                    //if (Convert.ToDouble(ds.Tables[0].Rows[i][45].ToString()) != 0.00)
                    //{
                    //    Ggrp = Grr3a;
                    //    Gdesc = "TOTAL PROTEIN";
                    //    Gdesc1 = "";
                    //    Gresult = ds.Tables[0].Rows[i][45].ToString();
                    //    Double gre = Convert.ToDouble(Gresult);
                    //    Gresult = Math.Round(gre, 2).ToString("0.0###");
                    //    da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'TOTAL PROTEIN'", con);
                    //    ds3 = new DataSet();
                    //    da.Fill(ds3);
                    //    Gunit = ds3.Tables[0].Rows[0][1].ToString();
                    //    Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                    //    Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                    //    Gnormalrange1 = "";
                    //    if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                    //    {
                    //        grange_from = "1";
                    //        grange_to = "1";
                    //    }
                    //    else
                    //    {
                    //        grange_from = "0";
                    //        grange_to = "0";
                    //    }

                    //    ADDROW();
                    //}
                    //if (Convert.ToDouble(ds.Tables[0].Rows[i][46].ToString()) != 0.00)
                    //{
                    //    Ggrp = Grr3a;
                    //    Gdesc = "ALBUMIN";
                    //    Gdesc1 = "";
                    //    Gresult = ds.Tables[0].Rows[i][46].ToString();
                    //    Double gre = Convert.ToDouble(Gresult);
                    //    Gresult = Math.Round(gre, 2).ToString("0.0###");
                    //    da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'ALBUMIN'", con);
                    //    ds3 = new DataSet();
                    //    da.Fill(ds3);
                    //    Gunit = ds3.Tables[0].Rows[0][1].ToString();
                    //    Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                    //    Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                    //    Gnormalrange1 = "";
                    //    if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                    //    {
                    //        grange_from = "1";
                    //        grange_to = "1";
                    //    }
                    //    else
                    //    {
                    //        grange_from = "0";
                    //        grange_to = "0";
                    //    }

                    //    ADDROW();
                    //}
                  
                    
                    
                    
                    
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][37].ToString()) != 0)
                    {
                        Ggrp = Grr3a;
                        Gdesc = "BLOOD UREA NITROGEN ( BUN )";
                        Gdesc1 = " ";
                        Gresult = ds.Tables[0].Rows[i][37].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'BLOOD UREA NITROGEN ( BUN )'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }

                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][38].ToString()) != 0.00)
                    {
                        Ggrp = Grr3a;
                        Gdesc = "NPN";
                        Gdesc1 = " ";
                        Gresult = ds.Tables[0].Rows[i][38].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'NPN'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }

                        ADDROW();
                    }





                    Double ren10 = Convert.ToDouble(ds.Tables[0].Rows[i][39].ToString());
                    Double ren20 = Convert.ToDouble(ds.Tables[0].Rows[i][40].ToString());
                    Double ren30 = Convert.ToDouble(ds.Tables[0].Rows[i][41].ToString());
                    Double ren40 = Convert.ToDouble(ds.Tables[0].Rows[i][42].ToString());
                    Double ren50 = Convert.ToDouble(ds.Tables[0].Rows[i][43].ToString());
                    Double ren60 = Convert.ToDouble(ds.Tables[0].Rows[i][44].ToString());
                    Double ren70 = Convert.ToDouble(ds.Tables[0].Rows[i][45].ToString());
                    Double ren80 = Convert.ToDouble(ds.Tables[0].Rows[i][46].ToString());
                    Double ren90 = Convert.ToDouble(ds.Tables[0].Rows[i][47].ToString());
                    Double ren100 = Convert.ToDouble(ds.Tables[0].Rows[i][48].ToString());
                    Double ren101 = Convert.ToDouble(ds.Tables[0].Rows[i][49].ToString());

                    String Grf;
                    if (ren10 != 0.00 & ren20 != 0.00  & ren40 != 0 & ren50 != 0 & ren60 != 0.00 )
                    {
                        Grf = "LIVER  FUNCTION  TEST ( LFT )";
                    }
                    else
                    {
                        Grf = "";
                    }


                    if (Convert.ToDouble(ds.Tables[0].Rows[i][39].ToString()) != 0.00)
                    {
                        Ggrp = Grf;
                        Gdesc = "TOTAL BILIRUBIN";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][39].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'TOTAL BILIRUBIN'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }

                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][40].ToString()) != 0.00)
                    {
                        Ggrp = Grf;
                        Gdesc = "DIRECT BILIRUBIN";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][40].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'DIRECT BILIRUBIN'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }

                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][41].ToString()) != 0.00)
                    {
                        Ggrp = Grf;
                        Gdesc = "INDIRECT BILIRUBIN";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][41].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range ,range_from,range_to,method from reference_master where test = 'INDIRECT BILIRUBIN'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }

                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][42].ToString()) != 0)
                    {
                        Ggrp = Grf;
                        Gdesc = "A.S.T.(S.G.O.T.)";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][42].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'A.S.T.(S.G.O.T.)'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }

                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][43].ToString()) != 0)
                    {
                        Ggrp = Grf;
                        Gdesc = "A.L.T.(S.G.P.T.)";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][43].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'A.L.T.(S.G.P.T.)'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";

                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][44].ToString()) != 0)
                    {
                        Ggrp = Grf;
                        Gdesc = "ALKALINE PHOSPHATASE";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][44].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'ALKALINE PHOSPHATASE'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }

                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][45].ToString()) != 0.00)
                    {
                        Ggrp = Grf;
                        Gdesc = "TOTAL PROTEIN";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][45].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'TOTAL PROTEIN'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }

                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][46].ToString()) != 0.00)
                    {
                        Ggrp = Grf;
                        Gdesc = "ALBUMIN";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][46].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'ALBUMIN'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }

                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][47].ToString()) != 0.00)
                    {
                        Ggrp = Grf;
                        Gdesc = "GLOBULIN";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][47].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'GLOBULIN'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";

                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][48].ToString()) != 0.00)
                    {
                        Ggrp = Grf;
                        Gdesc = "A:G RATIO";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][48].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'A:G RATIO'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }

                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][49].ToString()) != 0.00)
                    {
                        Ggrp = Grf;
                        Gdesc = "GAMMA GLUTAMYL TRANSFERASE";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][49].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'GAMMA GLUTAMYL TRANSFERASE'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";

                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }
                    Double ren110 = Convert.ToDouble(ds.Tables[0].Rows[i][50].ToString());
                    Double ren111 = Convert.ToDouble(ds.Tables[0].Rows[i][51].ToString());
                    String Gre;
                    if (ren110 != 0 & ren111 != 0.00)
                    {
                        Gre = "ELECTROLYTES";
                    }
                    else
                    {
                        Gre = "";
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][50].ToString()) != 0)
                    {
                        Ggrp = Gre;
                        Gdesc = "SODIUM";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][50].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'SODIUM'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";

                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][51].ToString()) != 0.00)
                    {
                        Ggrp = Gre;
                        Gdesc = "POTASSIUM";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][51].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'POTASSIUM'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }

                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][52].ToString()) != 0.00)
                    {
                        Ggrp = Gre;
                        Gdesc = "CHLORIDES";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][52].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'CHLORIDES'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }

                        ADDROW();
                    }



                    if (Convert.ToDouble(ds.Tables[0].Rows[i][53].ToString()) != 0.00)
                    {
                        Ggrp = Gre;
                        Gdesc = "CALCIUM";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][53].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'CALCIUM'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";

                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][54].ToString()) != 0.00)
                    {
                        Ggrp = Gre;
                        Gdesc = "PHOSPHORUS";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][54].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'INORGANIC PHOSPHORUS'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }

                        ADDROW();
                    }
                    


                    if (Convert.ToDouble(ds.Tables[0].Rows[i][55].ToString()) != 0)
                    {
                        Ggrp = "CARDIAC ( ENZYMES )";
                        Gdesc = "LDH";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][55].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'LDH'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][56].ToString()) != 0)
                    {
                        Ggrp = "CARDIAC ( ENZYMES )";
                        Gdesc = "CPK - MB";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][56].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'CPK - MB'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][57].ToString()) != 0)
                    {
                        Ggrp = "OTHERS";
                        Gdesc = "AMYLASE";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][57].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'ALPHA AMYLASE'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }

                        ADDROW();
                    }
                    
                    //Bcr_OTH_Lipase,Bcr_OTH_Nac

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][61].ToString()) != 0)
                    {
                        //Mgrpc = "25";
                        //Mgrpname = "BIO-CHEMISTRY";
                        Ggrp = "OTHERS";
                        Gdesc = "LIPASE";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][61].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method  from reference_master where test = 'LIPASE'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }
                        ADDROW();
                    }
 
                    
                    
                    
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][58].ToString()) != 0)
                    {
                        Ggrp = "OTHERS";
                        Gdesc = "ACID PHOSPHATASE";
                        Gdesc1 = "";
                       
                        Gresult = ds.Tables[0].Rows[i][58].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method from reference_master where test = 'ACID PHOSPHATASE'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
                        Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            grange_from = "1";
                            grange_to = "1";
                        }
                        else
                        {
                            grange_from = "0";
                            grange_to = "0";
                        }

                        ADDROW();
                    }
                }
                string Gresultimp = "";
                if (ds.Tables[0].Rows[i][60].ToString() != "")
                {
                   
               Gresultimp = ds.Tables[0].Rows[i][60].ToString();
                    
                }

               
                da.Dispose();
                da = new SqlDataAdapter("select test,method,result,unit,normal_range from biochemistext where pcode='" + cbopcode.Text + "'", con);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count != 0)
                {

                    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[i][2].ToString() != "")
                        {
                            Ggrp = "";
                            if (ds.Tables[0].Rows[i][1].ToString() != "")
                            {

                                Gdesc = ds.Tables[0].Rows[i][0].ToString();
                                Gdesc1 ="(" + ds.Tables[0].Rows[i][1].ToString().Trim() + ")";
                            
                            }
                            else
                            {
                                Gdesc = ds.Tables[0].Rows[i][0].ToString();
                                Gdesc1 = "";
                            }
                                 
                                 //Gdesc1 = "";
                            Gresult = ds.Tables[0].Rows[i][2].ToString();

                            Double gre = Convert.ToDouble(Gresult);
                            Gresult = Math.Round(gre, 2).ToString("0.0###");
                            
                            Gunit = ds.Tables[0].Rows[i][3].ToString();
                            Gnormalrange = ds.Tables[0].Rows[i][4].ToString();
                            Gnormalrange1 = "";
                            //grange_from=ds.Tables[0].Rows[i][5].ToString();
                            //grange_to=ds.Tables[0].Rows[i][6].ToString();
                            ADDROW();
                        }
                    }
                }

                if (Gresultimp != "")
                {
                    Ggrp = "";
                    Gdesc = "IMPRESSION :";
                    Gdesc1 = "";
                    Gresult = Gresultimp;
                    //Gresult = Gresult.TrimStart('0').TrimEnd('0', '.');
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }

                
                //if  (radioButton1.Checked == true) 
                //{
                //    Repdiabetic cashbankrep = new Repdiabetic();

                //    //cashbankrep.SetDatabaseLogon("sa", "software", @".\SQLEXPRESS", "pathology2627");
                //    cashbankrep.SetDataSource(dt);
                //    crv.ReportSource = cashbankrep;
                //    cashbankrep.SetParameterValue(0, ds2.Tables[0].Rows[0][5].ToString());
                //    cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows[0][6].ToString());
                //    cashbankrep.SetParameterValue(2, ds2.Tables[0].Rows[0][9].ToString());
                //    cashbankrep.SetParameterValue(3, ds2.Tables[0].Rows[0][10].ToString());
                //    cashbankrep.SetParameterValue(4, ds2.Tables[0].Rows[0][11].ToString());
                    
                //}
                //else
                //    if (radioButton2.Checked == true)
                //    {
                //        Repnil cashbankrep = new Repnil();

                //        //cashbankrep.SetDatabaseLogon("sa", "software", @".\SQLEXPRESS", "pathology2627");
                //        cashbankrep.SetDataSource(dt);
                //        crv.ReportSource = cashbankrep;
                //        cashbankrep.SetParameterValue(0, ds2.Tables[0].Rows[0][5].ToString());
                //        cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows[0][6].ToString());
                //        cashbankrep.SetParameterValue(2, ds2.Tables[0].Rows[0][9].ToString());
                //        cashbankrep.SetParameterValue(3, ds2.Tables[0].Rows[0][10].ToString());
                //        cashbankrep.SetParameterValue(4, ds2.Tables[0].Rows[0][11].ToString());
                    
                    
                    
                //    }
                
                //    else
                //{

                if (radioButton3.Checked == true)
                {



                    Repbiochemall cashbankrep = new Repbiochemall();
                    //cashbankrep.SetDatabaseLogon("sa", "software", @".\SQLEXPRESS", "pathology2627");
                    cashbankrep.SetDataSource(dt);
                    crv.ReportSource = cashbankrep;
                    cashbankrep.SetParameterValue(0, ds2.Tables[0].Rows[0][5].ToString());
                    cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows[0][6].ToString());
                    cashbankrep.SetParameterValue(2, ds2.Tables[0].Rows[0][9].ToString());
                    cashbankrep.SetParameterValue(3, ds2.Tables[0].Rows[0][10].ToString());
                    cashbankrep.SetParameterValue(4, ds2.Tables[0].Rows[0][11].ToString());
                    crv.Refresh();
                }
                else
                {
                    Repbiochemn cashbankrep = new Repbiochemn();
                    //cashbankrep.SetDatabaseLogon("sa", "software", @".\SQLEXPRESS", "pathology2627");
                    cashbankrep.SetDataSource(dt);
                    crv.ReportSource = cashbankrep;
                    cashbankrep.SetParameterValue(0, ds2.Tables[0].Rows[0][5].ToString());
                    cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows[0][6].ToString());
                    cashbankrep.SetParameterValue(2, ds2.Tables[0].Rows[0][9].ToString());
                    cashbankrep.SetParameterValue(3, ds2.Tables[0].Rows[0][10].ToString());
                    cashbankrep.SetParameterValue(4, ds2.Tables[0].Rows[0][11].ToString());
                    crv.Refresh();
                
                
                }
            
            
            
            }
            else
            {
                MessageBox.Show("No Records Found!!!");
            }

        }

        private void cbocode_SelectedIndexChanged(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("select patient_name,pcode from patient_master where pcode='" + cbopcode.Text + "'", con);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
                cboname.Text = ds.Tables[0].Rows[0][0].ToString();
            cbopcode.Text = ds.Tables[0].Rows[0][1].ToString();
        
        }

        private void cboname_SelectedIndexChanged(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("select pcode,patient_name from patient_master where patient_name='" + cboname.Text + "'", con);
            ds = new DataSet();
            da.Fill(ds);
            cbopcode.Text = ds.Tables[0].Rows[0][0].ToString();
            cboname.Text = ds.Tables[0].Rows[0][1].ToString();
        }

        private void btnbioback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbopcode_Validating(object sender, CancelEventArgs e)
        {
            da = new SqlDataAdapter("select patient_name,pcode from patient_master where pcode='" + cbopcode.Text + "'", con);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
                cboname.Text = ds.Tables[0].Rows[0][0].ToString();
            cbopcode.Text = ds.Tables[0].Rows[0][1].ToString();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void crv_Load(object sender, EventArgs e)
        {

        }
    }
}