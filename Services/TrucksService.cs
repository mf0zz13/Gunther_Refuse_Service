namespace GuntherRefuse.Services;

public class TrucksService
{
    List<Truck> dispatchList = new();

    public async Task<List<Truck>> GetAvailableTrucks()
    {
        await using var connection = new SqlConnection("Data Source=MICHAEL_DESKTOP;Initial Catalog=MSSAProject;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

        string sql = "SELECT * FROM Trucks WHERE Available = 1";

        var results = await connection.QueryAsync<Truck>(sql);

        foreach (Truck truck in results)
        {
            dispatchList.Add(truck);
        }

        return dispatchList;
    }

}