namespace GuntherRefuse.ViewModel;

public partial class EmployeeViewModel : BaseViewModel
{
    EmployeeService employeeService;
    
    public ObservableCollection<Employee> Employees { get; } = new();

    public EmployeeViewModel(EmployeeService employeeService)
    {
        Title = "Employee's";
        this.employeeService = employeeService;
        this.GetEmployeesAsync();
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
            {
                employee.StartDateFormatted = $"Start Date: {employee.StartDate.ToShortDateString()}";
                employee.NameFormatted = $"{employee.FirstName.Trim()}, {employee.LastName.Trim()}";
                Employees.Add(employee);
            }
            

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

    #if WINDOWS

    #endif





}