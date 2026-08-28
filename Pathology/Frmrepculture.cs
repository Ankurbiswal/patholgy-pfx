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
    public partial class Frmrepculture : Form
    {
      SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        SqlDataReader dr1;
        DataRow dr;
        DataTable dt;
        DataSet ds, ds1, ds2, ds5;
        DataSet dsur, dsst, dsbd, dsbc;
        public string Ggrp, Gdesc, Gdesc1, Gresult, Gresult1, Gresult2, Gunit, Gnormalrange, Gnormalrange1;
        public int gcode, gage;
        public string gsex, gpatient_name, gdoctor, gmnyr, gscn, gtpt;
        public DateTime gdt_report;
        public string reportname;
        public String Gdescpss = "";
        public String Gresultpss = "";

        
        
        public Frmrepculture()
        {
            InitializeComponent();
        }

        private void btngo_Click(object sender, EventArgs e)
        {
            String strsql = "";
            int i = 0;
            strsql = "select a.cc,a.patient_name,a.pcode,a.sex,a.age,a.doctor,a.date_exam,a.month_year,a.scn,a.tpt,";
                //strsql = strsql + "b.cc,b.pcode,b.amoxicillin,b.ampicillin,b.amikacin,b.cephalexin,b.ceftazidime,b.ceftriaxone,b.cloxacillin,b.co_trimoxazole,b.cefazolin,b.cefotaxime,b.ciprofloxacin,b.doxycycline,";
                //strsql = strsql + "b.erythromycin,b.gentamycin,b.gemifloxacin,b.neomycin,b.nitrofurantion,b.norfloxacine,";
                //strsql = strsql + "b.netromycin,b.ofloxacin,b.piperacillin,b.pencillin,b.streptomycin,b.tetracycline,";
                //strsql = strsql + "b.roxythromycin,b.cefoperazone,b.levofloxacin,b.gatifloxacin,b.tazobactum,b.tobramycin,b.cefixime";
            strsql = strsql + "b.cc,b.pcode,b.amoxicillin,b.amoxicillin_no,b.amoxicillin_srm,b.ampicillin,b.ampicillin_no,b.ampicillin_srm,b.amikacin,b.amikacin_no,b.amikacin_srm,b.cephalexin,b.cephalexin_no,b.cephalexin_srm,b.ceftazidime,b.ceftazidime_no,b.ceftazidime_srm,b.ceftriaxone,b.ceftriaxone_no,b.ceftriaxone_srm,b.cloxacillin,b.cloxacillin_no,b.cloxacillin_srm,b.co_trimoxazole,b.co_trimoxazole_no,b.co_trimoxazole_srm,b.cefazolin,b.cefazolin_no,b.cefazolin_srm,b.cefotaxime,b.cefotaxime_no,b.cefotaxime_srm,b.ciprofloxacin,b.ciprofloxacin_no,b.ciprofloxacin_srm,b.doxycycline,b.doxycycline_no,b.doxycycline_srm,";
            strsql = strsql + "b.erythromycin,b.erythromycin_no,b.erythromycin_srm,b.gentamycin,b.gentamycin_no,b.gentamycin_srm,b.gemifloxacin,b.gemifloxacin_no,b.gemifloxacin_srm,neomycin,b.neomycin_no,b.neomycin_srm,b.nitrofurantion,b.nitrofurantion_no,b.nitrofurantion_srm,b.norfloxacine,b.norfloxacine_no,b.norfloxacine_srm,";
            strsql = strsql + "b.netromycin,b.netromycin_no,b.netromycin_srm,ofloxacin,b.ofloxacin_no,b.ofloxacin_srm,b.piperacillin,b.piperacillin_no,b.piperacillin_srm,b.pencillin,pencillin_no,b.pencillin_srm,b.streptomycin,b.streptomycin_no,b.streptomycin_srm,b.tetracycline,b.tetracycline_no,b.tetracycline_srm,";
            strsql = strsql + "b.roxythromycin,b.roxythromycin_no,b.roxythromycin_srm,b.cefoperazone,b.cefoperazone_no,b.cefoperazone_srm,b.levofloxacin,b.levofloxacin_no,b.levofloxacin_srm,b.gatifloxacin,b.gatifloxacin_no,b.gatifloxacin_srm,b.tazobactum,b.tazobactum_no,b.tazobactum_srm,b.tobramycin,b.tobramycin_no,b.tobramycin_srm,b.cefixime,b.cefixime_no,b.cefixime_srm,b.organism_isolated";   
            
            strsql = strsql + " from patient_master a,Culture b  where a.pcode='" + cbopcode.SelectedItem + "' and a.pcode=b.pcode";

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
                   if (checkBox1.Checked==false)
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




                    if (ds.Tables[0].Rows[i][12].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Amoxicillin Staphylococci/Others ";
                        Gdesc1 = "19/13          ";
                        Gresult = ds.Tables[0].Rows[i][12].ToString();
                        Gresult1 = ds.Tables[0].Rows[i][13].ToString();
                        Gresult2 = ds.Tables[0].Rows[i][14].ToString();
                        Gunit = "mm";
                        Gnormalrange = "o/14-17";
                        Gnormalrange1 = "20/18";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][15].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Ampicillin Staphylococci ";
                        Gdesc1 = "28/13 ";
                        Gresult = ds.Tables[0].Rows[i][15].ToString();
                        Gresult1 = ds.Tables[0].Rows[i][16].ToString();
                        Gresult2 = ds.Tables[0].Rows[i][17].ToString();
                        
                        Gunit = "mm";
                        Gnormalrange = "o/14-16";
                        Gnormalrange1 = "29/17 ";
                        ADDROW();
                    }



                    if (ds.Tables[0].Rows[i][18].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Amikacin";
                        Gdesc1 = "14";
                        Gresult = ds.Tables[0].Rows[i][18].ToString();
                        Gresult1 = ds.Tables[0].Rows[i][19].ToString();
                        Gresult2 = ds.Tables[0].Rows[i][20].ToString();
                        Gunit = "gm/dl";
                        Gnormalrange = "15-16";
                        Gnormalrange1 = "17";
                        ADDROW();
                    }

                    if (ds.Tables[0].Rows[i][21].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Cephalexin";
                        Gdesc1 = "14";
                        Gresult = ds.Tables[0].Rows[i][21].ToString();
                        Gresult1 = ds.Tables[0].Rows[i][22].ToString();
                        Gresult2 = ds.Tables[0].Rows[i][23].ToString();
                        Gunit = "Million /cmm.";
                        Gnormalrange = "15-17";
                        Gnormalrange1 = "18";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][24].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Ceftazidime";
                        Gdesc1 = "14";
                        Gresult = ds.Tables[0].Rows[i][24].ToString();
                        Gresult1 = ds.Tables[0].Rows[i][25].ToString();
                        Gresult2 = ds.Tables[0].Rows[i][26].ToString();
                        Gunit = "lakhs";
                        Gnormalrange = "15-17";
                        Gnormalrange1 = "18";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][27].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Ceftriaxone";
                        Gdesc1 = "13";
                        Gresult = ds.Tables[0].Rows[i][27].ToString();
                        Gresult1 = ds.Tables[0].Rows[i][28].ToString();
                        Gresult2 = ds.Tables[0].Rows[i][29].ToString();
                        Gunit = "/cmm.";
                        Gnormalrange = "14-20";
                        Gnormalrange1 = "21";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][30].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Cloxacillin";
                        Gdesc1 = "11";
                        Gresult = ds.Tables[0].Rows[i][30].ToString();
                        Gresult1 = ds.Tables[0].Rows[i][31].ToString();
                        Gresult2 = ds.Tables[0].Rows[i][32].ToString();
                        Gunit = "%";
                        Gnormalrange = "12-13";

                        Gnormalrange1 = "14";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][33].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Co-trimoxazole";
                        Gdesc1 = "10";
                        Gresult = ds.Tables[0].Rows[i][33].ToString();
                        Gresult1 = ds.Tables[0].Rows[i][34].ToString();
                        Gresult2 = ds.Tables[0].Rows[i][35].ToString();
                        Gunit = " fl";
                        Gnormalrange = "11-15";

                        Gnormalrange1 = "16";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][36].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Cefazolin";
                        Gdesc1 = "14";
                        Gresult = ds.Tables[0].Rows[i][36].ToString();
                        Gresult1 = ds.Tables[0].Rows[i][37].ToString();
                        Gresult2 = ds.Tables[0].Rows[i][38].ToString();
                        Gunit = "pgms";
                        Gnormalrange = "15-17";
                        Gnormalrange1 = "18";
                        ADDROW();
                    }

                    if (ds.Tables[0].Rows[i][39].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Cefotaxime";
                        Gdesc1 = "14";
                        Gresult = ds.Tables[0].Rows[i][39].ToString();
                        Gresult1 = ds.Tables[0].Rows[i][40].ToString();
                        Gresult2 = ds.Tables[0].Rows[i][41].ToString();
                        Gunit = "%";
                        Gnormalrange = "15-22";
                        Gnormalrange1 = "23";
                        ADDROW();
                    }




                    if (ds.Tables[0].Rows[i][42].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Ciprofloxacin";
                        Gdesc1 = "15";
                        Gresult = ds.Tables[0].Rows[i][42].ToString();
                        Gresult1 = ds.Tables[0].Rows[i][43].ToString();
                        Gresult2 = ds.Tables[0].Rows[i][44].ToString();
                        Gunit = "%";
                        Gnormalrange = "16-20";
                        Gnormalrange1 = "21";
                        ADDROW();
                    }

                    if (ds.Tables[0].Rows[i][45].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Doxycycline";
                        Gdesc1 = "12";
                        Gresult = ds.Tables[0].Rows[i][45].ToString();
                        Gresult1 = ds.Tables[0].Rows[i][46].ToString();
                        Gresult2 = ds.Tables[0].Rows[i][47].ToString();
                        Gunit = "%";
                        Gnormalrange = "13-15";
                        Gnormalrange1 = "16";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][48].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Erythromycin";
                        Gdesc1 = "13";
                        Gresult = ds.Tables[0].Rows[i][48].ToString();
                        Gresult1 = ds.Tables[0].Rows[i][49].ToString();
                        Gresult2 = ds.Tables[0].Rows[i][50].ToString();
                        Gunit = "%";
                        Gnormalrange = "14-22";
                        Gnormalrange1 = "23";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][51].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Gentamycin";
                        Gdesc1 = "12";
                        Gresult = ds.Tables[0].Rows[i][51].ToString();
                        Gresult1 = ds.Tables[0].Rows[i][52].ToString();
                        Gresult2 = ds.Tables[0].Rows[i][53].ToString();
                        Gunit = "%";
                        Gnormalrange = "13-14";
                        Gnormalrange1 = "15";
                        ADDROW();
                    }

                    if (ds.Tables[0].Rows[i][54].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Gemifloxacin";
                        Gdesc1 = "15";
                        Gresult = ds.Tables[0].Rows[i][54].ToString();
                        Gresult1 = ds.Tables[0].Rows[i][55].ToString();
                        Gresult2 = ds.Tables[0].Rows[i][56].ToString();
                        Gunit = "%";
                        Gnormalrange = "16-19";
                        Gnormalrange1 = "20";
                        ADDROW();
                    }
                    //Gdescpss = "( P.S. )";
                    //Gresultpss = ds.Tables[0].Rows[i][27].ToString();
                    if (ds.Tables[0].Rows[i][57].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Neomycin";
                        Gdesc1 = "12";
                        Gresult = ds.Tables[0].Rows[i][57].ToString();
                        Gresult1 = ds.Tables[0].Rows[i][58].ToString();
                        Gresult2 = ds.Tables[0].Rows[i][59].ToString();
                        Gunit = "";
                        Gnormalrange = "13-16";
                        Gnormalrange1 = "17";
                        ADDROW();
                    }





                    if (ds.Tables[0].Rows[i][60].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Nitrofurantion";
                        Gdesc1 = "14";
                        Gresult = ds.Tables[0].Rows[i][60].ToString();
                        Gresult1 = ds.Tables[0].Rows[i][61].ToString();
                        Gresult2= ds.Tables[0].Rows[i][62].ToString();
                        Gunit = "";
                        Gnormalrange = "15-16";
                        Gnormalrange1 = "17";
                        ADDROW();
                    }






                    if (ds.Tables[0].Rows[i][63].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Norfloxacine";
                        Gdesc1 = "12";
                        Gresult = ds.Tables[0].Rows[i][63].ToString();
                        Gresult1 = ds.Tables[0].Rows[i][64].ToString();
                        Gresult2 = ds.Tables[0].Rows[i][65].ToString();
                        Gunit = "";
                        Gnormalrange = "";
                        Gnormalrange1 = "17";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][66].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Netromycin";
                        Gdesc1 = "12";
                        Gresult = ds.Tables[0].Rows[i][66].ToString();
                        Gresult1 = ds.Tables[0].Rows[i][67].ToString();
                        Gresult2 = ds.Tables[0].Rows[i][68].ToString();
                        Gunit = "Min.";
                        Gnormalrange = "";
                        Gnormalrange1 = "15";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][69].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Ofloxacin";
                        Gdesc1 = "13";
                        Gresult = ds.Tables[0].Rows[i][69].ToString();
                        Gresult1 = ds.Tables[0].Rows[i][70].ToString();
                        Gresult2 = ds.Tables[0].Rows[i][71].ToString();
                        Gunit = "Min.";
                        Gnormalrange = "14-15";
                        Gnormalrange1 = "16";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][72].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Piperacillin";
                        Gdesc1 = "14";
                        Gresult = ds.Tables[0].Rows[i][72].ToString();
                        Gresult1 = ds.Tables[0].Rows[i][73].ToString();
                        Gresult2 = ds.Tables[0].Rows[i][74].ToString();
                        Gunit = "";
                        Gnormalrange = "15-17";
                        Gnormalrange1 = "18";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][75].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Pencillin";
                        Gdesc1 = "28/14";
                        Gresult = ds.Tables[0].Rows[i][75].ToString();
                        Gresult1 = ds.Tables[0].Rows[i][76].ToString();
                        Gresult2 = ds.Tables[0].Rows[i][77].ToString();
                        Gunit = "";
                        Gnormalrange = " ";
                        Gnormalrange1 = "28/15";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][78].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Streptomycin";
                        Gdesc1 = "11";
                        Gresult = ds.Tables[0].Rows[i][78].ToString();
                        Gresult1 = ds.Tables[0].Rows[i][79].ToString();
                        Gresult2 = ds.Tables[0].Rows[i][80].ToString();
                        Gunit = "";
                        Gnormalrange = "12-14";
                        Gnormalrange1 = "15";
                        ADDROW();
                    }

                    if (ds.Tables[0].Rows[i][81].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Tetracycline";
                        Gdesc1 = "14";
                        Gresult = ds.Tables[0].Rows[i][81].ToString();
                        Gresult1 = ds.Tables[0].Rows[i][82].ToString();
                        Gresult2 = ds.Tables[0].Rows[i][83].ToString();
                        Gunit = "";
                        Gnormalrange = "15-18";
                        Gnormalrange1 = "19";
                        ADDROW();
                    }
                       
                    if (ds.Tables[0].Rows[i][84].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Roxythromycin";
                        Gdesc1 = "13";
                        Gresult = ds.Tables[0].Rows[i][84].ToString();
                        Gresult1 = ds.Tables[0].Rows[i][85].ToString();
                        Gresult2 = ds.Tables[0].Rows[i][86].ToString();
                        Gunit = "";
                        Gnormalrange = "14-22";
                        Gnormalrange1 = "23";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][87].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Cefoperazone";
                        Gdesc1 = "15";
                        Gresult = ds.Tables[0].Rows[i][87].ToString();
                        Gresult1 = ds.Tables[0].Rows[i][88].ToString();
                        Gresult2 = ds.Tables[0].Rows[i][89].ToString();
                        Gunit = "";
                        Gnormalrange = "16-20";
                        Gnormalrange1 = "21";
                        ADDROW();
                    }

                    if (ds.Tables[0].Rows[i][90].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Levofloxacin";
                        Gdesc1 = "13";
                        Gresult = ds.Tables[0].Rows[i][90].ToString();
                        Gresult1 = ds.Tables[0].Rows[i][91].ToString();
                        Gresult2 = ds.Tables[0].Rows[i][92].ToString();
                        Gunit = "";
                        Gnormalrange = "14-16";
                        Gnormalrange1 = "17";
                        ADDROW();
                    }

                    if (ds.Tables[0].Rows[i][93].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Gatifloxacin";
                        Gdesc1 = "14";
                        Gresult = ds.Tables[0].Rows[i][93].ToString();
                        Gresult1 = ds.Tables[0].Rows[i][94].ToString();
                        Gresult2 = ds.Tables[0].Rows[i][95].ToString();
                        Gunit = "";
                        Gnormalrange = "15-17";
                        Gnormalrange1 = "18";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][96].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Tazobactum";
                        Gdesc1 = "17";
                        Gresult = ds.Tables[0].Rows[i][96].ToString();
                        Gresult1 = ds.Tables[0].Rows[i][97].ToString();
                        Gresult2 = ds.Tables[0].Rows[i][98].ToString();
                        Gunit = "";
                        Gnormalrange = "18-20";
                        Gnormalrange1 = "21";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][99].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Tobramycin";
                        Gdesc1 = "12";
                        Gresult = ds.Tables[0].Rows[i][99].ToString();
                        Gresult1 = ds.Tables[0].Rows[i][100].ToString();
                        Gresult2 = ds.Tables[0].Rows[i][101].ToString();
                        Gunit = "";
                        Gnormalrange = "13-14";
                        Gnormalrange1 = "15";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][102].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Cefixime";
                        Gdesc1 = "15";
                        Gresult = ds.Tables[0].Rows[i][102].ToString();
                        Gresult1 = ds.Tables[0].Rows[i][103].ToString();
                        Gresult2 = ds.Tables[0].Rows[i][104].ToString();
                        Gunit = "";
                        Gnormalrange = "16-18";
                        Gnormalrange1 = "19";
                        ADDROW();
                    }
                    Gdescpss = ds.Tables[0].Rows[i][105].ToString();
                    
                    //if (Convert.ToInt32(ds.Tables[0].Rows[i][46].ToString()) != 0)
                    //{
                    //    Ggrp = "";
                    //    Gdesc = "Widal Test";
                    //    Gdesc1 = "15        16-19       20";
                    //    Gresult = ds.Tables[0].Rows[i][46].ToString();
                    //    Gunit = "";
                    //    Gnormalrange = " ";
                    //    ADDROW();
                    //}
                    //if (ds.Tables[0].Rows[i][47].ToString() != "")
                    //{
                    //    Ggrp = "";
                    //    Gdesc = "Widal Test";
                    //    Gdesc1 = "15        16-19       20";
                    //    Gresult = ds.Tables[0].Rows[i][47].ToString();
                    //    Gunit = "";
                    //    Gnormalrange = " ";
                    //    ADDROW();
                    //}

                    //if (ds.Tables[0].Rows[i][48].ToString() != "")
                    //{
                    //    Ggrp = "..Widal Test..";
                    //    Gdesc = "Widal Test";
                    //    Gresult = ds.Tables[0].Rows[i][48].ToString();
                    //    Gunit = "";
                    //    Gnormalrange = " ";
                    //    ADDROW();
                    //}
                    //if (ds.Tables[0].Rows[i][49].ToString() != "")
                    //{
                    //    Ggrp = "..Widal Test..";
                    //    Gdesc = "Widal Test";
                    //    Gresult = ds.Tables[0].Rows[i][49].ToString();
                    //    Gunit = "";
                    //    Gnormalrange = " ";
                    //    ADDROW();
                    //}



                    //if (ds.Tables[0].Rows[i][50].ToString() != "")
                    //{
                    //    Ggrp = ".Montoux Test.";
                    //    Gdesc = "MontouxTest_injon";
                    //    Gresult = ds.Tables[0].Rows[i][50].ToString();
                    //    Gunit = "";
                    //    Gnormalrange = " ";
                    //    ADDROW();
                    //}

                    //if (ds.Tables[0].Rows[i][51].ToString() != "")
                    //{
                    //    Ggrp = ".Montoux Test.";
                    //    Gdesc = "MontouxTest_readon";
                    //    Gresult = ds.Tables[0].Rows[i][51].ToString();
                    //    Gunit = "";
                    //    Gnormalrange = " ";
                    //    ADDROW();
                    //}
                    //if (ds.Tables[0].Rows[i][52].ToString() != "")
                    //{
                    //    Ggrp = ".Montoux Test.";
                    //    Gdesc = "MontouxTest_induration";
                    //    Gresult = ds.Tables[0].Rows[i][52].ToString();
                    //    Gunit = "";
                    //    Gnormalrange = " ";
                    //    ADDROW();
                    //}

                      
                   }
                //else
                //   {
                   
                   
                //   }
                   if (checkBox1.Checked == true)
                   {

                       //gcode = Convert.ToInt32(ds.Tables[0].Rows[i][2].ToString());
                       //gage = Convert.ToInt32(ds.Tables[0].Rows[i][4].ToString());
                       //gsex = ds.Tables[0].Rows[i][3].ToString();
                       //gpatient_name = ds.Tables[0].Rows[i][1].ToString();
                       //gdt_report = Convert.ToDateTime(ds.Tables[0].Rows[i][6].ToString());
                       //gdoctor = ds.Tables[0].Rows[i][5].ToString();
                       //gmnyr = ds.Tables[0].Rows[i][7].ToString();
                       //gscn = ds.Tables[0].Rows[i][8].ToString();
                       //gtpt = ds.Tables[0].Rows[i][9].ToString();
                       gcode = 0;
                       gage = 0;
                       gsex = "";
                       gpatient_name = "";
                       gdt_report =Convert.ToDateTime("01/01/0001");
                       gdoctor ="";
                       gmnyr = "";
                       gscn = "";
                       gtpt = "";




                       //if (ds.Tables[0].Rows[i][12].ToString() != "")
                       //{
                           Ggrp = "";
                           Gdesc = "Amoxicillin Staphylococci/Others ";
                           Gdesc1 = "19/13          ";
                           //Gresult = ds.Tables[0].Rows[i][12].ToString();
                           //Gresult1 = ds.Tables[0].Rows[i][13].ToString();
                           //Gresult2 = ds.Tables[0].Rows[i][14].ToString();
                           Gunit = "mm";
                           Gnormalrange = "o/14-17";
                           Gnormalrange1 = "20/18";
                           ADDROW();
                      // }
                      // if (ds.Tables[0].Rows[i][15].ToString() != "")
                      // {
                           Ggrp = "";
                           Gdesc = "Ampicillin Staphylococci ";
                           Gdesc1 = "28/13 ";
                           //Gresult = ds.Tables[0].Rows[i][15].ToString();
                           //Gresult1 = ds.Tables[0].Rows[i][16].ToString();
                           //Gresult2 = ds.Tables[0].Rows[i][17].ToString();

                           Gunit = "mm";
                           Gnormalrange = "o/14-16";
                           Gnormalrange1 = "29/17 ";
                           ADDROW();
                      // }



                      // if (ds.Tables[0].Rows[i][18].ToString() != "")
                       //{
                           Ggrp = "";
                           Gdesc = "Amikacin";
                           Gdesc1 = "14";
                           //Gresult = ds.Tables[0].Rows[i][18].ToString();
                           //Gresult1 = ds.Tables[0].Rows[i][19].ToString();
                           //Gresult2 = ds.Tables[0].Rows[i][20].ToString();
                           Gunit = "gm/dl";
                           Gnormalrange = "15-16";
                           Gnormalrange1 = "17";
                           ADDROW();
                       //}

                       //if (ds.Tables[0].Rows[i][21].ToString() != "")
                      // {
                           Ggrp = "";
                           Gdesc = "Cephalexin";
                           Gdesc1 = "14";
                           //Gresult = ds.Tables[0].Rows[i][21].ToString();
                           //Gresult1 = ds.Tables[0].Rows[i][22].ToString();
                           //Gresult2 = ds.Tables[0].Rows[i][23].ToString();
                           Gunit = "Million /cmm.";
                           Gnormalrange = "15-17";
                           Gnormalrange1 = "18";
                           ADDROW();
                       //}
                       //if (ds.Tables[0].Rows[i][24].ToString() != "")
                       //{
                           Ggrp = "";
                           Gdesc = "Ceftazidime";
                           Gdesc1 = "14";
                           //Gresult = ds.Tables[0].Rows[i][24].ToString();
                           //Gresult1 = ds.Tables[0].Rows[i][25].ToString();
                           //Gresult2 = ds.Tables[0].Rows[i][26].ToString();
                           Gunit = "lakhs";
                           Gnormalrange = "15-17";
                           Gnormalrange1 = "18";
                           ADDROW();
                       //}
                      // if (ds.Tables[0].Rows[i][27].ToString() != "")
                      // {
                           Ggrp = "";
                           Gdesc = "Ceftriaxone";
                           Gdesc1 = "13";
                           //Gresult = ds.Tables[0].Rows[i][27].ToString();
                           //Gresult1 = ds.Tables[0].Rows[i][28].ToString();
                           //Gresult2 = ds.Tables[0].Rows[i][29].ToString();
                           Gunit = "/cmm.";
                           Gnormalrange = "14-20";
                           Gnormalrange1 = "21";
                           ADDROW();
                      // }
                      // if (ds.Tables[0].Rows[i][30].ToString() != "")
                      // {
                           Ggrp = "";
                           Gdesc = "Cloxacillin";
                           Gdesc1 = "11";
                           //Gresult = ds.Tables[0].Rows[i][30].ToString();
                           //Gresult1 = ds.Tables[0].Rows[i][31].ToString();
                           //Gresult2 = ds.Tables[0].Rows[i][32].ToString();
                           Gunit = "%";
                           Gnormalrange = "12-13";

                           Gnormalrange1 = "14";
                           ADDROW();
                       //}
                       //if (ds.Tables[0].Rows[i][33].ToString() != "")
                       //{
                           Ggrp = "";
                           Gdesc = "Co-trimoxazole";
                           Gdesc1 = "10";
                           //Gresult = ds.Tables[0].Rows[i][33].ToString();
                           //Gresult1 = ds.Tables[0].Rows[i][34].ToString();
                           //Gresult2 = ds.Tables[0].Rows[i][35].ToString();
                           Gunit = " fl";
                           Gnormalrange = "11-15";

                           Gnormalrange1 = "16";
                           ADDROW();
                       //}
                       //if (ds.Tables[0].Rows[i][36].ToString() != "")
                       //{
                           Ggrp = "";
                           Gdesc = "Cefazolin";
                           Gdesc1 = "14";
                           //Gresult = ds.Tables[0].Rows[i][36].ToString();
                           //Gresult1 = ds.Tables[0].Rows[i][37].ToString();
                           //Gresult2 = ds.Tables[0].Rows[i][38].ToString();
                           Gunit = "pgms";
                           Gnormalrange = "15-17";
                           Gnormalrange1 = "18";
                           ADDROW();
                       //}

                       //if (ds.Tables[0].Rows[i][39].ToString() != "")
                       //{
                           Ggrp = "";
                           Gdesc = "Cefotaxime";
                           Gdesc1 = "14";
                           //Gresult = ds.Tables[0].Rows[i][39].ToString();
                           //Gresult1 = ds.Tables[0].Rows[i][40].ToString();
                           //Gresult2 = ds.Tables[0].Rows[i][41].ToString();
                           Gunit = "%";
                           Gnormalrange = "15-22";
                           Gnormalrange1 = "23";
                           ADDROW();
                       //}
                       //if (ds.Tables[0].Rows[i][42].ToString() != "")
                       //{
                           Ggrp = "";
                           Gdesc = "Ciprofloxacin";
                           Gdesc1 = "15";
                           //Gresult = ds.Tables[0].Rows[i][42].ToString();
                           //Gresult1 = ds.Tables[0].Rows[i][43].ToString();
                           //Gresult2 = ds.Tables[0].Rows[i][44].ToString();
                           Gunit = "%";
                           Gnormalrange = "16-20";
                           Gnormalrange1 = "21";
                           ADDROW();
                       //}

                       //if (ds.Tables[0].Rows[i][45].ToString() != "")
                       //{
                           Ggrp = "";
                           Gdesc = "Doxycycline";
                           Gdesc1 = "12";
                           //Gresult = ds.Tables[0].Rows[i][45].ToString();
                           //Gresult1 = ds.Tables[0].Rows[i][46].ToString();
                           //Gresult2 = ds.Tables[0].Rows[i][47].ToString();
                           Gunit = "%";
                           Gnormalrange = "13-15";
                           Gnormalrange1 = "16";
                           ADDROW();
                       //}
                       //if (ds.Tables[0].Rows[i][48].ToString() != "")
                       //{
                           Ggrp = "";
                           Gdesc = "Erythromycin";
                           Gdesc1 = "13";
                           //Gresult = ds.Tables[0].Rows[i][48].ToString();
                           //Gresult1 = ds.Tables[0].Rows[i][49].ToString();
                           //Gresult2 = ds.Tables[0].Rows[i][50].ToString();
                           Gunit = "%";
                           Gnormalrange = "14-22";
                           Gnormalrange1 = "23";
                           ADDROW();
                       //}
                       //if (ds.Tables[0].Rows[i][51].ToString() != "")
                       //{
                           Ggrp = "";
                           Gdesc = "Gentamycin";
                           Gdesc1 = "12";
                           //Gresult = ds.Tables[0].Rows[i][51].ToString();
                           //Gresult1 = ds.Tables[0].Rows[i][52].ToString();
                           //Gresult2 = ds.Tables[0].Rows[i][53].ToString();
                           Gunit = "%";
                           Gnormalrange = "13-14";
                           Gnormalrange1 = "15";
                           ADDROW();
                       //}

                       //if (ds.Tables[0].Rows[i][54].ToString() != "")
                       //{
                           Ggrp = "";
                           Gdesc = "Gemifloxacin";
                           Gdesc1 = "15";
                           //Gresult = ds.Tables[0].Rows[i][54].ToString();
                           //Gresult1 = ds.Tables[0].Rows[i][55].ToString();
                           //Gresult2 = ds.Tables[0].Rows[i][56].ToString();
                           Gunit = "%";
                           Gnormalrange = "16-19";
                           Gnormalrange1 = "20";
                           ADDROW();
                      // }
                       //Gdescpss = "( P.S. )";
                       //Gresultpss = ds.Tables[0].Rows[i][27].ToString();
                      // if (ds.Tables[0].Rows[i][57].ToString() != "")
                      // {
                           Ggrp = "";
                           Gdesc = "Neomycin";
                           Gdesc1 = "12";
                           //Gresult = ds.Tables[0].Rows[i][57].ToString();
                           //Gresult1 = ds.Tables[0].Rows[i][58].ToString();
                           //Gresult2 = ds.Tables[0].Rows[i][59].ToString();
                           Gunit = "";
                           Gnormalrange = "13-16";
                           Gnormalrange1 = "17";
                           ADDROW();
                      // }





                       //if (ds.Tables[0].Rows[i][60].ToString() != "")
                       //{
                           Ggrp = "";
                           Gdesc = "Nitrofurantion";
                           Gdesc1 = "14";
                           //Gresult = ds.Tables[0].Rows[i][60].ToString();
                           //Gresult1 = ds.Tables[0].Rows[i][61].ToString();
                           //Gresult2 = ds.Tables[0].Rows[i][62].ToString();
                           Gunit = "";
                           Gnormalrange = "15-16";
                           Gnormalrange1 = "17";
                           ADDROW();
                       //}






                       //if (ds.Tables[0].Rows[i][63].ToString() != "")
                       //{
                           Ggrp = "";
                           Gdesc = "Norfloxacine";
                           Gdesc1 = "12";
                           //Gresult = ds.Tables[0].Rows[i][63].ToString();
                           //Gresult1 = ds.Tables[0].Rows[i][64].ToString();
                           //Gresult2 = ds.Tables[0].Rows[i][65].ToString();
                           Gunit = "";
                           Gnormalrange = "";
                           Gnormalrange1 = "17";
                           ADDROW();
                       //}
                       //if (ds.Tables[0].Rows[i][66].ToString() != "")
                       //{
                           Ggrp = "";
                           Gdesc = "Netromycin";
                           Gdesc1 = "12";
                           //Gresult = ds.Tables[0].Rows[i][66].ToString();
                           //Gresult1 = ds.Tables[0].Rows[i][67].ToString();
                           //Gresult2 = ds.Tables[0].Rows[i][68].ToString();
                           Gunit = "Min.";
                           Gnormalrange = "";
                           Gnormalrange1 = "15";
                           ADDROW();
                       //}
                       //if (ds.Tables[0].Rows[i][69].ToString() != "")
                       //{
                           Ggrp = "";
                           Gdesc = "Ofloxacin";
                           Gdesc1 = "13";
                           //Gresult = ds.Tables[0].Rows[i][69].ToString();
                           //Gresult1 = ds.Tables[0].Rows[i][70].ToString();
                           //Gresult2 = ds.Tables[0].Rows[i][71].ToString();
                           Gunit = "Min.";
                           Gnormalrange = "14-15";
                           Gnormalrange1 = "16";
                           ADDROW();
                       //}
                       //if (ds.Tables[0].Rows[i][72].ToString() != "")
                       //{
                           Ggrp = "";
                           Gdesc = "Piperacillin";
                           Gdesc1 = "14";
                           //Gresult = ds.Tables[0].Rows[i][72].ToString();
                           //Gresult1 = ds.Tables[0].Rows[i][73].ToString();
                           //Gresult2 = ds.Tables[0].Rows[i][74].ToString();
                           Gunit = "";
                           Gnormalrange = "15-17";
                           Gnormalrange1 = "18";
                           ADDROW();
                       //}
                       //if (ds.Tables[0].Rows[i][75].ToString() != "")
                       //{
                           Ggrp = "";
                           Gdesc = "Pencillin";
                           Gdesc1 = "28/14";
                           //Gresult = ds.Tables[0].Rows[i][75].ToString();
                           //Gresult1 = ds.Tables[0].Rows[i][76].ToString();
                           //Gresult2 = ds.Tables[0].Rows[i][77].ToString();
                           Gunit = "";
                           Gnormalrange = " ";
                           Gnormalrange1 = "28/15";
                           ADDROW();
                       //}
                       //if (ds.Tables[0].Rows[i][78].ToString() != "")
                       //{
                           Ggrp = "";
                           Gdesc = "Streptomycin";
                           Gdesc1 = "11";
                           //Gresult = ds.Tables[0].Rows[i][78].ToString();
                           //Gresult1 = ds.Tables[0].Rows[i][79].ToString();
                           //Gresult2 = ds.Tables[0].Rows[i][80].ToString();
                           Gunit = "";
                           Gnormalrange = "12-14";
                           Gnormalrange1 = "15";
                           ADDROW();
                       //}

                       //if (ds.Tables[0].Rows[i][81].ToString() != "")
                       //{
                           Ggrp = "";
                           Gdesc = "Tetracycline";
                           Gdesc1 = "14";
                           //Gresult = ds.Tables[0].Rows[i][81].ToString();
                           //Gresult1 = ds.Tables[0].Rows[i][82].ToString();
                           //Gresult2 = ds.Tables[0].Rows[i][83].ToString();
                           Gunit = "";
                           Gnormalrange = "15-18";
                           Gnormalrange1 = "19";
                           ADDROW();
                       //}

                       //if (ds.Tables[0].Rows[i][84].ToString() != "")
                       //{
                           Ggrp = "";
                           Gdesc = "Roxythromycin";
                           Gdesc1 = "13";
                           //Gresult = ds.Tables[0].Rows[i][84].ToString();
                           //Gresult1 = ds.Tables[0].Rows[i][85].ToString();
                           //Gresult2 = ds.Tables[0].Rows[i][86].ToString();
                           Gunit = "";
                           Gnormalrange = "14-22";
                           Gnormalrange1 = "23";
                           ADDROW();
                       //}
                       //if (ds.Tables[0].Rows[i][87].ToString() != "")
                       //{
                           Ggrp = "";
                           Gdesc = "Cefoperazone";
                           Gdesc1 = "15";
                           //Gresult = ds.Tables[0].Rows[i][87].ToString();
                           //Gresult1 = ds.Tables[0].Rows[i][88].ToString();
                           //Gresult2 = ds.Tables[0].Rows[i][89].ToString();
                           Gunit = "";
                           Gnormalrange = "16-20";
                           Gnormalrange1 = "21";
                           ADDROW();
                       //}

                       //if (ds.Tables[0].Rows[i][90].ToString() != "")
                       //{
                           Ggrp = "";
                           Gdesc = "Levofloxacin";
                           Gdesc1 = "13";
                           //Gresult = ds.Tables[0].Rows[i][90].ToString();
                           //Gresult1 = ds.Tables[0].Rows[i][91].ToString();
                           //Gresult2 = ds.Tables[0].Rows[i][92].ToString();
                           Gunit = "";
                           Gnormalrange = "14-16";
                           Gnormalrange1 = "17";
                           ADDROW();
                       //}

                       //if (ds.Tables[0].Rows[i][93].ToString() != "")
                       //{
                           Ggrp = "";
                           Gdesc = "Gatifloxacin";
                           Gdesc1 = "14";
                           //Gresult = ds.Tables[0].Rows[i][93].ToString();
                           //Gresult1 = ds.Tables[0].Rows[i][94].ToString();
                           //Gresult2 = ds.Tables[0].Rows[i][95].ToString();
                           //Gunit = "";
                           Gnormalrange = "15-17";
                           Gnormalrange1 = "18";
                           ADDROW();
                       //}
                       //if (ds.Tables[0].Rows[i][96].ToString() != "")
                       //{
                           Ggrp = "";
                           Gdesc = "Tazobactum";
                           Gdesc1 = "17";
                           //Gresult = ds.Tables[0].Rows[i][96].ToString();
                           //Gresult1 = ds.Tables[0].Rows[i][97].ToString();
                           //Gresult2 = ds.Tables[0].Rows[i][98].ToString();
                           Gunit = "";
                           Gnormalrange = "18-20";
                           Gnormalrange1 = "21";
                           ADDROW();
                       //}
                       //if (ds.Tables[0].Rows[i][99].ToString() != "")
                       //{
                           Ggrp = "";
                           Gdesc = "Tobramycin";
                           Gdesc1 = "12";
                           //Gresult = ds.Tables[0].Rows[i][99].ToString();
                           //Gresult1 = ds.Tables[0].Rows[i][100].ToString();
                           //Gresult2 = ds.Tables[0].Rows[i][101].ToString();
                           Gunit = "";
                           Gnormalrange = "13-14";
                           Gnormalrange1 = "15";
                           ADDROW();
                       //}
                       //if (ds.Tables[0].Rows[i][102].ToString() != "")
                       //{
                           Ggrp = "";
                           Gdesc = "Cefixime";
                           Gdesc1 = "15";
                           //Gresult = ds.Tables[0].Rows[i][102].ToString();
                           //Gresult1 = ds.Tables[0].Rows[i][103].ToString();
                           //Gresult2 = ds.Tables[0].Rows[i][104].ToString();
                           Gunit = "";
                           Gnormalrange = "16-18";
                           Gnormalrange1 = "19";
                           ADDROW();
                      // }
                       Gdescpss = "";

                      

                   }
          
          
          }



         
                // Repblood cashbankrep = new Repblood();
                Repculture cashbankrep = new Repculture();
                cashbankrep.SetDatabaseLogon("sa", "software", @".\sqlexpress", "pathology2627");
                cashbankrep.SetDataSource(dt);
                crv.ReportSource = cashbankrep;
               
                //cashbankrep.SetParameterValue(2, reportname);
                cashbankrep.SetParameterValue(0, Gdescpss);
                cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows.Count > 0 ? ds2.Tables[0].Rows[0][5].ToString() : "");
                cashbankrep.SetParameterValue(2, ds2.Tables[0].Rows.Count > 0 ? ds2.Tables[0].Rows[0][6].ToString() : "");

                //cashbankrep.SetParameterValue(4, Gresultpss);
         
            crv.Refresh();
           // crv.PrintReport();
       
        //end blood report
            //start biochem report

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frmrepculture_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=pathology2627;Persist Security Info=True;User ID=sa;Password=software;");
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

            da = new SqlDataAdapter("select cc,comp,address,year_start,year_end,pathologist,biochemist from company", con);
            ds2 = new DataSet();
            da.Fill(ds2);
        
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
            dt.Rows.Add(dr);
            dt.AcceptChanges();
         }

        }
    }
