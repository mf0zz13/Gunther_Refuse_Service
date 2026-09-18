namespace GuntherRefuse.Services;

public class TrucksService
{
    private static string ConnectionString =>
        Environment.GetEnvironmentVariable("GUNTHER_REFUSE_DB_CONNECTION")
        ?? throw new InvalidOperationException(
            "Database configuration is missing. Set GUNTHER_REFUSE_DB_CONNECTION outside source control.");

    List<Truck> dispatchList = new();

    public async Task<List<Truck>> GetAvailableTrucks()
    {
        await using var connection = new SqlConnection(ConnectionString);

        string sql = "SELECT * FROM Trucks WHERE Available = 1";

        var results = await connection.QueryAsync<Truck>(sql);

        foreach (Truck truck in results)
        {
            dispatchList.Add(truck);
        }

        return dispatchList;
    }

}
