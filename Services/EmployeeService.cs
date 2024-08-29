namespace GuntherRefuse.Services
{
    public class EmployeeService
    {
        List<Employee> employeeList = new();

        string connectionString = "Data Source=192.168.1.155,49250;Initial Catalog=MSSAProject;User ID=RemoteUser;Password=R3m0t3P@ssW0rd;Trust Server Certificate=True";

        public async Task<List<Employee>> GetEmployees()
        {
            await using SqlConnection connection = new SqlConnection(connectionString);

            string sql = "SELECT * FROM Employee";

            var results = await connection.QueryAsync<Employee>(sql);

            foreach (Employee employee in results)
               employeeList.Add(employee);
 
            return employeeList;
        }

        public async Task<List<Employee>> GetDrivers()
        {

            await using SqlConnection connection = new SqlConnection(connectionString);

            string sql = "SELECT * FROM Employee WHERE HasCDL = 1";

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