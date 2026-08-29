@echo off
echo ============================================================
echo   PATHOLOGY LAB - SQL Server Connection Fix
echo   Run this as ADMINISTRATOR if app shows login error
echo ============================================================
echo.
echo This will:
echo   1. Enable SA account on SQL Server
echo   2. Set SA password to: software  
echo   3. Enable Mixed Mode Authentication
echo   4. Reset Admin user in Pathology database
echo   5. Restart SQL Server
echo.
echo Right-click this file and choose "Run as administrator"
echo.
pause

:: Step 1: Find sqlcmd location
set SQLCMD=sqlcmd
if exist "C:\Program Files\Microsoft SQL Server\Client SDK\ODBC\170\Tools\Binn\SQLCMD.EXE" set SQLCMD="C:\Program Files\Microsoft SQL Server\Client SDK\ODBC\170\Tools\Binn\SQLCMD.EXE"
if exist "C:\Program Files\Microsoft SQL Server\Client SDK\ODBC\180\Tools\Binn\SQLCMD.EXE" set SQLCMD="C:\Program Files\Microsoft SQL Server\Client SDK\ODBC\180\Tools\Binn\SQLCMD.EXE"
if exist "C:\Program Files\Microsoft SQL Server\110\Tools\Binn\SQLCMD.EXE" set SQLCMD="C:\Program Files\Microsoft SQL Server\110\Tools\Binn\SQLCMD.EXE"

:: Step 2: Enable Mixed Mode + SA account using Windows Authentication
echo Step 1: Enabling SA account...
%SQLCMD% -S .\SQLEXPRESS -E -Q "ALTER LOGIN [sa] WITH PASSWORD = 'software', CHECK_POLICY = OFF; ALTER LOGIN [sa] ENABLE;"
if errorlevel 1 (
    echo   WARNING: Could not enable SA via Windows Auth - trying alternative...
)

:: Step 3: Set Mixed Mode via registry
echo Step 2: Enabling Mixed Mode Authentication...
for %%v in (15 16 14 13 12) do (
    if exist "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Microsoft SQL Server\MSSQL%%v.SQLEXPRESS\MSSQLServer" (
        reg add "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Microsoft SQL Server\MSSQL%%v.SQLEXPRESS\MSSQLServer" /v LoginMode /t REG_DWORD /d 2 /f
    )
)

:: Step 4: Restart SQL Server to apply changes
echo Step 3: Restarting SQL Server...
net stop MSSQL$SQLEXPRESS /y
timeout /t 3 /nobreak > nul
net start MSSQL$SQLEXPRESS
timeout /t 5 /nobreak > nul

:: Step 5: Create/reset database and Admin user
echo Step 4: Setting up database and Admin user...
%SQLCMD% -S .\SQLEXPRESS -U sa -P software -Q "IF NOT EXISTS (SELECT name FROM sys.databases WHERE name='pathology2627') CREATE DATABASE [pathology2627];"
timeout /t 2 /nobreak > nul

:: Reset admin user - delete and re-insert
%SQLCMD% -S .\SQLEXPRESS -U sa -P software -d pathology2627 -Q "IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='usermaster') BEGIN DELETE FROM usermaster WHERE userid='Admin'; INSERT INTO usermaster (userid,password,username,type) VALUES ('Admin','Admin','Administrator','Admin'); PRINT 'Admin user reset successfully'; END"

echo.
echo ============================================================
echo   DONE! Now try opening Pathology.exe
echo   Login with: Username = Admin   Password = Admin
echo ============================================================
pause
