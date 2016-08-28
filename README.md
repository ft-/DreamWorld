# DreamWorld
An simple automatic installer for an Opensimulator Western town simulation In VB Dot Net

Diva OpenSim distro, while easy for you, is not easy for new people.   Specifically, there is no easy way to create a shortcut the the opensim.exe that is portable across drives, and a mesh-compliant viewer must be installed and started with a specific "--loginuri" command line.  That is what this installer does.

"Diva Distro" sim-in-a-stick is included, but it is an old on at version 0.7.4. I hope to update this soon.

Some mods were made to index.htm and links.htm for graphics and an Up.htm web page was inserted to allow easy detection of the server.   

It detects if the folder it is running from is already installed to.  If so, a Start Button is made.

Buttons are set for Setup and the folder for disk drivesis populated with any online drives that are R/W.

Upon completion of the file copy, the program Displays a Start button.

Runing the actual simulator system requires 3 progams to be running to operate: Mowes.exe, Opensim, and the viewer. 

Mowes.exe starts a web server and MySQL database.  The installer detects this completion by probing the web server for a new file 'Up.htm' that is placed in the \DreamWorldFiles\www\start\Up.htm folder.  using the URL http://127.0.0.1:62535/start/up.htm

The Installer then launchs Opensim.  The installer detects this as being up by probing the web server for an Up.htnm file located in \DreamWorldFiles\diva-r20232-b\WifiPages using the URL http://127.0.0.1:9100/wifi/up.htm

After these ops succeed, the Firestorm viewer is launched with the local login URI.

ForeverWorld Version 0.7.4.1   2/7/2013

1) Navigate to \Setup and run Click "Start ForEverVirtualWorld.exe"
2) Pick a disk drive for the files to install on 
3) Click "Install"  The system will copy files for several minutes 
4) A setup program for "Phoenix Firestorm" will launch. Install it.
5) After the programs are installed, Click "Start"
6) Several programs will appear. These includes Mowes and OpenSim windows.  If your firewall is operating as it should, a series of requests to send data through the firewall will appear.   No personal data is sent when you authorize this app.  
6) The Phoenix viewer will appear. 
7) Log in as "Dream Guy"or "Dream Girl" with the password '123'.

The next time you wish to log in, navigate to "ForEverVirtual" folder and slick "Start.exe"

To shut down: 

Click the OpenSim window and type 'Quit<ret>'.
Click the Mowes Window and click "End'. You may have to click "Hide" to see the "End" button.

==================
This application requires 2 or more GB of free disk space and a good 3-D graphics card.

Windows 		Minimum Requirements 		Recommended
Operating System: 	Windows 7 			Windows 7, 8 or 10
Computer Processor: 	CPU with SSE2 support, 		Dual Core 
			including Intel Pentium 4, 
			Pentium M, Core or Atom, 
			AMD Athlon 64 or later. 	1.5 GHz (XP), 2-GHz (Vista) 32-bit (x86) or better
Computer Memory: 	512 MB or more 			3 GB or more
Screen Resolution: 	1024x768 pixels 		1024x768 pixels or higher

Troubleshooting:

The following graphics cards are NOT compatible:

    NVIDIA cards that report as a RIVA TNT or TNT2
    ATI cards that report as RAGE, RAGE PRO, or RADEON 320M, 340M, 345M, or similar model numbers
    Intel chipsets less than a 945 including Intel Extreme
    Cards with the following branding: 3DFX, RIVA, TNT, SiS, S3, S3TC, Savage, Twister, Rage, Kyro, MILENNIA, MATROX


Speed: 

If it is very slow, check that you have a 3-D capable graphics card.   You can asjust many settings in Phoenix aftre logging in with the Ctrl-P menu.

If it crashes, check that you have the latest graphics drivers:

    ATI/AMD drivers are at http://support.amd.com/us/gpudownload/Pages/index.aspx
    NVIDIA drivers are at http://www.nvidia.com/Download/index.aspx
    Intel drivers are at http://www.intel.com/p/en_US/support/graphics

The following procedure, called a clean install, will often fix problems related to graphics cards and drivers:

    Download the latest graphics driver from the chipset manufacturer (ATI, Nvidia, or Intel), not the maker of your graphics card or computer. Save the file where you can easily find it, but do not install it yet.
    Run Windows Update and make sure your system is fully patched.
    Reboot your computer and enter Safe Mode by pressing F8 at the Windows logo screen.
    Uninstall your old video driver. On Windows XP use Control Panel > System > Hardware > Device Manager (steps will be different on other operating systems). Then open Display Adapters, right-click and choose Uninstall.
    Reboot your computer.
    If Windows displays a message that it found new hardware, do not let it automatically install drivers. Instead, run the installation program that you downloaded in step 1.
    Reboot your computer





