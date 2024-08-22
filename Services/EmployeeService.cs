using Microsoft.Data.SqlClient;
using Dapper;

namespace GuntherRefuse.Services;

public class EmployeeService
{
    List<Employee> employeeList = new();

    public async Task<List<Employee>> GetEmployees()
    {
        await using var connection = new SqlConnection("Data Source=MICHAEL_DESKTOP;Initial Catalog=MSSAProject;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

        var status = connection.State;

        var sql = "SELECT * FROM Employees";

        var results = await connection.QueryAsync<Employee>(sql);

        foreach (Employee employee in results)
        {
            employeeList.Add(employee);
        }

        return employeeList;
    }
}