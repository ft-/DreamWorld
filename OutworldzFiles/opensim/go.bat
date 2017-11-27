
echo Loading %1
@echo off
cls
cd bin
set SimName=%1 %2 %3
OpenSim.exe -inidirectory="./Regions/%SimName%" 
cd ..
echo %SimName% has exited.
