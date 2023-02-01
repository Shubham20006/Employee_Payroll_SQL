create database PayRollService240

create table employeepayroll
(
EmployeeID int primary key identity,
EmployeeName varchar(255),
PhoneNumber varchar(255),
Address varchar(255),
Department varchar(255),
Gender char(1),
BasicPay float,
Deductions float,
TaxablePay float,
Tax float,
NetPay float,
StartDate date,
City varchar (255),
Country varchar(255)
)

select * from employeepayroll

create table Salary
(
EmployeeId int,
EmployeeName varchar(255),
Department varchar(255),
Month varchar(255),
EmployeeSalary int,
SalaryId int primary key identity
)

Insert into Salary(EmployeeId,EmployeeName,Department,Month,EmployeeSalary)
values(1,'shubham','sales','Jan',20000)

Insert into Salary(EmployeeId,EmployeeName,Department,Month,EmployeeSalary)
values(1,'shubham','sales','Feb',20000)

Insert into Salary(EmployeeId,EmployeeName,Department,Month,EmployeeSalary)
values(1,'shubham','sales','Mar',20000)

select * from Salary

