using static System.Net.Mime.MediaTypeNames;

namespace GuntherRefuse.ViewModels
{
    [QueryProperty(nameof(Truck), nameof(Truck))]
    public partial class DispatchViewModel : BaseViewModel
    {
        HomeViewModel hVM;
        DispatchService dispatchService = new();
        EmployeeService employeeService = new();
        List<Dispatch> dispatchedList;
        List<Employee> helperList;
        List<Employee> driverList;
        public ObservableCollection<Employee> filteredEmployeeList { get; } = new();
        public ObservableCollection<Employee> filteredEmployeeList1 { get; } = new();
        public ObservableCollection<Employee> filteredEmployeeList2 { get; } = new();

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
        Employee helperOne;

        [ObservableProperty]
        Employee helperTwo;

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
            Date = DateTime.Today;
        }

        public async Task GetAvailableDrivers()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                if (driverList != null)
                    driverList.Clear();

                if (dispatchedList != null)
                    dispatchedList.Clear();

                dispatchedList = await dispatchService.GetTodaysRecords();
                driverList = await employeeService.GetDrivers();

            }
            catch
            {
                await Shell.Current.DisplayAlert("Error!", "Database connection error.", "OK");
            }
            finally
            {
                IsBusy = false;
            }
            GetAvailableHelpers();
        }

        public async Task GetAvailableHelpers()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                if (helperList != null)
                    helperList.Clear();

                if (dispatchedList != null)
                    dispatchedList.Clear();

                dispatchedList = await dispatchService.GetTodaysRecords();
                helperList = await employeeService.GetHelpers();

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
            if (dispatchedList.Count > 0)
            {
                var query = from employee in driverList
                            join record in dispatchedList on employee.EmployeeID equals record.Driver into groupJoin
                            from subgroup in groupJoin.DefaultIfEmpty()
                            select new { employee };

                foreach (var v in query)
                {
                    if (v.employee.FullName.ToUpper().Contains(text.ToUpper()))
                        filteredEmployeeList.Add(v.employee);
                }
            }
            else
            {
                foreach (Employee employee in driverList)
                {
                    if (employee.FullName.ToUpper().Contains(text.ToUpper()))
                        filteredEmployeeList.Add(employee);
                }
            }
        }

        [RelayCommand]
        public void SearchHelperOneCommand(string text)
        {
            if (filteredEmployeeList != null)
                filteredEmployeeList.Clear();

            if (dispatchedList.Count > 0)
            {
                var query = from employee in helperList
                            join record in dispatchedList on employee.EmployeeID equals record.HelperOne into groupJoin
                            from subgroup in groupJoin.DefaultIfEmpty()
                            select new { employee };

                foreach (var v in query)
                {
                    if (v.employee.FullName.ToUpper().Contains(text.ToUpper()))
                        filteredEmployeeList1.Add(v.employee);
                }
            }
            else
            {
                foreach (Employee employee in helperList)
                {
                    if (employee.FullName.ToUpper().Contains(text.ToUpper()))
                        filteredEmployeeList1.Add(employee);
                }
            }
        }

        [RelayCommand]
        public void SearchHelperTwoCommand(string text)
        {
            if (filteredEmployeeList != null)
                filteredEmployeeList.Clear();

            if (dispatchedList.Count > 0)
            {
                var query = from employee in helperList
                            join record in dispatchedList on employee.EmployeeID equals record.HelperTwo into groupJoin
                            from subgroup in groupJoin.DefaultIfEmpty()
                            select new { employee };

                foreach (var v in query)
                {
                    if (v.employee.FullName.ToUpper().Contains(text.ToUpper()))
                        filteredEmployeeList2.Add(v.employee);
                }
            }
            else
            {
                foreach (Employee employee in helperList)
                {
                    if (employee.FullName.ToUpper().Contains(text.ToUpper()))
                        filteredEmployeeList2.Add(employee);
                }
            }
        }

        [RelayCommand]
        public void SetDriver(Employee employee) { this.dispatchDriver = employee; }

        [RelayCommand]
        public void SetHelperOne(Employee employee) { this.helperOne = employee; }

        [RelayCommand]
        public void SetHelperTwo(Employee employee) { this.helperTwo = employee; }

        [RelayCommand]
        public async void Dispatch()
        {
            await dispatchService.DispatchTruck($"INSERT INTO DispatchLogs (Date, ServiceArea, TruckNumber, Driver, HelperOne, HelperTwo, TrashOrRecyclingOrYard) VALUES ('{Date.ToShortDateString()}','{ServiceArea}','{Truck.TruckNumber}','{DispatchDriver.EmployeeID}','{HelperOne.EmployeeID}','{HelperTwo.EmployeeID}','{WasteCollectionType}');");
            await Shell.Current.GoToAsync("../..");
        }
    }
}
