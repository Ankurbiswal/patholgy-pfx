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
    public partial class Frmreppathbill : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds,ds2;
        SqlDataReader dr;
        public Frmreppathbill()
        {
            InitializeComponent();
        }

        private void Frmreppathbill_Load(object sender, EventArgs e)
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
                //dtfrom.Text = dr.GetValue(2).ToString();
            }
            dr.Close();
            // cbotype.Items.Add("Sale");
            da = new SqlDataAdapter("select distinct pcode from billl order by pcode", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                this.cboissfrom.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                this.cboissto.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            cboissfrom.Text = Frmresultentry.pidr.ToString();
            cboissto.Text = Frmresultentry.pidr.ToString();
            da.Dispose();
            da = new SqlDataAdapter("select cc,comp,address,year_start,year_end,pathologist,biochemist,telphoneno,email,cstno,address1,faxno from company", con);
            ds2 = new DataSet();
            da.Fill(ds2);
            da.Dispose();
        
        }

        private void btnview_Click(object sender, EventArgs e)
        {

            String strsql = "";

            strsql = "select a.pcode,a.patient_name,a.date_exam,b.test,b.price,c.comp,c.address,c.telphoneno,a.age,a.sex,a.doctor,a.Month_Year,a.tpt,b.test_date,b.srlno,b.disc,b.adv,b.balance from patient_master a,billl b,company c where a.pcode=b.pcode and a.cc=c.cc and b.pcode='" + cboissfrom.Text + "' order by b.pcode,b.srlno";


            //strsql = strsql + " from bill where pcode>='" + cboissfrom.Text + "'  and (pcode)<= '" + cboissto.Text + "'";
            da = new SqlDataAdapter(strsql, con);
            ds = new DataSet();
            da.Fill(ds, "path_bill");
            if (ds.Tables[0].Rows.Count != 0)
            {

                Reppathbill cashbankrep = new Reppathbill();

               // cashbankrep.SetDatabaseLogon("sa", "software", @".\sqlexpress", "pathology2627");
                cashbankrep.SetDataSource(ds);
                crv.ReportSource = cashbankrep;
                cashbankrep.SetParameterValue(0, ds2.Tables[0].Rows[0][1].ToString());
                cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows[0][2].ToString());
                cashbankrep.SetParameterValue(2, ds2.Tables[0].Rows[0][7].ToString());
                cashbankrep.SetParameterValue(3, ds2.Tables[0].Rows[0][8].ToString());
                cashbankrep.SetParameterValue(4, ds2.Tables[0].Rows[0][9].ToString());
                cashbankrep.SetParameterValue(5, ds2.Tables[0].Rows[0][10].ToString());
                cashbankrep.SetParameterValue(6, ds2.Tables[0].Rows[0][11].ToString());


                crv.Refresh();
            }
            else
            {
                MessageBox.Show("No Records Found!!!");
            }
        }

        private void cboissfrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboissto.Text = cboissfrom.Text;
        }

        private void crv_Load(object sender, EventArgs e)
        {

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
