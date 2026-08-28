using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Reflection;
using System.Threading;
using System.Data.SqlClient;
using System.IO;
//using Microsoft.Office.Interop.Word;
//using Word = Microsoft.Office.Interop.Word;
namespace Pathology
{
    public partial class Frmresultentry : Form
    {
        SqlConnection con;
        DataSet ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds10, ds11, ds12, ds13, ds14,ds15,ds16,ds17;
        DataSet dsru1;
        SqlDataAdapter da, da1;
        SqlCommand cmd,cmd1;
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
        public static int pidr=0;
        public static int tag = 0;
        int i = 0;
        public string dd, mm, yy;
        public static DateTime repdt1;

        public static string  pat_name="";
        //public static string cbo = "";
        ToolTip t = new ToolTip();


        public static int rpcode_del_tag = Frmpassword.pcode_del_tag;
        public static String ruserid1 = Frmpassword.userid1;
        public static String rpasswd1 = Frmpassword.passwd1;
        public static String rusrname1 = Frmpassword.usrname1;
        public static String rusrtype1 = Frmpassword.usrtype1;

        String sSelectedFolder = "";
        String sSelectedFile = "";
        
        public Frmresultentry()
        {
            InitializeComponent();
            //timer1.Start();
            //e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == 8);
            this.cbopcode.KeyPress += new KeyPressEventHandler(cbopcode_KeyPress);

        }
     
        
        
        private void Frmresultentry_Load(object sender, EventArgs e)
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
            da = new SqlDataAdapter("select pcode,patient_name from patient_Master order by pcode", con);
            DataSet ds = new DataSet();
            da.Fill(ds,"patient_master");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                this.cbopcode.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                this.cboname.Items.Add(ds.Tables[0].Rows[i][1].ToString());
            }
            da.Dispose();


           // da = new SqlDataAdapter("select pcode from patient_Master order by pcode", con);
            //
          //DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
           // da.Fill(dt);

            //DataRow row = dt.NewRow();
           // row[0] = 0;
            //row[1] = "select";
            //dt.Rows.InsertAt(row,0);

            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //


               // this.cbopcode.DataSource = dt;
                //cbopcode.DisplayMember="pcode";
            //cbopcode.ValueMember="pcode";
                    //this.cboname.Items.Add(ds.Tables[0].Rows[i][1].ToString());
            //}
            da.Dispose();

            da = new SqlDataAdapter("select max(pcode) from patient_Master", con);
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
                dgvbilltest.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            da.Dispose();

            da = new SqlDataAdapter("select test,method,unit,reference_range from test_master order by test",con);
            ds = new DataSet();
            da.Fill(ds, "test_master");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                grtestmast.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                dgvostest.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                dgvostestos.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                dgvsertest.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                dgvhormonetest.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }

            da = new SqlDataAdapter("select test from CULTURE_master order by test", con);
            ds = new DataSet();
            da.Fill(ds, "CULTURE_master");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dgcult.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                dgculs.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                dgculv.Items.Add(ds.Tables[0].Rows[i][0].ToString());
               
            }

            da.Dispose();

            da = new SqlDataAdapter("select test from CULTURE_type order by test", con);
            ds = new DataSet();
            da.Fill(ds, "CULTURE_type");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cbons.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            da.Dispose();
            da = new SqlDataAdapter("select test from CULTURE_organism order by test", con);
            ds = new DataSet();
            da.Fill(ds, "CULTURE_organism");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Cu_Organism_isolated1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            da.Dispose();

            da = new SqlDataAdapter("select test from CULTURE_colonycount order by test", con);
            ds = new DataSet();
            da.Fill(ds, "CULTURE_colonycount");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cbocolonycount.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            da.Dispose();
            SqlDataAdapter adapter = new SqlDataAdapter("select grp,sgrp from Group_master order by grp", con);
            ds = new DataSet();
            adapter.Fill(ds, "Group_master");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cboprofilename.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                
            }
            adapter.Dispose();


            da.Dispose();
            da = new SqlDataAdapter("select cc,comp,address,year_start,year_end,pathologist,biochemist,telphoneno,email,cstno,address1,faxno from company", con);
            ds2 = new DataSet();
            da.Fill(ds2);
            da.Dispose();
            con.Close();
            cbosex.Items.Add("Male");
            cbosex.Items.Add("Female");
            cbosex.Items.Add("Mch");
            cbosex.Items.Add("Fch");

            cbomy1.Items.Add("Months");
            cbomy1.Items.Add("Yrs.");
            cbomy1.Items.Add("Days");
            cbomy1.Text ="Yrs.";
            
            
            txtage.Text = "";
            txtdue.Text = "0.00";
            txtpaid.Text = "0.00";

            UP_color.Text = "Pale Yellow";
            // UP_sediments.Text = ds2.Tables[0].Rows[0][3].ToString();
            UP_reaction.Text = "Acidic";
            UP_specificgravity.Text = "10mL";
            //chkspecificgravity.Text = ds.Tables[0].Rows[0][11].ToString();
            UC_sugar.Text = "Nil";
            UC_albumin.Text = "Nil";
            UC_phosphate.Text = "Nil";
            //chkphosphate.Text = "";
            UC_chyle.Text = "Nil";
            //chkchyle.Text = "";
            UC_ketonebodies.Text = "";
            //chkketonebodies.Text ="";
            UC_bilesalts.Text = "";
            //chkbilesalts.Text = "";
            UC_bilepigment.Text = "";
            // chkbilepigment.Text = ds.Tables[0].Rows[0][23].ToString();
            UM_puscells.Text = "0-1";
            UM_epithcells.Text = "1-2";
            UM_rbc.Text = "Nil";
            UM_casts.Text = "Nil";
            UM_crystals.Text = "Nil";
            UM_bacterial.Text = "Nil";
            UM_spermatozoa.Text = "Nil";
            UM_mf_tv.Text = "";
            UM_others.Text = "";
            UU_urine_b_hcg.Text = "";
            UA_urine_albumin.Text = "";
            BDc_Nasalsmear.Text = "";
            ur_imp.Text = "";
            txtmicrofilaria.Text = "";
            Ur_spgr.Text = "";
            Ur_php.Text = "";
            Ur_urobil.Text = "";
            Ur_benzodine.Text = "";
            
            //sto0l start
            Sp_color.Text = "Brownish";
            Sp_reaction.Text = "Acidic";
            SP_mucus.Text = "Present(+)";
            SM_rbc_from.Text = "Nil";
            //SM_rbc_to.Text = "";
            SM_puscells_from.Text = "0-1";
            //SM_puscells_to.Text = "";
            SM_macrophase.Text = "Nil";
            SM_vegetables.Text = "Present(+)";
            SM_fatglobules.Text = "Nil";
            SM_yeast.Text = "Nil";
            SM_crystal.Text = "Semi Solid";
            SM_bacterialflora.Text = "Adequate";
            SP_EHistolytica.Text = "Nil";
            SP_ecoli.Text = "Nil";
            SP_giardia.Text = "Nil";
            SP_trichmonas.Text = "Nil";
            SH_OvaHW.Text = "Nil";
            SH_Larva.Text = "Nil";
            SH_OvaRW.Text = "Nil";
            SM_other_crystal.Text = "";
            SC_Occultblood.Text = "xxxx";
            SC_Reducingsugar.Text = "xxxx";
            st_imp1.Text = "";

            SH_hymene.Text = "2-3";
            SH_crystal1.Text = "";

            
            
            
            
            //stools end
            
            
            BDc_Neutrophild.Text = "0";
            BDc_Eosinophils.Text = "0";
            BDc_Lymphocytes.Text = "0";
            BDc_Basophils.Text = "0";
            BDc_Monocytes.Text = "0";
            BDc_Twbc.Text = "0";
            BDc_Trbc.Text = "0";
            BDc_Tplatelets.Text = "0";
            BDc_Aec.Text = "0";
            BDc_Reticulocyte_Count.Text = "0";
            BDc_Tnc.Text = "0";
            BDc_PCV.Text = "0";
            BDCmcv.Text = "0";
            BDCmch.Text = "0";
            BDCmchc.Text = "0";
            BDc_Rct.Text = "0";
            BDc_Hb.Text = "0";
           
            BDc_ESR_1sthour.Text = "0";
            BDc_ESR_2ndhour.Text = "0";
            
            Bcr1_Glucose_Fpg_RPG.Text = "0";
            Bcr1_PPPG_PGPG_2hr.Text = "0";
            Bcr1_PPPG_PGPG_1hr.Text = "0";
            Bcr1_RBS.Text = "0";


            Bcr1_PBBS.Text = "0";
            Bcr1_PLBS.Text = "0";
            Bcr1_GTT_1hr.Text = "0";
            Bcr1_GTT_2hr.Text = "0";
            Bcr1_GTT_3hr.Text = "0";
            Bcr1_PGBS_1hr.Text = "0";
            Bcr1_PGBS_2hr.Text = "0";
            Bcr1_HBAC_good.Text = "0";
            Bcr1_HBAC_fair.Text = "0";
            Bcr1_HBAC_poor.Text = "0";
            Bcr1_MBGE.Text = "0";

            //RE_urea.Text = "0";
            Bcr_RP_Urea.Text = "0";
            Bcr_RP_BUN.Text = "0";
            Bcr_RP_Creatinine.Text = "0";
            //RE_creatinine.Text = "0.00";
            Bcr3_Uric_Acid.Text = "0";
            Bcr3_NPN.Text = "0";
            //Bc1_fbs.Text = "0";
            //Bc1_ppbs1.Text = "0";
            //Bc1_ppbs2.Text = "0";
            //Bc2_fbs.Text = "0";
            ////RE_fbs.Text = "0";
            //Bc2_ppbs1.Text = "0";
            //Bc2_ppbs2.Text = "0";
            //Bc2_urea.Text = "0";
            //Bc2_uric_acid.Text = "0";
            //Bc2_creatinine.Text = "0.00";
            //Bc3_fbs.Text = "0";
            //Bc3_cholesterol.Text = "0.00";
            //Bc3_creatinine.Text = "0.00";
            //Bc3_hdl.Text = "0.00";
            //Bc3_ldl.Text = "0.00";
            //Bc3_ppbs1.Text = "0";
            //Bc3_ppbs2.Text = "0";
            //Bc3_triglyceride.Text = "0.00";
            //Bc3_urea.Text = "0";
            //Bc3_uric_acid.Text = "0";
            //Bc3_vldl.Text = "0.00";

            Bcr_LP_Cholesterol.Text = "0.00";
            Bcr_LP_HDLCholesterol.Text = "0.00";
            Bcr_LP_LDLCholesterol.Text = "0.00";
            Bcr_LP_VLDLCholesterol.Text = "0.00";
            Bcr_LP_Triglycerides.Text = "0.00";

            Bcr2_LP_CHR.Text = "0.00";
            Bcr2_LP_LHR.Text = "0.00";
            Bcr_LFT_Bilirubin_total.Text = "0.00";
            Bcr_LFT_Bilirubin_Direct.Text = "0.00";
            Bcr4_LFT_Indirect.Text = "0.00";

            Bcr_LFT_Alkaline_Phosphates.Text = "0";
            Bcr_LFT_SGOT_AST.Text = "0";
            Bcr_LFT_SGPT_ALT.Text = "0";
            Bcr_LFT_Albumin.Text = "0.00";
            Bcr_LFT_Protein.Text = "0.00";
            Bcr_LFT_Globulin.Text = "0.00";
            Bcr_LFT_AG_Ratio.Text = "0.00";
            Bcr4_LFT_GGTP.Text = "0.00";

            Bcr_Electrolyte_Sodium.Text = "0";
            Bcr_Electrolyte_Potassium.Text = "0.00";
            Bcr5_Electrolyte_Chlorides.Text = "0.00";

            Bcr_OTH_Acid_Phosphate.Text = "0";
            Bcr_OTH_Amylase.Text = "0";
            Bcr_OTH_Acid_Calcium.Text = "0.00";
            Bcr_OTH_Acid_Phosphorus.Text = "0.00";
            Bcr_OTH_Uric_Acid.Text = "0.00";
            Bcr_OTH_Pasting_urine_sugar.Text = "0";
            Bcr_OTH_PP_PG_urine_sugar.Text = "0";

            Bcr_OTH_Lipase.Text = "0";
            Bcr_OTH_nac.Text = "0";
            FA_MP_Deformed.Text = "";
            FA_MT_Active.Text = "0";
            FA_MT_Slugish.Text = "0";
            FA_MT_Dead.Text = "0";
            FA_MT_Totalcount.Text = "0";
            FA_MP_Prostaticpearls.Text = "";
            FA_MP_Premature.Text = "";
            cboiv.Text = "";
            TOTAL_TRIIODOTHYRONINE_T3.Text = "0";
            TOTAL_THYROXINE_T4.Text = "0";
            TSH.Text = "0";
            FREE_TRIIODOTHYRONINE_FT3.Text = "0";
            FREE_THYROXINE_FT4.Text = "0";
            ANTIMICROSOMAL_ANTIBODY_AMA.Text = "0";
            TOTAL_CHOLESTEROL.Text = "0";
            PROLACTIN_PRL.Text = "0";
            PROSTATESPECIFICANTIGEN_PSA.Text = "0";
            ADENOSINE_DEAMINASE.Text = "0";
            ANTITUBERCULOSIS_TB_IgG.Text = "0";
            ANTITUBERCULOSIS_TB_IgM.Text = "0";
            ANTITUBERCULOSIS_TB_IgA.Text = "0";
            BHCG.Text = "0";
            CA_125.Text = "0";
            ANA.Text = "0";
            BDcRcdw.Text = "0";
            BDCmpv.Text = "0";
            BDCpdw.Text = "0";
            SBPS_Aso_Qty.Text = "0";
            SBPS_Crp_Qty.Text = "0";
            SBPS_Rafactor_Qty.Text = "0";
            SBS_trop_Qty.Text = "0";
            dataGridView1.Visible = false;
            crystalReportViewer1.Visible = false;
            btnclosecrv.Visible = false;
            crystalReportViewer2.Visible = false;
            btnclosestoolcrvn.Visible = false;
            crystalReportViewer3.Visible = false;
            crystalReportViewer4.Visible = false;
            btnclosebloodcrv.Visible = false;
            rmdelete.Enabled = false;
            RMMERGE.Enabled = false;
            reentry.Enabled = false;
            dgvbill.Visible = false;
            dgvbill1.Visible = false;
            dgvbloodnewtest.Visible = false;
            dgvbiochemext.Visible = false;
           
            dgvser.Visible = false;
            dgvhormonenew.Visible = false;
            dgvurine.Visible = false;
          
            //RMBILLING.Enabled = false;
            RMBILLING.Enabled = false;
        
        //t.Show("M:12-18 F:11-16", BDc_Hb);
        //t.Show("M:12-18 F:11-16", BDc_Hb);
        //t.SetToolTip(this.BDc_Hb, "M:12-18 F:11-16");
        //private void BDc_Hb_MouseHover(object sender, EventArgs e)
        //{
        //    t.Show("M:12-18 F:11-16", BDc_Hb);
        //}



            //string filePath = Server.MapPath("APP_DATA/offer.docx");


            txtoperator.Text = rusrname1;
        
        
        
        }
       
        private void btnsaveurine_Click(object sender, EventArgs e)
        {
            String Sqlstr0 = "";
            String Sqlstr = "";
            con.Close();
            con.Open();

            if (MessageBox.Show("Save ? ", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                String strsql2 = "";
                strsql2 = "select cc,pcode,UP_color,UP_reaction,UP_specificgravity,UC_sugar,UC_albumin,UC_phosphate,UC_chyle,UC_ketonebodies,UC_bilesalts,UC_bilepigment,UM_puscells,UM_epithcells,UM_rbc,UM_casts,UM_crystals,UM_bacterial,UM_spermatozoa,UM_mf_tv,UM_others,UU_urine_b_hcg,UA_urine_albumin,UN_nasalsmear";
                strsql2 = strsql2 + " from Urine where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
                da = new SqlDataAdapter(strsql2, con);
                ds2 = new DataSet();
                da.Fill(ds2);


                if (ds2.Tables[0].Rows.Count == 0)
                {
                    Sqlstr0 = "insert into Urine (cc,pcode,UP_color,UP_reaction,UP_specificgravity,UC_sugar,UC_albumin,UC_phosphate,UC_chyle,UC_ketonebodies,UC_bilesalts,UC_bilepigment,UM_puscells,UM_epithcells,UM_rbc,UM_casts,UM_crystals,UM_bacterial,UM_spermatozoa,UM_mf_tv,UM_others,UU_urine_b_hcg,UA_urine_albumin,UN_nasalsmear ,ur_imp,ur_cotinine,up_specificgravity_onr,UC_php,US_SputumAfb,UC_Phosphate_onr) values('" + Convert.ToInt32(txtcompanycode.Text) + "','" + Convert.ToInt32(cbopcode.Text);

                    Sqlstr0 = Sqlstr0 + "','" + UP_color.Text;
                    Sqlstr0 = Sqlstr0 + "','" + UP_reaction.Text + "','" + UP_specificgravity.Text;
                    Sqlstr0 = Sqlstr0 + "','" + UC_sugar.Text + "','" + UC_albumin.Text;
                    Sqlstr0 = Sqlstr0 + "','" + UC_phosphate.Text + "','" + UC_chyle.Text;
                    Sqlstr0 = Sqlstr0 + "','" + UC_ketonebodies.Text + "','" + UC_bilesalts.Text;
                    Sqlstr0 = Sqlstr0 + "','" + UC_bilepigment.Text + "','" + UM_puscells.Text;
                    Sqlstr0 = Sqlstr0 + "','" + UM_epithcells.Text + "','" + UM_rbc.Text;
                    Sqlstr0 = Sqlstr0 + "','" + UM_casts.Text + "','" + UM_crystals.Text;
                    Sqlstr0 = Sqlstr0 + "','" + UM_bacterial.Text + "','" + UM_spermatozoa.Text;
                    Sqlstr0 = Sqlstr0 + "','" + UM_mf_tv.Text + "','" + UM_others.Text;
                    Sqlstr0 = Sqlstr0 + "','" + UU_urine_b_hcg.Text + "','" + UA_urine_albumin.Text;
                    Sqlstr0 = Sqlstr0 + "','" + BDc_Nasalsmear.Text + "','" + ur_imp.Text + "','" + txtmicrofilaria.Text + "','" + Ur_spgr.Text + "','" + Ur_php.Text + "','" + Ur_urobil.Text + "','" + Ur_benzodine.Text + "')";
                    cmd = new SqlCommand(Sqlstr0, con);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    Sqlstr = "";
                    Sqlstr = "update Urine set cc='" + Convert.ToInt32(txtcompanycode.Text) + "',pcode='" + Convert.ToInt32(cbopcode.Text);

                    Sqlstr = Sqlstr + "',UP_color='" + UP_color.Text;
                    Sqlstr = Sqlstr + "',UP_reaction='" + UP_reaction.Text + "',UP_specificgravity='" + UP_specificgravity.Text;
                    Sqlstr = Sqlstr + "',UC_sugar='" + UC_sugar.Text + "',UC_albumin='" + UC_albumin.Text;
                    Sqlstr = Sqlstr + "',UC_phosphate='" + UC_phosphate.Text + "',UC_chyle='" + UC_chyle.Text;
                    Sqlstr = Sqlstr + "',UC_ketonebodies='" + UC_ketonebodies.Text + "',UC_bilesalts='" + UC_bilesalts.Text;
                    Sqlstr = Sqlstr + "',UC_bilepigment='" + UC_bilepigment.Text + "',UM_puscells='" + UM_puscells.Text;
                    Sqlstr = Sqlstr + "',UM_epithcells='" + UM_epithcells.Text + "',UM_rbc='" + UM_rbc.Text;
                    Sqlstr = Sqlstr + "',UM_casts='" + UM_casts.Text + "',UM_crystals='" + UM_crystals.Text;
                    Sqlstr = Sqlstr + "',UM_bacterial='" + UM_bacterial.Text + "',UM_spermatozoa='" + UM_spermatozoa.Text;
                    Sqlstr = Sqlstr + "',UM_mf_tv='" + UM_mf_tv.Text + "',UM_others='" + UM_others.Text;
                    Sqlstr = Sqlstr + "',UU_urine_b_hcg='" + UU_urine_b_hcg.Text + "',UA_urine_albumin='" + UA_urine_albumin.Text;
                    Sqlstr = Sqlstr + "',UN_nasalsmear='" + BDc_Nasalsmear.Text + "',ur_imp='" + ur_imp.Text + "', ur_cotinine='" + txtmicrofilaria.Text;
                    Sqlstr = Sqlstr + "',up_specificgravity_onr='" + Ur_spgr.Text + "',UC_php='" + Ur_php.Text + "',US_SputumAfb='" + Ur_urobil.Text + "',UC_Phosphate_onr='" + Ur_benzodine.Text;
                   // '" + Ur_spgr.Text + "','" + Ur_php.Text + "','" + Ur_urobil.Text + "','" + Ur_benzodine.Text + "'
                        
                        //Sqlstr = Sqlstr + "' where pcode='" + Convert.ToInt32(txtpcode.Text) + "' and age='" + Convert.ToInt32(txtage.Text) + "' and date_exam='" + this.dtreport.Text+"'";
                    Sqlstr = Sqlstr + "'  where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";

                    cmd = new SqlCommand(Sqlstr, con);
                    cmd.ExecuteNonQuery();
                }
                Sqlstr0 = "";
                Sqlstr = "";
                strsql2 = "";
                da.Dispose();
                strsql2 = " delete  from Urineext where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
                cmd = new SqlCommand(strsql2, con);
                cmd.ExecuteNonQuery();
                strsql2 = "";
                for (int u = 0; u < dgvurine.Rows.Count;u++ )
                {
                    if (dgvurine.Rows[u].Cells[0].Value != null)
                    {
                        strsql2 = "insert into Urineext (pcode,test,method,result,unit,normal_range) values ('" + Convert.ToInt32(cbopcode.Text) + "','" + dgvurine.Rows[u].Cells[0].Value + "','" + dgvurine.Rows[u].Cells[1].Value + "','" + dgvurine.Rows[u].Cells[2].Value + "','" + dgvurine.Rows[u].Cells[3].Value + "','" + dgvurine.Rows[u].Cells[4].Value + "')";
                        cmd = new SqlCommand(strsql2, con);
                        cmd.ExecuteNonQuery();
                    }
                    }
            
            
            }
        }

        private void btnsavemaster_Click(object sender, EventArgs e)
        {
           
        }

        private void btnsavestool_Click(object sender, EventArgs e)
        {
            String Sqlstr = "";
            con.Close();
            con.Open();

            if (MessageBox.Show("Save ? ", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                String strsql3 = "";
                strsql3 = "select cc,pcode, Sp_color, Sp_reaction,Sp_Mucus,SH_OvaHW,SH_larva,SH_OvaRW,SP_EHistolytica,SP_ecoli,SP_giardia,SP_trichomonas, SM_rbc_from, SM_puscells_from,SM_macrophase,SM_vegetables,SM_yeast,SM_crystal,SM_bacterialflora,SH_Others,SC_Occultblood,SC_Reducingsugar,st_imp,SH_hymen,SH_taenia";
                strsql3 = strsql3 + " from Stool where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";

               
                da = new SqlDataAdapter(strsql3, con);
                ds3 = new DataSet();
                da.Fill(ds3);

                if (ds3.Tables[0].Rows.Count == 0)
                {
                   
                    Sqlstr = "insert into Stool (cc,pcode, Sp_color, Sp_reaction,Sp_Mucus,SH_OvaHW,SH_larva,SH_OvaRW,SP_EHistolytica,SP_ecoli,SP_giardia,SP_trichomonas, SM_rbc_from,  SM_puscells_from,SM_macrophase,SM_vegetables,SM_yeast,SM_crystal,SM_fataglobules,SM_bacterialflora,SH_Others,SC_Occultblood,SC_Reducingsugar,st_imp,SH_hymen,SH_taenia,sm_rbc_to,sm_puscells_to) values ('" + Convert.ToInt32(txtcompanycode.Text) + "','" + Convert.ToInt32(cbopcode.Text);
                    Sqlstr = Sqlstr + "','" + Sp_color.Text + "','" + Sp_reaction.Text;
                    Sqlstr = Sqlstr + "','" + SP_mucus.Text;
                    Sqlstr = Sqlstr + "','" + SH_OvaHW.Text;
                    Sqlstr = Sqlstr + "','" + SH_Larva.Text;
                    Sqlstr = Sqlstr + "','" + SH_OvaRW.Text;
                    Sqlstr = Sqlstr + "','" + SP_EHistolytica.Text;
                    Sqlstr = Sqlstr + "','" + SP_ecoli.Text;
                    Sqlstr = Sqlstr + "','" + SP_giardia.Text;
                    Sqlstr = Sqlstr + "','" + SP_trichmonas.Text;
                    Sqlstr = Sqlstr + "','" + SM_rbc_from.Text;
                    Sqlstr = Sqlstr + "','" + SM_puscells_from.Text;
                    Sqlstr = Sqlstr + "','" + SM_macrophase.Text;
                    Sqlstr = Sqlstr + "','" + SM_vegetables.Text;
                    Sqlstr = Sqlstr + "','" + SM_yeast.Text + "','" + SM_crystal.Text + "','" + SM_fatglobules.Text;
                    Sqlstr = Sqlstr + "','" + SM_bacterialflora.Text + "','" + SM_other_crystal.Text;
                    Sqlstr = Sqlstr + "','" + SC_Occultblood.Text + "','" + SC_Reducingsugar.Text + "','" + st_imp1.Text + "','" + SH_hymene.Text + "','" + SH_crystal1.Text + "','" + sm_rbc_to.Text + "','" + sm_puscells_to.Text + "')";
                    
                    cmd = new SqlCommand(Sqlstr, con);
                    cmd.ExecuteNonQuery();
                    Sqlstr = "";

                }
                else
                {

                    Sqlstr = "update Stool set cc='" + Convert.ToInt32(txtcompanycode.Text) + "',pcode='" + Convert.ToInt32(cbopcode.Text);
                    Sqlstr = Sqlstr + "',Sp_color='" + Sp_color.Text + "',Sp_reaction='" + Sp_reaction.Text;
                    Sqlstr = Sqlstr + "',Sp_mucus='" + SP_mucus.Text + "',SM_rbc_from='" + SM_rbc_from.Text;
                    Sqlstr = Sqlstr + "',SM_puscells_from='" + SM_puscells_from.Text;
                    Sqlstr = Sqlstr + "', SM_macrophase='" + SM_macrophase.Text;
                    Sqlstr = Sqlstr + "',SM_vegetables='" + SM_vegetables.Text;
                    Sqlstr = Sqlstr + "',SM_yeast='" + SM_yeast.Text + "',SM_crystal='" + SM_crystal.Text + "',SH_Others='" + SM_other_crystal.Text + "',SM_fataglobules='" + SM_fatglobules.Text;
                    Sqlstr = Sqlstr + "',SM_bacterialflora='" + SM_bacterialflora.Text + "',SP_EHistolytica='" + SP_EHistolytica.Text;
                    Sqlstr = Sqlstr + "',SP_ecoli='" + SP_ecoli.Text;
                    Sqlstr = Sqlstr + "',SP_giardia='" + SP_giardia.Text;
                    Sqlstr = Sqlstr + "',SP_trichomonas='" + SP_trichmonas.Text;
                    Sqlstr = Sqlstr + "',SH_OvaHW='" + SH_OvaHW.Text;
                    Sqlstr = Sqlstr + "',SH_larva='" + SH_Larva.Text;
                    Sqlstr = Sqlstr + "',SH_OvaRW='" + SH_OvaRW.Text;
                    Sqlstr = Sqlstr + "',SC_Occultblood='" + SC_Occultblood.Text + "',SC_Reducingsugar='" + SC_Reducingsugar.Text + "' ,SH_hymen='" + SH_hymene.Text + "',SH_taenia='" + SH_crystal1.Text + "' ,sm_rbc_to='" + sm_rbc_to.Text + "',sm_puscells_to='" + sm_puscells_to.Text + "'  ,st_imp='" + st_imp1.Text;
                    
                    Sqlstr = Sqlstr + "' where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
                    cmd = new SqlCommand(Sqlstr, con);
                    
                    cmd.ExecuteNonQuery();
                    Sqlstr = "";
                }
            }
        }

        private void btnsaveblood_Click(object sender, EventArgs e)
        {
            String Sqlstr = "";
            con.Close();
            con.Open();

            int neu = Convert.ToInt32(BDc_Neutrophild.Text);
            int lymp = Convert.ToInt32(BDc_Lymphocytes.Text);
            int eos = Convert.ToInt32(BDc_Eosinophils.Text);
            int mon = Convert.ToInt32(BDc_Monocytes.Text);
            int baso = Convert.ToInt32(BDc_Basophils.Text);
            int TDC = neu + lymp + eos + mon + baso;
            int tdcb = 100 - TDC;
            dctot();
            if (neu + lymp + eos + mon + baso != 0)
            {
                if (neu + lymp + eos + mon + baso != 100)
                {
                    
                    MessageBox.Show("DC Balance  = " + tdcb);
                    BDc_Neutrophild.Focus();
                    return;
                
                }
            }
            
            if (MessageBox.Show("Save ? ", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                String strsql4 = "";
                strsql4 = "select cc,pcode,BG_Blood_Group,BR_RhD_Typing,BDc_Neutrophild,BDc_Eosinophils,BDc_Lymphocytes,";
                strsql4 = strsql4 + "BDc_Basophils,BDc_Monocytes,BDc_Twbc,BDc_Trbc,BDc_Tplatelets,BDc_Aec,BDc_Tnc,BDc_Reticulocyte_Count,";
                strsql4 = strsql4 + "BDc_PCV,BDC_mcv,BDC_mch,BDC_mchc,BDc_Pss,BDc_Mp_ICT_QBC_Smear,BDc_Mp_ICT,BDc_Mf_ICT_QBC_Smear,BDc_Mf_ICT,BDc_Rct,BDc_Hb,BDc_ESR_1sthour,";
                strsql4 = strsql4 + "BDc_Bleeding_Time,BDc_Clotting_Time,BDC_nasalsmear,BDC_nasalsmear_right,BDc_Sickle_cell,BDC_prothombintime,BDC_prothombintime_cont,BPS_Toxo,BPS_Crp,BPS_Vdrl,BPS_Ana,";
                strsql4 = strsql4 + "BPS_Rafactor,BPS_Aso,BS_Australia_Antigen,BS_Hepatitis_C_Virus,BS_HIV_1,BS_HIV_2,";
                strsql4 = strsql4 + "Bw_Widaltubeo80,Bw_Widaltubeo160,Bw_Widaltubeo320,Bw_Widaltubeh80,Bw_Widaltubeh160,Bw_Widaltubeh320,Bw_Widaltubeah80,Bw_Widaltubeah160,Bw_Widaltubeah320,Bw_Widaltubebh80,Bw_Widaltubebh160,Bw_Widaltubebh320,Bw_Widalslide1,Bw_Widalslide2,Bw_Widalslide3,Bw_Widalslide4,Bw_mycodot,bw_trop,Bm_MontouxTest_injon,Bm_MontouxTest_readon,Bm_MontouxTest_induration,BDC_prothombintime_inr,BDc_ESR_2ndhour,BDc_Dengue,BDc_typhicheck,bl_imp,BDc_Rcdw,BDc_MPV,BDc_PDW";
                strsql4 = strsql4 + " from Blood where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";

                da = new SqlDataAdapter(strsql4, con);


                ds4 = new DataSet();
                da.Fill(ds4);


                if (ds4.Tables[0].Rows.Count == 0)
                {
                    //BDc_Neutrophild.Focus();
                    
                    
                    
                    Sqlstr = "insert into Blood ( cc,pcode,BG_Blood_Group,BR_RhD_Typing,BDc_Neutrophild,BDc_Eosinophils,BDc_Lymphocytes,BDc_Basophils, BDc_Monocytes,BDc_Twbc,BDc_Trbc,BDc_Tplatelets,";
                    Sqlstr = Sqlstr + "BDc_Aec,BDc_Tnc,BDc_Reticulocyte_Count,BDc_PCV,BDC_mcv,BDC_mch,BDC_mchc,BDc_Pss,BDc_Mp_ICT_QBC_Smear,BDc_Mp_ICT,BDc_Mf_ICT_QBC_Smear,BDc_Mf_ICT,Bdc_Rct,BDc_Hb,BDc_ESR_1sthour,";
                    Sqlstr = Sqlstr + "BDc_Bleeding_Time,BDc_Clotting_Time,BDC_nasalsmear,BDC_nasalsmear_right,BDc_Sickle_cell,BDC_prothombintime,BDC_prothombintime_cont,BPS_Toxo,BPS_Crp,BPS_Vdrl,BPS_Ana,";
                    Sqlstr = Sqlstr + "BPS_Rafactor,BPS_Aso,BS_Australia_Antigen,BS_Hepatitis_C_Virus,BS_HIV_1,BS_HIV_2,";
                    Sqlstr = Sqlstr + "Bw_Widaltubeo80,Bw_Widaltubeo160,Bw_Widaltubeo320,Bw_Widaltubeh80,Bw_Widaltubeh160,Bw_Widaltubeh320,Bw_Widaltubeah80,Bw_Widaltubeah160,Bw_Widaltubeah320,Bw_Widaltubebh80,Bw_Widaltubebh160,Bw_Widaltubebh320,Bw_Widalslide1,Bw_Widalslide2,Bw_Widalslide3,Bw_Widalslide4,Bw_mycodot,bw_trop,Bm_MontouxTest_injon,Bm_MontouxTest_readon,";
                    Sqlstr = Sqlstr + "Bm_MontouxTest_induration,BDC_prothombintime_inr,BDc_ESR_2ndhour,BDc_Dengue,BDc_typhicheck,bl_imp,BDc_Rcdw,BDc_MPV,BDc_PDW,BDc_Mp_ICT_slide,BPS_Aso_qty,BPS_Crp_qty,BPS_Rafactor_qty,Bw_Trop_qty,BDc_MP_ICT_QBC_METHOD) values ('" + Convert.ToInt32(txtcompanycode.Text) + "','" + Convert.ToInt32(cbopcode.Text);
                    Sqlstr = Sqlstr + "','" + BG_Blood_Group.Text + "','" + BR_RhD_Typing.Text;
                    Sqlstr = Sqlstr + "' ,'" + BDc_Neutrophild.Text + "','" + BDc_Eosinophils.Text;
                    Sqlstr = Sqlstr + "','" + BDc_Lymphocytes.Text + "','" + BDc_Basophils.Text;
                    Sqlstr = Sqlstr + "','" + BDc_Monocytes.Text + "','" + BDc_Twbc.Text;
                    Sqlstr = Sqlstr + "','" + BDc_Trbc.Text + "','" + BDc_Tplatelets.Text;
                    Sqlstr = Sqlstr + "','" + BDc_Aec.Text + "','" + BDc_Tnc.Text + "','" + BDc_Reticulocyte_Count.Text;
                    Sqlstr = Sqlstr + "','" + BDc_PCV.Text + "','" + BDCmcv.Text;
                    Sqlstr = Sqlstr + "','" + BDCmch.Text + "','" + BDCmchc.Text + "','" + CBDcPSS.Text + "','" + BDc_Mp_ICT_QBC_Smear.Text + "','" + BDc_Mp_ICT.Text;
                    Sqlstr = Sqlstr + "','" + BDc_Mf_ICT_QBC_Smear.Text + "','" + BDc_Mf_ICT.Text + "','" + BDc_Rct.Text + "','" + BDc_Hb.Text;
                    Sqlstr = Sqlstr + "','" + BDc_ESR_1sthour.Text;
                    Sqlstr = Sqlstr + "','" + BDc_Bleeding_Time.Text + "','" + BDc_Clotting_Time.Text;
                    Sqlstr = Sqlstr + "','" + BDc_Nasalsmear.Text + "','" + BDc_Nasalsmear_Right.Text;
                    Sqlstr = Sqlstr + "','" + BDc_Sickle_cell.Text + "','" + BDc_Prothombintime.Text + "','" + BDc_Prothombintime_cont.Text + "','" + SBPS_Toxo.Text;
                    Sqlstr = Sqlstr + "','" + SBPS_Crp.Text + "','" + SBPS_vdrl.Text + "','" + SBPS_Ana.Text;
                    Sqlstr = Sqlstr + "','" + SBPS_Rafactor.Text + "','" + SBPS_Aso.Text;
                    Sqlstr = Sqlstr + "','" + SBS_Australia_Antigen.Text + "','" + SBS_Hepatitis_C_Virus.Text;
                    Sqlstr = Sqlstr + "','" + SBS_HIV_1.Text + "','" + SBS_HIV_2.Text;
                    Sqlstr = Sqlstr + "','" + BWwidaltubeo80.Text + "','" + BWwidaltubeo160.Text + "','" + BWwidaltubeo320.Text + "','" + BWwidaltubeh80.Text + "','" + BWwidaltubeh160.Text + "','" + BWwidaltubeh320.Text + "','" + BWwidaltubeah80.Text + "','" + BWwidaltubeah160.Text + "','" + BWwidaltubeah320.Text + "','" + BWwidaltubebh80.Text + "','" + BWwidaltubebh160.Text + "','" + BWwidaltubebh320.Text;
                    Sqlstr = Sqlstr + "','" + BWwidalslide1.Text + "','" + BWwidalslide2.Text + "','" + BWwidalslide3.Text + "','" + BWwidalslide4.Text + "','" + SBS_mycodot.Text + "','" + SBS_trop.Text;
                    Sqlstr = Sqlstr + "','" + SBm_MontouxTest_injon.Text + "','" + SBm_MontouxTest_readon.Text;
                    Sqlstr = Sqlstr + "','" + SBm_MontouxTest_induration.Text + "','" + BDc_Prothombintime_inr.Text + "','" + BDc_ESR_2ndhour.Text + "','" + SBS_Dengue.Text + "','" + SBS_Typhicheck.Text + "','" + bl_imp.Text + "','" + BDcRcdw.Text + "','" + BDCmpv.Text + "','" + BDCpdw.Text + "','" + BDc_Mp_ICT_slide.Text + "','" + SBPS_Aso_Qty.Text + "', '" + SBPS_Crp_Qty.Text + "','" + SBPS_Rafactor_Qty.Text + "','" + SBS_trop_Qty.Text + "','" + BDc_Mp_ICT_QBC_method.Text + "')";
               
                    
                }
                else
                {

                    Sqlstr = "update blood set cc='" + Convert.ToInt32(txtcompanycode.Text) + "',pcode='" + Convert.ToInt32(cbopcode.Text);

                    Sqlstr = Sqlstr + "',BG_Blood_Group='" + BG_Blood_Group.Text + "',BR_RhD_Typing='" + BR_RhD_Typing.Text;
                    Sqlstr = Sqlstr + "',BDc_Neutrophild='" + BDc_Neutrophild.Text + "',BDc_Eosinophils='" + BDc_Eosinophils.Text;
                    Sqlstr = Sqlstr + "',BDc_Lymphocytes='" + BDc_Lymphocytes.Text + "',BDc_Basophils='" + BDc_Basophils.Text;
                    Sqlstr = Sqlstr + "',BDc_Monocytes='" + BDc_Monocytes.Text + "',BDc_Twbc='" + BDc_Twbc.Text;
                    Sqlstr = Sqlstr + "',BDc_Trbc='" + BDc_Trbc.Text + "',BDc_Tplatelets='" + BDc_Tplatelets.Text;
                    Sqlstr = Sqlstr + "',BDc_Aec='" + BDc_Aec.Text + "',BDc_Tnc='" + BDc_Tnc.Text + "',BDc_Reticulocyte_Count='" + BDc_Reticulocyte_Count.Text;
                    Sqlstr = Sqlstr + "',BDc_PCV='" + BDc_PCV.Text + "',BDC_mcv='" + BDCmcv.Text + "',BDC_mch='" + BDCmch.Text + "',BDC_mchc='" + BDCmchc.Text + "',BDc_Pss='" + CBDcPSS.Text;
                    Sqlstr = Sqlstr + "',BDc_Mp_ICT_QBC_Smear='" + BDc_Mp_ICT_QBC_Smear.Text + "',BDc_Mp_ICT='" + BDc_Mp_ICT.Text;
                    Sqlstr = Sqlstr + "',BDc_Mf_ICT_QBC_Smear='" + BDc_Mf_ICT_QBC_Smear.Text + "',BDc_Mf_ICT='" + BDc_Mf_ICT.Text + "',BDc_Rct='" + BDc_Rct.Text + "',BDc_Hb='" + BDc_Hb.Text;
                    Sqlstr = Sqlstr + "',BDc_ESR_1sthour='" + BDc_ESR_1sthour.Text;
                    Sqlstr = Sqlstr + "',BDc_Bleeding_Time='" + BDc_Bleeding_Time.Text + "',BDc_Clotting_Time='" + BDc_Clotting_Time.Text + "',BDc_nasalsmear='" + BDc_Nasalsmear.Text + "',BDc_nasalsmear_right='" + BDc_Nasalsmear_Right.Text;
                    Sqlstr = Sqlstr + "',BDc_Sickle_cell='" + BDc_Sickle_cell.Text + "',Bdc_prothombintime='" + BDc_Prothombintime.Text + "',Bdc_prothombintime_cont='" + BDc_Prothombintime_cont.Text + "',BPS_Toxo='" + SBPS_Toxo.Text;
                    Sqlstr = Sqlstr + "',BPS_Crp='" + SBPS_Crp.Text + "',BPS_Vdrl='" + SBPS_vdrl.Text + "',BPS_Ana='" + SBPS_Ana.Text;
                    Sqlstr = Sqlstr + "',BPS_Rafactor='" + SBPS_Rafactor.Text + "',BPS_Aso='" + SBPS_Aso.Text;
                    Sqlstr = Sqlstr + "',BS_Australia_Antigen='" + SBS_Australia_Antigen.Text + "',BS_Hepatitis_C_Virus='" + SBS_Hepatitis_C_Virus.Text;
                    Sqlstr = Sqlstr + "',BS_HIV_1='" + SBS_HIV_1.Text + "',BS_HIV_2='" + SBS_HIV_2.Text;
                    Sqlstr = Sqlstr + "',Bw_Widaltubeo80='" + BWwidaltubeo80.Text + "',Bw_Widaltubeo160='" + BWwidaltubeo160.Text + "',Bw_Widaltubeo320='" + BWwidaltubeo320.Text + "',Bw_Widaltubeh80='" + BWwidaltubeh80.Text + "',Bw_Widaltubeh160='" + BWwidaltubeh160.Text + "',Bw_Widaltubeh320='" + BWwidaltubeh320.Text + "',Bw_Widaltubeah80='" + BWwidaltubeah80.Text + "',Bw_Widaltubeah160='" + BWwidaltubeah160.Text + "',Bw_Widaltubeah320='" + BWwidaltubeah320.Text + "',Bw_Widaltubebh80='" + BWwidaltubebh80.Text + "',Bw_Widaltubebh160='" + BWwidaltubebh160.Text + "',Bw_Widaltubebh320='" + BWwidaltubebh320.Text;

                    Sqlstr = Sqlstr + "',Bw_Widalslide1='" + BWwidalslide1.Text + "',Bw_Widalslide2='" + BWwidalslide2.Text + "',Bw_Widalslide3='" + BWwidalslide3.Text + "',Bw_Widalslide4='" + BWwidalslide4.Text + "',bw_mycodot='" + SBS_mycodot.Text + "',bw_trop='" + SBS_trop.Text;
                    Sqlstr = Sqlstr + "',Bm_MontouxTest_injon='" + SBm_MontouxTest_injon.Text + "',Bm_MontouxTest_readon='" + SBm_MontouxTest_readon.Text;
                    Sqlstr = Sqlstr + "',Bm_MontouxTest_induration='" + SBm_MontouxTest_induration.Text + "',BDc_ESR_2ndhour='" + BDc_ESR_2ndhour.Text + "',Bdc_prothombintime_inr='" + BDc_Prothombintime_inr.Text + "',BDc_Dengue='" + SBS_Dengue.Text + "',BDc_Typhicheck='" + SBS_Typhicheck.Text + "',bl_imp='" + bl_imp.Text + "',BDc_Rcdw='" + BDcRcdw.Text + "',BDC_mpv='" + BDCmpv.Text + "',BDC_pdw='" + BDCpdw.Text + "',BDc_Mp_ICT_slide='" + BDc_Mp_ICT_slide.Text + "', BPS_Aso_qty='" + SBPS_Aso_Qty.Text + "', BPS_Crp_qty='" + SBPS_Crp_Qty.Text + "',BPS_Rafactor_qty='" + SBPS_Rafactor_Qty.Text + "',BDC_MP_ICT_QBC_METHOD='" + BDc_Mp_ICT_QBC_method.Text + "',Bw_Trop_qty='" + SBS_trop_Qty.Text;
                    Sqlstr = Sqlstr + "' where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
                  
                }
                cmd = new SqlCommand(Sqlstr, con);
                cmd.ExecuteNonQuery();

                Sqlstr = "";
      
                Sqlstr = "delete from bloodext where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
                cmd = new SqlCommand(Sqlstr, con);
                cmd.ExecuteNonQuery();
                Sqlstr = "";
                for (int i = 0; i < dgvbloodnewtest.Rows.Count; i++)
                {

                    if (dgvbloodnewtest.Rows[i].Cells[0].Value!=null)
                    {
                   
                        Sqlstr = "insert into bloodext (pcode,test,method,result,unit,normal_range) values ('" + Convert.ToInt32(cbopcode.Text) + "','" + dgvbloodnewtest.Rows[i].Cells[0].Value + "','" + dgvbloodnewtest.Rows[i].Cells[1].Value + "','" + dgvbloodnewtest.Rows[i].Cells[2].Value + "','" + dgvbloodnewtest.Rows[i].Cells[3].Value + "','" + dgvbloodnewtest.Rows[i].Cells[4].Value + "')";
                    cmd = new SqlCommand(Sqlstr, con);
                    cmd.ExecuteNonQuery();
                    Sqlstr = "";
                    }
               }
            
            
            }

            if (cbopcode.Text != "")
            {
                Sqlstr = "update setup set regno='" + Convert.ToInt32(cbopcode.Text) + "'";
                cmd = new SqlCommand(Sqlstr, con);
                cmd.ExecuteNonQuery();
                Sqlstr = "";

            }

        }


        private void btncancelblood_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BR_RhD_Typing_TextChanged(object sender, EventArgs e)
        {

        }

        private void btncancelmaster_Click(object sender, EventArgs e)
        {
            
        }

        private void btncancelurine_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btncancelstool_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnsavebiochem_Click(object sender, EventArgs e)
        {
            String Sqlstr = "";
            con.Close();
            con.Open();

            if (MessageBox.Show("Save ? ", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                String strsql5 = "";

                strsql5 = strsql5 + "select cc,pcode,Bcr1_Glucose_Fpg_RPG,Bcr1_PPPG_PGPG_2hr,Bcr1_PPPG_PGPG_1hr,Bcr1_RBS,Bcr1_PBBS,Bcr1_PLBS,Bcr1_GTT_1hr,Bcr1_GTT_2hr,Bcr1_GTT_3hr,Bcr1_PGBS_1hr,Bcr1_PGBS_2hr,Bcr1_HBAC_fair,Bcr1_HBAC_good,Bcr1_HBAC_poor,Bcr1_MBGE,Bcr_RP_Urea,Bcr_RP_BUN,Bcr_RP_Creatinine,Bcr3_NPN,Bcr3_Uric_Acid,Bcr_LP_Cholesterol,Bcr_LP_HDLCholesterol,";
                strsql5 = strsql5 + "Bcr_LP_LDLCholesterol,Bcr_LP_VLDLCholesterol,Bcr_LP_Triglycerides,Bcr2_LP_CHR,Bcr2_LP_LHR,Bcr_LFT_Bilirubin_total,Bcr_LFT_Bilirubin_Direct,Bcr4_LFT_Indirect,Bcr_LFT_Alkaline_Phosphates,";
                strsql5 = strsql5 + "Bcr_LFT_SGOT_AST,Bcr_LFT_SGPT_ALT,Bcr_LFT_Albumin,Bcr_LFT_Protein,Bcr_LFT_Globulin,Bcr_LFT_AG_Ratio,Bcr4_LFT_GGTP,Bcr_Electrolyte_Sodium,";
                strsql5 = strsql5 + "Bcr_Electrolyte_Potassium,Bcr5_Electrolyte_Chlorides,Bcr_OTH_Acid_Phosphate,Bcr_OTH_Amylase,Bcr_OTH_Acid_Calcium,Bcr_OTH_Acid_Phosphorus,Bcr_OTH_Uric_Acid,Bcr_OTH_Pasting_urine_sugar,Bcr_OTH_PP_PG_urine_sugar,Bcr_OTH_Lipase,Bcr_OTH_Nac";
                strsql5 = strsql5 + " from Biochemist where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";

                da = new SqlDataAdapter(strsql5, con);
                ds5 = new DataSet();
                da.Fill(ds5);
                if (ds5.Tables[0].Rows.Count == 0)
                {
                    Sqlstr = "insert into Biochemist (cc,pcode,Bcr1_Glucose_Fpg_RPG,Bcr1_PPPG_PGPG_2hr,Bcr1_PPPG_PGPG_1hr,Bcr1_RBS,Bcr1_PBBS,Bcr1_PLBS,Bcr1_GTT_1hr,Bcr1_GTT_2hr,Bcr1_GTT_3hr,Bcr1_PGBS_1hr,Bcr1_PGBS_2hr,Bcr1_HBAC_fair,Bcr1_HBAC_good,Bcr1_HBAC_poor,Bcr1_MBGE,Bcr_RP_Urea,Bcr_RP_BUN,Bcr_RP_Creatinine,Bcr3_NPN,Bcr3_Uric_Acid,Bcr_LP_Cholesterol,Bcr_LP_HDLCholesterol,";
                    Sqlstr = Sqlstr + "Bcr_LP_LDLCholesterol,Bcr_LP_VLDLCholesterol,Bcr_LP_Triglycerides  ,Bcr2_LP_CHR,Bcr2_LP_LHR,Bcr_LFT_Bilirubin_total,Bcr_LFT_Bilirubin_Direct,Bcr4_LFT_Indirect,Bcr_LFT_Alkaline_Phosphates,";
                    Sqlstr = Sqlstr + "Bcr_LFT_SGOT_AST,Bcr_LFT_SGPT_ALT,Bcr_LFT_Albumin,Bcr_LFT_Protein,Bcr_LFT_Globulin,Bcr_LFT_AG_Ratio,Bcr4_LFT_GGTP,Bcr_Electrolyte_Sodium,";
                    Sqlstr = Sqlstr + "Bcr_Electrolyte_Potassium,Bcr5_Electrolyte_Chlorides,Bcr_OTH_Acid_Phosphate,Bcr_OTH_Amylase,Bcr_OTH_Acid_Calcium,Bcr_OTH_Acid_Phosphorus,Bcr_OTH_Uric_Acid,Bcr_OTH_Pasting_urine_sugar,Bcr_OTH_PP_PG_urine_sugar,db_imp,Bcr_OTH_Lipase,Bcr_OTH_Nac) values ( '" + Convert.ToInt32(txtcompanycode.Text) + "','" + Convert.ToInt32(cbopcode.Text);

                    Sqlstr = Sqlstr + "','" + Bcr1_Glucose_Fpg_RPG.Text + "','" + Bcr1_PPPG_PGPG_2hr.Text + "','" + Bcr1_PPPG_PGPG_1hr.Text + "','" + Bcr1_RBS.Text + "','" + Bcr1_PBBS.Text + "','" + Bcr1_PLBS.Text + "','" + Bcr1_GTT_1hr.Text + "','" + Bcr1_GTT_2hr.Text + "','" + Bcr1_GTT_3hr.Text + "','" + Bcr1_PGBS_1hr.Text + "','" + Bcr1_PGBS_2hr.Text + "','" + Bcr1_HBAC_fair.Text + "','" + Bcr1_HBAC_good.Text + "','" + Bcr1_HBAC_poor.Text + "','" + Bcr1_MBGE.Text + "','" + Bcr_RP_Urea.Text + "','" + Bcr_RP_BUN.Text + "','" + Bcr_RP_Creatinine.Text + "','" + Bcr3_NPN.Text + "','" + Bcr3_Uric_Acid.Text + "','" + Bcr_LP_Cholesterol.Text + "','" + Bcr_LP_HDLCholesterol.Text;
                    Sqlstr = Sqlstr + "','" + Bcr_LP_LDLCholesterol.Text + "','" + Bcr_LP_VLDLCholesterol.Text + "','" + Bcr_LP_Triglycerides.Text + "','" + Bcr2_LP_CHR.Text + "','" + Bcr2_LP_LHR.Text + "','" + Bcr_LFT_Bilirubin_total.Text + "','" + Bcr_LFT_Bilirubin_Direct.Text + "','" + Bcr4_LFT_Indirect.Text + "','" + Bcr_LFT_Alkaline_Phosphates.Text;
                    Sqlstr = Sqlstr + "','" + Bcr_LFT_SGOT_AST.Text + "','" + Bcr_LFT_SGPT_ALT.Text + "','" + Bcr_LFT_Albumin.Text + "','" + Bcr_LFT_Protein.Text + "','" + Bcr_LFT_Globulin.Text + "','" + Bcr_LFT_AG_Ratio.Text + "','" + Bcr4_LFT_GGTP.Text + "','" + Bcr_Electrolyte_Sodium.Text;
                    Sqlstr = Sqlstr + "','" + Bcr_Electrolyte_Potassium.Text + "','" + Bcr5_Electrolyte_Chlorides.Text + "','" + Bcr_OTH_Acid_Phosphate.Text + "','" + Bcr_OTH_Amylase.Text + "','" + Bcr_OTH_Acid_Calcium.Text + "','" + Bcr_OTH_Acid_Phosphorus.Text + "','" + Bcr_OTH_Uric_Acid.Text + "','" + Bcr_OTH_Pasting_urine_sugar.Text + "','" + Bcr_OTH_PP_PG_urine_sugar.Text + "','" + db_all.Text + "','" + Bcr_OTH_Lipase.Text + "','" + Bcr_OTH_nac.Text + "')";
                    cmd = new SqlCommand(Sqlstr, con);
                    cmd.ExecuteNonQuery();
                    Sqlstr = "";


                }
                else
                {
                    String strsql = "";
                    
                    strsql = "update Biochemist set cc='" + Convert.ToInt32(txtcompanycode.Text) + "',pcode='" + Convert.ToInt32(cbopcode.Text);
                    strsql = strsql + "',Bcr1_Glucose_Fpg_RPG='" + Bcr1_Glucose_Fpg_RPG.Text + "',Bcr1_PPPG_PGPG_2hr='" + Bcr1_PPPG_PGPG_2hr.Text + "',Bcr1_PPPG_PGPG_1hr='" + Bcr1_PPPG_PGPG_1hr.Text + "',Bcr1_RBS='" + Bcr1_RBS.Text + "',Bcr1_PBBS='" + Bcr1_PBBS.Text + "',Bcr1_PLBS='" + Bcr1_PLBS.Text + "', Bcr1_GTT_1hr='" + Bcr1_GTT_1hr.Text + "',Bcr1_GTT_2hr='" + Bcr1_GTT_2hr.Text + "',Bcr1_GTT_3hr='" + Bcr1_GTT_3hr.Text + "',Bcr1_PGBS_1hr='" + Bcr1_PGBS_1hr.Text + "',Bcr1_PGBS_2hr='" + Bcr1_PGBS_2hr.Text + "',Bcr1_HBAC_fair='" + Bcr1_HBAC_fair.Text + "',Bcr1_HBAC_good='" + Bcr1_HBAC_good.Text + "',Bcr1_HBAC_poor='" + Bcr1_HBAC_poor.Text + "', Bcr1_MBGE='" + Bcr1_MBGE.Text + "', Bcr_RP_Urea='" + Bcr_RP_Urea.Text + "',Bcr_RP_BUN='" + Bcr_RP_BUN.Text + "',Bcr_RP_Creatinine='" + Bcr_RP_Creatinine.Text + "',Bcr3_NPN='" + Bcr3_NPN.Text + "',Bcr3_Uric_Acid='" + Bcr3_Uric_Acid.Text + "',Bcr_LP_Cholesterol='" + Bcr_LP_Cholesterol.Text + "',Bcr_LP_HDLCholesterol='" + Bcr_LP_HDLCholesterol.Text;
                    strsql = strsql + "',Bcr_LP_LDLCholesterol='" + Bcr_LP_LDLCholesterol.Text + "',Bcr_LP_VLDLCholesterol='" + Bcr_LP_VLDLCholesterol.Text + "',Bcr_LP_Triglycerides='" + Bcr_LP_Triglycerides.Text + "',Bcr2_LP_CHR='" + Bcr2_LP_CHR.Text + "',Bcr2_LP_LHR='" + Bcr2_LP_LHR.Text + "',Bcr_LFT_Bilirubin_total='" + Bcr_LFT_Bilirubin_total.Text + "',Bcr_LFT_Bilirubin_Direct='" + Bcr_LFT_Bilirubin_Direct.Text + "',Bcr4_LFT_Indirect='" + Bcr4_LFT_Indirect.Text + "',Bcr_LFT_Alkaline_Phosphates='" + Bcr_LFT_Alkaline_Phosphates.Text;
                    strsql = strsql + "',Bcr_LFT_SGOT_AST='" + Bcr_LFT_SGOT_AST.Text + "',Bcr_LFT_SGPT_ALT='" + Bcr_LFT_SGPT_ALT.Text + "',Bcr_LFT_Albumin='" + Bcr_LFT_Albumin.Text + "',Bcr_LFT_Protein='" + Bcr_LFT_Protein.Text + "',Bcr_LFT_Globulin='" + Bcr_LFT_Globulin.Text + "',Bcr_LFT_AG_Ratio='" + Bcr_LFT_AG_Ratio.Text + "',Bcr4_LFT_GGTP='" + Bcr4_LFT_GGTP.Text + "',Bcr_Electrolyte_Sodium='" + Bcr_Electrolyte_Sodium.Text;
                    strsql = strsql + "',Bcr_Electrolyte_Potassium='" + Bcr_Electrolyte_Potassium.Text + "',Bcr5_Electrolyte_Chlorides='" + Bcr5_Electrolyte_Chlorides.Text + "',Bcr_OTH_Acid_Phosphate='" + Bcr_OTH_Acid_Phosphate.Text + "',Bcr_OTH_Amylase='" + Bcr_OTH_Amylase.Text + "',Bcr_OTH_Acid_Calcium='" + Bcr_OTH_Acid_Calcium.Text + "',Bcr_OTH_Acid_Phosphorus='" + Bcr_OTH_Acid_Phosphorus.Text + "',Bcr_OTH_Uric_Acid='" + Bcr_OTH_Uric_Acid.Text + "',Bcr_OTH_Pasting_urine_sugar='" + Bcr_OTH_Pasting_urine_sugar.Text + "',Bcr_OTH_PP_PG_urine_sugar='" + Bcr_OTH_PP_PG_urine_sugar.Text + "',Bcr_OTH_Lipase='" + Bcr_OTH_Lipase.Text + "',Bcr_OTH_Nac='" + Bcr_OTH_nac.Text + "',db_imp='" + db_all.Text;

                    strsql = strsql + "' where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
                    cmd = new SqlCommand(strsql, con);
                    cmd.ExecuteNonQuery();
                    strsql = "";
                }


                Sqlstr = "delete from biochemistext where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
                cmd = new SqlCommand(Sqlstr, con);
                cmd.ExecuteNonQuery();
                Sqlstr = "";
                for (int i = 0; i < dgvbiochemext.Rows.Count; i++)
                {
                    if (dgvbiochemext.Rows[i].Cells[0].Value != null)
                    {
                        Sqlstr = "insert into biochemistext (pcode,test,method,result,unit,normal_range) values ('" + Convert.ToInt32(cbopcode.Text) + "','" + dgvbiochemext.Rows[i].Cells[0].Value + "','" + dgvbiochemext.Rows[i].Cells[1].Value + "','" + dgvbiochemext.Rows[i].Cells[2].Value + "','" + dgvbiochemext.Rows[i].Cells[3].Value + "','" + dgvbiochemext.Rows[i].Cells[4].Value + "')";
                        cmd = new SqlCommand(Sqlstr, con);
                        cmd.ExecuteNonQuery();
                        Sqlstr = "";
                    }
                 }
          
            }
        }
        private void btncancelbiochem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsavesemen_Click(object sender, EventArgs e)
        {
            String strsql = "";

            con.Close();
            con.Open();

            if (MessageBox.Show("Save ? ", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                String strsql6 = "";

                strsql6 = strsql6 + "select cc,pcode,FA_Timeofcollection,FA_Timeofexamination,FA_Timeofliquification,FA_Volume,FA_Reaction,FA_Color,FA_Viscocity,FA_MP_Prostaticpearls,FA_MP_Puscells,FA_MP_RBC,";
                strsql6 = strsql6 + "FA_MP_Epithcells,FA_MP_Deformed,FA_MT_Active,FA_MT_Slugish,FA_MT_Dead,FA_MT_Totalcount,FA_MP_Premature";
                strsql6 = strsql6 + " from Seminal_Fluid where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
                da = new SqlDataAdapter(strsql6, con);
                ds6 = new DataSet();
                da.Fill(ds6, "Seminal Fluid");


                if (ds6.Tables[0].Rows.Count == 0)
                {
                    strsql = "insert into Seminal_Fluid (cc,pcode,FA_Timeofcollection,FA_Timeofexamination,FA_Timeofliquification,FA_Volume,FA_Reaction,FA_Color,FA_Viscocity,FA_MP_Prostaticpearls,FA_MP_Puscells,FA_MP_RBC,";
                    strsql = strsql + "FA_MP_Epithcells,FA_MP_Deformed,FA_MT_Active,FA_MT_Slugish,FA_MT_Dead,FA_MT_Totalcount,FA_MT_IMP,FA_MP_Premature,patient_name ) values ('" + Convert.ToInt32(txtcompanycode.Text) + "','" + Convert.ToInt32(cbopcode.Text);
                    strsql = strsql + "','" + FA_Timeofcollection.Text + "','" + FA_Timeofexamination.Text + "','" + FA_Timeofliquification.Text + "','" + FA_Volume.Text + "','" + FA_Reaction.Text + "','" + FA_Color.Text + "','" + FA_Viscocity.Text + "','" + FA_MP_Prostaticpearls.Text + "','" + FA_MP_Puscells.Text + "','" + FA_MP_RBC.Text;
                    strsql = strsql + "','" + FA_MP_Epithcells.Text + "','" + FA_MP_Deformed.Text + "','" + FA_MT_Active.Text + "','" + FA_MT_Slugish.Text + "','" + FA_MT_Dead.Text + "','" + FA_MT_Totalcount.Text + "','" + sf_imp.Text + "','" + FA_MP_Premature.Text + "','" + cboiv.Text + "')";
                    cmd = new SqlCommand(strsql, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con.Open();
                    cmd = new SqlCommand("insert into mrn_detail(cc,type,blno,bldt,acdes,child ,item,qty,unit,rate,gross) values('" + txtcompanycode.Text + "','Issue','" + cbopcode.Text + "','" + repdt1 + "','Self','','Tube','2','No.','0.00','0.00')", con);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("insert into mrn_detail(cc,type,blno,bldt,acdes,child ,item,qty,unit,rate,gross) values('" + txtcompanycode.Text + "','Issue','" + cbopcode.Text + "','" + repdt1 + "','Self','','Peped','2','No.','0.00','0.00')", con);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("insert into mrn_detail(cc,type,blno,bldt,acdes,child ,item,qty,unit,rate,gross) values('" + txtcompanycode.Text + "','Issue','" + cbopcode.Text + "','" + repdt1 + "','Self','','Cathod','1','No.','0.00','0.00')", con);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("insert into mrn_detail(cc,type,blno,bldt,acdes,child ,item,qty,unit,rate,gross) values('" + txtcompanycode.Text + "','Issue','" + cbopcode.Text + "','" + repdt1 + "','Self','','Chemical','1','No.','0.00','0.00')", con);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    strsql = "update Seminal_Fluid set cc='" + Convert.ToInt32(txtcompanycode.Text) + "',pcode='" + Convert.ToInt32(cbopcode.Text);
                    strsql = strsql + "',FA_Timeofcollection='" + FA_Timeofcollection.Text + "',FA_Timeofexamination='" + FA_Timeofexamination.Text + "',FA_Timeofliquification='" + FA_Timeofliquification.Text + "',FA_Volume='" + FA_Volume.Text + "',FA_Reaction='" + FA_Reaction.Text + "',FA_Color='" + FA_Color.Text + "',FA_Viscocity='" + FA_Viscocity.Text + "',FA_MP_Prostaticpearls='" + FA_MP_Prostaticpearls.Text + "',FA_MP_Puscells='" + FA_MP_Puscells.Text + "',FA_MP_RBC='" + FA_MP_RBC.Text;
                    strsql = strsql + "',FA_MP_Epithcells='" + FA_MP_Epithcells.Text + "',FA_MP_Deformed='" + FA_MP_Deformed.Text + "',FA_MT_Active='" + FA_MT_Active.Text + "',FA_MT_Slugish='" + FA_MT_Slugish.Text + "',FA_MT_Dead='" + FA_MT_Dead.Text + "',FA_MT_Totalcount='" + FA_MT_Totalcount.Text + "',FA_MP_Premature='" + FA_MP_Premature.Text + "',patient_name='" + cboiv.Text + "',FA_MT_IMP='" + sf_imp.Text;
                    strsql = strsql + "' where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
                    cmd = new SqlCommand(strsql, con);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("delete from mrn_detail where type='Issue' and blno='" + cbopcode.Text + "'", con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                    con.Open();
                    cmd = new SqlCommand("insert into mrn_detail(cc,type,blno,bldt,acdes,child ,item,qty,unit,rate,gross) values('" + txtcompanycode.Text + "','Issue','" + cbopcode.Text + "','" + repdt1 + "','Self','','Tube','2','No.','0.00','0.00')", con);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("insert into mrn_detail(cc,type,blno,bldt,acdes,child ,item,qty,unit,rate,gross) values('" + txtcompanycode.Text + "','Issue','" + cbopcode.Text + "','" + repdt1 + "','Self','','Peped','2','No.','0.00','0.00')", con);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("insert into mrn_detail(cc,type,blno,bldt,acdes,child ,item,qty,unit,rate,gross) values('" + txtcompanycode.Text + "','Issue','" + cbopcode.Text + "','" + repdt1 + "','Self','','Cathod','1','No.','0.00','0.00')", con);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("insert into mrn_detail(cc,type,blno,bldt,acdes,child ,item,qty,unit,rate,gross) values('" + txtcompanycode.Text + "','Issue','" + cbopcode.Text + "','" + repdt1 + "','Self','','Chemical','1','No.','0.00','0.00')", con);
                    cmd.ExecuteNonQuery();
                
                
                }
               
                strsql = "";


            }
        }
        private void btncancelsemen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void BDc_Neutrophild_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void BDc_Eosinophils_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void BDc_Lymphocytes_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void BDc_Basophils_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void BDc_Monocytes_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void BDc_Twbc_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void BDc_Trbc_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void BDc_Tplatelets_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void BDc_Aec_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void BDc_Reticulocyte_Count_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void BDc_PCV_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void BDc_Hb_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void BDc_ESR_1sthour_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void BDc_ESR_2ndhour_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            
            }
        private void callnumber(KeyPressEventArgs e)
        {
            //const char Delete = (char)8;
           // e.Handled = !Char.IsDigit(e.KeyChar) && !Char.IsPunctuation(e.KeyChar) && e.KeyChar != Delete && (e.KeyChar != '.');

            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            {
                e.Handled = true;

            }

            // only allow one decimal point
            //if (e.KeyChar == '.'
            //    && (sender as TextBox).Text.IndexOf('.') > -1)
            //{
            //    e.Handled = true;
            //}
        }
        private void callnumber1(KeyPressEventArgs e)
        {
           //  only allow one decimal point
           // if (e.KeyChar == '.'
           //     && (sender as TextBox).Text.IndexOf('.') > -1)
           //{
           //     e.Handled = true;
           // }
        }


        private void Bcr_Glucose_Fpg_RPG_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);

            if (e.KeyChar == '.'
                   && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        
        
        }

        private void Bcr_PPPG_PGPG_2hr_1hr_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
            if (e.KeyChar == '.'
                           && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        
        
        }

        private void Bcr_RP_Urea_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
            if (e.KeyChar == '.'
                   && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        
        
        }

        private void Bcr_RP_BUN_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
            if (e.KeyChar == '.'
                    && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        
        
        }

        private void Bcr_RP_Creatinine_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
            if (e.KeyChar == '.'
                   && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        
        }

        private void Bcr_LP_Cholesterol_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
            if (e.KeyChar == '.'
                           && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        
        }

        private void Bcr_LP_HDLCholesterol_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
            if (e.KeyChar == '.'
                       && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void Bcr_LP_LDLCholesterol_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
            if (e.KeyChar == '.'
                       && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void Bcr_LP_VLDLCholesterol_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
            if (e.KeyChar == '.'
                       && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void Bcr_LP_Triglycerides_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
            if (e.KeyChar == '.'
                       && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void Bcr_LP_IC_HDLC_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
            if (e.KeyChar == '.'
                       && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void Bcr_LFT_Bilirubin_total_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
            if (e.KeyChar == '.'
                       && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void Bcr_LFT_Bilirubin_Direct_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
            if (e.KeyChar == '.'
                       && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void Bcr_LFT_Alkaline_Phosphates_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
            if (e.KeyChar == '.'
                       && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void Bcr_LFT_SGOT_AST_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
            if (e.KeyChar == '.'
                       && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void Bcr_LFT_SGPT_ALT_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
            if (e.KeyChar == '.'
                       && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void Bcr_LFT_Albumin_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
            if (e.KeyChar == '.'
                       && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void Bcr_LFT_Protein_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
            if (e.KeyChar == '.'
                       && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void Bcr_LFT_Globulin_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
            if (e.KeyChar == '.'
                       && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void Bcr_LFT_AG_Ratio_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
            if (e.KeyChar == '.'
                       && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void Bcr_Electrolyte_Sodium_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
            if (e.KeyChar == '.'
                       && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void Bcr_Electrolyte_Potassium_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
            if (e.KeyChar == '.'
                       && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void Bcr_OTH_Acid_Phosphate_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bcr_OTH_Amylase_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bcr_OTH_Acid_Calcium_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bcr_OTH_Acid_Phosphorus_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bcr_OTH_Uric_Acid_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bcr_OTH_Pasting_urine_sugar_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bcr_OTH_PP_PG_urine_sugar_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void btnprinturine_Click(object sender, EventArgs e)
        {


            da = new SqlDataAdapter("select cc,comp,address,year_start,year_end,pathologist,biochemist,telphoneno,email,cstno,address1,faxno from company", con);
            ds2 = new DataSet();
            da.Fill(ds2);

            da.Dispose();
            btnclosecrv.Visible = true;
            crystalReportViewer1.Visible = true;

            String s1 = "select a.cc,a.patient_name,a.pcode,a.sex,a.age,a.doctor,a.date_exam as Dt_Report,a.month_year,b.UP_color,b.UP_reaction,b.UP_specificgravity,b.UC_sugar,b.UC_albumin,b.UC_phosphate,b.UC_chyle,b.UC_ketonebodies,b.UC_bilesalts,b.UC_bilepigment,b.UM_puscells,b.UM_epithcells,b.UM_rbc,b.UM_casts,b.UM_crystals,b.UM_bacterial,b.UM_spermatozoa,b.UM_mf_tv,b.UM_others,b.UU_urine_b_hcg,b.UA_urine_albumin,b.UN_nasalsmear,b.ur_imp,a.scn,a.tpt,b.ur_cotinine,b.up_specificgravity_onr,b.uc_php,b.us_sputumafb,b.uc_phosphate_onr from patient_master a , urine b where a.pcode=b.pcode and  a.pcode='" + cbopcode.Text + "'   order by b.pcode,a.date_exam";
            da = new SqlDataAdapter(s1, con);
            ds = new DataSet();
            da.Fill(ds, "Pathology_Urine");
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
                
                dt.Columns.Add("barcode", System.Type.GetType("System.Byte[]"));

                String qrdata = cbopcode.Text.Trim();
                BarcodeLib.Barcode.Linear qrcode = new BarcodeLib.Barcode.Linear();
                qrcode.Type = BarcodeLib.Barcode.BarcodeType.CODE39;
                qrcode.Data = qrdata;

                // Save & output QR Code barcode image to your system
                qrcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;
                byte[] imageData = qrcode.drawBarcodeAsBytes();
                //byte[] barcode = qrcode.drawBarcodeAsBytes();
           
                
                
                
                gpatient_name = ds.Tables[0].Rows[i][1].ToString();
                gcode = Convert.ToInt32(ds.Tables[0].Rows[i][2].ToString());
                gsex = ds.Tables[0].Rows[i][3].ToString();
                gage = Convert.ToInt32(ds.Tables[0].Rows[i][4].ToString());
                gdoctor = ds.Tables[0].Rows[i][5].ToString();
                gdt_report = Convert.ToDateTime(ds.Tables[0].Rows[i][6].ToString());
                gmnyr = ds.Tables[0].Rows[i][7].ToString();
                gscn = ds.Tables[0].Rows[i][31].ToString();
                gtpt = ds.Tables[0].Rows[i][32].ToString();

                if (ds.Tables[0].Rows[i][10].ToString() != "")
                {
                    Ggrp = "1.MACROSCOPIC-EX-";
                    Gdesc = "MACROSCOPIC-EX-";
                    Gdesc1 = "Volume";
                    Gresult = ds.Tables[0].Rows[i][10].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }
                if (ds.Tables[0].Rows[i][8].ToString() != "")
                {
                    Ggrp = "1.MACROSCOPIC-EX-";
                    Gdesc = "MACROSCOPIC-EX-";
                    Gdesc1 = "Colour";
                    Gresult = ds.Tables[0].Rows[i][8].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();

                }

                if (ds.Tables[0].Rows[i][37].ToString() != "")
                {
                    Ggrp = "1.MACROSCOPIC-EX-";
                    Gdesc = "MACROSCOPIC-EX-";
                    Gdesc1 = "Appearance";
                    Gresult = ds.Tables[0].Rows[i][37].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }
                
                if (ds.Tables[0].Rows[i][25].ToString() != "")
                {
                    Ggrp = "1.MACROSCOPIC-EX-";
                    Gdesc = "MACROSCOPIC-EX-";
                    Gdesc1 = "Sediment";
                    Gresult = ds.Tables[0].Rows[i][25].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }
                if (ds.Tables[0].Rows[i][34].ToString() != "")
                {
                    Ggrp = "1.MACROSCOPIC-EX-";
                    Gdesc = "MACROSCOPIC-EX-";
                    Gdesc1 = "Sp. Gravity";
                    Gresult = ds.Tables[0].Rows[i][34].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }

                if (ds.Tables[0].Rows[i][35].ToString() != "")
                {
                    Ggrp = "2.CHEMICAL-EX-";
                    Gdesc = "CHEMICAL-EX-";
                    Gdesc1 = "PH%";
                    Gresult = ds.Tables[0].Rows[i][35].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }
                
                
                if (ds.Tables[0].Rows[i][9].ToString() != "")
                {
                    Ggrp = "2.CHEMICAL-EX-";
                    Gdesc = "CHEMICAL-EX-";
                    Gdesc1 = "Reaction";
                    Gresult = ds.Tables[0].Rows[i][9].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }

                if (ds.Tables[0].Rows[i][12].ToString() != "")
                {
                    Ggrp = "2.CHEMICAL-EX-";
                    Gdesc = "CHEMICAL-EX-";
                    Gdesc1 = "Albumin";
                    Gresult = ds.Tables[0].Rows[i][12].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }
                
               if (ds.Tables[0].Rows[i][11].ToString() != "")
                {
                    Ggrp = "2.CHEMICAL-EX-";

                    Gdesc = "CHEMICAL-EX-";
                    Gdesc1 = "Sugar";
                    Gresult = ds.Tables[0].Rows[i][11].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }
               
                               
       if (ds.Tables[0].Rows[i][13].ToString() != "")
                {
                    Ggrp = "2.CHEMICAL-EX-";
                    Gdesc = "CHEMICAL-EX-";
                    Gdesc1 = "Chyle";
                    Gresult = ds.Tables[0].Rows[i][13].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }
 
                if (ds.Tables[0].Rows[i][14].ToString() != "")
                {
                    Ggrp = "2.CHEMICAL-EX-";
                    Gdesc = "CHEMICAL-EX-";
                    Gdesc1 = "Phosphate";
                    Gresult = ds.Tables[0].Rows[i][14].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }
                
               if (ds.Tables[0].Rows[i][15].ToString() != "")
                {
                    Ggrp = "2.CHEMICAL-EX-";
                    Gdesc = "CHEMICAL-EX-";
                    Gdesc1 = "Ketone Bodies";
                    Gresult = ds.Tables[0].Rows[i][15].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }
                if (ds.Tables[0].Rows[i][16].ToString() != "")
                {
                    Ggrp = "2.CHEMICAL-EX-";
                    Gdesc = "CHEMICAL-EX-";
                    Gdesc1 = "Bile Salts";
                    Gresult = ds.Tables[0].Rows[i][16].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }         
               
               
                 if (ds.Tables[0].Rows[i][17].ToString() != "")
                {
                    Ggrp = "2.CHEMICAL-EX-";
                    Gdesc = "CHEMICAL-EX-";
                    Gdesc1 = "Bile Pigments";
                    Gresult = ds.Tables[0].Rows[i][17].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }
                 if (ds.Tables[0].Rows[i][36].ToString() != "")
                 {
                     Ggrp = "2.CHEMICAL-EX-";
                     Gdesc = "CHEMICAL-EX-";
                     Gdesc1 = "Urobilinogen";
                     Gresult = ds.Tables[0].Rows[i][36].ToString();
                     Gunit = "";
                     Gnormalrange = "";
                     Gnormalrange1 = "";
                     ADDROW();
                 }
                 //if (ds.Tables[0].Rows[i][37].ToString() != "")
                 //{
                 //    Ggrp = "2.CHEMICAL-EX-";
                 //    Gdesc = "CHEMICAL-EX-";
                 //    Gdesc1 = "Benzodine Test";
                 //    Gresult = ds.Tables[0].Rows[i][37].ToString();
                 //    Gunit = "";
                 //    Gnormalrange = "";
                 //    Gnormalrange1 = "";
                 //    ADDROW();
                 //}    
                
                
                if (ds.Tables[0].Rows[i][26].ToString() != "")
                 {
                     Ggrp = "2.CHEMICAL-EX-";
                     Gdesc = "CHEMICAL-EX-";
                     Gdesc1 = "Micro Filaria";
                     Gresult = ds.Tables[0].Rows[i][26].ToString();
                     Gunit = "";
                     Gnormalrange = "";
                     Gnormalrange1 = "";
                     ADDROW();
                 }    
                
                
               
                 
                
                
                if (ds.Tables[0].Rows[i][18].ToString() != "")
                {
                    Ggrp = "3.MICROSCOPIC-EX-";
                    Gdesc = "MICROSCOPIC-EX-";
                    Gdesc1 = "Pus Cells";
                    Gresult = ds.Tables[0].Rows[i][18].ToString().Trim()+"/HPF";
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }          
     if (ds.Tables[0].Rows[i][19].ToString() != "")
                {
                    Ggrp = "3.MICROSCOPIC-EX-";
                    Gdesc = "MICROSCOPIC-EX-";
                    Gdesc1 = "Epithelial Cells";
                    Gresult = ds.Tables[0].Rows[i][19].ToString().Trim() + "/HPF";
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }    
           if (ds.Tables[0].Rows[i][20].ToString() != "")
                {
                    Ggrp = "3.MICROSCOPIC-EX-";
                    Gdesc = "MICROSCOPIC-EX-";
                    Gdesc1 = "R.B.C.";
                    Gresult = ds.Tables[0].Rows[i][20].ToString().Trim() + "/HPF";
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }          
           
          if (ds.Tables[0].Rows[i][21].ToString() != "")
                {
                    Ggrp = "3.MICROSCOPIC-EX-";
                    Gdesc = "MICROSCOPIC-EX-";
                    Gdesc1 = "Casts";
                    Gresult = ds.Tables[0].Rows[i][21].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }                
           if (ds.Tables[0].Rows[i][22].ToString() != "")
                {
                    Ggrp = "3.MICROSCOPIC-EX-";
                    Gdesc = "MICROSCOPIC-EX-";
                    Gdesc1 = "Crystals";
                    Gresult = ds.Tables[0].Rows[i][22].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }            
                
               if (ds.Tables[0].Rows[i][23].ToString() != "")
                {
                    Ggrp = "3.MICROSCOPIC-EX-";
                    Gdesc = "MICROSCOPIC-EX-";
                    Gdesc1 = "Bacterial";
                    Gresult = ds.Tables[0].Rows[i][23].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }        
        if (ds.Tables[0].Rows[i][24].ToString() != "")
                {
                    Ggrp = "3.MICROSCOPIC-EX-";
                    Gdesc = "MICROSCOPIC-EX-";
                    Gdesc1 = "Spermatozoa";
                    Gresult = ds.Tables[0].Rows[i][24].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }
        if (ds.Tables[0].Rows[i][28].ToString() != "")
        {
            Ggrp = "3.MICROSCOPIC-EX-";
            Gdesc = "MICROSCOPIC-EX-";
            Gdesc1 = "Yeast Cells";
            Gresult = ds.Tables[0].Rows[i][28].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }

        if (ds.Tables[0].Rows[i][33].ToString() != "")
        {
            Ggrp = "3.MICROSCOPIC-EX-";
            Ggrp = "3.MICROSCOPIC-EX-";
            Gdesc = "";
            Gdesc1 = "Micral Test(UACR)";
            Gresult = ds.Tables[0].Rows[i][33].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }

        if (ds.Tables[0].Rows[i][30].ToString() != "")
        {
            Ggrp = "3.MICROSCOPIC-EX-";
            Gdesc = "MICROSCOPIC-EX-";
            Gdesc1 = "Impression";
            Gresult = ds.Tables[0].Rows[i][30].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }       


                //UM_mf_tv,b.UM_others,b.UU_urine_b_hcg,b.UA_urine_albumin,b.UN_nasalsmear                      
                
                
                
                //Repurine cashbankrep = new Repurine();
                Repurinenew cashbankrep = new Repurinenew();
                //cashbankrep.SetDatabaseLogon("sa", "software", @".\SQLEXPRESS", "pathology2627");
                cashbankrep.SetDataSource(dt);
                crystalReportViewer1.ReportSource = cashbankrep;
                cashbankrep.SetParameterValue(0, ds2.Tables[0].Rows[0][5].ToString());
                cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows[0][6].ToString());
                cashbankrep.SetParameterValue(2, ds2.Tables[0].Rows[0][9].ToString());
                cashbankrep.SetParameterValue(3, ds2.Tables[0].Rows[0][10].ToString());
                cashbankrep.SetParameterValue(4, ds2.Tables[0].Rows[0][11].ToString());
                crystalReportViewer1.Refresh();
 
            }
            else
            {
                MessageBox.Show("No Records Found!!!");
            }

        }

        private void btnprintstool_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("select cc,comp,address,year_start,year_end,pathologist,biochemist,telphoneno,email,cstno,address1,faxno from company", con);
            ds2 = new DataSet();
            da.Fill(ds2);

            da.Dispose();
            
            
            btnclosestoolcrvn.Visible = true;
            crystalReportViewer2.Visible = true;

            String s1 = ("select a.cc,a.patient_name,a.pcode,a.sex,a.age,a.doctor,a.date_exam as Dt_Report,a.month_year,b.Sp_color, b.Sp_reaction,b.Sp_Mucus,b.SH_OvaHW,b.SH_larva,b.SH_OvaRW,b.SP_EHistolytica,b.SP_ecoli,b.SP_giardia,b.SP_trichomonas, b.SM_rbc_from,  b.SM_puscells_from,b.SM_macrophase,b.SM_vegetables,b.SM_yeast,b.SM_crystal,b.SM_fataglobules,b.SM_bacterialflora,b.SH_Others,b.SC_Occultblood,b.SC_Reducingsugar,b.st_imp,a.scn,a.tpt,b.SH_hymen,b.SH_taenia,b.sm_rbc_to,b.sm_puscells_to from patient_master a,stool b where a.pcode='" + cbopcode.Text + "' and a.pcode=b.pcode order by a.pcode,a.date_exam");

            da = new SqlDataAdapter(s1, con);
            ds = new DataSet();
            da.Fill(ds, "Pathology_Stool");


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

                dt.Columns.Add("barcode", System.Type.GetType("System.Byte[]"));

                String qrdata = cbopcode.Text.Trim();
                BarcodeLib.Barcode.Linear qrcode = new BarcodeLib.Barcode.Linear();
                qrcode.Type = BarcodeLib.Barcode.BarcodeType.CODE39;
                qrcode.Data = qrdata;

                // Save & output QR Code barcode image to your system
                qrcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;
                byte[] imageData = qrcode.drawBarcodeAsBytes();
               
                
                
                gpatient_name = ds.Tables[0].Rows[i][1].ToString();
                gcode = Convert.ToInt32(ds.Tables[0].Rows[i][2].ToString());
                gsex = ds.Tables[0].Rows[i][3].ToString();
                gage = Convert.ToInt32(ds.Tables[0].Rows[i][4].ToString());
                gdoctor = ds.Tables[0].Rows[i][5].ToString();
                gdt_report = Convert.ToDateTime(ds.Tables[0].Rows[i][6].ToString());
                gmnyr = ds.Tables[0].Rows[i][7].ToString();
                gscn = ds.Tables[0].Rows[i][30].ToString();
                gtpt = ds.Tables[0].Rows[i][31].ToString();
                if (ds.Tables[0].Rows[i][8].ToString() != "")
                {
                    Ggrp = "1.MACROSCOPIC";
                    Gdesc = "MACROSCOPIC";
                    Gdesc1 = "Colour";
                    Gresult = ds.Tables[0].Rows[i][8].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();

                }

                if (ds.Tables[0].Rows[i][23].ToString() != "")
                {
                    Ggrp = "1.MACROSCOPIC";
                    Gdesc = "MACROSCOPIC";
                    Gdesc1 = "Consistency";
                    Gresult = ds.Tables[0].Rows[i][23].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }
               
                
                
                
                if (ds.Tables[0].Rows[i][9].ToString() != "")
                {
                    Ggrp = "1.MACROSCOPIC";
                    Gdesc = "MACROSCOPIC";
                    Gdesc1 = "Reaction";
                    Gresult = ds.Tables[0].Rows[i][9].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }

                if (ds.Tables[0].Rows[i][17].ToString() != "")
                {
                    Ggrp = "1.MACROSCOPIC";
                    Gdesc = "MACROSCOPIC";
                    Gdesc1 = "Blood";
                    Gresult = ds.Tables[0].Rows[i][17].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }
                
                if (ds.Tables[0].Rows[i][10].ToString() != "")
                {
                    Ggrp = "1.MACROSCOPIC";
                    Gdesc = "MACROSCOPIC";
                    Gdesc1 = "Mucus";
                    Gresult = ds.Tables[0].Rows[i][10].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }

                if (ds.Tables[0].Rows[i][11].ToString() != "")
                {
                    Ggrp = "2.MICROSCOPIC";
                    Gdesc = "MICROSCOPIC";
                    Gdesc1 = "Ova of Helminths";
                    Gresult = ds.Tables[0].Rows[i][11].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }
                if (ds.Tables[0].Rows[i][12].ToString() != "")
                {
                    Ggrp = "2.MICROSCOPIC";
                    Gdesc = "MICROSCOPIC";
                    Gdesc1 = "Larva of S.Stercoralis";
                    Gresult = ds.Tables[0].Rows[i][12].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }

                if (ds.Tables[0].Rows[i][13].ToString() != "")
                {
                    Ggrp = "2.MICROSCOPIC";
                    Gdesc = "MICROSCOPIC";
                    Gdesc1 = "Ascarris lumbricoides";
                    Gresult = ds.Tables[0].Rows[i][13].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }

                if (ds.Tables[0].Rows[i][14].ToString() != "")
                {
                    Ggrp = "2.MICROSCOPIC";
                    Gdesc = "MICROSCOPIC";
                    Gdesc1 = "Cyst of E.Histolytica";
                    Gresult = ds.Tables[0].Rows[i][14].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }

                if (ds.Tables[0].Rows[i][15].ToString() != "")
                {
                    Ggrp = "2.MICROSCOPIC";
                    Gdesc = "MICROSCOPIC";
                    Gdesc1 = "E.coli";
                    Gresult = ds.Tables[0].Rows[i][15].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }
                if (ds.Tables[0].Rows[i][16].ToString() != "")
                {
                    Ggrp = "2.MICROSCOPIC";
                    Gdesc = "MICROSCOPIC";
                    Gdesc1 = "Giardia Lamblia";
                    Gresult = ds.Tables[0].Rows[i][16].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }
                if (ds.Tables[0].Rows[i][34].ToString() != "")
                {
                    Ggrp = "2.MICROSCOPIC";
                    Gdesc = "MICROSCOPIC";
                    Gdesc1 = "Trichomonas";
                    Gresult = ds.Tables[0].Rows[i][34].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }
                if (ds.Tables[0].Rows[i][35].ToString() != "")
                {
                    Ggrp = "2.MICROSCOPIC";
                    Gdesc = "MICROSCOPIC";
                    Gdesc1 = "T. Trichiura";
                    Gresult = ds.Tables[0].Rows[i][35].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }
               
                if (ds.Tables[0].Rows[i][18].ToString() != "")
                {
                    Ggrp = "2.MICROSCOPIC";
                    Gdesc = "MICROSCOPIC";
                    Gdesc1 = "R.B.C.";
                    Gresult = ds.Tables[0].Rows[i][18].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }
                if (ds.Tables[0].Rows[i][19].ToString() != "")
                {
                    Ggrp = "2.MICROSCOPIC";
                    Gdesc = "MICROSCOPIC";
                    Gdesc1 = "Pus Cells";
                    Gresult = ds.Tables[0].Rows[i][19].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }
                if (ds.Tables[0].Rows[i][20].ToString() != "")
                {
                    Ggrp = "2.MICROSCOPIC";
                    Gdesc = "MICROSCOPIC";
                    Gdesc1 = "Macrophages";
                    Gresult = ds.Tables[0].Rows[i][20].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }

                if (ds.Tables[0].Rows[i][21].ToString() != "")
                {
                    Ggrp = "2.MICROSCOPIC";
                    Gdesc = "MICROSCOPIC";
                    Gdesc1 = "Vegetable Cells";
                    Gresult = ds.Tables[0].Rows[i][21].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }
                if (ds.Tables[0].Rows[i][22].ToString() != "")
                {
                    Ggrp = "2.MICROSCOPIC";
                    Gdesc = "MICROSCOPIC";
                    Gdesc1 = "Yeast Cells";
                    Gresult = ds.Tables[0].Rows[i][22].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }
                //b.SM_yeast,b.SM_crystal,b.SM_fataglobules,b.SM_bacterialflora,b.SH_Others,b.SC_Occultblood,b.SC_Reducingsugar
               
                
                
                
                if (ds.Tables[0].Rows[i][24].ToString() != "")
                {
                    Ggrp = "2.MICROSCOPIC";
                    Gdesc = "MICROSCOPIC";
                    Gdesc1 = "Fat globules";
                    Gresult = ds.Tables[0].Rows[i][24].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }
                if (ds.Tables[0].Rows[i][25].ToString() != "")
                {
                    Ggrp = "2.MICROSCOPIC";
                    Gdesc = "MICROSCOPIC";
                    Gdesc1 = "Bacterial Flora";
                    Gresult = ds.Tables[0].Rows[i][25].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }
                if (ds.Tables[0].Rows[i][26].ToString() != "")
                {
                    Ggrp = "2.MICROSCOPIC";
                    Gdesc = "MICROSCOPIC";
                    Gdesc1 = "Starch";
                    Gresult = ds.Tables[0].Rows[i][26].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }
                if (ds.Tables[0].Rows[i][27].ToString() != "")
                {
                    Ggrp = "3.CHEMICAL";
                    Gdesc = "CHEMICAL";
                    Gdesc1 = "Occult Blood  ( Hemospot )";
                    Gresult = ds.Tables[0].Rows[i][27].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }
                if (ds.Tables[0].Rows[i][28].ToString() != "")
                {
                    Ggrp = "3.CHEMICAL";
                    Gdesc = "CHEMICAL";
                    Gdesc1 = "Sugar (Reducing)";
                    Gresult = ds.Tables[0].Rows[i][28].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }
                if (ds.Tables[0].Rows[i][29].ToString() != "")
                {
                    Ggrp = "3.OTHERS";
                    Gdesc = "OTHERS";
                    Gdesc1 = "Impression";
                    Gresult = ds.Tables[0].Rows[i][29].ToString();
                    Gunit = "";
                
                   Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }

                if (ds.Tables[0].Rows[i][32].ToString() != "")
                {
                    Ggrp = "2.MICROSCOPIC";
                    Gdesc = "MICROSCOPIC";
                    Gdesc1 = "Epithelial Cell";
                    Gresult = ds.Tables[0].Rows[i][32].ToString();
                    Gunit = "";

                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }
                if (ds.Tables[0].Rows[i][33].ToString() != "")
                {
                    Ggrp = "2.MICROSCOPIC";
                    Gdesc = "MICROSCOPIC";
                    Gdesc1 = "Crystals";
                    Gresult = ds.Tables[0].Rows[i][33].ToString();
                    Gunit = "";

                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }



                Repstoolnew1 cashbankrep = new Repstoolnew1();
                //cashbankrep.SetDatabaseLogon("sa", "software", @".\SQLEXPRESS", "pathology2627");
                cashbankrep.SetDataSource(dt);
                crystalReportViewer2.ReportSource = cashbankrep;
                cashbankrep.SetParameterValue(0, ds2.Tables[0].Rows[0][5].ToString());
                cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows[0][6].ToString());
                cashbankrep.SetParameterValue(2, ds2.Tables[0].Rows[0][9].ToString());
                cashbankrep.SetParameterValue(3, ds2.Tables[0].Rows[0][10].ToString());
                cashbankrep.SetParameterValue(4, ds2.Tables[0].Rows[0][11].ToString());
                
                
                crystalReportViewer2.Refresh();
            }
            else
            {
                MessageBox.Show("No Records Found!!!");
            }


        }



        public void ADDROW()
        {

            drw = dt.NewRow();
            drw["Grp"] = Ggrp;
            drw["Desc"] = Gdesc;
            drw["Desc1"] = Gdesc1;
            drw["Result"] = Gresult;
            drw["Unit"] = Gunit;
            drw["Normal_Range"] = Gnormalrange;
            drw["Normal_Range1"] = Gnormalrange1;
            drw["pcode"] = gcode;
            drw["Age"] = gage;
            drw["Sex"] = gsex;
            drw["Patient_name"] = gpatient_name;
            drw["dt_report"] = gdt_report;
            drw["doctor"] = gdoctor;
            drw["month_year"] = gmnyr;
            drw["scn"] = gscn;
            drw["tpt"] = gtpt;

            String qrdata = cbopcode.Text.Trim();
            BarcodeLib.Barcode.Linear qrcode = new BarcodeLib.Barcode.Linear();
            qrcode.Type = BarcodeLib.Barcode.BarcodeType.CODE39;
            qrcode.Data = qrdata;

            // Save & output QR Code barcode image to your system
            qrcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;
            byte[] imageData = qrcode.drawBarcodeAsBytes();
            //byte[] barcode = qrcode.drawBarcodeAsBytes();


            drw["barcode"] = imageData;

            
            dt.Rows.Add(drw);
            dt.AcceptChanges();
        }



        private void btnprintblood_Click(object sender, EventArgs e)
        {
            Frmrepbloodn repblood = new Frmrepbloodn();
            repblood.Show();

        }

        private void btnprintbiochem_Click(object sender, EventArgs e)
        {
            Frmrepbiochemn repbiochem = new Frmrepbiochemn();
            repbiochem.Show();
        }

  
        private void cbopcode_SelectedIndexChanged(object sender, EventArgs e)
        {

            dd = dtreport.Text.Substring(0, 2).ToString();
            mm = this.dtreport.Text.Substring(3, 2).ToString();
            yy = this.dtreport.Text.Substring(6, 4).ToString();
            repdt1 = DateTime.ParseExact(dd + "/" + mm + "/" + yy, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            
            
            RMBILLING.Enabled = true;
           pidr = Convert.ToInt32(cbopcode.Text);
            Frmbillentry.pid = Convert.ToInt32(cbopcode.Text);
            
                   
            gcode = Convert.ToInt32(cbopcode .Text );
            dataGridView1.Visible = false;
            RMSAVE.Enabled = true;
            rmdelete.Enabled = true;
            RMMERGE.Enabled = true;
         
            con.Close();
            con.Open();
            String strsql1 = "";
            String strsql2 = "";
            String strsql3 = "";
            String strsql4 = "";
            String strsql5 = "";
            String strsql6 = "";
            String strsql7 = "";
            String strsql8 = "";
            String strsql9 = "";
            String strsql10 = "";
            String strsql11 = "";
            String strsql12 = "";
            String strsql13 = "";
            String strsql14 = "";
            String strsql15 = "";
            String strsql16 = "";
            String strsql17 = "";
            String strsql18 = "";

            strsql1 = "select cc,pcode,patient_name,sex,age,doctor,date_exam,due_amount,paid_amount,month_year,Scn,Tpt,operator,referal,area";
            strsql1 = strsql1 + " from patient_master where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
            strsql2 = "select cc,pcode,UP_color,UP_reaction,UP_specificgravity,UC_sugar,UC_albumin,UC_phosphate,UC_chyle,UC_ketonebodies,UC_bilesalts,UC_bilepigment,UM_puscells,UM_epithcells,UM_rbc,UM_casts,UM_crystals,UM_bacterial,UM_spermatozoa,UM_mf_tv,UM_others,UU_urine_b_hcg,UA_urine_albumin,UN_nasalsmear,ur_imp,ur_cotinine,UP_specificgravity_onr,UC_php,US_SputumAfb,UC_phosphate_onr";
            strsql2 = strsql2 + " from Urine where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
            strsql3 = "select cc,pcode, Sp_color, Sp_reaction,Sp_Mucus,SH_OvaHW,SH_larva,SH_OvaRW,SP_EHistolytica,SP_ecoli,SP_giardia,SP_trichomonas, SM_rbc_from,  SM_puscells_from,SM_macrophase,SM_vegetables,SM_yeast,SM_crystal,SM_fataglobules,SM_bacterialflora,SH_Others,SC_Occultblood,SC_Reducingsugar,st_imp,SH_hymen,SH_taenia,sm_rbc_to,sm_puscells_to";
            strsql3 = strsql3 + " from Stool where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";


            strsql4 = "select cc,pcode,BG_Blood_Group,BR_RhD_Typing,BDc_Neutrophild,BDc_Eosinophils,BDc_Lymphocytes,";
            strsql4 = strsql4 + "BDc_Basophils,BDc_Monocytes,BDc_Twbc,BDc_Trbc,BDc_Tplatelets,BDc_Aec,BDc_Tnc,BDc_Reticulocyte_Count,";
            strsql4 = strsql4 + "BDc_PCV,BDC_mcv,BDC_mch,BDC_mchc,BDC_Pss,BDc_Mp_ICT_QBC_Smear, BDc_Mp_ICT,BDc_Mf_ICT_QBC_Smear,BDc_Mf_ICT,BDc_Rct,BDc_Hb,BDc_ESR_1sthour,";
            strsql4 = strsql4 + "BDc_Bleeding_Time,BDc_Clotting_Time,BDC_nasalsmear,BDC_nasalsmear_right,BDc_Sickle_cell,BDC_prothombintime,BDC_prothombintime_cont,BPS_Toxo,BPS_Crp,BPS_Vdrl,BPS_Ana,";
            strsql4 = strsql4 + "BPS_Rafactor,BPS_Aso,BS_Australia_Antigen,BS_Hepatitis_C_Virus,BS_HIV_1,BS_HIV_2,";
            strsql4 = strsql4 + "Bw_Widaltubeo80,Bw_Widaltubeo160,Bw_Widaltubeo320,Bw_Widaltubeo240,Bw_Widaltubeo480,Bw_Widaltubeh80,Bw_Widaltubeh160,Bw_Widaltubeh320,Bw_Widaltubeh240,Bw_Widaltubeh480,Bw_Widaltubeah80,Bw_Widaltubeah160,Bw_Widaltubeah320,Bw_Widaltubeah240,Bw_Widaltubeah480,Bw_Widaltubebh80,Bw_Widaltubebh160,Bw_Widaltubebh320,Bw_Widaltubebh240,Bw_Widaltubebh480,Bw_Widalslide1,Bw_Widalslide2,Bw_Widalslide3,Bw_Widalslide4,bw_mycodot,bw_trop,Bm_MontouxTest_injon,Bm_MontouxTest_readon,Bm_MontouxTest_induration,BDc_ESR_2ndhour,BDC_prothombintime_inr,Bdc_Dengue,BDc_typhicheck,BDc_Dengue_NSI,bl_imp,ser_imp,BDc_Rcdw,BDc_mpv,BDc_pdw,";

            strsql4 = strsql4 + "BPS_Aso_qty,BPS_Crp_qty,BPS_Rafactor_qty,Bw_Trop_qty,BDc_Mp_ICT_slide,BDc_Mp_ICT_QBC_method";
            strsql4 = strsql4 + " from Blood where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";

            //strsql14 = "select cc,pcode,BG_Blood_Group,BR_RhD_Typing,BDc_Neutrophild,BDc_Eosinophils,BDc_Lymphocytes,";
            //strsql14 = strsql14 + "BDc_Basophils,BDc_Monocytes,BDc_Twbc,BDc_Trbc,BDc_Tplatelets,BDc_Aec,BDc_Tnc,BDc_Reticulocyte_Count,";
            //strsql14 = strsql14 + "BDc_PCV,BDC_mcv,BDC_mch,BDC_mchc,BDc_Pss,BDc_Mp_ICT_QBC_Smear,BDc_Mp_ICT,BDc_Mf_ICT_QBC_Smear,BDc_Mf_ICT,BDc_Rct,BDc_Hb,BDc_ESR_1sthour,";
            //strsql14 = strsql14 + "BDc_Bleeding_Time,BDc_Clotting_Time,BDC_nasalsmear,BDC_nasalsmear_right,BDc_Sickle_cell,BDC_prothombintime,BDC_prothombintime_cont,BPS_Toxo,BPS_Crp,BPS_Vdrl,BPS_Ana,";
            //strsql14 = strsql14 + "BPS_Rafactor,BPS_Aso,BS_Australia_Antigen,BS_Hepatitis_C_Virus,BS_HIV_1,BS_HIV_2,";
            //strsql14 = strsql14 + "Bw_Widaltubeo80,Bw_Widaltubeo160,Bw_Widaltubeo320,Bw_Widaltubeo240,Bw_Widaltubeo480,Bw_Widaltubeh80,Bw_Widaltubeh160,Bw_Widaltubeh320,Bw_Widaltubeh240,Bw_Widaltubeh480,Bw_Widaltubeah80,Bw_Widaltubeah160,Bw_Widaltubeah320,Bw_Widaltubeah240,Bw_Widaltubeah480,Bw_Widaltubebh80,Bw_Widaltubebh160,Bw_Widaltubebh320,Bw_Widaltubebh240,Bw_Widaltubebh480,Bw_Widalslide1,Bw_Widalslide2,Bw_Widalslide3,Bw_Widalslide4,Bw_mycodot,bw_trop,Bm_MontouxTest_injon,Bm_MontouxTest_readon,Bm_MontouxTest_induration,BDc_ESR_2ndhour,BDC_prothombintime_inr,BDc_Dengue,BDc_typhicheck,";
            //strsql14 = strsql14 + "RE_fbs,RE_rbs,RE_urea,RE_creatinine,RE_PPPG_PGPG_2hr,RE_PPPG_PGPG_1hr,BDc_Dengue_NSI,ru_imp from Blood where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";



            strsql5 = strsql5 + "select cc,pcode,Bcr1_Glucose_Fpg_RPG,Bcr1_PPPG_PGPG_2hr,Bcr1_PPPG_PGPG_1hr,Bcr1_RBS,Bcr1_PBBS,Bcr1_PLBS,Bcr1_GTT_1hr,Bcr1_GTT_2hr,Bcr1_GTT_3hr,Bcr1_PGBS_1hr,Bcr1_PGBS_2hr,Bcr1_HBAC_fair,Bcr1_HBAC_good,Bcr1_HBAC_poor,Bcr1_MBGE,Bcr_RP_Urea,Bcr_RP_BUN,Bcr_RP_Creatinine,Bcr3_Uric_Acid,Bcr3_NPN,Bcr_LP_Cholesterol,Bcr_LP_HDLCholesterol,";
            strsql5 = strsql5 + "Bcr_LP_LDLCholesterol,Bcr_LP_VLDLCholesterol,Bcr_LP_Triglycerides,Bcr2_LP_CHR,Bcr2_LP_LHR,Bcr_LFT_Bilirubin_total,Bcr_LFT_Bilirubin_Direct,Bcr4_LFT_Indirect,Bcr_LFT_Alkaline_Phosphates,";
            strsql5 = strsql5 + "Bcr_LFT_SGOT_AST,Bcr_LFT_SGPT_ALT,Bcr_LFT_Albumin,Bcr_LFT_Protein,Bcr_LFT_Globulin,Bcr_LFT_AG_Ratio,Bcr4_LFT_GGTP,Bcr_Electrolyte_Sodium,";
            strsql5 = strsql5 + "Bcr_Electrolyte_Potassium,Bcr5_Electrolyte_Chlorides,Bcr_OTH_Acid_Phosphate,Bcr_OTH_Amylase,Bcr_OTH_Acid_Calcium,Bcr_OTH_Acid_Phosphorus,Bcr_OTH_Uric_Acid,Bcr_OTH_Pasting_urine_sugar,Bcr_OTH_PP_PG_urine_sugar,db_imp,Bcr_OTH_Lipase,Bcr_OTH_Nac";
            strsql5 = strsql5 + " from Biochemist where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";

            strsql6 = strsql6 + "select cc,pcode,FA_Timeofcollection,FA_Timeofexamination,FA_Timeofliquification,FA_Volume,FA_Reaction,FA_Color,FA_Viscocity,FA_MP_Prostaticpearls,FA_MP_Puscells,FA_MP_RBC,";
            strsql6 = strsql6 + "FA_MP_Epithcells,FA_MP_Deformed,FA_MT_Active,FA_MT_Slugish,FA_MT_Dead,FA_MT_Totalcount,FA_MT_IMP,FA_MP_Premature,patient_name";
            strsql6 = strsql6 + " from Seminal_Fluid where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
            //urine 2,stool 3,blood 4,biochemist 5,7,8,9Seminal_Fluid 6,culture 10,hormone 11

            strsql7 = strsql7 + "select cc,pcode,Bcr1_Glucose_Fpg_RPG,Bcr1_PPPG_PGPG_2hr,Bcr1_PPPG_PGPG_1hr,Bcr1_RBS,Bcr1_PBBS,Bcr1_PLBS,Bcr1_GTT_1hr,Bcr1_GTT_2hr,Bcr1_GTT_3hr,Bcr1_PGBS_1hr,Bcr1_PGBS_2hr,Bcr1_HBAC_fair,Bcr1_HBAC_good,Bcr1_HBAC_poor,Bcr1_MBGE,Bcr_RP_Urea,Bcr_RP_BUN,Bcr_RP_Creatinine,Bcr3_Uric_Acid,Bcr3_NPN,Bcr_LP_Cholesterol,Bcr_LP_HDLCholesterol,";
            strsql7 = strsql7 + "Bcr_LP_LDLCholesterol,Bcr_LP_VLDLCholesterol,Bcr_LP_Triglycerides,Bcr2_LP_CHR,Bcr2_LP_LHR,Bcr_LFT_Bilirubin_total,Bcr_LFT_Bilirubin_Direct,Bcr4_LFT_Indirect,Bcr_LFT_Alkaline_Phosphates,";
            strsql7 = strsql7 + "Bcr_LFT_SGOT_AST,Bcr_LFT_SGPT_ALT,Bcr_LFT_Albumin,Bcr_LFT_Protein,Bcr_LFT_Globulin,Bcr_LFT_AG_Ratio,Bcr4_LFT_GGTP,Bcr_Electrolyte_Sodium,";
            strsql7 = strsql7 + "Bcr_Electrolyte_Potassium,Bcr5_Electrolyte_Chlorides,Bcr_OTH_Acid_Phosphate,Bcr_OTH_Amylase,Bcr_OTH_Acid_Calcium,Bcr_OTH_Acid_Phosphorus,Bcr_OTH_Uric_Acid,Bcr_OTH_Pasting_urine_sugar,Bcr_OTH_PP_PG_urine_sugar,db_imp,Bcr_OTH_Lipase,Bcr_OTH_Nac";
            strsql7 = strsql7 + " from Biochemist where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";

            strsql8 = strsql8 + "select cc,pcode,Bcr1_Glucose_Fpg_RPG,Bcr1_PPPG_PGPG_2hr,Bcr1_PPPG_PGPG_1hr,Bcr1_RBS,Bcr1_PBBS,Bcr1_PLBS,Bcr1_GTT_1hr,Bcr1_GTT_2hr,Bcr1_GTT_3hr,Bcr1_PGBS_1hr,Bcr1_PGBS_2hr,Bcr1_HBAC_fair,Bcr1_HBAC_good,Bcr1_HBAC_poor,Bcr1_MBGE,Bcr_RP_Urea,Bcr_RP_BUN,Bcr_RP_Creatinine,Bcr3_Uric_Acid,Bcr3_NPN,Bcr_LP_Cholesterol,Bcr_LP_HDLCholesterol,";
            strsql8 = strsql8 + "Bcr_LP_LDLCholesterol,Bcr_LP_VLDLCholesterol,Bcr_LP_Triglycerides,Bcr2_LP_CHR,Bcr2_LP_LHR,Bcr_LFT_Bilirubin_total,Bcr_LFT_Bilirubin_Direct,Bcr4_LFT_Indirect,Bcr_LFT_Alkaline_Phosphates,";
            strsql8 = strsql8 + "Bcr_LFT_SGOT_AST,Bcr_LFT_SGPT_ALT,Bcr_LFT_Albumin,Bcr_LFT_Protein,Bcr_LFT_Globulin,Bcr_LFT_AG_Ratio,Bcr4_LFT_GGTP,Bcr_Electrolyte_Sodium,";
            strsql8 = strsql8 + "Bcr_Electrolyte_Potassium,Bcr5_Electrolyte_Chlorides,Bcr_OTH_Acid_Phosphate,Bcr_OTH_Amylase,Bcr_OTH_Acid_Calcium,Bcr_OTH_Acid_Phosphorus,Bcr_OTH_Uric_Acid,Bcr_OTH_Pasting_urine_sugar,Bcr_OTH_PP_PG_urine_sugar,db_imp,Bcr_OTH_Lipase,Bcr_OTH_Nac";
            strsql8 = strsql8 + " from Biochemist where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";

            strsql9 = strsql9 + "select cc,pcode,Bcr1_Glucose_Fpg_RPG,Bcr1_PPPG_PGPG_2hr,Bcr1_PPPG_PGPG_1hr,Bcr1_RBS,Bcr1_PBBS,Bcr1_PLBS,Bcr1_GTT_1hr,Bcr1_GTT_2hr,Bcr1_GTT_3hr,Bcr1_PGBS_1hr,Bcr1_PGBS_2hr,Bcr1_HBAC_fair,Bcr1_HBAC_good,Bcr1_HBAC_poor,Bcr1_MBGE,Bcr_RP_Urea,Bcr_RP_BUN,Bcr_RP_Creatinine,Bcr3_Uric_Acid,Bcr3_NPN,Bcr_LP_Cholesterol,Bcr_LP_HDLCholesterol,";
            strsql9 = strsql9 + "Bcr_LP_LDLCholesterol,Bcr_LP_VLDLCholesterol,Bcr_LP_Triglycerides,Bcr2_LP_CHR,Bcr2_LP_LHR,Bcr_LFT_Bilirubin_total,Bcr_LFT_Bilirubin_Direct,Bcr4_LFT_Indirect,Bcr_LFT_Alkaline_Phosphates,";
            strsql9 = strsql9 + "Bcr_LFT_SGOT_AST,Bcr_LFT_SGPT_ALT,Bcr_LFT_Albumin,Bcr_LFT_Protein,Bcr_LFT_Globulin,Bcr_LFT_AG_Ratio,Bcr4_LFT_GGTP,Bcr_Electrolyte_Sodium,";
            strsql9 = strsql9 + "Bcr_Electrolyte_Potassium,Bcr5_Electrolyte_Chlorides,Bcr_OTH_Acid_Phosphate,Bcr_OTH_Amylase,Bcr_OTH_Acid_Calcium,Bcr_OTH_Acid_Phosphorus,Bcr_OTH_Uric_Acid,Bcr_OTH_Pasting_urine_sugar,Bcr_OTH_PP_PG_urine_sugar,db_imp,Bcr_OTH_Lipase,Bcr_OTH_Nac";
            strsql9 = strsql9 + " from Biochemist where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";

            
            strsql11 = strsql11 + "select cc,pcode,TOTAL_TRIIODOTHYRONINE_T3,TOTAL_THYROXINE_T4,TSH,FREE_TRIIODOTHYRONINE_FT3,FREE_THYROXINE_FT4,ANTIMICROSOMAL_ANTIBODY_AMA,TOTAL_CHOLESTEROL,PROLACTIN_PRL,PROSTATESPECIFICANTIGEN_PSA,ADENOSINE_DEAMINASE,ANTITUBERCULOSIS_TB_IgG,ANTITUBERCULOSIS_TB_IgM,ANTITUBERCULOSIS_TB_IgA,BHCG,CA_125,ANA,hm_imp";
            strsql11 = strsql11 + " from Hormone where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";


            strsql12 = strsql12 + "select cc,pcode,Specimen,Benign_Cell,Endocervical_Cell,Inflammatory_Cell,Trichomonas,Monilia,Endometrial_Cell,Spermatozoa,Rbc,Dysplastic_Cell,Malignant_Cell,Others,Impression";
            strsql12 = strsql12 + " from Cytology where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";

            strsql13 = strsql13 + "select cc,pcode,Specimen,Qty,Appearance,Color,ClotFormation,Sugar,Microprotein,Neutrophil,Lymphocyte,Total_cell_count,Rbc,Malignant_Cell,Impression,abnormal_cell";
            strsql13 = strsql13 + " from Body_fluid_analysis where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";

            strsql15 = strsql15 + "select cc,pcode,Specimen,gross_exam,microscopic,Impression";
            strsql15 = strsql15 + " from histopathology where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";

            strsql16 = strsql16 + "select cc,pcode,sr_afp,SR_ASA,SR_CV_IGG,SR_CV_IGM,SR_HSV_IGG,SR_HSV_IGM,SR_RV_IGG,";
            strsql16 = strsql16 + "SR_RV_IGM,SR_HBSA,SR_AHBSAT,SR_HBEA,SR_AHBEAT,sr_ahbca_igm,sr_ahbcat,SR_AHAV_IGM,SR_AHAVT,";
            strsql16 = strsql16 + "SR_AHCVT,SR_AHEV_IGM,sr_hp_igg,sr_hp_igm,sr_hp_iga,ser_imp";
            strsql16 = strsql16 + " from blood where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
            strsql17 = strsql17 + "select cc,pcode,note";
            strsql17 = strsql17 + " from notepad where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";

            strsql18 = strsql18 + "select cc,pcode,Specimen,gross_exam,microscopic,Impression";
            strsql18 = strsql18 + " from xray where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
            
            
            dgvos.Rows.Clear();
            //Double dbval = 0.00;
            da = new SqlDataAdapter("select test,method,result,unit,normal_range from outsource where pcode='" + cbopcode.Text.Trim() + "' order by test ", con);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dgvos.Rows.Add();
                    dgvos.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][0].ToString();
                    dgvos.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][1].ToString();
                    dgvos.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][2].ToString();
                    dgvos.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][3].ToString();
                    dgvos.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][4].ToString();

                   

                }

                
            }

            da.Dispose();
             
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
                txtdue.Text = ds1.Tables[0].Rows[0][7].ToString();
                txtpaid.Text = ds1.Tables[0].Rows[0][8].ToString();
                cbomy1.Text = ds1.Tables[0].Rows[0][9].ToString();
                txtscn.Text = ds1.Tables[0].Rows[0][10].ToString();
                txttpt.Text = ds1.Tables[0].Rows[0][11].ToString();
                //txtoperator  = ds1.Tables[0].Rows[0][12].ToString().;
                String opr1=ds1.Tables[0].Rows[0][12].ToString();
               txtoperator.Text = rusrname1;
               cboreferal.Text = ds1.Tables[0].Rows[0][13].ToString();
               txtadr.Text = ds1.Tables[0].Rows[0][14].ToString();
            }

            da = new SqlDataAdapter(strsql2, con);
            ds2 = new DataSet();
            da.Fill(ds2);
            if (ds2.Tables[0].Rows.Count != 0)
            {
                txtcompanycode.Text = ds2.Tables[0].Rows[0][0].ToString();
                cbopcode.Text = ds2.Tables[0].Rows[0][1].ToString();
                UP_color.Text = ds2.Tables[0].Rows[0][2].ToString();
                // UP_sediments.Text = ds2.Tables[0].Rows[0][3].ToString();
                UP_reaction.Text = ds2.Tables[0].Rows[0][3].ToString();
                UP_specificgravity.Text = ds2.Tables[0].Rows[0][4].ToString();
                //chkspecificgravity.Text = ds.Tables[0].Rows[0][11].ToString();
                UC_sugar.Text = ds2.Tables[0].Rows[0][5].ToString();
                UC_albumin.Text = ds2.Tables[0].Rows[0][6].ToString();
                UC_phosphate.Text = ds2.Tables[0].Rows[0][7].ToString();
                //chkphosphate.Text = ds2.Tables[0].Rows[0][15].ToString();
                UC_chyle.Text = ds2.Tables[0].Rows[0][8].ToString();
                //chkchyle.Text = ds.Tables[0].Rows[0][17].ToString();
                UC_ketonebodies.Text = ds2.Tables[0].Rows[0][9].ToString();
                //chkketonebodies.Text = ds.Tables[0].Rows[0][19].ToString();
                UC_bilesalts.Text = ds2.Tables[0].Rows[0][10].ToString();
                //chkbilesalts.Text = ds.Tables[0].Rows[0][21].ToString();
                UC_bilepigment.Text = ds2.Tables[0].Rows[0][11].ToString();
                // chkbilepigment.Text = ds.Tables[0].Rows[0][23].ToString();
                UM_puscells.Text = ds2.Tables[0].Rows[0][12].ToString();
                UM_epithcells.Text = ds2.Tables[0].Rows[0][13].ToString();
                UM_rbc.Text = ds2.Tables[0].Rows[0][14].ToString();
                UM_casts.Text = ds2.Tables[0].Rows[0][15].ToString();
                UM_crystals.Text = ds2.Tables[0].Rows[0][16].ToString();
                UM_bacterial.Text = ds2.Tables[0].Rows[0][17].ToString();
                UM_spermatozoa.Text = ds2.Tables[0].Rows[0][18].ToString();
                UM_mf_tv.Text = ds2.Tables[0].Rows[0][19].ToString();
                UM_others.Text = ds2.Tables[0].Rows[0][20].ToString();
                UU_urine_b_hcg.Text = ds2.Tables[0].Rows[0][21].ToString();
                UA_urine_albumin.Text = ds2.Tables[0].Rows[0][22].ToString();
                BDc_Nasalsmear.Text = ds2.Tables[0].Rows[0][23].ToString();
                ur_imp.Text = ds2.Tables[0].Rows[0][24].ToString();
                txtmicrofilaria.Text = ds2.Tables[0].Rows[0][25].ToString();
                Ur_spgr .Text =ds2.Tables[0].Rows[0][26].ToString();
                Ur_php .Text =ds2.Tables[0].Rows[0][27].ToString();
                Ur_urobil .Text =ds2.Tables[0].Rows[0][28].ToString();
                Ur_benzodine.Text = ds2.Tables[0].Rows[0][29].ToString();
            
            }

            else
            {
                //txtcompanycode.Text ="";
                //cbopcode.Text = "";
                UP_color.Text = "";
                // UP_sediments.Text = ds2.Tables[0].Rows[0][3].ToString();
                UP_reaction.Text = "";
                UP_specificgravity.Text = "";
                //chkspecificgravity.Text = ds.Tables[0].Rows[0][11].ToString();
                UC_sugar.Text = "";
                UC_albumin.Text = "";
                UC_phosphate.Text = "";
                //chkphosphate.Text = "";
                UC_chyle.Text = "";
                //chkchyle.Text = "";
                UC_ketonebodies.Text = "";
                //chkketonebodies.Text ="";
                UC_bilesalts.Text = "";
                //chkbilesalts.Text = "";
                UC_bilepigment.Text = "";
                // chkbilepigment.Text = ds.Tables[0].Rows[0][23].ToString();
                UM_puscells.Text = "";
                UM_epithcells.Text = "";
                UM_rbc.Text = "";
                UM_casts.Text = "";
                UM_crystals.Text = "";
                UM_bacterial.Text = "";
                UM_spermatozoa.Text = "";
                UM_mf_tv.Text = "";
                UM_others.Text = "";
                UU_urine_b_hcg.Text = "";
                UA_urine_albumin.Text = "";
                BDc_Nasalsmear.Text = "";
                ur_imp.Text = "";
                txtmicrofilaria.Text = "";
                //BDC_Sputumafb.Text = "";
                Ur_spgr.Text = "";
                Ur_php.Text = "";
                Ur_urobil.Text = "";
                Ur_benzodine.Text = "";
            }


            da = new SqlDataAdapter(strsql3, con);
            ds3 = new DataSet();
            da.Fill(ds3);
            if (ds3.Tables[0].Rows.Count != 0)
            {


                // cc,pcode, Sp_color, Sp_reaction,Sp_Mucus,SH_OvaHW,SH_larva,SH_OvaRW,SP_EHistolytica,SP_ecoli,SP_giardia,SP_trichomonas, SM_rbc_from,  SM_puscells_from,SM_macrophase,SM_vegetables,SM_yeast,SM_crystal,SM_fataglobules,SM_bacterialflora,SH_Others,SC_Occultblood,SC_Reducingsugar
                txtcompanycode.Text = ds3.Tables[0].Rows[0][0].ToString();
                cbopcode.Text = ds3.Tables[0].Rows[0][1].ToString();
                Sp_color.Text = ds3.Tables[0].Rows[0][2].ToString();
                Sp_reaction.Text = ds3.Tables[0].Rows[0][3].ToString();
                SP_mucus.Text = ds3.Tables[0].Rows[0][4].ToString();
                SH_OvaHW.Text = ds3.Tables[0].Rows[0][5].ToString();
                SH_Larva.Text = ds3.Tables[0].Rows[0][6].ToString();
                SH_OvaRW.Text = ds3.Tables[0].Rows[0][7].ToString();
                SP_EHistolytica.Text = ds3.Tables[0].Rows[0][8].ToString();
                SP_ecoli.Text = ds3.Tables[0].Rows[0][9].ToString();
                SP_giardia.Text = ds3.Tables[0].Rows[0][10].ToString();
                SP_trichmonas.Text = ds3.Tables[0].Rows[0][11].ToString();


                SM_rbc_from.Text = ds3.Tables[0].Rows[0][12].ToString();
                //SM_rbc_to.Text = ds3.Tables[0].Rows[0][6].ToString();
                SM_puscells_from.Text = ds3.Tables[0].Rows[0][13].ToString();
                //SM_puscells_to.Text = ds3.Tables[0].Rows[0][8].ToString();
                SM_macrophase.Text = ds3.Tables[0].Rows[0][14].ToString();
                SM_vegetables.Text = ds3.Tables[0].Rows[0][15].ToString();
                // SM_fataglobules.Text = ds3.Tables[0].Rows[0][11].ToString();
                SM_yeast.Text = ds3.Tables[0].Rows[0][16].ToString();
                SM_crystal.Text = ds3.Tables[0].Rows[0][17].ToString();
                SM_fatglobules.Text = ds3.Tables[0].Rows[0][18].ToString();
                SM_bacterialflora.Text = ds3.Tables[0].Rows[0][19].ToString();

                SM_other_crystal.Text = ds3.Tables[0].Rows[0][20].ToString();
                SC_Occultblood.Text = ds3.Tables[0].Rows[0][21].ToString();
                SC_Reducingsugar.Text = ds3.Tables[0].Rows[0][22].ToString();
                st_imp1.Text = ds3.Tables[0].Rows[0][23].ToString();

                SH_hymene.Text = ds3.Tables[0].Rows[0][24].ToString();
                SH_crystal1.Text = ds3.Tables[0].Rows[0][25].ToString();
                sm_rbc_to.Text = ds3.Tables[0].Rows[0][26].ToString();
                sm_puscells_to.Text = ds3.Tables[0].Rows[0][27].ToString();
               
            }
            else
            {
                
                Sp_color.Text = "";
                Sp_reaction.Text = "";
                SP_mucus.Text = "";
                SM_rbc_from.Text = "";
                //SM_rbc_to.Text = "";
                SM_puscells_from.Text = "";
                //SM_puscells_to.Text = "";
                SM_macrophase.Text = "";
                SM_vegetables.Text = "";
                SM_fatglobules.Text = "";
                SM_yeast.Text = "";
                SM_crystal.Text = "";
                SM_bacterialflora.Text = "";
                SP_EHistolytica.Text = "";
                SP_ecoli.Text = "";
                SP_giardia.Text = "";
                SP_trichmonas.Text = "";
                SH_OvaHW.Text = "";
                SH_Larva.Text = "";
                SH_OvaRW.Text = "";
                SM_other_crystal.Text = "";
                SC_Occultblood.Text = "";
                SC_Reducingsugar.Text = "";
                st_imp1.Text = "";

                SH_hymene.Text = "";
                SH_crystal1.Text = "";
                sm_rbc_to.Text ="";
                sm_puscells_to.Text ="";
            }



            da = new SqlDataAdapter(strsql4, con);
            ds4 = new DataSet();
            da.Fill(ds4);
            if (ds4.Tables[0].Rows.Count != 0)
            {
                txtcompanycode.Text = ds4.Tables[0].Rows[0][0].ToString();
                cbopcode.Text = ds4.Tables[0].Rows[0][1].ToString();
                BG_Blood_Group.Text = ds4.Tables[0].Rows[0][2].ToString();
                BR_RhD_Typing.Text = ds4.Tables[0].Rows[0][3].ToString();
                BDc_Neutrophild.Text = ds4.Tables[0].Rows[0][4].ToString();
                BDc_Eosinophils.Text = ds4.Tables[0].Rows[0][5].ToString();
                BDc_Lymphocytes.Text = ds4.Tables[0].Rows[0][6].ToString();
                BDc_Basophils.Text = ds4.Tables[0].Rows[0][7].ToString();
                BDc_Monocytes.Text = ds4.Tables[0].Rows[0][8].ToString();
                BDc_Twbc.Text = ds4.Tables[0].Rows[0][9].ToString();
                BDc_Trbc.Text = ds4.Tables[0].Rows[0][10].ToString();
                BDc_Tplatelets.Text = ds4.Tables[0].Rows[0][11].ToString();
                BDc_Aec.Text = ds4.Tables[0].Rows[0][12].ToString();
                BDc_Tnc.Text = ds4.Tables[0].Rows[0][13].ToString();

                BDc_Reticulocyte_Count.Text = ds4.Tables[0].Rows[0][14].ToString();
                BDc_PCV.Text = ds4.Tables[0].Rows[0][15].ToString();
                BDCmcv.Text = ds4.Tables[0].Rows[0][16].ToString();
                BDCmch.Text = ds4.Tables[0].Rows[0][17].ToString();
                BDCmchc.Text = ds4.Tables[0].Rows[0][18].ToString();
                CBDcPSS.Text = ds4.Tables[0].Rows[0][19].ToString();
                BDc_Mp_ICT_QBC_Smear.Text = ds4.Tables[0].Rows[0][20].ToString();
                BDc_Mp_ICT.Text = ds4.Tables[0].Rows[0][21].ToString();
                BDc_Mf_ICT_QBC_Smear.Text = ds4.Tables[0].Rows[0][22].ToString();
                BDc_Mf_ICT.Text = ds4.Tables[0].Rows[0][23].ToString();
                BDc_Rct.Text = ds4.Tables[0].Rows[0][24].ToString();
                BDc_Hb.Text = ds4.Tables[0].Rows[0][25].ToString();
                BDc_ESR_1sthour.Text = ds4.Tables[0].Rows[0][26].ToString();
                // BDc_ESR_2ndhour.Text = ds4.Tables[0].Rows[0][27].ToString();
                BDc_Bleeding_Time.Text = ds4.Tables[0].Rows[0][27].ToString();
                BDc_Clotting_Time.Text = ds4.Tables[0].Rows[0][28].ToString();
                BDc_Nasalsmear.Text = ds4.Tables[0].Rows[0][29].ToString();
                BDc_Nasalsmear_Right.Text = ds4.Tables[0].Rows[0][30].ToString();
                BDc_Sickle_cell.Text = ds4.Tables[0].Rows[0][31].ToString();
                BDc_Prothombintime.Text = ds4.Tables[0].Rows[0][32].ToString();
                BDc_Prothombintime_cont.Text = ds4.Tables[0].Rows[0][33].ToString();
                SBPS_Toxo.Text = ds4.Tables[0].Rows[0][34].ToString();
                SBPS_Crp.Text = ds4.Tables[0].Rows[0][35].ToString();
                SBPS_vdrl.Text = ds4.Tables[0].Rows[0][36].ToString();
                SBPS_Ana.Text = ds4.Tables[0].Rows[0][37].ToString();
                SBPS_Rafactor.Text = ds4.Tables[0].Rows[0][38].ToString();
                SBPS_Aso.Text = ds4.Tables[0].Rows[0][39].ToString();
                SBS_Australia_Antigen.Text = ds4.Tables[0].Rows[0][40].ToString();
                SBS_Hepatitis_C_Virus.Text = ds4.Tables[0].Rows[0][41].ToString();
                SBS_HIV_1.Text = ds4.Tables[0].Rows[0][42].ToString();
                SBS_HIV_2.Text = ds4.Tables[0].Rows[0][43].ToString();
                //BS_Ict_PF_PV.Text = ds4.Tables[0].Rows[0][45].ToString();

                BWwidaltubeo80.Text = ds4.Tables[0].Rows[0][44].ToString();
                BWwidaltubeo160.Text = ds4.Tables[0].Rows[0][45].ToString();
                BWwidaltubeo320.Text = ds4.Tables[0].Rows[0][46].ToString();
                BWwidaltubeo240.Text = ds4.Tables[0].Rows[0][47].ToString();
                BWwidaltubeo480.Text = ds4.Tables[0].Rows[0][48].ToString();

                BWwidaltubeh80.Text = ds4.Tables[0].Rows[0][49].ToString();
                BWwidaltubeh160.Text = ds4.Tables[0].Rows[0][50].ToString();
                BWwidaltubeh320.Text = ds4.Tables[0].Rows[0][51].ToString();
                BWwidaltubeh240.Text = ds4.Tables[0].Rows[0][52].ToString();
                BWwidaltubeh480.Text = ds4.Tables[0].Rows[0][53].ToString();

                BWwidaltubeah80.Text = ds4.Tables[0].Rows[0][54].ToString();
                BWwidaltubeah160.Text = ds4.Tables[0].Rows[0][55].ToString();
                BWwidaltubeah320.Text = ds4.Tables[0].Rows[0][56].ToString();
                BWwidaltubeah240.Text = ds4.Tables[0].Rows[0][57].ToString();
                BWwidaltubeah480.Text = ds4.Tables[0].Rows[0][58].ToString();


                BWwidaltubebh80.Text = ds4.Tables[0].Rows[0][59].ToString();
                BWwidaltubebh160.Text = ds4.Tables[0].Rows[0][60].ToString();
                BWwidaltubebh320.Text = ds4.Tables[0].Rows[0][61].ToString();
                BWwidaltubebh240.Text = ds4.Tables[0].Rows[0][62].ToString();
                BWwidaltubebh480.Text = ds4.Tables[0].Rows[0][63].ToString();

                BWwidalslide1.Text = ds4.Tables[0].Rows[0][64].ToString();
                BWwidalslide2.Text = ds4.Tables[0].Rows[0][65].ToString();
                BWwidalslide3.Text = ds4.Tables[0].Rows[0][66].ToString();
                BWwidalslide4.Text = ds4.Tables[0].Rows[0][67].ToString();
                SBS_mycodot.Text = ds4.Tables[0].Rows[0][68].ToString();
                SBS_trop.Text = ds4.Tables[0].Rows[0][69].ToString();

                SBm_MontouxTest_injon.Text = ds4.Tables[0].Rows[0][70].ToString();
                SBm_MontouxTest_readon.Text = ds4.Tables[0].Rows[0][71].ToString();
                SBm_MontouxTest_induration.Text = ds4.Tables[0].Rows[0][72].ToString();
                BDc_ESR_2ndhour.Text = ds4.Tables[0].Rows[0][73].ToString();
                BDc_Prothombintime_inr.Text = ds4.Tables[0].Rows[0][74].ToString();
                SBS_Dengue.Text = ds4.Tables[0].Rows[0][75].ToString();
                
                SBS_Typhicheck.Text = ds4.Tables[0].Rows[0][76].ToString();
                SBS_Dengue_NSI.Text = ds4.Tables[0].Rows[0][77].ToString();
                bl_imp.Text = ds4.Tables[0].Rows[0][78].ToString();
                ser_imp.Text = ds4.Tables[0].Rows[0][79].ToString();
                BDcRcdw.Text = ds4.Tables[0].Rows[0][80].ToString();
                BDCmpv.Text  = ds4.Tables[0].Rows[0][81].ToString();
                BDCpdw.Text = ds4.Tables[0].Rows[0][82].ToString();
               
                SBPS_Aso_Qty.Text = ds4.Tables[0].Rows[0][83].ToString();
                SBPS_Crp_Qty.Text = ds4.Tables[0].Rows[0][84].ToString();
                SBPS_Rafactor_Qty.Text = ds4.Tables[0].Rows[0][85].ToString();

                SBS_trop_Qty.Text = ds4.Tables[0].Rows[0][86].ToString();
                BDc_Mp_ICT_slide.Text = ds4.Tables[0].Rows[0][87].ToString();
                BDc_Mp_ICT_QBC_method.Text = ds4.Tables[0].Rows[0][88].ToString();
            
            }
            else
            {

                
                BG_Blood_Group.Text = "";
                BR_RhD_Typing.Text = "";
                BDc_Neutrophild.Text = "0";
                BDc_Eosinophils.Text = "0";
                BDc_Lymphocytes.Text = "0";
                BDc_Basophils.Text = "0";
                BDc_Monocytes.Text = "0";
                BDc_Twbc.Text = "0";
                BDc_Trbc.Text = "0";
                BDc_Tplatelets.Text = "0";
                BDc_Aec.Text = "0";
                BDc_Reticulocyte_Count.Text = "0";
                BDc_Tnc.Text = "0";


                BDc_PCV.Text = "0";
                BDCmcv.Text = "0";
                BDCmch.Text = "0";
                BDCmchc.Text = "0";

                CBDcPSS.Text = "";
                BDc_Mp_ICT_QBC_Smear.Text = "";
                BDc_Mp_ICT.Text = "";
                BDc_Mf_ICT_QBC_Smear.Text = "";
                BDc_Mf_ICT.Text = "";
                BDc_Rct.Text = "0";
                BDc_Hb.Text = "0";
                BDc_ESR_1sthour.Text = "0";
                // BDc_ESR_2ndhour.Text = "0";
                BDc_Bleeding_Time.Text = "";
                BDc_Clotting_Time.Text = "";
                BDc_Nasalsmear.Text = "";
                BDc_Nasalsmear_Right.Text = "";
                BDc_Sickle_cell.Text = "";
                BDc_Prothombintime.Text = "";
                BDc_Prothombintime_cont.Text = "";
                SBPS_Toxo.Text = "";
                SBPS_Crp.Text = "";
                SBPS_vdrl.Text = "";
                SBPS_Ana.Text = "";
                SBPS_Rafactor.Text = "";
                SBPS_Aso.Text = "";
                SBS_Australia_Antigen.Text = "";
                SBS_Hepatitis_C_Virus.Text = "";
                SBS_HIV_1.Text = "";
                SBS_HIV_2.Text = "";
                //BS_Ict_PF_PV.Text = ds4.Tables[0].Rows[0][45].ToString();

                BWwidaltubeo80.Text = "";
                BWwidaltubeo160.Text = "";
                BWwidaltubeo320.Text = "";
                BWwidaltubeo240.Text = "";
                BWwidaltubeo480.Text = "";

                BWwidaltubeh80.Text = "";
                BWwidaltubeh160.Text = "";
                BWwidaltubeh320.Text = "";
                BWwidaltubeh240.Text = "";
                BWwidaltubeh480.Text = "";

                BWwidaltubeah80.Text = "";
                BWwidaltubeah160.Text = "";
                BWwidaltubeah320.Text = "";
                BWwidaltubeah240.Text = "";
                BWwidaltubeah480.Text = "";

                BWwidaltubebh80.Text = "";
                BWwidaltubebh160.Text = "";
                BWwidaltubebh320.Text = "";
                BWwidaltubebh240.Text = "";
                BWwidaltubebh480.Text = "";

                BWwidalslide1.Text = "";
                BWwidalslide2.Text = "";
                BWwidalslide3.Text = "";
                BWwidalslide4.Text = "";
                SBS_mycodot.Text = "";
                SBS_trop.Text = "";

                SBm_MontouxTest_injon.Text = "";
                SBm_MontouxTest_readon.Text = "";
                SBm_MontouxTest_induration.Text = "";
                BDc_ESR_2ndhour.Text = "0";
                BDc_Prothombintime_inr.Text = "";
                SBS_Dengue.Text = "";
                SBS_Dengue_NSI.Text = "";
                SBS_Typhicheck.Text = "";
                bl_imp.Text = "";
                ser_imp.Text = "";
                BDcRcdw.Text = "0";
                BDCmpv.Text = "0";
                BDCpdw.Text = "0";
                SBPS_Aso_Qty.Text = "0";
                SBPS_Crp_Qty.Text = "0";
                SBPS_Rafactor_Qty.Text = "0";

                SBS_trop_Qty.Text = "0";
                BDc_Mp_ICT_slide.Text = "";
                BDc_Mp_ICT_QBC_method.Text = "";
            
            }

            da.Dispose();
            
            da = new SqlDataAdapter(strsql5, con);
            ds5 = new DataSet();
            da.Fill(ds5);
            if (ds5.Tables[0].Rows.Count != 0)
            {
                txtcompanycode.Text = ds5.Tables[0].Rows[0][0].ToString();
                cbopcode.Text = ds5.Tables[0].Rows[0][1].ToString();
                Bcr1_Glucose_Fpg_RPG.Text = ds5.Tables[0].Rows[0][2].ToString();
                Bcr1_PPPG_PGPG_2hr.Text = ds5.Tables[0].Rows[0][3].ToString();
                Bcr1_PPPG_PGPG_1hr.Text = ds5.Tables[0].Rows[0][4].ToString();
                Bcr1_RBS.Text = ds5.Tables[0].Rows[0][5].ToString();
                Bcr1_PBBS.Text = ds5.Tables[0].Rows[0][6].ToString();
                Bcr1_PLBS.Text = ds5.Tables[0].Rows[0][7].ToString();
                Bcr1_GTT_1hr.Text = ds5.Tables[0].Rows[0][8].ToString();
                Bcr1_GTT_2hr.Text = ds5.Tables[0].Rows[0][9].ToString();
                Bcr1_GTT_3hr.Text = ds5.Tables[0].Rows[0][10].ToString();
                Bcr1_PGBS_1hr.Text = ds5.Tables[0].Rows[0][11].ToString();
                Bcr1_PGBS_2hr.Text = ds5.Tables[0].Rows[0][12].ToString();
                Bcr1_HBAC_fair.Text = ds5.Tables[0].Rows[0][13].ToString();
                Bcr1_HBAC_good.Text = ds5.Tables[0].Rows[0][14].ToString();
                Bcr1_HBAC_poor.Text = ds5.Tables[0].Rows[0][15].ToString();
                Bcr1_MBGE.Text = ds5.Tables[0].Rows[0][16].ToString();
                Bcr_RP_Urea.Text = ds5.Tables[0].Rows[0][17].ToString();
                Bcr_RP_BUN.Text = ds5.Tables[0].Rows[0][18].ToString();
                Bcr_RP_Creatinine.Text = ds5.Tables[0].Rows[0][19].ToString();
                Bcr3_Uric_Acid.Text = ds5.Tables[0].Rows[0][20].ToString();
                Bcr3_NPN.Text = ds5.Tables[0].Rows[0][21].ToString();

                Bcr_LP_Cholesterol.Text = ds5.Tables[0].Rows[0][22].ToString();
                Bcr_LP_HDLCholesterol.Text = ds5.Tables[0].Rows[0][23].ToString();
                Bcr_LP_LDLCholesterol.Text = ds5.Tables[0].Rows[0][24].ToString();
                Bcr_LP_VLDLCholesterol.Text = ds5.Tables[0].Rows[0][25].ToString();
                Bcr_LP_Triglycerides.Text = ds5.Tables[0].Rows[0][26].ToString();
                Bcr2_LP_CHR.Text = ds5.Tables[0].Rows[0][27].ToString();
                Bcr2_LP_LHR.Text = ds5.Tables[0].Rows[0][28].ToString();
                Bcr_LFT_Bilirubin_total.Text = ds5.Tables[0].Rows[0][29].ToString();
                Bcr_LFT_Bilirubin_Direct.Text = ds5.Tables[0].Rows[0][30].ToString();
                Bcr4_LFT_Indirect.Text = ds5.Tables[0].Rows[0][31].ToString();

                Bcr_LFT_Alkaline_Phosphates.Text = ds5.Tables[0].Rows[0][32].ToString();
                Bcr_LFT_SGOT_AST.Text = ds5.Tables[0].Rows[0][33].ToString();
                Bcr_LFT_SGPT_ALT.Text = ds5.Tables[0].Rows[0][34].ToString();
                Bcr_LFT_Albumin.Text = ds5.Tables[0].Rows[0][35].ToString();
                Bcr_LFT_Protein.Text = ds5.Tables[0].Rows[0][36].ToString();
                Bcr_LFT_Globulin.Text = ds5.Tables[0].Rows[0][37].ToString();
                Bcr_LFT_AG_Ratio.Text = ds5.Tables[0].Rows[0][38].ToString();
                Bcr4_LFT_GGTP.Text = ds5.Tables[0].Rows[0][39].ToString();
                Bcr_Electrolyte_Sodium.Text = ds5.Tables[0].Rows[0][40].ToString();
                Bcr_Electrolyte_Potassium.Text = ds5.Tables[0].Rows[0][41].ToString();
                Bcr5_Electrolyte_Chlorides.Text = ds5.Tables[0].Rows[0][42].ToString();
                Bcr_OTH_Acid_Phosphate.Text = ds5.Tables[0].Rows[0][43].ToString();
                Bcr_OTH_Amylase.Text = ds5.Tables[0].Rows[0][44].ToString();
                Bcr_OTH_Acid_Calcium.Text = ds5.Tables[0].Rows[0][45].ToString();
                Bcr_OTH_Acid_Phosphorus.Text = ds5.Tables[0].Rows[0][46].ToString();
                Bcr_OTH_Uric_Acid.Text = ds5.Tables[0].Rows[0][47].ToString();
                Bcr_OTH_Pasting_urine_sugar.Text = ds5.Tables[0].Rows[0][48].ToString();
                Bcr_OTH_PP_PG_urine_sugar.Text = ds5.Tables[0].Rows[0][49].ToString();
                db_all.Text = ds5.Tables[0].Rows[0][50].ToString();
                Bcr_OTH_Lipase.Text = ds5.Tables[0].Rows[0][51].ToString();
                Bcr_OTH_nac.Text = ds5.Tables[0].Rows[0][52].ToString();
            
            }

            else
            {
               
                Bcr1_Glucose_Fpg_RPG.Text = "0.00";
                Bcr1_PPPG_PGPG_2hr.Text = "0.00";
                Bcr1_PPPG_PGPG_1hr.Text = "0.00";
                Bcr1_RBS.Text = "0.00";
                Bcr1_PBBS.Text = "0.00";
                Bcr1_PLBS.Text = "0.00";
                Bcr1_GTT_1hr.Text = "0.00";
                Bcr1_GTT_2hr.Text = "0.00";
                Bcr1_GTT_3hr.Text = "0.00";
                Bcr1_PGBS_1hr.Text = "0.00";
                Bcr1_PGBS_2hr.Text = "0.00";
                Bcr1_HBAC_fair.Text = "0.00";
                Bcr1_HBAC_good.Text = "0.00";
                Bcr1_HBAC_poor.Text = "0.00";
                Bcr1_MBGE.Text = "0.00";
                Bcr_RP_Urea.Text = "0.00";
                Bcr_RP_BUN.Text = "0.00";
                Bcr_RP_Creatinine.Text = "0.00";
                Bcr3_Uric_Acid.Text = "0.00";
                Bcr3_NPN.Text = "0.00";

                Bcr_LP_Cholesterol.Text = "0.00";
                Bcr_LP_HDLCholesterol.Text = "0.00";
                Bcr_LP_LDLCholesterol.Text = "0.00";
                Bcr_LP_VLDLCholesterol.Text = "0.00";
                Bcr_LP_Triglycerides.Text = "0.00";
                Bcr2_LP_CHR.Text = "0.00";
                Bcr2_LP_LHR.Text = "0.00";
                Bcr_LFT_Bilirubin_total.Text = "0.00";
                Bcr_LFT_Bilirubin_Direct.Text = "0.00";
                Bcr4_LFT_Indirect.Text = "0.00";

                Bcr_LFT_Alkaline_Phosphates.Text = "0.00";
                Bcr_LFT_SGOT_AST.Text = "0.00";
                Bcr_LFT_SGPT_ALT.Text = "0.00";
                Bcr_LFT_Albumin.Text = "0.00";
                Bcr_LFT_Protein.Text = "0.00";
                Bcr_LFT_Globulin.Text = "0.00";
                Bcr_LFT_AG_Ratio.Text = "0.00";
                Bcr4_LFT_GGTP.Text = "0.00";
                Bcr_Electrolyte_Sodium.Text = "0.00";
                Bcr_Electrolyte_Potassium.Text = "0.00";
                Bcr5_Electrolyte_Chlorides.Text = "0.00";
                Bcr_OTH_Acid_Phosphate.Text = "0.00";
                Bcr_OTH_Amylase.Text = "0.00";
                Bcr_OTH_Acid_Calcium.Text = "0.00";
                Bcr_OTH_Acid_Phosphorus.Text = "0.00";
                Bcr_OTH_Uric_Acid.Text = "0.00";
                Bcr_OTH_Pasting_urine_sugar.Text = "0.00";
                Bcr_OTH_PP_PG_urine_sugar.Text = "0.00";


                Bcr1_Glucose_Fpg_RPG.Text = "0";
                Bcr1_PPPG_PGPG_2hr.Text = "0";
                Bcr1_PPPG_PGPG_1hr.Text = "0";
                //Bcr1_PGBS_1hr.Text = "0";
                Bcr1_RBS.Text = "0";
                Bcr1_PBBS.Text = "0";
                Bcr1_PLBS.Text = "0";
                Bcr1_GTT_1hr.Text = "0";
                Bcr1_GTT_2hr.Text = "0";
                Bcr1_GTT_3hr.Text = "0";
                Bcr1_PGBS_1hr.Text = "0";
                Bcr1_PGBS_2hr.Text = "0";
                Bcr1_HBAC_good.Text = "0";
                Bcr1_HBAC_fair.Text = "0";
                Bcr1_HBAC_poor.Text = "0";
                Bcr1_MBGE.Text = "0";


                Bcr_RP_Urea.Text = "0";
                Bcr_RP_BUN.Text = "0";
                Bcr_RP_Creatinine.Text = "0.00";
                Bcr3_Uric_Acid.Text = "0";
                Bcr3_NPN.Text = "0";


                Bcr_LP_Cholesterol.Text = "0.00";
                Bcr_LP_HDLCholesterol.Text = "0.00";
                Bcr_LP_LDLCholesterol.Text = "0.00";
                Bcr_LP_VLDLCholesterol.Text = "0.00";
                Bcr_LP_Triglycerides.Text = "0.00";

                Bcr2_LP_CHR.Text = "0.00";
                Bcr2_LP_LHR.Text = "0.00";
                Bcr_LFT_Bilirubin_total.Text = "0.00";
                Bcr_LFT_Bilirubin_Direct.Text = "0.00";
                Bcr4_LFT_Indirect.Text = "0.00";

                Bcr_LFT_Alkaline_Phosphates.Text = "0";
                Bcr_LFT_SGOT_AST.Text = "0";
                Bcr_LFT_SGPT_ALT.Text = "0";
                Bcr_LFT_Albumin.Text = "0.00";
                Bcr_LFT_Protein.Text = "0.00";
                Bcr_LFT_Globulin.Text = "0.00";
                Bcr_LFT_AG_Ratio.Text = "0.00";
                Bcr4_LFT_GGTP.Text = "0.00";

                Bcr_Electrolyte_Sodium.Text = "0";
                Bcr_Electrolyte_Potassium.Text = "0.00";
                Bcr5_Electrolyte_Chlorides.Text = "0.00";

                Bcr_OTH_Acid_Phosphate.Text = "0";
                Bcr_OTH_Amylase.Text = "0";
                Bcr_OTH_Acid_Calcium.Text = "0.00";
                Bcr_OTH_Acid_Phosphorus.Text = "0.00";
                Bcr_OTH_Uric_Acid.Text = "0.00";
                Bcr_OTH_Pasting_urine_sugar.Text = "0";
                Bcr_OTH_PP_PG_urine_sugar.Text = "0";
                db_all.Text = "";
                Bcr_OTH_Lipase.Text ="0";
                Bcr_OTH_nac.Text = "0";



            }


            da = new SqlDataAdapter(strsql6, con);
            ds6 = new DataSet();
            da.Fill(ds6);
            if (ds6.Tables[0].Rows.Count != 0)
            {
                txtcompanycode.Text = ds6.Tables[0].Rows[0][0].ToString();
                cbopcode.Text = ds6.Tables[0].Rows[0][1].ToString();
                FA_Timeofcollection.Text = ds6.Tables[0].Rows[0][2].ToString();
                FA_Timeofexamination.Text = ds6.Tables[0].Rows[0][3].ToString();
                FA_Timeofliquification.Text = ds6.Tables[0].Rows[0][4].ToString();
                FA_Volume.Text = ds6.Tables[0].Rows[0][5].ToString();
                FA_Reaction.Text = ds6.Tables[0].Rows[0][6].ToString();
                FA_Color.Text = ds6.Tables[0].Rows[0][7].ToString();
                FA_Viscocity.Text = ds6.Tables[0].Rows[0][8].ToString();
                FA_MP_Prostaticpearls.Text = ds6.Tables[0].Rows[0][9].ToString();
                FA_MP_Puscells.Text = ds6.Tables[0].Rows[0][10].ToString();
                FA_MP_RBC.Text = ds6.Tables[0].Rows[0][11].ToString();
                FA_MP_Epithcells.Text = ds6.Tables[0].Rows[0][12].ToString();
                FA_MP_Deformed.Text = ds6.Tables[0].Rows[0][13].ToString();
                FA_MT_Active.Text = ds6.Tables[0].Rows[0][14].ToString();
                FA_MT_Slugish.Text = ds6.Tables[0].Rows[0][15].ToString();
                FA_MT_Dead.Text = ds6.Tables[0].Rows[0][16].ToString();
                FA_MT_Totalcount.Text = ds6.Tables[0].Rows[0][17].ToString();
                sf_imp.Text = ds6.Tables[0].Rows[0][18].ToString();
                FA_MP_Premature.Text = ds6.Tables[0].Rows[0][19].ToString();
                cboiv.Text = ds6.Tables[0].Rows[0][20].ToString();
            
            }
            else
            {
                FA_Timeofcollection.Text = "";
                FA_Timeofexamination.Text = "";
                FA_Timeofliquification.Text = "";
                FA_Volume.Text = "";
                FA_Reaction.Text = "";
                FA_Color.Text = "";
                FA_Viscocity.Text = "";
                FA_MP_Prostaticpearls.Text = "0";
                FA_MP_Puscells.Text = "";
                FA_MP_RBC.Text = "";
                FA_MP_Epithcells.Text = "";
                FA_MP_Deformed.Text = "";
                FA_MT_Active.Text = "0";
                FA_MT_Slugish.Text = "0";
                FA_MT_Dead.Text = "0";
                FA_MT_Totalcount.Text = "0";
                sf_imp.Text = "";
                FA_MP_Premature.Text = "";
                cboiv.Text = "";
            }


            //da = new SqlDataAdapter(strsql8, con);
            //ds8 = new DataSet();
            //da.Fill(ds8);
            //if (ds8.Tables[0].Rows.Count != 0)
            //{
            //    txtcompanycode.Text = ds8.Tables[0].Rows[0][0].ToString();
            //    cbopcode.Text = ds8.Tables[0].Rows[0][1].ToString();
            //    Bc2_fbs.Text = ds8.Tables[0].Rows[0][2].ToString();
            //    Bc2_ppbs2.Text = ds8.Tables[0].Rows[0][3].ToString();
            //    Bc2_ppbs1.Text = ds8.Tables[0].Rows[0][4].ToString();
             

            //    Bc2_urea.Text = ds8.Tables[0].Rows[0][17].ToString();
            //    // Bcr_RP_BUN.Text = ds5.Tables[0].Rows[0][18].ToString();
            //    Bc2_creatinine.Text = ds8.Tables[0].Rows[0][19].ToString();
            //    Bc2_uric_acid.Text = ds8.Tables[0].Rows[0][20].ToString();
  
            //    db2_imp.Text = ds8.Tables[0].Rows[0][50].ToString();
            
            //}
            //else
            //{
            //    Bc2_fbs.Text = "0";
            //    Bc2_ppbs1.Text = "0";
            //    Bc2_ppbs2.Text = "0";
            //    Bc2_urea.Text = "0";
            //    Bc2_uric_acid.Text = "0";
            //    Bc2_creatinine.Text = "0.00";
            //    db2_imp.Text = "";
            //}

            //da = new SqlDataAdapter(strsql9, con);
            //ds9 = new DataSet();
            //da.Fill(ds9);
            //if (ds9.Tables[0].Rows.Count != 0)
            //{
            //    txtcompanycode.Text = ds9.Tables[0].Rows[0][0].ToString();
            //    cbopcode.Text = ds9.Tables[0].Rows[0][1].ToString();
            //    Bc3_fbs.Text = ds9.Tables[0].Rows[0][2].ToString();
            //    Bc3_ppbs2.Text = ds9.Tables[0].Rows[0][3].ToString();
            //    Bc3_ppbs1.Text = ds9.Tables[0].Rows[0][4].ToString();
 
            //    Bc3_urea.Text = ds9.Tables[0].Rows[0][17].ToString();
            //    // Bcr_RP_BUN.Text = ds5.Tables[0].Rows[0][18].ToString();
            //    Bc3_creatinine.Text = ds9.Tables[0].Rows[0][19].ToString();
            //    Bc3_uric_acid.Text = ds9.Tables[0].Rows[0][20].ToString();
            //    // Bcr3_NPN.Text = ds5.Tables[0].Rows[0][21].ToString();

            //    Bc3_cholesterol.Text = ds9.Tables[0].Rows[0][22].ToString();
            //    Bc3_hdl.Text = ds9.Tables[0].Rows[0][23].ToString();
            //    Bc3_ldl.Text = ds9.Tables[0].Rows[0][24].ToString();
            //    Bc3_vldl.Text = ds9.Tables[0].Rows[0][25].ToString();
            //    Bc3_triglyceride.Text = ds9.Tables[0].Rows[0][26].ToString();
 
            //    db3_imp.Text = ds9.Tables[0].Rows[0][50].ToString();
            
            //}
            //else
            //{
            //    Bc3_fbs.Text = "0";
            //    Bc3_cholesterol.Text = "0.00";
            //    Bc3_creatinine.Text = "0.00";
            //    Bc3_hdl.Text = "0.00";
            //    Bc3_ldl.Text = "0.00";
            //    Bc3_ppbs1.Text = "0";
            //    Bc3_ppbs2.Text = "0";
            //    Bc3_triglyceride.Text = "0.00";
            //    Bc3_urea.Text = "0";
            //    Bc3_uric_acid.Text = "0";
            //    Bc3_vldl.Text = "0.00";
            //    db3_imp.Text = "";
            //}


            da = new SqlDataAdapter(strsql11, con);
            ds11 = new DataSet();
            da.Fill(ds11);
            if (ds11.Tables[0].Rows.Count != 0)
            {
                txtcompanycode.Text = ds11.Tables[0].Rows[0][0].ToString();
                cbopcode.Text = ds11.Tables[0].Rows[0][1].ToString();

                TOTAL_TRIIODOTHYRONINE_T3.Text = ds11.Tables[0].Rows[0][2].ToString();
                TOTAL_THYROXINE_T4.Text = ds11.Tables[0].Rows[0][3].ToString();
                TSH.Text = ds11.Tables[0].Rows[0][4].ToString();
                FREE_TRIIODOTHYRONINE_FT3.Text = ds11.Tables[0].Rows[0][5].ToString();
                FREE_THYROXINE_FT4.Text = ds11.Tables[0].Rows[0][6].ToString();
                ANTIMICROSOMAL_ANTIBODY_AMA.Text = ds11.Tables[0].Rows[0][7].ToString();
                TOTAL_CHOLESTEROL.Text = ds11.Tables[0].Rows[0][8].ToString();
                PROLACTIN_PRL.Text = ds11.Tables[0].Rows[0][9].ToString();
                PROSTATESPECIFICANTIGEN_PSA.Text = ds11.Tables[0].Rows[0][10].ToString();
                ADENOSINE_DEAMINASE.Text = ds11.Tables[0].Rows[0][11].ToString();
                ANTITUBERCULOSIS_TB_IgG.Text = ds11.Tables[0].Rows[0][12].ToString();
                ANTITUBERCULOSIS_TB_IgM.Text = ds11.Tables[0].Rows[0][13].ToString();
                ANTITUBERCULOSIS_TB_IgA.Text = ds11.Tables[0].Rows[0][14].ToString();
                BHCG.Text = ds11.Tables[0].Rows[0][15].ToString();
                CA_125.Text = ds11.Tables[0].Rows[0][16].ToString();
                ANA.Text = ds11.Tables[0].Rows[0][17].ToString();
                hm_imp.Text = ds11.Tables[0].Rows[0][18].ToString();


            }

            da = new SqlDataAdapter(strsql12, con);
            ds12 = new DataSet();
            da.Fill(ds12);
            if (ds12.Tables[0].Rows.Count != 0)
            {
                txtcompanycode.Text = ds12.Tables[0].Rows[0][0].ToString();
                cbopcode.Text = ds12.Tables[0].Rows[0][1].ToString();
                CtSpecimen.Text = ds12.Tables[0].Rows[0][2].ToString();
                CtBenign_Cell.Text = ds12.Tables[0].Rows[0][3].ToString();
                CtEndocervical_Cell.Text = ds12.Tables[0].Rows[0][4].ToString();
                CtInflammatory_Cell.Text = ds12.Tables[0].Rows[0][5].ToString();
                CtTrichomonas.Text = ds12.Tables[0].Rows[0][6].ToString();
                CtMonilia.Text = ds12.Tables[0].Rows[0][7].ToString();
                CtEndometrial_Cell.Text = ds12.Tables[0].Rows[0][8].ToString();
                CtSpermatozoa.Text = ds12.Tables[0].Rows[0][9].ToString();
                CtRbc.Text = ds12.Tables[0].Rows[0][10].ToString();
                CtDysplastic_Cell.Text = ds12.Tables[0].Rows[0][11].ToString();
                CtMalignant_Cell.Text = ds12.Tables[0].Rows[0][12].ToString();
                CtOthers.Text = ds12.Tables[0].Rows[0][13].ToString();
                Ctimp.Text = ds12.Tables[0].Rows[0][14].ToString();
            }
            else
            {
                CtSpecimen.Text = "";
                CtBenign_Cell.Text = "";
                CtEndocervical_Cell.Text = "";
                CtInflammatory_Cell.Text = "";
                CtTrichomonas.Text = "";
                CtMonilia.Text = "";
                CtEndometrial_Cell.Text = "";
                CtSpermatozoa.Text = "";
                CtRbc.Text = "";
                CtDysplastic_Cell.Text = "";
                CtMalignant_Cell.Text = "";
                CtOthers.Text = "";
                Ctimp.Text = "";
            }


            da = new SqlDataAdapter(strsql13, con);
            ds13 = new DataSet();
            da.Fill(ds13);
            if (ds13.Tables[0].Rows.Count != 0)
            {
                txtcompanycode.Text = ds13.Tables[0].Rows[0][0].ToString();
                cbopcode.Text = ds13.Tables[0].Rows[0][1].ToString();

                BfSpecimen.Text = ds13.Tables[0].Rows[0][2].ToString();
                BfQty.Text = ds13.Tables[0].Rows[0][3].ToString();
                BfAppearance.Text = ds13.Tables[0].Rows[0][4].ToString();
                BfColor.Text = ds13.Tables[0].Rows[0][5].ToString();
                BfClotFormation.Text = ds13.Tables[0].Rows[0][6].ToString();
                BfNeutrophil.Text = ds13.Tables[0].Rows[0][7].ToString();
                BfSugar.Text = ds13.Tables[0].Rows[0][8].ToString();
                BfMicroprotein.Text = ds13.Tables[0].Rows[0][9].ToString();
                BfLymphocyte.Text = ds13.Tables[0].Rows[0][10].ToString();
                BfTotal_cell_count.Text = ds13.Tables[0].Rows[0][11].ToString();
                BfRbc.Text = ds13.Tables[0].Rows[0][12].ToString();
                BfMalignant_Cell.Text = ds13.Tables[0].Rows[0][13].ToString();
                BfImpression.Text = ds13.Tables[0].Rows[0][14].ToString();
                BfAbnormal_Cell.Text = ds13.Tables[0].Rows[0][15].ToString();
            }
            else
            {
                BfSpecimen.Text = "";
                BfQty.Text = "";
                BfAppearance.Text = "";
                BfColor.Text = "";
                BfClotFormation.Text = "";
                BfNeutrophil.Text = "";
                BfSugar.Text = "";
                BfMicroprotein.Text = "";
                BfLymphocyte.Text = "";
                BfTotal_cell_count.Text = "";
                BfRbc.Text = "";
                BfMalignant_Cell.Text = "";
                BfImpression.Text = "";
                BfAbnormal_Cell.Text = "";
            }
            da.Dispose();
            da = new SqlDataAdapter(strsql15, con);
            ds15 = new DataSet();
            da.Fill(ds15);
            if (ds15.Tables[0].Rows.Count != 0)
            {
                txtcompanycode.Text = ds15.Tables[0].Rows[0][0].ToString();
                cbopcode.Text = ds15.Tables[0].Rows[0][1].ToString();
                
             txthisto.Text = ds15.Tables[0].Rows[0][2].ToString();
                txtgexam.Text = ds15.Tables[0].Rows[0][3].ToString();
                txtmicro.Text = ds15.Tables[0].Rows[0][4].ToString();
                txtimpresion.Text = ds15.Tables[0].Rows[0][5].ToString();
                
            }
            else
            {
                txthisto.Text = "";
                txtgexam.Text = "";
                txtmicro.Text = "";
                txtimpresion.Text = "";
               
            }

            da.Dispose();

            da = new SqlDataAdapter(strsql16, con);
            ds16 = new DataSet();
            da.Fill(ds16);
            if (ds16.Tables[0].Rows.Count != 0)
            {
                txtcompanycode.Text = ds16.Tables[0].Rows[0][0].ToString();
                cbopcode.Text = ds16.Tables[0].Rows[0][1].ToString();

                srt_afp.Text = ds16.Tables[0].Rows[0][2].ToString();
                SRT_ASA.Text = ds16.Tables[0].Rows[0][3].ToString();
                SRT_CV_IGG.Text = ds16.Tables[0].Rows[0][4].ToString();
                SRT_CV_IGM.Text = ds16.Tables[0].Rows[0][5].ToString();
                SRT_HSV_IGG.Text = ds16.Tables[0].Rows[0][6].ToString();
                SRT_HSV_IGM.Text = ds16.Tables[0].Rows[0][7].ToString();
                SRT_RV_IGG.Text = ds16.Tables[0].Rows[0][8].ToString();
               
               SRT_RV_IGM.Text = ds16.Tables[0].Rows[0][9].ToString();
               SRT_HBSA.Text = ds16.Tables[0].Rows[0][10].ToString();
               SRT_AHBSAT.Text = ds16.Tables[0].Rows[0][11].ToString();
                SRT_HBEA.Text = ds16.Tables[0].Rows[0][12].ToString();
                SRT_AHBEAT.Text = ds16.Tables[0].Rows[0][13].ToString();

                SRT_AHBCA_IGM.Text = ds16.Tables[0].Rows[0][14].ToString();
                SRT_AHBCAT.Text = ds16.Tables[0].Rows[0][15].ToString();
                
                
                SRT_AHAV_IGM.Text = ds16.Tables[0].Rows[0][16].ToString();
                SRT_AHAVT.Text = ds16.Tables[0].Rows[0][17].ToString();
            
                 SRT_AHCVT.Text = ds16.Tables[0].Rows[0][18].ToString();
               SRT_AHEV_IGM.Text = ds16.Tables[0].Rows[0][19].ToString();
               srt_hp_igg.Text = ds16.Tables[0].Rows[0][20].ToString();
               srt_hp_igm.Text = ds16.Tables[0].Rows[0][21].ToString();
                srt_hp_iga.Text = ds16.Tables[0].Rows[0][22].ToString();
                SER_IMP2.Text = ds16.Tables[0].Rows[0][23].ToString();
              }
            else
            {
                srt_afp.Text = "";
                SRT_ASA.Text = "";
                SRT_CV_IGG.Text = "";
                SRT_CV_IGM.Text = "";
                SRT_HSV_IGG.Text = "";
                SRT_HSV_IGM.Text = "";
                SRT_RV_IGG.Text = "";
                SRT_RV_IGM.Text = "";
                SRT_HBSA.Text = "";
                SRT_AHBSAT.Text = "";
                SRT_HBEA.Text = "";
                SRT_AHBEAT.Text = "";
                SRT_AHBCA_IGM.Text = "";
                SRT_AHBCAT.Text = "";
                SRT_AHAV_IGM.Text = "";
                SRT_AHAVT.Text = "";
                SRT_AHCVT.Text = "";
                SRT_AHEV_IGM.Text = "";
                srt_hp_igg.Text = "";
                srt_hp_igm.Text = "";
                srt_hp_iga.Text = "";
                SER_IMP2.Text = "";
            
            }
            da.Dispose();
            da = new SqlDataAdapter(strsql17, con);
            ds17 = new DataSet();
            da.Fill(ds17);
            if (ds17.Tables[0].Rows.Count != 0)
            {
                txtcompanycode.Text = ds17.Tables[0].Rows[0][0].ToString();
                cbopcode.Text = ds17.Tables[0].Rows[0][1].ToString();

                txtnotepad.Text = ds17.Tables[0].Rows[0][2].ToString();
                
            }
            else
            {
                txtnotepad.Text = "";
                
            }

            da.Dispose();
           
            da = new SqlDataAdapter(strsql18, con);
            DataSet ds18 = new DataSet();
            da.Fill(ds18);
            if (ds18.Tables[0].Rows.Count != 0)
            {
                txtcompanycode.Text = ds18.Tables[0].Rows[0][0].ToString();
                cbopcode.Text = ds18.Tables[0].Rows[0][1].ToString();

                txthistox.Text = ds18.Tables[0].Rows[0][2].ToString();
                txtgexamx.Text = ds18.Tables[0].Rows[0][3].ToString();
                txtmicrox.Text = ds18.Tables[0].Rows[0][4].ToString();
                txthistoimp.Text = ds18.Tables[0].Rows[0][5].ToString();

            }
            else
            {
                //txthistox.Text = "";
                //txtgexamx.Text = "";
                //txtmicrox.Text = "";
                //txthistoimp.Text = "";
            }

            da.Dispose();
            
            da = new SqlDataAdapter("select test,method,result,unit,normal_range from bloodext where pcode='" + cbopcode.Text.Trim() + "' order by test ", con);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dgvbloodnewtest.Rows.Add();
                    dgvbloodnewtest.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][0].ToString();
                    dgvbloodnewtest.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][1].ToString();
                    dgvbloodnewtest.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][2].ToString();
                    dgvbloodnewtest.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][3].ToString();
                    dgvbloodnewtest.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][4].ToString();
                   

                }

               
            }

            da.Dispose();
            da = new SqlDataAdapter("select test,method,result,unit,normal_range from serologyext where pcode='" + cbopcode.Text.Trim() + "' order by test ", con);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                   
                    
                    dgvser.Rows.Add();
                    dgvser.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][0].ToString();
                    dgvser.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][1].ToString();
                    dgvser.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][2].ToString();
                    dgvser.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][3].ToString();
                    dgvser.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][4].ToString();


                }


            }


            da.Dispose();
            da = new SqlDataAdapter("select test,method,result,unit,normal_range from biochemistext where pcode='" + cbopcode.Text.Trim() + "' order by test ", con);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {


                    dgvbiochemext.Rows.Add();
                    dgvbiochemext.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][0].ToString();
                    dgvbiochemext.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][1].ToString();
                    dgvbiochemext.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][2].ToString();
                    dgvbiochemext.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][3].ToString();
                    dgvbiochemext.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][4].ToString();

                }

                
            }

            da.Dispose();
            //hormone new
            da = new SqlDataAdapter("select test,method,result,unit,normal_range from hormoneext where pcode='" + cbopcode.Text.Trim() + "' order by test ", con);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    
                    dgvhormonenew.Rows.Add();
                    dgvhormonenew.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][0].ToString();
                    dgvhormonenew.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][1].ToString();
                    dgvhormonenew.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][2].ToString();
                    dgvhormonenew.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][3].ToString();
                    dgvhormonenew.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][4].ToString();

                }


            }



           
             da.Dispose();
            //hormone new
             da = new SqlDataAdapter("select antibiotic,antibiotics,antibioticv,organism_isolated,cu_imp,test,colony_count from cultureext where pcode='" + cbopcode.Text.Trim() + "' order by test ", con);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                cbons.Text = ds.Tables[0].Rows[0][5].ToString();
                cbocolonycount.Text = ds.Tables[0].Rows[0][6].ToString();
                Cu_Organism_isolated1.Text = ds.Tables[0].Rows[0][3].ToString();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {


                    dgvculture.Rows.Add();
                    dgvculture.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][0].ToString();
                    dgvculture.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][1].ToString();
                    dgvculture.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][2].ToString();
                    dgvculture.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][3].ToString();
                    dgvculture.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][4].ToString();
                    //dgvculture.Rows[i].Cells[5].Value = ds.Tables[0].Rows[i][5].ToString();
                    //dgvculture.Rows[i].Cells[6].Value = ds.Tables[0].Rows[i][6].ToString();
                }


            }
            else
            {
                cbons.Text = "";
                cbocolonycount.Text ="";
                Cu_Organism_isolated1.Text = "";
                dgvculture.Rows.Clear();
            
            }

            da.Dispose(); 
            
            
            
            
            
            
            
            reentry.Enabled = true;
            String Sqlstr = "";
            if (cbopcode.Text != "")
            {
                Sqlstr = "update setup set regno='" + Convert.ToInt32(cbopcode.Text) + "'";
                cmd = new SqlCommand(Sqlstr, con);
                cmd.ExecuteNonQuery();
                Sqlstr = "";

            }


        }

        private void btnseminalfluidprint_Click(object sender, EventArgs e)
        {
            Frmrepseminalfluid repseminal = new Frmrepseminalfluid();
            repseminal.Show();
        }


        private void btnfind_Click(object sender, EventArgs e)
        {
            
            
         

        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            //rowindex = dataGridView1.CurrentRow.Index;
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_KeyDown_1(object sender, KeyEventArgs e)
        {
            //rowindex = dataGridView1.CurrentRow.Index;
        }

        private void dataGridView1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 13)
            //{


            //    this.cbopcode.Text = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();
            //    this.cboname.Text = dataGridView1.Rows[rowindex].Cells[1].Value.ToString();
            //    this.dataGridView1.Visible = false;
            //    cbopcode.Focus();

            //}

        }

        private void dataGridView1_KeyUp_1(object sender, KeyEventArgs e)
        {
            //rowindex = dataGridView1.CurrentRow.Index;
        }

        private void btndelbiochem_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("delete from Biochemist where cc='" + txtcompanycode.Text + "' and  pcode='" + Convert.ToInt32(cbopcode.Text) + "'");
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Deleted");

        }

        private void btndelurine_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("delete from urine where cc='" + txtcompanycode.Text + "' and  pcode='" + Convert.ToInt32(cbopcode.Text) + "'");
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Deleted");
        }

        private void btndelstool_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("delete from stool where cc='" + txtcompanycode.Text + "' and  pcode='" + Convert.ToInt32(cbopcode.Text) + "'");
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Deleted");

        }

        private void btndelseminal_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("delete from seminal_fluid where cc='" + txtcompanycode.Text + "' and  pcode='" + Convert.ToInt32(cbopcode.Text) + "'");
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Deleted");
        }

        private void btndelblood_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("delete from blood where cc='" + txtcompanycode.Text + "' and  pcode='" + Convert.ToInt32(cbopcode.Text) + "'");
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Deleted");
        }

     
        private void btnsaveserology_Click(object sender, EventArgs e)
        {
            String Sqlstr = "";
            con.Close();
            con.Open();

            if (MessageBox.Show("Save ? ", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                String strsql4 = "";
                strsql4 = "select cc,pcode,BG_Blood_Group,BR_RhD_Typing,BDc_Neutrophild,BDc_Eosinophils,BDc_Lymphocytes,";
                strsql4 = strsql4 + "BDc_Basophils,BDc_Monocytes,BDc_Twbc,BDc_Trbc,BDc_Tplatelets,BDc_Aec,BDc_Tnc,BDc_Reticulocyte_Count,";
                strsql4 = strsql4 + "BDc_PCV,BDC_mcv,BDC_mch,BDC_mchc,BDc_Pss,BDc_Mp_ICT_QBC_Smear,BDc_Mp_ICT,BDc_Mf_ICT_QBC_Smear,BDc_Mf_ICT,BDc_Rct,BDc_Hb,BDc_ESR_1sthour,";
                strsql4 = strsql4 + "BDc_Bleeding_Time,BDc_Clotting_Time,BDC_nasalsmear,BDC_nasalsmear_right,BDc_Sickle_cell,BDC_prothombintime,BDC_prothombintime_cont,BPS_Toxo,BPS_Crp,BPS_Vdrl,BPS_Ana,";
                strsql4 = strsql4 + "BPS_Rafactor,BPS_Aso,BS_Australia_Antigen,BS_Hepatitis_C_Virus,BS_HIV_1,BS_HIV_2,";


                strsql4 = strsql4 + "Bw_Widaltubeo80,Bw_Widaltubeo160,Bw_Widaltubeo320,Bw_Widaltubeo240,Bw_Widaltubeo480,Bw_Widaltubeh80,Bw_Widaltubeh160,Bw_Widaltubeh320,Bw_Widaltubeh240,Bw_Widaltubeh480,Bw_Widaltubeah80,Bw_Widaltubeah160,Bw_Widaltubeah320,Bw_Widaltubeah240,Bw_Widaltubeah480,Bw_Widaltubebh80,Bw_Widaltubebh160,Bw_Widaltubebh320,Bw_Widaltubebh240,Bw_Widaltubebh480,Bw_Widalslide1,Bw_Widalslide2,Bw_Widalslide3,Bw_Widalslide4,Bw_mycodot,bw_trop,Bm_MontouxTest_injon,Bm_MontouxTest_readon,Bm_MontouxTest_induration,BDc_ESR_2ndhour,BDC_prothombintime_inr,BDc_Dengue,BDc_typhicheck,BDc_Dengue_NSI,ser_imp,BDc_Rcdw,BDc_MPV,BDc_PDW";
                strsql4 = strsql4 + " from Blood where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";

                da = new SqlDataAdapter(strsql4, con);


                ds4 = new DataSet();
                da.Fill(ds4);


                if (ds4.Tables[0].Rows.Count == 0)
                {

                    Sqlstr = "insert into Blood ( cc,pcode,BG_Blood_Group,BR_RhD_Typing,BDc_Neutrophild,BDc_Eosinophils,BDc_Lymphocytes,BDc_Basophils, BDc_Monocytes,BDc_Twbc,BDc_Trbc,BDc_Tplatelets,";
                    Sqlstr = Sqlstr + "BDc_Aec,BDc_Tnc,BDc_Reticulocyte_Count,BDc_PCV,BDC_mcv,BDC_mch,BDC_mchc,BDc_Pss,BDc_Mp_ICT_QBC_Smear,BDc_Mp_ICT,BDc_Mf_ICT_QBC_Smear,BDc_Mf_ICT,Bdc_Rct,BDc_Hb,BDc_ESR_1sthour,";
                    Sqlstr = Sqlstr + "BDc_Bleeding_Time,BDc_Clotting_Time,BDC_nasalsmear,BDC_nasalsmear_right,BDc_Sickle_cell,BDC_prothombintime,BDC_prothombintime_cont,BPS_Toxo,BPS_Crp,BPS_Vdrl,BPS_Ana,";
                    Sqlstr = Sqlstr + "BPS_Rafactor,BPS_Aso,BS_Australia_Antigen,BS_Hepatitis_C_Virus,BS_HIV_1,BS_HIV_2,";
                    Sqlstr = Sqlstr + "Bw_Widaltubeo80,Bw_Widaltubeo160,Bw_Widaltubeo320,Bw_Widaltubeo240,Bw_Widaltubeo480,Bw_Widaltubeh80,Bw_Widaltubeh160,Bw_Widaltubeh320,Bw_Widaltubeh240,Bw_Widaltubeh480,Bw_Widaltubeah80,Bw_Widaltubeah160,Bw_Widaltubeah320,Bw_Widaltubeah240,Bw_Widaltubeah480,Bw_Widaltubebh80,Bw_Widaltubebh160,Bw_Widaltubebh320,Bw_Widaltubebh240,Bw_Widaltubebh480,Bw_Widalslide1,Bw_Widalslide2,Bw_Widalslide3,Bw_Widalslide4,Bw_mycodot,bw_trop,Bm_MontouxTest_injon,Bm_MontouxTest_readon,";
                    Sqlstr = Sqlstr + "Bm_MontouxTest_induration,BDc_ESR_2ndhour,BDC_prothombintime_inr,BDc_Dengue,BDc_typhicheck,BDc_Dengue_NSI,ser_imp,BDc_Rcdw,BDc_MPV,BDc_PDW,BPS_Aso_qty,BPS_Crp_qty,BPS_Rafactor_qty,Bw_Trop_qty) values ('" + Convert.ToInt32(txtcompanycode.Text) + "','" + Convert.ToInt32(cbopcode.Text);
                    Sqlstr = Sqlstr + "','" + BG_Blood_Group.Text + "','" + BR_RhD_Typing.Text;
                    Sqlstr = Sqlstr + "' ,'" + BDc_Neutrophild.Text + "','" + BDc_Eosinophils.Text;
                    Sqlstr = Sqlstr + "','" + BDc_Lymphocytes.Text + "','" + BDc_Basophils.Text;
                    Sqlstr = Sqlstr + "','" + BDc_Monocytes.Text + "','" + BDc_Twbc.Text;
                    Sqlstr = Sqlstr + "','" + BDc_Trbc.Text + "','" + BDc_Tplatelets.Text;
                    Sqlstr = Sqlstr + "','" + BDc_Aec.Text + "','" + BDc_Tnc.Text + "','" + BDc_Reticulocyte_Count.Text;
                    Sqlstr = Sqlstr + "','" + BDc_PCV.Text + "','" + BDCmcv.Text;
                    Sqlstr = Sqlstr + "','" + BDCmch.Text + "','" + BDCmchc.Text + "','" + CBDcPSS.Text + "','" + BDc_Mp_ICT_QBC_Smear.Text + "','" + BDc_Mp_ICT.Text;
                    Sqlstr = Sqlstr + "','" + BDc_Mf_ICT_QBC_Smear.Text + "','" + BDc_Mf_ICT.Text + "','" + BDc_Rct.Text + "','" + BDc_Hb.Text;
                    Sqlstr = Sqlstr + "','" + BDc_ESR_1sthour.Text;
                    Sqlstr = Sqlstr + "','" + BDc_Bleeding_Time.Text + "','" + BDc_Clotting_Time.Text;
                    Sqlstr = Sqlstr + "','" + BDc_Nasalsmear.Text + "','" + BDc_Nasalsmear_Right.Text;
                    Sqlstr = Sqlstr + "','" + BDc_Sickle_cell.Text + "','" + BDc_Prothombintime.Text + "','" + BDc_Prothombintime_cont.Text + "','" + SBPS_Toxo.Text;

                    Sqlstr = Sqlstr + "','" + SBPS_Crp.Text + "','" + SBPS_vdrl.Text + "','" + SBPS_Ana.Text;
                    Sqlstr = Sqlstr + "','" + SBPS_Rafactor.Text + "','" + SBPS_Aso.Text;
                    Sqlstr = Sqlstr + "','" + SBS_Australia_Antigen.Text + "','" + SBS_Hepatitis_C_Virus.Text;
                    Sqlstr = Sqlstr + "','" + SBS_HIV_1.Text + "','" + SBS_HIV_2.Text;
                    Sqlstr = Sqlstr + "','" + BWwidaltubeo80.Text + "','" + BWwidaltubeo160.Text + "','" + BWwidaltubeo320.Text + "','" + BWwidaltubeo240.Text + "','" + BWwidaltubeo480.Text + "','" + BWwidaltubeh80.Text + "','" + BWwidaltubeh160.Text + "','" + BWwidaltubeh320.Text + "','" + BWwidaltubeh240.Text + "','" + BWwidaltubeh480.Text + "','" + BWwidaltubeah80.Text + "','" + BWwidaltubeah160.Text + "','" + BWwidaltubeah320.Text + "','" + BWwidaltubeah240.Text + "','" + BWwidaltubeah480.Text + "','" + BWwidaltubebh80.Text + "','" + BWwidaltubebh160.Text + "','" + BWwidaltubebh320.Text + "','" + BWwidaltubebh240.Text + "','" + BWwidaltubebh480.Text;

                    Sqlstr = Sqlstr + "','" + BWwidalslide1.Text + "','" + BWwidalslide2.Text + "','" + BWwidalslide3.Text + "','" + BWwidalslide4.Text + "','" + SBS_mycodot.Text + "','" + SBS_trop.Text;
                    Sqlstr = Sqlstr + "','" + SBm_MontouxTest_injon.Text + "','" + SBm_MontouxTest_readon.Text;
                    Sqlstr = Sqlstr + "','" + SBm_MontouxTest_induration.Text + "','" + BDc_ESR_2ndhour.Text + "','" + BDc_Prothombintime_inr.Text + "','" + SBS_Dengue.Text + "','" + SBS_Typhicheck.Text + "','" + SBS_Dengue_NSI.Text + "','" + ser_imp.Text + "','" + BDcRcdw.Text + "','" + BDCmpv.Text + "','" + BDCpdw.Text + "','" + SBPS_Aso_Qty.Text+"','" + SBPS_Crp_Qty.Text+"','" + SBPS_Rafactor_Qty.Text+"','" + SBS_trop_Qty.Text+"')";
                    //Sqlstr = Sqlstr + "' where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
                }
                else
                {

                    Sqlstr = "update blood set cc='" + Convert.ToInt32(txtcompanycode.Text) + "',pcode='" + Convert.ToInt32(cbopcode.Text);

                    Sqlstr = Sqlstr + "',BG_Blood_Group='" + BG_Blood_Group.Text + "',BR_RhD_Typing='" + BR_RhD_Typing.Text;
                    Sqlstr = Sqlstr + "',BDc_Neutrophild='" + BDc_Neutrophild.Text + "',BDc_Eosinophils='" + BDc_Eosinophils.Text;
                    Sqlstr = Sqlstr + "',BDc_Lymphocytes='" + BDc_Lymphocytes.Text + "',BDc_Basophils='" + BDc_Basophils.Text;
                    Sqlstr = Sqlstr + "', BDc_Monocytes='" + BDc_Monocytes.Text + "',BDc_Twbc='" + BDc_Twbc.Text;
                    Sqlstr = Sqlstr + "',BDc_Trbc='" + BDc_Trbc.Text + "',BDc_Tplatelets='" + BDc_Tplatelets.Text;
                    Sqlstr = Sqlstr + "',BDc_Aec='" + BDc_Aec.Text + "',BDc_Tnc='" + BDc_Tnc.Text + "',BDc_Reticulocyte_Count='" + BDc_Reticulocyte_Count.Text;
                    Sqlstr = Sqlstr + "',BDc_PCV='" + BDc_PCV.Text + "',BDC_mcv='" + BDCmcv.Text + "',BDC_mch='" + BDCmch.Text + "',BDC_mchc='" + BDCmchc.Text + "',BDc_Pss='" + CBDcPSS.Text;
                    Sqlstr = Sqlstr + "',BDc_Mp_ICT_QBC_Smear='" + BDc_Mp_ICT_QBC_Smear.Text + "',BDc_Mp_ICT='" + BDc_Mp_ICT.Text;
                    Sqlstr = Sqlstr + "',BDc_Mf_ICT_QBC_Smear='" + BDc_Mf_ICT_QBC_Smear.Text + "',BDc_Mf_ICT='" + BDc_Mf_ICT.Text + "',BDc_Rct='" + BDc_Rct.Text + "',BDc_Hb='" + BDc_Hb.Text;
                    Sqlstr = Sqlstr + "',BDc_ESR_1sthour='" + BDc_ESR_1sthour.Text;
                    Sqlstr = Sqlstr + "',BDc_Bleeding_Time='" + BDc_Bleeding_Time.Text + "',BDc_Clotting_Time='" + BDc_Clotting_Time.Text + "',BDc_nasalsmear='" + BDc_Nasalsmear.Text + "',BDc_nasalsmear_right='" + BDc_Nasalsmear_Right.Text;
                    Sqlstr = Sqlstr + "',BDc_Sickle_cell='" + BDc_Sickle_cell.Text + "',Bdc_prothombintime='" + BDc_Prothombintime.Text + "',Bdc_prothombintime_cont='" + BDc_Prothombintime_cont.Text + "',BPS_Toxo='" + SBPS_Toxo.Text;
                    Sqlstr = Sqlstr + "',BPS_Crp='" + SBPS_Crp.Text + "',BPS_Vdrl='" + SBPS_vdrl.Text + "',BPS_Ana='" + SBPS_Ana.Text;
                    Sqlstr = Sqlstr + "',BPS_Rafactor='" + SBPS_Rafactor.Text + "',BPS_Aso='" + SBPS_Aso.Text;
                    Sqlstr = Sqlstr + "',BS_Australia_Antigen='" + SBS_Australia_Antigen.Text + "',BS_Hepatitis_C_Virus='" + SBS_Hepatitis_C_Virus.Text;
                    Sqlstr = Sqlstr + "',BS_HIV_1='" + SBS_HIV_1.Text + "',BS_HIV_2='" + SBS_HIV_2.Text;
                    Sqlstr = Sqlstr + "',Bw_Widaltubeo80='" + BWwidaltubeo80.Text + "',Bw_Widaltubeo160='" + BWwidaltubeo160.Text + "',Bw_Widaltubeo320='" + BWwidaltubeo320.Text + "',Bw_Widaltubeh80='" + BWwidaltubeh80.Text + "',Bw_Widaltubeh160='" + BWwidaltubeh160.Text + "',Bw_Widaltubeh320='" + BWwidaltubeh320.Text + "',Bw_Widaltubeah80='" + BWwidaltubeah80.Text + "',Bw_Widaltubeah160='" + BWwidaltubeah160.Text + "',Bw_Widaltubeah320='" + BWwidaltubeah320.Text + "',Bw_Widaltubebh80='" + BWwidaltubebh80.Text + "',Bw_Widaltubebh160='" + BWwidaltubebh160.Text + "',Bw_Widaltubebh320='" + BWwidaltubebh320.Text;
                    Sqlstr = Sqlstr + "',Bw_Widaltubeo240='" + BWwidaltubeo240.Text + "',Bw_Widaltubeo480='" + BWwidaltubeo480.Text + "',Bw_Widaltubeh240='" + BWwidaltubeh240.Text + "',Bw_Widaltubeh480='" + BWwidaltubeh480.Text + "',Bw_Widaltubeah240='" + BWwidaltubeah240.Text + "',Bw_Widaltubeah480='" + BWwidaltubeah480.Text + "',Bw_Widaltubebh240='" + BWwidaltubebh240.Text + "',Bw_Widaltubebh480='" + BWwidaltubebh480.Text;

                    Sqlstr = Sqlstr + "',Bw_Widalslide1='" + BWwidalslide1.Text + "',Bw_Widalslide2='" + BWwidalslide2.Text + "',Bw_Widalslide3='" + BWwidalslide3.Text + "',Bw_Widalslide4='" + BWwidalslide4.Text + "',bw_mycodot='" + SBS_mycodot.Text + "',bw_trop='" + SBS_trop.Text;
                    Sqlstr = Sqlstr + "',Bm_MontouxTest_injon='" + SBm_MontouxTest_injon.Text + "',Bm_MontouxTest_readon='" + SBm_MontouxTest_readon.Text;
                    Sqlstr = Sqlstr + "',Bm_MontouxTest_induration='" + SBm_MontouxTest_induration.Text + "',BDc_ESR_2ndhour='" + BDc_ESR_2ndhour.Text + "',Bdc_prothombintime_inr='" + BDc_Prothombintime_inr.Text + "',BDc_Dengue='" + SBS_Dengue.Text + "',BDc_Typhicheck='" + SBS_Typhicheck.Text + "',BDc_Dengue_NSI='" + SBS_Dengue_NSI.Text + "',ser_imp='" + ser_imp.Text + "',BDc_Rcdw='" + BDcRcdw.Text + "',BDc_MPV='" + BDCmpv.Text + "',BDc_PDW='" + BDCpdw.Text+"',BPS_Aso_qty='" + SBPS_Aso_Qty.Text+"',BPS_Crp_qty='" + SBPS_Crp_Qty.Text+"',BPS_Rafactor_qty='" + SBPS_Rafactor_Qty.Text+"',Bw_Trop_qty='" + SBS_trop_Qty.Text;
                    Sqlstr = Sqlstr + "' where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";

                }
                cmd = new SqlCommand(Sqlstr, con);
                cmd.ExecuteNonQuery();
                Sqlstr = "";
                Sqlstr = "delete from serologyext where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
                cmd = new SqlCommand(Sqlstr, con);
                cmd.ExecuteNonQuery();
                Sqlstr = "";
                for (int i = 0; i < dgvser.Rows.Count; i++)
                {

                    if (dgvser.Rows[i].Cells[0].Value != null)
                    {

                        Sqlstr = "insert into serologyext (pcode,test,method,result,unit,normal_range) values ('" + Convert.ToInt32(cbopcode.Text) + "','" + dgvser.Rows[i].Cells[0].Value + "','" + dgvser.Rows[i].Cells[1].Value + "','" + dgvser.Rows[i].Cells[2].Value + "','" + dgvser.Rows[i].Cells[3].Value + "','" + dgvser.Rows[i].Cells[4].Value + "')";
                        cmd = new SqlCommand(Sqlstr, con);
                        cmd.ExecuteNonQuery();
                        Sqlstr = "";
                    }
                }
            
            
            
            
            
            
            }
        }

        private void btnprintserology_Click(object sender, EventArgs e)
        {
            Frmrepserology frs = new Frmrepserology();
            frs.Show();
        }

        private void label122_Click(object sender, EventArgs e)
        {

        }

        private void Bcr1_PPPG_PGPG_1hr_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);

        }

        private void Bcr1_RBS_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bcr1_PBBS_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bcr1_PLBS_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bcr1_GTT_1hr_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bcr1_GTT_2hr_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bcr1_GTT_3hr_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bcr1_PGBS_1hr_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bcr1_PGBS_2hr_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bcr1_HBAC_good_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bcr1_HBAC_fair_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bcr1_HBAC_poor_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bcr1_MBGE_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bcr3_Uric_Acid_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bcr3_NPN_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bcr2_LP_LHR_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bcr4_LFT_Indirect_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bcr4_LFT_GGTP_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bcr5_Electrolyte_Chlorides_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void label180_Click(object sender, EventArgs e)
        {

        }

        private void btnsavebc1_Click(object sender, EventArgs e)
        {
           
        }

        private void btnsavebc2_Click(object sender, EventArgs e)
        {
            //String Sqlstr = "";
            //con.Close();
            //con.Open();

            //if (MessageBox.Show("Save ? ", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            //{
            //    String strsql5 = "";

            //    strsql5 = strsql5 + "select cc,pcode,Bcr1_Glucose_Fpg_RPG,Bcr1_PPPG_PGPG_2hr,Bcr1_PPPG_PGPG_1hr,Bcr1_RBS,Bcr1_PBBS,Bcr1_PLBS,Bcr1_GTT_1hr,Bcr1_GTT_2hr,Bcr1_GTT_3hr,Bcr1_PGBS_1hr,Bcr1_PGBS_2hr,Bcr1_HBAC_fair,Bcr1_HBAC_good,Bcr1_HBAC_poor,Bcr1_MBGE,Bcr_RP_Urea,Bcr_RP_BUN,Bcr_RP_Creatinine,Bcr3_NPN,Bcr3_Uric_Acid,Bcr_LP_Cholesterol,Bcr_LP_HDLCholesterol,";
            //    strsql5 = strsql5 + "Bcr_LP_LDLCholesterol,Bcr_LP_VLDLCholesterol,Bcr_LP_Triglycerides,Bcr2_LP_CHR,Bcr2_LP_LHR,Bcr_LFT_Bilirubin_total,Bcr_LFT_Bilirubin_Direct,Bcr4_LFT_Indirect,Bcr_LFT_Alkaline_Phosphates,";
            //    strsql5 = strsql5 + "Bcr_LFT_SGOT_AST,Bcr_LFT_SGPT_ALT,Bcr_LFT_Albumin,Bcr_LFT_Protein,Bcr_LFT_Globulin,Bcr_LFT_AG_Ratio,Bcr4_LFT_GGTP,Bcr_Electrolyte_Sodium,";
            //    strsql5 = strsql5 + "Bcr_Electrolyte_Potassium,Bcr5_Electrolyte_Chlorides,Bcr_OTH_Acid_Phosphate,Bcr_OTH_Amylase,Bcr_OTH_Acid_Calcium,Bcr_OTH_Acid_Phosphorus,Bcr_OTH_Uric_Acid,Bcr_OTH_Pasting_urine_sugar,Bcr_OTH_PP_PG_urine_sugar";
            //    strsql5 = strsql5 + " from Biochemist where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";

            //    da = new SqlDataAdapter(strsql5, con);
            //    ds5 = new DataSet();
            //    da.Fill(ds5);
            //    if (ds5.Tables[0].Rows.Count == 0)
            //    {
            //        Sqlstr = "insert into Biochemist (cc,pcode,Bcr1_Glucose_Fpg_RPG,Bcr1_PPPG_PGPG_2hr,Bcr1_PPPG_PGPG_1hr,Bcr1_RBS,Bcr1_PBBS,Bcr1_PLBS,Bcr1_GTT_1hr,Bcr1_GTT_2hr,Bcr1_GTT_3hr,Bcr1_PGBS_1hr,Bcr1_PGBS_2hr,Bcr1_HBAC_fair,Bcr1_HBAC_good,Bcr1_HBAC_poor,Bcr1_MBGE,Bcr_RP_Urea,Bcr_RP_BUN,Bcr_RP_Creatinine,Bcr3_NPN,Bcr3_Uric_Acid,Bcr_LP_Cholesterol,Bcr_LP_HDLCholesterol,";
            //        Sqlstr = Sqlstr + "Bcr_LP_LDLCholesterol,Bcr_LP_VLDLCholesterol,Bcr_LP_Triglycerides  ,Bcr2_LP_CHR,Bcr2_LP_LHR,Bcr_LFT_Bilirubin_total,Bcr_LFT_Bilirubin_Direct,Bcr4_LFT_Indirect,Bcr_LFT_Alkaline_Phosphates,";
            //        Sqlstr = Sqlstr + "Bcr_LFT_SGOT_AST,Bcr_LFT_SGPT_ALT,Bcr_LFT_Albumin,Bcr_LFT_Protein,Bcr_LFT_Globulin,Bcr_LFT_AG_Ratio,Bcr4_LFT_GGTP,Bcr_Electrolyte_Sodium,";
            //        Sqlstr = Sqlstr + "Bcr_Electrolyte_Potassium,Bcr5_Electrolyte_Chlorides,Bcr_OTH_Acid_Phosphate,Bcr_OTH_Amylase,Bcr_OTH_Acid_Calcium,Bcr_OTH_Acid_Phosphorus,Bcr_OTH_Uric_Acid,Bcr_OTH_Pasting_urine_sugar,Bcr_OTH_PP_PG_urine_sugar,db_imp,Bcr_OTH_Lipase,Bcr_OTH_Nac) values ( '" + Convert.ToInt32(txtcompanycode.Text) + "','" + Convert.ToInt32(cbopcode.Text);

            //        Sqlstr = Sqlstr + "','" + Bc2_fbs.Text + "','" + Bc2_ppbs2.Text + "','" + Bc2_ppbs1.Text + "','" + Bcr1_RBS.Text + "','" + Bcr1_PBBS.Text + "','" + Bcr1_PLBS.Text + "','" + Bcr1_GTT_1hr.Text + "','" + Bcr1_GTT_2hr.Text + "','" + Bcr1_GTT_3hr.Text + "','" + Bcr1_PGBS_1hr.Text + "','" + Bcr1_PGBS_2hr.Text + "','" + Bcr1_HBAC_fair.Text + "','" + Bcr1_HBAC_good.Text + "','" + Bcr1_HBAC_poor.Text + "','" + Bcr1_MBGE.Text + "','" + Bc2_urea.Text + "','" + Bcr_RP_BUN.Text + "','" + Bc2_creatinine.Text + "','" + Bcr3_NPN.Text + "','" + Bc2_uric_acid.Text + "','" + Bcr_LP_Cholesterol.Text + "','" + Bcr_LP_HDLCholesterol.Text;
            //        Sqlstr = Sqlstr + "','" + Bcr_LP_LDLCholesterol.Text + "','" + Bcr_LP_VLDLCholesterol.Text + "','" + Bcr_LP_Triglycerides.Text + "','" + Bcr2_LP_CHR.Text + "','" + Bcr2_LP_LHR.Text + "','" + Bcr_LFT_Bilirubin_total.Text + "','" + Bcr_LFT_Bilirubin_Direct.Text + "','" + Bcr4_LFT_Indirect.Text + "','" + Bcr_LFT_Alkaline_Phosphates.Text;
            //        Sqlstr = Sqlstr + "','" + Bcr_LFT_SGOT_AST.Text + "','" + Bcr_LFT_SGPT_ALT.Text + "','" + Bcr_LFT_Albumin.Text + "','" + Bcr_LFT_Protein.Text + "','" + Bcr_LFT_Globulin.Text + "','" + Bcr_LFT_AG_Ratio.Text + "','" + Bcr4_LFT_GGTP.Text + "','" + Bcr_Electrolyte_Sodium.Text;
            //        Sqlstr = Sqlstr + "','" + Bcr_Electrolyte_Potassium.Text + "','" + Bcr5_Electrolyte_Chlorides.Text + "','" + Bcr_OTH_Acid_Phosphate.Text + "','" + Bcr_OTH_Amylase.Text + "','" + Bcr_OTH_Acid_Calcium.Text + "','" + Bcr_OTH_Acid_Phosphorus.Text + "','" + Bcr_OTH_Uric_Acid.Text + "','" + Bcr_OTH_Pasting_urine_sugar.Text + "','" + Bcr_OTH_PP_PG_urine_sugar.Text + "','" + db2_imp.Text + "','" + Bcr_OTH_Lipase.Text + "','" + Bcr_OTH_nac.Text + "')";
            //        cmd = new SqlCommand(Sqlstr, con);
            //        cmd.ExecuteNonQuery();
            //        Sqlstr = "";


            //    }
            //    else
            //    {
            //        String strsql = "";
                    
            //        strsql = "update Biochemist set cc='" + Convert.ToInt32(txtcompanycode.Text) + "',pcode='" + Convert.ToInt32(cbopcode.Text);
            //        strsql = strsql + "',Bcr1_Glucose_Fpg_RPG='" + Bc2_fbs.Text + "',Bcr1_PPPG_PGPG_2hr='" + Bc2_ppbs2.Text + "',Bcr1_PPPG_PGPG_1hr='" + Bc2_ppbs1.Text + "',Bcr1_RBS='" + Bcr1_RBS.Text + "',Bcr1_PBBS='" + Bcr1_PBBS.Text + "',Bcr1_PLBS='" + Bcr1_PLBS.Text + "', Bcr1_GTT_1hr='" + Bcr1_GTT_1hr.Text + "',Bcr1_GTT_2hr='" + Bcr1_GTT_2hr.Text + "',Bcr1_GTT_3hr='" + Bcr1_GTT_3hr.Text + "',Bcr1_PGBS_1hr='" + Bcr1_PGBS_1hr.Text + "',Bcr1_PGBS_2hr='" + Bcr1_PGBS_2hr.Text + "',Bcr1_HBAC_fair='" + Bcr1_HBAC_fair.Text + "',Bcr1_HBAC_good='" + Bcr1_HBAC_good.Text + "',Bcr1_HBAC_poor='" + Bcr1_HBAC_poor.Text + "', Bcr1_MBGE='" + Bcr1_MBGE.Text + "', Bcr_RP_Urea='" + Bc2_urea.Text + "',Bcr_RP_BUN='" + Bcr_RP_BUN.Text + "',Bcr_RP_Creatinine='" + Bc2_creatinine.Text + "',Bcr3_NPN='" + Bcr3_NPN.Text + "',Bcr3_Uric_Acid='" + Bc2_uric_acid.Text + "',Bcr_LP_Cholesterol='" + Bcr_LP_Cholesterol.Text + "',Bcr_LP_HDLCholesterol='" + Bcr_LP_HDLCholesterol.Text;
            //        strsql = strsql + "',Bcr_LP_LDLCholesterol='" + Bcr_LP_LDLCholesterol.Text + "',Bcr_LP_VLDLCholesterol='" + Bcr_LP_VLDLCholesterol.Text + "',Bcr_LP_Triglycerides='" + Bcr_LP_Triglycerides.Text + "',Bcr2_LP_CHR='" + Bcr2_LP_CHR.Text + "',Bcr2_LP_LHR='" + Bcr2_LP_LHR.Text + "',Bcr_LFT_Bilirubin_total='" + Bcr_LFT_Bilirubin_total.Text + "',Bcr_LFT_Bilirubin_Direct='" + Bcr_LFT_Bilirubin_Direct.Text + "',Bcr4_LFT_Indirect='" + Bcr4_LFT_Indirect.Text + "',Bcr_LFT_Alkaline_Phosphates='" + Bcr_LFT_Alkaline_Phosphates.Text;
            //        strsql = strsql + "',Bcr_LFT_SGOT_AST='" + Bcr_LFT_SGOT_AST.Text + "',Bcr_LFT_SGPT_ALT='" + Bcr_LFT_SGPT_ALT.Text + "',Bcr_LFT_Albumin='" + Bcr_LFT_Albumin.Text + "',Bcr_LFT_Protein='" + Bcr_LFT_Protein.Text + "',Bcr_LFT_Globulin='" + Bcr_LFT_Globulin.Text + "',Bcr_LFT_AG_Ratio='" + Bcr_LFT_AG_Ratio.Text + "',Bcr4_LFT_GGTP='" + Bcr4_LFT_GGTP.Text + "',Bcr_Electrolyte_Sodium='" + Bcr_Electrolyte_Sodium.Text;
            //        strsql = strsql + "',Bcr_Electrolyte_Potassium='" + Bcr_Electrolyte_Potassium.Text + "',Bcr5_Electrolyte_Chlorides='" + Bcr5_Electrolyte_Chlorides.Text + "',Bcr_OTH_Acid_Phosphate='" + Bcr_OTH_Acid_Phosphate.Text + "',Bcr_OTH_Amylase='" + Bcr_OTH_Amylase.Text + "',Bcr_OTH_Acid_Calcium='" + Bcr_OTH_Acid_Calcium.Text + "',Bcr_OTH_Acid_Phosphorus='" + Bcr_OTH_Acid_Phosphorus.Text + "',Bcr_OTH_Uric_Acid='" + Bcr_OTH_Uric_Acid.Text + "',Bcr_OTH_Pasting_urine_sugar='" + Bcr_OTH_Pasting_urine_sugar.Text + "',Bcr_OTH_PP_PG_urine_sugar='" + Bcr_OTH_PP_PG_urine_sugar.Text + "',Bcr_OTH_Lipase='" + Bcr_OTH_Lipase.Text + "',Bcr_OTH_Nac='" + Bcr_OTH_nac.Text + "',db_imp='" + db2_imp.Text;

            //        strsql = strsql + "' where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
            //        cmd = new SqlCommand(strsql, con);
            //        cmd.ExecuteNonQuery();
            //        strsql = "";
            //    }

            //}

        }

        private void btnsavebc3_Click(object sender, EventArgs e)
        {
            //String Sqlstr = "";
            //con.Close();
            //con.Open();

            //if (MessageBox.Show("Save ? ", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            //{
            //    String strsql5 = "";

            //    strsql5 = strsql5 + "select cc,pcode,Bcr1_Glucose_Fpg_RPG,Bcr1_PPPG_PGPG_2hr,Bcr1_PPPG_PGPG_1hr,Bcr1_RBS,Bcr1_PBBS,Bcr1_PLBS,Bcr1_GTT_1hr,Bcr1_GTT_2hr,Bcr1_GTT_3hr,Bcr1_PGBS_1hr,Bcr1_PGBS_2hr,Bcr1_HBAC_fair,Bcr1_HBAC_good,Bcr1_HBAC_poor,Bcr1_MBGE,Bcr_RP_Urea,Bcr_RP_BUN,Bcr_RP_Creatinine,Bcr3_NPN,Bcr3_Uric_Acid,Bcr_LP_Cholesterol,Bcr_LP_HDLCholesterol,";
            //    strsql5 = strsql5 + "Bcr_LP_LDLCholesterol,Bcr_LP_VLDLCholesterol,Bcr_LP_Triglycerides,Bcr2_LP_CHR,Bcr2_LP_LHR,Bcr_LFT_Bilirubin_total,Bcr_LFT_Bilirubin_Direct,Bcr4_LFT_Indirect,Bcr_LFT_Alkaline_Phosphates,";
            //    strsql5 = strsql5 + "Bcr_LFT_SGOT_AST,Bcr_LFT_SGPT_ALT,Bcr_LFT_Albumin,Bcr_LFT_Protein,Bcr_LFT_Globulin,Bcr_LFT_AG_Ratio,Bcr4_LFT_GGTP,Bcr_Electrolyte_Sodium,";
            //    strsql5 = strsql5 + "Bcr_Electrolyte_Potassium,Bcr5_Electrolyte_Chlorides,Bcr_OTH_Acid_Phosphate,Bcr_OTH_Amylase,Bcr_OTH_Acid_Calcium,Bcr_OTH_Acid_Phosphorus,Bcr_OTH_Uric_Acid,Bcr_OTH_Pasting_urine_sugar,Bcr_OTH_PP_PG_urine_sugar";
            //    strsql5 = strsql5 + " from Biochemist where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";

            //    da = new SqlDataAdapter(strsql5, con);
            //    ds5 = new DataSet();
            //    da.Fill(ds5);
            //    if (ds5.Tables[0].Rows.Count == 0)
            //    {
            //        Sqlstr = "insert into Biochemist (cc,pcode,Bcr1_Glucose_Fpg_RPG,Bcr1_PPPG_PGPG_2hr,Bcr1_PPPG_PGPG_1hr,Bcr1_RBS,Bcr1_PBBS,Bcr1_PLBS,Bcr1_GTT_1hr,Bcr1_GTT_2hr,Bcr1_GTT_3hr,Bcr1_PGBS_1hr,Bcr1_PGBS_2hr,Bcr1_HBAC_fair,Bcr1_HBAC_good,Bcr1_HBAC_poor,Bcr1_MBGE,Bcr_RP_Urea,Bcr_RP_BUN,Bcr_RP_Creatinine,Bcr3_NPN,Bcr3_Uric_Acid,Bcr_LP_Cholesterol,Bcr_LP_HDLCholesterol,";
            //        Sqlstr = Sqlstr + "Bcr_LP_LDLCholesterol,Bcr_LP_VLDLCholesterol,Bcr_LP_Triglycerides  ,Bcr2_LP_CHR,Bcr2_LP_LHR,Bcr_LFT_Bilirubin_total,Bcr_LFT_Bilirubin_Direct,Bcr4_LFT_Indirect,Bcr_LFT_Alkaline_Phosphates,";
            //        Sqlstr = Sqlstr + "Bcr_LFT_SGOT_AST,Bcr_LFT_SGPT_ALT,Bcr_LFT_Albumin,Bcr_LFT_Protein,Bcr_LFT_Globulin,Bcr_LFT_AG_Ratio,Bcr4_LFT_GGTP,Bcr_Electrolyte_Sodium,";
            //        Sqlstr = Sqlstr + "Bcr_Electrolyte_Potassium,Bcr5_Electrolyte_Chlorides,Bcr_OTH_Acid_Phosphate,Bcr_OTH_Amylase,Bcr_OTH_Acid_Calcium,Bcr_OTH_Acid_Phosphorus,Bcr_OTH_Uric_Acid,Bcr_OTH_Pasting_urine_sugar,Bcr_OTH_PP_PG_urine_sugar,db_imp,Bcr_OTH_Lipase,Bcr_OTH_Nac) values ( '" + Convert.ToInt32(txtcompanycode.Text) + "','" + Convert.ToInt32(cbopcode.Text);

            //        Sqlstr = Sqlstr + "','" + Bc3_fbs.Text + "','" + Bc3_ppbs2.Text + "','" + Bc3_ppbs1.Text + "','" + Bcr1_RBS.Text + "','" + Bcr1_PBBS.Text + "','" + Bcr1_PLBS.Text + "','" + Bcr1_GTT_1hr.Text + "','" + Bcr1_GTT_2hr.Text + "','" + Bcr1_GTT_3hr.Text + "','" + Bcr1_PGBS_1hr.Text + "','" + Bcr1_PGBS_2hr.Text + "','" + Bcr1_HBAC_fair.Text + "','" + Bcr1_HBAC_good.Text + "','" + Bcr1_HBAC_poor.Text + "','" + Bcr1_MBGE.Text + "','" + Bc3_urea.Text + "','" + Bcr_RP_BUN.Text + "','" + Bc3_creatinine.Text + "','" + Bcr3_NPN.Text + "','" + Bc3_uric_acid.Text + "','" + Bc3_cholesterol.Text + "','" + Bc3_hdl.Text;
            //        Sqlstr = Sqlstr + "','" + Bc3_ldl.Text + "','" + Bc3_vldl.Text + "','" + Bc3_triglyceride.Text + "','" + Bcr2_LP_CHR.Text + "','" + Bcr2_LP_LHR.Text + "','" + Bcr_LFT_Bilirubin_total.Text + "','" + Bcr_LFT_Bilirubin_Direct.Text + "','" + Bcr4_LFT_Indirect.Text + "','" + Bcr_LFT_Alkaline_Phosphates.Text;
            //        Sqlstr = Sqlstr + "','" + Bcr_LFT_SGOT_AST.Text + "','" + Bcr_LFT_SGPT_ALT.Text + "','" + Bcr_LFT_Albumin.Text + "','" + Bcr_LFT_Protein.Text + "','" + Bcr_LFT_Globulin.Text + "','" + Bcr_LFT_AG_Ratio.Text + "','" + Bcr4_LFT_GGTP.Text + "','" + Bcr_Electrolyte_Sodium.Text;
            //        Sqlstr = Sqlstr + "','" + Bcr_Electrolyte_Potassium.Text + "','" + Bcr5_Electrolyte_Chlorides.Text + "','" + Bcr_OTH_Acid_Phosphate.Text + "','" + Bcr_OTH_Amylase.Text + "','" + Bcr_OTH_Acid_Calcium.Text + "','" + Bcr_OTH_Acid_Phosphorus.Text + "','" + Bcr_OTH_Uric_Acid.Text + "','" + Bcr_OTH_Pasting_urine_sugar.Text + "','" + Bcr_OTH_PP_PG_urine_sugar.Text + "','" + db3_imp.Text + "','" + Bcr_OTH_Lipase.Text + "','" + Bcr_OTH_nac.Text + "')";
            //        cmd = new SqlCommand(Sqlstr, con);
            //        cmd.ExecuteNonQuery();
            //        Sqlstr = "";


            //    }
            //    else
            //    {
            //        String strsql = "";
            //        strsql = "update Biochemist set cc='" + Convert.ToInt32(txtcompanycode.Text) + "',pcode='" + Convert.ToInt32(cbopcode.Text);
            //        strsql = strsql + "',Bcr1_Glucose_Fpg_RPG='" + Bc3_fbs.Text + "',Bcr1_PPPG_PGPG_2hr='" + Bc3_ppbs2.Text + "',Bcr1_PPPG_PGPG_1hr='" + Bc3_ppbs1.Text + "',Bcr1_RBS='" + Bcr1_RBS.Text + "',Bcr1_PBBS='" + Bcr1_PBBS.Text + "',Bcr1_PLBS='" + Bcr1_PLBS.Text + "', Bcr1_GTT_1hr='" + Bcr1_GTT_1hr.Text + "',Bcr1_GTT_2hr='" + Bcr1_GTT_2hr.Text + "',Bcr1_GTT_3hr='" + Bcr1_GTT_3hr.Text + "',Bcr1_PGBS_1hr='" + Bcr1_PGBS_1hr.Text + "',Bcr1_PGBS_2hr='" + Bcr1_PGBS_2hr.Text + "',Bcr1_HBAC_fair='" + Bcr1_HBAC_fair.Text + "',Bcr1_HBAC_good='" + Bcr1_HBAC_good.Text + "',Bcr1_HBAC_poor='" + Bcr1_HBAC_poor.Text + "', Bcr1_MBGE='" + Bcr1_MBGE.Text + "', Bcr_RP_Urea='" + Bc3_urea.Text + "',Bcr_RP_BUN='" + Bcr_RP_BUN.Text + "',Bcr_RP_Creatinine='" + Bc3_creatinine.Text + "',Bcr3_NPN='" + Bcr3_NPN.Text + "',Bcr3_Uric_Acid='" + Bc3_uric_acid.Text + "',Bcr_LP_Cholesterol='" + Bc3_cholesterol.Text + "',Bcr_LP_HDLCholesterol='" + Bc3_hdl.Text;
            //        strsql = strsql + "',Bcr_LP_LDLCholesterol='" + Bc3_ldl.Text + "',Bcr_LP_VLDLCholesterol='" + Bc3_vldl.Text + "',Bcr_LP_Triglycerides='" + Bc3_triglyceride.Text + "',Bcr2_LP_CHR='" + Bcr2_LP_CHR.Text + "',Bcr2_LP_LHR='" + Bcr2_LP_LHR.Text + "',Bcr_LFT_Bilirubin_total='" + Bcr_LFT_Bilirubin_total.Text + "',Bcr_LFT_Bilirubin_Direct='" + Bcr_LFT_Bilirubin_Direct.Text + "',Bcr4_LFT_Indirect='" + Bcr4_LFT_Indirect.Text + "',Bcr_LFT_Alkaline_Phosphates='" + Bcr_LFT_Alkaline_Phosphates.Text;
            //        strsql = strsql + "',Bcr_LFT_SGOT_AST='" + Bcr_LFT_SGOT_AST.Text + "',Bcr_LFT_SGPT_ALT='" + Bcr_LFT_SGPT_ALT.Text + "',Bcr_LFT_Albumin='" + Bcr_LFT_Albumin.Text + "',Bcr_LFT_Protein='" + Bcr_LFT_Protein.Text + "',Bcr_LFT_Globulin='" + Bcr_LFT_Globulin.Text + "',Bcr_LFT_AG_Ratio='" + Bcr_LFT_AG_Ratio.Text + "',Bcr4_LFT_GGTP='" + Bcr4_LFT_GGTP.Text + "',Bcr_Electrolyte_Sodium='" + Bcr_Electrolyte_Sodium.Text;
            //        strsql = strsql + "',Bcr_Electrolyte_Potassium='" + Bcr_Electrolyte_Potassium.Text + "',Bcr5_Electrolyte_Chlorides='" + Bcr5_Electrolyte_Chlorides.Text + "',Bcr_OTH_Acid_Phosphate='" + Bcr_OTH_Acid_Phosphate.Text + "',Bcr_OTH_Amylase='" + Bcr_OTH_Amylase.Text + "',Bcr_OTH_Acid_Calcium='" + Bcr_OTH_Acid_Calcium.Text + "',Bcr_OTH_Acid_Phosphorus='" + Bcr_OTH_Acid_Phosphorus.Text + "',Bcr_OTH_Uric_Acid='" + Bcr_OTH_Uric_Acid.Text + "',Bcr_OTH_Pasting_urine_sugar='" + Bcr_OTH_Pasting_urine_sugar.Text + "',Bcr_OTH_PP_PG_urine_sugar='" + Bcr_OTH_PP_PG_urine_sugar.Text + "',Bcr_OTH_Lipase='" + Bcr_OTH_Lipase.Text + "',Bcr_OTH_Nac='" + Bcr_OTH_nac.Text + "',db_imp='" + db3_imp.Text;
            //        strsql = strsql + "' where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
            //        cmd = new SqlCommand(strsql, con);
            //        cmd.ExecuteNonQuery();
            //        strsql = "";
            //    }

            //}
        }

        private void txtage_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && !Char.IsPunctuation(e.KeyChar) && e.KeyChar != Delete;

            //if (txtage.Text == "")
            //    txtage.Text = "0";
        }

        private void txtdue_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && !Char.IsPunctuation(e.KeyChar) && e.KeyChar != Delete;

            if (txtdue.Text == "")
                txtdue.Text = "0.00";
        }

        private void txtpaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && !Char.IsPunctuation(e.KeyChar) && e.KeyChar != Delete;

            if (txtpaid.Text == "")
                txtpaid.Text = "0.00";
        }

        private void btnprintbc1_Click(object sender, EventArgs e)
        {
            Frmrepbiochemn repbiochem1 = new Frmrepbiochemn();
            repbiochem1.Show();
        }

        private void btnprintbc2_Click(object sender, EventArgs e)
        {
            Frmrepbiochemn repbiochem2 = new Frmrepbiochemn();
            repbiochem2.Show();
        }

        private void btnprintbc3_Click(object sender, EventArgs e)
        {
            Frmrepbiochemn repbiochem3 = new Frmrepbiochemn();
            repbiochem3.Show();
        }

        private void btnsaveculture_Click(object sender, EventArgs e)
        {
            
            con.Close();
            con.Open();

            if (MessageBox.Show("Save ? ", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                String strsql5 = "";
                String strsql = "";
                //strsql5 = strsql5 + "select cc,pcode,amoxicillin,amoxicillin_no,amoxicillin_srm,ampicillin,ampicillin_no,ampicillin_srm,amikacin,amikacin_no,amikacin_srm,cephalexin,cephalexin_no,cephalexin_srm,ceftazidime,ceftazidime_no,ceftazidime_srm,ceftriaxone,ceftriaxone_no,ceftriaxone_srm,cloxacillin,cloxacillin_no,cloxacillin_srm,co_trimoxazole,co_trimoxazole_no,co_trimoxazole_srm,cefazolin,cefazolin_no,cefazolin_srm,cefotaxime,cefotaxime_no,cefotaxime_srm,ciprofloxacin,ciprofloxacin_no,ciprofloxacin_srm,doxycycline,doxycycline_no,doxycycline_srm,";
                //strsql5 = strsql5 + "erythromycin,erythromycin_no,erythromycin_srm,gentamycin,gentamycin_no,gentamycin_srm,gemifloxacin,gemifloxacin_no,gemifloxacin_srm,neomycin,neomycin_no,neomycin_srm,nitrofurantion,nitrofurantion_no,nitrofurantion_srm,norfloxacine,norfloxacine_no,norfloxacine_srm,";
                //strsql5 = strsql5 + "netromycin,netromycin_no,netromycin_srm,ofloxacin,ofloxacin_no,ofloxacin_srm,piperacillin,piperacillin_no,piperacillin_srm,pencillin,pencillin_no,pencillin_srm,streptomycin,streptomycin_no,streptomycin_srm,tetracycline,tetracycline_no,tetracycline_srm,";
                //strsql5 = strsql5 + "roxythromycin,roxythromycin_no,roxythromycin_srm,cefoperazone,cefoperazone_no,cefoperazone_srm,levofloxacin,levofloxacin_no,levofloxacin_srm,gatifloxacin,gatifloxacin_no,gatifloxacin_srm,tazobactum,tazobactum_no,tazobactum_srm,tobramycin,tobramycin_no,tobramycin_srm,cefixime,cefixime_no,cefixime_srm,organism_isolated,cu_imp";
                //strsql5 = strsql5 + "select * ";
                strsql5 = strsql5 + "select *  from Cultureext where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";

                da = new SqlDataAdapter(strsql5, con);
                ds5 = new DataSet();
                da.Fill(ds5);
              tag = 0;
                if (ds5.Tables[0].Rows.Count == 0)
                {
                    // 1st column dupl check start
                   //int k = 0;
                   // while (k <= dgvculture.Rows.Count-1)

                   // {
                   //     if (dgvculture.Rows[k].Cells[0].Value == null) break;
                   //      String dcvk = dgvculture.Rows[k].Cells[0].Value.ToString ().Trim ();
                   //     int m = k+1;
                   //     while (m < dgvculture.Rows.Count-1)
                   //     {
                   //         if (dgvculture.Rows[m].Cells[0].Value == null) break;
                   //         String dcvm = dgvculture.Rows[m].Cells[0].Value.ToString().Trim();
                   //         if (dcvk == dcvm)
                   //         {
                   //             MessageBox.Show(dcvk + " is duplicate");
                   //             tag = 1;
                   //             break;
                   //         }
                   //         else
                   //         {
                   //             m++;
                   //           }
                   //        if (m == dgvculture.Rows.Count-1)break ; 
                   //     }
                   //     k++;
                   //     if (k == dgvculture.Rows.Count - 1) break; 
                   // }
                   // // 1st column dupl check end
                   // // 1st column dupl check with 3rd column start  
                   //  k = 0;
                   // while (k <= dgvculture.Rows.Count - 1)
                   // {
                   //     if (dgvculture.Rows[k].Cells[0].Value == null) break;
                   //     String dcvk = dgvculture.Rows[k].Cells[0].Value.ToString().Trim();
                   //     int m = k + 1;
                   //     while (m < dgvculture.Rows.Count - 1)
                   //     {
                   //         if (dgvculture.Rows[m].Cells[2].Value == null) break;
                            
                   //         String dcvm = dgvculture.Rows[m].Cells[2].Value.ToString().Trim();
                   //         if (dcvk == dcvm)
                   //         {
                   //             MessageBox.Show(dcvk + " is duplicate");
                   //             tag = 1;
                   //             break;
                   //         }
                   //         else
                   //         {
                   //             m++;
                   //         }
                   //         if (m == dgvculture.Rows.Count - 1) break;
                   //     }
                   //     k++;
                   //     if (k == dgvculture.Rows.Count - 1) break;
                   // }
                   //  // 1st column dupl check with 3rd column  end

                   // // 3rd column dupl check with 3rd column start  
                   // k = 0;
                   // while (k <= dgvculture.Rows.Count - 1)
                   // {
                   //     if (dgvculture.Rows[k].Cells[2].Value == null) break;
                   //     String dcvk = dgvculture.Rows[k].Cells[2].Value.ToString().Trim();
                   //     int m = k + 1;
                   //     while (m < dgvculture.Rows.Count - 1)
                   //     {
                   //         if (dgvculture.Rows[m].Cells[2].Value == null) break;
                   //         String dcvm = dgvculture.Rows[m].Cells[2].Value.ToString().Trim();
                   //         if (dcvk == dcvm)
                   //         {
                   //             MessageBox.Show(dcvk + " is duplicate");
                   //             tag = 1;
                   //             break;
                   //         }
                   //         else
                   //         {
                   //             m++;
                   //         }
                   //         if (m == dgvculture.Rows.Count - 1) break;
                   //     }
                   //     k++;
                   //     if (k == dgvculture.Rows.Count - 1) break;
                   // }
                   // // 3rd column dupl check with 3rd column  end                    
                    
                    
                    
                    
                    
                    if (tag == 0)
                    {
                        for (int i = 0; i < dgvculture.Rows.Count; i++)
                        {
                            //if (dgvculture.Rows[i].Cells[0].Value != null || dgvculture.Rows[i].Cells[2].Value != null)
                            if (cbons.Text != "")
                            {
                                strsql = "insert into Cultureext (cc,pcode,antibiotic,antibiotics,antibioticv,";
                                strsql = strsql + "organism_isolated,colony_count,cu_imp,test) values ( '" + Convert.ToInt32(txtcompanycode.Text) + "','" + Convert.ToInt32(cbopcode.Text) + "','" + dgvculture.Rows[i].Cells[0].Value + "','" + dgvculture.Rows[i].Cells[1].Value + "','" + dgvculture.Rows[i].Cells[2].Value + "','" + Cu_Organism_isolated1.Text + "','" + cbocolonycount.Text + "','" + cul_imp.Text + "','" + cbons.Text + "')";

                                cmd = new SqlCommand(strsql, con);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                   

                    strsql = "";
                
                
                }
                else
                {
                    cmd = new SqlCommand("delete from cultureext where pcode='" + Convert.ToInt32(cbopcode.Text) + "'", con);
                    cmd.ExecuteNonQuery();

               //modification start

                    // 1st column dupl check start
                    //int k = 0;
                    //while (k <= dgvculture.Rows.Count - 1)

                    //{
                    //    if (dgvculture.Rows[k].Cells[0].Value == null) break;
                    //    String dcvk = dgvculture.Rows[k].Cells[0].Value.ToString().Trim();
                    //    int m = k + 1;
                    //    while (m < dgvculture.Rows.Count - 1)
                    //    {

                    //        if (dgvculture.Rows[m].Cells[0].Value==null) break;
                    //        String dcvm = dgvculture.Rows[m].Cells[0].Value.ToString().Trim();
                    //        if (dcvk == dcvm)
                    //        {
                    //            MessageBox.Show(dcvk + " is duplicate");
                    //            tag = 1;
                    //            break;
                    //        }
                    //        else
                    //        {
                    //            m++;
                    //        }
                    //        if (m == dgvculture.Rows.Count - 1) break;
                    //    }
                    //    k++;
                    //    if (k == dgvculture.Rows.Count - 1) break;
                    //}
                    //// 1st column dupl check end
                    //// 1st column dupl check with 3rd column start  
                    //k = 0;
                    //while (k <= dgvculture.Rows.Count - 1)
                    //{
                    //    if (dgvculture.Rows[k].Cells[0].Value == null) break;
                    //    String dcvk = dgvculture.Rows[k].Cells[0].Value.ToString().Trim();
                    //    int m = k + 1;
                    //    while (m < dgvculture.Rows.Count - 1)
                    //    {
                    //        if (dgvculture.Rows[m].Cells[2].Value == null) break;

                    //        String dcvm = dgvculture.Rows[m].Cells[2].Value.ToString().Trim();
                    //        if (dcvk == dcvm)
                    //        {
                    //            MessageBox.Show(dcvk + " is duplicate");
                    //            tag = 1;
                    //            break;
                    //        }
                    //        else
                    //        {
                    //            m++;
                    //        }
                    //        if (m == dgvculture.Rows.Count - 1) break;
                    //    }
                    //    k++;
                    //    if (k == dgvculture.Rows.Count - 1) break;
                    //}
                    //// 1st column dupl check with 3rd column  end

                    //// 3rd column dupl check with 3rd column start  
                    //k = 0;
                    //while (k <= dgvculture.Rows.Count - 1)
                    //{
                    //    if (dgvculture.Rows[k].Cells[2].Value == null) break;
                    //    String dcvk = dgvculture.Rows[k].Cells[2].Value.ToString().Trim();
                    //    int m = k + 1;
                    //    while (m < dgvculture.Rows.Count - 1)
                    //    {
                    //        if (dgvculture.Rows[m].Cells[2].Value == null) break;
                    //        String dcvm = dgvculture.Rows[m].Cells[2].Value.ToString().Trim();
                    //        if (dcvk == dcvm)
                    //        {
                    //            MessageBox.Show(dcvk + " is duplicate");
                    //            tag = 1;
                    //            break;
                    //        }
                    //        else
                    //        {
                    //            m++;
                    //        }
                    //        if (m == dgvculture.Rows.Count - 1) break;
                    //    }
                    //    k++;
                    //    if (k == dgvculture.Rows.Count - 1) break;
                    //}
                    //// 3rd column dupl check with 3rd column  end                    
                   

                    ////modification end





                    if (tag == 0)
                    {


                        for (int i = 0; i < dgvculture.Rows.Count; i++)
                        {
                            if (cbons.Text!="")
                            {
                                strsql = "insert into Cultureext (cc,pcode,antibiotic,antibiotics,antibioticv,";
                                //strsql = strsql + "erythromycin,erythromycin_no,erythromycin_srm,gentamycin,gentamycin_no,gentamycin_srm,gemifloxacin,gemifloxacin_no,gemifloxacin_srm,neomycin,neomycin_no,neomycin_srm,nitrofurantion,nitrofurantion_no,nitrofurantion_srm,norfloxacine,norfloxacine_no,norfloxacine_srm,";
                                //strsql = strsql + "netromycin,netromycin_no,netromycin_srm,ofloxacin,ofloxacin_no,ofloxacin_srm,piperacillin,piperacillin_no,piperacillin_srm,pencillin,pencillin_no,pencillin_srm,streptomycin,streptomycin_no,streptomycin_srm,tetracycline,tetracycline_no,tetracycline_srm,";
                                strsql = strsql + "organism_isolated,colony_count,cu_imp,test) values ( '" + Convert.ToInt32(txtcompanycode.Text) + "','" + Convert.ToInt32(cbopcode.Text) + "','" + dgvculture.Rows[i].Cells[0].Value + "','" + dgvculture.Rows[i].Cells[1].Value + "','" + dgvculture.Rows[i].Cells[2].Value + "','" + Cu_Organism_isolated1.Text + "','" + cbocolonycount.Text + "','" + cul_imp.Text + "','" + cbons.Text + "')";
                                cmd = new SqlCommand(strsql, con);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    
                    //String strsql = "";
                    //strsql = "update Culture set cc='" + Convert.ToInt32(txtcompanycode.Text) + "',pcode='" + Convert.ToInt32(cbopcode.Text);
                    //strsql = strsql + "',Amoxicillin='" + Cu_Amoxicillin.Text + "',Amoxicillin_no='" + Cu_Amoxicillin_no.Text + "',Amoxicillin_srm='" + Cu_Amoxicillin_srm.Text + "',Ampicillin='" + Cu_Ampicillin.Text + "',Ampicillin_no='" + Cu_Ampicillin_no.Text + "',Ampicillin_srm='" + Cu_Ampicillin_srm.Text + "',Amikacin='" + Cu_Amikacin.Text + "',Amikacin_no='" + Cu_Amikacin_no.Text + "',Amikacin_srm='" + Cu_Amikacin_srm.Text + "',Cephalexin='" + Cu_Cephalexin.Text + "',Cephalexin_no='" + Cu_Cephalexin_no.Text + "',Cephalexin_srm='" + Cu_Cephalexin_srm.Text + "',Ceftazidime='" + Cu_Ceftazidime.Text + "',Ceftazidime_no='" + Cu_Ceftazidime_no.Text + "',Ceftazidime_srm='" + Cu_Ceftazidime_srm.Text + "',Ceftriaxone='" + Cu_Ceftriaxone.Text + "',Ceftriaxone_no='" + Cu_Ceftriaxone_no.Text + "',Ceftriaxone_srm='" + Cu_Ceftriaxone_srm.Text + "',Cloxacillin='" + Cu_Cloxacillin.Text + "',Cloxacillin_no='" + Cu_Cloxacillin_no.Text + "',Cloxacillin_srm='" + Cu_Cloxacillin_srm.Text + "',Co_trimoxazole='" + Cu_Co_trimoxazole.Text + "',Co_trimoxazole_no='" + Cu_Co_trimoxazole_no.Text + "',Co_trimoxazole_srm='" + Cu_Co_trimoxazole_srm.Text + "',Cefazolin='" + Cu_Cefazolin.Text + "',Cefazolin_no='" + Cu_Cefazolin_no.Text + "',Cefazolin_srm='" + Cu_Cefazolin_srm.Text + "',Cefotaxime='" + Cu_Cefotaxime.Text + "',Cefotaxime_no='" + Cu_Cefotaxime_no.Text + "',Cefotaxime_srm='" + Cu_Cefotaxime_srm.Text + "',Ciprofloxacin='" + Cu_Ciprofloxacin.Text + "',Ciprofloxacin_no='" + Cu_Ciprofloxacin_no.Text + "',Ciprofloxacin_srm='" + Cu_Ciprofloxacin_srm.Text + "',Doxycycline='" + Cu_Doxycycline.Text + "',Doxycycline_no='" + Cu_Doxycycline_no.Text + "',Doxycycline_srm='" + Cu_Doxycycline_srm.Text;
                    //strsql = strsql + "',Erythromycin='" + Cu_Erythromycin.Text + "',Erythromycin_no='" + Cu_Erythromycin_no.Text + "',Erythromycin_srm='" + Cu_Erythromycin_srm.Text + "',Gentamycin='" + Cu_Gentamycin.Text + "',Gentamycin_no='" + Cu_Gentamycin_no.Text + "',Gentamycin_srm='" + Cu_Gentamycin_srm.Text + "',Gemifloxacin='" + Cu_Gemifloxacin.Text + "',Gemifloxacin_no='" + Cu_Gemifloxacin_no.Text + "',Gemifloxacin_srm='" + Cu_Gemifloxacin_srm.Text + "',Neomycin='" + Cu_Neomycin.Text + "',Neomycin_no='" + Cu_Neomycin_no.Text + "',Neomycin_srm='" + Cu_Neomycin_srm.Text + "',Nitrofurantion='" + Cu_Nitrofurantion.Text + "',Nitrofurantion_no='" + Cu_Nitrofurantion_no.Text + "',Nitrofurantion_srm='" + Cu_Nitrofurantion_srm.Text + "',Norfloxacine='" + Cu_Norfloxacine.Text + "',Norfloxacine_no='" + Cu_Norfloxacine_no.Text + "',Norfloxacine_srm='" + Cu_Norfloxacine_srm.Text;
                    //strsql = strsql + "',Netromycin='" + Cu_Netromycin.Text + "',Netromycin_no='" + Cu_Netromycin_no.Text + "',Netromycin_srm='" + Cu_Netromycin_srm.Text + "',Ofloxacin='" + Cu_Ofloxacin.Text + "',Ofloxacin_no='" + Cu_Ofloxacin_no.Text + "',Ofloxacin_srm='" + Cu_Ofloxacin_srm.Text + "',Piperacillin='" + Cu_Piperacillin.Text + "',Piperacillin_no='" + Cu_Piperacillin_no.Text + "',Piperacillin_srm='" + Cu_Piperacillin_srm.Text + "',Pencillin='" + Cu_Pencillin.Text + "',Pencillin_no='" + Cu_Pencillin_no.Text + "',Pencillin_srm='" + Cu_Pencillin_srm.Text + "',Streptomycin='" + Cu_Streptomycin.Text + "',Streptomycin_no='" + Cu_Streptomycin_no.Text + "',Streptomycin_srm='" + Cu_Streptomycin_srm.Text + "',Tetracycline='" + Cu_Tetracycline.Text + "',Tetracycline_no='" + Cu_Tetracycline_no.Text + "',Tetracycline_srm='" + Cu_Tetracycline_srm.Text;
                    //strsql = strsql + "',Roxythromycin='" + Cu_Roxythromycin.Text + "',Roxythromycin_no='" + Cu_Roxythromycin_no.Text + "',Roxythromycin_srm='" + Cu_Roxythromycin_srm.Text + "',Cefoperazone='" + Cu_Cefoperazone.Text + "',Cefoperazone_no='" + Cu_Cefoperazone_no.Text + "',Cefoperazone_srm='" + Cu_Cefoperazone_srm.Text + "',Levofloxacin='" + Cu_Levofloxacin.Text + "',Levofloxacin_no='" + Cu_Levofloxacin_no.Text + "',Levofloxacin_srm='" + Cu_Levofloxacin_srm.Text + "',Gatifloxacin='" + Cu_Gatifloxacin.Text + "',Gatifloxacin_no='" + Cu_Gatifloxacin_no.Text + "',Gatifloxacin_srm='" + Cu_Gatifloxacin_srm.Text + "',Tazobactum='" + Cu_Tazobactum.Text + "',Tazobactum_no='" + Cu_Tazobactum_no.Text + "',Tazobactum_srm='" + Cu_Tazobactum_srm.Text + "',Tobramycin='" + Cu_Tobramycin.Text + "',Tobramycin_no='" + Cu_Tobramycin_no.Text + "',Tobramycin_srm='" + Cu_Tobramycin_srm.Text + "',Cefixime='" + Cu_Cefixime.Text + "',Cefixime_no='" + Cu_Cefixime_no.Text + "',Cefixime_srm='" + Cu_Cefixime_srm.Text + "',Organism_isolated='" + Cu_Organism_isolated.Text+"',cu_imp='"+cul_imp.Text ;

                    //strsql = strsql + "' where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
                    //cmd = new SqlCommand(strsql, con);
                    //cmd.ExecuteNonQuery();
                    strsql = "";
                }

            }
        }

        private void btnprintculture_Click(object sender, EventArgs e)
        {
            //Frmrepculture FRC = new Frmrepculture();
            //FRC.Show();
            Frmrepculturedgv FRC = new Frmrepculturedgv();
            FRC.Show();
        }

        private void btnsavehormone_Click(object sender, EventArgs e)
        {




            con.Close();
            con.Open();

            if (MessageBox.Show("Save ? ", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                String strsql5 = "";

                strsql5 = strsql5 + "select cc,pcode,TOTAL_TRIIODOTHYRONINE_T3,TOTAL_THYROXINE_T4,TSH,FREE_TRIIODOTHYRONINE_FT3,FREE_THYROXINE_FT4,ANTIMICROSOMAL_ANTIBODY_AMA,TOTAL_CHOLESTEROL,PROLACTIN_PRL,PROSTATESPECIFICANTIGEN_PSA,ADENOSINE_DEAMINASE,ANTITUBERCULOSIS_TB_IgG,ANTITUBERCULOSIS_TB_IgM,ANTITUBERCULOSIS_TB_IgA,BHCG,CA_125,ANA,hm_imp";
                strsql5 = strsql5 + " from Hormone where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";

                 da = new SqlDataAdapter(strsql5, con);
                ds5 = new DataSet();
                da.Fill(ds5);
                if (ds5.Tables[0].Rows.Count == 0)
                {
                    String strsql = "";
                     strsql = "insert into Hormone (cc,pcode,TOTAL_TRIIODOTHYRONINE_T3,TOTAL_THYROXINE_T4,TSH,FREE_TRIIODOTHYRONINE_FT3,FREE_THYROXINE_FT4,ANTIMICROSOMAL_ANTIBODY_AMA,TOTAL_CHOLESTEROL,PROLACTIN_PRL,PROSTATESPECIFICANTIGEN_PSA,ADENOSINE_DEAMINASE,ANTITUBERCULOSIS_TB_IgG,ANTITUBERCULOSIS_TB_IgM,ANTITUBERCULOSIS_TB_IgA,BHCG,CA_125,ANA,hm_imp ) values ( '" + Convert.ToInt32(txtcompanycode.Text) + "','" + Convert.ToInt32(cbopcode.Text);

                    strsql = strsql + "', '" + TOTAL_TRIIODOTHYRONINE_T3.Text + "','" + TOTAL_THYROXINE_T4.Text + "'  ,'" + TSH.Text + "' , '" + FREE_TRIIODOTHYRONINE_FT3.Text;
                    strsql = strsql + "','" + FREE_THYROXINE_FT4.Text + "','" + ANTIMICROSOMAL_ANTIBODY_AMA.Text + "'  ,'" + TOTAL_CHOLESTEROL.Text + "',   '" + PROLACTIN_PRL.Text;
                    strsql = strsql + "','" + PROSTATESPECIFICANTIGEN_PSA.Text + "', '" + ADENOSINE_DEAMINASE.Text + "'  ,  '" + ANTITUBERCULOSIS_TB_IgG.Text;
                    strsql = strsql + "','" + ANTITUBERCULOSIS_TB_IgM.Text + "','" + ANTITUBERCULOSIS_TB_IgA.Text + "','" + BHCG.Text;
                    strsql = strsql + "', '" + CA_125.Text + "','" + ANA.Text + "','" + hm_imp.Text + "')";

                    cmd = new SqlCommand(strsql, con);
                    cmd.ExecuteNonQuery();
                    strsql = "";
                }
                else
                {
                    String strsql = "";
                    strsql = "update Hormone set cc='" + Convert.ToInt32(txtcompanycode.Text) + "',pcode='" + Convert.ToInt32(cbopcode.Text);
                    strsql = strsql + "',TOTAL_TRIIODOTHYRONINE_T3= '" + TOTAL_TRIIODOTHYRONINE_T3.Text + "',TOTAL_THYROXINE_T4='" + TOTAL_THYROXINE_T4.Text + "'  ,TSH='" + TSH.Text + "' , FREE_TRIIODOTHYRONINE_FT3='" + FREE_TRIIODOTHYRONINE_FT3.Text;
                    strsql = strsql + "',FREE_THYROXINE_FT4='" + FREE_THYROXINE_FT4.Text + "',ANTIMICROSOMAL_ANTIBODY_AMA='" + ANTIMICROSOMAL_ANTIBODY_AMA.Text + "'  , TOTAL_CHOLESTEROL='" + TOTAL_CHOLESTEROL.Text + "', PROLACTIN_PRL=  '" + PROLACTIN_PRL.Text;
                    strsql = strsql + "',PROSTATESPECIFICANTIGEN_PSA='" + PROSTATESPECIFICANTIGEN_PSA.Text + "',ADENOSINE_DEAMINASE= '" + ADENOSINE_DEAMINASE.Text + "'  , ANTITUBERCULOSIS_TB_IgG= '" + ANTITUBERCULOSIS_TB_IgG.Text;
                    strsql = strsql + "',ANTITUBERCULOSIS_TB_IgM='" + ANTITUBERCULOSIS_TB_IgM.Text + "',ANTITUBERCULOSIS_TB_IgA='" + ANTITUBERCULOSIS_TB_IgA.Text + "',BHCG='" + BHCG.Text;
                    strsql = strsql + "', CA_125='" + CA_125.Text + "',ANA='" + ANA.Text+"',hm_imp='"+hm_imp .Text ;

                    strsql = strsql + "' where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
                    cmd = new SqlCommand(strsql, con);
                    cmd.ExecuteNonQuery();
                    strsql = "";
                
                
                }
                String Sqlstr = "";
                Sqlstr = "delete from hormoneext where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
                cmd = new SqlCommand(Sqlstr, con);
                cmd.ExecuteNonQuery();
                Sqlstr = "";
                for (int i = 0; i < dgvhormonenew.Rows.Count; i++)
                {

                    if (dgvhormonenew.Rows[i].Cells[0].Value != null)
                    {

                        Sqlstr = "insert into hormoneext (pcode,test,method,result,unit,normal_range) values ('" + Convert.ToInt32(cbopcode.Text) + "','" + dgvhormonenew.Rows[i].Cells[0].Value + "','" + dgvhormonenew.Rows[i].Cells[1].Value + "','" + dgvhormonenew.Rows[i].Cells[2].Value + "','" + dgvhormonenew.Rows[i].Cells[3].Value + "','" + dgvhormonenew.Rows[i].Cells[4].Value + "')";
                        cmd = new SqlCommand(Sqlstr, con);
                        cmd.ExecuteNonQuery();
                        Sqlstr = "";
                    }
                }


            }

        }

        private void SBS_trop_TextChanged(object sender, EventArgs e)
        {

        }

        private void btndeleteculture_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("delete from cultureext where cc='" + txtcompanycode.Text + "' and  pcode='" + Convert.ToInt32(cbopcode.Text) + "'");
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Deleted");

        }

        private void btndeletehormone_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("delete from hormone where cc='" + txtcompanycode.Text + "' and  pcode='" + Convert.ToInt32(cbopcode.Text) + "'");
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Deleted");
        }

        private void btnprinthormone_Click(object sender, EventArgs e)
        {
            Frmrephormone frh = new Frmrephormone();
            frh.Show();
        }

        private void Bc1_fbs_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bc1_ppbs2_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bc1_ppbs1_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bc2_fbs_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bc2_ppbs2_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bc2_ppbs1_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bc2_urea_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bc2_creatinine_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bc2_uric_acid_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bc3_fbs_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bc3_ppbs2_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bc3_ppbs1_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bc3_urea_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bc3_creatinine_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bc3_uric_acid_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bc3_triglyceride_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bc3_cholesterol_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bc3_hdl_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bc3_ldl_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void Bc3_vldl_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void BDc_Tnc_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void BDCmch_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void BDCmchc_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void BDCmcv_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void FA_MT_Totalcount_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void FA_MT_Active_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void FA_MT_Slugish_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void FA_MT_Dead_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void FA_MP_Puscells_KeyPress(object sender, KeyPressEventArgs e)
        {
            //callnumber(e);
        }

        private void FA_MP_Epithcells_KeyPress(object sender, KeyPressEventArgs e)
        {
            // callnumber(e);
        }

        private void FA_MP_RBC_KeyPress(object sender, KeyPressEventArgs e)
        {
            // callnumber(e);
        }

        private void FA_MP_Deformed_KeyPress(object sender, KeyPressEventArgs e)
        {
            //callnumber(e);
        }

        private void TOTAL_TRIIODOTHYRONINE_T3_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void TOTAL_THYROXINE_T4_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void TSH_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void FREE_TRIIODOTHYRONINE_FT3_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void FREE_THYROXINE_FT4_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void ANTIMICROSOMAL_ANTIBODY_AMA_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void TOTAL_CHOLESTEROL_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void PROLACTIN_PRL_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void PROSTATESPECIFICANTIGEN_PSA_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void ADENOSINE_DEAMINASE_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void ANTITUBERCULOSIS_TB_IgG_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void ANTITUBERCULOSIS_TB_IgM_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void ANTITUBERCULOSIS_TB_IgA_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void BHCG_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void CA_125_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void ANA_KeyPress(object sender, KeyPressEventArgs e)
        {
            callnumber(e);
        }

        private void btnclosecrv_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.Visible = false;
            btnclosecrv.Visible = false;
        }

        private void btnclosestoolcrv_Click(object sender, EventArgs e)
        {
            st_imp1.Visible = false;
            btnclosestoolcrv.Visible = false;
            crystalReportViewer2.Visible = false;
        }

        private void btnclosebloodcrv_Click(object sender, EventArgs e)
        {
            crystalReportViewer3.Visible = false;
            btnclosebloodcrv.Visible = false;


        }

        private void dataGridView1_Leave(object sender, EventArgs e)
        {
            dataGridView1.Hide();
        }

        
        private void btnsavect_Click(object sender, EventArgs e)
        {
            String Sqlstr0 = "";
            String Sqlstr = "";
            con.Close();
            con.Open();

            if (MessageBox.Show("Save ? ", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                String strsql2 = "";
                strsql2 = "select cc,pcode,Specimen,Benign_Cell,Endocervical_Cell,Inflammatory_Cell,Trichomonas,Monilia,Endometrial_Cell,Spermatozoa,Rbc,Dysplastic_Cell,Malignant_Cell,Others";
                strsql2 = strsql2 + " from Cytology where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
                da = new SqlDataAdapter(strsql2, con);
                ds2 = new DataSet();
                da.Fill(ds2);


                if (ds2.Tables[0].Rows.Count == 0)
                {
                    Sqlstr0 = "insert into Cytology (cc,pcode,Specimen,Benign_Cell,Endocervical_Cell,Inflammatory_Cell,Trichomonas,Monilia,Endometrial_Cell,Spermatozoa,Rbc,Dysplastic_Cell,Malignant_Cell,Others,Impression ) values('" + Convert.ToInt32(txtcompanycode.Text) + "','" + Convert.ToInt32(cbopcode.Text);

                    Sqlstr0 = Sqlstr0 + "','" + CtSpecimen.Text;
                    Sqlstr0 = Sqlstr0 + "','" + CtBenign_Cell.Text + "','" + CtEndocervical_Cell.Text;
                    Sqlstr0 = Sqlstr0 + "','" + CtInflammatory_Cell.Text + "','" + CtTrichomonas.Text;
                    Sqlstr0 = Sqlstr0 + "','" + CtMonilia.Text + "','" + CtEndometrial_Cell.Text;
                    Sqlstr0 = Sqlstr0 + "','" + CtSpermatozoa.Text + "','" + CtRbc.Text;
                    Sqlstr0 = Sqlstr0 + "','" + CtDysplastic_Cell.Text + "','" + CtMalignant_Cell.Text;
                    Sqlstr0 = Sqlstr0 + "','" + CtOthers.Text + "','" + Ctimp.Text + "')";

                    cmd = new SqlCommand(Sqlstr0, con);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    Sqlstr = "";
                    Sqlstr = "update Cytology set cc='" + Convert.ToInt32(txtcompanycode.Text) + "',pcode='" + Convert.ToInt32(cbopcode.Text);
                    Sqlstr = Sqlstr + "',Specimen='" + CtSpecimen.Text;
                    Sqlstr = Sqlstr + "',Benign_Cell='" + CtBenign_Cell.Text + "',Endocervical_Cell='" + CtEndocervical_Cell.Text;
                    Sqlstr = Sqlstr + "',Inflammatory_Cell='" + CtInflammatory_Cell.Text + "',Trichomonas='" + CtTrichomonas.Text;
                    Sqlstr = Sqlstr + "',Monilia='" + CtMonilia.Text + "',Endometrial_Cell='" + CtEndometrial_Cell.Text;
                    Sqlstr = Sqlstr + "',Spermatozoa='" + CtSpermatozoa.Text + "',Rbc='" + CtRbc.Text;
                    Sqlstr = Sqlstr + "',Dysplastic_Cell='" + CtDysplastic_Cell.Text + "',Malignant_Cell='" + CtMalignant_Cell.Text;
                    Sqlstr = Sqlstr + "',Others='" + CtOthers.Text + "',Impression='" + Ctimp.Text;

                    Sqlstr = Sqlstr + "'  where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
                    cmd = new SqlCommand(Sqlstr, con);
                    cmd.ExecuteNonQuery();
                }
                Sqlstr0 = "";
                Sqlstr = "";

            }
        }

   
        private void btnsavebf_Click(object sender, EventArgs e)
        {
            String Sqlstr0 = "";
            String Sqlstr = "";
            con.Close();
            con.Open();

            if (MessageBox.Show("Save ? ", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                String strsql2 = "";
                strsql2 = "select cc,pcode,Specimen,Qty,Appearance,Color,ClotFormation,Sugar,Microprotein,Neutrophil,Lymphocyte,Total_cell_count,Rbc,Malignant_Cell,Impression";
                strsql2 = strsql2 + " from Body_fluid_analysis where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
                da = new SqlDataAdapter(strsql2, con);
                ds2 = new DataSet();
                da.Fill(ds2);


                if (ds2.Tables[0].Rows.Count == 0)
                {
                    Sqlstr0 = "insert into Body_fluid_analysis (cc,pcode,Specimen,Qty,Appearance,Color,ClotFormation,Sugar,Microprotein,Neutrophil,Lymphocyte,Total_cell_count,Rbc,Malignant_Cell,Impression,abnormal_cell ) values('" + Convert.ToInt32(txtcompanycode.Text) + "','" + Convert.ToInt32(cbopcode.Text);

                    Sqlstr0 = Sqlstr0 + "','" + BfSpecimen.Text;
                    Sqlstr0 = Sqlstr0 + "','" + BfQty.Text + "','" + BfAppearance.Text;
                    Sqlstr0 = Sqlstr0 + "','" + BfColor.Text + "','" + BfClotFormation.Text;
                    Sqlstr0 = Sqlstr0 + "','" + BfSugar.Text + "','" + BfMicroprotein.Text;
                    Sqlstr0 = Sqlstr0 + "','" + BfNeutrophil.Text + "','" + BfLymphocyte.Text;
                    Sqlstr0 = Sqlstr0 + "','" + BfTotal_cell_count.Text + "','" + BfRbc.Text;
                    Sqlstr0 = Sqlstr0 + "','" + BfMalignant_Cell.Text + "','" + BfImpression.Text + "','"+BfAbnormal_Cell.Text +"')";

                    cmd = new SqlCommand(Sqlstr0, con);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    Sqlstr = "";
                    Sqlstr = "update Body_fluid_analysis set cc='" + Convert.ToInt32(txtcompanycode.Text) + "',pcode='" + Convert.ToInt32(cbopcode.Text);
                    Sqlstr = Sqlstr + "',Specimen='" + BfSpecimen.Text;
                    Sqlstr = Sqlstr + "',Qty='" + BfQty.Text + "',Appearance='" + BfAppearance.Text;
                    Sqlstr = Sqlstr + "',Color='" + BfColor.Text + "',ClotFormation='" + BfClotFormation.Text;
                    Sqlstr = Sqlstr + "',Sugar='" + BfSugar.Text + "',Microprotein='" + BfMicroprotein.Text;
                    Sqlstr = Sqlstr + "',Neutrophil='" + BfNeutrophil.Text + "',Lymphocyte='" + BfLymphocyte.Text;
                    Sqlstr = Sqlstr + "',Total_cell_count='" + BfTotal_cell_count.Text + "',Rbc='" + BfRbc.Text;
                    Sqlstr = Sqlstr + "',Malignant_Cell='" + BfMalignant_Cell.Text + "',abnormal_cell='" + BfAbnormal_Cell.Text + "',Impression='" + BfImpression.Text;

                    Sqlstr = Sqlstr + "'  where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
                    cmd = new SqlCommand(Sqlstr, con);
                    cmd.ExecuteNonQuery();
                }
                Sqlstr0 = "";
                Sqlstr = "";

            }


        }

        private void btncancelbf_Click(object sender, EventArgs e)
        {

        }

        private void btndeletebf_Click(object sender, EventArgs e)
        {

        }

        private void btnprintbf_Click(object sender, EventArgs e)
        {
            Frmrepbodyfluid frbf = new Frmrepbodyfluid();
            frbf.Show();
        }

        private void Frmresultentry_KeyDown(object sender, KeyEventArgs e)
        {
            Control nextControl;
            if (e.KeyCode == Keys.Enter)
            {
                nextControl = GetNextControl(ActiveControl, !e.Shift);
                if (nextControl == null)
                     nextControl = GetNextControl(null, true);
                nextControl.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void btnresave_Click(object sender, EventArgs e)
        {
           
        }

        private void tbroutine_Click(object sender, EventArgs e)
        {

        }

        private void btnrecancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
                
        private void btnreprint_Click(object sender, EventArgs e)
        {
         
        }
        private void btncloseroutine_Click(object sender, EventArgs e)
        {
            //crystalReportViewer4.Visible = false;
            //btncloseroutine.Visible = false;
        }

        private void BDc_Basophils_Validating(object sender, CancelEventArgs e)
        {
            int neu = Convert.ToInt32(BDc_Neutrophild.Text);
            int lymp = Convert.ToInt32(BDc_Lymphocytes.Text);
            int eos = Convert.ToInt32(BDc_Eosinophils.Text);
            int mon = Convert.ToInt32(BDc_Monocytes.Text);
            int baso = Convert.ToInt32(BDc_Basophils.Text);
            int TDC = neu + lymp + eos + mon + baso;
            int tdcb = 100 - TDC;
            dctot();
            if (neu + lymp + eos + mon + baso != 0)
            {
                if (neu + lymp + eos + mon + baso != 100)
                {
                    //dctot();
                    labelbas.Text = tdcb.ToString();
                    //MessageBox.Show("Balance  = " + tdcb);
                    //BDc_Neutrophild.Focus();
                }
            }

        }

        private void RE_Basophils_Validating(object sender, CancelEventArgs e)
        {
            //int neu = Convert.ToInt32(RE_Neutrophild.Text);
            //int lymp = Convert.ToInt32(RE_Lymphocytes.Text);
            //int eos = Convert.ToInt32(RE_Eosinophils.Text);
            //int mon = Convert.ToInt32(RE_Monocytes.Text);
            //int baso = Convert.ToInt32(RE_Basophils.Text);
            //int TDC = neu + lymp + eos + mon + baso;
            //if (neu + lymp + eos + mon + baso != 100)
            //{
            //    MessageBox.Show("DC = " + TDC);
            //    RE_Neutrophild.Focus();
            //}
        }

        
        

        
        

        private void btnbill1_Click(object sender, EventArgs e)
        {

            
        }

      
   
        private void btnbloodnewtest_Click(object sender, EventArgs e)
        {
            dgvbloodnewtest.Visible = true;

            dgvbloodnewtest.Show();
            dgvbloodnewtest.Rows.Clear();
            
            da = new SqlDataAdapter("select test,method,result,unit,normal_range from bloodext where pcode='" + cbopcode.Text.Trim() + "' order by test ", con);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dgvbloodnewtest.Rows.Add();
                    dgvbloodnewtest.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][0].ToString();
                    dgvbloodnewtest.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][1].ToString();
                    dgvbloodnewtest.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][2].ToString();
                    dgvbloodnewtest.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][3].ToString();
                    dgvbloodnewtest.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][4].ToString();

                   
                }

                
            }
              



        }

        private void btnbiochemext_Click(object sender, EventArgs e)
        {
            dgvbiochemext.Visible = true;

            dgvbiochemext.Show();
            dgvbiochemext.Rows.Clear();
           
            da = new SqlDataAdapter("select test,method,result,unit,normal_range from Biochemistext where pcode='" + cbopcode.Text.Trim() + "' order by test ", con);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dgvbiochemext.Rows.Add();
                    dgvbiochemext.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][0].ToString();
                    dgvbiochemext.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][1].ToString();
                    dgvbiochemext.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][2].ToString();
                    dgvbiochemext.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][3].ToString();
                    dgvbiochemext.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][4].ToString();
                    

                }

                
            }
        }

        private void dgvbloodnewtest_Leave(object sender, EventArgs e)
        {
            dgvbloodnewtest.Hide ();
        }

        private void dgvbiochemext_Leave(object sender, EventArgs e)
        {
            dgvbiochemext.Hide();
        }

        private void dgvbloodnewtest_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            da = new SqlDataAdapter("select test,method,unit,reference_range from test_master where test='" + dgvbloodnewtest.CurrentRow.Cells[0].Value + "'", con);
            ds = new DataSet();
            da.Fill(ds, "test_master");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    dgvbloodnewtest.Rows.Add();
                    dgvbloodnewtest.CurrentRow.Cells[1].Value = ds.Tables[0].Rows[0][1].ToString();
                    dgvbloodnewtest.CurrentRow.Cells[3].Value = ds.Tables[0].Rows[0][2].ToString();
                    dgvbloodnewtest.CurrentRow.Cells[4].Value = ds.Tables[0].Rows[0][3].ToString();
                }
            }
        }

        private void dgvbiochemext_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            da = new SqlDataAdapter("select test,method,unit,reference_range from test_master where test='" + dgvbiochemext.CurrentRow.Cells[0].Value + "'", con);
            ds = new DataSet();
            da.Fill(ds, "test_master");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    dgvbiochemext.Rows.Add();
                    dgvbiochemext.CurrentRow.Cells[0].Value = ds.Tables[0].Rows[0][0].ToString();
                    dgvbiochemext.CurrentRow.Cells[1].Value = ds.Tables[0].Rows[0][1].ToString();
                    dgvbiochemext.CurrentRow.Cells[3].Value = ds.Tables[0].Rows[0][2].ToString();
                    dgvbiochemext.CurrentRow.Cells[4].Value = ds.Tables[0].Rows[0][3].ToString();
                }
            }
        }

        
        
        
        private void cboname_Leave(object sender, EventArgs e)
        {
            cboname.Text = cboname.Text.ToUpper();
        }

        private void btnsaveos_Click(object sender, EventArgs e)
        {
            String Sqlstr = "";
            Sqlstr = "delete from outsource where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
            cmd = new SqlCommand(Sqlstr, con);
            cmd.ExecuteNonQuery();
            Sqlstr = "";
            for (int i = 0; i < dgvos.Rows.Count; i++)
            {
                if (dgvos.Rows[i].Cells[0].Value != null)
                {
                    //dgvbiochemext.Rows.Add();
                    Sqlstr = "insert into outsource (pcode,test,method,result,unit,normal_range) values ('" + Convert.ToInt32(cbopcode.Text) + "','" + dgvos.Rows[i].Cells[0].Value + "','" + dgvos.Rows[i].Cells[1].Value + "','" + dgvos.Rows[i].Cells[2].Value + "','" + dgvos.Rows[i].Cells[3].Value + "','" + dgvos.Rows[i].Cells[4].Value + "')";
                    cmd = new SqlCommand(Sqlstr, con);
                    cmd.ExecuteNonQuery();
                    Sqlstr = "";
                }
            }
        }

        private void btncancelos_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btndelos_Click(object sender, EventArgs e)
        {
            String Sqlstr = "";
            Sqlstr = "delete from outsource where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
            cmd = new SqlCommand(Sqlstr, con);
            cmd.ExecuteNonQuery();
        }

        private void btnprintos_Click(object sender, EventArgs e)
        {
            Frmoutsource fouts = new Frmoutsource();
            fouts.Show();
        }

        private void dgvos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            da = new SqlDataAdapter("select test,method,unit,reference_range from test_master where test='" + dgvos.CurrentRow.Cells[0].Value + "'", con);
            ds = new DataSet();
            da.Fill(ds, "test_master");
            if (ds.Tables[0].Rows.Count > 0)
            {

                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    dgvos.Rows.Add();
                    dgvos.CurrentRow.Cells[1].Value = ds.Tables[0].Rows[0][1].ToString();
                    dgvos.CurrentRow.Cells[3].Value = ds.Tables[0].Rows[0][2].ToString();
                    dgvos.CurrentRow.Cells[4].Value = ds.Tables[0].Rows[0][3].ToString();
                }
            }
        }

        private void btnsavehisto_Click(object sender, EventArgs e)
        {
            String Sqlstr0 = "";
            String Sqlstr = "";
            con.Close();
            con.Open();

            if (MessageBox.Show("Save ? ", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                String strsql2 = "";
                strsql2 = "select cc,pcode,Specimen,gross_exam,microscopic,impression";
                strsql2 = strsql2 + " from histopathology where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
                da = new SqlDataAdapter(strsql2, con);
                ds2 = new DataSet();
                da.Fill(ds2);


                if (ds2.Tables[0].Rows.Count == 0)
                {
                    Sqlstr0 = "insert into histopathology (cc,pcode,Specimen,gross_exam,microscopic,impression ) values('" + Convert.ToInt32(txtcompanycode.Text) + "','" + Convert.ToInt32(cbopcode.Text);

                    Sqlstr0 = Sqlstr0 + "','" + txthisto.Text;
                    Sqlstr0 = Sqlstr0 + "','" + txtgexam.Text + "','" + txtmicro.Text;
 
                    Sqlstr0 = Sqlstr0 + "','" + txtimpresion.Text + "')";

                    cmd = new SqlCommand(Sqlstr0, con);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    Sqlstr = "";
                    Sqlstr = "update histopathology set cc='" + Convert.ToInt32(txtcompanycode.Text) + "',pcode='" + Convert.ToInt32(cbopcode.Text);
                    Sqlstr = Sqlstr + "',Specimen='" + txthisto.Text;
                    Sqlstr = Sqlstr + "',gross_exam='" + txtgexam.Text + "',microscopic='" + txtmicro.Text;
         
                    Sqlstr = Sqlstr + "',Impression='" + txtimpresion.Text;

                    Sqlstr = Sqlstr + "'  where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
                    cmd = new SqlCommand(Sqlstr, con);
                    cmd.ExecuteNonQuery();
                }
                Sqlstr0 = "";
                Sqlstr = "";

            }
        }

        private void btncancelhisto_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnprinthisto_Click(object sender, EventArgs e)
        {
            Frmrephisto FRHIST = new Frmrephisto();
            FRHIST.Show();
        }

        private void btndeletehisto_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("delete from histopathology where cc='" + txtcompanycode.Text + "' and  pcode='" + Convert.ToInt32(cbopcode.Text) + "'");
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Deleted");
        }

        private void btnsaveserology2_Click(object sender, EventArgs e)
        {
            String Sqlstr = "";
            con.Close();
            con.Open();

            if (MessageBox.Show("Save ? ", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                String strsql4 = "";
                strsql4 = "select cc,pcode,BG_Blood_Group,BR_RhD_Typing,BDc_Neutrophild,BDc_Eosinophils,BDc_Lymphocytes,";
                strsql4 = strsql4 + "BDc_Basophils,BDc_Monocytes,BDc_Twbc,BDc_Trbc,BDc_Tplatelets,BDc_Aec,BDc_Tnc,BDc_Reticulocyte_Count,";
                strsql4 = strsql4 + "BDc_PCV,BDC_mcv,BDC_mch,BDC_mchc,BDc_Pss,BDc_Mp_ICT_QBC_Smear,BDc_Mp_ICT,BDc_Mf_ICT_QBC_Smear,BDc_Mf_ICT,BDc_Rct,BDc_Hb,BDc_ESR_1sthour,";
                strsql4 = strsql4 + "BDc_Bleeding_Time,BDc_Clotting_Time,BDC_nasalsmear,BDC_nasalsmear_right,BDc_Sickle_cell,BDC_prothombintime,BDC_prothombintime_cont,BPS_Toxo,BPS_Crp,BPS_Vdrl,BPS_Ana,";
                strsql4 = strsql4 + "BPS_Rafactor,BPS_Aso,BS_Australia_Antigen,BS_Hepatitis_C_Virus,BS_HIV_1,BS_HIV_2,";


                strsql4 = strsql4 + "Bw_Widaltubeo80,Bw_Widaltubeo160,Bw_Widaltubeo320,Bw_Widaltubeo240,Bw_Widaltubeo480,Bw_Widaltubeh80,Bw_Widaltubeh160,Bw_Widaltubeh320,Bw_Widaltubeh240,Bw_Widaltubeh480,Bw_Widaltubeah80,Bw_Widaltubeah160,Bw_Widaltubeah320,Bw_Widaltubeah240,Bw_Widaltubeah480,Bw_Widaltubebh80,Bw_Widaltubebh160,Bw_Widaltubebh320,Bw_Widaltubebh240,Bw_Widaltubebh480,Bw_Widalslide1,Bw_Widalslide2,Bw_Widalslide3,Bw_Widalslide4,Bw_mycodot,bw_trop,Bm_MontouxTest_injon,Bm_MontouxTest_readon,Bm_MontouxTest_induration,BDc_ESR_2ndhour,BDC_prothombintime_inr,BDc_Dengue,BDc_typhicheck,BDc_Dengue_NSI,ser_imp";
                strsql4 = strsql4 + " from Blood where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";

                da = new SqlDataAdapter(strsql4, con);


                ds4 = new DataSet();
                da.Fill(ds4);


                if (ds4.Tables[0].Rows.Count == 0)
                {

 
                    Sqlstr = "insert into Blood ( cc,pcode,sr_afp,SR_ASA,SR_CV_IGG,SR_CV_IGM,SR_HSV_IGG,SR_HSV_IGM,SR_RV_IGG,";
                    Sqlstr = Sqlstr + "SR_RV_IGM,SR_HBSA,SR_AHBSAT,SR_HBEA,SR_AHBEAT,SR_AHBCA_IGM,SR_AHBCAT,SR_AHAV_IGM,SR_AHAVT,";
                    Sqlstr = Sqlstr + "SR_AHCVT,SR_AHEV_IGM,sr_hp_igg,sr_hp_igm,sr_hp_iga,ser_imp) values ('" + Convert.ToInt32(txtcompanycode.Text) + "','" + Convert.ToInt32(cbopcode.Text);

                    Sqlstr = Sqlstr + "','" + srt_afp.Text + "','" + SRT_ASA.Text;
                    Sqlstr = Sqlstr + "' ,'" + SRT_CV_IGG.Text + "','" + SRT_CV_IGM.Text;
                    Sqlstr = Sqlstr + "','" + SRT_HSV_IGG.Text + "','" + SRT_HSV_IGM.Text;
                    Sqlstr = Sqlstr + "','" + SRT_RV_IGG.Text + "','" + SRT_RV_IGM.Text;
                    Sqlstr = Sqlstr + "','" + SRT_HBSA.Text + "','" + SRT_AHBSAT.Text;
                    Sqlstr = Sqlstr + "','" + SRT_HBEA.Text + "','" + SRT_AHBEAT.Text + "','" + SRT_AHBCA_IGM.Text + "','" + SRT_AHBCAT.Text + "','" + SRT_AHAV_IGM.Text;
                    Sqlstr = Sqlstr + "','" + SRT_AHAVT.Text + "','" + SRT_AHCVT.Text;
                    Sqlstr = Sqlstr + "','" + SRT_AHEV_IGM.Text + "','" + srt_hp_igg.Text + "','" + srt_hp_igm.Text + "','" + srt_hp_iga.Text + "','" + SER_IMP2.Text + "')";
 
                }
                else
                {

                    Sqlstr = "update blood set cc='" + Convert.ToInt32(txtcompanycode.Text) + "',pcode='" + Convert.ToInt32(cbopcode.Text);
                 
                    Sqlstr = Sqlstr + "',sr_afp='" + srt_afp.Text + "',SR_ASA='" + SRT_ASA.Text;
                    Sqlstr = Sqlstr + "',SR_CV_IGG='" + SRT_CV_IGG.Text + "',SR_CV_IGM='" + SRT_CV_IGM.Text;
                    Sqlstr = Sqlstr + "',SR_HSV_IGG='" + SRT_HSV_IGG.Text + "',SR_HSV_IGM='" + SRT_HSV_IGM.Text;
                    Sqlstr = Sqlstr + "', SR_RV_IGG='" + SRT_RV_IGG.Text + "',SR_RV_IGM='" + SRT_RV_IGM.Text;
                                       
                                      
                    Sqlstr = Sqlstr + "',SR_HBSA='" + SRT_HBSA.Text + "',SR_AHBSAT='" + SRT_AHBSAT.Text;
                    Sqlstr = Sqlstr + "',SR_HBEA='" + SRT_HBEA.Text + "',SR_AHBEAT='" + SRT_AHBEAT.Text + "',SR_AHBCA_IGM='" + SRT_AHBCA_IGM.Text + "',SR_AHBCAT='" + SRT_AHBCAT.Text + "',SR_AHAV_IGM='" + SRT_AHAV_IGM.Text;
                    Sqlstr = Sqlstr + "',SR_AHAVT='" + SRT_AHAVT.Text + "',SR_AHCVT='" + SRT_AHCVT.Text + "',SR_AHEV_IGM='" + SRT_AHEV_IGM.Text + "',sr_hp_igg='" + srt_hp_igg.Text + "',sr_hp_igm='" + srt_hp_igm.Text;
                    Sqlstr = Sqlstr + "',sr_hp_iga='" + srt_hp_iga.Text + "',ser_imp='" + SER_IMP2.Text;
                     Sqlstr = Sqlstr + "' where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";

                }
                cmd = new SqlCommand(Sqlstr, con);
                cmd.ExecuteNonQuery();
                Sqlstr = "";
            }
        }

        private void cbodoctor_Leave(object sender, EventArgs e)
        {
            cbodoctor.Text = cbodoctor.Text.ToUpper();
        }

        private void btnrutinenew_Click(object sender, EventArgs e)
        {
        }

        private void dgvrutinenewext_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgvrutinenewext_Leave(object sender, EventArgs e)
        {
            //dgvrutinenewext.Hide();
        }

        private void btnsaveprofileresult_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            dd = dtreport.Text.Substring(0, 2).ToString();
            mm = this.dtreport.Text.Substring(3, 2).ToString();
            yy = this.dtreport.Text.Substring(6, 4).ToString();
            repdt1 = DateTime.ParseExact(dd + "/" + mm + "/" + yy, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);


            cmd1 = new SqlCommand("delete from profile_data where type='" + cboprofilename.Text + "' and pcode='" + cbopcode.Text + "'", con);

            cmd1.ExecuteNonQuery();

            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                con.Close();
                con.Open();

                if (dataGridView2.Rows[i].Cells[0].Value != null)
                {

                    cmd = new SqlCommand("insert into profile_data(test,method,result,unit,reference_range,grp,sgrp,type,pcode,grp_code,srlno) values ('" + dataGridView2.Rows[i].Cells[0].Value + "','" + dataGridView2.Rows[i].Cells[1].Value + "','" + dataGridView2.Rows[i].Cells[2].Value + "','" + dataGridView2.Rows[i].Cells[3].Value + "','" + dataGridView2.Rows[i].Cells[4].Value + "','" + dataGridView2.Rows[i].Cells[5].Value + "','" + dataGridView2.Rows[i].Cells[6].Value + "','" + cboprofilename.Text + "','" + cbopcode.Text + "','" + dataGridView2.Rows[i].Cells[7].Value + "','" + dataGridView2.Rows[i].Cells[8].Value + "')", con);

                    cmd.ExecuteNonQuery();

                }

            }
            SqlDataAdapter adapter = new SqlDataAdapter("select type,pcode,dt_report,note from profile_note where type='" + cboprofilename.Text + "' and  pcode='" + cbopcode.Text + "'", con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "profile_note");
            if (ds.Tables[0].Rows.Count == 0)
            {
                cmd = new SqlCommand("insert into profile_note(type,pcode,dt_report,note) values ('" + cboprofilename.Text + "','" + cbopcode.Text + "','" + repdt1 + "','" + txtnote.Text + "')", con);
                cmd.ExecuteNonQuery();
            }
            else
            {
                cmd = new SqlCommand("update profile_note set type='" + cboprofilename.Text + "',pcode='" + cbopcode.Text + "',dt_report='" + repdt1 + "',note='" + txtnote.Text + "'", con);
                cmd.ExecuteNonQuery();
            }
                
        }

        private void btnprintprofileresult_Click(object sender, EventArgs e)
        {
            Frmrepprofilereport frprep = new Frmrepprofilereport();
            frprep.Show();
        }

        private void cboprofilename_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select test,method,result,unit,reference_range,grp,sgrp,pcode,type,grp_code,srlno from profile_data where type='" + cboprofilename.Text + "' and  pcode='" + cbopcode.Text + "'", con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "profile_data");
            if (ds.Tables[0].Rows.Count == 0)
            {
                SqlDataAdapter adapter1 = new SqlDataAdapter("select test,method,unit,reference_range,grp,sgrp,type,grp_code,srlno from profile_master where type='" + cboprofilename.Text + "' ", con);
                ds = new DataSet();
                adapter1.Fill(ds, "profile_master");

                dataGridView2.Rows.Clear();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dataGridView2.Rows.Add();
                    dataGridView2.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][0].ToString();
                    dataGridView2.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][1].ToString();

                    dataGridView2.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][2].ToString();
                    dataGridView2.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][3].ToString();
                    dataGridView2.Rows[i].Cells[5].Value = ds.Tables[0].Rows[i][4].ToString();
                    dataGridView2.Rows[i].Cells[6].Value = ds.Tables[0].Rows[i][5].ToString();
                    dataGridView2.Rows[i].Cells[7].Value = ds.Tables[0].Rows[i][7].ToString();
                    dataGridView2.Rows[i].Cells[8].Value = ds.Tables[0].Rows[i][8].ToString();

                
                
                }
                txtnote.Text = "";
                adapter1.Dispose();
              adapter1 = new SqlDataAdapter("select type,note from profile_master_note where type='" + cboprofilename.Text + "' ", con);
                ds = new DataSet();
                adapter1.Fill(ds, "profile_master_note");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtnote.Text = ds.Tables[0].Rows[0][1].ToString();
                }
                else
                {
                    txtnote.Text = "";
                }
            }
            else
            {


                SqlDataAdapter adapter2 = new SqlDataAdapter("select pcode,type,note from profile_note where type='" + cboprofilename.Text + "' and  pcode='" + cbopcode.Text + "'", con);
                DataSet ds2 = new DataSet();
                adapter2.Fill(ds2, "profile_note");
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    txtnote.Text = ds2.Tables[0].Rows[0][2].ToString();
                }
                else
                {
                    txtnote.Text = "";
                }

                adapter2.Dispose();

                dataGridView2.Rows.Clear();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dataGridView2.Rows.Add();
                    dataGridView2.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][0].ToString();
                    dataGridView2.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][1].ToString();
                    dataGridView2.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][2].ToString();
                    dataGridView2.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][3].ToString();
                    dataGridView2.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][4].ToString();
                    dataGridView2.Rows[i].Cells[5].Value = ds.Tables[0].Rows[i][5].ToString();
                    dataGridView2.Rows[i].Cells[6].Value = ds.Tables[0].Rows[i][6].ToString();
                    dataGridView2.Rows[i].Cells[7].Value = ds.Tables[0].Rows[i][9].ToString();
                    dataGridView2.Rows[i].Cells[8].Value = ds.Tables[0].Rows[i][10].ToString();

                
                
                }
            }
        }

      private void txtimpresion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (this.ActiveControl != null)
                {
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                }
                e.Handled = true; // Mark the event as handled
            }
        }

        private void dgvbill_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            //da = new SqlDataAdapter("select price from Test_master where test='" + dgvbill.CurrentRow.Cells[0].Value + "' order by test ", con);
            //ds = new DataSet();
            //da.Fill(ds);
            //if (ds.Tables[0].Rows.Count != 0)
            //{
            //    dgvbill.CurrentRow.Cells[1].Value = ds.Tables[0].Rows[0][0].ToString();
            //}
            //Double dbval = 0.00;
            //for (int i = 0; i < dgvbill.Rows.Count; i++)
            //{
            //    if (dgvbill.Rows[i].Cells[1].Value != null)
            //    {

            //        dbval = dbval + (Convert.ToDouble(dgvbill.Rows[i].Cells[1].Value.ToString()));

            //    }
            //}
            //txtdue.Text = dbval.ToString();
        }

        private void dgvbill_Leave_1(object sender, EventArgs e)
        {
            //dgvbill.Hide();
        }

   
        private void cbopcode_Validating(object sender, CancelEventArgs e)
         {
            if (pidr != 0)
            {
                cbopcode.Text = pidr.ToString();
                cbopcode.Refresh();
            }
        }

        private void btnreportall_Click(object sender, EventArgs e)
        {
            
        }

        
        private void cbopcode_TextUpdate(object sender, EventArgs e)
        {
            if (pidr != 0)
            {
                cbopcode.Text = pidr.ToString();
                cbopcode.Refresh();
            }
        }

        private void cbopcode_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (pidr != 0)
            //{
            //    cbopcode.Text = pidr.ToString();
            //}
        }

        private void cbopcode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //if (pidr != 0)
            //{
            //    cbopcode.Text = pidr.ToString();
            //}
        }

        private void cbopcode_Validated(object sender, EventArgs e)
        {
            if (pidr != 0)
            {
                cbopcode.Text = pidr.ToString();
                cbopcode.Refresh();
            }
        }

        private void cbopcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (pidr != 0)
            {
                cbopcode.Text = pidr.ToString();
                cbopcode.Refresh();
            }
        }

        private void cbopcode_Enter(object sender, EventArgs e)
        {
            if (pidr != 0)
            {
                cbopcode.Text = pidr.ToString();
                cbopcode.Refresh();
            
            }
        }

        private void cbopcode_KeyUp(object sender, KeyEventArgs e)
        {
            if (pidr != 0)
            {
                cbopcode.Text = pidr.ToString();
                cbopcode.Refresh();
            }
        }

        private void btnaddnext_Click(object sender, EventArgs e)
        {
            
        }



        private void btnclosestooln_Click(object sender, EventArgs e)
        {
            st_imp1.Visible = false;
            btnclosestoolcrvn.Visible = false;
            crystalReportViewer2.Visible = false;
        }

       

        private void BDCpdw_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void BDCpdw_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void BDc_Hb_MouseHover(object sender, EventArgs e)
        {
            t.Show("M:12-18 F:11-16", BDc_Hb);
        }

        private void BDc_Hb_MouseLeave(object sender, EventArgs e)
        {
            t.Hide( BDc_Hb);
        }

        private void rmdelete_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            if (MessageBox.Show("Delete ? ", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (ruserid1 == "Admin")
                {
                    if (cbopcode.Text != "")
                    {
                        cmd = new SqlCommand("delete from patient_Master where  pcode='" + Convert.ToInt32(cbopcode.Text) + "'", con);

                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("delete from urine where  pcode='" + Convert.ToInt32(cbopcode.Text) + "'", con);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("delete from stool where  pcode='" + Convert.ToInt32(cbopcode.Text) + "'", con);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("delete from blood where  pcode='" + Convert.ToInt32(cbopcode.Text) + "'", con);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("delete from Biochemist where  pcode='" + Convert.ToInt32(cbopcode.Text) + "'", con);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("delete from Seminal_fluid where  pcode='" + Convert.ToInt32(cbopcode.Text) + "'", con);
                        cmd.ExecuteNonQuery();
                        cmd = new SqlCommand("delete from Culture where  pcode='" + Convert.ToInt32(cbopcode.Text) + "'", con);
                        cmd.ExecuteNonQuery();
                        cmd = new SqlCommand("delete from Cultureext where  pcode='" + Convert.ToInt32(cbopcode.Text) + "'", con);
                        cmd.ExecuteNonQuery();
                        cmd = new SqlCommand("delete from Hormone where   pcode='" + Convert.ToInt32(cbopcode.Text) + "'", con);
                        cmd.ExecuteNonQuery();
                        cmd = new SqlCommand("delete from Hormoneext where   pcode='" + Convert.ToInt32(cbopcode.Text) + "'", con);
                        cmd.ExecuteNonQuery();
                        cmd = new SqlCommand("delete from cbj where  vono='" + (cbopcode.Text) + "' and trncd='Test'", con);
                        cmd.ExecuteNonQuery();
                        cmd = new SqlCommand("delete from bloodext where  pcode='" + Convert.ToInt32(cbopcode.Text) + "'", con);
                        cmd.ExecuteNonQuery();
                        cmd = new SqlCommand("delete from serologyext where  pcode='" + Convert.ToInt32(cbopcode.Text) + "'", con);
                        cmd.ExecuteNonQuery();
                        
                        cmd = new SqlCommand("delete from biochemistext where pcode='" + Convert.ToInt32(cbopcode.Text) + "'", con);
                        cmd.ExecuteNonQuery();
                            
                        cmd = new SqlCommand("delete from outsource where pcode='" + Convert.ToInt32(cbopcode.Text) + "'", con);
                        cmd.ExecuteNonQuery();
                        cmd = new SqlCommand("delete from histopathology where pcode='" + Convert.ToInt32(cbopcode.Text) + "'", con);
                        cmd.ExecuteNonQuery();
                        //cmd = new SqlCommand("delete from rutineext where pcode='" + Convert.ToInt32(cbopcode.Text) + "'", con);
                        //cmd.ExecuteNonQuery();
                        cmd = new SqlCommand("delete from billl where pcode='" + Convert.ToInt32(cbopcode.Text) + "'", con);
                        cmd.ExecuteNonQuery();
                        cmd = new SqlCommand("delete from notepad where pcode='" + Convert.ToInt32(cbopcode.Text) + "'", con);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("delete from profile_data where pcode='" + Convert.ToInt32(cbopcode.Text) + "'", con);
                        cmd.ExecuteNonQuery();
                        cmd = new SqlCommand("delete from Profile_note where pcode='" + Convert.ToInt32(cbopcode.Text) + "'", con);
                        cmd.ExecuteNonQuery();
                        cmd = new SqlCommand("delete from xray where pcode='" + Convert.ToInt32(cbopcode.Text) + "'", con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("All Test Deleted in Regn. No. " + cbopcode.Text);
                    }
                    else
                    {
                        MessageBox.Show("Select Reg.No.");
                    }
                }
                else
                {
                    MessageBox.Show("You are Not Authorised !!");
                }

            }
        }

        private void Rmsearch_Click(object sender, EventArgs e)
        {

            Frmserch repsr = new Frmserch();
            repsr.Show();
        }

        private void RMSAVE_Click(object sender, EventArgs e)
        {
            String Sqlstr = "";
            con.Close();
            con.Open();
//           begin
//    DECLARE @dateFrom AS datetime,@dateTo as datetime;
//    SET @dateFrom = (SELECT convert(datetime,@effectiveFrom,101));
//    SET @dateTo = (SELECT convert(datetime,@effectiveTo,101));
	
//    //Insert into taxmaster 
//    //    (TaxCode ,TaxName ,TaxPc,effectiveFrom, effectiveTo) 
//    //values 
//    //    (@TaxCode,@TaxName ,@TaxPc , @dateFrom, @dateTo)
 
//end
            
            
            
            
            
            if (MessageBox.Show("Save ? ", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                if (cboname.Text != "")
                {


                    //da = new SqlDataAdapter("select max(pcode) from patient_Master", con);
                    //ds = new DataSet();
                    //da.Fill(ds);
                    //if (ds.Tables[0].Rows[0][0].ToString() == "")
                    //{
                    //    cbopcode.Text = "1";
                    //}
                    //else
                    //{
                    //    int p = (Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) + 1);
                    //    cbopcode.Text = Convert.ToString(p);
                    //}
                    //pidr = Convert.ToInt32(cbopcode.Text);

                    //ds.Dispose();



                    pidr = Convert.ToInt32(cbopcode.Text);
                    RMBILLING.Enabled = true;
                    pat_name = cboname.Text;
                    Sqlstr = "select cc,pcode,patient_name,sex,age,doctor,date_exam,due_amount,paid_amount,month_year,Scn,Tpt";
                    Sqlstr = Sqlstr + " from patient_master where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
                    da = new SqlDataAdapter(Sqlstr, con);
                    ds1 = new DataSet();
                    da.Fill(ds1);

                    if (ds1.Tables[0].Rows.Count == 0)
                    {


                        if (txtage.Text == "")
                            txtage.Text = "0";

                        if (txtdue.Text == "")
                            txtdue.Text = "0.00";

                        if (txtpaid.Text == "")
                            txtpaid.Text = "0.00";

                        dd = dtreport.Text.Substring(0, 2).ToString();
                        mm = this.dtreport.Text.Substring(3, 2).ToString();
                        yy = this.dtreport.Text.Substring(6, 4).ToString();
                        //String tt = this.dtreport.Text.Substring(11,5).ToString();
                       repdt1 = DateTime.ParseExact(dd + "/" + mm + "/" + yy, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        //repdt1 = Convert(dtreport.Text, repdt1, 105);
                        //CONVERT(dtreport.Text, repdt1, 105)
                        //dd1 = txttpt.Text.Substring(0, 2).ToString();
                        //mm1 = this.txttpt.Text.Substring(3, 2).ToString();
                        //yy1 = this.txttpt.Text.Substring(6, 4).ToString();
                        //repdt1 = Convert.ToDateTime(yy + '/' + mm + '/' + dd);
                        //DateTime dt = dtreport.Text;
                        //string format = "dd-mm-yyyy";
                        //string repdt = dtreport.Text.ToString(format);

                       da = new SqlDataAdapter("select max(pcode) from patient_Master", con);
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



                      // if (pidr < 234)
                      // {
                           Sqlstr = "insert into patient_Master (cc,Patient_name,pcode,sex,age,doctor,date_exam,due_amount,paid_amount,month_year,Scn,Tpt,operator,referal,area,report_status) values('" + Convert.ToInt32(txtcompanycode.Text) + "','" + this.cboname.Text + "','" + Convert.ToInt32(cbopcode.Text) + "','" + this.cbosex.Text + "','" + Convert.ToInt32(txtage.Text) + "','" + this.cbodoctor.Text + "','" + repdt1 + "','" + Convert.ToDouble(txtdue.Text) + "','" + Convert.ToDouble(txtpaid.Text) + "','" + cbomy1.Text + "', '" + txtscn.Text + "','" + txttpt.Text + "','" + rusrname1 + "','" + cboreferal.Text + "','" + txtadr.Text + "','Pending')";
                           cmd = new SqlCommand(Sqlstr, con);
                           cmd.ExecuteNonQuery();
                           Sqlstr = "";
                           cbopcode.Items.Add(cbopcode.Text);
                           pidr = Convert.ToInt32(cbopcode.Text);
                           //String ostrue = "";
                           Sqlstr = "update setup set regno='" + Convert.ToInt32(cbopcode.Text) + "'";
                           cmd = new SqlCommand(Sqlstr, con);
                           cmd.ExecuteNonQuery();
                           Sqlstr = "";
                       //}
                       }
                    else
                    {
                        if (ruserid1 == "Admin")
                        {

                           if (txtage.Text == "")
                            {
                                txtage.Text = "0";
                            }
                            if (txtdue.Text == "")
                            {
                                txtdue.Text = "0.00";
                            }
                            if (txtpaid.Text == "")
                            {
                                txtpaid.Text = "0.00";
                            }
                            dd = dtreport.Text.Substring(0, 2).ToString();
                            mm = this.dtreport.Text.Substring(3, 2).ToString();
                            yy = this.dtreport.Text.Substring(6, 4).ToString();
                            //repdt1 = DateTime.ParseExact("2017/20/10", "yyyy/dd/MM", CultureInfo.InvariantCulture);
                            //repdt1 = DateTime.ParseExact("20/10/2017 12:00:00", "dd/MM/yyyy hh:mm:ss", CultureInfo.InvariantCulture);
                            //repdt1 =DateTime.Parse(mm + '/' + dd + '/' + yy);
                           //repdt1 = DateTime.Parse(repdt, CultureInfo.CurrentUICulture.DateTimeFormat);
                            //repdt1 = DateTime.ParseExact("2017/20/10", "yyyy/dd/MM", System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat);
                            //repdt1 = DateTime.ParseExact(repdt1);

                            
                            repdt1 = DateTime.ParseExact(dd + "/" + mm + "/" + yy, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                            //repdt1= CONVERT(VARCHAR, @repdt1, 103);
                            Sqlstr = "update patient_Master set cc='" + Convert.ToInt32(txtcompanycode.Text) + "',Patient_name='" + this.cboname.Text + "',pcode='" + Convert.ToInt32(cbopcode.Text) + "',sex='" + this.cbosex.Text + "',age='" + Convert.ToInt32(txtage.Text) + "',doctor='" + this.cbodoctor.Text + "',date_exam='" + repdt1 + "',due_amount='" + Convert.ToDouble(txtdue.Text) + "',paid_amount='" + Convert.ToDouble(txtpaid.Text) + "',month_year='" + cbomy1.Text + "',Scn='" + txtscn.Text + "',Tpt='" + txttpt.Text + "',operator='" + rusrname1 + "',referal='" + cboreferal.Text + "',area='" + txtadr.Text + "' WHERE Pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
                            cmd = new SqlCommand(Sqlstr, con);
                            cmd.ExecuteNonQuery();
                            Sqlstr = "";
                            pidr = Convert.ToInt32(cbopcode.Text);

                            Sqlstr = "update setup set regno='" + Convert.ToInt32(cbopcode.Text) + "'";
                            cmd = new SqlCommand(Sqlstr, con);
                            cmd.ExecuteNonQuery();
                            Sqlstr = "";
                        
                        }
                        else
                        {
                            MessageBox.Show("Contact Administrator");
                            cbopcode.Focus();
                        }
                    
                    }  
                        pat_name = cboname.Text;
                        dgvbill.Hide();
                        cboname.Focus();
                        reentry.Enabled = true;
                        rmdelete.Enabled = true;
                        RMMERGE.Enabled = true;

                  
                }// name blank
                else
                {
                    MessageBox.Show("name can't be blank");
                    cboname.Focus();
                }
            }//save
        }
         
    

        private void RMBILLING_Click(object sender, EventArgs e)
        {
           pidr = Convert.ToInt32(cbopcode.Text);
            pat_name = cboname.Text;

            dd = dtreport.Text.Substring(0, 2).ToString();
            mm = this.dtreport.Text.Substring(3, 2).ToString();
            yy = this.dtreport.Text.Substring(6, 4).ToString();
            repdt1 = DateTime.ParseExact(dd + "/" + mm + "/" + yy, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);


            Frmbillentry FPBILLent = new Frmbillentry();
            FPBILLent.Show();
              
        }

        private void RMADDNEXT_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("select max(pcode) from patient_Master", con);
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
            reentry.Enabled = false;
            txtage.Text = "";
            txtdue.Text = "0.00";
            txtpaid.Text = "0.00";

            BDc_Neutrophild.Text = "0";
            BDc_Eosinophils.Text = "0";
            BDc_Lymphocytes.Text = "0";
            BDc_Basophils.Text = "0";
            BDc_Monocytes.Text = "0";
            BDc_Twbc.Text = "0";
            BDc_Trbc.Text = "0.00";
            BDc_Tplatelets.Text = "0.00";
            BDc_Aec.Text = "0";
            BDc_Reticulocyte_Count.Text = "0";
            BDc_Tnc.Text = "0";
            BDc_PCV.Text = "0";
            BDCmcv.Text = "0.00";
            BDCmch.Text = "0.00";
            BDCmchc.Text = "0.00";
            BDc_Rct.Text = "0.00";
            BDc_Hb.Text = "0.00";
            BDc_ESR_1sthour.Text = "0";
            BDc_ESR_2ndhour.Text = "0";
            BDc_Mp_ICT_QBC_method.Text = "";
            BDc_Mp_ICT_slide.Text = "";
            Bcr1_Glucose_Fpg_RPG.Text = "0";
            Bcr1_PPPG_PGPG_2hr.Text = "0";
            Bcr1_PPPG_PGPG_1hr.Text = "0";

            Bcr1_RBS.Text = "0";
            //RE_rbs.Text = "0";

            Bcr1_PBBS.Text = "0";
            Bcr1_PLBS.Text = "0";
            Bcr1_GTT_1hr.Text = "0";
            Bcr1_GTT_2hr.Text = "0";
            Bcr1_GTT_3hr.Text = "0";
            Bcr1_PGBS_1hr.Text = "0";
            Bcr1_PGBS_2hr.Text = "0";
            Bcr1_HBAC_good.Text = "0";
            Bcr1_HBAC_fair.Text = "0";
            Bcr1_HBAC_poor.Text = "0";
            Bcr1_MBGE.Text = "0";

            //RE_urea.Text = "0";
            Bcr_RP_Urea.Text = "0";
            Bcr_RP_BUN.Text = "0";
            Bcr_RP_Creatinine.Text = "0.00";
            //RE_creatinine.Text = "0.00";
            Bcr3_Uric_Acid.Text = "0";
            Bcr3_NPN.Text = "0";
            //Bc1_fbs.Text = "0";
            //Bc1_ppbs1.Text = "0";
            //Bc1_ppbs2.Text = "0";
            //Bc2_fbs.Text = "0";
            ////RE_fbs.Text = "0";
            //Bc2_ppbs1.Text = "0";
            //Bc2_ppbs2.Text = "0";
            //Bc2_urea.Text = "0";
            //Bc2_uric_acid.Text = "0";
            //Bc2_creatinine.Text = "0.00";
            //Bc3_fbs.Text = "0";
            //Bc3_cholesterol.Text = "0.00";
            //Bc3_creatinine.Text = "0.00";
            //Bc3_hdl.Text = "0.00";
            //Bc3_ldl.Text = "0.00";
            //Bc3_ppbs1.Text = "0";
            //Bc3_ppbs2.Text = "0";
            //Bc3_triglyceride.Text = "0.00";
            //Bc3_urea.Text = "0";
            //Bc3_uric_acid.Text = "0";
            //Bc3_vldl.Text = "0.00";

            Bcr_LP_Cholesterol.Text = "0.00";
            Bcr_LP_HDLCholesterol.Text = "0.00";
            Bcr_LP_LDLCholesterol.Text = "0.00";
            Bcr_LP_VLDLCholesterol.Text = "0.00";
            Bcr_LP_Triglycerides.Text = "0.00";

            Bcr2_LP_CHR.Text = "0.00";
            Bcr2_LP_LHR.Text = "0.00";
            Bcr_LFT_Bilirubin_total.Text = "0.00";
            Bcr_LFT_Bilirubin_Direct.Text = "0.00";
            Bcr4_LFT_Indirect.Text = "0.00";

            Bcr_LFT_Alkaline_Phosphates.Text = "0";
            Bcr_LFT_SGOT_AST.Text = "0";
            Bcr_LFT_SGPT_ALT.Text = "0";
            Bcr_LFT_Albumin.Text = "0.00";
            Bcr_LFT_Protein.Text = "0.00";
            Bcr_LFT_Globulin.Text = "0.00";
            Bcr_LFT_AG_Ratio.Text = "0.00";
            Bcr4_LFT_GGTP.Text = "0.00";

            Bcr_Electrolyte_Sodium.Text = "0";
            Bcr_Electrolyte_Potassium.Text = "0.00";
            Bcr5_Electrolyte_Chlorides.Text = "0.00";

            Bcr_OTH_Acid_Phosphate.Text = "0";
            Bcr_OTH_Amylase.Text = "0";
            Bcr_OTH_Acid_Calcium.Text = "0.00";
            Bcr_OTH_Acid_Phosphorus.Text = "0.00";
            Bcr_OTH_Uric_Acid.Text = "0.00";
            Bcr_OTH_Pasting_urine_sugar.Text = "0";
            Bcr_OTH_PP_PG_urine_sugar.Text = "0";
            Bcr_OTH_Lipase.Text = "0";
            Bcr_OTH_nac.Text = "0";

            FA_MP_Deformed.Text = "0";
            FA_MT_Active.Text = "0";
            FA_MT_Slugish.Text = "0";
            FA_MT_Dead.Text = "0";
            FA_MT_Totalcount.Text = "0";
            FA_MP_Prostaticpearls.Text = "0";
            cboiv.Text = "";
            TOTAL_TRIIODOTHYRONINE_T3.Text = "0";
            TOTAL_THYROXINE_T4.Text = "0";
            TSH.Text = "0";
            FREE_TRIIODOTHYRONINE_FT3.Text = "0";
            FREE_THYROXINE_FT4.Text = "0";
            ANTIMICROSOMAL_ANTIBODY_AMA.Text = "0";
            TOTAL_CHOLESTEROL.Text = "0";
            PROLACTIN_PRL.Text = "0";
            PROSTATESPECIFICANTIGEN_PSA.Text = "0";
            ADENOSINE_DEAMINASE.Text = "0";
            ANTITUBERCULOSIS_TB_IgG.Text = "0";
            ANTITUBERCULOSIS_TB_IgM.Text = "0";
            ANTITUBERCULOSIS_TB_IgA.Text = "0";
            BHCG.Text = "0";
            CA_125.Text = "0";
            ANA.Text = "0";


            dataGridView1.Visible = false;
            crystalReportViewer1.Visible = false;
            btnclosecrv.Visible = false;
            crystalReportViewer2.Visible = false;
            btnclosestoolcrv.Visible = false;
            crystalReportViewer3.Visible = false;
            btnclosebloodcrv.Visible = false;
            //crystalReportViewer4.Visible = false;
            // btncloseroutine.Visible = false;
            dgvbloodnewtest.Rows.Clear();
            dgvser.Rows.Clear();
            dgvbiochemext.Rows.Clear();
            dgvhormonenew.Rows.Clear();
            dgvculture.Rows.Clear();
            dgvbill.Visible = false;
            dgvbill1.Visible = false;
            dgvbloodnewtest.Visible = false;
            dgvser.Visible = false;
            dgvbiochemext.Visible = false;
            dgvhormonenew.Visible = false;
            
            
            
            // dgvrutinenewext.Visible = false;

            BDcRcdw.Text = "0.00";
            BDCmpv.Text = "0.00";
            BDCpdw.Text = "0.00";
            SBPS_Aso_Qty.Text = "0.00";
            SBPS_Crp_Qty.Text = "0.00";
            SBPS_Rafactor_Qty.Text = "0.00";

            SBS_trop_Qty.Text = "0.00";
            RMBILLING.Enabled = false;
            cboname.Text = "";
            cbodoctor.Text = "";
            cbosex.Text = "";
            cbomy1.Text = "Yrs.";
            txtscn.Text = "";
            txttpt.Text = "";
            cboreferal.Text = "";
            txtadr.Text = "";
            //urine
           

            UP_color.Text = "Pale Yellow";
            // UP_sediments.Text = ds2.Tables[0].Rows[0][3].ToString();
            UP_reaction.Text = "Acidic";
            UP_specificgravity.Text = "10mL";
            //chkspecificgravity.Text = ds.Tables[0].Rows[0][11].ToString();
            UC_sugar.Text = "Nil";
            UC_albumin.Text = "Nil";
            UC_phosphate.Text = "Nil";
            //chkphosphate.Text = "";
            UC_chyle.Text = "Nil";
            //chkchyle.Text = "";
            UC_ketonebodies.Text = "";
            //chkketonebodies.Text ="";
            UC_bilesalts.Text = "";
            //chkbilesalts.Text = "";
            UC_bilepigment.Text = "";
            // chkbilepigment.Text = ds.Tables[0].Rows[0][23].ToString();
            UM_puscells.Text = "0-1";
            UM_epithcells.Text = "1-2";
            UM_rbc.Text = "Nil";
            UM_casts.Text = "Nil";
            UM_crystals.Text = "Nil";
            UM_bacterial.Text = "Nil";
            UM_spermatozoa.Text = "Nil";
            UM_mf_tv.Text = "";
            UM_others.Text = "";
            UU_urine_b_hcg.Text = "";
            UA_urine_albumin.Text = "";
            BDc_Nasalsmear.Text = "";
            ur_imp.Text = "";
            txtmicrofilaria.Text = "";
            Ur_spgr.Text = "";
            Ur_php.Text = "";
            Ur_urobil.Text = "";
            Ur_benzodine.Text = "";
            
            
            
            //urine end

            //stool start
            //Sp_color.Text = "Brownish";
            //Sp_reaction.Text = "Acidic";
            //SP_mucus.Text = "";
            //SM_rbc_from.Text = "";
            ////SM_rbc_to.Text = "";
            //SM_puscells_from.Text = "";
            ////SM_puscells_to.Text = "";
            //SM_macrophase.Text = "";
            //SM_vegetables.Text = "Present(+)";
            //SM_fatglobules.Text = "";
            //SM_yeast.Text = "";
            //SM_crystal.Text = "";
            //SM_bacterialflora.Text = "";
            //SP_EHistolytica.Text = "";
            //SP_ecoli.Text = "";
            //SP_giardia.Text = "";
            //SP_trichmonas.Text = "";
            //SH_OvaHW.Text = "";
            //SH_Larva.Text = "";
            //SH_OvaRW.Text = "";
            //SM_other_crystal.Text = "";
            //SC_Occultblood.Text = "xxxx";
            //SC_Reducingsugar.Text = "xxxx";
            //st_imp1.Text = "";

            //SH_hymene.Text = "";
            //SH_crystal1.Text = "";

            Sp_color.Text = "Brownish";
            Sp_reaction.Text = "Acidic";
            SP_mucus.Text = "Present(+)";
            SM_rbc_from.Text = "Nil";
            //SM_rbc_to.Text = "";
            SM_puscells_from.Text = "0-1";
            //SM_puscells_to.Text = "";
            SM_macrophase.Text = "Nil";
            SM_vegetables.Text = "Present(+)";
            SM_fatglobules.Text = "Nil";
            SM_yeast.Text = "Nil";
            SM_crystal.Text = "Semi Solid";
            SM_bacterialflora.Text = "Adequate";
            SP_EHistolytica.Text = "Nil";
            SP_ecoli.Text = "Nil";
            SP_giardia.Text = "Nil";
            SP_trichmonas.Text = "Nil";
            SH_OvaHW.Text = "Nil";
            SH_Larva.Text = "Nil";
            SH_OvaRW.Text = "Nil";
            SM_other_crystal.Text = "";
            SC_Occultblood.Text = "xxxx";
            SC_Reducingsugar.Text = "xxxx";
            st_imp1.Text = "";

            SH_hymene.Text = "2-3";
            SH_crystal1.Text = "";

            
            
            
            
            //stool end
            // blood sart

            BG_Blood_Group.Text = "";
            BR_RhD_Typing.Text = "";
            //BDc_Neutrophild.Text = "0";
            //BDc_Eosinophils.Text = "0";
            //BDc_Lymphocytes.Text = "0";
            //BDc_Basophils.Text = "0";
            //BDc_Monocytes.Text = "0";
            //BDc_Twbc.Text = "0";
            //BDc_Trbc.Text = "0.00";
            //BDc_Tplatelets.Text = "0.00";
            //BDc_Aec.Text = "0";
            //BDc_Reticulocyte_Count.Text = "0";
            //BDc_Tnc.Text = "0";


            //BDc_PCV.Text = "0";
            //BDCmcv.Text = "0.00";
            //BDCmch.Text = "0.00";
            //BDCmchc.Text = "0.00";

            CBDcPSS.Text = "";
            BDc_Mp_ICT_QBC_Smear.Text = "";
            BDc_Mp_ICT.Text = "";
            BDc_Mf_ICT_QBC_Smear.Text = "";
            BDc_Mf_ICT.Text = "";
            //BDc_Rct.Text = "0.00";
            //BDc_Hb.Text = "0.00";
            //BDc_ESR_1sthour.Text = "0";
            // BDc_ESR_2ndhour.Text = "0";
            BDc_Bleeding_Time.Text = "";
            BDc_Clotting_Time.Text = "";
            BDc_Nasalsmear.Text = "";
            BDc_Nasalsmear_Right.Text = "";
            BDc_Sickle_cell.Text = "";
            BDc_Prothombintime.Text = "";
            BDc_Prothombintime_cont.Text = "";
            SBPS_Toxo.Text = "";
            SBPS_Crp.Text = "";
            SBPS_vdrl.Text = "";
            SBPS_Ana.Text = "";
            SBPS_Rafactor.Text = "";
            SBPS_Aso.Text = "";
            SBS_Australia_Antigen.Text = "";
            SBS_Hepatitis_C_Virus.Text = "";
            SBS_HIV_1.Text = "";
            SBS_HIV_2.Text = "";
            //BS_Ict_PF_PV.Text = ds4.Tables[0].Rows[0][45].ToString();

            BWwidaltubeo80.Text = "";
            BWwidaltubeo160.Text = "";
            BWwidaltubeo320.Text = "";
            BWwidaltubeo240.Text = "";
            BWwidaltubeo480.Text = "";

            BWwidaltubeh80.Text = "";
            BWwidaltubeh160.Text = "";
            BWwidaltubeh320.Text = "";
            BWwidaltubeh240.Text = "";
            BWwidaltubeh480.Text = "";

            BWwidaltubeah80.Text = "";
            BWwidaltubeah160.Text = "";
            BWwidaltubeah320.Text = "";
            BWwidaltubeah240.Text = "";
            BWwidaltubeah480.Text = "";

            BWwidaltubebh80.Text = "";
            BWwidaltubebh160.Text = "";
            BWwidaltubebh320.Text = "";
            BWwidaltubebh240.Text = "";
            BWwidaltubebh480.Text = "";

            BWwidalslide1.Text = "";
            BWwidalslide2.Text = "";
            BWwidalslide3.Text = "";
            BWwidalslide4.Text = "";
            SBS_mycodot.Text = "";
            SBS_trop.Text = "";

            SBm_MontouxTest_injon.Text = "";
            SBm_MontouxTest_readon.Text = "";
            SBm_MontouxTest_induration.Text = "";
            BDc_ESR_2ndhour.Text = "0";
            BDc_Prothombintime_inr.Text = "";
            SBS_Dengue.Text = "";
            SBS_Dengue_NSI.Text = "";
            SBS_Typhicheck.Text = "";
            bl_imp.Text = "";
            ser_imp.Text = "";
            //BDcRcdw.Text = "0.00";
            //BDCmpv.Text = "0.00";
            //BDCpdw.Text = "0.00";

            //blood end

            //rutine start
            // RE_Blood_Group.Text = "";
            //RE_RhD_Typing.Text = "";
            //RE_Neutrophild.Text = "0";
            //RE_Eosinophils.Text = "0";
            //RE_Lymphocytes.Text = "0";
            // RE_Basophils.Text = "0";
            // RE_Monocytes.Text = "0";
            // RE_Twbc.Text = "0";
            BDc_Trbc.Text = "0.00";
            BDc_Tplatelets.Text = "0.00";
            // RE_Aec.Text = "0";
            BDc_Reticulocyte_Count.Text = "0";
            BDc_Tnc.Text = "0";


            BDc_PCV.Text = "0";
            BDCmcv.Text = "0.00";
            BDCmch.Text = "0.00";
            BDCmchc.Text = "0.00";

            CBDcPSS.Text = "";
            //RE_Mp_ICT_QBC_Smear.Text = "";
            // RE_Mp_ICT.Text = "";
            BDc_Mf_ICT_QBC_Smear.Text = "";
            BDc_Mf_ICT.Text = "";
            BDc_Rct.Text = "0.00";
            //RE_Hb.Text = "0.00";
            BDc_ESR_1sthour.Text = "0";
            // BDc_ESR_2ndhour.Text = "0";
            // RE_Bleeding_Time.Text = "";
            // RE_Clotting_Time.Text = "";
            BDc_Nasalsmear.Text = "";
            BDc_Nasalsmear_Right.Text = "";
            BDc_Sickle_cell.Text = "";
            BDc_Prothombintime.Text = "";
            BDc_Prothombintime_cont.Text = "";
            //RE_Toxo.Text = "";
            //RE_Crp.Text = "";
            //RE_vdrl.Text = "";
            SBPS_Ana.Text = "";
            //RE_Rafactor.Text = "";
            //RE_Aso.Text = "";
            //RE_Australia_Antigen.Text = "";
            SBS_Hepatitis_C_Virus.Text = "";
            //RE_HIV_1.Text = "";
            //RE_HIV_2.Text = "";

           
            SBS_mycodot.Text = "";
            SBS_trop.Text = "";

            SBm_MontouxTest_injon.Text = "";
            SBm_MontouxTest_readon.Text = "";
            SBm_MontouxTest_induration.Text = "";
            BDc_ESR_2ndhour.Text = "0";
            BDc_Prothombintime_inr.Text = "";
            SBS_Dengue.Text = "";
            SBS_Typhicheck.Text = "";

          
            SBS_Dengue_NSI.Text = "";
            
            //rotyine end

            //semen start
            FA_Timeofcollection.Text = "";
            FA_Timeofexamination.Text = "";
            FA_Timeofliquification.Text = "";
            FA_Volume.Text = "";
            FA_Reaction.Text = "";
            FA_Color.Text = "";
            FA_Viscocity.Text = "";
            FA_MP_Prostaticpearls.Text = "0";
            FA_MP_Puscells.Text = "";
            FA_MP_RBC.Text = "";
            FA_MP_Epithcells.Text = "";
            FA_MP_Deformed.Text = "0";
            FA_MT_Active.Text = "0";
            FA_MT_Slugish.Text = "0";
            FA_MT_Dead.Text = "0";
            FA_MT_Totalcount.Text = "0";
            sf_imp.Text = "";
            //semen end
            CtSpecimen.Text = "";
            CtBenign_Cell.Text = "";
            CtEndocervical_Cell.Text = "";
            CtInflammatory_Cell.Text = "";
            CtTrichomonas.Text = "";
            CtMonilia.Text = "";
            CtEndometrial_Cell.Text = "";
            CtSpermatozoa.Text = "";
            CtRbc.Text = "";
            CtDysplastic_Cell.Text = "";
            CtMalignant_Cell.Text = "";
            CtOthers.Text = "";
            Ctimp.Text = "";


            BfSpecimen.Text = "";
            BfQty.Text = "";
            BfAppearance.Text = "";
            BfColor.Text = "";
            BfClotFormation.Text = "";
            BfNeutrophil.Text = "";
            BfSugar.Text = "";
            BfMicroprotein.Text = "";
            BfLymphocyte.Text = "";
            BfTotal_cell_count.Text = "";
            BfRbc.Text = "";
            BfMalignant_Cell.Text = "";
            BfImpression.Text = "";
            BfAbnormal_Cell.Text = "";

            srt_afp.Text = "";
            SRT_ASA.Text = "";
            SRT_CV_IGG.Text = "";
            SRT_CV_IGM.Text = "";
            SRT_HSV_IGG.Text = "";
            SRT_HSV_IGM.Text = "";
            SRT_RV_IGG.Text = "";
            SRT_RV_IGM.Text = "";
            SRT_HBSA.Text = "";
            SRT_AHBSAT.Text = "";
            SRT_HBEA.Text = "";
            SRT_AHBEAT.Text = "";
            SRT_AHBCA_IGM.Text = "";
            SRT_AHBCAT.Text = "";
            SRT_AHAV_IGM.Text = "";
            SRT_AHAVT.Text = "";
            SRT_AHCVT.Text = "";
            SRT_AHEV_IGM.Text = "";
            srt_hp_igg.Text = "";
            srt_hp_igm.Text = "";
            srt_hp_iga.Text = "";
            SER_IMP2.Text = "";
            txtnote.Text = "";
            txtnotepad.Text = "";
            dtreport.Text = DateTime.Now.ToShortDateString();
            txthisto.Text = "";
            //txthistox.Text = "";
           //txthistoimp.Text = "";
            txtimpresion.Text = "";
            txtmicro.Text = "";
            //txtmicrox.Text = "";
            txtgexam.Text = "";
            //txtgexamx.Text = "";

        }

        private void RMCANCEL_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RMMERGE_Click(object sender, EventArgs e)
        {
            Frmreportall FRPALL = new Frmreportall();
            FRPALL.Show();
        }

        private void tpsemen_Click(object sender, EventArgs e)
        {

        }

        private void label168_Click(object sender, EventArgs e)
        {

        }

        private void btnserdgv_Click(object sender, EventArgs e)
        {
            dgvser.Visible = true;
            dgvser.Show();
            dgvser.Rows.Clear();

            da = new SqlDataAdapter("select test,method,result,unit,normal_range from serologyext where pcode='" + cbopcode.Text.Trim() + "' order by test ", con);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dgvser.Rows.Add();
                    dgvser.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][0].ToString();
                    dgvser.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][1].ToString();
                    dgvser.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][2].ToString();
                    dgvser.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][3].ToString();
                    dgvser.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][4].ToString();


                }


            }
        
         
        }

        private void btnrhormonenew_Click(object sender, EventArgs e)
        {
            dgvhormonenew.Visible = true;


            dgvhormonenew.Show();
            dgvhormonenew.Rows.Clear();

            da = new SqlDataAdapter("select test,method,result,unit,normal_range from hormoneext where pcode='" + cbopcode.Text.Trim() + "' order by test ", con);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dgvhormonenew.Rows.Add();
                    dgvhormonenew.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][0].ToString();
                    dgvhormonenew.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][1].ToString();
                    dgvhormonenew.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][2].ToString();
                    dgvhormonenew.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][3].ToString();
                    dgvhormonenew.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][4].ToString();


                }


            }
        
        }

        private void dgvhormonenew_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            da = new SqlDataAdapter("select test,method,unit,reference_range from test_master where test='" + dgvhormonenew.CurrentRow.Cells[0].Value + "'", con);
            ds = new DataSet();
            da.Fill(ds, "test_master");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    dgvhormonenew.Rows.Add();
                    dgvhormonenew.CurrentRow.Cells[0].Value = ds.Tables[0].Rows[0][0].ToString();
                    dgvhormonenew.CurrentRow.Cells[1].Value = ds.Tables[0].Rows[0][1].ToString();
                    dgvhormonenew.CurrentRow.Cells[3].Value = ds.Tables[0].Rows[0][2].ToString();
                    dgvhormonenew.CurrentRow.Cells[4].Value = ds.Tables[0].Rows[0][3].ToString();
                }
            }
        }

        private void dgvser_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            da = new SqlDataAdapter("select test,method,unit,reference_range from test_master where test='" + dgvser.CurrentRow.Cells[0].Value + "'", con);
            ds = new DataSet();
            da.Fill(ds, "test_master");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    dgvser.Rows.Add();
                    dgvser.CurrentRow.Cells[0].Value = ds.Tables[0].Rows[0][0].ToString();
                    dgvser.CurrentRow.Cells[1].Value = ds.Tables[0].Rows[0][1].ToString();
                    dgvser.CurrentRow.Cells[3].Value = ds.Tables[0].Rows[0][2].ToString();
                    dgvser.CurrentRow.Cells[4].Value = ds.Tables[0].Rows[0][3].ToString();
                }
            }
        }

        private void dgvser_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvser_Leave(object sender, EventArgs e)
        {
            dgvser.Hide();
        }

        private void dgvhormonenew_Leave(object sender, EventArgs e)
        {
            dgvhormonenew.Hide();
        }

        private void btnpregprint_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("select cc,comp,address,year_start,year_end,pathologist,biochemist,telphoneno,email,cstno,address1,faxno from company", con);
            ds2 = new DataSet();
            da.Fill(ds2);

            da.Dispose();
            btnclosecrv.Visible = true;
            crystalReportViewer1.Visible = true;

            String s1 = "select a.cc,a.patient_name,a.pcode,a.sex,a.age,a.doctor,a.date_exam as Dt_Report,a.month_year,b.UP_color,b.UP_reaction,b.UP_specificgravity,b.UC_sugar,b.UC_albumin,b.UC_phosphate,b.UC_chyle,b.UC_ketonebodies,b.UC_bilesalts,b.UC_bilepigment,b.UM_puscells,b.UM_epithcells,b.UM_rbc,b.UM_casts,b.UM_crystals,b.UM_bacterial,b.UM_spermatozoa,b.UM_mf_tv,b.UM_others,b.UU_urine_b_hcg,b.UA_urine_albumin,b.UN_nasalsmear,b.ur_imp,a.scn,a.tpt,ur_cotinine from patient_master a , urine b where a.pcode=b.pcode and  a.pcode='" + cbopcode.Text + "'   order by b.pcode,a.date_exam";
            da = new SqlDataAdapter(s1, con);
            ds = new DataSet();
            da.Fill(ds, "Pathology_Urine");
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

                dt.Columns.Add("barcode", System.Type.GetType("System.Byte[]"));

                String qrdata = cbopcode.Text.Trim();
                BarcodeLib.Barcode.Linear qrcode = new BarcodeLib.Barcode.Linear();
                qrcode.Type = BarcodeLib.Barcode.BarcodeType.CODE39;
                qrcode.Data = qrdata;

                // Save & output QR Code barcode image to your system
                qrcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;
                byte[] imageData = qrcode.drawBarcodeAsBytes();
               
                
                gpatient_name = ds.Tables[0].Rows[i][1].ToString();
                gcode = Convert.ToInt32(ds.Tables[0].Rows[i][2].ToString());
                gsex = ds.Tables[0].Rows[i][3].ToString();
                gage = Convert.ToInt32(ds.Tables[0].Rows[i][4].ToString());
                gdoctor = ds.Tables[0].Rows[i][5].ToString();
                gdt_report = Convert.ToDateTime(ds.Tables[0].Rows[i][6].ToString());
                gmnyr = ds.Tables[0].Rows[i][7].ToString();
                gscn = ds.Tables[0].Rows[i][31].ToString();
                gtpt = ds.Tables[0].Rows[i][32].ToString();



                if (ds.Tables[0].Rows[i][27].ToString() != "")
                {
                    Ggrp = "Pregnancy";
                    //Ggrp = "Pregnancy";
                    Gdesc = "";
                    Gdesc1 = "Pregnancy";
                    Gresult = ds.Tables[0].Rows[i][27].ToString();
                    Gunit = "";
                    Gnormalrange = "";
                    Gnormalrange1 = "";
                    ADDROW();
                }

                //if (ds.Tables[0].Rows[i][30].ToString() != "")
                //{
                //    Ggrp = "3.MICROSCOPIC-EX-";
                //    Gdesc = "MICROSCOPIC-EX-";
                //    Gdesc1 = "Impression";
                //    Gresult = ds.Tables[0].Rows[i][30].ToString();
                //    Gunit = "";
                //    Gnormalrange = "";
                //    Gnormalrange1 = "";
                //    ADDROW();
                //}


                //UM_mf_tv,b.UM_others,b.UU_urine_b_hcg,b.UA_urine_albumin,b.UN_nasalsmear                      



                //Repurine cashbankrep = new Repurine();
                Reppregnancy cashbankrep = new Reppregnancy();
                //cashbankrep.SetDatabaseLogon("sa", "software", @".\SQLEXPRESS", "pathology2627");
                cashbankrep.SetDataSource(dt);
                crystalReportViewer1.ReportSource = cashbankrep;
                cashbankrep.SetParameterValue(0, ds2.Tables[0].Rows[0][5].ToString());
                cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows[0][6].ToString());
                cashbankrep.SetParameterValue(2, ds2.Tables[0].Rows[0][1].ToString());
                cashbankrep.SetParameterValue(3, ds2.Tables[0].Rows[0][2].ToString());
                cashbankrep.SetParameterValue(4, ds2.Tables[0].Rows[0][7].ToString());
                cashbankrep.SetParameterValue(5, ds2.Tables[0].Rows[0][8].ToString());
                cashbankrep.SetParameterValue(6, ds2.Tables[0].Rows[0][9].ToString());
                cashbankrep.SetParameterValue(7, ds2.Tables[0].Rows[0][10].ToString());
                cashbankrep.SetParameterValue(8, ds2.Tables[0].Rows[0][11].ToString());
                
                crystalReportViewer1.Refresh();

            }
            else
            {
                MessageBox.Show("No Records Found!!!");
            }
        }

        private void label523_Click(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void Bcr_LP_VLDLCholesterol_Validating(object sender, CancelEventArgs e)
        {
            Double vldl = Convert.ToDouble(Bcr_LP_Triglycerides.Text ) / 5;
            Bcr_LP_VLDLCholesterol.Text = vldl.ToString();
        }

        private void Bcr2_LP_CHR_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToDouble(Bcr_LP_HDLCholesterol.Text)!=0)
            {
            Double chor = Convert.ToDouble(Bcr_LP_Cholesterol.Text ) / Convert.ToDouble(Bcr_LP_HDLCholesterol.Text );
            Bcr2_LP_CHR.Text = Math.Round(chor,2).ToString();
            }
            else
            {
                Bcr2_LP_CHR.Text = "0.00";
            }
            }

        private void Bcr2_LP_LHR_Validating(object sender, CancelEventArgs e)
        {
           if (Convert.ToDouble(Bcr_LP_HDLCholesterol.Text)!=0)
            {
            Double lhor = Convert.ToDouble(Bcr_LP_LDLCholesterol.Text) / Convert.ToDouble(Bcr_LP_HDLCholesterol.Text);
            Bcr2_LP_LHR.Text = Math.Round(lhor, 2).ToString();
            }
           else
           {
               Bcr2_LP_LHR.Text = "0.00";
           }
           
           }

        private void label575_Click(object sender, EventArgs e)
        {

        }

        private void tpblood_Click(object sender, EventArgs e)
        {

        }

        private void dgvbloodnewtest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BDc_Monocytes_Validating(object sender, CancelEventArgs e)
        {
            int neu = Convert.ToInt32(BDc_Neutrophild.Text);
            int lymp = Convert.ToInt32(BDc_Lymphocytes.Text);
            int eos = Convert.ToInt32(BDc_Eosinophils.Text);
            int mon = Convert.ToInt32(BDc_Monocytes.Text);
            int baso = Convert.ToInt32(BDc_Basophils.Text);
            int TDC = neu + lymp + eos + mon + baso;
            int tdcb = 100 - TDC;
            dctot();
            if (neu + lymp + eos + mon + baso != 0)
            {
                if (neu + lymp + eos + mon + baso != 100)
                {

                    labelmon.Text=tdcb.ToString();

                    //BDc_Neutrophild.Focus();.Text=tdcb.ToString();
                }
            }
        }

        private void crystalReportViewer2_Load(object sender, EventArgs e)
        {
           // BDc_Neutrophild.Focus();

        }

        private void SH_hymene_TextChanged(object sender, EventArgs e)
        {

        }

        private void Bcr_LP_HDLCholesterol_Validating(object sender, CancelEventArgs e)
        {
           // Bcr_LP_LDLCholesterol.Text = Convert.ToString(Convert.ToDouble(Bcr_LP_Cholesterol.Text) - Convert.ToDouble(Bcr_LP_HDLCholesterol.Text) - (Convert.ToDouble(Bcr_LP_Triglycerides.Text) / 5));
        }

        private void Bcr_LFT_AG_Ratio_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToDouble(Bcr_LFT_Globulin.Text) != 0)
            {
                Double agr = Convert.ToDouble(Bcr_LFT_Albumin.Text) / Convert.ToDouble(Bcr_LFT_Globulin.Text);
                Bcr_LFT_AG_Ratio.Text = Math.Round(agr, 2).ToString();
            }
            else
            {
                Bcr_LFT_AG_Ratio.Text = "0.00";
            }
            }

        private void btnsavenotepad_Click(object sender, EventArgs e)
        {
            String Sqlstr0 = "";
            String Sqlstr = "";
            con.Close();
            con.Open();

            if (MessageBox.Show("Save ? ", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                String strsql2 = "";
                strsql2 = "select cc,pcode,note";
                strsql2 = strsql2 + " from notepad where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
                da = new SqlDataAdapter(strsql2, con);
                ds2 = new DataSet();
                da.Fill(ds2);


                if (ds2.Tables[0].Rows.Count == 0)
                {
                    Sqlstr0 = "insert into notepad (cc,pcode,note) values('" + Convert.ToInt32(txtcompanycode.Text) + "','" + Convert.ToInt32(cbopcode.Text);

                         Sqlstr0 = Sqlstr0 + "','" + txtnotepad.Text + "')";
                   // Sqlstr0 = Sqlstr0 + "','" + richTextBox1.Text + "')";
                    cmd = new SqlCommand(Sqlstr0, con);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    Sqlstr = "";
                    Sqlstr = "update notepad set cc='" + Convert.ToInt32(txtcompanycode.Text) + "',pcode='" + Convert.ToInt32(cbopcode.Text);

                    Sqlstr = Sqlstr + "',note='" + txtnotepad.Text;
                    //Sqlstr = Sqlstr + "' where pcode='" + Convert.ToInt32(txtpcode.Text) + "' and age='" + Convert.ToInt32(txtage.Text) + "' and date_exam='" + this.dtreport.Text+"'";
                    Sqlstr = Sqlstr + "'  where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";

                    cmd = new SqlCommand(Sqlstr, con);
                    cmd.ExecuteNonQuery();
                }
                


            }
        }

        private void btnprintnotepad_Click(object sender, EventArgs e)
        {
            //da = new SqlDataAdapter("select cc,comp,address,year_start,year_end,pathologist,biochemist from company", con);
            //ds2 = new DataSet();
            //da.Fill(ds2);

            //da.Dispose();


            //btnclosestoolcrvn.Visible = true;
            //crystalReportViewer4.Visible = true;
            
            
            
            
            //da = new SqlDataAdapter("select note from notepad where pcode='" + cbopcode.Text + "' order by pcode", con);
            //DataSet ds3 = new DataSet();
            //da.Fill(ds3);
            //String note = "";

            //if (ds3.Tables[0].Rows.Count > 0)
            //{
            //    if (ds3.Tables[0].Rows[0][0].ToString().Trim() == "")
            //    {
            //        note = "";
            //    }
            //    else
            //    {
            //        note = ds3.Tables[0].Rows[0][0].ToString();
            //    }
            //    da.Dispose();
            //}



            ////SqlCommand command = new SqlCommand("itmgrp", con);
            //SqlDataAdapter adapter = new SqlDataAdapter("select b.pcode,b.patient_name,b.date_exam,b.scn as telphoneno,b.age,b.sex,b.month_year,b.doctor,b.tpt,a.note,a.pcode from notepad a,patient_master b where (a.pcode=b.pcode) and b.pcode='" + cbopcode.Text + "'  order by b.pcode  ", con);
            ////SqlDataAdapter adapter = new SqlDataAdapter("select b.pcode,b.patient_name,b.date_exam,b.telphoneno,b.age,b.sex,a.test,a.method,a.result,a.unit,a.reference_range,a.grp,a.sgrp,a.pcode,a.type from profile_data where (a.pcode=b.pcode) and b.pcode='" + cbocode.Text + "' and a.type='" + cboprofile.Text + "'   ", con);
            //DataSet ds = new DataSet();
            //adapter.Fill(ds, "notepad");

            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    //if (radioButton1.Checked == true)
            //    //{

            //    //    Reportprofilewonor cashbankrep = new Reportprofilewonor();
            //    //    // cashbankrep.SetDatabaseLogon("sa", "software", @".\SQLEXPRESS", "pathology2627");
            //    //    cashbankrep.SetDataSource(ds);
            //    //    crystalReportViewer1.ReportSource = cashbankrep;
            //    //    cashbankrep.SetParameterValue(0, ds2.Tables[0].Rows[0][5].ToString());
            //    //    cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows[0][6].ToString());
            //    //    ////cashbankrep.SetParameterValue(2, clbal);
            //    //    cashbankrep.SetParameterValue(2, cboprofile.Text);
            //    //    cashbankrep.SetParameterValue(3, note);
            //    //    //cashbankrep.SetParameterValue(3, label4.Text);
            //    //    crystalReportViewer1.Refresh();
            //    //}
            //    //else
            //    //{
            //        Reportnote cashbankrep = new Reportnote();
            //        // cashbankrep.SetDatabaseLogon("sa", "software", @".\SQLEXPRESS", "pathology2627");
            //        cashbankrep.SetDataSource(ds);
            //        crystalReportViewer4.ReportSource = cashbankrep;
            //        cashbankrep.SetParameterValue(0, ds2.Tables[0].Rows[0][5].ToString());
            //        cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows[0][6].ToString());
            //        ////cashbankrep.SetParameterValue(2, clbal);
            //        //cashbankrep.SetParameterValue(2, cboprofile.Text);
            //        cashbankrep.SetParameterValue(2, note);
            //        //cashbankrep.SetParameterValue(3, label4.Text);
            //        crystalReportViewer1.Refresh();

            //    //}


            //}
            //else
            //{
            //    MessageBox.Show("No record found");
            //}

            //SqlConnection con = new SqlConnection("data source=.;integrated security=SSPI;database=Pathology;");
            Class1 objclass = new Class1();
            con = new SqlConnection(objclass.arun_con());
            con.Open();
            //SqlDataAdapter ad = new SqlDataAdapter("SELECT pcode,patient_name,age,sex,doctor,date_exam from patient_master WHERE pcode = '"+cbopcode.Text+"'", con);
            SqlDataAdapter ad = new SqlDataAdapter("select b.pcode,b.patient_name,b.date_exam,b.scn as telphoneno,b.age,b.sex,b.month_year,b.doctor,b.tpt,a.note,a.pcode,a.note_header,a.note_footer from notepad a,patient_master b where (a.pcode=b.pcode) and b.pcode='" + cbopcode.Text + "'  order by b.pcode  ", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            FileStream fs = new FileStream("D:/plain.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            //sw.WriteLine("<table border='1' style='font-size:14px;'>");
            sw.WriteLine("");

            //sw.WriteLine("<tr style='font-weight:bold;'>");
            //sw.WriteLine("<tr style='font-size:14px;'>" + dt.Rows[i]["note_header"].ToString() + "");


            sw.WriteLine("");

            //String dd= dt.Rows[i]["Date_Exam"].ToString().Substring ()
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            sw.WriteLine("______________________________________________________________________________________");
            sw.WriteLine("");
            sw.WriteLine("Regd.No. : " + dt.Rows[i]["pcode"].ToString() + "                                    " + "Date : " + dt.Rows[i]["Date_Exam"].ToString() + "");
            //sw.WriteLine("Regd.No. " + dt.Rows[i]["pcode"].ToString() + "");
            //sw.WriteLine("");
            // sw.WriteLine("");
            sw.WriteLine("Name     : " + dt.Rows[i]["patient_name"].ToString() + "                       " + "Age : " + dt.Rows[i]["Age"].ToString() + " " + dt.Rows[i]["month_year"].ToString() + "   " + "Sex : " + dt.Rows[i]["Sex"].ToString());
            //sw.WriteLine("Sex " + dt.Rows[i]["Sex"].ToString() + "             ");

            //sw.WriteLine("Report Date " + dt.Rows[i]["Date_Exam"].ToString() + "");
            //sw.WriteLine("");
            //sw.WriteLine("");
            sw.WriteLine("Ref.Dr.  : " + dt.Rows[i]["Doctor"].ToString() + "");
            sw.WriteLine("______________________________________________________________________________________");
            //}
            sw.WriteLine("");
            //sw.WriteLine("");
            //sw.WriteLine("");
            //sw.WriteLine("");

            sw.WriteLine("" + dt.Rows[i]["note"].ToString() + "");
            sw.WriteLine("");


            sw.Close();
            fs.Close();
            System.Diagnostics.Process.Start("d:/plain.txt"); 

       
        }

        private void rndclosenotepad_Click(object sender, EventArgs e)
        {
            crystalReportViewer4.Visible = false;
            this.Close();
        }

        private void btnview1_Click(object sender, EventArgs e)
        {
             //private void CreateDocument()
        //{
            //try
            //{
        //        //Create an instance for word app
        //        Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();

        //        //Set animation status for word application
        //        winword.ShowAnimation = false;

        //        //Set status for word application is to be visible or not.
        //        winword.Visible = false;
                
        //        //Create a missing variable for missing value
        //        object missing = System.Reflection.Missing.Value;

        //        //Create a new document
        //        Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);
                
        //        //Add header into the document
        //        foreach (Microsoft.Office.Interop.Word.Section section in document.Sections)
        //        {
        //            //Get the header range and add the header details.
        //            Microsoft.Office.Interop.Word.Range headerRange = section.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
        //            headerRange.Fields.Add(headerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
        //            headerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
        //            headerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlue;
        //            headerRange.Font.Size = 10;
        //            headerRange.Text = "Header text goes here";
        //        }

        //        //Add the footers into the document
        //        foreach (Microsoft.Office.Interop.Word.Section wordSection in document.Sections)
        //        {
        //            //Get the footer range and add the footer details.
        //            Microsoft.Office.Interop.Word.Range footerRange = wordSection.Footers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
        //            footerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdDarkRed;
        //            footerRange.Font.Size =10;
        //            footerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
        //            footerRange.Text = "Footer text goes here";
        //        }

        //        //adding text to document
        //        document.Content.SetRange(0, 0);
        //        document.Content.Text = "This is test document "+ Environment.NewLine;
                
        //        //Add paragraph with Heading 1 style
        //        Microsoft.Office.Interop.Word.Paragraph para1 = document.Content.Paragraphs.Add(ref missing);                
        //        object styleHeading1 = "Heading 1";
        //        para1.Range.set_Style(ref styleHeading1);                
        //        para1.Range.Text = "Para 1 text";
        //        para1.Range.InsertParagraphAfter();

        //        //Add paragraph with Heading 2 style
        //        Microsoft.Office.Interop.Word.Paragraph para2 = document.Content.Paragraphs.Add(ref missing);
        //        object styleHeading2 = "Heading 2";
        //        para2.Range.set_Style(ref styleHeading2);
        //        para2.Range.Text = "Para 2 text";
        //        para2.Range.InsertParagraphAfter();

        //        //Create a 5X5 table and insert some dummy record
        //       Table firstTable = document.Tables.Add(para1.Range, 5, 5, ref missing, ref missing);
                
        //        firstTable.Borders.Enable = 1;
        //        foreach (Row row in firstTable.Rows)
        //        {
        //            foreach (Cell cell in row.Cells)
        //            {
        //                //Header row
        //                if (cell.RowIndex == 1)
        //                {
        //                    cell.Range.Text = "Column " + cell.ColumnIndex.ToString();
        //                    cell.Range.Font.Bold = 1;
        //                    //other format properties goes here
        //                    cell.Range.Font.Name = "verdana";
        //                    cell.Range.Font.Size = 10;
        //                    //cell.Range.Font.ColorIndex = WdColorIndex.wdGray25;                            
        //                    cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
        //                    //Center alignment for the Header cells
        //                    cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
        //                    cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                            
        //                }
        //                //Data row
        //                else
        //                {
        //                    cell.Range.Text = (cell.RowIndex - 2 + cell.ColumnIndex).ToString();
        //                }
        //            }
        //        }
                
        //        //Save the document
        //        object filename = @"c:\temp1.docx";
        //        document.SaveAs2(ref filename);
        //        document.Close(ref missing, ref missing, ref missing);
        //        document = null;
        //        winword.Quit(ref missing, ref missing, ref missing);
        //        winword = null;
        //        MessageBox.Show("Document created successfully !");
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    MessageBox.Show(ex.Message);
        //    //}
        //}

            
            
            
            
            
            ///*** below is a new programme test it later
            //Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            //Microsoft.Office.Interop.Word.Document doc = app.Documents.Open(@"D://jh.txt");
            //object missing = System.Reflection.Missing.Value;
            //doc.Content.Text += textBox1.Text;
            //app.Visible = true;    //Optional
            //doc.Save();
            //this.Close();    
            


            //**** old correct routine start 



            //string st = pidr.ToString().Trim();
            //string fl = st + ".docx";
            //System.Diagnostics.Process.Start(fl); 
            ////Microsoft.Office.Interop.Word.Tables.Add(Microsoft.Office.Interop.Word.Range,System.Int32,System.Int32,System.Object,System.Object); 
            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */
            //object oEndOfDoc = fl; 
            // added here ****************

            //string strQuery = "select pcode,Name,age,sex from patient_master where pcode='" + pidr + "'";
            //cmd = new SqlCommand(strQuery);
            //cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1;
            //DataTable dt = GetData(cmd);
            //if (dt != null)
            //{
            //    download(dt);
            //}
            
            
            
            //String strConnString = System.Configuration.ConfigurationManager
            //.ConnectionStrings["conString"].ConnectionString;
            Class1 objclass = new Class1();
            con = new SqlConnection(objclass.arun_con());
            //SqlConnection con = new SqlConnection(strConnString);
           
            SqlDataAdapter sda = new SqlDataAdapter("select pcode,patient_name,sex,age,doctor,date_exam,month_year,Scn,Tpt,operator,referal from patient_master where pcode='" + pidr + "'", con);
            //cmd.CommandType = CommandType.Text;
            //cmd.Connection = con;
            //try
            //{
                con.Open();
            DataTable dt = new DataTable();
                //sda.SelectCommand = cmd;
                sda.Fill(dt);


                DateTime dtf1;
                String dd = dtreport.Text.Substring(0, 2).ToString();
                String mm = dtreport.Text.Substring(3, 2).ToString();
                String yy = dtreport.Text.Substring(6, 4).ToString();
               String tt1 = dtreport.Text.Substring(11, 8).ToString();
                dtf1 = DateTime.ParseExact(dd + "/" + mm + "/" + yy, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                //DateTimePicker timePicker = new DateTimePicker();
                //timePicker.Format = dtreport.CustomFormat;
                //timePicker.CustomFormat = "HH:mm"; // Only use hours and minutes
                ////timePicker.ShowUpDown = true;

                //dtreport.Format = DateTimePickerFormat.Time;
                //dtreport..ShowUpDown = true;
                //String dttime = dtreport.Format.ToString().Substring (11,5);
            
            
            //added upto this
            
            
            
            
            //Start Word and create a new document.
//            Word._Application oWord;
//            Word._Document oDoc;
//            oWord = new Word.Application();
//            oWord.Visible = true;
           //oWord.Height= 100;
//           oWord.Width = 100;
//            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
//                ref oMissing, ref oMissing);
//
//            Word.Paragraph oPara1;
//            
//            object oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
//            oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
            //oDoc.PageSetup.LeftMargin=  f(0.5);
            //oDoc.PageSetup.RightMargin=  0.5;
//            oPara1.Range.Text = "";
//            oPara1.Range.Font.Name = "Times New Roman";
//            oPara1.Range.Font.Size = 10;
//            oPara1.Range.Font.Bold = 1;
//
            //oPara1.Range.Font.Size = 12;
            //oPara1.Range.Font.Bold = 0;
//            
            //oPara1.Format.SpaceAfter = 24;
//            oPara1.Range.InsertParagraphAfter();
//
//            Word.Paragraph oPara2;
//            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
//            oPara2 = oDoc.Content.Paragraphs.Add(ref oRng);
//            oPara2.Range.Text = "";
//            oPara2.Range.Font.Name = "Times New Roman";
//            oPara2.Range.Font.Size = 10;
//            oPara2.Range.Font.Bold = 1;
            //oPara2.Format.SpaceAfter = 24;
//            oPara2.Range.InsertParagraphAfter();
//            Word.Paragraph oPara3;
//            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
//            oPara3 = oDoc.Content.Paragraphs.Add(ref oRng);
//            oPara3.Range.Text = "--------------------------------------------------------------------------------------------------------------------------------------------";
//            oPara3.Range.Font.Size = 10;
            //oPara3.Range.Font.Bold = 1;
            //oPara3.Format.SpaceAfter = 24;
//            oPara3.Range.InsertParagraphAfter();
//            
//            
//            
            //Insert a paragraph at the beginning of the document.
//            Word.Paragraph oPara4;
//            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
//            oPara4 = oDoc.Content.Paragraphs.Add(ref oRng);
//     
//            oPara4.Range.Text = "Regd.No.:  " + dt.Rows[0][0].ToString() + "                                                                                                    "+"Report Date :   " + dd+"/"+mm+"/"+yy+"  "+tt1 ;
            //oPara1.Range.Text = "";
//            oPara4.Range.Font.Name = "Times New Roman";
//            oPara4.Range.Font.Size = 10;
//            oPara4.Range.Font.Bold = 1;
            //oPara4.Format.SpaceAfter = 24;    //24 pt spacing after paragraph.
//            oPara4.Range.InsertParagraphAfter();
            //pcode,patient_name,sex,age,doctor,date_exam,month_year,Scn,Tpt,operator,referal
            //Insert a paragraph at the end of the document.
//            Word.Paragraph oPara5;
//            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
//            oPara5 = oDoc.Content.Paragraphs.Add(ref oRng);
//            int lch = dt.Rows[0][1].ToString().Trim().Length;
//            int lch1 = 100 - lch-4;
            //String pnm = dt.Rows[0][1].ToString().Trim().PadRight(65);
            //pnm = pnm.Substring(1, 65);
//            String p5 = "Name       :  " + dt.Rows[0][1].ToString().TrimEnd().PadRight(lch1) + "Receive Date :  " + dt.Rows[0][8].ToString();
//            oPara5.Range.Text =p5;
//                oPara5.Range.Font.Name = "Times New Roman";
//            oPara5.Range.Font.Size = 10;
//            oPara5.Range.Font.Bold = 1;
            //oPara5.Format.SpaceAfter = 24;
//            oPara5.Range.InsertParagraphAfter();
//
//
            //Insert another paragraph.
//            Word.Paragraph oPara6;
//            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
//            oPara6 = oDoc.Content.Paragraphs.Add(ref oRng);
            //String pdoct = dt.Rows[0][4].ToString().Trim().PadRight(65);
//             lch = dt.Rows[0][4].ToString().Trim().Length;
//            lch1 = 100 - lch;
            //pdoct = pdoct.Substring(1, 65);
//
//            oPara6.Range.Text = "Ref Dr.     :  " + dt.Rows[0][4].ToString().Trim().PadRight(lch1 ) + "Age   :   " + dt.Rows[0][3].ToString().Trim() + " " + dt.Rows[0][6].ToString().Trim() + "      Sex   :   " + dt.Rows[0][2].ToString();
            //oPara6.Range.Font.Name = "";
//            oPara6.Range.Font.Name = "Times New Roman";
//            oPara6.Range.Font.Size = 10;
//            oPara6.Range.Font.Bold = 1;
            //oPara6.Format.SpaceAfter = 24;
//            oPara6.Range.InsertParagraphAfter();
//
            //Insert another paragraph.
//            Word.Paragraph oPara7;
//            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
//            oPara7 = oDoc.Content.Paragraphs.Add(ref oRng);
//            oPara7.Range.Text = "--------------------------------------------------------------------------------------------------------------------------------------------";
//            oPara7.Range.Font.Name = "Times New Roman";
//            oPara7.Range.Font.Size = 10;
            //oPara7.Range.Font.Bold = 1;
            //oPara7.Format.SpaceAfter = 24;
//            oPara7.Range.InsertParagraphAfter();
            // i am omiting all below this ********
 
            //Insert a 3 x 5 table, fill it with data, and make the first row
            //bold and italic.
            //Word.Table oTable;
            //Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            //oTable = oDoc.Tables.Add(wrdRng, 3, 5, ref oMissing, ref oMissing);
            //oTable.Range.ParagraphFormat.SpaceAfter = 6;
            int r, c;
            string strText;
            //for (r = 1; r <= 3; r++)
            //    for (c = 1; c <= 5; c++)
            //    {
            //        strText = "r" + r + "c" + c;
            //        oTable.Cell(r, c).Range.Text = strText;
            //    }
            //oTable.Rows[1].Range.Font.Bold = 1;
            //oTable.Rows[1].Range.Font.Italic = 1;

            ////Add some text after the table.
            //Word.Paragraph oPara5;
            //oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            //oPara5 = oDoc.Content.Paragraphs.Add(ref oRng);
            //oPara5.Range.InsertParagraphBefore();
            //oPara5.Range.Text = "And here's another table:";
            //oPara5.Format.SpaceAfter = 24;
            //oPara5.Range.InsertParagraphAfter();

            ////Insert a 5 x 2 table, fill it with data, and change the column widths.
            //wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            //oTable = oDoc.Tables.Add(wrdRng, 5, 2, ref oMissing, ref oMissing);
            //oTable.Range.ParagraphFormat.SpaceAfter = 6;
            //for (r = 1; r <= 5; r++)
            //    for (c = 1; c <= 2; c++)
            //    {
            //        strText = "r" + r + "c" + c;
            //        oTable.Cell(r, c).Range.Text = strText;
            //    }
            //oTable.Columns[1].Width = oWord.InchesToPoints(2); //Change width of columns 1 & 2
            //oTable.Columns[2].Width = oWord.InchesToPoints(3);

            ////Keep inserting text. When you get to 7 inches from top of the
            ////document, insert a hard page break.
            //object oPos;
            //double dPos = oWord.InchesToPoints(7);
            //oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range.InsertParagraphAfter();
            //do
            //{
            //    wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            //    wrdRng.ParagraphFormat.SpaceAfter = 6;
            //    wrdRng.InsertAfter("A line of text");
            //    wrdRng.InsertParagraphAfter();
            //    oPos = wrdRng.get_Information
            //                   (Word.WdInformation.wdVerticalPositionRelativeToPage);
            //}
            //while (dPos >= Convert.ToDouble(oPos));
            //object oCollapseEnd = Word.WdCollapseDirection.wdCollapseEnd;
            //object oPageBreak = Word.WdBreakType.wdPageBreak;
            //wrdRng.Collapse(ref oCollapseEnd);
            //wrdRng.InsertBreak(ref oPageBreak);
            //wrdRng.Collapse(ref oCollapseEnd);
            //wrdRng.InsertAfter("We're now on page 2. Here's my chart:");
            //wrdRng.InsertParagraphAfter();

            //Insert a chart.
            //Word.InlineShape oShape;
            //object oClassType = "MSGraph.Chart.8";
            //wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            //oShape = wrdRng.InlineShapes.AddOLEObject(ref oClassType, ref oMissing,
            //    ref oMissing, ref oMissing, ref oMissing,
            //    ref oMissing, ref oMissing, ref oMissing);

            ////Demonstrate use of late bound oChart and oChartApp objects to
            ////manipulate the chart object with MSGraph.
            //object oChart;
            //object oChartApp;
            //oChart = oShape.OLEFormat.Object;
            //oChartApp = oChart.GetType().InvokeMember("Application",
            //    BindingFlags.GetProperty, null, oChart, null);

            ////Change the chart type to Line.
            //object[] Parameters = new Object[1];
            //Parameters[0] = 4; //xlLine = 4
            //oChart.GetType().InvokeMember("ChartType", BindingFlags.SetProperty,
            //    null, oChart, Parameters);

            ////Update the chart image and quit MSGraph.
            //oChartApp.GetType().InvokeMember("Update",
            //    BindingFlags.InvokeMethod, null, oChartApp, null);
            //oChartApp.GetType().InvokeMember("Quit",
            //    BindingFlags.InvokeMethod, null, oChartApp, null);
            ////... If desired, you can proceed from here using the Microsoft Graph 
            ////Object model on the oChart and oChartApp objects to make additional
            ////changes to the chart.

            ////Set the width of the chart.
            //oShape.Width = oWord.InchesToPoints(6.25f);
            //oShape.Height = oWord.InchesToPoints(3.57f);

            //Add text after the chart.
            //wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            //wrdRng.InsertParagraphAfter();
            //wrdRng.InsertAfter("THE END.");

            //Close this form.
            this.Close();
     


        //private void FindAndReplace(Word.Application wordApp,
        //     object findText, object replaceText)
        //{
        //    object matchCase = true;
        //    object matchWholeWord = true;
        //    object matchWildCards = false;
        //    object matchSoundsLike = false;
        //    object matchAllWordForms = false;
        //    object forward = true;
        //    object format = false;
        //    object matchKashida = false;
        //    object matchDiacritics = false;
        //    object matchAlefHamza = false;
        //    object matchControl = false;
        //    object read_only = false;
        //    object visible = true;
        //    object replace = 2;
        //    object wrap = 1;
        //    wordApp.Selection.Find.Execute(ref findText, ref matchCase,
        //        ref matchWholeWord, ref matchWildCards, ref matchSoundsLike,
        //        ref matchAllWordForms, ref forward, ref wrap, ref format,
        //        ref replaceText, ref replace, ref matchKashida,
        //                ref matchDiacritics,
        //        ref matchAlefHamza, ref matchControl);
       }

        private void btnwrdview2_Click(object sender, EventArgs e)
        {


            //OpenFileDialog dlg = new OpenFileDialog();
            //dlg.ShowDialog();

            //if (dlg.ShowDialog() == DialogResult.OK)
            //{
            //    string fileName;
            //    fileName = dlg.FileName;
            //    System.Diagnostics.Process.Start(fileName);
            //    //MessageBox.Show(fileName);
            //}

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "goto program folder"; //not mandatory

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                sSelectedFolder = fbd.SelectedPath;
            }
            else
            {
                sSelectedFolder = string.Empty;
            }

            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            //choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                sSelectedFile = choofdlog.FileName;
                System.Diagnostics.Process.Start(sSelectedFile);
            }
            else
            {
                sSelectedFile = string.Empty;
                MessageBox.Show("No File Selected");
            }
            





            //string st = pidr.ToString().Trim();
            //string fl = st + ".docx";
            //if (File.Exists((string)fl))
            //{
            //    System.Diagnostics.Process.Start(fl);
            //}
            //else
            //{
            //    MessageBox.Show("Create file 1st!!");
            //}
                //if (Offer.docx.ShowDialog() == true)
            //{
            //    // Open document 
            //    string originalfilename = System.IO.Path.GetFullPath(openFile.FileName);

            //    if (OpenFile.CheckFileExists && new[] { ".docx", ".doc", ".txt", ".rtf" }.Contains(Path.GetExtension(originalfilename).ToLower()))
            //    {
            //        Microsoft.Office.Interop.Word.Application wordObject = new Microsoft.Office.Interop.Word.Application();
            //        object File = originalfilename;
            //        object nullobject = System.Reflection.Missing.Value;
            //        Microsoft.Office.Interop.Word.Application wordobject = new Microsoft.Office.Interop.Word.Application();
            //        wordobject.DisplayAlerts = Microsoft.Office.Interop.Word.WdAlertLevel.wdAlertsNone;
            //        Microsoft.Office.Interop.Word._Document docs = wordObject.Documents.Open(ref File, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject);
            //        docs.ActiveWindow.Selection.WholeStory();
            //        docs.ActiveWindow.Selection.Copy();
            //        rtfMain.Document.Paste();
            //        docs.Close(ref nullobject, ref nullobject, ref nullobject);
            //        wordobject.Quit(ref nullobject, ref nullobject, ref nullobject);


            //        MessageBox.Show("file loaded");
            //    }
            //} 

//-----------------
            //Word.Application wordApp = new Word.Application();
            //object filename = @"C:\temp\Offer.docx";
            //object missing = Type.Missing;
            //Word.Document doc = wordApp.Documents.Open(ref filename, ref missing, ref missing, ref missing, ref missing,
            //    ref missing, ref missing, ref missing, ref missing, ref missing,
            //    ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
            //object what = Word.WdGoToItem.wdGoToPage;
            //object which = Word.WdGoToDirection.wdGoToAbsolute;
            //object count = 1;
            //object sentence = Word.WdUnits.wdSentence;
            //doc.ActiveWindow.Selection.GoTo(ref what, ref which, ref count, ref missing);
            //object index = "\\Page";
            //Word.Range rng = doc.Bookmarks.get_Item(ref index).Range;
            //rng.Copy();
            //richTextBox1.Paste();
            //doc.Close(ref missing, ref missing, ref missing);
            ////Marshal.ReleaseComObject(wordApp);
            ////object.Quit(ref nullobject, ref nullobject, ref nullobject);
      
      //--------------------------        
            //Microsoft.Office.Interop.Word.ApplicationClass wordApp = new ApplicationClass();
            //object file = "c:\\offer.docx";
            //object nullobj = System.Reflection.Missing.Value;

            //Microsoft.Office.Interop.Word.Document doc = Word.Document.Open(
            //    ref file, ref nullobj, ref nullobj,
            //    ref nullobj, ref nullobj, ref nullobj,
            //    ref nullobj, ref nullobj, ref nullobj,
            //    ref nullobj, ref nullobj, ref nullobj);
            //doc.ActiveWindow.Selection.WholeStory();
            //doc.ActiveWindow.Selection.Copy();
            //IDataObject data = Clipboard.GetDataObject();
            //richTextBox1.Text = data.GetData(DataFormats.Text).ToString();
            //doc.Close(ref nullobj, ref nullobj, ref nullobj);
            //wordApp.Quit(ref nullobj, ref nullobj, ref nullobj);
//-----------------
            //Word.ApplicationClass wordApp = new ApplicationClass();
            ////Word.ApplicationClass is to access the word application
            //object file = path;
            //object nullobj = System.Reflection.Missing.Value;
            //Word.Document doc = wordApp.Documents.Open(
            //ref file, ref nullobj, ref nullobj,
            //                                      ref nullobj, ref nullobj, ref nullobj,
            //                                      ref nullobj, ref nullobj, ref nullobj,
            //                                      ref nullobj, ref nullobj, ref nullobj);
            //doc.ActiveWindow.Selection.WholeStory();
            //doc.ActiveWindow.Selection.Copy();
            //IDataObject data = Clipboard.GetDataObject();
            //txtFileContent.Text = data.GetData(DataFormats.Text).ToString();
            //doc.Close();
        //------------------------

            //  create offer letter
            //try
            //{
                //  Just to kill WINWORD.EXE if it is running
                //killprocess("winword");
                //  copy letter format to temp.doc
        //        File.Copy("c:\\Offer.docx", "c:\\temp.docx", true);
        //        //  create missing object
        //        object missing = System.Reflection.Missing.Value;
        //        //  create Word application object
        //        Word.Application wordApp = new Word.ApplicationClass();
        //        //  create Word document object
        //        Word.Document aDoc = null;
        //        //  create & define filename object with temp.doc
        //        object filename = "c:\\temp.docx";
        //        //  if temp.doc available
        //        if (File.Exists((string)filename))
        //        {
        //            object readOnly = false;
        //            object isVisible = false;
        //            //  make visible Word application
        //            wordApp.Visible = false;
        //            //  open Word document named temp.doc
        //            aDoc = wordApp.Documents.Open(ref filename, ref missing,
        //ref readOnly, ref missing, ref missing, ref missing,
        //ref missing, ref missing, ref missing, ref missing,
        //ref missing, ref isVisible, ref missing, ref missing,
        //ref missing, ref missing);
        //            aDoc.Activate();
        //            //  Call FindAndReplace()function for each change
        //            //this.FindAndReplace(wordApp, "<Date>", dtpDate.Text);
        //            //this.FindAndReplace(wordApp, "<Name>", txName.Text.Trim());
        //            this.FindAndReplace(wordApp, "rerffsdfsdf",
        //        richTextBox1.Text.Trim());
        //            //  save temp.doc after modified
        //            aDoc.Save();
        //        }
        //        else
        //            MessageBox.Show("File does not exist.",
        //    "No File", MessageBoxButtons.OK,
        //    MessageBoxIcon.Information);
        //        //killprocess("winword");
          //}
        //    catch (Exception)
        //    {
        //        MessageBox.Show("Error in process.", "Internal Error",
        //MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
            
            
            
         //   }

      
        //-all start

        // Read the file and convert it to Byte Array

 }
//------------------
//private Boolean InsertData(SqlCommand cmd)
//{

   
//        }
//----------------
//private Boolean InsertUpdateData(SqlCommand cmd)
//{
//    //String strConnString = System.Configuration.ConfigurationManager
//    //.ConnectionStrings["conString"].ConnectionString;
//    //SqlConnection con = new SqlConnection(strConnString);
//    //Class1 objclass = new Class1();
//    //con = new SqlConnection(objclass.arun_con());
//    //cmd.CommandType = CommandType.Text;
//    //cmd.Connection = con;
//    //try
//    //{
//    //    con.Open();
//    //    cmd.ExecuteNonQuery();
//    //    return true;
//    //}
//    //catch (Exception ex)
//    //{
//    //    MessageBox.Show(ex.Message);
//    //    return false;
//    //}
//    //finally
//    //{
//    //    con.Close();
//    //    con.Dispose();
//    //}
//}


//private Boolean InsertUpdateData1(SqlCommand cmd)
//{
//    //------------------
//    string strQuery = "select Name, ContentType, Data from notepad1 where id=@id";
//    cmd = new SqlCommand(strQuery);
//    cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1;
//    DataTable dt = GetData(cmd);
//    if (dt != null)
//    {
//        download(dt);
//    }
//}
//------------------------
//private DataTable GetData(SqlCommand cmd)
//{
//    //DataTable dt = new DataTable();
//    ////String strConnString = System.Configuration.ConfigurationManager
//    ////.ConnectionStrings["conString"].ConnectionString;
//    //Class1 objclass = new Class1();
//    //con = new SqlConnection(objclass.arun_con());
//    ////SqlConnection con = new SqlConnection(strConnString);
//    //SqlDataAdapter sda = new SqlDataAdapter();
//    //cmd.CommandType = CommandType.Text;
//    //cmd.Connection = con;
//    //try
//    //{
//    //    con.Open();
//    //    sda.SelectCommand = cmd;
//    //    sda.Fill(dt);
//    //    return dt;
//    //}
//    //catch
//    //{
//    //    return null;
//    //}
//    //finally
//    //{
//    //    con.Close();
//    //    sda.Dispose();
//    //    con.Dispose();
//    //}
//}
//------------------
private void download (DataTable dt)
{
    
    //Byte[] bytes = (Byte[])dt.Rows[0]["Data"];
  //  MemoryStream stream = new MemoryStream(bytes);
  //  // retrieve RTF from MemoryStream
  //  stream.Seek(0, SeekOrigin.Begin);
  //  StreamReader sr = new StreamReader(stream);
  //String rtf = sr.ReadToEnd();
  //  //txtnotepad.Text  = sr.ReadToEnd();

    //byte[] binaryString = (byte[])reader[1];

    // if the original encoding was ASCII
    //string ascii = Encoding.ASCII.GetString(bytes);

    // if the original encoding was UTF-8
   // string utf = Encoding.UTF8.GetString(bytes );

    // if the original encoding was UTF-16
    //string utfs = Encoding.Unicode.GetString(bytes );
    
    
    //myImage = (byte[])ds.Tables[0].Rows[0]["imgdata"];
    //MemoryStream stream = new MemoryStream(myImage);
    //pictureBox2.Image = Byte[].FromStream(stream);
    
    
    
    
    //StreamWriter sw = new StreamWriter(bytes);
    //sw.WriteLine("" + (Byte[])dt.Rows[0]["Data"] + "");
    //sw.WriteLine("");


    //Response.Buffer = true;
    //Response.Charset = "";
    //Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //Response.ContentType = dt.Rows[0]["ContentType"].ToString();
    //Response.AddHeader("content-disposition", "attachment;filename="
    //+ dt.Rows[0]["Name"].ToString());
    //Response.BinaryWrite(bytes);
    //Response.Flush();
    //Response.End();
}

private void btnwrdreadwrite_Click(object sender, EventArgs e)
{
    //string filePath = ("c://offer.docx");
    //string filename = Path.GetFileName(filePath);

    //FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
    //BinaryReader br = new BinaryReader(fs);
    //Byte[] bytes = br.ReadBytes((Int32)fs.Length);
    //br.Close();
    //fs.Close();

    ////insert the file into database
    //string strQuery = "insert into notepad1(Pcode,Name, ContentType, Data) values (@pcode,@Name, @ContentType, @Data)";
    //cmd = new SqlCommand(strQuery);
    //cmd.Parameters.Add("@Pcode", SqlDbType.Int).Value = pidr;
    //cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = filename;
    //cmd.Parameters.Add("@ContentType", SqlDbType.VarChar).Value = "application/vnd.ms-word";
    //cmd.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes;
    //InsertUpdateData(cmd);
}

private void btnwrdprint_Click(object sender, EventArgs e)
{
    //string strQuery = "select Name, ContentType, Data from notepad1 where pcode='" + pidr + "'";
    //cmd = new SqlCommand(strQuery);
    ////cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1;
    //DataTable dt = GetData(cmd);
    //if (dt != null)
    //{
    //    download(dt);
    //}
}

//private void timer1_Tick(object sender, EventArgs e)
//{
//    //DateTime datetime = DateTime.Now;
//    //this.dtreport.Text = datetime.ToString();
//}

private void btnprintct_Click(object sender, EventArgs e)
{
    Frmrepcytology fcyto = new Frmrepcytology();
    fcyto.Show();
}

private void crystalReportViewer1_Load_1(object sender, EventArgs e)
{

}

private void BTN_EXURINE_Click(object sender, EventArgs e)
{


    da = new SqlDataAdapter("select cc,comp,address,year_start,year_end,pathologist,biochemist,telphoneno,email,cstno,address1,faxno from company", con);
    ds2 = new DataSet();
    da.Fill(ds2);

    da.Dispose();
    btnclosecrv.Visible = true;
    crystalReportViewer1.Visible = true;

    String s1 = "select a.cc,a.patient_name,a.pcode,a.sex,a.age,a.doctor,a.date_exam as Dt_Report,a.month_year,b.UP_color,b.UP_reaction,b.UP_specificgravity,b.UC_sugar,b.UC_albumin,b.UC_phosphate,b.UC_chyle,b.UC_ketonebodies,b.UC_bilesalts,b.UC_bilepigment,b.UM_puscells,b.UM_epithcells,b.UM_rbc,b.UM_casts,b.UM_crystals,b.UM_bacterial,b.UM_spermatozoa,b.UM_mf_tv,b.UM_others,b.UU_urine_b_hcg,b.UA_urine_albumin,b.UN_nasalsmear,b.ur_imp,a.scn,a.tpt,b.ur_cotinine,b.up_specificgravity_onr,b.uc_php,b.us_sputumafb,b.uc_phosphate_onr from patient_master a , urine b where a.pcode=b.pcode and  a.pcode='" + cbopcode.Text + "'   order by b.pcode,a.date_exam";
    da = new SqlDataAdapter(s1, con);
    ds = new DataSet();
    da.Fill(ds, "Pathology_Urine");
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
        dt.Columns.Add("barcode", System.Type.GetType("System.Byte[]"));

        String qrdata = cbopcode.Text.Trim();
        BarcodeLib.Barcode.Linear qrcode = new BarcodeLib.Barcode.Linear();
        qrcode.Type = BarcodeLib.Barcode.BarcodeType.CODE39;
        qrcode.Data = qrdata;

        // Save & output QR Code barcode image to your system
        qrcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;
        byte[] imageData = qrcode.drawBarcodeAsBytes();
        //byte[] barcode = qrcode.drawBarcodeAsBytes();
           
        
        
        
        
        
        gpatient_name = ds.Tables[0].Rows[i][1].ToString();
        gcode = Convert.ToInt32(ds.Tables[0].Rows[i][2].ToString());
        gsex = ds.Tables[0].Rows[i][3].ToString();
        gage = Convert.ToInt32(ds.Tables[0].Rows[i][4].ToString());
        gdoctor = ds.Tables[0].Rows[i][5].ToString();
        gdt_report = Convert.ToDateTime(ds.Tables[0].Rows[i][6].ToString());
        gmnyr = ds.Tables[0].Rows[i][7].ToString();
        gscn = ds.Tables[0].Rows[i][31].ToString();
        gtpt = ds.Tables[0].Rows[i][32].ToString();

        if (ds.Tables[0].Rows[i][10].ToString() != "")
        {
            Ggrp = "1.MACROSCOPIC-EX-";
            Gdesc = "MACROSCOPIC-EX-";
            Gdesc1 = "Volume";
            Gresult = ds.Tables[0].Rows[i][10].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }
        if (ds.Tables[0].Rows[i][8].ToString() != "")
        {
            Ggrp = "1.MACROSCOPIC-EX-";
            Gdesc = "MACROSCOPIC-EX-";
            Gdesc1 = "Colour";
            Gresult = ds.Tables[0].Rows[i][8].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();

        }
        if (ds.Tables[0].Rows[i][37].ToString() != "")
        {
            Ggrp = "1.MACROSCOPIC-EX-";
            Gdesc = "MACROSCOPIC-EX-";
            Gdesc1 = "Appearance ";
            Gresult = ds.Tables[0].Rows[i][37].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }






        if (ds.Tables[0].Rows[i][25].ToString() != "")
        {
            Ggrp = "1.MACROSCOPIC-EX-";
            Gdesc = "MACROSCOPIC-EX-";
            Gdesc1 = "Sediment";
            Gresult = ds.Tables[0].Rows[i][25].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }
        if (ds.Tables[0].Rows[i][34].ToString() != "")
        {
            Ggrp = "1.MACROSCOPIC-EX-";
            Gdesc = "MACROSCOPIC-EX-";
            Gdesc1 = "Sp. Gravity";
            Gresult = ds.Tables[0].Rows[i][34].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }

        if (ds.Tables[0].Rows[i][35].ToString() != "")
        {
            Ggrp = "2.CHEMICAL-EX-";
            Gdesc = "CHEMICAL-EX-";
            Gdesc1 = "PH%";
            Gresult = ds.Tables[0].Rows[i][35].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }


        if (ds.Tables[0].Rows[i][9].ToString() != "")
        {
            Ggrp = "2.CHEMICAL-EX-";
            Gdesc = "CHEMICAL-EX-";
            Gdesc1 = "Reaction";
            Gresult = ds.Tables[0].Rows[i][9].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }

        if (ds.Tables[0].Rows[i][12].ToString() != "")
        {
            Ggrp = "2.CHEMICAL-EX-";
            Gdesc = "CHEMICAL-EX-";
            Gdesc1 = "Albumin";
            Gresult = ds.Tables[0].Rows[i][12].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }

        if (ds.Tables[0].Rows[i][11].ToString() != "")
        {
            Ggrp = "2.CHEMICAL-EX-";

            Gdesc = "CHEMICAL-EX-";
            Gdesc1 = "Sugar";
            Gresult = ds.Tables[0].Rows[i][11].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }


        if (ds.Tables[0].Rows[i][13].ToString() != "")
        {
            Ggrp = "2.CHEMICAL-EX-";
            Gdesc = "CHEMICAL-EX-";
            Gdesc1 = "Chyle";
            Gresult = ds.Tables[0].Rows[i][13].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }

        if (ds.Tables[0].Rows[i][14].ToString() != "")
        {
            Ggrp = "2.CHEMICAL-EX-";
            Gdesc = "CHEMICAL-EX-";
            Gdesc1 = "Phosphate";
            Gresult = ds.Tables[0].Rows[i][14].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }

        if (ds.Tables[0].Rows[i][15].ToString() != "")
        {
            Ggrp = "2.CHEMICAL-EX-";
            Gdesc = "CHEMICAL-EX-";
            Gdesc1 = "Ketone Bodies";
            Gresult = ds.Tables[0].Rows[i][15].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }
        if (ds.Tables[0].Rows[i][16].ToString() != "")
        {
            Ggrp = "2.CHEMICAL-EX-";
            Gdesc = "CHEMICAL-EX-";
            Gdesc1 = "Bile Salts";
            Gresult = ds.Tables[0].Rows[i][16].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }


        if (ds.Tables[0].Rows[i][17].ToString() != "")
        {
            Ggrp = "2.CHEMICAL-EX-";
            Gdesc = "CHEMICAL-EX-";
            Gdesc1 = "Bile Pigments";
            Gresult = ds.Tables[0].Rows[i][17].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }
        if (ds.Tables[0].Rows[i][36].ToString() != "")
        {
            Ggrp = "2.CHEMICAL-EX-";
            Gdesc = "CHEMICAL-EX-";
            Gdesc1 = "Urobilinogen";
            Gresult = ds.Tables[0].Rows[i][36].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }
        //if (ds.Tables[0].Rows[i][37].ToString() != "")
        //{
        //    Ggrp = "2.CHEMICAL-EX-";
        //    Gdesc = "CHEMICAL-EX-";
        //    Gdesc1 = "Benzodine Test";
        //    Gresult = ds.Tables[0].Rows[i][37].ToString();
        //    Gunit = "";
        //    Gnormalrange = "";
        //    Gnormalrange1 = "";
        //    ADDROW();
        //}


        if (ds.Tables[0].Rows[i][26].ToString() != "")
        {
            Ggrp = "2.CHEMICAL-EX-";
            Gdesc = "CHEMICAL-EX-";
            Gdesc1 = "Micro Filaria";
            Gresult = ds.Tables[0].Rows[i][26].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }






        if (ds.Tables[0].Rows[i][18].ToString() != "")
        {
            Ggrp = "3.MICROSCOPIC-EX-";
            Gdesc = "MICROSCOPIC-EX-";
            Gdesc1 = "Pus Cells";
            Gresult = ds.Tables[0].Rows[i][18].ToString().Trim() + "/HPF";
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }
        if (ds.Tables[0].Rows[i][19].ToString() != "")
        {
            Ggrp = "3.MICROSCOPIC-EX-";
            Gdesc = "MICROSCOPIC-EX-";
            Gdesc1 = "Epithelial Cells";
            Gresult = ds.Tables[0].Rows[i][19].ToString().Trim() + "/HPF";
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }
        if (ds.Tables[0].Rows[i][20].ToString() != "")
        {
            Ggrp = "3.MICROSCOPIC-EX-";
            Gdesc = "MICROSCOPIC-EX-";
            Gdesc1 = "R.B.C.";
            Gresult = ds.Tables[0].Rows[i][20].ToString().Trim() + "/HPF";
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }

        if (ds.Tables[0].Rows[i][21].ToString() != "")
        {
            Ggrp = "3.MICROSCOPIC-EX-";
            Gdesc = "MICROSCOPIC-EX-";
            Gdesc1 = "Casts";
            Gresult = ds.Tables[0].Rows[i][21].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }
        if (ds.Tables[0].Rows[i][22].ToString() != "")
        {
            Ggrp = "3.MICROSCOPIC-EX-";
            Gdesc = "MICROSCOPIC-EX-";
            Gdesc1 = "Crystals";
            Gresult = ds.Tables[0].Rows[i][22].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }

        if (ds.Tables[0].Rows[i][23].ToString() != "")
        {
            Ggrp = "3.MICROSCOPIC-EX-";
            Gdesc = "MICROSCOPIC-EX-";
            Gdesc1 = "Bacterial";
            Gresult = ds.Tables[0].Rows[i][23].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }
        if (ds.Tables[0].Rows[i][24].ToString() != "")
        {
            Ggrp = "3.MICROSCOPIC-EX-";
            Gdesc = "MICROSCOPIC-EX-";
            Gdesc1 = "Spermatozoa";
            Gresult = ds.Tables[0].Rows[i][24].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }
        if (ds.Tables[0].Rows[i][28].ToString() != "")
        {
            Ggrp = "3.MICROSCOPIC-EX-";
            Gdesc = "MICROSCOPIC-EX-";
            Gdesc1 = "Yeast Cells";
            Gresult = ds.Tables[0].Rows[i][28].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }

        if (ds.Tables[0].Rows[i][33].ToString() != "")
        {
            Ggrp = "3.MICROSCOPIC-EX-";
            Gdesc = "MICROSCOPIC-EX-";
            Gdesc1 = "Micral Test(UACR)";
            Gresult = ds.Tables[0].Rows[i][33].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }

        if (ds.Tables[0].Rows[i][30].ToString() != "")
        {
            Ggrp = "3.MICROSCOPIC-EX-";
            Gdesc = "MICROSCOPIC-EX-";
            Gdesc1 = "Impression";
            Gresult = ds.Tables[0].Rows[i][30].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }

        //Repurine cashbankrep = new Repurine();
        Repurinenewh cashbankrep = new Repurinenewh();
        //cashbankrep.SetDatabaseLogon("sa", "software", @".\SQLEXPRESS", "pathology2627");
        cashbankrep.SetDataSource(dt);
        crystalReportViewer1.ReportSource = cashbankrep;
        cashbankrep.SetParameterValue(0, ds2.Tables[0].Rows[0][1].ToString());
        cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows[0][2].ToString());
        cashbankrep.SetParameterValue(2, ds2.Tables[0].Rows[0][5].ToString());
        cashbankrep.SetParameterValue(3, ds2.Tables[0].Rows[0][6].ToString());

        cashbankrep.SetParameterValue(4, ds2.Tables[0].Rows[0][7].ToString());
        cashbankrep.SetParameterValue(5, ds2.Tables[0].Rows[0][8].ToString());
        cashbankrep.SetParameterValue(6, ds2.Tables[0].Rows[0][9].ToString());
        cashbankrep.SetParameterValue(7, ds2.Tables[0].Rows[0][10].ToString());
        cashbankrep.SetParameterValue(8, ds2.Tables[0].Rows[0][11].ToString());
        
        
        crystalReportViewer1.Refresh();

    }
    else
    {
        MessageBox.Show("No Records Found!!!");
    }

}

private void btnrepstoolh_Click(object sender, EventArgs e)
{
    da = new SqlDataAdapter("select cc,comp,address,year_start,year_end,pathologist,biochemist,telphoneno,email,cstno,address1,faxno from company", con);
    ds2 = new DataSet();
    da.Fill(ds2);

    da.Dispose();


    btnclosestoolcrvn.Visible = true;
    crystalReportViewer2.Visible = true;

    String s1 = ("select a.cc,a.patient_name,a.pcode,a.sex,a.age,a.doctor,a.date_exam as Dt_Report,a.month_year,b.Sp_color, b.Sp_reaction,b.Sp_Mucus,b.SH_OvaHW,b.SH_larva,b.SH_OvaRW,b.SP_EHistolytica,b.SP_ecoli,b.SP_giardia,b.SP_trichomonas, b.SM_rbc_from,  b.SM_puscells_from,b.SM_macrophase,b.SM_vegetables,b.SM_yeast,b.SM_crystal,b.SM_fataglobules,b.SM_bacterialflora,b.SH_Others,b.SC_Occultblood,b.SC_Reducingsugar,b.st_imp,a.scn,a.tpt,b.SH_hymen,b.SH_taenia,b.sm_rbc_to,b.sm_puscells_to from patient_master a,stool b where a.pcode='" + cbopcode.Text + "' and a.pcode=b.pcode order by a.pcode,a.date_exam");

    da = new SqlDataAdapter(s1, con);
    ds = new DataSet();
    da.Fill(ds, "Pathology_Stool");


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

        dt.Columns.Add("barcode", System.Type.GetType("System.Byte[]"));

        String qrdata = cbopcode.Text.Trim();
        BarcodeLib.Barcode.Linear qrcode = new BarcodeLib.Barcode.Linear();
        qrcode.Type = BarcodeLib.Barcode.BarcodeType.CODE39;
        qrcode.Data = qrdata;

        // Save & output QR Code barcode image to your system
        qrcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;
        byte[] imageData = qrcode.drawBarcodeAsBytes();
        //byte[] barcode = qrcode.drawBarcodeAsBytes();
           
        
        gpatient_name = ds.Tables[0].Rows[i][1].ToString();
        gcode = Convert.ToInt32(ds.Tables[0].Rows[i][2].ToString());
        gsex = ds.Tables[0].Rows[i][3].ToString();
        gage = Convert.ToInt32(ds.Tables[0].Rows[i][4].ToString());
        gdoctor = ds.Tables[0].Rows[i][5].ToString();
        gdt_report = Convert.ToDateTime(ds.Tables[0].Rows[i][6].ToString());
        gmnyr = ds.Tables[0].Rows[i][7].ToString();
        gscn = ds.Tables[0].Rows[i][30].ToString();
        gtpt = ds.Tables[0].Rows[i][31].ToString();
        if (ds.Tables[0].Rows[i][8].ToString() != "")
        {
            Ggrp = "1.MACROSCOPIC";
            Gdesc = "MACROSCOPIC";
            Gdesc1 = "Colour";
            Gresult = ds.Tables[0].Rows[i][8].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();

        }

        if (ds.Tables[0].Rows[i][23].ToString() != "")
        {
            Ggrp = "1.MACROSCOPIC";
            Gdesc = "MACROSCOPIC";
            Gdesc1 = "Consistency";
            Gresult = ds.Tables[0].Rows[i][23].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }




        if (ds.Tables[0].Rows[i][9].ToString() != "")
        {
            Ggrp = "1.MACROSCOPIC";
            Gdesc = "MACROSCOPIC";
            Gdesc1 = "Reaction";
            Gresult = ds.Tables[0].Rows[i][9].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }

        if (ds.Tables[0].Rows[i][17].ToString() != "")
        {
            Ggrp = "1.MACROSCOPIC";
            Gdesc = "MACROSCOPIC";
            Gdesc1 = "Blood";
            Gresult = ds.Tables[0].Rows[i][17].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }

        if (ds.Tables[0].Rows[i][10].ToString() != "")
        {
            Ggrp = "1.MACROSCOPIC";
            Gdesc = "MACROSCOPIC";
            Gdesc1 = "Mucus";
            Gresult = ds.Tables[0].Rows[i][10].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }

        if (ds.Tables[0].Rows[i][11].ToString() != "")
        {
            Ggrp = "2.MICROSCOPIC";
            Gdesc = "MICROSCOPIC";
            Gdesc1 = "Ova of Hook worm";
            Gresult = ds.Tables[0].Rows[i][11].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }
        if (ds.Tables[0].Rows[i][12].ToString() != "")
        {
            Ggrp = "2.MICROSCOPIC";
            Gdesc = "MICROSCOPIC";
            Gdesc1 = "Larva of-S.Stercoralis";
            Gresult = ds.Tables[0].Rows[i][12].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }

        if (ds.Tables[0].Rows[i][13].ToString() != "")
        {
            Ggrp = "2.MICROSCOPIC";
            Gdesc = "MICROSCOPIC";
            Gdesc1 = "Ascarris lumbricoides";
            Gresult = ds.Tables[0].Rows[i][13].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }

        if (ds.Tables[0].Rows[i][14].ToString() != "")
        {
            Ggrp = "2.MICROSCOPIC";
            Gdesc = "MICROSCOPIC";
            Gdesc1 = "E.Histolytica";
            Gresult = ds.Tables[0].Rows[i][14].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }

        if (ds.Tables[0].Rows[i][15].ToString() != "")
        {
            Ggrp = "2.MICROSCOPIC";
            Gdesc = "MICROSCOPIC";
            Gdesc1 = "E.coli";
            Gresult = ds.Tables[0].Rows[i][15].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }
        if (ds.Tables[0].Rows[i][16].ToString() != "")
        {
            Ggrp = "2.MICROSCOPIC";
            Gdesc = "MICROSCOPIC";
            Gdesc1 = "Giardia Lamblia";
            Gresult = ds.Tables[0].Rows[i][16].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }
        if (ds.Tables[0].Rows[i][34].ToString() != "")
        {
            Ggrp = "2.MICROSCOPIC";
            Gdesc = "MICROSCOPIC";
            Gdesc1 = "Trichomonas";
            Gresult = ds.Tables[0].Rows[i][34].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }
        if (ds.Tables[0].Rows[i][35].ToString() != "")
        {
            Ggrp = "2.MICROSCOPIC";
            Gdesc = "MICROSCOPIC";
            Gdesc1 = "T. trichiura";
            Gresult = ds.Tables[0].Rows[i][35].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }

        if (ds.Tables[0].Rows[i][18].ToString() != "")
        {
            Ggrp = "2.MICROSCOPIC";
            Gdesc = "MICROSCOPIC";
            Gdesc1 = "R.B.C.";
            Gresult = ds.Tables[0].Rows[i][18].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }
        if (ds.Tables[0].Rows[i][19].ToString() != "")
        {
            Ggrp = "2.MICROSCOPIC";
            Gdesc = "MICROSCOPIC";
            Gdesc1 = "Pus Cells";
            Gresult = ds.Tables[0].Rows[i][19].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }
        if (ds.Tables[0].Rows[i][20].ToString() != "")
        {
            Ggrp = "2.MICROSCOPIC";
            Gdesc = "MICROSCOPIC";
            Gdesc1 = "Macrophages";
            Gresult = ds.Tables[0].Rows[i][20].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }

        if (ds.Tables[0].Rows[i][21].ToString() != "")
        {
            Ggrp = "2.MICROSCOPIC";
            Gdesc = "MICROSCOPIC";
            Gdesc1 = "Vegetable Cells";
            Gresult = ds.Tables[0].Rows[i][21].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }
        if (ds.Tables[0].Rows[i][22].ToString() != "")
        {
            Ggrp = "2.MICROSCOPIC";
            Gdesc = "MICROSCOPIC";
            Gdesc1 = "Yeast Cells";
            Gresult = ds.Tables[0].Rows[i][22].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }
        //b.SM_yeast,b.SM_crystal,b.SM_fataglobules,b.SM_bacterialflora,b.SH_Others,b.SC_Occultblood,b.SC_Reducingsugar




        if (ds.Tables[0].Rows[i][24].ToString() != "")
        {
            Ggrp = "2.MICROSCOPIC";
            Gdesc = "MICROSCOPIC";
            Gdesc1 = "Fat globules";
            Gresult = ds.Tables[0].Rows[i][24].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }
        if (ds.Tables[0].Rows[i][25].ToString() != "")
        {
            Ggrp = "2.MICROSCOPIC";
            Gdesc = "MICROSCOPIC";
            Gdesc1 = "Bacterial Flora";
            Gresult = ds.Tables[0].Rows[i][25].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }
        if (ds.Tables[0].Rows[i][26].ToString() != "")
        {
            Ggrp = "2.MICROSCOPIC";
            Gdesc = "MICROSCOPIC";
            Gdesc1 = "Starch";
            Gresult = ds.Tables[0].Rows[i][26].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }
        if (ds.Tables[0].Rows[i][27].ToString() != "")
        {
            Ggrp = "3.CHEMICAL";
            Gdesc = "CHEMICAL";
            Gdesc1 = "Occult Blood  ( Hemospot )";
            Gresult = ds.Tables[0].Rows[i][27].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }
        if (ds.Tables[0].Rows[i][28].ToString() != "")
        {
            Ggrp = "3.CHEMICAL";
            Gdesc = "CHEMICAL";
            Gdesc1 = "Sugar (Reducing)";
            Gresult = ds.Tables[0].Rows[i][28].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }
        if (ds.Tables[0].Rows[i][29].ToString() != "")
        {
            Ggrp = "3.OTHERS";
            Gdesc = "OTHERS";
            Gdesc1 = "Impression";
            Gresult = ds.Tables[0].Rows[i][29].ToString();
            Gunit = "";

            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }

        if (ds.Tables[0].Rows[i][32].ToString() != "")
        {
            Ggrp = "2.MICROSCOPIC";
            Gdesc = "MICROSCOPIC";
            Gdesc1 = "Epithelial Cell";
            Gresult = ds.Tables[0].Rows[i][32].ToString();
            Gunit = "";

            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }
        if (ds.Tables[0].Rows[i][33].ToString() != "")
        {
            Ggrp = "2.MICROSCOPIC";
            Gdesc = "MICROSCOPIC";
            Gdesc1 = "Crystals";
            Gresult = ds.Tables[0].Rows[i][33].ToString();
            Gunit = "";

            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }



        Repstoolnew1h cashbankrep = new Repstoolnew1h();
       // cashbankrep.SetDatabaseLogon("sa", "software", @".\SQLEXPRESS", "pathology2627");
        cashbankrep.SetDataSource(dt);
        crystalReportViewer2.ReportSource = cashbankrep;
        cashbankrep.SetParameterValue(0, ds2.Tables[0].Rows[0][1].ToString());
        cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows[0][2].ToString());
        cashbankrep.SetParameterValue(2, ds2.Tables[0].Rows[0][5].ToString());
        cashbankrep.SetParameterValue(3, ds2.Tables[0].Rows[0][6].ToString());
        cashbankrep.SetParameterValue(4, ds2.Tables[0].Rows[0][7].ToString());
        cashbankrep.SetParameterValue(5, ds2.Tables[0].Rows[0][8].ToString());
        cashbankrep.SetParameterValue(6, ds2.Tables[0].Rows[0][9].ToString());
        cashbankrep.SetParameterValue(7, ds2.Tables[0].Rows[0][10].ToString());
        cashbankrep.SetParameterValue(8, ds2.Tables[0].Rows[0][11].ToString());
        
        
        crystalReportViewer2.Refresh();
    }
    else
    {
        MessageBox.Show("No Records Found!!!");
    }


}

private void btnrepsfh_Click(object sender, EventArgs e)
{

}

private void btnpregh_Click(object sender, EventArgs e)
{
    da = new SqlDataAdapter("select cc,comp,address,year_start,year_end,pathologist,biochemist,telphoneno,email,cstno,address1,faxno from company", con);
    ds2 = new DataSet();
    da.Fill(ds2);

    da.Dispose();
    btnclosecrv.Visible = true;
    crystalReportViewer1.Visible = true;

    String s1 = "select a.cc,a.patient_name,a.pcode,a.sex,a.age,a.doctor,a.date_exam as Dt_Report,a.month_year,b.UP_color,b.UP_reaction,b.UP_specificgravity,b.UC_sugar,b.UC_albumin,b.UC_phosphate,b.UC_chyle,b.UC_ketonebodies,b.UC_bilesalts,b.UC_bilepigment,b.UM_puscells,b.UM_epithcells,b.UM_rbc,b.UM_casts,b.UM_crystals,b.UM_bacterial,b.UM_spermatozoa,b.UM_mf_tv,b.UM_others,b.UU_urine_b_hcg,b.UA_urine_albumin,b.UN_nasalsmear,b.ur_imp,a.scn,a.tpt,ur_cotinine from patient_master a , urine b where a.pcode=b.pcode and  a.pcode='" + cbopcode.Text + "'   order by b.pcode,a.date_exam";
    da = new SqlDataAdapter(s1, con);
    ds = new DataSet();
    da.Fill(ds, "Pathology_Urine");
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

        dt.Columns.Add("barcode", System.Type.GetType("System.Byte[]"));

        String qrdata = cbopcode.Text.Trim();
        BarcodeLib.Barcode.Linear qrcode = new BarcodeLib.Barcode.Linear();
        qrcode.Type = BarcodeLib.Barcode.BarcodeType.CODE39;
        qrcode.Data = qrdata;

        // Save & output QR Code barcode image to your system
        qrcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;
        byte[] imageData = qrcode.drawBarcodeAsBytes();
        //byte[] barcode = qrcode.drawBarcodeAsBytes();
           
        
        gpatient_name = ds.Tables[0].Rows[i][1].ToString();
        gcode = Convert.ToInt32(ds.Tables[0].Rows[i][2].ToString());
        gsex = ds.Tables[0].Rows[i][3].ToString();
        gage = Convert.ToInt32(ds.Tables[0].Rows[i][4].ToString());
        gdoctor = ds.Tables[0].Rows[i][5].ToString();
        gdt_report = Convert.ToDateTime(ds.Tables[0].Rows[i][6].ToString());
        gmnyr = ds.Tables[0].Rows[i][7].ToString();
        gscn = ds.Tables[0].Rows[i][31].ToString();
        gtpt = ds.Tables[0].Rows[i][32].ToString();



        if (ds.Tables[0].Rows[i][27].ToString() != "")
        {
            Ggrp = "Pregnancy";
            //Ggrp = "Pregnancy";
            Gdesc = "";
            Gdesc1 = "Pregnancy";
            Gresult = ds.Tables[0].Rows[i][27].ToString();
            Gunit = "";
            Gnormalrange = "";
            Gnormalrange1 = "";
            ADDROW();
        }

        //if (ds.Tables[0].Rows[i][30].ToString() != "")
        //{
        //    Ggrp = "3.MICROSCOPIC-EX-";
        //    Gdesc = "MICROSCOPIC-EX-";
        //    Gdesc1 = "Impression";
        //    Gresult = ds.Tables[0].Rows[i][30].ToString();
        //    Gunit = "";
        //    Gnormalrange = "";
        //    Gnormalrange1 = "";
        //    ADDROW();
        //}


        //UM_mf_tv,b.UM_others,b.UU_urine_b_hcg,b.UA_urine_albumin,b.UN_nasalsmear                      



        //Repurine cashbankrep = new Repurine();
        Reppregnancyh cashbankrep = new Reppregnancyh();
        //cashbankrep.SetDatabaseLogon("sa", "software", @".\SQLEXPRESS", "pathology2627");
        cashbankrep.SetDataSource(dt);
        crystalReportViewer1.ReportSource = cashbankrep;
        cashbankrep.SetParameterValue(0, ds2.Tables[0].Rows[0][5].ToString());
        cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows[0][6].ToString());
        cashbankrep.SetParameterValue(2, ds2.Tables[0].Rows[0][1].ToString());
        cashbankrep.SetParameterValue(3, ds2.Tables[0].Rows[0][2].ToString());
        cashbankrep.SetParameterValue(4, ds2.Tables[0].Rows[0][7].ToString());
        cashbankrep.SetParameterValue(5, ds2.Tables[0].Rows[0][8].ToString());
        cashbankrep.SetParameterValue(6, ds2.Tables[0].Rows[0][9].ToString());
        cashbankrep.SetParameterValue(7, ds2.Tables[0].Rows[0][10].ToString());
        cashbankrep.SetParameterValue(8, ds2.Tables[0].Rows[0][11].ToString());
        crystalReportViewer1.Refresh();

    }
    else
    {
        MessageBox.Show("No Records Found!!!");
    }
}

private void crystalReportViewer1_Load_2(object sender, EventArgs e)
{

}

private void Bcr_LP_LDLCholesterol_Validating(object sender, CancelEventArgs e)
{
    //Double ldl = Convert.ToDouble(Bcr_LP_Cholesterol.Text) - Convert.ToDouble(Bcr_LP_HDLCholesterol.Text) - Convert.ToDouble(Bcr_LP_VLDLCholesterol.Text);
    //Bcr_LP_LDLCholesterol.Text = ldl.ToString();
    Bcr_LP_LDLCholesterol.Text = Convert.ToString(Convert.ToDouble(Bcr_LP_Cholesterol.Text) - Convert.ToDouble(Bcr_LP_HDLCholesterol.Text) - (Convert.ToDouble(Bcr_LP_Triglycerides.Text) / 5));


}

private void Bcr_LP_Triglycerides_Validating(object sender, CancelEventArgs e)
{
    //Bcr_LP_LDLCholesterol.Text = Convert.ToString(Convert.ToDouble(Bcr_LP_Cholesterol.Text) - Convert.ToDouble(Bcr_LP_HDLCholesterol.Text) - (Convert.ToDouble(Bcr_LP_Triglycerides.Text) / 5));
}

private void BDCmcv_TextChanged(object sender, EventArgs e)
{

}

private void CBDcPSS_Enter(object sender, EventArgs e)
{
    this.KeyPreview = false;
}

private void CBDcPSS_Leave(object sender, EventArgs e)
{
    this.KeyPreview = true;
}











private void label450_Click(object sender, EventArgs e)
{

}

private void label449_Click(object sender, EventArgs e)
{

}

private void label448_Click(object sender, EventArgs e)
{

}

private void label447_Click(object sender, EventArgs e)
{

}

private void label446_Click(object sender, EventArgs e)
{

}

private void label445_Click(object sender, EventArgs e)
{

}

private void label444_Click(object sender, EventArgs e)
{

}

private void BWwidaltubebh320_TextChanged(object sender, EventArgs e)
{

}

private void BWwidaltubebh160_TextChanged(object sender, EventArgs e)
{

}

private void BWwidaltubebh80_TextChanged(object sender, EventArgs e)
{

}

private void BWwidaltubeah320_TextChanged(object sender, EventArgs e)
{

}

private void BWwidaltubeah160_TextChanged(object sender, EventArgs e)
{

}

private void BWwidaltubeah80_TextChanged(object sender, EventArgs e)
{

}

private void BWwidaltubeh320_TextChanged(object sender, EventArgs e)
{

}

private void BWwidaltubeh160_TextChanged(object sender, EventArgs e)
{

}

private void BWwidaltubeh80_TextChanged(object sender, EventArgs e)
{

}

private void BWwidaltubeo320_TextChanged(object sender, EventArgs e)
{

}

private void BWwidaltubeo160_TextChanged(object sender, EventArgs e)
{

}

private void BWwidalslide4_TextChanged(object sender, EventArgs e)
{

}

private void BWwidalslide3_TextChanged(object sender, EventArgs e)
{

}

private void BWwidalslide2_TextChanged(object sender, EventArgs e)
{

}

private void BWwidalslide1_TextChanged(object sender, EventArgs e)
{

}

private void label382_Click(object sender, EventArgs e)
{

}

private void label381_Click(object sender, EventArgs e)
{

}

private void label380_Click(object sender, EventArgs e)
{

}

private void label379_Click(object sender, EventArgs e)
{

}

private void SBS_Typhicheck_TextChanged(object sender, EventArgs e)
{

}

private void SBS_Dengue_TextChanged(object sender, EventArgs e)
{

}

private void label211_Click(object sender, EventArgs e)
{

}

private void label210_Click(object sender, EventArgs e)
{

}

private void label189_Click(object sender, EventArgs e)
{

}

private void label188_Click(object sender, EventArgs e)
{

}

private void label187_Click(object sender, EventArgs e)
{

}

private void label177_Click(object sender, EventArgs e)
{

}

private void SBS_mycodot_TextChanged(object sender, EventArgs e)
{

}

private void label176_Click(object sender, EventArgs e)
{

}

private void label175_Click(object sender, EventArgs e)
{

}

private void SBm_MontouxTest_readon_TextChanged(object sender, EventArgs e)
{

}

private void SBm_MontouxTest_injon_TextChanged(object sender, EventArgs e)
{

}

private void label173_Click(object sender, EventArgs e)
{

}

private void SBm_MontouxTest_induration_TextChanged(object sender, EventArgs e)
{

}

private void label174_Click(object sender, EventArgs e)
{

}

private void btncancelserology_Click(object sender, EventArgs e)
{

}

private void SBS_HIV_2_TextChanged(object sender, EventArgs e)
{

}

private void SBS_HIV_1_TextChanged(object sender, EventArgs e)
{

}

private void SBS_Hepatitis_C_Virus_TextChanged(object sender, EventArgs e)
{

}

private void SBS_Australia_Antigen_TextChanged(object sender, EventArgs e)
{

}

private void label169_Click(object sender, EventArgs e)
{

}

private void label170_Click(object sender, EventArgs e)
{

}

private void label171_Click(object sender, EventArgs e)
{

}

private void label172_Click(object sender, EventArgs e)
{

}

private void SBPS_Toxo_TextChanged(object sender, EventArgs e)
{

}

private void SBPS_vdrl_TextChanged(object sender, EventArgs e)
{

}

private void label167_Click(object sender, EventArgs e)
{

}

private void SBPS_Ana_TextChanged(object sender, EventArgs e)
{

}

private void label166_Click(object sender, EventArgs e)
{

}

private void SBPS_Rafactor_TextChanged(object sender, EventArgs e)
{

}

private void label165_Click(object sender, EventArgs e)
{

}

private void SBPS_Crp_TextChanged(object sender, EventArgs e)
{

}

private void label164_Click(object sender, EventArgs e)
{

}

private void SBPS_Aso_TextChanged(object sender, EventArgs e)
{

}

private void label163_Click(object sender, EventArgs e)
{

}

private void BWwidaltubeo80_TextChanged(object sender, EventArgs e)
{

}

private void label160_Click(object sender, EventArgs e)
{

}

private void tpbiochem3_Click(object sender, EventArgs e)
{

}

private void label536_Click(object sender, EventArgs e)
{

}

private void db3_imp_TextChanged(object sender, EventArgs e)
{

}

private void btncancelbc3_Click(object sender, EventArgs e)
{

}

private void label361_Click(object sender, EventArgs e)
{

}

private void label362_Click(object sender, EventArgs e)
{

}

private void label363_Click(object sender, EventArgs e)
{

}

private void label364_Click(object sender, EventArgs e)
{

}

private void label365_Click(object sender, EventArgs e)
{

}

private void label366_Click(object sender, EventArgs e)
{

}

private void Bc3_uric_acid_TextChanged(object sender, EventArgs e)
{

}

private void label1_Click(object sender, EventArgs e)
{

}

private void Bc3_ppbs1_TextChanged(object sender, EventArgs e)
{

}

private void label368_Click(object sender, EventArgs e)
{

}

private void label369_Click(object sender, EventArgs e)
{

}

private void label370_Click(object sender, EventArgs e)
{

}

private void label371_Click(object sender, EventArgs e)
{

}

private void label372_Click(object sender, EventArgs e)
{

}

private void label373_Click(object sender, EventArgs e)
{

}

private void label374_Click(object sender, EventArgs e)
{

}

private void Bc3_triglyceride_TextChanged(object sender, EventArgs e)
{

}

private void Bc3_vldl_TextChanged(object sender, EventArgs e)
{

}

private void Bc3_ldl_TextChanged(object sender, EventArgs e)
{

}

private void Bc3_hdl_TextChanged(object sender, EventArgs e)
{

}

private void Bc3_cholesterol_TextChanged(object sender, EventArgs e)
{

}

private void label375_Click(object sender, EventArgs e)
{

}

private void label376_Click(object sender, EventArgs e)
{

}

private void label377_Click(object sender, EventArgs e)
{

}

private void Bc3_creatinine_TextChanged(object sender, EventArgs e)
{

}

private void Bc3_urea_TextChanged(object sender, EventArgs e)
{

}

private void Bc3_ppbs2_TextChanged(object sender, EventArgs e)
{

}

private void Bc3_fbs_TextChanged(object sender, EventArgs e)
{

}

private void label378_Click(object sender, EventArgs e)
{

}

private void tpbiochem_Click(object sender, EventArgs e)
{

}

private void label504_Click(object sender, EventArgs e)
{

}

private void Bcr_OTH_Lipase_TextChanged(object sender, EventArgs e)
{

}

private void label503_Click(object sender, EventArgs e)
{

}

private void Bcr_OTH_nac_TextChanged(object sender, EventArgs e)
{

}

private void label142_Click(object sender, EventArgs e)
{

}

private void label537_Click(object sender, EventArgs e)
{

}

private void db_all_TextChanged(object sender, EventArgs e)
{

}

private void dgvbiochemext_CellContentClick(object sender, DataGridViewCellEventArgs e)
{

}

private void label202_Click(object sender, EventArgs e)
{

}

private void label201_Click(object sender, EventArgs e)
{

}

private void label200_Click(object sender, EventArgs e)
{

}

private void label199_Click(object sender, EventArgs e)
{

}

private void label198_Click(object sender, EventArgs e)
{

}

private void label197_Click(object sender, EventArgs e)
{

}

private void label196_Click(object sender, EventArgs e)
{

}

private void label195_Click(object sender, EventArgs e)
{

}

private void label194_Click(object sender, EventArgs e)
{

}

private void label193_Click(object sender, EventArgs e)
{

}

private void label82_Click(object sender, EventArgs e)
{

}

private void label80_Click(object sender, EventArgs e)
{

}

private void label76_Click(object sender, EventArgs e)
{

}

private void label74_Click(object sender, EventArgs e)
{

}

private void label73_Click(object sender, EventArgs e)
{

}

private void label192_Click(object sender, EventArgs e)
{

}

private void label109_Click(object sender, EventArgs e)
{

}

private void label146_Click(object sender, EventArgs e)
{

}

private void label191_Click(object sender, EventArgs e)
{

}

private void label190_Click(object sender, EventArgs e)
{

}

private void Bcr5_Electrolyte_Chlorides_TextChanged(object sender, EventArgs e)
{

}

private void label154_Click(object sender, EventArgs e)
{

}

private void Bcr4_LFT_GGTP_TextChanged(object sender, EventArgs e)
{

}

private void label153_Click(object sender, EventArgs e)
{

}

private void Bcr4_LFT_Indirect_TextChanged(object sender, EventArgs e)
{

}

private void label151_Click(object sender, EventArgs e)
{

}

private void label152_Click(object sender, EventArgs e)
{

}

private void Bcr2_LP_LHR_TextChanged(object sender, EventArgs e)
{

}

private void label150_Click(object sender, EventArgs e)
{

}

private void Bcr3_NPN_TextChanged(object sender, EventArgs e)
{

}

private void label149_Click(object sender, EventArgs e)
{

}

private void Bcr3_Uric_Acid_TextChanged(object sender, EventArgs e)
{

}

private void label148_Click(object sender, EventArgs e)
{

}

private void Bcr1_MBGE_TextChanged(object sender, EventArgs e)
{

}

private void Bcr1_HBAC_poor_TextChanged(object sender, EventArgs e)
{

}

private void Bcr1_HBAC_fair_TextChanged(object sender, EventArgs e)
{

}

private void Bcr1_HBAC_good_TextChanged(object sender, EventArgs e)
{

}

private void Bcr1_PGBS_2hr_TextChanged(object sender, EventArgs e)
{

}

private void label147_Click(object sender, EventArgs e)
{

}

private void label124_Click(object sender, EventArgs e)
{

}

private void label123_Click(object sender, EventArgs e)
{

}

private void Bcr1_PGBS_1hr_TextChanged(object sender, EventArgs e)
{

}

private void Bcr1_GTT_3hr_TextChanged(object sender, EventArgs e)
{

}

private void Bcr1_GTT_2hr_TextChanged(object sender, EventArgs e)
{

}

private void Bcr1_GTT_1hr_TextChanged(object sender, EventArgs e)
{

}

private void Bcr1_PLBS_TextChanged(object sender, EventArgs e)
{

}

private void Bcr1_PBBS_TextChanged(object sender, EventArgs e)
{

}

private void Bcr1_RBS_TextChanged(object sender, EventArgs e)
{

}

private void Bcr1_PPPG_PGPG_1hr_TextChanged(object sender, EventArgs e)
{

}

private void label121_Click(object sender, EventArgs e)
{

}

private void label120_Click(object sender, EventArgs e)
{

}

private void label119_Click(object sender, EventArgs e)
{

}

private void label118_Click(object sender, EventArgs e)
{

}

private void label115_Click(object sender, EventArgs e)
{

}

private void label113_Click(object sender, EventArgs e)
{

}

private void label111_Click(object sender, EventArgs e)
{

}

private void label106_Click(object sender, EventArgs e)
{

}

private void label105_Click(object sender, EventArgs e)
{

}

private void label104_Click(object sender, EventArgs e)
{

}

private void label103_Click(object sender, EventArgs e)
{

}

private void label102_Click(object sender, EventArgs e)
{

}

private void Bcr_LFT_Albumin_TextChanged(object sender, EventArgs e)
{

}

private void Bcr_OTH_Acid_Phosphorus_TextChanged(object sender, EventArgs e)
{

}

private void label69_Click(object sender, EventArgs e)
{

}

private void label70_Click(object sender, EventArgs e)
{

}

private void Bcr_LFT_SGPT_ALT_TextChanged(object sender, EventArgs e)
{

}

private void Bcr_OTH_Acid_Calcium_TextChanged(object sender, EventArgs e)
{

}

private void Bcr_OTH_Amylase_TextChanged(object sender, EventArgs e)
{

}

private void Bcr_OTH_Acid_Phosphate_TextChanged(object sender, EventArgs e)
{

}

private void Bcr_Electrolyte_Potassium_TextChanged(object sender, EventArgs e)
{

}

private void Bcr_Electrolyte_Sodium_TextChanged(object sender, EventArgs e)
{

}

private void Bcr_OTH_PP_PG_urine_sugar_TextChanged(object sender, EventArgs e)
{

}

private void Bcr_LFT_AG_Ratio_TextChanged(object sender, EventArgs e)
{

}

private void Bcr_OTH_Pasting_urine_sugar_TextChanged(object sender, EventArgs e)
{

}

private void Bcr_LFT_Globulin_TextChanged(object sender, EventArgs e)
{

}

private void Bcr_OTH_Uric_Acid_TextChanged(object sender, EventArgs e)
{

}

private void label71_Click(object sender, EventArgs e)
{

}

private void Bcr_LFT_Protein_TextChanged(object sender, EventArgs e)
{

}

private void label72_Click(object sender, EventArgs e)
{

}

private void label75_Click(object sender, EventArgs e)
{

}

private void label77_Click(object sender, EventArgs e)
{

}

private void label81_Click(object sender, EventArgs e)
{

}

private void label83_Click(object sender, EventArgs e)
{

}

private void label84_Click(object sender, EventArgs e)
{

}

private void label85_Click(object sender, EventArgs e)
{

}

private void label86_Click(object sender, EventArgs e)
{

}

private void label87_Click(object sender, EventArgs e)
{

}

private void label88_Click(object sender, EventArgs e)
{

}

private void label89_Click(object sender, EventArgs e)
{

}

private void label90_Click(object sender, EventArgs e)
{

}

private void label91_Click(object sender, EventArgs e)
{

}

private void label92_Click(object sender, EventArgs e)
{

}

private void label93_Click(object sender, EventArgs e)
{

}

private void label94_Click(object sender, EventArgs e)
{

}

private void Bcr_LFT_SGOT_AST_TextChanged(object sender, EventArgs e)
{

}

private void Bcr_LFT_Alkaline_Phosphates_TextChanged(object sender, EventArgs e)
{

}

private void Bcr_LFT_Bilirubin_Direct_TextChanged(object sender, EventArgs e)
{

}

private void Bcr_LFT_Bilirubin_total_TextChanged(object sender, EventArgs e)
{

}

private void Bcr2_LP_CHR_TextChanged(object sender, EventArgs e)
{

}

private void Bcr_LP_Triglycerides_TextChanged(object sender, EventArgs e)
{

}

private void Bcr_LP_VLDLCholesterol_TextChanged(object sender, EventArgs e)
{

}

private void Bcr_LP_LDLCholesterol_TextChanged(object sender, EventArgs e)
{

}

private void Bcr_LP_HDLCholesterol_TextChanged(object sender, EventArgs e)
{

}

private void Bcr_LP_Cholesterol_TextChanged(object sender, EventArgs e)
{

}

private void label95_Click(object sender, EventArgs e)
{

}

private void label97_Click(object sender, EventArgs e)
{

}

private void label99_Click(object sender, EventArgs e)
{

}

private void label100_Click(object sender, EventArgs e)
{

}

private void Bcr_RP_Creatinine_TextChanged(object sender, EventArgs e)
{

}

private void Bcr_RP_BUN_TextChanged(object sender, EventArgs e)
{

}

private void Bcr_RP_Urea_TextChanged(object sender, EventArgs e)
{

}

private void Bcr1_PPPG_PGPG_2hr_TextChanged(object sender, EventArgs e)
{

}

private void Bcr1_Glucose_Fpg_RPG_TextChanged(object sender, EventArgs e)
{

}

private void label101_Click(object sender, EventArgs e)
{

}

private void tpculture_Click(object sender, EventArgs e)
{

}

private void cbons_SelectedIndexChanged(object sender, EventArgs e)
{

}

private void label98_Click(object sender, EventArgs e)
{

}

private void cbocolonycount_SelectedIndexChanged(object sender, EventArgs e)
{

}

private void Cu_Organism_isolated1_SelectedIndexChanged(object sender, EventArgs e)
{

}

private void dgvculture_CellContentClick(object sender, DataGridViewCellEventArgs e)
{

}

private void label540_Click(object sender, EventArgs e)
{

}

private void label539_Click(object sender, EventArgs e)
{

}

private void cul_imp_TextChanged(object sender, EventArgs e)
{

}

private void label442_Click(object sender, EventArgs e)
{

}

private void label441_Click(object sender, EventArgs e)
{

}

private void label418_Click(object sender, EventArgs e)
{

}

private void Cu_Cefixime_srm_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Tobramycin_srm_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Tazobactum_srm_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Gatifloxacin_srm_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Levofloxacin_srm_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Cefoperazone_srm_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Roxythromycin_srm_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Tetracycline_srm_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Streptomycin_srm_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Pencillin_srm_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Piperacillin_srm_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Ofloxacin_srm_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Netromycin_srm_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Norfloxacine_srm_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Nitrofurantion_srm_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Neomycin_srm_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Gemifloxacin_srm_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Gentamycin_srm_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Erythromycin_srm_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Doxycycline_srm_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Ciprofloxacin_srm_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Cefotaxime_srm_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Cefazolin_srm_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Co_trimoxazole_srm_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Cloxacillin_srm_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Ceftriaxone_srm_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Ceftazidime_srm_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Cephalexin_srm_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Amikacin_srm_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Ampicillin_srm_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Amoxicillin_srm_TextChanged(object sender, EventArgs e)
{

}

private void label383_Click(object sender, EventArgs e)
{

}

private void Cu_Cefixime_no_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Tobramycin_no_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Tazobactum_no_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Gatifloxacin_no_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Levofloxacin_no_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Cefoperazone_no_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Roxythromycin_no_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Tetracycline_no_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Streptomycin_no_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Pencillin_no_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Piperacillin_no_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Ofloxacin_no_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Netromycin_no_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Norfloxacine_no_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Nitrofurantion_no_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Neomycin_no_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Gemifloxacin_no_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Gentamycin_no_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Erythromycin_no_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Doxycycline_no_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Ciprofloxacin_no_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Cefotaxime_no_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Cefazolin_no_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Co_trimoxazole_no_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Cloxacillin_no_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Ceftriaxone_no_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Ceftazidime_no_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Cephalexin_no_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Amikacin_no_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Ampicillin_no_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Amoxicillin_no_TextChanged(object sender, EventArgs e)
{

}

private void label417_Click(object sender, EventArgs e)
{

}

private void btncancelculture_Click(object sender, EventArgs e)
{

}

private void label416_Click(object sender, EventArgs e)
{

}

private void Cu_Cefixime_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Tobramycin_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Tazobactum_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Gatifloxacin_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Levofloxacin_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Cefoperazone_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Roxythromycin_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Tetracycline_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Streptomycin_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Pencillin_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Piperacillin_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Ofloxacin_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Netromycin_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Norfloxacine_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Nitrofurantion_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Neomycin_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Gemifloxacin_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Gentamycin_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Erythromycin_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Doxycycline_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Ciprofloxacin_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Cefotaxime_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Cefazolin_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Co_trimoxazole_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Cloxacillin_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Ceftriaxone_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Ceftazidime_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Cephalexin_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Amikacin_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Ampicillin_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Amoxicillin_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Inter_sensitivity_TextChanged(object sender, EventArgs e)
{

}

private void Cu_Organism_isolated_TextChanged(object sender, EventArgs e)
{

}

private void label415_Click(object sender, EventArgs e)
{

}

private void label414_Click(object sender, EventArgs e)
{

}

private void label413_Click(object sender, EventArgs e)
{

}

private void label412_Click(object sender, EventArgs e)
{

}

private void label411_Click(object sender, EventArgs e)
{

}

private void label410_Click(object sender, EventArgs e)
{

}

private void label409_Click(object sender, EventArgs e)
{

}

private void label408_Click(object sender, EventArgs e)
{

}

private void label407_Click(object sender, EventArgs e)
{

}

private void label406_Click(object sender, EventArgs e)
{

}

private void label405_Click(object sender, EventArgs e)
{

}

private void label404_Click(object sender, EventArgs e)
{

}

private void label403_Click(object sender, EventArgs e)
{

}

private void label402_Click(object sender, EventArgs e)
{

}

private void label401_Click(object sender, EventArgs e)
{

}

private void label400_Click(object sender, EventArgs e)
{

}

private void label399_Click(object sender, EventArgs e)
{

}

private void label398_Click(object sender, EventArgs e)
{

}

private void label397_Click(object sender, EventArgs e)
{

}

private void label396_Click(object sender, EventArgs e)
{

}

private void label395_Click(object sender, EventArgs e)
{

}

private void label394_Click(object sender, EventArgs e)
{

}

private void label393_Click(object sender, EventArgs e)
{

}

private void label392_Click(object sender, EventArgs e)
{

}

private void label391_Click(object sender, EventArgs e)
{

}

private void label390_Click(object sender, EventArgs e)
{

}

private void label389_Click(object sender, EventArgs e)
{

}

private void label388_Click(object sender, EventArgs e)
{

}

private void label387_Click(object sender, EventArgs e)
{

}

private void label386_Click(object sender, EventArgs e)
{

}

private void label385_Click(object sender, EventArgs e)
{

}

private void label384_Click(object sender, EventArgs e)
{

}

private void tphormone_Click(object sender, EventArgs e)
{

}

private void dgvhormonenew_CellContentClick(object sender, DataGridViewCellEventArgs e)
{

}

private void hm_imp_TextChanged(object sender, EventArgs e)
{

}

private void label541_Click(object sender, EventArgs e)
{

}

private void label443_Click(object sender, EventArgs e)
{

}

private void btncancelhormone_Click(object sender, EventArgs e)
{

}

private void label439_Click(object sender, EventArgs e)
{

}

private void label438_Click(object sender, EventArgs e)
{

}

private void label437_Click(object sender, EventArgs e)
{

}

private void label436_Click(object sender, EventArgs e)
{

}

private void label435_Click(object sender, EventArgs e)
{

}

private void ANA_TextChanged(object sender, EventArgs e)
{

}

private void label434_Click(object sender, EventArgs e)
{

}

private void CA_125_TextChanged(object sender, EventArgs e)
{

}

private void label433_Click(object sender, EventArgs e)
{

}

private void BHCG_TextChanged(object sender, EventArgs e)
{

}

private void label432_Click(object sender, EventArgs e)
{

}

private void ANTITUBERCULOSIS_TB_IgA_TextChanged(object sender, EventArgs e)
{

}

private void label431_Click(object sender, EventArgs e)
{

}

private void ANTITUBERCULOSIS_TB_IgM_TextChanged(object sender, EventArgs e)
{

}

private void label430_Click(object sender, EventArgs e)
{

}

private void ANTITUBERCULOSIS_TB_IgG_TextChanged(object sender, EventArgs e)
{

}

private void label429_Click(object sender, EventArgs e)
{

}

private void ADENOSINE_DEAMINASE_TextChanged(object sender, EventArgs e)
{

}

private void label428_Click(object sender, EventArgs e)
{

}

private void PROSTATESPECIFICANTIGEN_PSA_TextChanged(object sender, EventArgs e)
{

}

private void label427_Click(object sender, EventArgs e)
{

}

private void PROLACTIN_PRL_TextChanged(object sender, EventArgs e)
{

}

private void label426_Click(object sender, EventArgs e)
{

}

private void TOTAL_CHOLESTEROL_TextChanged(object sender, EventArgs e)
{

}

private void label425_Click(object sender, EventArgs e)
{

}

private void ANTIMICROSOMAL_ANTIBODY_AMA_TextChanged(object sender, EventArgs e)
{

}

private void label424_Click(object sender, EventArgs e)
{

}

private void FREE_THYROXINE_FT4_TextChanged(object sender, EventArgs e)
{

}

private void label423_Click(object sender, EventArgs e)
{

}

private void FREE_TRIIODOTHYRONINE_FT3_TextChanged(object sender, EventArgs e)
{

}

private void label422_Click(object sender, EventArgs e)
{

}

private void TSH_TextChanged(object sender, EventArgs e)
{

}

private void label421_Click(object sender, EventArgs e)
{

}

private void TOTAL_THYROXINE_T4_TextChanged(object sender, EventArgs e)
{

}

private void label420_Click(object sender, EventArgs e)
{

}

private void TOTAL_TRIIODOTHYRONINE_T3_TextChanged(object sender, EventArgs e)
{

}

private void label419_Click(object sender, EventArgs e)
{

}

private void label509_Click(object sender, EventArgs e)
{

}

private void cboiv_SelectedIndexChanged(object sender, EventArgs e)
{

}

private void label207_Click(object sender, EventArgs e)
{

}

private void FA_MP_Premature_TextChanged(object sender, EventArgs e)
{

}

private void label538_Click(object sender, EventArgs e)
{

}

private void sf_imp_TextChanged(object sender, EventArgs e)
{

}

private void label208_Click(object sender, EventArgs e)
{

}

private void label206_Click(object sender, EventArgs e)
{

}

private void label205_Click(object sender, EventArgs e)
{

}

private void label138_Click(object sender, EventArgs e)
{

}

private void FA_MT_Totalcount_TextChanged(object sender, EventArgs e)
{

}

private void label137_Click(object sender, EventArgs e)
{

}

private void label136_Click(object sender, EventArgs e)
{

}

private void FA_MT_Dead_TextChanged(object sender, EventArgs e)
{

}

private void label135_Click(object sender, EventArgs e)
{

}

private void FA_MT_Slugish_TextChanged(object sender, EventArgs e)
{

}

private void label134_Click(object sender, EventArgs e)
{

}

private void FA_MT_Active_TextChanged(object sender, EventArgs e)
{

}

private void label133_Click(object sender, EventArgs e)
{

}

private void label52_Click(object sender, EventArgs e)
{

}

private void label114_Click(object sender, EventArgs e)
{

}

private void label116_Click(object sender, EventArgs e)
{

}

private void label125_Click(object sender, EventArgs e)
{

}

private void label126_Click(object sender, EventArgs e)
{

}

private void label127_Click(object sender, EventArgs e)
{

}

private void label128_Click(object sender, EventArgs e)
{

}

private void FA_MP_Deformed_TextChanged(object sender, EventArgs e)
{

}

private void FA_MP_Epithcells_TextChanged(object sender, EventArgs e)
{

}

private void FA_MP_RBC_TextChanged(object sender, EventArgs e)
{

}

private void FA_MP_Puscells_TextChanged(object sender, EventArgs e)
{

}

private void FA_MP_Prostaticpearls_TextChanged(object sender, EventArgs e)
{

}

private void FA_Viscocity_TextChanged(object sender, EventArgs e)
{

}

private void FA_Color_TextChanged(object sender, EventArgs e)
{

}

private void FA_Reaction_TextChanged(object sender, EventArgs e)
{

}

private void FA_Volume_TextChanged(object sender, EventArgs e)
{

}

private void label129_Click(object sender, EventArgs e)
{

}

private void FA_Timeofliquification_TextChanged(object sender, EventArgs e)
{

}

private void label130_Click(object sender, EventArgs e)
{

}

private void FA_Timeofexamination_TextChanged(object sender, EventArgs e)
{

}

private void label131_Click(object sender, EventArgs e)
{

}

private void FA_Timeofcollection_TextChanged(object sender, EventArgs e)
{

}

private void label132_Click(object sender, EventArgs e)
{

}

private void tpserology2_Click(object sender, EventArgs e)
{

}

private void label571_Click(object sender, EventArgs e)
{

}

private void btnprintserology2_Click(object sender, EventArgs e)
{

}

private void btncancelserology2_Click(object sender, EventArgs e)
{

}

private void srt_hp_iga_TextChanged(object sender, EventArgs e)
{

}

private void label557_Click(object sender, EventArgs e)
{

}

private void label555_Click(object sender, EventArgs e)
{

}

private void srt_hp_igg_TextChanged(object sender, EventArgs e)
{

}

private void label556_Click(object sender, EventArgs e)
{

}

private void srt_hp_igm_TextChanged(object sender, EventArgs e)
{

}

private void SER_IMP2_TextChanged(object sender, EventArgs e)
{

}

private void SRT_AHBCAT_TextChanged(object sender, EventArgs e)
{

}

private void label552_Click(object sender, EventArgs e)
{

}

private void SRT_AHAV_IGM_TextChanged(object sender, EventArgs e)
{

}

private void SRT_AHBCA_IGM_TextChanged(object sender, EventArgs e)
{

}

private void label553_Click(object sender, EventArgs e)
{

}

private void label554_Click(object sender, EventArgs e)
{

}

private void SRT_AHBEAT_TextChanged(object sender, EventArgs e)
{

}

private void label558_Click(object sender, EventArgs e)
{

}

private void SRT_HBEA_TextChanged(object sender, EventArgs e)
{

}

private void label559_Click(object sender, EventArgs e)
{

}

private void label560_Click(object sender, EventArgs e)
{

}

private void SRT_AHCVT_TextChanged(object sender, EventArgs e)
{

}

private void SRT_AHAVT_TextChanged(object sender, EventArgs e)
{

}

private void label561_Click(object sender, EventArgs e)
{

}

private void SRT_AHEV_IGM_TextChanged(object sender, EventArgs e)
{

}

private void label562_Click(object sender, EventArgs e)
{

}

private void SRT_AHBSAT_TextChanged(object sender, EventArgs e)
{

}

private void SRT_HBSA_TextChanged(object sender, EventArgs e)
{

}

private void SRT_RV_IGM_TextChanged(object sender, EventArgs e)
{

}

private void SRT_RV_IGG_TextChanged(object sender, EventArgs e)
{

}

private void label563_Click(object sender, EventArgs e)
{

}

private void label564_Click(object sender, EventArgs e)
{

}

private void label565_Click(object sender, EventArgs e)
{

}

private void label566_Click(object sender, EventArgs e)
{

}

private void SRT_HSV_IGM_TextChanged(object sender, EventArgs e)
{

}

private void label567_Click(object sender, EventArgs e)
{

}

private void SRT_HSV_IGG_TextChanged(object sender, EventArgs e)
{

}

private void label568_Click(object sender, EventArgs e)
{

}

private void SRT_CV_IGM_TextChanged(object sender, EventArgs e)
{

}

private void label569_Click(object sender, EventArgs e)
{

}

private void SRT_CV_IGG_TextChanged(object sender, EventArgs e)
{

}

private void label570_Click(object sender, EventArgs e)
{

}

private void SRT_ASA_TextChanged(object sender, EventArgs e)
{

}

private void label900_Click(object sender, EventArgs e)
{

}

private void srt_afp_TextChanged(object sender, EventArgs e)
{

}

private void label572_Click(object sender, EventArgs e)
{

}

private void LABEL1000_Click(object sender, EventArgs e)
{

}

private void tpbiochem2_Click(object sender, EventArgs e)
{

}

private void label535_Click(object sender, EventArgs e)
{

}

private void db2_imp_TextChanged(object sender, EventArgs e)
{

}

private void Bc2_ppbs2_TextChanged(object sender, EventArgs e)
{

}

private void btncancelbc2_Click(object sender, EventArgs e)
{

}

private void label218_Click(object sender, EventArgs e)
{

}

private void label219_Click(object sender, EventArgs e)
{

}

private void label220_Click(object sender, EventArgs e)
{

}

private void Bc2_uric_acid_TextChanged(object sender, EventArgs e)
{

}

private void label221_Click(object sender, EventArgs e)
{

}

private void Bc2_ppbs1_TextChanged(object sender, EventArgs e)
{

}

private void label222_Click(object sender, EventArgs e)
{

}

private void label223_Click(object sender, EventArgs e)
{

}

private void label224_Click(object sender, EventArgs e)
{

}

private void label225_Click(object sender, EventArgs e)
{

}

private void Bc2_creatinine_TextChanged(object sender, EventArgs e)
{

}

private void Bc2_urea_TextChanged(object sender, EventArgs e)
{

}

private void Bc2_fbs_TextChanged(object sender, EventArgs e)
{

}

private void label226_Click(object sender, EventArgs e)
{

}

private void tbnotepad_Click(object sender, EventArgs e)
{

}

private void label502_Click(object sender, EventArgs e)
{

}

private void richTextBox1_TextChanged(object sender, EventArgs e)
{

}

private void crystalReportViewer4_Load(object sender, EventArgs e)
{

}

private void button9_Click(object sender, EventArgs e)
{

}

private void txtnotepad_TextChanged(object sender, EventArgs e)
{

}

private void tposource_Click(object sender, EventArgs e)
{

}

private void label542_Click(object sender, EventArgs e)
{

}

private void dgvos_CellContentClick(object sender, DataGridViewCellEventArgs e)
{

}

private void tbhisto_Click(object sender, EventArgs e)
{

}

private void label547_Click(object sender, EventArgs e)
{

}

private void txtimpresion_TextChanged(object sender, EventArgs e)
{

}

private void label548_Click(object sender, EventArgs e)
{

}

private void txtmicro_TextChanged(object sender, EventArgs e)
{

}

private void label549_Click(object sender, EventArgs e)
{

}

private void label550_Click(object sender, EventArgs e)
{

}

private void txtgexam_TextChanged(object sender, EventArgs e)
{

}

private void label551_Click(object sender, EventArgs e)
{

}

private void txthisto_TextChanged(object sender, EventArgs e)
{

}

private void tabcytology_Click(object sender, EventArgs e)
{

}

private void Ctimp_TextChanged(object sender, EventArgs e)
{

}

private void label486_Click(object sender, EventArgs e)
{

}

private void btndeletect_Click(object sender, EventArgs e)
{

}

private void btncancelct_Click(object sender, EventArgs e)
{

}

private void label471_Click(object sender, EventArgs e)
{

}

private void CtOthers_TextChanged(object sender, EventArgs e)
{

}

private void CtMalignant_Cell_TextChanged(object sender, EventArgs e)
{

}

private void CtDysplastic_Cell_TextChanged(object sender, EventArgs e)
{

}

private void CtRbc_TextChanged(object sender, EventArgs e)
{

}

private void CtSpermatozoa_TextChanged(object sender, EventArgs e)
{

}

private void CtEndometrial_Cell_TextChanged(object sender, EventArgs e)
{

}

private void CtMonilia_TextChanged(object sender, EventArgs e)
{

}

private void CtTrichomonas_TextChanged(object sender, EventArgs e)
{

}

private void CtInflammatory_Cell_TextChanged(object sender, EventArgs e)
{

}

private void CtEndocervical_Cell_TextChanged(object sender, EventArgs e)
{

}

private void CtBenign_Cell_TextChanged(object sender, EventArgs e)
{

}

private void CtSpecimen_TextChanged(object sender, EventArgs e)
{

}

private void label467_Click(object sender, EventArgs e)
{

}

private void label468_Click(object sender, EventArgs e)
{

}

private void label469_Click(object sender, EventArgs e)
{

}

private void label470_Click(object sender, EventArgs e)
{

}

private void label463_Click(object sender, EventArgs e)
{

}

private void label464_Click(object sender, EventArgs e)
{

}

private void label465_Click(object sender, EventArgs e)
{

}

private void label466_Click(object sender, EventArgs e)
{

}

private void label462_Click(object sender, EventArgs e)
{

}

private void label461_Click(object sender, EventArgs e)
{

}

private void label460_Click(object sender, EventArgs e)
{

}

private void label459_Click(object sender, EventArgs e)
{

}

private void tbbodyfluid_Click(object sender, EventArgs e)
{

}

private void BfAbnormal_Cell_TextChanged(object sender, EventArgs e)
{

}

private void label546_Click(object sender, EventArgs e)
{

}

private void label545_Click(object sender, EventArgs e)
{

}

private void label544_Click(object sender, EventArgs e)
{

}

private void label543_Click(object sender, EventArgs e)
{

}

private void BfImpression_TextChanged(object sender, EventArgs e)
{

}

private void label485_Click(object sender, EventArgs e)
{

}

private void label472_Click(object sender, EventArgs e)
{

}






private void dgvbloodnewtest_DataError(object sender, DataGridViewDataErrorEventArgs e)
{
    //lblerr.Text = "";

    if (e.ColumnIndex != 1)
    {
        // //Alert the user for any other DataError's outside of the column I care about
        ////MessageBox.Show("The following exception was encountered: " + e.Exception);
        // MessageBox.Show(dgv.Rows[e.RowIndex].Cells[0].Value.ToString ()+" : Not Found in Item/Batch Master,PL Add in Master");
        // dgv.Rows[e.RowIndex].Cells[0].Value = "";
        // return;
        String err = dgvbloodnewtest.Rows[e.RowIndex].Cells[0].Value.ToString();
        //lblerr.Text = err + " Not Found in New Test Master !!";
        MessageBox.Show(err + " is Deleted or Moved from New Test Master,;Reenter it with Same name !!");
        dgvbloodnewtest.Rows[e.RowIndex].Cells[0].Value = "";
    }
}

private void dgvser_DataError(object sender, DataGridViewDataErrorEventArgs e)
{
    if (e.ColumnIndex != 1)
    {
        String err = dgvser.Rows[e.RowIndex].Cells[0].Value.ToString();
        //lblerr.Text = err + " Not Found in New Test Master !!";
        MessageBox.Show(err + " is Deleted or Moved from New Test Master,;Reenter it with Same name !!");
        dgvser.Rows[e.RowIndex].Cells[0].Value = "";
    }
}

private void dgvbiochemext_DataError(object sender, DataGridViewDataErrorEventArgs e)
{
    if (e.ColumnIndex != 1)
    {
        String err = dgvbiochemext.Rows[e.RowIndex].Cells[0].Value.ToString();
        //lblerr.Text = err + " Not Found in New Test Master !!";
        MessageBox.Show(err + " is Deleted or Moved from New Test Master,;Reenter it with Same name !!");
        dgvbiochemext.Rows[e.RowIndex].Cells[0].Value = "";
    }
}

private void dgvhormonenew_DataError(object sender, DataGridViewDataErrorEventArgs e)
{
    if (e.ColumnIndex != 1)
    {
        String err = dgvhormonenew.Rows[e.RowIndex].Cells[0].Value.ToString();
        //lblerr.Text = err + " Not Found in New Test Master !!";
        MessageBox.Show(err + " is Deleted or Moved from New Test Master,;Reenter it with Same name !!");
        dgvhormonenew.Rows[e.RowIndex].Cells[0].Value = "";
    } 
}

private void crystalReportViewer3_Load(object sender, EventArgs e)
{

}

private void BDc_Mp_ICT_TextChanged(object sender, EventArgs e)
{

}

private void label55_Click(object sender, EventArgs e)
{

}

private void BDc_Eosinophils_TextChanged(object sender, EventArgs e)
{

}

private void label68_Click(object sender, EventArgs e)
{

}

private void BDc_Basophils_TextChanged(object sender, EventArgs e)
{

}

private void label54_Click(object sender, EventArgs e)
{

}

private void BDc_Lymphocytes_TextChanged(object sender, EventArgs e)
{

}

private void label67_Click(object sender, EventArgs e)
{

}

private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
{

}

private void UC_phosphate_TextChanged(object sender, EventArgs e)
{

}

private void UM_epithcells_TextChanged(object sender, EventArgs e)
{

}

private void label4_Click(object sender, EventArgs e)
{

}

private void txtscn_KeyPress(object sender, KeyPressEventArgs e)
{
    if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back ))
    {
        e.Handled = true;

    }

    // only allow one decimal point
    //if (e.KeyChar == '.'
    //    && (sender as TextBox).Text.IndexOf('.') > -1)
    //{
    //    e.Handled = true;
    //}
}

private void TPXRAY_Click(object sender, EventArgs e)
{

}

private void button10_Click(object sender, EventArgs e)
{
    cmd = new SqlCommand("delete from xray where cc='" + txtcompanycode.Text + "' and  pcode='" + Convert.ToInt32(cbopcode.Text) + "'");
    cmd.Connection = con;
    cmd.ExecuteNonQuery();
    MessageBox.Show("Record Deleted");

}

private void BTNXRAYSAVE_Click(object sender, EventArgs e)
{
    String Sqlstr0 = "";
    String Sqlstr = "";
    con.Close();
    con.Open();

    if (MessageBox.Show("Save ? ", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
    {
        String strsql2 = "";
        strsql2 = "select cc,pcode,Specimen,gross_exam,microscopic,impression";
        strsql2 = strsql2 + " from XRAY where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
        da = new SqlDataAdapter(strsql2, con);
        ds2 = new DataSet();
        da.Fill(ds2);


        if (ds2.Tables[0].Rows.Count == 0)
        {
            Sqlstr0 = "insert into XRAY (cc,pcode,Specimen,gross_exam,microscopic,impression ) values('" + Convert.ToInt32(txtcompanycode.Text) + "','" + Convert.ToInt32(cbopcode.Text);

            Sqlstr0 = Sqlstr0 + "','" + txthistox.Text;
            Sqlstr0 = Sqlstr0 + "','" + txtgexamx.Text + "','" + txtmicrox.Text;

            Sqlstr0 = Sqlstr0 + "','" + txthistoimp.Text + "')";

            cmd = new SqlCommand(Sqlstr0, con);
            cmd.ExecuteNonQuery();
        }
        else
        {
            Sqlstr = "";
            Sqlstr = "update XRAY set cc='" + Convert.ToInt32(txtcompanycode.Text) + "',pcode='" + Convert.ToInt32(cbopcode.Text);
            Sqlstr = Sqlstr + "',Specimen='" + txthistox.Text;
            Sqlstr = Sqlstr + "',gross_exam='" + txtgexamx.Text + "',microscopic='" + txtmicrox.Text;

            Sqlstr = Sqlstr + "',Impression='" + txthistoimp.Text;

            Sqlstr = Sqlstr + "'  where pcode='" + Convert.ToInt32(cbopcode.Text) + "'";
            cmd = new SqlCommand(Sqlstr, con);
            cmd.ExecuteNonQuery();
        }
        Sqlstr0 = "";
        Sqlstr = "";

    }
}

private void BTNXRAYPRINT_Click(object sender, EventArgs e)
{
    Frmrepxray rpxray = new Frmrepxray();
    rpxray.Show();
}

private void BTNXRAYCANCEL_Click(object sender, EventArgs e)
{
    this.Close();
}

private void txtgexamx_TextChanged(object sender, EventArgs e)
{

}

private void txthistox_Enter(object sender, EventArgs e)
{
    this.KeyPreview = false;
}

private void txthistox_Leave(object sender, EventArgs e)
{
    this.KeyPreview = true;
}

private void txtgexamx_Enter(object sender, EventArgs e)
{
    this.KeyPreview = false;
}

private void txtgexamx_Leave(object sender, EventArgs e)
{
    this.KeyPreview = true;
}

private void txtmicrox_Enter(object sender, EventArgs e)
{
    this.KeyPreview = false;
}

private void txtmicrox_Leave(object sender, EventArgs e)
{
    this.KeyPreview = true;
}

private void txthistoimp_Enter(object sender, EventArgs e)
{
    this.KeyPreview = false;
}

private void txthistoimp_Leave(object sender, EventArgs e)
{
    this.KeyPreview = true;
}

private void CtSpecimen_Enter(object sender, EventArgs e)
{
    this.KeyPreview = false;
}

private void CtSpecimen_Leave(object sender, EventArgs e)
{
    this.KeyPreview = true;
}

private void CtBenign_Cell_Enter(object sender, EventArgs e)
{
    this.KeyPreview = false;
}

private void CtBenign_Cell_Leave(object sender, EventArgs e)
{
    this.KeyPreview = true;
}

private void CtEndocervical_Cell_Enter(object sender, EventArgs e)
{
    this.KeyPreview = false;
}

private void CtEndocervical_Cell_Leave(object sender, EventArgs e)
{
    this.KeyPreview = true;
}

private void Ctimp_Enter(object sender, EventArgs e)
{
    this.KeyPreview = false;
}

private void Ctimp_Leave(object sender, EventArgs e)
{
    this.KeyPreview = true;
}

private void cul_imp_Enter(object sender, EventArgs e)
{
    this.KeyPreview = false;
}

private void cul_imp_Leave(object sender, EventArgs e)
{
    this.KeyPreview = true;
}

private void txtnotepad_Enter(object sender, EventArgs e)
{
    this.KeyPreview = false;
}

private void txtnotepad_Leave(object sender, EventArgs e)
{
    this.KeyPreview = true;
}

private void tpstool_Click(object sender, EventArgs e)
{

}

private void SBPS_Aso_Qty_KeyPress(object sender, KeyPressEventArgs e)
{
    callnumber(e);
}

private void SBPS_Crp_Qty_KeyPress(object sender, KeyPressEventArgs e)
{
    callnumber(e);
}

private void SBPS_Rafactor_Qty_KeyPress(object sender, KeyPressEventArgs e)
{
    callnumber(e);
}

private void SBS_trop_Qty_KeyPress(object sender, KeyPressEventArgs e)
{
    callnumber(e);
}

private void BDc_Eosinophils_Validating(object sender, CancelEventArgs e)
{
    int neu = Convert.ToInt32(BDc_Neutrophild.Text);
    int lymp = Convert.ToInt32(BDc_Lymphocytes.Text);
    int eos = Convert.ToInt32(BDc_Eosinophils.Text);
    int mon = Convert.ToInt32(BDc_Monocytes.Text);
    int baso = Convert.ToInt32(BDc_Basophils.Text);
    int TDC = neu + lymp + eos + mon + baso;
    int tdcb = 100 - TDC;
    dctot();
    if (neu + lymp + eos + mon + baso != 0)
    {
        if (neu + lymp + eos + mon + baso != 100)
        {
            //dctot();
            labeleos.Text = tdcb.ToString();
            //MessageBox.Show("Balance  = " + tdcb);
            //BDc_Neutrophild.Focus();
        }
    }
}

private void BDc_Lymphocytes_Validating(object sender, CancelEventArgs e)
{
    int neu = Convert.ToInt32(BDc_Neutrophild.Text);
    int lymp = Convert.ToInt32(BDc_Lymphocytes.Text);
    int eos = Convert.ToInt32(BDc_Eosinophils.Text);
    int mon = Convert.ToInt32(BDc_Monocytes.Text);
    int baso = Convert.ToInt32(BDc_Basophils.Text);
    int TDC = neu + lymp + eos + mon + baso;
    int tdcb = 100 - TDC;
    dctot();
    if (neu + lymp + eos + mon + baso != 0)
    {
        if (neu + lymp + eos + mon + baso != 100)
        {
            //dctot();
            labellym.Text = tdcb.ToString();
            //MessageBox.Show("Balance  = " + tdcb);
            //BDc_Neutrophild.Focus();
        }
    }
}

private void BDc_Neutrophild_Validating(object sender, CancelEventArgs e)
{
    int neu = Convert.ToInt32(BDc_Neutrophild.Text);
    int lymp = Convert.ToInt32(BDc_Lymphocytes.Text);
    int eos = Convert.ToInt32(BDc_Eosinophils.Text);
    int mon = Convert.ToInt32(BDc_Monocytes.Text);
    int baso = Convert.ToInt32(BDc_Basophils.Text);
    int TDC = neu + lymp + eos + mon + baso;
    int tdcb = 100 - TDC;
    dctot();
    if (neu + lymp + eos + mon + baso != 0)
    {
        if (neu + lymp + eos + mon + baso != 100)
        {

            //dctot();
            labelneu.Text = tdcb.ToString();
            // MessageBox.Show("Balance  = " + tdcb);
            //BDc_Neutrophild.Focus();
        }
    }
}

private void cbomy1_SelectedIndexChanged(object sender, EventArgs e)
{

}
        //-end all
private void dctot()
{
    labelneu.Text = "";
    labellym.Text = "";
    labelmon.Text = "";
    labeleos.Text = "";
    labelbas.Text = "";
}

private void tpurine_Click(object sender, EventArgs e)
{

}

private void label145_Click(object sender, EventArgs e)
{

}

private void UU_urine_b_hcg_TextChanged(object sender, EventArgs e)
{

}

private void UP_color_TextChanged(object sender, EventArgs e)
{

}

private void rbwhatsapp_Click(object sender, EventArgs e)
{
    System.Diagnostics.Process.Start("https://api.whatsapp.com/send?phone=919937726338");
}

private void cboname_KeyPress(object sender, KeyPressEventArgs e)
{
    e.KeyChar = Char.ToUpper(e.KeyChar);
}

private void cbodoctor_KeyPress(object sender, KeyPressEventArgs e)
{
    e.KeyChar = Char.ToUpper(e.KeyChar);
}

private void cbopcode_KeyPress(object sender, KeyPressEventArgs e)
{
    e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == 8);
}

private void Bcr_LFT_Bilirubin_total_Validating(object sender, CancelEventArgs e)
{
    Bcr4_LFT_Indirect.Text = Convert.ToString(Convert.ToDouble(Bcr_LFT_Bilirubin_total.Text) - Convert.ToDouble(Bcr_LFT_Bilirubin_Direct.Text));
}

private void Bcr_LFT_Bilirubin_Direct_Validating(object sender, CancelEventArgs e)
{
    Bcr4_LFT_Indirect.Text = Convert.ToString(Convert.ToDouble(Bcr_LFT_Bilirubin_total.Text) - Convert.ToDouble(Bcr_LFT_Bilirubin_Direct.Text));
}

private void Bcr_LFT_Protein_Validating(object sender, CancelEventArgs e)
{
    Bcr_LFT_Globulin.Text = Convert.ToString(Convert.ToDouble(Bcr_LFT_Protein.Text) - Convert.ToDouble(Bcr_LFT_Albumin.Text));
}

private void Bcr_LFT_Albumin_Validating(object sender, CancelEventArgs e)
{
    Bcr_LFT_Globulin.Text = Convert.ToString(Convert.ToDouble(Bcr_LFT_Protein.Text) - Convert.ToDouble(Bcr_LFT_Albumin.Text));
}

private void Bcr1_HBAC_good_Validating(object sender, CancelEventArgs e)
{
    if (Convert.ToDouble(Bcr1_HBAC_good.Text) != 0.00)
    {
        Bcr1_MBGE.Text = Convert.ToString((Convert.ToDouble(Bcr1_HBAC_good.Text) * 28.7) - 46.7);
    }
    else
    {
        Bcr1_MBGE.Text = "0.00";
    }
}

private void Bcr_LP_Cholesterol_Validating(object sender, CancelEventArgs e)
{
   // Bcr_LP_LDLCholesterol.Text = Convert.ToString(Convert.ToDouble(Bcr_LP_Cholesterol.Text) - Convert.ToDouble(Bcr_LP_HDLCholesterol.Text) - (Convert.ToDouble(Bcr_LP_Triglycerides.Text) / 5));
}



    }
}