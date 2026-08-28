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
    public partial class Frmprofilemaster : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds1;
        SqlCommand cmd1, cmd;
        
        public Frmprofilemaster()
        {
            InitializeComponent();
        }

        private void Frmprofilemaster_Load(object sender, EventArgs e)
        {
            Class1 objclass = new Class1();
            con = new SqlConnection(objclass.arun_con());

            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("select grp,sgrp from Group_master where type=' ' order by grp", con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Group_master");


            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)          
            {
                cboprofilename.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                //cboprofilename.Items.Add("Complete Blood Count Report");
                //cboprofilename.Items.Add("Complete Blood Count Report");
            }
            adapter.Dispose();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();

            cmd1 = new SqlCommand("delete from profile_master where type='" + cboprofilename.Text + "'", con);
            cmd1.ExecuteNonQuery();
            cmd1 = new SqlCommand("delete from profile_master_note where type='" + cboprofilename.Text + "'", con);
            cmd1.ExecuteNonQuery();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                con.Close();
                con.Open();

                if (dataGridView1.Rows[i].Cells[0].Value != null)
                {
                    //int gcd1 = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                    if (dataGridView1.Rows[i].Cells[4].Value == null || dataGridView1.Rows[i].Cells[4].Value.ToString() == "")
                    {
                        dataGridView1.Rows[i].Cells[4].Value = "0.00";
                    }
                    if (dataGridView1.Rows[i].Cells[7].Value == null || dataGridView1.Rows[i].Cells[7].Value.ToString() == "")
                    {
                        dataGridView1.Rows[i].Cells[7].Value = "0";
                    }
                    if (dataGridView1.Rows[i].Cells[8].Value == null || dataGridView1.Rows[i].Cells[8].Value.ToString() == "")
                    {
                        dataGridView1.Rows[i].Cells[8].Value = "0";
                    }
                    cmd = new SqlCommand("insert into profile_master(test,method,unit,reference_range,price,grp,sgrp,grp_code,srlno,TYPE) values ('" + dataGridView1.Rows[i].Cells[0].Value + "','" + dataGridView1.Rows[i].Cells[1].Value + "','" + dataGridView1.Rows[i].Cells[2].Value + "','" + dataGridView1.Rows[i].Cells[3].Value + "','" + Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) + "','" + dataGridView1.Rows[i].Cells[5].Value + "','" + dataGridView1.Rows[i].Cells[6].Value + "','" + dataGridView1.Rows[i].Cells[7].Value + "','" + dataGridView1.Rows[i].Cells[8].Value + "','" + cboprofilename.Text + "')", con);
                    cmd.ExecuteNonQuery();
                }

            }
            cmd = new SqlCommand("insert into profile_master_note(note,TYPE) values ('" + txtmnote1.Text  + "','" + cboprofilename.Text + "')", con);
            cmd.ExecuteNonQuery();
        
        
        }

        private void cboprofilename_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select test,method,unit,reference_range,price,grp,sgrp,grp_code,srlno from profile_master where type='" + cboprofilename.Text + "'", con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "profile_master");
            if (ds.Tables[0].Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //dataGridView1.DataSource = ds;
                    //dataGridView1.DataMember = "test_master";

                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][0].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][1].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][2].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][3].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][4].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = ds.Tables[0].Rows[i][5].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = ds.Tables[0].Rows[i][6].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = ds.Tables[0].Rows[i][7].ToString();
                    dataGridView1.Rows[i].Cells[8].Value = ds.Tables[0].Rows[i][8].ToString();


                }
            }
            adapter.Dispose();
            adapter = new SqlDataAdapter("select type,note from profile_master_note where type='" + cboprofilename.Text + "'", con);
             ds = new DataSet();
            adapter.Fill(ds, "profile_master_note");
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtmnote1.Text = ds.Tables[0].Rows[0][1].ToString();
            }
            else
            {
                txtmnote1.Text = "";
            }
        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
