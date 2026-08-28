-- =====================================================
-- Pathology Lab Software - Database Tables Setup
-- Run this AFTER running 01_create_database.sql
-- =====================================================
USE [pathology2627];
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='account_master')
CREATE TABLE [account_master] (
    [acode] INT IDENTITY(1,1) NOT NULL,
    [aname] NVARCHAR(200) NULL,
    [atype] NVARCHAR(100) NULL,
    [opbal] FLOAT NULL,
    [drcrflag] NVARCHAR(2) NULL,
    [partyId] INT NULL,
    [acdes] NVARCHAR(300) NULL,
    [grpname] NVARCHAR(200) NULL,
    [gcd] INT NULL,
    [s_group] NVARCHAR(100) NULL,
    [scd] INT NULL,
    [add1] NVARCHAR(300) NULL,
    [city] NVARCHAR(100) NULL,
    [pin] INT NULL,
    [zone] NVARCHAR(100) NULL,
    [phone] NVARCHAR(50) NULL,
    [fax] NVARCHAR(50) NULL,
    [email] NVARCHAR(200) NULL,
    [vatno] NVARCHAR(50) NULL,
    [cstno] NVARCHAR(50) NULL,
    [dl_no] NVARCHAR(50) NULL,
    [opening_bal] FLOAT NULL,
    [closing_bal] FLOAT NULL,
    [temp_bal] FLOAT NULL,
    [dr_cr] NVARCHAR(5) NULL,
    [stag] INT NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='bill')
CREATE TABLE [bill] (
    [billno] INT IDENTITY(1,1) NOT NULL,
    [pcode] INT NULL,
    [patient_name] NVARCHAR(200) NULL,
    [date_exam] DATETIME NULL,
    [gross] FLOAT NULL,
    [disc] FLOAT NULL,
    [adv] FLOAT NULL,
    [balance] FLOAT NULL,
    [month_year] NVARCHAR(20) NULL,
    [cc] INT NULL,
    [del_tag] INT NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='bill2')
CREATE TABLE [bill2] (
    [billno] INT IDENTITY(1,1) NOT NULL,
    [pcode] INT NULL,
    [patient_name] NVARCHAR(200) NULL,
    [date_exam] DATETIME NULL,
    [test] NVARCHAR(200) NULL,
    [price] FLOAT NULL,
    [gross] FLOAT NULL,
    [disc] FLOAT NULL,
    [adv] FLOAT NULL,
    [balance] FLOAT NULL,
    [month_year] NVARCHAR(20) NULL,
    [cc] INT NULL,
    [del_tag] INT NULL,
    [test_date] NVARCHAR(30) NULL,
    [o_s] NVARCHAR(10) NULL,
    [name] NVARCHAR(200) NULL,
    [dt_discharge] NVARCHAR(30) NULL,
    [treatment_given] NVARCHAR(500) NULL,
    [srlno] INT NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='billl')
CREATE TABLE [billl] (
    [srlno] INT IDENTITY(1,1) NOT NULL,
    [pcode] INT NULL,
    [test_date] DATETIME NULL,
    [test] NVARCHAR(200) NULL,
    [price] FLOAT NULL,
    [o_s] NVARCHAR(100) NULL,
    [gross] FLOAT NULL,
    [disc] FLOAT NULL,
    [adv] FLOAT NULL,
    [balance] FLOAT NULL,
    [osc] NVARCHAR(100) NULL,
    [month_year] NVARCHAR(20) NULL,
    [cc] INT NULL,
    [del_tag] INT NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Biochemist')
CREATE TABLE [Biochemist] (
    [bcid] INT IDENTITY(1,1) NOT NULL,
    [cc] INT NULL,
    [pcode] INT NULL,
    [Bcr1_Glucose_Fpg_RPG] NVARCHAR(50) NULL,
    [Bcr1_PPPG_PGPG_2hr] NVARCHAR(50) NULL,
    [Bcr1_PPPG_PGPG_1hr] NVARCHAR(50) NULL,
    [Bcr1_RBS] NVARCHAR(50) NULL,
    [Bcr1_PBBS] NVARCHAR(50) NULL,
    [Bcr1_PLBS] NVARCHAR(50) NULL,
    [Bcr1_GTT_1hr] NVARCHAR(50) NULL,
    [Bcr1_GTT_2hr] NVARCHAR(50) NULL,
    [Bcr1_GTT_3hr] NVARCHAR(50) NULL,
    [Bcr1_PGBS_1hr] NVARCHAR(50) NULL,
    [Bcr1_PGBS_2hr] NVARCHAR(50) NULL,
    [Bcr1_HBAC_fair] NVARCHAR(50) NULL,
    [Bcr1_HBAC_good] NVARCHAR(50) NULL,
    [Bcr1_HBAC_poor] NVARCHAR(50) NULL,
    [Bcr1_MBGE] NVARCHAR(50) NULL,
    [Bcr_RP_Urea] NVARCHAR(50) NULL,
    [Bcr_RP_BUN] NVARCHAR(50) NULL,
    [Bcr_RP_Creatinine] NVARCHAR(50) NULL,
    [Bcr3_NPN] NVARCHAR(50) NULL,
    [Bcr3_Uric_Acid] NVARCHAR(50) NULL,
    [Bcr_LP_Cholesterol] NVARCHAR(50) NULL,
    [Bcr_LP_HDLCholesterol] NVARCHAR(50) NULL,
    [Bcr_LP_LDLCholesterol] NVARCHAR(50) NULL,
    [Bcr_LP_VLDLCholesterol] NVARCHAR(50) NULL,
    [Bcr_LP_Triglycerides] NVARCHAR(50) NULL,
    [Bcr2_LP_CHR] NVARCHAR(50) NULL,
    [Bcr2_LP_LHR] NVARCHAR(50) NULL,
    [Bcr_LFT_Bilirubin_total] NVARCHAR(50) NULL,
    [Bcr_LFT_Bilirubin_Direct] NVARCHAR(50) NULL,
    [Bcr4_LFT_Indirect] NVARCHAR(50) NULL,
    [Bcr_LFT_Alkaline_Phosphates] NVARCHAR(50) NULL,
    [Bcr_LFT_SGOT_AST] NVARCHAR(50) NULL,
    [Bcr_LFT_SGPT_ALT] NVARCHAR(50) NULL,
    [Bcr_LFT_Albumin] NVARCHAR(50) NULL,
    [Bcr_LFT_Protein] NVARCHAR(50) NULL,
    [Bcr_LFT_Globulin] NVARCHAR(50) NULL,
    [Bcr_LFT_AG_Ratio] NVARCHAR(50) NULL,
    [Bcr4_LFT_GGTP] NVARCHAR(50) NULL,
    [Bcr_Electrolyte_Sodium] NVARCHAR(50) NULL,
    [Bcr_Electrolyte_Potassium] NVARCHAR(50) NULL,
    [Bcr5_Electrolyte_Chlorides] NVARCHAR(50) NULL,
    [Bcr_OTH_Acid_Phosphate] NVARCHAR(50) NULL,
    [Bcr_OTH_Amylase] NVARCHAR(50) NULL,
    [Bcr_OTH_Acid_Calcium] NVARCHAR(50) NULL,
    [Bcr_OTH_Acid_Phosphorus] NVARCHAR(50) NULL,
    [Bcr_OTH_Uric_Acid] NVARCHAR(50) NULL,
    [Bcr_OTH_Pasting_urine_sugar] NVARCHAR(50) NULL,
    [Bcr_OTH_PP_PG_urine_sugar] NVARCHAR(50) NULL,
    [db_imp] NVARCHAR(1000) NULL,
    [Bcr_OTH_Lipase] NVARCHAR(50) NULL,
    [Bcr_OTH_Nac] NVARCHAR(50) NULL,
    [month_year] NVARCHAR(20) NULL,
    [del_tag] INT NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='biochemistext')
CREATE TABLE [biochemistext] (
    [biec] INT IDENTITY(1,1) NOT NULL,
    [pcode] INT NULL,
    [test] NVARCHAR(200) NULL,
    [method] NVARCHAR(200) NULL,
    [result] NVARCHAR(200) NULL,
    [unit] NVARCHAR(100) NULL,
    [normal_range] NVARCHAR(200) NULL,
    [month_year] NVARCHAR(20) NULL,
    [del_tag] INT NULL,
    [cc] INT NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Blood')
CREATE TABLE [Blood] (
    [bid] INT IDENTITY(1,1) NOT NULL,
    [cc] INT NULL,
    [pcode] INT NULL,
    [BG_Blood_Group] NVARCHAR(50) NULL,
    [BR_RhD_Typing] NVARCHAR(50) NULL,
    [BDc_Neutrophild] NVARCHAR(50) NULL,
    [BDc_Eosinophils] NVARCHAR(50) NULL,
    [BDc_Lymphocytes] NVARCHAR(50) NULL,
    [BDc_Basophils] NVARCHAR(50) NULL,
    [BDc_Monocytes] NVARCHAR(50) NULL,
    [BDc_Twbc] NVARCHAR(50) NULL,
    [BDc_Trbc] NVARCHAR(50) NULL,
    [BDc_Tplatelets] NVARCHAR(50) NULL,
    [BDc_Aec] NVARCHAR(50) NULL,
    [BDc_Tnc] NVARCHAR(50) NULL,
    [BDc_Reticulocyte_Count] NVARCHAR(50) NULL,
    [BDc_PCV] NVARCHAR(50) NULL,
    [BDC_mcv] NVARCHAR(50) NULL,
    [BDC_mch] NVARCHAR(50) NULL,
    [BDC_mchc] NVARCHAR(50) NULL,
    [BDc_Pss] NVARCHAR(200) NULL,
    [BDc_Mp_ICT_QBC_Smear] NVARCHAR(50) NULL,
    [BDc_Mp_ICT] NVARCHAR(50) NULL,
    [BDc_Mf_ICT_QBC_Smear] NVARCHAR(50) NULL,
    [BDc_Mf_ICT] NVARCHAR(50) NULL,
    [Bdc_Rct] NVARCHAR(50) NULL,
    [BDc_Hb] NVARCHAR(50) NULL,
    [BDc_ESR_1sthour] NVARCHAR(50) NULL,
    [BDc_Bleeding_Time] NVARCHAR(50) NULL,
    [BDc_Clotting_Time] NVARCHAR(50) NULL,
    [BDC_nasalsmear] NVARCHAR(200) NULL,
    [BDC_nasalsmear_right] NVARCHAR(200) NULL,
    [BDc_Sickle_cell] NVARCHAR(50) NULL,
    [BDC_prothombintime] NVARCHAR(50) NULL,
    [BDC_prothombintime_cont] NVARCHAR(50) NULL,
    [BPS_Toxo] NVARCHAR(50) NULL,
    [BPS_Crp] NVARCHAR(50) NULL,
    [BPS_Vdrl] NVARCHAR(50) NULL,
    [BPS_Ana] NVARCHAR(50) NULL,
    [BPS_Rafactor] NVARCHAR(50) NULL,
    [BPS_Aso] NVARCHAR(50) NULL,
    [BS_Australia_Antigen] NVARCHAR(50) NULL,
    [BS_Hepatitis_C_Virus] NVARCHAR(50) NULL,
    [BS_HIV_1] NVARCHAR(50) NULL,
    [BS_HIV_2] NVARCHAR(50) NULL,
    [Bw_Widaltubeo80] NVARCHAR(50) NULL,
    [Bw_Widaltubeo160] NVARCHAR(50) NULL,
    [Bw_Widaltubeo320] NVARCHAR(50) NULL,
    [Bw_Widaltubeh80] NVARCHAR(50) NULL,
    [Bw_Widaltubeh160] NVARCHAR(50) NULL,
    [Bw_Widaltubeh320] NVARCHAR(50) NULL,
    [Bw_Widaltubeah80] NVARCHAR(50) NULL,
    [Bw_Widaltubeah160] NVARCHAR(50) NULL,
    [Bw_Widaltubeah320] NVARCHAR(50) NULL,
    [Bw_Widaltubebh80] NVARCHAR(50) NULL,
    [Bw_Widaltubebh160] NVARCHAR(50) NULL,
    [Bw_Widaltubebh320] NVARCHAR(50) NULL,
    [Bw_Widalslide1] NVARCHAR(50) NULL,
    [Bw_Widalslide2] NVARCHAR(50) NULL,
    [Bw_Widalslide3] NVARCHAR(50) NULL,
    [Bw_Widalslide4] NVARCHAR(50) NULL,
    [Bw_mycodot] NVARCHAR(50) NULL,
    [bw_trop] NVARCHAR(50) NULL,
    [Bm_MontouxTest_injon] NVARCHAR(50) NULL,
    [Bm_MontouxTest_readon] NVARCHAR(50) NULL,
    [Bm_MontouxTest_induration] NVARCHAR(50) NULL,
    [BDC_prothombintime_inr] NVARCHAR(50) NULL,
    [BDc_ESR_2ndhour] NVARCHAR(50) NULL,
    [BDc_Dengue] NVARCHAR(50) NULL,
    [BDc_typhicheck] NVARCHAR(50) NULL,
    [bl_imp] NVARCHAR(1000) NULL,
    [BDc_Rcdw] NVARCHAR(50) NULL,
    [BDc_MPV] NVARCHAR(50) NULL,
    [BDc_PDW] NVARCHAR(50) NULL,
    [BDc_Mp_ICT_slide] NVARCHAR(50) NULL,
    [BPS_Aso_qty] NVARCHAR(50) NULL,
    [BPS_Crp_qty] NVARCHAR(50) NULL,
    [BPS_Rafactor_qty] NVARCHAR(50) NULL,
    [Bw_Trop_qty] NVARCHAR(50) NULL,
    [BDc_MP_ICT_QBC_METHOD] NVARCHAR(50) NULL,
    [month_year] NVARCHAR(20) NULL,
    [del_tag] INT NULL,
    [Bw_Widaltubeo240] NVARCHAR(100) NULL,
    [Bw_Widaltubeo480] NVARCHAR(100) NULL,
    [Bw_Widaltubeh240] NVARCHAR(100) NULL,
    [Bw_Widaltubeh480] NVARCHAR(100) NULL,
    [Bw_Widaltubeah240] NVARCHAR(100) NULL,
    [Bw_Widaltubeah480] NVARCHAR(100) NULL,
    [Bw_Widaltubebh240] NVARCHAR(100) NULL,
    [Bw_Widaltubebh480] NVARCHAR(100) NULL,
    [BDc_Dengue_NSI] NVARCHAR(100) NULL,
    [ser_imp] NVARCHAR(100) NULL,
    [sr_afp] NVARCHAR(100) NULL,
    [SR_ASA] NVARCHAR(100) NULL,
    [SR_CV_IGG] NVARCHAR(100) NULL,
    [SR_CV_IGM] NVARCHAR(100) NULL,
    [SR_HSV_IGG] NVARCHAR(100) NULL,
    [SR_HSV_IGM] NVARCHAR(100) NULL,
    [SR_RV_IGG] NVARCHAR(100) NULL,
    [SR_RV_IGM] NVARCHAR(100) NULL,
    [SR_HBSA] NVARCHAR(100) NULL,
    [SR_AHBSAT] NVARCHAR(100) NULL,
    [SR_HBEA] NVARCHAR(100) NULL,
    [SR_AHBEAT] NVARCHAR(100) NULL,
    [sr_ahbca_igm] NVARCHAR(100) NULL,
    [sr_ahbcat] NVARCHAR(100) NULL,
    [SR_AHAV_IGM] NVARCHAR(100) NULL,
    [SR_AHAVT] NVARCHAR(100) NULL,
    [SR_AHCVT] NVARCHAR(100) NULL,
    [SR_AHEV_IGM] NVARCHAR(100) NULL,
    [sr_hp_igg] NVARCHAR(100) NULL,
    [sr_hp_igm] NVARCHAR(100) NULL,
    [sr_hp_iga] NVARCHAR(100) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='bloodext')
CREATE TABLE [bloodext] (
    [bec] INT IDENTITY(1,1) NOT NULL,
    [pcode] INT NULL,
    [test] NVARCHAR(200) NULL,
    [method] NVARCHAR(200) NULL,
    [result] NVARCHAR(200) NULL,
    [unit] NVARCHAR(100) NULL,
    [normal_range] NVARCHAR(200) NULL,
    [month_year] NVARCHAR(20) NULL,
    [del_tag] INT NULL,
    [cc] INT NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Body_fluid_analysis')
CREATE TABLE [Body_fluid_analysis] (
    [bfid] INT IDENTITY(1,1) NOT NULL,
    [cc] INT NULL,
    [pcode] INT NULL,
    [Specimen] NVARCHAR(200) NULL,
    [Qty] NVARCHAR(100) NULL,
    [Appearance] NVARCHAR(200) NULL,
    [Color] NVARCHAR(100) NULL,
    [ClotFormation] NVARCHAR(100) NULL,
    [Sugar] NVARCHAR(100) NULL,
    [Microprotein] NVARCHAR(100) NULL,
    [Neutrophil] NVARCHAR(100) NULL,
    [Lymphocyte] NVARCHAR(100) NULL,
    [Total_cell_count] NVARCHAR(100) NULL,
    [Rbc] NVARCHAR(100) NULL,
    [Malignant_Cell] NVARCHAR(100) NULL,
    [Impression] NVARCHAR(1000) NULL,
    [abnormal_cell] NVARCHAR(500) NULL,
    [month_year] NVARCHAR(20) NULL,
    [del_tag] INT NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Body_fluid_analysisext')
CREATE TABLE [Body_fluid_analysisext] (
    [bfaec] INT IDENTITY(1,1) NOT NULL,
    [cc] INT NULL,
    [pcode] INT NULL,
    [test] NVARCHAR(200) NULL,
    [method] NVARCHAR(200) NULL,
    [result] NVARCHAR(200) NULL,
    [unit] NVARCHAR(100) NULL,
    [normal_range] NVARCHAR(200) NULL,
    [month_year] NVARCHAR(20) NULL,
    [del_tag] NVARCHAR(5) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='cbj')
CREATE TABLE [cbj] (
    [cbno] INT IDENTITY(1,1) NOT NULL,
    [cbdt] DATETIME NULL,
    [narration] NVARCHAR(500) NULL,
    [month_year] NVARCHAR(20) NULL,
    [cc] INT NULL,
    [Trncd] NVARCHAR(100) NULL,
    [Vodt] DATETIME NULL,
    [Vono] NVARCHAR(50) NULL,
    [acdes] NVARCHAR(300) NULL,
    [dcin] NVARCHAR(5) NULL,
    [Amt] FLOAT NULL,
    [narr] NVARCHAR(500) NULL,
    [chno] NVARCHAR(50) NULL,
    [chdt] DATETIME NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='cbjopd')
CREATE TABLE [cbjopd] (
    [cbopd_id] INT IDENTITY(1,1) NOT NULL,
    [cbdt] DATETIME NULL,
    [narration] NVARCHAR(200) NULL,
    [month_year] NVARCHAR(20) NULL,
    [cc] INT NULL,
    [Trncd] NVARCHAR(20) NULL,
    [Vodt] NVARCHAR(20) NULL,
    [Vono] NVARCHAR(20) NULL,
    [acdes] NVARCHAR(100) NULL,
    [dcin] NVARCHAR(5) NULL,
    [Amt] FLOAT NULL,
    [narr] NVARCHAR(200) NULL,
    [chno] NVARCHAR(20) NULL,
    [chdt] NVARCHAR(20) NULL,
    [pcode] INT NULL,
    [referal] NVARCHAR(100) NULL,
    [doctor] NVARCHAR(100) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='company')
CREATE TABLE [company] (
    [Cc] INT IDENTITY(1,1) NOT NULL,
    [Comp] NVARCHAR(200) NULL,
    [Address] NVARCHAR(300) NULL,
    [Address1] NVARCHAR(300) NULL,
    [TELPHONENO] NVARCHAR(50) NULL,
    [FAXNO] NVARCHAR(50) NULL,
    [Vatno] NVARCHAR(50) NULL,
    [cstno] NVARCHAR(50) NULL,
    [Pathologist] NVARCHAR(200) NULL,
    [Biochemist] NVARCHAR(200) NULL,
    [email] NVARCHAR(200) NULL,
    [year_start] NVARCHAR(50) NULL,
    [year_end] NVARCHAR(50) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Culture')
CREATE TABLE [Culture] (
    [pcode] INT NULL,
    [sample_type] NVARCHAR(100) NULL,
    [organism] NVARCHAR(200) NULL,
    [colony_count] NVARCHAR(100) NULL,
    [sensitivity] NVARCHAR(200) NULL,
    [resistance] NVARCHAR(200) NULL,
    [impression] NVARCHAR(500) NULL,
    [month_year] NVARCHAR(20) NULL,
    [del_tag] INT NULL,
    [cc] INT NULL,
    [amoxicillin] NVARCHAR(50) NULL,
    [amoxicillin_no] NVARCHAR(50) NULL,
    [amoxicillin_srm] NVARCHAR(50) NULL,
    [amoxicillin_sm] NVARCHAR(50) NULL,
    [ampicillin] NVARCHAR(50) NULL,
    [ampicillin_no] NVARCHAR(50) NULL,
    [ampicillin_srm] NVARCHAR(50) NULL,
    [ampicillin_sm] NVARCHAR(50) NULL,
    [amikacin] NVARCHAR(50) NULL,
    [amikacin_no] NVARCHAR(50) NULL,
    [amikacin_srm] NVARCHAR(50) NULL,
    [amikacin_sm] NVARCHAR(50) NULL,
    [cephalexin] NVARCHAR(50) NULL,
    [cephalexin_no] NVARCHAR(50) NULL,
    [cephalexin_srm] NVARCHAR(50) NULL,
    [cephalexin_sm] NVARCHAR(50) NULL,
    [ceftazidime] NVARCHAR(50) NULL,
    [ceftazidime_no] NVARCHAR(50) NULL,
    [ceftazidime_srm] NVARCHAR(50) NULL,
    [ceftazidime_sm] NVARCHAR(50) NULL,
    [ceftriaxone] NVARCHAR(50) NULL,
    [ceftriaxone_no] NVARCHAR(50) NULL,
    [ceftriaxone_srm] NVARCHAR(50) NULL,
    [ceftriaxone_sm] NVARCHAR(50) NULL,
    [cloxacillin] NVARCHAR(50) NULL,
    [cloxacillin_no] NVARCHAR(50) NULL,
    [cloxacillin_srm] NVARCHAR(50) NULL,
    [cloxacillin_sm] NVARCHAR(50) NULL,
    [co_trimoxazole] NVARCHAR(50) NULL,
    [co_trimoxazole_no] NVARCHAR(50) NULL,
    [co_trimoxazole_srm] NVARCHAR(50) NULL,
    [co_trimoxazole_sm] NVARCHAR(50) NULL,
    [cefazolin] NVARCHAR(50) NULL,
    [cefazolin_no] NVARCHAR(50) NULL,
    [cefazolin_srm] NVARCHAR(50) NULL,
    [cefazolin_sm] NVARCHAR(50) NULL,
    [cefotaxime] NVARCHAR(50) NULL,
    [cefotaxime_no] NVARCHAR(50) NULL,
    [cefotaxime_srm] NVARCHAR(50) NULL,
    [cefotaxime_sm] NVARCHAR(50) NULL,
    [ciprofloxacin] NVARCHAR(50) NULL,
    [ciprofloxacin_no] NVARCHAR(50) NULL,
    [ciprofloxacin_srm] NVARCHAR(50) NULL,
    [ciprofloxacin_sm] NVARCHAR(50) NULL,
    [doxycycline] NVARCHAR(50) NULL,
    [doxycycline_no] NVARCHAR(50) NULL,
    [doxycycline_srm] NVARCHAR(50) NULL,
    [doxycycline_sm] NVARCHAR(50) NULL,
    [erythromycin] NVARCHAR(50) NULL,
    [erythromycin_no] NVARCHAR(50) NULL,
    [erythromycin_srm] NVARCHAR(50) NULL,
    [erythromycin_sm] NVARCHAR(50) NULL,
    [gentamycin] NVARCHAR(50) NULL,
    [gentamycin_no] NVARCHAR(50) NULL,
    [gentamycin_srm] NVARCHAR(50) NULL,
    [gentamycin_sm] NVARCHAR(50) NULL,
    [gemifloxacin] NVARCHAR(50) NULL,
    [gemifloxacin_no] NVARCHAR(50) NULL,
    [gemifloxacin_srm] NVARCHAR(50) NULL,
    [gemifloxacin_sm] NVARCHAR(50) NULL,
    [neomycin] NVARCHAR(50) NULL,
    [neomycin_no] NVARCHAR(50) NULL,
    [neomycin_srm] NVARCHAR(50) NULL,
    [neomycin_sm] NVARCHAR(50) NULL,
    [nitrofurantion] NVARCHAR(50) NULL,
    [nitrofurantion_no] NVARCHAR(50) NULL,
    [nitrofurantion_srm] NVARCHAR(50) NULL,
    [nitrofurantion_sm] NVARCHAR(50) NULL,
    [norfloxacine] NVARCHAR(50) NULL,
    [norfloxacine_no] NVARCHAR(50) NULL,
    [norfloxacine_srm] NVARCHAR(50) NULL,
    [norfloxacine_sm] NVARCHAR(50) NULL,
    [netromycin] NVARCHAR(50) NULL,
    [netromycin_no] NVARCHAR(50) NULL,
    [netromycin_srm] NVARCHAR(50) NULL,
    [netromycin_sm] NVARCHAR(50) NULL,
    [ofloxacin] NVARCHAR(50) NULL,
    [ofloxacin_no] NVARCHAR(50) NULL,
    [ofloxacin_srm] NVARCHAR(50) NULL,
    [ofloxacin_sm] NVARCHAR(50) NULL,
    [piperacillin] NVARCHAR(50) NULL,
    [piperacillin_no] NVARCHAR(50) NULL,
    [piperacillin_srm] NVARCHAR(50) NULL,
    [piperacillin_sm] NVARCHAR(50) NULL,
    [pencillin] NVARCHAR(50) NULL,
    [pencillin_no] NVARCHAR(50) NULL,
    [pencillin_srm] NVARCHAR(50) NULL,
    [pencillin_sm] NVARCHAR(50) NULL,
    [streptomycin] NVARCHAR(50) NULL,
    [streptomycin_no] NVARCHAR(50) NULL,
    [streptomycin_srm] NVARCHAR(50) NULL,
    [streptomycin_sm] NVARCHAR(50) NULL,
    [tetracycline] NVARCHAR(50) NULL,
    [tetracycline_no] NVARCHAR(50) NULL,
    [tetracycline_srm] NVARCHAR(50) NULL,
    [tetracycline_sm] NVARCHAR(50) NULL,
    [roxythromycin] NVARCHAR(50) NULL,
    [roxythromycin_no] NVARCHAR(50) NULL,
    [roxythromycin_srm] NVARCHAR(50) NULL,
    [roxythromycin_sm] NVARCHAR(50) NULL,
    [cefoperazone] NVARCHAR(50) NULL,
    [cefoperazone_no] NVARCHAR(50) NULL,
    [cefoperazone_srm] NVARCHAR(50) NULL,
    [cefoperazone_sm] NVARCHAR(50) NULL,
    [levofloxacin] NVARCHAR(50) NULL,
    [levofloxacin_no] NVARCHAR(50) NULL,
    [levofloxacin_srm] NVARCHAR(50) NULL,
    [levofloxacin_sm] NVARCHAR(50) NULL,
    [gatifloxacin] NVARCHAR(50) NULL,
    [gatifloxacin_no] NVARCHAR(50) NULL,
    [gatifloxacin_srm] NVARCHAR(50) NULL,
    [gatifloxacin_sm] NVARCHAR(50) NULL,
    [tazobactum] NVARCHAR(50) NULL,
    [tazobactum_no] NVARCHAR(50) NULL,
    [tazobactum_srm] NVARCHAR(50) NULL,
    [tazobactum_sm] NVARCHAR(50) NULL,
    [tobramycin] NVARCHAR(50) NULL,
    [tobramycin_no] NVARCHAR(50) NULL,
    [tobramycin_srm] NVARCHAR(50) NULL,
    [tobramycin_sm] NVARCHAR(50) NULL,
    [cefixime] NVARCHAR(50) NULL,
    [cefixime_no] NVARCHAR(50) NULL,
    [cefixime_srm] NVARCHAR(50) NULL,
    [cefixime_sm] NVARCHAR(50) NULL,
    [organism_isolated] NVARCHAR(200) NULL,
    [cu_imp] NVARCHAR(200) NULL,
    [cu_sample_type] NVARCHAR(200) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='CULTURE_colonycount')
CREATE TABLE [CULTURE_colonycount] (
    [ccc] INT IDENTITY(1,1) NOT NULL,
    [test] NVARCHAR(200) NULL,
    [method] NVARCHAR(200) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='CULTURE_master')
CREATE TABLE [CULTURE_master] (
    [cmc] INT IDENTITY(1,1) NOT NULL,
    [test] NVARCHAR(200) NULL,
    [method] NVARCHAR(200) NULL,
    [unit] NVARCHAR(200) NULL,
    [reference_range] NVARCHAR(200) NULL,
    [price] NVARCHAR(200) NULL,
    [grp] NVARCHAR(200) NULL,
    [sgrp] NVARCHAR(200) NULL,
    [range_from] NVARCHAR(200) NULL,
    [range_to] NVARCHAR(200) NULL,
    [ttype] NVARCHAR(200) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='CULTURE_organism')
CREATE TABLE [CULTURE_organism] (
    [coc] INT IDENTITY(1,1) NOT NULL,
    [test] NVARCHAR(200) NULL,
    [culture] NVARCHAR(200) NULL,
    [method] NVARCHAR(200) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='CULTURE_type')
CREATE TABLE [CULTURE_type] (
    [ctc] INT IDENTITY(1,1) NOT NULL,
    [test] NVARCHAR(200) NULL,
    [method] NVARCHAR(200) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='cultureext')
CREATE TABLE [cultureext] (
    [cec] INT IDENTITY(1,1) NOT NULL,
    [cc] INT NULL,
    [pcode] INT NULL,
    [antibiotic] NVARCHAR(200) NULL,
    [antibiotics] NVARCHAR(200) NULL,
    [antibioticv] NVARCHAR(200) NULL,
    [organism_isolated] NVARCHAR(200) NULL,
    [cu_imp] NVARCHAR(500) NULL,
    [test] NVARCHAR(200) NULL,
    [colony_count] NVARCHAR(100) NULL,
    [month_year] NVARCHAR(20) NULL,
    [del_tag] INT NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Cytology')
CREATE TABLE [Cytology] (
    [cyid] INT IDENTITY(1,1) NOT NULL,
    [cc] INT NULL,
    [pcode] INT NULL,
    [Specimen] NVARCHAR(300) NULL,
    [Benign_Cell] NVARCHAR(200) NULL,
    [Endocervical_Cell] NVARCHAR(200) NULL,
    [Inflammatory_Cell] NVARCHAR(200) NULL,
    [Trichomonas] NVARCHAR(200) NULL,
    [Monilia] NVARCHAR(200) NULL,
    [Endometrial_Cell] NVARCHAR(200) NULL,
    [Spermatozoa] NVARCHAR(200) NULL,
    [Rbc] NVARCHAR(100) NULL,
    [Dysplastic_Cell] NVARCHAR(200) NULL,
    [Malignant_Cell] NVARCHAR(200) NULL,
    [Others] NVARCHAR(500) NULL,
    [Impression] NVARCHAR(1000) NULL,
    [month_year] NVARCHAR(20) NULL,
    [del_tag] INT NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Cytologyext')
CREATE TABLE [Cytologyext] (
    [cyec] INT IDENTITY(1,1) NOT NULL,
    [cc] INT NULL,
    [pcode] INT NULL,
    [test] NVARCHAR(200) NULL,
    [method] NVARCHAR(200) NULL,
    [result] NVARCHAR(200) NULL,
    [unit] NVARCHAR(100) NULL,
    [normal_range] NVARCHAR(200) NULL,
    [month_year] NVARCHAR(20) NULL,
    [del_tag] NVARCHAR(5) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Doctor')
CREATE TABLE [Doctor] (
    [Dc] INT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(200) NULL,
    [Address] NVARCHAR(300) NULL,
    [Phone] NVARCHAR(50) NULL,
    [Comm] FLOAT NULL,
    [Cc] INT NULL,
    [TELPHONENO] NVARCHAR(50) NULL,
    [FAXNO] NVARCHAR(50) NULL,
    [pathologist] NVARCHAR(200) NULL,
    [Biochemist] NVARCHAR(200) NULL,
    [doctper] FLOAT NULL,
    [temp_bal] FLOAT NULL,
    [stag] INT NULL,
    [opening_bal] FLOAT NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Group_master')
CREATE TABLE [Group_master] (
    [gcode] INT IDENTITY(1,1) NOT NULL,
    [grp] NVARCHAR(200) NULL,
    [sgrp] NVARCHAR(200) NULL,
    [type] NVARCHAR(100) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='histopathology')
CREATE TABLE [histopathology] (
    [hid] INT IDENTITY(1,1) NOT NULL,
    [cc] INT NULL,
    [pcode] INT NULL,
    [Specimen] NVARCHAR(300) NULL,
    [gross_exam] NVARCHAR(1000) NULL,
    [microscopic] NVARCHAR(1000) NULL,
    [impression] NVARCHAR(1000) NULL,
    [month_year] NVARCHAR(20) NULL,
    [del_tag] INT NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='histopathologyext')
CREATE TABLE [histopathologyext] (
    [hec] INT IDENTITY(1,1) NOT NULL,
    [cc] INT NULL,
    [pcode] INT NULL,
    [test] NVARCHAR(200) NULL,
    [method] NVARCHAR(200) NULL,
    [result] NVARCHAR(200) NULL,
    [unit] NVARCHAR(100) NULL,
    [normal_range] NVARCHAR(200) NULL,
    [month_year] NVARCHAR(20) NULL,
    [del_tag] NVARCHAR(5) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Hormone')
CREATE TABLE [Hormone] (
    [hmid] INT IDENTITY(1,1) NOT NULL,
    [cc] INT NULL,
    [pcode] INT NULL,
    [TOTAL_TRIIODOTHYRONINE_T3] NVARCHAR(50) NULL,
    [TOTAL_THYROXINE_T4] NVARCHAR(50) NULL,
    [TSH] NVARCHAR(50) NULL,
    [FREE_TRIIODOTHYRONINE_FT3] NVARCHAR(50) NULL,
    [FREE_THYROXINE_FT4] NVARCHAR(50) NULL,
    [ANTIMICROSOMAL_ANTIBODY_AMA] NVARCHAR(50) NULL,
    [TOTAL_CHOLESTEROL] NVARCHAR(50) NULL,
    [PROLACTIN_PRL] NVARCHAR(50) NULL,
    [PROSTATESPECIFICANTIGEN_PSA] NVARCHAR(50) NULL,
    [ADENOSINE_DEAMINASE] NVARCHAR(50) NULL,
    [ANTITUBERCULOSIS_TB_IgG] NVARCHAR(50) NULL,
    [ANTITUBERCULOSIS_TB_IgM] NVARCHAR(50) NULL,
    [ANTITUBERCULOSIS_TB_IgA] NVARCHAR(50) NULL,
    [BHCG] NVARCHAR(50) NULL,
    [CA_125] NVARCHAR(50) NULL,
    [ANA] NVARCHAR(50) NULL,
    [hm_imp] NVARCHAR(1000) NULL,
    [month_year] NVARCHAR(20) NULL,
    [del_tag] INT NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='hormoneext')
CREATE TABLE [hormoneext] (
    [hec] INT IDENTITY(1,1) NOT NULL,
    [pcode] INT NULL,
    [test] NVARCHAR(200) NULL,
    [method] NVARCHAR(200) NULL,
    [result] NVARCHAR(200) NULL,
    [unit] NVARCHAR(100) NULL,
    [normal_range] NVARCHAR(200) NULL,
    [month_year] NVARCHAR(20) NULL,
    [del_tag] INT NULL,
    [cc] INT NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Issue')
CREATE TABLE [Issue] (
    [issno] INT IDENTITY(1,1) NOT NULL,
    [issdt] DATETIME NULL,
    [department] NVARCHAR(200) NULL,
    [month_year] NVARCHAR(20) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Issue_detail')
CREATE TABLE [Issue_detail] (
    [issd_id] INT IDENTITY(1,1) NOT NULL,
    [issno] INT NULL,
    [itemid] INT NULL,
    [item] NVARCHAR(200) NULL,
    [qty] FLOAT NULL,
    [rate] FLOAT NULL,
    [amount] FLOAT NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='itmgrp')
CREATE TABLE [itmgrp] (
    [gcd] INT IDENTITY(1,1) NOT NULL,
    [grpname] NVARCHAR(200) NULL,
    [scd] NVARCHAR(200) NULL,
    [s_group] NVARCHAR(200) NULL,
    [sgrpname] NVARCHAR(200) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Masteropd')
CREATE TABLE [Masteropd] (
    [mopdno] INT IDENTITY(1,1) NOT NULL,
    [patient_name] NVARCHAR(200) NULL,
    [age] INT NULL,
    [sex] NVARCHAR(10) NULL,
    [address] NVARCHAR(300) NULL,
    [phone] NVARCHAR(50) NULL,
    [reg_date] DATETIME NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Mrn')
CREATE TABLE [Mrn] (
    [mrnno] INT IDENTITY(1,1) NOT NULL,
    [mrndt] DATETIME NULL,
    [supplier] NVARCHAR(200) NULL,
    [total] FLOAT NULL,
    [month_year] NVARCHAR(20) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Mrn_detail')
CREATE TABLE [Mrn_detail] (
    [mrnd_id] INT IDENTITY(1,1) NOT NULL,
    [mrnno] INT NULL,
    [itemid] INT NULL,
    [item] NVARCHAR(200) NULL,
    [qty] FLOAT NULL,
    [rate] FLOAT NULL,
    [amount] FLOAT NULL,
    [expiry] DATETIME NULL,
    [cc] INT NULL,
    [type] NVARCHAR(100) NULL,
    [blno] NVARCHAR(50) NULL,
    [bldt] DATETIME NULL,
    [acdes] NVARCHAR(300) NULL,
    [child] NVARCHAR(200) NULL,
    [unit] NVARCHAR(50) NULL,
    [gross] FLOAT NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='mrn_master')
CREATE TABLE [mrn_master] (
    [mrn_id] INT IDENTITY(1,1) NOT NULL,
    [cc] INT NULL,
    [mrn] NVARCHAR(50) NULL,
    [pcode] INT NULL,
    [patient_name] NVARCHAR(200) NULL,
    [date_exam] DATETIME NULL,
    [month_year] NVARCHAR(20) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='mstgrp')
CREATE TABLE [mstgrp] (
    [scd] INT IDENTITY(1,1) NOT NULL,
    [gcd] INT NULL,
    [sgrpname] NVARCHAR(200) NULL,
    [s_group] NVARCHAR(100) NULL,
    [grpname] NVARCHAR(200) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='notepad')
CREATE TABLE [notepad] (
    [nid] INT IDENTITY(1,1) NOT NULL,
    [cc] INT NULL,
    [pcode] INT NULL,
    [note] NVARCHAR(200) NULL,
    [note_header] NVARCHAR(500) NULL,
    [note_footer] NVARCHAR(500) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='notepad1')
CREATE TABLE [notepad1] (
    [n1id] INT IDENTITY(1,1) NOT NULL,
    [cc] INT NULL,
    [pcode] INT NULL,
    [note] NVARCHAR(200) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='OPD_Detail')
CREATE TABLE [OPD_Detail] (
    [opdd_id] INT IDENTITY(1,1) NOT NULL,
    [opdno] INT NULL,
    [medicine] NVARCHAR(200) NULL,
    [dose] NVARCHAR(100) NULL,
    [duration] NVARCHAR(50) NULL,
    [instruction] NVARCHAR(200) NULL,
    [cc] INT NULL,
    [pcode] INT NULL,
    [date_exam] DATETIME NULL,
    [test] NVARCHAR(200) NULL,
    [doctor] NVARCHAR(100) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='opd_master')
CREATE TABLE [opd_master] (
    [opdno] INT IDENTITY(1,1) NOT NULL,
    [reg_date] DATETIME NULL,
    [patient_name] NVARCHAR(200) NULL,
    [age] INT NULL,
    [sex] NVARCHAR(10) NULL,
    [address] NVARCHAR(300) NULL,
    [phone] NVARCHAR(50) NULL,
    [doctor] NVARCHAR(200) NULL,
    [diagnosis] NVARCHAR(500) NULL,
    [month_year] NVARCHAR(20) NULL,
    [cc] INT NULL,
    [pcode] INT NULL,
    [Scn] NVARCHAR(50) NULL,
    [Tpt] NVARCHAR(50) NULL,
    [referal] NVARCHAR(100) NULL,
    [date_exam] DATETIME NULL,
    [del_tag] INT NULL,
    [cfees] NVARCHAR(100) NULL,
    [due_amount] NVARCHAR(100) NULL,
    [paid_amount] NVARCHAR(100) NULL,
    [expenditure] NVARCHAR(100) NULL,
    [balance] NVARCHAR(100) NULL,
    [acdes] NVARCHAR(100) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='outsource')
CREATE TABLE [outsource] (
    [osc_id] INT IDENTITY(1,1) NOT NULL,
    [cc] INT NULL,
    [pcode] INT NULL,
    [test] NVARCHAR(200) NULL,
    [method] NVARCHAR(200) NULL,
    [result] NVARCHAR(200) NULL,
    [unit] NVARCHAR(100) NULL,
    [normal_range] NVARCHAR(200) NULL,
    [month_year] NVARCHAR(20) NULL,
    [del_tag] INT NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='outsourceext')
CREATE TABLE [outsourceext] (
    [osec] INT IDENTITY(1,1) NOT NULL,
    [cc] INT NULL,
    [pcode] INT NULL,
    [test] NVARCHAR(200) NULL,
    [method] NVARCHAR(200) NULL,
    [result] NVARCHAR(200) NULL,
    [unit] NVARCHAR(100) NULL,
    [normal_range] NVARCHAR(200) NULL,
    [month_year] NVARCHAR(20) NULL,
    [del_tag] NVARCHAR(5) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='owner')
CREATE TABLE [owner] (
    [oid] INT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(200) NULL,
    [Address] NVARCHAR(300) NULL,
    [Phone] NVARCHAR(50) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='patient_master')
CREATE TABLE [patient_master] (
    [pcode] INT NOT NULL,
    [patient_name] NVARCHAR(200) NULL,
    [age] INT NULL,
    [age_month] INT NULL,
    [age_day] INT NULL,
    [sex] NVARCHAR(10) NULL,
    [address] NVARCHAR(300) NULL,
    [phone] NVARCHAR(50) NULL,
    [doctor] NVARCHAR(200) NULL,
    [referal] NVARCHAR(200) NULL,
    [date_exam] DATETIME NULL,
    [dt_report] DATETIME NULL,
    [month_year] NVARCHAR(20) NULL,
    [scn] NVARCHAR(50) NULL,
    [tpt] NVARCHAR(50) NULL,
    [cc] INT NULL,
    [del_tag] INT NULL,
    [userid] NVARCHAR(50) NULL,
    [outsource] NVARCHAR(200) NULL,
    [email] NVARCHAR(200) NULL,
    [mobile] NVARCHAR(50) NULL,
    [barcode] VARBINARY NULL,
    [due_amount] FLOAT NULL,
    [paid_amount] FLOAT NULL,
    [operator] NVARCHAR(100) NULL,
    [area] NVARCHAR(200) NULL,
    [acdes] NVARCHAR(300) NULL,
    [temp_bal] FLOAT NULL,
    [stag] INT NULL,
    [opening_bal] FLOAT NULL,
    [report_status] NVARCHAR(20) NULL,
    [delivered_on] DATETIME NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='patient_record')
CREATE TABLE [patient_record] (
    [pcode] INT NULL,
    [test] NVARCHAR(200) NULL,
    [price] FLOAT NULL,
    [done] NVARCHAR(10) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='po_details')
CREATE TABLE [po_details] (
    [pod_id] INT IDENTITY(1,1) NOT NULL,
    [pono] INT NULL,
    [itemid] INT NULL,
    [item] NVARCHAR(200) NULL,
    [qty] FLOAT NULL,
    [rate] FLOAT NULL,
    [amount] FLOAT NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='product_master')
CREATE TABLE [product_master] (
    [itemid] INT IDENTITY(1,1) NOT NULL,
    [item] NVARCHAR(200) NULL,
    [type] NVARCHAR(100) NULL,
    [unit] NVARCHAR(50) NULL,
    [reorderqty] FLOAT NULL,
    [opqty] FLOAT NULL,
    [oprate] FLOAT NULL,
    [gcd] INT NULL,
    [scd] INT NULL,
    [grpname] NVARCHAR(200) NULL,
    [sgrpname] NVARCHAR(200) NULL,
    [itemdes] NVARCHAR(200) NULL,
    [opvalue] FLOAT NULL,
    [reorder_qty] FLOAT NULL,
    [unit_s] NVARCHAR(200) NULL,
    [unit_p] NVARCHAR(200) NULL,
    [sale_rate] FLOAT NULL,
    [tempqty] DECIMAL(18,4) NULL,
    [tempvalue] DECIMAL(18,4) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='profile_data')
CREATE TABLE [profile_data] (
    [pdc] INT IDENTITY(1,1) NOT NULL,
    [profile] NVARCHAR(200) NULL,
    [test] NVARCHAR(200) NULL,
    [price] FLOAT NULL,
    [type] NVARCHAR(200) NULL,
    [pcode] INT NULL,
    [method] NVARCHAR(200) NULL,
    [result] NVARCHAR(200) NULL,
    [unit] NVARCHAR(200) NULL,
    [reference_range] NVARCHAR(200) NULL,
    [grp] NVARCHAR(200) NULL,
    [sgrp] NVARCHAR(200) NULL,
    [grp_code] NVARCHAR(200) NULL,
    [srlno] NVARCHAR(200) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='profile_master')
CREATE TABLE [profile_master] (
    [pmc] INT IDENTITY(1,1) NOT NULL,
    [profile] NVARCHAR(200) NULL,
    [price] FLOAT NULL,
    [grp] NVARCHAR(100) NULL,
    [test] NVARCHAR(200) NULL,
    [method] NVARCHAR(200) NULL,
    [unit] NVARCHAR(100) NULL,
    [reference_range] NVARCHAR(300) NULL,
    [grp_code] NVARCHAR(50) NULL,
    [srlno] INT NULL,
    [sgrp] NVARCHAR(100) NULL,
    [type] NVARCHAR(200) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='profile_master_note')
CREATE TABLE [profile_master_note] (
    [pmnc] INT IDENTITY(1,1) NOT NULL,
    [profile] NVARCHAR(200) NULL,
    [note] NVARCHAR(200) NULL,
    [type] NVARCHAR(200) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='profile_note')
CREATE TABLE [profile_note] (
    [pnc] INT IDENTITY(1,1) NOT NULL,
    [pcode] INT NULL,
    [profile] NVARCHAR(200) NULL,
    [note] NVARCHAR(200) NULL,
    [type] NVARCHAR(200) NULL,
    [dt_report] NVARCHAR(30) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Purchase')
CREATE TABLE [Purchase] (
    [pono] INT IDENTITY(1,1) NOT NULL,
    [podt] DATETIME NULL,
    [supplier] NVARCHAR(200) NULL,
    [total] FLOAT NULL,
    [month_year] NVARCHAR(20) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='referal')
CREATE TABLE [referal] (
    [Rc] INT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(200) NULL,
    [Address] NVARCHAR(300) NULL,
    [Phone] NVARCHAR(50) NULL,
    [Comm] FLOAT NULL,
    [Cc] INT NULL,
    [TELPHONENO] NVARCHAR(50) NULL,
    [FAXNO] NVARCHAR(50) NULL,
    [pathologist] NVARCHAR(200) NULL,
    [Biochemist] NVARCHAR(200) NULL,
    [refper] FLOAT NULL,
    [temp_bal] FLOAT NULL,
    [stag] INT NULL,
    [opening_bal] FLOAT NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='reference_master')
CREATE TABLE [reference_master] (
    [rcode] INT IDENTITY(1,1) NOT NULL,
    [test] NVARCHAR(200) NULL,
    [grp] NVARCHAR(100) NULL,
    [sgrp] NVARCHAR(100) NULL,
    [Desc1] NVARCHAR(500) NULL,
    [Desc2] NVARCHAR(500) NULL,
    [unit] NVARCHAR(100) NULL,
    [normal_from] FLOAT NULL,
    [normal_to] FLOAT NULL,
    [normal_text] NVARCHAR(300) NULL,
    [age_from] INT NULL,
    [age_to] INT NULL,
    [sex] NVARCHAR(10) NULL,
    [type] NVARCHAR(100) NULL,
    [method] NVARCHAR(200) NULL,
    [gcode] INT NULL,
    [reference_range] NVARCHAR(300) NULL,
    [range_from] FLOAT NULL,
    [range_to] FLOAT NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='reference_master_bom')
CREATE TABLE [reference_master_bom] (
    [rbcode] INT IDENTITY(1,1) NOT NULL,
    [test] NVARCHAR(200) NULL,
    [desc1] NVARCHAR(500) NULL,
    [desc2] NVARCHAR(500) NULL,
    [unit] NVARCHAR(100) NULL,
    [normal] NVARCHAR(300) NULL,
    [item] NVARCHAR(200) NULL,
    [qty] NVARCHAR(200) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='rutineext')
CREATE TABLE [rutineext] (
    [pcode] INT NULL,
    [field1] NVARCHAR(200) NULL,
    [val1] NVARCHAR(200) NULL,
    [field2] NVARCHAR(200) NULL,
    [val2] NVARCHAR(200) NULL,
    [field3] NVARCHAR(200) NULL,
    [val3] NVARCHAR(200) NULL,
    [field4] NVARCHAR(200) NULL,
    [val4] NVARCHAR(200) NULL,
    [field5] NVARCHAR(200) NULL,
    [val5] NVARCHAR(200) NULL,
    [field6] NVARCHAR(200) NULL,
    [val6] NVARCHAR(200) NULL,
    [field7] NVARCHAR(200) NULL,
    [val7] NVARCHAR(200) NULL,
    [field8] NVARCHAR(200) NULL,
    [val8] NVARCHAR(200) NULL,
    [field9] NVARCHAR(200) NULL,
    [val9] NVARCHAR(200) NULL,
    [field10] NVARCHAR(200) NULL,
    [val10] NVARCHAR(200) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Seminal_Fluid')
CREATE TABLE [Seminal_Fluid] (
    [sfid] INT IDENTITY(1,1) NOT NULL,
    [cc] INT NULL,
    [pcode] INT NULL,
    [FA_Timeofcollection] NVARCHAR(100) NULL,
    [FA_Timeofexamination] NVARCHAR(100) NULL,
    [FA_Timeofliquification] NVARCHAR(100) NULL,
    [FA_Volume] NVARCHAR(100) NULL,
    [FA_Reaction] NVARCHAR(100) NULL,
    [FA_Color] NVARCHAR(100) NULL,
    [FA_Viscocity] NVARCHAR(100) NULL,
    [FA_MP_Prostaticpearls] NVARCHAR(100) NULL,
    [FA_MP_Puscells] NVARCHAR(100) NULL,
    [FA_MP_RBC] NVARCHAR(100) NULL,
    [FA_MP_Epithcells] NVARCHAR(100) NULL,
    [FA_MP_Deformed] NVARCHAR(100) NULL,
    [FA_MT_Active] NVARCHAR(100) NULL,
    [FA_MT_Slugish] NVARCHAR(100) NULL,
    [FA_MT_Dead] NVARCHAR(100) NULL,
    [FA_MT_Totalcount] NVARCHAR(100) NULL,
    [FA_MT_IMP] NVARCHAR(500) NULL,
    [FA_MP_Premature] NVARCHAR(100) NULL,
    [patient_name] NVARCHAR(200) NULL,
    [month_year] NVARCHAR(20) NULL,
    [del_tag] INT NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Seminal_Fluidext')
CREATE TABLE [Seminal_Fluidext] (
    [sfec] INT IDENTITY(1,1) NOT NULL,
    [cc] INT NULL,
    [pcode] INT NULL,
    [test] NVARCHAR(200) NULL,
    [method] NVARCHAR(200) NULL,
    [result] NVARCHAR(200) NULL,
    [unit] NVARCHAR(100) NULL,
    [normal_range] NVARCHAR(200) NULL,
    [month_year] NVARCHAR(20) NULL,
    [del_tag] NVARCHAR(5) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='serologyext')
CREATE TABLE [serologyext] (
    [sec] INT IDENTITY(1,1) NOT NULL,
    [pcode] INT NULL,
    [test] NVARCHAR(200) NULL,
    [method] NVARCHAR(200) NULL,
    [result] NVARCHAR(200) NULL,
    [unit] NVARCHAR(100) NULL,
    [normal_range] NVARCHAR(200) NULL,
    [month_year] NVARCHAR(20) NULL,
    [del_tag] INT NULL,
    [cc] INT NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='setup')
CREATE TABLE [setup] (
    [cc] INT NULL,
    [comp] NVARCHAR(200) NULL,
    [currentuser] NVARCHAR(100) NULL,
    [blno] NVARCHAR(50) NULL,
    [type] NVARCHAR(100) NULL,
    [year_start] NVARCHAR(50) NULL,
    [year_end] NVARCHAR(50) NULL,
    [regno] INT NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='stool')
CREATE TABLE [stool] (
    [pcode] INT NULL,
    [Sp_color] NVARCHAR(50) NULL,
    [Sp_reaction] NVARCHAR(50) NULL,
    [Sp_Mucus] NVARCHAR(50) NULL,
    [SH_OvaHW] NVARCHAR(50) NULL,
    [SH_larva] NVARCHAR(50) NULL,
    [SH_OvaRW] NVARCHAR(50) NULL,
    [SP_EHistolytica] NVARCHAR(50) NULL,
    [SP_ecoli] NVARCHAR(50) NULL,
    [SP_giardia] NVARCHAR(50) NULL,
    [SP_trichomonas] NVARCHAR(50) NULL,
    [SM_rbc_from] NVARCHAR(50) NULL,
    [SM_puscells_from] NVARCHAR(50) NULL,
    [SM_macrophase] NVARCHAR(50) NULL,
    [SM_vegetables] NVARCHAR(50) NULL,
    [SM_yeast] NVARCHAR(50) NULL,
    [SM_crystal] NVARCHAR(50) NULL,
    [SM_fataglobules] NVARCHAR(50) NULL,
    [SM_bacterialflora] NVARCHAR(50) NULL,
    [SH_Others] NVARCHAR(50) NULL,
    [SC_Occultblood] NVARCHAR(50) NULL,
    [SC_Reducingsugar] NVARCHAR(50) NULL,
    [st_imp] NVARCHAR(500) NULL,
    [month_year] NVARCHAR(20) NULL,
    [del_tag] INT NULL,
    [cc] INT NULL,
    [SH_hymen] NVARCHAR(100) NULL,
    [SH_taenia] NVARCHAR(100) NULL,
    [sm_rbc_to] NVARCHAR(100) NULL,
    [sm_puscells_to] NVARCHAR(100) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='stoolext')
CREATE TABLE [stoolext] (
    [stec] INT IDENTITY(1,1) NOT NULL,
    [cc] INT NULL,
    [pcode] INT NULL,
    [test] NVARCHAR(200) NULL,
    [method] NVARCHAR(200) NULL,
    [result] NVARCHAR(200) NULL,
    [unit] NVARCHAR(100) NULL,
    [normal_range] NVARCHAR(200) NULL,
    [month_year] NVARCHAR(20) NULL,
    [del_tag] NVARCHAR(5) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Test_master')
CREATE TABLE [Test_master] (
    [tc] INT IDENTITY(1,1) NOT NULL,
    [test] NVARCHAR(200) NULL,
    [method] NVARCHAR(300) NULL,
    [unit] NVARCHAR(100) NULL,
    [reference_range] NVARCHAR(300) NULL,
    [price] FLOAT NULL,
    [grp] NVARCHAR(100) NULL,
    [sgrp] NVARCHAR(100) NULL,
    [range_from] FLOAT NULL,
    [range_to] FLOAT NULL,
    [ttype] NVARCHAR(100) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='urine')
CREATE TABLE [urine] (
    [pcode] INT NULL,
    [UP_color] NVARCHAR(50) NULL,
    [UP_reaction] NVARCHAR(50) NULL,
    [UP_specificgravity] NVARCHAR(50) NULL,
    [UC_sugar] NVARCHAR(50) NULL,
    [UC_albumin] NVARCHAR(50) NULL,
    [UC_phosphate] NVARCHAR(50) NULL,
    [UC_chyle] NVARCHAR(50) NULL,
    [UC_ketonebodies] NVARCHAR(50) NULL,
    [UC_bilesalts] NVARCHAR(50) NULL,
    [UC_bilepigment] NVARCHAR(50) NULL,
    [UM_puscells] NVARCHAR(50) NULL,
    [UM_epithcells] NVARCHAR(50) NULL,
    [UM_rbc] NVARCHAR(50) NULL,
    [UM_casts] NVARCHAR(50) NULL,
    [UM_crystals] NVARCHAR(50) NULL,
    [UM_bacterial] NVARCHAR(50) NULL,
    [UM_spermatozoa] NVARCHAR(50) NULL,
    [UM_mf_tv] NVARCHAR(50) NULL,
    [UM_others] NVARCHAR(50) NULL,
    [UU_urine_b_hcg] NVARCHAR(50) NULL,
    [UA_urine_albumin] NVARCHAR(50) NULL,
    [UN_nasalsmear] NVARCHAR(50) NULL,
    [ur_imp] NVARCHAR(500) NULL,
    [month_year] NVARCHAR(20) NULL,
    [del_tag] INT NULL,
    [cc] INT NULL,
    [ur_cotinine] NVARCHAR(100) NULL,
    [up_specificgravity_onr] NVARCHAR(100) NULL,
    [UC_php] NVARCHAR(100) NULL,
    [US_SputumAfb] NVARCHAR(100) NULL,
    [UC_Phosphate_onr] NVARCHAR(100) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Urineext')
CREATE TABLE [Urineext] (
    [uec] INT IDENTITY(1,1) NOT NULL,
    [pcode] INT NULL,
    [test] NVARCHAR(200) NULL,
    [method] NVARCHAR(200) NULL,
    [result] NVARCHAR(200) NULL,
    [unit] NVARCHAR(100) NULL,
    [normal_range] NVARCHAR(200) NULL,
    [month_year] NVARCHAR(20) NULL,
    [del_tag] INT NULL,
    [cc] INT NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='usermaster')
CREATE TABLE [usermaster] (
    [userid] NVARCHAR(50) NOT NULL,
    [password] NVARCHAR(100) NULL,
    [username] NVARCHAR(100) NULL,
    [type] NVARCHAR(50) NULL,
    [Designation] NVARCHAR(100) NULL,
    [Date_of_Joining] NVARCHAR(50) NULL,
    [Basic] FLOAT NULL,
    [hra] FLOAT NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='wbs1')
CREATE TABLE [wbs1] (
    [wid] INT IDENTITY(1,1) NOT NULL,
    [baudrate1] NVARCHAR(20) NULL,
    [databits1] NVARCHAR(10) NULL,
    [parity1] NVARCHAR(20) NULL,
    [stopbits1] NVARCHAR(10) NULL,
    [dtrenables11] NVARCHAR(10) NULL,
    [handshake1] NVARCHAR(20) NULL,
    [dtrenables12] NVARCHAR(10) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='weighment')
CREATE TABLE [weighment] (
    [wid] INT IDENTITY(1,1) NOT NULL,
    [Cc] INT NULL,
    [ticket_no] NVARCHAR(50) NULL,
    [vehicle_no] NVARCHAR(50) NULL,
    [transporter] NVARCHAR(200) NULL,
    [vehicle_type] NVARCHAR(100) NULL,
    [productid] NVARCHAR(50) NULL,
    [name] NVARCHAR(200) NULL,
    [do_no] NVARCHAR(50) NULL,
    [do_qty] FLOAT NULL,
    [exp_dt] DATETIME NULL,
    [ChallanWt] FLOAT NULL,
    [Firstwt] FLOAT NULL,
    [Secondwt] FLOAT NULL,
    [netwt] FLOAT NULL,
    [Address] NVARCHAR(300) NULL,
    [type] NVARCHAR(100) NULL,
    [grosswtdate] DATETIME NULL,
    [tarewtdate] DATETIME NULL,
    [accp_wt] FLOAT NULL,
    [chl_dt] DATETIME NULL,
    [chl_no] NVARCHAR(50) NULL,
    [tpno] NVARCHAR(50) NULL,
    [product] NVARCHAR(200) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='xray')
CREATE TABLE [xray] (
    [xid] INT IDENTITY(1,1) NOT NULL,
    [cc] INT NULL,
    [pcode] INT NULL,
    [Specimen] NVARCHAR(300) NULL,
    [gross_exam] NVARCHAR(1000) NULL,
    [microscopic] NVARCHAR(1000) NULL,
    [impression] NVARCHAR(1000) NULL,
    [month_year] NVARCHAR(20) NULL,
    [del_tag] INT NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='xrayext')
CREATE TABLE [xrayext] (
    [xec] INT IDENTITY(1,1) NOT NULL,
    [cc] INT NULL,
    [pcode] INT NULL,
    [test] NVARCHAR(200) NULL,
    [method] NVARCHAR(200) NULL,
    [result] NVARCHAR(200) NULL,
    [unit] NVARCHAR(100) NULL,
    [normal_range] NVARCHAR(200) NULL,
    [month_year] NVARCHAR(20) NULL,
    [del_tag] NVARCHAR(5) NULL
);
GO

