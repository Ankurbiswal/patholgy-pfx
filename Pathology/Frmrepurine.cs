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
    public partial class Frmrepurine : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds,ds2;
        SqlDataReader dr;
        public int i;
        public Frmrepurine()
        {
            InitializeComponent();
        }

        private void btngo_Click(object sender, EventArgs e)
        {
            //String s1 = ("select cc,type,blno,bldt,acdes,challan_no,challan_dt,gross,discount_rt,discount,vat_rt,vat,tamt from inv where bldt>= '" + Convert.ToDateTime(dtfrom.Text) + "' and bldt<= '" + Convert.ToDateTime(dtto.Text) + "' and cc='" + txtcompid.Text + "' and type='" + cbotype.Text + "' order by cc,type,bldt,blno");
            String s1 = ("select b.UP_color,b.UP_reaction,b.UP_specificgravity,b.UC_sugar,b.UC_albumin,b.UC_phosphate,b.UC_chyle,b.UC_ketonebodies,b.UC_bilesalts,b.UC_bilepigment,b.UM_puscells,b.UM_epithcells,b.UM_rbc,b.UM_casts,b.UM_crystals,b.UM_bacterial,b.UM_spermatozoa,b.UM_mf_tv,b.UM_others,b.UU_urine_b_hcg,b.UA_urine_albumin,b.UN_nasalsmear,a.pcode,a.age,a.sex,a.patient_name,a.date_exam,a.doctor,a.month_year,a.scn,a.tpt from patient_master a,urine b where a.pcode='" + cbocode.Text + "' and a.pcode=b.pcode  order by b.pcode,a.date_exam");
            da = new SqlDataAdapter(s1, con);
            ds = new DataSet();
            da.Fill(ds,"urine");


            DataTable dtv = new DataTable();
            dtv = ds.Tables[0];

            Pathology_Ds dsh = new Pathology_Ds();
            DataTable dt = new DataTable();
            dt = dsh.Tables.Add("Pathology_Urine");

            dt.Columns.Add("UP_color", System.Type.GetType("System.String"));
            dt.Columns.Add("UP_reaction", System.Type.GetType("System.String"));
            dt.Columns.Add("UP_specificgravity", System.Type.GetType("System.String"));
            dt.Columns.Add("UC_sugar", System.Type.GetType("System.String"));
            dt.Columns.Add("UC_albumin", System.Type.GetType("System.String"));
            dt.Columns.Add("UC_phosphate", System.Type.GetType("System.String"));
            dt.Columns.Add("UC_chyle", System.Type.GetType("System.String"));
            dt.Columns.Add("UC_ketonebodies", System.Type.GetType("System.String"));
            dt.Columns.Add("UC_bilesalts", System.Type.GetType("System.String"));
            dt.Columns.Add("UC_bilepigment", System.Type.GetType("System.String"));
            dt.Columns.Add("UM_puscells", System.Type.GetType("System.String"));
            dt.Columns.Add("UM_epithcells", System.Type.GetType("System.String"));
            dt.Columns.Add("UM_rbc", System.Type.GetType("System.String"));
            dt.Columns.Add("UM_casts", System.Type.GetType("System.String"));

            dt.Columns.Add("UM_crystals", System.Type.GetType("System.String"));
            dt.Columns.Add("UM_bacterial", System.Type.GetType("System.String"));
            dt.Columns.Add("UM_spermatozoa", System.Type.GetType("System.String"));
            dt.Columns.Add("UM_mf_tv", System.Type.GetType("System.String"));
            dt.Columns.Add("UM_others", System.Type.GetType("System.String"));
            dt.Columns.Add("UU_urine_b_hcg", System.Type.GetType("System.String"));
            dt.Columns.Add("UA_urine_albumin", System.Type.GetType("System.String"));
            dt.Columns.Add("UN_nasalsmear", System.Type.GetType("System.String"));



            dt.Columns.Add("Pcode", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Age", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Sex", System.Type.GetType("System.String"));
            dt.Columns.Add("Patient_Name", System.Type.GetType("System.String"));
            dt.Columns.Add("Dt_Report", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("Doctor", System.Type.GetType("System.String"));
            dt.Columns.Add("month_year", System.Type.GetType("System.String"));
            dt.Columns.Add("scn", System.Type.GetType("System.String"));
            dt.Columns.Add("tpt", System.Type.GetType("System.String"));

            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
            {
                dt.Rows.Add(dtv.Rows[k][0], dtv.Rows[k][1], dtv.Rows[k][2], dtv.Rows[k][3], dtv.Rows[k][4], dtv.Rows[k][5], dtv.Rows[k][6], dtv.Rows[k][7], dtv.Rows[k][8], dtv.Rows[k][9], dtv.Rows[k][10], dtv.Rows[k][11], dtv.Rows[k][12], dtv.Rows[k][13], dtv.Rows[k][14], dtv.Rows[k][15], dtv.Rows[k][16], dtv.Rows[k][17], dtv.Rows[k][18], dtv.Rows[k][19], dtv.Rows[k][20], dtv.Rows[k][21], Convert.ToInt32 (dtv.Rows[k][22]),Convert.ToInt32 ( dtv.Rows[k][23]), dtv.Rows[k][24], dtv.Rows[k][25], Convert.ToDateTime (dtv.Rows[k][26]), dtv.Rows[k][27], dtv.Rows[k][28], dtv.Rows[k][29], dtv.Rows[k][30]);
                
            }
          
            if (ds.Tables[0].Rows.Count != 0)
            {
                if (checkBox1.Checked == true)
                {
                    Reppregnancy cashbankrep = new Reppregnancy();
                    cashbankrep.SetDataSource(dt);
                    crv.ReportSource = cashbankrep;
                    cashbankrep.SetParameterValue(0, ds2.Tables[0].Rows[0][5].ToString());
                    cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows[0][6].ToString());
                    crv.Refresh();

                }
                else
                {
                    Repurine cashbankrep = new Repurine();
                    cashbankrep.SetDataSource(dt);
                    crv.ReportSource = cashbankrep;
                    cashbankrep.SetParameterValue(0, ds2.Tables[0].Rows[0][5].ToString());
                    cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows[0][6].ToString());
                    ////cashbankrep.SetParameterValue(2, clbal);
                    //cashbankrep.SetParameterValue(2, cbotype.Text);
                    //cashbankrep.SetParameterValue(3, label4.Text);
                    crv.Refresh();

                }
            
            
            }
            else
            {
                MessageBox.Show("No Records Found!!!");
            }
 
        }

        private void Frmrepurine_Load(object sender, EventArgs e)
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
                cbocode.Text = dr.GetValue(4).ToString();
                //label4.Text = dr.GetValue(1).ToString();
                //dtfrom.Text = dr.GetValue(2).ToString();
            }
            dr.Close();
           
            da = new SqlDataAdapter("select distinct patient_name,pcode from patient_master order by pcode", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                this.cbocode.Items.Add(ds.Tables[0].Rows[i][1].ToString());
                this.cboname.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            da.Dispose();
            da = new SqlDataAdapter("select cc,comp,address,year_start,year_end,pathologist,biochemist from company", con);
            ds2 = new DataSet();
            da.Fill(ds2);
            da.Dispose();
        
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
            da = new SqlDataAdapter("select pcode from patient_master where patient_name='" + cboname.Text + "'", con);
            ds = new DataSet();
            da.Fill(ds);
            cbocode.Text = ds.Tables[0].Rows[0][0].ToString();
        }

        private void btnurineback_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}