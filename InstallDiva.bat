cd Outworldzfile\opensim\bin
mautil.exe -reg ../addins-registry  reg-update
mautil.exe -reg ../addins-registry  rep-add http://metaverseink.com/repo
mautil.exe -reg ../addins-registry  reg-update
mautil.exe -reg ../addins-registry  list-av

mautil.exe -reg ../addins-registry  install Diva.Wifi
@rem mautil.exe -reg ../addins-registry  install Diva.MISearchModules
mautil.exe -reg ../addins-registry  reg-update