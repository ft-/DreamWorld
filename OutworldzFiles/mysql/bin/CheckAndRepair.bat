@echo off
echo Checking MySql Database
mysqlcheck.exe --port %1 -u root mysql 
set /p fixmysql=Repair Mysql[y/n]?:
IF "%fixmysql%" == "y" mysqlcheck.exe --port %1 -u root -r Mysql
set /p temp="Press enter to exit"

