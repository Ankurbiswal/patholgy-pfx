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
    public partial class Frmrephormone : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        SqlDataReader dr1;
        DataRow dr;
        DataTable dt;
        DataSet ds, ds1, ds2, ds3,ds5;
        //DataSet dsur, dsst, dsbd, dsbc;
        public string Ggrp, Gdesc, Gdesc1, Gresult, Gresult1, Gresult2, Gunit, Gnormalrange, Gnormalrange1, grange_from, grange_to;
        public int gcode, gage;
        public string gsex, gpatient_name, gdoctor, gmnyr, gscn, gtpt;
        public DateTime gdt_report;
        public string reportname;
        public String Gdescpss = "";
        public String Gresultpss = "";
        public Byte[] imageData;
        public static String qrcode = "";
        
        public Frmrephormone()
        {
            InitializeComponent();
        }

        private void Frmrephormone_Load(object sender, EventArgs e)
        {
           // con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Pathology;Persist Security Info=True;User ID=sa;Password=software;");
            Class1 objclass = new Class1();
            con = new SqlConnection(objclass.arun_con());
            
            con.Open();
            cmd = new SqlCommand("select cc,comp,year_start,year_end,Regno from setup");
            cmd.Connection = con;
            dr1 = cmd.ExecuteReader();
            while (dr1.Read())
            {
                cbopcode.Text = dr1.GetValue(4).ToString();
                //this.txtcompid.Text = dr.GetValue(0).ToString();
                //label4.Text = dr.GetValue(1).ToString();
                //dtfrom.Text = dr.GetValue(2).ToString();
            
            }
            dr1.Close();
         
            da = new SqlDataAdapter("select distinct patient_name,pcode from patient_master order by pcode", con);
            ds5 = new DataSet();
            da.Fill(ds5);
            for (int i = 0; i < ds5.Tables[0].Rows.Count; i++)
            {
                this.cboname.Items.Add(ds5.Tables[0].Rows[i][0].ToString());
                this.cbopcode.Items.Add(ds5.Tables[0].Rows[i][1].ToString());
            }

            da = new SqlDataAdapter("select cc,comp,address,year_start,year_end,pathologist,biochemist,telphoneno,email,cstno,address1,faxno from company", con);
            ds2 = new DataSet();
            da.Fill(ds2);
            da.Dispose();
       
        }
        public void ADDROW()
        {
            
            dr = dt.NewRow();
            dr["Grp"] = Ggrp;
            dr["Desc"] = Gdesc;
            dr["Desc1"] = Gdesc1;
            dr["Result"] = Gresult;
            dr["Result1"] = Gresult1;
            dr["Result2"] = Gresult2;
            dr["Unit"] = Gunit;
            dr["Normal_Range"] = Gnormalrange;
            dr["Normal_Range1"] = Gnormalrange1;
            
            dr["pcode"]=gcode;
            dr["Age"] = gage;
            dr["Sex"] = gsex;
            dr["Patient_name"] = gpatient_name;
            dr["dt_report"] = gdt_report;
            dr["doctor"] = gdoctor;
            dr["month_year"] = gmnyr;
            dr["scn"] = gscn;
            dr["tpt"] = gtpt;
            dr["range_from"] = grange_from;
            dr["range_to"] = grange_to;
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
            int i = 0;
            //strsql = "select a.cc,a.patient_name,a.pcode,a.sex,a.age,a.doctor,a.date_exam,a.month_year,a.scn,a.tpt,";
            //strsql = strsql + "b.cc,b.pcode,b.TOTAL_TRIIODOTHYRONINE_T3,b.TOTAL_THYROXINE_T4,b.TSH,b.FREE_TRIIODOTHYRONINE_FT3,b.FREE_THYROXINE_FT4,b.ANTIMICROSOMAL_ANTIBODY_AMA,b.TOTAL_CHOLESTEROL,b.ANTITUBERCULOSIS_TB_IgG,b.ANTITUBERCULOSIS_TB_IgM,b.ANTITUBERCULOSIS_TB_IgA,b.PROLACTIN_PRL,b.PROSTATESPECIFICANTIGEN_PSA,b.ADENOSINE_DEAMINASE,b.CA_125,b.ANA,b.BHCG";
            strsql = "select a.cc,a.patient_name,a.pcode,a.sex,a.age,a.doctor,a.date_exam,a.month_year,a.scn,a.tpt,";
            strsql = strsql + "b.cc,b.pcode,b.TOTAL_TRIIODOTHYRONINE_T3,b.TOTAL_THYROXINE_T4,b.TSH,b.FREE_TRIIODOTHYRONINE_FT3,b.FREE_THYROXINE_FT4,b.ANTIMICROSOMAL_ANTIBODY_AMA,b.TOTAL_CHOLESTEROL,b.ANTITUBERCULOSIS_TB_IgG,b.ANTITUBERCULOSIS_TB_IgM,b.ANTITUBERCULOSIS_TB_IgA,b.PROLACTIN_PRL,b.PROSTATESPECIFICANTIGEN_PSA,b.ADENOSINE_DEAMINASE,b.CA_125,b.ANA,b.BHCG";
            
                        
            strsql = strsql + " from patient_master a,Hormone b  where a.pcode='" + cbopcode.Text + "' and a.pcode=b.pcode";

            da = new SqlDataAdapter(strsql, con);
            ds = new DataSet();
            da.Fill(ds);

            //int i = 0;
           
                //cashbankrep = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                //cashbankrep.Load("/Hope_account/Hope_account/repcash_Bank.rpt");
                dt = new DataTable();
                //Ds_hope ds1 = new Ds_hope();
                //Pathology_Ds Ds1 = new Pathology_Ds();
                ds1 = new DataSet();
                dt = ds1.Tables.Add("Pathology_Dt");
                dt.Columns.Add("Grp", System.Type.GetType("System.String"));
                dt.Columns.Add("Desc", System.Type.GetType("System.String"));
                dt.Columns.Add("Desc1", System.Type.GetType("System.String"));
                dt.Columns.Add("Result", System.Type.GetType("System.String"));
                dt.Columns.Add("Result1", System.Type.GetType("System.String"));
                dt.Columns.Add("Result2", System.Type.GetType("System.String"));
                dt.Columns.Add("Unit", System.Type.GetType("System.String"));
                dt.Columns.Add("Normal_Range", System.Type.GetType("System.String"));
                dt.Columns.Add("Normal_Range1", System.Type.GetType("System.String"));
                //String acd = ds.Tables[0].Rows[i][53].ToString();
                //while (acd == ds.Tables[0].Rows[i][0].ToString())
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
            
            
            if (ds.Tables[0].Rows.Count != 0)
                {
            
            gcode = Convert.ToInt32(ds.Tables[0].Rows[i][2].ToString());
                gage = Convert.ToInt32(ds.Tables[0].Rows[i][4].ToString());
                gsex = ds.Tables[0].Rows[i][3].ToString();
                gpatient_name = ds.Tables[0].Rows[i][1].ToString();
                gdt_report = Convert.ToDateTime(ds.Tables[0].Rows[i][6].ToString());
                gdoctor = ds.Tables[0].Rows[i][5].ToString();
                gmnyr = ds.Tables[0].Rows[i][7].ToString();
                gscn = ds.Tables[0].Rows[i][8].ToString();
                gtpt = ds.Tables[0].Rows[i][9].ToString();


                //if (radioButton1.Checked == true)
                //{
                    if (Convert.ToDouble (ds.Tables[0].Rows[i][12].ToString()) != 0)
                    {
                        Ggrp = "";
                        Gdesc = "TOTAL TRIIODOTHYRONINE (T3) ";
                       // Gdesc1 = "C.L.I.A.";
                        Gresult = ds.Tables[0].Rows[i][12].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 3).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method  from reference_master where test = 'TOTAL TRIIODOTHYRONINE (T3)'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();

                        Gnormalrange1 = "";
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
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
                        da.Dispose();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][13].ToString()) != 0)
                    {
                        Ggrp = "";
                        Gdesc = "TOTAL THYROXINE (T4) ";
                        //Gdesc1 = "C.L.I.A. ";
                        Gresult = ds.Tables[0].Rows[i][13].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 3).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method  from reference_master where test = 'TOTAL THYROXINE (T4)'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();

                        Gnormalrange1 = "";
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
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
                        da.Dispose();
                    }



                    if (Convert.ToDouble (ds.Tables[0].Rows[i][14].ToString()) != 0)
                    {
                        Ggrp = "";
                        Gdesc = "THYROID STIMULATING HORMONE (TSH)";
                        //Gdesc1 = "C.L.I.A.";
                        Gresult = ds.Tables[0].Rows[i][14].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 3).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method  from reference_master where test = 'THYROID STIMULATING HORMONE (TSH)'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();

                        Gnormalrange1 = "";
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
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
                        da.Dispose();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][15].ToString()) != 0)
                    {
                        Ggrp = "";
                        Gdesc = "FREE TRIIODOTHYRONINE (FT3)";
                        //Gdesc1 = "C.L.I.A.";
                        Gresult = ds.Tables[0].Rows[i][15].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 3).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method  from reference_master where test = 'FREE TRIIODOTHYRONINE (FT3)'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();

                        Gnormalrange1 = "";
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
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
                        da.Dispose();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][16].ToString()) != 0)
                    {
                        Ggrp = "";
                        Gdesc = "FREE THYROXINE (FT4)";
                        //Gdesc1 = "C.L.I.A.";
                        Gresult = ds.Tables[0].Rows[i][16].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 3).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method  from reference_master where test = 'FREE THYROXINE (FT4)'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();

                        Gnormalrange1 = "";
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
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
                        da.Dispose();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][17].ToString()) != 0)
                    {
                        //Mgrpc = "26";
                        //Mgrpname = "HORMONE ASSAY";
                        Ggrp = "";
                        Gdesc = "ANTIMICROSOMAL ANTIBODY (AMA)";
                        //Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][17].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 3).ToString("0.0###");

                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method  from reference_master where test = 'ANTIMICROSOMAL ANTIBODY (AMA)'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();

                        Gnormalrange1 = "";
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
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
                        da.Dispose();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][18].ToString()) != 0)
                    {
                        //Mgrpc = "26";
                        //Mgrpname = "HORMONE ASSAY";
                        Ggrp = "";
                        Gdesc = "TOTAL CHOLESTEROL";
                       // Gdesc1 = "Biochemistry";
                        Gresult = ds.Tables[0].Rows[i][18].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 3).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method  from reference_master where test = 'TOTAL CHOLESTEROL'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();

                        Gnormalrange1 = "";
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
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
                        da.Dispose();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][19].ToString()) != 0)
                    {
                        //Mgrpc = "26";
                        //Mgrpname = "HORMONE ASSAY";
                        Ggrp = "";
                        Gdesc = "ANTI TUBERCULOSIS (TB)-IgG";
                        //Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][19].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 3).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method  from reference_master where test = 'ANTI TUBERCULOSIS (TB)-IgG'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();

                        Gnormalrange1 = "";
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
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
                        da.Dispose();
                    }


                    if (Convert.ToDouble(ds.Tables[0].Rows[i][20].ToString()) != 0)
                    {
                        //Mgrpc = "26";
                        //Mgrpname = "HORMONE ASSAY";
                        Ggrp = "";
                        Gdesc = "ANTI TUBERCULOSIS(TB)-IgM";
                       // Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][20].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 3).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method  from reference_master where test = 'ANTI TUBERCULOSIS(TB)-IgM'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();

                        Gnormalrange1 = "";
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
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
                        da.Dispose();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][21].ToString()) != 0)
                    {
                        //Mgrpc = "26";
                        //Mgrpname = "HORMONE ASSAY";
                        Ggrp = "";
                        Gdesc = "ANTI TUBERCULOSIS(TB)-IgA";
                        //Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][21].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 3).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method  from reference_master where test = 'ANTI TUBERCULOSIS(TB)-IgA'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();

                        Gnormalrange1 = "";
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
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
                        da.Dispose();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][22].ToString()) != 0)
                    {
                        //Mgrpc = "26";
                        //Mgrpname = "HORMONE ASSAY";
                        Ggrp = "";
                        Gdesc = "PROLACTIN (PRL)";
                       // Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][22].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 3).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method  from reference_master where test = 'PROLACTIN (PRL)'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();

                        Gnormalrange1 = "";
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
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
                        da.Dispose();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][23].ToString()) != 0)
                    {
                        //Mgrpc = "26";
                        //Mgrpname = "HORMONE ASSAY";
                        Ggrp = "";
                        Gdesc = "PROSTATE SPECIFIC ANTIGEN (PSA)";
                       // Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][23].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 3).ToString("0.0###");

                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method  from reference_master where test = 'PROSTATE SPECIFIC ANTIGEN (PSA)'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();

                        Gnormalrange1 = "";
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
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
                        da.Dispose();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][24].ToString()) != 0)
                    {
                        //Mgrpc = "26";
                        //Mgrpname = "HORMONE ASSAY";
                        Ggrp = "";
                        Gdesc = "ADENOSINE DEAMINASE";
                       // Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][24].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 3).ToString("0.0###");

                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method  from reference_master where test = 'ADENOSINE DEAMINASE'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();

                        Gnormalrange1 = "";
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
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
                        da.Dispose();
                    }


                    if (Convert.ToDouble(ds.Tables[0].Rows[i][25].ToString()) != 0)
                    {
                        //Mgrpc = "26";
                        //Mgrpname = "HORMONE ASSAY";
                        Ggrp = "";
                        Gdesc = "CA - 125";
                        //Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][25].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 3).ToString("0.0###");

                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method  from reference_master where test = 'CA - 125'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();

                        Gnormalrange1 = "";
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
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
                        da.Dispose();
                    }
                    //Gdescpss = "( P.S. )";
                    //Gresultpss = ds.Tables[0].Rows[i][27].ToString();
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][26].ToString()) != 0)
                    {
                        //Mgrpc = "26";
                        //Mgrpname = "HORMONE ASSAY";
                        Ggrp = "";
                        Gdesc = "ANTI NUCLEAR ANTIBODIES (ANA)";
                       // Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][26].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 3).ToString("0.0###");

                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method  from reference_master where test = 'ANTI NUCLEAR ANTIBODIES (ANA)'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();

                        Gnormalrange1 = "";
                        Gdesc1 = ds3.Tables[0].Rows[0][5].ToString();
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
                        da.Dispose();
                    }

                //if (radioButton3.Checked == true)
                //{
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][27].ToString()) != 0)
                    {
                        Ggrp = "";
                        Gdesc = "BETA HUMAN CHRONIC GONADOTROPIN(BHCG)";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][27].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 3).ToString("0.0###");

                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to,method  from reference_master where test = 'BETA HUMAN CHRONIC GONADOTROPIN(BHCG)'", con);
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



                        //Gunit = "mIU/mL";
                        //Gnormalrange = "< 10 ";
                        //Gnormalrange1 = "";
                        //grange_from = "0";
                        //grange_to = "0";
                        ADDROW();
                        da.Dispose();
                    }
                //}
                // pregnacny ends
            
            }

            //da.Dispose();
            da = new SqlDataAdapter("select b.test,b.method,b.result,b.unit,b.normal_range, a.cc,a.patient_name,a.pcode,a.sex,a.age,a.doctor,a.date_exam,a.month_year,a.scn,a.tpt from hormoneext b,patient_master a where (a.pcode=b.pcode) and a.pcode='" + cbopcode.Text + "'", con);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                gcode = Convert.ToInt32(ds.Tables[0].Rows[i][7].ToString());
                gage = Convert.ToInt32(ds.Tables[0].Rows[i][9].ToString());
                gsex = ds.Tables[0].Rows[i][8].ToString();
                gpatient_name = ds.Tables[0].Rows[i][6].ToString();
                gdt_report = Convert.ToDateTime(ds.Tables[0].Rows[i][11].ToString());
                gdoctor = ds.Tables[0].Rows[i][10].ToString();
                gmnyr = ds.Tables[0].Rows[i][12].ToString();
                gscn = ds.Tables[0].Rows[i][13].ToString();
                gtpt = ds.Tables[0].Rows[i][14].ToString();

                int k = i;
                for (i = k; i < k + ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i][2].ToString() != "")
                    {
                        //Mgrpc = "26";
                        //Mgrpname = "HORMONE ASSAY";
                        Ggrp = "";
                        if (ds.Tables[0].Rows[i][1].ToString() != "")
                        {

                            Gdesc = ds.Tables[0].Rows[i][0].ToString().Trim();
                            Gdesc1 = ds.Tables[0].Rows[i][1].ToString().Trim() ;
                        }
                        else
                        {
                            Gdesc = ds.Tables[0].Rows[i][0].ToString().Trim();
                            Gdesc1 = "";
                        }
                                               
                        Gresult = ds.Tables[0].Rows[i][2].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 3).ToString("0.0###");

                        Gunit = ds.Tables[0].Rows[i][3].ToString();
                        Gnormalrange = ds.Tables[0].Rows[i][4].ToString();
                        Gnormalrange1 = "";

                        grange_from = "0";
                        grange_to = "0";

                        ADDROW();
                    }
                }
            }
            da.Dispose();
            // *****hormoneext  end






            // Repblood cashbankrep = new Repblood();
            //Rephormone cashbankrep = new Rephormone();
            Rephormonen cashbankrep = new Rephormonen();
            // cashbankrep.SetDatabaseLogon("sa", "software", @".\sqlexpress", "pathology2627");
            cashbankrep.SetDataSource(dt);
            crv.ReportSource = cashbankrep;
            cashbankrep.SetParameterValue(0, ds2.Tables[0].Rows[0][5].ToString());
            cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows[0][6].ToString());
            cashbankrep.SetParameterValue(2, ds2.Tables[0].Rows[0][9].ToString());
            cashbankrep.SetParameterValue(3, ds2.Tables[0].Rows[0][10].ToString());
            cashbankrep.SetParameterValue(4, ds2.Tables[0].Rows[0][11].ToString());
            
            
            //cashbankrep.SetParameterValue(2, reportname);
           // cashbankrep.SetParameterValue(0, Gdescpss);
            //cashbankrep.SetParameterValue(4, Gresultpss);

            crv.Refresh();
           // crv.PrintReport();
       
        }

        private void cbopcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("select distinct patient_name,pcode from patient_master where pcode='"+cbopcode.Text  +"' order by pcode", con);
            ds5 = new DataSet();
            da.Fill(ds5);

                cboname.Text =(ds5.Tables[0].Rows[0][0].ToString());
                
           
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnback_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    
    
    
    
    
    }
}