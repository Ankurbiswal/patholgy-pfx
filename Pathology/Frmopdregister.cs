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
    public partial class Frmopdregister : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        SqlDataReader dr;
        public static string cnm = "";
        public Frmopdregister()
        {
            InitializeComponent();
        }

        private void Frmopdregister_Load(object sender, EventArgs e)
        {
            Class1 objclass = new Class1();
            con = new SqlConnection(objclass.arun_con());

            con.Open();
            cmd = new SqlCommand("select cc,comp,year_start,year_end from setup");
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //this.txtcompid.Text = dr.GetValue(0).ToString();
                String cnm = dr.GetValue(1).ToString();
                //dtfrom.Text = dr.GetValue(2).ToString();
            }
            dr.Close();
            // cbotype.Items.Add("Sale");
            da = new SqlDataAdapter("select distinct acdes from opd_master order by acdes", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                this.cboreferal.Items.Add(ds.Tables[0].Rows[i][0].ToString());

            }
            da.Dispose();
            da = new SqlDataAdapter("select distinct doctor from opd_master order by doctor", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                this.cbodoctor.Items.Add(ds.Tables[0].Rows[i][0].ToString());

            }
            
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            DateTime dtf1, dtt1;
            String dd = dtf.Text.Substring(0, 2).ToString();
            String mm = this.dtf.Text.Substring(3, 2).ToString();
            String yy = this.dtf.Text.Substring(6, 4).ToString();
            //String tt = this.dtf.Text.Substring(11, 8).ToString();
            dtf1 = DateTime.ParseExact(dd + "/" + mm + "/" + yy, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            String dd1 = dtt.Text.Substring(0, 2).ToString();
            String mm1 = this.dtt.Text.Substring(3, 2).ToString();
            String yy1 = this.dtt.Text.Substring(6, 4).ToString();
            //String tt1 = this.dtreport.Text.Substring(11, 8).ToString();
            dtt1 = DateTime.ParseExact(dd1 + "/" + mm1 + "/" + yy1, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            String strsql = "";

            if (cboreferal.Text != "")
            {
                //strsql = "select a.pcode,a.patient_name,a.date_exam,b.dcin as test,b.amt as price,c.comp,c.address,c.telphoneno,a.age,a.sex,a.doctor,a.Month_Year,a.tpt from patient_master a,cbj b,company c where a.pcode=b.pcode and a.cc=c.cc and b.dcin='D' and a.date_exam>='" + dtf1.ToString("yyyy-MM-dd") + "' and a.date_exam<='" + dtt1.ToString("yyyy-MM-dd") + "'  and a.tpt='" + cboreferal.Text + "'";
                String strsql1 = "select pcode,patient_name,date_exam,scn,tpt,acdes,doctor,due_amount,paid_amount,expenditure,referal,balance,cfees";
            strsql1 = strsql1 + " from opd_master where date_exam>='" + dtf1.ToString("yyyy-MM-dd") + "' and date_exam<='" + dtt1.ToString("yyyy-MM-dd") + "'  and acdes='" + cboreferal.Text + "' order by pcode";
            da = new SqlDataAdapter(strsql1, con);
            DataSet ds1 = new DataSet();
            da.Fill(ds1,"opddata");
            if (ds1.Tables[0].Rows.Count != 0)
            {
                Repopdregistern cashbankrep = new Repopdregistern();
                cashbankrep.SetDatabaseLogon("sa", "software", @".\sqlexpress", "pathology2627");
                cashbankrep.SetDataSource(ds1);
                crv.ReportSource = cashbankrep;
                cashbankrep.SetParameterValue(0, dtf1);
                cashbankrep.SetParameterValue(1, dtt1);
                cashbankrep.SetParameterValue(2, cnm);
                crv.Refresh();

            
            
            }
            
            
            }
            else if (cbodoctor.Text != "")
            {
                //strsql = "select a.pcode,a.patient_name,a.date_exam,b.dcin as test,b.amt as price,c.comp,c.address,c.telphoneno,a.age,a.sex,a.doctor,a.Month_Year,a.tpt from patient_master a,cbj b,company c where a.pcode=b.pcode and a.cc=c.cc and b.dcin='D' and a.date_exam>='" + dtf1.ToString("yyyy-MM-dd") + "' and a.date_exam<='" + dtt1.ToString("yyyy-MM-dd") + "'  and a.doctor='" + cbodoctor.Text + "'";
                String strsql1 = "select pcode,patient_name,date_exam,scn,tpt,acdes,doctor,due_amount,paid_amount,expenditure,referal,balance,cfees";
                strsql1 = strsql1 + " from opd_master where date_exam>='" + dtf1.ToString("yyyy-MM-dd") + "' and date_exam<='" + dtt1.ToString("yyyy-MM-dd") + "'  and doctor='" + cbodoctor.Text + "' order by pcode";
                da = new SqlDataAdapter(strsql1, con);
               
                DataSet ds1 = new DataSet();
                da.Fill(ds1, "opddata");
                if (ds1.Tables[0].Rows.Count != 0)
                {
                    Repopdregistern cashbankrep = new Repopdregistern();
                    cashbankrep.SetDatabaseLogon("sa", "software", @".\sqlexpress", "pathology2627");
                    cashbankrep.SetDataSource(ds1);
                    crv.ReportSource = cashbankrep;
                    cashbankrep.SetParameterValue(0, dtf1);
                    cashbankrep.SetParameterValue(1, dtt1);
                    cashbankrep.SetParameterValue(2, cnm);
                    crv.Refresh();
                }
            
            
            
            
            }
            else
            {
                //strsql = "select a.pcode,a.patient_name,a.date_exam,b.dcin as test,b.amt as price,c.comp,c.address,c.telphoneno,a.age,a.sex,a.doctor,a.Month_Year,a.tpt from patient_master a,cbj b,company c where a.pcode=b.pcode and a.cc=c.cc and b.dcin='D' and a.date_exam>='" + dtf1.ToString("yyyy-MM-dd") + "' and a.date_exam<='" + dtt1.ToString("yyyy-MM-dd") + "' ";
                String strsql1 = "select pcode,patient_name,date_exam,scn,tpt,acdes,doctor,due_amount,paid_amount,expenditure,referal,balance,cfees";
                strsql1 = strsql1 + " from opd_master where date_exam>='" + dtf1.ToString("yyyy-MM-dd") + "' and date_exam<='" + dtt1.ToString("yyyy-MM-dd") + "' order by pcode ";
                da = new SqlDataAdapter(strsql1, con);
                DataSet ds1 = new DataSet();
                da.Fill(ds1, "opddata");
                if (ds1.Tables[0].Rows.Count != 0)
                {
                    Repopdregistern cashbankrep = new Repopdregistern();
                    cashbankrep.SetDatabaseLogon("sa", "software", @".\sqlexpress", "pathology2627");
                    cashbankrep.SetDataSource(ds1);
                    crv.ReportSource = cashbankrep;
                    cashbankrep.SetParameterValue(0, dtf1);
                    cashbankrep.SetParameterValue(1, dtt1);
                    cashbankrep.SetParameterValue(2, cnm);
                    crv.Refresh();
                }
            
            
            }
           
        }
    }
}
