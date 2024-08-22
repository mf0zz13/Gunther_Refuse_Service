namespace GuntherRefuse.Services;

public class DispatcherService
{
    List<Model.Dispatcher> dispatchList = new();

    public async Task<List<Model.Dispatcher>> GetAvailableTrucks()
    {
        await using var connection = new SqlConnection("Data Source=MICHAEL_DESKTOP;Initial Catalog=MSSAProject;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

        string sql = "SELECT * FROM Trucks WHERE Available = 1";

        var results = await connection.QueryAsync<Model.Dispatcher>(sql);

        foreach (Model.Dispatcher truck in results)
        {
            dispatchList.Add(truck);
        }

        return dispatchList;
    }

}