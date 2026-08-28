@echo off
echo ============================================
echo   Pathology Lab - SQL Server Restart Tool
echo ============================================
echo.
echo Starting SQL Server service...
net start MSSQL$SQLEXPRESS
if %errorlevel% == 0 (
    echo.
    echo SUCCESS! SQL Server is now running.
    echo You can now open the Pathology software.
) else (
    echo.
    echo SQL Server may already be running, or there was an error.
    echo Try opening the Pathology software now.
)
echo.
pause
