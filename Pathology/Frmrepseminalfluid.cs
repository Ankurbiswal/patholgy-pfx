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
    public partial class Frmrepseminalfluid : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds,ds2;
        SqlDataReader dr;
        public Byte[] imageData;
        public static String qrcode = "";
        public Frmrepseminalfluid()
        {
            InitializeComponent();
        }

        private void Frmrepseminalfluid_Load(object sender, EventArgs e)
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
                
               this.cbopcode .Text = dr.GetValue(4).ToString();
                //label4.Text = dr.GetValue(1).ToString();
                //dtfrom.Text = dr.GetValue(2).ToString();
            }
            dr.Close();

            da = new SqlDataAdapter("select patient_name,pcode from patient_master where pcode='" + cbopcode.Text + "' order by pcode", con);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
                cboname.Text = ds.Tables[0].Rows[0][0].ToString();
            da.Dispose();
            da = new SqlDataAdapter("select distinct patient_name,pcode from patient_master order by pcode", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                this.cboname.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                this.cbopcode.Items.Add(ds.Tables[0].Rows[i][1].ToString());
            }
            da.Dispose();
            da = new SqlDataAdapter("select cc,comp,address,year_start,year_end,pathologist,biochemist,telphoneno,email,cstno,address1,faxno from company", con);
            ds2 = new DataSet();
            da.Fill(ds2);
            da.Dispose();
        }

        private void btngo_Click(object sender, EventArgs e)
        {
            //String s1 = ("select cc,type,blno,bldt,acdes,challan_no,challan_dt,gross,discount_rt,discount,vat_rt,vat,tamt from inv where bldt>= '" + Convert.ToDateTime(dtfrom.Text) + "' and bldt<= '" + Convert.ToDateTime(dtto.Text) + "' and cc='" + txtcompid.Text + "' and type='" + cbotype.Text + "' order by cc,type,bldt,blno");
            String s1 = ("select b.FA_Timeofcollection,b.FA_Timeofexamination,b.FA_Timeofliquification,b.FA_Volume,b.FA_Reaction,b.FA_Color,b.FA_Viscocity,b.FA_MP_Prostaticpearls,b.FA_MP_Puscells,b.FA_MP_RBC,b.FA_MP_Epithcells,b.FA_MP_Deformed,b.FA_MT_Active,b.FA_MT_Slugish,b.FA_MT_Dead,b.FA_MT_Totalcount,b.FA_MP_Premature,b.FA_MT_IMP,a.pcode,a.age,a.sex,a.patient_name,a.date_exam,a.doctor,a.month_year,a.scn,a.tpt,b.patient_name as ivif from patient_master a,seminal_fluid b where a.pcode='" + cbopcode.Text + "' and a.pcode=b.pcode order by a.pcode,a.date_exam");
           
            da = new SqlDataAdapter(s1, con);
            ds = new DataSet();
            da.Fill(ds, "seminal_fluid");


            DataTable dtv = new DataTable();
            dtv = ds.Tables[0];

            Pathology_Ds dsh = new Pathology_Ds();
            DataTable dt = new DataTable();
            dt = dsh.Tables.Add("Pathology_sf");

            dt.Columns.Add("FA_Timeofcollection", System.Type.GetType("System.String"));
            dt.Columns.Add("FA_Timeofexamination", System.Type.GetType("System.String"));
            dt.Columns.Add("FA_Timeofliquification", System.Type.GetType("System.String"));
            dt.Columns.Add("FA_Volume", System.Type.GetType("System.String"));
            dt.Columns.Add("FA_Reaction", System.Type.GetType("System.String"));
            dt.Columns.Add("FA_Color", System.Type.GetType("System.String"));
            dt.Columns.Add("FA_Viscocity", System.Type.GetType("System.String"));
            dt.Columns.Add("FA_MP_Prostaticpearls", System.Type.GetType("System.String"));
            dt.Columns.Add("FA_MP_Puscells", System.Type.GetType("System.String"));
            dt.Columns.Add("FA_MP_RBC", System.Type.GetType("System.String"));
            dt.Columns.Add("FA_MP_Epithcells", System.Type.GetType("System.String"));
            dt.Columns.Add("FA_MP_Deformed", System.Type.GetType("System.String"));
            dt.Columns.Add("FA_MT_Active", System.Type.GetType("System.Int32"));
            dt.Columns.Add("FA_MT_Slugish", System.Type.GetType("System.Int32"));

            dt.Columns.Add("FA_MT_Dead", System.Type.GetType("System.Int32"));
            dt.Columns.Add("FA_MT_Totalcount", System.Type.GetType("System.Double"));
            dt.Columns.Add("FA_MP_Premature", System.Type.GetType("System.String"));
            dt.Columns.Add("FA_MT_IMP", System.Type.GetType("System.String"));
           
            dt.Columns.Add("Pcode", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Age", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Sex", System.Type.GetType("System.String"));
            dt.Columns.Add("Patient_Name", System.Type.GetType("System.String"));
            dt.Columns.Add("Dt_Report", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("Doctor", System.Type.GetType("System.String"));
            dt.Columns.Add("month_year", System.Type.GetType("System.String"));
            dt.Columns.Add("scn", System.Type.GetType("System.String"));
            dt.Columns.Add("tpt", System.Type.GetType("System.String"));
            dt.Columns.Add("ivif", System.Type.GetType("System.String"));

            dt.Columns.Add("imageData", System.Type.GetType("System.Byte[]"));

            String qrdata = cbopcode.Text.Trim();
            BarcodeLib.Barcode.Linear qrcode = new BarcodeLib.Barcode.Linear();
            qrcode.Type = BarcodeLib.Barcode.BarcodeType.CODE39;
            qrcode.Data = qrdata;

            // Save & output QR Code barcode image to your system
            qrcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;
            byte[] imageData = qrcode.drawBarcodeAsBytes();

            
            
            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
            {
                dt.Rows.Add(dtv.Rows[k][0], dtv.Rows[k][1], dtv.Rows[k][2], dtv.Rows[k][3], dtv.Rows[k][4], dtv.Rows[k][5], dtv.Rows[k][6], dtv.Rows[k][7], dtv.Rows[k][8], dtv.Rows[k][9], dtv.Rows[k][10], dtv.Rows[k][11], Convert.ToInt32(dtv.Rows[k][12]), Convert.ToInt32(dtv.Rows[k][13]), Convert.ToInt32(dtv.Rows[k][14]), Convert.ToDouble(dtv.Rows[k][15]), dtv.Rows[k][16], dtv.Rows[k][17], Convert.ToInt32(dtv.Rows[k][18]), Convert.ToInt32(dtv.Rows[k][19]), dtv.Rows[k][20], dtv.Rows[k][21], Convert.ToDateTime(dtv.Rows[k][22]), dtv.Rows[k][23], dtv.Rows[k][24], dtv.Rows[k][25], dtv.Rows[k][26], dtv.Rows[k][27], imageData);

            }
            
            
            if (ds.Tables[0].Rows.Count != 0)
            {
                //cashbankrep = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                //cashbankrep.Load("/Hope_account/Hope_account/repcash_Bank.rpt");

                Repseminalfluidds cashbankrep = new Repseminalfluidds();
                //cashbankrep.SetDatabaseLogon("sa", "software", @".\SQLEXPRESS", "pathology2627");
                cashbankrep.SetDataSource(dt);
                crv.ReportSource = cashbankrep;
                cashbankrep.SetParameterValue(0, ds2.Tables[0].Rows[0][5].ToString());
                cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows[0][6].ToString());
                cashbankrep.SetParameterValue(2, ds2.Tables[0].Rows[0][9].ToString());
                cashbankrep.SetParameterValue(3, ds2.Tables[0].Rows[0][10].ToString());
                cashbankrep.SetParameterValue(4, ds2.Tables[0].Rows[0][11].ToString());
                //cashbankrep.SetParameterValue(0, dtfrom.Text);
                //cashbankrep.SetParameterValue(1, dtto.Text);
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

        private void cbopcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("select patient_name from patient_master where pcode='" + cbopcode.Text + "'", con);
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
            cbopcode.Text = ds.Tables[0].Rows[0][0].ToString();
        }

        private void btnsemiback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnrepsfh_Click(object sender, EventArgs e)
        {
            String s1 = ("select b.FA_Timeofcollection,b.FA_Timeofexamination,b.FA_Timeofliquification,b.FA_Volume,b.FA_Reaction,b.FA_Color,b.FA_Viscocity,b.FA_MP_Prostaticpearls,b.FA_MP_Puscells,b.FA_MP_RBC,b.FA_MP_Epithcells,b.FA_MP_Deformed,b.FA_MT_Active,b.FA_MT_Slugish,b.FA_MT_Dead,b.FA_MT_Totalcount,b.FA_MP_Premature,b.FA_MT_IMP,a.pcode,a.age,a.sex,a.patient_name,a.date_exam,a.doctor,a.month_year,a.scn,a.tpt,b.patient_name as ivif from patient_master a,seminal_fluid b where a.pcode='" + cbopcode.Text + "' and a.pcode=b.pcode order by a.pcode,a.date_exam");

            da = new SqlDataAdapter(s1, con);
            ds = new DataSet();
            da.Fill(ds, "seminal_fluid");


            DataTable dtv = new DataTable();
            dtv = ds.Tables[0];

            Pathology_Ds dsh = new Pathology_Ds();
            DataTable dt = new DataTable();
            dt = dsh.Tables.Add("Pathology_sf");

            dt.Columns.Add("FA_Timeofcollection", System.Type.GetType("System.String"));
            dt.Columns.Add("FA_Timeofexamination", System.Type.GetType("System.String"));
            dt.Columns.Add("FA_Timeofliquification", System.Type.GetType("System.String"));
            dt.Columns.Add("FA_Volume", System.Type.GetType("System.String"));
            dt.Columns.Add("FA_Reaction", System.Type.GetType("System.String"));
            dt.Columns.Add("FA_Color", System.Type.GetType("System.String"));
            dt.Columns.Add("FA_Viscocity", System.Type.GetType("System.String"));
            dt.Columns.Add("FA_MP_Prostaticpearls", System.Type.GetType("System.String"));
            dt.Columns.Add("FA_MP_Puscells", System.Type.GetType("System.String"));
            dt.Columns.Add("FA_MP_RBC", System.Type.GetType("System.String"));
            dt.Columns.Add("FA_MP_Epithcells", System.Type.GetType("System.String"));
            dt.Columns.Add("FA_MP_Deformed", System.Type.GetType("System.String"));
            dt.Columns.Add("FA_MT_Active", System.Type.GetType("System.Int32"));
            dt.Columns.Add("FA_MT_Slugish", System.Type.GetType("System.Int32"));

            dt.Columns.Add("FA_MT_Dead", System.Type.GetType("System.Int32"));
            dt.Columns.Add("FA_MT_Totalcount", System.Type.GetType("System.Double"));
            dt.Columns.Add("FA_MP_Premature", System.Type.GetType("System.String"));
            dt.Columns.Add("FA_MT_IMP", System.Type.GetType("System.String"));

            dt.Columns.Add("Pcode", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Age", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Sex", System.Type.GetType("System.String"));
            dt.Columns.Add("Patient_Name", System.Type.GetType("System.String"));
            dt.Columns.Add("Dt_Report", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("Doctor", System.Type.GetType("System.String"));
            dt.Columns.Add("month_year", System.Type.GetType("System.String"));
            dt.Columns.Add("scn", System.Type.GetType("System.String"));
            dt.Columns.Add("tpt", System.Type.GetType("System.String"));
            dt.Columns.Add("ivif", System.Type.GetType("System.String"));
            dt.Columns.Add("imageData", System.Type.GetType("System.Byte[]"));

            String qrdata = cbopcode.Text.Trim();
            BarcodeLib.Barcode.Linear qrcode = new BarcodeLib.Barcode.Linear();
            qrcode.Type = BarcodeLib.Barcode.BarcodeType.CODE39;
            qrcode.Data = qrdata;

            // Save & output QR Code barcode image to your system
            qrcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;
            byte[] imageData = qrcode.drawBarcodeAsBytes();

            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
            {
                dt.Rows.Add(dtv.Rows[k][0], dtv.Rows[k][1], dtv.Rows[k][2], dtv.Rows[k][3], dtv.Rows[k][4], dtv.Rows[k][5], dtv.Rows[k][6], dtv.Rows[k][7], dtv.Rows[k][8], dtv.Rows[k][9], dtv.Rows[k][10], dtv.Rows[k][11], Convert.ToInt32(dtv.Rows[k][12]), Convert.ToInt32(dtv.Rows[k][13]), Convert.ToInt32(dtv.Rows[k][14]), Convert.ToDouble(dtv.Rows[k][15]), dtv.Rows[k][16], dtv.Rows[k][17], Convert.ToInt32(dtv.Rows[k][18]), Convert.ToInt32(dtv.Rows[k][19]), dtv.Rows[k][20], dtv.Rows[k][21], Convert.ToDateTime(dtv.Rows[k][22]), dtv.Rows[k][23], dtv.Rows[k][24], dtv.Rows[k][25], dtv.Rows[k][26], dtv.Rows[k][27], imageData);

            }


            if (ds.Tables[0].Rows.Count != 0)
            {
                //cashbankrep = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                //cashbankrep.Load("/Hope_account/Hope_account/repcash_Bank.rpt");

                Repseminalfluiddsh cashbankrep = new Repseminalfluiddsh();
                //cashbankrep.SetDatabaseLogon("sa", "software", @".\SQLEXPRESS", "pathology2627");
                cashbankrep.SetDataSource(dt);
                crv.ReportSource = cashbankrep;
                cashbankrep.SetParameterValue(0, ds2.Tables[0].Rows[0][1].ToString());
                cashbankrep.SetParameterValue(1, ds2.Tables[0].Rows[0][2].ToString());
                cashbankrep.SetParameterValue(2, ds2.Tables[0].Rows[0][5].ToString());
                cashbankrep.SetParameterValue(3, ds2.Tables[0].Rows[0][6].ToString());
                cashbankrep.SetParameterValue(4, ds2.Tables[0].Rows[0][7].ToString());
                cashbankrep.SetParameterValue(5, ds2.Tables[0].Rows[0][8].ToString());

                cashbankrep.SetParameterValue(6, ds2.Tables[0].Rows[0][9].ToString());
                cashbankrep.SetParameterValue(7, ds2.Tables[0].Rows[0][10].ToString());
                cashbankrep.SetParameterValue(8, ds2.Tables[0].Rows[0][11].ToString());
                
                //cashbankrep.SetParameterValue(0, dtfrom.Text);
                //cashbankrep.SetParameterValue(1, dtto.Text);
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
    }
}