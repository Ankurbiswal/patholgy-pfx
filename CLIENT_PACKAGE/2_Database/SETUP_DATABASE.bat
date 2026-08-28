@echo off
echo ====================================================
echo   Pathology Lab Software - Database Setup
echo ====================================================
echo.
echo This will create the database on this PC's SQL Server.
echo Make sure SQL Server Express is installed first!
echo.
pause

set SQLCMD="C:\Program Files\Microsoft SQL Server\Client SDK\ODBC\170\Tools\Binn\SQLCMD.EXE"
if not exist %SQLCMD% set SQLCMD="C:\Program Files\Microsoft SQL Server\110\Tools\Binn\SQLCMD.EXE"
if not exist %SQLCMD% set SQLCMD=sqlcmd

echo Step 1: Creating database...
%SQLCMD% -S .\SQLEXPRESS -U sa -P software -i "01_create_database.sql"
if errorlevel 1 goto error

echo.
echo Step 2: Creating tables...
%SQLCMD% -S .\SQLEXPRESS -U sa -P software -i "02_create_tables.sql"
if errorlevel 1 goto error

echo.
echo Step 3: Inserting default data...
%SQLCMD% -S .\SQLEXPRESS -U sa -P software -i "03_default_data.sql"
if errorlevel 1 goto error

echo.
echo ====================================================
echo   SUCCESS! Database setup complete.
echo   You can now run Pathology.exe
echo ====================================================
pause
exit /b 0

:error
echo.
echo ====================================================
echo   ERROR during setup!
echo   Make sure:
echo   1. SQL Server Express is installed
echo   2. sa password is 'software'
echo   3. Run this as Administrator
echo ====================================================
pause
exit /b 1
