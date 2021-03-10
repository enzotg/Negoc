use master;

alter database negoc set single_user with rollback immediate
restore database negoc from disk=N'd:\code\vs2017\negoc\negocback.bak'  
alter database negoc set MULTI_USER