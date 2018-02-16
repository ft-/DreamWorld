
@rem makes a full back into Autobackup of mysql, robust and opensim


for /f "tokens=2 delims==" %%a in ('wmic OS Get localdatetime /value') do set "dt=%%a"
set "YY=%dt:~2,2%" & set "YYYY=%dt:~0,4%" & set "MM=%dt:~4,2%" & set "DD=%dt:~6,2%"
set "HH=%dt:~8,2%" & set "Min=%dt:~10,2%" & set "Sec=%dt:~12,2%"
set "fullstamp=%YYYY%-%MM%-%DD%_%HH%-%Min%-%Sec%"

mysqldump.exe --opt  -uroot --verbose mysql  > ..\..\Autobackup\mysql_%fullstamp%.sql
mysqldump.exe --opt  -uroot --verbose opensim  > ..\..\Autobackup\Opensim_%fullstamp%.sql
*mysqldump.exe --opt  -uroot --verbose robust  > ..\..\Autobackup\Robust_%fullstamp%.sql*
xcopy /s /i ..\..\Opensim\bin\Regions ..\..\Autobackup\Regions_%fullstamp%
@echo Finished!