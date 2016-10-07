-- sql script to create the users instead of using OEM

-- create the oranetuser user
create user oranetuser identified by demo
default tablespace users
temporary tablespace temp
quota unlimited on users;

grant alter session, create procedure, create sequence, create session, create
table, create trigger to oranetuser;

-- create the oranetadmin user
create user oranetadmin identified by demo
default tablespace users
temporary tablespace temp
quota unlimited on users;

grant dba to oranetadmin;
