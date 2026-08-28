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
    public partial class Frmrepissue : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        SqlDataReader dr;

        public string adr1 = "";
        public string tel1 = "";
        public Frmrepissue()
        {
            InitializeComponent();
        }

        private void Frmrepissue_Load(object sender, EventArgs e)
        {
            //con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Pathology;Persist Security Info=True;User ID=sa;Password=software;");
            Class1 objclass = new Class1();
            con = new SqlConnection(objclass.arun_con());
            
            con.Open();

            SqlCommand cmd = new SqlCommand("select  Cc,Comp,Address,TELPHONENO,FAXNO,Vatno,cstno,year_start,year_end,Pathologist,Biochemist from company ");
            //cmd = new SqlCommand("select cc,comp,year_start,year_end from setup");
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
               this.txtcompid.Text = dr.GetValue(0).ToString();
                label3.Text = dr.GetValue(1).ToString();
                
                String adr1 = dr.GetValue(2).ToString();
                String tel1 = dr.GetValue(3).ToString();
                //dtfrom.Text = dr.GetValue(7).ToString();
            }
            dr.Close();
            // cbotype.Items.Add("Sale");
            da = new SqlDataAdapter("select distinct blno from mrn_detail where type='Issue' order by blno", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                this.cboissfrom.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                this.cboissto.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            //DateTime dtf, dtt;
            //String dd = dtfrom.Text.Substring(0, 2).ToString();
            //String mmm = this.dtfrom.Text.Substring(3, 2).ToString();
            //String yy = this.dtfrom.Text.Substring(6, 4).ToString();
            //dtf = DateTime.ParseExact(dd + "/" + mmm + "/" + yy, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            //String dd1 = dtto.Text.Substring(0, 2).ToString();
            //String mmm1 = this.dtto.Text.Substring(3, 2).ToString();
            //String yy1 = this.dtto.Text.Substring(6, 4).ToString();
            //dtt = DateTime.ParseExact(dd1 + "/" + mmm1 + "/" + yy1, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);


            //String s1 = ("select cc,type,blno,bldt,acdes,challan_no,challan_dt,gross,discount_rt,discount,vat_rt,vat,tamt from inv where bldt>= '" + Convert.ToDateTime(dtfrom.Text) + "' and bldt<= '" + Convert.ToDateTime(dtto.Text) + "' and cc='" + txtcompid.Text + "' and type='" + cbotype.Text + "' order by cc,type,bldt,blno");
            // String s1 = ("select cc,patient_name,pcode,sex,age,doctor,date_exam,Sp_color, Sp_reaction, Sp_Mucus, SM_rbc_from, SM_rbc_to, SM_puscells_from,SM_puscells_to,SM_macrophase,SM_vegetables,SM_fataglobules,SM_yeast,SM_crystal,SM_bacterialflora,SP_EHistolytica,SP_ecoli,SP_giardia,SP_trichomonas,SH_OvaHW,SH_OvaRW,SH_Others,SC_Occultblood,SC_Reducingsugar from patient_record where patient_name='" + cboname.Text + "' and date_exam= '" + Convert.ToDateTime(dtreport.Text) + "' order by pcode,date_exam");
            String strsql = "";
           
            strsql = "select cc,type,blno,bldt,acdes,child ,item,qty,unit,rate,gross ";


            strsql = strsql + " from mrn_detail where blno>='" + cboissfrom.Text + "'  and (blno)<= '" + cboissto.Text + "'";
            da = new SqlDataAdapter(strsql, con);
            ds = new DataSet();
            da.Fill(ds, "mrn_detail");
            if (ds.Tables[0].Rows.Count != 0)
            {
                
                repissue cashbankrep = new repissue();

                cashbankrep.SetDatabaseLogon("sa", "software", @".\sqlexpress", "pathology2627");
                cashbankrep.SetDataSource(ds);
                crv.ReportSource = cashbankrep;
                cashbankrep.SetParameterValue(0, label3.Text);
                cashbankrep.SetParameterValue(1, adr1);
                cashbankrep.SetParameterValue(2, adr1);

               
              crv.Refresh();
            }
            else
            {
                MessageBox.Show("No Records Found!!!");
            }
        }
    }
}
