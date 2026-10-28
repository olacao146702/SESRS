@echo off
REM SESRS database restore. Usage: restore.bat "path\to\backup.sql"
REM WARNING: this REPLACES the current contents of the database with the backup.
setlocal

set MYSQLBIN=C:\xampp\mysql\bin
set DBNAME=sesrs_db
set DBUSER=root

if "%~1"=="" (
    echo Usage: restore.bat "path\to\backup.sql"
    pause
    exit /b 1
)

if not exist "%~1" (
    echo File not found: %~1
    pause
    exit /b 1
)

echo This will REPLACE all data in %DBNAME% with:
echo   %~1
set /p CONFIRM=Type YES to continue: 
if /i not "%CONFIRM%"=="YES" (
    echo Cancelled.
    exit /b 0
)

"%MYSQLBIN%\mysql.exe" -u %DBUSER% -p -e "DROP DATABASE IF EXISTS %DBNAME%; CREATE DATABASE %DBNAME% CHARACTER SET latin1;"
if errorlevel 1 goto :failed

"%MYSQLBIN%\mysql.exe" -u %DBUSER% -p %DBNAME% < "%~1"
if errorlevel 1 goto :failed

echo.
echo Restore complete.
pause
exit /b 0

:failed
echo.
echo RESTORE FAILED. The database may be incomplete; try again or restore another backup.
pause
exit /b 1
