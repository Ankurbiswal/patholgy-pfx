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
    public partial class Frmrepserology : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        SqlDataReader dr1;
        DataRow dr;
        DataTable dt;
        DataSet ds, ds1, ds2,ds3 ,ds5;
        public static string Ggrp, Gdesc, Gresult, Gunit, Gnormalrange;
        public static int gcode, gage;
        public static string gsex, gpatient_name, gdoctor, gmnyr, gscn, gtpt;
        public DateTime gdt_report;
        public static string reportname;
        public static string Gdescpss, Gdescpss1;
        public static string Gresultpss, Gresultpss1;
        public static string Gdesc10, Gdesc14, Gdesc18, Gdesc22 = "";
        public static string Gresult11, Gresult12, Gresult13, Gresult15, Gresult16, Gresult17, Gresult19, Gresult20, Gresult21, Gresult23, Gresult24, Gresult25 = "";
        public static string Gdesc200="", Gdesc201="",Gdesc202="", Gdesc203="";
        public static string Gresult26, Gresult27, Gresult28, Gresult29, Gresult30, Gresult31, Gresult32, Gresult33 = "";
        public static string typhoimpr="";
        public Byte[] imageData;
        public static String qrcode = "";
        public Frmrepserology()
        {
            InitializeComponent();
        }

        private void Frmrepserology_Load(object sender, EventArgs e)
        {
            //con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Pathology;Persist Security Info=True;User ID=sa;Password=software;");
            Class1 objclass = new Class1();
            con = new SqlConnection(objclass.arun_con());
            
            con.Open();
            cmd = new SqlCommand("select cc,comp,year_start,year_end,regno from setup");
            cmd.Connection = con;
            dr1 = cmd.ExecuteReader();
            while (dr1.Read())
            {
                this.cbopcode .Text  = dr1.GetValue(4).ToString();
                
            }
            dr1.Close();

            da = new SqlDataAdapter("select patient_name,pcode from patient_master where pcode='" + cbopcode.Text + "' order by pcode", con);
            ds5 = new DataSet();
            da.Fill(ds5);

            if (ds5.Tables[0].Rows.Count > 0)
                cboname.Text = ds5.Tables[0].Rows[0][0].ToString();
            da.Dispose();


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
            reportname = "SEROLOGY  REPORT";
            da.Dispose();
            radioButton1.Checked = true;
        
        }
        public void ADDROW()
        {

            dr = dt.NewRow();
            dr["Grp"] = Ggrp;
            dr["Desc"] = Gdesc;
            dr["Result"] = Gresult;
            dr["Unit"] = Gunit;
            dr["Normal_Range"] = Gnormalrange;
            dr["pcode"] = gcode;
            dr["Age"] = gage;
            dr["Sex"] = gsex;
            dr["Patient_name"] = gpatient_name;
            dr["dt_report"] = gdt_report;
            dr["doctor"] = gdoctor;
            dr["month_year"] = gmnyr;
            dr["scn"] = gscn;
            dr["tpt"] = gtpt;
            String qrdata = (ds2.Tables[0].Rows.Count > 0 ? ds2.Tables[0].Rows[0][11].ToString().Trim() : "") + cbopcode.Text.Trim();


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
          
                strsql = "select a.cc,a.patient_name,a.pcode,a.sex,a.age,a.doctor,a.date_exam,a.month_year,a.scn,a.tpt,";
                strsql = strsql + "b.cc,b.pcode,b.BG_Blood_Group,b.BR_RhD_Typing,b.BDc_Neutrophild,b.BDc_Eosinophils,b.BDc_Lymphocytes,b.BDc_Basophils,b.BDc_Monocytes,b.BDc_Twbc,b.BDc_Trbc,b.BDc_Tplatelets,";
                strsql = strsql + "b.BDc_Aec,b.BDc_Tnc,b.BDc_Reticulocyte_Count,b.BDc_PCV,b.BDC_mcv,b.BDC_mch,b.BDC_mchc,b.BDc_Mp_ICT_QBC_Smear,b.BDc_Mf_ICT_QBC_Smear,b.BDc_Hb,b.BDc_ESR_1sthour,";
                strsql = strsql + "b.BDc_Bleeding_Time,b.BDc_Clotting_Time,b.BDc_Sickle_cell,b.Bw_WidaltubeO80,b.Bw_Widalslide1,b.Bw_Widalslide2,b.Bw_Widalslide3,b.Bw_Widalslide4,";
                strsql = strsql + "b.BPS_Aso,b.BPS_Crp,b.BPS_Rafactor,b.BPS_Ana,b.BPS_Vdrl,b.BPS_Toxo,b.BS_Australia_Antigen,b.BS_Hepatitis_C_Virus,b.BS_HIV_1,b.BS_HIV_2,";
                strsql = strsql + "b.Bw_mycodot,b.bw_trop,b.Bm_MontouxTest_injon,b.Bm_MontouxTest_readon,b.Bm_MontouxTest_induration,b.BDc_Dengue,b.BDc_Typhicheck,";
                strsql = strsql + "b.Bw_Widaltubeo80,b.Bw_Widaltubeo160,b.Bw_Widaltubeo320,b.Bw_Widaltubeh80,b.Bw_Widaltubeh160,b.Bw_Widaltubeh320,b.Bw_Widaltubeah80,b.Bw_Widaltubeah160,b.Bw_Widaltubeah320,b.Bw_Widaltubebh80,b.Bw_Widaltubebh160,b.Bw_Widaltubebh320,";
                strsql = strsql + "b.Bw_Widaltubeo240,b.Bw_Widaltubeo480,b.Bw_Widaltubeh240,b.Bw_Widaltubeh480,b.Bw_Widaltubeah240,b.Bw_Widaltubeah480,b.Bw_Widaltubebh240,b.Bw_Widaltubebh480,b.BDc_Dengue_NSI,b.ser_imp,";

                strsql = strsql + "b.sr_afp,b.SR_ASA,b.SR_CV_IGG,b.SR_CV_IGM,b.SR_HSV_IGG,b.SR_HSV_IGM,b.SR_RV_IGG,";
                strsql = strsql + "b.SR_RV_IGM,b.SR_HBSA,b.SR_AHBSAT,b.SR_HBEA,b.SR_AHBEAT,b.sr_ahbca_igm,b.sr_ahbcat,b.SR_AHAV_IGM,b.SR_AHAVT,";
                strsql = strsql + "b.SR_AHCVT,b.SR_AHEV_IGM,b.sr_hp_igg,b.sr_hp_igm,b.sr_hp_iga,BPS_Aso_qty,BPS_Crp_qty,BPS_Rafactor_qty,Bw_Trop_qty";
             
            strsql = strsql + " from patient_master a,Blood b where a.pcode='" + cbopcode.Text + "' and a.pcode=b.pcode";

                da = new SqlDataAdapter(strsql, con);
                ds = new DataSet();
                da.Fill(ds);

                //int i = 0;
                if (ds.Tables[0].Rows.Count != 0)
                {
                    //cashbankrep = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    //cashbankrep.Load("/Hope_account/Hope_account/repcash_Bank.rpt");
                    dt = new DataTable();
                    //Ds_hope ds1 = new Ds_hope();
                    //Pathology_Ds Ds1 = new Pathology_Ds();
                    ds1 = new DataSet();
                    dt = ds1.Tables.Add("Pathology_Dt");
                    dt.Columns.Add("Grp", System.Type.GetType("System.String"));
                    dt.Columns.Add("Desc", System.Type.GetType("System.String"));
                    dt.Columns.Add("Result", System.Type.GetType("System.String"));
                    dt.Columns.Add("Unit", System.Type.GetType("System.String"));
                    dt.Columns.Add("Normal_Range", System.Type.GetType("System.String"));

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
                   
                    if (ds.Tables[0].Rows[i][37].ToString() != "")
                    {
                        Ggrp = "Widal Test: By Slide Agglutination Method";
                        Gdesc = "Salmonella Typhi O";
                        Gresult = ds.Tables[0].Rows[i][37].ToString();
                        Gunit = "";
                        Gnormalrange = " ";
                        ADDROW();
                     Gdesc200= ds.Tables[0].Rows[i][37].ToString();
                    }
                    if (ds.Tables[0].Rows[i][38].ToString() != "")
                    {
                        Ggrp = "Widal Test: By Slide Agglutination Method";
                        Gdesc = "Salmonella Typhi H";
                        Gresult = ds.Tables[0].Rows[i][38].ToString();
                        Gunit = "";
                        Gnormalrange = "";
                        ADDROW();
                        Gdesc201 = ds.Tables[0].Rows[i][38].ToString();
                    }
                    if (ds.Tables[0].Rows[i][39].ToString() != "")
                    {
                        Ggrp = "Widal Test: By Slide Agglutination Method";
                        Gdesc = "Salmonella Typhi AH";
                        Gresult = ds.Tables[0].Rows[i][39].ToString();
                        Gunit = "";
                        Gnormalrange = "";
                        ADDROW();
                        Gdesc202 = ds.Tables[0].Rows[i][39].ToString();
                    }
                    if (ds.Tables[0].Rows[i][40].ToString() != "")
                    {
                        Ggrp = "Widal Test: By Slide Agglutination Method";
                        Gdesc = "Salmonella Typhi BH";
                        Gresult = ds.Tables[0].Rows[i][40].ToString();
                        Gunit = "";
                        Gnormalrange = "";
                        ADDROW();
                        Gdesc203 = ds.Tables[0].Rows[i][40].ToString();
                    }  
                    
                    if (ds.Tables[0].Rows[i][41].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "A.S.O. Titre";
                        Gresult = ds.Tables[0].Rows[i][41].ToString();
                        Gunit = "";
                        Gnormalrange = "";
                        ADDROW();
                    }  
                    
                    
                   
                    if (ds.Tables[0].Rows[i][42].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "C Reactive Protein(CRP)";
                        Gresult = ds.Tables[0].Rows[i][42].ToString();
                        Gunit = "";
                        Gnormalrange = "";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][43].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Rheumatoid Factor(RF)";
                        Gresult = ds.Tables[0].Rows[i][43].ToString();
                        Gunit = "";
                        Gnormalrange = "";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][44].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Test for Antinuclear Antibody";
                        Gresult = ds.Tables[0].Rows[i][44].ToString();
                        Gunit = "";
                        Gnormalrange = " ";
                        ADDROW();
                    } 
                   
                    
                    if (ds.Tables[0].Rows[i][45].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "V.D.R.L";
                        Gresult = ds.Tables[0].Rows[i][45].ToString();
                        Gunit = "";
                        Gnormalrange = " ";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][46].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Toxo Plasma(Antibody) ";
                        Gresult = ds.Tables[0].Rows[i][46].ToString();
                        Gunit = "";
                        Gnormalrange = " ";
                        ADDROW();
                    }
                   
                  

                    if (ds.Tables[0].Rows[i][47].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "HbsAg (Australian Antigen)";
                        Gresult = ds.Tables[0].Rows[i][47].ToString();
                        Gunit = "";
                        Gnormalrange = " ";
                        ADDROW();
                    }

                    if (ds.Tables[0].Rows[i][48].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Hepatitis C Virus";
                        Gresult = ds.Tables[0].Rows[i][48].ToString();
                        Gunit = "";
                        Gnormalrange = " ";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][49].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "HIV Rapid Test(I)";
                        Gresult = ds.Tables[0].Rows[i][49].ToString();
                        Gunit = "";
                        Gnormalrange = " ";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][50].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "HIV Rapid Test(II)";
                        Gresult = ds.Tables[0].Rows[i][50].ToString();
                        Gunit = "";
                        Gnormalrange = " ";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][51].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Mycodot/(LAM) Test-                                  (For detection of (IgG)";
                        Gresult = ds.Tables[0].Rows[i][51].ToString();
                        Gunit = "";
                        Gnormalrange = " ";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][52].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Trop T /Trop I(Qualitative)";
                        Gresult = ds.Tables[0].Rows[i][52].ToString();
                        Gunit = "";
                        Gnormalrange = " ";
                        ADDROW();
                    }   
                    
                   
                                       
                    if (ds.Tables[0].Rows[i][53].ToString() != "")
                    {
                        Ggrp = "Mantoux Test";
                        Gdesc = "MantouxTest Inj On";
                        Gresult = ds.Tables[0].Rows[i][53].ToString();
                        Gunit = "";
                        Gnormalrange = " ";
                        ADDROW();
                    }

                    if (ds.Tables[0].Rows[i][54].ToString() != "")
                    {
                        Ggrp = "Mantoux Test";
                        Gdesc = "        Read On";
                        Gresult = ds.Tables[0].Rows[i][54].ToString();
                        Gunit = "";
                        Gnormalrange = " ";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][55].ToString() != "")
                    {
                        Ggrp = "Mantoux Test";
                        Gdesc = "       Induration";
                        Gresult = ds.Tables[0].Rows[i][55].ToString();
                        Gunit = "";
                        Gnormalrange = " ";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][56].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "DENGUE (IgG/IgM)";
                        Gresult = ds.Tables[0].Rows[i][56].ToString();
                        Gunit = "";
                        Gnormalrange = " ";
                        ADDROW();
                    }

                    if (ds.Tables[0].Rows[i][78].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "DENGUE (NSI Antigen)";
                        Gresult = ds.Tables[0].Rows[i][78].ToString();
                        Gunit = "";
                        Gnormalrange = " ";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][57].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Typhoid Check (IgG/IgM)";
                        Gresult = ds.Tables[0].Rows[i][57].ToString();
                        Gunit = "";
                        Gnormalrange = " ";
                        ADDROW();
                    }
//serology 2 start
                    if (ds.Tables[0].Rows[i][80].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Alpha Feto Protein";
                        Gresult = ds.Tables[0].Rows[i][80].ToString();
                        Gunit = "OD Ratio";
                        Gnormalrange = "Negative  :  <=0.90           Equivocal : 0.91-1.10            Positive : >=1.11 ";
                        ADDROW();
                    }

                    if (ds.Tables[0].Rows[i][81].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Anti Sperm Antibody";
                        Gresult = ds.Tables[0].Rows[i][81].ToString();
                        Gunit = "";
                        Gnormalrange = "Negative  :  <=0.90           Equivocal : 0.91-1.10            Positive : >=1.11 ";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][82].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Cytomegalovirus-IgG";
                        Gresult = ds.Tables[0].Rows[i][82].ToString();
                        Gunit = "";
                        Gnormalrange = "Negative  :  <=0.90           Equivocal : 0.91-1.10            Positive : >=1.11 ";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][83].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Cytomegalovirus-IgM";
                        Gresult = ds.Tables[0].Rows[i][83].ToString();
                        Gunit = "";
                        Gnormalrange = "Negative  :  <=0.90           Equivocal : 0.91-1.10            Positive : >=1.11 ";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][84].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Herpes Simplex Virus-IgG";
                        Gresult = ds.Tables[0].Rows[i][84].ToString();
                        Gunit = "";
                        Gnormalrange = "Negative  :  <=0.90           Equivocal : 0.91-1.10            Positive : >=1.11 ";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][85].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Herpes Simplex Virus-IgM";
                        Gresult = ds.Tables[0].Rows[i][85].ToString();
                        Gunit = "";
                        Gnormalrange = "Negative  :  <=0.90           Equivocal : 0.91-1.10            Positive : >=1.11 ";
                        ADDROW();
                    }

                    if (ds.Tables[0].Rows[i][86].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Rubella-IgG";
                        Gresult = ds.Tables[0].Rows[i][86].ToString();
                        Gunit = "";
                        Gnormalrange = "Negative  :  <=0.90           Equivocal : 0.91-1.10            Positive : >=1.11 ";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][87].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Rubella-IgM";
                        Gresult = ds.Tables[0].Rows[i][87].ToString();
                        Gunit = "";
                        Gnormalrange = "Negative  :  <=0.90           Equivocal : 0.91-1.10            Positive : >=1.11 ";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][88].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Hepatitis B Surface Antigen";
                        Gresult = ds.Tables[0].Rows[i][88].ToString();
                        Gunit = "";
                        Gnormalrange = "Negative  :  <=0.90           Equivocal : 0.91-1.10            Positive : >=1.11 ";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][89].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Anti Hepatitis B Surface Antigen-Total";
                        Gresult = ds.Tables[0].Rows[i][89].ToString();
                        Gunit = "";
                        Gnormalrange = "Negative  :  <=0.90           Equivocal : 0.91-1.10            Positive : >=1.11 ";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][90].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Hepatitis B Envelope Antigen";
                        Gresult = ds.Tables[0].Rows[i][90].ToString();
                        Gunit = "";
                        Gnormalrange = "Negative  :  <=0.90           Equivocal : 0.91-1.10            Positive : >=1.11 ";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][91].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Anti Hepatitis B Envelope Antigen-Total";
                        Gresult = ds.Tables[0].Rows[i][91].ToString();
                        Gunit = "";
                        Gnormalrange = "Negative  :  <=0.90           Equivocal : 0.91-1.10            Positive : >=1.11 ";
                        ADDROW();
                    }

                    if (ds.Tables[0].Rows[i][92].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Anti Hepatitis B Core Antigen-IgM";
                        Gresult = ds.Tables[0].Rows[i][92].ToString();
                        Gunit = "";
                        Gnormalrange = "Negative  :  <=0.90           Equivocal : 0.91-1.10            Positive : >=1.11 ";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][93].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Anti Hepatitis B Core Antigen-Total";
                        Gresult = ds.Tables[0].Rows[i][93].ToString();
                        Gunit = "";
                        Gnormalrange = "Negative  :  <=0.90           Equivocal : 0.91-1.10            Positive : >=1.11 ";
                        ADDROW();
                    }

                    if (ds.Tables[0].Rows[i][94].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Anti Hepatitis A Virus-IgM";
                        Gresult = ds.Tables[0].Rows[i][94].ToString();
                        Gunit = "";
                        Gnormalrange = "Negative  :  <=0.90           Equivocal : 0.91-1.10            Positive : >=1.11 ";
                        ADDROW();
                    }

                    if (ds.Tables[0].Rows[i][95].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Anti Hepatitis A Virus-Total";
                        Gresult = ds.Tables[0].Rows[i][95].ToString();
                        Gunit = "";
                        Gnormalrange = "Negative  :  <=0.90           Equivocal : 0.91-1.10            Positive : >=1.11 ";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][96].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Anti Hepatitis C Virus-Total";
                        Gresult = ds.Tables[0].Rows[i][96].ToString();
                        Gunit = "";
                        Gnormalrange = "Negative  :  <=0.90           Equivocal : 0.91-1.10            Positive : >=1.11 ";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][97].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Anti Hepatitis E Virus-IgM";
                        Gresult = ds.Tables[0].Rows[i][97].ToString();
                        Gunit = "";
                        Gnormalrange = "Negative  :  <=0.90           Equivocal : 0.91-1.10            Positive : >=1.11 ";
                        ADDROW();
                    }


                    if (ds.Tables[0].Rows[i][98].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "H.Pylori IgG";
                        Gresult = ds.Tables[0].Rows[i][98].ToString();
                        Gunit = "";
                        Gnormalrange = "Negative  :  <=0.90           Equivocal : 0.91-1.10            Positive : >=1.11 ";
                        ADDROW();
                    }

                    if (ds.Tables[0].Rows[i][99].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "H.Pylori IgM";
                        Gresult = ds.Tables[0].Rows[i][99].ToString();
                        Gunit = "";
                        Gnormalrange = "Negative  :  <=0.90           Equivocal : 0.91-1.10            Positive : >=1.11 ";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][100].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "H.Pylori IgA";
                        Gresult = ds.Tables[0].Rows[i][100].ToString();
                        Gunit = "";
                        Gnormalrange = "Negative  :  <=0.90           Equivocal : 0.91-1.10            Positive : >=1.11 ";
                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][101].ToString()) != 0)
                    {
                        //Mgrpc = "21";
                        //Mgrpname = "SEROLOGY  REPORT";
                        Ggrp = "";
                        Gdesc = "A.S.O.(Quantitative)";
                        //Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][101].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to  from reference_master where test = 'A.S.O.(Quantitative)'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        //Gnormalrange = "70 - 110 ";
                        //Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            //grange_from = "1";
                            //grange_to = "1";
                        }
                        else
                        {
                            //grange_from = "0";
                            //grange_to = "0";
                        }
                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][102].ToString()) != 0)
                    {
                        //Mgrpc = "21";
                        //Mgrpname = "SEROLOGY  REPORT";
                        Ggrp = "";
                        Gdesc = "C.R.P.(Quantitative)";
                        //Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][102].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to  from reference_master where test = 'C.R.P.(Quantitative)'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        //Gnormalrange = "70 - 110 ";
                        //Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            //grange_from = "1";
                            //grange_to = "1";
                        }
                        else
                        {
                            //grange_from = "0";
                            //grange_to = "0";
                        }
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][103].ToString()) != 0)
                    {
                        //Mgrpc = "21";
                        //Mgrpname = "SEROLOGY  REPORT";
                        Ggrp = "";
                        Gdesc = "Rheumatoid Factor (Quantitative)";
                        //Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][103].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to  from reference_master where test = 'Rheumatoid Factor (Quantitative)'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        //Gnormalrange = "70 - 110 ";
                        //Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            //grange_from = "1";
                            //grange_to = "1";
                        }
                        else
                        {
                            //grange_from = "0";
                            //grange_to = "0";
                        }
                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][104].ToString()) != 0)
                    {
                        //Mgrpc = "21";
                        //Mgrpname = "SEROLOGY  REPORT";
                        Ggrp = "";
                        Gdesc = "Trop T (Sensitive)";
                        //Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][104].ToString();
                        Double gre = Convert.ToDouble(Gresult);
                        Gresult = Math.Round(gre, 2).ToString("0.0###");
                        da = new SqlDataAdapter("select test,unit,reference_range,range_from,range_to  from reference_master where test = 'Trop T (Sensitive)'", con);
                        ds3 = new DataSet();
                        da.Fill(ds3);
                        Gunit = ds3.Tables[0].Rows[0][1].ToString();
                        Gnormalrange = ds3.Tables[0].Rows[0][2].ToString();
                        //Gnormalrange = "70 - 110 ";
                        //Gnormalrange1 = "";
                        if (Convert.ToDouble(Gresult) < Convert.ToDouble(ds3.Tables[0].Rows[0][3].ToString()) || Convert.ToDouble(Gresult) > Convert.ToDouble(ds3.Tables[0].Rows[0][4].ToString()))
                        {
                            //grange_from = "1";
                            //grange_to = "1";
                        }
                        else
                        {
                            //grange_from = "0";
                            //grange_to = "0";
                        }
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][79].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "IMPRESSION :";
                        Gresult = ds.Tables[0].Rows[i][79].ToString();
                        //typhoimpr = ds.Tables[0].Rows[i][79].ToString();
                        Gunit = "";
                        Gnormalrange = " ";
                       // ADDROW();
                    }
                
                
                  




                    if (radioButton2.Checked == true || radioButton3.Checked == true)
                    {
                        ADDROW();
                        Gdesc10 = "Salmonella Typhi O";
                        Gresult11 = ds.Tables[0].Rows[i][58].ToString();
                        Gresult12 = ds.Tables[0].Rows[i][59].ToString();
                        Gresult13 = ds.Tables[0].Rows[i][60].ToString();
                        Gdesc14 = "Salmonella Typhi H";
                        Gresult15 = ds.Tables[0].Rows[i][61].ToString();
                        Gresult16 = ds.Tables[0].Rows[i][62].ToString();
                        Gresult17 = ds.Tables[0].Rows[i][63].ToString();
                        Gdesc18 = "Salmonella Typhi AH";
                        Gresult19 = ds.Tables[0].Rows[i][64].ToString();
                        Gresult20 = ds.Tables[0].Rows[i][65].ToString();
                        Gresult21 = ds.Tables[0].Rows[i][66].ToString();
                        Gdesc22 = "Salmonella Typhi BH";
                        Gresult23 = ds.Tables[0].Rows[i][67].ToString();
                        Gresult24 = ds.Tables[0].Rows[i][68].ToString();
                        Gresult25 = ds.Tables[0].Rows[i][69].ToString();

                        Gresult26 = ds.Tables[0].Rows[i][70].ToString();
                        Gresult27 = ds.Tables[0].Rows[i][71].ToString();
                        Gresult28 = ds.Tables[0].Rows[i][72].ToString();
                        Gresult29 = ds.Tables[0].Rows[i][73].ToString();
                        Gresult30 = ds.Tables[0].Rows[i][74].ToString();
                        Gresult31 = ds.Tables[0].Rows[i][75].ToString();
                        Gresult32 = ds.Tables[0].Rows[i][76].ToString();
                        Gresult33 = ds.Tables[0].Rows[i][77].ToString();
                        ADDROW();
                   
                    
                    
                    }

                    
                
                }
                // *****serologyext  start
                da.Dispose();
                da = new SqlDataAdapter("select b.test,b.method,b.result,b.unit,b.normal_range, a.cc,a.patient_name,a.pcode,a.sex,a.age,a.doctor,a.date_exam,a.month_year,a.scn,a.tpt from serologyext b,patient_master a where (a.pcode=b.pcode) and a.pcode='" + cbopcode.Text + "'", con);
                ds = new DataSet();
                da.Fill(ds, "serologyext");
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
                            //Mgrpc = "21";
                            //Mgrpname = "SEROLOGY  REPORT";
                            Ggrp = "";
                            if (ds.Tables[0].Rows[i][1].ToString() != "")
                            {

                                Gdesc = ds.Tables[0].Rows[i][0].ToString().Trim() + "(" + ds.Tables[0].Rows[i][1].ToString().Trim() + ")";
                            }
                            else
                            {
                                Gdesc = ds.Tables[0].Rows[i][0].ToString().Trim();
                            }

                            //Gdesc1 = "";
                            Gresult = ds.Tables[0].Rows[i][2].ToString();
                            // Gresult = Gresult.TrimStart('0').TrimEnd('0', '.');

                            Gunit = ds.Tables[0].Rows[i][3].ToString();
                            Gnormalrange = ds.Tables[0].Rows[i][4].ToString();
                            //Gnormalrange1 = "";

                            //grange_from = "0";
                            //grange_to = "0";

                            ADDROW();
                        }
                    }
                }
                // *****serologyext  end





           
            
            
            
            {
               if (radioButton1.Checked == true)
                {
                    Repserology cashbankrep = new Repserology();
                    //cashbankrep.SetDatabaseLogon("sa", "software", @".\sqlexpress", "pathology2627");
                    cashbankrep.SetDataSource(dt);
                    crv.ReportSource = cashbankrep;
                    cashbankrep.SetParameterValue(0, ds2.Tables[0].Rows[0][5].ToString());
                    cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows[0][6].ToString());
                    cashbankrep.SetParameterValue(2, reportname);
                    cashbankrep.SetParameterValue(3, ds2.Tables[0].Rows[0][9].ToString());
                    cashbankrep.SetParameterValue(4, ds2.Tables[0].Rows[0][10].ToString());
                    cashbankrep.SetParameterValue(5, ds2.Tables[0].Rows[0][11].ToString());
                    cashbankrep.SetParameterValue(10, typhoimpr);
                   //cashbankrep.SetParameterValue(3, Gdesc10);
                    //cashbankrep.SetParameterValue(4, Gresult11);
                    //cashbankrep.SetParameterValue(5, Gresult12);
                    //cashbankrep.SetParameterValue(6, Gresult13);
                    //cashbankrep.SetParameterValue(7, Gdesc14);
                    //cashbankrep.SetParameterValue(8, Gresult15);
                    //cashbankrep.SetParameterValue(9, Gresult16);
                    //cashbankrep.SetParameterValue(10, Gresult17);
                    //cashbankrep.SetParameterValue(11, Gdesc18);
                    //cashbankrep.SetParameterValue(12, Gresult19);
                    //cashbankrep.SetParameterValue(13, Gresult20);
                    //cashbankrep.SetParameterValue(14, Gresult21);
                    //cashbankrep.SetParameterValue(15, Gdesc22);
                    //cashbankrep.SetParameterValue(16, Gresult23);
                    //cashbankrep.SetParameterValue(17, Gresult24);
                    //cashbankrep.SetParameterValue(18, Gresult25);
                }
               else if (radioButton3.Checked == true)
               {

                   String slm = "Tube Agglutination Method";

                  Repserologyanglunation cashbankrep = new Repserologyanglunation();
                  // Repserologytubeanglunitation2 cashbankrep = new Repserologytubeanglunitation2();
                   //cashbankrep.SetDatabaseLogon("sa", "software", @".\sqlexpress", "pathology2627");
                   cashbankrep.SetDataSource(dt);
                   crv.ReportSource = cashbankrep;
                   //cashbankrep.SetParameterValue(0, ds2.Tables[0].Rows[0][5].ToString());
                   //cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows[0][6].ToString());
                   //cashbankrep.SetParameterValue(2, reportname);
                   ////cashbankrep.SetParameterValue(3, Gdesc10);
                   //cashbankrep.SetParameterValue(3, Gresult11);
                   //cashbankrep.SetParameterValue(4, Gresult12);
                   //cashbankrep.SetParameterValue(5, Gresult13);
                   //cashbankrep.SetParameterValue(65, Gdesc14);
                   //cashbankrep.SetParameterValue(6, Gresult15);
                   //cashbankrep.SetParameterValue(7, Gresult16);
                   //cashbankrep.SetParameterValue(8, Gresult17);
                   //cashbankrep.SetParameterValue(9, Gdesc18);
                   //cashbankrep.SetParameterValue(10, Gresult19);
                   //cashbankrep.SetParameterValue(11, Gresult20);
                   //cashbankrep.SetParameterValue(12, Gresult21);
                   //cashbankrep.SetParameterValue(13, Gdesc22);
                   //cashbankrep.SetParameterValue(14, Gresult23);
                   //cashbankrep.SetParameterValue(15, Gresult24);
                   //cashbankrep.SetParameterValue(16, Gresult25);

                   //cashbankrep.SetParameterValue(17, Gresult26);
                   //cashbankrep.SetParameterValue(18, Gresult27);
                   //cashbankrep.SetParameterValue(19, Gresult28);
                   //cashbankrep.SetParameterValue(20, Gresult29);
                   //cashbankrep.SetParameterValue(21, Gresult30);
                   //cashbankrep.SetParameterValue(22, Gresult31);
                   //cashbankrep.SetParameterValue(23, Gresult32);
                   //cashbankrep.SetParameterValue(24, Gresult33);

                   cashbankrep.SetParameterValue(0, ds2.Tables[0].Rows[0][5].ToString());
                   cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows[0][6].ToString());
                   cashbankrep.SetParameterValue(2, reportname);
                   cashbankrep.SetParameterValue(3, Gdesc200);
                   cashbankrep.SetParameterValue(4, Gdesc201);
                   cashbankrep.SetParameterValue(5, Gdesc202);
                   cashbankrep.SetParameterValue(6, Gdesc203);
               
               }
               else
               {
                   String slm = "Slide Agglutination Method";
                 
                   Repslidenew11 cashbankrep = new Repslidenew11();
                   //cashbankrep.SetDatabaseLogon("sa", "software", @".\sqlexpress", "pathology2627");
                   cashbankrep.SetDataSource(dt);
                   crv.ReportSource = cashbankrep;
                   //cashbankrep.SetParameterValue(0, ds2.Tables[0].Rows[0][5].ToString());
                   //cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows[0][6].ToString());
                   cashbankrep.SetParameterValue(0, reportname);
                   cashbankrep.SetParameterValue(1, Gdesc10);
                   cashbankrep.SetParameterValue(2, Gresult11);
                   cashbankrep.SetParameterValue(3, Gresult12);
                   cashbankrep.SetParameterValue(4, Gresult13);
                   cashbankrep.SetParameterValue(5, Gdesc14);
                   cashbankrep.SetParameterValue(6, Gresult15);
                   cashbankrep.SetParameterValue(7, Gresult16);
                   cashbankrep.SetParameterValue(8, Gresult17);
                   cashbankrep.SetParameterValue(9, Gdesc18);
                   cashbankrep.SetParameterValue(10, Gresult19);
                   cashbankrep.SetParameterValue(11, Gresult20);
                   cashbankrep.SetParameterValue(12, Gresult21);
                   cashbankrep.SetParameterValue(13, Gdesc22);
                   cashbankrep.SetParameterValue(14, Gresult23);
                   cashbankrep.SetParameterValue(15, Gresult24);
                   cashbankrep.SetParameterValue(16, Gresult25);

                   cashbankrep.SetParameterValue(17, Gresult26);
                   cashbankrep.SetParameterValue(18, Gresult27);
                   cashbankrep.SetParameterValue(19, Gresult28);
                   cashbankrep.SetParameterValue(20, Gresult29);
                   cashbankrep.SetParameterValue(21, Gresult30);
                   cashbankrep.SetParameterValue(22, Gresult31);
                   cashbankrep.SetParameterValue(23, Gresult32);
                   cashbankrep.SetParameterValue(24, Gresult33);

                   cashbankrep.SetParameterValue(25, ds2.Tables[0].Rows[0][5].ToString());
                   cashbankrep.SetParameterValue(26, ds2.Tables[0].Rows[0][6].ToString());
                   cashbankrep.SetParameterValue(27, slm);
                   cashbankrep.SetParameterValue(28, ds2.Tables[0].Rows[0][9].ToString());
                   cashbankrep.SetParameterValue(29, ds2.Tables[0].Rows[0][10].ToString());
                   cashbankrep.SetParameterValue(30, ds2.Tables[0].Rows[0][11].ToString());
                   cashbankrep.SetParameterValue(31, typhoimpr);
               
               
               }
            
            
            
            }
            crv.Refresh();
        }

        private void btnseroback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbopcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            String s = "select patient_name from patient_master  where pcode='" + cbopcode.SelectedItem + "' ";

            da = new SqlDataAdapter(s, con);
            ds = new DataSet();
            da.Fill(ds);
            cboname.Text = ds.Tables[0].Rows[0][0].ToString();
            da.Dispose();
        }

        private void cboname_SelectedIndexChanged(object sender, EventArgs e)
        {
            String s = "select pcode from patient_master  where patient_name='" + cboname.SelectedItem + "' ";

            da = new SqlDataAdapter(s, con);
            ds = new DataSet();
            da.Fill(ds);
            cbopcode.Text = ds.Tables[0].Rows[0][0].ToString();
            da.Dispose();
        }
    }
}