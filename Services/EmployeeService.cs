namespace GuntherRefuse.Services
{
    public class EmployeeService
    {
        private static string ConnectionString =>
            Environment.GetEnvironmentVariable("GUNTHER_REFUSE_DB_CONNECTION")
            ?? throw new InvalidOperationException(
                "Database configuration is missing. Set GUNTHER_REFUSE_DB_CONNECTION outside source control.");

        List<Employee> employeeList = new();

        public async Task<List<Employee>> GetEmployees()
        {
            await using SqlConnection connection = new SqlConnection(ConnectionString);

            string sql = "SELECT * FROM Employee";

            var results = await connection.QueryAsync<Employee>(sql);

            foreach (Employee employee in results)
               employeeList.Add(employee);
 
            return employeeList;
        }

        public async Task<List<Employee>> GetDrivers()
        {

            await using SqlConnection connection = new SqlConnection(ConnectionString);

            string sql = "SELECT * FROM Employee WHERE HasCDL = 1";

            var result = await connection.QueryAsync<Employee>(sql);

            foreach (Employee employee in result)
            {
                employee.FullName = $"{employee.FirstName.Trim()} {employee.LastName.Trim()}";
                employeeList.Add(employee);
            }

            return employeeList;
        }

        public async Task<List<Employee>> GetHelpers()
        {

            await using SqlConnection connection = new SqlConnection(ConnectionString);

            string sql = "SELECT * FROM Employee WHERE HasCDL = 0";

            var result = await connection.QueryAsync<Employee>(sql);

            foreach (Employee employee in result)
            {
                employee.FullName = $"{employee.FirstName.Trim()} {employee.LastName.Trim()}";
                employeeList.Add(employee);
            }

            return employeeList;
        }
    }
}
