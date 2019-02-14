@echo off
echo Upgrading MySql Database
mysql_upgrade.exe --port=%1

myisamchk --force --fast --update-state ..\data\mysql\*.MYI
myisamchk --force --fast --update-state ..\data\robust\*.MYI

echo Checking Database
mysqlcheck.exe --port %1 -u root -A 
set /p fixmysql=Repair and Optimize [y/n]?:
IF "%fixmysql%" == "y" mysqlcheck.exe --port %1 -A  -u root -r
IF "%fixmysql%" == "y" mysqlcheck.exe --port %1 -A  -u root -o

set /p temp="Press enter to exit"


