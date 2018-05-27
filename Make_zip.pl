
my $type  = '-V1.77';# '-Beta-V1.5';

 use Cwd;
my $dir = getcwd;

use File::Copy;
use File::Path;
use 5.010;

my @deletions = (
				 "$dir/OutworldzFiles/AutoBackup",
				 "$dir/OutworldzFiles/mysql/data/opensim",
				 
				 "$dir/OutworldzFiles/Opensim/bin/assetcache",
				 "$dir/OutworldzFiles/Opensim/bin/j2kDecodeCache",
				 "$dir/OutworldzFiles/Opensim/bin/autobackup",
				 "$dir/OutworldzFiles/Opensim/bin/ScriptEngines",
				 "$dir/OutworldzFiles/Opensim/bin/maptiles",
				 "$dir/OutworldzFiles/Opensim/bin/bakes",
				 
				 "$dir/OutworldzFiles/Opensim-0.9/bin/assetcache",
				 "$dir/OutworldzFiles/Opensim-0.9/bin/j2kDecodeCache",
				 "$dir/OutworldzFiles/Opensim-0.9/bin/autobackup",
				 "$dir/OutworldzFiles/Opensim-0.9/bin/ScriptEngines",
				 "$dir/OutworldzFiles/Opensim-0.9/bin/maptiles",
				 "$dir/OutworldzFiles/Opensim-0.9/bin/bakes",
				 
				 "$dir/OutworldzFiles/mysql/data/opensim",
				 "$dir/OutworldzFiles/mysql/data/addin-db-002",
				 "$dir/OutworldzFiles/mysql/data/fsassets",
				 
				 
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

#mysql
unlink "$dir/OutworldzFiles/mysql/data/Alienware.err" ;
unlink "$dir/OutworldzFiles/mysql/data/Alienware.pid" ;
unlink	"$dir/OutworldzFiles/mysql/data/ib_logfile0" || die;
unlink	"$dir/OutworldzFiles/mysql/data/ib_logfile1" || die;
unlink	"$dir/OutworldzFiles/mysql/data/ibdata1" || die;



unlink "../Zips/Outworldz$type.zip" ;
unlink "../Zips/Outworldz-Update$type.zip" ;

say ("Start Mysql and wait for it to come up:");
<STDIN>;

chdir(qq!$dir/OutworldzFiles/mysql/bin/!);

print `mysqlcheck.exe --port 3309 -u root -r mysql`;
print `mysqlcheck.exe --port 3309 -u root -r opensim`;
print `mysqladmin.exe --port 3309 -u root shutdown`;

print "Processing Main Zip\n";

my @files =   glob("'$dir\\*'");

foreach (@files) {
	next if -d $_;
	next if $_ eq 'Make_zip.pl';
	Process ("../7z.exe -tzip a ..\\Zips\\Outworldz$type.zip \"$_\" ");
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
	while ($_ = glob("'$path/*'")) {
		rmtree($_)
		  or ++$errors, warn("Can't remove $_: $!");
	}
	
	exit(1) if $errors;
}