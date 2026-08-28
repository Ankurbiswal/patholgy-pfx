using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.ServiceProcess;
namespace Pathology
{
    public partial class Frmmainmenu : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataSet ds;

        public static int mpcode_del_tag = Frmpassword.pcode_del_tag;
        public static String muserid1 = Frmpassword.userid1;
        public static String mpasswd1 = Frmpassword.passwd1;
        public static String musrname1 = Frmpassword.usrname1;
        public static String musrtype1 = Frmpassword.usrtype1;
        
        
        
        
        public Frmmainmenu()
        {
            
            InitializeComponent();
        }

        private void entryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmresultentry fre = new Frmresultentry();
            fre.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pendingReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmpending fpend = new Frmpending();
            fpend.Show();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmrepurine fru = new Frmrepurine();
            fru.Show();
        }

        private void stoolReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmrepstool frss = new Frmrepstool();
            frss.Show();
        }

        private void bloodReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Frmrepblood frrb = new Frmrepblood();
            //frrb.Show();
           // Frmrepbloodhtml frrb = new Frmrepbloodhtml();
            Frmrepbloodn frrb = new Frmrepbloodn();
            frrb.Show();
        
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmcompanysel fcs = new Frmcompanysel();
            fcs.Show();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmcompany fc1 = new Frmcompany();
            fc1.Show();
        }

        private void biochemistReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmrepbiochemn frb = new Frmrepbiochemn();
            frb.Show();
        }

        private void seminalFluidReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmrepseminalfluid frsf = new Frmrepseminalfluid();
            frsf.Show();
        }

        private void othersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Frmreppaid frmpaid = new Frmreppaid();
            Frmrepcashbook frmpaid = new Frmrepcashbook();
            
            frmpaid.Show();
        }

        private void sugarRegiserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmrepsugar frmsugar = new Frmrepsugar();
            frmsugar.Show();
        }

        private void baToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe"); 
        }

        private void doctorNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmdoctor fd = new Frmdoctor();
            fd.Show();
        }

        private void doctorPaidReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Frmrepdoctor frd = new Frmrepdoctor();
            Frmdoctorcomm frd = new Frmdoctorcomm();
            frd.Show();
        }

        private void Frmmainmenu_Load(object sender, EventArgs e)
        {
            Class1 objclass = new Class1();
            con = new SqlConnection(objclass.arun_con());
            try { con.Open(); }
            catch
            {
                CheckSqlService();
                try { con.Open(); }
                catch (Exception ex2)
                {
                    MessageBox.Show("Cannot connect to database!\n\n" + ex2.Message +
                        "\n\nPlease start SQL Server service or contact support.",
                        "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit(); return;
                }
            }
            da = new SqlDataAdapter("select comp from company", con);
            ds = new DataSet();
            da.Fill(ds);
            label1.Text = ds.Tables[0].Rows[0][0].ToString();
            da.Dispose();
            RunStartupChecks();
        }

        private void RunStartupChecks()
        {
            // CHECK 1: Disk space
            try
            {
                DriveInfo drive = new DriveInfo("C");
                long freeGB = drive.AvailableFreeSpace / (1024L * 1024 * 1024);
                if (freeGB < 5)
                    MessageBox.Show("LOW DISK SPACE WARNING!\n\nOnly " + freeGB + " GB free on C:\\\n\n" +
                        "Please free up disk space or the app may stop working.\n" +
                        "Delete old files or contact your IT person.",
                        "Disk Space Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch { }

            // CHECK 2: SQL Server Express DB size (10 GB limit)
            try
            {
                SqlCommand sizeCmd = new SqlCommand("SELECT SUM(size) * 8.0 / 1024 / 1024 FROM sys.database_files", con);
                double sizeGB = Convert.ToDouble(sizeCmd.ExecuteScalar());
                if (sizeGB >= 9.0)
                    MessageBox.Show("DATABASE SIZE CRITICAL: " + sizeGB.ToString("F1") + " GB / 10 GB limit!\n\n" +
                        "SQL Server Express will STOP ACCEPTING DATA at 10 GB.\n" +
                        "Contact your software vendor IMMEDIATELY.",
                        "Database Critical", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (sizeGB >= 7.0)
                    MessageBox.Show("Database size warning: " + sizeGB.ToString("F1") + " GB used (limit is 10 GB).\n\n" +
                        "Contact your software vendor to plan an upgrade.",
                        "Database Size Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch { }

            // CHECK 3: PC clock vs SQL Server clock
            try
            {
                SqlCommand timeCmd = new SqlCommand("SELECT GETDATE()", con);
                DateTime sqlTime = Convert.ToDateTime(timeCmd.ExecuteScalar());
                double diffMinutes = Math.Abs((DateTime.Now - sqlTime).TotalMinutes);
                if (diffMinutes > 5)
                    MessageBox.Show("CLOCK WARNING!\n\n" +
                        "Your PC clock: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "\n" +
                        "Correct time:  " + sqlTime.ToString("dd/MM/yyyy HH:mm") + "\n\n" +
                        "Wrong date/time will file patient records on the wrong date!\n" +
                        "Please correct your PC clock via Windows Settings.",
                        "Clock Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch { }
        }

        private void CheckSqlService()
        {
            try
            {
                foreach (ServiceController svc in ServiceController.GetServices())
                {
                    if (svc.ServiceName.StartsWith("MSSQL$"))
                    {
                        if (svc.Status != ServiceControllerStatus.Running)
                        {
                            DialogResult r = MessageBox.Show(
                                "SQL Server service is not running.\n\nClick OK to try starting it automatically.",
                                "SQL Server Stopped", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            if (r == DialogResult.OK)
                            {
                                svc.Start();
                                svc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(30));
                            }
                        }
                        break;
                    }
                }
            }
            catch { }
        }

        private void Frmmainmenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                string backupFolder = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "PathologyBackups");
                Directory.CreateDirectory(backupFolder);
                string backupFile = Path.Combine(backupFolder,
                    "auto_backup_" + DateTime.Now.ToString("yyyy-MM-dd") + ".bak");
                if (!File.Exists(backupFile))
                {
                    Class1 objclass = new Class1();
                    using (SqlConnection bkCon = new SqlConnection(objclass.arun_con()))
                    {
                        bkCon.Open();
                        SqlCommand bkCmd = new SqlCommand(
                            "BACKUP DATABASE [pathology2627] TO DISK = @path WITH FORMAT, INIT, SKIP, NOREWIND, NOUNLOAD",
                            bkCon);
                        bkCmd.CommandTimeout = 120;
                        bkCmd.Parameters.AddWithValue("@path", backupFile);
                        bkCmd.ExecuteNonQuery();
                    }
                    // Delete backups older than 7 days
                    foreach (string old in Directory.GetFiles(backupFolder, "auto_backup_*.bak"))
                        if (File.GetCreationTime(old) < DateTime.Now.AddDays(-7))
                            File.Delete(old);
                }
            }
            catch { }
        }

        private void serologyReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmrepserology frs = new Frmrepserology();
            frs.Show();
        }

        private void Codewisereport_Click(object sender, EventArgs e)
        {
            Frmrepcodewise frmrepcode = new Frmrepcodewise();
            frmrepcode.Show();
        }

        private void cultureSensitivityReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmrepculture frmrepculture = new Frmrepculture();
            frmrepculture.Show();
        }

        private void hormoneAssayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmrephormone frmrephormone = new Frmrephormone();
            frmrephormone.Show();
        }

        private void bodyFluidAnalysisReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmrepbodyfluid fbf = new Frmrepbodyfluid();
            fbf.Show();
        }

        private void cytologyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmrepcytology frcy = new Frmrepcytology();

            frcy.Show();
        }

        private void vaccinePurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmpurchase frmpurchase = new Frmpurchase();

            frmpurchase.Show();
        }

        private void vaccineIssueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmrepissue frissue = new Frmrepissue();
            frissue.Show();
        }

        private void stockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmrepstock frstock = new Frmrepstock();
            frstock.Show();
        }

        private void itemMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmproductmaster frmpmast = new Frmproductmaster();
            frmpmast.Show();
        }

        private void testSummaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmreptestsummary frts = new Frmreptestsummary();
            frts.Show();
        }

        private void testMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmtestmaster ftm1 = new Frmtestmaster();
            ftm1.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frmvoucherentry fvent = new Frmvoucherentry();
            fvent.Show();
        }

        private void patientLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmrepledger frledg = new Frmrepledger();
            frledg.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Frmoutsource frous2 = new Frmoutsource();
            frous2.Show();
        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void profileMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmprofilemaster fprof1 = new Frmprofilemaster();
            fprof1.Show();
        }

        private void profileGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmprofilegr frmgrmast = new Frmprofilegr();
            frmgrmast.Show();
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmnormalreferencesetup fnsetup = new Frmnormalreferencesetup();
            fnsetup.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Frmrepurine frurine = new Frmrepurine();
            frurine.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Frmbillreg frmbr = new Frmbillreg();
            frmbr.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Frmreferal referal = new Frmreferal();
            referal.Show();
        }

        private void opdRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmopdmaster fopdm = new Frmopdmaster();
            fopdm.Show();
            //Frmopdregistration fopdm = new Frmopdregistration();
            //fopdm.Show();
        }

        private void oPDRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmopdregister fopdr = new Frmopdregister();
            fopdr.Show();
        }

       

     
       private void rblogincancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbsubmit_Click(object sender, EventArgs e)
        {

            //cmd = new SqlCommand("select userid,password,username,type from usermaster where userid='" + txtuserid.Text + "' and password='" + txtpassword.Text + "' ", con);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //ds = new DataSet();
            //da.Fill(ds);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    this.txtuseridd.Text = ds.Tables[0].Rows[0][0].ToString();
            //    this.txtpasswordd.Text = ds.Tables[0].Rows[0][1].ToString();
            //    //label4.Text = dr.GetValue(1).ToString();
            //    //dtfrom.Text = dr.GetValue(2).ToString();
            //    userid1 = txtuseridd.Text;
            //    passw = txtpasswordd.Text;
            //    //Frmlogin.ActiveForm.Hide();
            //    String main = "Y";
            //    //Frmmainmenu frmm = new Frmmainmenu();
            //    //frmm.Show();
            //    if (txtuseridd.Text.ToUpper() == "ADMIN")
            //    {

            //        pcode_del_tag = 1;
            //        //partyMasterToolStripMenuItem.Enabled = true;
            //        //productMasterToolStripMenuItem.Enabled = true;
            //        //batchMasterToolStripMenuItem.Enabled = true;
            //        //receiptRegisterToolStripMenuItem.Enabled = true;
            //        //employeeAttendanceToolStripMenuItem.Enabled = true;
            //        //attendanceReportToolStripMenuItem.Enabled = true;
            //        //toolStripMenuItem4.Enabled = true;
            //        //toolStripMenuItem7.Enabled = true;  // do

            //        //employeeAttendanceToolStripMenuItem.Enabled = true;
            //        //attendanceReportToolStripMenuItem.Enabled = true;



            //    }
            //    //if (txtuseridd.Text.ToUpper() == "ADMIN")
            //    //{
            //    //    cmd = new SqlCommand("update setup set currentuser='ADMIN'", con);
            //    //    cmd.ExecuteNonQuery();
            //    //}
            //    //else
            //    //{
            //    //    cmd = new SqlCommand("update setup set currentuser=''", con);
            //    //    cmd.ExecuteNonQuery();
            //    //}
            //    //partyMasterToolStripMenuItem.Enabled = true;
            //    //productMasterToolStripMenuItem.Enabled = true;
            //    //batchMasterToolStripMenuItem.Enabled = true;
            //    //toolStripMenuItem8.Enabled = true;  // ta
            //    //receiptRegisterToolStripMenuItem.Enabled = true;
            //    //toolStripMenuItem1.Enabled = true;
            //    //issueSlipToolStripMenuItem.Enabled = true;
            //    //changeInMasterFileToolStripMenuItem.Enabled = true;
            //    //toolStripMenuItem6.Enabled = true;
            //    ////toolStripMenuItem7.Enabled = true;
            //    //toolStripMenuItem8.Enabled = true;
            //    //// toolStripMenuItem4.Enabled = true;
            //    //outwardWeighmentEntryToolStripMenuItem.Enabled = true;
            //    //inwardWeighmentEntryToolStripMenuItem.Enabled = true;
            //    //groupBox1.Visible = false;
            //    //toolStripMenuItem4.Enabled = true;
            //    //toolStripMenuItem7.Enabled = true;




            //}
            //else
            //{
            //    MessageBox.Show("Invalid User Name/Password");
            //    txtpassword.Focus();
            //}
        }

        private void txtuserid_Validating(object sender, CancelEventArgs e)
        {
            //if (txtuserid.Text == "" || txtuserid.Text == null)
            //{
            //    MessageBox.Show("User Id can't be blank");
            //    txtuserid.Focus();
            //}
        }

        private void txtpasswordd_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void adminPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (musrtype1=="Admin")
            {
            Frmadminmaster fadmn = new Frmadminmaster();
            fadmn.Show();
            }
            }

        private void accountMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmaccountmaster facc = new Frmaccountmaster();
            facc.Show();
        }

        private void readMeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //string st = "001";
            //string fl = st+".docx";
            System.Diagnostics.Process.Start("help.txt"); 
        }

        private void wordFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Goto NOTEPAD in Patient-Result ->Result Entry Menu Tab to Create Word File. You can Copy & paste the content from the saved file & edit it, then save to respective reg.no. for your reference & print");
            Frmculturemaster fcult = new Frmculturemaster();
            fcult.Show();

        }

        private void accountMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frmaccountmaster facmast = new Frmaccountmaster();
            facmast.Show();
        }

        private void cashBankBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmrepcashbook frmpaid = new Frmrepcashbook();

            frmpaid.Show();
        }

        private void patientLedgerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frmrepledger frledg = new Frmrepledger();
            frledg.Show();
        }

        private void paymentVoucherEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmvoucherentry fvent = new Frmvoucherentry();
            fvent.Show();
        }

        private void doctorWiseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmdoctorcomm frd = new Frmdoctorcomm();
            frd.Show();
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Frmbom bom = new Frmbom();
            bom.Show();
        }

        private void outdoorRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmopdregistration frmopdreg = new Frmopdregistration();
            frmopdreg.Show();
        }

        private void billDischargeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmpathbill_opd fopdbill = new Frmpathbill_opd();
            fopdbill.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Frmopdbillentry fopdbillentry = new Frmopdbillentry();
            fopdbillentry.Show();
        }

        private void testPriceListToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem6_Click_1(object sender, EventArgs e)
        {

        }

        private void cultureTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmculturetype fctyp = new Frmculturetype();
            fctyp.Show();
        }

        private void cultureDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmculture_organism fcorg = new Frmculture_organism();
            fcorg.Show();
        }

        private void culture3rdTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmcolonycount fccnt = new Frmcolonycount();
            fccnt.Show();
        }

        private void patientRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {

        }

       

        
    }
}