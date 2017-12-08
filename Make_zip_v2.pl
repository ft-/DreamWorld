
my $type  = '-V2.0 Beta';# '-Beta-V1.5';

my $rev = 'V2.0';
my $dir = "C:\\Opensim\\Outworldz-Source";


chdir ($dir);
use File::Copy;
use File::Path;
use 5.010;

my @deletions = ("$dir/OutworldzFiles/addins-registry",
				 "$dir/OutworldzFiles/AutoBackup",
				 
				 "$dir/OutworldzFiles/Opensim/bin/assetcache",
				 "$dir/OutworldzFiles/Opensim/bin/j2kDecodeCache",
				 "$dir/OutworldzFiles/Opensim/bin/autobackup",
				 "$dir/OutworldzFiles/Opensim/bin/ScriptEngines",
				 "$dir/OutworldzFiles/Opensim/bin/maptiles",
				 "$dir/OutworldzFiles/Opensim/bin/addin-db-002",
				 "$dir/OutworldzFiles/Opensim/bin/bakes",
				 
				 "$dir/OutworldzFiles/Opensim-0.9/bin/assetcache",
				 "$dir/OutworldzFiles/Opensim-0.9/bin/j2kDecodeCache",
				 "$dir/OutworldzFiles/Opensim-0.9/bin/autobackup",
				 "$dir/OutworldzFiles/Opensim-0.9/bin/ScriptEngines",
				 "$dir/OutworldzFiles/Opensim-0.9/bin/maptiles",
				 "$dir/OutworldzFiles/Opensim-0.9/bin/addin-db-002",
				 "$dir/OutworldzFiles/Opensim-0.9/bin/bakes",
				 "$dir/OutworldzFiles/mysql/data/opensim",
				 "$dir/OutworldzFiles/mysql/data/robust",
				 );

foreach my $path ( @deletions) {
	rm($path);
}

#clean up opensim
unlink "$dir/OutworldzFiles/Opensim/bin/Opensim.log" ;
unlink "$dir/OutworldzFiles/Opensim-0.9/bin/Opensim.log" ;

unlink "$dir/OutworldzFiles/Opensim/bin/Opensimstats.log" ;
unlink "$dir/OutworldzFiles/Opensim-0.9/bin/Opensimstats.log" ;


unlink "$dir/OutworldzFiles/Opensim/bin/OpensimConsoleHistory.txt" ;
unlink "$dir/OutworldzFiles/Opensim-0.9/bin/OpensimConsoleHistory.txt" ;

unlink "$dir/OutworldzFiles/Opensim/bin/LocalUserStatistics.db" ;
unlink "$dir/OutworldzFiles/Opensim-0.9/bin/LocalUserStatistics.db" ;

#mysql
unlink "$dir/OutworldzFiles/mysql/data/Alienware.err" ;
unlink "$dir/OutworldzFiles/mysql/data/Alienware.pid" ;
unlink	"$dir/OutworldzFiles/mysql/data/ib_logfile0";
unlink	"$dir/OutworldzFiles/mysql/data/ib_logfile1";
unlink	"$dir/OutworldzFiles/mysql/data/ibdata1";

#logs
unlink "$dir/OutworldzFiles/Diagnostics.log" ;
unlink "$dir/OutworldzFiles/Outworldz.log" ;
unlink "$dir/OutworldzFiles/Init.txt" ;
unlink "$dir/OutworldzFiles/upnp.log" ;


unlink "../Zips/Outworldz$type.zip" ;
unlink "../Zips/Outworldz-Update$type.zip" ;

print "Making binaries, please be sure they are signed\n";


# SIGN FIRST

#unlink "y:/Inetpub/Secondlife/Outworldz_Installer/Updater.exe" || die $!;
#unlink "y:/Inetpub/Secondlife/Outworldz_Installer/Outworldz_Installer.exe" || die $!;

#if (!copy  ("$dir/Signed_Binaries/Updater.exe" ,"y:/Inetpub/Secondlife/Outworldz_Installer/Updater.exe"))  {die $!;}
#if (!copy  ("$dir/Signed_Binaries/Outworldz_Installer.exe" ,"y:/Inetpub/Secondlife/Outworldz_Installer/Outworldz_Installer.exe"))  {die $!;}

if (!copy ("$dir/Signed_Binaries/Start.exe", $dir))  {die $!;}
#if (!copy ("$dir/Signed_Binaries/Start.exe.config", $dir))  {die $!;}

print "Processing Main Zip\n";

my @files =   glob("$dir\\*");

foreach (@files) {
	next if -d $_;
	Process ("../7z.exe -tzip a ..\\Zips\\Outworldz$type.zip $_ ");
}

say("Adding folders");
Process ("../7z.exe -tzip a ..\\Zips\\Outworldz-Update$type.zip Licenses_to_Content");
Process ("../7z.exe -tzip a ..\\Zips\\Outworldz-Update$type.zip OutworldzFiles");
Process ("../7z.exe -tzip a ..\\Zips\\Outworldz-Update$type.zip Viewer");

Process ("../7z.exe -tzip a ..\\Zips\\Outworldz$type.zip Licenses_to_Content");
Process ("../7z.exe -tzip a ..\\Zips\\Outworldz$type.zip OutworldzFiles");
Process ("../7z.exe -tzip a ..\\Zips\\Outworldz$type.zip Viewer");

		
say("Updater Build");
if (!copy ("../Zips/Outworldz$type.zip", "../Zips/Outworldz-Update$type.zip"))  {die $!;}

say("Drop mysql files");
# now delete the mysql from the UPDATE
Process ("../7z.exe -tzip d ..\\Zips\\Outworldz-Update$type.zip Outworldzfiles\\mysql\\data -r ");


# Dot net because we cannot overwrite an open file
Process ("../7z.exe -tzip d ..\\Zips\\Outworldz-Update$type.zip DotNetZip.dll ");

say("Remove Outworldz.ini");
# and Outworldz.ini so we do not end up with both Outworldz and RegionConfig.ini
Process ("../7z.exe -tzip d ..\\Zips\\Outworldz-Update$type.zip OutworldzFiles\\Opensim\\bin\\Regions\\Outworldz.ini");		
Process ("../7z.exe -tzip d ..\\Zips\\Outworldz-Update$type.zip OutworldzFiles\\Opensim-0.9\\bin\\Regions\\Outworldz.ini");	


#####################
print "Server Copy\n";

# Ready to move it all
unlink "y:/Inetpub/Secondlife/Outworldz_Installer/Grid/Outworldz$type.zip";
if (!copy ("../Zips/Outworldz$type.zip", "y:/Inetpub/Secondlife/Outworldz_Installer/Grid/Outworldz$type.zip"))  {die $!;}

#web server
print "Server Copy Update\n";
unlink "y:/Inetpub/Secondlife/Outworldz_Installer/Grid/Outworldz-Update$type.zip";
if (!copy ("../Zips/Outworldz-Update$type.zip", "y:/Inetpub/Secondlife/Outworldz_Installer/Grid/Outworldz-Update$type.zip"))  {die $!;}

# lastly revisions file
if (!copy ('Revisions.txt', 'y:/Inetpub/Secondlife/Outworldz_Installer/Revisions.txt'))  {die $!;}

print "Done!";

sub Write
{
	my $dest = shift;
	my $content = shift;
	open OUT, ">$dest" || die $!;
	print OUT $content;
	close OUT;
}

sub Process
{
	my $file = shift;
	my $x = `$file`;
	if ($x =~ /Everything is Ok/) {
		print "Okay $file\n";
	} else {
		print "Fail: $x\n";
		exit;
	}
}

sub rm {
	
my $path = shift;
	
	my $errors;
	while ($_ = glob("$path/*")) {
		rmtree($_)
		  or ++$errors, warn("Can't remove $_: $!");
	}
	
	exit(1) if $errors;
}
