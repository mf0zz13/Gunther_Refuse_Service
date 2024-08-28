namespace GuntherRefuse.ViewModels
{
    public partial class DispatchTrucksViewModel : BaseViewModel
    {
        DispatchService dispatchedTrucks = new();
        TrucksService trucks = new();
        List<Truck> truckList = new();
        List<Dispatch> dispatchedList = new();

        public ObservableCollection<Truck> AvalibleTrucks { get; } = new();

        public DispatchTrucksViewModel()
        {
            Title = "Truck Dispatch";
            this.GetAvalibleTrucks();
        }

        [RelayCommand]
        public async Task GetAvalibleTrucks()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                truckList = await trucks.GetAvailableTrucks();
                dispatchedList = await dispatchedTrucks.GetTodaysRecords();

                foreach (Truck truck in truckList)
                {
                    if (!dispatchedList.Any(x => x.TruckNumber == truck.TruckNumber))
                    {
                        AvalibleTrucks.Add(truck);
                    }
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

        [RelayCommand]
        async Task GoToDispatchView(Truck truck)
        {
            if (truck == null)
                return;

            await Shell.Current.GoToAsync(nameof(DispatchView), false, new Dictionary<string, object>
            {
                { "Truck", truck }
            });
        }
    }
}
