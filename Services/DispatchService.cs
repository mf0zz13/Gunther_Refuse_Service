namespace GuntherRefuse.Services;

public class DispatchService
{
    private static string ConnectionString =>
        Environment.GetEnvironmentVariable("GUNTHER_REFUSE_DB_CONNECTION")
        ?? throw new InvalidOperationException(
            "Database configuration is missing. Set GUNTHER_REFUSE_DB_CONNECTION outside source control.");

    List<Dispatch> dispatchedTrucks = new();

    public async Task<List<Dispatch>> GetTodaysRecords()
    {
        DateTime today = DateTime.Today;

        await using SqlConnection connection = new SqlConnection(ConnectionString);

        string sql = $"SELECT * FROM DispatchLogs WHERE Date = '{today.Year}-{today.Month}-{today.Day}'";

        var results = await connection.QueryAsync<Dispatch>(sql);

        foreach (Dispatch record in results)
        {
            dispatchedTrucks.Add(record);
        }

        return dispatchedTrucks;
    }

    public async Task GetTodaysRecordsCount(HomeViewModel viewModel)
    {
        DateTime today = DateTime.Today;

        await using SqlConnection connection = new SqlConnection(ConnectionString);

        string sql = $"SELECT * FROM DispatchLogs WHERE Date = '{today.Year}-{today.Month}-{today.Day}'";

        var results = await connection.QueryAsync<Dispatch>(sql);

        viewModel.Count = results.Count();
    }

    public async Task DispatchTruck(string inject)
    {
        await using SqlConnection connection = new SqlConnection(ConnectionString);
        
        connection.Execute(inject);
    }
}
