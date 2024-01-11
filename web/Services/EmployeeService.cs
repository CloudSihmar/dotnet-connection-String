using System.Data.SqlClient;
using web.Models;

namespace web.Services
{
    public class EmployeeService
    {
        private static string db_source = "sandeep-data.database.windows.net";
        private static string db_user = "admindb";
        private static string db_password = "Tech@2020";
        private static string db_database = "appdata";

        private SqlConnection GetConnection()
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;
            return new SqlConnection(_builder.ConnectionString);
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
