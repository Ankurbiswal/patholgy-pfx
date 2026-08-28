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
    public partial class Frmserch : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        SqlDataReader dr;
        public static int pid ;
        public Frmserch()
        {
            InitializeComponent();
        }

        private void Frmserch_Load(object sender, EventArgs e)
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
            
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            //pid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            //Frmresultentry.pidr = pid;
           
            this.Close();
        }

      

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            String strsql = "";

            strsql = "select a.pcode,a.patient_name,a.area,a.scn as PhoneNo,a.date_exam,a.age,a.sex,b.test,b.pcode from patient_master a left join billl b on a.pcode=b.pcode where a.patient_name like '%" + txtname.Text + "%' order by a.date_exam";


            //strsql = strsql + " from bill where pcode>='" + cboissfrom.Text + "'  and (pcode)<= '" + cboissto.Text + "'";
            da = new SqlDataAdapter(strsql, con);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {

                dataGridView1.DataSource = ds.Tables[0].DefaultView;
                //dataGridView1.DataMember = "patient_master";


            }
            else
            {
                MessageBox.Show("No Records Found!!!");
            }


          

            da.Dispose();
        }

        private void txtphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            String strsql = "";

            strsql = "select a.pcode,a.patient_name,a.area,a.scn as PhoneNo,a.date_exam,a.age,a.sex,b.test,b.pcode from patient_master a left join billl b on a.pcode=b.pcode where a.scn like '%" + txtphone.Text + "%' order by a.date_exam";


            //strsql = strsql + " from bill where pcode>='" + cboissfrom.Text + "'  and (pcode)<= '" + cboissto.Text + "'";
            da = new SqlDataAdapter(strsql, con);
            ds = new DataSet();
            da.Fill(ds, "patient_master");
            if (ds.Tables[0].Rows.Count != 0)
            {

                //dataGridView1.AutoGenerateColumns();
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
                //dataGridView1.DataMember = "patient_master";


            }
            else
            {
                MessageBox.Show("No Records Found!!!");
            }
            da.Dispose();
        
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        { if (e.KeyValue == 27)
            {
                dataGridView1.Hide();
                this.Close();
            Frmresultentry.ActiveForm.Activate();
            }
            
            
            else if (e.KeyValue == 13)
            {
                pid = Convert.ToInt32 (dataGridView1.CurrentRow.Cells[0].Value);
               
                Frmresultentry.pidr = pid;
                Frmresultentry.gcode = pid;
                dataGridView1.Hide();
                this.Close();
                Frmresultentry.ActiveForm.Activate();
       
                //ActiveForm(Frmresultentry);
            
            }
        
        }

        

        private void dtser_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btngo_Click(object sender, EventArgs e)
        {
            DateTime dtf,dtt;
            String dd = dtser.Text.Substring(0, 2).ToString();
            String mmm = this.dtser.Text.Substring(3, 2).ToString();
            String yy = this.dtser.Text.Substring(6, 4).ToString();
            dtf = DateTime.ParseExact(dd + "/" + mmm + "/" + yy, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            String dd1 = dtto.Text.Substring(0, 2).ToString();
            String mmm1 = this.dtto.Text.Substring(3, 2).ToString();
            String yy1 = this.dtto.Text.Substring(6, 4).ToString();
            dtt = DateTime.ParseExact(dd1 + "/" + mmm1 + "/" + yy1, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            String strsql = "";

            strsql = "select a.pcode,a.scn as PhoneNo,a.patient_name,a.area,a.date_exam,a.age,a.sex,b.test,b.pcode from patient_master a left join billl b on a.pcode=b.pcode where a.date_exam >= '" + dtf.ToString("yyyy-MM-dd") + "' and a.date_exam <= '" + dtt.ToString("yyyy-MM-dd") + "' order by a.date_exam  ";


            //strsql = strsql + " from bill where pcode>='" + cboissfrom.Text + "'  and (pcode)<= '" + cboissto.Text + "'";
            da = new SqlDataAdapter(strsql, con);
            ds = new DataSet();
            da.Fill(ds, "patient_master");
            dataGridView1.DataSource = null;
            if (ds.Tables[0].Rows.Count != 0)
            {

                //dataGridView1.AutoGenerateColumns();
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
                //dataGridView1.DataMember = "patient_master";


            }
            else
            {
                MessageBox.Show("No Records Found!!!");
            }
            da.Dispose();
        
        }

        private void btnback_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //dgv.CurrentRow.Cells[0].Value = dataGridView1.CurrentRow.Cells[0].Value;
            pid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            Frmresultentry.pidr = pid;
            Frmresultentry.gcode = pid;
            this.Close();
            Frmresultentry.ActiveForm.Activate();
            
          
            
        }

        

       
    }
}
