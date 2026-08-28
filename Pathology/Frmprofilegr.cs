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
    public partial class Frmprofilegr : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds1;
        SqlCommand cmd1, cmd;
        public Frmprofilegr()
        {
            InitializeComponent();
        }

        private void Frmprofilegr_Load(object sender, EventArgs e)
        {
            Class1 objclass = new Class1();
            con = new SqlConnection(objclass.arun_con());

            con.Open();
            //SqlCommand command = new SqlCommand("itmgrp", con);
            SqlDataAdapter adapter = new SqlDataAdapter("select grp,sgrp from Group_master where type='  '", con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Group_master");
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //dataGridView1.DataSource = ds;
                    //dataGridView1.DataMember = "test_master";

                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][0].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][1].ToString();
                    //dataGridView1.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][2].ToString();
                    //dataGridView1.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][3].ToString();
                    //dataGridView1.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][4].ToString();
                    //dataGridView1.Rows[i].Cells[5].Value = ds.Tables[0].Rows[i][5].ToString();
                    //dataGridView1.Rows[i].Cells[6].Value = ds.Tables[0].Rows[i][6].ToString();

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();

            cmd1 = new SqlCommand("delete from Group_master where type='  ' ", con);

            cmd1.ExecuteNonQuery();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                con.Close();
                con.Open();

                if (dataGridView1.Rows[i].Cells[0].Value != null)
                {
                    //int gcd1 = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);

                    cmd = new SqlCommand("insert into Group_master(grp,sgrp,type) values ('" + dataGridView1.Rows[i].Cells[0].Value + "','" + dataGridView1.Rows[i].Cells[1].Value + "','')", con);

                    cmd.ExecuteNonQuery();

                }

            }        
        }
    }
}
