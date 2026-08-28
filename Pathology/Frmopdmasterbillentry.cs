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
    public partial class Frmopdmasterbillentry : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd, cmd1;
        DataSet ds;
        SqlDataReader dr;
       // public static int pid = Frmopdregistration.pidr;
       public static int pid = Frmopdmaster.pidr;
       public static String pat_name1 = Frmopdmaster.pat_name;
        public static DateTime repdt2;
        
        public Frmopdmasterbillentry()
        {
            InitializeComponent();
        }

        private void Frmopdmasterbillentry_Load(object sender, EventArgs e)
        {
            Class1 objclass = new Class1();
            con = new SqlConnection(objclass.arun_con());

            con.Open();
            txtdisc.Text = "0.00";
            txtadv.Text = "0.00";
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

            da = new SqlDataAdapter("select test from test_master order by test ", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dgvtest.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            da.Dispose();
            pid = Frmopdmaster.pidr;
            cbopcode.Text = pid.ToString();



            //dgvbill.Visible = true;
            //dgvbill.Show();
            Double dbval = 0.00;
            da = new SqlDataAdapter("select test_date,test,price,o_s,disc,adv from bill2 where pcode='" + pid + "' order by srlno ", con);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                txtdisc.Text = ds.Tables[0].Rows[0][4].ToString();
                txtadv.Text = ds.Tables[0].Rows[0][5].ToString();
                dgvbillnew.Rows.Clear();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dgvbillnew.Rows.Add();
                    dgvbillnew.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][0].ToString();
                    dgvbillnew.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][1].ToString();


                    dgvbillnew.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][2].ToString();
                    dgvbillnew.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][3].ToString();
                    dbval = dbval + (Convert.ToDouble(dgvbillnew.Rows[i].Cells[2].Value.ToString()));

                }

                txtdue.Text = dbval.ToString();
                txtbalance.Text = (dbval - Convert.ToDouble(txtdisc.Text) - Convert.ToDouble(txtadv.Text)).ToString();

            }

            //String    mm = Frmresultentry.repdt1.Month();
            //String dd = Frmresultentry.repdt1.Day();
            //String yy = Frmresultentry.repdt1.Year();
            //   repdt2 = Convert.ToDateTime(mm + '/' + dd + '/' + yy);







            repdt2 = Frmopdmaster.repdt1;

            pat_name1 = Frmopdmaster.pat_name;
            cboname1.Text = pat_name1;
        }

        private void dgvbillnew_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvbillnew.CurrentRow.Cells[1].Value != null)
            {
                da = new SqlDataAdapter("select price from Test_master where test='" + dgvbillnew.CurrentRow.Cells[1].Value + "' order by test ", con);
                ds = new DataSet();
                da.Fill(ds);
                if (dgvbillnew.CurrentRow.Cells[2].Value == null || dgvbillnew.CurrentRow.Cells[2].Value.ToString() == "0.00")
                {
                    dgvbillnew.CurrentRow.Cells[2].Value = ds.Tables[0].Rows[0][0].ToString();
                }



                Double dbval = 0.00;
                for (int i = 0; i < dgvbillnew.Rows.Count; i++)
                {
                    if (dgvbillnew.Rows[i].Cells[2].Value != null)
                    {

                        dbval = dbval + (Convert.ToDouble(dgvbillnew.Rows[i].Cells[2].Value.ToString()));

                    }
                }
                txtdue.Text = dbval.ToString();
                txtbalance.Text = dbval.ToString();


            }
           
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            String ostrue = "";
            cmd = new SqlCommand("delete  bill2 where pcode='" + pid + "'", con);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("delete  cbjopd where vono='" + pid + "' and trncd='Test'", con);
            cmd.ExecuteNonQuery();


            for (int j = 0; j < dgvbillnew.Rows.Count; j++)
            {
                if (dgvbillnew.Rows[j].Cells[1].Value != null)
                {
                    if (dgvbillnew.Rows[j].Cells[3].Value == null || dgvbillnew.Rows[j].Cells[3].Value.ToString() == "False")
                    {
                        ostrue = "False";
                    }
                    else
                    {
                        ostrue = "True";
                    }
                    cmd = new SqlCommand("insert into bill2 (pcode,test_date,test,price,o_s,srlno,gross,disc,adv) values ('" + pid + "', '" + dgvbillnew.Rows[j].Cells[0].Value + "','" + dgvbillnew.Rows[j].Cells[1].Value + "','" + dgvbillnew.Rows[j].Cells[2].Value + "','" + ostrue + "','" + j + "','" + txtdue.Text + "','" + txtdisc.Text + "','" + txtadv.Text + "' )", con);
                    cmd.ExecuteNonQuery();
                }
            }
            double gr = Convert.ToDouble(txtdue.Text) - Convert.ToDouble(txtdisc.Text);
            da.Dispose();
            da = new SqlDataAdapter("select doctor,tpt from opd_master where pcode='" + pid + "'", con);
            ds = new DataSet();
            da.Fill(ds);
            String pat1 = pat_name1.Trim() + "(" + pid.ToString().Trim() + ")";
            cmd1 = new SqlCommand("insert into cbjopd (cc,Trncd,Vodt,Vono,acdes,dcin,Amt,narr,chno,chdt,pcode,referal,doctor) values('1','Test ','" + repdt2 + "','" + pid + "', '" + pat1 + "', 'D', '" + gr + "', '', '', '','" + pid + "','" + ds.Tables[0].Rows[0][1].ToString() + "','" + ds.Tables[0].Rows[0][0].ToString() + "')", con);
            cmd1.ExecuteNonQuery();

            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                cmd1 = new SqlCommand("insert into cbjopd (cc,Trncd,Vodt,Vono,acdes,dcin,Amt,narr,chno,chdt,pcode,referal,doctor) values('1','Test ','" + repdt2 + "','" + pid + "', '" + ds.Tables[0].Rows[0][0].ToString() + "', 'C', '" + gr + "', '" + pat1 + "', '', '','" + pid + "','" + ds.Tables[0].Rows[0][1].ToString() + "','" + ds.Tables[0].Rows[0][0].ToString() + "')", con);
                cmd1.ExecuteNonQuery();
            }
            if (ds.Tables[0].Rows[0][1].ToString() != "")
            {
                cmd1 = new SqlCommand("insert into cbjopd (cc,Trncd,Vodt,Vono,acdes,dcin,Amt,narr,chno,chdt,pcode,referal,doctor) values('1','Test ','" + repdt2 + "','" + pid + "', '" + ds.Tables[0].Rows[0][1].ToString() + "', 'C', '" + gr + "', '" + pat1 + "', '', '','" + pid + "','" + ds.Tables[0].Rows[0][1].ToString() + "','" + ds.Tables[0].Rows[0][0].ToString() + "')", con);
                cmd1.ExecuteNonQuery();
            }


            label4.Text = "Bill Saved !!";  
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            Frmpathbill_opd FPBILL = new Frmpathbill_opd();
            FPBILL.Show();
        }

        private void txtbalance_Validating(object sender, CancelEventArgs e)
        {
            if (txtdue.Text == "")
            {
                txtdue.Text = "0.00";
            }
            else
            {
                txtbalance.Text = (Convert.ToDouble(txtdue.Text) - Convert.ToDouble(txtdisc.Text) - Convert.ToDouble(txtadv.Text)).ToString();
            }
        }

        private void callnumber(KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && !Char.IsPunctuation(e.KeyChar) && e.KeyChar != Delete;
        }
        private void txtdisc_Validating(object sender, CancelEventArgs e)
        {
            txtbalance.Text = (Convert.ToDouble(txtdue.Text) - Convert.ToDouble(txtdisc.Text) - Convert.ToDouble(txtadv.Text)).ToString();
        }

        private void txtadv_Validating(object sender, CancelEventArgs e)
        {
            txtbalance.Text = (Convert.ToDouble(txtdue.Text) - Convert.ToDouble(txtdisc.Text) - Convert.ToDouble(txtadv.Text)).ToString();
        }
        
        
        private void txtdue_Validating(object sender, CancelEventArgs e)
        {
            txtbalance.Text = (Convert.ToDouble(txtdue.Text) - Convert.ToDouble(txtdisc.Text) - Convert.ToDouble(txtadv.Text)).ToString();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
