using EmployeePayrollServiceSQL;

namespace EmployeeManagementTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Salary salary = new Salary();
            SalaryUpdateModel salaryUpdateModel = new SalaryUpdateModel()
            {
                SalaryId = 2,
                Month = "Feb",
                EmployeeSalary = 13000,
                EmployeeId = 1
            };

            int empsal = salary.UpdateEmployeeSalary(salaryUpdateModel);
            Assert.AreEqual(salaryUpdateModel.EmployeeSalary, empsal);
        }
    }
}