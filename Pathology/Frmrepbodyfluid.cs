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
    public partial class Frmrepbodyfluid : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds, ds2;
        SqlDataReader dr;
        
        public Frmrepbodyfluid()
        {
            InitializeComponent();
        }

        private void Frmrepbodyfluid_Load(object sender, EventArgs e)
        {
            //con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Pathology;Persist Security Info=True;User ID=sa;Password=software;");
            Class1 objclass = new Class1();
            con = new SqlConnection(objclass.arun_con());
            con.Open();
            cmd = new SqlCommand("select cc,comp,year_start,year_end,regno from setup", con);
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
            da = new SqlDataAdapter("select cc,comp,address,year_start,year_end,pathologist,biochemist from company", con);
            ds2 = new DataSet();
            da.Fill(ds2);

        }

        private void btngo_Click(object sender, EventArgs e)
        {
            //String s1 = ("select cc,type,blno,bldt,acdes,challan_no,challan_dt,gross,discount_rt,discount,vat_rt,vat,tamt from inv where bldt>= '" + Convert.ToDateTime(dtfrom.Text) + "' and bldt<= '" + Convert.ToDateTime(dtto.Text) + "' and cc='" + txtcompid.Text + "' and type='" + cbotype.Text + "' order by cc,type,bldt,blno");
            String s1 = ("select a.cc,a.patient_name,a.pcode,a.sex,a.age,a.doctor,a.date_exam,b.Specimen,b.Qty,b.Appearance,b.Color,b.ClotFormation,b.Sugar,b.Microprotein,b.Neutrophil,b.Lymphocyte,b.Total_cell_count,b.Rbc,b.Malignant_Cell,b.Impression,b.abnormal_cell,a.month_year from patient_master a,Body_fluid_analysis b where a.pcode='" + cbocode.Text + "' and a.pcode=b.pcode order by a.pcode,a.date_exam");
            //strsql = strsql + "FA_Timeofcollection,FA_Timeofexamination,FA_Timeofliquification,FA_Volume,FA_Reaction,FA_Color,FA_Viscocity,FA_MP_Prostaticpearls,FA_MP_Puscells,FA_MP_RBC,";
            //strsql = strsql + "";

            da = new SqlDataAdapter(s1, con);
            ds = new DataSet();
            da.Fill(ds, "Body_fluid_analysis");
            if (ds.Tables[0].Rows.Count != 0)
            {
                //cashbankrep = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                //cashbankrep.Load("/Hope_account/Hope_account/repcash_Bank.rpt");

                //CrystalReport1 cashbankrep = new Repstool();
               // Repbodyfluid cashbankrep = new Repbodyfluid();
                Repbodyfluid_ds cashbankrep = new Repbodyfluid_ds();
                //cashbankrep.SetDatabaseLogon("sa", "software", @".\SQLEXPRESS", "pathology2627");
                cashbankrep.SetDataSource(ds);
                crv.ReportSource = cashbankrep;
                cashbankrep.SetParameterValue(0, ds2.Tables[0].Rows[0][5].ToString());
                cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows[0][6].ToString());
                ////cashbankrep.SetParameterValue(2, clbal);
                //cashbankrep.SetParameterValue(2, cbotype.Text);
                //cashbankrep.SetParameterValue(3, label4.Text);
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
    }
}