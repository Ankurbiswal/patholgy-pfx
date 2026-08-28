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
    public partial class Frmbillentry : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd,cmd1;
        DataSet ds;
        SqlDataReader dr;
        public static int pid=0;
        public static String pat_name1="";
        public static DateTime repdt2;
            //= Frmresultentry.repdt1;
        public static int rpcode_del_tag = Frmpassword.pcode_del_tag;
        public static String buserid1 = Frmpassword.userid1;
        public static String bpasswd1 = Frmpassword.passwd1;
        public static String busrname1 = Frmpassword.usrname1;
        public static String busrtype1 = Frmpassword.usrtype1;

        Double gross = 0.00;
        Double dis = 0.00;
        Double netgr = 0.00;
        Double adv = 0.00;
        Double bal = 0.00;
        public Frmbillentry()
        {
            InitializeComponent();
        }
        private void Frmbillentry_Load(object sender, EventArgs e)
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

            da = new SqlDataAdapter("select test from Test_master order by test ", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dgvtest.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            da.Dispose();
             da = new SqlDataAdapter("select Name from referal  order by name ", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                dgvoscompany.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            da.Dispose();
            


            
            txtdue.Text = "0.00";
            txtdisc.Text = "0.00";
            txtadv.Text = "0.00";
            txtbalance.Text = "0.00";
            
           
            Double dbval = 0.00;
            da = new SqlDataAdapter("select test_date,test,price,o_s,srlno,gross,disc,adv,balance,osc from billl where pcode='" + Frmresultentry.pidr + "' order by srlno ", con);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                dgvbillnew.Rows.Clear();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dgvbillnew.Rows.Add();
                    dgvbillnew.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][0].ToString();
                    dgvbillnew.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][1].ToString();


                    dgvbillnew.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][2].ToString();
                    dgvbillnew.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][3].ToString();
                    dgvbillnew.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][9].ToString();
                    dbval = dbval + (Convert.ToDouble(dgvbillnew.Rows[i].Cells[2].Value.ToString()));

                }

                txtdue.Text = dbval.ToString();
                txtdisc.Text = ds.Tables[0].Rows[0][6].ToString();
                txtadv.Text = ds.Tables[0].Rows[0][7].ToString();
                txtbalance.Text = ds.Tables[0].Rows[0][8].ToString();
            }


            pid = Frmresultentry.pidr;
            cbopcode.Text = pid.ToString();
            repdt2 = Frmresultentry.repdt1;
            
            pat_name1=Frmresultentry.pat_name;
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
                    if (dgvbillnew.Rows[i].Cells[2].Value != null )
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
            //Sqlstr = "";
            String ostrue = "";
             gross = 0.00;
           dis = 0.00;
            netgr = 0.00;
            adv = 0.00;
            bal = 0.00;
            
            
            if (busrtype1 == "Admin")
            {
                cmd = new SqlCommand("delete  billl where pcode='" + pid + "'", con);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("delete  cbj where vono='" + pid + "' and trncd='Test'", con);
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
                        // Fixed: removed srlno (IDENTITY column) from billl insert; added month_year and cc
                        cmd = new SqlCommand("insert into billl (pcode,test_date,test,price,o_s,gross,disc,adv,balance,osc,month_year,cc,del_tag) values ('" + pid + "', '" + dgvbillnew.Rows[j].Cells[0].Value + "','" + dgvbillnew.Rows[j].Cells[1].Value + "','" + dgvbillnew.Rows[j].Cells[2].Value + "','" + ostrue + "','" + txtdue.Text + "','" + txtdisc.Text + "','" + txtadv.Text + "','" + txtbalance.Text + "','" + dgvbillnew.Rows[j].Cells[4].Value + "','" + DateTime.Now.ToString("MM/yyyy") + "',1,0)", con);
                        cmd.ExecuteNonQuery();
                    }
                }
                da.Dispose();
                 gross = Convert.ToDouble (txtdue.Text);
                 dis = Convert.ToDouble(txtdisc.Text);
                 adv = Convert.ToDouble(txtadv.Text);
                 netgr = gross - dis;
                bal = gross-dis-adv;
                String pat1 = pat_name1.Trim ()+"(" + pid.ToString().Trim()+")"; 
                da = new SqlDataAdapter("select doctor,referal from patient_master where pcode='" + pid + "'", con);
                ds = new DataSet();
                da.Fill(ds);

                // Fixed: cbj has no pcode/referal/doctor columns - removed them
                cmd1 = new SqlCommand("insert into cbj (cc,Trncd,Vodt,Vono,acdes,dcin,Amt,narr,chno,chdt) values('1','Test ','" + repdt2 + "','" + pid + "', '" + pat1 +"', 'D', '" + netgr + "', '" + pat1 + "', '', '')", con);
                cmd1.ExecuteNonQuery();

                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    cmd1 = new SqlCommand("insert into cbj (cc,Trncd,Vodt,Vono,acdes,dcin,Amt,narr,chno,chdt) values('1','Test ','" + repdt2 + "','" + pid + "', '" + ds.Tables[0].Rows[0][0].ToString() + "', 'C', '" + netgr + "', '" + pat1 + "', '', '')", con);
                    cmd1.ExecuteNonQuery();
                }
                if (ds.Tables[0].Rows[0][1].ToString() != "")
                {
                    cmd1 = new SqlCommand("insert into cbj (cc,Trncd,Vodt,Vono,acdes,dcin,Amt,narr,chno,chdt) values('1','Test ','" + repdt2 + "','" + pid + "', '" + ds.Tables[0].Rows[0][1].ToString() + "', 'C', '" + netgr + "', '" + pat1 + "', '', '')", con);
                    cmd1.ExecuteNonQuery();
                }


                label4.Text = "Bill Saved !!";
            }
            else
            {
                MessageBox.Show("You are not authorised !!", "Authorisation",
       MessageBoxButtons.OK, MessageBoxIcon.Information );
                
                //MessageBox.Show("You are not authorised !!");
            }

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            Frmreppathbill FPBILL = new Frmreppathbill();
            FPBILL.Show();
        }

        private void Frmbillentry_Validating(object sender, CancelEventArgs e)
        {
            gross = Convert.ToDouble(txtdue.Text);
            dis = Convert.ToDouble(txtdisc.Text);
            adv = Convert.ToDouble(txtadv.Text);
            netgr = gross - dis;
            bal = gross - dis - adv;
            txtbalance.Text = bal.ToString();
        }

        private void txtdisc_Validating(object sender, CancelEventArgs e)
        {
            gross = Convert.ToDouble(txtdue.Text);
            dis = Convert.ToDouble(txtdisc.Text);
            adv = Convert.ToDouble(txtadv.Text);
            netgr = gross - dis;
            bal = gross - dis - adv;
            txtbalance.Text = bal.ToString();
        }

        private void txtadv_Validating(object sender, CancelEventArgs e)
        {
            gross = Convert.ToDouble(txtdue.Text);
            dis = Convert.ToDouble(txtdisc.Text);
            adv = Convert.ToDouble(txtadv.Text);
            netgr = gross - dis;
            bal = gross - dis - adv;
            txtbalance.Text = bal.ToString();
        }

        private void txtbalance_Validating(object sender, CancelEventArgs e)
        {
            gross = Convert.ToDouble(txtdue.Text);
            dis = Convert.ToDouble(txtdisc.Text);
            adv = Convert.ToDouble(txtadv.Text);
            netgr = gross - dis;
            bal = gross - dis - adv;
            txtbalance.Text = bal.ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtdisc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
       
        }

        private void txtadv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtbalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void dgvbillnew_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //ComboBox editingComboBox = (ComboBox)e.Control;
            //if (editingComboBox != null)
            //    editingComboBox.SelectedIndexChanged += new System.EventHandler(this.editingComboBox_SelectedIndexChanged);
            
            
            
            
            
            e.Control.KeyPress -= new KeyPressEventHandler(dgvprice_KeyPress);

            if (dgvbillnew.CurrentCell.ColumnIndex == 2) //Desired Column
            {
                TextBox tbox = e.Control as TextBox;
                if (tbox != null)
                {
                    tbox.KeyPress += new KeyPressEventHandler(dgvprice_KeyPress);
                }
            }
        
        }
        private void editingComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
           // ComboBox comboBox1 = (ComboBox)sender;
            // Display index
           // MessageBox.Show(comboBox1.SelectedIndex.ToString());
            // Display value
           // MessageBox.Show(comboBox1.Text);
        }

        private void dgvprice_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            {
                e.Handled = true;

            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void dgvbillnew_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex != 1)
            {
                String err = dgvbillnew.Rows[e.RowIndex].Cells[0].Value.ToString();
                //MessageBox.Show(err + " Not Found in Product Master !!;Pl create It.");
                dgvbillnew.Rows[e.RowIndex].Cells[0].Value = "";
            }
        }

        private void dgvbillnew_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!e.Row.IsNewRow)
            {
                DialogResult res = MessageBox.Show("Are you sure you want to delete this row?", "Delete confirmation",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    Double dbval = 0.00;
                    for (int i = 0; i < dgvbillnew.Rows.Count; i++)
                    {
                        if (dgvbillnew.Rows[i].Cells[2].Value != null)
                        {

                            dbval = dbval + (Convert.ToDouble(dgvbillnew.Rows[i].Cells[2].Value.ToString()));

                        }
                    }
                    txtdue.Text = dbval.ToString();
                    //txtbalance.Text = dbval.ToString();
                    gross = Convert.ToDouble(txtdue.Text);
                    dis = Convert.ToDouble(txtdisc.Text);
                    adv = Convert.ToDouble(txtadv.Text);
                    netgr = gross - dis;
                    bal = gross - dis - adv;
                    txtbalance.Text = bal.ToString();
                
                }
            
            
            
            }
        }

        private void dgvbillnew_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            Double dbval = 0.00;
            for (int i = 0; i < dgvbillnew.Rows.Count; i++)
            {
                if (dgvbillnew.Rows[i].Cells[2].Value != null)
                {

                    dbval = dbval + (Convert.ToDouble(dgvbillnew.Rows[i].Cells[2].Value.ToString()));

                }
            }
            txtdue.Text = dbval.ToString();
            //txtbalance.Text = dbval.ToString();
            gross = Convert.ToDouble(txtdue.Text);
            dis = Convert.ToDouble(txtdisc.Text);
            adv = Convert.ToDouble(txtadv.Text);
            netgr = gross - dis;
            bal = gross - dis - adv;
            txtbalance.Text = bal.ToString();
                
        }

       
    }
}
