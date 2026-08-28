-- ============================================================
-- Pathology Database Creation Script
-- Database: pathology2627
-- Server:   .\SQLEXPRESS
-- ============================================================

USE master;
GO

-- Drop if already exists
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'pathology2627')
BEGIN
    ALTER DATABASE pathology2627 SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE pathology2627;
END
GO

CREATE DATABASE pathology2627;
GO

USE pathology2627;
GO

-- ============================================================
-- TABLE: company
-- ============================================================
CREATE TABLE company (
    Cc          INT PRIMARY KEY IDENTITY(1,1),
    Comp        NVARCHAR(200),
    Address     NVARCHAR(300),
    Address1    NVARCHAR(300),
    TELPHONENO  NVARCHAR(50),
    FAXNO       NVARCHAR(50),
    Vatno       NVARCHAR(50),
    cstno       NVARCHAR(50),
    year_start  DATETIME,
    year_end    DATETIME,
    Pathologist NVARCHAR(200),
    Biochemist  NVARCHAR(200),
    email       NVARCHAR(200)
);
GO

-- ============================================================
-- TABLE: setup  (application-wide settings, single row)
-- ============================================================
CREATE TABLE setup (
    cc          INT,
    comp        NVARCHAR(200),
    year_start  DATETIME,
    year_end    DATETIME,
    currentuser NVARCHAR(100)
);
GO

-- Insert default setup row
INSERT INTO setup (cc, comp, year_start, year_end, currentuser)
VALUES (1, 'My Pathology Lab', '2026-04-01', '2027-03-31', 'ADMIN');
GO

-- ============================================================
-- TABLE: usermaster
-- ============================================================
CREATE TABLE usermaster (
    userid      NVARCHAR(50) PRIMARY KEY,
    password    NVARCHAR(100),
    username    NVARCHAR(100),
    type        NVARCHAR(50)
);
GO

-- Default admin user  (Login: Admin / Admin)
INSERT INTO usermaster (userid, password, username, type)
VALUES ('Admin', 'Admin', 'Administrator', 'Admin');
GO

-- ============================================================
-- TABLE: Doctor
-- ============================================================
CREATE TABLE Doctor (
    Dc      INT PRIMARY KEY IDENTITY(1,1),
    Name    NVARCHAR(200),
    Address NVARCHAR(300),
    Phone   NVARCHAR(50),
    Comm    FLOAT DEFAULT 0
);
GO

-- ============================================================
-- TABLE: referal
-- ============================================================
CREATE TABLE referal (
    Rc      INT PRIMARY KEY IDENTITY(1,1),
    Name    NVARCHAR(200),
    Address NVARCHAR(300),
    Phone   NVARCHAR(50),
    Comm    FLOAT DEFAULT 0
);
GO

-- ============================================================
-- TABLE: Test_master
-- ============================================================
CREATE TABLE Test_master (
    tc              INT PRIMARY KEY IDENTITY(1,1),
    test            NVARCHAR(200),
    method          NVARCHAR(300),
    unit            NVARCHAR(100),
    reference_range NVARCHAR(300),
    price           FLOAT DEFAULT 0,
    grp             NVARCHAR(100),
    sgrp            NVARCHAR(100),
    range_from      FLOAT DEFAULT 0,
    range_to        FLOAT DEFAULT 0,
    ttype           NVARCHAR(100)
);
GO

-- ============================================================
-- TABLE: Group_master
-- ============================================================
CREATE TABLE Group_master (
    gcode   INT PRIMARY KEY IDENTITY(1,1),
    grp     NVARCHAR(200),
    sgrp    NVARCHAR(200)
);
GO

-- ============================================================
-- TABLE: reference_master
-- ============================================================
CREATE TABLE reference_master (
    rcode       INT PRIMARY KEY IDENTITY(1,1),
    test        NVARCHAR(200),
    grp         NVARCHAR(100),
    sgrp        NVARCHAR(100),
    Desc1       NVARCHAR(500),
    Desc2       NVARCHAR(500),
    unit        NVARCHAR(100),
    normal_from FLOAT DEFAULT 0,
    normal_to   FLOAT DEFAULT 0,
    normal_text NVARCHAR(300),
    age_from    INT DEFAULT 0,
    age_to      INT DEFAULT 150,
    sex         NVARCHAR(10)
);
GO

-- ============================================================
-- TABLE: reference_master_bom
-- ============================================================
CREATE TABLE reference_master_bom (
    rbcode  INT PRIMARY KEY IDENTITY(1,1),
    test    NVARCHAR(200),
    desc1   NVARCHAR(500),
    desc2   NVARCHAR(500),
    unit    NVARCHAR(100),
    normal  NVARCHAR(300)
);
GO

-- ============================================================
-- TABLE: patient_master
-- ============================================================
CREATE TABLE patient_master (
    pcode           INT PRIMARY KEY,
    patient_name    NVARCHAR(200),
    age             INT DEFAULT 0,
    age_month       INT DEFAULT 0,
    age_day         INT DEFAULT 0,
    sex             NVARCHAR(10),
    address         NVARCHAR(300),
    phone           NVARCHAR(50),
    doctor          NVARCHAR(200),
    referal         NVARCHAR(200),
    date_exam       DATETIME,
    dt_report       DATETIME,
    month_year      NVARCHAR(20),
    scn             NVARCHAR(50),
    tpt             NVARCHAR(50),
    cc              INT DEFAULT 1,
    del_tag         INT DEFAULT 0,
    userid          NVARCHAR(50),
    outsource       NVARCHAR(200),
    email           NVARCHAR(200),
    mobile          NVARCHAR(50),
    barcode         VARBINARY(MAX)
);
GO

-- ============================================================
-- TABLE: patient_record
-- ============================================================
CREATE TABLE patient_record (
    pcode   INT,
    test    NVARCHAR(200),
    price   FLOAT DEFAULT 0,
    done    NVARCHAR(10) DEFAULT 'N'
);
GO

-- ============================================================
-- TABLE: billl  (Bill lines)
-- ============================================================
CREATE TABLE billl (
    srlno       INT PRIMARY KEY IDENTITY(1,1),
    pcode       INT,
    test_date   DATETIME,
    test        NVARCHAR(200),
    price       FLOAT DEFAULT 0,
    o_s         NVARCHAR(100),
    gross       FLOAT DEFAULT 0,
    disc        FLOAT DEFAULT 0,
    adv         FLOAT DEFAULT 0,
    balance     FLOAT DEFAULT 0,
    osc         NVARCHAR(100),
    month_year  NVARCHAR(20),
    cc          INT DEFAULT 1,
    del_tag     INT DEFAULT 0
);
GO

-- ============================================================
-- TABLE: bill  (Bill summary header)
-- ============================================================
CREATE TABLE bill (
    billno       INT PRIMARY KEY IDENTITY(1,1),
    pcode        INT,
    patient_name NVARCHAR(200),
    date_exam    DATETIME,
    gross        FLOAT DEFAULT 0,
    disc         FLOAT DEFAULT 0,
    adv          FLOAT DEFAULT 0,
    balance      FLOAT DEFAULT 0,
    month_year   NVARCHAR(20),
    cc           INT DEFAULT 1,
    del_tag      INT DEFAULT 0
);
GO

-- ============================================================
-- TABLE: bill2
-- ============================================================
CREATE TABLE bill2 (
    billno       INT PRIMARY KEY IDENTITY(1,1),
    pcode        INT,
    patient_name NVARCHAR(200),
    date_exam    DATETIME,
    test         NVARCHAR(200),
    price        FLOAT DEFAULT 0,
    gross        FLOAT DEFAULT 0,
    disc         FLOAT DEFAULT 0,
    adv          FLOAT DEFAULT 0,
    balance      FLOAT DEFAULT 0,
    month_year   NVARCHAR(20),
    cc           INT DEFAULT 1,
    del_tag      INT DEFAULT 0
);
GO

-- ============================================================
-- TABLE: Blood (CBC / Haematology)
-- ============================================================
CREATE TABLE Blood (
    pcode               INT,
    Hb                  NVARCHAR(50),
    TLC                 NVARCHAR(50),
    Neutrophils         NVARCHAR(50),
    Lymphocytes         NVARCHAR(50),
    Eosinophils         NVARCHAR(50),
    Monocytes           NVARCHAR(50),
    Basophils           NVARCHAR(50),
    PlateletCount       NVARCHAR(50),
    BleedingTime        NVARCHAR(50),
    ClottingTime        NVARCHAR(50),
    ESR                 NVARCHAR(50),
    PCV                 NVARCHAR(50),
    MCV                 NVARCHAR(50),
    MCH                 NVARCHAR(50),
    MCHC                NVARCHAR(50),
    RBC                 NVARCHAR(50),
    BloodGroup          NVARCHAR(20),
    RhFactor            NVARCHAR(20),
    PeripheralSmear     NVARCHAR(300),
    Impression          NVARCHAR(500),
    mp_slide            NVARCHAR(100),
    mp_species          NVARCHAR(100),
    mp_stage            NVARCHAR(100),
    mp_count            NVARCHAR(100),
    Reticulocyte        NVARCHAR(50),
    month_year          NVARCHAR(20),
    del_tag             INT DEFAULT 0
);
GO

CREATE TABLE bloodext (
    pcode INT, field1 NVARCHAR(200), val1 NVARCHAR(200),
    field2 NVARCHAR(200), val2 NVARCHAR(200),
    field3 NVARCHAR(200), val3 NVARCHAR(200),
    field4 NVARCHAR(200), val4 NVARCHAR(200)
);
GO

-- ============================================================
-- TABLE: urine
-- ============================================================
CREATE TABLE urine (
    pcode               INT,
    UP_color            NVARCHAR(50),
    UP_reaction         NVARCHAR(50),
    UP_specificgravity  NVARCHAR(50),
    UC_sugar            NVARCHAR(50),
    UC_albumin          NVARCHAR(50),
    UC_phosphate        NVARCHAR(50),
    UC_chyle            NVARCHAR(50),
    UC_ketonebodies     NVARCHAR(50),
    UC_bilesalts        NVARCHAR(50),
    UC_bilepigment      NVARCHAR(50),
    UM_puscells         NVARCHAR(50),
    UM_epithcells       NVARCHAR(50),
    UM_rbc              NVARCHAR(50),
    UM_casts            NVARCHAR(50),
    UM_crystals         NVARCHAR(50),
    UM_bacterial        NVARCHAR(50),
    UM_spermatozoa      NVARCHAR(50),
    UM_mf_tv            NVARCHAR(50),
    UM_others           NVARCHAR(50),
    UU_urine_b_hcg      NVARCHAR(50),
    UA_urine_albumin    NVARCHAR(50),
    UN_nasalsmear       NVARCHAR(50),
    ur_imp              NVARCHAR(500),
    month_year          NVARCHAR(20),
    del_tag             INT DEFAULT 0
);
GO

CREATE TABLE Urineext (
    pcode INT, field1 NVARCHAR(200), val1 NVARCHAR(200),
    field2 NVARCHAR(200), val2 NVARCHAR(200),
    field3 NVARCHAR(200), val3 NVARCHAR(200)
);
GO

-- ============================================================
-- TABLE: stool
-- ============================================================
CREATE TABLE stool (
    pcode               INT,
    Sp_color            NVARCHAR(50),
    Sp_reaction         NVARCHAR(50),
    Sp_Mucus            NVARCHAR(50),
    SH_OvaHW            NVARCHAR(50),
    SH_larva            NVARCHAR(50),
    SH_OvaRW            NVARCHAR(50),
    SP_EHistolytica     NVARCHAR(50),
    SP_ecoli            NVARCHAR(50),
    SP_giardia          NVARCHAR(50),
    SP_trichomonas      NVARCHAR(50),
    SM_rbc_from         NVARCHAR(50),
    SM_puscells_from    NVARCHAR(50),
    SM_macrophase       NVARCHAR(50),
    SM_vegetables       NVARCHAR(50),
    SM_yeast            NVARCHAR(50),
    SM_crystal          NVARCHAR(50),
    SM_fataglobules     NVARCHAR(50),
    SM_bacterialflora   NVARCHAR(50),
    SH_Others           NVARCHAR(50),
    SC_Occultblood      NVARCHAR(50),
    SC_Reducingsugar    NVARCHAR(50),
    st_imp              NVARCHAR(500),
    month_year          NVARCHAR(20),
    del_tag             INT DEFAULT 0
);
GO

CREATE TABLE rutineext (
    pcode INT,
    field1 NVARCHAR(200), val1 NVARCHAR(200),
    field2 NVARCHAR(200), val2 NVARCHAR(200),
    field3 NVARCHAR(200), val3 NVARCHAR(200),
    field4 NVARCHAR(200), val4 NVARCHAR(200),
    field5 NVARCHAR(200), val5 NVARCHAR(200),
    field6 NVARCHAR(200), val6 NVARCHAR(200),
    field7 NVARCHAR(200), val7 NVARCHAR(200),
    field8 NVARCHAR(200), val8 NVARCHAR(200),
    field9 NVARCHAR(200), val9 NVARCHAR(200),
    field10 NVARCHAR(200), val10 NVARCHAR(200)
);
GO

-- ============================================================
-- TABLE: Biochemist
-- ============================================================
CREATE TABLE Biochemist (
    pcode               INT,
    TotalProtein        NVARCHAR(50),
    Albumin             NVARCHAR(50),
    Globulin            NVARCHAR(50),
    AGRatio             NVARCHAR(50),
    TotalBilirubin      NVARCHAR(50),
    DirectBilirubin     NVARCHAR(50),
    IndirectBilirubin   NVARCHAR(50),
    SGOT                NVARCHAR(50),
    SGPT                NVARCHAR(50),
    AlkPhos             NVARCHAR(50),
    Urea                NVARCHAR(50),
    Creatinine          NVARCHAR(50),
    Uric_Acid           NVARCHAR(50),
    Cholesterol         NVARCHAR(50),
    Triglycerides       NVARCHAR(50),
    HDL                 NVARCHAR(50),
    LDL                 NVARCHAR(50),
    VLDL                NVARCHAR(50),
    BloodGlucose        NVARCHAR(50),
    FastingGlucose      NVARCHAR(50),
    PostprandialGlucose NVARCHAR(50),
    HbA1c               NVARCHAR(50),
    Calcium             NVARCHAR(50),
    Phosphorus          NVARCHAR(50),
    Sodium              NVARCHAR(50),
    Potassium           NVARCHAR(50),
    Chloride            NVARCHAR(50),
    Amylase             NVARCHAR(50),
    Lipase              NVARCHAR(50),
    impression          NVARCHAR(500),
    month_year          NVARCHAR(20),
    del_tag             INT DEFAULT 0
);
GO

CREATE TABLE biochemistext (
    pcode INT,
    field1 NVARCHAR(200), val1 NVARCHAR(200),
    field2 NVARCHAR(200), val2 NVARCHAR(200),
    field3 NVARCHAR(200), val3 NVARCHAR(200),
    field4 NVARCHAR(200), val4 NVARCHAR(200),
    field5 NVARCHAR(200), val5 NVARCHAR(200),
    field6 NVARCHAR(200), val6 NVARCHAR(200),
    field7 NVARCHAR(200), val7 NVARCHAR(200),
    field8 NVARCHAR(200), val8 NVARCHAR(200),
    field9 NVARCHAR(200), val9 NVARCHAR(200),
    field10 NVARCHAR(200), val10 NVARCHAR(200)
);
GO

-- ============================================================
-- TABLE: Hormone
-- ============================================================
CREATE TABLE Hormone (
    pcode        INT,
    T3           NVARCHAR(50),
    T4           NVARCHAR(50),
    TSH          NVARCHAR(50),
    FT3          NVARCHAR(50),
    FT4          NVARCHAR(50),
    LH           NVARCHAR(50),
    FSH          NVARCHAR(50),
    Prolactin    NVARCHAR(50),
    Testosterone NVARCHAR(50),
    Estradiol    NVARCHAR(50),
    Progesterone NVARCHAR(50),
    HCG          NVARCHAR(50),
    Cortisol     NVARCHAR(50),
    Insulin      NVARCHAR(50),
    impression   NVARCHAR(500),
    month_year   NVARCHAR(20),
    del_tag      INT DEFAULT 0
);
GO

CREATE TABLE hormoneext (
    pcode INT,
    field1 NVARCHAR(200), val1 NVARCHAR(200),
    field2 NVARCHAR(200), val2 NVARCHAR(200),
    field3 NVARCHAR(200), val3 NVARCHAR(200),
    field4 NVARCHAR(200), val4 NVARCHAR(200),
    field5 NVARCHAR(200), val5 NVARCHAR(200),
    field6 NVARCHAR(200), val6 NVARCHAR(200),
    field7 NVARCHAR(200), val7 NVARCHAR(200),
    field8 NVARCHAR(200), val8 NVARCHAR(200)
);
GO

-- ============================================================
-- TABLE: Culture
-- ============================================================
CREATE TABLE Culture (
    pcode        INT,
    sample_type  NVARCHAR(100),
    organism     NVARCHAR(200),
    colony_count NVARCHAR(100),
    sensitivity  NVARCHAR(MAX),
    resistance   NVARCHAR(MAX),
    impression   NVARCHAR(500),
    month_year   NVARCHAR(20),
    del_tag      INT DEFAULT 0
);
GO

CREATE TABLE cultureext (
    pcode INT,
    field1 NVARCHAR(200), val1 NVARCHAR(200),
    field2 NVARCHAR(200), val2 NVARCHAR(200),
    field3 NVARCHAR(200), val3 NVARCHAR(200)
);
GO

CREATE TABLE CULTURE_master (
    cmc     INT PRIMARY KEY IDENTITY(1,1),
    culture NVARCHAR(200)
);
GO

CREATE TABLE CULTURE_organism (
    coc      INT PRIMARY KEY IDENTITY(1,1),
    organism NVARCHAR(200),
    culture  NVARCHAR(200)
);
GO

CREATE TABLE CULTURE_colonycount (
    ccc         INT PRIMARY KEY IDENTITY(1,1),
    colonycount NVARCHAR(200)
);
GO

CREATE TABLE CULTURE_type (
    ctc   INT PRIMARY KEY IDENTITY(1,1),
    ctype NVARCHAR(200)
);
GO

-- ============================================================
-- TABLE: Cytology
-- ============================================================
CREATE TABLE Cytology (
    pcode      INT,
    specimen   NVARCHAR(200),
    macroscopy NVARCHAR(500),
    microscopy NVARCHAR(MAX),
    impression NVARCHAR(500),
    month_year NVARCHAR(20),
    del_tag    INT DEFAULT 0
);
GO

-- ============================================================
-- TABLE: histopathology
-- ============================================================
CREATE TABLE histopathology (
    pcode      INT,
    specimen   NVARCHAR(200),
    macroscopy NVARCHAR(500),
    microscopy NVARCHAR(MAX),
    impression NVARCHAR(500),
    month_year NVARCHAR(20),
    del_tag    INT DEFAULT 0
);
GO

-- ============================================================
-- TABLE: Seminal_Fluid
-- ============================================================
CREATE TABLE Seminal_Fluid (
    pcode               INT,
    volume              NVARCHAR(50),
    appearance          NVARCHAR(50),
    reaction            NVARCHAR(50),
    liquefaction        NVARCHAR(50),
    total_count         NVARCHAR(50),
    motility_active     NVARCHAR(50),
    motility_sluggish   NVARCHAR(50),
    motility_dead       NVARCHAR(50),
    morphology_normal   NVARCHAR(50),
    morphology_abnormal NVARCHAR(50),
    puscells            NVARCHAR(50),
    rbc                 NVARCHAR(50),
    epithelial          NVARCHAR(50),
    impression          NVARCHAR(500),
    month_year          NVARCHAR(20),
    del_tag             INT DEFAULT 0
);
GO

-- ============================================================
-- TABLE: Body_fluid_analysis
-- ============================================================
CREATE TABLE Body_fluid_analysis (
    pcode       INT,
    fluid_type  NVARCHAR(100),
    colour      NVARCHAR(50),
    appearance  NVARCHAR(50),
    reaction    NVARCHAR(50),
    glucose     NVARCHAR(50),
    protein     NVARCHAR(50),
    puscells    NVARCHAR(50),
    rbc         NVARCHAR(50),
    lymphocytes NVARCHAR(50),
    neutrophils NVARCHAR(50),
    macrophages NVARCHAR(50),
    mesothelial NVARCHAR(50),
    other_cells NVARCHAR(50),
    impression  NVARCHAR(500),
    month_year  NVARCHAR(20),
    del_tag     INT DEFAULT 0
);
GO

-- ============================================================
-- TABLE: xray
-- ============================================================
CREATE TABLE xray (
    pcode      INT,
    xray_type  NVARCHAR(100),
    findings   NVARCHAR(MAX),
    impression NVARCHAR(500),
    month_year NVARCHAR(20),
    del_tag    INT DEFAULT 0
);
GO

CREATE TABLE serologyext (
    pcode INT,
    field1 NVARCHAR(200), val1 NVARCHAR(200),
    field2 NVARCHAR(200), val2 NVARCHAR(200),
    field3 NVARCHAR(200), val3 NVARCHAR(200),
    field4 NVARCHAR(200), val4 NVARCHAR(200),
    field5 NVARCHAR(200), val5 NVARCHAR(200),
    field6 NVARCHAR(200), val6 NVARCHAR(200),
    field7 NVARCHAR(200), val7 NVARCHAR(200),
    field8 NVARCHAR(200), val8 NVARCHAR(200),
    field9 NVARCHAR(200), val9 NVARCHAR(200),
    field10 NVARCHAR(200), val10 NVARCHAR(200)
);
GO

-- ============================================================
-- TABLE: profile_master
-- ============================================================
CREATE TABLE profile_master (
    pmc     INT PRIMARY KEY IDENTITY(1,1),
    profile NVARCHAR(200),
    price   FLOAT DEFAULT 0,
    grp     NVARCHAR(100)
);
GO

CREATE TABLE profile_master_note (
    pmnc    INT PRIMARY KEY IDENTITY(1,1),
    profile NVARCHAR(200),
    note    NVARCHAR(MAX)
);
GO

CREATE TABLE profile_note (
    pnc     INT PRIMARY KEY IDENTITY(1,1),
    pcode   INT,
    profile NVARCHAR(200),
    note    NVARCHAR(MAX)
);
GO

CREATE TABLE profile_data (
    pdc     INT PRIMARY KEY IDENTITY(1,1),
    profile NVARCHAR(200),
    test    NVARCHAR(200),
    price   FLOAT DEFAULT 0
);
GO

-- ============================================================
-- TABLE: outsource
-- ============================================================
CREATE TABLE outsource (
    oc      INT PRIMARY KEY IDENTITY(1,1),
    Name    NVARCHAR(200),
    Address NVARCHAR(300),
    Phone   NVARCHAR(50)
);
GO

-- ============================================================
-- TABLE: account_master
-- ============================================================
CREATE TABLE account_master (
    acode    INT PRIMARY KEY IDENTITY(1,1),
    aname    NVARCHAR(200),
    atype    NVARCHAR(100),
    opbal    FLOAT DEFAULT 0,
    drcrflag NVARCHAR(2)
);
GO

-- ============================================================
-- TABLE: cbj  (Cash book journal)
-- ============================================================
CREATE TABLE cbj (
    cbno       INT PRIMARY KEY IDENTITY(1,1),
    cbdt       DATETIME,
    narration  NVARCHAR(500),
    month_year NVARCHAR(20)
);
GO

CREATE TABLE Cbj_Detail (
    cbd_id INT PRIMARY KEY IDENTITY(1,1),
    cbno   INT,
    acode  INT,
    aname  NVARCHAR(200),
    dramt  FLOAT DEFAULT 0,
    cramt  FLOAT DEFAULT 0
);
GO

-- ============================================================
-- TABLE: product_master  (Inventory items)
-- ============================================================
CREATE TABLE product_master (
    itemid     INT PRIMARY KEY IDENTITY(1,1),
    item       NVARCHAR(200),
    type       NVARCHAR(100),
    unit       NVARCHAR(50),
    reorderqty FLOAT DEFAULT 0,
    opqty      FLOAT DEFAULT 0,
    oprate     FLOAT DEFAULT 0,
    gcd        INT DEFAULT 0,
    scd        INT DEFAULT 0
);
GO

CREATE TABLE itmgrp (
    gcd     INT PRIMARY KEY IDENTITY(1,1),
    grpname NVARCHAR(200)
);
GO

CREATE TABLE mstgrp (
    scd      INT PRIMARY KEY IDENTITY(1,1),
    gcd      INT,
    sgrpname NVARCHAR(200)
);
GO

-- ============================================================
-- TABLE: Purchase / Mrn / Issue
-- ============================================================
CREATE TABLE Purchase (
    pono       INT PRIMARY KEY IDENTITY(1,1),
    podt       DATETIME,
    supplier   NVARCHAR(200),
    total      FLOAT DEFAULT 0,
    month_year NVARCHAR(20)
);
GO

CREATE TABLE po_details (
    pod_id INT PRIMARY KEY IDENTITY(1,1),
    pono   INT,
    itemid INT,
    item   NVARCHAR(200),
    qty    FLOAT DEFAULT 0,
    rate   FLOAT DEFAULT 0,
    amount FLOAT DEFAULT 0
);
GO

CREATE TABLE Mrn (
    mrnno      INT PRIMARY KEY IDENTITY(1,1),
    mrndt      DATETIME,
    supplier   NVARCHAR(200),
    total      FLOAT DEFAULT 0,
    month_year NVARCHAR(20)
);
GO

CREATE TABLE Mrn_detail (
    mrnd_id INT PRIMARY KEY IDENTITY(1,1),
    mrnno   INT,
    itemid  INT,
    item    NVARCHAR(200),
    qty     FLOAT DEFAULT 0,
    rate    FLOAT DEFAULT 0,
    amount  FLOAT DEFAULT 0,
    expiry  DATETIME
);
GO

CREATE TABLE Issue (
    issno      INT PRIMARY KEY IDENTITY(1,1),
    issdt      DATETIME,
    department NVARCHAR(200),
    month_year NVARCHAR(20)
);
GO

CREATE TABLE Issue_detail (
    issd_id INT PRIMARY KEY IDENTITY(1,1),
    issno   INT,
    itemid  INT,
    item    NVARCHAR(200),
    qty     FLOAT DEFAULT 0,
    rate    FLOAT DEFAULT 0,
    amount  FLOAT DEFAULT 0
);
GO

CREATE TABLE inv (
    invid   INT PRIMARY KEY IDENTITY(1,1),
    invdt   DATETIME,
    itemid  INT,
    item    NVARCHAR(200),
    invtype NVARCHAR(50),
    qty     FLOAT DEFAULT 0,
    rate    FLOAT DEFAULT 0,
    amount  FLOAT DEFAULT 0,
    refno   INT
);
GO

-- ============================================================
-- TABLE: opd_master / OPD_Detail / Masteropd
-- ============================================================
CREATE TABLE opd_master (
    opdno        INT PRIMARY KEY IDENTITY(1,1),
    reg_date     DATETIME,
    patient_name NVARCHAR(200),
    age          INT DEFAULT 0,
    sex          NVARCHAR(10),
    address      NVARCHAR(300),
    phone        NVARCHAR(50),
    doctor       NVARCHAR(200),
    diagnosis    NVARCHAR(500),
    month_year   NVARCHAR(20)
);
GO

CREATE TABLE OPD_Detail (
    opdd_id     INT PRIMARY KEY IDENTITY(1,1),
    opdno       INT,
    medicine    NVARCHAR(200),
    dose        NVARCHAR(100),
    duration    NVARCHAR(50),
    instruction NVARCHAR(200)
);
GO

CREATE TABLE Masteropd (
    mopdno       INT PRIMARY KEY IDENTITY(1,1),
    patient_name NVARCHAR(200),
    age          INT DEFAULT 0,
    sex          NVARCHAR(10),
    address      NVARCHAR(300),
    phone        NVARCHAR(50),
    reg_date     DATETIME
);
GO

CREATE TABLE tarewt_details (
    twid INT PRIMARY KEY IDENTITY(1,1),
    item NVARCHAR(200),
    tare FLOAT DEFAULT 0
);
GO

-- Change DB owner to sa
EXEC sp_changedbowner 'sa';
GO

PRINT '=========================================';
PRINT 'DATABASE pathology2627 CREATED OK!';
PRINT '';
PRINT 'Login with:  Admin / Admin';
PRINT 'NEXT: Add Company, Doctors, Test Masters';
PRINT '=========================================';
GO
