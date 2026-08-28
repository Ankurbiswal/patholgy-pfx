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
    public partial class Frmrepcytology : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds, ds2,ds1;
        SqlDataReader dr;
        DataTable dt;
        public Frmrepcytology()
        {
            InitializeComponent();
        }

        private void Frmrepcytology_Load(object sender, EventArgs e)
        {
           // con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Pathology;Persist Security Info=True;User ID=sa;Password=software;");
            Class1 objclass = new Class1();
            con = new SqlConnection(objclass.arun_con());
            
            con.Open();
            cmd = new SqlCommand("select cc,comp,year_start,year_end,regno from setup",con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbocode.Text = dr.GetValue(4).ToString();
                //label4.Text = dr.GetValue(1).ToString();
                //dtfrom.Text = dr.GetValue(2).ToString();
            }
            dr.Close();
            // cbotype.Items.Add("Sale");
            da = new SqlDataAdapter("select distinct patient_name,pcode from patient_master order by pcode", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                this.cboname.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                this.cbocode.Items.Add(ds.Tables[0].Rows[i][1].ToString());
            }
            da = new SqlDataAdapter("select cc,comp,address,year_start,year_end,pathologist,biochemist,telphoneno,email,cstno,address1,faxno from company", con);
            //da = new SqlDataAdapter("select cc,comp,address,year_start,year_end,pathologist,biochemist from company", con);
            ds2 = new DataSet();
            da.Fill(ds2);
            da.Dispose();
        }

        private void btngo_Click(object sender, EventArgs e)
        {
            //String s1 = ("select cc,type,blno,bldt,acdes,challan_no,challan_dt,gross,discount_rt,discount,vat_rt,vat,tamt from inv where bldt>= '" + Convert.ToDateTime(dtfrom.Text) + "' and bldt<= '" + Convert.ToDateTime(dtto.Text) + "' and cc='" + txtcompid.Text + "' and type='" + cbotype.Text + "' order by cc,type,bldt,blno");
            String s1 = ("select a.cc,a.pcode,a.patient_name,a.date_exam,a.age,a.sex,a.month_year,a.doctor,a.scn,a.tpt,b.Specimen,b.Benign_Cell,b.Endocervical_Cell,b.Impression from patient_master a,cytology b where a.pcode='" + cbocode.Text + "' and a.pcode=b.pcode order by a.pcode,a.date_exam");
            //String s1 = ("select a.cc,a.pcode,a.patient_name,a.date_exam,a.age,a.sex,a.month_year,a.doctor,a.scn,a.tpt,b.Specimen,b.Benign_Cell,b.Endocervical_Cell,b.Inflammatory_Cell,b.Trichomonas,b.Monilia,b.Endometrial_Cell,b.Spermatozoa,b.Rbc,b.Dysplastic_Cell,b.Malignant_Cell,b.Others,b.Impression from patient_master a,cytology b where a.pcode='" + cbocode.Text + "' and a.pcode=b.pcode order by a.pcode,a.date_exam");
            
            //strsql = strsql + "FA_Timeofcollection,FA_Timeofexamination,FA_Timeofliquification,FA_Volume,FA_Reaction,FA_Color,FA_Viscocity,FA_MP_Prostaticpearls,FA_MP_Puscells,FA_MP_RBC,";
            //strsql = strsql + "";

            da = new SqlDataAdapter(s1, con);
            ds = new DataSet();
            da.Fill(ds, "cytology");
            
            
            
            
            
            if (ds.Tables[0].Rows.Count != 0)
            {
                DataTable dtv = new DataTable();
                dtv = ds.Tables[0];

                Pathology_Ds dsh = new Pathology_Ds();
                 dt = new DataTable();
                
                //dt = dsh.Tables.Add("cytology");
                
             ds1 = new DataSet();
            dt = ds1.Tables.Add("cytology");
            dt.Columns.Add("cc", System.Type.GetType("System.Int32"));
            dt.Columns.Add("pcode", System.Type.GetType("System.Int32"));
            dt.Columns.Add("patient_Name", System.Type.GetType("System.String"));
            dt.Columns.Add("date_exam", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("age", System.Type.GetType("System.Int32"));
            dt.Columns.Add("sex", System.Type.GetType("System.String"));
            dt.Columns.Add("month_year", System.Type.GetType("System.String"));
           
            dt.Columns.Add("Doctor", System.Type.GetType("System.String"));
           
            dt.Columns.Add("scn", System.Type.GetType("System.String"));
            dt.Columns.Add("tpt", System.Type.GetType("System.String"));

            dt.Columns.Add("Specimen", System.Type.GetType("System.String"));

            dt.Columns.Add("Benign_Cell", System.Type.GetType("System.String"));
            dt.Columns.Add("Endocervical_Cell", System.Type.GetType("System.String"));
            dt.Columns.Add("Impression", System.Type.GetType("System.String"));

            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
            {
                //if (dtv.Rows[k][9].ToString() == "")
                //{
                //    dtv.Rows[k][9] = "0.00";
                //}
                //  dt.Rows.Add(Convert.ToDouble(dtv.Rows[k][0]), dtv.Rows[k][1], dtv.Rows[k][2], Convert.ToDateTime(dtv.Rows[k][3]), dtv.Rows[k][4], dtv.Rows[k][5], dtv.Rows[k][6], dtv.Rows[k][7], dtv.Rows[k][8], Convert.ToDouble(dtv.Rows[k][9]), Convert.ToDouble(dtv.Rows[k][10]), Convert.ToDouble(dtv.Rows[k][11]), Convert.ToDouble(dtv.Rows[k][12]), Convert.ToDouble(dtv.Rows[k][13]), Convert.ToDouble(dtv.Rows[k][14]), Convert.ToDouble(dtv.Rows[k][15]), Convert.ToDouble(dtv.Rows[k][16]), Convert.ToDouble(dtv.Rows[k][17]), Convert.ToDouble(dtv.Rows[k][18]), dtv.Rows[k][19], dtv.Rows[k][20], dtv.Rows[k][21], dtv.Rows[k][22], dtv.Rows[k][23]);
                dt.Rows.Add(Convert.ToInt32(dtv.Rows[k][0]), Convert.ToInt32(dtv.Rows[k][1]), dtv.Rows[k][2], Convert.ToDateTime(dtv.Rows[k][3]), Convert.ToInt32(dtv.Rows[k][4]), dtv.Rows[k][5], dtv.Rows[k][6], dtv.Rows[k][7], dtv.Rows[k][8], dtv.Rows[k][9], dtv.Rows[k][10], dtv.Rows[k][11], dtv.Rows[k][12], dtv.Rows[k][13]);

            }

  
                
                
                
                
                
                
                //cashbankrep = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                //cashbankrep.Load("/Hope_account/Hope_account/repcash_Bank.rpt");

                //CrystalReport1 cashbankrep = new Repstool();
                Repcytology11 cashbankrep = new Repcytology11();
                //cashbankrep.SetDatabaseLogon("sa", "software", @".\SQLEXPRESS", "Pathology1819");
                cashbankrep.SetDataSource(dt);
                crv.ReportSource = cashbankrep;
                cashbankrep.SetParameterValue(0, ds2.Tables[0].Rows[0][5].ToString());
                cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows[0][6].ToString());
                cashbankrep.SetParameterValue(2, ds2.Tables[0].Rows[0][1].ToString());
                cashbankrep.SetParameterValue(3, ds2.Tables[0].Rows[0][2].ToString());
                cashbankrep.SetParameterValue(4, ds2.Tables[0].Rows[0][7].ToString());
                cashbankrep.SetParameterValue(5, ds2.Tables[0].Rows[0][8].ToString());
                cashbankrep.SetParameterValue(6, ds2.Tables[0].Rows[0][9].ToString());
                cashbankrep.SetParameterValue(7, ds2.Tables[0].Rows[0][10].ToString());
                cashbankrep.SetParameterValue(8, ds2.Tables[0].Rows[0][11].ToString());

                crv.Refresh();
            }
            else
            {
                MessageBox.Show("No Records Found!!!");
            }
        }

        private void btncytoback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbocode_SelectedIndexChanged(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("select patient_name from patient_master where pcode='" + cbocode.Text + "'", con);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
                cboname.Text = ds.Tables[0].Rows[0][0].ToString();
        }

        private void cboname_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}