@echo OFF
echo.
echo.
echo|set /p=Starting 
.\bin\icecast.exe -v
echo Using config "icecast_run.xml" from Outworldzfiles\Icecast directory ...
echo.
echo.
echo Leave this window open to keep Icecast running. You may minimize it.
.\bin\icecast.exe -c .\icecast_run.xml

