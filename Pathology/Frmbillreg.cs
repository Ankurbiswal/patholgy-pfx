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
    public partial class Frmbillreg : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        SqlDataReader dr;
        public Frmbillreg()
        {
            InitializeComponent();
        }

        private void Frmbillreg_Load(object sender, EventArgs e)
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
                //label4.Text = dr.GetValue(1).ToString();
                dtf.Text = dr.GetValue(2).ToString();
            }
            dr.Close();
            // cbotype.Items.Add("Sale");
            da = new SqlDataAdapter("select distinct referal from patient_master order by referal", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                this.cboreferal.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                
            }
            da.Dispose();
            da = new SqlDataAdapter("select distinct doctor from patient_master order by doctor", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                this.cbodoctor.Items.Add(ds.Tables[0].Rows[i][0].ToString());

            }
            
            
            
            
            //cboissfrom.Text = Frmresultentry.gcode.ToString();
            //cboissto.Text = Frmresultentry.gcode.ToString();

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
                strsql = "select a.pcode, a.patient_name, a.date_exam, CAST(COUNT(d.test) as varchar)+' Tests' as test, SUM(d.price) as price, c.comp, c.address, c.telphoneno, a.age, a.sex, a.doctor, a.Month_Year, a.tpt, a.referal from patient_master a inner join billl d on (a.pcode=d.pcode) inner join company c on (a.cc=c.cc) where a.cc=1 and a.date_exam>='" + dtf1.ToString("yyyy-MM-dd") + "' and a.date_exam<='" + dtt1.ToString("yyyy-MM-dd") + "' and a.referal='" + cboreferal.Text + "' group by a.pcode,a.patient_name,a.date_exam,c.comp,c.address,c.telphoneno,a.age,a.sex,a.doctor,a.Month_Year,a.tpt,a.referal";
            }
            else if (cbodoctor.Text != "")
            {
                strsql = "select a.pcode, a.patient_name, a.date_exam, CAST(COUNT(d.test) as varchar)+' Tests' as test, SUM(d.price) as price, c.comp, c.address, c.telphoneno, a.age, a.sex, a.doctor, a.Month_Year, a.tpt, a.referal from patient_master a inner join billl d on (a.pcode=d.pcode) inner join company c on (a.cc=c.cc) where a.cc=1 and a.date_exam>='" + dtf1.ToString("yyyy-MM-dd") + "' and a.date_exam<='" + dtt1.ToString("yyyy-MM-dd") + "' and a.doctor='" + cbodoctor.Text + "' group by a.pcode,a.patient_name,a.date_exam,c.comp,c.address,c.telphoneno,a.age,a.sex,a.doctor,a.Month_Year,a.tpt,a.referal";
            }
            else
            {
                strsql = "select a.pcode, a.patient_name, a.date_exam, CAST(COUNT(d.test) as varchar)+' Tests' as test, SUM(d.price) as price, c.comp, c.address, c.telphoneno, a.age, a.sex, a.doctor, a.Month_Year, a.tpt, a.referal from patient_master a inner join billl d on (a.pcode=d.pcode) inner join company c on (a.cc=c.cc) where a.cc=1 and a.date_exam>='" + dtf1.ToString("yyyy-MM-dd") + "' and a.date_exam<='" + dtt1.ToString("yyyy-MM-dd") + "' group by a.pcode,a.patient_name,a.date_exam,c.comp,c.address,c.telphoneno,a.age,a.sex,a.doctor,a.Month_Year,a.tpt,a.referal";
            }

            da = new SqlDataAdapter(strsql, con);
            ds = new DataSet();
            da.Fill(ds, "path_bill");
            if (ds.Tables[0].Rows.Count != 0)
            {
                Repbillreg cashbankrep = new Repbillreg();
                cashbankrep.SetDatabaseLogon("sa", "software", @".\sqlexpress", "pathology2627");
                cashbankrep.SetDataSource(ds);
                crv.ReportSource = cashbankrep;
                crv.Refresh();
            }
            else
            {
                MessageBox.Show("No Records Found!!!");
            }
        }

        private void cboissto_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cboissfrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cboissto.Text = cboissfrom.Text;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btndetail_Click(object sender, EventArgs e)
        {
            DateTime dtf1, dtt1;
            String dd = dtf.Text.Substring(0, 2).ToString();
            String mm = this.dtf.Text.Substring(3, 2).ToString();
            String yy = this.dtf.Text.Substring(6, 4).ToString();
            dtf1 = DateTime.ParseExact(dd + "/" + mm + "/" + yy, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            String dd1 = dtt.Text.Substring(0, 2).ToString();
            String mm1 = this.dtt.Text.Substring(3, 2).ToString();
            String yy1 = this.dtt.Text.Substring(6, 4).ToString();
            dtt1 = DateTime.ParseExact(dd1 + "/" + mm1 + "/" + yy1, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            String strsql = "";
            String whereClause = " where a.cc=1 and a.date_exam>='" + dtf1.ToString("yyyy-MM-dd") + "' and a.date_exam<='" + dtt1.ToString("yyyy-MM-dd") + "'";

            if (cboreferal.Text != "")
                whereClause += " and a.referal='" + cboreferal.Text + "'";
            else if (cbodoctor.Text != "")
                whereClause += " and a.doctor='" + cbodoctor.Text + "'";

            strsql = "select a.pcode, a.patient_name, a.date_exam, d.test as test, d.price as price, " +
                     "c.comp, c.address, c.telphoneno, a.age, a.sex, a.doctor, a.Month_Year, a.tpt, a.referal, " +
                     "d.test as test_name, d.price as test_rate " +
                     "from patient_master a " +
                     "inner join billl d on (a.pcode = d.pcode) " +
                     "inner join company c on (a.cc = c.cc)" + whereClause;

            da = new SqlDataAdapter(strsql, con);
            ds = new DataSet();
            da.Fill(ds, "path_bill");
            if (ds.Tables[0].Rows.Count != 0)
            {
                Repbillreg_detail cashbankrep = new Repbillreg_detail();
                cashbankrep.SetDatabaseLogon("sa", "software", @".\sqlexpress", "pathology2627");
                cashbankrep.SetDataSource(ds);
                crv.ReportSource = cashbankrep;
                crv.Refresh();
            }
            else
            {
                MessageBox.Show("No Records Found!!!");
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
