




SELECT * FROM COMPANY 


--4)
SELECT * INTO #temp_company
FROM COMPANY

SELECT * FROM #temp_company

--4.1)
SELECT NAME 
FROM #temp_company
WHERE INTERVIEW_DATE > '2020-09-01'


--4.2)
SELECT * 
FROM #temp_company
WHERE INTERVIEW_DATE BETWEEN '2020-09-01' AND '2020-09-30'


--6)
DECLARE @student_table_variable TABLE (
ID VARCHAR(10) PRIMARY KEY NOT NULL,
NAME VARCHAR(30) ,
DEPARTMENT VARCHAR(30),
CGPA DECIMAL(2,1)
) 

INSERT INTO @student_table_variable
VALUES 
('S001','ARUN','CS',8),
('S002','GITA','CS',7.5),
('S003','KUMAR','IT',6),
('S004','ROHIT','IT',8.5),
('S005','YAMUNA','ECE',9),
('S006','YOGESH','ECE',9)



--6.1)
SELECT * 
FROM @student_table_variable
WHERE DEPARTMENT IN ('IT','ECE')


--6.2)
SELECT S1.NAME 
FROM @student_table_variable S1
WHERE 2=(  
		SELECT COUNT(DISTINCT S2.CGPA)
		FROM @student_table_variable S2
		WHERE S2.CGPA>=S1.CGPA	)

SELECT * FROM @student_table_variable