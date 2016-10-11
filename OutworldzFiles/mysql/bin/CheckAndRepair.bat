@echo off
echo Checking MySql Database
mysqlcheck.exe -u root mysql
set /p fixmysql=Repair Mysql[y/n]?:
IF "%fixmysql%" == "y" mysqlcheck.exe -u root -r Mysql
set /p temp="Press enter to exit"

