namespace GuntherRefuse.Services;

public class EmployeeService
{
    List<Employee> employeeList = new();

    public async Task<List<Employee>> GetEmployees()
    {
        await using SqlConnection connection = new SqlConnection("Data Source=MICHAEL_DESKTOP;Initial Catalog=MSSAProject;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

        string sql = "SELECT * FROM Employee";

        var results = await connection.QueryAsync<Employee>(sql);

        foreach (Employee employee in results)
        {
            employeeList.Add(employee);
        }

        return employeeList;
    }
}