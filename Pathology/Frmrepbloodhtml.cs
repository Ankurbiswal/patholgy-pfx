using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace Pathology
{
    public partial class Frmrepbloodhtml : Form
    {
        SqlConnection con;
        DataSet ds;
        SqlDataAdapter da;
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt;

        public Frmrepbloodhtml()
        {
            InitializeComponent();
        }

        private void Frmrepbloodhtml_Load(object sender, EventArgs e)
        {
          con = new SqlConnection("data source=.\\sqlexpress;integrated security=SSPI;database=Pathology;");
            //con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Pathology;Persist Security Info=True;User ID=sa;Password=software;");

            
            con.Open();
            cmd = new SqlCommand("select cc,comp,year_start,year_end from setup");
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //this.txtcompid.Text = dr.GetValue(0).ToString();
                //label4.Text = dr.GetValue(1).ToString();
                //dtfrom.Text = dr.GetValue(2).ToString();
            }
            dr.Close();
            // cbotype.Items.Add("Sale");
            da = new SqlDataAdapter("select distinct patient_name,pcode from patient_record order by patient_name", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                this.cboname.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            con.Close();
        }

        private void btngo_Click(object sender, EventArgs e)
        {
            con.Open();
            //da  = new SqlDataAdapter("SELECT pcode,patient_name,age,sex,doctor,date_exam from patient_record WHERE Patient_Name = '"+cboname.Text+"'", con);

            String strsql = "";
            strsql = "select cc,patient_name,pcode,sex,age,doctor,date_exam,UP_color,UP_sediments,UP_reaction,UP_specificgravity,UC_sugar,UC_albumin,UC_phosphate,UC_chyle,UC_ketonebodies,UC_bilesalts,UC_bilepigment,UM_puscells,UM_epithcells,UM_rbc,UM_casts,UM_crystals,UM_bacterial,UM_spermatozoa,UM_mf_tv,UM_others,UU_urine_b_hcg,UA_urine_albumin,UN_nasalsmear,Us_SputumAfb, Sp_color, Sp_reaction, Sp_Mucus, SM_rbc_from, SM_rbc_to, SM_puscells_from,SM_puscells_to,SM_macrophase,SM_vegetables,SM_fataglobules,SM_yeast,SM_crystal,SM_bacterialflora,SP_EHistolytica,SP_ecoli,SP_giardia,SP_trichomonas,SH_OvaHW,SH_OvaRW,SH_Others,SC_Occultblood,SC_Reducingsugar,";
            strsql = strsql + "BG_Blood_Group,BR_RhD_Typing,BDc_Neutrophild,BDc_Eosinophils,BDc_Lymphocytes,";
            strsql = strsql + "BDc_Basophils,BDc_Monocytes,BDc_Twbc,BDc_Trbc,BDc_Tplatelets,BDc_Aec,BDc_Reticulocyte_Count,";
            strsql = strsql + "BDc_PCV,BDc_Mp_ICT_QBC_Smear,BDc_Mf_ICT_QBC_Smear,BDc_Hb,BDc_ESR_1sthour,BDc_ESR_2ndhour,";
            strsql = strsql + "BDc_Bleeding_Time,BDc_Clotting_Time,BDc_Sickle_cell,BPS_Toxo,BPS_Crp,BPS_Vdrl,";
            strsql = strsql + "BPS_Rafactor,BPS_Aso,BS_Australia_Antigen,BS_Hepatitis_C_Virus,BS_HIV_1,BS_HIV_2,";
            strsql = strsql + "BS_Ict_PF_PV,Bw_Widaltest,Bm_MontouxTest_injon,Bm_MontouxTest_readon,Bm_MontouxTest_induration";
            strsql = strsql + " from patient_record where patient_name='" + cboname.SelectedItem + "'  and date_exam= '" + Convert.ToDateTime(dtreport.Text) + "'";
            da = new SqlDataAdapter(strsql, con);
            //ds = new DataSet();
            //da.Fill(ds, "patient_record");  
 
            DataTable dt = new DataTable();
            da.Fill(dt);

            FileStream fs = new FileStream("D:/pathology/Bloodhtml.Doc", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("<table border='1' style='font-size:14px;'>");
            sw.WriteLine("<tr style='font-weight:bold;'>");
            //sw.WriteLine("<td>Code</td>");
             sw.WriteLine("</tr>");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sw.WriteLine("<tr>");
                sw.WriteLine("<td>Code : </td>");
                sw.WriteLine("<td>" + dt.Rows[i]["pcode"].ToString() + "</td>");
                sw.WriteLine("<td>Age</td>");
                sw.WriteLine("<td>" + dt.Rows[i]["Age"].ToString() + "</td>");
                sw.WriteLine("<td>Sex</td>");
                sw.WriteLine("<td>" + dt.Rows[i]["Sex"].ToString() + "</td>");
                sw.WriteLine("</tr>");
                sw.WriteLine("</tr>");
                sw.WriteLine("</tr>");
                sw.WriteLine("</tr>");
                sw.WriteLine("<td>Name :          </td>");
                sw.WriteLine("<td>" + dt.Rows[i]["Patient_Name"].ToString() + "</td>");
                sw.WriteLine("<td>                            Reported On</td>");
                sw.WriteLine("<td>" + dt.Rows[i]["Date_Exam"].ToString() + "</td>");
                sw.WriteLine("</tr>");
                sw.WriteLine("<td>Doctor Ref By</td>");
                sw.WriteLine("<td>" + dt.Rows[i]["Doctor"].ToString() + "</td>");
                sw.WriteLine("<td>" + dt.Rows[i]["Doctor"].ToString() + "</td>");
                sw.WriteLine("</tr>");
                sw.WriteLine("<td>");
                sw.WriteLine("</tr>");
                sw.WriteLine("<td>");
                sw.WriteLine("</tr>");

                sw.WriteLine("<td>");
                sw.WriteLine("</tr>");
                sw.WriteLine("<td>");
                sw.WriteLine("</tr>");
                sw.WriteLine("<td>Blood_Group </td>");
                sw.WriteLine("<td>" + dt.Rows[i]["BG_Blood_Group"].ToString() + "</td>");
                sw.WriteLine("</tr>");
                
                sw.WriteLine("<td>RhD_Typing </td>" ); 
                sw.WriteLine("<td> " + dt.Rows[i]["BR_RhD_Typing"].ToString() + "</td>");
                sw.WriteLine("</tr>");
                sw.WriteLine("<td>Neutrophil </td> " );
                sw.WriteLine("<td>" + dt.Rows[i]["BDc_Neutrophild"].ToString() + "</td>");
                sw.WriteLine("</tr>");
                sw.WriteLine("<td>Eosinophils </td> ");
                sw.WriteLine("<td>" + dt.Rows[i]["BDc_Eosinophils"].ToString() + "</td>");
                if (dt.Rows[i]["BDc_Lymphocytes"].ToString() != "0")
                {
                    sw.WriteLine("<td>Lymphocytes                               </td> ");
                    sw.WriteLine("<td>" + dt.Rows[i]["BDc_Lymphocytes"].ToString() + "</td>");
                }
                sw.WriteLine("</tr>");

               
                if (dt.Rows[i]["BDc_Monocytes"].ToString() != "0")
                {
                    sw.WriteLine("<td>Monocytes                                 </td> ");
                    sw.WriteLine("<td>" + dt.Rows[i]["BDc_Monocytes"].ToString() + "</td>");
                }
                sw.WriteLine("</tr>");
                if (dt.Rows[i]["BDc_Twbc"].ToString() != "0")
                {
                    sw.WriteLine("<td>Twbc                                 </td> ");
                    sw.WriteLine("<td>" + dt.Rows[i]["BDc_Twbc"].ToString() + "</td>");
                }
                sw.WriteLine("</tr>");


                if (dt.Rows[i]["BDc_Trbc"].ToString() != "0")
                {
                    sw.WriteLine("<td>Trbc                                 </td> ");
                    sw.WriteLine("<td>" + dt.Rows[i]["BDc_Trbc"].ToString() + "</td>");
                }
                sw.WriteLine("</tr>");
                if (dt.Rows[i]["BDc_Tplatelets"].ToString() != "0")
                {
                    sw.WriteLine("<td>Tplatelets                                 </td> ");
                    sw.WriteLine("<td>" + dt.Rows[i]["BDc_Tplatelets"].ToString() + "</td>");
                }
                sw.WriteLine("</tr>");
                if (dt.Rows[i]["BDc_Aec"].ToString() != "0")
                {
                    sw.WriteLine("<td>Aec                                 </td> ");
                    sw.WriteLine("<td>" + dt.Rows[i]["BDc_Aec"].ToString() + "</td>");
                }
                sw.WriteLine("</tr>");
                if (dt.Rows[i]["BDc_Reticulocyte_Count"].ToString() != "0.00")
                {
                    sw.WriteLine("<td>Reticulocyte_Count                                 </td> ");
                    sw.WriteLine("<td>" + dt.Rows[i]["BDc_Reticulocyte_Count"].ToString() + "</td>");
                }
                sw.WriteLine("</tr>");
                if (dt.Rows[i]["BDc_PCV"].ToString() != "0.00")
                {
                    sw.WriteLine("<td>PCV                                 </td> ");
                    sw.WriteLine("<td>" + dt.Rows[i]["BDc_PCV"].ToString() + "</td>");
                }
                sw.WriteLine("</tr>");
                if (dt.Rows[i]["BDc_Mp_ICT_QBC_Smear"].ToString() != "")
                {
                    sw.WriteLine("<td>Mp_ICT_QBC_Smear                                 </td> ");
                    sw.WriteLine("<td>" + dt.Rows[i]["BDc_Mp_ICT_QBC_Smear"].ToString() + "</td>");
                }
                sw.WriteLine("</tr>");
                if (dt.Rows[i]["BDc_Mf_ICT_QBC_Smear"].ToString() != "")
                {
                    sw.WriteLine("<td>Mf_ICT_QBC_Smear                                 </td> ");
                    sw.WriteLine("<td>" + dt.Rows[i]["BDc_Mf_ICT_QBC_Smear"].ToString() + "</td>");
                }
                sw.WriteLine("</tr>");
                if (dt.Rows[i]["BDc_Hb"].ToString() != "0.00")
                {
                    sw.WriteLine("<td>Hb                                 </td> ");
                    sw.WriteLine("<td>" + dt.Rows[i]["BDc_Hb"].ToString() + "</td>");
                }
                sw.WriteLine("</tr>");

                if (dt.Rows[i]["BDc_ESR_1sthour"].ToString() != "0.00")
                {
                    sw.WriteLine("<td>ESR_1sthour                                </td> ");
                    sw.WriteLine("<td>" + dt.Rows[i]["BDc_ESR_1sthour"].ToString() + "</td>");
                }
                sw.WriteLine("</tr>");

                if (dt.Rows[i]["BDc_ESR_2ndhour"].ToString() != "0.00")
                {
                    sw.WriteLine("<td>ESR_2ndhour                                 </td> ");
                    sw.WriteLine("<td>" + dt.Rows[i]["BDc_ESR_2ndhour"].ToString() + "</td>");
                }
                sw.WriteLine("</tr>");

                if (dt.Rows[i]["BDc_Bleeding_Time"].ToString() != "")
                {
                    sw.Write("<td>Bleeding_Time                                </td> ");
                    sw.WriteLine("<td>" + dt.Rows[i]["BDc_Bleeding_Time"].ToString() + "</td>");
           
                
                }
                sw.WriteLine("</tr>");

                if (dt.Rows[i]["BDc_Clotting_Time"].ToString() != "")
                {
                    sw.WriteLine("<td>Clotting_Time                              </td> ");
                    sw.WriteLine("<td>" + dt.Rows[i]["BDc_Clotting_Time"].ToString() + "</td>");
                }
                sw.WriteLine("</tr>");

                if (dt.Rows[i]["BDc_Sickle_cell"].ToString() != "")
                {
                    sw.WriteLine("<td>Sickle_cell                  </td> ");
                    sw.WriteLine("<td>" + dt.Rows[i]["BDc_Sickle_cell"].ToString() + "</td>");
                }
                sw.WriteLine("</tr>");

                if (dt.Rows[i]["BPS_Toxo"].ToString() != "")
                {
                    sw.WriteLine("<td>Toxo                               </td> ");
                    sw.WriteLine("<td>" + dt.Rows[i]["BPS_Toxo"].ToString() + "</td>");
                }
                sw.WriteLine("</tr>");
                if (dt.Rows[i]["BPS_Crp"].ToString() != "")
                {
                    sw.WriteLine("<td>Crp                      </td> ");
                    sw.WriteLine("<td>" + dt.Rows[i]["BPS_Crp"].ToString() + "</td>");
                }
                sw.WriteLine("</tr>");

                if (dt.Rows[i]["BPS_Vdrl"].ToString() != "")
                {
                    sw.WriteLine("<td>Vdrl                                </td> ");
                    sw.WriteLine("<td>" + dt.Rows[i]["BPS_Vdrl"].ToString() + "</td>");
                }
                sw.WriteLine("</tr>");

                if (dt.Rows[i]["BPS_Rafactor"].ToString() != "")
                {
                    sw.WriteLine("<td>Rafactor                              </td> ");
                    sw.WriteLine("<td>" + dt.Rows[i]["BPS_Rafactor"].ToString() + "</td>");
                }
                sw.WriteLine("</tr>");

                if (dt.Rows[i]["BPS_Aso"].ToString() != "")
                {
                    sw.WriteLine("<td>Aso                              </td> ");
                    sw.WriteLine("<td>" + dt.Rows[i]["BPS_Aso"].ToString() + "</td>");
                }
                sw.WriteLine("</tr>");
                if (dt.Rows[i]["BS_Australia_Antigen"].ToString() != "")
                {
                    sw.WriteLine("<td>Australia_Antigen                          </td> ");
                    sw.WriteLine("<td>" + dt.Rows[i]["BS_Australia_Antigen"].ToString() + "</td>");
                }
                sw.WriteLine("</tr>");
                if (dt.Rows[i]["BS_Hepatitis_C_Virus"].ToString() != "")
                {
                    sw.WriteLine("<td>Hepatitis_C_Virus                            </td> ");
                    sw.WriteLine("<td>" + dt.Rows[i]["BS_Hepatitis_C_Virus"].ToString() + "</td>");
                }
                sw.WriteLine("</tr>");
                if (dt.Rows[i]["BS_HIV_1"].ToString() != "")
                {
                    sw.WriteLine("<td>HIV_1                            </td> ");
                    sw.WriteLine("<td>" + dt.Rows[i]["BS_HIV_1"].ToString() + "</td>");
                }
                sw.WriteLine("</tr>");
                if (dt.Rows[i]["BS_HIV_2"].ToString() != "")
                {
                    sw.WriteLine("<td>HIV_2                             </td> ");
                    sw.WriteLine("<td>" + dt.Rows[i]["BS_HIV_2"].ToString() + "</td>");
                }
                sw.WriteLine("</tr>");
                if (dt.Rows[i]["BS_Ict_PF_PV"].ToString() != "")
                {
                    sw.WriteLine("<td>Ict_PF_PV                       </td> ");
                    sw.WriteLine("<td>" + dt.Rows[i]["BS_Ict_PF_PV"].ToString() + "</td>");
                }
                sw.WriteLine("</tr>");
                if (dt.Rows[i]["Bm_MontouxTest_injon"].ToString() != "")
                {
                    sw.WriteLine("<td>MontouxTest_injon                      </td> ");
                    sw.WriteLine("<td>" + dt.Rows[i]["Bm_MontouxTest_injon"].ToString() + "</td>");
                }
                sw.WriteLine("</tr>");

                if (dt.Rows[i]["Bm_MontouxTest_readon"].ToString() != "")
                {
                    sw.WriteLine("<td>MontouxTest_readon                     </td> ");
                    sw.WriteLine("<td>" + dt.Rows[i]["Bm_MontouxTest_readon"].ToString() + "</td>");
                }
                sw.WriteLine("</tr>");

                if (dt.Rows[i]["Bm_MontouxTest_induration"].ToString() != "")
                {
                    sw.WriteLine("<td>MontouxTest_induration                      </td> ");
                    sw.WriteLine("<td>" + dt.Rows[i]["Bm_MontouxTest_induration"].ToString() + "</td>");
                }
                sw.WriteLine("</tr>");



                if (dt.Rows[i]["Bw_Widaltest"].ToString() != "")
                {
                    sw.WriteLine("<td>Widaltest                      </td> ");
                    sw.WriteLine("<td>" + dt.Rows[i]["Bw_Widaltest"].ToString() + "</td>");
                }
                sw.WriteLine("</tr>");      
            
            
            
            
            
            
            
            
            
            }
            sw.WriteLine("</table>");
            sw.Close();
            fs.Close();
            System.Diagnostics.Process.Start("D:/pathology/Bloodhtml.Doc");

        }
    }
}