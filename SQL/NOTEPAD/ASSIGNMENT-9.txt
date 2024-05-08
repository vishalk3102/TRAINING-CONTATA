

CREATE TABLE menu ( 
	product_id INT PRIMARY KEY NOT NULL, 
	product_name VARCHAR(5), 
	price INTEGER 
); 

CREATE TABLE members ( 
	 customer_id VARCHAR(1) PRIMARY KEY NOT NULL, 
	 join_date DATE 
); 

CREATE TABLE sales ( 
	customer_id VARCHAR(1) FOREIGN KEY REFERENCES MEMBERS(customer_id), 
	order_date DATE, 
	product_id INT FOREIGN KEY REFERENCES MENU(product_id)
); 

INSERT INTO sales 
VALUES 
('A', '2021-01-01', '1'), 
('A', '2021-01-01', '2'),
('A', '2021-01-01', '2'), 
('A', '2021-01-07', '2'), 
('A', '2021-01-10', '3'),
('A', '2021-01-11', '3'), 
('A', '2021-01-11', '3'), 
('B', '2021-01-01', '2'), 
('B', '2021-01-02', '2'), 
('B', '2021-01-04', '1'), 
('B', '2021-01-11', '1'),
('B', '2021-01-16', '3'),
('B', '2021-02-01', '3'), 
('C', '2021-01-01', '3'), 
('C', '2021-01-01', '3'), 
('C', '2021-01-07', '3')

INSERT INTO menu 
VALUES 
('1', 'sushi', '10'), 
('2', 'curry', '15'), 
('3', 'ramen', '12'); 
 
INSERT INTO MEMBERS 
VALUES 
('A', '2021-01-07'), 
('B', '2021-01-09'),
('C', '2021-01-07')



select * from menu
select * from sales
select * from MEMBERS

   

 
--1)
SELECT customer_id  ,SUM(m.price) AS total_spent
FROM sales s
INNER JOIN  menu m
ON s.product_id =m.product_id
GROUP BY customer_id

 --2)
 SELECT customer_id, COUNT(DISTINCT order_date) AS no_of_days_visited
 FROM sales
 GROUP BY customer_id
  
--3)
SELECT DISTINCT d.customer_id ,d.product_id,d.product_name
FROM (
	SELECT s.customer_id ,s.product_id,m.product_name, 
	DENSE_RANK() OVER(PARTITION BY customer_id  ORDER BY order_date) AS rank 
	FROM sales s 
	INNER JOIN menu m
	ON s.product_id =m.product_id) AS d
WHERE d.rank=1

--4)
SELECT TOP 1 s.product_id ,M.product_name,COUNT(s.product_id) AS no_of_orders
FROM sales s 
INNER JOIN menu m
ON s.product_id =m.product_id
GROUP BY s.product_id ,m.product_name 
ORDER BY COUNT(s.product_id) DESC

--5)
SELECT d.customer_id ,d.product_id,d.product_name
FROM  (SELECT s.customer_id ,m.product_id,m.product_name,COUNT(m.product_id) as no_of_times_purchased ,
	DENSE_RANK() OVER(PARTITION BY s.customer_id ORDER BY COUNT(m.product_id) DESC) AS RANK
FROM sales s
INNER JOIN menu m
ON s.product_id=m.product_id
GROUP BY s.customer_id ,m.product_id,m.product_name ) as d
WHERE rank=1

--6)
WITH CTE_CUSOTMER_MEMBER 
AS
(
	SELECT s.customer_id,m.product_name,s.product_id,
	DENSE_RANK() OVER(PARTITION BY s.customer_id ORDER BY s.order_date) AS rank
	FROM SALES S
	INNER JOIN MENU M
	ON M.product_id=S.product_id
	INNER JOIN MEMBERS D
	ON S.customer_id=D.customer_id
	WHERE S.order_date > D.join_date
)
SELECT customer_id ,product_name,product_id
FROM CTE_CUSOTMER_MEMBER C
WHERE RANK=1

--7)
SELECT customer_id,product_name,product_id,join_date, order_date
FROM ( 
    SELECT s.customer_id,m.product_name,s.product_id,D.join_date, s.order_date,
	DENSE_RANK() OVER(PARTITION BY s.customer_id ORDER BY s.order_date DESC) AS RANK
	FROM SALES S
	INNER JOIN MENU M
	ON M.product_id=S.product_id
	INNER JOIN MEMBERS D
	ON S.customer_id=D.customer_id AND S.order_date < D.join_date
) AS A	
WHERE RANK=1

--8)
	SELECT s.customer_id ,COUNT(S.customer_id) AS total_items ,SUM (m.price) AS amount
	FROM SALES S
	INNER JOIN MENU M
	ON M.product_id=S.product_id
	INNER JOIN MEMBERS D
	ON S.customer_id=D.customer_id AND S.order_date < D.join_date
	GROUP BY S.customer_id
