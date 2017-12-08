cd bin\addon-modules
git clone https://github.com/JakDaniels/OpenSimBirds.git
cd .. 
cd ..
call prebuild.bat
call compile.bat
cd bin

@rem Installing Diva Wifi and registering the birds module:
mautil.exe -reg "." reg-update
mautil.exe -reg "." rep-add http://metaverseink.com/repo
mautil.exe -reg "." rep-update
@rem You can now see the list of all the available addins:
mautil.exe -reg "." list-av
@rem Install the Diva.Wifi addin:
mautil.exe -reg "." install Diva.Wifi
mautil.exe -reg "." install Diva.MISearchModules

