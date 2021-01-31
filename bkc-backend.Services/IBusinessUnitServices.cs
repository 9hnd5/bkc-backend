using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.Services
{
    public class BusinessUnit
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public interface IBusinessUnitServices
    {
        public List<BusinessUnit> GetBusinessUnitsByName(string buName);
        public List<BusinessUnit> GetBusinessUnits();
    }
    public class BusinessUnitServices : IBusinessUnitServices
    {
        private IConfiguration _config;
        public BusinessUnitServices(IConfiguration config)
        {
            _config = config;
        }

        public List<BusinessUnit> GetBusinessUnits()
        {
            string connectionString = _config["ConnectionString"];
            string queryString = "select BusinessUnitId, BusinessUnitName FROM dbo.BusinessUnit";
            List<BusinessUnit> businessUnits = new List<BusinessUnit>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        businessUnits.Add(new BusinessUnit()
                        {
                            Id = Convert.ToString(reader[0]),
                            Name = Convert.ToString(reader[1]),
                        });
                    }
                    reader.Close();
                    return businessUnits;
                }
                catch (Exception err)
                {
                    Console.WriteLine("Error when get bu by buname" + err);
                    return null;
                }
            }
        }

        public List<BusinessUnit> GetBusinessUnitsByName(string buName)
        {
            string connectionString = _config["ConnectionString"];
            string queryString = "select BusinessUnitId, BusinessUnitName FROM dbo.BusinessUnit where BusinessUnitName like '%" + buName + "%'";
            List<BusinessUnit> businessUnits = new List<BusinessUnit>();
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
                        businessUnits.Add(new BusinessUnit()
                        {
                            Id = Convert.ToString(reader[0]),
                            Name = Convert.ToString(reader[1]),
                        });
                    }
                    reader.Close();
                    return businessUnits;
                }
                catch (Exception err)
                {
                    Console.WriteLine("Error when get bu by buname" + err);
                    return null;
                }
            }
        }
    }
}
