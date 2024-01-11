using System.Data.SqlClient;
using web.Models;

namespace web.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IConfiguration _configuration;
        public EmployeeService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("SQLConnection"));
        }

        public List<Employees> GetEmployees()
        {
            List<Employees> _employees_lst = new List<Employees>();
            string _statement = "SELECT EmployeeID,Name,Age from Employees";
            SqlConnection _connection = GetConnection();

            _connection.Open();

            SqlCommand _sqlcommand = new SqlCommand(_statement, _connection);

            using (SqlDataReader _reader = _sqlcommand.ExecuteReader())
            {
                while (_reader.Read())
                {
                    Employees _employees = new Employees()
                    {
                        EmployeeID = _reader.GetInt32(0),
                        Name = _reader.GetString(1),
                        Age = _reader.GetInt32(2)
                    };

                    _employees_lst.Add(_employees);
                }
            }
            _connection.Close();
            return _employees_lst;
        }
    }
}
