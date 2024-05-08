
--TABLE CREATION 
create table department 
(
id varchar(10) primary key not null,
name varchar(30)  not null
)

create table roles 
(
id varchar(10) primary key not null,
name varchar(30)  not null
)

create table reporting 
(
id varchar(10) primary key not null,
l2 varchar(10) ,
l1 varchar(10) 
)

create table emp_active_date 
(
id varchar(10) primary key not null,
active_from date ,
resigned_on date
)

create table employee
(
 id varchar(10) primary key not null,
 name varchar(63) not null,
 department_id varchar(10) foreign key references department(id) ,
 active int ,
 gender varchar(2),
 role_id varchar(10) foreign key references roles(id)
)

--INSERTING VALUES 
insert into  department values
('D001','development'),
('D002','HR')

insert into  roles values
('R001','TEAM LEAD'),
('R002','SR. DEVELOPER'),
('R003','DEVLOPER'),
('R004','MANAGER'),
('R005','SR. MANAGER'),
('R006','EXE. MANAGER')

insert into  reporting values
('E001','NULL','NULL'),
('E002','NULL','E001'),
('E003','E002','E001'),
('E004','NULL','NULL'),
('E005','NULL','E004'),
('E006','E005','E004'),
('E007','NULL','NULL'),
('E008','NULL','E007'),
('E009','E008','E007'),
('E010','E008','E007')

insert into  employee values
('E001','RAJKUMAR','D001',1,'M','R001'),
('E002','GANESH','D001',1,'M','R002'),
('E003','RAGHU'	,'D001',1,'M','R003'),
('E004','CHITRA','D001',1,'F','R001'),
('E005','PRIYA','D001',1,'F','R002'),
('E006','PREM KUMAR','D001','1','M','R003'),
('E007','KRISHNA','D002',1,'M','R006'),
('E008','PREETHI','D002',1,'F','R005'),
('E009','RAVI','D002',0	,'M','R004'),
('E010','MEENA','D002',1,'F','R004')

insert into  emp_active_date values
('E001','2015/01/02',NULL),
('E002','2016/03/01',NULL),
('E003','2018/01/02',NULL),
('E004','2014/11/01',NULL),
('E005','2015/02/01',NULL),
('E006','2019/01/02',NULL),
('E007','2013/01/02',NULL),
('E008','2015/01/02',NULL),
('E009','2017/11/05','2020-10-31'),
('E010','2015/01/02',NULL)


select * from employee
select * from department
select * from roles
select * from reporting
select * from emp_active_date

--1
SELECT D.ID ,D.NAME,COUNT(D.ID) AS STRENGTH
FROM DEPARTMENT D
JOIN  EMPLOYEE E
ON E.DEPARTMENT_ID =D.ID
GROUP BY D.ID,D.NAME

--2
select e1.id ,
e1.name as employee,
e2.name as L2,
e3.name as L1
from reporting r
left join employee e1 on e1.id=r.id
left join employee e2 on e2.id=r.l2
left join employee e3 on e3.id=r.l1

--3)
select  e.id as id,
e.name as employee,
e.department_id as department, 
e.role_id as role,
e.active as status ,
e.gender as gender ,
CONCAT (
FLOOR(DATEDIFF(YEAR,CAST(d.active_from AS DATE),CAST(GETDATE() AS DATE))), ' years ' ,
DATEDIFF(MONTH,CAST(d.active_from AS DATE),CAST(GETDATE() AS DATE))%12, ' months ',
FLOOR((DATEDIFF(DAY,CAST(d.active_from AS DATE),CAST(GETDATE() AS DATE))%365.25)%12), ' days '
) AS term
from employee e
join emp_active_date d
on d.id=e.id



--4)
select  e.id as id,
e.name as employee,
e.department_id as department, 
(select DATEDIFF(DAY,CAST(d.active_from AS DATE),CAST(GETDATE() AS DATE))) as days 
from employee e
join emp_active_date d
on d.id=e.id
where DATEDIFF(DAY,CAST(d.active_from AS DATE),CAST(GETDATE() AS DATE)) >2500

--5)
select d.name as DEPARTMENT , 
      CAST(CAST(  
				  SUM(CASE 
						 when e.gender='f' then 1
						 ELSE 0
					   END )  AS FLOAT) /(COUNT (e.id))*100  AS DECIMAL(4,2)) AS PERCENTAGE
FROM employee e 
join department d
on  e.department_id=d.id 
where e.active=1
group by d.name

