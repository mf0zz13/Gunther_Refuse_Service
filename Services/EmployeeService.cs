using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;

namespace GuntherRefuse.Services;

public class EmployeeService
{
    List<Employee> employeeList = new();

    public async Task<List<Employee>> GetEmployees()
    {
        await using var connection = new SqlConnection("Data Source=MICHAEL_DESKTOP;Initial Catalog=MSSAProject");

        var sql = "SELECT * FROM Employees";

        var results = await connection.QueryAsync<Employee>(sql);

        foreach (Employee employee in results)
        {
            employeeList.Add(employee);
        }

        return employeeList;
    }
}