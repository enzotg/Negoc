use master;

alter database negoc set single_user with rollback immediate
<<<<<<< HEAD
restore database negoc from disk=N'd:\negocback.bak'  
=======
restore database negoc from disk='d:\code\vs2017\negoc\negocback.bak'  with
MOVE 'Negoc' TO 'd:\code\vs2017\negoc\negoc_Data.mdf',   
MOVE 'Negoc_log' TO 'd:\code\vs2017\negoc\negoc_Log.ldf', REPLACE;  

>>>>>>> 732283587911371be4fc8312a3aa766a48e3ce57
alter database negoc set MULTI_USER