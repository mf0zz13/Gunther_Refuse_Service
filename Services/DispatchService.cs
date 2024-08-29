namespace GuntherRefuse.Services;

public class DispatchService
{
    List<Dispatch> dispatchedTrucks = new();

    public async Task<List<Dispatch>> GetTodaysRecords()
    {
        DateTime today = DateTime.Today;

        await using SqlConnection connection = new SqlConnection("Data Source=192.168.1.155,49250;Initial Catalog=MSSAProject;User ID=RemoteUser;Password=R3m0t3P@ssW0rd;Trust Server Certificate=True");

        string sql = $"SELECT * FROM DispatchLogs WHERE Date = '{today.Year}-{today.Month}-{today.Day}'";

        var results = await connection.QueryAsync<Dispatch>(sql);

        foreach (Dispatch record in results)
        {
            dispatchedTrucks.Add(record);
        }

        return dispatchedTrucks;
    }

    public async Task DispatchTruck(string inject)
    {
        await using SqlConnection connection = new SqlConnection("Data Source=192.168.1.155,49250;Initial Catalog=MSSAProject;User ID=RemoteUser;Password=R3m0t3P@ssW0rd;Trust Server Certificate=True");
        
        connection.Execute(inject);
    }
}

