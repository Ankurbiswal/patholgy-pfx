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
    public partial class Frmcolonycount : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds1;
        SqlCommand cmd1, cmd;
        SqlDataReader dr;
        public static String cnm = "";
        public Frmcolonycount()
        {
            InitializeComponent();
        }

        private void Frmcolonycount_Load(object sender, EventArgs e)
        {
            Class1 objclass = new Class1();
            con = new SqlConnection(objclass.arun_con());
            label2.Text = "";

            con.Open();

            this.dataGridView1.DataError +=
           new DataGridViewDataErrorEventHandler(dataGridView1_DataError);


            cmd = new SqlCommand("select cc,comp,year_start,year_end from setup");
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //this.txtcompid.Text = dr.GetValue(0).ToString();
                cnm = dr.GetValue(1).ToString();
                //dtfrom.Text = dr.GetValue(2).ToString();
            }
            dr.Close();

            //crystalReportViewer1.Hide();



            //con.Open();
            //SqlCommand command = new SqlCommand("itmgrp", con);
            //SqlDataAdapter adapter = new SqlDataAdapter("select test,method,unit,reference_range,price,grp,sgrp,range_from,range_to from CULTURE_type", con);
            SqlDataAdapter adapter = new SqlDataAdapter("select test,method from CULTURE_colonycount", con);

            DataSet ds = new DataSet();
            adapter.Fill(ds, "CULTURE_colonycount");
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
                    //dataGridView1.Rows[i].Cells[7].Value = ds.Tables[0].Rows[i][7].ToString();
                    //dataGridView1.Rows[i].Cells[8].Value = ds.Tables[0].Rows[i][8].ToString();

                }
            }
        }

        private void BTNCULSAVE_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();

            cmd1 = new SqlCommand("delete from CULTURE_colonycount ", con);

            cmd1.ExecuteNonQuery();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                con.Close();
                con.Open();

                if (dataGridView1.Rows[i].Cells[0].Value != null)
                {
                    //if (dataGridView1.Rows[i].Cells[4].Value == null || dataGridView1.Rows[i].Cells[4].Value.ToString() == " ")
                    //{
                    //    dataGridView1.Rows[i].Cells[4].Value = "0.00";
                    //}
                    //if (dataGridView1.Rows[i].Cells[7].Value == null || dataGridView1.Rows[i].Cells[7].Value.ToString() == " ")
                    //{
                    //    dataGridView1.Rows[i].Cells[7].Value = "0.00";
                    //}
                    //if (dataGridView1.Rows[i].Cells[8].Value == null || dataGridView1.Rows[i].Cells[8].Value.ToString() == " ")
                    //{
                    //    dataGridView1.Rows[i].Cells[8].Value = "0.00";
                    //}


                    //cmd = new SqlCommand("insert into CULTURE_master(test,method,unit,reference_range,price,grp,sgrp,range_from,range_to) values ('" + dataGridView1.Rows[i].Cells[0].Value + "','" + dataGridView1.Rows[i].Cells[1].Value + "','" + dataGridView1.Rows[i].Cells[2].Value + "','" + dataGridView1.Rows[i].Cells[3].Value + "','" + Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) + "','" + dataGridView1.Rows[i].Cells[5].Value + "','" + dataGridView1.Rows[i].Cells[6].Value + "','" + dataGridView1.Rows[i].Cells[7].Value + "','" + dataGridView1.Rows[i].Cells[8].Value + "')", con);
                    cmd = new SqlCommand("insert into CULTURE_colonycount(test,method) values ('" + dataGridView1.Rows[i].Cells[0].Value + "','" + dataGridView1.Rows[i].Cells[1].Value + "')", con);

                    cmd.ExecuteNonQuery();

                }

            }
            label2.Text = "Save Successful";
        
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;

            // Display an error message.
            string txt = "Error with " +
                dataGridView1.Columns[e.ColumnIndex].HeaderText +
                "\n\n" + e.Exception.Message;
            MessageBox.Show(txt, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

            // If this is true, then the user is trapped in this cell.
            e.Cancel = false;
        }
    }
}
