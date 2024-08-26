using System.Linq;

namespace GuntherRefuse.View;

public partial class EmployeeView : ContentPage
{
    EmployeeViewModel viewModel;

	public EmployeeView(EmployeeViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
        this.viewModel = viewModel;

    }

    private void EmployeeSearch_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(e.NewTextValue))
        {
            EmployeeDisplay.ItemsSource = viewModel.Employees;
        }
        else
        {
            EmployeeDisplay.ItemsSource = viewModel.Employees.Where(
                employee => employee.FirstName.ToLower().Contains(e.NewTextValue.ToLower()) ||
                employee.LastName.ToLower().Contains(e.NewTextValue.ToLower()));
        }
    }
}