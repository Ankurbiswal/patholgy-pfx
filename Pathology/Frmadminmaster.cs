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
    public partial class Frmadminmaster : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        
        public Frmadminmaster()
        {
            InitializeComponent();
        }

        private void Frmadminmaster_Load(object sender, EventArgs e)
        {
            Class1 objclass = new Class1();
            con = new SqlConnection(objclass.arun_con());
            con.Open();
            da = new SqlDataAdapter("select cc,comp from company order by cc", con);
            ds = new DataSet();
            da.Fill(ds);
            txtcompanycode.Text = ds.Tables[0].Rows[0][0].ToString();
            label1.Text = ds.Tables[0].Rows[0][1].ToString();
            txtcompanycode.Enabled = false;




            da = new SqlDataAdapter("select userid,username,password ,type,Designation,Date_of_Joining,Basic,hra from usermaster order by userid", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dgv.Rows.Add(i, dgv.Rows.Count + 1);
                dgv.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][0].ToString();
                dgv.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][1].ToString();
                dgv.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][2].ToString();
                dgv.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][3].ToString();
                dgv.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][4].ToString();
                dgv.Rows[i].Cells[5].Value = ds.Tables[0].Rows[i][5].ToString();
                dgv.Rows[i].Cells[6].Value = ds.Tables[0].Rows[i][6].ToString();
                dgv.Rows[i].Cells[7].Value = ds.Tables[0].Rows[i][7].ToString();
            }

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            cmd = new SqlCommand("delete from usermaster ");
            cmd.Connection = con;
            cmd.ExecuteNonQuery();

            //Double tot = 0;
            int i;
            Double d6 = 0; 
            Double d7 = 0, d8 = 0, d9 = 0;
            string d1, d2, d3, d4, d5, d0 = "";
            //int d10 = 0, d11 = 0, d12 = 0, d13 = 0, d14 = 0, d15 = 0, d16 = 0, d17 = 0, d18 = 0, d19 = 0;

            //int d20 = 0, d21 = 0, d22 = 0, d23 = 0, d24 = 0, d25 = 0, d26 = 0, d27 = 0, d28 = 0, d29 = 0;
            //int d30 = 0, d31 = 0, d32 = 0, d33 = 0, d34 = 0, d35 = 0, d36 = 0, d37 = 0, d38 = 0, d39 = 0;
            //int d40 = 0, d41 = 0, d42 = 0, d43 = 0, d44 = 0, d45 = 0, d46 = 0, d47 = 0, d48 = 0, d49 = 0;
            //int d50 = 0, d51 = 0, d52 = 0, d53 = 0, d54 = 0, d55 = 0, d56 = 0, d57 = 0, d58 = 0, d59 = 0;
            //int d60 = 0, d61 = 0, d62 = 0, d63 = 0, d64 = 0, d65 = 0, d66 = 0, d67 = 0;



            for (i = 0; i <= dgv.Rows.Count - 1; i++)
            {
                con.Close();
                con.Open();
                //dgv.Rows[i].Cells[0].Value = dgv.Rows[i].Cells[0].Value.ToString().Replace("'", "''");
                if (dgv.Rows[i].Cells[0].Value != null)
                {

                    d0 = dgv.Rows[i].Cells[0].Value.ToString();
                    if (dgv.Rows[i].Cells[1].Value != null)
                        d1 = dgv.Rows[i].Cells[1].Value.ToString();
                    else
                        d1 = "";
                    if (dgv.Rows[i].Cells[2].Value != null)
                        d2 = dgv.Rows[i].Cells[2].Value.ToString();
                    else
                        d2 = "";
                    if (dgv.Rows[i].Cells[3].Value != null)
                        d3 = dgv.Rows[i].Cells[3].Value.ToString();
                    else
                        d3 = "";
                    if (dgv.Rows[i].Cells[4].Value != null)
                        d4 = dgv.Rows[i].Cells[4].Value.ToString();
                    else
                        d4 = "";
                    if (dgv.Rows[i].Cells[5].Value != null)
                        d5 = dgv.Rows[i].Cells[5].Value.ToString();
                    else
                        d5 = "";
                    if (dgv.Rows[i].Cells[6].Value != null)
                        d6 = Convert.ToDouble(dgv.Rows[i].Cells[6].Value);
                    else
                        d6 = 0;
                    if (dgv.Rows[i].Cells[7].Value != null)
                        d7 = Convert.ToDouble(dgv.Rows[i].Cells[7].Value);
                    else
                        d7 = 0;


                    //cmd = new SqlCommand("insert into emp_master(Emp_code,Emp_name,Month_year,dh1,ot1,dh2,ot2,dh3,ot3,dh4,ot4,dh5,ot5,dh6,ot6,dh7,ot7,dh8,ot8,dh9,ot9,dh10,ot10,dh11,ot11,dh12,ot12,dh13,ot13,dh14,ot14,dh15,ot15,dh16,ot16,dh17,ot17,dh18,ot18,dh19,ot19,dh20,ot20,dh21,ot21,dh22,ot22,dh23,ot23,dh24,ot24,dh25,ot25,dh26,ot26,dh27,ot27,dh28,ot28,dh29,ot29,dh30,ot30,dh31,ot31,Total_Daily_Hr,Total_Ot_Hr,Total_Hr) values( '" + d0 + "','" + d1 + "','" + d2 + "','" + d3 + "','" + d4 + "','" + d5 + "','" + d6 + "','" + d7 + "','" + d8 + "','" + d9 + "','" + d10 + "','" + d11 + "','" + d12 + "','" + d13 + "','" + d14 + "','" + d15 + "','" + d16 + "','" + d17 + "','" + d18 + "','" + d19 + "','" + d20 + "','" + d21 + "','" + d22 + "','" + d23 + "','" + d24 + "','" + d25 + "','" + d26 + "','" + d27 + "','" + d28 + "','" + d29 + "','" + d30 + "','" + d31 + "','" + d32 + "','" + d33 + "','" + d34 + "','" + d35 + "','" + d36 + "','" + d37 + "','" + d38 + "','" + d39 + "','" + d40 + "','" + d41 + "','" + d42 + "','" + d43 + "','" + d44 + "','" + d45 + "','" + d46 + "','" + d47 + "','" + d48 + "','" + d49 + "','" + d50 + "','" + d51 + "','" + d52 + "','" + d53 + "','" + d54 + "','" + d55 + "','" + d56 + "','" + d57 + "','" + d58 + "','" + d59 + "','" + d60 + "','" + d61 + "','" + d62 + "','" + d63 + "','" + d64 + "','" + d65 + "','" + d66 + "','" + d67 + "')");
                    cmd = new SqlCommand("insert into usermaster(userid,username,password,type,Designation,Date_of_Joining,Basic,hra) values( '" + d0 + "','" + d1 + "','" + d2 + "','" + d3 + "','" + d4 + "','" + d5 + "','" + d6 + "','" + d7 + "')");
                    cmd.Connection = con;
                    //try
                    //{
                        con.Close();
                        con.Open();
                        cmd.ExecuteNonQuery();
                    //}
                    //catch (Exception e)
                    //{
                    //    MessageBox.Show(e.ToString());
                    //}
                    //finally
                    //{
                    //    con.Close();
                    //}
                    
                    // tot = tot + Convert.ToDouble(dgv.Rows[i].Cells[8].Value);
                    //con.Close();
                }
            }
            //  txttotalamt.Text = tot.ToString();
           
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
