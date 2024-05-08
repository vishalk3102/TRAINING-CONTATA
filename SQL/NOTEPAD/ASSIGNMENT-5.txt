
--CREATE TABLE 
create table orders
(
orderid int identity(1,1) primary key ,
orderdate date ,
orderprice int,
orderqty int,
name varchar(10)
)

--INSERT INTO TABLE 
insert into orders values
('2005/12/22',160,2,'smith'),
('2005/08/10',190,2,'johnson'),
('2005/07/13',500,5,'baldwin'),
('2005/07/15',420,2,'smith'),
('2005/12/22',1000,4,'wood'),
('2005/10/02',820,4,'smith'),
('2005/11/03',2000,2,'baldwin')

select * from orders


--1
--1.1)
select count(*)as no_of_orders from orders
where name='smith'

--1.2)
select *
from orders a
where 2= (
			select count(distinct b.orderprice) from orders b
			where b.orderprice >= a.orderprice
          )

--1.3)
select sum(orderprice) as total
from orders 

--1.4)
select orderid,avg(orderqty) as average_per_order
from orders
group by orderid

--1.5)
select avg(orderprice) as average_price
from orders
where orderprice >200

--1.6)
select min(orderprice) from orders

--1.7)
select max(orderprice) from orders




--2)
create table emp
(
id int identity(1,1) primary key,
name  varchar(10) not null  ,
joining_date date,
leaving_date date
)

insert into emp values 
('vishal','2024/02/02',NULL),
('sahil','2019/03/01','2023/11/01'),
('shrey','2018/01/02','2023/11/01'),
('geetansh','2020/11/01','2022/11/01'),
('saksham','2020/02/01','2021/11/01')

select * from emp

--2)
UPDATE EMP
SET NAME =CONCAT (UPPER(LEFT(name,2)),LOWER(SUBSTRING ( NAME, 3, LEN(NAME)-3 )),UPPER(RIGHT(name,1)))
from emp

--3.1)
SELECT * FROM emp
WHERE leaving_date is not NULL

--3.2)
SELECT name ,
(CASE  
    WHEN leaving_date IS NULL  THEN (
	CONCAT (
			FLOOR(DATEDIFF(YEAR,CAST(joining_date AS DATE),CAST(GETDATE() AS DATE))), ' years ' ,
			DATEDIFF(MONTH,CAST(joining_date AS DATE),CAST(GETDATE() AS DATE))%12, ' months ',
			FLOOR((DATEDIFF(DAY,CAST(joining_date AS DATE),CAST(GETDATE() AS DATE))%365.25)%12), ' days '
			) )
	ELSE  (
	CONCAT (
			FLOOR(DATEDIFF(YEAR,CAST(joining_date AS DATE),CAST(leaving_date AS DATE))), ' years ' ,
			DATEDIFF(MONTH,CAST(joining_date AS DATE),CAST(leaving_date AS DATE))%12, ' months ',
			FLOOR((DATEDIFF(DAY,CAST(joining_date AS DATE),CAST(leaving_date AS DATE))%365.25)%12), ' days '
			) )
END  ) AS duration 
FROM emp

--4)
SELECT * ,
(CASE  
    WHEN leaving_date IS NULL  THEN (DATEDIFF(DAY,CAST(joining_date AS DATE),CAST(GETDATE() AS DATE)) )
	ELSE  (DATEDIFF(DAY,CAST(joining_date AS DATE),CAST(leaving_date AS DATE)))
END) AS duration 
FROM EMP

--5)
select ISDATE('2024/02/22')

--6)
SELECT (DATEADD(DAY,(7-DATEPART(DW,GETDATE())+4)%7,CAST(GETDATE()AS DATE))) as nextWednesday
FROM emp

--7)
SELECT (DATEPART(WEEK,'2024/02/26')-DATEPART(WEEK,DATEADD(MONTH,DATEDIFF(MONTH,0,'2024/02/25'),0)))+1 AS WEEKNUMBER
FROM EMP

--8)
SELECT DATEADD(DAY ,2-DATEPART(DW,GETDATE()),CAST(GETDATE() AS DATE))
FROM EMP


