using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EmployeePayrollServiceSQL
{
    public class EmployeeRepo
    {
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PayRollService240;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);

        public void GetAllEmployee()
        {
            try
            {
                EmployeeModel employee = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"SELECT EmployeeID,EmployeeName,PhoneNumber,Address,Department,Gender,BasicPay,Deductions,TaxablePay,Tax,NetPay,StartDate,City,Country from employeepayroll";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    this.connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employee.EmployeeID = dr.GetInt32(0);
                            employee.EmployeeName = dr.GetString(1);
                            employee.PhoneNumber = dr.GetString(2);
                            employee.Address = dr.GetString(3);
                            employee.Department = dr.GetString(4);
                            employee.Gender = Convert.ToChar(dr.GetString(5));
                            employee.BasicPay = dr.GetDouble(6);
                            employee.Deductions = dr.GetDouble(7);
                            employee.TaxablePay = dr.GetDouble(8);
                            employee.Tax = dr.GetDouble(9);
                            employee.NetPay = dr.GetDouble(10);
                            employee.StartDate = dr.GetDateTime(11);
                            employee.City = dr.GetString(12);
                            employee.Country = dr.GetString(13);

                            Console.WriteLine(employee.EmployeeName + " " + employee.Address);
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
                this.connection.Close();
            }
        }

        public bool AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("SpAddEmployeeDetails", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeName", employeeModel.EmployeeName);
                    command.Parameters.AddWithValue("@PhoneNumber", employeeModel.PhoneNumber);
                    command.Parameters.AddWithValue("@Address", employeeModel.Address);
                    command.Parameters.AddWithValue("@Department", employeeModel.Department);
                    command.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                    command.Parameters.AddWithValue("@BasicPay", employeeModel.BasicPay);
                    command.Parameters.AddWithValue("@Deductions", employeeModel.Deductions);
                    command.Parameters.AddWithValue("@TaxablePay", employeeModel.TaxablePay);
                    command.Parameters.AddWithValue("@Tax", employeeModel.Tax);
                    command.Parameters.AddWithValue("@NetPay", employeeModel.NetPay);
                    command.Parameters.AddWithValue("@StartDate", DateTime.Now);
                    command.Parameters.AddWithValue("@City", employeeModel.City);
                    command.Parameters.AddWithValue("@Country", employeeModel.Country);

                    this.connection.Open();
                    var results = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (results != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                this.connection.Close();
            }
        }

    }
}