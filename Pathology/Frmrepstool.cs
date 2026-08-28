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
    public partial class Frmrepstool : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds,ds2;
        SqlDataReader dr;
        
        public Frmrepstool()
        {
            InitializeComponent();
        }

        private void Frmrepstool_Load(object sender, EventArgs e)
        {
            //con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Pathology;Persist Security Info=True;User ID=sa;Password=software;");
            Class1 objclass = new Class1();
            con = new SqlConnection(objclass.arun_con());
            con.Open();
            cmd = new SqlCommand("select cc,comp,year_start,year_end,regno from setup");
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
               cbocode .Text  = dr.GetValue(4).ToString();
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
            da.Dispose();
        
        }

        private void btngo_Click(object sender, EventArgs e)
        {
            //String s1 = ("select cc,type,blno,bldt,acdes,challan_no,challan_dt,gross,discount_rt,discount,vat_rt,vat,tamt from inv where bldt>= '" + Convert.ToDateTime(dtfrom.Text) + "' and bldt<= '" + Convert.ToDateTime(dtto.Text) + "' and cc='" + txtcompid.Text + "' and type='" + cbotype.Text + "' order by cc,type,bldt,blno");
            String s1 = ("select b.Sp_color, b.Sp_reaction,b.Sp_Mucus,b.SH_OvaHW,b.SH_larva,b.SH_OvaRW,b.SP_EHistolytica,b.SP_ecoli,b.SP_giardia,b.SP_trichomonas, b.SM_rbc_from,  b.SM_puscells_from,b.SM_macrophase,b.SM_vegetables,b.SM_yeast,b.SM_crystal,b.SM_fataglobules,b.SM_bacterialflora,b.SH_Others,b.SC_Occultblood,b.SC_Reducingsugar,a.pcode,a.age,a.sex,a.patient_name,a.date_exam,a.doctor,a.month_year,a.scn,a.tpt,b.st_imp from patient_master a,stool b where a.pcode='" + cbocode.Text + "' and a.pcode=b.pcode order by a.pcode,a.date_exam");
                       
            da = new SqlDataAdapter(s1, con);
            ds = new DataSet();
            da.Fill(ds, "stool");


            DataTable dtv = new DataTable();
            dtv = ds.Tables[0];

            Pathology_Ds dsh = new Pathology_Ds();
            DataTable dt = new DataTable();
            dt = dsh.Tables.Add("Pathology_Stool");

            dt.Columns.Add("Sp_color", System.Type.GetType("System.String"));
            dt.Columns.Add("SP_reaction", System.Type.GetType("System.String"));
            dt.Columns.Add("SP_Mucus", System.Type.GetType("System.String"));
            dt.Columns.Add("SH_OvaHW", System.Type.GetType("System.String"));
            dt.Columns.Add("SH_Larva", System.Type.GetType("System.String"));
            dt.Columns.Add("SH_OvaRW", System.Type.GetType("System.String"));
            dt.Columns.Add("SP_EHistolytica", System.Type.GetType("System.String"));
            dt.Columns.Add("SP_ecoli", System.Type.GetType("System.String"));
            dt.Columns.Add("SP_giardia", System.Type.GetType("System.String"));
            dt.Columns.Add("SP_trichomonas", System.Type.GetType("System.String"));
            dt.Columns.Add("SM_rbc_from", System.Type.GetType("System.String"));
            dt.Columns.Add("SM_puscells_from", System.Type.GetType("System.String"));
            dt.Columns.Add("SM_macrophase", System.Type.GetType("System.String"));
            dt.Columns.Add("SM_vegetables", System.Type.GetType("System.String"));

            dt.Columns.Add("SM_yeast", System.Type.GetType("System.String"));
            dt.Columns.Add("SM_crystal", System.Type.GetType("System.String"));
            dt.Columns.Add("SM_fataglobules", System.Type.GetType("System.String"));
            dt.Columns.Add("SM_bacterialflora", System.Type.GetType("System.String"));
            dt.Columns.Add("SH_Others", System.Type.GetType("System.String"));
            dt.Columns.Add("SC_Occultblood", System.Type.GetType("System.String"));
            dt.Columns.Add("SC_Reducingsugar", System.Type.GetType("System.String"));
           // dt.Columns.Add("UN_nasalsmear", System.Type.GetType("System.String"));
            dt.Columns.Add("Pcode", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Age", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Sex", System.Type.GetType("System.String"));
            dt.Columns.Add("Patient_Name", System.Type.GetType("System.String"));
            dt.Columns.Add("Dt_Report", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("Doctor", System.Type.GetType("System.String"));
            dt.Columns.Add("month_year", System.Type.GetType("System.String"));
            dt.Columns.Add("scn", System.Type.GetType("System.String"));
            dt.Columns.Add("tpt", System.Type.GetType("System.String"));
            dt.Columns.Add("st_imp", System.Type.GetType("System.String"));
            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
            {
                dt.Rows.Add(dtv.Rows[k][0], dtv.Rows[k][1], dtv.Rows[k][2], dtv.Rows[k][3], dtv.Rows[k][4], dtv.Rows[k][5], dtv.Rows[k][6], dtv.Rows[k][7], dtv.Rows[k][8], dtv.Rows[k][9], dtv.Rows[k][10], dtv.Rows[k][11], dtv.Rows[k][12], dtv.Rows[k][13], dtv.Rows[k][14], dtv.Rows[k][15], dtv.Rows[k][16], dtv.Rows[k][17], dtv.Rows[k][18], dtv.Rows[k][19], dtv.Rows[k][20], Convert.ToInt32(dtv.Rows[k][21]), Convert.ToInt32(dtv.Rows[k][22]), dtv.Rows[k][23], dtv.Rows[k][24], Convert.ToDateTime(dtv.Rows[k][25]), dtv.Rows[k][26], dtv.Rows[k][27], dtv.Rows[k][28], dtv.Rows[k][29], dtv.Rows[k][30]);

            }


            
            if (ds.Tables[0].Rows.Count != 0)
            {
              
                Repstooln cashbankrep = new Repstooln();
               // cashbankrep.SetDatabaseLogon("sa", "software", @".\SQLEXPRESS", "pathology2627");
                cashbankrep.SetDataSource(dt);
                crv.ReportSource = cashbankrep;
               cashbankrep.SetParameterValue(0,ds2.Tables[0].Rows[0][5].ToString() );
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

        private void cboname_SelectedIndexChanged(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("select pcode from patient_master where patient_name='" + cboname.Text + "'", con);
            ds = new DataSet();
            da.Fill(ds);
            cbocode.Text = ds.Tables[0].Rows[0][0].ToString();
        }

        private void cbocode_SelectedIndexChanged(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("select patient_name from patient_master where pcode='" + cbocode.Text + "'", con);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
                cboname.Text = ds.Tables[0].Rows[0][0].ToString();
        }

        private void btnstoolback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}