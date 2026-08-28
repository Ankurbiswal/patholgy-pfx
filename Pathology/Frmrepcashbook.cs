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
    public partial class Frmrepcashbook : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        SqlDataReader dr;
        public Frmrepcashbook()
        {
            InitializeComponent();
        }

        private void Frmrepcashbook_Load(object sender, EventArgs e)
        {
            Class1 objclass = new Class1();
            con = new SqlConnection(objclass.arun_con());
            con.Open();
            cmd = new SqlCommand("select cc,comp,year_start,year_end from setup");
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                this.txtcompid.Text = dr.GetValue(0).ToString();
                label4.Text = dr.GetValue(1).ToString();
                dtfrom.Text = dr.GetValue(2).ToString();
            }
            dr.Close();



            String s = ("select acdes from account_master where gcd=3 and scd=2 order by Acdes");
            da = new SqlDataAdapter(s, con);
            ds = new DataSet();
            da.Fill(ds);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cbocashbank.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            //This for item name 
          // cbocashbank.Items.Add("Cash");
            cbocashbank.SelectedIndex = -1;
            con.Close();
            da.Dispose();
        }

        private void cbocashbank_SelectedIndexChanged(object sender, EventArgs e)
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


            Pathology_Ds ds0 = new Pathology_Ds();
            String s = ("select cc,trncd,vodt,vono,acdes,chno,chdt,amt,narr,dcin from cbj where vodt< '" + dtf.ToString("yyyy-MM-dd") + "' and cc='" + txtcompid.Text + "' and trncd='" + cbocashbank.SelectedItem + "' order by cc,trncd,vodt,vono");
            da = new SqlDataAdapter(s, con);
            ds = new DataSet();
            da.Fill(ds, "cbj");
            int i = 0;
            Double clbal = 0;
            if (ds.Tables[0].Rows.Count != 0)
            {
                while (Convert.ToDateTime(ds.Tables[0].Rows[i][2].ToString()) <= dtf & ds.Tables[0].Rows[i][1].ToString() == cbocashbank.SelectedItem.ToString())
                {
                    if (ds.Tables[0].Rows[i][9].ToString() == "C")
                    {

                        clbal = clbal + Convert.ToDouble(ds.Tables[0].Rows[i][7].ToString());

                    }
                    else
                    {
                        clbal = clbal - Convert.ToDouble(ds.Tables[0].Rows[i][7].ToString());

                    }
                    i++;
                    if (i >= ds.Tables[0].Rows.Count) break;
                }
            }
            else
            {
                //MessageBox.Show("No Records");
            }
            da.Dispose();



            String s1 = ("select cc,trncd,vono,vodt,acdes,amt,dcin,narr,chno,chdt from cbj where vodt>= '" + dtf.ToString("yyyy-MM-dd") + "' and vodt<= '" + dtt.ToString("yyyy-MM-dd") + "' and cc='" + txtcompid.Text + "' and trncd='" + cbocashbank.SelectedItem + "' order by cc,trncd,vodt,vono");
            da = new SqlDataAdapter(s1, con);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                DataTable dtv = new DataTable();
                dtv = ds.Tables[0];

                Pathology_Ds dsh = new Pathology_Ds();
                DataTable dt = new DataTable();
                // Ds_hope dsh = new Ds_hope();
                //  DataTable dt = new DataTable();
                dt = dsh.Tables.Add("ds_cbj");
                dt.Columns.Add("Cc", System.Type.GetType("System.Int32"));
                dt.Columns.Add("Trncd", System.Type.GetType("System.String"));
                dt.Columns.Add("Vono", System.Type.GetType("System.String"));
                dt.Columns.Add("Vodt", System.Type.GetType("System.DateTime"));

                dt.Columns.Add("Acdes", System.Type.GetType("System.String"));
                dt.Columns.Add("Amt", System.Type.GetType("System.Double"));
                dt.Columns.Add("Dcin", System.Type.GetType("System.String"));
                dt.Columns.Add("Narr", System.Type.GetType("System.String"));
                dt.Columns.Add("Chno", System.Type.GetType("System.String"));
                dt.Columns.Add("Chdt", System.Type.GetType("System.DateTime"));

                for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                {
                    //if (dtv.Rows[k][9].ToString() == "")
                    //{
                    //    dtv.Rows[k][9] = "0.00";
                    //}
                    //  dt.Rows.Add(Convert.ToDouble(dtv.Rows[k][0]), dtv.Rows[k][1], dtv.Rows[k][2], Convert.ToDateTime(dtv.Rows[k][3]), dtv.Rows[k][4], dtv.Rows[k][5], dtv.Rows[k][6], dtv.Rows[k][7], dtv.Rows[k][8], Convert.ToDouble(dtv.Rows[k][9]), Convert.ToDouble(dtv.Rows[k][10]), Convert.ToDouble(dtv.Rows[k][11]), Convert.ToDouble(dtv.Rows[k][12]), Convert.ToDouble(dtv.Rows[k][13]), Convert.ToDouble(dtv.Rows[k][14]), Convert.ToDouble(dtv.Rows[k][15]), Convert.ToDouble(dtv.Rows[k][16]), Convert.ToDouble(dtv.Rows[k][17]), Convert.ToDouble(dtv.Rows[k][18]), dtv.Rows[k][19], dtv.Rows[k][20], dtv.Rows[k][21], dtv.Rows[k][22], dtv.Rows[k][23]);
                    dt.Rows.Add(Convert.ToDouble(dtv.Rows[k][0]), dtv.Rows[k][1], dtv.Rows[k][2], Convert.ToDateTime(dtv.Rows[k][3]), dtv.Rows[k][4], Convert.ToDouble(dtv.Rows[k][5]), dtv.Rows[k][6], dtv.Rows[k][7], dtv.Rows[k][8], Convert.ToDateTime(dtv.Rows[k][9]));

                }



                Repcash cashbankrep = new Repcash();
                //cashbankrep.SetDatabaseLogon("sa", "software", @".\SQLEXPRESS", "pathology2627");
                cashbankrep.SetDataSource(dt);
                crv.ReportSource = cashbankrep;
                
                cashbankrep.SetParameterValue(0, clbal);
                cashbankrep.SetParameterValue(1, cbocashbank.Text);
                cashbankrep.SetParameterValue(2, label4.Text);
                cashbankrep.SetParameterValue(3, dtf);
                cashbankrep.SetParameterValue(4, dtt);
                crv.Refresh();
            }
            else
            {
                MessageBox.Show("Voucher Not Entered!!!");
            }


            con.Close();

            //reptop50 frm3 = new reptop50();
            //frm3.SetDataSource(ds0);
            //crystalReportViewer1.ReportSource = frm3;
            //crystalReportViewer1.Refresh();
        
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
