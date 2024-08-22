namespace GuntherRefuse.ViewModel;

public partial class EmployeeViewModel : BaseViewModel
{
    EmployeeService employeeService;

    public ObservableCollection<Employee> Employees { get; } = new();

    public EmployeeViewModel(EmployeeService employeeService)
    {
        Title = "Employee's";
        this.employeeService = employeeService;

    }

    [RelayCommand]
    async Task GetEmployeesAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            List<Employee> employees = await employeeService.GetEmployees();

            Employees.Clear();
            foreach (Employee employee in employees)
                Employees.Add(employee);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            await Shell.Current.DisplayAlert("Error!", $"Unable to get employees: {e.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}