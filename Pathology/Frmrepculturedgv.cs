using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Pathology
{
    public partial class Frmrepculturedgv : Form
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
        public static String Gdescpss = "";
        public static String Gresultpss = "";
        public static String gtest = "";
        
        public Frmrepculturedgv()
        {
            InitializeComponent();
        }

        private void Frmrepculturedgv_Load(object sender, EventArgs e)
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

            da = new SqlDataAdapter("select pcode from patient_master order by pcode", con);
            ds5 = new DataSet();
            da.Fill(ds5);
            for (int i = 0; i < ds5.Tables[0].Rows.Count; i++)
            {
                //this.cboname.Items.Add(ds5.Tables[0].Rows[i][0].ToString());
                this.cbopcode.Items.Add(ds5.Tables[0].Rows[i][0].ToString());
            }
            da.Dispose();
            da = new SqlDataAdapter("select Name from Doctor order by name ", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                cbodoctor.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            da.Dispose();
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

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btngo_Click(object sender, EventArgs e)
        {
            String strsql = "";
            int i = 0;
            String organism = "";
            String colonycount = "";
            String Gdescpss = "";
            strsql = "select a.cc,a.patient_name,a.pcode,a.sex,a.age,a.doctor,a.date_exam,a.month_year,a.scn,a.tpt,";
            //strsql = strsql + "b.cc,b.pcode,b.amoxicillin,b.amoxicillin_no,b.amoxicillin_srm,b.ampicillin,b.ampicillin_no,b.ampicillin_srm,b.amikacin,b.amikacin_no,b.amikacin_srm,b.cephalexin,b.cephalexin_no,b.cephalexin_srm,b.ceftazidime,b.ceftazidime_no,b.ceftazidime_srm,b.ceftriaxone,b.ceftriaxone_no,b.ceftriaxone_srm,b.cloxacillin,b.cloxacillin_no,b.cloxacillin_srm,b.co_trimoxazole,b.co_trimoxazole_no,b.co_trimoxazole_srm,b.cefazolin,b.cefazolin_no,b.cefazolin_srm,b.cefotaxime,b.cefotaxime_no,b.cefotaxime_srm,b.ciprofloxacin,b.ciprofloxacin_no,b.ciprofloxacin_srm,b.doxycycline,b.doxycycline_no,b.doxycycline_srm,";
            //strsql = strsql + "b.erythromycin,b.erythromycin_no,b.erythromycin_srm,b.gentamycin,b.gentamycin_no,b.gentamycin_srm,b.gemifloxacin,b.gemifloxacin_no,b.gemifloxacin_srm,neomycin,b.neomycin_no,b.neomycin_srm,b.nitrofurantion,b.nitrofurantion_no,b.nitrofurantion_srm,b.norfloxacine,b.norfloxacine_no,b.norfloxacine_srm,";
            //strsql = strsql + "b.netromycin,b.netromycin_no,b.netromycin_srm,ofloxacin,b.ofloxacin_no,b.ofloxacin_srm,b.piperacillin,b.piperacillin_no,b.piperacillin_srm,b.pencillin,pencillin_no,b.pencillin_srm,b.streptomycin,b.streptomycin_no,b.streptomycin_srm,b.tetracycline,b.tetracycline_no,b.tetracycline_srm,";
            strsql = strsql + "b.antibiotic,b.antibiotics,b.antibioticv,b.organism_isolated,b.colony_count,b.cu_imp,b.test";

           // strsql = strsql + " from patient_master a left join Cultureext b on (a.pcode=b.pcode) where a.pcode='" + cbopcode.Text + "' and a.pcode=b.pcode";
            strsql = strsql + " from patient_master a left join Cultureext b on (a.pcode=b.pcode) where a.pcode='" + cbopcode.Text + "' ";

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
                //if (checkBox1.Checked == false)
                //{
                    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
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
                        organism = ds.Tables[0].Rows[i][13].ToString();
                        colonycount = ds.Tables[0].Rows[i][14].ToString();
                        Gdescpss = ds.Tables[0].Rows[i][15].ToString();
                        gtest = ds.Tables[0].Rows[i][16].ToString();
                        //if (ds.Tables[0].Rows[i][10].ToString() != "" || ds.Tables[0].Rows[i][12].ToString() != "")
                        //{
                            Ggrp = "";
                            Gdesc = "";
                            Gdesc1 = "";
                            Gresult = ds.Tables[0].Rows[i][10].ToString();
                            Gresult1 = ds.Tables[0].Rows[i][11].ToString();
                            Gresult2 = ds.Tables[0].Rows[i][12].ToString();
                            Gunit = ds.Tables[0].Rows[i][15].ToString(); 
                            Gnormalrange = "o/14-17";
                            Gnormalrange1 = "20/18";
                            ADDROW();
                        //}

                    }




                    // Repblood cashbankrep = new Repblood();
                    //if (cbodoctor.Text.ToUpper().Contains("DEBASISH"))
                    //{
                    
                 if (checkBox1.Checked == false)
                {
                
                
                Repculturedgv cashbankrep = new Repculturedgv();

                        //cashbankrep.SetDatabaseLogon("sa", "software", @".\sqlexpress", "pathology2627");
                        cashbankrep.SetDataSource(dt);
                        crv.ReportSource = cashbankrep;

                        //cashbankrep.SetParameterValue(2, reportname);
                        cashbankrep.SetParameterValue(0, Gdescpss);
                        cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows[0][5].ToString());
                        cashbankrep.SetParameterValue(2, ds2.Tables[0].Rows[0][6].ToString());
                        cashbankrep.SetParameterValue(3, organism);
                        cashbankrep.SetParameterValue(4, colonycount);
                        cashbankrep.SetParameterValue(5, gtest);
                        cashbankrep.SetParameterValue(6, ds2.Tables[0].Rows[0][9].ToString());
                        cashbankrep.SetParameterValue(7, ds2.Tables[0].Rows[0][10].ToString());
                        cashbankrep.SetParameterValue(8, ds2.Tables[0].Rows[0][11].ToString());
                        //cashbankrep.SetParameterValue(4, Gresultpss);

                    }
                    else
                    {
                        Repculturenogrowth1 cashbankrep = new Repculturenogrowth1();

                        //cashbankrep.SetDatabaseLogon("sa", "software", @".\sqlexpress", "pathology2627");
                        cashbankrep.SetDataSource(dt);
                        crv.ReportSource = cashbankrep;

                        //cashbankrep.SetParameterValue(2, reportname);
                        cashbankrep.SetParameterValue(0, Gdescpss);
                        cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows[0][5].ToString());
                        cashbankrep.SetParameterValue(2, ds2.Tables[0].Rows[0][6].ToString());
                        cashbankrep.SetParameterValue(3, organism);
                        cashbankrep.SetParameterValue(4, colonycount);
                        cashbankrep.SetParameterValue(5, gtest);
                        cashbankrep.SetParameterValue(6, ds2.Tables[0].Rows[0][9].ToString());
                        cashbankrep.SetParameterValue(7, ds2.Tables[0].Rows[0][10].ToString());
                        cashbankrep.SetParameterValue(8, ds2.Tables[0].Rows[0][11].ToString());
                        
                        
                        //cashbankrep.SetParameterValue(4, Gresultpss);
                    }
                    crv.Refresh();
                    // crv.PrintReport();

                    //end blood report
                    //start biochem report

                }
            }
            //else
            //{

            //    {
            //        //cashbankrep = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            //        //cashbankrep.Load("/Hope_account/Hope_account/repcash_Bank.rpt");
            //        dt = new DataTable();
            //        //Ds_hope ds1 = new Ds_hope();
            //        //Pathology_Ds Ds1 = new Pathology_Ds();
            //        ds1 = new DataSet();
            //        dt = ds1.Tables.Add("Pathology_Dt");
            //        dt.Columns.Add("Grp", System.Type.GetType("System.String"));
            //        dt.Columns.Add("Desc", System.Type.GetType("System.String"));
            //        dt.Columns.Add("Desc1", System.Type.GetType("System.String"));
            //        dt.Columns.Add("Result", System.Type.GetType("System.String"));
            //        dt.Columns.Add("Result1", System.Type.GetType("System.String"));
            //        dt.Columns.Add("Result2", System.Type.GetType("System.String"));
            //        dt.Columns.Add("Unit", System.Type.GetType("System.String"));
            //        dt.Columns.Add("Normal_Range", System.Type.GetType("System.String"));
            //        dt.Columns.Add("Normal_Range1", System.Type.GetType("System.String"));
            //        //String acd = ds.Tables[0].Rows[i][53].ToString();
            //        //while (acd == ds.Tables[0].Rows[i][0].ToString())
            //        dt.Columns.Add("Pcode", System.Type.GetType("System.Int32"));
            //        dt.Columns.Add("Age", System.Type.GetType("System.Int32"));
            //        dt.Columns.Add("Sex", System.Type.GetType("System.String"));
            //        dt.Columns.Add("Patient_Name", System.Type.GetType("System.String"));
            //        dt.Columns.Add("Dt_Report", System.Type.GetType("System.DateTime"));
            //        dt.Columns.Add("Doctor", System.Type.GetType("System.String"));
            //        dt.Columns.Add("month_year", System.Type.GetType("System.String"));
            //        dt.Columns.Add("scn", System.Type.GetType("System.String"));
            //        dt.Columns.Add("tpt", System.Type.GetType("System.String"));
            //        if (checkBox1.Checked == false)
            //        {
            //            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            //            {

            //                gcode = Convert.ToInt32(ds.Tables[0].Rows[i][2].ToString());
            //                gage = Convert.ToInt32(ds.Tables[0].Rows[i][4].ToString());
            //                gsex = ds.Tables[0].Rows[i][3].ToString();
            //                gpatient_name = ds.Tables[0].Rows[i][1].ToString();
            //                gdt_report = Convert.ToDateTime(ds.Tables[0].Rows[i][6].ToString());
            //                gdoctor = ds.Tables[0].Rows[i][5].ToString();
            //                gmnyr = ds.Tables[0].Rows[i][7].ToString();
            //                gscn = ds.Tables[0].Rows[i][8].ToString();
            //                gtpt = ds.Tables[0].Rows[i][9].ToString();
            //                organism = ds.Tables[0].Rows[i][13].ToString();
            //                colonycount = ds.Tables[0].Rows[i][14].ToString();
            //                Gdescpss = ds.Tables[0].Rows[i][15].ToString();
            //                gtest = ds.Tables[0].Rows[i][16].ToString();
            //                if (ds.Tables[0].Rows[i][10].ToString() != "" || ds.Tables[0].Rows[i][12].ToString() != "")
            //                {
            //                    Ggrp = "";
            //                    Gdesc = "";
            //                    Gdesc1 = "";
            //                    Gresult = ds.Tables[0].Rows[i][10].ToString();
            //                    Gresult1 = ds.Tables[0].Rows[i][11].ToString();
            //                    Gresult2 = ds.Tables[0].Rows[i][12].ToString();
            //                    Gunit = "";
            //                    Gnormalrange = "o/14-17";
            //                    Gnormalrange1 = "20/18";
            //                    ADDROW();
            //                }

            //            }




            //            // Repblood cashbankrep = new Repblood();
            //            if (cbodoctor.Text.ToUpper().Contains("DEBASISH"))
            //            {
            //                Repculturedgv cashbankrep = new Repculturedgv();

            //                cashbankrep.SetDatabaseLogon("sa", "software", @".\sqlexpress", "pathology2627");
            //                cashbankrep.SetDataSource(dt);
            //                crv.ReportSource = cashbankrep;

            //                //cashbankrep.SetParameterValue(2, reportname);
            //                cashbankrep.SetParameterValue(0, Gdescpss);
            //                cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows[0][5].ToString());
            //                cashbankrep.SetParameterValue(2, ds2.Tables[0].Rows[0][6].ToString());
            //                cashbankrep.SetParameterValue(3, organism);
            //                cashbankrep.SetParameterValue(4, colonycount);
            //                cashbankrep.SetParameterValue(5, gtest);
            //                //cashbankrep.SetParameterValue(4, Gresultpss);

            //            }
            //            else
            //            {
            //                Repculturedgv1 cashbankrep = new Repculturedgv1();

            //                cashbankrep.SetDatabaseLogon("sa", "software", @".\sqlexpress", "pathology2627");
            //                cashbankrep.SetDataSource(dt);
            //                crv.ReportSource = cashbankrep;

            //                //cashbankrep.SetParameterValue(2, reportname);
            //                cashbankrep.SetParameterValue(0, Gdescpss);
            //                cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows[0][5].ToString());
            //                cashbankrep.SetParameterValue(2, ds2.Tables[0].Rows[0][6].ToString());
            //                cashbankrep.SetParameterValue(3, organism);
            //                cashbankrep.SetParameterValue(4, colonycount);
            //                cashbankrep.SetParameterValue(5, gtest);
            //                //cashbankrep.SetParameterValue(4, Gresultpss);
            //            }
            //            crv.Refresh();
            //            // crv.PrintReport();

            //            //end blood report
            //            //start biochem report

            //        }

            //    }

            //}
       // }

        private void cbopcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("select  patient_name,pcode from patient_master where pcode='"+cbopcode.Text+"' order by pcode", con);
            ds5 = new DataSet();
            da.Fill(ds5);
            cboname.Text = ds5.Tables[0].Rows[0][0].ToString();
        }
    }
}


  
