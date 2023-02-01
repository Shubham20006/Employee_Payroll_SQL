/*UC1:- Ability to create a payroll service database */

create database payroll_service
use payroll_service

/* UC2:- Ability to create a employee payroll table in the payroll service database to manage employee payrolls.*/

Create Table employee_payroll
(
emp_ID int identity primary key,
emp_Name varchar(255),
emp_sallery int,
startDate Date
)


/*UC3:- Ability to create employee payroll data in the payroll service database as part of CRUD Operation. */

insert into employee_payroll values('shubham',15000,'2022-08-16')
insert into employee_payroll values('prachi',12000,'2021-05-26')
insert into employee_payroll values('aishwarya',9000,'2022-10-16')
insert into employee_payroll values('raj',13000,'2020-11-24')

/* UC4:- Ability to retrieve all the employee payroll data. */
select * from employee_payroll

/* UC5:- Ability to retrieve salary data for a particular employee as well as all employees who have joined in a particular data range from the payroll service database */

SELECT emp_sallery FROM employee_payroll
WHERE emp_Name ='shubham'

SELECT emp_sallery FROM employee_payroll
WHERE emp_Name ='raj'

SELECT emp_sallery FROM employee_payroll
WHERE startDate BETWEEN CAST('2022-05-01'AS DATE) AND CAST('2023-01-30'AS DATE)

SELECT emp_sallery FROM employee_payroll
WHERE startDate BETWEEN CAST('2022-05-01'AS DATE) AND DATE(NOW());

/* UC6:- Ability to add Gender to Employee Payroll Table and Update the Rows reflect the correct Employee Gender. */

Alter table employee_payroll
add Gender char(1)

update employee_payroll
set Gender='M'
where emp_Name IN('shubham','raj')

update employee_payroll
set Gender='F'
where emp_Name IN('prachi','aishwarya')

/* UC7:-Ability to find sum, average, min, max and number of male and female employees */

select sum(emp_sallery) from employee_payroll
select avg(emp_sallery) from employee_payroll
select count(emp_sallery) from employee_payroll
select max(emp_sallery) from employee_payroll
select min(emp_sallery) from employee_payroll

select * from employee_payroll
where Gender='M'
select * from employee_payroll
where Gender='F'

SELECT SUM(emp_sallery) FROM employee_payroll
WHERE Gender = 'F' GROUP BY Gender
SELECT SUM(emp_sallery) FROM employee_payroll
WHERE Gender = 'M' GROUP BY Gender