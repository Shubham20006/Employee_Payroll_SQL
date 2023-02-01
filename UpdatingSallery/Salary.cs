using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollServiceSQL
{
    public class Salary
    {
        private static SqlConnection ConnectionSetup()
        {
            return new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PayRollService240;Integrated Security=True");
        }
        public int UpdateEmployeeSalary(SalaryUpdateModel salaryUpdateModel)
        {

            SqlConnection salaryconnection = ConnectionSetup();

            int salary = 0;
            try
            {
                using (salaryconnection)
                {
                    SalaryDetailModel displayModel = new SalaryDetailModel();
                    SqlCommand command = new SqlCommand("spUpdateEmployeeSalary", salaryconnection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", salaryUpdateModel.SalaryId);
                    command.Parameters.AddWithValue("@month", salaryUpdateModel.Month);
                    command.Parameters.AddWithValue("@salary", salaryUpdateModel.EmployeeSalary);
                    command.Parameters.AddWithValue("@EmpId", salaryUpdateModel.EmployeeId);

                    salaryconnection.Open();

                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            displayModel.EmployeeId = dr.GetInt32(0);
                            displayModel.EmployeeName = dr.GetString(1);
                            displayModel.Department = dr.GetString(2);
                            displayModel.Month = dr.GetString(4);
                            displayModel.EmployeeSalary = dr.GetInt32(3);

                            Console.WriteLine(displayModel.EmployeeId + " " + displayModel.EmployeeName + " " + displayModel.EmployeeSalary);
                            salary = displayModel.EmployeeSalary;
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                salaryconnection.Close();
            }
            return salary;
        }
    }
}
