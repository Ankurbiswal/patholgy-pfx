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
    public partial class Frmreptestsummary : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        SqlDataReader dr1;
        DataRow dr;
        DataTable dt;
        DataSet ds1, ds2,ds3,ds4;
        public string Ggrp, Gdesc, Gdesc1, Gresult, Gunit, Gnormalrange, Gnormalrange1;
        public int gcode, gage;
        public string gsex, gpatient_name, gdoctor, gmnyr, gscn, gtpt, grrd, grrd3;
        public DateTime gdt_report;
        public Frmreptestsummary()
        {
            InitializeComponent();
        }

        private void Frmreptestsummary_Load(object sender, EventArgs e)
        {
            Class1 objclass = new Class1();
            con = new SqlConnection(objclass.arun_con());
            con.Open();
            cmd = new SqlCommand("select cc,comp,year_start,year_end from setup");
            cmd.Connection = con;
            dr1 = cmd.ExecuteReader();
            while (dr1.Read())
            {
                //this.txtcompid.Text = dr.GetValue(0).ToString();
              label4.Text = dr1.GetValue(1).ToString();
                dtfrom.Text = dr1.GetValue(2).ToString();
            }
            dr1.Close();
           
            da = new SqlDataAdapter("select  patient_name,pcode from patient_master order by patient_name", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                this.cboname.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        
        
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
            dt.Rows.Add(dr);
            dt.AcceptChanges();
        }
        
        private void btngo_Click(object sender, EventArgs e)
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



            //String s1 = ("select cc,type,blno,bldt,acdes,challan_no,challan_dt,gross,discount_rt,discount,vat_rt,vat,tamt from inv where bldt>= '" + Convert.ToDateTime(dtfrom.Text) + "' and bldt<= '" + Convert.ToDateTime(dtto.Text) + "' and cc='" + txtcompid.Text + "' and type='" + cbotype.Text + "' order by cc,type,bldt,blno");
            // String s1 = ("select cc,patient_name,pcode,sex,age,doctor,date_exam,Sp_color, Sp_reaction, Sp_Mucus, SM_rbc_from, SM_rbc_to, SM_puscells_from,SM_puscells_to,SM_macrophase,SM_vegetables,SM_fataglobules,SM_yeast,SM_crystal,SM_bacterialflora,SP_EHistolytica,SP_ecoli,SP_giardia,SP_trichomonas,SH_OvaHW,SH_OvaRW,SH_Others,SC_Occultblood,SC_Reducingsugar from patient_record where patient_name='" + cboname.Text + "' and date_exam= '" + Convert.ToDateTime(dtreport.Text) + "' order by pcode,date_exam");
            String strsql = "";
            //strsql = "select cc,patient_name,pcode,sex,age,doctor,date_exam,UP_color,UP_sediments,UP_reaction,UP_specificgravity,UC_sugar,UC_albumin,UC_phosphate,UC_chyle,UC_ketonebodies,UC_bilesalts,UC_bilepigment,UM_puscells,UM_epithcells,UM_rbc,UM_casts,UM_crystals,UM_bacterial,UM_spermatozoa,UM_mf_tv,UM_others,UU_urine_b_hcg,UA_urine_albumin,UN_nasalsmear,Us_SputumAfb, Sp_color, Sp_reaction, Sp_Mucus, SM_rbc_from, SM_rbc_to, SM_puscells_from,SM_puscells_to,SM_macrophase,SM_vegetables,SM_fataglobules,SM_yeast,SM_crystal,SM_bacterialflora,SP_EHistolytica,SP_ecoli,SP_giardia,SP_trichomonas,SH_OvaHW,SH_OvaRW,SH_Others,SC_Occultblood,SC_Reducingsugar,";
            //strsql = strsql + "BG_Blood_Group,BR_RhD_Typing,BDc_Neutrophild,BDc_Eosinophils,BDc_Lymphocytes,";
            //strsql = strsql + "BDc_Basophils,BDc_Monocytes,BDc_Twbc,BDc_Trbc,BDc_Tplatelets,BDc_Aec,BDc_Reticulocyte_Count,";
            //strsql = strsql + "BDc_PCV,BDc_Mp_ICT_QBC_Smear,BDc_Mf_ICT_QBC_Smear,BDc_Hb,BDc_ESR_1sthour,BDc_ESR_2ndhour,";
            //strsql = strsql + "BDc_Bleeding_Time,BDc_Clotting_Time,BDc_Sickle_cell,BPS_Toxo,BPS_Crp,BPS_Vdrl,";
            //strsql = strsql + "BPS_Rafactor,BPS_Aso,BS_Australia_Antigen,BS_Hepatitis_C_Virus,BS_HIV_1,BS_HIV_2,";
            //strsql = strsql + "BS_Ict_PF_PV,Bw_Widaltest,Bm_MontouxTest_injon,Bm_MontouxTest_readon,Bm_MontouxTest_induration,due_amount,paid_amount";


            //strsql = strsql + " from patient_record where patient_name='" + cboname.SelectedItem + "'  and date_exam= '" + Convert.ToDateTime(dtreport.Text) + "'";
            if (cboname.Text == "")
            {
                strsql = "select a.cc,a.patient_name,a.pcode,a.sex,a.age,a.doctor,a.date_exam,a.month_year,a.Scn,a.Tpt,";
                strsql = strsql + "b.cc,b.pcode,b.Bcr1_Glucose_Fpg_RPG,b.Bcr1_PPPG_PGPG_2hr,b.Bcr1_PPPG_PGPG_1hr,b.Bcr1_RBS,b.Bcr1_PBBS,b.Bcr1_PLBS,b.Bcr1_GTT_1hr,b.Bcr1_GTT_2hr,b.Bcr1_GTT_3hr,b.Bcr1_PGBS_1hr,b.Bcr1_PGBS_2hr,b.Bcr1_HBAC_good,b.Bcr1_HBAC_fair,b.Bcr1_HBAC_poor, b.Bcr1_MBGE,b.Bcr_LP_Triglycerides,b.Bcr_LP_Cholesterol,b.Bcr_LP_HDLCholesterol,";
                strsql = strsql + "b.Bcr_LP_LDLCholesterol,b.Bcr_LP_VLDLCholesterol,b.Bcr2_LP_CHR,b.Bcr2_LP_LHR,b.Bcr_RP_Urea,b.Bcr_RP_Creatinine,b.Bcr3_Uric_Acid,b.Bcr_RP_BUN,b.Bcr3_NPN,b.Bcr_LFT_Bilirubin_total,b.Bcr_LFT_Bilirubin_Direct,b.Bcr4_LFT_Indirect,";
                strsql = strsql + "b.Bcr_LFT_SGOT_AST,b.Bcr_LFT_SGPT_ALT,b.Bcr_LFT_Alkaline_Phosphates,b.Bcr_LFT_Protein,b.Bcr_LFT_Albumin,b.Bcr_LFT_Globulin,b.Bcr_LFT_AG_Ratio,b.Bcr4_LFT_GGTP,b.Bcr_Electrolyte_Sodium,";
                strsql = strsql + "b.Bcr_Electrolyte_Potassium,b.Bcr5_Electrolyte_Chlorides,b.Bcr_OTH_Acid_Calcium,b.Bcr_OTH_Acid_Phosphorus,b.Bcr_OTH_Uric_Acid,b.Bcr_OTH_Pasting_urine_sugar,b.Bcr_OTH_Amylase,b.Bcr_OTH_Acid_Phosphate,b.Bcr_OTH_PP_PG_urine_sugar";

                strsql = strsql + " from patient_master a, biochemist b  where   (a.pcode=b.pcode) and a.date_exam>= '" + dtf.ToString("yyyy-MM-dd") + "' and a.date_exam<= '" + dtt.ToString("yyyy-MM-dd") + "' order by a.pcode,a.date_exam";





                //strsql = " select * from Biochemist where date_exam>= '" + dtf+ "' and date_exam<= '" + dtt.ToString("yyyy-MM-dd") + "' order by pcode,date_exam";
            }
            else
            {
                strsql = "select a.cc,a.patient_name,a.pcode,a.sex,a.age,a.doctor,a.date_exam,a.month_year,a.Scn,a.Tpt,";
                strsql = strsql + "b.cc,b.pcode,b.Bcr1_Glucose_Fpg_RPG,b.Bcr1_PPPG_PGPG_2hr,b.Bcr1_PPPG_PGPG_1hr,b.Bcr1_RBS,b.Bcr1_PBBS,b.Bcr1_PLBS,b.Bcr1_GTT_1hr,b.Bcr1_GTT_2hr,b.Bcr1_GTT_3hr,b.Bcr1_PGBS_1hr,b.Bcr1_PGBS_2hr,b.Bcr1_HBAC_good,b.Bcr1_HBAC_fair,b.Bcr1_HBAC_poor, b.Bcr1_MBGE,b.Bcr_LP_Triglycerides,b.Bcr_LP_Cholesterol,b.Bcr_LP_HDLCholesterol,";
                strsql = strsql + "b.Bcr_LP_LDLCholesterol,b.Bcr_LP_VLDLCholesterol,b.Bcr2_LP_CHR,b.Bcr2_LP_LHR,b.Bcr_RP_Urea,b.Bcr_RP_Creatinine,b.Bcr3_Uric_Acid,b.Bcr_RP_BUN,b.Bcr3_NPN,b.Bcr_LFT_Bilirubin_total,b.Bcr_LFT_Bilirubin_Direct,b.Bcr4_LFT_Indirect,";
                strsql = strsql + "b.Bcr_LFT_SGOT_AST,b.Bcr_LFT_SGPT_ALT,b.Bcr_LFT_Alkaline_Phosphates,b.Bcr_LFT_Protein,b.Bcr_LFT_Albumin,b.Bcr_LFT_Globulin,b.Bcr_LFT_AG_Ratio,b.Bcr4_LFT_GGTP,b.Bcr_Electrolyte_Sodium,";
                strsql = strsql + "b.Bcr_Electrolyte_Potassium,b.Bcr5_Electrolyte_Chlorides,b.Bcr_OTH_Acid_Calcium,b.Bcr_OTH_Acid_Phosphorus,b.Bcr_OTH_Uric_Acid,b.Bcr_OTH_Pasting_urine_sugar,b.Bcr_OTH_Amylase,b.Bcr_OTH_Acid_Phosphate,b.Bcr_OTH_PP_PG_urine_sugar";

                strsql = strsql + " from patient_master a ,biochemist b  where  (a.pcode=b.pcode) and a.date_exam>= '" + dtf.ToString("yyyy-MM-dd") + "' and a.date_exam<= '" + dtt.ToString("yyyy-MM-dd") + "' and a.patient_name='" + cboname.Text + "' order by a.date_exam,a.pcode";

                //and a.patient_name='" + cboname.Text + "'

                //strsql = " select * from Biochemist where date_exam>= '" +dtf + "' and date_exam<= '" + dtt.ToString("yyyy-MM-dd") + "' and patient_name='" + cboname.Text + "' order by pcode,date_exam";
            }
            int i = 0;
            da = new SqlDataAdapter(strsql, con);
            ds = new DataSet();
            da.Fill(ds, "Biochemist");

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
            if (ds.Tables[0].Rows.Count == 0) { MessageBox.Show("No Bio-Chem records found for the selected patient/date range.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            gcode = Convert.ToInt32(ds.Tables[0].Rows[i][2].ToString());
            gage = Convert.ToInt32(ds.Tables[0].Rows[i][4].ToString());
            gsex = ds.Tables[0].Rows[i][3].ToString();
            gpatient_name = ds.Tables[0].Rows[i][1].ToString();
            gdt_report = Convert.ToDateTime(ds.Tables[0].Rows[i][6].ToString());
            gdoctor = ds.Tables[0].Rows[i][5].ToString();
            gmnyr = ds.Tables[0].Rows[i][7].ToString();
            gscn = ds.Tables[0].Rows[i][8].ToString();
            gtpt = ds.Tables[0].Rows[i][9].ToString();

            Double fbs = 0; Double ppbs = 0; Double ppbs1 = 0; Double rbs = 0; Double pbbs = 0; Double plbs = 0;
            Double gtt = 0; Double pgbs = 0; Double hba1c = 0; Double mbge = 0; Double lip1 = 0; Double lip2 = 0;
            Double lip3 = 0; Double lip4 = 0; Double lip5 = 0; Double lip6 = 0; Double lip7 = 0; Double ren1 = 0;
            Double ren2 = 0; Double ren3 = 0; Double ren4 = 0; Double ren5 = 0; Double tb = 0; Double db = 0; Double ib = 0;
            Double sgot = 0; Double sgpt = 0; Double ap = 0; Double tp = 0; Double alb = 0; Double glob = 0; Double agr = 0; Double ggt = 0;
            Double sod = 0; Double pot = 0; Double chl = 0; Double cal = 0; Double phos = 0;



        // start check biochemistry

            //double fbs = 0; ppbs = 0; ppbs1 = 0; rbs = 0; pbbs = 0; plbs = 0;
            //double gtt = 0; pgbs = 0; hba1c = 0; mbge = 0; lip1 = 0; lip2 = 0;
            //double lip3 = 0; lip4 = 0; lip5 = 0; lip6 = 0; lip7 = 0; ren1 = 0;
            //double ren2 = 0; ren3 = 0; ren4 = 0; ren5 = 0; tb = 0; db = 0; ib = 0;
            //double sgot = 0; sgpt = 0; ap = 0; tp = 0; alb = 0; glob = 0; agr = 0; ggt = 0;
            //double sod = 0; pot = 0; chl = 0; cal = 0; phos = 0;

            
            
            
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
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


                //double fbs = 0; ppbs = 0; ppbs1 = 0;

                if (Convert.ToDouble(ds.Tables[0].Rows[i][12].ToString()) != 0)
                {
                    Ggrp = grrd3;
                    Gdesc = "FASTING BLOOD SUGAR ( FBS )";
                    fbs = fbs + 1;
                    //Gdesc1 = "";
                    //Gresult = ds.Tables[0].Rows[i][12].ToString();
                    //Gunit = "mg/dl";

                    //Gnormalrange = "60 - 110 ";
                    //Gnormalrange1 = "";
                    
                    //ADDROW();
                }
                if (Convert.ToDouble(ds.Tables[0].Rows[i][13].ToString()) != 0)
                {
                    Ggrp = grrd3;
                    Gdesc = "POST PRANDIAL BLOOD SUGAR ( PPBS )";
                    ppbs = ppbs + 1;
                    //Gdesc1 = "(2 hour)";
                    //Gresult = ds.Tables[0].Rows[i][13].ToString();
                    //Gunit = "mg/dl";
                    //Gnormalrange = "70 - 140 ";
                    //Gnormalrange1 = "";
                    //ADDROW();
                }
                if (Convert.ToDouble(ds.Tables[0].Rows[i][14].ToString()) != 0)
                {
                    Ggrp = grrd3;
                    Gdesc = "POST PRANDIAL BLOOD SUGAR ( PPBS )";
                    ppbs1 = ppbs1 + 1;
                    Gdesc1 = "(1 hour)";
                    Gresult = ds.Tables[0].Rows[i][14].ToString();
                    Gunit = "mg/dl";
                    Gnormalrange = "70 - 140 ";
                    Gnormalrange1 = "";
                    ADDROW();
                }



                if (Convert.ToDouble(ds.Tables[0].Rows[i][15].ToString()) != 0)
                {
                    Ggrp = grrd3;
                    Gdesc = "RANDOM BLOOD SUGAR ( RBS )";
                    rbs = rbs + 1;
                    
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][15].ToString();
                    Gunit = "mg/dl";
                    Gnormalrange = "70 - 140 ";
                    Gnormalrange1 = "";
                    ADDROW();
                }
                if (Convert.ToDouble(ds.Tables[0].Rows[i][16].ToString()) != 0)
                {
                    Ggrp = grrd3;
                    Gdesc = "POST BREAKFAST BLOOD SUGAR ( PBBS )";
                    
                    pbbs = pbbs + 1;
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][16].ToString();
                    Gunit = "mg/dl";
                    Gnormalrange = "70 - 140";
                    Gnormalrange1 = "";
                    ADDROW();
                }

                if (Convert.ToDouble(ds.Tables[0].Rows[i][17].ToString()) != 0)
                {
                    Ggrp = grrd3;
                    Gdesc = "POST LUNCH BLOOD SUGAR ( PLBS )";
                    
                    plbs = plbs + 1;
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][17].ToString();
                    Gunit = "mg/dl";
                    Gnormalrange = "70 - 140";
                    Gnormalrange1 = "";
                    ADDROW();
                }


                if (Convert.ToDouble(ds.Tables[0].Rows[i][18].ToString()) != 0)
                {
                    Ggrp = grrd3;
                    Gdesc = "GLUCOSE TOLERANCE TEST ( GTT )";

                    gtt = gtt + 1;
                    Gdesc1 = "(1 hour)";
                    Gresult = ds.Tables[0].Rows[i][18].ToString();
                    Gunit = "mg/dl";
                    Gnormalrange = "70 - 140";
                    Gnormalrange1 = "";
                    ADDROW();
                }
                if (Convert.ToDouble(ds.Tables[0].Rows[i][19].ToString()) != 0)
                {
                    Ggrp = grrd3;
                    Gdesc = "";
                    Gdesc1 = "(2 hour)";
                    Gresult = ds.Tables[0].Rows[i][19].ToString();
                    Gunit = "mg/dl";
                    Gnormalrange = "70 - 140";
                    Gnormalrange1 = "";
                    ADDROW();
                }
                if (Convert.ToDouble(ds.Tables[0].Rows[i][20].ToString()) != 0)
                {
                    Ggrp = grrd3;
                    Gdesc = "                                    ";
                    Gdesc1 = "(3 hour)";
                    Gresult = ds.Tables[0].Rows[i][20].ToString();
                    Gunit = "mg/dl";
                    Gnormalrange = "70 - 140";
                    Gnormalrange1 = "";
                    ADDROW();
                }


                if (Convert.ToDouble(ds.Tables[0].Rows[i][21].ToString()) != 0)
                {
                    Ggrp = grrd3;
                    Gdesc = "POST GLUCOSE BLOOD SUGAR ( PGBS )";
                   
                    pgbs = pgbs + 1;
                    Gdesc1 = "(1 hour)";
                    Gresult = ds.Tables[0].Rows[i][21].ToString();
                    Gunit = "mg/dl";
                    Gnormalrange = "70 - 140";
                    Gnormalrange1 = "";
                    ADDROW();
                }
                if (Convert.ToDouble(ds.Tables[0].Rows[i][22].ToString()) != 0)
                {
                    Ggrp = grrd3;
                    Gdesc = "POST GLUCOSE BLOOD SUGAR ( PGBS ) ";
                    Gdesc1 = "(2 hour)";
                    Gresult = ds.Tables[0].Rows[i][22].ToString();
                    Gunit = "mg/dl";
                    Gnormalrange = "70 - 140";
                    Gnormalrange1 = "";
                    ADDROW();
                }


                if (Convert.ToDouble(ds.Tables[0].Rows[i][23].ToString()) != 0)
                {
                    Ggrp = grrd3;
                    Gdesc = "GLYCO CYLATED HAEMOGLOBIN ( HbA1C )";
                   
                    hba1c = hba1c + 1;
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][23].ToString();
                    Gunit = "%";
                    Gnormalrange = "Non-diabetic: 4 - 6 ";
                    Gnormalrange1 = "Excellent Control: 6 - 7              Fair to good control: 7 - 8        Unsatisfactory control: 8 - 10          Poor Control:   >10";                        //Poor Control,   >7.6"

                    ADDROW();
                }
                if (Convert.ToDouble(ds.Tables[0].Rows[i][24].ToString()) != 0)
                {
                    Ggrp = grrd3;
                    Gdesc = " ";
                    Gdesc1 = " ";
                    Gresult = ds.Tables[0].Rows[i][24].ToString();
                    Gunit = "%";
                    Gnormalrange = "Fair to good control: 7 - 8 ";
                    Gnormalrange1 = "";
                    ADDROW();
                }
                if (Convert.ToDouble(ds.Tables[0].Rows[i][25].ToString()) != 0)
                {
                    Ggrp = grrd3;
                    Gdesc = " ";
                    Gdesc1 = " ";
                    Gresult = ds.Tables[0].Rows[i][25].ToString();
                    Gunit = "%";
                    Gnormalrange = "Poor Control:   > 10 ";
                    Gnormalrange1 = "";
                    ADDROW();
                }

                if (Convert.ToDouble(ds.Tables[0].Rows[i][26].ToString()) != 0)
                {
                    Ggrp = grrd3;
                    Gdesc = "MEAN BLOOD GLUCOSE ESTIMATION";
                    
                    mbge = mbge + 1;
                    
                    Gdesc1 = " ";
                    Gresult = ds.Tables[0].Rows[i][26].ToString();
                    Gunit = "%";
                    Gnormalrange = "6.5 - 13.0";
                    Gnormalrange1 = "";
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
                if (ren11 != 0 & ren21 != 0 & ren31 != 0.00 & ren41 != 0.00 & ren51 != 0.00)
                {
                    Grl = "LIPID  PROFILE";
                }
                else
                {
                    Grl = "";
                }


                if (Convert.ToDouble(ds.Tables[0].Rows[i][27].ToString()) != 0.00)
                {
                    Ggrp = Grl;
                    Gdesc = "TRIGLYCERIDE";
                    
                    lip1 = lip1 + 1;
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][27].ToString();
                    Gunit = "mg/dl";
                    Gnormalrange = "60 - 165";
                    Gnormalrange1 = "";
                    ADDROW();
                }

                if (Convert.ToDouble(ds.Tables[0].Rows[i][28].ToString()) != 0.00)
                {
                    Ggrp = Grl;
                    Gdesc = "CHOLESTEROL";
                    
                    lip2=lip2+1;
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][28].ToString();
                    Gunit = "mg/dl";
                    Gnormalrange = "130 - 250";
                    Gnormalrange1 = "";
                    ADDROW();
                }


                if (Convert.ToDouble(ds.Tables[0].Rows[i][29].ToString()) != 0.00)
                {
                    Ggrp = Grl;
                    Gdesc = "HIGH DENSITY LIPOPROTEIN ( HDL )";
                    
                    lip3 = lip3 + 1;
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][29].ToString();
                    Gunit = "mg/dl";
                    Gnormalrange = "30 - 65";
                    Gnormalrange1 = "";
                    ADDROW();
                }
                if (Convert.ToDouble(ds.Tables[0].Rows[i][30].ToString()) != 0.00)
                {
                    Ggrp = Grl;
                    Gdesc = "LOW DENSITY LIPOPROTEIN ( LDL )";
                    
                    lip4 = lip4 + 1;
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][30].ToString();
                    Gunit = "mg/dl";
                    Gnormalrange = "120 - 180";
                    Gnormalrange1 = "";
                    ADDROW();
                }
                if (Convert.ToDouble(ds.Tables[0].Rows[i][31].ToString()) != 0.00)
                {
                    Ggrp = Grl;
                    Gdesc = "VERY LOW DENSITY LIPOPROTEIN ( VLDL )";
                    
                    lip5 = lip5 + 1;
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][31].ToString();
                    Gunit = "mg/dl";
                    Gnormalrange = "30 - 50";
                    Gnormalrange1 = "";
                    ADDROW();
                }



                if (Convert.ToDouble(ds.Tables[0].Rows[i][32].ToString()) != 0.00)
                {
                    Ggrp = Grl;
                    Gdesc = "CHOL/HDL RATIO";
                    
                    lip6 = lip6 + 1;
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][32].ToString();
                    Gunit = "mg/dl";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }
                if (Convert.ToDouble(ds.Tables[0].Rows[i][33].ToString()) != 0.00)
                {
                    Ggrp = Grl;
                    Gdesc = "LDL/HDL RATIO";
                   
                    lip7 = lip7 + 1;
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][33].ToString();
                    Gunit = "mg/dl";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }

                // }

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
                    
                    ren1 = ren1 + 1;
                    Gdesc1 = " ";
                    Gresult = ds.Tables[0].Rows[i][34].ToString();
                    Gunit = "mg/dl";
                    Gnormalrange = "13 - 40";
                    Gnormalrange1 = "";
                    ADDROW();
                }



                if (Convert.ToDouble(ds.Tables[0].Rows[i][35].ToString()) != 0.00)
                {
                    Ggrp = Grr3a;
                    Gdesc = "CREATININE";
                    
                    ren2 = ren2 + 1;
                    Gdesc1 = " ";
                    Gresult = ds.Tables[0].Rows[i][35].ToString();
                    Gunit = "mg/dl";
                    Gnormalrange = "M: 0.9 - 1.4 ";
                    Gnormalrange1 = "F: 0.5 - 1.1 ";
                    ADDROW();
                }
                if (Convert.ToDouble(ds.Tables[0].Rows[i][36].ToString()) != 0.00)
                {
                    Ggrp = Grr3a;
                    Gdesc = "URIC ACID";
                    
                    ren3 = ren3 + 1;
                    Gdesc1 = " ";
                    Gresult = ds.Tables[0].Rows[i][36].ToString();
                    Gunit = "mg/dl";
                    Gnormalrange = "M: 3.4 - 7.0";
                    Gnormalrange1 = "F: 2.5 - 6.0";
                    ADDROW();
                }

                if (Convert.ToDouble(ds.Tables[0].Rows[i][37].ToString()) != 0)
                {
                    Ggrp = Grr3a;
                    Gdesc = "BLOOD UREA NITROGEN ( BUN ) ";
                   
                    ren4 = ren4 + 1;
                    Gdesc1 = " ";
                    Gresult = ds.Tables[0].Rows[i][37].ToString();
                    Gunit = "mg/dl";
                    Gnormalrange = "5 - 21";
                    Gnormalrange1 = "";
                    ADDROW();
                }
                if (Convert.ToDouble(ds.Tables[0].Rows[i][38].ToString()) != 0.00)
                {
                    Ggrp = Grr3a;
                    Gdesc = "NPN";
                   
                    ren5 = ren5 + 1;
                    Gdesc1 = " ";
                    Gresult = ds.Tables[0].Rows[i][38].ToString();
                    Gunit = "mg/dl";
                    Gnormalrange = "25 - 40";
                    Gnormalrange1 = "";
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
                if (ren10 != 0.00 & ren20 != 0.00 & ren30 != 0 & ren40 != 0 & ren50 != 0 & ren60 != 0.00)
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

                    
                    tb = tb + 1;
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][39].ToString();
                    Gunit = "mg/dl";
                    Gnormalrange = "0.2 - 1.0";
                    Gnormalrange1 = "";
                    ADDROW();
                }
                if (Convert.ToDouble(ds.Tables[0].Rows[i][40].ToString()) != 0.00)
                {
                    Ggrp = Grf;
                    Gdesc = "DIRECT BILIRUBIN";
                    
                    db = db + 1;
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][40].ToString();
                    Gunit = "mg/dl";
                    Gnormalrange = "0.0 - 0.2";
                    Gnormalrange1 = "";
                    ADDROW();
                }
                if (Convert.ToDouble(ds.Tables[0].Rows[i][41].ToString()) != 0.00)
                {
                    Ggrp = Grf;
                    Gdesc = "INDIRECT BILIRUBIN";

                    
                    ib = ib + 1;
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

                    
                    sgot = sgot + 1;
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][42].ToString();
                    Gunit = "u/l";
                    Gnormalrange = "8 - 40";
                    Gnormalrange1 = "";
                    ADDROW();
                }

                if (Convert.ToDouble(ds.Tables[0].Rows[i][43].ToString()) != 0)
                {
                    Ggrp = Grf;
                    Gdesc = "S.G.P.T.";
                    
                    sgpt = sgpt + 1;
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][43].ToString();
                    Gunit = "u/l";
                    Gnormalrange = "5 - 35";
                    Gnormalrange1 = "";
                    ADDROW();
                }

                if (Convert.ToDouble(ds.Tables[0].Rows[i][44].ToString()) != 0)
                {
                    Ggrp = Grf;
                    Gdesc = "ALKALINE PHOSPHATASE";

                    
                    
                    ap = ap + 1;
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
                   
                    tp = tp + 1;
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][45].ToString();
                    Gunit = "g/dl";
                    Gnormalrange = "6.2 - 8.2";
                    Gnormalrange1 = "";
                    ADDROW();
                }
                if (Convert.ToDouble(ds.Tables[0].Rows[i][46].ToString()) != 0.00)
                {
                    Ggrp = Grf;
                    Gdesc = "ALBUMIN";
                    
                    alb = alb + 1;
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][46].ToString();
                    Gunit = "g/dl";
                    Gnormalrange = "3.5 - 5.0";
                    Gnormalrange1 = "";
                    ADDROW();
                }
                if (Convert.ToDouble(ds.Tables[0].Rows[i][47].ToString()) != 0.00)
                {
                    Ggrp = Grf;
                    Gdesc = "GLOBULIN";
                    
                    glob = glob + 1;
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
                    
                    agr = agr + 1;
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
                   
                    ggt = ggt + 1;
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
                    Gdesc = "SODIUM ";

                    
                    sod = sod + 1;
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
                    Gdesc = "POTASSIUM ";
                    
                    pot = pot + 1;
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
                    Gdesc = "CHLORIDES ";
                    
                    chl = chl + 1;
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
                    Gdesc = "CALCIUM ";
                    
                    cal = cal + 1;
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][53].ToString();
                    Gunit = "mg%";
                    Gnormalrange = "8.1 - 10.4";
                    Gnormalrange1 = "";
                    ADDROW();
                }

                if (Convert.ToDouble(ds.Tables[0].Rows[i][54].ToString()) != 0.00)
                {
                    Ggrp = Gre;
                    Gdesc = "PHOSPHORUS ";
                    
                    phos = phos + 1;
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][54].ToString();
                    Gunit = "mg%";
                    Gnormalrange = "A: 2.68 - 4.5";
                    Gnormalrange1 = "C: 4.0 - 6.5";
                    ADDROW();
                }


                //if (Convert.ToDouble(ds.Tables[0].Rows[i][56].ToString()) != 0.00)
                //{
                //    Ggrp = "";
                //    Gdesc = "Uric Acid";
                //    Gresult = ds.Tables[0].Rows[i][56].ToString();
                //    Gunit = "mg/dl";
                //    Gnormalrange = "2.5-7.0";
                //    ADDROW();
                //}

                if (Convert.ToDouble(ds.Tables[0].Rows[i][55].ToString()) != 0)
                {
                    Ggrp = "CARDIAC ( ENZYMES )";
                    Gdesc = "LDH";
                    Gdesc1 = "";
                    Gresult = ds.Tables[0].Rows[i][55].ToString();
                    Gunit = "U/L";
                    Gnormalrange = "313 - 618";
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
                    Gnormalrange = "M: 30 - 110";
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
            }

//end check biochemist




            if (ds.Tables[0].Rows.Count != 0)
            {
                String repdesc = "BIO-CHEMISTRY COUNTS";
                Reptestsummary cashbankrep = new Reptestsummary();
                //cashbankrep.SetDatabaseLogon("sa", "software", @".\sqlexpress", "pathology2627");
               // cashbankrep.SetDataSource(ds);

                cashbankrep.SetParameterValue(0, label4.Text);
                cashbankrep.SetParameterValue(1, repdesc);
                cashbankrep.SetParameterValue(2, dtf);
                cashbankrep.SetParameterValue(3, dtt);
                cashbankrep.SetParameterValue(4, fbs);
                cashbankrep.SetParameterValue(5, ppbs);
                cashbankrep.SetParameterValue(6, ppbs1);
                cashbankrep.SetParameterValue(7, rbs);
                cashbankrep.SetParameterValue(8, pbbs);
                cashbankrep.SetParameterValue(9, plbs);
                cashbankrep.SetParameterValue(10, gtt);

                //double fbs = 0; ppbs = 0; ppbs1 = 0; rbs = 0; pbbs = 0; plbs = 0;
                //double gtt = 0; pgbs = 0; hba1c = 0; mbge = 0; lip1 = 0; lip2 = 0;
                //double lip3 = 0; lip4 = 0; lip5 = 0; lip6 = 0; lip7 = 0; ren1 = 0;
                //double ren2 = 0; ren3 = 0; ren4 = 0; ren5 = 0; tb = 0; db = 0; ib = 0;
                //double sgot = 0; sgpt = 0; ap = 0; tp = 0; alb = 0; glob = 0; agr = 0; ggt = 0;
                //double sod = 0; pot = 0; chl = 0; cal = 0; phos = 0;

                cashbankrep.SetParameterValue(11, pgbs);
               
                cashbankrep.SetParameterValue(12, hba1c);
                cashbankrep.SetParameterValue(13, mbge);
                cashbankrep.SetParameterValue(14, lip1);
                cashbankrep.SetParameterValue(15, lip2);

                cashbankrep.SetParameterValue(16, lip3);
                cashbankrep.SetParameterValue(17, lip4);
                cashbankrep.SetParameterValue(18, lip5);
                cashbankrep.SetParameterValue(19, lip6);
                //double lip3 = 0; lip4 = 0; lip5 = 0; lip6 = 0; lip7 = 0; ren1 = 0;
                //double ren2 = 0; ren3 = 0; ren4 = 0; ren5 = 0; tb = 0; db = 0; ib = 0;
                //double sgot = 0; sgpt = 0; ap = 0; tp = 0; alb = 0; glob = 0; agr = 0; ggt = 0;
                //double sod = 0; pot = 0; chl = 0; cal = 0; phos = 0;
                cashbankrep.SetParameterValue(20, lip7);
                cashbankrep.SetParameterValue(21, ren1);
                cashbankrep.SetParameterValue(22, ren2);
                cashbankrep.SetParameterValue(23, ren3);
                cashbankrep.SetParameterValue(24, ren4);
                cashbankrep.SetParameterValue(25, ren5);
                cashbankrep.SetParameterValue(26, tb);
                cashbankrep.SetParameterValue(27, db);
                cashbankrep.SetParameterValue(28, ib);
                cashbankrep.SetParameterValue(29, sgot);
                cashbankrep.SetParameterValue(30, sgpt);
                cashbankrep.SetParameterValue(31, ap);
                cashbankrep.SetParameterValue(32, tp);
                cashbankrep.SetParameterValue(33, alb);
                cashbankrep.SetParameterValue(34, glob);
                cashbankrep.SetParameterValue(35, agr);

                cashbankrep.SetParameterValue(36, ggt);
                cashbankrep.SetParameterValue(37, sod);
                cashbankrep.SetParameterValue(38, pot);
                cashbankrep.SetParameterValue(39, chl);
                cashbankrep.SetParameterValue(40, cal);
                cashbankrep.SetParameterValue(41, phos);
                      
                
                
                
                crv.ReportSource = cashbankrep;
                
                
                
                crv.Refresh();
            }
            else
            {
                MessageBox.Show("No Records Found!!!");
            }
 
        }

        private void btnblood_Click(object sender, EventArgs e)
        {
            
            String repdesc="BLOOD COUNT REPORT";
            DateTime dtf, dtt;
            String dd = dtfrom.Text.Substring(0, 2).ToString();
            String mmm = this.dtfrom.Text.Substring(3, 2).ToString();
            String yy = this.dtfrom.Text.Substring(6, 4).ToString();
            dtf = DateTime.ParseExact(dd + "/" + mmm + "/" + yy, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            String dd1 = dtto.Text.Substring(0, 2).ToString();
            String mmm1 = this.dtto.Text.Substring(3, 2).ToString();
            String yy1 = this.dtto.Text.Substring(6, 4).ToString();
            dtt = DateTime.ParseExact(dd1 + "/" + mmm1 + "/" + yy1, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);



            //String s1 = ("select cc,type,blno,bldt,acdes,challan_no,challan_dt,gross,discount_rt,discount,vat_rt,vat,tamt from inv where bldt>= '" + Convert.ToDateTime(dtfrom.Text) + "' and bldt<= '" + Convert.ToDateTime(dtto.Text) + "' and cc='" + txtcompid.Text + "' and type='" + cbotype.Text + "' order by cc,type,bldt,blno");
            // String s1 = ("select cc,patient_name,pcode,sex,age,doctor,date_exam,Sp_color, Sp_reaction, Sp_Mucus, SM_rbc_from, SM_rbc_to, SM_puscells_from,SM_puscells_to,SM_macrophase,SM_vegetables,SM_fataglobules,SM_yeast,SM_crystal,SM_bacterialflora,SP_EHistolytica,SP_ecoli,SP_giardia,SP_trichomonas,SH_OvaHW,SH_OvaRW,SH_Others,SC_Occultblood,SC_Reducingsugar from patient_record where patient_name='" + cboname.Text + "' and date_exam= '" + Convert.ToDateTime(dtreport.Text) + "' order by pcode,date_exam");
            String strsql = "";
            //strsql = "select cc,patient_name,pcode,sex,age,doctor,date_exam,UP_color,UP_sediments,UP_reaction,UP_specificgravity,UC_sugar,UC_albumin,UC_phosphate,UC_chyle,UC_ketonebodies,UC_bilesalts,UC_bilepigment,UM_puscells,UM_epithcells,UM_rbc,UM_casts,UM_crystals,UM_bacterial,UM_spermatozoa,UM_mf_tv,UM_others,UU_urine_b_hcg,UA_urine_albumin,UN_nasalsmear,Us_SputumAfb, Sp_color, Sp_reaction, Sp_Mucus, SM_rbc_from, SM_rbc_to, SM_puscells_from,SM_puscells_to,SM_macrophase,SM_vegetables,SM_fataglobules,SM_yeast,SM_crystal,SM_bacterialflora,SP_EHistolytica,SP_ecoli,SP_giardia,SP_trichomonas,SH_OvaHW,SH_OvaRW,SH_Others,SC_Occultblood,SC_Reducingsugar,";
            //strsql = strsql + "BG_Blood_Group,BR_RhD_Typing,BDc_Neutrophild,BDc_Eosinophils,BDc_Lymphocytes,";
            //strsql = strsql + "BDc_Basophils,BDc_Monocytes,BDc_Twbc,BDc_Trbc,BDc_Tplatelets,BDc_Aec,BDc_Reticulocyte_Count,";
            //strsql = strsql + "BDc_PCV,BDc_Mp_ICT_QBC_Smear,BDc_Mf_ICT_QBC_Smear,BDc_Hb,BDc_ESR_1sthour,BDc_ESR_2ndhour,";
            //strsql = strsql + "BDc_Bleeding_Time,BDc_Clotting_Time,BDc_Sickle_cell,BPS_Toxo,BPS_Crp,BPS_Vdrl,";
            //strsql = strsql + "BPS_Rafactor,BPS_Aso,BS_Australia_Antigen,BS_Hepatitis_C_Virus,BS_HIV_1,BS_HIV_2,";
            //strsql = strsql + "BS_Ict_PF_PV,Bw_Widaltest,Bm_MontouxTest_injon,Bm_MontouxTest_readon,Bm_MontouxTest_induration,due_amount,paid_amount";


            //strsql = strsql + " from patient_record where patient_name='" + cboname.SelectedItem + "'  and date_exam= '" + Convert.ToDateTime(dtreport.Text) + "'";
            if (cboname.Text == "")
            {
                strsql = "select a.cc,a.patient_name,a.pcode,a.sex,a.age,a.doctor,a.date_exam,a.month_year,a.scn,a.tpt,";
                strsql = strsql + "b.cc,b.pcode,b.BG_Blood_Group,b.BR_RhD_Typing,b.BDc_Neutrophild,b.BDc_Lymphocytes,b.BDc_Eosinophils,b.BDc_Monocytes,b.BDc_Basophils,b.BDc_Twbc,b.BDc_Trbc,b.BDc_Tplatelets,";
                strsql = strsql + "b.BDc_Aec,b.BDc_Tnc,b.BDc_Reticulocyte_Count,b.BDc_PCV,b.BDC_mcv,b.BDC_mch,b.BDC_mchc,b.BDc_Mp_ICT_QBC_Smear,b.BDc_Mp_ICT,b.BDc_Mf_ICT_QBC_Smear,b.BDc_Mf_ICT,b.BDc_Hb,b.BDc_ESR_1sthour,b.BDc_ESR_2ndhour,";
                strsql = strsql + "b.BDc_Bleeding_Time,b.BDc_Clotting_Time,b.BDc_nasalsmear,b.BDc_nasalsmear_right,b.BDc_Sickle_cell,b.BDC_Prothombintime,b.BDC_Prothombintime_cont,b.BDC_Prothombintime_inr,";

                strsql = strsql + "b.BDC_pss,b.Bw_Widaltubeo80,b.Bm_MontouxTest_injon,b.BPS_Aso,b.BPS_Crp,b.BPS_Rafactor,b.BPS_Ana,b.BPS_Vdrl,b.BPS_Toxo,b.BS_Australia_Antigen,b.BS_Hepatitis_C_Virus,b.BS_HIV_1,b.BS_HIV_2,b.Bw_mycodot,b.bw_trop";
                strsql = strsql + " from patient_master a,Blood b where (a.pcode=b.pcode) and a.date_exam>= '" + dtf.ToString("yyyy-MM-dd") + "' and a.date_exam<= '" + dtt.ToString("yyyy-MM-dd") + "' order by a.pcode,a.date_exam";

                da = new SqlDataAdapter(strsql, con);
                ds = new DataSet();
                da.Fill(ds);
            }
            else
            {
                strsql = "select a.cc,a.patient_name,a.pcode,a.sex,a.age,a.doctor,a.date_exam,a.month_year,a.scn,a.tpt,";
                strsql = strsql + "b.cc,b.pcode,b.BG_Blood_Group,b.BR_RhD_Typing,b.BDc_Neutrophild,b.BDc_Lymphocytes,b.BDc_Eosinophils,b.BDc_Monocytes,b.BDc_Basophils,b.BDc_Twbc,b.BDc_Trbc,b.BDc_Tplatelets,";
                strsql = strsql + "b.BDc_Aec,b.BDc_Tnc,b.BDc_Reticulocyte_Count,b.BDc_PCV,b.BDC_mcv,b.BDC_mch,b.BDC_mchc,b.BDc_Mp_ICT_QBC_Smear,b.BDc_Mp_ICT,b.BDc_Mf_ICT_QBC_Smear,b.BDc_Mf_ICT,b.BDc_Hb,b.BDc_ESR_1sthour,b.BDc_ESR_2ndhour,";
                strsql = strsql + "b.BDc_Bleeding_Time,b.BDc_Clotting_Time,b.BDc_nasalsmear,b.BDc_nasalsmear_right,b.BDc_Sickle_cell,b.BDC_Prothombintime,b.BDC_Prothombintime_cont,b.BDC_Prothombintime_inr,";

                strsql = strsql + "b.BDC_pss,b.Bw_Widaltubeo80,b.Bm_MontouxTest_injon,b.BPS_Aso,b.BPS_Crp,b.BPS_Rafactor,b.BPS_Ana,b.BPS_Vdrl,b.BPS_Toxo,b.BS_Australia_Antigen,b.BS_Hepatitis_C_Virus,b.BS_HIV_1,b.BS_HIV_2,b.Bw_mycodot,b.bw_trop";
                strsql = strsql + " from patient_master a,Blood b where (a.pcode=b.pcode) and a.date_exam>= '" + dtf.ToString("yyyy-MM-dd") + "' and a.date_exam<= '" + dtt.ToString("yyyy-MM-dd") + "' and a.patient_name='" + cboname.Text + "' order by a.pcode,a.date_exam";

            }

            da = new SqlDataAdapter(strsql, con);
            ds = new DataSet();
            da.Fill(ds, "blood");
            int bg = 0; int rhd = 0; int dc = 0; int twbc = 0; int mpict = 0; int mfict = 0; int hb = 0; int esr = 0; int bt = 0; int ct = 0; int pss = 0; int wid = 0; int mont = 0;
            int aso = 0; int crp = 0; int raf = 0; int ana = 0; int vdrl = 0; int toxo = 0; int aa = 0; int hcv = 0; int hiv1 = 0; int hiv2 = 0; int mycodot = 0; int trop = 0;
            
            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
            {

                if (ds.Tables[0].Rows[k][12].ToString() != "")
                {
                    bg = bg + 1;
                }
                if (ds.Tables[0].Rows[k][13].ToString() != "")
                {
                     rhd = rhd + 1;
                }

                if (Convert.ToInt32(ds.Tables[0].Rows[k][14].ToString()) + Convert.ToInt32(ds.Tables[0].Rows[k][15].ToString()) + Convert.ToInt32(ds.Tables[0].Rows[k][16].ToString()) + Convert.ToInt32(ds.Tables[0].Rows[k][17].ToString()) !=0)
                {
                   dc = dc + 1;
                }
                if (Convert.ToInt32(ds.Tables[0].Rows[k][19].ToString()) != 0)
                {
                    twbc = twbc + 1;
                }
                if (ds.Tables[0].Rows[k][30].ToString() !="")
                {
                     mpict = mpict + 1;
                }
                if (ds.Tables[0].Rows[k][32].ToString() != "")
                {
                     mfict = mfict + 1;
                }

                if (Convert.ToDouble(ds.Tables[0].Rows[k][33].ToString()) != 0)
                {
                   hb = hb + 1;
                }
                if (Convert.ToDouble(ds.Tables[0].Rows[k][34].ToString()) != 0)
                {
                     esr = esr+ 1;
                }
                if (ds.Tables[0].Rows[k][36].ToString() != "")
                {
                    bt = bt + 1;
                }

                if (ds.Tables[0].Rows[k][37].ToString() != "")
                {
                    ct = ct + 1;
                }

                if (ds.Tables[0].Rows[k][44].ToString() != "")
                {
                     pss = pss + 1;
                }

                if (ds.Tables[0].Rows[k][45].ToString() != "")
                {
                    wid = wid + 1;
                }

                if (ds.Tables[0].Rows[k][46].ToString() != "")
                {
                    mont = mont + 1;
                }

               if (ds.Tables[0].Rows[k][47].ToString() != "")
                {
                    aso = aso + 1;
                }

                if (ds.Tables[0].Rows[k][48].ToString() != "")
                {
                    crp = crp + 1;
                }
                if (ds.Tables[0].Rows[k][49].ToString() != "")
                {
                    raf = raf + 1;
                }
                if (ds.Tables[0].Rows[k][50].ToString() != "")
                {
                    ana = ana + 1;
                }
                if (ds.Tables[0].Rows[k][51].ToString() != "")
                {
                    vdrl = vdrl + 1;
                }
                if (ds.Tables[0].Rows[k][52].ToString() != "")
                {
                    toxo = toxo + 1;
                }
                if (ds.Tables[0].Rows[k][53].ToString() != "")
                {
                    aa= aa + 1;
                }
                if (ds.Tables[0].Rows[k][54].ToString() != "")
                {
                    hcv = hcv + 1;
                }

                if (ds.Tables[0].Rows[k][55].ToString() != "")
                {
                    hiv1 = hiv1 + 1;
                }

                if (ds.Tables[0].Rows[k][56].ToString() != "")
                {
                    hiv2 = hiv2 + 1;
                }



                if (ds.Tables[0].Rows[k][57].ToString() != "")
                {
                    mycodot = mycodot + 1;
                }
                if (ds.Tables[0].Rows[k][58].ToString() != "")
                {
                    trop = trop + 1;
                }
                
            
            
            
            
            }



  
            
            
            
            if (ds.Tables[0].Rows.Count != 0)
                {
                    Repbloodsumm cashbankrep = new Repbloodsumm();
                    //cashbankrep.SetDatabaseLogon("sa", "software", @".\sqlexpress", "pathology2627");
                   // cashbankrep.SetDataSource(ds);
                   // crv.ReportSource = cashbankrep;

                    cashbankrep.SetParameterValue(0, label4.Text);
                    cashbankrep.SetParameterValue(1, repdesc);
                    cashbankrep.SetParameterValue(2, dtf);
                    cashbankrep.SetParameterValue(3, dtt);
                    cashbankrep.SetParameterValue(4, bg);
                    cashbankrep.SetParameterValue(5, rhd);
                    cashbankrep.SetParameterValue(6, dc);
                    cashbankrep.SetParameterValue(7, twbc);
                    cashbankrep.SetParameterValue(8, mpict);
                    cashbankrep.SetParameterValue(9, mfict);
                    cashbankrep.SetParameterValue(10, hb);
                    cashbankrep.SetParameterValue(11, esr);
                    //int bg = 0; int rhd = 0; int dc = 0; int twbc = 0; int mpict = 0;
                    //int mfict = 0; int hb = 0; 
                    //int esr = 0; int bt = 0; int ct = 0; int pss = 0;
                    cashbankrep.SetParameterValue(12, bt);
                    cashbankrep.SetParameterValue(13, ct);
                    cashbankrep.SetParameterValue(14, pss);
                    cashbankrep.SetParameterValue(15, wid);
                    cashbankrep.SetParameterValue(16, mont);
                    //int aso = 0; int crp = 0; int raf = 0; int ana = 0; int vdrl = 0; int toxo = 0; int aa = 0; int hcv = 0; int hiv1 = 0; int hiv2 = 0; int mycodot = 0; int trop = 0;       
                    cashbankrep.SetParameterValue(17, aso);
                    cashbankrep.SetParameterValue(18, crp);
                    cashbankrep.SetParameterValue(19, raf);
                    cashbankrep.SetParameterValue(20, ana);
                    cashbankrep.SetParameterValue(21, vdrl);

                    cashbankrep.SetParameterValue(22, toxo);
                    cashbankrep.SetParameterValue(23, aa);
                    cashbankrep.SetParameterValue(24, hcv);
                    cashbankrep.SetParameterValue(25, hiv1);
                    cashbankrep.SetParameterValue(26, hiv2);
                    cashbankrep.SetParameterValue(27, mycodot);
                    cashbankrep.SetParameterValue(28, trop);
                    crv.ReportSource = cashbankrep;
                
                crv.Refresh();
                }
                else
                {
                    MessageBox.Show("No Records Found!!!");
                }
 
        }

        private void btnurst_Click(object sender, EventArgs e)
        {
            String repdesc = "URINE & STOOL TEST COUNT";
            DateTime dtf, dtt;
            String dd = dtfrom.Text.Substring(0, 2).ToString();
            String mmm = this.dtfrom.Text.Substring(3, 2).ToString();
            String yy = this.dtfrom.Text.Substring(6, 4).ToString();
            dtf = DateTime.ParseExact(dd + "/" + mmm + "/" + yy, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            String dd1 = dtto.Text.Substring(0, 2).ToString();
            String mmm1 = this.dtto.Text.Substring(3, 2).ToString();
            String yy1 = this.dtto.Text.Substring(6, 4).ToString();
            dtt = DateTime.ParseExact(dd1 + "/" + mmm1 + "/" + yy1, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);



            //String s1 = ("select cc,type,blno,bldt,acdes,challan_no,challan_dt,gross,discount_rt,discount,vat_rt,vat,tamt from inv where bldt>= '" + Convert.ToDateTime(dtfrom.Text) + "' and bldt<= '" + Convert.ToDateTime(dtto.Text) + "' and cc='" + txtcompid.Text + "' and type='" + cbotype.Text + "' order by cc,type,bldt,blno");
            // String s1 = ("select cc,patient_name,pcode,sex,age,doctor,date_exam,Sp_color, Sp_reaction, Sp_Mucus, SM_rbc_from, SM_rbc_to, SM_puscells_from,SM_puscells_to,SM_macrophase,SM_vegetables,SM_fataglobules,SM_yeast,SM_crystal,SM_bacterialflora,SP_EHistolytica,SP_ecoli,SP_giardia,SP_trichomonas,SH_OvaHW,SH_OvaRW,SH_Others,SC_Occultblood,SC_Reducingsugar from patient_record where patient_name='" + cboname.Text + "' and date_exam= '" + Convert.ToDateTime(dtreport.Text) + "' order by pcode,date_exam");
            String strsql = "";
        

            //strsql = strsql + " from patient_record where patient_name='" + cboname.SelectedItem + "'  and date_exam= '" + Convert.ToDateTime(dtreport.Text) + "'";
            if (cboname.Text == "")
            {
                strsql = "select a.cc,a.patient_name,a.pcode,a.sex,a.age,a.doctor,a.date_exam,a.month_year,a.scn,a.tpt,b.pcode, b.UP_color";
               
                strsql = strsql + " from patient_master a,URINE b where (a.pcode=b.pcode) and a.date_exam>= '" + dtf.ToString("yyyy-MM-dd") + "' and a.date_exam<= '" + dtt.ToString("yyyy-MM-dd") + "' order by a.pcode,a.date_exam";

               
            }
            else
            {
                strsql = "select a.cc,a.patient_name,a.pcode,a.sex,a.age,a.doctor,a.date_exam,a.month_year,a.scn,a.tpt,";
                strsql = strsql + "b.cc,b.pcode,b. UP_color";
                
                strsql = strsql + " from patient_master a,urine b where (a.pcode=b.pcode) and a.date_exam>= '" + dtf.ToString("yyyy-MM-dd") + "' and a.date_exam<= '" + dtt.ToString("yyyy-MM-dd") + "' and a.patient_name='" + cboname.Text + "' order by a.pcode,a.date_exam";

            }

            da = new SqlDataAdapter(strsql, con);
            ds3 = new DataSet();
            da.Fill(ds3, "urine");
            int urcn = 0;
        if (ds3.Tables [0].Rows .Count !=0)
        {
           urcn = ds3.Tables[0].Rows.Count;
        }
        da.Dispose();

        if (cboname.Text == "")
        {
            strsql = "select a.cc,a.patient_name,a.pcode,a.sex,a.age,a.doctor,a.date_exam,a.month_year,a.scn,a.tpt,b.pcode, b.Sp_color";
            strsql = strsql + " from patient_master a,stool b where (a.pcode=b.pcode) and a.date_exam>= '" + dtf.ToString("yyyy-MM-dd") + "' and a.date_exam<= '" + dtt.ToString("yyyy-MM-dd") + "' order by a.pcode,a.date_exam";
        }
        else
        {
                strsql = "select a.cc,a.patient_name,a.pcode,a.sex,a.age,a.doctor,a.date_exam,a.month_year,a.scn,a.tpt,";
                strsql = strsql + "b.cc,b.pcode,b.SP_color";
                
                strsql = strsql + " from patient_master a,stool b where (a.pcode=b.pcode) and a.date_exam>= '" + dtf.ToString("yyyy-MM-dd") + "' and a.date_exam<= '" + dtt.ToString("yyyy-MM-dd") + "' and a.patient_name='" + cboname.Text + "' order by a.pcode,a.date_exam";

            }

            da = new SqlDataAdapter(strsql, con);
            ds4 = new DataSet();
            da.Fill(ds4, "stool");
            int stcn = 0;
            if (ds4.Tables[0].Rows.Count != 0)
            {
                stcn = ds4.Tables[0].Rows.Count;
            }
            da.Dispose();

            MessageBox.Show("urine count= "+urcn+" Stool count= "+stcn);


        
        
        }
    }
}
