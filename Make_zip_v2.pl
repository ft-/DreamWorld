
my $type  = '-V2.42' ;  # '-Beta-V1.5';
my $dir = "E:/Opensim/Outworldz Dreamgrid Source";

chdir ($dir);
use Cwd;
my $curdir =getcwd;

print $curdir . ' ' .  $type . "\n";
die if $curdir ne $dir ;

use File::Copy;
use File::Path;
use 5.010;



my @deletions = (
	"$dir/OutworldzFiles/Opensim/bin/assetcache",
	"$dir/OutworldzFiles/Opensim/bin/j2kDecodeCache",
	"$dir/OutworldzFiles/Opensim/bin/MeshCache",
	"$dir/OutworldzFiles/Opensim/bin/ScriptEngines",
	"$dir/OutworldzFiles/Opensim/bin/maptiles",
	"$dir/OutworldzFiles/Opensim/bin/Regions",
	"$dir/OutworldzFiles/Opensim/bin/bakes",
	"$dir/OutworldzFiles/mysql/data/opensim",
	"$dir/OutworldzFiles/mysql/data/robust",
	"$dir/OutworldzFiles/mysql/data/addin-db-002",
	"$dir/OutworldzFiles/mysql/data/fsassets",
);

foreach my $path ( @deletions) {
	rm($path);
}

#clean up opensim
unlink "$dir/OutworldzFiles/Opensim/bin/Opensim.log" ;
unlink "$dir/OutworldzFiles/Opensim/bin/Opensimstats.log" ;
unlink "$dir/OutworldzFiles/Photo.png";
unlink "$dir/Icecast/error.log" ;
unlink "$dir/Icecast/access.log" ;

unlink "$dir/OutworldzFiles/Opensim/bin/OpensimConsoleHistory.txt" ;
unlink "$dir/OutworldzFiles/Opensim-0.9/bin/OpensimConsoleHistory.txt" ;
unlink "$dir/OutworldzFiles/Opensim/bin/LocalUserStatistics.db" ;

#Setting
unlink "$dir/Outworldzfiles/Settings.ini" ;


#logs
unlink "$dir/OutworldzFiles/Diagnostics.log" ;
unlink "$dir/OutworldzFiles/Outworldz.log" ;
unlink "$dir/OutworldzFiles/Init.txt" ;
unlink "$dir/OutworldzFiles/upnp.log" ;
unlink "$dir/OutworldzFiles/http.log" ;

unlink "../Zips/DreamGrid$type.zip" ;
unlink "../Zips/Outworldz-Update$type.zip" ;

say("Signing");
use IO::All;

my @files = io->dir($dir)->all(0);  

foreach my $file (@files) {
    my $name = $file->name;
    next if $name =~ /Installer_Src|\.git/;
    if ($name =~ /dll$|exe$/ ) {
        
        my $r = qq!../Certs/sigcheck64.exe "$name"!;
        print $r. "\n";
        my $result1 = `$r`;
        if ($result1 =~ /Publisher:.*Outworldz, LLC/) {
            next;
        }
        
        my $f = qq!../Certs/DigiCertUtil.exe sign /noInput /sha1 "52CADF8EA98C9382D0350815A68B2C79340E141F" "$name"!;
        print $f;
        my $result = `$f`;
        print $result. "\n";
        if ($result !~ /success/) {
            die;
        }
    }
}

# mysql
chdir(qq!$dir/OutworldzFiles/mysql/bin/!);
print `mysqladmin.exe --port 3309 -u root shutdown`;

unlink	"$dir/OutworldzFiles/mysql/data/ib_logfile0" || die;
unlink	"$dir/OutworldzFiles/mysql/data/ib_logfile1" || die;
unlink	"$dir/OutworldzFiles/mysql/data/ibdata1" || die;

#say ("Start Mysql and wait for it to come up:");
#<STDIN>;
#
#print `mysqlcheck.exe --port 3309 -u root -r mysql`;
#print `mysqlcheck.exe --port 3309 -u root -r opensim`;
#print `mysqlcheck.exe --port 3309 -u root -r robust`;
#print `mysqladmin.exe --port 3309 -u root shutdown`;


#mysql
unlink "$dir/OutworldzFiles/mysql/data/Mach.err" ;
unlink "$dir/OutworldzFiles/mysql/data/Mach.pid" ;

unlink "$dir/OutworldzFiles/mysql/data/Alienware.err" ;
unlink "$dir/OutworldzFiles/mysql/data/Alienware.pid" ;

chdir ($dir);


print "Processing Main Zip\n";


@files =   `cmd /c dir /b `;

foreach my $file (@files) {
	chomp $file;
	next if -d $file;
	#next if $file eq 'Make_zip_v2.pl';
	next if $file =~ /^\./;
	print  "$file ";
	Process ("../7z.exe -tzip a ..\\Zips\\DreamGrid$type.zip \"$dir\\$file\" ");
}

say("Adding folders");
#Process ("../7z.exe -tzip a ..\\Zips\\DreamGrid-Update$type.zip Licenses_to_Content");
#Process ("../7z.exe -tzip a ..\\Zips\\DreamGrid-Update$type.zip OutworldzFiles");
#Process ("../7z.exe -tzip a ..\\Zips\\DreamGrid-Update$type.zip Viewer");

Process ("../7z.exe -tzip a ..\\Zips\\DreamGrid$type.zip Licenses_to_Content");
Process ("../7z.exe -tzip a ..\\Zips\\DreamGrid$type.zip OutworldzFiles");

		
say("Updater Build");
if (!copy ("../Zips/DreamGrid$type.zip", "../Zips/DreamGrid-Update$type.zip"))  {die $!;}

say("Drop mysql files from update");
# now delete the mysql from the UPDATE
Process ("../7z.exe -tzip d ..\\Zips\\DreamGrid-Update$type.zip Outworldzfiles\\mysql\\data\\ -r ");

say ("Dropping Setting.ini from update");
Process ("../7z.exe -tzip d ..\\Zips\\DreamGrid-Update$type.zip Outworldzfiles\\Settings.ini -r ");

say ("Dropping Perl  from both");
Process ("../7z.exe -tzip d ..\\Zips\\DreamGrid-Update$type.zip Make_zip_v2.pl -r ");
Process ("../7z.exe -tzip d ..\\Zips\\DreamGrid$type.zip Make_zip_v2.pl -r ");

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

print "Server Publish?\n";
<stdin>;

unlink "y:/Inetpub/Secondlife/Outworldz_Installer/Grid/DreamGrid.zip";
if (!copy ("../Zips/DreamGrid$type.zip", "y:/Inetpub/Secondlife/Outworldz_Installer/Grid/DreamGrid.zip"))  {die $!;}
unlink "y:/Inetpub/Secondlife/Outworldz_Installer/Grid/DreamGrid-Update.zip";
if (!copy ("../Zips/DreamGrid-Update$type.zip", "y:/Inetpub/Secondlife/Outworldz_Installer/Grid/DreamGrid-Update.zip"))  {die $!;}


# lastly revisions file
if (!copy ('Revisions.txt', 'y:/Inetpub/Secondlife/Outworldz_Installer/Revisions.txt'))  {die $!;}
if (!copy ('Revisions.txt', 'y:/Inetpub/Secondlife/Outworldz_Installer/Grid/Revisions.txt'))  {die $!;}





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
		print "\n";
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
