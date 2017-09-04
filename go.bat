
echo Loading %1
@echo off
cls
cd Outworldzfiles\Opensim\bin
set SimName=%1 %2 %3 %4 %5
OpenSim.exe -inidirectory="./Regions/%SimName%" 
cd ..\..\..
echo %SimName% has exited.
