using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO.Ports;
using System.Text.RegularExpressions;
namespace Pathology
{
    public partial class Frmdatareceived : Form
    {
        SqlConnection con;
        DataSet ds, ds0, ds1;
        SqlDataAdapter da;
        SqlCommand cmd;
        SqlDataReader dr;
        public String cbtyp = "Inbound Delivery";
        public String adminid = "";
        string InputData = String.Empty;
        System.IO.Ports.SerialPort port = new System.IO.Ports.SerialPort();
        delegate void SetTextCallback(string text);
        public Frmdatareceived()
        {
            port.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(port_DataReceived_1);
            
            InitializeComponent();
        }

        private void Frmdatareceived_Load(object sender, EventArgs e)
        {
            Class1 objclass = new Class1();
            con = new SqlConnection(objclass.arun_con());

            con.Open();

            da = new SqlDataAdapter("select Name from owner order by name ", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cbotransporter.Items.Add(ds.Tables[0].Rows[i].ItemArray[0].ToString());
            }
            da.Dispose();
            da = new SqlDataAdapter("select currentuser from setup ", con);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                adminid = ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
            }
            da.Dispose();

            //da = new SqlDataAdapter("select ticket_no from weighment where type='Inbound Delivery' order by ticket_no", con);
            //ds = new DataSet();
            //da.Fill(ds);
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    cbotkn.Items.Add(ds.Tables[0].Rows[i].ItemArray[0].ToString());
            //}
            //da.Dispose();
            //da = new SqlDataAdapter("select type,max(convert(int,ticket_no)) from weighment where type='Inbound Delivery' group by type", con);
            //ds = new DataSet();
            //da.Fill(ds);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    cbotkn.Text = Convert.ToString(Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString()) + 1);
            //}
            //else
            //{
            //    cbotkn.Text = "1";
            //}

            if (adminid == "ADMIN")
            {
                da = new SqlDataAdapter("select ticket_no from weighment where type='Inbound Delivery'  order by Convert(int,ticket_no)", con);
                ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    cbotkn.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                }
                da.Dispose();

                btndelete.Enabled = true;
                txtswt.Enabled = true;
                txtfwt.Enabled = true;
                txtnwt.Enabled = true;
                cbotkn.Enabled = true;
            }
            else
            {
                da = new SqlDataAdapter("select vehicle_no from weighment where type='Inbound Delivery' and Firstwt=0  order by vehicle_no", con);
                ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    cbovehicleno.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                }
                da.Dispose();


                btndelete.Enabled = false;
                txtswt.Enabled = false;
                txtfwt.Enabled = false;
                txtnwt.Enabled = false;
                cbotkn.Enabled = false;
            }



            //da.Dispose();
            da = new SqlDataAdapter("select po_no from po_details order by po_no ", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cbodono.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            da.Dispose();
            //DateTime dte;
            //String dd1 = sdt1.Text.Substring(0, 2).ToString();
            //String mmm1 = sdt1.Text.Substring(3, 2).ToString();
            //String yy1 = sdt1.Text.Substring(6, 4).ToString();
            //dte = DateTime.ParseExact(dd1 + "/" + mmm1 + "/" + yy1, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);



            //da = new SqlDataAdapter("select vehicle_no,exp_dt from tarewt_details where exp_dt<='" + sdt1.Text + "' order by vehicle_no", con);

            da = new SqlDataAdapter("select item from product_master order by item ", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cboproduct.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            da.Dispose();
            da = new SqlDataAdapter("select acdes from account_master where grpname='Supplier' order by acdes", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                this.cbocompanyname.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }


            //da = new SqlDataAdapter("select vehicle_no from weighment order by vehicle_no ", con);
            //ds = new DataSet();
            //da.Fill(ds);
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    cbovehicleno.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            //}
            cbovehicletype.Items.Add("Container");
            cbovehicletype.Items.Add("Hyva");
            cbovehicletype.Items.Add("Jcb");
            cbovehicletype.Items.Add("Tipper");
            cbovehicletype.Items.Add("Tractor");
            cbovehicletype.Items.Add("Truck");
            cbovehicletype.Items.Add("Trolley");
            //btndelete.Enabled = false;
            btnupdate.Enabled = false;
            btnprint.Enabled = true;
            txtdoqty.Text = "0.000";
            txtchallanqty.Text = "0.000";
            txtdopending.Text = "0.000";
            txtfwt.Text = "0.000";
            txtswt.Text = "0.000";
            txtnwt.Text = "0.000";
            txtchldiff.Text = "0.000";
            //txtfwt.Enabled =false;
            //txtswt.Enabled = false;


            port.PortName = "COM1";

            //port.BaudRate = 2400;
            //port.DataBits = 8;
            //port.Parity = Parity.None;
            //port.StopBits = StopBits.One;
            //port.DtrEnable = true;
            //port.Handshake = Handshake.None;
            //port.DtrEnable = true;
            da.Dispose();

            String s1 = ("select baudrate1,databits1,parity1,stopbits1,dtrenables11,handshake1,dtrenables12 from wbs1");
            da = new SqlDataAdapter(s1, con);
            ds = new DataSet();
            da.Fill(ds, "wbs1");

            //bool par1 = Convert.ToBoolean("Parity."+ds.Tables[0].Rows[0][2].ToString().Trim());
            ////String par=Parity&par1;
            //bool stp1 ="StopBits." + ds.Tables[0].Rows[0][3].ToString().Trim();
            // String stp = StopBits & stp1;

            port.BaudRate = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString().Trim());

            port.DataBits = Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString().Trim());
            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.DtrEnable = Convert.ToBoolean(ds.Tables[0].Rows[0][4].ToString().Trim());
            port.Handshake = Handshake.None;
            port.DtrEnable = Convert.ToBoolean(ds.Tables[0].Rows[0][6].ToString().Trim());
            if (port.IsOpen)
            {
                port.Close();
            }
            else
            {
                port.Open();
            }

            checkBox2.Checked = true;


        }
        private void port_DataReceived_1(object sender, SerialDataReceivedEventArgs e)
        {

            InputData = port.ReadExisting();
            // this.Invoke(new EventHandler(SetText));

            //InputData = port.ReadExisting();
            //byte[] receiveBuffer = new byte[128];
            //int bufferIndex = 0;
            //int bytesRead = 0;
            //int startPacketIndex = 0;
            //int expectedPacketLength = -1;
            //bool expectedPacketLengthIsSet = false;
            //int numBytesToRead = receiveBuffer.Length;
            //bytesRead += port.Read(receiveBuffer, bufferIndex, numBytesToRead);
            if (InputData != String.Empty)
            {
                // txtIn.Text = InputData;
                // because of different threads this
                // does not work properly !!
                SetText(InputData);
            }
        }
        int l = 0;
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.

            if (this.textBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {

                // textBox1.AppendText(InputData);

                // this.textBox1.Text += (text);
                string txt = (text);
                var numericPart = Regex.Match(txt, "\\d+").Value;
                //comboBox1.Items.Add(numericPart);
                //listBox1.Items.Add(numericPart);
                if (numericPart != "")
                {
                    btn_wt_value.Text = numericPart;
                    //btn_wt_value.Focus();
                }
                // this.textBox1.Text += numericPart + "\n";
                // string number = Regex.Match("txt<br>", @"\d+").Value;

                // l++;
                // if (l > 50)
                // {


                //     listBox1.Items.Clear(); l = 0;


                //  }

            }



        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtswt.Text) == 0.000)
            {
                MessageBox.Show("Gross Wt can't be 0");
                cbovehicleno.Focus();
            }
            else
            {

                checkBox2.Checked = true;
                int j = 1;
                txtcompanyid.Text = j.ToString();


                DateTime dtb, dtc;


                String dd1 = expdt.Text.Substring(0, 2).ToString();
                String mmm1 = expdt.Text.Substring(3, 2).ToString();
                String yy1 = expdt.Text.Substring(6, 4).ToString();
                dtc = DateTime.ParseExact(dd1 + "/" + mmm1 + "/" + yy1, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);





                da = new SqlDataAdapter("select type,max(convert(int,ticket_no)) from weighment where type='Inbound Delivery' group by type", con);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cbotkn.Text = Convert.ToString(Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString()) + 1);
                }
                else
                {
                    cbotkn.Text = "1";
                }



                if (MessageBox.Show("Save ? ", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {


                    double nwtt = 0;
                    if (txtpveh.Text.ToUpper() == "Y")
                    {
                        nwtt = Convert.ToDouble(txtswt.Text) - Convert.ToDouble(txtfwt.Text);
                        cmd = new SqlCommand("insert into Weighment (Cc,ticket_no,vehicle_no,transporter,vehicle_type,productid,name,do_no,do_qty,exp_dt,ChallanWt,Firstwt,Secondwt,netwt,Address,type,grosswtdate,tarewtdate,accp_wt,chl_dt,chl_no,tpno,product) values('" + this.txtcompanyid.Text + "','" + cbotkn.Text + "','" + this.cbovehicleno.Text.ToUpper() + "','" + this.cbotransporter.Text + "','" + this.cbovehicletype.Text + "','" + cboproduct.Text + "','" + this.cbocompanyname.Text + "','" + this.cbodono.Text + "','" + Convert.ToDouble(txtdoqty.Text) + "','" + dtc + "','" + Convert.ToDouble(txtchallanqty.Text) + "','" + Convert.ToDouble(txtfwt.Text) + "','" + Convert.ToDouble(txtswt.Text) + "','" + nwtt + "','" + this.txtaddress.Text + "','Inbound Delivery','" + sdt1.Value + "','','" + Convert.ToDouble(txtnwt.Text) + "','" + sdt1.Value + "','" + txtchlno.Text + "','" + txttpno.Text + "','" + label16.Text + "')", con);
                    }
                    else
                    {
                        cmd = new SqlCommand("insert into Weighment (Cc,ticket_no,vehicle_no,transporter,vehicle_type,productid,name,do_no,do_qty,exp_dt,ChallanWt,Firstwt,Secondwt,netwt,Address,type,grosswtdate,tarewtdate,accp_wt,chl_dt,chl_no,tpno,product) values('" + this.txtcompanyid.Text + "','" + cbotkn.Text + "','" + this.cbovehicleno.Text.ToUpper() + "','" + this.cbotransporter.Text + "','" + this.cbovehicletype.Text + "','" + cboproduct.Text + "','" + this.cbocompanyname.Text + "','" + this.cbodono.Text + "','" + Convert.ToDouble(txtdoqty.Text) + "','" + dtc + "','" + Convert.ToDouble(txtchallanqty.Text) + "','0.000','" + Convert.ToDouble(txtswt.Text) + "','" + Convert.ToDouble(txtnwt.Text) + "','" + this.txtaddress.Text + "','Inbound Delivery','" + sdt1.Value + "','','" + Convert.ToDouble(txtnwt.Text) + "','" + sdt1.Value + "','" + txtchlno.Text + "','" + txttpno.Text + "','" + label16.Text + "')", con);
                    }
                    cmd.ExecuteNonQuery();
                    //cbotkn.Text = Convert.ToString(Convert.ToInt32(cbotkn.Text) + 1);
                    btnprint.Enabled = true;
                    da.Dispose();
                    da = new SqlDataAdapter("select vehicle_no from weighment where type='Inbound Delivery' and Firstwt=0 order by vehicle_no", con);
                    ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        cbovehicleno.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                    }
                    da.Dispose();
                    cmd = new SqlCommand("update setup set blno ='" + this.cbotkn.Text + "' , type='Inbound Delivery'", con);
                    cmd.ExecuteNonQuery();
                    txtswt.Text = "0.000";
                    txtfwt.Text = "0.000";
                    txtnwt.Text = "0.000";
                    txtchallanqty.Text = "0.000";
                    txtchldiff.Text = "0.000";
                }
                if (port.IsOpen)
                {

                }
                else
                {
                    port.Open();
                }



                cbovehicleno.Focus();


            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            DateTime dtb, dtc;
            //String dd = dodt.Text.Substring(0, 2).ToString();
            //String mmm = this.dodt.Text.Substring(3, 2).ToString();
            //String yy = this.dodt.Text.Substring(6, 4).ToString();
            //dtb = DateTime.ParseExact(dd + "/" + mmm + "/" + yy, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            String dd1 = expdt.Text.Substring(0, 2).ToString();
            String mmm1 = expdt.Text.Substring(3, 2).ToString();
            String yy1 = expdt.Text.Substring(6, 4).ToString();
            dtc = DateTime.ParseExact(dd1 + "/" + mmm1 + "/" + yy1, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);


            //DateTime dte;
            // dd1 = sdt1.Text.Substring(0, 2).ToString();
            // mmm1 = sdt1.Text.Substring(3, 2).ToString();
            //yy1 = sdt1.Text.Substring(6, 4).ToString();
            //dte = DateTime.ParseExact(dd1 + "/" + mmm1 + "/" + yy1, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            //if (MessageBox.Show("Do You Want Save ? ", "Save", MessageBoxButtons.OKCancel) == DialogResult.OK)
            //{

            //cmd = new SqlCommand("update do_details set Name = '" + cbocompanyname.Text + "',Address = '" + txtaddress.Text + "',do_no='" + this.cbodono.Text + "',do_qty='" + Convert.ToDouble(txtchallanqty.Text) + "',exp_dt='" + dtc + "' where do_no='" + cbodono.SelectedItem + "'");
            //                                                                                                                                ,vehicle_type,product,                                                                      name,do_no,   do_dt,do_qty,exp_dt                               ,Address,ChallanWt,Firstwt,Secondwt,netwt
            if (adminid == "ADMIN")
            {
                cmd = new SqlCommand("update Weighment set Cc='" + this.txtcompanyid.Text + "',vehicle_no='" + this.cbovehicleno.Text + "',transporter='" + this.cbotransporter.Text + "',vehicle_type='" + this.cbovehicletype.Text + "',product='" + label16.Text + "',productid='" + cboproduct.Text + "',name='" + this.cbocompanyname.Text + "',do_no='" + this.cbodono.Text + "',do_qty='" + Convert.ToDouble(txtdopending.Text) + "',exp_dt='" + dtc + "',ChallanWt='" + Convert.ToDouble(txtchallanqty.Text) + "',Firstwt='" + Convert.ToDouble(txtfwt.Text) + "',Secondwt='" + Convert.ToDouble(txtswt.Text) + "',netwt='" + Convert.ToDouble(txtnwt.Text) + "',accp_wt='" + Convert.ToDouble(txtnwt.Text) + "',Address='" + this.txtaddress.Text + "',tarewtdate='" + sdt1.Value + "',chl_dt='" + sdt1.Value + "',chl_no='" + txtchlno.Text + "',tpno='" + txttpno.Text + "' where ticket_no='" + this.cbotkn.Text + "' and type='Inbound Delivery'");
            }
            else
            {
                cmd = new SqlCommand("update Weighment set Cc='" + this.txtcompanyid.Text + "',vehicle_no='" + this.cbovehicleno.Text + "',transporter='" + this.cbotransporter.Text + "',vehicle_type='" + this.cbovehicletype.Text + "',product='" + label16.Text + "',productid='" + cboproduct.Text + "',name='" + this.cbocompanyname.Text + "',do_no='" + this.cbodono.Text + "',do_qty='" + Convert.ToDouble(txtdopending.Text) + "',exp_dt='" + dtc + "',ChallanWt='" + Convert.ToDouble(txtchallanqty.Text) + "',Firstwt='" + Convert.ToDouble(txtfwt.Text) + "',netwt='" + Convert.ToDouble(txtnwt.Text) + "',accp_wt='" + Convert.ToDouble(txtnwt.Text) + "',Address='" + this.txtaddress.Text + "',tarewtdate='" + sdt1.Value + "',chl_dt='" + sdt1.Value + "',chl_no='" + txtchlno.Text + "',tpno='" + txttpno.Text + "' where ticket_no='" + this.cbotkn.Text + "' and type='Inbound Delivery'");
            }
            cmd.Connection = con;

            //Cc,Comp,Address,TELPHONENO,FAXNO,Vatno,cstno,year_start,year_end
            cmd.ExecuteNonQuery();
            //     cmd.CommandText = "update company set comp = '" + cbocompanyname.Text + "',address = '" + txtaddress.text + "',Vatno = '" + txtvatno.text + "',cstno = '" + txtcstno.text + "',year_start = '" + comboBox1.SelectedItem + "',divient = '" + txtdvnt.Text + "',amountinvested =  '" + txtamount.Text + "',Date1 = '" + dateTimePicker1.Text + "',companyissued = '" + txtcomp.Text + "',pvccode = '" + txtpvccode.Text + "',password1 = '" + txtpwd.Text + "',PanNo = '" + txtpno.Text + "' where userid='" + comboBox2.SelectedItem + "'";

            Double dop = (Convert.ToDouble(txtdopending.Text) - Convert.ToDouble(txtnwt.Text));
            txtdopending.Text = dop.ToString();

            cmd = new SqlCommand("update po_details set po_qty_pending ='" + dop + "' where po_no='" + cbodono.Text + "'", con);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("update setup set blno ='" + this.cbotkn.Text + "' , type='Inbound Delivery'", con);
            cmd.ExecuteNonQuery();

            if (MessageBox.Show("Do You Want Print ? ", "Print", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

               // Frmrepin_outslip frios = new Frmrepin_outslip();

               // frios.Show();

                if (port.IsOpen)
                {
                    //   port.WriteLine(textBox2.Text);
                    //textBox3.Text = textBox1.Text;
                }
                else
                {

                    port.Open();
                    //MessageBox.Show("Serial port is closed!",
                    //                 "RS232 tester",
                    //                 MessageBoxButtons.OK,
                    //                 MessageBoxIcon.Error);
                    //textBox2.Text = textBox1.Text;
                    //textBox2.Text = textBox1.Text;
                    //textBox2.Clear();
                    //port.Close();
                }


            }
            else
            {
                cbovehicleno.Focus();

                if (port.IsOpen)
                {

                }
                else
                {
                    port.Open();
                }



            }

            txtswt.Text = "0.000";
            txtfwt.Text = "0.000";
            txtnwt.Text = "0.000";
            txtchallanqty.Text = "0.000";
            txtchldiff.Text = "0.000";

           
        }

        private void btn_wt_value_Click(object sender, EventArgs e)
        {
            //txtswt.Text = btn_wt_value.Text;
            if (btn_wt_value.Text != "CAPTURE")
            {
                if (checkBox2.Checked == true)
                {
                    txtswt.Text = Convert.ToString(Convert.ToDouble(btn_wt_value.Text) / 1000);

                }
                else
                {
                    txtfwt.Text = Convert.ToString(Convert.ToDouble(btn_wt_value.Text) / 1000);

                    txtnwt.Text = Convert.ToString(Convert.ToDouble(txtswt.Text) - Convert.ToDouble(txtfwt.Text));
                    Double nw = Convert.ToDouble(txtnwt.Text);
                    txtnwt.Text = Math.Round(nw, 3).ToString();

                    if (Convert.ToDouble(txtchallanqty.Text) == 0)
                    {
                        txtchldiff.Text = "0.00";
                    }
                    else
                    {
                        txtchldiff.Text = Convert.ToString(Convert.ToDouble(txtchallanqty.Text) - Convert.ToDouble(txtnwt.Text));
                    }


                }

            }
            else
            {

            }


        
        }

        private void cbovehicleno_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbotkn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (adminid == "ADMIN")
            {

                if (this.cbotkn.Text != "")
                {
                    con.Close();
                    con.Open();
                    checkBox1.Checked = true;
                    checkBox2.Checked = false;
                    SqlDataAdapter da = new SqlDataAdapter("select  Cc,vehicle_no,transporter,vehicle_type,product,name,do_no,do_qty,exp_dt,ChallanWt,Firstwt,Secondwt,netwt,address,ticket_no,grosswtdate,chl_no,tpno from Weighment where Ticket_no= '" + cbotkn.Text + "' and type='Inbound Delivery'", con);
                    ds1 = new DataSet();
                    da.Fill(ds1, "weighment");

                    //cmd.ExecuteNonQuery();

                    this.btnadd.Enabled = false;
                    this.btndelete.Enabled = true;
                    this.btnupdate.Enabled = true;
                    this.btncancel.Enabled = true;
                    this.btnprint.Enabled = true;
                    this.txtcompanyid.Enabled = false;
                    //dr.Close();

                    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    {

                        this.txtcompanyid.Text = ds1.Tables[0].Rows[i][0].ToString();
                        cbovehicleno.Text = ds1.Tables[0].Rows[i][1].ToString();
                        cbotransporter.Text = ds1.Tables[0].Rows[i][2].ToString();
                        cbovehicletype.Text = ds1.Tables[0].Rows[i][3].ToString();
                        cboproduct.Text = ds1.Tables[0].Rows[i][4].ToString();
                        cbocompanyname.Text = ds1.Tables[0].Rows[i][5].ToString();
                        this.cbodono.Text = ds1.Tables[0].Rows[i][6].ToString();


                        txtdoqty.Text = ds1.Tables[0].Rows[i][7].ToString();
                        this.expdt.Text = ds1.Tables[0].Rows[i][8].ToString();
                        this.txtchallanqty.Text = ds1.Tables[0].Rows[i][9].ToString();
                        txtfwt.Text = ds1.Tables[0].Rows[i][10].ToString();
                        txtswt.Text = ds1.Tables[0].Rows[i][11].ToString();
                        txtnwt.Text = ds1.Tables[0].Rows[i][12].ToString();

                        this.txtaddress.Text = ds1.Tables[0].Rows[i][13].ToString();
                        this.cbotkn.Text = ds1.Tables[0].Rows[i][14].ToString();
                        this.gwdt.Text = ds1.Tables[0].Rows[i][15].ToString();
                        this.txtchlno.Text = ds1.Tables[0].Rows[i][16].ToString();
                        this.txttpno.Text = ds1.Tables[0].Rows[i][17].ToString();

                        txtchldiff.Text = Convert.ToString(Convert.ToDouble(txtchallanqty.Text) - Convert.ToDouble(txtnwt.Text));

                        //this.txtdono.Text = dr.GetValue(3).ToString();
                        //this.txtdoqty.Text = dr.GetValue(4).ToString();
                        //this.txtpathologist.Text = dr.GetValue(5).ToString();
                        //this.txtbiochemist.Text = dr.GetValue(6).ToString();
                        //this.txtdlno.Text = dr.GetValue(7).ToString();
                        //this.dtyearstart.Text = dr.GetValue(7).ToString();
                        //this.dtyearend.Text = dr.GetValue(8).ToString();
                    }
                    da.Dispose();
                    cmd = new SqlCommand("update setup set blno ='" + this.cbotkn.Text + "' , type='Inbound Delivery'", con);
                    cmd.ExecuteNonQuery();

                    //dr.Close();


                }
                else
                {
                    //btnNew.Enabled = true;
                    //button2.Enabled = true;
                    //button3.Enabled = true;
                    //button5.Enabled = true;
                }
                // txtfwt.Focus();

            }
        }
    }
}
