
--1)
DECLARE @NUMBER INT=0
BEGIN TRY
	select active/@number as error
	from employee
END TRY
BEGIN CATCH
  select 
       ERROR_NUMBER() AS error_number,
	   ERROR_MESSAGE() AS error_message,
	   ERROR_LINE() AS error_line
END CATCH 


--2)
CREATE PROCEDURE EMP_DETAILS @NUMBER INT
AS
BEGIN
	BEGIN TRY
		select id,name,active/@number
		from employee
	END TRY
	BEGIN CATCH
		select 
		   ERROR_NUMBER() AS error_number,
		   ERROR_MESSAGE() AS error_message,
		   ERROR_LINE() AS error_line,
		   ERROR_PROCEDURE() AS procedure_name
	END CATCH
END
EXEC EMP_DETAILS 0


--3)
CREATE PROCEDURE show_emp_details @ID VARCHAR(10),@NAME VARCHAR(30),@ACTIVE INT
AS
BEGIN
	 BEGIN TRANSACTION
		BEGIN TRY
			insert into employee(id,name,active) values (@ID,@NAME,@ACTIVE)
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			IF(@@TRANCOUNT >0)
				ROLLBACK TRANSACTION

			SELECT
			   ERROR_NUMBER() AS error_number,
			   ERROR_MESSAGE() AS error_message,
			   ERROR_LINE() AS error_line,
			   ERROR_SEVERITY() AS error_severity,
			   ERROR_STATE() AS error_state,
			   ERROR_PROCEDURE() AS procedure_name
		END CATCH
END

EXEC show_emp_details 'E016','SAHIL',1


--4)
CREATE PROCEDURE EMPDATA @ID VARCHAR(10),@NAME VARCHAR(30),@ACTIVE INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			insert into employee(id,name,active) values (@ID,@NAME,@ACTIVE)
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		IF(@@TRANCOUNT >0)
			ROLLBACK TRANSACTION
	
		DECLARE @error_message VARCHAR(MAX)='Cannot insert duplicate values';
		    
		THROW 50000, @error_message, 1;
			 
	END CATCH
END 

EXEC EMPDATA 'E012','SAHIL',1


