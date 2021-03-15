use master;

alter database negoc set single_user with rollback immediate
restore database negoc from disk='d:\code\vs2017\negoc\negocback.bak'  with
MOVE 'Negoc' TO 'd:\code\vs2017\negoc\negoc_Data.mdf',   
MOVE 'Negoc_log' TO 'd:\code\vs2017\negoc\negoc_Log.ldf', REPLACE;  

alter database negoc set MULTI_USER