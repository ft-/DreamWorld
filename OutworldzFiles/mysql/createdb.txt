mysql -u root
create database opensim;
use opensim;
create user 'opensimuser'@'localhost' identified by 'opensimpassword';
grant all on opensim.* to 'opensimuser'@'localhost';
quit