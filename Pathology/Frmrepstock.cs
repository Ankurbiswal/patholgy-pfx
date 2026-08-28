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
    public partial class Frmrepstock : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds, ds0, ds2;

        DataRow dr;
        DataTable dt;
        SqlDataReader dr1;
        DateTime dtf, dtt;
        public string adr1 = "";
        public string tel1 = "";
        public Frmrepstock()
        {
            InitializeComponent();
        }

        private void Frmrepstock_Load(object sender, EventArgs e)
        {
            Class1 objclass = new Class1();
            con = new SqlConnection(objclass.arun_con());
            con.Open();

            //SqlCommand cmd = new SqlCommand("select cc,comp,year_start,year_end from setup");
            SqlCommand cmd = new SqlCommand("select  Cc,Comp,Address,TELPHONENO,FAXNO,Vatno,cstno,year_start,year_end,Pathologist,Biochemist from company ");
            
            cmd.Connection = con;
            dr1 = cmd.ExecuteReader();
            while (dr1.Read())
            {
                //txtcompid.Text = dr1.GetValue(0).ToString();
             label4.Text = dr1.GetValue(1).ToString();
             String adr1 = dr1.GetValue(2).ToString();
             String tel1 = dr1.GetValue(3).ToString(); 
                
                dtfrom.Text = dr1.GetValue(7).ToString();
            
            
            }
            dr1.Close();
            // cboledger.Items.Add("STORE LEDGER");
            // cboledger.Items.Add("STORE SUMMARY");

            cboledger.Items.Add("STOCK LEDGER");
            cboledger.Items.Add("STOCK SUMMARY");
            Double cq = 0;
            Double cv = 0;

            da = new SqlDataAdapter("select item,tempqty,tempvalue from Product_master  order by item", con);
            ds = new DataSet();
            da.Fill(ds);

            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {

                cmd = new SqlCommand("update Product_master set  tempqty=" + cq + " ,tempvalue=" + cv + "  ", con);
                cmd.ExecuteNonQuery();
            }

            da.Dispose();
        }

        private void cboblno_SelectedIndexChanged(object sender, EventArgs e)
        {

           
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            DateTime dtf, dtt;
            String dd = dtfrom.Text.Substring(0, 2).ToString();
            String mmm = this.dtfrom.Text.Substring(3, 2).ToString();
            String yy = this.dtfrom.Text.Substring(6, 4).ToString();
            dtf = DateTime.ParseExact(dd + "/" + mmm + "/" + yy, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            String dd1 = dtto.Text.Substring(0, 2).ToString();
            String mmm1 = this.dtto.Text.Substring(3, 2).ToString();
            String yy1 = this.dtto.Text.Substring(6, 4).ToString();
            dtt = DateTime.ParseExact(dd1 + "/" + mmm1 + "/" + yy1, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            da = new SqlDataAdapter("select mrd.item,mrd.bldt,mrd.qty,mrd.rate,mrd.gross,mrd.type from mrn_detail mrd where   mrd.Bldt< '" + dtf.ToString("yyyy-MM-dd") + "' and (mrd.type='Purchase' or mrd.type='Issue' or mrd.type='Issue Return' or mrd.type='Purch Return') order by mrd.item,mrd.bldt,mrd.blno", con);
            ds2 = new DataSet();
            da.Fill(ds2);
            int i = 0;
            String pid;
            int tag = ds2.Tables[0].Rows.Count;
            Double pqty, prate, pvalue, iqty, irate, ivalue, netbal;
            Double oqty, orate, ovalue, cqty, crate, cvalue;
            Double grclosvalue = 0;
            if (tag != 0)
            {
                while (i <= tag)
                {
                    pid = ds2.Tables[0].Rows[i][0].ToString();
                    pqty = 0; iqty = 0; cvalue = 0;
                    pvalue = 0; ivalue = 0; cqty = 0;
                    while (pid == ds2.Tables[0].Rows[i][0].ToString())
                    {
                        if (ds2.Tables[0].Rows[i][5].ToString() == "Purchase" || ds2.Tables[0].Rows[i][5].ToString() == "Issue Return")
                        {

                            pqty = pqty + Convert.ToDouble(ds2.Tables[0].Rows[i][2].ToString());
                            pvalue = pvalue + Convert.ToDouble(ds2.Tables[0].Rows[i][4].ToString());
                        }
                        else
                        {
                            iqty = iqty + Convert.ToDouble(ds2.Tables[0].Rows[i][2].ToString());
                            ivalue = ivalue + Convert.ToDouble(ds2.Tables[0].Rows[i][4].ToString());
                        }
                        i++;

                        cqty = pqty - iqty;
                        if (pqty != 0)
                        {
                            cvalue = cqty * (pvalue / pqty);
                        }


                        if (i == tag) break;
                    }

                    SqlCommand cmd = new SqlCommand("update Product_master set  tempqty=" + cqty + " ,tempvalue=" + cvalue + "  where item='" + pid + "'", con);
                    cmd.ExecuteNonQuery();
                    if (i == tag) break;

                    pid = ds2.Tables[0].Rows[i][0].ToString();
                }

            }


            String s;

            //s = ("select am.acdes,am.opening_bal,cb.trncd,cb.vodt,cb.vono,cb.amt,cb.dcin,cb.narr,cb.cc from account_master am left join cbj cb on am.partyid=cb.partyid  where am.gcd= 3 and am.scd=1");
            //s = ("select cb.cc,cb.type,cb.blno,cb.bldt,am.acdes,cb.amt,cb.dcin,cb.narr,am.opening_bal,am.temp_bal from Product_master am left join mrn cb on (am.item=cb.item and cb.bldt>='" + dtfrom.Text + "' and cb.bldt<='" + dtto.Text + "')   where am.gcd= 3 and am.scd=1  order by am.item");
            //s = ("select am.item,mr.type,mr.bldt,mr.blno,mrd.qty,mrd.unit,mrd.rate,am.opqty,am.opvalue,am.tempqty,am.tempvalue from Product_master am left join mrn_detail mrd on am.item=mrd.item left join mrn mr on (mr.type=mrd.type and mr.blno=mrd.blno and mr.bldt>='" + dtfrom.Text + "' and mr.bldt<='" + dtto.Text + "' where am.item=mrd.item and mr.type=mrd.type and mr.blno=mrd.blno)");
            //s = ("select am.item,mrd.type,mr.bldt,mrd.blno,mrd.qty,mrd.unit,mrd.rate,am.opqty,am.opvalue,am.tempqty,am.tempvalue from Product_master am left join mrn_detail mrd on (am.item=mrd.item) left join mrn mr on (mr.type=mrd.type and mr.blno=mrd.blno and mr.bldt>='" + dtfrom.Text + "' and mr.bldt<='" + dtto.Text + "')");
            s = ("select am.item,mrd.type,mrd.bldt,mrd.blno,mrd.qty,mrd.unit,mrd.rate,am.opqty,am.opvalue,am.tempqty,am.tempvalue from Product_master am  left join mrn_detail mrd on (am.item=mrd.item and  mrd.bldt>='" + dtf.ToString("yyyy-MM-dd") + "' and mrd.bldt<='" + dtt.ToString("yyyy-MM-dd") + "')  and (mrd.type='Purchase' or mrd.type='Issue' or mrd.type='Issue Return' or mrd.type='Purch Return')  order by am.item,mrd.bldt,mrd.type");

            da = new SqlDataAdapter(s, con);
            ds = new DataSet();
            da.Fill(ds);
            Pathology_Ds ds1 = new Pathology_Ds();
            dt = ds1.Tables.Add("pathology_ds_stock");
            dt.Columns.Add("item", System.Type.GetType("System.String"));
            dt.Columns.Add("type", System.Type.GetType("System.String"));
            dt.Columns.Add("bldt", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("blno", System.Type.GetType("System.String"));
            dt.Columns.Add("opqty", System.Type.GetType("System.Double"));
            dt.Columns.Add("oprate", System.Type.GetType("System.Double"));
            dt.Columns.Add("opvalue", System.Type.GetType("System.Double"));

            dt.Columns.Add("rcqty", System.Type.GetType("System.Double"));
            dt.Columns.Add("rcrate", System.Type.GetType("System.Double"));
            dt.Columns.Add("rcvalue", System.Type.GetType("System.Double"));
            dt.Columns.Add("issqty", System.Type.GetType("System.Double"));
            dt.Columns.Add("issrate", System.Type.GetType("System.Double"));
            dt.Columns.Add("issvalue", System.Type.GetType("System.Double"));

            dt.Columns.Add("clqty", System.Type.GetType("System.Double"));
            dt.Columns.Add("clrate", System.Type.GetType("System.Double"));
            dt.Columns.Add("clvalue", System.Type.GetType("System.Double"));
            //dt.Columns.Add("cc", System.Type.GetType("System.String"));

            int tag1 = 0;
            i = 0;
            Double mrcqty, mrcrate, mrcvalue, misqty, misrate, misvalue;
            mrcqty = 0; mrcrate = 0; mrcvalue = 0; misqty = 0; misrate = 0; misvalue = 0;
            Double mrcqty1, mrcrate1, mrcvalue1, misqty1, misrate1, misvalue1;
            mrcqty1 = 0; mrcrate1 = 0; mrcvalue1 = 0; misqty1 = 0; misrate1 = 0; misvalue1 = 0;
            Double mclqty, mclrate, mclvalue;
            mclqty = 0; mclrate = 0; mclvalue = 0;
            Double opq, opq7, opq9, opq8, opq10;
            opq = 0; opq7 = 0; opq9 = 0; opq8 = 0; opq10 = 0;
            Double opr = 0;
            Double opv = 0;


            if (ds.Tables[0].Rows.Count != 0)
            {
                String acd = ds.Tables[0].Rows[i][0].ToString();
                while (acd == ds.Tables[0].Rows[i][0].ToString())
                {


                    //mclqty=0; mclrate=0; mclvalue=0;
                    //mrcqty = 0; mrcrate = 0; mrcvalue = 0; misqty = 0; misrate = 0; misvalue = 0;
                    mrcqty1 = 0; mrcrate1 = 0; mrcvalue1 = 0; misqty1 = 0; misrate1 = 0; misvalue1 = 0;

                    if (ds.Tables[0].Rows[i][1].ToString() != "")
                    {
                        //if (Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[2].ToString()) >= dtfrom.Text & Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[2].ToString()) <= dtto.Text)
                        //{         

                        if (ds.Tables[0].Rows[i][1].ToString() == "Purchase" || ds.Tables[0].Rows[i][1].ToString() == "Issue Return")
                        {
                            mrcqty = mrcqty + Convert.ToDouble(ds.Tables[0].Rows[i][4].ToString());
                            mrcqty1 = Convert.ToDouble(ds.Tables[0].Rows[i][4].ToString());
                            mrcvalue = mrcvalue + Convert.ToDouble(ds.Tables[0].Rows[i][4].ToString()) * Convert.ToDouble(ds.Tables[0].Rows[i][6].ToString());
                            mrcvalue1 = Convert.ToDouble(ds.Tables[0].Rows[i][4].ToString()) * Convert.ToDouble(ds.Tables[0].Rows[i][6].ToString());
                            mrcrate = mrcvalue / mrcqty;
                            mrcrate1 = mrcvalue1 / mrcqty1;
                        }
                        else
                        {
                            misqty = misqty + Convert.ToDouble(ds.Tables[0].Rows[i][4].ToString());
                            misvalue = misvalue + Convert.ToDouble(ds.Tables[0].Rows[i][4].ToString()) * Convert.ToDouble(ds.Tables[0].Rows[i][6].ToString());
                            misrate = misvalue / misqty;
                            misqty1 = Convert.ToDouble(ds.Tables[0].Rows[i][4].ToString());
                            misvalue1 = Convert.ToDouble(ds.Tables[0].Rows[i][4].ToString()) * Convert.ToDouble(ds.Tables[0].Rows[i][6].ToString());
                            misrate1 = misvalue1 / misqty1;
                        }
                    }
                    dr = dt.NewRow();

                    dr["item"] = acd.ToString();
                    dr["type"] = ds.Tables[0].Rows[i][1].ToString();
                    if (ds.Tables[0].Rows[i][2].ToString() != "")
                    {
                        dr["bldt"] = ds.Tables[0].Rows[i][2].ToString();
                    }
                    dr["blno"] = ds.Tables[0].Rows[i][3].ToString();

                    opq = 0; opr = 0; opv = 0; opq7 = 0; opq8 = 0; opq8 = 0; opq10 = 0;
                    if (ds.Tables[0].Rows[i][7].ToString() != "")
                    {
                        opq7 = Convert.ToDouble(ds.Tables[0].Rows[i][7].ToString());
                    }
                    if (ds.Tables[0].Rows[i][9].ToString() != "")
                    {
                        opq9 = Convert.ToDouble(ds.Tables[0].Rows[i][9].ToString());
                    }
                    opq = opq7 + opq9;

                    if (ds.Tables[0].Rows[i][8].ToString() != "")
                    {
                        opq8 = Convert.ToDouble(ds.Tables[0].Rows[i][8].ToString());
                    }
                    if (ds.Tables[0].Rows[i][10].ToString() != "")
                    {
                        opq10 = Convert.ToDouble(ds.Tables[0].Rows[i][10].ToString());
                    }
                    opv = opq8 + opq10;


                    opr = opv / opq;
                    dr["opqty"] = opq;
                    dr["oprate"] = opr;
                    dr["opvalue"] = opv;

                    dr["rcqty"] = mrcqty1;
                    dr["rcrate"] = mrcrate1;
                    dr["rcvalue"] = mrcvalue1;
                    dr["issqty"] = misqty1;
                    dr["issrate"] = misrate1;
                    dr["issvalue"] = misvalue1;
                    mclqty = opq + mrcqty - misqty;
                    mclvalue = mclqty * mrcrate;
                    mclrate = mclvalue / mclqty;
                    dr["clqty"] = mclqty;
                    dr["clrate"] = mclrate;
                    dr["clvalue"] = mclvalue;
                    if (opq + mrcqty + misqty != 0)
                    {
                        dt.Rows.Add(dr);
                        dt.AcceptChanges();
                    }
                    //}   // date > dtfrom and <=dtto
                    i++;
                    if (i >= ds.Tables[0].Rows.Count) break;

                    if (acd != ds.Tables[0].Rows[i][0].ToString())
                    {
                        mrcqty = 0; mrcrate = 0; mrcvalue = 0; misqty = 0; misrate = 0; misvalue = 0;
                        grclosvalue = grclosvalue + mclvalue;
                        // grclos.Text = Convert.ToString(grclosvalue);

                    }
                    acd = ds.Tables[0].Rows[i][0].ToString();


                }

                //da.Dispose();
                //da = new SqlDataAdapter("select partyid,acdes,gcd,grpname,scd,s_group,add1,city,pin,zone,phone,fax,email,vatno,cstno,dl_no,opening_bal,closing_bal,temp_bal,dr_cr from account_master where gcd=3 and scd=1 order by acdes", con);
                //ds0 = new DataSet();
                //da.Fill(ds0, "ds_account_master");

            }

            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            if (cboledger.Text == "STOCK LEDGER")
            {
              Repstled1 stoledrep = new Repstled1();
               // //ledgerrep.Load("/Hope_account/Hope_account/repledg.rpt");
               //// stoledrep.SetDatabaseLogon("sa", "software", @".\SQLEXPRESS", "hope_account");
              stoledrep.SetDataSource(dt);
              crystalReportViewer1.ReportSource = stoledrep;
              
              stoledrep.SetParameterValue(0, label4.Text);
              stoledrep.SetParameterValue(1, adr1);
              stoledrep.SetParameterValue(2, tel1);
              stoledrep.SetParameterValue(3, dtf);
              stoledrep.SetParameterValue(4, dtt);
                //stoledrep.SetParameterValue(3, grclos.Text);
                //ledgerrep.SetParameterValue(2, cboledger.SelectedItem .ToString ());
            }
            else
            {
                Repstocksumm stoledrep = new Repstocksumm();
                //ledgerrep.Load("/Hope_account/Hope_account/repledg.rpt");
                stoledrep.SetDatabaseLogon("sa", "software", @".\SQLEXPRESS", "pathology2627");
                stoledrep.SetDataSource(dt);
                crystalReportViewer1.ReportSource = stoledrep;
               
                stoledrep.SetParameterValue(0, label4.Text);
                stoledrep.SetParameterValue(1, adr1);
                stoledrep.SetParameterValue(2, tel1);

                stoledrep.SetParameterValue(3, dtf);
                stoledrep.SetParameterValue(4, dtt);
                //ledgerrep.SetParameterValue(2, cboledger.SelectedItem .ToString ());
            }




            //crv.Refresh();
            con.Close();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
