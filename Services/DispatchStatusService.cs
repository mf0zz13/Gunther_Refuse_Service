namespace GuntherRefuse.Services;

public class DispatchStatusService
{
	List<Dispatch> dispatchStatusList = new();

    public async Task<List<Dispatch>> GetDispatchStatus()
    {
		await using SqlConnection connection = new SqlConnection("Data Source=MICHAEL_DESKTOP;Initial Catalog=MSSAProject;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

        DateTime today = DateTime.Today;

        //string sql = $"SELECT * FROM DispatchLogs WHERE Date = '{today.Year}-{today.Month}-{today.Day}'";
        string sql = $"SELECT * FROM DispatchLogs WHERE Date = '{today.Year}-{today.Month}-{today.Day}'";

        var results = await connection.QueryAsync<Dispatch>(sql);

        foreach (Dispatch record in results)
        {
            dispatchStatusList.Add(record);
        }

        return dispatchStatusList;

    }

 
}