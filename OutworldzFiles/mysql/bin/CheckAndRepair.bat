@echo off
echo Upgrading MySql Database
mysql_upgrade.exe
pause
echo Checking MySql Database
mysqlcheck.exe --port %1 -u root mysql 
set /p fixmysql=Repair Mysql[y/n]?:
IF "%fixmysql%" == "y" mysqlcheck.exe --port %1 -u root -r Mysql

mysqlcheck.exe --port %1 -u root opensim
set /p fixmysql=Repair Opensim[y/n]?:
IF "%fixmysql%" == "y" mysqlcheck.exe --port %1 -u root -r Opensim


set /p temp="Press enter to exit"

