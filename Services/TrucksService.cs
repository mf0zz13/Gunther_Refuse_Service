namespace GuntherRefuse.Services;

public class TrucksService
{
    List<Truck> dispatchList = new();

    public async Task<List<Truck>> GetAvailableTrucks()
    {
        await using var connection = new SqlConnection("Data Source=192.168.1.155,49250;Initial Catalog=MSSAProject;User ID=RemoteUser;Password=R3m0t3P@ssW0rd;Trust Server Certificate=True");

        string sql = "SELECT * FROM Trucks WHERE Available = 1";

        var results = await connection.QueryAsync<Truck>(sql);

        foreach (Truck truck in results)
        {
            dispatchList.Add(truck);
        }

        return dispatchList;
    }

}