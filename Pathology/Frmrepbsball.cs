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
    public partial class Frmrepbsball : Form
    {

        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        SqlDataReader dr1;
        public static DataRow dr;
        public static DataTable dt;
        DataSet ds, ds1, ds2, ds5;
        public string Ggrp, Gdesc, Gdesc1, Gresult, Gunit, Gnormalrange, Gnormalrange1;
        public int gcode, gage;
        public string gsex, gpatient_name, gdoctor, gmnyr, gscn, gtpt;
        public DateTime gdt_report;
        public string reportname;
        public String Gdescpss = "";
        public String Gresultpss = "";
        public String Gresultbl = "";
        public Frmrepbsball()
        {
            InitializeComponent();
        }

        private void Frmrepbsball_Load(object sender, EventArgs e)
        {
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
            // cbotype.Items.Add("Sale");
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


        private void cbopcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("select patient_name from patient_master where pcode='" + cbopcode.Text + "'", con);
            ds = new DataSet();
            da.Fill(ds);
            cboname.Text = ds.Tables[0].Rows[0][0].ToString();
        }

        private void btngo_Click(object sender, EventArgs e)
        {
            String strsql = "";
            int i = 0;


            if (radioButton2.Checked == true)
            {
                reportname = "              HAEMATOLOGY  REPORT";
            }
            else
            {
                reportname = "COMPLETE  BLOOD  COUNT  REPORT";
            }

            if (radioButton2.Checked == true)
            {
                strsql = "select a.cc,a.patient_name,a.pcode,a.sex,a.age,a.doctor,a.date_exam,a.month_year,a.scn,a.tpt,";
                strsql = strsql + "b.cc,b.pcode,b.BG_Blood_Group,b.BR_RhD_Typing,b.BDc_Neutrophild,b.BDc_Lymphocytes,b.BDc_Eosinophils,b.BDc_Monocytes,b.BDc_Basophils,b.BDc_Twbc,b.BDc_Trbc,b.BDc_Tplatelets,";
                strsql = strsql + "b.BDc_Aec,b.BDc_Tnc,b.BDc_Reticulocyte_Count,b.BDc_PCV,b.BDC_mcv,b.BDC_mch,b.BDC_mchc,b.BDc_Mp_ICT_QBC_Smear,b.BDc_Mp_ICT,b.BDc_Mf_ICT_QBC_Smear,b.BDc_Mf_ICT,b.BDc_Hb,b.BDc_ESR_1sthour,b.BDc_ESR_2ndhour,";
                strsql = strsql + "b.BDc_Bleeding_Time,b.BDc_Clotting_Time,b.BDc_nasalsmear,b.BDc_nasalsmear_right,b.BDc_Sickle_cell,b.BDC_Prothombintime,b.BDC_Prothombintime_cont,b.BDC_Prothombintime_inr,";

                strsql = strsql + "b.BDC_pss,b.bl_imp,b.BDc_Rcdw,b.BDc_mpv,b.BDc_pdw";
                strsql = strsql + " from patient_master a,Blood b where a.pcode='" + cbopcode.Text + "' and a.pcode=b.pcode";

                da = new SqlDataAdapter(strsql, con);
                ds = new DataSet();
                da.Fill(ds);

                //int i = 0;
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
                    if (ds.Tables[0].Rows[i][12].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "BLOOD GROUP";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][12].ToString();
                        Gunit = "";
                        Gnormalrange = "";
                        Gnormalrange1 = "";
                        ADDROW();

                    }

                    if (ds.Tables[0].Rows[i][13].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "Rh (D) Type";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][13].ToString();
                        Gunit = "";
                        Gnormalrange = "";
                        Gnormalrange1 = "";
                        ADDROW();
                    }

                    int neu = Convert.ToInt32(ds.Tables[0].Rows[i][14].ToString());
                    int lymp = Convert.ToInt32(ds.Tables[0].Rows[i][15].ToString());
                    int eos = Convert.ToInt32(ds.Tables[0].Rows[i][16].ToString());
                    int mon = Convert.ToInt32(ds.Tables[0].Rows[i][17].ToString());
                    int baso = Convert.ToInt32(ds.Tables[0].Rows[i][18].ToString());
                    if (neu + lymp + eos + mon + baso != 0)
                    {



                        //if (Convert.ToInt32(ds.Tables[0].Rows[i][14].ToString()) != 0)
                        //{
                        Ggrp = "DIFFERENTIAL COUNT";
                        Gdesc = "NEUTROPHILS";
                        Gdesc1 = "";
                        if (neu < 10)
                        {
                            Gresult = "0" + ds.Tables[0].Rows[i][14].ToString();
                        }
                        else
                        {
                            Gresult = ds.Tables[0].Rows[i][14].ToString();
                        }
                        Gunit = "%";
                        Gnormalrange = "30 - 70 ";
                        Gnormalrange1 = "";
                        ADDROW();
                        //}

                        // if (Convert.ToInt32(ds.Tables[0].Rows[i][15].ToString()) != 0)
                        // {
                        Ggrp = "DIFFERENTIAL COUNT";
                        Gdesc = "LYMPHOCYTES";
                        Gdesc1 = "";

                        if (lymp < 10)
                        {
                            Gresult = "0" + ds.Tables[0].Rows[i][15].ToString();
                        }
                        else
                        {

                            Gresult = ds.Tables[0].Rows[i][15].ToString();
                        }
                        Gunit = "%";
                        Gnormalrange = "15 - 40 ";
                        Gnormalrange1 = "";
                        ADDROW();
                        // }
                        // if (Convert.ToInt32(ds.Tables[0].Rows[i][16].ToString()) != 0)
                        // {
                        Ggrp = "DIFFERENTIAL COUNT";
                        Gdesc = "EOSINOPHILS";
                        Gdesc1 = "";
                        if (eos < 10)
                        {
                            Gresult = "0" + ds.Tables[0].Rows[i][16].ToString();
                        }
                        else
                        {

                            Gresult = ds.Tables[0].Rows[i][16].ToString();
                        }
                        Gunit = "%";
                        Gnormalrange = "00 - 06 ";
                        Gnormalrange1 = "";
                        ADDROW();
                        // }


                        //  if (Convert.ToInt32(ds.Tables[0].Rows[i][17].ToString()) != 0)
                        //  {
                        Ggrp = "DIFFERENTIAL COUNT";
                        Gdesc = "MONOCYTES";
                        Gdesc1 = "";
                        if (mon < 10)
                        {
                            Gresult = "0" + ds.Tables[0].Rows[i][17].ToString();
                        }
                        else
                        {

                            Gresult = ds.Tables[0].Rows[i][17].ToString();
                        }
                        Gunit = "%";
                        Gnormalrange = "02 - 10 ";

                        Gnormalrange1 = "";
                        ADDROW();
                        // }

                        //  if (Convert.ToInt32(ds.Tables[0].Rows[i][18].ToString()) != 0)
                        //  {
                        Ggrp = "DIFFERENTIAL COUNT";
                        Gdesc = "BASOPHILS";
                        Gdesc1 = "";

                        if (baso < 10)
                        {
                            Gresult = "0" + ds.Tables[0].Rows[i][18].ToString();
                        }
                        else
                        {

                            Gresult = ds.Tables[0].Rows[i][18].ToString();
                        }


                        Gunit = "%";
                        Gnormalrange = "0 - 1 ";
                        Gnormalrange1 = "";
                        ADDROW();
                        // }
                    }

                    if (Convert.ToInt32(ds.Tables[0].Rows[i][19].ToString()) != 0)
                    {
                        Ggrp = "";
                        Gdesc = "TOTAL LEUCOCYTE COUNT";
                        Gdesc1 = "";

                        Gresult = ds.Tables[0].Rows[i][19].ToString().Trim();
                        //Gresult = Gresult.TrimStart('0').TrimEnd('0', '.');


                        Gunit = "/cmm";
                        Gnormalrange = "4000 - 10000 ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][20].ToString()) != 0.00)
                    {
                        Ggrp = "";
                        Gdesc = "TOTAL ERYTHROCYTE COUNT (RBC)";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][20].ToString();


                        Gunit = "million/cmm.";
                        Gnormalrange = "4.0 - 5.9 ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][46].ToString()) != 0.00)
                    {
                        Ggrp = "";
                        Gdesc = "RDW";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][46].ToString();

                        Gunit = "%";
                        Gnormalrange = "8.0 - 12.0 ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }




                    if (Convert.ToDouble(ds.Tables[0].Rows[i][21].ToString()) != 0.00)
                    {
                        Ggrp = "";
                        Gdesc = "PLATELET COUNT";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][21].ToString();

                        Gunit = "lakhs";
                        Gnormalrange = "1.5 - 4.5 ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }

                    if (Convert.ToInt32(ds.Tables[0].Rows[i][22].ToString()) != 0)
                    {
                        Ggrp = "";
                        Gdesc = "ABSOLUTE EOSINOPHIL COUNT";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][22].ToString();
                        //Gresult = Gresult.TrimStart('0').TrimEnd('0', '.');
                        Gunit = "cells/cmm.";
                        Gnormalrange = "40  - 440 ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (Convert.ToInt32(ds.Tables[0].Rows[i][23].ToString()) != 0)
                    {
                        Ggrp = "";
                        Gdesc = "TOTAL NEUTROPHIL COUNT";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][23].ToString();
                        //Gresult = Gresult.TrimStart('0').TrimEnd('0', '.');
                        Gunit = "cells/cmm.";
                        Gnormalrange = "2,500 - 6,500 ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (Convert.ToInt32(ds.Tables[0].Rows[i][24].ToString()) != 0)
                    {
                        Ggrp = "";
                        Gdesc = "RDW-SD";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][24].ToString();

                        Gunit = "%";
                        Gnormalrange = "1.0 - 2.0";
                        Gnormalrange1 = "";
                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][25].ToString()) != 0.00)
                    {
                        Ggrp = "";
                        Gdesc = "P.C.V";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][25].ToString();

                        Gunit = "%";
                        Gnormalrange = "35 - 54 ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][26].ToString()) != 0)
                    {
                        Ggrp = "";
                        Gdesc = "M.C.V";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][26].ToString();

                        Gunit = " fl";
                        Gnormalrange = "82 - 100";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][27].ToString()) != 0)
                    {
                        Ggrp = "";
                        Gdesc = "M.C.H";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][27].ToString();

                        Gunit = "pgms";
                        Gnormalrange = "27 - 32 ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][28].ToString()) != 0)
                    {
                        Ggrp = "";
                        Gdesc = "M.C.H.C.";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][28].ToString();

                        Gunit = "g/dl";
                        Gnormalrange = "28 - 40 ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][47].ToString()) != 0.00)
                    {
                        Ggrp = "";
                        Gdesc = "MPV";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][47].ToString();

                        Gunit = "%";
                        Gnormalrange = "6.0 - 13.0 ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][48].ToString()) != 0.00)
                    {
                        Ggrp = "";
                        Gdesc = "PDW";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][48].ToString();

                        Gunit = "%";
                        Gnormalrange = "6.0 - 10.0 ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }









                    if (ds.Tables[0].Rows[i][29].ToString() != "")
                    {
                        Ggrp = "PARASITES";
                        Gdesc = "MALARIA PARASITES (SLIDE METHOD)";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][29].ToString();
                        Gunit = "";
                        Gnormalrange = "";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][30].ToString() != "")
                    {
                        Ggrp = "PARASITES";
                        Gdesc = "MALARIA PARASITES (ICT METHOD)";
                        Gdesc1 = "";
                        //Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][30].ToString();
                        Gunit = "";
                        Gnormalrange = "";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][31].ToString() != "")
                    {
                        Ggrp = "PARASITES";
                        Gdesc = "MICRO FILARIA (SLIDE METHOD)";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][31].ToString();
                        Gunit = "";
                        Gnormalrange = "";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][32].ToString() != "")
                    {
                        Ggrp = "PARASITES";
                        Gdesc = "MICRO FILARIA (ICT METHOD)";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][32].ToString();
                        Gunit = "";
                        Gnormalrange = "";
                        Gnormalrange1 = "";
                        ADDROW();
                    }



                    if (Convert.ToDouble(ds.Tables[0].Rows[i][33].ToString()) != 0.00)
                    {
                        Ggrp = "";
                        Gdesc = "HAEMOGLOBIN";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][33].ToString();

                        Gunit = "gm/dl";
                        Gnormalrange = "M: 12 - 18 ";
                        Gnormalrange1 = "F: 12 - 15 ";
                        ADDROW();
                    }

                    if (Convert.ToInt32(ds.Tables[0].Rows[i][34].ToString()) != 0)
                    {
                        Ggrp = "";
                        Gdesc = "E.S.R. ( 1st hour )";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][34].ToString();
                        // Gresult = Gresult.TrimStart('0').TrimEnd('0', '.');
                        Gunit = "mm";
                        //Gnormalrange = "M: 3 - 5 ";
                        //Gnormalrange1 = "F: 4 - 8 ";
                        Gnormalrange = "<20 mm";
                        Gnormalrange1 = " ";
                        ADDROW();
                    }
                    if (Convert.ToInt32(ds.Tables[0].Rows[i][35].ToString()) != 0)
                    {
                        Ggrp = "";
                        Gdesc = "E.S.R. ( 2nd hour )";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][35].ToString();
                        // Gresult = Gresult.TrimStart('0').TrimEnd('0', '.');
                        Gunit = "mm";
                        //Gnormalrange = "M: 3 - 5 ";
                        //Gnormalrange1 = "F: 4 - 8 ";
                        Gnormalrange = "<20 mm";
                        Gnormalrange1 = " ";
                        ADDROW();
                    }

                    if (ds.Tables[0].Rows[i][36].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "BLEEDING TIME ( BT )";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][36].ToString();
                        Gunit = "min. sec.";
                        Gnormalrange = "01 - 05 ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][37].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "CLOTTING TIME (CT)";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][37].ToString();
                        Gunit = "min. sec.";
                        Gnormalrange = "03 - 08 ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][38].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "NASAL SMEARS FOR EOSINOPHILS : LEFT";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][38].ToString();
                        Gunit = "";
                        Gnormalrange = "Negative/Positive ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][39].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "NASAL SMEARS FOR EOSINOPHILS : RIGHT";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][39].ToString();
                        Gunit = "";
                        Gnormalrange = "Negative/Positive ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }


                    if (ds.Tables[0].Rows[i][40].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "SICKLING TEST                                               (After 24 hours incubation)";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][40].ToString();
                        Gunit = "";
                        Gnormalrange = "Negative/Positive ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][41].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "PROTHROMBIN TIME (PT) ";
                        Gdesc1 = "(TEST)";
                        Gresult = ds.Tables[0].Rows[i][41].ToString();
                        Gunit = "";
                        Gnormalrange = " ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }


                    if (ds.Tables[0].Rows[i][42].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "";
                        Gdesc1 = "(CONTROL)";
                        Gresult = ds.Tables[0].Rows[i][42].ToString();
                        Gunit = "";
                        Gnormalrange = " ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (ds.Tables[0].Rows[i][43].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "";
                        Gdesc1 = "(INR)";
                        Gresult = ds.Tables[0].Rows[i][43].ToString();
                        Gunit = "";
                        Gnormalrange = " ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }

                    if (ds.Tables[0].Rows[i][44].ToString() != "")
                    {
                        Gdescpss = " COMMENT ON PERIPHERAL SMEAR :-";
                    }
                    else
                    {
                        Gdescpss = "";
                    }
                    //Gdescpss = "P.S.";
                    Gresultpss = ds.Tables[0].Rows[i][44].ToString();
                    Gresultbl = "";
                    if (ds.Tables[0].Rows[i][45].ToString() != "")
                    {
                        Gresultbl = ds.Tables[0].Rows[i][45].ToString();

                    }






                }
            }
            else if (radioButton1.Checked == true)
            {

                strsql = "select a.cc,a.patient_name,a.pcode,a.sex,a.age,a.doctor,a.date_exam,a.month_year,a.scn,a.tpt,";
                strsql = strsql + "b.cc,b.pcode,b.BDc_ESR_1sthour,b.BDc_ESR_2ndhour,b.BDc_Hb,b.BDc_Trbc,b.BDc_Tplatelets,b.BDc_Twbc,b.BDc_PCV,b.BDC_mcv,b.BDC_mch,b.BDC_mchc,b.BDc_Neutrophild,b.BDc_Lymphocytes,b.BDc_Eosinophils,b.BDc_Monocytes,b.BDc_Basophils,b.BDC_pss,b.bl_imp,b.BDc_Rcdw,b.BDc_mpv,b.BDc_pdw";

                strsql = strsql + " from patient_master a,Blood b where a.pcode='" + cbopcode.SelectedItem + "' and a.pcode=b.pcode";

                da = new SqlDataAdapter(strsql, con);
                ds = new DataSet();
                da.Fill(ds);

                //int i = 0;
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





                    if (Convert.ToDouble(ds.Tables[0].Rows[i][14].ToString()) != 0.00)
                    {
                        Ggrp = "";
                        Gdesc = "HAEMOGLOBIN";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][14].ToString();
                        //   Double mch1 = Convert.ToDouble(Gresult);
                        //   Gresult = Math.Round(mch1, 1).ToString();
                        //Gresult = Gresult.TrimStart('0').TrimEnd('0', '.');
                        Gunit = "gm/dl";
                        Gnormalrange = "12 - 18 ";
                        Gnormalrange1 = "";
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

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][29].ToString()) != 0.00)
                    {
                        Ggrp = "";
                        Gdesc = "RDW";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][29].ToString();

                        Gunit = "%";
                        Gnormalrange = "8.0 - 12.0 ";
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
                        Gnormalrange = "1.5 - 4.5 ";
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
                        Gnormalrange = "4000 - 10000 ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][18].ToString()) != 0.00)
                    {
                        Ggrp = "";
                        Gdesc = "PACKED CELL VOLUME( PCV )";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][18].ToString();

                        Gunit = "%";
                        Gnormalrange = "M: 35 - 54 ";

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
                        Gnormalrange = "82 - 100";

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
                        Gnormalrange = "28 - 40 ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }

                    if (Convert.ToDouble(ds.Tables[0].Rows[i][30].ToString()) != 0.00)
                    {
                        Ggrp = "";
                        Gdesc = "MPV";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][30].ToString();

                        Gunit = "%";
                        Gnormalrange = "6.0 - 13.0 ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[i][31].ToString()) != 0.00)
                    {
                        Ggrp = "";
                        Gdesc = "PDW";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][31].ToString();

                        Gunit = "%";
                        Gnormalrange = "6.0 - 10.0 ";
                        Gnormalrange1 = "";
                        ADDROW();
                    }




                    int neu = Convert.ToInt32(ds.Tables[0].Rows[i][22].ToString());
                    int lymp = Convert.ToInt32(ds.Tables[0].Rows[i][23].ToString());
                    int eos = Convert.ToInt32(ds.Tables[0].Rows[i][24].ToString());
                    int mon = Convert.ToInt32(ds.Tables[0].Rows[i][25].ToString());
                    int baso = Convert.ToInt32(ds.Tables[0].Rows[i][26].ToString());
                    if (neu + lymp + eos + mon + baso != 0)
                    {

                        Ggrp = "DIFFERENTIAL COUNT";
                        Gdesc = "NEUTROPHILS";
                        Gdesc1 = "";
                        if (neu < 10)
                        {
                            Gresult = "0" + ds.Tables[0].Rows[i][22].ToString();
                        }
                        else
                        {
                            Gresult = ds.Tables[0].Rows[i][22].ToString();
                        }
                        Gunit = "%";
                        Gnormalrange = "30 - 70 ";
                        Gnormalrange1 = "";
                        ADDROW();
                        //}

                        // if (Convert.ToInt32(ds.Tables[0].Rows[i][15].ToString()) != 0)
                        // {
                        Ggrp = "DIFFERENTIAL COUNT";
                        Gdesc = "LYMPHOCYTES";
                        Gdesc1 = "";

                        if (lymp < 10)
                        {
                            Gresult = "0" + ds.Tables[0].Rows[i][23].ToString();
                        }
                        else
                        {

                            Gresult = ds.Tables[0].Rows[i][23].ToString();
                        }
                        Gunit = "%";
                        Gnormalrange = "15 - 40 ";
                        Gnormalrange1 = "";
                        ADDROW();
                        // }
                        // if (Convert.ToInt32(ds.Tables[0].Rows[i][16].ToString()) != 0)
                        // {
                        Ggrp = "DIFFERENTIAL COUNT";
                        Gdesc = "EOSINOPHILS";
                        Gdesc1 = "";
                        if (eos < 10)
                        {
                            Gresult = "0" + ds.Tables[0].Rows[i][24].ToString();
                        }
                        else
                        {

                            Gresult = ds.Tables[0].Rows[i][24].ToString();
                        }
                        Gunit = "%";
                        Gnormalrange = "00 - 06 ";
                        Gnormalrange1 = "";
                        ADDROW();
                        // }


                        //  if (Convert.ToInt32(ds.Tables[0].Rows[i][17].ToString()) != 0)
                        //  {
                        Ggrp = "DIFFERENTIAL COUNT";
                        Gdesc = "MONOCYTES";
                        Gdesc1 = "";
                        if (mon < 10)
                        {
                            Gresult = "0" + ds.Tables[0].Rows[i][25].ToString();
                        }
                        else
                        {

                            Gresult = ds.Tables[0].Rows[i][25].ToString();
                        }
                        Gunit = "%";
                        Gnormalrange = "02 - 10 ";

                        Gnormalrange1 = "";
                        ADDROW();
                        // }

                        //  if (Convert.ToInt32(ds.Tables[0].Rows[i][18].ToString()) != 0)
                        //  {
                        Ggrp = "DIFFERENTIAL COUNT";
                        Gdesc = "BASOPHILS";
                        Gdesc1 = "";

                        if (baso < 10)
                        {
                            Gresult = "0" + ds.Tables[0].Rows[i][26].ToString();
                        }
                        else
                        {

                            Gresult = ds.Tables[0].Rows[i][26].ToString();
                        }


                        Gunit = "%";
                        Gnormalrange = "0 - 1 ";
                        Gnormalrange1 = "";
                        ADDROW();
                        // }
                    }
                    if (ds.Tables[0].Rows[i][27].ToString() != "")
                    {
                        Gdescpss = "COMMENT ON PERIPHERAL SMEAR :-";
                    }
                    else
                    {
                        Gdescpss = "";
                    }
                    Gresultpss = ds.Tables[0].Rows[i][27].ToString();
                    Gresultbl = "";
                    if (ds.Tables[0].Rows[i][28].ToString() != "")
                    {

                        Gresultbl = ds.Tables[0].Rows[i][28].ToString();
                        // Gresult = Gresult.TrimStart('0').TrimEnd('0', '.');


                    }









                }

            }


            da.Dispose();
            da = new SqlDataAdapter("select test,method,result,unit,normal_range from bloodext where pcode='" + cbopcode.Text + "'", con);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {

                for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i][2].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = ds.Tables[0].Rows[i][0].ToString().Trim() + "(" + ds.Tables[0].Rows[i][1].ToString().Trim() + ")";
                        Gdesc1 = "";
                        Gresult = ds.Tables[0].Rows[i][2].ToString();
                        // Gresult = Gresult.TrimStart('0').TrimEnd('0', '.');
                        Gunit = ds.Tables[0].Rows[i][3].ToString();
                        Gnormalrange = ds.Tables[0].Rows[i][4].ToString();
                        Gnormalrange1 = "";
                        ADDROW();
                    }
                }
            }


            if (radioButton3.Checked == true)
            {

                strsql = "";
                strsql = "select a.cc,a.patient_name,a.pcode,a.sex,a.age,a.doctor,a.date_exam,a.month_year,a.scn,a.tpt,";
                strsql = strsql + "b.cc,b.pcode,b.BDc_ESR_1sthour,b.BDc_ESR_2ndhour,b.BDc_Hb,b.BDc_Trbc,b.BDc_Tplatelets,b.BDc_Twbc,b.BDc_PCV,b.BDC_mcv,b.BDC_mch,b.BDC_mchc,b.BDc_Neutrophild,b.BDc_Lymphocytes,b.BDc_Eosinophils,b.BDc_Monocytes,b.BDc_Basophils,b.BDC_pss,b.bl_imp ";
                //strsql = strsql + "b.BDc_Aec,b.BDc_Tnc,b.BDc_Reticulocyte_Count,b.BDc_Mp_ICT_QBC_Smear,b.BDc_Mf_ICT_QBC_Smear,";
                //strsql = strsql + "b.BDc_Bleeding_Time,b.BDc_Clotting_Time,b.BDc_Sickle_cell,b.BPS_Toxo,b.BPS_Crp,b.BPS_Vdrl,";
                //strsql = strsql + "b.BPS_Rafactor,b.BPS_Aso,b.BS_Australia_Antigen,b.BS_Hepatitis_C_Virus,b.BS_HIV_1,b.BS_HIV_2,";
                //strsql = strsql + "b.BS_Ict_PF_PV,b.Bw_Widaltube,b.Bw_Widalslide,b.Bw_mycodot,b.bw_trop,b.Bm_MontouxTest_injon,b.Bm_MontouxTest_readon,b.Bm_MontouxTest_induration";
                strsql = strsql + " from patient_master a,Blood b where a.pcode='" + cbopcode.SelectedItem + "' and a.pcode=b.pcode";

                da = new SqlDataAdapter(strsql, con);
                ds = new DataSet();
                da.Fill(ds);

                i = 0;
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




                    if (ds.Tables[0].Rows[i][27].ToString() != "")
                    {
                        Gdescpss = "COMMENT ON PERIPHERAL SMEAR :-";
                    }
                    else
                    {
                        Gdescpss = "";
                    }
                    Gresultpss = ds.Tables[0].Rows[i][27].ToString();
                    Gresultbl = "";
                    if (ds.Tables[0].Rows[i][28].ToString() != "")
                    {

                        Gresultbl = ds.Tables[0].Rows[i][28].ToString();
                        // Gresult = Gresult.TrimStart('0').TrimEnd('0', '.');


                    }

                    if (ds.Tables[0].Rows[i][27].ToString() != "")
                    {
                        Ggrp = "";
                        Gdesc = "";
                        Gdesc1 = "";
                        Gresult = "";
                        // Gresult = Gresult.TrimStart('0').TrimEnd('0', '.');
                        Gunit = "";
                        Gnormalrange = "";
                        Gnormalrange1 = "";
                        ADDROW();
                    }





                }
            }
            string GDIMP = "IMPRESSION :";

            {

                Repbloodnew cashbankrep = new Repbloodnew();

                cashbankrep.SetDataSource(dt);
                crv.ReportSource = cashbankrep;
                cashbankrep.SetParameterValue(0, ds2.Tables[0].Rows[0][5].ToString());
                cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows[0][6].ToString());
                cashbankrep.SetParameterValue(2, reportname);
                cashbankrep.SetParameterValue(3, Gdescpss);
                cashbankrep.SetParameterValue(4, Gresultpss);
                cashbankrep.SetParameterValue(5, GDIMP);
                cashbankrep.SetParameterValue(6, Gresultbl);
            }
            crv.Refresh();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboname_SelectedIndexChanged(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("select pcode from patient_master where patient_name='" + cboname.Text + "'", con);
            ds = new DataSet();
            da.Fill(ds);
            cbopcode.Text = ds.Tables[0].Rows[0][0].ToString();
        }
    }
}
