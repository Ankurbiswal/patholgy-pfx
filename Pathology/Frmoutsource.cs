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
    public partial class Frmoutsource : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        SqlDataReader dr1;
        DataRow dr;
        DataTable dt;
        DataSet ds1, ds2, ds3, ds4;
        public string Ggrp, Gdesc, Gdesc1, Gresult, Gunit, Gnormalrange, Gnormalrange1;
        public int gcode, gage,gphno,gnr;
        public string gsex, gpatient_name, gdoctor, gmnyr, gscn, gtpt, grrd, grrd3;
        
        public DateTime gdt_report;
        public Frmoutsource()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Frmoutsource_Load(object sender, EventArgs e)
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




            String strsql = "";
            
            if (cboname.Text == "")
            {
                strsql = "select a.pcode,a.patient_name,a.date_exam as Dt_Report,a.scn as telphoneno,a.age,a.sex,";
                strsql = strsql + "b.pcode,b.test,b.method,b.result,b.unit,b.normal_range";
                strsql = strsql + " from patient_master a, outsource b  where   (a.pcode=b.pcode) and a.date_exam>= '" + dtf.ToString("yyyy-MM-dd") + "' and a.date_exam<= '" + dtt.ToString("yyyy-MM-dd") + "' order by a.pcode,a.date_exam";
            }
            else
            {
                strsql = "select a.pcode,a.patient_name,a.date_exam as Dt_Report,a.scn as telphoneno,a.age,a.sex,";
                strsql = strsql + "b.pcode,b.test,b.method,b.result,b.unit,b.normal_range";
                strsql = strsql + " from patient_master a ,outsource b  where  (a.pcode=b.pcode) and a.date_exam>= '" + dtf.ToString("yyyy-MM-dd") + "' and a.date_exam<= '" + dtt.ToString("yyyy-MM-dd") + "' and a.patient_name='" + cboname.Text + "' order by a.date_exam,a.pcode";
            }
            int i = 0;
            da = new SqlDataAdapter(strsql, con);
            ds = new DataSet();
            da.Fill(ds, "outsource");

            dt = new DataTable();
            ds1 = new DataSet();
            dt = ds1.Tables.Add("outsource");
           
           
            dt.Columns.Add("Pcode", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Patient_Name", System.Type.GetType("System.String"));
            dt.Columns.Add("Dt_Report", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("telphoneno", System.Type.GetType("System.String"));
            dt.Columns.Add("Age", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Sex", System.Type.GetType("System.String"));
            dt.Columns.Add("test", System.Type.GetType("System.String"));
            dt.Columns.Add("method", System.Type.GetType("System.String"));
            dt.Columns.Add("Result", System.Type.GetType("System.String"));
            dt.Columns.Add("Unit", System.Type.GetType("System.String"));
            dt.Columns.Add("Normal_Range", System.Type.GetType("System.String"));


            //gcode = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());
            //gpatient_name = ds.Tables[0].Rows[i][1].ToString();
            //gdt_report = Convert.ToDateTime(ds.Tables[0].Rows[i][2].ToString());
            //gphno = ds.Tables[0].Rows[i][3].ToString();
            //gage = Convert.ToInt32(ds.Tables[0].Rows[i][4].ToString());
            //gsex = ds.Tables[0].Rows[i][5].ToString();
           
          
            //gtest = ds.Tables[0].Rows[i][6].ToString();
            //gmethod = ds.Tables[0].Rows[i][7].ToString();
            //gresult = ds.Tables[0].Rows[i][8].ToString();
            //gunit = ds.Tables[0].Rows[i][9].ToString();
            //gnr = ds.Tables[0].Rows[i][10].ToString();
            

            if (ds.Tables[0].Rows.Count != 0)
            {
                //String repdesc = "OutSource Report";
                Repos cashbankrep = new Repos();
                cashbankrep.SetDatabaseLogon("sa", "software", @".\sqlexpress", "pathology2627");
                cashbankrep.SetDataSource(ds);

                cashbankrep.SetParameterValue(0, label4.Text);
               
                cashbankrep.SetParameterValue(1, dtf);
                cashbankrep.SetParameterValue(2, dtt);
               // cashbankrep.SetParameterValue(4, fbs);
               

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

 
        
        }
    }
}
