using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Pathology
{
    public partial class Frmnormalreferencesetup : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds1;
        SqlCommand cmd1, cmd;
        public Frmnormalreferencesetup()
        {
            InitializeComponent();
        }

        private void Frmnormalreferencesetup_Load(object sender, EventArgs e)
        {
            Class1 objclass = new Class1();
            con = new SqlConnection(objclass.arun_con());

            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("select grp,sgrp from Group_master where type='Single' order by grp", con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Group_master");


            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cboprofilename.Items.Add(ds.Tables[0].Rows[i][0].ToString());

            }
            adapter.Dispose();
        }

        private void cboprofilename_SelectedIndexChanged(object sender, EventArgs e)
        {
            label3.Text = "";
            SqlDataAdapter adapter = new SqlDataAdapter("select rcode,test,method,unit,reference_range,grp,sgrp,gcode,range_from,range_to from reference_master where type='" + cboprofilename.Text + "' order by gcode,convert(int,rcode)", con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "reference_master");
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgvnormalreference.Rows.Clear();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //dataGridView1.DataSource = ds;
                    //dataGridView1.DataMember = "test_master";

                    dgvnormalreference.Rows.Add();
                    dgvnormalreference.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][0].ToString();
                    dgvnormalreference.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][1].ToString();
                    dgvnormalreference.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][2].ToString();
                    dgvnormalreference.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][3].ToString();
                    dgvnormalreference.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][4].ToString();
                    dgvnormalreference.Rows[i].Cells[5].Value = ds.Tables[0].Rows[i][5].ToString();
                    dgvnormalreference.Rows[i].Cells[6].Value = ds.Tables[0].Rows[i][6].ToString();
                    dgvnormalreference.Rows[i].Cells[7].Value = ds.Tables[0].Rows[i][7].ToString();
                    dgvnormalreference.Rows[i].Cells[8].Value = ds.Tables[0].Rows[i][8].ToString();
                    dgvnormalreference.Rows[i].Cells[9].Value = ds.Tables[0].Rows[i][9].ToString();
                }
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();

            cmd1 = new SqlCommand("delete from reference_master where type='" + cboprofilename.Text + "'", con);

            cmd1.ExecuteNonQuery();

            for (int i = 0; i < dgvnormalreference.Rows.Count; i++)
            {
                con.Close();
                con.Open();

                if (dgvnormalreference.Rows[i].Cells[0].Value != null)
                {
                    //int gcd1 = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                    if (dgvnormalreference.Rows[i].Cells[0].Value == null || dgvnormalreference.Rows[i].Cells[0].Value.ToString() == " ")
                    {
                        dgvnormalreference.Rows[i].Cells[0].Value = "0";
                    }
                    if (dgvnormalreference.Rows[i].Cells[7].Value == null || dgvnormalreference.Rows[i].Cells[7].Value.ToString() == " ")
                    {
                        dgvnormalreference.Rows[i].Cells[7].Value = "1";
                    }
                    if (dgvnormalreference.Rows[i].Cells[8].Value == null || dgvnormalreference.Rows[i].Cells[8].Value.ToString() == " ")
                    {
                        dgvnormalreference.Rows[i].Cells[8].Value = "0.00";
                    }
                    if (dgvnormalreference.Rows[i].Cells[9].Value == null || dgvnormalreference.Rows[i].Cells[9].Value.ToString() == " ")
                    {
                        dgvnormalreference.Rows[i].Cells[9].Value = "0.00";
                    }




                    cmd = new SqlCommand("insert into reference_master(rcode,test,method,unit,reference_range,grp,sgrp,gcode,type,range_from,range_to) values ('" + dgvnormalreference.Rows[i].Cells[0].Value + "','" + dgvnormalreference.Rows[i].Cells[1].Value + "','" + dgvnormalreference.Rows[i].Cells[2].Value + "','" + dgvnormalreference.Rows[i].Cells[3].Value + "','" + (dgvnormalreference.Rows[i].Cells[4].Value) + "','" + dgvnormalreference.Rows[i].Cells[5].Value + "','" + dgvnormalreference.Rows[i].Cells[6].Value + "','" + dgvnormalreference.Rows[i].Cells[7].Value + "','" + cboprofilename.Text + "','" + dgvnormalreference.Rows[i].Cells[8].Value + "','" + dgvnormalreference.Rows[i].Cells[9].Value + "')", con);

                    //cmd.ExecuteNonQuery();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        //tot = tot + Convert.ToDouble(dgv.Rows[i].Cells[12].Value);
                    }
                    catch
                    {
                        MessageBox.Show(e.ToString());
                    }
                    finally
                    {
                        con.Close();
                    }


                }

            }
            label3.Text = "Save Successful";

        }


   private void dgvnormalreference_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvnormalreference.CurrentRow.Cells[0].Value == null || Convert.ToString(dgvnormalreference.CurrentRow.Cells[0].Value) == "")
            {
                dgvnormalreference.CurrentRow.Cells[0].Value = "0";
            }
            if (dgvnormalreference.CurrentRow.Cells[7].Value == null || Convert.ToString(dgvnormalreference.CurrentRow.Cells[7].Value) == "")
            {
                dgvnormalreference.CurrentRow.Cells[7].Value = "1";
            }
            if (dgvnormalreference.CurrentRow.Cells[8].Value == null || Convert.ToString(dgvnormalreference.CurrentRow.Cells[8].Value) == "")
            {
                dgvnormalreference.CurrentRow.Cells[8].Value = "0.00";
            }
            if (dgvnormalreference.CurrentRow.Cells[9].Value == null || Convert.ToString(dgvnormalreference.CurrentRow.Cells[9].Value) == "")
            {
                dgvnormalreference.CurrentRow.Cells[9].Value = "0.00";
            }
   }

        private void dgvnormalreference_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

           

   

        }

        private void dgvnormalreference_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            







        }

        private void btnnrcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvnormalreference_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvnormalreference_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            e.Control.KeyPress -= new KeyPressEventHandler(tmgcode_KeyPress);
            e.Control.KeyPress -= new KeyPressEventHandler(tmgrangef_KeyPress);
            e.Control.KeyPress -= new KeyPressEventHandler(tmgranget_KeyPress);

            if (dgvnormalreference.CurrentCell.ColumnIndex == 7) //Desired Column
            {
                TextBox tbox = e.Control as TextBox;
                if (tbox != null)
                {
                    tbox.KeyPress += new KeyPressEventHandler(tmgcode_KeyPress);
                }
            }


            if (dgvnormalreference.CurrentCell.ColumnIndex == 8) //Desired Column
            {
                TextBox tbox = e.Control as TextBox;
                if (tbox != null)
                {
                    tbox.KeyPress += new KeyPressEventHandler(tmgrangef_KeyPress);
                }
            }

            if (dgvnormalreference.CurrentCell.ColumnIndex == 9) //Desired Column
            {
                TextBox tbox = e.Control as TextBox;
                if (tbox != null)
                {
                    tbox.KeyPress += new KeyPressEventHandler(tmgranget_KeyPress);
                }
            }


        }
        private void tmgcode_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tmgrangef_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tmgranget_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dgvnormalreference_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex != 1)
            {
                String err = dgvnormalreference.Rows[e.RowIndex].Cells[0].Value.ToString();
                //MessageBox.Show(err + " Not Found in Product Master !!;Pl create It.");
                dgvnormalreference.Rows[e.RowIndex].Cells[0].Value = "";
            }
        }

        private void dgvnormalreference_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {

         String drow = dgvnormalreference.CurrentRow.Cells[0].Value.ToString();

         if (!e.Row.IsNewRow)
         {


             DialogResult res = MessageBox.Show("This Row is reserved,Should not be deleted?", "", MessageBoxButtons.OK);
             if (res == DialogResult.OK)
             {
                 e.Cancel = true;
                 dgvnormalreference.Focus();
             }
             //       else
             //       {

             //           SqlDataAdapter adapter = new SqlDataAdapter("select * from billl where test='" + drow + "'", con);
             //   DataSet ds = new DataSet();
             //   adapter.Fill(ds);
             //   if (ds.Tables[0].Rows.Count > 0)
             //   {

             //       MessageBox.Show("Billing is exist in this test,Check the register!! " + drow);
             //       e.Cancel = true;
             //       dgvnormalreference.Focus();
             //   }


         }
        
        
        
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }
    
    
    
    
    
    
    }
}
