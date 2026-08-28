using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
namespace Pathology
{
    public partial class Frmbom : Form
    {
        SqlConnection con;
        SqlDataAdapter da, adapter;
        DataSet ds,ds1;
        SqlCommand cmd1, cmd;
        public Frmbom()
        {
            InitializeComponent();
        }

        private void Frmbom_Load(object sender, EventArgs e)
        {
            Class1 objclass = new Class1();
            con = new SqlConnection(objclass.arun_con());

            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("select item from product_master  order by item", con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "product_master");

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                tmtest.Items.Add(ds.Tables[0].Rows[i][0].ToString());

            }
            adapter.Dispose();
            
            
            adapter = new SqlDataAdapter("select test from reference_master ", con);
            DataSet ds1 = new DataSet();
            adapter.Fill(ds1, "reference_master");

            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                cboprofilename.Items.Add(ds1.Tables[0].Rows[i][0].ToString());

            }
            adapter.Dispose();
        
        
        
        
        }

        private void cboprofilename_SelectedIndexChanged(object sender, EventArgs e)
        {
            label3.Text = "";
            SqlDataAdapter adapter = new SqlDataAdapter("select test,item,qty,unit from reference_master_bom where test='" + cboprofilename.Text + "'", con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "reference_master_bom");
            dgvnormalreference.Rows.Clear();

            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //dataGridView1.DataSource = ds;
                    //dataGridView1.DataMember = "test_master";

                    dgvnormalreference.Rows.Add();
                    dgvnormalreference.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][1].ToString();
                    dgvnormalreference.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][2].ToString();
                    dgvnormalreference.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][3].ToString();
                    //dgvnormalreference.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][3].ToString();
                    //dgvnormalreference.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][4].ToString();
                    //dgvnormalreference.Rows[i].Cells[5].Value = ds.Tables[0].Rows[i][5].ToString();
                    //dgvnormalreference.Rows[i].Cells[6].Value = ds.Tables[0].Rows[i][6].ToString();
                    //dgvnormalreference.Rows[i].Cells[7].Value = ds.Tables[0].Rows[i][7].ToString();
                    //dgvnormalreference.Rows[i].Cells[8].Value = ds.Tables[0].Rows[i][8].ToString();
                    //dgvnormalreference.Rows[i].Cells[9].Value = ds.Tables[0].Rows[i][9].ToString();
                }
            }
            else
            {
                MessageBox.Show("Item not Asigned!!");
                cboprofilename.Focus();
            }
        
        
        
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();

            cmd1 = new SqlCommand("delete from reference_master_bom where test='" + cboprofilename.Text + "'", con);

            cmd1.ExecuteNonQuery();

            for (int i = 0; i < dgvnormalreference.Rows.Count; i++)
            {
                con.Close();
                con.Open();

                if (dgvnormalreference.Rows[i].Cells[0].Value != null)
                {
                    //int gcd1 = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                    if (dgvnormalreference.Rows[i].Cells[1].Value == null || dgvnormalreference.Rows[i].Cells[1].Value.ToString() == " ")
                    {
                        dgvnormalreference.Rows[i].Cells[1].Value = "0";
                    }
                    //if (dgvnormalreference.Rows[i].Cells[7].Value == null || dgvnormalreference.Rows[i].Cells[7].Value.ToString() == " ")
                    //{
                    //    dgvnormalreference.Rows[i].Cells[7].Value = "0";
                    //}
                    //if (dgvnormalreference.Rows[i].Cells[8].Value == null || dgvnormalreference.Rows[i].Cells[8].Value.ToString() == " ")
                    //{
                    //    dgvnormalreference.Rows[i].Cells[8].Value = "0.00";
                    //}
                    //if (dgvnormalreference.Rows[i].Cells[9].Value == null || dgvnormalreference.Rows[i].Cells[9].Value.ToString() == " ")
                    //{
                    //    dgvnormalreference.Rows[i].Cells[9].Value = "0.00";
                    //}




                    cmd = new SqlCommand("insert into reference_master_bom(test,item,qty,unit) values ('"+cboprofilename.Text+"','" + dgvnormalreference.Rows[i].Cells[0].Value + "','" + dgvnormalreference.Rows[i].Cells[1].Value + "','" + dgvnormalreference.Rows[i].Cells[2].Value + "')", con);

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
            if (dgvnormalreference.CurrentRow.Cells[1].Value == null || Convert.ToString(dgvnormalreference.CurrentRow.Cells[1].Value) == "")
            {
                dgvnormalreference.CurrentRow.Cells[1].Value = "0";
            }
            //if (dgvnormalreference.CurrentRow.Cells[7].Value == null || Convert.ToString(dgvnormalreference.CurrentRow.Cells[7].Value) == "")
            //{
            //    dgvnormalreference.CurrentRow.Cells[7].Value = "0";
            //}
            //if (dgvnormalreference.CurrentRow.Cells[8].Value == null || Convert.ToString(dgvnormalreference.CurrentRow.Cells[8].Value) == "")
            //{
            //    dgvnormalreference.CurrentRow.Cells[8].Value = "0.00";
            //}
            //if (dgvnormalreference.CurrentRow.Cells[9].Value == null || Convert.ToString(dgvnormalreference.CurrentRow.Cells[9].Value) == "")
            //{
            //    dgvnormalreference.CurrentRow.Cells[9].Value = "0.00";
            //}
        }

        private void btnnrcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvnormalreference_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            
        }
    }
}
