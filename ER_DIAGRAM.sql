
/* UC8:- Ability to extend employee_payroll data to store employee information like employee phone, address and department */
Alter table employee_payroll add PhoneNum varchar(255) 
Alter table employee_payroll add address varchar(255) default 'Pune'
Alter table employee_payroll add  department varchar(255)not null

/* UC9:- Ability to extend employee_payroll table to have Basic Pay, Deductions, Taxable Pay, Income Tax, Net Pay*/
Alter table employee_payroll add Deductions varchar(255)
Alter table employee_payroll add TaxablePay varchar(255)
Alter table employee_payroll add IncomeTax varchar(255)
Alter table employee_payroll add NetPay varchar(255)

 /* UC10:- Ability to make Terissa as part of Sales and Marketing Department. */
 update employee_payroll
set department='Sales'
where emp_Name='prachi'

 insert into employee_payroll values('prachi',12000,'2020-10-22','F','9832565155','Mumbai','Marketing','2000','1000','200','10000')
 select * from employee_payroll

 /* Uc11:- Draw ER diagram and Implement the ER Diagram into Payroll Service DB*/

 create table Company
 ( 
 companyID varchar(255),
 companyName varchar(255)
 )
 insert into Company values(50,'BridgeLabz')

 create table department
 (
 departmentID varchar(255) not null,
 departName varchar(255)
 )
 insert into department values('01','sales')
 insert into department values('02','Marketing')

 create table EmployeeDepartment
 ( 
  emp_ID int,
 departmentID varchar(255) not null
 )
 insert into EmployeeDepartment values(101,'01')
 insert into EmployeeDepartment values(102,'01')
 insert into EmployeeDepartment values(103,'01')
 insert into EmployeeDepartment values(104,'01')
 insert into EmployeeDepartment values(101,'02')
 insert into EmployeeDepartment values(103,'02')

 Create Table employee
(
emp_ID int,
emp_Name varchar(255),
PhoneNum varchar(255),
address varchar(255),
Gender char(1),
startDate Date,
companyID varchar(255)
)
insert into employee values(101,'shubham','9656244565','pune','M','2022-08-16','50')
insert into employee values(102,'prachi','8652656651','Mumbai','F','2021-05-26','50')
insert into employee values(103,'aishwarya','9065656445','Delhi','F','2022-10-16','50')
insert into employee values(104,'raj','9815225562','Banglore','M','2020-11-24','50')

create table payroll
(
 emp_ID int,
 BasicPay int,
 Deductions int,
 TaxablePay int,
 IncomeTax int,
 NetPay int
 )
insert into payroll values(101,15000,3000,12000,500,11500)
insert into payroll values(102,12000,2000,10000,200,9800)
insert into payroll values(103,9000,1000,8000,100,7900)
insert into payroll values(104,13000,2500,10500,300,10200)


 /* UC12:- Ensure all retrieve queries done especially in UC 4, UC 5 and UC 7 are working with new table structure*/
 select * from Company
 select * from department
 select * from EmployeeDepartment
 select * from employee
 select * from payroll

 SELECT BasicPay FROM payroll
WHERE emp_ID =101
SELECT BasicPay FROM payroll
WHERE emp_ID =102
SELECT BasicPay FROM payroll
WHERE emp_ID =103
SELECT BasicPay FROM payroll
WHERE emp_ID =104

select sum(BasicPay) from payroll 
select avg(BasicPay) from payroll  
select count(BasicPay) from payroll 
select max(BasicPay) from payroll 
select min(BasicPay) from payroll 


