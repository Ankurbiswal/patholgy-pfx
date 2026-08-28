using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Pathology
{
    public partial class Frmrepopdprescription : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        SqlDataReader dr;
        public Frmrepopdprescription()
        {
            InitializeComponent();
        }

        private void Frmrepopdprescription_Load(object sender, EventArgs e)
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
            //da = new SqlDataAdapter("select  pcode from Masteropd order by pcode", con);
            da = new SqlDataAdapter("select  pcode from OPD_Master order by pcode", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                this.cboissuefrom.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                this.cboissueto.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            //cboissuefrom.Text = Frmopdregistration.pidr.ToString ();
            //cboissueto.Text = Frmopdmaster.pidr.ToString(); ;
            cboissuefrom.Text = Frmopdmaster.pidr.ToString();
            cboissueto.Text = Frmopdmaster.pidr.ToString(); ;
        }

        private void btnviewopd_Click(object sender, EventArgs e)
        {
            string strsql = "";
            //strsql = "select a.cc,a.pcode,a.regd_no,a.patient_name,a.age,a.month_year,a.sex,a.date_exam,a.admn_time,a.department ,a.room_no,a.seat_no,a.ADD_AT,a.ADD_PO,a.ADD_DIST,a.ADD_STATE,a.mob,a.LANDLINE,a.ORGANIZATION,a.orga_mob,a.GUARDIAN,a.GUARDIAN_MOB,a.RELATIONSHIP,a.ADMIT_FOR,a.NOTES,a.OTYN,a.DT_OPERATION,a.Date_discharge,a.TIME_DISCHARGE,a.ROOM_INSPECTION_STATUS,a.Scn,a.Tpt,a.doctor,a.bpl,a.admitted,a.diagnosis,c.comp,c.address,c.telphoneno,b.telphoneno as telphoneno1,b.pathologist,b.biochemist";
            //strsql = strsql + " from OPD_Master a,doctor b,company c where a.cc=c.cc and a.doctor=b.Name and a.pcode>='" + cboissuefrom.Text + "'  and a.pcode<= '" + cboissueto.Text + "'";

            strsql = "select a.cc,a.pcode,a.regd_no,a.patient_name,a.age,a.month_year,a.sex,a.date_exam,a.admn_time,a.acdes ,a.room_no,a.seat_no,a.ADD_AT,a.ADD_PO,a.ADD_DIST,a.ADD_STATE,a.mob,a.LANDLINE,a.ORGANIZATION,a.orga_mob,a.GUARDIAN,a.GUARDIAN_MOB,a.RELATIONSHIP,a.ADMIT_FOR,a.NOTES,a.OTYN,a.DT_OPERATION,a.Date_discharge,a.TIME_DISCHARGE,a.ROOM_INSPECTION_STATUS,a.Scn,a.Tpt,a.doctor,c.comp,c.address,c.telphoneno,b.telphoneno as telphoneno1,b.pathologist,b.biochemist";
            strsql = strsql + " from OPD_Master a,doctor b,company c where a.cc=c.cc and a.doctor=b.Name and a.pcode>='" + cboissuefrom.Text + "'  and a.pcode<= '" + cboissueto.Text + "'";
            
            da = new SqlDataAdapter(strsql, con);
            ds = new DataSet();
            da.Fill(ds, "path_ipd");
            if (ds.Tables[0].Rows.Count != 0)
            {

                //Repprescription cashbankrep = new Repprescription();
                //Repopd cashbankrep = new Repopd();
                //Repopdnew cashbankrep = new Repopdnew();
                Repopdsaiseva cashbankrep = new Repopdsaiseva();
                // cashbankrep.SetDatabaseLogon("sa", "software", @".\sqlexpress", "pathology2627");
                cashbankrep.SetDataSource(ds);
                crv.ReportSource = cashbankrep;
                // cashbankrep.SetParameterValue(0, ds.Tables[0].Rows[0][62].ToString());
                // cashbankrep.SetParameterValue(1, ds.Tables[0].Rows[0][63].ToString());


                crv.Refresh();
            }
            else
            {
                MessageBox.Show("No Records Found!!!");
            }
        }

        private void cboissuefrom_Validating(object sender, CancelEventArgs e)
        {
            cboissueto.Text = cboissuefrom.Text;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
