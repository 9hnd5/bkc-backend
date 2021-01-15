using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace bkc_backend.Services.UserServices
{
    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Department { get; set; }
        public string BuId { get; set; }
        public string BuName { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string LineManagerId { get; set; }
        public string LineManagerName { get; set; }
    }
    public interface IEmployeeServices
    {
        public Employee GetEmployeeByEmail(string email);
        public Employee GetEmployeeById(string id);
        public List<Employee> GetEmployeesByName(string UserName);
    }
    public class EmployeeServices : IEmployeeServices
    {
        private IConfiguration _config;
        public EmployeeServices(IConfiguration config)
        {
            _config = config;
        }
        public Employee GetEmployeeByEmail(string email)
        {
            string connectionString = _config["ConnectionString"];
            string queryString = "select EMPLOYEE_ID, EMPLOYEE_FULL_NAME, MOBILE_NUMBER, DEPARTMENT," +
                "BUID, BUSINESS_UNIT, WORKING_EMAIL, LINE_MANAGER_ID FROM dbo.TSEmployee where WORKING_EMAIL = @email";
            Employee employee = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@email", email);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        employee = new Employee()
                        {
                            Id = Convert.ToString(reader[0]),
                            Name = (string)reader[1],
                            Phone = Convert.ToString(reader[2]),
                            Department = (string)reader[3],
                            BuId = (string)reader[4],
                            BuName = (string)reader[5],
                            Email = (string)reader[6],
                            LineManagerId=Convert.ToString(reader[7])
                        };
                    }
                    reader.Close();
                    var lineManager = GetEmployeeById(employee.LineManagerId);
                    if (lineManager == null) return employee;
                    employee.LineManagerName = lineManager.Name;
                    return employee;
                }
                catch (Exception err)
                {
                    return null;
                }
            }
        }

        public Employee GetEmployeeById(string id)
        {
            string connectionString = _config["ConnectionString"];
            string queryString = "select EMPLOYEE_ID, EMPLOYEE_FULL_NAME, MOBILE_NUMBER, DEPARTMENT," +
                "BUID, BUSINESS_UNIT, WORKING_EMAIL FROM dbo.TSEmployee where EMPLOYEE_ID = " + Convert.ToString(id);
            Employee employee = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@email", email);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        employee = new Employee()
                        {
                            Id = Convert.ToString(reader[0]),
                            Name = (string)reader[1],
                            Phone = Convert.ToString(reader[2]),
                            Department = (string)reader[3],
                            BuId = (string)reader[4],
                            BuName = (string)reader[5],
                            Email = (string)reader[6],
                        };
                    }
                    reader.Close();
                    return employee;
                }
                catch (Exception err)
                {
                    return null;
                }
            }
        }

        public List<Employee> GetEmployeesByName(string UserName)
        {
            string connectionString = _config["ConnectionString"];
            string queryString = "select EMPLOYEE_ID, EMPLOYEE_FULL_NAME, MOBILE_NUMBER, DEPARTMENT," +
                "BUID, BUSINESS_UNIT, WORKING_EMAIL FROM dbo.TSEmployee where EMPLOYEE_FULL_NAME like '%" + UserName + "%'";
            List<Employee> employees = new List<Employee>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@filterKeyEmail", filterKeyEmail);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        employees.Add(new Employee()
                        {
                            Id = Convert.ToString(reader[0]),
                            Name = Convert.ToString(reader[1]),
                            Phone = Convert.ToString(reader[2]),
                            Department = Convert.ToString(reader[3]),
                            BuId = Convert.ToString(reader[4]),
                            BuName = Convert.ToString(reader[5]),
                            Email = Convert.ToString(reader[6])
                        });
                    }
                    reader.Close();
                    return employees;
                }
                catch (Exception err)
                {
                    throw (err);
                }
            }
        }
    }
}
