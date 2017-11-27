
@rem commands to Compile and install Opensim Birds
cd addon-modules
git clone https://github.com/Outworldz/OpenSimBirds.git
cd ../
call runprebuild.bat
call compile.bat
cd bin
mautil -reg ../addins-config reg-update
