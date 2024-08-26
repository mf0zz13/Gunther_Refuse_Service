namespace GuntherRefuse.Services;

public class DispatchRecordsService
{
	List<Dispatch> dispatchServiceList = new();

    public async Task<List<Dispatch>> GetDispatchRecords()
    {
		await using SqlConnection connection = new SqlConnection("Data Source=MICHAEL_DESKTOP;Initial Catalog=MSSAProject;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        
		string sql = "SELECT * FROM DispatchLogs";

        IEnumerable<Dispatch> results = await connection.QueryAsync<Dispatch>(sql);

        foreach (Dispatch record in results)
        {
            dispatchServiceList.Add(record);
        }

        return dispatchServiceList;

    }

 
}