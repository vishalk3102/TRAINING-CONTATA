
--INSERT CONSTRAINTS 
CREATE TABLE EMPLOYEES(
employeeID int  identity(1000,1) primary key,
firstName varchar(30) not null,
lastName varchar(30) not null ,
age int check(age>=18) ,
department varchar(50) not null 
)


INSERT INTO  EMPLOYEES( firstName,lastName,age,department) 
VALUES ('John', 'Doe', 30, 'Sales'), 
('Jane', 'Smith', 25, 'Marketing'), 
('Alice', 'Johnson', 35, 'HR'), 
('Bob', 'Williams', 28, 'IT'); 


--AUTO INCREMENT
INSERT INTO EMPLOYEES VALUES('Michael','Brown',32,'Finance')
INSERT INTO EMPLOYEES VALUES('Emily','Clark',29,'Operations')


--DELETE 
DELETE FROM EMPLOYEES
WHERE firstName='john'


--TRUNCATE
TRUNCATE TABLE EMPLOYEES

--DROP
DROP TABLE EMPLOYEES


--INDEXES
CREATE INDEX idx_employees_department
ON EMPLOYEES (department)

SELECT * FROM EMPLOYEES
WHERE department='IT'


SELECT * FROM EMPLOYEES