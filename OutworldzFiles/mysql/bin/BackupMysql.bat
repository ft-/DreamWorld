@REM A program to backup Mysql manually
mysqldump.exe --opt  -uroot --verbose opensim  > "C:/Opensim/Outworldz Source/OutworldzFiles/Autobackup/Opensim_2018-01-30_12_43_27.sql"
mysqldump.exe --opt  -uroot --verbose robust  > "C:/Opensim/Outworldz Source/OutworldzFiles/Autobackup/Robust_2018-01-30_12_43_27.sql"
@REM Finished!
@pause

