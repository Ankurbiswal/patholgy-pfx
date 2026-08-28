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
    public partial class Frmrepcodewise : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        SqlDataReader dr1;
        DataRow dr;
        DataTable dt;
        DataSet ds, ds1, ds2, ds5;
        DataSet dsur, dsst, dsbd, dsbc;
        public string Ggrp, Gdesc, Gdesc1, Gresult, Gunit, Gnormalrange, Gnormalrange1;
        public int gcode, gage;
        public string gsex, gpatient_name, gdoctor, gmnyr, gscn, gtpt;
        public DateTime gdt_report;
        public string reportname;
        public String Gdescpss = "";
        public String Gresultpss = "";


        //public string reportname;
        public string  Gdescpss1="";
        public string  Gresultpss1="";
        public string Gdesc10, Gdesc14, Gdesc18, Gdesc22 = "";
        public string Gresult11, Gresult12, Gresult13, Gresult15, Gresult16, Gresult17, Gresult19, Gresult20, Gresult21, Gresult23, Gresult24, Gresult25 = "";

        public string Gresult26, Gresult27, Gresult28, Gresult29, Gresult30, Gresult31, Gresult32, Gresult33 = "";
        
        
        
        
        
        
        public Frmrepcodewise()
        {
            InitializeComponent();
        }

        private void Frmrepcodewise_Load(object sender, EventArgs e)
        {
             //con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Pathology;Persist Security Info=True;User ID=sa;Password=software;");
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
  

        private void btngo_Click(object sender, EventArgs e)
        {
            //String s1 = ("select cc,type,blno,bldt,acdes,challan_no,challan_dt,gross,discount_rt,discount,vat_rt,vat,tamt from inv where bldt>= '" + Convert.ToDateTime(dtfrom.Text) + "' and bldt<= '" + Convert.ToDateTime(dtto.Text) + "' and cc='" + txtcompid.Text + "' and type='" + cbotype.Text + "' order by cc,type,bldt,blno");
            String s1 = "select a.cc,a.patient_name,a.pcode,a.sex,a.age,a.doctor,a.date_exam as Dt_Report,a.month_year,b.UP_color,b.UP_reaction,b.UP_specificgravity,b.UC_sugar,b.UC_albumin,b.UC_phosphate,b.UC_chyle,b.UC_ketonebodies,b.UC_bilesalts,b.UC_bilepigment,b.UM_puscells,b.UM_epithcells,b.UM_rbc,b.UM_casts,b.UM_crystals,b.UM_bacterial,b.UM_spermatozoa,b.UM_mf_tv,b.UM_others,b.UU_urine_b_hcg,b.UA_urine_albumin,b.UN_nasalsmear from patient_master a , urine b where a.pcode=b.pcode and  a.pcode='" + cbopcode.Text + "'   order by b.pcode,a.date_exam";
            da = new SqlDataAdapter(s1, con);
            ds = new DataSet();
            da.Fill(ds, "Pathology_Urine");
            if (ds.Tables[0].Rows.Count != 0)
            {
                if (ds.Tables[0].Rows[0][8].ToString().Trim() != "")
                {

                    Repurine cashbankrep = new Repurine();

                    cashbankrep.SetDatabaseLogon("sa", "software", @".\SQLEXPRESS", "pathology2627");
                    cashbankrep.SetDataSource(ds);
                    
                    crv.ReportSource = cashbankrep;
                   

                    crv.Refresh();
                    crv.PrintReport();
                    //crystalReportViewer1.PrintReport();

                    //crystalReportViewer1.Visible = false;
                }
            }
            else
            {
                
            }
           
            s1 = "";
             s1 = ("select b.Sp_color, b.Sp_reaction,b.Sp_Mucus,b.SH_OvaHW,b.SH_larva,b.SH_OvaRW,b.SP_EHistolytica,b.SP_ecoli,b.SP_giardia,b.SP_trichomonas, b.SM_rbc_from,  b.SM_puscells_from,b.SM_macrophase,b.SM_vegetables,b.SM_yeast,b.SM_crystal,b.SM_fataglobules,b.SM_bacterialflora,b.SH_Others,b.SC_Occultblood,b.SC_Reducingsugar,a.pcode,a.age,a.sex,a.patient_name,a.date_exam as Dt_Report,a.doctor,a.month_year,a.scn,a.tpt from patient_master a,stool b where a.pcode='" + cbopcode.Text + "' and a.pcode=b.pcode order by a.pcode,a.date_exam");

            da = new SqlDataAdapter(s1, con);
            ds = new DataSet();
            da.Fill(ds, "Pathology_Stool");






            if (ds.Tables[0].Rows.Count != 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString().Trim() != "")
                {
                    Repstooln cashbankrep = new Repstooln();
                    cashbankrep.SetDatabaseLogon("sa", "software", @".\SQLEXPRESS", "pathology2627");
                    cashbankrep.SetDataSource(ds);
                    crv.ReportSource = cashbankrep;
                   
                    crv.Refresh();
                    crv.PrintReport();
                }
            }
            else
            {
                //MessageBox.Show("No Records Found!!!");
            }

           


            String strsql = "";
            int i = 0;


            
                reportname = "COMPLETE BLOOD COUNT";
            
                
          
            {

                strsql = "select a.cc,a.patient_name,a.pcode,a.sex,a.age,a.doctor,a.date_exam,a.month_year,a.scn,a.tpt,";
                strsql = strsql + "b.cc,b.pcode,b.BDc_ESR_1sthour,b.BDc_ESR_2ndhour,b.BDc_Hb,b.BDc_Trbc,b.BDc_Tplatelets,b.BDc_Twbc,b.BDc_PCV,b.BDC_mcv,b.BDC_mch,b.BDC_mchc,b.BDc_Neutrophild,b.BDc_Lymphocytes,b.BDc_Eosinophils,b.BDc_Monocytes,b.BDc_Basophils,b.BDC_pss ";
                //strsql = strsql + "b.BDc_Aec,b.BDc_Tnc,b.BDc_Reticulocyte_Count,b.BDc_Mp_ICT_QBC_Smear,b.BDc_Mf_ICT_QBC_Smear,";
                //strsql = strsql + "b.BDc_Bleeding_Time,b.BDc_Clotting_Time,b.BDc_Sickle_cell,b.BPS_Toxo,b.BPS_Crp,b.BPS_Vdrl,";
                //strsql = strsql + "b.BPS_Rafactor,b.BPS_Aso,b.BS_Australia_Antigen,b.BS_Hepatitis_C_Virus,b.BS_HIV_1,b.BS_HIV_2,";
                //strsql = strsql + "b.BS_Ict_PF_PV,b.Bw_Widaltube,b.Bw_Widalslide,b.Bw_mycodot,b.bw_trop,b.Bm_MontouxTest_injon,b.Bm_MontouxTest_readon,b.Bm_MontouxTest_induration";
                strsql = strsql + " from patient_master a,Blood b where a.pcode='" + cbopcode.SelectedItem + "' and a.pcode=b.pcode";

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
                    gcode = Convert.ToInt32(ds.Tables[0].Rows[i][2].ToString());
                    gage = Convert.ToInt32(ds.Tables[0].Rows[i][4].ToString());
                    gsex = ds.Tables[0].Rows[i][3].ToString();
                    gpatient_name = ds.Tables[0].Rows[i][1].ToString();
                    gdt_report = Convert.ToDateTime(ds.Tables[0].Rows[i][6].ToString());
                    gdoctor = ds.Tables[0].Rows[i][5].ToString();
                    gmnyr = ds.Tables[0].Rows[i][7].ToString();
                    gscn = ds.Tables[0].Rows[i][8].ToString();
                    gtpt = ds.Tables[0].Rows[i][9].ToString();




                    if (Convert.ToInt32(ds.Tables[0].Rows[i][12].ToString()) != 0)
                    {
                        Ggrp = "";
                        Gdesc = "E.S.R. (1 hour) ";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][12].ToString();
                        Gunit = "mm";
                        Gnormalrange = "M: 3 - 5 ";
                        Gnormalrange1 = "F: 4 - 8 ";
                        ADDROW();
                    }
                    if (Convert.ToInt32(ds.Tables[0].Rows[i][13].ToString()) != 0)
                    {
                        Ggrp = "";
                        Gdesc = "E.S.R. (2 hour) ";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][13].ToString();
                        Gunit = "mm";
                        Gnormalrange = "M: 3 - 5 ";
                        Gnormalrange1 = "F: 4 - 8 ";
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][14].ToString()) != 0.00)
                    {
                        Ggrp = "";
                        Gdesc = "HAEMOGLOBIN";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][14].ToString();
                        Gunit = "gm/dl";
                        Gnormalrange = "M: 14 - 18 ";
                        Gnormalrange1 = "F: 12 - 15 ";
                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][15].ToString()) != 0.00)
                    {
                        Ggrp = "";
                        Gdesc = "TOTAL R.B.C. COUNT";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][15].ToString();
                        Gunit = "Million /cmm.";
                        Gnormalrange = "3.5 - 5.5 ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][16].ToString()) != 0.00)
                    {
                        Ggrp = "";
                        Gdesc = "PLATELET COUNT";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][16].ToString();
                        Gunit = "lakhs";
                        Gnormalrange = "1.5 - 4.0 ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (Convert.ToInt32(ds.Tables[0].Rows[i][17].ToString()) != 0)
                    {
                        Ggrp = "";
                        Gdesc = "TOTAL LEUCOCYTE COUNT";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][17].ToString();
                        Gunit = "/cmm.";
                        Gnormalrange = "4,000 - 11,000 ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (Convert.ToInt32(ds.Tables[0].Rows[i][18].ToString()) != 0)
                    {
                        Ggrp = "";
                        Gdesc = "PACKED CELL VOLUME( PCV )";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][18].ToString();
                        Gunit = "%";
                        Gnormalrange = "M: 40 - 54 ";

                        Gnormalrange1 = "F: 36-45";
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][19].ToString()) != 0)
                    {
                        Ggrp = "";
                        Gdesc = "M.C.V";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][19].ToString();
                        Gunit = " fl";
                        Gnormalrange = "82 - 92";

                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][20].ToString()) != 0)
                    {
                        Ggrp = "";
                        Gdesc = "M.C.H";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][20].ToString();
                        Gunit = "pgms";
                        Gnormalrange = "27 - 32 ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][21].ToString()) != 0)
                    {
                        Ggrp = "";
                        Gdesc = "M.C.H.C.";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][21].ToString();
                        Gunit = "%";
                        Gnormalrange = "32 - 36 ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }




                    if (Convert.ToInt32(ds.Tables[0].Rows[i][22].ToString()) != 0)
                    {
                        Ggrp = "DIFFERENTIAL  COUNT";
                        Gdesc = "NEUTROPHILS";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][22].ToString();
                        Gunit = "%";
                        Gnormalrange = "40 - 60 ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }

                    if (Convert.ToInt32(ds.Tables[0].Rows[i][23].ToString()) != 0)
                    {
                        Ggrp = "DIFFERENTIAL  COUNT";
                        Gdesc = "LYMPHOCYTES";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][23].ToString();
                        Gunit = "%";
                        Gnormalrange = "20 - 40 ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (Convert.ToInt32(ds.Tables[0].Rows[i][24].ToString()) != 0)
                    {
                        Ggrp = "DIFFERENTIAL  COUNT";
                        Gdesc = "EOSINOPHILS";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][24].ToString();
                        Gunit = "%";
                        Gnormalrange = "02 - 08";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (Convert.ToInt32(ds.Tables[0].Rows[i][25].ToString()) != 0)
                    {
                        Ggrp = "DIFFERENTIAL  COUNT";
                        Gdesc = "MONOCYTES";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][25].ToString();
                        Gunit = "%";
                        Gnormalrange = "1 - 4 ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    
                    if (Convert.ToInt32(ds.Tables[0].Rows[i][26].ToString()) != 0)
                    {
                        Ggrp = "DIFFERENTIAL  COUNT";
                        Gdesc = "BASOPHILS";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][26].ToString();
                        Gunit = "%";
                        Gnormalrange = "0 - 1 ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }

                   
                    Gdescpss = "( P.S. )";
                    Gresultpss = ds.Tables[0].Rows[i][27].ToString();
                    




                }

            }


            {
                // Repblood cashbankrep = new Repblood();
                Repbloodnew cashbankrep = new Repbloodnew();
                cashbankrep.SetDatabaseLogon("sa", "software", @".\sqlexpress", "pathology2627");
                cashbankrep.SetDataSource(dt);
                crv.ReportSource = cashbankrep;
                cashbankrep.SetParameterValue(0, ds2.Tables[0].Rows[0][5].ToString());
                cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows[0][6].ToString());
                cashbankrep.SetParameterValue(2, reportname);
                cashbankrep.SetParameterValue(3, Gdescpss);
                cashbankrep.SetParameterValue(4, Gresultpss);
            }
            crv.Refresh();
            crv.PrintReport();
       
        //end blood report
            //start biochem report

             strsql = "";
            //strsql = "select cc,patient_name,pcode,sex,age,doctor,date_exam,UP_color,UP_sediments,UP_reaction,UP_specificgravity,UC_sugar,UC_albumin,UC_phosphate,UC_chyle,UC_ketonebodies,UC_bilesalts,UC_bilepigment,UM_puscells,UM_epithcells,UM_rbc,UM_casts,UM_crystals,UM_bacterial,UM_spermatozoa,UM_mf_tv,UM_others,UU_urine_b_hcg,UA_urine_albumin,UN_nasalsmear,Us_SputumAfb, Sp_color, Sp_reaction, Sp_Mucus, SM_rbc_from, SM_rbc_to, SM_puscells_from,SM_puscells_to,SM_macrophase,SM_vegetables,SM_fataglobules,SM_yeast,SM_crystal,SM_bacterialflora,SP_EHistolytica,SP_ecoli,SP_giardia,SP_trichomonas,SH_OvaHW,SH_OvaRW,SH_Others,SC_Occultblood,SC_Reducingsugar,";
            strsql = "select a.cc,a.patient_name,a.pcode,a.sex,a.age,a.doctor,a.date_exam,a.month_year,a.Scn,a.Tpt,";
            strsql = strsql + "b.cc,b.pcode,b.Bcr1_Glucose_Fpg_RPG,b.Bcr1_PPPG_PGPG_2hr,b.Bcr1_PPPG_PGPG_1hr,b.Bcr1_RBS,b.Bcr1_PBBS,b.Bcr1_PLBS,b.Bcr1_GTT_1hr,b.Bcr1_GTT_2hr,b.Bcr1_GTT_3hr,b.Bcr1_PGBS_1hr,b.Bcr1_PGBS_2hr,b.Bcr1_HBAC_good,b.Bcr1_HBAC_fair,b.Bcr1_HBAC_poor, b.Bcr1_MBGE,b.Bcr_RP_Urea,b.Bcr_RP_Creatinine,b.Bcr3_Uric_Acid,b.Bcr_RP_BUN,b.Bcr3_NPN,b.Bcr_LP_Triglycerides,b.Bcr_LP_Cholesterol,b.Bcr_LP_HDLCholesterol,";
            strsql = strsql + "b.Bcr_LP_LDLCholesterol,b.Bcr_LP_VLDLCholesterol,b.Bcr2_LP_CHR,b.Bcr2_LP_LHR,b.Bcr_LFT_Bilirubin_total,b.Bcr_LFT_Bilirubin_Direct,b.Bcr4_LFT_Indirect,";
            strsql = strsql + "b.Bcr_LFT_SGOT_AST,b.Bcr_LFT_SGPT_ALT,b.Bcr_LFT_Alkaline_Phosphates,b.Bcr_LFT_Protein,b.Bcr_LFT_Albumin,b.Bcr_LFT_Globulin,b.Bcr_LFT_AG_Ratio,b.Bcr4_LFT_GGTP,b.Bcr_Electrolyte_Sodium,";
            strsql = strsql + "b.Bcr_Electrolyte_Potassium,b.Bcr5_Electrolyte_Chlorides,b.Bcr_OTH_Acid_Calcium,b.Bcr_OTH_Acid_Phosphorus,b.Bcr_OTH_Uric_Acid,b.Bcr_OTH_Pasting_urine_sugar,b.Bcr_OTH_Amylase,b.Bcr_OTH_Acid_Phosphate,b.Bcr_OTH_PP_PG_urine_sugar";

            strsql = strsql + " from patient_master a,biochemist b where a.pcode='" + cbopcode.SelectedItem + "' and a.pcode=b.pcode";

            da = new SqlDataAdapter(strsql, con);
            ds = new DataSet();
            da.Fill(ds, "Biochemist");
           i = 0;
            if (ds.Tables[0].Rows.Count != 0)
            {

                dt = new DataTable();
                //Ds_hope ds1 = new Ds_hope();
                //Pathology_Ds Ds1 = new Pathology_Ds();
                ds1 = new DataSet();
                dt = ds1.Tables.Add("Pathology_Dt");
                dt.Columns.Add("Grp", System.Type.GetType("System.String"));
                dt.Columns.Add("Desc", System.Type.GetType("System.String"));
                dt.Columns.Add("Desc1", System.Type.GetType("System.String"));
                dt.Columns.Add("Result", System.Type.GetType("System.String"));
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
                gcode = Convert.ToInt32(ds.Tables[0].Rows[i][2].ToString());
                gage = Convert.ToInt32(ds.Tables[0].Rows[i][4].ToString());
                gsex = ds.Tables[0].Rows[i][3].ToString();
                gpatient_name = ds.Tables[0].Rows[i][1].ToString();
                gdt_report = Convert.ToDateTime(ds.Tables[0].Rows[i][6].ToString());
                gdoctor = ds.Tables[0].Rows[i][5].ToString();
                gmnyr = ds.Tables[0].Rows[i][7].ToString();
                gscn = ds.Tables[0].Rows[i][8].ToString();
                gtpt = ds.Tables[0].Rows[i][9].ToString();

              

               
                {
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][12].ToString()) != 0)
                    {
                        Ggrp = "DIABETIC  PROFILE";
                        Gdesc = "FASTING BLOOD SUGAR ( FBS )";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][12].ToString();
                        Gunit = "mg/dl";

                        Gnormalrange = "70 - 110 ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][13].ToString()) != 0)
                    {
                        Ggrp = "DIABETIC  PROFILE";
                        Gdesc = "POST PRANDIAL BLOOD SUGAR ( PPBS )";
                        Gdesc1 = "(2 hour)";
                        Gresult = ds.Tables[0].Rows[i][13].ToString();
                        Gunit = "mg/dl";
                        Gnormalrange = "upto 150 ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][14].ToString()) != 0)
                    {
                        Ggrp = "DIABETIC  PROFILE";
                        Gdesc = "POST PRANDIAL BLOOD SUGAR ( PPBS )";
                        Gdesc1 = "(1 hour)";
                        Gresult = ds.Tables[0].Rows[i][14].ToString();
                        Gunit = "mg/dl";
                        Gnormalrange = "upto 150 ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }



                    if (Convert.ToDouble(ds.Tables[0].Rows[i][15].ToString()) != 0)
                    {
                        Ggrp = "DIABETIC  PROFILE";
                        Gdesc = "RANDOM BLOOD SUGAR ( RBS )";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][15].ToString();
                        Gunit = "mg/dl";
                        Gnormalrange = "upto 150 ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][16].ToString()) != 0)
                    {
                        Ggrp = "DIABETIC  PROFILE";
                        Gdesc = "POST BREAKFAST BLOOD SUGAR ( PBBS )";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][16].ToString();
                        Gunit = "mg/dl";
                        Gnormalrange = "upto 150";
                        Gnormalrange1 = "";
                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][17].ToString()) != 0)
                    {
                        Ggrp = "DIABETIC  PROFILE";
                        Gdesc = "POST LUNCH BLOOD SUGAR ( PLBS )";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][17].ToString();
                        Gunit = "mg/dl";
                        Gnormalrange = "upto 150";
                        Gnormalrange1 = "";
                        ADDROW();
                    }


                    if (Convert.ToDouble(ds.Tables[0].Rows[i][18].ToString()) != 0)
                    {
                        Ggrp = "DIABETIC  PROFILE";
                        Gdesc = "GLUCOSE TOLERANCE TEST ( GTT )";
                        Gdesc1 = "(1 hour)";
                        Gresult = ds.Tables[0].Rows[i][18].ToString();
                        Gunit = "mg/dl";
                        Gnormalrange = "upto 150";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][19].ToString()) != 0)
                    {
                        Ggrp = "DIABETIC  PROFILE";
                        Gdesc = "                                    ";
                        Gdesc1 = "(2 hour)";
                        Gresult = ds.Tables[0].Rows[i][19].ToString();
                        Gunit = "mg/dl";
                        Gnormalrange = "upto 150";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][20].ToString()) != 0)
                    {
                        Ggrp = "DIABETIC  PROFILE";
                        Gdesc = "                                    ";
                        Gdesc1 = "(3 hour)";
                        Gresult = ds.Tables[0].Rows[i][20].ToString();
                        Gunit = "mg/dl";
                        Gnormalrange = "upto 150";
                        Gnormalrange1 = "";
                        ADDROW();
                    }


                    if (Convert.ToDouble(ds.Tables[0].Rows[i][21].ToString()) != 0)
                    {
                        Ggrp = "DIABETIC  PROFILE";
                        Gdesc = "POST GLUCOSE BLOOD SUGAR ( PGBS )";
                        Gdesc1 = "(1 hour)";
                        Gresult = ds.Tables[0].Rows[i][21].ToString();
                        Gunit = "mg/dl";
                        Gnormalrange = "upto 150";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][22].ToString()) != 0)
                    {
                        Ggrp = "DIABETIC  PROFILE";
                        Gdesc = "POST GLUCOSE BLOOD SUGAR ( PGBS ) ";
                        Gdesc1 = "(2 hour)";
                        Gresult = ds.Tables[0].Rows[i][22].ToString();
                        Gunit = "mg/dl";
                        Gnormalrange = "upto 150";
                        Gnormalrange1 = "";
                        ADDROW();
                    }


                    if (Convert.ToDouble(ds.Tables[0].Rows[i][23].ToString()) != 0)
                    {
                        Ggrp = "DIABETIC  PROFILE";
                        Gdesc = "GLYCO CYLATED HAEMOGLOBIN ( HbA1C )";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][23].ToString();
                        Gunit = "%";
                        Gnormalrange = "Normal: 4.2 - 6.2";
                        Gnormalrange1 = "Good Control:   5.5 - 6.8             Fair Control:   6.8 - 7.6              Poor Control:   >7.6";  
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][24].ToString()) != 0)
                    {
                        Ggrp = "DIABETIC  PROFILE";
                        Gdesc = " ";
                        Gdesc1 = " ";
                        Gresult = ds.Tables[0].Rows[i][24].ToString();
                        Gunit = "%";
                        Gnormalrange = "Fair Control: 6.8 - 7.6 ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][25].ToString()) != 0)
                    {
                        Ggrp = "DIABETIC  PROFILE";
                        Gdesc = " ";
                        Gdesc1 = " ";
                        Gresult = ds.Tables[0].Rows[i][25].ToString();
                        Gunit = "%";
                        Gnormalrange = "Poor Control:   > 7.6 ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][26].ToString()) != 0)
                    {
                        Ggrp = "DIABETIC  PROFILE";
                        Gdesc = "MEAN BLOOD GLUCOSE ESTIMATION";
                        Gdesc1 = " ";
                        Gresult = ds.Tables[0].Rows[i][26].ToString();
                        Gunit = "%";
                        Gnormalrange = "6.5 - 13.0";
                        Gnormalrange1 = "";
                        ADDROW();
                    }



                    Double ren1 = Convert.ToDouble(ds.Tables[0].Rows[i][27].ToString());
                    Double ren2 = Convert.ToDouble(ds.Tables[0].Rows[i][28].ToString());
                    Double ren3 = Convert.ToDouble(ds.Tables[0].Rows[i][29].ToString());
                    String Grr;
                    if (ren1 != 0 & ren2 != 0 & ren3 != 0.00)
                    {
                        Grr = "RENAL  FUNCTION  TEST ( RFT )";
                    }
                    else
                    {
                        Grr = "";
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][27].ToString()) != 0)
                    {
                        Ggrp = Grr;
                        Gdesc = "UREA";
                        Gdesc1 = " ";
                        Gresult = ds.Tables[0].Rows[i][27].ToString();
                        Gunit = "mg/dl";
                        Gnormalrange = "15 - 40";
                        Gnormalrange1 = "";
                        ADDROW();
                    }



                    if (Convert.ToDouble(ds.Tables[0].Rows[i][28].ToString()) != 0.00)
                    {
                        Ggrp = Grr;
                        Gdesc = "CREATININE";
                        Gdesc1 = " ";
                        Gresult = ds.Tables[0].Rows[i][28].ToString();
                        Gunit = "mg/dl";
                        Gnormalrange = "M: 0.6 - 1.2 ";
                        Gnormalrange1 = "F: 0.5 - 1.1 ";
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][29].ToString()) != 0.00)
                    {
                        Ggrp = Grr;
                        Gdesc = "URIC ACID";
                        Gdesc1 = " ";
                        Gresult = ds.Tables[0].Rows[i][29].ToString();
                        Gunit = "mg/dl";
                        Gnormalrange = "M: 3.4 - 7.0";
                        Gnormalrange1 = "F: 2.5 - 6.0";
                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][30].ToString()) != 0)
                    {
                        Ggrp = Grr;
                        Gdesc = "BLOOD UREA NITROGEN ( BUN ) ";
                        Gdesc1 = " ";
                        Gresult = ds.Tables[0].Rows[i][30].ToString();
                        Gunit = "mg/dl";
                        Gnormalrange = "5 - 21";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][31].ToString()) != 0.00)
                    {
                        Ggrp = Grr;
                        Gdesc = "NPN";
                        Gdesc1 = " ";
                        Gresult = ds.Tables[0].Rows[i][31].ToString();
                        Gunit = "mg/dl";
                        Gnormalrange = "25 - 40";
                        Gnormalrange1 = "";
                        ADDROW();
                    }



                    Double ren11 = Convert.ToDouble(ds.Tables[0].Rows[i][32].ToString());
                    Double ren21 = Convert.ToDouble(ds.Tables[0].Rows[i][33].ToString());
                    Double ren31 = Convert.ToDouble(ds.Tables[0].Rows[i][34].ToString());
                    Double ren41 = Convert.ToDouble(ds.Tables[0].Rows[i][35].ToString());
                    Double ren51 = Convert.ToDouble(ds.Tables[0].Rows[i][36].ToString());
                    Double ren61 = Convert.ToDouble(ds.Tables[0].Rows[i][37].ToString());
                    Double ren71 = Convert.ToDouble(ds.Tables[0].Rows[i][38].ToString());
                    String Grl;
                    if (ren11 != 0 & ren21 != 0 & ren31 != 0.00 & ren41 != 0.00 & ren51 != 0.00 & ren61 != 0.00 & ren71 != 0.00)
                    {
                        Grl = "LIPID  PROFILE";
                    }
                    else
                    {
                        Grl = "";
                    }


                    if (Convert.ToDouble(ds.Tables[0].Rows[i][32].ToString()) != 0.00)
                    {
                        Ggrp = Grl;
                        Gdesc = "TRIGLYCERIDE";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][32].ToString();
                        Gunit = "mg/dl";
                        Gnormalrange = "50 - 200";
                        Gnormalrange1 = "";
                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][33].ToString()) != 0.00)
                    {
                        Ggrp = Grl;
                        Gdesc = "CHOLESTEROL";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][33].ToString();
                        Gunit = "mg/dl";
                        Gnormalrange = "150 - 200";
                        Gnormalrange1 = "";
                        ADDROW();
                    }


                    if (Convert.ToDouble(ds.Tables[0].Rows[i][34].ToString()) != 0.00)
                    {
                        Ggrp = Grl;
                        Gdesc = "HIGH DENSITY LIPOPROTEIN ( HDL )";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][34].ToString();
                        Gunit = "mg/dl";
                        Gnormalrange = "30 - 55";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][35].ToString()) != 0.00)
                    {
                        Ggrp = Grl;
                        Gdesc = "LOW DENSITY LIPOPROTEIN ( LDL )";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][35].ToString();
                        Gunit = "mg/dl";
                        Gnormalrange = "< 150";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][36].ToString()) != 0.00)
                    {
                        Ggrp = Grl;
                        Gdesc = "VERY LOW DENSITY LIPOPROTEIN ( VLDL )";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][36].ToString();
                        Gunit = "mg/dl";
                        Gnormalrange = "< 35";
                        Gnormalrange1 = "";
                        ADDROW();
                    }



                    if (Convert.ToDouble(ds.Tables[0].Rows[i][37].ToString()) != 0.00)
                    {
                        Ggrp = Grl;
                        Gdesc = "CHOL/HDL RATIO";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][37].ToString();
                        Gunit = "mg/dl";
                        Gnormalrange = "3.4 - 5.0";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][38].ToString()) != 0.00)
                    {
                        Ggrp = Grl;
                        Gdesc = "LDL/HDL RATIO";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][38].ToString();
                        Gunit = "mg/dl";
                        Gnormalrange = "";
                        Gnormalrange1 = "";
                        ADDROW();
                    }

                    // }


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
                    if (ren10 != 0.00 & ren20 != 0.00 & ren30 != 0 & ren40 != 0 & ren50 != 0 & ren60 != 0.00 & ren70 != 0.00 & ren80 != 0.00 & ren90 != 0.00 & ren100 != 0.00 & ren101 != 0.00)
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
                        Gunit = "mg/dl";
                        Gnormalrange = "upto 1.0";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][40].ToString()) != 0.00)
                    {
                        Ggrp = Grf;
                        Gdesc = "DIRECT BILIRUBIN";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][40].ToString();
                        Gunit = "mg/dl";
                        Gnormalrange = "upto 0.3";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][41].ToString()) != 0.00)
                    {
                        Ggrp = Grf;
                        Gdesc = "INDIRECT BILIRUBIN";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][41].ToString();
                        Gunit = "mg/dl";
                        Gnormalrange = "upto 0.5";
                        Gnormalrange1 = "";
                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][42].ToString()) != 0)
                    {
                        Ggrp = Grf;
                        Gdesc = "S.G.O.T.";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][42].ToString();
                        Gunit = "u/l";
                        Gnormalrange = "upto 40";
                        Gnormalrange1 = "";
                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][43].ToString()) != 0)
                    {
                        Ggrp = Grf;
                        Gdesc = "S.G.P.T.";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][43].ToString();
                        Gunit = "u/l";
                        Gnormalrange = "upto 40";
                        Gnormalrange1 = "";
                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][44].ToString()) != 0)
                    {
                        Ggrp = Grf;
                        Gdesc = "ALKALINE PHOSPHATASE";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][44].ToString();
                        Gunit = "u/l";
                        Gnormalrange = "A: 108 - 306";
                        Gnormalrange1 = "C: 210 - 810";
                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][45].ToString()) != 0.00)
                    {
                        Ggrp = Grf;
                        Gdesc = "TOTAL PROTEIN";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][45].ToString();
                        Gunit = "g/dl";
                        Gnormalrange = "6.0 - 8.0";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][46].ToString()) != 0.00)
                    {
                        Ggrp = Grf;
                        Gdesc = "ALBUMIN";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][46].ToString();
                        Gunit = "g/dl";
                        Gnormalrange = "3.7 - 5.3";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][47].ToString()) != 0.00)
                    {
                        Ggrp = Grf;
                        Gdesc = "GLOBULIN";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][47].ToString();
                        Gunit = "g/dl";
                        Gnormalrange = "2.3 - 3.6 ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][48].ToString()) != 0.00)
                    {
                        Ggrp = Grf;
                        Gdesc = "A:G RATIO";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][48].ToString();
                        Gunit = "g/dl";
                        Gnormalrange = "1.0 : 2.3";
                        Gnormalrange1 = "";
                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][49].ToString()) != 0.00)
                    {
                        Ggrp = Grf;
                        Gdesc = "GAMMA GLUTAMYL TRANSFERASE";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][49].ToString();
                        Gunit = "u/l";

                        Gnormalrange = "M: 10 - 50";
                        Gnormalrange1 = "F: 07 - 35";
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
                        Gdesc = "SODIUM (NA+)";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][50].ToString();
                        Gunit = "mmol/l";
                        Gnormalrange = "135 - 150";
                        Gnormalrange1 = "";
                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][51].ToString()) != 0.00)
                    {
                        Ggrp = Gre;
                        Gdesc = "POTASSIUM (K+)";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][51].ToString();
                        Gunit = "mmol/l";
                        Gnormalrange = "3.5 - 5.5";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][52].ToString()) != 0.00)
                    {
                        Ggrp = Gre;
                        Gdesc = "CHLORIDES (Cl-)";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][52].ToString();
                        Gunit = "mmol/l";
                        Gnormalrange = "98 - 106";
                        Gnormalrange1 = "";
                        ADDROW();
                    }



                    if (Convert.ToDouble(ds.Tables[0].Rows[i][53].ToString()) != 0.00)
                    {
                        Ggrp = Gre;
                        Gdesc = "CALCIUM (Ca++)";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][53].ToString();
                        Gunit = "mg%";
                        Gnormalrange = "8.0 - 11.0";
                        Gnormalrange1 = "";
                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][54].ToString()) != 0.00)
                    {
                        Ggrp = Gre;
                        Gdesc = "PHOSPHORUS (P)";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][54].ToString();
                        Gunit = "mg%";
                        Gnormalrange = "A: 2.5 - 5.0";
                        Gnormalrange1 = "C: 4.0 - 6.5";
                        ADDROW();
                    }



                    if (Convert.ToDouble(ds.Tables[0].Rows[i][55].ToString()) != 0)
                    {
                        Ggrp = "CARDIAC ( ENZYMES )";
                        Gdesc = "LDH";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][55].ToString();
                        Gunit = "U/L";
                        Gnormalrange = "230 - 460";
                        Gnormalrange1 = "";
                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][56].ToString()) != 0)
                    {
                        Ggrp = "CARDIAC ( ENZYMES )";
                        Gdesc = "CPK - MB";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][56].ToString();
                        Gunit = "U/L";
                        Gnormalrange = "upto 25";
                        Gnormalrange1 = "";
                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][57].ToString()) != 0)
                    {
                        Ggrp = "OTHERS";
                        Gdesc = "AMYLASE";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][57].ToString();
                        Gunit = "U/L";
                        Gnormalrange = "M: Upto 90";
                        Gnormalrange1 = "F: 35 - 120";
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][58].ToString()) != 0)
                    {
                        Ggrp = "OTHERS";
                        Gdesc = "ACID PHOSPHATASE";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][58].ToString();
                        Gunit = "U/L";
                        Gnormalrange = "M: upto 47";
                        Gnormalrange1 = "F: upto 37";
                        ADDROW();
                    }








                    //all
                }
                //cashbankrep = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                //cashbankrep.Load("/Hope_account/Hope_account/repcash_Bank.rpt");

                Repbiochemn cashbankrep = new Repbiochemn();
                cashbankrep.SetDatabaseLogon("sa", "software", @".\SQLEXPRESS", "pathology2627");
                cashbankrep.SetDataSource(dt);
                crv.ReportSource = cashbankrep;
               
                crv.Refresh();
            }
            else
            {
                MessageBox.Show("No Records Found!!!");
            }


             s1 = ("select a.cc,a.patient_name,a.pcode,a.sex,a.age,a.doctor,a.date_exam,b.FA_Timeofcollection,b.FA_Timeofexamination,b.FA_Timeofliquification,b.FA_Volume,b.FA_Reaction,b.FA_Color,b.FA_Viscocity,b.FA_MP_Prostaticpearls,b.FA_MP_Puscells,b.FA_MP_RBC,b.FA_MP_Epithcells,b.FA_MP_Deformed,b.FA_MT_Active,b.FA_MT_Slugish,b.FA_MT_Dead,b.FA_MT_Totalcount,a.month_year from patient_master a,seminal_fluid b where a.pcode='" + cbopcode.Text + "' and a.pcode=b.pcode order by a.pcode,a.date_exam");
            //strsql = strsql + "FA_Timeofcollection,FA_Timeofexamination,FA_Timeofliquification,FA_Volume,FA_Reaction,FA_Color,FA_Viscocity,FA_MP_Prostaticpearls,FA_MP_Puscells,FA_MP_RBC,";
            //strsql = strsql + "";

            da = new SqlDataAdapter(s1, con);
            ds = new DataSet();
            da.Fill(ds, "seminal_fluid");
            if (ds.Tables[0].Rows.Count != 0)
            {
                if (ds.Tables[0].Rows[0][7].ToString().Trim() != "")
                {


                    Repseminalfluidn1 cashbankrep = new Repseminalfluidn1();
                    cashbankrep.SetDatabaseLogon("sa", "software", @".\SQLEXPRESS", "pathology2627");
                    cashbankrep.SetDataSource(ds);
                    crv.ReportSource = cashbankrep;
                    
                    crv.Refresh();
                    crv.PrintReport();
                }
            }
            else
            {
                //MessageBox.Show("No Records Found!!!");
            }
        
        
            // serology start

           strsql = "";
          i = 0;

            strsql = "select a.cc,a.patient_name,a.pcode,a.sex,a.age,a.doctor,a.date_exam,a.month_year,a.scn,a.tpt,";
            strsql = strsql + "b.cc,b.pcode,b.BG_Blood_Group,b.BR_RhD_Typing,b.BDc_Neutrophild,b.BDc_Eosinophils,b.BDc_Lymphocytes,b.BDc_Basophils,b.BDc_Monocytes,b.BDc_Twbc,b.BDc_Trbc,b.BDc_Tplatelets,";
            strsql = strsql + "b.BDc_Aec,b.BDc_Tnc,b.BDc_Reticulocyte_Count,b.BDc_PCV,b.BDC_mcv,b.BDC_mch,b.BDC_mchc,b.BDc_Mp_ICT_QBC_Smear,b.BDc_Mf_ICT_QBC_Smear,b.BDc_Hb,b.BDc_ESR_1sthour,";
            strsql = strsql + "b.BDc_Bleeding_Time,b.BDc_Clotting_Time,b.BDc_Sickle_cell,b.Bw_WidaltubeO80,b.Bw_Widalslide1,b.Bw_Widalslide2,b.Bw_Widalslide3,b.Bw_Widalslide4,";
            strsql = strsql + "b.BPS_Aso,b.BPS_Crp,b.BPS_Rafactor,b.BPS_Ana,b.BPS_Vdrl,b.BPS_Toxo,b.BS_Australia_Antigen,b.BS_Hepatitis_C_Virus,b.BS_HIV_1,b.BS_HIV_2,";
            strsql = strsql + "b.Bw_mycodot,b.bw_trop,b.Bm_MontouxTest_injon,b.Bm_MontouxTest_readon,b.Bm_MontouxTest_induration,b.BDc_Dengue,b.BDc_Typhicheck,";
            strsql = strsql + "b.Bw_Widaltubeo80,b.Bw_Widaltubeo160,b.Bw_Widaltubeo320,b.Bw_Widaltubeh80,b.Bw_Widaltubeh160,b.Bw_Widaltubeh320,b.Bw_Widaltubeah80,b.Bw_Widaltubeah160,b.Bw_Widaltubeah320,b.Bw_Widaltubebh80,b.Bw_Widaltubebh160,b.Bw_Widaltubebh320,";
            strsql = strsql + "b.Bw_Widaltubeo240,b.Bw_Widaltubeo480,b.Bw_Widaltubeh240,b.Bw_Widaltubeh480,b.Bw_Widaltubeah240,b.Bw_Widaltubeah480,b.Bw_Widaltubebh240,b.Bw_Widaltubebh480";

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
                dt.Columns.Add("Desc1", System.Type.GetType("System.String"));
                dt.Columns.Add("Result", System.Type.GetType("System.String"));
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
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][37].ToString();
                    Gunit = "";
                    Gnormalrange = " ";
                    Gnormalrange1 = " ";
                    ADDROW();
                }
                if (ds.Tables[0].Rows[i][38].ToString() != "")
                {
                    Ggrp = "Widal Test: By Slide Agglutination Method";
                    Gdesc = "Salmonella Typhi H";
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][38].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = " ";
                    ADDROW();
                }
                if (ds.Tables[0].Rows[i][39].ToString() != "")
                {
                    Ggrp = "Widal Test: By Slide Agglutination Method";
                    Gdesc = "Salmonella Typhi AH";
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][39].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = " ";
                    ADDROW();
                }
                if (ds.Tables[0].Rows[i][40].ToString() != "")
                {
                    Ggrp = "Widal Test: By Slide Agglutination Method";
                    Gdesc = "Salmonella Typhi BH";
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][40].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = " ";
                    ADDROW();
                }

                if (ds.Tables[0].Rows[i][41].ToString() != "")
                {
                    Ggrp = "";
                    Gdesc = "A.S.O. Titre";
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][41].ToString();
                    Gunit = "lu/ml";
                    Gnormalrange = "< 200 ";
                    Gnormalrange1 = " ";
                    ADDROW();
                }



                if (ds.Tables[0].Rows[i][42].ToString() != "")
                {
                    Ggrp = "";
                    Gdesc = "C Reactive Protein";
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][42].ToString();
                    Gunit = "mg/L";
                    Gnormalrange = "Upto 6 ";
                    Gnormalrange1 = " ";
                    ADDROW();
                }
                if (ds.Tables[0].Rows[i][43].ToString() != "")
                {
                    Ggrp = "";
                    Gdesc = "Rheumatoid Factor";
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][43].ToString();
                    Gunit = "IU/ml";
                    Gnormalrange = "0 - 20 ";
                    Gnormalrange1 = " ";
                    ADDROW();
                }
                if (ds.Tables[0].Rows[i][44].ToString() != "")
                {
                    Ggrp = "";
                    Gdesc = "Test for Antinuclear Antibody";
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][44].ToString();
                    Gunit = "";
                    Gnormalrange = " ";
                    Gnormalrange1 = " ";
                    ADDROW();
                }


                if (ds.Tables[0].Rows[i][45].ToString() != "")
                {
                    Ggrp = "";
                    Gdesc = "V.D.R.L";
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][45].ToString();
                    Gunit = "";
                    Gnormalrange = " ";
                    Gnormalrange1 = " ";
                    ADDROW();
                }
                if (ds.Tables[0].Rows[i][46].ToString() != "")
                {
                    Ggrp = "";
                    Gdesc = "Toxo Plasma(Antibody) ";
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][46].ToString();
                    Gunit = "";
                    Gnormalrange = " ";
                    Gnormalrange1 = " ";
                    ADDROW();
                }



                if (ds.Tables[0].Rows[i][47].ToString() != "")
                {
                    Ggrp = "";
                    Gdesc = "Australia Antigen";
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][47].ToString();
                    Gunit = "";
                    Gnormalrange = " ";
                    Gnormalrange1 = " ";
                    ADDROW();
                }

                if (ds.Tables[0].Rows[i][48].ToString() != "")
                {
                    Ggrp = "";
                    Gdesc = "Hepatitis C Virus";
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][48].ToString();
                    Gunit = "";
                    Gnormalrange = " ";
                    Gnormalrange1 = " ";
                    ADDROW();
                }
                if (ds.Tables[0].Rows[i][49].ToString() != "")
                {
                    Ggrp = "";
                    Gdesc = "HIV Rapid Test(I)";
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][49].ToString();
                    Gunit = "";
                    Gnormalrange = " ";
                    Gnormalrange1 = " ";
                    ADDROW();
                }
                if (ds.Tables[0].Rows[i][50].ToString() != "")
                {
                    Ggrp = "";
                    Gdesc = "HIV Rapid Test(II)";
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][50].ToString();
                    Gunit = "";
                    Gnormalrange = " ";
                    Gnormalrange1 = " ";
                    ADDROW();
                }
                if (ds.Tables[0].Rows[i][51].ToString() != "")
                {
                    Ggrp = "";
                    Gdesc = "Mycodot/(LAM) Test-                                  (For detection of (IgG)";
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][51].ToString();
                    Gunit = "";
                    Gnormalrange = " ";
                    Gnormalrange1 = " ";
                    ADDROW();
                }
                if (ds.Tables[0].Rows[i][52].ToString() != "")
                {
                    Ggrp = "";
                    Gdesc = "Trop T /Trop I(Qualitative)";
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][52].ToString();
                    Gunit = "";
                    Gnormalrange = " ";
                    Gnormalrange1 = " ";
                    ADDROW();
                }



                if (ds.Tables[0].Rows[i][53].ToString() != "")
                {
                    Ggrp = "Mantoux Test";
                    Gdesc = "MantouxTest Inj On";
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][53].ToString();
                    Gunit = "";
                    Gnormalrange = " ";
                    Gnormalrange1 = " ";
                    ADDROW();
                }

                if (ds.Tables[0].Rows[i][54].ToString() != "")
                {
                    Ggrp = "Mantoux Test";
                    Gdesc = "        Read On";
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][54].ToString();
                    Gunit = "";
                    Gnormalrange = " ";
                    Gnormalrange1 = " ";
                    ADDROW();
                }
                if (ds.Tables[0].Rows[i][55].ToString() != "")
                {
                    Ggrp = "Mantoux Test";
                    Gdesc = "       Induration";
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][55].ToString();
                    Gunit = "";
                    Gnormalrange = " ";
                    Gnormalrange1 = " ";
                    ADDROW();
                }
                if (ds.Tables[0].Rows[i][56].ToString() != "")
                {
                    Ggrp = "";
                    Gdesc = "DENGUE (IgG/IgM)";
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][56].ToString();
                    Gunit = "";
                    Gnormalrange = " ";
                    Gnormalrange1 = " ";
                    ADDROW();
                }
                if (ds.Tables[0].Rows[i][57].ToString() != "")
                {
                    Ggrp = "";
                    Gdesc = "TYPHI CHECK (IgG/IgM)";
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][57].ToString();
                    Gunit = "";
                    Gnormalrange = " ";
                    Gnormalrange1 = " ";
                    ADDROW();
                }

            }

            reportname = "Serology Report";
            {
                
                //if (radioButton1.Checked == true)
                {
                    Repserology cashbankrep = new Repserology();
                    cashbankrep.SetDatabaseLogon("sa", "software", @".\sqlexpress", "pathology2627");
                    cashbankrep.SetDataSource(dt);
                    crv.ReportSource = cashbankrep;
                    cashbankrep.SetParameterValue(0, ds2.Tables[0].Rows[0][5].ToString());
                    cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows[0][6].ToString());
                    cashbankrep.SetParameterValue(2, reportname);
                    
                    crv.Refresh();
                }
                

                crv.PrintReport();
            
            }

            // serology end
        
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbopcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            String s1 = "select a.cc,a.patient_name,a.pcode,a.sex,a.age,a.doctor,a.date_exam as Dt_Report,a.month_year,a.tpt from patient_master a  where a.pcode='" + cbopcode.Text + "'   order by a.pcode,a.date_exam";
            da = new SqlDataAdapter(s1, con);
            ds = new DataSet();
            da.Fill(ds);
            cboname.Text = ds.Tables[0].Rows[0][1].ToString();
            label2.Text=(ds.Tables[0].Rows[0][8].ToString());
        }

       
    }
}