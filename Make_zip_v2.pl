
my $type  = '-V2.08';# '-Beta-V1.5';
my $dir = "C:\\Opensim\\OutworldzSource";

chdir ($dir);


use File::Copy;
use File::Path;
use 5.010;

my @deletions = (
				 "$dir/OutworldzFiles/AutoBackup",
				 "$dir/OutworldzFiles/Opensim/bin/assetcache",
				 "$dir/OutworldzFiles/Opensim/bin/j2kDecodeCache",
				 "$dir/OutworldzFiles/Opensim/bin/autobackup",
				 "$dir/OutworldzFiles/Opensim/bin/ScriptEngines",
				 "$dir/OutworldzFiles/Opensim/bin/maptiles",
				 "$dir/OutworldzFiles/Opensim/bin/Regions",
				 "$dir/OutworldzFiles/Opensim/bin/bakes",
				 "$dir/OutworldzFiles/mysql/data/opensim",
				 "$dir/OutworldzFiles/mysql/data/robust",
				 
				 );

foreach my $path ( @deletions) {
	rm($path);
}

#clean up opensim
unlink "$dir/OutworldzFiles/Opensim/bin/Opensim.log" ;
unlink "$dir/OutworldzFiles/Opensim/bin/Opensimstats.log" ;

unlink "$dir/OutworldzFiles/Opensim/bin/OpensimConsoleHistory.txt" ;
unlink "$dir/OutworldzFiles/Opensim-0.9/bin/OpensimConsoleHistory.txt" ;

unlink "$dir/OutworldzFiles/Opensim/bin/LocalUserStatistics.db" ;

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

unlink "../Zips/DreamGrid$type.zip" ;
unlink "../Zips/Outworldz-Update$type.zip" ;

say ("Start Mysql and wait for it to come up:");
<STDIN>;

chdir(qq!"$dir/OutworldzFiles/mysql/bin/!);
`"$dir\\OutworldzFiles\\mysql\\bin\\mysqlcheck.exe --port 3306 -u root -r mysql"`;
`"$dir\\OutworldzFiles\\mysql\\bin\\mysqlcheck.exe --port 3306 -u root -r opensim"`;
`"$dir\\OutworldzFiles\\mysql\\bin\\mysqlcheck.exe --port 3306 -u root -r robust"`;
`"$dir\\OutworldzFiles\\mysql\\bin\\mysqladmin.exe --port 3306 -u root shutdown"`;

unlink "$dir/OutworldzFiles/mysql/data/Alienware.err" ;
unlink "$dir/OutworldzFiles/mysql/data/Alienware.pid" ;

chdir ($dir);
# SIGN FIRST

if (!copy ("$dir/Signed_Binaries/Start.exe", $dir))  {die $!;}


print "Processing Main Zip\n";

my @files =   `cmd /c dir /b `;

foreach my $file (@files) {
	chomp $file;
	next if -d $file;
	#next if $file eq 'Make_zip_v2.pl';
	next if $file =~ /^\./;
	print  "$file ";
	Process ("../7z.exe -tzip a ..\\Zips\\DreamGrid$type.zip \"$dir\\$file\" ");
}

say("Adding folders");
Process ("../7z.exe -tzip a ..\\Zips\\DreamGrid-Update$type.zip Licenses_to_Content");
Process ("../7z.exe -tzip a ..\\Zips\\DreamGrid-Update$type.zip OutworldzFiles");
#Process ("../7z.exe -tzip a ..\\Zips\\DreamGrid-Update$type.zip Viewer");

Process ("../7z.exe -tzip a ..\\Zips\\DreamGrid$type.zip Licenses_to_Content");
Process ("../7z.exe -tzip a ..\\Zips\\DreamGrid$type.zip OutworldzFiles");


		
say("Updater Build");
if (!copy ("../Zips/DreamGrid$type.zip", "../Zips/DreamGrid-Update$type.zip"))  {die $!;}

say("Drop mysql files from update");
# now delete the mysql from the UPDATE
Process ("../7z.exe -tzip d ..\\Zips\\DreamGrid-Update$type.zip Outworldzfiles\\mysql\\data\\ -r ");



# del Dot net because we cannot overwrite an open file
Process ("../7z.exe -tzip d ..\\Zips\\DreamGrid-Update$type.zip DotNetZip.dll ");

#####################
print "Server Copy\n";

# Ready to move it all
unlink "y:/Inetpub/Secondlife/Outworldz_Installer/Grid/DreamGrid$type.zip";
if (!copy ("../Zips/DreamGrid$type.zip", "y:/Inetpub/Secondlife/Outworldz_Installer/Grid/DreamGrid$type.zip"))  {die $!;}

#web server
print "Server Copy Update\n";
unlink "y:/Inetpub/Secondlife/Outworldz_Installer/Grid/DreamGrid-Update$type.zip";
if (!copy ("../Zips/DreamGrid-Update$type.zip", "y:/Inetpub/Secondlife/Outworldz_Installer/Grid/DreamGrid-Update$type.zip"))  {die $!;}

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
		print "Ok\n";
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
	
	#exit(1) if $errors;
}
