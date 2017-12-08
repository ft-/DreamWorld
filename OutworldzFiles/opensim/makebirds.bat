
@rem commands to Compile and install Opensim Birds
cd addon-modules
git clone https://github.com/JakDaniels/OpenSimBirds
cd ../
call runprebuild.bat
call compile.bat
cd bin
mautil -reg . reg-update
