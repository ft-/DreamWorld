cd bin
mautil.exe -reg ../../addins-registry reg-update
mautil.exe -reg ../../addins-registry rep-add http://metaverseink.com/repo
mautil.exe -reg ../../addins-registry reg-update
mautil.exe -reg ../../addins-registry  list-av
@pause
mautil.exe -reg ../../addins-registry  install Diva.Wifi
