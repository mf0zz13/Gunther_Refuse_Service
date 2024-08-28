namespace GuntherRefuse.ViewModels;

public partial class HomeViewModel : BaseViewModel
{
    GetNumberOfDispatchedTrucks getTruckService;
    List<Dispatch> records;

    public ObservableCollection<Dispatch> DispatchRecords { get; } = new();


    public HomeViewModel(GetNumberOfDispatchedTrucks getTruckService)
    {
        this.getTruckService = getTruckService;
        this.GetNumberOfTrucks();
    }

    [RelayCommand]
    public async Task GetNumberOfTrucks()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;

            records = await getTruckService.GetNumberOfRecords();
            
            foreach (Dispatch record in records)
            {
                DispatchRecords.Add(record);
            }

        }
        catch
        {
            await Shell.Current.DisplayAlert("Error!", "Database connection error.", "OK");
        }
        finally
        {
            IsBusy = false;
        }

    }
}

