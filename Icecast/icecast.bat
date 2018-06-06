@echo OFF
echo.
echo.
echo|set /p=Starting 
.\bin\icecast.exe -v
echo Using config "icecast.xml" from installation directory ...
echo.
echo Please open http://localhost:8080 or http://127.0.0.1:8080 in your web browser to see the web interface.
echo.
echo.
echo Leave this window open to keep Icecast running and, if necessary, minimize it.
.\bin\icecast.exe -c .\icecast_run.xml

