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
    public partial class Frmrepsugar : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        SqlDataReader dr;
        public Frmrepsugar()
        {
            InitializeComponent();
        }

        private void Frmrepsugar_Load(object sender, EventArgs e)
        {
            //con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Pathology;Persist Security Info=True;User ID=sa;Password=software;");
            //con.Open();
            Class1 objclass = new Class1();
            con = new SqlConnection(objclass.arun_con());

            con.Open();
            
            cmd = new SqlCommand("select cc,comp,year_start,year_end from setup");
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //this.txtcompid.Text = dr.GetValue(0).ToString();
                //label4.Text = dr.GetValue(1).ToString();
              dtfrom.Text = dr.GetValue(2).ToString();
            }
            dr.Close();
            // cbotype.Items.Add("Sale");
            da = new SqlDataAdapter("select  patient_name,pcode from patient_master order by patient_name", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                this.cboname.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        
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

                strsql = strsql + " from patient_master a,biochemist b where a.pcode=b.pcode and  a.date_exam>= '" + dtf.ToString("yyyy-MM-dd") + "' and a.date_exam<= '" + dtt.ToString("yyyy-MM-dd") + "' order by a.patient_name";

               

                
                
                //strsql = " select * from Biochemist where date_exam>= '" + dtf+ "' and date_exam<= '" + dtt.ToString("yyyy-MM-dd") + "' order by pcode,date_exam";
            }
            else
            {
                strsql = "select a.cc,a.patient_name,a.pcode,a.sex,a.age,a.doctor,a.date_exam,a.month_year,a.Scn,a.Tpt,";
                strsql = strsql + "b.cc,b.pcode,b.Bcr1_Glucose_Fpg_RPG,b.Bcr1_PPPG_PGPG_2hr,b.Bcr1_PPPG_PGPG_1hr,b.Bcr1_RBS,b.Bcr1_PBBS,b.Bcr1_PLBS,b.Bcr1_GTT_1hr,b.Bcr1_GTT_2hr,b.Bcr1_GTT_3hr,b.Bcr1_PGBS_1hr,b.Bcr1_PGBS_2hr,b.Bcr1_HBAC_good,b.Bcr1_HBAC_fair,b.Bcr1_HBAC_poor, b.Bcr1_MBGE,b.Bcr_LP_Triglycerides,b.Bcr_LP_Cholesterol,b.Bcr_LP_HDLCholesterol,";
                strsql = strsql + "b.Bcr_LP_LDLCholesterol,b.Bcr_LP_VLDLCholesterol,b.Bcr2_LP_CHR,b.Bcr2_LP_LHR,b.Bcr_RP_Urea,b.Bcr_RP_Creatinine,b.Bcr3_Uric_Acid,b.Bcr_RP_BUN,b.Bcr3_NPN,b.Bcr_LFT_Bilirubin_total,b.Bcr_LFT_Bilirubin_Direct,b.Bcr4_LFT_Indirect,";
                strsql = strsql + "b.Bcr_LFT_SGOT_AST,b.Bcr_LFT_SGPT_ALT,b.Bcr_LFT_Alkaline_Phosphates,b.Bcr_LFT_Protein,b.Bcr_LFT_Albumin,b.Bcr_LFT_Globulin,b.Bcr_LFT_AG_Ratio,b.Bcr4_LFT_GGTP,b.Bcr_Electrolyte_Sodium,";
                strsql = strsql + "b.Bcr_Electrolyte_Potassium,b.Bcr5_Electrolyte_Chlorides,b.Bcr_OTH_Acid_Calcium,b.Bcr_OTH_Acid_Phosphorus,b.Bcr_OTH_Uric_Acid,b.Bcr_OTH_Pasting_urine_sugar,b.Bcr_OTH_Amylase,b.Bcr_OTH_Acid_Phosphate,b.Bcr_OTH_PP_PG_urine_sugar";

                strsql = strsql + " from patient_master a,biochemist b where a.pcode=b.pcode and  a.date_exam>= '" + dtf.ToString("yyyy-MM-dd") + "' and a.date_exam<= '" + dtt.ToString("yyyy-MM-dd") + "' and a.patient_name='" + cboname.Text + "' order by a.patient_name";
 
                
                
                //strsql = " select * from Biochemist where date_exam>= '" +dtf + "' and date_exam<= '" + dtt.ToString("yyyy-MM-dd") + "' and patient_name='" + cboname.Text + "' order by pcode,date_exam";
            }

            da = new SqlDataAdapter(strsql, con);
            ds = new DataSet();
            da.Fill(ds, "Biochemist");
            
            
            if (ds.Tables[0].Rows.Count != 0)
            {
                //cashbankrep = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                //cashbankrep.Load("/Hope_account/Hope_account/repcash_Bank.rpt");
                //if (chkmontouxwidal.Checked)
                //{
                Repsugar cashbankrep = new Repsugar();

                cashbankrep.SetDatabaseLogon("sa", "software", @".\sqlexpress", "pathology2627");
                cashbankrep.SetDataSource(ds);
                crv.ReportSource = cashbankrep;
                // cashbankrep.SetParameterValue(0, ds.Tables[0].Rows[0][62].ToString());
                // cashbankrep.SetParameterValue(1, ds.Tables[0].Rows[0][63].ToString());

                //}
                //else
                // {
                //    Repblood cashbankrep = new Repblood();

                //    cashbankrep.SetDatabaseLogon("sa", "software", @".\sqlexpress", "pathology2627");
                //   cashbankrep.SetDataSource(ds);
                //   crv.ReportSource = cashbankrep;
                //  cashbankrep.SetParameterValue(0, ds.Tables[0].Rows[0][62].ToString());
                //  cashbankrep.SetParameterValue(1, ds.Tables[0].Rows[0][63].ToString());
                ////cashbankrep.SetParameterValue(2, clbal);
                //cashbankrep.SetParameterValue(2, cbotype.Text);
                //cashbankrep.SetParameterValue(3, label4.Text);
                // }
                crv.Refresh();
            }
            else
            {
                MessageBox.Show("No Records Found!!!");
            }
 
        }
    }
}