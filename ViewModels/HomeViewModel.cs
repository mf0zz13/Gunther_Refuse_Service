namespace GuntherRefuse.ViewModels
{

    public partial class HomeViewModel : BaseViewModel
    {
        DispatchService getTruckService;
        List<Dispatch> records;
        DateTime currTime = DateTime.Now;
        string properGreetingOftheDay;
        string name = "Mike";

        public ObservableCollection<Dispatch> DispatchRecords { get; } = new();

        public HomeViewModel(DispatchService getTruckService)
        {
            switch (currTime.Hour)
            {
                case int i when i >= 0 && i <= 11:
                    properGreetingOftheDay = "Good Morning,";
                    break;
                case int i when i >= 12 && i <= 16:
                    properGreetingOftheDay = "Good Afternoon,";
                    break;
                default:
                    properGreetingOftheDay = "Good Evening,";
                    break;

            }

            Title = $"{properGreetingOftheDay} {name}";
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

                records = await getTruckService.GetTodaysRecords();

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

        [RelayCommand]
        public Task NavigateToDispatchTrucks() => Shell.Current.GoToAsync(nameof(DispatchTrucksView),false);

        [RelayCommand]
        public Task NavigateToManageEmployees() => Shell.Current.GoToAsync(nameof(ManageEmployeesView), false);
    }
}

