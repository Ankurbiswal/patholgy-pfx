-- =====================================================
-- Pathology Lab Software - STEP 1: Create Database
-- Run this script FIRST as SQL Server Admin (sa)
-- =====================================================

USE [master];
GO

-- Create the database (skip if already exists)
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'pathology2627')
BEGIN
    CREATE DATABASE [pathology2627];
    PRINT 'Database pathology2627 created successfully.';
END
ELSE
BEGIN
    PRINT 'Database pathology2627 already exists - skipping creation.';
END
GO

USE [pathology2627];
GO

PRINT 'Database setup complete. Now run 02_create_tables.sql';
GO
