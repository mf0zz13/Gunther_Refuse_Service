using static System.Net.Mime.MediaTypeNames;

namespace GuntherRefuse.ViewModels
{
    [QueryProperty(nameof(Truck), nameof(Truck))]
    public partial class DispatchViewModel : BaseViewModel
    {
        DispatchService dispatchService = new();
        EmployeeService employeeService = new();
        List<Dispatch> dispatchedList;
        List<Employee> employeeList;
        public ObservableCollection<Employee> filteredEmployeeList { get; } = new();

        [ObservableProperty]
        Truck truck;

        [ObservableProperty]
        bool isChecked;

        [ObservableProperty]
        string collectionType;

        [ObservableProperty]
        DateTime date;

        [ObservableProperty]
        int serviceArea;

        [ObservableProperty]
        Employee dispatchDriver;

        [ObservableProperty]
        int helperOne;

        [ObservableProperty]
        int helperTwo;

        [ObservableProperty]
        int helperThree;

        [ObservableProperty]
        int wasteCollectionType;

        public List<string> TrashCollectionTypes { get; } = new List<string>()
        {
            "Trash",
            "Recycling",
            "Yard Waste"
        };

        public List<int> ServiceAreas { get; } = new List<int>() { 1, 2 };

        public DispatchViewModel()
        {
            this.GetAvailableDrivers();
        }

        public async Task GetAvailableDrivers()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                if (employeeList != null)
                    employeeList.Clear();

                if (dispatchedList != null)
                    dispatchedList.Clear();

                dispatchedList = await dispatchService.GetTodaysRecords();
                employeeList = await employeeService.GetDrivers();

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
        public void SearchDrivers(string text)
        {
            if (filteredEmployeeList != null)
                filteredEmployeeList.Clear();

            var query = from employee in employeeList
                        join record in dispatchedList on employee.EmployeeID equals record.Driver into groupJoin
                        from subgroup in groupJoin.DefaultIfEmpty()
                        select new { employee}; 

            foreach (var v in query)
            {
                if (v.employee.FullName.ToUpper().Contains(text.ToUpper()))
                    filteredEmployeeList.Add(v.employee);
            }   
        }

        [RelayCommand]
        public void SetDriver(Employee employee)
        {
            this.dispatchDriver = employee;
            
        }

    }
}
