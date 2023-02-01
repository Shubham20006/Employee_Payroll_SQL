create procedure spUpdateEmployeeSalary
(
@id int,
@month varchar(255),
@salary varchar(255),
@EmpId varchar(255)
)
as
begin

update Salary
set EmployeeSalary=@salary
where EmployeeId=@EmpId and SalaryId=@id and Month=@month

select e.EmployeeID,e.EmployeeName,s.Department,s.EmployeeSalary,s.Month from 
employeepayroll e inner join Salary s on e.EmployeeId=s.Employeeid
where s.SalaryId=@id

End