namespace GuntherRefuse.ViewModel;

public partial class DispatchTrucksViewModel : BaseViewModel
{
	TrucksService dispatcherService;

	public ObservableCollection<Truck> Dispatcher { get; } = new();

	public DispatchTrucksViewModel(TrucksService dispatcherService)
	{
		this.dispatcherService = dispatcherService;
		this.GetDispatchableTrucksAsync();
	}

	[RelayCommand]
	async Task GetDispatchableTrucksAsync()
	{
		if (IsBusy)
			return;

		try
		{
			IsBusy = true;
			List<Truck> trucks = await dispatcherService.GetAvailableTrucks();

			Dispatcher.Clear();
			foreach(Truck truck in trucks)
			{
				truck.TruckNumberFormatted = $"Truck Number: {truck.TruckNumber}";
				Dispatcher.Add(truck);
			}
		}
        catch (Exception e)
        {
            Debug.WriteLine(e);
            await Shell.Current.DisplayAlert("Error!", $"Unable to get trucks: {e.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

	[RelayCommand]
	async Task GoToDispatchAsync(Truck truck)
	{
		if (truck is null)
			return;

		await Shell.Current.GoToAsync(nameof(DispatchView), true, new Dictionary<string, object>
		{
			{nameof(Truck), truck }
		});
	}
}