@echo off
REM SESRS database backup. Double-click, or schedule it daily with Windows Task Scheduler.
REM Edit the three settings below to match your computer.
setlocal

set MYSQLBIN=C:\xampp\mysql\bin
set DBNAME=sesrs_db
set DBUSER=root

set BACKUPDIR=%~dp0backups
if not exist "%BACKUPDIR%" mkdir "%BACKUPDIR%"

for /f %%i in ('powershell -NoProfile -Command "Get-Date -Format yyyyMMdd_HHmmss"') do set STAMP=%%i
set OUTFILE=%BACKUPDIR%\%DBNAME%_%STAMP%.sql

echo Backing up %DBNAME% to:
echo   %OUTFILE%
echo (Enter the database password if asked; press Enter if there is none.)

"%MYSQLBIN%\mysqldump.exe" -u %DBUSER% -p --single-transaction --routines --triggers --default-character-set=utf8mb4 %DBNAME% > "%OUTFILE%"

if errorlevel 1 (
    echo.
    echo BACKUP FAILED. Check the settings at the top of this file.
    del "%OUTFILE%" 2>nul
    pause
    exit /b 1
)

echo.
echo Backup complete. Keep a copy on another drive or cloud folder.
pause
