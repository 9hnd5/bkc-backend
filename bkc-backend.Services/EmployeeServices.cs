using bkc_backend.Data.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace bkc_backend.Services.EmployeeServices
{
    public interface IEmployeeServices
    {
        public List<Employee> GetAllEmployee();
        public Employee GetEmployeeByEmail(string email);
        public Employee getEmployeeById(int id);
        public List<Employee> GetEmployeeByFilterKeyEmail(string filterKeyEmail);
        public List<Employee> getEmployeeByName(string employeeName);
    }
    public class EmployeeServices : IEmployeeServices
    {
        private IConfiguration _config;
        public EmployeeServices(IConfiguration config)
        {
            _config = config;
        }
        public List<Employee> GetAllEmployee()
        {
            string connectionString = "Server=192.168.170.82; Database=HRAD;User Id=sa;password=gf40@2018";
            string queryString = "select EMPLOYEE_ID, EMPLOYEE_FULL_NAME from dbo.Employee";
            List<Employee> employees = new List<Employee>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        employees.Add(new Employee() { Id = (int)reader[0], Name = (string)reader[1] });
                    }
                    reader.Close();
                    return employees;
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                    return new List<Employee>();
                }
            }
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
                            Id = Convert.ToInt32(reader[0]),
                            Name = (string)reader[1],
                            Phone = Convert.ToString(reader[2]),
                            Department = (string)reader[3],
                            BuId = (string)reader[4],
                            BuName = (string)reader[5],
                            Email = (string)reader[6],
                            LineManagerId=Convert.ToInt32(reader[7])
                        };
                    }
                    reader.Close();
                    var lineManager = getEmployeeById(employee.LineManagerId);
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

        public List<Employee> GetEmployeeByFilterKeyEmail(string filterKeyEmail)
        {
            string connectionString = _config["ConnectionString"];
            string queryString = "select EMPLOYEE_ID, EMPLOYEE_FULL_NAME, MOBILE_NUMBER, DEPARTMENT," +
                "BUID, BUSINESS_UNIT, WORKING_EMAIL FROM dbo.TSEmployee where WORKING_EMAIL like '%" + filterKeyEmail + "%'";
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
                            Id = (int)reader[0],
                            Name = (string)reader[1],
                            Phone = (string)reader[2],
                            Department = (string)reader[3],
                            BuId = (string)reader[4],
                            BuName = (string)reader[5],
                            Email = (string)reader[6]
                        });
                    }
                    reader.Close();
                    if (employees.Count == 0) return null;
                    return employees;
                }
                catch (Exception err)
                {
                    return null;
                    throw (err);
                }
            }
        }

        public Employee getEmployeeById(int id)
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
                            Id = Convert.ToInt32(reader[0]),
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

        public List<Employee> getEmployeeByName(string employeeName)
        {
            string connectionString = _config["ConnectionString"];
            string queryString = "select EMPLOYEE_ID, EMPLOYEE_FULL_NAME, MOBILE_NUMBER, DEPARTMENT," +
                "BUID, BUSINESS_UNIT, WORKING_EMAIL FROM dbo.TSEmployee where EMPLOYEE_FULL_NAME like '%" + employeeName + "%'";
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
                            Id = Convert.ToInt32(reader[0]),
                            Name = Convert.ToString(reader[1]),
                            //Phone = Convert.ToString(reader[2]),k
                            //Department = (string)reader[3],
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
