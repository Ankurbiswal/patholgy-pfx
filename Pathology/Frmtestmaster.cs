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
    public partial class Frmtestmaster : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds1;
        SqlCommand cmd1, cmd;
        SqlDataReader dr;
        public static String cnm = "";
        public Frmtestmaster()
        {
            InitializeComponent();
        }

        private void Frmtestmaster_Load(object sender, EventArgs e)
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

            crystalReportViewer1.Hide();
            
            
            
            //con.Open();
            //SqlCommand command = new SqlCommand("itmgrp", con);
            SqlDataAdapter adapter = new SqlDataAdapter("select test,method,unit,reference_range,price,grp,sgrp,range_from,range_to from test_master", con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "test_master");
            if (ds.Tables[0].Rows.Count > 0)
            {
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
           }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();

            cmd1 = new SqlCommand("delete from test_master ", con);

            cmd1.ExecuteNonQuery();

            for (int i = 0; i < dataGridView1.Rows.Count ; i++)
            {
                con.Close();
                con.Open();

                if (dataGridView1.Rows[i].Cells[0].Value != null)
                {
                    if (dataGridView1.Rows[i].Cells[4].Value == null || dataGridView1.Rows[i].Cells[4].Value.ToString() == " ")
                    {
                        dataGridView1.Rows[i].Cells[4].Value = "0.00";
                    }
                    if (dataGridView1.Rows[i].Cells[7].Value == null || dataGridView1.Rows[i].Cells[7].Value.ToString() == " ")
                    {
                        dataGridView1.Rows[i].Cells[7].Value = "0.00";
                    }
                    if (dataGridView1.Rows[i].Cells[8].Value == null || dataGridView1.Rows[i].Cells[8].Value.ToString() == " ")
                    {
                        dataGridView1.Rows[i].Cells[8].Value = "0.00";
                    }
                    

                    cmd = new SqlCommand("insert into test_master(test,method,unit,reference_range,price,grp,sgrp,range_from,range_to) values ('" + dataGridView1.Rows[i].Cells[0].Value + "','" + dataGridView1.Rows[i].Cells[1].Value + "','" + dataGridView1.Rows[i].Cells[2].Value + "','" + dataGridView1.Rows[i].Cells[3].Value + "','" + Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) + "','" + dataGridView1.Rows[i].Cells[5].Value + "','" + dataGridView1.Rows[i].Cells[6].Value + "','" + dataGridView1.Rows[i].Cells[7].Value + "','" + dataGridView1.Rows[i].Cells[8].Value + "')", con);

                    cmd.ExecuteNonQuery();

                }

            }
            label2.Text = "Save Successful";
        
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNPRINT_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.Show ();
            
            SqlDataAdapter adapter = new SqlDataAdapter("select test,method,price,grp,sgrp from test_master where price!=0", con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "DS_TEST_PRICE");
            if (ds.Tables[0].Rows.Count > 0)
            {
                reppricelist cashbankrep = new reppricelist();
               // cashbankrep.SetDatabaseLogon("sa", "software", @".\sqlexpress", "pathology2627");
                cashbankrep.SetDataSource(ds);
                crystalReportViewer1.ReportSource = cashbankrep;
                //cashbankrep.SetParameterValue(0, dtf1);
                //cashbankrep.SetParameterValue(1, dtt1);
                cashbankrep.SetParameterValue(0, cnm);
                crystalReportViewer1.Refresh();
 
            }
        }
        #region "sql error handling"
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //if (e.ColumnIndex != 1)
            //{
            //    //Alert the user for any other DataError's outside of the column I care about
            //    MessageBox.Show("The following exception was encountered: " + e.Exception);
            //    //MessageBox.Show(dgv.Rows[e.RowIndex].Cells[0].Value.ToString() + " : Not Found in Item/Batch Master,PL Add in Master");
            //    dataGridView1.RefreshEdit();
            //}
            //if (e.Exception != null &&
            //   e.Context == DataGridViewDataErrorContexts.Commit)
            //{
            //    MessageBox.Show("Pl check the data for null,apostoppe etc.");
            //}

            // Don't throw an exception when we're done.
            //e.ThrowException = false;

            //// Display an error message.
            //string txt = "Error with " +
            //    dataGridView1.Columns[e.ColumnIndex].HeaderText +
            //    "\n\n" + e.Exception.Message;
            MessageBox.Show("Error " + e.Context.ToString());
            //    MessageBoxButtons.OK, MessageBoxIcon.Error);

            //// If this is true, then the user is trapped in this cell.
            //e.Cancel = false;
            if (e.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("commit Error ");
            }
            if (e.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            {
                MessageBox.Show("cell change ");
            }
            if (e.Context == DataGridViewDataErrorContexts.Parsing )
            {
                MessageBox.Show("parsing Error ");
            }
            if (e.Context == DataGridViewDataErrorContexts.LeaveControl )
            {
                MessageBox.Show("Leave control Error ");
            }
            if ((e.Exception  ) is ConstraintException )
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[e.RowIndex].ErrorText = "an error";
                view.Rows[e.RowIndex].Cells [e.ColumnIndex ].ErrorText = "an error";
                e.ThrowException =false ;



                //MessageBox.Show("commit Error ");
            }
            
            
            
            
            
            
            
            
            
            
            
            
            
            //if (e.ColumnIndex != 1)
            //{
            //    String err = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            //    //MessageBox.Show(err + " Not Found in Product Master !!;Pl create It.");
            //    dataGridView1.Rows[e.RowIndex].Cells[0].Value = "";
            //}

        }
        #endregion

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //if (e.Control is DataGridViewComboBoxEditingControl)
            //{
            //    DataGridViewComboBoxEditingControl tb = e.Control as DataGridViewComboBoxEditingControl;
            //    ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
            //    ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
            //    ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;

            //    DataGridViewRow row = dgv.CurrentRow;
            //    DataGridViewCell cell = dgv.CurrentCell;
            //    if (e.Control.GetType() == typeof(DataGridViewComboBoxEditingControl))
            //    {
            //        if (cell == row.Cells["tmtest"])
            //        {
            //            DataGridViewComboBoxEditingControl cbo = e.Control as DataGridViewComboBoxEditingControl;
            //            cbo.DropDownStyle = ComboBoxStyle.DropDown;
            //            cbo.Validating += new CancelEventHandler(cbo_Validating);
            //            dgv.CurrentCellDirtyStateChanged += new EventHandler(dgv_CurrentCellDirtyStateChanged);

            //            // SendKeys.Send("{down}");

            //        }
            //    }
            //    tb.PreviewKeyDown -= dgv_PreviewKeyDown;
            //    tb.PreviewKeyDown += dgv_PreviewKeyDown;
            //}



            e.Control.KeyPress -= new KeyPressEventHandler(tmrate_KeyPress);
            e.Control.KeyPress -= new KeyPressEventHandler(grrangefrom_KeyPress);
            e.Control.KeyPress -= new KeyPressEventHandler(grrangeto_KeyPress);

            if (dataGridView1.CurrentCell.ColumnIndex == 4) //Desired Column
            {
                TextBox tbox = e.Control as TextBox;
                if (tbox != null)
                {
                    tbox.KeyPress += new KeyPressEventHandler(tmrate_KeyPress);
                }
            }


            if (dataGridView1.CurrentCell.ColumnIndex == 7) //Desired Column
            {
                TextBox tbox = e.Control as TextBox;
                if (tbox != null)
                {
                    tbox.KeyPress += new KeyPressEventHandler(grrangefrom_KeyPress);
                }
            }

            if (dataGridView1.CurrentCell.ColumnIndex == 8) //Desired Column
            {
                TextBox tbox = e.Control as TextBox;
                if (tbox != null)
                {
                    tbox.KeyPress += new KeyPressEventHandler(grrangeto_KeyPress);
                }
            }
        }

        private void tmrate_KeyPress(object sender, KeyPressEventArgs e)
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

        private void grrangefrom_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            {
                e.Handled = true;

            }

            //if (!char.IsControl(e.KeyChar)&& !char.IsDigit(e.KeyChar)
            //     && e.KeyChar != '.')
            //{
            //    e.Handled = true;
            //}

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void grrangeto_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            {
                e.Handled = true;

            }

            //if (!char.IsControl(e.KeyChar)&& !char.IsDigit(e.KeyChar)
            //     && e.KeyChar != '.')
            //{
            //    e.Handled = true;
            //}

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            String drow = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            
            if (!e.Row.IsNewRow)
            {
               
                
                DialogResult res = MessageBox.Show("Delete this row?", "Confirm delete", MessageBoxButtons.YesNo);
                if (res == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {

                    SqlDataAdapter adapter = new SqlDataAdapter("select * from billl where test='" + drow + "'", con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {

                MessageBox.Show("Billing is exist in this test,Check the register!! " + drow);
                e.Cancel = true;
                dataGridView1.Focus();
            }

                    //    Double tot = 0;
                //    int i;
                //    for (i = 0; i <= dgv.Rows.Count - 1; i++)
                //    {
                //        if (dgv.Rows[i].Cells[0].Value != null)
                //        {
                //            con.Close();
                //            con.Open();

                //            tot = tot + Convert.ToDouble(dgv.Rows[i].Cells[12].Value);

                //        }

                //    }


                //    txttotalamt.Text = tot.ToString();

                //    txtgrtot.Text = Convert.ToString(Math.Round(Convert.ToDouble(txttotalamt.Text) + Convert.ToDouble(txtaddcharge.Text) - (Convert.ToDouble(txtadvance.Text))));


                }


            }
       




        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[4].Value == null || Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value) == "")
            {
                dataGridView1.CurrentRow.Cells[4].Value = "0";
            }
            if (dataGridView1.CurrentRow.Cells[7].Value == null || Convert.ToString(dataGridView1.CurrentRow.Cells[7].Value) == "")
            {
                dataGridView1.CurrentRow.Cells[7].Value = "0";
            }
            if (dataGridView1.CurrentRow.Cells[8].Value == null || Convert.ToString(dataGridView1.CurrentRow.Cells[8].Value) == "")
            {
                dataGridView1.CurrentRow.Cells[8].Value = "0.00";
            }
            //if (dataGridView1.CurrentRow.Cells[9].Value == null || Convert.ToString(dataGridView1.CurrentRow.Cells[9].Value) == "")
            //{
            //    dataGridView1.CurrentRow.Cells[9].Value = "0.00";
            //}
        }

      

       
    }
}
