@echo off
@echo Loading %1
cls
set SimName=%1 %2 %3 %4 %5
OpenSim.exe -inidirectory="./Regions/%SimName%" 
echo %SimName% has exited.
