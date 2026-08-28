-- =====================================================
-- Pathology Lab Software - STEP 3: Default / Seed Data
-- Run this AFTER 02_create_tables.sql
-- =====================================================
USE [pathology2627];
GO

-- Company / Lab Info
IF NOT EXISTS (SELECT 1 FROM company)
    INSERT INTO company (Cc,Comp,Address,TELPHONENO,Pathologist,Biochemist,year_start,year_end)
    VALUES (1,'Arogya Pathology Lab','12, Gandhi Nagar, Civil Lines','0522-4012345','Dr. Ramesh Kumar','Dr. Sunita Verma','01/04/2026','31/03/2027');
GO

-- Setup row
IF NOT EXISTS (SELECT 1 FROM setup)
    INSERT INTO setup (cc,comp,currentuser,blno,type,year_start,year_end,regno)
    VALUES (1,'1','Admin','1','P','01/04/2026','31/03/2027','1');
GO

-- Default Admin user (password: Admin)
IF NOT EXISTS (SELECT 1 FROM usermaster)
    INSERT INTO usermaster (userid,password,username,type)
    VALUES ('Admin','Admin','Administrator','Admin');
GO

-- Analyser port defaults
IF NOT EXISTS (SELECT 1 FROM wbs1)
    INSERT INTO wbs1 (baudrate1,databits1,parity1,stopbits1,dtrenables11,handshake1,dtrenables12)
    VALUES ('9600','8','None','One','False','None','False');
GO

-- Reference ranges for Blood/Biochemist tests
IF NOT EXISTS (SELECT 1 FROM reference_master)
BEGIN
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('1','ABSOLUTE EOSINOPHIL COUNT','BLOOD','BLOOD','--','0','0','','0','150','','Single','--','1','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('2','BASOPHILS','BLOOD','BLOOD','--','0','0','','0','150','','Single','--','1','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('3','BLEEDING TIME ( BT )','BLOOD','BLOOD','--','0','0','','0','150','','Single','--','1','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('4','CLOTTING TIME (CT)','BLOOD','BLOOD','--','0','0','','0','150','','Single','--','1','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('5','E.S.R. ( 1st hour )','BLOOD','BLOOD','--','0','0','','0','150','','Single','--','1','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('6','E.S.R. ( 2nd hours )','BLOOD','BLOOD','--','0','0','','0','150','','Single','--','1','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('7','EOSINOPHILS','BLOOD','BLOOD','--','0','0','','0','150','','Single','--','1','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('8','HAEMOGLOBIN','BLOOD','BLOOD','--','0','0','','0','150','','Single','--','1','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('9','LYMPHOCYTES','BLOOD','BLOOD','--','0','0','','0','150','','Single','--','1','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('10','M.C.H','BLOOD','BLOOD','--','0','0','','0','150','','Single','--','1','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('11','M.C.H.C.','BLOOD','BLOOD','--','0','0','','0','150','','Single','--','1','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('12','M.C.V','BLOOD','BLOOD','--','0','0','','0','150','','Single','--','1','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('13','MONOCYTES','BLOOD','BLOOD','--','0','0','','0','150','','Single','--','1','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('14','MPV','BLOOD','BLOOD','--','0','0','','0','150','','Single','--','1','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('15','NASAL SMEARS FOR EOSINOPHILS : LEFT','BLOOD','BLOOD','--','0','0','','0','150','','Single','--','1','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('16','NASAL SMEARS FOR EOSINOPHILS : RIGHT','BLOOD','BLOOD','--','0','0','','0','150','','Single','--','1','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('17','NEUTROPHILS','BLOOD','BLOOD','--','0','0','','0','150','','Single','--','1','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('18','P.C.V','BLOOD','BLOOD','--','0','0','','0','150','','Single','--','1','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('19','PACKED CELL VOLUME( PCV )','BLOOD','BLOOD','--','0','0','','0','150','','Single','--','1','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('20','PDW','BLOOD','BLOOD','--','0','0','','0','150','','Single','--','1','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('21','PLATELET COUNT','BLOOD','BLOOD','--','0','0','','0','150','','Single','--','1','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('22','RDW-CV','BLOOD','BLOOD','--','0','0','','0','150','','Single','--','1','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('23','RDW-SD','BLOOD','BLOOD','--','0','0','','0','150','','Single','--','1','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('24','Red Cell Distribution Width','BLOOD','BLOOD','--','0','0','','0','150','','Single','--','1','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('25','RETICULOCYTE COUNT TEST','BLOOD','BLOOD','--','0','0','','0','150','','Single','--','1','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('26','SICKLING TEST          (After 24 hours incubation)','BLOOD','BLOOD','--','0','0','','0','150','','Single','--','1','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('27','TOTAL ERYTHROCYTE COUNT (RBC)','BLOOD','BLOOD','--','0','0','','0','150','','Single','--','1','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('28','TOTAL LEUCOCYTE COUNT','BLOOD','BLOOD','--','0','0','','0','150','','Single','--','1','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('29','TOTAL NEUTROPHIL COUNT','BLOOD','BLOOD','--','0','0','','0','150','','Single','--','1','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('30','A.L.T.(S.G.P.T.)','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('31','A.S.T.(S.G.O.T.)','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('32','A:G RATIO','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('33','ACID PHOSPHATASE','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('34','ALBUMIN','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('35','ALKALINE PHOSPHATASE','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('36','ALPHA AMYLASE','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('37','BLOOD UREA NITROGEN ( BUN )','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('38','CALCIUM','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('39','CHLORIDES','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('40','CHOL/HDL RATIO','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('41','CHOLESTEROL','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('42','CPK - MB','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('43','CREATININE','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('44','DIRECT BILIRUBIN','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('45','FASTING BLOOD SUGAR ( FBS )','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('46','GAMMA GLUTAMYL TRANSFERASE','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('47','GLOBULIN','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('48','GLUCOSE TOLERANCE TEST (GTT-1hr)','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('49','GLYCOSYLATED HEMOGLOBIN ( HbA1C )','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('50','HIGH DENSITY LIPOPROTEIN ( HDL )','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('51','INDIRECT BILIRUBIN','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('52','INORGANIC PHOSPHORUS','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('53','LDH','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('54','LDL/HDL RATIO','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('55','LIPASE','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('56','LOW DENSITY LIPOPROTEIN ( LDL )','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('57','MEAN BLOOD GLUCOSE ESTIMATION','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('58','NPN','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('59','POST BREAKFAST BLOOD SUGAR ( PBBS )','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('60','POST GLUCOSE BLOOD SUGAR (PGBS-1hr)','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('61','POST GLUCOSE BLOOD SUGAR (PGBS-2hr)','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('62','POST LUNCH BLOOD SUGAR ( PLBS )','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('63','POST PRANDIAL BLOOD SUGAR(PPBS-1hr)','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('64','POST PRANDIAL BLOOD SUGAR(PPBS-2hr)','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('65','POTASSIUM','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('66','RANDOM BLOOD SUGAR ( RBS )','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('67','SODIUM','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('68','TOTAL BILIRUBIN','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('69','TOTAL PROTEIN','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('70','TRIGLYCERIDE','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('71','UREA','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('72','URIC ACID','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
    INSERT INTO reference_master (rcode,test,grp,sgrp,unit,normal_from,normal_to,normal_text,age_from,age_to,sex,type,method,gcode,range_from,range_to)
    VALUES ('73','VERY LOW DENSITY LIPOPROTEIN ( VLDL )','BIOCHEMIST','BIOCHEMIST','--','0','0','','0','150','','Single','--','2','0','9999');
END
GO

PRINT 'Default data inserted. Setup complete!';
GO
