namespace EmployeePayrollServiceSQL
{
    class Program
    {
        public static void Main(string[] args)
        {
            EmployeeRepo employeeRepo = new EmployeeRepo();
            EmployeeModel employeeModel = new EmployeeModel();

            employeeModel.EmployeeName = "raj";
            employeeModel.PhoneNumber = "9815225562";
            employeeModel.Address = "13 street";
            employeeModel.Department = "marketing";
            employeeModel.Gender = 'M';
            employeeModel.BasicPay = 13000;
            employeeModel.Deductions = 2500;
            employeeModel.TaxablePay = 10500;
            employeeModel.Tax = 300;
            employeeModel.NetPay = 10200;
            employeeModel.City = "Banglore";
            employeeModel.Country = "India";

             employeeRepo.AddEmployee(employeeModel);
            // employeeRepo.GetAllEmployee();
        }
    }
}