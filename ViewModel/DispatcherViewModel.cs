namespace GuntherRefuse.ViewModel;

public partial class DispatcherViewModel : BaseViewModel
{
	DispatcherService dispatcherService;

	public ObservableCollection<Model.Dispatcher> Dispatcher { get; } = new();

	public DispatcherViewModel(DispatcherService dispatcherService)
	{
		Title = "Dispatch";
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
			List<Model.Dispatcher> trucks = await dispatcherService.GetAvailableTrucks();

			Dispatcher.Clear();
			foreach(Model.Dispatcher truck in trucks)
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
}